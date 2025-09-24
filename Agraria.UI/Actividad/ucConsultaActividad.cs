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
        private readonly IActividadService _actividadService;
        private readonly ITipoEntornosService _tipoEntornoService;
        private readonly IEntornoService _entornoService;

        private List<Modelo.Entidades.Actividad> ListaActividades { get; set; } = [];

        public ucConsultaActividad(IActividadService actividadService, ITipoEntornosService tipoEntornoService, IEntornoService entornoService)
        {
            _actividadService = actividadService;
            _tipoEntornoService = tipoEntornoService;
            _entornoService = entornoService;

            InitializeComponent();
        }

        private void ucConsultaActividad_Load(object sender, EventArgs e)
        {
            var taskHelper = new TareasLargas(PanelMedio, ProgressBar, CargaInicial, CargarGrilla);
            taskHelper.Iniciar();
        }

        private async Task CargaInicial()
        {
            var datos = await _actividadService.GetAll();
            if (!datos.IsSuccess)
                MessageBox.Show(datos.Error, "Error en UI", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                ListaActividades = datos.Value;
        }

        private void CargarGrilla()
        {
            this.Invoke(
                () =>
                {
                    // Configurar la fuente de datos del DataGridView
                    ListBArticulos.DataSource = ListaActividades;

                    // Configurar los nombres de las columnas
                    if (ListBArticulos.Columns["Id_Actividad"] != null)
                        ListBArticulos.Columns["Id_Actividad"].HeaderText = "CÓDIGO";
                    
                    if (ListBArticulos.Columns["Fecha_Actividad"] != null)
                        ListBArticulos.Columns["Fecha_Actividad"].HeaderText = "FECHA Y HORA";
                    
                    if (ListBArticulos.Columns["Descripcion_Actividad"] != null)
                        ListBArticulos.Columns["Descripcion_Actividad"].HeaderText = "DESCRIPCIÓN";
                });
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            // Implementar lógica de actualización de actividad
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            // Implementar lógica de eliminación de actividad
        }
    }
}
