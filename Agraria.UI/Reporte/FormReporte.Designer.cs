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
            this.panelMenu = new System.Windows.Forms.Panel();
            this.btnStock = new System.Windows.Forms.Button();
            this.btnVentasPeriodo = new System.Windows.Forms.Button();
            this.btnMasVendidos = new System.Windows.Forms.Button();
            this.dgvReporte = new System.Windows.Forms.DataGridView();
            this.panelMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReporte)).BeginInit();
            this.SuspendLayout();
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            this.panelMenu.Controls.Add(this.btnStock);
            this.panelMenu.Controls.Add(this.btnVentasPeriodo);
            this.panelMenu.Controls.Add(this.btnMasVendidos);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(200, 579);
            this.panelMenu.TabIndex = 0;
            // 
            // btnStock
            // 
            this.btnStock.Location = new System.Drawing.Point(12, 90);
            this.btnStock.Name = "btnStock";
            this.btnStock.Size = new System.Drawing.Size(176, 33);
            this.btnStock.TabIndex = 2;
            this.btnStock.Text = "Stock Actual";
            this.btnStock.UseVisualStyleBackColor = true;
            this.btnStock.Click += new System.EventHandler(this.btnStock_Click);
            // 
            // btnVentasPeriodo
            // 
            this.btnVentasPeriodo.Location = new System.Drawing.Point(12, 51);
            this.btnVentasPeriodo.Name = "btnVentasPeriodo";
            this.btnVentasPeriodo.Size = new System.Drawing.Size(176, 33);
            this.btnVentasPeriodo.TabIndex = 1;
            this.btnVentasPeriodo.Text = "Ventas por Período";
            this.btnVentasPeriodo.UseVisualStyleBackColor = true;
            this.btnVentasPeriodo.Click += new System.EventHandler(this.btnVentasPeriodo_Click);
            // 
            // btnMasVendidos
            // 
            this.btnMasVendidos.Location = new System.Drawing.Point(12, 12);
            this.btnMasVendidos.Name = "btnMasVendidos";
            this.btnMasVendidos.Size = new System.Drawing.Size(176, 33);
            this.btnMasVendidos.TabIndex = 0;
            this.btnMasVendidos.Text = "Artículos más vendidos";
            this.btnMasVendidos.UseVisualStyleBackColor = true;
            this.btnMasVendidos.Click += new System.EventHandler(this.btnMasVendidos_Click);
            // 
            // dgvReporte
            // 
            this.dgvReporte.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReporte.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvReporte.Location = new System.Drawing.Point(200, 0);
            this.dgvReporte.Name = "dgvReporte";
            this.dgvReporte.Size = new System.Drawing.Size(624, 579);
            this.dgvReporte.TabIndex = 1;
            // 
            // FormReporte
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(824, 579);
            this.Controls.Add(this.dgvReporte);
            this.Controls.Add(this.panelMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormReporte";
            this.Text = "FormReporte";
            this.panelMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvReporte)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Button btnMasVendidos;
        private System.Windows.Forms.DataGridView dgvReporte;
        private System.Windows.Forms.Button btnStock;
        private System.Windows.Forms.Button btnVentasPeriodo;
    }
}
