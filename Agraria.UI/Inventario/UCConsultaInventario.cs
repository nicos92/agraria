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
using Agraria.Util.Validaciones;
using Agraria.Utilidades;

namespace Agraria.UI.Inventario
{
    [SupportedOSPlatform("windows")]
    public partial class UCConsultaInventario : UserControl
    {
        #region Campos y Servicios

        private readonly IArticulosGralService _articulosService;

        private ArticulosGral _articuloSeleccionado;

        private readonly ValidadorTextBox _validadorNombre;
        private readonly ValidadorTextBox _validadorCantidad;
        private readonly ValidadorTextBox _validadorPrecio;

        private readonly ErrorProvider _errorProviderNombre;
        private readonly ErrorProvider _errorProviderCantidad;
        private readonly ErrorProvider _errorProviderPrecio;

        private List<ArticulosGral> _listaArticulos;

        private int _indiceSeleccionado;

        #endregion

        #region Constructor

        public UCConsultaInventario(IArticulosGralService articulosService)
        {
            InitializeComponent();

            // Inyección de dependencias
            _articulosService = articulosService;

            // Inicialización de campos
            _articuloSeleccionado = new ArticulosGral();

            _listaArticulos = [];

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
            var taskHelper = new TareasLargas(
                PanelMedio,
                ProgressBar,
                CargaInicial,
                CargarDataGrid);
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
            
            DialogResult dialogResult = MessageBox.Show("¿Estas seguro que queres guardar los cambios?","Guardar Cambios", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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
                CargarArticulos()
                
            );
           
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

        #endregion

        private void UCConsultaInventario_VisibleChanged(object sender, EventArgs e)
        {
            if (Visible)
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
}