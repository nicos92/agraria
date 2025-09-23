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

        private readonly IHojadeVidaService _hojadeVidaService;

        private Modelo.Entidades.HojadeVida _hojaVidaSeleccionada;

        private readonly ValidadorTextBox _validadorNombre;
        private readonly ValidadorTextBox _validadorPeso;
        private readonly ValidadorTextBox _validadorEstadoSalud;

        private readonly ErrorProvider _errorProviderNombre;
        private readonly ErrorProvider _errorProviderPeso;
        private readonly ErrorProvider _errorProviderEstadoSalud;

        private List<Modelo.Entidades.HojadeVida> _listaHojasVida;

        private int _indiceSeleccionado;

        #endregion

        #region Constructor

        public UCConsultaHojadeVida(IHojadeVidaService hojadeVidaService)
        {
            InitializeComponent();

            // Inyección de dependencias
            _hojadeVidaService = hojadeVidaService;

            // Inicialización de campos
            _hojaVidaSeleccionada = new Modelo.Entidades.HojadeVida();
            _listaHojasVida = [];

            _indiceSeleccionado = -1;

            // Inicialización de validadores y configuración de botones
            _errorProviderNombre = new ErrorProvider();
            _validadorNombre = new ValidadorNombre(TxtNombre, _errorProviderNombre)
            {
                MensajeError = "El nombre debe contener solo letras y espacios, y no puede estar vacío."
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
            ConfigurarDGV();
            var taskHelper = new TareasLargas(
                PanelMedio,
                ProgressBar,
                CargaInicial,
                CargadeDatos);
            taskHelper.Iniciar();
        }

        private void CargadeDatos()
        {
            this.Invoke(
                () =>
                {
                    CargarCMB();
                    CargarDataGrid();
                });
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

            DialogResult dialogResult = MessageBox.Show(
                "¿Está seguro de que desea guardar los cambios en esta hoja de vida?",
                "Confirmación de guardado",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            if (dialogResult != DialogResult.Yes) return;

            if (!CrearHojadeVidaDesdeFormulario())
            {
                return;
            }

            var tarea = new TareasLargas(
                PanelMedio,
                ProgressBar,
                GuardarHojadeVida,
                FinBtnGuardar);
            tarea.Iniciar();
        }

        private void FinBtnGuardar()
        {
            this.Invoke(
                () =>
                {

            ActualizarListas();
            ListBHojasVida.Refresh();
                });

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
                        Utilidades.Util.LimpiarForm(TLPForm, TxtNombre);
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
                _validadorNombre,
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
            var resultado = await _hojadeVidaService.GetAll();

            if (resultado.IsSuccess)
            {
                _listaHojasVida = resultado.Value;
            }
            else
            {
                MostrarMensaje(resultado.Error, "Error al cargar hojas de vida", MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Carga el DataGridView con los datos iniciales.
        /// </summary>
        private void CargarDataGrid()
        {
            this.Invoke(
                () =>
                {
                    CargarHojasVidaDataGridView();
                    if (Utilidades.Util.CalcularDGVVacio(ListBHojasVida, LblLista, "Hojas de Vida"))
                    {
                        Utilidades.Util.LimpiarForm(TLPForm, TxtNombre);
                        Utilidades.Util.BloquearBtns(ListBHojasVida, TLPForm);
                    }
                    else
                    {
                        Utilidades.Util.DesbloquearTLPForm(TLPForm);
                    }
                });
            
        }

        /// <summary>
        /// Carga los datos en los ComboBoxes.
        /// </summary>
        private void CargarCMB()
        {
            this.Invoke(
                () =>
                {
                    // Cargar tipos de animal
                    CMBTipoAnimal.DataSource = Enum.GetValues<TipoAnimal>()
                                           .Select(e => new { Value = e, Display = e.ToString() })
                                           .ToList();
                    CMBTipoAnimal.ValueMember = "Value";
                    CMBTipoAnimal.DisplayMember = "Display";

                    // Cargar sexos
                    CMBSexo.DataSource = Enum.GetValues<Sexo>()
                                       .Select(e => new { Value = e, Display = e.ToString() })
                                       .ToList();
                    CMBSexo.ValueMember = "Value";
                    CMBSexo.DisplayMember = "Display";
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
            if (CMBTipoAnimal.SelectedValue is TipoAnimal tipoAnimal1 && CMBSexo.SelectedValue is Sexo sexo)
            {

                _hojaVidaSeleccionada.Nombre = TxtNombre.Text;
                _hojaVidaSeleccionada.TipoAnimal = tipoAnimal1;
                _hojaVidaSeleccionada.Sexo = sexo;
                _hojaVidaSeleccionada.FechaNacimiento = DTPFechaNacimiento.Value;
                _hojaVidaSeleccionada.Peso = DecimalFormatter.ParseDecimal(TxtPeso.Text);
                _hojaVidaSeleccionada.EstadoSalud = TxtEstadoSalud.Text;
                _hojaVidaSeleccionada.Observaciones = TxtObservaciones.Text;
                _hojaVidaSeleccionada.Activo = ChkActivo.Checked;
                return true;
            }

            return false;
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
                TxtNombre.Text = _hojaVidaSeleccionada.Nombre;
                CMBTipoAnimal.SelectedValue = _hojaVidaSeleccionada.TipoAnimal;
                CMBSexo.SelectedValue = _hojaVidaSeleccionada.Sexo;
                DTPFechaNacimiento.Value = _hojaVidaSeleccionada.FechaNacimiento;
                TxtPeso.Text = DecimalFormatter.ToDecimal(_hojaVidaSeleccionada.Peso);
                TxtEstadoSalud.Text = _hojaVidaSeleccionada.EstadoSalud ?? string.Empty;
                TxtObservaciones.Text = _hojaVidaSeleccionada.Observaciones ?? string.Empty;
                ChkActivo.Checked = _hojaVidaSeleccionada.Activo;
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
            TxtNombre.Clear();
            CMBTipoAnimal.SelectedIndex = 0;
            CMBSexo.SelectedIndex = 0;
            DTPFechaNacimiento.Value = DateTime.Now;
            TxtPeso.Clear();
            TxtEstadoSalud.Clear();
            TxtObservaciones.Clear();
            ChkActivo.Checked = true;

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
            var resultado = await _hojadeVidaService.Update(_hojaVidaSeleccionada);

            if (resultado.IsSuccess)
            {
                MostrarMensaje("Hoja de vida actualizada correctamente", "Éxito", MessageBoxIcon.Information);
            }
            else
            {
                MostrarMensaje(resultado.Error, "Error en la actualización", MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Elimina la hoja de vida seleccionada de forma asíncrona.
        /// </summary>
        private async Task EliminarHojadeVida()
        {
            var resultado = await _hojadeVidaService.Delete(_hojaVidaSeleccionada.Codigo);

            if (resultado.IsSuccess)
            {
                MostrarMensaje("Hoja de vida eliminada correctamente", "Éxito", MessageBoxIcon.Information);
                EliminarDeListas();
            }
            else
            {
                MostrarMensaje(resultado.Error, "Error al eliminar hoja de vida", MessageBoxIcon.Error);
            }
        }

        private void ConfigurarDGV()
        {
            ListBHojasVida.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            ListBHojasVida.AllowUserToAddRows = false;
            ListBHojasVida.AllowUserToDeleteRows = false;
            ListBHojasVida.ReadOnly = true;
            ListBHojasVida.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            ListBHojasVida.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            ListBHojasVida.MultiSelect = false;
            ListBHojasVida.RowHeadersVisible = false;
            ListBHojasVida.AllowUserToResizeRows = false;
            ListBHojasVida.AllowUserToResizeColumns = true;
            ListBHojasVida.AutoGenerateColumns = false;

            // Asegurar que el DataGridView puede recibir el foco y selecciones
            ListBHojasVida.TabStop = true;
            ListBHojasVida.Enabled = true;

            ConfigurarColumnasDataGridView();
        }

        private void ConfigurarColumnasDataGridView()
        {
            ListBHojasVida.Columns.Clear();

            

            var columns = new[]
            {
                new DataGridViewTextBoxColumn
                {
                    Name = "Codigo",
                    DataPropertyName = "Codigo",
                    HeaderText = "Codigo",
                    Visible = true,
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
                },
                new DataGridViewTextBoxColumn
                {
                    Name = "TipoAnimal",
                    DataPropertyName = "TipoAnimal",
                    HeaderText = "Tipo Animal",
                    Width = 200,
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,

                },
                new DataGridViewTextBoxColumn
                {
                    Name = "Sexo",
                    DataPropertyName = "Sexo",
                    HeaderText = "Sexo",
                    Width = 80,
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
                    DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleRight }
                }
            };

            foreach (var column in columns)
            {
                ListBHojasVida.Columns.Add(column);
            }
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
                CargadeDatos);
            taskHelper.Iniciar();
        }
    }
}