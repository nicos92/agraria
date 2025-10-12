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
    public partial class ucIngresoActividad : UserControl
    {
        #region Atributos y Propiedades

        private readonly IActividadService _actividadService;
        private readonly ITipoEntornosService _tipoEntornoService;
        private readonly IEntornoService _entornoService;
        private readonly IEntornoFormativoService _entornoFormativoService;

        private readonly Modelo.Entidades.Actividad _actividadSeleccionada;

        private readonly ValidadorTextBox _vTxtDescripcion;

        private readonly ErrorProvider _epTxtDescripcion;

        private List<TipoEntorno> ListaTiposEntorno { get; set; } = [];
        private List<Entorno> ListaEntornos { get; set; } = [];
        private List<Modelo.Entidades.EntornoFormativo> ListaEntornosFormativos { get; set; } = [];

        #endregion Atributos y Propiedades

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="ucIngresoActividad"/>.
        /// </summary>
        public ucIngresoActividad(IActividadService actividadService, ITipoEntornosService tipoEntornoService, IEntornoService entornoService, IEntornoFormativoService entornoFormativoService)
        {
            _actividadService = actividadService;
            _tipoEntornoService = tipoEntornoService;
            _entornoService = entornoService;
            _entornoFormativoService = entornoFormativoService;

            InitializeComponent();

            _actividadSeleccionada = new Modelo.Entidades.Actividad();

            _epTxtDescripcion = new ErrorProvider();
            _vTxtDescripcion = new ValidadorDireccion(TxtDescripcion, _epTxtDescripcion) { MensajeError = "La Descripción no puede estar vacía" };
        }

        #region Eventos

        /// <summary>
        /// Controla el evento TextChanged de la descripción.
        /// </summary>
        /// <param name="sender">El origen del evento.</param>
        /// <param name="e">El <see cref="EventArgs"/> instancia que contiene los datos del evento.</param>
        private void TxtDescripcion_TextChanged(object sender, EventArgs e)
        {
            ValidadorMultiple.ValidacionMultiple(BtnIngresar, _vTxtDescripcion);
        }

        /// <summary>
        /// Controla el evento SelectedIndexChanged del ComboBox de tipos de entorno.
        /// </summary>
        /// <param name="sender">El origen del evento.</param>
        /// <param name="e">El <see cref="EventArgs"/> instancia que contiene los datos del evento.</param>
        private async void CMBTipoEntorno_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CMBTipoEntorno.SelectedItem is TipoEntorno tipoEntorno)
                await CargarEntornos(tipoEntorno.Id_Area);
        }

        /// <summary>
        /// Controla el evento SelectedIndexChanged del ComboBox de entornos.
        /// </summary>
        /// <param name="sender">El origen del evento.</param>
        /// <param name="e">El <see cref="EventArgs"/> instancia que contiene los datos del evento.</param>
        private async void CMBEntorno_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CMBEntorno.SelectedItem is Entorno entorno)
                await CargarEntornosFormativos(entorno.Id_Entorno);
        }

        #endregion Eventos

        #region Métodos Privados

        /// <summary>
        /// Crea una nueva actividad a partir de los datos introducidos por el usuario.
        /// </summary>
        /// <returns>Verdadero si la actividad se creó correctamente, falso en caso contrario.</returns>
        private bool CrearActividad()
        {
            if (CMBTipoEntorno.SelectedItem is not TipoEntorno tipoEntorno)
            {
                MessageBox.Show("El tipo de entorno seleccionado no es válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (CMBEntorno.SelectedItem is not Entorno entorno)
            {
                MessageBox.Show("El entorno seleccionado no es válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (CMBEntornoFormativo.SelectedItem is not Modelo.Entidades.EntornoFormativo entornoFormativo)
            {
                MessageBox.Show("El entorno formativo seleccionado no es válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            _actividadSeleccionada.Id_TipoEntorno = tipoEntorno.Id_Area;
            _actividadSeleccionada.Id_Entorno = entorno.Id_Entorno;
            _actividadSeleccionada.Id_EntornoFormativo = entornoFormativo.Id_Entorno_Formativo;
            _actividadSeleccionada.Fecha_Actividad = dateTimePicker1.Value;
            _actividadSeleccionada.Descripcion_Actividad = TxtDescripcion.Text;

            return true;
        }

        /// <summary>
        /// Maneja el evento Load del UserControl.
        /// </summary>
        /// <param name="sender">El origen del evento.</param>
        /// <param name="e">El <see cref="EventArgs"/> instancia que contiene los datos del evento.</param>
        private void ucIngresoActividad_Load(object sender, EventArgs e)
        {
            ConfigurarDGV();
            var taskHelper = new TareasLargas(PanelMedio, ProgressBar, CargaInicial, CargarCMB);
            taskHelper.Iniciar();
        }

        private List<Modelo.Entidades.ActividadesCurso> ListaActividades { get; set; } = [];

        /// <summary>
        /// Realiza la carga inicial de datos de forma asíncrona.
        /// </summary>
        private async Task CargaInicial()
        {
            await Task.WhenAll(CargarTiposEntorno(), CargarUltimasActividades());
        }

        /// <summary>
        /// Carga los datos de tipos de entorno en los ComboBox correspondientes y configura el DataGridView con las últimas actividades.
        /// Se configuran las propiedades DataSource, DisplayMember y ValueMember para cada control.
        /// </summary>
        private void CargarCMB()
        {
            this.Invoke(
                () =>
                {
                    CMBTipoEntorno.DataSource = ListaTiposEntorno;
                    CMBTipoEntorno.DisplayMember = "Area";
                    CMBTipoEntorno.ValueMember = "Id_Area";

                    // Configurar la fuente de datos del DataGridView con las últimas 10 actividades
                    ListBArticulos.DataSource = ListaActividades;


                });
        }

        /// <summary>
        /// Carga la lista de tipos de entorno en el ComboBox.
        /// </summary>
        private async Task CargarTiposEntorno()
        {
            var datos = await _tipoEntornoService.GetAll();
            if (!datos.IsSuccess)
                MessageBox.Show(datos.Error, "Error en UI", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                ListaTiposEntorno = datos.Value;
        }

        /// <summary>
        /// Carga la lista de entornos en el ComboBox.
        /// </summary>
        /// <param name="id">ID del tipo de entorno para la cual cargar los entornos.</param>
        private async Task CargarEntornos(int id)
        {
            try
            {
                var datos = await _entornoService.GetAllxEntorno(id);
                if (!datos.IsSuccess)
                    MessageBox.Show(datos.Error, "Error en UI", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    var entornos = datos.Value;
                    CMBEntorno.DataSource = null;
                    CMBEntorno.DataSource = entornos;
                    CMBEntorno.DisplayMember = "Entorno_Nombre";
                    CMBEntorno.ValueMember = "Id_Entorno";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Carga la lista de entornos formativos en el ComboBox.
        /// </summary>
        /// <param name="id">ID del entorno para la cual cargar los entornos formativos.</param>
        private async Task CargarEntornosFormativos(int id)
        {
            try
            {
                var datos = await _entornoFormativoService.GetAllByIdEntorno(id);
                if (!datos.IsSuccess)
                    MessageBox.Show(datos.Error, "Error en UI", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    var entornosFormativos = datos.Value;
                    CMBEntornoFormativo.DataSource = null;
                    CMBEntornoFormativo.DataSource = entornosFormativos;
                    CMBEntornoFormativo.DisplayMember = "Curso_Completo";
                    CMBEntornoFormativo.ValueMember = "Id_Entorno_Formativo";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Carga las últimas 10 actividades en la lista.
        /// </summary>
        private async Task CargarUltimasActividades()
        {
            var datos = await _actividadService.GetTopDiez();
            if (!datos.IsSuccess)
                MessageBox.Show(datos.Error, "Error en UI", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                // Ordenar por fecha descendente y tomar las últimas 10
                ListaActividades = datos.Value;
            }
        }

        #endregion Métodos Privados

        #region Otros Metodos

        /// <summary>
        /// Controla el evento Click del botón Ingresar.
        /// </summary>
        /// <param name="sender">El origen del evento.</param>
        /// <param name="e">El <see cref="EventArgs"/> instancia que contiene los datos del evento.</param>
        private void BtnIngresar_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("¿Estás seguro que quieres registrar la actividad?", "Ingreso de Actividad", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.No)
                return;

            if (!CrearActividad())
            {
                MessageBox.Show("Actividad no creada", "Actividad", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var tarea = new TareasLargas(PanelMedio, ProgressBar, InsertarActividad, Limpiar);
            tarea.Iniciar();
        }

        private void Limpiar()
        {
            this.Invoke(
                () =>
                {
                    Utilidades.Util.LimpiarForm(TLPForm, TxtDescripcion);
                    dateTimePicker1.Value = DateTime.Now;
                });
        }

        /// <summary>
        /// Inserta una nueva actividad en la base de datos.
        /// </summary>
        public async Task InsertarActividad()
        {
            var insercionResult = await _actividadService.Add(_actividadSeleccionada);

            if (!insercionResult.IsSuccess)
                MessageBox.Show(insercionResult.Error, "Error en la inserción", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                MessageBox.Show("Registro de actividad correcto", "Actividad", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Refrescar la lista de últimas actividades y actualizar el DataGridView
                await CargarUltimasActividades();
                this.Invoke(() =>
                {
                    ListBArticulos.DataSource = ListaActividades;
                });
            }
        }

        #endregion Otros Metodos

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
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
                },
                new DataGridViewTextBoxColumn
                {
                    Name = "Fecha_Actividad",
                    DataPropertyName = "Fecha_Actividad",
                    HeaderText = "Fecha y Hora",
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
                },
                new DataGridViewTextBoxColumn
                {
                    Name = "Curso_Anio",
                    DataPropertyName = "Curso_Anio",
                    HeaderText = "Año",
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
                },
                new DataGridViewTextBoxColumn
                {
                    Name = "Curso_Division",
                    DataPropertyName = "Curso_Division",
                    HeaderText = "Division",
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
                },
                new DataGridViewTextBoxColumn
                {
                    Name = "Curso_Grupo",
                    DataPropertyName = "Curso_Grupo",
                    HeaderText = "Grupo",
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
                },
                new DataGridViewTextBoxColumn
                {
                    Name = "Descripcion_Actividad",
                    DataPropertyName = "Descripcion_Actividad",
                    HeaderText = "Descripción",
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                }
            };

            foreach (var column in columns)
            {
                ListBArticulos.Columns.Add(column);
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            TxtDescripcion_TextChanged(sender, e); // Activar validación cuando cambia la fecha
        }

        private void ucIngresoActividad_VisibleChanged(object sender, EventArgs e)
        {
            if (Visible)
            {
                var taskHelper = new TareasLargas(PanelMedio, ProgressBar, CargaInicial, CargarCMB);
                taskHelper.Iniciar();
            }
        }
    }
}
