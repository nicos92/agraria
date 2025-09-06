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
    public partial class FormActividad: Form
    {
        public FormActividad()
        {
            InitializeComponent();
            // Load the default user control on startup
            LoadUserControl(new ucIngresoActividad());
        }

        private void LoadUserControl(UserControl userControl)
        {
            panelContainer.Controls.Clear();
            userControl.Dock = DockStyle.Fill;
            panelContainer.Controls.Add(userControl);
        }

        private void btnIngreso_Click(object sender, EventArgs e)
        {
            LoadUserControl(new ucIngresoActividad());
        }

        private void btnConsulta_Click(object sender, EventArgs e)
        {
            LoadUserControl(new ucConsultaActividad());
        }
    }
}
