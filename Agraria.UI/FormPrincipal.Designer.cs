namespace Agraria.UI
{
    partial class FormPrincipal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPrincipal));
            PanelMenu = new Panel();
            BtnProveedores = new Button();
            BtnUsuarios = new Button();
            BtnReporte = new Button();
            BtnVenta = new Button();
            BtnIndustrial = new Button();
            BtnVegetal = new Button();
            BtnAnimal = new Button();
            BtnActividad = new Button();
            PanelLblMenu = new Panel();
            LblEscuelaAgraria = new Label();
            PanelMenu.SuspendLayout();
            PanelLblMenu.SuspendLayout();
            SuspendLayout();
            // 
            // PanelMenu
            // 
            PanelMenu.BackColor = Color.FromArgb(7, 100, 147);
            PanelMenu.Controls.Add(BtnProveedores);
            PanelMenu.Controls.Add(BtnUsuarios);
            PanelMenu.Controls.Add(BtnReporte);
            PanelMenu.Controls.Add(BtnVenta);
            PanelMenu.Controls.Add(BtnIndustrial);
            PanelMenu.Controls.Add(BtnVegetal);
            PanelMenu.Controls.Add(BtnAnimal);
            PanelMenu.Controls.Add(BtnActividad);
            PanelMenu.Controls.Add(PanelLblMenu);
            PanelMenu.Dock = DockStyle.Left;
            PanelMenu.Location = new Point(0, 0);
            PanelMenu.Margin = new Padding(4);
            PanelMenu.Name = "PanelMenu";
            PanelMenu.Size = new Size(200, 579);
            PanelMenu.TabIndex = 0;
            // 
            // BtnProveedores
            // 
            BtnProveedores.Cursor = Cursors.Hand;
            BtnProveedores.Dock = DockStyle.Top;
            BtnProveedores.FlatAppearance.BorderSize = 0;
            BtnProveedores.FlatStyle = FlatStyle.Flat;
            BtnProveedores.ForeColor = SystemColors.ButtonHighlight;
            BtnProveedores.Image = Properties.Resources.proveedores;
            BtnProveedores.ImageAlign = ContentAlignment.MiddleLeft;
            BtnProveedores.Location = new Point(0, 512);
            BtnProveedores.Margin = new Padding(4);
            BtnProveedores.Name = "BtnProveedores";
            BtnProveedores.Padding = new Padding(8, 0, 0, 0);
            BtnProveedores.Size = new Size(200, 64);
            BtnProveedores.TabIndex = 8;
            BtnProveedores.Text = "Proveedores";
            BtnProveedores.TextImageRelation = TextImageRelation.ImageBeforeText;
            BtnProveedores.UseVisualStyleBackColor = true;
            BtnProveedores.Click += BtnActividad_Click;
            // 
            // BtnUsuarios
            // 
            BtnUsuarios.Cursor = Cursors.Hand;
            BtnUsuarios.Dock = DockStyle.Top;
            BtnUsuarios.FlatAppearance.BorderSize = 0;
            BtnUsuarios.FlatStyle = FlatStyle.Flat;
            BtnUsuarios.ForeColor = SystemColors.ButtonHighlight;
            BtnUsuarios.Image = Properties.Resources.users2;
            BtnUsuarios.ImageAlign = ContentAlignment.MiddleLeft;
            BtnUsuarios.Location = new Point(0, 448);
            BtnUsuarios.Margin = new Padding(4);
            BtnUsuarios.Name = "BtnUsuarios";
            BtnUsuarios.Padding = new Padding(8, 0, 0, 0);
            BtnUsuarios.Size = new Size(200, 64);
            BtnUsuarios.TabIndex = 7;
            BtnUsuarios.Text = "Usuarios";
            BtnUsuarios.TextImageRelation = TextImageRelation.ImageBeforeText;
            BtnUsuarios.UseVisualStyleBackColor = true;
            BtnUsuarios.Click += BtnActividad_Click;
            // 
            // BtnReporte
            // 
            BtnReporte.Cursor = Cursors.Hand;
            BtnReporte.Dock = DockStyle.Top;
            BtnReporte.FlatAppearance.BorderSize = 0;
            BtnReporte.FlatStyle = FlatStyle.Flat;
            BtnReporte.ForeColor = SystemColors.ButtonHighlight;
            BtnReporte.Image = Properties.Resources.charts;
            BtnReporte.ImageAlign = ContentAlignment.MiddleLeft;
            BtnReporte.Location = new Point(0, 384);
            BtnReporte.Margin = new Padding(4);
            BtnReporte.Name = "BtnReporte";
            BtnReporte.Padding = new Padding(8, 0, 0, 0);
            BtnReporte.Size = new Size(200, 64);
            BtnReporte.TabIndex = 6;
            BtnReporte.Text = "Reporte";
            BtnReporte.TextImageRelation = TextImageRelation.ImageBeforeText;
            BtnReporte.UseVisualStyleBackColor = true;
            BtnReporte.Click += BtnActividad_Click;
            // 
            // BtnVenta
            // 
            BtnVenta.Cursor = Cursors.Hand;
            BtnVenta.Dock = DockStyle.Top;
            BtnVenta.FlatAppearance.BorderSize = 0;
            BtnVenta.FlatStyle = FlatStyle.Flat;
            BtnVenta.ForeColor = SystemColors.ButtonHighlight;
            BtnVenta.Image = Properties.Resources.venta;
            BtnVenta.ImageAlign = ContentAlignment.MiddleLeft;
            BtnVenta.Location = new Point(0, 320);
            BtnVenta.Margin = new Padding(4);
            BtnVenta.Name = "BtnVenta";
            BtnVenta.Padding = new Padding(8, 0, 0, 0);
            BtnVenta.Size = new Size(200, 64);
            BtnVenta.TabIndex = 5;
            BtnVenta.Text = "Venta";
            BtnVenta.TextImageRelation = TextImageRelation.ImageBeforeText;
            BtnVenta.UseVisualStyleBackColor = true;
            BtnVenta.Click += BtnActividad_Click;
            // 
            // BtnIndustrial
            // 
            BtnIndustrial.Cursor = Cursors.Hand;
            BtnIndustrial.Dock = DockStyle.Top;
            BtnIndustrial.FlatAppearance.BorderSize = 0;
            BtnIndustrial.FlatStyle = FlatStyle.Flat;
            BtnIndustrial.ForeColor = SystemColors.ButtonHighlight;
            BtnIndustrial.Image = Properties.Resources.industrial;
            BtnIndustrial.ImageAlign = ContentAlignment.MiddleLeft;
            BtnIndustrial.Location = new Point(0, 256);
            BtnIndustrial.Margin = new Padding(4);
            BtnIndustrial.Name = "BtnIndustrial";
            BtnIndustrial.Padding = new Padding(8, 0, 0, 0);
            BtnIndustrial.Size = new Size(200, 64);
            BtnIndustrial.TabIndex = 4;
            BtnIndustrial.Text = "Inventario";
            BtnIndustrial.TextImageRelation = TextImageRelation.ImageBeforeText;
            BtnIndustrial.UseVisualStyleBackColor = true;
            BtnIndustrial.Click += BtnActividad_Click;
            // 
            // BtnVegetal
            // 
            BtnVegetal.Cursor = Cursors.Hand;
            BtnVegetal.Dock = DockStyle.Top;
            BtnVegetal.FlatAppearance.BorderSize = 0;
            BtnVegetal.FlatStyle = FlatStyle.Flat;
            BtnVegetal.ForeColor = SystemColors.ButtonHighlight;
            BtnVegetal.Image = Properties.Resources.vegetal;
            BtnVegetal.ImageAlign = ContentAlignment.MiddleLeft;
            BtnVegetal.Location = new Point(0, 192);
            BtnVegetal.Margin = new Padding(4);
            BtnVegetal.Name = "BtnVegetal";
            BtnVegetal.Padding = new Padding(8, 0, 0, 0);
            BtnVegetal.Size = new Size(200, 64);
            BtnVegetal.TabIndex = 3;
            BtnVegetal.Text = "Vegetal";
            BtnVegetal.TextImageRelation = TextImageRelation.ImageBeforeText;
            BtnVegetal.UseVisualStyleBackColor = true;
            BtnVegetal.Click += BtnActividad_Click;
            // 
            // BtnAnimal
            // 
            BtnAnimal.Cursor = Cursors.Hand;
            BtnAnimal.Dock = DockStyle.Top;
            BtnAnimal.FlatAppearance.BorderSize = 0;
            BtnAnimal.FlatStyle = FlatStyle.Flat;
            BtnAnimal.ForeColor = SystemColors.ButtonHighlight;
            BtnAnimal.Image = Properties.Resources.animal;
            BtnAnimal.ImageAlign = ContentAlignment.MiddleLeft;
            BtnAnimal.Location = new Point(0, 128);
            BtnAnimal.Margin = new Padding(4);
            BtnAnimal.Name = "BtnAnimal";
            BtnAnimal.Padding = new Padding(8, 0, 0, 0);
            BtnAnimal.Size = new Size(200, 64);
            BtnAnimal.TabIndex = 2;
            BtnAnimal.Text = "Productos";
            BtnAnimal.TextImageRelation = TextImageRelation.ImageBeforeText;
            BtnAnimal.UseVisualStyleBackColor = true;
            BtnAnimal.Click += BtnActividad_Click;
            // 
            // BtnActividad
            // 
            BtnActividad.Cursor = Cursors.Hand;
            BtnActividad.Dock = DockStyle.Top;
            BtnActividad.FlatAppearance.BorderSize = 0;
            BtnActividad.FlatStyle = FlatStyle.Flat;
            BtnActividad.ForeColor = SystemColors.ButtonHighlight;
            BtnActividad.Image = Properties.Resources.actividad;
            BtnActividad.ImageAlign = ContentAlignment.MiddleLeft;
            BtnActividad.Location = new Point(0, 64);
            BtnActividad.Margin = new Padding(4);
            BtnActividad.Name = "BtnActividad";
            BtnActividad.Padding = new Padding(8, 0, 0, 0);
            BtnActividad.Size = new Size(200, 64);
            BtnActividad.TabIndex = 1;
            BtnActividad.Text = "Actividad";
            BtnActividad.TextImageRelation = TextImageRelation.ImageBeforeText;
            BtnActividad.UseVisualStyleBackColor = true;
            BtnActividad.Click += BtnActividad_Click;
            // 
            // PanelLblMenu
            // 
            PanelLblMenu.Controls.Add(LblEscuelaAgraria);
            PanelLblMenu.Dock = DockStyle.Top;
            PanelLblMenu.Location = new Point(0, 0);
            PanelLblMenu.Margin = new Padding(4);
            PanelLblMenu.Name = "PanelLblMenu";
            PanelLblMenu.Size = new Size(200, 64);
            PanelLblMenu.TabIndex = 0;
            // 
            // LblEscuelaAgraria
            // 
            LblEscuelaAgraria.Dock = DockStyle.Fill;
            LblEscuelaAgraria.Font = new Font("Segoe UI Black", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LblEscuelaAgraria.ForeColor = SystemColors.ButtonHighlight;
            LblEscuelaAgraria.Location = new Point(0, 0);
            LblEscuelaAgraria.Name = "LblEscuelaAgraria";
            LblEscuelaAgraria.Size = new Size(200, 64);
            LblEscuelaAgraria.TabIndex = 0;
            LblEscuelaAgraria.Text = "Escuela Agraria";
            LblEscuelaAgraria.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // FormPrincipal
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(1024, 579);
            Controls.Add(PanelMenu);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Icon = (Icon)resources.GetObject("$this.Icon");
            IsMdiContainer = true;
            Margin = new Padding(4);
            MinimumSize = new Size(1040, 600);
            Name = "FormPrincipal";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormPrincipal";
            Load += FormPrincipal_Load;
            PanelMenu.ResumeLayout(false);
            PanelLblMenu.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel PanelMenu;
        private Button BtnActividad;
        private Panel PanelLblMenu;
        private Button BtnProveedores;
        private Button BtnUsuarios;
        private Button BtnReporte;
        private Button BtnVenta;
        private Button BtnIndustrial;
        private Button BtnVegetal;
        private Button BtnAnimal;
        private Label LblEscuelaAgraria;
    }
}