using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Agraria.UI.Vegetal
{
    public partial class FormVegetal : Form
    {
        public FormVegetal()
        {
            InitializeComponent();
            LoadUserControl(new ucIngresoVegetal());
        }

        private void LoadUserControl(UserControl userControl)
        {
            panelContainer.Controls.Clear();
            userControl.Dock = DockStyle.Fill;
            panelContainer.Controls.Add(userControl);
        }

        private void btnIngreso_Click(object sender, EventArgs e)
        {
            LoadUserControl(new ucIngresoVegetal());
        }

        private void btnConsulta_Click(object sender, EventArgs e)
        {
            LoadUserControl(new ucConsultaVegetal());
        }
    }
}
