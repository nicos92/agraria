using Agraria.Contrato.Servicios;
using Agraria.Modelo.Entidades;
using Agraria.Util.Validaciones;
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
        private List<Modelo.Entidades.Actividad> _listaActividadesOriginal; // Lista original para filtrado

        private int _indiceSeleccionado;

        private readonly ValidadorTextBox _vTxtDescripcion;

        // Campos para filtros
        private List<TipoEntorno> _listaFiltroTipoEntorno;
        private List<Entorno> _listaFiltroEntorno;
        private List<Modelo.Entidades.EntornoFormativo> _listaFiltroEntornoFormativo;

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
            _listaActividadesOriginal = [];
            _listaFiltroTipoEntorno = [];
            _listaFiltroEntorno = [];
            _listaFiltroEntornoFormativo = [];

            _indiceSeleccionado = -1;

            // Configurar el DataGridView
            ConfigurarDGV();
            _vTxtDescripcion = new ValidadorDireccion(TxtDescripcion, new ErrorProvider()) { MensajeError = "La Descripción no puede estar vacía" };

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
                CargarEntornosList(),
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

        private async Task CargarEntornosList()
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
                    _listaActividadesOriginal = new List<Modelo.Entidades.Actividad>(_listaActividades);

                    // Configurar combo principal (Tipo Entorno)
                    CMBTipoEntorno.DataSource = _listaTipoEntorno ?? [];
                    CMBTipoEntorno.DisplayMember = "Area";
                    CMBTipoEntorno.ValueMember = "Id_Area";

                    // Configurar combos de filtros
                    CMFTipoEntorno.DataSource = new List<TipoEntorno> { new TipoEntorno { Id_Area = 0, Area = "Todos" } }
                        .Concat(_listaTipoEntorno ?? []).ToList();
                    CMFTipoEntorno.DisplayMember = "Area";
                    CMFTipoEntorno.ValueMember = "Id_Area";
                    CMFTipoEntorno.SelectedIndex = 0; // Seleccionar "Todos" por defecto

                    // Configurar combos de filtro para entornos y entornos formativos inicialmente vacíos
                    CMBFiltroEntorno.DataSource = new List<Entorno> { new Entorno { Id_Entorno = 0, Entorno_nombre = "Todos" } };
                    CMBFiltroEntorno.DisplayMember = "Entorno_nombre";
                    CMBFiltroEntorno.ValueMember = "Id_Entorno";
                    CMBFiltroEntorno.SelectedIndex = 0;

                    // Create a new EntornoFormativo instance with all necessary properties
                    var todosEntornoFormativo = new Modelo.Entidades.EntornoFormativo
                    {
                        Id_Entorno_Formativo = 0,
                        Usuario_Apellido = "",
                        Usuario_Nombre = "",
                        Curso_anio = "",
                        Curso_Division = "",
                        Curso_Grupo = "Todos"
                    };
                    CMBFiltroEntornoFormativo.DataSource = new List<Modelo.Entidades.EntornoFormativo> { todosEntornoFormativo };
                    CMBFiltroEntornoFormativo.DisplayMember = "Curso_Completo";
                    CMBFiltroEntornoFormativo.ValueMember = "Id_Entorno_Formativo";
                    CMBFiltroEntornoFormativo.SelectedIndex = 0;

                    // Configurar fechas por defecto para los filtros
                    DTPFechaDesde.Value = DateTime.Now.AddDays(-30); // 1 año atrás
                    DTPFechaHasta.Value = DateTime.Now;  // 1 año adelante

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
                    Visible = true,
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
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
            //var resultado = await _entornoService.GetAllxEntorno(idTipoEntorno);
            var re = _listaEntorno.Where(e => e.Id_Area == idTipoEntorno).ToList();
            //if (resultado.IsSuccess)
            //{
            CMBEntorno.DataSource = null; // Clear previous data
            CMBEntorno.DataSource = re;
            CMBEntorno.DisplayMember = "Entorno_nombre";
            CMBEntorno.ValueMember = "Id_Entorno";
            //}
            //else
            //{
            //    MessageBox.Show(resultado.Error, "Error al cargar entornos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
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

            _actividadSeleccionada.Id_TipoEntorno = tipoEntorno.Id_Area;
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
                await CargarEntornos(tipoEntorno.Id_Area);
                // Clear the subcategory combo since its contents depend on the selected entorno
                //CMBEntorno.SelectedIndex = -1;
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

        private async void CMFTipoEntorno_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CMFTipoEntorno.SelectedItem is TipoEntorno tipoEntorno && tipoEntorno.Id_Area != 0)
            {
                // Load entornos for the selected tipo entorno in the filter
                var resultado = await _entornoService.GetAllxEntorno(tipoEntorno.Id_Area);
                if (resultado.IsSuccess)
                {
                    _listaFiltroEntorno = resultado.Value.ToList();

                    // Add "Todos" option to the combo
                    var entornosConTodos = new List<Entorno> { new Entorno { Id_Entorno = 0, Entorno_nombre = "Todos" } }
                        .Concat(_listaFiltroEntorno).ToList();

                    CMBFiltroEntorno.DataSource = entornosConTodos;
                    CMBFiltroEntorno.DisplayMember = "Entorno_nombre";
                    CMBFiltroEntorno.ValueMember = "Id_Entorno";
                    CMBFiltroEntorno.SelectedIndex = 0; // Seleccionar "Todos" por defecto
                }
            }
            else
            {
                // If "Todos" is selected (Id_Tipo_Entorno == 0), clear the filter combos
                CMBFiltroEntorno.DataSource = new List<Entorno> { new Entorno { Id_Entorno = 0, Entorno_nombre = "Todos" } };
                CMBFiltroEntorno.DisplayMember = "Entorno_nombre";
                CMBFiltroEntorno.ValueMember = "Id_Entorno";
                CMBFiltroEntorno.SelectedIndex = 0;

                // Create a new EntornoFormativo with required properties
                var todosEntornoFormativo = new Modelo.Entidades.EntornoFormativo
                {
                    Id_Entorno_Formativo = 0,
                    Usuario_Apellido = "",
                    Usuario_Nombre = "",
                    Curso_anio = "",
                    Curso_Division = "",
                    Curso_Grupo = "Todos"
                };
                CMBFiltroEntornoFormativo.DataSource = new List<Modelo.Entidades.EntornoFormativo> { todosEntornoFormativo };
                CMBFiltroEntornoFormativo.DisplayMember = "Curso_Completo";
                CMBFiltroEntornoFormativo.ValueMember = "Id_Entorno_Formativo";
                CMBFiltroEntornoFormativo.SelectedIndex = 0;
            }
        }

        private async void CMBFiltroEntorno_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CMBFiltroEntorno.SelectedItem is Entorno entorno && entorno.Id_Entorno != 0)
            {
                // Load entorno formativos for the selected entorno in the filter
                var resultado = await _entornoFormativoService.GetAllByIdEntorno(entorno.Id_Entorno);
                if (resultado.IsSuccess)
                {
                    _listaFiltroEntornoFormativo = resultado.Value.ToList();

                    // Create a new EntornoFormativo with required properties
                    var todosEntornoFormativo = new Modelo.Entidades.EntornoFormativo
                    {
                        Id_Entorno_Formativo = 0,
                        Usuario_Apellido = "",
                        Usuario_Nombre = "",
                        Curso_anio = "",
                        Curso_Division = "",
                        Curso_Grupo = "Todos"
                    };

                    // Add "Todos" option to the combo
                    var formativosConTodos = new List<Modelo.Entidades.EntornoFormativo> { todosEntornoFormativo }
                        .Concat(_listaFiltroEntornoFormativo).ToList();

                    CMBFiltroEntornoFormativo.DataSource = formativosConTodos;
                    CMBFiltroEntornoFormativo.DisplayMember = "Curso_Completo";
                    CMBFiltroEntornoFormativo.ValueMember = "Id_Entorno_Formativo";
                    CMBFiltroEntornoFormativo.SelectedIndex = 0; // Seleccionar "Todos" por defecto
                }
            }
            else
            {
                // If "Todos" is selected (Id_Entorno == 0), clear the entorno formativo filter combo
                var todosEntornoFormativo = new Modelo.Entidades.EntornoFormativo
                {
                    Id_Entorno_Formativo = 0,
                    Usuario_Apellido = "",
                    Usuario_Nombre = "",
                    Curso_anio = "",
                    Curso_Division = "",
                    Curso_Grupo = "Todos"
                };
                CMBFiltroEntornoFormativo.DataSource = new List<Modelo.Entidades.EntornoFormativo> { todosEntornoFormativo };
                CMBFiltroEntornoFormativo.DisplayMember = "Curso_Completo";
                CMBFiltroEntornoFormativo.ValueMember = "Id_Entorno_Formativo";
                CMBFiltroEntornoFormativo.SelectedIndex = 0;
            }
        }

        private void BtnAplicarFiltros_Click(object sender, EventArgs e)
        {
            AplicarFiltros();
        }

        private void BtnLimpiarFiltros_Click(object sender, EventArgs e)
        {
            LimpiarFiltros();
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

        #region Métodos de Filtrado

        private void AplicarFiltros()
        {
            var actividadesFiltradas = _listaActividadesOriginal.AsEnumerable();

            // Filtrar por fecha 
            actividadesFiltradas = actividadesFiltradas.Where(a => a.Fecha_Actividad.Date >= DTPFechaDesde.Value.Date && a.Fecha_Actividad.Date <= DTPFechaHasta.Value.Date);

            // Filtrar por tipo de entorno
            if (CMFTipoEntorno.SelectedItem is TipoEntorno tipoEntorno && tipoEntorno.Id_Area != 0)
            {
                actividadesFiltradas = actividadesFiltradas.Where(a => a.Id_TipoEntorno == tipoEntorno.Id_Area);
            }

            // Filtrar por entorno
            if (CMBFiltroEntorno.SelectedItem is Entorno entorno && entorno.Id_Entorno != 0)
            {
                actividadesFiltradas = actividadesFiltradas.Where(a => a.Id_Entorno == entorno.Id_Entorno);
            }

            // Filtrar por entorno formativo
            if (CMBFiltroEntornoFormativo.SelectedItem is Modelo.Entidades.EntornoFormativo entornoFormativo && entornoFormativo.Id_Entorno_Formativo != 0)
            {
                actividadesFiltradas = actividadesFiltradas.Where(a => a.Id_EntornoFormativo == entornoFormativo.Id_Entorno_Formativo);
            }

            // Actualizar el DataGridView con las actividades filtradas
            this.Invoke(() =>
            {
                ListBArticulos.DataSource = actividadesFiltradas.ToList();
            });

            MessageBox.Show($"Se Filtraron {ListBArticulos.RowCount} actividades", "Filtro de Actividades", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void LimpiarFiltros()
        {
            // Limpiar valores de los controles de filtro
            DTPFechaDesde.Value = DateTime.Now.AddDays(-30); // Valor por defecto, por ejemplo 30 días atrás
            DTPFechaHasta.Value = DateTime.Now; // Valor por defecto, por ejemplo 30 días adelante

            // Restablecer los combos de filtro a "Todos"
            if (CMFTipoEntorno.Items.Count > 0)
                CMFTipoEntorno.SelectedIndex = 0;

            if (CMBFiltroEntorno.Items.Count > 0)
                CMBFiltroEntorno.SelectedIndex = 0;

            if (CMBFiltroEntornoFormativo.Items.Count > 0)
                CMBFiltroEntornoFormativo.SelectedIndex = 0;

            // Mostrar todas las actividades
            this.Invoke(() =>
            {
                ListBArticulos.DataSource = _listaActividadesOriginal;
            });
        }

        #endregion


        private void TxtDescripcion_TextChanged(object sender, EventArgs e)
        {
            ValidadorMultiple.ValidacionMultiple(BtnGuardar, _vTxtDescripcion);

        }

        private void DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            TxtDescripcion_TextChanged(sender, e);
        }

        private void UCConsultaActividad_VisibleChanged(object sender, EventArgs e)
        {
            if (Visible)
            {
                var taskHelper = new TareasLargas(PanelMedio, ProgressBar, CargaInicial, CargarGrilla);
                taskHelper.Iniciar();
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
