using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Agraria.Modelo;
using Agraria.UI.Actividad;
using Agraria.UI.Venta;
using Agraria.UI.RemitoProduccion;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Agraria.Utilidades;
using Agraria.UI.Acerca;
using Agraria.Contrato.Repositorios;
using Agraria.Contrato.Servicios;
using Agraria.Servicio;

namespace Agraria.UI
{
	public partial class FormPrincipal : Form
	{
		private readonly ILogger<FormPrincipal> _logger;
		private readonly IServiceProvider _serviceProvider;

		private Button _btnActivo;

		/// <summary>
		/// Inicializa una nueva instancia del formulario principal.
		/// </summary>
		/// <param name="serviceProvider">El proveedor de servicios para la inyección de dependencias.</param>
		/// <param name="logger">El logger para registrar eventos.</param>
		public FormPrincipal(IServiceProvider serviceProvider, ILogger<FormPrincipal> logger)
		{
			_logger = logger;
			_serviceProvider = serviceProvider;
			InitializeComponent();
			_btnActivo = BtnActividad;

			_logger.LogInformation("FormPrincipal inicializado.");
		}

		/// <summary>
		/// Maneja el evento de clic de los botones del menú para abrir el formulario correspondiente.
		/// </summary>
		/// <param name="sender">El objeto que originó el evento (se espera que sea un botón).</param>
		/// <param name="e">Los datos del evento.</param>
		private void BtnActividad_Click(object sender, EventArgs e)
		{
			_logger.LogDebug("BtnActividad_Click iniciado.");

			// Usamos el operador 'is' con patrón para verificar si el 'sender' es un botón
			if (sender is Button btn)
			{
				_logger.LogInformation("Botón {ButtonName} clickeado.", btn.Name);

				// El 'campo' _btnActivo debe ser 'null' en la primera ejecución
				// Esto previene que intente cambiar el color de un botón que no existe
				if (_btnActivo != null)
				{
					ResetearEstiloBoton(_btnActivo);
				}

				// Aplicar el estilo al botón que se acaba de presionar
				AplicarEstiloActivo(btn);

				// Actualizar la referencia del botón activo
				_btnActivo = btn;

				// Comprobar si el 'Tag' del botón es del tipo 'Type'
				if (btn.Tag is Type tipoForm)
				{
					_logger.LogDebug("Seleccionando formulario del tipo: {TypeName}", tipoForm.Name);

					// Seleccionar y mostrar el formulario
					SeleccionarForm(tipoForm);

					// Actualizar el título de la ventana de forma segura
					this.Text = $"Escuela Agraria - {btn.Text}";
					LblModulo.Text = btn.Text;
					_logger.LogInformation("Formulario {TypeName} seleccionado y título actualizado.", tipoForm.Name);
				}
				else
				{
					_logger.LogWarning("El botón {ButtonName} no tiene un Tag válido asignado.", btn.Name);
				}
			}
			else
			{
				_logger.LogWarning("El sender no es un botón válido.");
			}

			_logger.LogDebug("BtnActividad_Click finalizado.");
		}

		/// <summary>
		/// Restablece el estilo visual de un botón a su estado predeterminado.
		/// </summary>
		/// <param name="btn">El botón cuyo estilo se va a restablecer.</param>
		private static void ResetearEstiloBoton(Button btn)
		{
			btn.BackColor = AppColorPalette.Light.Primary;
			btn.ForeColor = AppColorPalette.Light.OnPrimary;
			btn.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
		}

		

		/// <summary>
		/// Aplica el estilo visual de "activo" a un botón.
		/// </summary>
		/// <param name="btn">El botón al que se le aplicará el estilo.</param>
		private static void AplicarEstiloActivo(Button btn)
		{
			btn.BackColor = AppColorPalette.Light.OnPrimaryContainer;
			btn.ForeColor = AppColorPalette.Light.PrimaryContainer;
			btn.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
		}


		/// <summary>
		/// Gestiona la visualización de formularios secundarios dentro del contenedor MDI.
		/// Si un formulario del tipo especificado ya existe, lo muestra. De lo contrario, crea una nueva instancia.
		/// </summary>
		/// <param name="tipoForm">El tipo (Type) del formulario que se debe mostrar.</param>
		private void SeleccionarForm(Type tipoForm)
		{
			_logger.LogDebug("Iniciando SeleccionarForm para el tipo: {TypeName}", tipoForm?.Name ?? "null");

			// 1. Validar el tipo de formulario antes de cualquier operación
			if (tipoForm == null || !typeof(Form).IsAssignableFrom(tipoForm))
			{
				_logger.LogWarning("Tipo de formulario no válido o nulo proporcionado.");
				// Puedes agregar un log aquí o simplemente salir
				return;
			}

			// 2. Optimizar el cierre de formularios
			// Utilizar una versión moderna del bucle para mejor legibilidad
			foreach (var childForm in MdiChildren)
			{
				// 3. Ocultar en lugar de cerrar para reutilizar formularios
				if (childForm.GetType() == tipoForm)
				{
					_logger.LogDebug("Formulario {TypeName} ya existe, mostrando.", tipoForm.Name);

					// Si el formulario ya está abierto, solo lo mostramos y terminamos
					childForm.Show();
					return;
				}
				else
				{
					// Ocultamos los demás
					childForm.Hide();
				}
			}

			// 4. Crear el formulario si no estaba abierto
			// Usar 'var' para inferencia de tipo hace el código más limpio
			_logger.LogDebug("Creando nueva instancia del formulario {TypeName}", tipoForm.Name);

			// 5. Configurar el nuevo formulario
			try
			{
				if (_serviceProvider.GetRequiredService(tipoForm) is Form form)
				{
					form.MdiParent = this;
					form.FormBorderStyle = FormBorderStyle.None; // Asegura que no se muestre la barra de títulos del formulario
					form.Dock = DockStyle.Fill; // Establece el formulario en lleno
					form.Show();
					_logger.LogInformation("Formulario {TypeName} creado y mostrado exitosamente.", tipoForm.Name);
				}
				else
				{
					_logger.LogError("No se pudo crear una instancia válida del formulario {TypeName}.", tipoForm.Name);
				}
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Error al crear o mostrar el formulario {TypeName}", tipoForm.Name);
				throw;
			}
		}

		/// <summary>
		/// Maneja el evento de carga del formulario principal.
		/// </summary>
		/// <param name="sender">El objeto que originó el evento.</param>
		/// <param name="e">Los datos del evento.</param>
		private void FormPrincipal_Load(object sender, EventArgs e)
		{
			_logger.LogInformation("FormPrincipal_Load iniciado.");
			
			ConfigBtnsMenu();
			ConfigUsuario();
			BtnActividad_Click(_btnActivo, e);
			AplicarVistadeBotones();
			_logger.LogInformation("FormPrincipal_Load finalizado.");
		}

		private void ConfigUsuario()
		{
			_logger.LogDebug("Configurando información de usuario.");
			try
			{
				LblUsuario.Text = SessionManager.Instance.Usuario.Apellido + ", " + SessionManager.Instance.Usuario.Nombre;
				LblTipoUsuario.Text = SessionManager.Instance.Usuario.Descripcion;
				_logger.LogInformation("Información de usuario configurada exitosamente para: {Apellido}, {Nombre}",
					SessionManager.Instance.Usuario.Apellido, SessionManager.Instance.Usuario.Nombre);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Error al configurar la información de usuario.");
				throw;
			}
		}

		/// <summary>
		/// Configura la propiedad 'Tag' de cada botón del menú con el tipo de formulario que debe abrir.
		/// </summary>
		private void ConfigBtnsMenu()
		{
			_logger.LogDebug("Configurando tags de botones del menú.");

			BtnActividad.Tag = typeof(Actividad.FormActividad);
			BtnProductos.Tag = typeof(Articulos.FormArticulos);
			BtnHojaVida.Tag = typeof(HojadeVida.FormHojadeVida);
			BtnInventario.Tag = typeof(Inventario.FormInventario);
			BtnVenta.Tag = typeof(FormVentaPrincipal);
			BtnProduccion.Tag = typeof(FormRemitoProduccion);
			BtnReporte.Tag = typeof(Reporte.FormReporte);
			BtnUsuarios.Tag = typeof(Usuarios.FormUsuarios);
			BtnProveedores.Tag = typeof(Proveedores.FormProveedores);
			BtnPaniol.Tag = typeof(Paniol.FormPaniol);
			BtnEntornos.Tag = typeof(EntornoFormativo.FormEntornoFormativo);

			_logger.LogInformation("Tags de botones del menú configurados exitosamente.");
		}

		/// <summary>
		/// Maneja el evento de cierre del formulario principal para limpiar los datos de sesión.
		/// </summary>
		/// <param name="sender">El objeto que originó el evento.</param>
		/// <param name="e">Los datos del evento.</param>
		private void FormPrincipal_FormClosing(object sender, FormClosingEventArgs e)
		{
			_logger.LogInformation("FormPrincipal_FormClosing iniciado. Limpiando sesión.");
			SessionManager.Instance.ClearSession();
			_logger.LogInformation("Sesión limpiada exitosamente.");
		}

		private void cerrarToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void CopiarToolStripMenuItem_Click(object sender, EventArgs e)
		{
			// Llama a una función auxiliar para encontrar el control activo
			Control controlConFoco = FindFocusedControl(this);

			// Intenta copiar según el tipo de control
			if (controlConFoco is TextBoxBase textBox)
			{
				// Esto cubre TextBox, RichTextBox
				textBox.Copy();
			}
			else if (controlConFoco is DataGridView dataGridView)
			{
				// Copia las celdas seleccionadas en un DataGridView
				// (el método .GetClipboardContent() es común para esto)
				System.Windows.Forms.SendKeys.Send("^c"); // Simula Ctrl+C
			}
			// Puedes agregar más tipos de controles aquí (ej. MaskedTextBox)
		}

		// Función auxiliar que busca recursivamente el control con el foco.
		private Control FindFocusedControl(Control parent)
		{
			// Caso base: si el control padre es el que tiene el foco, lo devuelve.
			if (parent.Focused)
			{
				return parent;
			}

			// Recorre todos los controles dentro del control padre
			foreach (Control child in parent.Controls)
			{
				// 1. Si el control hijo es el activo (tiene el foco).
				if (child.Focused)
				{
					return child;
				}

				// 2. Si el control hijo es un contenedor (Form, UserControl, Panel, etc.),
				// busca recursivamente dentro de él.
				if (child.ContainsFocus)
				{
					Control focusedChild = FindFocusedControl(child);
					if (focusedChild != null)
					{
						return focusedChild;
					}
				}
			}

			return null; // No se encontró ningún control con foco en esta rama
		}

		private void cortarToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Control controlConFoco = FindFocusedControl(this);

			if (controlConFoco is TextBoxBase textBox)
			{
				// El método Cut() funciona para TextBox y RichTextBox
				textBox.Cut();
			}
			// Para DataGridView, puedes simular Ctrl+X si es necesario:
			// else if (controlConFoco is DataGridView) { System.Windows.Forms.SendKeys.Send("^x"); }
		}

		private void pegarToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Control controlConFoco = FindFocusedControl(this);

			if (controlConFoco is TextBoxBase textBox)
			{
				// El método Paste() funciona para TextBox y RichTextBox
				textBox.Paste();
			}
			// Para DataGridView, puedes simular Ctrl+V si es necesario:
			// else if (controlConFoco is DataGridView) { System.Windows.Forms.SendKeys.Send("^v"); }
		}

		private void deshacerToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Control controlConFoco = FindFocusedControl(this);

			if (controlConFoco is TextBoxBase textBox)
			{
				// El método Undo() funciona para TextBox y RichTextBox
				textBox.Undo();
			}
		}

		private void copiarToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			Control controlConFoco = FindFocusedControl(this);

			// Rehacer solo es compatible con RichTextBox
			if (controlConFoco is RichTextBox richTextBox)
			{
				richTextBox.Redo();
			}
			else
			{
				// Opcionalmente, podrías mostrar un mensaje o deshabilitar
				// el ToolStripMenuItem si el control activo no lo soporta.
				// MessageBox.Show("Rehacer no es compatible con este control.");
			}
		}

		private void ediciónToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
		{

			Control controlConFoco = FindFocusedControl(this);

			// Condición para Cortar y Copiar
			if (controlConFoco is TextBoxBase textBox)
			{
				bool hasSelection = textBox.SelectionLength > 0;
				cortarToolStripMenuItem.Enabled = hasSelection;
				// Ya que el código de Copiar es idéntico al de Cortar
				// copiarToolStripMenuItem.Enabled = hasSelection; 

				// Condición para Deshacer
				deshacerToolStripMenuItem.Enabled = textBox.CanUndo;
			}
			else
			{
				// Si no es un control de texto base, deshabilitar por defecto
				cortarToolStripMenuItem.Enabled = false;
				deshacerToolStripMenuItem.Enabled = false;
			}

			// Condición para Pegar (independiente del tipo de control de texto)
			pegarToolStripMenuItem.Enabled = Clipboard.ContainsText();

			// Condición especial para Rehacer (solo RichTextBox)
			if (controlConFoco is RichTextBox richTextBox)
			{
				// RichTextBox no tiene una propiedad CanRedo directa, se asume que si soporta Undo lo soporta.
				// Por simplicidad, lo habilitamos si el control activo es un RichTextBox.
				rehacerToolStripMenuItem.Enabled = true;
			}
			else
			{
				rehacerToolStripMenuItem.Enabled = false;
			}
		}

		private void sobreNosotrosToolStripMenuItem_Click(object sender, EventArgs e)
		{
			FormAcercaDe formAcercaDe = new FormAcercaDe();
			formAcercaDe.ShowDialog();
		}

		private void fuenteToolStripMenuItem_Click(object sender, EventArgs e)
		{
			// 1. Crear y configurar el FontDialog
			using (FontDialog fd = new FontDialog())
			{
				// Mostrar la fuente actual del formulario como valor predeterminado
				fd.Font = this.Font;
				fd.ShowColor = false; // Solo necesitamos el tipo y el tamaño

				if (fd.ShowDialog() == DialogResult.OK)
				{
					// 2. Llamar al método estático para aplicar la nueva fuente
					// Pasamos la fuente seleccionada y una referencia al formulario principal (this).
					FontManager.AplicarNuevaFuente(fd.Font, this);

					// Opcional: Establecer también la fuente del Formulario principal
					this.Font = fd.Font;
				}
			}
		}

		private void AplicarVistadeBotones()
		{
			BtnActividad.Visible = ControlDeAccesos.PuedeVer(SingleListas.Instance.UsuariosTipos[2].Tipo);

			BtnEntornos.Visible = ControlDeAccesos.PuedeVer(2);

			BtnHojaVida.Visible = ControlDeAccesos.PuedeVer(2);

			BtnInventario.Visible = ControlDeAccesos.PuedeVer(3);
		}
	}
}
