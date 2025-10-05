namespace Agraria.UI.Paniol
{
    partial class UCConsultaHerramienta
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
            tableLayoutPanel3 = new TableLayoutPanel();
            PanelLista = new Panel();
            tableLayoutPanel1 = new TableLayoutPanel();
            LblLista = new Label();
            ListBArticulos = new DataGridView();
            Codigo = new DataGridViewTextBoxColumn();
            Nombre = new DataGridViewTextBoxColumn();
            PanelMedio = new Panel();
            tableLayoutPanel4 = new TableLayoutPanel();
            groupBox1 = new GroupBox();
            TLPForm = new TableLayoutPanel();
            LblNombre = new Label();
            TxtNombre = new TextBox();
            tableLayoutPanel2 = new TableLayoutPanel();
            BtnGuardar = new Button();
            BtnEliminar = new Button();
            TxtDescripcion = new TextBox();
            label5 = new Label();
            TxtCantidad = new TextBox();
            label4 = new Label();
            ProgressBar = new ProgressBar();
            PanelFiltros = new Panel();
            tableLayoutPanelFiltros = new TableLayoutPanel();
            labelFiltroNombre = new Label();
            TxtFiltroNombre = new TextBox();
            labelFiltroDescripcion = new Label();
            TxtFiltroDescripcion = new TextBox();
            labelFiltroCantidad = new Label();
            TxtFiltroCantidad = new TextBox();
            BtnLimpiarFiltro = new Button();
            BtnAplicarFiltro = new Button();
            tableLayoutPanel3.SuspendLayout();
            PanelLista.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ListBArticulos).BeginInit();
            PanelMedio.SuspendLayout();
            tableLayoutPanel4.SuspendLayout();
            groupBox1.SuspendLayout();
            TLPForm.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            PanelFiltros.SuspendLayout();
            tableLayoutPanelFiltros.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.BackColor = Color.FromArgb(218, 218, 220);
            tableLayoutPanel3.ColumnCount = 2;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60F));
            tableLayoutPanel3.Controls.Add(PanelLista, 0, 1);
            tableLayoutPanel3.Controls.Add(PanelMedio, 1, 1);
            tableLayoutPanel3.Controls.Add(ProgressBar, 0, 0);
            tableLayoutPanel3.Dock = DockStyle.Fill;
            tableLayoutPanel3.Location = new Point(0, 0);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 2;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 16F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel3.Size = new Size(804, 561);
            tableLayoutPanel3.TabIndex = 3;
            // 
            // PanelLista
            // 
            PanelLista.BackColor = Color.FromArgb(218, 218, 220);
            PanelLista.Controls.Add(tableLayoutPanel1);
            PanelLista.Controls.Add(PanelFiltros);
            PanelLista.Dock = DockStyle.Fill;
            PanelLista.Location = new Point(3, 19);
            PanelLista.Name = "PanelLista";
            PanelLista.Padding = new Padding(0, 16, 0, 16);
            PanelLista.Size = new Size(315, 539);
            PanelLista.TabIndex = 3;
            // 
            // PanelFiltros
            // 
            PanelFiltros.BackColor = Color.FromArgb(218, 218, 220);
            PanelFiltros.Controls.Add(tableLayoutPanelFiltros);
            PanelFiltros.Dock = DockStyle.Top;
            PanelFiltros.Location = new Point(0, 16);
            PanelFiltros.Name = "PanelFiltros";
            PanelFiltros.Padding = new Padding(0, 8, 0, 8);
            PanelFiltros.Size = new Size(315, 160);
            PanelFiltros.TabIndex = 4;
            // 
            // tableLayoutPanelFiltros
            // 
            tableLayoutPanelFiltros.ColumnCount = 2;
            tableLayoutPanelFiltros.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35F));
            tableLayoutPanelFiltros.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 65F));
            tableLayoutPanelFiltros.Controls.Add(labelFiltroNombre, 0, 0);
            tableLayoutPanelFiltros.Controls.Add(TxtFiltroNombre, 1, 0);
            tableLayoutPanelFiltros.Controls.Add(labelFiltroDescripcion, 0, 1);
            tableLayoutPanelFiltros.Controls.Add(TxtFiltroDescripcion, 1, 1);
            tableLayoutPanelFiltros.Controls.Add(labelFiltroCantidad, 0, 2);
            tableLayoutPanelFiltros.Controls.Add(TxtFiltroCantidad, 1, 2);
            tableLayoutPanelFiltros.Controls.Add(BtnLimpiarFiltro, 0, 3);
            tableLayoutPanelFiltros.Controls.Add(BtnAplicarFiltro, 1, 3);
            tableLayoutPanelFiltros.Dock = DockStyle.Fill;
            tableLayoutPanelFiltros.Location = new Point(0, 8);
            tableLayoutPanelFiltros.Name = "tableLayoutPanelFiltros";
            tableLayoutPanelFiltros.RowCount = 4;
            tableLayoutPanelFiltros.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanelFiltros.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanelFiltros.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanelFiltros.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanelFiltros.Size = new Size(315, 144);
            tableLayoutPanelFiltros.TabIndex = 0;
            // 
            // labelFiltroNombre
            // 
            labelFiltroNombre.Anchor = AnchorStyles.Right;
            labelFiltroNombre.AutoSize = true;
            labelFiltroNombre.Font = new Font("Segoe UI", 12F);
            labelFiltroNombre.Location = new Point(24, 7);
            labelFiltroNombre.Name = "labelFiltroNombre";
            labelFiltroNombre.Size = new Size(71, 21);
            labelFiltroNombre.TabIndex = 0;
            labelFiltroNombre.Text = "Nombre:";
            // 
            // TxtFiltroNombre
            // 
            TxtFiltroNombre.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            TxtFiltroNombre.BackColor = Color.FromArgb(238, 237, 240);
            TxtFiltroNombre.Font = new Font("Segoe UI", 12F);
            TxtFiltroNombre.ForeColor = Color.FromArgb(26, 28, 30);
            TxtFiltroNombre.Location = new Point(113, 4);
            TxtFiltroNombre.Margin = new Padding(3, 4, 3, 4);
            TxtFiltroNombre.Name = "TxtFiltroNombre";
            TxtFiltroNombre.Size = new Size(199, 29);
            TxtFiltroNombre.TabIndex = 1;
            // 
            // labelFiltroDescripcion
            // 
            labelFiltroDescripcion.Anchor = AnchorStyles.Right;
            labelFiltroDescripcion.AutoSize = true;
            labelFiltroDescripcion.Font = new Font("Segoe UI", 12F);
            labelFiltroDescripcion.Location = new Point(3, 45);
            labelFiltroDescripcion.Name = "labelFiltroDescripcion";
            labelFiltroDescripcion.Size = new Size(92, 21);
            labelFiltroDescripcion.TabIndex = 2;
            labelFiltroDescripcion.Text = "Descripción:";
            // 
            // TxtFiltroDescripcion
            // 
            TxtFiltroDescripcion.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            TxtFiltroDescripcion.BackColor = Color.FromArgb(238, 237, 240);
            TxtFiltroDescripcion.Font = new Font("Segoe UI", 12F);
            TxtFiltroDescripcion.ForeColor = Color.FromArgb(26, 28, 30);
            TxtFiltroDescripcion.Location = new Point(113, 42);
            TxtFiltroDescripcion.Margin = new Padding(3, 4, 3, 4);
            TxtFiltroDescripcion.Name = "TxtFiltroDescripcion";
            TxtFiltroDescripcion.Size = new Size(199, 29);
            TxtFiltroDescripcion.TabIndex = 3;
            // 
            // labelFiltroCantidad
            // 
            labelFiltroCantidad.Anchor = AnchorStyles.Right;
            labelFiltroCantidad.AutoSize = true;
            labelFiltroCantidad.Font = new Font("Segoe UI", 12F);
            labelFiltroCantidad.Location = new Point(32, 83);
            labelFiltroCantidad.Name = "labelFiltroCantidad";
            labelFiltroCantidad.Size = new Size(63, 21);
            labelFiltroCantidad.TabIndex = 4;
            labelFiltroCantidad.Text = "Cantidad:";
            // 
            // TxtFiltroCantidad
            // 
            TxtFiltroCantidad.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            TxtFiltroCantidad.BackColor = Color.FromArgb(238, 237, 240);
            TxtFiltroCantidad.Font = new Font("Segoe UI", 12F);
            TxtFiltroCantidad.ForeColor = Color.FromArgb(26, 28, 30);
            TxtFiltroCantidad.Location = new Point(113, 80);
            TxtFiltroCantidad.Margin = new Padding(3, 4, 3, 4);
            TxtFiltroCantidad.Name = "TxtFiltroCantidad";
            TxtFiltroCantidad.Size = new Size(199, 29);
            TxtFiltroCantidad.TabIndex = 5;
            // 
            // BtnLimpiarFiltro
            // 
            BtnLimpiarFiltro.Anchor = AnchorStyles.Right;
            BtnLimpiarFiltro.BackColor = Color.FromArgb(101, 89, 119);
            BtnLimpiarFiltro.FlatAppearance.BorderColor = Color.FromArgb(203, 230, 255);
            BtnLimpiarFiltro.FlatStyle = FlatStyle.Flat;
            BtnLimpiarFiltro.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            BtnLimpiarFiltro.ForeColor = Color.FromArgb(255, 255, 255);
            BtnLimpiarFiltro.Location = new Point(16, 112);
            BtnLimpiarFiltro.Margin = new Padding(3, 4, 3, 4);
            BtnLimpiarFiltro.Name = "BtnLimpiarFiltro";
            BtnLimpiarFiltro.Size = new Size(91, 32);
            BtnLimpiarFiltro.TabIndex = 6;
            BtnLimpiarFiltro.Text = "Limpiar";
            BtnLimpiarFiltro.UseVisualStyleBackColor = false;
            BtnLimpiarFiltro.Click += BtnLimpiarFiltro_Click;
            // 
            // BtnAplicarFiltro
            // 
            BtnAplicarFiltro.Anchor = AnchorStyles.Left;
            BtnAplicarFiltro.BackColor = Color.FromArgb(101, 89, 119);
            BtnAplicarFiltro.FlatAppearance.BorderColor = Color.FromArgb(203, 230, 255);
            BtnAplicarFiltro.FlatStyle = FlatStyle.Flat;
            BtnAplicarFiltro.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            BtnAplicarFiltro.ForeColor = Color.FromArgb(255, 255, 255);
            BtnAplicarFiltro.Location = new Point(113, 112);
            BtnAplicarFiltro.Margin = new Padding(3, 4, 3, 4);
            BtnAplicarFiltro.Name = "BtnAplicarFiltro";
            BtnAplicarFiltro.Size = new Size(91, 32);
            BtnAplicarFiltro.TabIndex = 7;
            BtnAplicarFiltro.Text = "Aplicar";
            BtnAplicarFiltro.UseVisualStyleBackColor = false;
            BtnAplicarFiltro.Click += BtnAplicarFiltro_Click;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(LblLista, 0, 0);
            tableLayoutPanel1.Controls.Add(ListBArticulos, 0, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 176);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 32F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(315, 347);
            tableLayoutPanel1.TabIndex = 2;
            // 
            // LblLista
            // 
            LblLista.Dock = DockStyle.Top;
            LblLista.Font = new Font("Segoe UI Black", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LblLista.ForeColor = Color.FromArgb(7, 100, 147);
            LblLista.Location = new Point(3, 0);
            LblLista.Name = "LblLista";
            LblLista.Size = new Size(309, 21);
            LblLista.TabIndex = 1;
            LblLista.Text = "Lista de Herramientas";
            LblLista.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // ListBArticulos
            // 
            ListBArticulos.AllowUserToAddRows = false;
            ListBArticulos.AllowUserToDeleteRows = false;
            ListBArticulos.AllowUserToResizeColumns = false;
            ListBArticulos.AllowUserToResizeRows = false;
            ListBArticulos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            ListBArticulos.Columns.AddRange(new DataGridViewColumn[] { Codigo, Nombre });
            ListBArticulos.Dock = DockStyle.Fill;
            ListBArticulos.Location = new Point(3, 35);
            ListBArticulos.Name = "ListBArticulos";
            ListBArticulos.ReadOnly = true;
            ListBArticulos.RowHeadersVisible = false;
            ListBArticulos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            ListBArticulos.Size = new Size(309, 469);
            ListBArticulos.TabIndex = 2;
            ListBArticulos.SelectionChanged += ListBArticulos_SelectionChanged;
            // 
            // Codigo
            // 
            Codigo.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            Codigo.DataPropertyName = "Id_Herramienta";
            Codigo.HeaderText = "CÓDIGO";
            Codigo.Name = "Codigo";
            Codigo.ReadOnly = true;
            Codigo.Width = 95;
            // 
            // Nombre
            // 
            Nombre.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Nombre.DataPropertyName = "Nombre";
            Nombre.HeaderText = "NOMBRE";
            Nombre.Name = "Nombre";
            Nombre.ReadOnly = true;
            // 
            // PanelMedio
            // 
            PanelMedio.Controls.Add(tableLayoutPanel4);
            PanelMedio.Dock = DockStyle.Fill;
            PanelMedio.Location = new Point(324, 19);
            PanelMedio.Name = "PanelMedio";
            PanelMedio.Size = new Size(477, 539);
            PanelMedio.TabIndex = 2;
            // 
            // tableLayoutPanel4
            // 
            tableLayoutPanel4.BackColor = Color.FromArgb(218, 218, 220);
            tableLayoutPanel4.ColumnCount = 1;
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel4.Controls.Add(groupBox1, 0, 0);
            tableLayoutPanel4.Dock = DockStyle.Fill;
            tableLayoutPanel4.Location = new Point(0, 0);
            tableLayoutPanel4.Name = "tableLayoutPanel4";
            tableLayoutPanel4.RowCount = 1;
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel4.Size = new Size(477, 539);
            tableLayoutPanel4.TabIndex = 2;
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            groupBox1.Controls.Add(TLPForm);
            groupBox1.Font = new Font("Segoe UI Black", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox1.ForeColor = Color.FromArgb(7, 100, 147);
            groupBox1.Location = new Point(3, 61);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(471, 417);
            groupBox1.TabIndex = 16;
            groupBox1.TabStop = false;
            groupBox1.Text = "Formulario de Edición de Herramientas";
            // 
            // TLPForm
            // 
            TLPForm.BackColor = Color.FromArgb(249, 249, 251);
            TLPForm.ColumnCount = 3;
            TLPForm.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 27.95699F));
            TLPForm.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 59.5698929F));
            TLPForm.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.4731178F));
            TLPForm.Controls.Add(LblNombre, 0, 1);
            TLPForm.Controls.Add(TxtNombre, 1, 1);
            TLPForm.Controls.Add(tableLayoutPanel2, 1, 4);
            TLPForm.Controls.Add(TxtDescripcion, 1, 3);
            TLPForm.Controls.Add(label5, 0, 3);
            TLPForm.Controls.Add(TxtCantidad, 1, 2);
            TLPForm.Controls.Add(label4, 0, 2);
            TLPForm.Dock = DockStyle.Fill;
            TLPForm.ForeColor = Color.FromArgb(26, 28, 30);
            TLPForm.Location = new Point(3, 29);
            TLPForm.Name = "TLPForm";
            TLPForm.RowCount = 6;
            TLPForm.RowStyles.Add(new RowStyle(SizeType.Absolute, 8F));
            TLPForm.RowStyles.Add(new RowStyle(SizeType.Percent, 16.6961918F));
            TLPForm.RowStyles.Add(new RowStyle(SizeType.Percent, 16.6961918F));
            TLPForm.RowStyles.Add(new RowStyle(SizeType.Percent, 38.2639465F));
            TLPForm.RowStyles.Add(new RowStyle(SizeType.Percent, 23.02923F));
            TLPForm.RowStyles.Add(new RowStyle(SizeType.Percent, 5.314438F));
            TLPForm.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            TLPForm.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            TLPForm.Size = new Size(465, 385);
            TLPForm.TabIndex = 0;
            // 
            // LblNombre
            // 
            LblNombre.Anchor = AnchorStyles.Right;
            LblNombre.AutoSize = true;
            LblNombre.Font = new Font("Segoe UI", 12F);
            LblNombre.Location = new Point(56, 28);
            LblNombre.Name = "LblNombre";
            LblNombre.Size = new Size(71, 21);
            LblNombre.TabIndex = 0;
            LblNombre.Text = "Nombre:";
            // 
            // TxtNombre
            // 
            TxtNombre.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            TxtNombre.BackColor = Color.FromArgb(238, 237, 240);
            TxtNombre.Font = new Font("Segoe UI", 12F);
            TxtNombre.ForeColor = Color.FromArgb(26, 28, 30);
            TxtNombre.Location = new Point(133, 24);
            TxtNombre.MaxLength = 50;
            TxtNombre.Name = "TxtNombre";
            TxtNombre.Size = new Size(271, 29);
            TxtNombre.TabIndex = 5;
            TxtNombre.TextChanged += TxtNombre_TextChanged;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Controls.Add(BtnGuardar, 0, 0);
            tableLayoutPanel2.Controls.Add(BtnEliminar, 1, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(133, 279);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Size = new Size(271, 80);
            tableLayoutPanel2.TabIndex = 18;
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
            BtnGuardar.Location = new Point(0, 16);
            BtnGuardar.Margin = new Padding(0);
            BtnGuardar.Name = "BtnGuardar";
            BtnGuardar.Size = new Size(135, 48);
            BtnGuardar.TabIndex = 12;
            BtnGuardar.Text = "Guardar";
            BtnGuardar.TextAlign = ContentAlignment.MiddleRight;
            BtnGuardar.TextImageRelation = TextImageRelation.ImageBeforeText;
            BtnGuardar.UseVisualStyleBackColor = false;
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
            BtnEliminar.Location = new Point(179, 16);
            BtnEliminar.Margin = new Padding(0);
            BtnEliminar.Name = "BtnEliminar";
            BtnEliminar.Size = new Size(48, 48);
            BtnEliminar.TabIndex = 13;
            BtnEliminar.UseVisualStyleBackColor = false;
            BtnEliminar.Click += BtnEliminar_Click;
            // 
            // TxtDescripcion
            // 
            TxtDescripcion.BackColor = Color.FromArgb(238, 237, 240);
            TxtDescripcion.Dock = DockStyle.Fill;
            TxtDescripcion.Font = new Font("Segoe UI", 12F);
            TxtDescripcion.ForeColor = Color.FromArgb(26, 28, 30);
            TxtDescripcion.Location = new Point(133, 135);
            TxtDescripcion.MaxLength = 400;
            TxtDescripcion.Multiline = true;
            TxtDescripcion.Name = "TxtDescripcion";
            TxtDescripcion.Size = new Size(271, 138);
            TxtDescripcion.TabIndex = 9;
            TxtDescripcion.TextChanged += TxtNombre_TextChanged;
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Right;
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F);
            label5.Location = new Point(33, 193);
            label5.Name = "label5";
            label5.Size = new Size(94, 21);
            label5.TabIndex = 12;
            label5.Text = "Descripción:";
            // 
            // TxtCantidad
            // 
            TxtCantidad.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            TxtCantidad.BackColor = Color.FromArgb(238, 237, 240);
            TxtCantidad.Font = new Font("Segoe UI", 12F);
            TxtCantidad.ForeColor = Color.FromArgb(26, 28, 30);
            TxtCantidad.Location = new Point(133, 86);
            TxtCantidad.MaxLength = 12;
            TxtCantidad.Name = "TxtCantidad";
            TxtCantidad.Size = new Size(271, 29);
            TxtCantidad.TabIndex = 7;
            TxtCantidad.TextChanged += TxtNombre_TextChanged;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Right;
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F);
            label4.Location = new Point(52, 90);
            label4.Name = "label4";
            label4.Size = new Size(75, 21);
            label4.TabIndex = 4;
            label4.Text = "Cantidad:";
            // 
            // ProgressBar
            // 
            tableLayoutPanel3.SetColumnSpan(ProgressBar, 2);
            ProgressBar.Dock = DockStyle.Fill;
            ProgressBar.Location = new Point(0, 0);
            ProgressBar.Margin = new Padding(0);
            ProgressBar.Name = "ProgressBar";
            ProgressBar.Size = new Size(804, 16);
            ProgressBar.TabIndex = 4;
            ProgressBar.Visible = false;
            // 
            // UCConsultaHerramienta
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.FromArgb(249, 249, 251);
            Controls.Add(tableLayoutPanel3);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ForeColor = Color.FromArgb(26, 28, 30);
            Margin = new Padding(4);
            Name = "UCConsultaHerramienta";
            Size = new Size(804, 561);
            Load += UCConsultaHerramienta_Load;
            VisibleChanged += UCConsultaHerramienta_VisibleChanged;
            tableLayoutPanel3.ResumeLayout(false);
            PanelLista.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)ListBArticulos).EndInit();
            PanelMedio.ResumeLayout(false);
            tableLayoutPanel4.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            TLPForm.ResumeLayout(false);
            TLPForm.PerformLayout();
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanelFiltros.ResumeLayout(false);
            tableLayoutPanelFiltros.PerformLayout();
            PanelFiltros.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel3;
        private Panel PanelLista;
        private TableLayoutPanel tableLayoutPanel1;
        private Label LblLista;
        private Panel PanelMedio;
        private TableLayoutPanel tableLayoutPanel4;
        private GroupBox groupBox1;
        private TableLayoutPanel TLPForm;
        private Label LblNombre;
        private TextBox TxtCantidad;
        private TextBox TxtNombre;
        private Label label4;
        private Label label5;
        private TableLayoutPanel tableLayoutPanel2;
        private Button BtnGuardar;
        private Button BtnEliminar;
        private ProgressBar ProgressBar;
        private DataGridView ListBArticulos;
        private DataGridViewTextBoxColumn Codigo;
        private DataGridViewTextBoxColumn Nombre;
        private TextBox TxtDescripcion;
        private Panel PanelFiltros;
        private TableLayoutPanel tableLayoutPanelFiltros;
        private Label labelFiltroNombre;
        private TextBox TxtFiltroNombre;
        private Label labelFiltroDescripcion;
        private TextBox TxtFiltroDescripcion;
        private Label labelFiltroCantidad;
        private TextBox TxtFiltroCantidad;
        private Button BtnLimpiarFiltro;
        private Button BtnAplicarFiltro;
    }
}
