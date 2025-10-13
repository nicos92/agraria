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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            panelMenu = new Panel();
            flowLayoutPanel1 = new FlowLayoutPanel();
            btnHojaVida = new Button();
            btnMasVendidos = new Button();
            btnVentasGrandes = new Button();
            btnActividades = new Button();
            btnProductos = new Button();
            btnUsuarios = new Button();
            btnProveedores = new Button();
            btnHerramientas = new Button();
            btnEntorno = new Button();
            btnEntornoFormativo = new Button();
            dgvReporte = new DataGridView();
            panelMenu.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvReporte).BeginInit();
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
            flowLayoutPanel1.Controls.Add(btnEntorno);
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
            btnHojaVida.Size = new Size(191, 64);
            btnHojaVida.TabIndex = 10;
            btnHojaVida.Text = "Hojas de Vida";
            btnHojaVida.UseVisualStyleBackColor = false;
            btnHojaVida.Click += BtnHojaVida_Click;
            // 
            // btnMasVendidos
            // 
            btnMasVendidos.BackColor = Color.FromArgb(7, 100, 147);
            btnMasVendidos.FlatAppearance.BorderSize = 0;
            btnMasVendidos.FlatStyle = FlatStyle.Flat;
            btnMasVendidos.Font = new Font("Segoe UI", 12F);
            btnMasVendidos.ForeColor = Color.White;
            btnMasVendidos.Location = new Point(3, 143);
            btnMasVendidos.Name = "btnMasVendidos";
            btnMasVendidos.Size = new Size(191, 64);
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
            btnVentasGrandes.Location = new Point(3, 213);
            btnVentasGrandes.Name = "btnVentasGrandes";
            btnVentasGrandes.Size = new Size(191, 64);
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
            btnActividades.Location = new Point(3, 283);
            btnActividades.Name = "btnActividades";
            btnActividades.Size = new Size(191, 64);
            btnActividades.TabIndex = 3;
            btnActividades.Text = "Actividades";
            btnActividades.UseVisualStyleBackColor = false;
            btnActividades.Click += BtnActividades_Click;
            // 
            // btnProductos
            // 
            btnProductos.BackColor = Color.FromArgb(7, 100, 147);
            btnProductos.FlatAppearance.BorderSize = 0;
            btnProductos.FlatStyle = FlatStyle.Flat;
            btnProductos.Font = new Font("Segoe UI", 12F);
            btnProductos.ForeColor = Color.White;
            btnProductos.Location = new Point(3, 73);
            btnProductos.Name = "btnProductos";
            btnProductos.Size = new Size(191, 64);
            btnProductos.TabIndex = 4;
            btnProductos.Text = "Productos";
            btnProductos.UseVisualStyleBackColor = false;
            btnProductos.Click += BtnProductos_Click;
            // 
            // btnUsuarios
            // 
            btnUsuarios.BackColor = Color.FromArgb(7, 100, 147);
            btnUsuarios.FlatAppearance.BorderSize = 0;
            btnUsuarios.FlatStyle = FlatStyle.Flat;
            btnUsuarios.Font = new Font("Segoe UI", 12F);
            btnUsuarios.ForeColor = Color.White;
            btnUsuarios.Location = new Point(3, 353);
            btnUsuarios.Name = "btnUsuarios";
            btnUsuarios.Size = new Size(191, 64);
            btnUsuarios.TabIndex = 5;
            btnUsuarios.Text = "Reporte de Usuarios";
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
            btnProveedores.Location = new Point(3, 423);
            btnProveedores.Name = "btnProveedores";
            btnProveedores.Size = new Size(191, 64);
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
            btnHerramientas.Location = new Point(3, 493);
            btnHerramientas.Name = "btnHerramientas";
            btnHerramientas.Size = new Size(191, 64);
            btnHerramientas.TabIndex = 7;
            btnHerramientas.Text = "Herramientas";
            btnHerramientas.UseVisualStyleBackColor = false;
            btnHerramientas.Click += BtnHerramientas_Click;
            // 
            // btnEntorno
            // 
            btnEntorno.BackColor = Color.FromArgb(7, 100, 147);
            btnEntorno.FlatAppearance.BorderSize = 0;
            btnEntorno.FlatStyle = FlatStyle.Flat;
            btnEntorno.Font = new Font("Segoe UI", 12F);
            btnEntorno.ForeColor = Color.White;
            btnEntorno.Location = new Point(3, 563);
            btnEntorno.Name = "btnEntorno";
            btnEntorno.Size = new Size(191, 64);
            btnEntorno.TabIndex = 8;
            btnEntorno.Text = "Entornos";
            btnEntorno.UseVisualStyleBackColor = false;
            btnEntorno.Click += BtnEntorno_Click;
            // 
            // btnEntornoFormativo
            // 
            btnEntornoFormativo.BackColor = Color.FromArgb(7, 100, 147);
            btnEntornoFormativo.FlatAppearance.BorderSize = 0;
            btnEntornoFormativo.FlatStyle = FlatStyle.Flat;
            btnEntornoFormativo.Font = new Font("Segoe UI", 12F);
            btnEntornoFormativo.ForeColor = Color.White;
            btnEntornoFormativo.Location = new Point(3, 633);
            btnEntornoFormativo.Name = "btnEntornoFormativo";
            btnEntornoFormativo.Size = new Size(191, 64);
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
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.DimGray;
            dataGridViewCellStyle1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvReporte.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvReporte.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(83, 96, 108);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvReporte.DefaultCellStyle = dataGridViewCellStyle2;
            dgvReporte.Dock = DockStyle.Fill;
            dgvReporte.EnableHeadersVisualStyles = false;
            dgvReporte.Location = new Point(227, 0);
            dgvReporte.Name = "dgvReporte";
            dgvReporte.ReadOnly = true;
            dgvReporte.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvReporte.RowHeadersVisible = false;
            dgvReporte.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvReporte.Size = new Size(597, 579);
            dgvReporte.TabIndex = 1;
            // 
            // FormReporte
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(203, 230, 255);
            ClientSize = new Size(824, 579);
            Controls.Add(dgvReporte);
            Controls.Add(panelMenu);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormReporte";
            Text = "FormReporte";
            panelMenu.ResumeLayout(false);
            flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvReporte).EndInit();
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
        private System.Windows.Forms.Button btnEntorno;
        private System.Windows.Forms.Button btnEntornoFormativo;
        private System.Windows.Forms.Button btnHojaVida;
        private FlowLayoutPanel flowLayoutPanel1;
    }
}
