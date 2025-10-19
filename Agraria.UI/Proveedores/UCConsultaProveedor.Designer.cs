using Agraria.Util;

namespace Agraria.UI.Proveedores
{
    partial class UCConsultaProveedor
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            PanelLista = new Panel();
            TLPLista = new TableLayoutPanel();
            LblLista = new Label();
            ListBProveedores = new DataGridView();
            CUIT = new DataGridViewTextBoxColumn();
            Proveedor = new DataGridViewTextBoxColumn();
            Nombre = new DataGridViewTextBoxColumn();
            PanelFiltros = new Panel();
            tableLayoutPanelFiltros = new TableLayoutPanel();
            TxtFiltroCUIT = new TextBox();
            labelFiltroCUIT = new Label();
            labelFiltroProveedor = new Label();
            TxtFiltroProveedor = new TextBox();
            labelFiltroNombre = new Label();
            TxtFiltroNombre = new TextBox();
            labelFiltroTelefono = new Label();
            TxtFiltroTelefono = new TextBox();
            BtnLimpiarFiltro = new Button();
            BtnAplicarFiltro = new Button();
            panel1 = new Panel();
            tableLayoutPanel4 = new TableLayoutPanel();
            GBFormProveedores = new GroupBox();
            TLPForm = new TableLayoutPanel();
            TxtEmail = new TextBox();
            label1 = new Label();
            label3 = new Label();
            label4 = new Label();
            label2 = new Label();
            LblCuit = new Label();
            TxtTel = new TextBox();
            TxtNombre = new TextBox();
            TxtProveedor = new TextBox();
            TxtCuit = new TextBox();
            tableLayoutPanel2 = new TableLayoutPanel();
            BtnGuardar = new Button();
            BtnEliminar = new Button();
            label5 = new Label();
            TxtObservacion = new TextBox();
            tableLayoutPanel3 = new TableLayoutPanel();
            PanelLista.SuspendLayout();
            TLPLista.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ListBProveedores).BeginInit();
            PanelFiltros.SuspendLayout();
            tableLayoutPanelFiltros.SuspendLayout();
            panel1.SuspendLayout();
            tableLayoutPanel4.SuspendLayout();
            GBFormProveedores.SuspendLayout();
            TLPForm.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            SuspendLayout();
            // 
            // PanelLista
            // 
            PanelLista.BackColor = Color.FromArgb(218, 218, 220);
            PanelLista.Controls.Add(TLPLista);
            PanelLista.Dock = DockStyle.Fill;
            PanelLista.Location = new Point(3, 105);
            PanelLista.Name = "PanelLista";
            PanelLista.Padding = new Padding(0, 16, 0, 16);
            PanelLista.Size = new Size(315, 453);
            PanelLista.TabIndex = 0;
            // 
            // TLPLista
            // 
            TLPLista.ColumnCount = 1;
            TLPLista.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            TLPLista.Controls.Add(LblLista, 0, 0);
            TLPLista.Controls.Add(ListBProveedores, 0, 1);
            TLPLista.Dock = DockStyle.Fill;
            TLPLista.Location = new Point(0, 16);
            TLPLista.Name = "TLPLista";
            TLPLista.RowCount = 2;
            TLPLista.RowStyles.Add(new RowStyle(SizeType.Absolute, 32F));
            TLPLista.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            TLPLista.Size = new Size(315, 421);
            TLPLista.TabIndex = 2;
            // 
            // LblLista
            // 
            LblLista.Dock = DockStyle.Top;
            LblLista.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LblLista.ForeColor = Color.FromArgb(7, 100, 147);
            LblLista.Location = new Point(3, 0);
            LblLista.Name = "LblLista";
            LblLista.Size = new Size(309, 21);
            LblLista.TabIndex = 1;
            LblLista.Text = "Lista de Proveedores";
            LblLista.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // ListBProveedores
            // 
            ListBProveedores.AllowUserToAddRows = false;
            ListBProveedores.AllowUserToDeleteRows = false;
            ListBProveedores.AllowUserToResizeColumns = false;
            ListBProveedores.AllowUserToResizeRows = false;
            ListBProveedores.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            ListBProveedores.Columns.AddRange(new DataGridViewColumn[] { CUIT, Proveedor, Nombre });
            ListBProveedores.Dock = DockStyle.Fill;
            ListBProveedores.Location = new Point(3, 35);
            ListBProveedores.Name = "ListBProveedores";
            ListBProveedores.ReadOnly = true;
            ListBProveedores.RowHeadersVisible = false;
            ListBProveedores.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            ListBProveedores.Size = new Size(309, 383);
            ListBProveedores.TabIndex = 2;
            ListBProveedores.SelectionChanged += ListBProveedores_SelectionChanged;
            // 
            // CUIT
            // 
            CUIT.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            CUIT.DataPropertyName = "CUIT";
            CUIT.HeaderText = "CUIT";
            CUIT.Name = "CUIT";
            CUIT.ReadOnly = true;
            CUIT.Width = 68;
            // 
            // Proveedor
            // 
            Proveedor.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Proveedor.DataPropertyName = "Proveedor";
            Proveedor.HeaderText = "Proveedor";
            Proveedor.Name = "Proveedor";
            Proveedor.ReadOnly = true;
            // 
            // Nombre
            // 
            Nombre.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Nombre.DataPropertyName = "Nombre";
            Nombre.HeaderText = "Nombre";
            Nombre.Name = "Nombre";
            Nombre.ReadOnly = true;
            // 
            // PanelFiltros
            // 
            PanelFiltros.BackColor = Color.FromArgb(218, 218, 220);
            tableLayoutPanel3.SetColumnSpan(PanelFiltros, 2);
            PanelFiltros.Controls.Add(tableLayoutPanelFiltros);
            PanelFiltros.Dock = DockStyle.Fill;
            PanelFiltros.Location = new Point(3, 3);
            PanelFiltros.Name = "PanelFiltros";
            PanelFiltros.Padding = new Padding(0, 8, 0, 8);
            PanelFiltros.Size = new Size(798, 96);
            PanelFiltros.TabIndex = 4;
            // 
            // tableLayoutPanelFiltros
            // 
            tableLayoutPanelFiltros.ColumnCount = 7;
            tableLayoutPanelFiltros.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanelFiltros.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanelFiltros.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanelFiltros.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanelFiltros.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanelFiltros.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanelFiltros.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanelFiltros.Controls.Add(TxtFiltroCUIT, 2, 0);
            tableLayoutPanelFiltros.Controls.Add(labelFiltroCUIT, 1, 0);
            tableLayoutPanelFiltros.Controls.Add(labelFiltroProveedor, 3, 0);
            tableLayoutPanelFiltros.Controls.Add(TxtFiltroProveedor, 4, 0);
            tableLayoutPanelFiltros.Controls.Add(labelFiltroNombre, 1, 1);
            tableLayoutPanelFiltros.Controls.Add(TxtFiltroNombre, 2, 1);
            tableLayoutPanelFiltros.Controls.Add(labelFiltroTelefono, 3, 1);
            tableLayoutPanelFiltros.Controls.Add(TxtFiltroTelefono, 4, 1);
            tableLayoutPanelFiltros.Controls.Add(BtnLimpiarFiltro, 5, 0);
            tableLayoutPanelFiltros.Controls.Add(BtnAplicarFiltro, 5, 1);
            tableLayoutPanelFiltros.Dock = DockStyle.Fill;
            tableLayoutPanelFiltros.Location = new Point(0, 8);
            tableLayoutPanelFiltros.Name = "tableLayoutPanelFiltros";
            tableLayoutPanelFiltros.RowCount = 2;
            tableLayoutPanelFiltros.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanelFiltros.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanelFiltros.Size = new Size(798, 80);
            tableLayoutPanelFiltros.TabIndex = 0;
            // 
            // TxtFiltroCUIT
            // 
            TxtFiltroCUIT.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            TxtFiltroCUIT.BackColor = Color.FromArgb(238, 237, 240);
            TxtFiltroCUIT.Font = new Font("Segoe UI", 12F);
            TxtFiltroCUIT.ForeColor = Color.FromArgb(26, 28, 30);
            TxtFiltroCUIT.Location = new Point(100, 5);
            TxtFiltroCUIT.Margin = new Padding(3, 4, 3, 4);
            TxtFiltroCUIT.Name = "TxtFiltroCUIT";
            TxtFiltroCUIT.Size = new Size(190, 29);
            TxtFiltroCUIT.TabIndex = 1;
            // 
            // labelFiltroCUIT
            // 
            labelFiltroCUIT.Anchor = AnchorStyles.Right;
            labelFiltroCUIT.AutoSize = true;
            labelFiltroCUIT.Font = new Font("Segoe UI", 12F);
            labelFiltroCUIT.Location = new Point(48, 9);
            labelFiltroCUIT.Name = "labelFiltroCUIT";
            labelFiltroCUIT.Size = new Size(46, 21);
            labelFiltroCUIT.TabIndex = 0;
            labelFiltroCUIT.Text = "CUIT:";
            // 
            // labelFiltroProveedor
            // 
            labelFiltroProveedor.Anchor = AnchorStyles.Right;
            labelFiltroProveedor.AutoSize = true;
            labelFiltroProveedor.Font = new Font("Segoe UI", 12F);
            labelFiltroProveedor.Location = new Point(296, 9);
            labelFiltroProveedor.Name = "labelFiltroProveedor";
            labelFiltroProveedor.Size = new Size(85, 21);
            labelFiltroProveedor.TabIndex = 2;
            labelFiltroProveedor.Text = "Proveedor:";
            // 
            // TxtFiltroProveedor
            // 
            TxtFiltroProveedor.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            TxtFiltroProveedor.BackColor = Color.FromArgb(238, 237, 240);
            TxtFiltroProveedor.Font = new Font("Segoe UI", 12F);
            TxtFiltroProveedor.ForeColor = Color.FromArgb(26, 28, 30);
            TxtFiltroProveedor.Location = new Point(387, 5);
            TxtFiltroProveedor.Margin = new Padding(3, 4, 3, 4);
            TxtFiltroProveedor.Name = "TxtFiltroProveedor";
            TxtFiltroProveedor.Size = new Size(190, 29);
            TxtFiltroProveedor.TabIndex = 3;
            // 
            // labelFiltroNombre
            // 
            labelFiltroNombre.Anchor = AnchorStyles.Right;
            labelFiltroNombre.AutoSize = true;
            labelFiltroNombre.Font = new Font("Segoe UI", 12F);
            labelFiltroNombre.Location = new Point(23, 49);
            labelFiltroNombre.Name = "labelFiltroNombre";
            labelFiltroNombre.Size = new Size(71, 21);
            labelFiltroNombre.TabIndex = 4;
            labelFiltroNombre.Text = "Nombre:";
            // 
            // TxtFiltroNombre
            // 
            TxtFiltroNombre.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            TxtFiltroNombre.BackColor = Color.FromArgb(238, 237, 240);
            TxtFiltroNombre.Font = new Font("Segoe UI", 12F);
            TxtFiltroNombre.ForeColor = Color.FromArgb(26, 28, 30);
            TxtFiltroNombre.Location = new Point(100, 45);
            TxtFiltroNombre.Margin = new Padding(3, 4, 3, 4);
            TxtFiltroNombre.Name = "TxtFiltroNombre";
            TxtFiltroNombre.Size = new Size(190, 29);
            TxtFiltroNombre.TabIndex = 5;
            // 
            // labelFiltroTelefono
            // 
            labelFiltroTelefono.Anchor = AnchorStyles.Right;
            labelFiltroTelefono.AutoSize = true;
            labelFiltroTelefono.Font = new Font("Segoe UI", 12F);
            labelFiltroTelefono.Location = new Point(310, 49);
            labelFiltroTelefono.Name = "labelFiltroTelefono";
            labelFiltroTelefono.Size = new Size(71, 21);
            labelFiltroTelefono.TabIndex = 6;
            labelFiltroTelefono.Text = "Teléfono:";
            // 
            // TxtFiltroTelefono
            // 
            TxtFiltroTelefono.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            TxtFiltroTelefono.BackColor = Color.FromArgb(238, 237, 240);
            TxtFiltroTelefono.Font = new Font("Segoe UI", 12F);
            TxtFiltroTelefono.ForeColor = Color.FromArgb(26, 28, 30);
            TxtFiltroTelefono.Location = new Point(387, 45);
            TxtFiltroTelefono.Margin = new Padding(3, 4, 3, 4);
            TxtFiltroTelefono.Name = "TxtFiltroTelefono";
            TxtFiltroTelefono.Size = new Size(190, 29);
            TxtFiltroTelefono.TabIndex = 7;
            // 
            // BtnLimpiarFiltro
            // 
            BtnLimpiarFiltro.Anchor = AnchorStyles.None;
            BtnLimpiarFiltro.BackColor = Color.FromArgb(101, 89, 119);
            BtnLimpiarFiltro.FlatAppearance.BorderColor = Color.FromArgb(203, 230, 255);
            BtnLimpiarFiltro.FlatStyle = FlatStyle.Flat;
            BtnLimpiarFiltro.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            BtnLimpiarFiltro.ForeColor = Color.FromArgb(255, 255, 255);
            BtnLimpiarFiltro.Location = new Point(632, 4);
            BtnLimpiarFiltro.Margin = new Padding(3, 4, 3, 4);
            BtnLimpiarFiltro.Name = "BtnLimpiarFiltro";
            BtnLimpiarFiltro.Size = new Size(91, 32);
            BtnLimpiarFiltro.TabIndex = 8;
            BtnLimpiarFiltro.Text = "Limpiar";
            BtnLimpiarFiltro.UseVisualStyleBackColor = false;
            BtnLimpiarFiltro.Click += BtnLimpiarFiltro_Click;
            // 
            // BtnAplicarFiltro
            // 
            BtnAplicarFiltro.Anchor = AnchorStyles.None;
            BtnAplicarFiltro.BackColor = Color.FromArgb(7, 100, 147);
            BtnAplicarFiltro.FlatAppearance.BorderColor = Color.FromArgb(203, 230, 255);
            BtnAplicarFiltro.FlatStyle = FlatStyle.Flat;
            BtnAplicarFiltro.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            BtnAplicarFiltro.ForeColor = Color.FromArgb(255, 255, 255);
            BtnAplicarFiltro.Location = new Point(632, 44);
            BtnAplicarFiltro.Margin = new Padding(3, 4, 3, 4);
            BtnAplicarFiltro.Name = "BtnAplicarFiltro";
            BtnAplicarFiltro.Size = new Size(91, 32);
            BtnAplicarFiltro.TabIndex = 9;
            BtnAplicarFiltro.Text = "Aplicar";
            BtnAplicarFiltro.UseVisualStyleBackColor = false;
            BtnAplicarFiltro.Click += BtnAplicarFiltro_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(tableLayoutPanel4);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(324, 105);
            panel1.Name = "panel1";
            panel1.Size = new Size(477, 453);
            panel1.TabIndex = 1;
            // 
            // tableLayoutPanel4
            // 
            tableLayoutPanel4.BackColor = Color.FromArgb(218, 218, 220);
            tableLayoutPanel4.ColumnCount = 1;
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel4.Controls.Add(GBFormProveedores, 0, 0);
            tableLayoutPanel4.Dock = DockStyle.Fill;
            tableLayoutPanel4.Location = new Point(0, 0);
            tableLayoutPanel4.Name = "tableLayoutPanel4";
            tableLayoutPanel4.RowCount = 1;
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel4.Size = new Size(477, 453);
            tableLayoutPanel4.TabIndex = 2;
            // 
            // GBFormProveedores
            // 
            GBFormProveedores.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            GBFormProveedores.Controls.Add(TLPForm);
            GBFormProveedores.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            GBFormProveedores.ForeColor = Color.FromArgb(7, 100, 147);
            GBFormProveedores.Location = new Point(3, 3);
            GBFormProveedores.Name = "GBFormProveedores";
            GBFormProveedores.Size = new Size(471, 447);
            GBFormProveedores.TabIndex = 12;
            GBFormProveedores.TabStop = false;
            GBFormProveedores.Text = "Formulario de Edición de Proveedores";
            // 
            // TLPForm
            // 
            TLPForm.BackColor = Color.FromArgb(249, 249, 251);
            TLPForm.ColumnCount = 3;
            TLPForm.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 23.2562962F));
            TLPForm.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 64.17014F));
            TLPForm.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5735607F));
            TLPForm.Controls.Add(TxtEmail, 1, 5);
            TLPForm.Controls.Add(label1, 0, 5);
            TLPForm.Controls.Add(label3, 0, 4);
            TLPForm.Controls.Add(label4, 0, 3);
            TLPForm.Controls.Add(label2, 0, 2);
            TLPForm.Controls.Add(LblCuit, 0, 1);
            TLPForm.Controls.Add(TxtTel, 1, 4);
            TLPForm.Controls.Add(TxtNombre, 1, 3);
            TLPForm.Controls.Add(TxtProveedor, 1, 2);
            TLPForm.Controls.Add(TxtCuit, 1, 1);
            TLPForm.Controls.Add(tableLayoutPanel2, 1, 7);
            TLPForm.Controls.Add(label5, 0, 6);
            TLPForm.Controls.Add(TxtObservacion, 1, 6);
            TLPForm.Dock = DockStyle.Fill;
            TLPForm.ForeColor = Color.FromArgb(26, 28, 30);
            TLPForm.Location = new Point(3, 29);
            TLPForm.Name = "TLPForm";
            TLPForm.RowCount = 9;
            TLPForm.RowStyles.Add(new RowStyle(SizeType.Absolute, 8F));
            TLPForm.RowStyles.Add(new RowStyle(SizeType.Percent, 12.2119818F));
            TLPForm.RowStyles.Add(new RowStyle(SizeType.Percent, 14.5161295F));
            TLPForm.RowStyles.Add(new RowStyle(SizeType.Percent, 14.0553F));
            TLPForm.RowStyles.Add(new RowStyle(SizeType.Percent, 11.9815664F));
            TLPForm.RowStyles.Add(new RowStyle(SizeType.Percent, 12.9032259F));
            TLPForm.RowStyles.Add(new RowStyle(SizeType.Percent, 20.0460835F));
            TLPForm.RowStyles.Add(new RowStyle(SizeType.Percent, 14.2857151F));
            TLPForm.RowStyles.Add(new RowStyle(SizeType.Absolute, 8F));
            TLPForm.Size = new Size(465, 415);
            TLPForm.TabIndex = 0;
            // 
            // TxtEmail
            // 
            TxtEmail.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            TxtEmail.BackColor = Color.FromArgb(238, 237, 240);
            TxtEmail.Font = new Font("Segoe UI", 12F);
            TxtEmail.ForeColor = Color.FromArgb(26, 28, 30);
            TxtEmail.Location = new Point(111, 227);
            TxtEmail.MaxLength = 255;
            TxtEmail.Name = "TxtEmail";
            TxtEmail.Size = new Size(292, 29);
            TxtEmail.TabIndex = 9;
            TxtEmail.TextChanged += TxtCuit_TextChanged;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(54, 231);
            label1.Name = "label1";
            label1.Size = new Size(51, 21);
            label1.TabIndex = 1;
            label1.Text = "Email:";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F);
            label3.Location = new Point(71, 182);
            label3.Name = "label3";
            label3.Size = new Size(34, 21);
            label3.TabIndex = 3;
            label3.Text = "Tel.:";
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Right;
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F);
            label4.Location = new Point(34, 130);
            label4.Name = "label4";
            label4.Size = new Size(71, 21);
            label4.TabIndex = 4;
            label4.Text = "Nombre:";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(20, 74);
            label2.Name = "label2";
            label2.Size = new Size(85, 21);
            label2.TabIndex = 2;
            label2.Text = "Proveedor:";
            // 
            // LblCuit
            // 
            LblCuit.Anchor = AnchorStyles.Right;
            LblCuit.AutoSize = true;
            LblCuit.Font = new Font("Segoe UI", 12F);
            LblCuit.Location = new Point(59, 21);
            LblCuit.Name = "LblCuit";
            LblCuit.Size = new Size(46, 21);
            LblCuit.TabIndex = 0;
            LblCuit.Text = "CUIT:";
            // 
            // TxtTel
            // 
            TxtTel.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            TxtTel.BackColor = Color.FromArgb(238, 237, 240);
            TxtTel.Font = new Font("Segoe UI", 12F);
            TxtTel.ForeColor = Color.FromArgb(26, 28, 30);
            TxtTel.Location = new Point(111, 178);
            TxtTel.MaxLength = 11;
            TxtTel.Name = "TxtTel";
            TxtTel.Size = new Size(292, 29);
            TxtTel.TabIndex = 8;
            TxtTel.TextChanged += TxtCuit_TextChanged;
            // 
            // TxtNombre
            // 
            TxtNombre.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            TxtNombre.BackColor = Color.FromArgb(238, 237, 240);
            TxtNombre.Font = new Font("Segoe UI", 12F);
            TxtNombre.ForeColor = Color.FromArgb(26, 28, 30);
            TxtNombre.Location = new Point(111, 126);
            TxtNombre.MaxLength = 50;
            TxtNombre.Name = "TxtNombre";
            TxtNombre.Size = new Size(292, 29);
            TxtNombre.TabIndex = 7;
            TxtNombre.TextChanged += TxtCuit_TextChanged;
            // 
            // TxtProveedor
            // 
            TxtProveedor.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            TxtProveedor.BackColor = Color.FromArgb(238, 237, 240);
            TxtProveedor.Font = new Font("Segoe UI", 12F);
            TxtProveedor.ForeColor = Color.FromArgb(26, 28, 30);
            TxtProveedor.Location = new Point(111, 70);
            TxtProveedor.MaxLength = 50;
            TxtProveedor.Name = "TxtProveedor";
            TxtProveedor.Size = new Size(292, 29);
            TxtProveedor.TabIndex = 6;
            TxtProveedor.TextChanged += TxtCuit_TextChanged;
            // 
            // TxtCuit
            // 
            TxtCuit.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            TxtCuit.BackColor = Color.FromArgb(238, 237, 240);
            TxtCuit.Font = new Font("Segoe UI", 12F);
            TxtCuit.ForeColor = Color.FromArgb(26, 28, 30);
            TxtCuit.Location = new Point(111, 17);
            TxtCuit.MaxLength = 11;
            TxtCuit.Name = "TxtCuit";
            TxtCuit.Size = new Size(292, 29);
            TxtCuit.TabIndex = 5;
            TxtCuit.TextChanged += TxtCuit_TextChanged;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Controls.Add(BtnGuardar, 0, 0);
            tableLayoutPanel2.Controls.Add(BtnEliminar, 1, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(111, 349);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Size = new Size(292, 51);
            tableLayoutPanel2.TabIndex = 11;
            // 
            // BtnGuardar
            // 
            BtnGuardar.Anchor = AnchorStyles.None;
            BtnGuardar.BackColor = Color.FromArgb(101, 89, 119);
            BtnGuardar.FlatAppearance.BorderColor = Color.FromArgb(203, 230, 255);
            BtnGuardar.FlatStyle = FlatStyle.Flat;
            BtnGuardar.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BtnGuardar.ForeColor = Color.FromArgb(255, 255, 255);
            BtnGuardar.Image = Properties.Resources.guardar;
            BtnGuardar.ImageAlign = ContentAlignment.MiddleRight;
            BtnGuardar.Location = new Point(7, 0);
            BtnGuardar.Margin = new Padding(0);
            BtnGuardar.Name = "BtnGuardar";
            BtnGuardar.Size = new Size(131, 51);
            BtnGuardar.TabIndex = 10;
            BtnGuardar.Text = "Guardar";
            BtnGuardar.TextAlign = ContentAlignment.MiddleRight;
            BtnGuardar.TextImageRelation = TextImageRelation.ImageBeforeText;
            BtnGuardar.UseVisualStyleBackColor = false;
            BtnGuardar.EnabledChanged += BtnGuardar_EnabledChanged;
            BtnGuardar.Click += BtnGuardar_Click;
            // 
            // BtnEliminar
            // 
            BtnEliminar.Anchor = AnchorStyles.None;
            BtnEliminar.BackColor = Color.FromArgb(186, 26, 26);
            BtnEliminar.FlatAppearance.BorderColor = Color.FromArgb(203, 230, 255);
            BtnEliminar.FlatStyle = FlatStyle.Flat;
            BtnEliminar.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BtnEliminar.ForeColor = Color.FromArgb(255, 255, 255);
            BtnEliminar.Image = Properties.Resources.trash;
            BtnEliminar.Location = new Point(187, 0);
            BtnEliminar.Margin = new Padding(0);
            BtnEliminar.Name = "BtnEliminar";
            BtnEliminar.Size = new Size(64, 51);
            BtnEliminar.TabIndex = 11;
            BtnEliminar.UseVisualStyleBackColor = false;
            BtnEliminar.Visible = false;
            BtnEliminar.EnabledChanged += BtnGuardar_EnabledChanged;
            BtnEliminar.Click += BtnEliminar_Click;
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Right;
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F);
            label5.Location = new Point(5, 296);
            label5.Name = "label5";
            label5.Size = new Size(100, 21);
            label5.TabIndex = 12;
            label5.Text = "Observación:";
            // 
            // TxtObservacion
            // 
            TxtObservacion.BackColor = Color.FromArgb(238, 237, 240);
            TxtObservacion.Dock = DockStyle.Fill;
            TxtObservacion.Font = new Font("Segoe UI", 12F);
            TxtObservacion.ForeColor = Color.FromArgb(26, 28, 30);
            TxtObservacion.Location = new Point(111, 270);
            TxtObservacion.MaxLength = 400;
            TxtObservacion.Multiline = true;
            TxtObservacion.Name = "TxtObservacion";
            TxtObservacion.Size = new Size(292, 73);
            TxtObservacion.TabIndex = 13;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.BackColor = Color.FromArgb(218, 218, 220);
            tableLayoutPanel3.ColumnCount = 2;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60F));
            tableLayoutPanel3.Controls.Add(PanelFiltros, 0, 0);
            tableLayoutPanel3.Controls.Add(PanelLista, 0, 1);
            tableLayoutPanel3.Controls.Add(panel1, 1, 1);
            tableLayoutPanel3.Dock = DockStyle.Fill;
            tableLayoutPanel3.Location = new Point(0, 0);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 2;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 18.181818F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 81.8181839F));
            tableLayoutPanel3.Size = new Size(804, 561);
            tableLayoutPanel3.TabIndex = 2;
            // 
            // UCConsultaProveedor
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.FromArgb(249, 249, 251);
            Controls.Add(tableLayoutPanel3);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ForeColor = Color.FromArgb(26, 28, 30);
            Margin = new Padding(5);
            Name = "UCConsultaProveedor";
            Size = new Size(804, 561);
            Load += UCConsultaProveedor_Load;
            PanelLista.ResumeLayout(false);
            TLPLista.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)ListBProveedores).EndInit();
            PanelFiltros.ResumeLayout(false);
            tableLayoutPanelFiltros.ResumeLayout(false);
            tableLayoutPanelFiltros.PerformLayout();
            panel1.ResumeLayout(false);
            tableLayoutPanel4.ResumeLayout(false);
            GBFormProveedores.ResumeLayout(false);
            TLPForm.ResumeLayout(false);
            TLPForm.PerformLayout();
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel3.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel PanelLista;
        private Label LblLista;
        private Panel panel1;
        private TableLayoutPanel tableLayoutPanel4;
        private TableLayoutPanel TLPForm;
        private TextBox TxtEmail;
        private Label label1;
        private Label label3;
        private Label label4;
        private Label label2;
        private Label LblCuit;
        private TextBox TxtTel;
        private TextBox TxtNombre;
        private TextBox TxtProveedor;
        private TextBox TxtCuit;
        private Button BtnEliminar;
        private Button BtnGuardar;
        private TableLayoutPanel tableLayoutPanel2;
        private TableLayoutPanel tableLayoutPanel3;
        private GroupBox GBFormProveedores;
        private TableLayoutPanel TLPLista;
        private DataGridView ListBProveedores;
        private DataGridViewTextBoxColumn CUIT;
        private DataGridViewTextBoxColumn Proveedor;
        private DataGridViewTextBoxColumn Nombre;
        private Label label5;
        private TextBox TxtObservacion;
        private Panel PanelFiltros;
        private TableLayoutPanel tableLayoutPanelFiltros;
        private Label labelFiltroCUIT;
        private TextBox TxtFiltroCUIT;
        private Label labelFiltroProveedor;
        private TextBox TxtFiltroProveedor;
        private Label labelFiltroNombre;
        private TextBox TxtFiltroNombre;
        private Label labelFiltroTelefono;
        private TextBox TxtFiltroTelefono;
        private Button BtnLimpiarFiltro;
        private Button BtnAplicarFiltro;
    }
}
