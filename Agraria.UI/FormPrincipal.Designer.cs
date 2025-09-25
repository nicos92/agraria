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
            BtnEntornos = new Button();
            BtnPaniol = new Button();
            BtnProveedores = new Button();
            BtnRemitoProduccion = new Button();
            BtnUsuarios = new Button();
            BtnReporte = new Button();
            BtnVenta = new Button();
            BtnInventario = new Button();
            BtnHojaVida = new Button();
            BtnProductos = new Button();
            BtnActividad = new Button();
            PanelLblMenu = new Panel();
            LblEscuelaAgraria = new Label();
            panel1 = new Panel();
            tableLayoutPanel1 = new TableLayoutPanel();
            LblModulo = new Label();
            LblTipoUsuario = new Label();
            label3 = new Label();
            LblUsuario = new Label();
            label1 = new Label();
            PanelMenu.SuspendLayout();
            PanelLblMenu.SuspendLayout();
            panel1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // PanelMenu
            // 
            PanelMenu.AutoScroll = true;
            PanelMenu.BackColor = Color.FromArgb(7, 100, 147);
            PanelMenu.Controls.Add(BtnEntornos);
            PanelMenu.Controls.Add(BtnPaniol);
            PanelMenu.Controls.Add(BtnProveedores);
            PanelMenu.Controls.Add(BtnRemitoProduccion);
            PanelMenu.Controls.Add(BtnUsuarios);
            PanelMenu.Controls.Add(BtnReporte);
            PanelMenu.Controls.Add(BtnVenta);
            PanelMenu.Controls.Add(BtnInventario);
            PanelMenu.Controls.Add(BtnHojaVida);
            PanelMenu.Controls.Add(BtnProductos);
            PanelMenu.Controls.Add(BtnActividad);
            PanelMenu.Controls.Add(PanelLblMenu);
            PanelMenu.Dock = DockStyle.Left;
            PanelMenu.Location = new Point(0, 0);
            PanelMenu.Margin = new Padding(4);
            PanelMenu.Name = "PanelMenu";
            PanelMenu.Size = new Size(200, 661);
            PanelMenu.TabIndex = 0;
            // 
            // BtnEntornos
            // 
            BtnEntornos.Cursor = Cursors.Hand;
            BtnEntornos.Dock = DockStyle.Top;
            BtnEntornos.FlatAppearance.BorderSize = 0;
            BtnEntornos.FlatStyle = FlatStyle.Flat;
            BtnEntornos.ForeColor = SystemColors.ButtonHighlight;
            BtnEntornos.Image = Properties.Resources.entornos;
            BtnEntornos.ImageAlign = ContentAlignment.MiddleLeft;
            BtnEntornos.Location = new Point(0, 704);
            BtnEntornos.Margin = new Padding(4);
            BtnEntornos.Name = "BtnEntornos";
            BtnEntornos.Padding = new Padding(8, 0, 0, 0);
            BtnEntornos.Size = new Size(183, 64);
            BtnEntornos.TabIndex = 11;
            BtnEntornos.Text = "Entornos";
            BtnEntornos.TextImageRelation = TextImageRelation.ImageBeforeText;
            BtnEntornos.UseVisualStyleBackColor = true;
            BtnEntornos.Click += BtnActividad_Click;
            // 
            // BtnPaniol
            // 
            BtnPaniol.Cursor = Cursors.Hand;
            BtnPaniol.Dock = DockStyle.Top;
            BtnPaniol.FlatAppearance.BorderSize = 0;
            BtnPaniol.FlatStyle = FlatStyle.Flat;
            BtnPaniol.ForeColor = SystemColors.ButtonHighlight;
            BtnPaniol.Image = Properties.Resources.paniol32px;
            BtnPaniol.ImageAlign = ContentAlignment.MiddleLeft;
            BtnPaniol.Location = new Point(0, 640);
            BtnPaniol.Margin = new Padding(4);
            BtnPaniol.Name = "BtnPaniol";
            BtnPaniol.Padding = new Padding(8, 0, 0, 0);
            BtnPaniol.Size = new Size(183, 64);
            BtnPaniol.TabIndex = 10;
            BtnPaniol.Text = "Pañol";
            BtnPaniol.TextImageRelation = TextImageRelation.ImageBeforeText;
            BtnPaniol.UseVisualStyleBackColor = true;
            BtnPaniol.Click += BtnActividad_Click;
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
            BtnProveedores.Location = new Point(0, 576);
            BtnProveedores.Margin = new Padding(4);
            BtnProveedores.Name = "BtnProveedores";
            BtnProveedores.Padding = new Padding(8, 0, 0, 0);
            BtnProveedores.Size = new Size(183, 64);
            BtnProveedores.TabIndex = 8;
            BtnProveedores.Text = "Proveedores";
            BtnProveedores.TextImageRelation = TextImageRelation.ImageBeforeText;
            BtnProveedores.UseVisualStyleBackColor = true;
            BtnProveedores.Click += BtnActividad_Click;
            // 
            // BtnRemitoProduccion
            // 
            BtnRemitoProduccion.Cursor = Cursors.Hand;
            BtnRemitoProduccion.Dock = DockStyle.Top;
            BtnRemitoProduccion.FlatAppearance.BorderSize = 0;
            BtnRemitoProduccion.FlatStyle = FlatStyle.Flat;
            BtnRemitoProduccion.ForeColor = SystemColors.ButtonHighlight;
            BtnRemitoProduccion.Image = Properties.Resources.remito32px;
            BtnRemitoProduccion.ImageAlign = ContentAlignment.MiddleLeft;
            BtnRemitoProduccion.Location = new Point(0, 512);
            BtnRemitoProduccion.Margin = new Padding(4);
            BtnRemitoProduccion.Name = "BtnRemitoProduccion";
            BtnRemitoProduccion.Padding = new Padding(8, 0, 0, 0);
            BtnRemitoProduccion.Size = new Size(183, 64);
            BtnRemitoProduccion.TabIndex = 9;
            BtnRemitoProduccion.Text = "Remito Producción";
            BtnRemitoProduccion.TextImageRelation = TextImageRelation.ImageBeforeText;
            BtnRemitoProduccion.UseVisualStyleBackColor = true;
            BtnRemitoProduccion.Click += BtnActividad_Click;
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
            BtnUsuarios.Size = new Size(183, 64);
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
            BtnReporte.Size = new Size(183, 64);
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
            BtnVenta.Size = new Size(183, 64);
            BtnVenta.TabIndex = 5;
            BtnVenta.Text = "Venta";
            BtnVenta.TextImageRelation = TextImageRelation.ImageBeforeText;
            BtnVenta.UseVisualStyleBackColor = true;
            BtnVenta.Click += BtnActividad_Click;
            // 
            // BtnInventario
            // 
            BtnInventario.Cursor = Cursors.Hand;
            BtnInventario.Dock = DockStyle.Top;
            BtnInventario.FlatAppearance.BorderSize = 0;
            BtnInventario.FlatStyle = FlatStyle.Flat;
            BtnInventario.ForeColor = SystemColors.ButtonHighlight;
            BtnInventario.Image = Properties.Resources.inventario;
            BtnInventario.ImageAlign = ContentAlignment.MiddleLeft;
            BtnInventario.Location = new Point(0, 256);
            BtnInventario.Margin = new Padding(4);
            BtnInventario.Name = "BtnInventario";
            BtnInventario.Padding = new Padding(8, 0, 0, 0);
            BtnInventario.Size = new Size(183, 64);
            BtnInventario.TabIndex = 4;
            BtnInventario.Text = "Inventario";
            BtnInventario.TextImageRelation = TextImageRelation.ImageBeforeText;
            BtnInventario.UseVisualStyleBackColor = true;
            BtnInventario.Click += BtnActividad_Click;
            // 
            // BtnHojaVida
            // 
            BtnHojaVida.Cursor = Cursors.Hand;
            BtnHojaVida.Dock = DockStyle.Top;
            BtnHojaVida.FlatAppearance.BorderSize = 0;
            BtnHojaVida.FlatStyle = FlatStyle.Flat;
            BtnHojaVida.ForeColor = SystemColors.ButtonHighlight;
            BtnHojaVida.Image = Properties.Resources.hojadevida;
            BtnHojaVida.ImageAlign = ContentAlignment.MiddleLeft;
            BtnHojaVida.Location = new Point(0, 192);
            BtnHojaVida.Margin = new Padding(4);
            BtnHojaVida.Name = "BtnHojaVida";
            BtnHojaVida.Padding = new Padding(8, 0, 0, 0);
            BtnHojaVida.Size = new Size(183, 64);
            BtnHojaVida.TabIndex = 3;
            BtnHojaVida.Text = "Hoja de Vida";
            BtnHojaVida.TextImageRelation = TextImageRelation.ImageBeforeText;
            BtnHojaVida.UseVisualStyleBackColor = true;
            BtnHojaVida.Click += BtnActividad_Click;
            // 
            // BtnProductos
            // 
            BtnProductos.Cursor = Cursors.Hand;
            BtnProductos.Dock = DockStyle.Top;
            BtnProductos.FlatAppearance.BorderSize = 0;
            BtnProductos.FlatStyle = FlatStyle.Flat;
            BtnProductos.ForeColor = SystemColors.ButtonHighlight;
            BtnProductos.Image = Properties.Resources.animal;
            BtnProductos.ImageAlign = ContentAlignment.MiddleLeft;
            BtnProductos.Location = new Point(0, 128);
            BtnProductos.Margin = new Padding(4);
            BtnProductos.Name = "BtnProductos";
            BtnProductos.Padding = new Padding(8, 0, 0, 0);
            BtnProductos.Size = new Size(183, 64);
            BtnProductos.TabIndex = 2;
            BtnProductos.Text = "Productos";
            BtnProductos.TextImageRelation = TextImageRelation.ImageBeforeText;
            BtnProductos.UseVisualStyleBackColor = true;
            BtnProductos.Click += BtnActividad_Click;
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
            BtnActividad.Size = new Size(183, 64);
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
            PanelLblMenu.Size = new Size(183, 64);
            PanelLblMenu.TabIndex = 0;
            // 
            // LblEscuelaAgraria
            // 
            LblEscuelaAgraria.Dock = DockStyle.Fill;
            LblEscuelaAgraria.Font = new Font("Segoe UI Black", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LblEscuelaAgraria.ForeColor = SystemColors.ButtonHighlight;
            LblEscuelaAgraria.Location = new Point(0, 0);
            LblEscuelaAgraria.Name = "LblEscuelaAgraria";
            LblEscuelaAgraria.Size = new Size(183, 64);
            LblEscuelaAgraria.TabIndex = 0;
            LblEscuelaAgraria.Text = "Escuela Agraria";
            LblEscuelaAgraria.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(7, 100, 147);
            panel1.Controls.Add(tableLayoutPanel1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(200, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(884, 32);
            panel1.TabIndex = 2;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 5;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.Controls.Add(LblModulo, 0, 0);
            tableLayoutPanel1.Controls.Add(label1, 1, 0);
            tableLayoutPanel1.Controls.Add(LblUsuario, 2, 0);
            tableLayoutPanel1.Controls.Add(label3, 3, 0);
            tableLayoutPanel1.Controls.Add(LblTipoUsuario, 4, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(884, 32);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // LblModulo
            // 
            LblModulo.Anchor = AnchorStyles.Left;
            LblModulo.AutoSize = true;
            LblModulo.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LblModulo.ForeColor = SystemColors.ButtonHighlight;
            LblModulo.Location = new Point(3, 5);
            LblModulo.Name = "LblModulo";
            LblModulo.Size = new Size(68, 21);
            LblModulo.TabIndex = 5;
            LblModulo.Text = "Modulo";
            LblModulo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // LblTipoUsuario
            // 
            LblTipoUsuario.Anchor = AnchorStyles.Left;
            LblTipoUsuario.AutoSize = true;
            LblTipoUsuario.Font = new Font("Segoe UI", 12F);
            LblTipoUsuario.ForeColor = SystemColors.ButtonHighlight;
            LblTipoUsuario.Location = new Point(765, 5);
            LblTipoUsuario.Name = "LblTipoUsuario";
            LblTipoUsuario.Size = new Size(116, 21);
            LblTipoUsuario.TabIndex = 4;
            LblTipoUsuario.Text = "Escuela Agraria";
            LblTipoUsuario.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = SystemColors.ButtonHighlight;
            label3.Image = Properties.Resources.usergear16px;
            label3.ImageAlign = ContentAlignment.MiddleLeft;
            label3.Location = new Point(614, 5);
            label3.Margin = new Padding(16, 0, 3, 0);
            label3.Name = "label3";
            label3.Size = new Size(145, 21);
            label3.TabIndex = 3;
            label3.Text = "    Tipo de Usuario:";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // LblUsuario
            // 
            LblUsuario.Anchor = AnchorStyles.Left;
            LblUsuario.AutoSize = true;
            LblUsuario.Font = new Font("Segoe UI", 12F);
            LblUsuario.ForeColor = SystemColors.ButtonHighlight;
            LblUsuario.Location = new Point(479, 5);
            LblUsuario.Name = "LblUsuario";
            LblUsuario.Size = new Size(116, 21);
            LblUsuario.TabIndex = 2;
            LblUsuario.Text = "Escuela Agraria";
            LblUsuario.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ButtonHighlight;
            label1.Image = Properties.Resources.user16px;
            label1.ImageAlign = ContentAlignment.MiddleLeft;
            label1.Location = new Point(388, 5);
            label1.Name = "label1";
            label1.Size = new Size(85, 21);
            label1.TabIndex = 1;
            label1.Text = "    Usuario:";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // FormPrincipal
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(1084, 661);
            Controls.Add(panel1);
            Controls.Add(PanelMenu);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Icon = (Icon)resources.GetObject("$this.Icon");
            IsMdiContainer = true;
            Margin = new Padding(4);
            MinimumSize = new Size(1100, 700);
            Name = "FormPrincipal";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormPrincipal";
            WindowState = FormWindowState.Maximized;
            FormClosing += FormPrincipal_FormClosing;
            Load += FormPrincipal_Load;
            PanelMenu.ResumeLayout(false);
            PanelLblMenu.ResumeLayout(false);
            panel1.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel PanelMenu;
        private Button BtnActividad;
        private Panel PanelLblMenu;
        private Button BtnProveedores;
        private Button BtnRemitoProduccion;
        private Button BtnUsuarios;
        private Button BtnReporte;
        private Button BtnVenta;
        private Button BtnInventario;
        private Button BtnHojaVida;
        private Button BtnProductos;
        private Label LblEscuelaAgraria;
        private Button BtnPaniol;
        private Panel panel1;
        private TableLayoutPanel tableLayoutPanel1;
        private Label LblTipoUsuario;
        private Label label3;
        private Label LblUsuario;
        private Label label1;
        private Label LblModulo;
        private Button BtnEntornos;
    }
}