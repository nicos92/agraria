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

namespace Agraria.UI.HojadeVida
{
    [SupportedOSPlatform("windows")]
    public partial class UCConsultaHojadeVida : UserControl
    {
        #region Campos y Servicios

        //private readonly IHojadeVidaService _hojadeVidaService;

        private Modelo.Entidades.HojadeVida _hojaVidaSeleccionada;

        private readonly ValidadorTextBox _validadorCodigo;
        private readonly ValidadorTextBox _validadorPeso;
        private readonly ValidadorTextBox _validadorEstadoSalud;

        private readonly ErrorProvider _errorProviderCodigo;
        private readonly ErrorProvider _errorProviderPeso;
        private readonly ErrorProvider _errorProviderEstadoSalud;

        private List<Modelo.Entidades.HojadeVida> _listaHojasVida;

        private int _indiceSeleccionado;

        #endregion

        #region Constructor

        public UCConsultaHojadeVida()
        {
            InitializeComponent();

            // Inyección de dependencias
            //_hojadeVidaService = hojadeVidaService;

            // Inicialización de campos
            _hojaVidaSeleccionada = new Modelo.Entidades.HojadeVida();
            _listaHojasVida = [];

            _indiceSeleccionado = -1;

            // Inicialización de validadores y configuración de botones
            _errorProviderCodigo = new ErrorProvider();
            _validadorCodigo = new ValidadorEntero(TxtCodigo, _errorProviderCodigo)
            {
                MensajeError = "El código debe ser un número válido"
            };

            _errorProviderPeso = new ErrorProvider();
            _validadorPeso = new ValidadorNumeroDecimal(TxtPeso, _errorProviderPeso)
            {
                MensajeError = "El peso debe ser un número válido"
            };

            _errorProviderEstadoSalud = new ErrorProvider();
            _validadorEstadoSalud = new ValidadorDireccion(TxtEstadoSalud, _errorProviderEstadoSalud)
            {
                MensajeError = "El estado de salud no puede estar vacío"
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
        private void UCConsultaHojadeVida_Load(object sender, EventArgs e)
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
        /// Maneja el evento de clic en el botón Guardar. Valida el formulario y guarda los datos de la hoja de vida.
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

            if (!CrearHojadeVidaDesdeFormulario())
            {
                return;
            }

            var tarea = new TareasLargas(
                PanelMedio,
                ProgressBar,
                GuardarHojadeVida,
                () =>
                {
                    ActualizarListas();
                    ListBHojasVida.Refresh();
                });
            tarea.Iniciar();
        }

        /// <summary>
        /// Maneja el evento de clic en el botón Eliminar. Elimina la hoja de vida seleccionada.
        /// </summary>
        /// <param name="sender">El objeto que generó el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (!ValidarSeleccionParaEliminar())
            {
                MostrarMensaje("Por favor, seleccione una hoja de vida de la lista para eliminar",
                              "Ninguna hoja de vida seleccionada",
                              MessageBoxIcon.Warning);
                return;
            }

            if (!ConfirmarEliminacion()) return;

            var tarea = new TareasLargas(
                PanelMedio,
                ProgressBar,
                EliminarHojadeVida,
                () =>
                {
                    LimpiarFormulario();
                    ActualizarDataGridView();
                    if (Utilidades.Util.CalcularDGVVacio(ListBHojasVida, LblLista, "Hojas de Vida"))
                    {
                        Utilidades.Util.LimpiarForm(TLPForm, TxtCodigo);
                        Utilidades.Util.BloquearBtns(ListBHojasVida, TLPForm);
                    }
                });
            tarea.Iniciar();
        }

        /// <summary>
        /// Maneja el evento de cambio de selección en la lista de hojas de vida. Carga los datos de la hoja seleccionada en el formulario.
        /// </summary>
        /// <param name="sender">El objeto que generó el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void ListBHojasVida_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!HaySeleccionValida())
            {
                LimpiarFormulario();
                return;
            }

            _indiceSeleccionado = ListBHojasVida.CurrentRow?.Index ?? -1;

            if (_indiceSeleccionado >= 0 && _indiceSeleccionado < ListBHojasVida.Rows.Count)
            {
                CargarFormularioEdicion();
            }
            else
            {
                LimpiarFormulario();
            }
        }

        /// <summary>
        /// Maneja el evento de cambio de texto en el cuadro de texto de código. Valida el formulario.
        /// </summary>
        /// <param name="sender">El objeto que generó el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void TxtCodigo_TextChanged(object sender, EventArgs e)
        {
            ValidadorMultiple.ValidacionMultiple(
                BtnGuardar,
                _validadorCodigo,
                _validadorPeso,
                _validadorEstadoSalud);
        }

        /// <summary>
        /// Maneja los errores de datos en el DataGridView.
        /// </summary>
        /// <param name="sender">El objeto que generó el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void ListBHojasVida_DataError(object sender, DataGridViewDataErrorEventArgs e)
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
            await CargarHojasVida();
        }

        /// <summary>
        /// Carga la lista de hojas de vida desde el servicio de forma asíncrona.
        /// </summary>
        private async Task CargarHojasVida()
        {
            // TODO: Implementar la lógica para cargar Hojas de Vida desde la base de datos
            // Esta implementación es un placeholder ya que no hay un servicio específico para HojadeVida
            _listaHojasVida = [];

            /*
            var resultado = await _hojadeVidaService.GetAll();

            if (resultado.IsSuccess)
            {
                _listaHojasVida = resultado.Value;
            }
            else
            {
                MostrarMensaje(resultado.Error, "Error al cargar hojas de vida", MessageBoxIcon.Error);
            }
            */
        }

        /// <summary>
        /// Carga el DataGridView con los datos iniciales.
        /// </summary>
        private void CargarDataGrid()
        {
            CargarHojasVidaDataGridView();
            if (Utilidades.Util.CalcularDGVVacio(ListBHojasVida, LblLista, "Hojas de Vida"))
            {
                Utilidades.Util.LimpiarForm(TLPForm, TxtCodigo);
                Utilidades.Util.BloquearBtns(ListBHojasVida, TLPForm);
            }
        }

        /// <summary>
        /// Carga los datos en los ComboBoxes.
        /// </summary>
        private void CargarCMB()
        {
            // Cargar tipos de animal
            CMBTipoAnimal.DataSource = Enum.GetValues<TipoAnimal>().Cast<TipoAnimal>().ToList();

            // Cargar sexos
            CMBSexo.DataSource = Enum.GetValues<Sexo>().Cast<Sexo>().ToList();
        }

        #endregion

        #region Métodos de Formulario y Validación

        /// <summary>
        /// Valida los campos del formulario.
        /// </summary>
        /// <returns>True si el formulario es válido, de lo contrario False.</returns>
        private bool ValidarFormulario()
        {
            return _validadorCodigo.Validar() &&
                   _validadorPeso.Validar() &&
                   _validadorEstadoSalud.Validar();
        }

        /// <summary>
        /// Valida si hay una hoja de vida seleccionada para eliminar.
        /// </summary>
        /// <returns>True si hay una hoja de vida seleccionada, de lo contrario False.</returns>
        private bool ValidarSeleccionParaEliminar()
        {
            return _hojaVidaSeleccionada != null && _hojaVidaSeleccionada.Codigo != 0;
        }

        /// <summary>
        /// Muestra un cuadro de diálogo de confirmación de eliminación.
        /// </summary>
        /// <returns>True si el usuario confirma la eliminación, de lo contrario False.</returns>
        private static bool ConfirmarEliminacion()
        {
            var resultado = MessageBox.Show(
                "¿Está seguro de que desea eliminar esta hoja de vida?",
                "Confirmación de eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            return resultado == DialogResult.Yes;
        }

        /// <summary>
        /// Crea o actualiza un objeto de hoja de vida a partir de los datos del formulario.
        /// </summary>
        /// <returns>True si el objeto se creó o actualizó correctamente, de lo contrario False.</returns>
        private bool CrearHojadeVidaDesdeFormulario()
        {
            _hojaVidaSeleccionada.Codigo = Convert.ToInt32(TxtCodigo.Text);
            _hojaVidaSeleccionada.TipoAnimal = (TipoAnimal)CMBTipoAnimal.SelectedItem;
            _hojaVidaSeleccionada.Sexo = (Sexo)CMBSexo.SelectedItem;
            _hojaVidaSeleccionada.FechaNacimiento = DTPFechaNacimiento.Value;
            _hojaVidaSeleccionada.Peso = DecimalFormatter.ParseDecimal(TxtPeso.Text);
            _hojaVidaSeleccionada.EstadoSalud = TxtEstadoSalud.Text;
            _hojaVidaSeleccionada.Observaciones = TxtObservaciones.Text;

            return true;
        }

        /// <summary>
        /// Carga los datos de la hoja de vida seleccionada en el formulario para su edición.
        /// </summary>
        private void CargarFormularioEdicion()
        {
            if (!HaySeleccionValida() ||
                _indiceSeleccionado < 0 ||
                _indiceSeleccionado >= ListBHojasVida.Rows.Count)
            {
                LimpiarFormulario();
                return;
            }

            var fila = ListBHojasVida.Rows[_indiceSeleccionado];

            if (fila.DataBoundItem is Modelo.Entidades.HojadeVida hojaVida)
            {
                _hojaVidaSeleccionada = hojaVida;

                // Cargar datos en los controles
                TxtCodigo.Text = _hojaVidaSeleccionada.Codigo.ToString();
                CMBTipoAnimal.SelectedItem = _hojaVidaSeleccionada.TipoAnimal;
                CMBSexo.SelectedItem = _hojaVidaSeleccionada.Sexo;
                DTPFechaNacimiento.Value = _hojaVidaSeleccionada.FechaNacimiento;
                TxtPeso.Text = DecimalFormatter.ToDecimal(_hojaVidaSeleccionada.Peso);
                TxtEstadoSalud.Text = _hojaVidaSeleccionada.EstadoSalud ?? string.Empty;
                TxtObservaciones.Text = _hojaVidaSeleccionada.Observaciones ?? string.Empty;
            }
            else
            {
                LimpiarFormulario();
            }
        }

        /// <summary>
        /// Limpia los campos del formulario y restablece el objeto de hoja de vida seleccionada.
        /// </summary>
        private void LimpiarFormulario()
        {
            TxtCodigo.Clear();
            CMBTipoAnimal.SelectedIndex = 0;
            CMBSexo.SelectedIndex = 0;
            DTPFechaNacimiento.Value = DateTime.Now;
            TxtPeso.Clear();
            TxtEstadoSalud.Clear();
            TxtObservaciones.Clear();

            _hojaVidaSeleccionada = new Modelo.Entidades.HojadeVida();
        }

        /// <summary>
        /// Verifica si hay una selección válida en la lista de hojas de vida.
        /// </summary>
        /// <returns>True si hay una selección válida, de lo contrario False.</returns>
        private bool HaySeleccionValida()
        {
            return ListBHojasVida.Rows.Count > 0 && ListBHojasVida.SelectedRows.Count > 0;
        }

        #endregion

        #region Métodos de Operaciones de Datos

        /// <summary>
        /// Guarda los cambios en la hoja de vida de forma asíncrona.
        /// </summary>
        private async Task GuardarHojadeVida()
        {
            // TODO: Implementar la lógica para guardar HojadeVida en la base de datos
            // Esta implementación es un placeholder ya que no hay un servicio específico para HojadeVida
            MessageBox.Show("Funcionalidad pendiente de implementación", "Hoja de Vida", MessageBoxButtons.OK, MessageBoxIcon.Information);

            /*
            var resultado = await _hojadeVidaService.Update(_hojaVidaSeleccionada);

            if (resultado.IsSuccess)
            {
                MostrarMensaje("Hoja de vida actualizada correctamente", "Éxito", MessageBoxIcon.Information);
            }
            else
            {
                MostrarMensaje(resultado.Error, "Error en la actualización", MessageBoxIcon.Error);
            }
            */
        }

        /// <summary>
        /// Elimina la hoja de vida seleccionada de forma asíncrona.
        /// </summary>
        private async Task EliminarHojadeVida()
        {
            // TODO: Implementar la lógica para eliminar HojadeVida de la base de datos
            // Esta implementación es un placeholder ya que no hay un servicio específico para HojadeVida
            MessageBox.Show("Funcionalidad pendiente de implementación", "Hoja de Vida", MessageBoxButtons.OK, MessageBoxIcon.Information);

            /*
            var resultado = await _hojadeVidaService.Delete(_hojaVidaSeleccionada);

            if (resultado.IsSuccess)
            {
                MostrarMensaje("Hoja de vida eliminada correctamente", "Éxito", MessageBoxIcon.Information);
                EliminarDeListas();
            }
            else
            {
                MostrarMensaje(resultado.Error, "Error al eliminar hoja de vida", MessageBoxIcon.Error);
            }
            */
        }

        /// <summary>
        /// Actualiza las listas de hojas de vida.
        /// </summary>
        private void ActualizarListas()
        {
            Utilidades.Util.ActualizarEnLista(_listaHojasVida, _hojaVidaSeleccionada);
            CargarHojasVidaDataGridView();
        }

        /// <summary>
        /// Elimina la hoja de vida seleccionada de las listas.
        /// </summary>
        private void EliminarDeListas()
        {
            Utilidades.Util.EliminarDeLista(_listaHojasVida, _hojaVidaSeleccionada);
        }

        #endregion

        #region Métodos de UI Helpers

        /// <summary>
        /// Carga los datos de las hojas de vida en el DataGridView.
        /// </summary>
        private void CargarHojasVidaDataGridView()
        {
            try
            {
                ListBHojasVida.SuspendLayout();
                int primeraFilaVisible = ListBHojasVida.FirstDisplayedScrollingRowIndex;

                ListBHojasVida.AutoGenerateColumns = false;
                ListBHojasVida.DataSource = null;
                ListBHojasVida.DataSource = _listaHojasVida ?? [];

                if (primeraFilaVisible >= 0 && primeraFilaVisible < ListBHojasVida.Rows.Count)
                {
                    ListBHojasVida.FirstDisplayedScrollingRowIndex = primeraFilaVisible;
                }
            }
            catch (Exception ex)
            {
                MostrarMensaje($"Error al cargar DataGridView: {ex.Message}", "Error", MessageBoxIcon.Error);
            }
            finally
            {
                ListBHojasVida.ResumeLayout();
            }
        }

        /// <summary>
        /// Actualiza el DataGridView y borra la selección.
        /// </summary>
        private void ActualizarDataGridView()
        {
            CargarHojasVidaDataGridView();
            ListBHojasVida.ClearSelection();
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

        private void UCConsultaHojadeVida_VisibleChanged(object sender, EventArgs e)
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
    }
}