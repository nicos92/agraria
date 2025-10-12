using System;
using System.Windows.Forms;

namespace Agraria.UI.Reporte
{
    public partial class DateTimePickerForm : Form
    {
        public DateTime FechaDesde { get; private set; }
        public DateTime FechaHasta { get; private set; }
        
        private DateTimePicker dtpFechaDesde;
        private DateTimePicker dtpFechaHasta;

        public DateTimePickerForm()
        {
            InitializeComponent();
            FechaDesde = DateTime.Now.AddMonths(-1); // Último mes por defecto
            FechaHasta = DateTime.Now;
            
            this.dtpFechaDesde.Value = FechaDesde;
            this.dtpFechaHasta.Value = FechaHasta;
        }

        private void InitializeComponent()
        {
            this.Text = "Seleccionar Rango de Fechas";
            this.Size = new System.Drawing.Size(350, 180);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            var lblDesde = new Label
            {
                Text = "Fecha Desde:",
                Location = new System.Drawing.Point(20, 20),
                Size = new System.Drawing.Size(100, 20)
            };

            this.dtpFechaDesde = new DateTimePicker
            {
                Format = DateTimePickerFormat.Short,
                Location = new System.Drawing.Point(130, 20),
                Size = new System.Drawing.Size(150, 20)
            };

            var lblHasta = new Label
            {
                Text = "Fecha Hasta:",
                Location = new System.Drawing.Point(20, 60),
                Size = new System.Drawing.Size(100, 20)
            };

            this.dtpFechaHasta = new DateTimePicker
            {
                Format = DateTimePickerFormat.Short,
                Location = new System.Drawing.Point(130, 60),
                Size = new System.Drawing.Size(150, 20)
            };

            var btnAceptar = new Button
            {
                Text = "Aceptar",
                Location = new System.Drawing.Point(120, 100),
                Size = new System.Drawing.Size(75, 30)
            };
            btnAceptar.Click += BtnAceptar_Click;

            var btnCancelar = new Button
            {
                Text = "Cancelar",
                DialogResult = DialogResult.Cancel,
                Location = new System.Drawing.Point(205, 100),
                Size = new System.Drawing.Size(75, 30)
            };

            this.Controls.AddRange(new Control[] { lblDesde, this.dtpFechaDesde, lblHasta, this.dtpFechaHasta, btnAceptar, btnCancelar });
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            FechaDesde = dtpFechaDesde.Value;
            FechaHasta = dtpFechaHasta.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59); // Hasta el final del día
        }
    }
}