using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Agraria.Contrato.Servicios;
using Agraria.Modelo.Entidades;
using Agraria.Util;

namespace Agraria.Login
{
    public partial class FormRecuperarContra : Form
    {
        private readonly IPreguntasSeguridadService _preguntasSeguridadService;

        public FormRecuperarContra(IPreguntasSeguridadService preguntasSeguridadService)
        {
            _preguntasSeguridadService = preguntasSeguridadService;
            InitializeComponent();
        }

        private async void FormRecuperarContra_Load(object sender, EventArgs e)
        {
            await CargarPreguntasSeguridad();
        }

        private async Task CargarPreguntasSeguridad()
        {
            var preguntas = await _preguntasSeguridadService.GetAll();

            if (preguntas.IsSuccess && preguntas.Value != null)
            {
                CMBPregunta.DataSource = null;
                CMBPregunta.DataSource = preguntas.Value;
                CMBPregunta.DisplayMember = "Pregunta";
                CMBPregunta.ValueMember = "Id_Pregunta";
            }
            else
            {
                MessageBox.Show("Error al cargar las preguntas de seguridad: " + preguntas.Error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnIngresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
