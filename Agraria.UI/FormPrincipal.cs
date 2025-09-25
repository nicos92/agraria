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
            BtnRemitoProduccion.Tag = typeof(FormRemitoProduccion);
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
    }
}
