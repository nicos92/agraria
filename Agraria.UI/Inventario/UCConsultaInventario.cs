using Agraria.Contrato.Servicios;
using Agraria.Modelo.Entidades;
using Agraria.Modelo.Enums;
using Agraria.Servicio.Implementaciones;
using Agraria.Util.Validaciones;
using Agraria.Utilidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Agraria.UI.Inventario
{
	[SupportedOSPlatform("windows")]
	public partial class UCConsultaInventario : UserControl
	{
		#region Campos y Servicios

		private readonly IArticulosGralService _articulosService;
		private readonly IProveedoresService _proveedoresService;

		private ArticulosGral _articuloSeleccionado;

		private readonly ValidadorTextBox _validadorNombre;
		private readonly ValidadorTextBox _validadorCantidad;
		private readonly ValidadorTextBox _validadorPrecio;

		private readonly ErrorProvider _errorProviderNombre;
		private readonly ErrorProvider _errorProviderCantidad;
		private readonly ErrorProvider _errorProviderPrecio;

		private List<ArticulosGral> _listaArticulos;
		private List<Modelo.Entidades.Proveedores> _listaProveedores;

		private int _indiceSeleccionado;

		#endregion

		#region Constructor

		public UCConsultaInventario(IArticulosGralService articulosService, IProveedoresService proveedoresService)
		{
			InitializeComponent();

			// Inyección de dependencias
			_articulosService = articulosService;

			// Inicialización de campos
			_articuloSeleccionado = new ArticulosGral();

			_listaArticulos = [];
			_listaProveedores = [];

			_indiceSeleccionado = -1;

			// Inicialización de validadores y configuración de botones
			// Configuración de validadores con proveedores de error
			_errorProviderNombre = new ErrorProvider();
			_validadorNombre = new ValidadorDireccion(TxtNombre, _errorProviderNombre)
			{
				MensajeError = "El nombre no puede estar vacío"
			};

			_errorProviderCantidad = new ErrorProvider();
			_validadorCantidad = new ValidadorNumeroDecimal(TxtCantidad, _errorProviderCantidad)
			{
				MensajeError = "Número ingresado no válido"
			};

			_errorProviderPrecio = new ErrorProvider();
			_validadorPrecio = new ValidadorNumeroDecimal(TxtPrecio, _errorProviderPrecio)
			{
				MensajeError = "Número ingresado no válido"
			};
			ConfigurarBotones();
			_proveedoresService = proveedoresService;
		}

		/// <summary>
		/// Configura las propiedades iniciales de los botones en el formulario.
		/// </summary>
		private void ConfigurarBotones()
		{
			BtnGuardar.Tag = AppColorsBlue.Tertiary;
			BtnEliminar.Tag = AppColorsBlue.Error;
		}

		#endregion

		#region Eventos de UI

		/// <summary>
		/// Maneja el evento de carga del control de usuario. Inicia la carga de datos iniciales.
		/// </summary>
		/// <param name="sender">El objeto que generó el evento.</param>
		/// <param name="e">Los datos del evento.</param>
		private void UCConsultaInventario_Load(object sender, EventArgs e)
		{
			CargarUnidadesMedida();
			ConfigurarDgv();
			var taskHelper = new TareasLargas(
				PanelMedio,
				ProgressBar,
				CargaInicial,
				CargarCombosYDataGrid);
			taskHelper.Iniciar();
		}


		/// <summary>
		/// Maneja el evento de clic en el botón Guardar. Valida el formulario y guarda los datos del artículo.
		/// </summary>
		/// <param name="sender">El objeto que generó el evento.</param>
		/// <param name="e">Los datos del evento.</param>
		private void BtnGuardar_Click(object sender, EventArgs e)
		{
			if (!ValidarFormulario())
			{
				MostrarMensaje("Por favor, complete todos los campos requeridos correctamente",
							  "Datos incompletos",
							  MessageBoxIcon.Warning);
				return;
			}

			DialogResult dialogResult = MessageBox.Show("¿Estas seguro que queres guardar los cambios?", "Guardar Cambios", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			if (dialogResult == DialogResult.No) return;

			if (!CrearArticuloDesdeFormulario())
			{
				return;
			}

			var tarea = new TareasLargas(
				PanelMedio,
				ProgressBar,
				GuardarArticulo,
				FinBtnGuardar);
			tarea.Iniciar();
		}

		private void FinBtnGuardar()
		{
			this.Invoke(() =>
			{
				ActualizarListas();
				ListBArticulos.Refresh();
			});

		}

		/// <summary>
		/// Maneja el evento de clic en el botón Eliminar. Elimina el artículo seleccionado.
		/// </summary>
		/// <param name="sender">El objeto que generó el evento.</param>
		/// <param name="e">Los datos del evento.</param>
		private void BtnEliminar_Click(object sender, EventArgs e)
		{
			if (!ValidarSeleccionParaEliminar())
			{
				MostrarMensaje("Por favor, seleccione un artículo de la lista para eliminar",
							  "Ningún artículo seleccionado",
							  MessageBoxIcon.Warning);
				return;
			}

			if (!ConfirmarEliminacion()) return;

			var tarea = new TareasLargas(
				PanelMedio,
				ProgressBar,
				EliminarArticulo,
				FinBtnEliminar);
			tarea.Iniciar();
		}

		private void FinBtnEliminar()
		{
			this.Invoke(() =>
			{
				LimpiarFormulario();
				ActualizarDataGridView();
				if (Utilidades.Util.CalcularDGVVacio(ListBArticulos, LblLista, "Articulos"))
				{
					Utilidades.Util.LimpiarForm(TLPForm, TxtNombre);
					Utilidades.Util.BloquearBtns(ListBArticulos, TLPForm);
				}
			});
		}

		/// <summary>
		/// Maneja el evento de cambio de selección en la lista de artículos. Carga los datos del artículo seleccionado en el formulario.
		/// </summary>
		/// <param name="sender">El objeto que generó el evento.</param>
		/// <param name="e">Los datos del evento.</param>
		private void ListBArticulos_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (!HaySeleccionValida())
			{
				LimpiarFormulario();
				return;
			}

			_indiceSeleccionado = ListBArticulos.CurrentRow?.Index ?? -1;

			if (_indiceSeleccionado >= 0 && _indiceSeleccionado < ListBArticulos.Rows.Count)
			{
				CargarFormularioEdicion();
			}
			else
			{
				LimpiarFormulario();
			}
		}

		/// <summary>
		/// Maneja el evento de cambio de texto en el cuadro de texto de nombre. Valida el formulario.
		/// </summary>
		/// <param name="sender">El objeto que generó el evento.</param>
		/// <param name="e">Los datos del evento.</param>
		private void TxtNombre_TextChanged(object sender, EventArgs e)
		{
			BtnGuardar.Enabled = ValidadorMultiple.ValidacionMultiple(

				_validadorNombre,
				_validadorCantidad,
				_validadorPrecio);
		}

		/// <summary>
		/// Maneja los errores de datos en el DataGridView.
		/// </summary>
		/// <param name="sender">El objeto que generó el evento.</param>
		/// <param name="e">Los datos del evento.</param>
		private void ListBArticulos_DataError(object sender, DataGridViewDataErrorEventArgs e)
		{
			e.ThrowException = false;
			// Solución CS8602: Comprobar si Exception es null antes de acceder a Message
			if (e.Exception != null)
			{
				Console.WriteLine($"Error en DataGridView: {e.Exception.Message}");
			}
			else
			{
				Console.WriteLine("Error en DataGridView: excepción desconocida.");
			}
		}

		/// <summary>
		/// Maneja el evento de cambio de estado de habilitación del botón Guardar. Cambia el color de fondo del botón.
		/// </summary>
		/// <param name="sender">El objeto que generó el evento.</param>
		/// <param name="e">Los datos del evento.</param>
		private void BtnGuardar_EnabledChanged(object sender, EventArgs e)
		{
			if (sender is Button btn && btn.Tag is Color color)
			{
				btn.BackColor = btn.Enabled ? color : AppColorsBlue.Secondary;
			}
		}

		#endregion

		#region Métodos de Carga de Datos

		/// <summary>
		/// Realiza la carga inicial de datos de forma asíncrona.
		/// </summary>
		private async Task CargaInicial()
		{
			await Task.WhenAll(
				CargarArticulos(),
				CargarProveedores()

			);

		}

		private async Task CargarProveedores()
		{
			var result = await _proveedoresService.GetAll();
			if (!result.IsSuccess)
			{
				MessageBox.Show($"Ocurrió un error al cargar los proveedores: {result.Error}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}


			_listaProveedores = result.Value;

		}



		/// <summary>
		/// Carga las unidades de medida en el ComboBox correspondiente.
		/// </summary>
		private void CargarUnidadesMedida()
		{
			try
			{
				var unidades = Enum.GetValues<UnidadMedida>()
					.Cast<UnidadMedida>()
					.ToList();

				// Agregar opción "Todos" al principio para el filtro
				var filtroOptions = new[] { new { Value = (UnidadMedida)(-1), Text = "Todos" } }
					.Concat(unidades.Select(u => new { Value = u, Text = u.ToString() }))
					.ToList();

				CmbFiltroUnidadMedida.DataSource = filtroOptions;
				CmbFiltroUnidadMedida.DisplayMember = "Text";
				CmbFiltroUnidadMedida.ValueMember = "Value";
				CmbFiltroUnidadMedida.SelectedIndex = 0; // Seleccionar "Todos" por defecto

				CMBUnidadMedida.DataSource = unidades;
				CMBUnidadMedida.DisplayMember = "ToString";
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Ocurrió un error al cargar las unidades de medida: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		/// <summary>
		/// Carga la lista de artículos desde el servicio de forma asíncrona.
		/// </summary>
		private async Task CargarArticulos()
		{
			var resultado = await _articulosService.GetAll();

			if (resultado.IsSuccess)
			{
				_listaArticulos = resultado.Value;
			}
			else
			{
				MostrarMensaje(resultado.Error, "Error al cargar artículos", MessageBoxIcon.Error);
			}
		}
		private void ConfigurarDgv()
		{
			// Configurar DataGridView de ventas
			ListBArticulos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			ListBArticulos.MultiSelect = false;
			ListBArticulos.ReadOnly = true;
			ListBArticulos.AllowUserToAddRows = false;
			ListBArticulos.AllowUserToDeleteRows = false;
			ListBArticulos.RowHeadersVisible = false;
			ListBArticulos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			ListBArticulos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			ListBArticulos.AllowUserToResizeRows = false;
			ListBArticulos.AllowUserToResizeColumns = true;
			ListBArticulos.AutoGenerateColumns = false;

			// Asegurar que el DataGridView puede recibir el foco y selecciones
			ListBArticulos.TabStop = true;
			ListBArticulos.Enabled = true;
			ConfigurarColumnasDataGridView();
		}

		private void ConfigurarColumnasDataGridView()
		{
			// Limpiar columnas existentes
			ListBArticulos.Columns.Clear();

			// Configurar columnas para DgvVentas
			var ventasColumns = new[]
			{
				new DataGridViewTextBoxColumn
				{
					Name = "Art_Cod",
					DataPropertyName = "Art_Cod",
					HeaderText = "Codigo",
					Visible = true,
					FillWeight = 20f,
					AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
				},
				new DataGridViewTextBoxColumn
				{
					Name = "Art_Nombre",
					DataPropertyName = "Art_Nombre",
					HeaderText = "Nombre",
					Visible = true,
					FillWeight = 30f,
					AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
				},
				new DataGridViewTextBoxColumn
				{
					Name = "Art_Descripcion",
					DataPropertyName = "Art_Descripcion",
					HeaderText = "Descripcion",
					Visible = true,
					AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
				}
			};

			foreach (var column in ventasColumns)
			{
				ListBArticulos.Columns.Add(column);
			}


		}
		/// <summary>
		/// Carga los datos de los artículos en el DataGridView.
		/// </summary>
		private void CargarDataGrid()
		{
			this.Invoke(
				() =>
				{
					try
					{
						CMBProveedor.DataSource = null;
						CMBProveedor.DataSource = _listaProveedores ?? [];
						CMBProveedor.DisplayMember = "Proveedor";
						CMBProveedor.ValueMember = "Id_Proveedor";
						ListBArticulos.SuspendLayout();
						int primeraFilaVisible = ListBArticulos.FirstDisplayedScrollingRowIndex;

						ListBArticulos.AutoGenerateColumns = false;
						ListBArticulos.DataSource = null;
						ListBArticulos.DataSource = _listaArticulos ?? [];



						if (primeraFilaVisible >= 0 && primeraFilaVisible < ListBArticulos.Rows.Count)
						{
							ListBArticulos.FirstDisplayedScrollingRowIndex = primeraFilaVisible;
						}

						// Verificar si hay artículos y activar/desactivar formulario según corresponda
						if (_listaArticulos == null || _listaArticulos.Count == 0)
						{
							// No hay artículos, desactivar formulario
							Utilidades.Util.LimpiarForm(TLPForm, TxtNombre);
							Utilidades.Util.BloquearBtns(ListBArticulos, TLPForm);
						}
						else
						{
							// Hay artículos, activar formulario
							Utilidades.Util.DesbloquearTLPForm(TLPForm);
						}
					}
					catch (Exception ex)
					{
						MostrarMensaje($"Error al cargar DataGridView: {ex.Message}", "Error", MessageBoxIcon.Error);
					}
					finally
					{
						ListBArticulos.ResumeLayout();
					}
				});
		}

		/// <summary>
		/// Carga los ComboBoxes y el DataGridView con los datos iniciales.
		/// </summary>
		private void CargarCombosYDataGrid()
		{
			this.Invoke(
				() =>
				{
					CargarDataGrid();

					// Inicializar controles de filtro
					InicializarControlesFiltro();

					// Verificar si hay artículos y activar/desactivar formulario según corresponda
					if (_listaArticulos == null || _listaArticulos.Count == 0)
					{
						// No hay artículos, desactivar formulario
						Utilidades.Util.LimpiarForm(TLPForm, TxtNombre);
						Utilidades.Util.BloquearBtns(ListBArticulos, TLPForm);
					}
					else
					{
						// Hay artículos, activar formulario
						Utilidades.Util.DesbloquearTLPForm(TLPForm);
					}
				});
		}

		/// <summary>
		/// Inicializa los controles de filtro con los valores correspondientes
		/// </summary>
		private void InicializarControlesFiltro()
		{
			try
			{
				// Limpiar los campos de texto de filtro
				TxtFiltroCodigo.Clear();
				TxtFiltroNombre.Clear();
				TxtFiltroDescripcion.Clear();

				// Seleccionar "Todos" en los ComboBox de filtro
				if (CmbFiltroUnidadMedida.Items.Count > 0)
				{
					CmbFiltroUnidadMedida.SelectedIndex = 0; // "Todos"
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Error al inicializar los controles de filtro: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		#endregion

		#region Métodos de Formulario y Validación

		/// <summary>
		/// Valida los campos del formulario.
		/// </summary>
		/// <returns>True si el formulario es válido, de lo contrario False.</returns>
		private bool ValidarFormulario()
		{
			return _validadorNombre.Validar() &&
				   _validadorCantidad.Validar() &&
				   _validadorPrecio.Validar();
		}

		/// <summary>
		/// Valida si hay un artículo seleccionado para eliminar.
		/// </summary>
		/// <returns>True si hay un artículo seleccionado, de lo contrario False.</returns>
		private bool ValidarSeleccionParaEliminar()
		{
			return _articuloSeleccionado != null && _articuloSeleccionado.Art_Id != 0;
		}

		/// <summary>
		/// Muestra un cuadro de diálogo de confirmación de eliminación.
		/// </summary>
		/// <returns>True si el usuario confirma la eliminación, de lo contrario False.</returns>
		private static bool ConfirmarEliminacion()
		{
			var resultado = MessageBox.Show(
				"¿Está seguro de que desea eliminar este artículo?",
				"Confirmación de eliminación",
				MessageBoxButtons.YesNo,
				MessageBoxIcon.Question);

			return resultado == DialogResult.Yes;
		}

		/// <summary>
		/// Crea o actualiza un objeto de artículo a partir de los datos del formulario.
		/// </summary>
		/// <returns>True si el objeto se creó o actualizó correctamente, de lo contrario False.</returns>
		private bool CrearArticuloDesdeFormulario()
		{
			if (CMBUnidadMedida.SelectedItem is not UnidadMedida unidadMedida)
			{
				MostrarMensaje("La unidad de medida seleccionada no es válida", "Error", MessageBoxIcon.Error);
				return false;
			}

			_articuloSeleccionado.Art_Nombre = TxtNombre.Text;
			_articuloSeleccionado.Art_Stock = DecimalFormatter.ParseDecimal(TxtCantidad.Text);
			_articuloSeleccionado.Art_Precio = DecimalFormatter.ParseDecimal(TxtPrecio.Text);
			_articuloSeleccionado.Art_Descripcion = TxtDescripcion.Text;
			_articuloSeleccionado.Art_Uni_Med = unidadMedida;
			if (CMBProveedor.SelectedValue is int idProveedor)
			{
				_articuloSeleccionado.Id_Proveedor = idProveedor;
			}
			else
			{
				_articuloSeleccionado.Id_Proveedor = 0; // O manejarlo como un valor nulo si es necesario
			}

			return true;
		}

		/// <summary>
		/// Carga los datos del artículo seleccionado en el formulario para su edición.
		/// </summary>
		private void CargarFormularioEdicion()
		{
			if (!HaySeleccionValida() ||
				_indiceSeleccionado < 0 ||
				_indiceSeleccionado >= ListBArticulos.Rows.Count)
			{
				LimpiarFormulario();
				return;
			}

			var fila = ListBArticulos.Rows[_indiceSeleccionado];

			if (fila.DataBoundItem is ArticulosGral articulo)
			{
				_articuloSeleccionado = articulo;

				// Cargar datos en los controles
				TxtNombre.Text = _articuloSeleccionado.Art_Nombre ?? string.Empty;
				TxtCantidad.Text = DecimalFormatter.ToDecimal(_articuloSeleccionado.Art_Stock);
				TxtPrecio.Text = DecimalFormatter.ToDecimal(_articuloSeleccionado.Art_Precio);
				TxtDescripcion.Text = _articuloSeleccionado.Art_Descripcion ?? string.Empty;

				// Cargar combo de unidad de medida
				CMBUnidadMedida.SelectedItem = _articuloSeleccionado.Art_Uni_Med;
				if (_articuloSeleccionado.Id_Proveedor != 0)
				{
					CMBProveedor.SelectedValue = _articuloSeleccionado.Id_Proveedor;
				}
				else
				{
					CMBProveedor.SelectedIndex = -1; // No seleccionado
				}
			}
			else
			{
				LimpiarFormulario();
			}
		}

		/// <summary>
		/// Limpia los campos del formulario y restablece los objetos de artículo seleccionados.
		/// </summary>
		private void LimpiarFormulario()
		{
			this.Invoke(() =>
			{
				TxtNombre.Clear();
				TxtCantidad.Clear();
				TxtPrecio.Clear();
				TxtDescripcion.Clear();

				_articuloSeleccionado = new ArticulosGral();
			});

		}

		/// <summary>
		/// Verifica si hay una selección válida en la lista de artículos.
		/// </summary>
		/// <returns>True si hay una selección válida, de lo contrario False.</returns>
		private bool HaySeleccionValida()
		{
			return ListBArticulos.Rows.Count > 0 && ListBArticulos.SelectedRows.Count > 0;
		}

		#endregion

		#region Métodos de Operaciones de Datos

		/// <summary>
		/// Guarda los cambios en el artículo de forma asíncrona.
		/// </summary>
		private async Task GuardarArticulo()
		{
			var resultado = await _articulosService.Update(_articuloSeleccionado);

			if (resultado.IsSuccess)
			{
				MostrarMensaje("Artículo actualizado correctamente", "Éxito", MessageBoxIcon.Information);
			}
			else
			{
				MostrarMensaje(resultado.Error, "Error en la actualización", MessageBoxIcon.Error);
			}
		}

		/// <summary>
		/// Elimina el artículo seleccionado de forma asíncrona.
		/// </summary>
		private async Task EliminarArticulo()
		{
			var resultado = _articulosService.Delete(_articuloSeleccionado.Art_Id);

			if (resultado.IsSuccess)
			{
				MostrarMensaje("Artículo eliminado correctamente", "Éxito", MessageBoxIcon.Information);
				EliminarDeListas();
			}
			else
			{
				MostrarMensaje(resultado.Error, "Error al eliminar artículo", MessageBoxIcon.Error);
			}
		}

		/// <summary>
		/// Actualiza las listas de artículos.
		/// </summary>
		private void ActualizarListas()
		{
			Utilidades.Util.ActualizarEnLista(_listaArticulos, _articuloSeleccionado);
			CargarDataGrid();
		}

		/// <summary>
		/// Elimina el artículo seleccionado de las listas.
		/// </summary>
		private void EliminarDeListas()
		{
			Utilidades.Util.EliminarDeLista(_listaArticulos, _articuloSeleccionado);
		}

		#endregion

		#region Métodos de UI Helpers

		/// <summary>
		/// Actualiza el DataGridView y borra la selección.
		/// </summary>
		private void ActualizarDataGridView()
		{
			CargarDataGrid();
			ListBArticulos.ClearSelection();
		}

		/// <summary>
		/// Muestra un cuadro de mensaje.
		/// </summary>
		/// <param name="mensaje">El mensaje a mostrar.</param>
		/// <param name="titulo">El título del cuadro de mensaje.</param>
		/// <param name="icono">El icono a mostrar en el cuadro de mensaje.</param>
		private static void MostrarMensaje(string mensaje, string titulo, MessageBoxIcon icono)
		{
			MessageBox.Show(mensaje, titulo, MessageBoxButtons.OK, icono);
		}

		/// <summary>
		/// Maneja los eventos de cambio de texto o selección en los controles de filtro
		/// </summary>
		/// <param name="sender">El objeto que generó el evento</param>
		/// <param name="e">Los datos del evento</param>
		private void Filtros_TextChanged(object sender, EventArgs e)
		{
			FiltrarDatos();
		}

		/// <summary>
		/// Filtra la lista de artículos generales según los valores de los controles de filtro
		/// </summary>
		private void FiltrarDatos()
		{
			try
			{
				// Obtener la lista completa de artículos generales
				var listaCompleta = _listaArticulos ?? [];
				var listaFiltrada = new List<ArticulosGral>();

				foreach (var articulo in listaCompleta)
				{
					bool coincide = true;

					// Filtrar por código
					if (!string.IsNullOrEmpty(TxtFiltroCodigo.Text))
					{
						if (articulo.Art_Cod == null || !articulo.Art_Cod.Contains(TxtFiltroCodigo.Text, StringComparison.CurrentCultureIgnoreCase))
						{
							coincide = false;
						}
					}

					// Filtrar por nombre
					if (coincide && !string.IsNullOrEmpty(TxtFiltroNombre.Text))
					{
						if (articulo.Art_Nombre == null || !articulo.Art_Nombre.Contains(TxtFiltroNombre.Text, StringComparison.CurrentCultureIgnoreCase))
						{
							coincide = false;
						}
					}

					// Filtrar por descripción
					if (coincide && !string.IsNullOrEmpty(TxtFiltroDescripcion.Text))
					{
						if (articulo.Art_Descripcion == null || !articulo.Art_Descripcion.Contains(TxtFiltroDescripcion.Text, StringComparison.CurrentCultureIgnoreCase))
						{
							coincide = false;
						}
					}

					// Filtrar por unidad de medida
					if (coincide && CmbFiltroUnidadMedida.SelectedItem != null && CmbFiltroUnidadMedida.SelectedIndex > 0)
					{
						var itemSeleccionado = CmbFiltroUnidadMedida.SelectedItem;
						if (itemSeleccionado != null)
						{
							var unidadMedidaSeleccionada = (UnidadMedida)CmbFiltroUnidadMedida.SelectedValue;
							// El valor -1 representa "Todos", por lo que no se considera una unidad de medida válida para filtrar
							if (unidadMedidaSeleccionada != (UnidadMedida)(-1) && articulo.Art_Uni_Med != unidadMedidaSeleccionada)
							{
								coincide = false;
							}
						}
					}

					if (coincide)
					{
						listaFiltrada.Add(articulo);
					}
				}

				// Actualizar el DataGridView con la lista filtrada
				ActualizarDataGridViewConFiltros(listaFiltrada);
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Error al filtrar los datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		/// <summary>
		/// Actualiza el DataGridView con la lista filtrada
		/// </summary>
		/// <param name="listaFiltrada">La lista de artículos generales ya filtrada</param>
		private void ActualizarDataGridViewConFiltros(List<ArticulosGral> listaFiltrada)
		{
			try
			{
				// Suspendemos el dibujado para evitar actualizaciones parciales
				ListBArticulos.SuspendLayout();
				ListBArticulos.DataSource = null;

				ListBArticulos.DataSource = listaFiltrada;

				// Aseguramos que las columnas tengan los encabezados correctos
				if (ListBArticulos.Columns["Art_Cod"] != null)
				{
					ListBArticulos.Columns["Art_Cod"]!.HeaderText = "CÓDIGO";
				}

				if (ListBArticulos.Columns["Art_Nombre"] != null)
				{
					ListBArticulos.Columns["Art_Nombre"]!.HeaderText = "NOMBRE";
				}

				if (ListBArticulos.Columns["Art_Descripcion"] != null)
				{
					ListBArticulos.Columns["Art_Descripcion"]!.HeaderText = "DESCRIPCIÓN";
				}

				if (ListBArticulos.Columns["Art_Uni_Med"] != null)
				{
					ListBArticulos.Columns["Art_Uni_Med"]!.HeaderText = "UNIDAD MEDIDA";
				}

				if (ListBArticulos.Columns["Art_Precio"] != null)
				{
					ListBArticulos.Columns["Art_Precio"]!.HeaderText = "PRECIO";
				}

				if (ListBArticulos.Columns["Art_Stock"] != null)
				{
					ListBArticulos.Columns["Art_Stock"]!.HeaderText = "STOCK";
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Error al actualizar el DataGridView: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			finally
			{
				ListBArticulos.ResumeLayout();
			}
		}

		#endregion

		private void UCConsultaInventario_VisibleChanged(object sender, EventArgs e)
		{
			if (Visible)
			{
				ConfigurarDgv();
				var taskHelper = new TareasLargas(
			   PanelMedio,
			   ProgressBar,
			   CargaInicial,
			   CargarCombosYDataGrid);
				taskHelper.Iniciar();
			}
		}
	}
}
