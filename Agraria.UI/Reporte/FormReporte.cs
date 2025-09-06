using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Agraria.UI.Reporte
{
    public partial class FormReporte : Form
    {
        public FormReporte()
        {
            InitializeComponent();
        }

        private void btnMasVendidos_Click(object sender, EventArgs e)
        {
            // TODO: Implementar la lógica para cargar el reporte de artículos más vendidos
            // Ejemplo:
            // var dt = new DataTable();
            // dt.Columns.Add("Artículo");
            // dt.Columns.Add("Cantidad");
            // dt.Rows.Add("Producto A", 100);
            // dt.Rows.Add("Producto B", 80);
            // dgvReporte.DataSource = dt;
        }

        private void btnVentasPeriodo_Click(object sender, EventArgs e)
        {
            // TODO: Implementar la lógica para cargar el reporte de ventas por período
        }

        private void btnStock_Click(object sender, EventArgs e)
        {
            // TODO: Implementar la lógica para cargar el reporte de stock actual
        }
    }
}
