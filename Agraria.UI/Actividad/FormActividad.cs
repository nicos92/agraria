using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection;

namespace Agraria.UI.Actividad
{
    public partial class FormActividad : Form
    {
        private readonly IServiceProvider _serviceProvider;

        public FormActividad(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            InitializeComponent();
            LoadUserControl<ucIngresoActividad>();
        }

        private void LoadUserControl<T>() where T : UserControl
        {
            var userControl = _serviceProvider.GetRequiredService<T>();
            panelContainer.Controls.Clear();
            userControl.Dock = DockStyle.Fill;
            panelContainer.Controls.Add(userControl);
        }

        private void btnIngreso_Click(object sender, EventArgs e)
        {
            LoadUserControl<ucIngresoActividad>();
        }

        private void btnConsulta_Click(object sender, EventArgs e)
        {
            LoadUserControl<ucConsultaActividad>();
        }
    }
}
