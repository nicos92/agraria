namespace Agraria.UI.Reporte
{
    partial class FormReporte
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
            panelMenu = new Panel();
            flowLayoutPanel1 = new FlowLayoutPanel();
            btnHojaVida = new Button();
            btnProductos = new Button();
            btnMasVendidos = new Button();
            btnVentasGrandes = new Button();
            btnActividades = new Button();
            btnUsuarios = new Button();
            btnProveedores = new Button();
            btnHerramientas = new Button();
            btnEntornoFormativo = new Button();
            dgvReporte = new DataGridView();
            panel1 = new Panel();
            BtnImprimir = new Button();
            tableLayoutPanel1 = new TableLayoutPanel();
            button1 = new Button();
            panelMenu.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvReporte).BeginInit();
            panel1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // panelMenu
            // 
            panelMenu.BackColor = Color.FromArgb(203, 230, 255);
            panelMenu.Controls.Add(flowLayoutPanel1);
            panelMenu.Dock = DockStyle.Left;
            panelMenu.Location = new Point(0, 0);
            panelMenu.Name = "panelMenu";
            panelMenu.Size = new Size(227, 579);
            panelMenu.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.BackColor = Color.FromArgb(0, 75, 113);
            flowLayoutPanel1.Controls.Add(btnHojaVida);
            flowLayoutPanel1.Controls.Add(btnProductos);
            flowLayoutPanel1.Controls.Add(btnMasVendidos);
            flowLayoutPanel1.Controls.Add(btnVentasGrandes);
            flowLayoutPanel1.Controls.Add(btnActividades);
            flowLayoutPanel1.Controls.Add(btnUsuarios);
            flowLayoutPanel1.Controls.Add(btnProveedores);
            flowLayoutPanel1.Controls.Add(btnHerramientas);
            flowLayoutPanel1.Controls.Add(btnEntornoFormativo);
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.Location = new Point(0, 0);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(227, 579);
            flowLayoutPanel1.TabIndex = 11;
            // 
            // btnHojaVida
            // 
            btnHojaVida.BackColor = Color.FromArgb(7, 100, 147);
            btnHojaVida.FlatAppearance.BorderSize = 0;
            btnHojaVida.FlatStyle = FlatStyle.Flat;
            btnHojaVida.Font = new Font("Segoe UI", 12F);
            btnHojaVida.ForeColor = Color.White;
            btnHojaVida.Location = new Point(3, 3);
            btnHojaVida.Name = "btnHojaVida";
            btnHojaVida.Size = new Size(191, 56);
            btnHojaVida.TabIndex = 10;
            btnHojaVida.Text = "Hojas de Vida";
            btnHojaVida.UseVisualStyleBackColor = false;
            btnHojaVida.Click += BtnHojaVida_Click;
            // 
            // btnProductos
            // 
            btnProductos.BackColor = Color.FromArgb(7, 100, 147);
            btnProductos.FlatAppearance.BorderSize = 0;
            btnProductos.FlatStyle = FlatStyle.Flat;
            btnProductos.Font = new Font("Segoe UI", 12F);
            btnProductos.ForeColor = Color.White;
            btnProductos.Location = new Point(3, 65);
            btnProductos.Name = "btnProductos";
            btnProductos.Size = new Size(191, 56);
            btnProductos.TabIndex = 4;
            btnProductos.Text = "Productos";
            btnProductos.UseVisualStyleBackColor = false;
            btnProductos.Click += BtnProductos_Click;
            // 
            // btnMasVendidos
            // 
            btnMasVendidos.BackColor = Color.FromArgb(7, 100, 147);
            btnMasVendidos.FlatAppearance.BorderSize = 0;
            btnMasVendidos.FlatStyle = FlatStyle.Flat;
            btnMasVendidos.Font = new Font("Segoe UI", 12F);
            btnMasVendidos.ForeColor = Color.White;
            btnMasVendidos.Location = new Point(3, 127);
            btnMasVendidos.Name = "btnMasVendidos";
            btnMasVendidos.Size = new Size(191, 56);
            btnMasVendidos.TabIndex = 0;
            btnMasVendidos.Text = "Más vendidos";
            btnMasVendidos.UseVisualStyleBackColor = false;
            btnMasVendidos.Click += BtnMasVendidos_Click;
            // 
            // btnVentasGrandes
            // 
            btnVentasGrandes.BackColor = Color.FromArgb(7, 100, 147);
            btnVentasGrandes.FlatAppearance.BorderSize = 0;
            btnVentasGrandes.FlatStyle = FlatStyle.Flat;
            btnVentasGrandes.Font = new Font("Segoe UI", 12F);
            btnVentasGrandes.ForeColor = Color.White;
            btnVentasGrandes.Location = new Point(3, 189);
            btnVentasGrandes.Name = "btnVentasGrandes";
            btnVentasGrandes.Size = new Size(191, 56);
            btnVentasGrandes.TabIndex = 1;
            btnVentasGrandes.Text = "Ventas Grandes";
            btnVentasGrandes.UseVisualStyleBackColor = false;
            btnVentasGrandes.Click += BtnVentasGrandes_Click;
            // 
            // btnActividades
            // 
            btnActividades.BackColor = Color.FromArgb(7, 100, 147);
            btnActividades.FlatAppearance.BorderSize = 0;
            btnActividades.FlatStyle = FlatStyle.Flat;
            btnActividades.Font = new Font("Segoe UI", 12F);
            btnActividades.ForeColor = Color.White;
            btnActividades.Location = new Point(3, 251);
            btnActividades.Name = "btnActividades";
            btnActividades.Size = new Size(191, 56);
            btnActividades.TabIndex = 3;
            btnActividades.Text = "Actividades";
            btnActividades.UseVisualStyleBackColor = false;
            btnActividades.Click += BtnActividades_Click;
            // 
            // btnUsuarios
            // 
            btnUsuarios.BackColor = Color.FromArgb(7, 100, 147);
            btnUsuarios.FlatAppearance.BorderSize = 0;
            btnUsuarios.FlatStyle = FlatStyle.Flat;
            btnUsuarios.Font = new Font("Segoe UI", 12F);
            btnUsuarios.ForeColor = Color.White;
            btnUsuarios.Location = new Point(3, 313);
            btnUsuarios.Name = "btnUsuarios";
            btnUsuarios.Size = new Size(191, 56);
            btnUsuarios.TabIndex = 5;
            btnUsuarios.Text = "Usuarios";
            btnUsuarios.UseVisualStyleBackColor = false;
            btnUsuarios.Click += BtnUsuarios_Click;
            // 
            // btnProveedores
            // 
            btnProveedores.BackColor = Color.FromArgb(7, 100, 147);
            btnProveedores.FlatAppearance.BorderSize = 0;
            btnProveedores.FlatStyle = FlatStyle.Flat;
            btnProveedores.Font = new Font("Segoe UI", 12F);
            btnProveedores.ForeColor = Color.White;
            btnProveedores.Location = new Point(3, 375);
            btnProveedores.Name = "btnProveedores";
            btnProveedores.Size = new Size(191, 56);
            btnProveedores.TabIndex = 6;
            btnProveedores.Text = "Proveedores";
            btnProveedores.UseVisualStyleBackColor = false;
            btnProveedores.Click += BtnProveedores_Click;
            // 
            // btnHerramientas
            // 
            btnHerramientas.BackColor = Color.FromArgb(7, 100, 147);
            btnHerramientas.FlatAppearance.BorderSize = 0;
            btnHerramientas.FlatStyle = FlatStyle.Flat;
            btnHerramientas.Font = new Font("Segoe UI", 12F);
            btnHerramientas.ForeColor = Color.White;
            btnHerramientas.Location = new Point(3, 437);
            btnHerramientas.Name = "btnHerramientas";
            btnHerramientas.Size = new Size(191, 56);
            btnHerramientas.TabIndex = 7;
            btnHerramientas.Text = "Herramientas";
            btnHerramientas.UseVisualStyleBackColor = false;
            btnHerramientas.Click += BtnHerramientas_Click;
            // 
            // btnEntornoFormativo
            // 
            btnEntornoFormativo.BackColor = Color.FromArgb(7, 100, 147);
            btnEntornoFormativo.FlatAppearance.BorderSize = 0;
            btnEntornoFormativo.FlatStyle = FlatStyle.Flat;
            btnEntornoFormativo.Font = new Font("Segoe UI", 12F);
            btnEntornoFormativo.ForeColor = Color.White;
            btnEntornoFormativo.Location = new Point(3, 499);
            btnEntornoFormativo.Name = "btnEntornoFormativo";
            btnEntornoFormativo.Size = new Size(191, 56);
            btnEntornoFormativo.TabIndex = 9;
            btnEntornoFormativo.Text = "Entornos Formativos";
            btnEntornoFormativo.UseVisualStyleBackColor = false;
            btnEntornoFormativo.Click += BtnEntornoFormativo_Click;
            // 
            // dgvReporte
            // 
            dgvReporte.AllowUserToAddRows = false;
            dgvReporte.AllowUserToDeleteRows = false;
            dgvReporte.BackgroundColor = Color.FromArgb(0, 75, 113);
            dgvReporte.BorderStyle = BorderStyle.None;
            dgvReporte.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = Color.DimGray;
            dataGridViewCellStyle7.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle7.ForeColor = Color.White;
            dataGridViewCellStyle7.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = DataGridViewTriState.True;
            dgvReporte.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            dgvReporte.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = Color.FromArgb(83, 96, 108);
            dataGridViewCellStyle8.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle8.ForeColor = Color.White;
            dataGridViewCellStyle8.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = DataGridViewTriState.False;
            dgvReporte.DefaultCellStyle = dataGridViewCellStyle8;
            dgvReporte.Dock = DockStyle.Fill;
            dgvReporte.EnableHeadersVisualStyles = false;
            dgvReporte.Location = new Point(227, 64);
            dgvReporte.Name = "dgvReporte";
            dgvReporte.ReadOnly = true;
            dgvReporte.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvReporte.RowHeadersVisible = false;
            dgvReporte.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvReporte.Size = new Size(597, 515);
            dgvReporte.TabIndex = 1;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(0, 75, 113);
            panel1.Controls.Add(tableLayoutPanel1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(227, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(597, 64);
            panel1.TabIndex = 11;
            // 
            // BtnImprimir
            // 
            BtnImprimir.Anchor = AnchorStyles.None;
            BtnImprimir.BackColor = Color.FromArgb(65, 0, 2);
            BtnImprimir.FlatAppearance.BorderColor = Color.FromArgb(203, 230, 255);
            BtnImprimir.FlatStyle = FlatStyle.Flat;
            BtnImprimir.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            BtnImprimir.ForeColor = Color.FromArgb(255, 218, 214);
            BtnImprimir.Location = new Point(383, 16);
            BtnImprimir.Name = "BtnImprimir";
            BtnImprimir.Size = new Size(128, 32);
            BtnImprimir.TabIndex = 10;
            BtnImprimir.Text = "Exportar a PDF";
            BtnImprimir.UseVisualStyleBackColor = false;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(button1, 0, 0);
            tableLayoutPanel1.Controls.Add(BtnImprimir, 1, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(597, 64);
            tableLayoutPanel1.TabIndex = 11;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.None;
            button1.BackColor = Color.FromArgb(83, 96, 108);
            button1.FlatAppearance.BorderColor = Color.FromArgb(203, 230, 255);
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            button1.ForeColor = Color.White;
            button1.Location = new Point(85, 16);
            button1.Name = "button1";
            button1.Size = new Size(128, 32);
            button1.TabIndex = 11;
            button1.Text = "Imprimir";
            button1.UseVisualStyleBackColor = false;
            // 
            // FormReporte
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(203, 230, 255);
            ClientSize = new Size(824, 579);
            Controls.Add(dgvReporte);
            Controls.Add(panel1);
            Controls.Add(panelMenu);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormReporte";
            Text = "FormReporte";
            panelMenu.ResumeLayout(false);
            flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvReporte).EndInit();
            panel1.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Button btnMasVendidos;
        private System.Windows.Forms.DataGridView dgvReporte;
        private System.Windows.Forms.Button btnVentasGrandes;
        private System.Windows.Forms.Button btnActividades;
        private System.Windows.Forms.Button btnProductos;
        private System.Windows.Forms.Button btnUsuarios;
        private System.Windows.Forms.Button btnProveedores;
        private System.Windows.Forms.Button btnHerramientas;
        private System.Windows.Forms.Button btnEntornoFormativo;
        private System.Windows.Forms.Button btnHojaVida;
        private FlowLayoutPanel flowLayoutPanel1;
        private Panel panel1;
        private TableLayoutPanel tableLayoutPanel1;
        private Button button1;
        private Button BtnImprimir;
    }
}
