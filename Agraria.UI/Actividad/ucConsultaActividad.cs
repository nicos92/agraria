using Agraria.Contrato.Servicios;
using Agraria.Modelo.Entidades;
using Agraria.Utilidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Agraria.UI.Actividad
{
    public partial class ucConsultaActividad : UserControl
    {
        #region Campos y Servicios

        private readonly IActividadService _actividadService;
        private readonly ITipoEntornosService _tipoEntornoService;
        private readonly IEntornoService _entornoService;
        private readonly IEntornoFormativoService _entornoFormativoService;

        private Modelo.Entidades.Actividad _actividadSeleccionada;

        private List<TipoEntorno> _listaTipoEntorno;
        private List<Entorno> _listaEntorno;
        private List<Modelo.Entidades.EntornoFormativo> _listaEntornoFormativo;
        private List<Modelo.Entidades.Actividad> _listaActividades;

        private int _indiceSeleccionado;

        #endregion

        public ucConsultaActividad(IActividadService actividadService, ITipoEntornosService tipoEntornoService, IEntornoService entornoService, IEntornoFormativoService entornoFormativoService)
        {
            InitializeComponent();

            // Inyección de dependencias
            _actividadService = actividadService;
            _tipoEntornoService = tipoEntornoService;
            _entornoService = entornoService;
            _entornoFormativoService = entornoFormativoService;

            // Inicialización de campos
            _actividadSeleccionada = new Modelo.Entidades.Actividad();

            _listaTipoEntorno = [];
            _listaEntorno = [];
            _listaEntornoFormativo = [];
            _listaActividades = [];

            _indiceSeleccionado = -1;

            // Configurar el DataGridView
            ConfigurarDGV();

           
        }

        private void ucConsultaActividad_Load(object sender, EventArgs e)
        {
            var taskHelper = new TareasLargas(PanelMedio, ProgressBar, CargaInicial, CargarGrilla);
            taskHelper.Iniciar();
        }

        private async Task CargaInicial()
        {
            await Task.WhenAll(
                CargarActividades(),
                CargarTipoEntornos(),
                CargarEntornos(),
                CargarEntornosFormativos()
            );
        }

        private async Task CargarActividades()
        {
            var resultado = await _actividadService.GetAll();
            if (resultado.IsSuccess)
            {
                _listaActividades = resultado.Value;
            }
            else
            {
                MessageBox.Show(resultado.Error, "Error al cargar actividades", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task CargarTipoEntornos()
        {
            var resultado = await _tipoEntornoService.GetAll();
            if (resultado.IsSuccess)
            {
                _listaTipoEntorno = resultado.Value;
            }
            else
            {
                MessageBox.Show(resultado.Error, "Error al cargar tipos de entorno", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task CargarEntornos()
        {
            var resultado = await _entornoService.GetAll();
            if (resultado.IsSuccess)
            {
                _listaEntorno = resultado.Value;
            }
            else
            {
                MessageBox.Show(resultado.Error, "Error al cargar entornos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task CargarEntornosFormativos()
        {
            var resultado = await _entornoFormativoService.GetAll();
            if (resultado.IsSuccess)
            {
                _listaEntornoFormativo = resultado.Value;
            }
            else
            {
                MessageBox.Show(resultado.Error, "Error al cargar entornos formativos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarGrilla()
        {
            this.Invoke(
                () =>
                {
                    // Configurar la fuente de datos del DataGridView
                    ListBArticulos.DataSource = _listaActividades;

                    // Configurar combo principal (Tipo Entorno)
                    CMBTipoEntorno.DataSource = _listaTipoEntorno ?? [];
                    CMBTipoEntorno.DisplayMember = "Tipo_Entorno";
                    CMBTipoEntorno.ValueMember = "Id_Tipo_Entorno";

                    // Verificar si hay actividades y activar/desactivar formulario según corresponda
                    if (_listaActividades == null || _listaActividades.Count == 0)
                    {
                        // No hay actividades, desactivar formulario
                        Utilidades.Util.LimpiarForm(TLPForm, TxtDescripcion);
                        Utilidades.Util.BloquearBtns(ListBArticulos, TLPForm);
                    }
                    else
                    {
                        // Hay actividades, activar formulario
                        Utilidades.Util.DesbloquearTLPForm(TLPForm);
                    }
                });
        }

        private void ConfigurarDGV()
        {
            ListBArticulos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            ListBArticulos.AllowUserToAddRows = false;
            ListBArticulos.AllowUserToDeleteRows = false;
            ListBArticulos.ReadOnly = true;
            ListBArticulos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            ListBArticulos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            ListBArticulos.MultiSelect = false;
            ListBArticulos.RowHeadersVisible = false;
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
            ListBArticulos.Columns.Clear();

            var columns = new[]
            {
                new DataGridViewTextBoxColumn
                {
                    Name = "Id_Actividad",
                    DataPropertyName = "Id_Actividad",
                    HeaderText = "ID",
                    Visible = false
                },
                new DataGridViewTextBoxColumn
                {
                    Name = "Fecha_Actividad",
                    DataPropertyName = "Fecha_Actividad",
                    HeaderText = "Fecha y Hora",
                    Width = 150,
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
                },
                new DataGridViewTextBoxColumn
                {
                    Name = "Descripcion_Actividad",
                    DataPropertyName = "Descripcion_Actividad",
                    HeaderText = "Descripción",
                    Width = 200,
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                }
            };

            foreach (var column in columns)
            {
                ListBArticulos.Columns.Add(column);
            }
        }


        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidarFormulario())
            {
                MessageBox.Show("Por favor, complete todos los campos requeridos correctamente",
                              "Datos incompletos",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult dialogResult = MessageBox.Show("¿Estás seguro que quieres guardar los cambios?", "Guardar Cambios", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.No) return;

            if (!CrearActividadDesdeFormulario())
            {
                return;
            }

            var tarea = new TareasLargas(
                PanelMedio,
                ProgressBar,
                GuardarActividad,
                FinBtnGuardar);
            tarea.Iniciar();
        }

        private void FinBtnGuardar()
        {
            this.Invoke(
                () =>
                {
                    ActualizarListas();
                    ListBArticulos.Refresh();
                });
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (!ValidarSeleccionParaEliminar())
            {
                MessageBox.Show("Por favor, seleccione una actividad de la lista para eliminar",
                              "Ninguna actividad seleccionada",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ConfirmarEliminacion()) return;

            var tarea = new TareasLargas(
                PanelMedio,
                ProgressBar,
                EliminarActividad,
                () =>
                {
                    LimpiarFormulario();
                    ActualizarDataGridView();
                    if (Utilidades.Util.CalcularDGVVacio(ListBArticulos, LblLista, "Actividades"))
                    {
                        Utilidades.Util.LimpiarForm(TLPForm, TxtDescripcion);
                        Utilidades.Util.BloquearBtns(ListBArticulos, TLPForm);
                    }
                });
            tarea.Iniciar();
        }

        private async void ListBArticulos_SelectionChanged(object sender, EventArgs e)
        {
            if (!HaySeleccionValida())
            {
                LimpiarFormulario();
                return;
            }

            _indiceSeleccionado = ListBArticulos.CurrentRow?.Index ?? -1;

            if (_indiceSeleccionado >= 0 && _indiceSeleccionado < ListBArticulos.Rows.Count)
            {
                await CargarFormularioEdicion();
            }
            else
            {
                LimpiarFormulario();
            }
        }

        private async Task CargarEntornos(int idTipoEntorno)
        {
            var resultado = await _entornoService.GetAllxEntorno(idTipoEntorno);
            if (resultado.IsSuccess)
            {
                CMBEntorno.DataSource = null; // Clear previous data
                CMBEntorno.DataSource = resultado.Value;
                CMBEntorno.DisplayMember = "Entorno_nombre";
                CMBEntorno.ValueMember = "Id_Entorno";
            }
            else
            {
                MessageBox.Show(resultado.Error, "Error al cargar entornos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task CargarEntornosFormativos(int idEntorno)
        {
            var resultado = await _entornoFormativoService.GetAllByIdEntorno(idEntorno);
            if (resultado.IsSuccess)
            {
                // Create a copy of the list to avoid potential issues with UI binding
                var entornosFormativos = resultado.Value.ToList();
                CMBEntornoFormativo.DataSource = null; // Clear previous data
                CMBEntornoFormativo.DataSource = entornosFormativos;
                CMBEntornoFormativo.DisplayMember = "Curso_Completo"; // Using Curso_Completo as a comprehensive display
                CMBEntornoFormativo.ValueMember = "Id_Entorno_Formativo";
            }
            else
            {
                MessageBox.Show(resultado.Error, "Error al cargar entornos formativos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #region Métodos de Validación y Formulario

        private bool ValidarFormulario()
        {
            return !string.IsNullOrWhiteSpace(TxtDescripcion.Text);
        }

        private bool ValidarSeleccionParaEliminar()
        {
            return _actividadSeleccionada != null && _actividadSeleccionada.Id_Actividad != 0;
        }

        private static bool ConfirmarEliminacion()
        {
            var resultado = MessageBox.Show(
                "¿Está seguro de que desea eliminar esta actividad?",
                "Confirmación de eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            return resultado == DialogResult.Yes;
        }

        private bool CrearActividadDesdeFormulario()
        {
            if (CMBTipoEntorno.SelectedItem is not TipoEntorno tipoEntorno)
            {
                MessageBox.Show("El tipo de entorno seleccionado no es válido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (CMBEntornoFormativo.SelectedItem is not Modelo.Entidades.EntornoFormativo entornoFormativo)
            {
                MessageBox.Show("El entorno formativo seleccionado no es válido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            _actividadSeleccionada.Id_TipoEntorno = tipoEntorno.Id_Tipo_Entorno;
            _actividadSeleccionada.Id_Entorno = entornoFormativo.Id_Entorno; // Use the entorno from the selected entorno formativo
            _actividadSeleccionada.Id_EntornoFormativo = entornoFormativo.Id_Entorno_Formativo;
            _actividadSeleccionada.Fecha_Actividad = dateTimePicker1.Value;
            _actividadSeleccionada.Descripcion_Actividad = TxtDescripcion.Text;

            return true;
        }

        private async Task CargarFormularioEdicion()
        {
            if (!HaySeleccionValida() ||
                _indiceSeleccionado < 0 ||
                _indiceSeleccionado >= ListBArticulos.Rows.Count)
            {
                LimpiarFormulario();
                return;
            }

            var fila = ListBArticulos.Rows[_indiceSeleccionado];

            if (fila.DataBoundItem is Modelo.Entidades.Actividad actividad)
            {
                _actividadSeleccionada = actividad;

                // Cargar datos en los controles
                TxtDescripcion.Text = _actividadSeleccionada.Descripcion_Actividad ?? string.Empty;
                dateTimePicker1.Value = _actividadSeleccionada.Fecha_Actividad;

                // Cargar combos
                await CargarCombosSeleccion();
            }
            else
            {
                LimpiarFormulario();
            }
        }

        private async Task CargarCombosSeleccion()
        {
            if (CMBTipoEntorno.Items.Count > 0)
                CMBTipoEntorno.SelectedValue = _actividadSeleccionada.Id_TipoEntorno;

            if (_actividadSeleccionada.Id_TipoEntorno > 0)
            {
                // First load entornos for the selected tipo entorno
                var entornosResultado = await _entornoService.GetAllxEntorno(_actividadSeleccionada.Id_TipoEntorno);
                if (entornosResultado.IsSuccess)
                {
                    CMBEntorno.DataSource = entornosResultado.Value;
                    CMBEntorno.DisplayMember = "Entorno_nombre";
                    CMBEntorno.ValueMember = "Id_Entorno";

                    if (_actividadSeleccionada.Id_Entorno > 0)
                    {
                        CMBEntorno.SelectedValue = _actividadSeleccionada.Id_Entorno;

                        // Now load entorno formativos for the selected entorno
                        var entornosFormativosResultado = await _entornoFormativoService.GetAllByIdEntorno(_actividadSeleccionada.Id_Entorno);
                        if (entornosFormativosResultado.IsSuccess)
                        {
                            CMBEntornoFormativo.DataSource = entornosFormativosResultado.Value;
                            CMBEntornoFormativo.DisplayMember = "Curso_Completo";
                            CMBEntornoFormativo.ValueMember = "Id_Entorno_Formativo";

                            if (_actividadSeleccionada.Id_EntornoFormativo > 0)
                            {
                                CMBEntornoFormativo.SelectedValue = _actividadSeleccionada.Id_EntornoFormativo;
                            }
                        }
                    }
                }
            }
        }

        private void LimpiarFormulario()
        {
            TxtDescripcion.Clear();
            dateTimePicker1.Value = DateTime.Now;

            _actividadSeleccionada = new Modelo.Entidades.Actividad();
        }

        private bool HaySeleccionValida()
        {
            return ListBArticulos.Rows.Count > 0 && ListBArticulos.SelectedRows.Count > 0 && ListBArticulos.CurrentRow != null;
        }

        #endregion

        #region Métodos de Operaciones de Datos

        private async Task GuardarActividad()
        {
            var resultado = await _actividadService.Update(_actividadSeleccionada);

            if (resultado.IsSuccess)
            {
                MessageBox.Show("Actividad actualizada correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(resultado.Error, "Error en la actualización", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EliminarActividad()
        {
            var resultado = _actividadService.Delete(_actividadSeleccionada.Id_Actividad);

            if (resultado.IsSuccess)
            {
                MessageBox.Show("Actividad eliminada correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                EliminarDeLista();
            }
            else
            {
                MessageBox.Show(resultado.Error, "Error al eliminar actividad", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ActualizarListas()
        {
            Utilidades.Util.ActualizarEnLista(_listaActividades, _actividadSeleccionada);
            CargarArticulosDataGridView();
        }

        private void EliminarDeLista()
        {
            Utilidades.Util.EliminarDeLista(_listaActividades, _actividadSeleccionada);
        }

        #endregion

        #region Eventos de UI

        private async void CMBTipoEntorno_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CMBTipoEntorno.SelectedItem is TipoEntorno tipoEntorno)
            {
                await CargarEntornos(tipoEntorno.Id_Tipo_Entorno);
                // Clear the subcategory combo since its contents depend on the selected entorno
                CMBEntorno.SelectedIndex = -1;
            }
        }

        private async void CMBEntorno_SelectedIndexChanged(object sender, EventArgs e)
        {
            // When CMBEntorno selection changes, we need to determine if the selected item is an Entorno
            // If it is an Entorno, we load EntornoFormativos for that Entorno
            // If it is an EntornoFormativo, we don't need to load anything further in the cascade
            if (CMBEntorno.SelectedItem is Entorno entorno)
            {
                // The selected item is an Entorno, so load EntornoFormativos for it
                await CargarEntornosFormativos(entorno.Id_Entorno);
            }
            // If it's an EntornoFormativo, no further loading is needed
        }

        #endregion

        #region Métodos de UI Helpers

        private void CargarArticulosDataGridView()
        {
            try
            {
                ListBArticulos.SuspendLayout();
                int primeraFilaVisible = ListBArticulos.FirstDisplayedScrollingRowIndex;

                ListBArticulos.AutoGenerateColumns = false;
                ListBArticulos.DataSource = null;
                ListBArticulos.DataSource = _listaActividades ?? [];

                if (primeraFilaVisible >= 0 && primeraFilaVisible < ListBArticulos.Rows.Count)
                {
                    ListBArticulos.FirstDisplayedScrollingRowIndex = primeraFilaVisible;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar DataGridView: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                ListBArticulos.ResumeLayout();
            }
        }

        private void ActualizarDataGridView()
        {
            CargarArticulosDataGridView();
            ListBArticulos.ClearSelection();
        }

        #endregion

      
    }
}
