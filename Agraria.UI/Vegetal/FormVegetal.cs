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

namespace Agraria.UI.Vegetal
{
    public partial class FormVegetal : Form
    {
        private readonly IServiceProvider _serviceProvider;

        public FormVegetal(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            InitializeComponent();
            LoadUserControl<ucIngresoVegetal>();
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
            LoadUserControl<ucIngresoVegetal>();
        }

        private void btnConsulta_Click(object sender, EventArgs e)
        {
            LoadUserControl<ucConsultaVegetal>();
        }
    }
}
