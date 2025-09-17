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
using Agraria.Contrato.Servicios;
using Agraria.Modelo.Entidades;
using Agraria.Modelo.Enums;
using Agraria.Util;
using Agraria.Util.Validaciones;

namespace Agraria.UI.Inventario
{
    [SupportedOSPlatform("windows")]
    public partial class UCConsultaInventario : UserControl
    {
        #region Campos y Servicios

        private readonly IArticulosService _articulosService;
        private readonly IStockService _stockService;

        private ArticulosGral _articuloSeleccionado;
        private Stock _stockSeleccionado;

        private readonly ValidadorTextBox _validadorNombre;
        private readonly ValidadorTextBox _validadorCantidad;
        private readonly ValidadorTextBox _validadorPrecio;

        private readonly ErrorProvider _errorProviderNombre;
        private readonly ErrorProvider _errorProviderCantidad;
        private readonly ErrorProvider _errorProviderPrecio;

        private List<ArticulosGral> _listaArticulos;
        private List<Stock> _listaStock;

        private int _indiceSeleccionado;

        #endregion

        #region Constructor

        public UCConsultaInventario(
            IArticulosService articulosService,
            IStockService stockService)
        {
            InitializeComponent();

            // Inyección de dependencias
            _articulosService = articulosService;
            _stockService = stockService;

            // Inicialización de campos
            _articuloSeleccionado = new ArticulosGral();
            _stockSeleccionado = new Stock();

            _listaArticulos = [];
            _listaStock = [];

            _indiceSeleccionado = -1;

            // Inicialización de validadores y configuración de botones
            // Configuración de validadores con proveedores de error
            _errorProviderNombre = new ErrorProvider();
            _validadorNombre = new ValidadorDireccion(TxtNombre, _errorProviderNombre)
            {
                MensajeError = "El nombre no puede estar vacío"
            };

            _errorProviderCantidad = new ErrorProvider();
            _validadorCantidad = new ValidadorEntero(TxtCantidad, _errorProviderCantidad)
            {
                MensajeError = "Número ingresado no válido"
            };

            _errorProviderPrecio = new ErrorProvider();
            _validadorPrecio = new ValidadorNumeroDecimal(TxtPrecio, _errorProviderPrecio)
            {
                MensajeError = "Número ingresado no válido"
            };
            ConfigurarBotones();
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
            var taskHelper = new TareasLargas(
                PanelMedio,
                ProgressBar,
                CargaInicial,
                () => {
                    CargarDataGrid();
                    CargarCMB();
                });
            taskHelper.Iniciar();
        }

        /// <summary>
        /// Maneja el evento de clic en el botón Guardar. Valida el formulario y guarda los datos del artículo y stock.
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

            if (!CrearArticuloDesdeFormulario() || !CrearStockDesdeFormulario())
            {
                return;
            }

            var tarea = new TareasLargas(
                PanelMedio,
                ProgressBar,
                GuardarArticuloStock,
                () =>
                {
                    ActualizarListas();
                    ListBArticulos.Refresh();
                });
            tarea.Iniciar();
        }

        /// <summary>
        /// Maneja el evento de clic en el botón Eliminar. Elimina el artículo y stock seleccionados.
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
                EliminarArticuloStock,
                () =>
                {
                    LimpiarFormulario();
                    ActualizarDataGridView();
                    if (Util.Util.CalcularDGVVacio(ListBArticulos, LblLista, "Articulos"))
                    {
                        Util.Util.LimpiarForm(TLPForm, TxtNombre);
                        Util.Util.BloquearBtns(ListBArticulos, TLPForm);
                    }
                });
            tarea.Iniciar();
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
            ValidadorMultiple.ValidacionMultiple(
                BtnGuardar,
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
                CargarStocks()
            );
        }

        /// <summary>
        /// Carga el DataGridView con los datos iniciales.
        /// </summary>
        private void CargarDataGrid()
        {
            CargarArticulosDataGridView();
            if (Util.Util.CalcularDGVVacio(ListBArticulos, LblLista, "Productos"))
            {
                Util.Util.LimpiarForm(TLPForm, TxtNombre);
                Util.Util.BloquearBtns(ListBArticulos, TLPForm);
            }
        }

        /// <summary>
        /// Carga los datos en el ComboBox de unidades de medida.
        /// </summary>
        private void CargarCMB()
        {
            CMBUnidadMedida.DataSource = Enum.GetValues(typeof(UnidadMedida)).Cast<UnidadMedida>().ToList();
        }

        /// <summary>
        /// Carga la lista de artículos desde el servicio de forma asíncrona.
        /// </summary>
        private async Task CargarArticulos()
        {
            // TODO: Implementar la lógica para cargar ArticulosGral desde la base de datos
            // Esta implementación es un placeholder ya que no hay un servicio específico para ArticulosGral
            _listaArticulos = new List<ArticulosGral>();
            
            /*
            var resultado = await _articulosService.GetAll();

            if (resultado.IsSuccess)
            {
                _listaArticulos = resultado.Value;
            }
            else
            {
                MostrarMensaje(resultado.Error, "Error al cargar artículos", MessageBoxIcon.Error);
            }
            */
        }

        /// <summary>
        /// Carga la lista de stocks desde el servicio de forma asíncrona.
        /// </summary>
        private async Task CargarStocks()
        {
            var resultado = await _stockService.GetAll();

            if (resultado.IsSuccess)
            {
                _listaStock = resultado.Value;
            }
            else
            {
                MostrarMensaje(resultado.Error, "Error al cargar stocks", MessageBoxIcon.Error);
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
            _articuloSeleccionado.Art_Nombre = TxtNombre.Text;
            _articuloSeleccionado.Art_Uni_Med = CMBUnidadMedida.SelectedItem?.ToString() ?? UnidadMedida.Unidad.ToString();
            _articuloSeleccionado.Art_Descripcion = TxtDescripcion.Text;

            return true;
        }

        /// <summary>
        /// Crea o actualiza un objeto de stock a partir de los datos del formulario.
        /// </summary>
        /// <returns>True si el objeto se creó o actualizó correctamente, de lo contrario False.</returns>
        private bool CrearStockDesdeFormulario()
        {
            if (string.IsNullOrEmpty(TxtCantidad.Text) ||
                string.IsNullOrEmpty(TxtPrecio.Text))
            {
                MostrarMensaje("Complete todos los campos de stock", "Datos incompletos", MessageBoxIcon.Error);
                return false;
            }

            _stockSeleccionado.Cantidad = Convert.ToInt32(TxtCantidad.Text);
            _stockSeleccionado.Costo = DecimalFormatter.ParseDecimal(TxtPrecio.Text);
            _stockSeleccionado.Ganancia = 0; // No se utiliza en este contexto

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
                // TODO: Implementar la lógica para obtener el stock asociado
                _stockSeleccionado = new Stock();

                // Cargar datos en los controles
                TxtNombre.Text = _articuloSeleccionado.Art_Nombre ?? string.Empty;
                // Seleccionar la unidad de medida en el ComboBox
                if (!string.IsNullOrEmpty(_articuloSeleccionado.Art_Uni_Med))
                {
                    if (Enum.TryParse<UnidadMedida>(_articuloSeleccionado.Art_Uni_Med, out UnidadMedida unidadMedida))
                    {
                        CMBUnidadMedida.SelectedItem = unidadMedida;
                    }
                    else
                    {
                        CMBUnidadMedida.SelectedIndex = 0; // Seleccionar el primero por defecto
                    }
                }
                else
                {
                    CMBUnidadMedida.SelectedIndex = 0; // Seleccionar el primero por defecto
                }
                TxtDescripcion.Text = _articuloSeleccionado.Art_Descripcion ?? string.Empty;
                TxtCantidad.Text = _stockSeleccionado.Cantidad.ToString();
                TxtPrecio.Text = DecimalFormatter.ToDecimal(_stockSeleccionado.Costo);
            }
            else
            {
                LimpiarFormulario();
            }
        }

        /// <summary>
        /// Limpia los campos del formulario y restablece los objetos de artículo y stock seleccionados.
        /// </summary>
        private void LimpiarFormulario()
        {
            TxtNombre.Clear();
            CMBUnidadMedida.SelectedIndex = 0; // Seleccionar el primer elemento por defecto
            TxtDescripcion.Clear();
            TxtCantidad.Clear();
            TxtPrecio.Clear();

            _articuloSeleccionado = new ArticulosGral();
            _stockSeleccionado = new Stock();
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
        /// Guarda los cambios en el artículo y el stock de forma asíncrona.
        /// </summary>
        private async Task GuardarArticuloStock()
        {
            // TODO: Implementar la lógica para guardar ArticulosGral en la base de datos
            // Esta implementación es un placeholder ya que no hay un servicio específico para ArticulosGral
            MessageBox.Show("Funcionalidad pendiente de implementación", "Inventario", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
            /*
            var resultado = await _articuloStockService.Update(_articuloSeleccionado, _stockSeleccionado);

            if (resultado.IsSuccess)
            {
                MostrarMensaje("Artículo actualizado correctamente", "Éxito", MessageBoxIcon.Information);
            }
            else
            {
                MostrarMensaje(resultado.Error, "Error en la actualización", MessageBoxIcon.Error);
            }
            */
        }

        /// <summary>
        /// Elimina el artículo y el stock seleccionados de forma asíncrona.
        /// </summary>
        private async Task EliminarArticuloStock()
        {
            // TODO: Implementar la lógica para eliminar ArticulosGral de la base de datos
            // Esta implementación es un placeholder ya que no hay un servicio específico para ArticulosGral
            MessageBox.Show("Funcionalidad pendiente de implementación", "Inventario", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
            /*
            var resultado = await _articuloStockService.Delete(_articuloSeleccionado, _stockSeleccionado);

            if (resultado.IsSuccess)
            {
                MostrarMensaje("Artículo eliminado correctamente", "Éxito", MessageBoxIcon.Information);
                EliminarDeListas();
            }
            else
            {
                MostrarMensaje(resultado.Error, "Error al eliminar artículo", MessageBoxIcon.Error);
            }
            */
        }

        /// <summary>
        /// Actualiza las listas de artículos y stock.
        /// </summary>
        private void ActualizarListas()
        {
            Util.Util.ActualizarEnLista(_listaArticulos, _articuloSeleccionado);
            Util.Util.ActualizarEnLista(_listaStock, _stockSeleccionado);
            CargarArticulosDataGridView();
        }

        /// <summary>
        /// Elimina el artículo y el stock seleccionados de las listas.
        /// </summary>
        private void EliminarDeListas()
        {
            Util.Util.EliminarDeLista(_listaArticulos, _articuloSeleccionado);
            Util.Util.EliminarDeLista(_listaStock, _stockSeleccionado);
        }

        #endregion

        #region Métodos de UI Helpers

        /// <summary>
        /// Carga los datos de los artículos en el DataGridView.
        /// </summary>
        private void CargarArticulosDataGridView()
        {
            try
            {
                ListBArticulos.SuspendLayout();
                int primeraFilaVisible = ListBArticulos.FirstDisplayedScrollingRowIndex;

                ListBArticulos.AutoGenerateColumns = false;
                ListBArticulos.DataSource = null;
                ListBArticulos.DataSource = _listaArticulos ?? [];

                if (primeraFilaVisible >= 0 && primeraFilaVisible < ListBArticulos.Rows.Count)
                {
                    ListBArticulos.FirstDisplayedScrollingRowIndex = primeraFilaVisible;
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
        }

        /// <summary>
        /// Actualiza el DataGridView y borra la selección.
        /// </summary>
        private void ActualizarDataGridView()
        {
            CargarArticulosDataGridView();
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

        #endregion

        private void UCConsultaInventario_VisibleChanged(object sender, EventArgs e)
        {
            var taskHelper = new TareasLargas(
               PanelMedio,
               ProgressBar,
               CargaInicial,
               CargarDataGrid);
            taskHelper.Iniciar();
        }
    }
}