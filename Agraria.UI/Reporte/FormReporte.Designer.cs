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
            panelMenu = new Panel();
            btnHojaVida = new Button();
            btnEntornoFormativo = new Button();
            btnEntorno = new Button();
            btnHerramientas = new Button();
            btnProveedores = new Button();
            btnUsuarios = new Button();
            btnProductos = new Button();
            btnActividades = new Button();
            btnStock = new Button();
            btnVentasGrandes = new Button();
            btnMasVendidos = new Button();
            dgvReporte = new DataGridView();
            panelMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvReporte).BeginInit();
            SuspendLayout();
            // 
            // panelMenu
            // 
            panelMenu.BackColor = Color.FromArgb(203, 230, 255);
            panelMenu.Controls.Add(btnHojaVida);
            panelMenu.Controls.Add(btnEntornoFormativo);
            panelMenu.Controls.Add(btnEntorno);
            panelMenu.Controls.Add(btnHerramientas);
            panelMenu.Controls.Add(btnProveedores);
            panelMenu.Controls.Add(btnUsuarios);
            panelMenu.Controls.Add(btnProductos);
            panelMenu.Controls.Add(btnActividades);
            panelMenu.Controls.Add(btnStock);
            panelMenu.Controls.Add(btnVentasGrandes);
            panelMenu.Controls.Add(btnMasVendidos);
            panelMenu.Dock = DockStyle.Left;
            panelMenu.Location = new Point(0, 0);
            panelMenu.Name = "panelMenu";
            panelMenu.Size = new Size(200, 579);
            panelMenu.TabIndex = 0;
            // 
            // btnHojaVida
            // 
            btnHojaVida.Location = new Point(12, 402);
            btnHojaVida.Name = "btnHojaVida";
            btnHojaVida.Size = new Size(176, 33);
            btnHojaVida.TabIndex = 10;
            btnHojaVida.Text = "Reporte de Hojas de Vida";
            btnHojaVida.UseVisualStyleBackColor = true;
            btnHojaVida.Click += btnHojaVida_Click;
            // 
            // btnEntornoFormativo
            // 
            btnEntornoFormativo.Location = new Point(12, 363);
            btnEntornoFormativo.Name = "btnEntornoFormativo";
            btnEntornoFormativo.Size = new Size(176, 33);
            btnEntornoFormativo.TabIndex = 9;
            btnEntornoFormativo.Text = "Reporte de Entornos Formativos";
            btnEntornoFormativo.UseVisualStyleBackColor = true;
            btnEntornoFormativo.Click += btnEntornoFormativo_Click;
            // 
            // btnEntorno
            // 
            btnEntorno.Location = new Point(12, 324);
            btnEntorno.Name = "btnEntorno";
            btnEntorno.Size = new Size(176, 33);
            btnEntorno.TabIndex = 8;
            btnEntorno.Text = "Reporte de Entornos";
            btnEntorno.UseVisualStyleBackColor = true;
            btnEntorno.Click += btnEntorno_Click;
            // 
            // btnHerramientas
            // 
            btnHerramientas.Location = new Point(12, 285);
            btnHerramientas.Name = "btnHerramientas";
            btnHerramientas.Size = new Size(176, 33);
            btnHerramientas.TabIndex = 7;
            btnHerramientas.Text = "Reporte de Herramientas";
            btnHerramientas.UseVisualStyleBackColor = true;
            btnHerramientas.Click += btnHerramientas_Click;
            // 
            // btnProveedores
            // 
            btnProveedores.Location = new Point(12, 246);
            btnProveedores.Name = "btnProveedores";
            btnProveedores.Size = new Size(176, 33);
            btnProveedores.TabIndex = 6;
            btnProveedores.Text = "Reporte de Proveedores";
            btnProveedores.UseVisualStyleBackColor = true;
            btnProveedores.Click += btnProveedores_Click;
            // 
            // btnUsuarios
            // 
            btnUsuarios.Location = new Point(12, 207);
            btnUsuarios.Name = "btnUsuarios";
            btnUsuarios.Size = new Size(176, 33);
            btnUsuarios.TabIndex = 5;
            btnUsuarios.Text = "Reporte de Usuarios";
            btnUsuarios.UseVisualStyleBackColor = true;
            btnUsuarios.Click += btnUsuarios_Click;
            // 
            // btnProductos
            // 
            btnProductos.Location = new Point(12, 168);
            btnProductos.Name = "btnProductos";
            btnProductos.Size = new Size(176, 33);
            btnProductos.TabIndex = 4;
            btnProductos.Text = "Reporte de Productos";
            btnProductos.UseVisualStyleBackColor = true;
            btnProductos.Click += btnProductos_Click;
            // 
            // btnActividades
            // 
            btnActividades.Location = new Point(12, 129);
            btnActividades.Name = "btnActividades";
            btnActividades.Size = new Size(176, 33);
            btnActividades.TabIndex = 3;
            btnActividades.Text = "Reporte de Actividades";
            btnActividades.UseVisualStyleBackColor = true;
            btnActividades.Click += btnActividades_Click;
            // 
            // btnStock
            // 
            btnStock.Location = new Point(12, 90);
            btnStock.Name = "btnStock";
            btnStock.Size = new Size(176, 33);
            btnStock.TabIndex = 2;
            btnStock.Text = "Stock Actual";
            btnStock.UseVisualStyleBackColor = true;
            btnStock.Click += btnStock_Click;
            // 
            // btnVentasGrandes
            // 
            btnVentasGrandes.Location = new Point(12, 51);
            btnVentasGrandes.Name = "btnVentasGrandes";
            btnVentasGrandes.Size = new Size(176, 33);
            btnVentasGrandes.TabIndex = 1;
            btnVentasGrandes.Text = "Ventas Grandes";
            btnVentasGrandes.UseVisualStyleBackColor = true;
            btnVentasGrandes.Click += btnVentasGrandes_Click;
            // 
            // btnMasVendidos
            // 
            btnMasVendidos.Location = new Point(12, 12);
            btnMasVendidos.Name = "btnMasVendidos";
            btnMasVendidos.Size = new Size(176, 33);
            btnMasVendidos.TabIndex = 0;
            btnMasVendidos.Text = "Artículos más vendidos";
            btnMasVendidos.UseVisualStyleBackColor = true;
            btnMasVendidos.Click += btnMasVendidos_Click;
            // 
            // dgvReporte
            // 
            dgvReporte.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvReporte.Dock = DockStyle.Fill;
            dgvReporte.Location = new Point(200, 0);
            dgvReporte.Name = "dgvReporte";
            dgvReporte.Size = new Size(624, 579);
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
            ((System.ComponentModel.ISupportInitialize)dgvReporte).EndInit();
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Button btnMasVendidos;
        private System.Windows.Forms.DataGridView dgvReporte;
        private System.Windows.Forms.Button btnStock;
        private System.Windows.Forms.Button btnVentasGrandes;
        private System.Windows.Forms.Button btnActividades;
        private System.Windows.Forms.Button btnProductos;
        private System.Windows.Forms.Button btnUsuarios;
        private System.Windows.Forms.Button btnProveedores;
        private System.Windows.Forms.Button btnHerramientas;
        private System.Windows.Forms.Button btnEntorno;
        private System.Windows.Forms.Button btnEntornoFormativo;
        private System.Windows.Forms.Button btnHojaVida;
    }
}
