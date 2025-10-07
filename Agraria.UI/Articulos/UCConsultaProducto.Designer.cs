namespace Agraria.UI.Articulos
{
    partial class UCConsultaProducto
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
            PanelFiltros = new Panel();
            tableLayoutPanelFiltros = new TableLayoutPanel();
            LblCodigo = new Label();
            TxtFiltroCodigo = new TextBox();
            LblDescripcion = new Label();
            TxtFiltroDescripcion = new TextBox();
            LblProveedor = new Label();
            CmbFiltroProveedor = new ComboBox();
            LblEnVenta = new Label();
            CmbFiltroEnVenta = new ComboBox();
            PanelLista = new Panel();
            tableLayoutPanel1 = new TableLayoutPanel();
            LblLista = new Label();
            ListBArticulos = new DataGridView();
            Cantidad = new DataGridViewTextBoxColumn();
            Descripcion = new DataGridViewTextBoxColumn();
            PanelMedio = new Panel();
            tableLayoutPanel4 = new TableLayoutPanel();
            groupBox1 = new GroupBox();
            TLPForm = new TableLayoutPanel();
            label3 = new Label();
            LblCuit = new Label();
            TxtGanancia = new TextBox();
            TxtCosto = new TextBox();
            TxtCantidad = new TextBox();
            TxtDescripcion = new TextBox();
            label4 = new Label();
            label2 = new Label();
            tableLayoutPanel2 = new TableLayoutPanel();
            BtnGuardar = new Button();
            BtnEliminar = new Button();
            CMBEntorno = new ComboBox();
            CMBTipoEntorno = new ComboBox();
            CMBProveedor = new ComboBox();
            label5 = new Label();
            label1 = new Label();
            label6 = new Label();
            label7 = new Label();
            LblPrecio = new Label();
            ProgressBar = new ProgressBar();
            tableLayoutPanel3.SuspendLayout();
            PanelFiltros.SuspendLayout();
            tableLayoutPanelFiltros.SuspendLayout();
            PanelLista.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ListBArticulos).BeginInit();
            PanelMedio.SuspendLayout();
            tableLayoutPanel4.SuspendLayout();
            groupBox1.SuspendLayout();
            TLPForm.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.BackColor = Color.FromArgb(218, 218, 220);
            tableLayoutPanel3.ColumnCount = 2;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60F));
            tableLayoutPanel3.Controls.Add(PanelFiltros, 0, 1);
            tableLayoutPanel3.Controls.Add(PanelLista, 0, 2);
            tableLayoutPanel3.Controls.Add(PanelMedio, 1, 2);
            tableLayoutPanel3.Controls.Add(ProgressBar, 0, 0);
            tableLayoutPanel3.Dock = DockStyle.Fill;
            tableLayoutPanel3.Location = new Point(0, 0);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 3;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 16F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 21.1009178F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 78.899086F));
            tableLayoutPanel3.Size = new Size(804, 561);
            tableLayoutPanel3.TabIndex = 3;
            // 
            // PanelFiltros
            // 
            PanelFiltros.BackColor = Color.FromArgb(240, 240, 240);
            tableLayoutPanel3.SetColumnSpan(PanelFiltros, 2);
            PanelFiltros.Controls.Add(tableLayoutPanelFiltros);
            PanelFiltros.Dock = DockStyle.Fill;
            PanelFiltros.Location = new Point(3, 19);
            PanelFiltros.Name = "PanelFiltros";
            PanelFiltros.Padding = new Padding(8);
            PanelFiltros.Size = new Size(798, 109);
            PanelFiltros.TabIndex = 2;
            // 
            // tableLayoutPanelFiltros
            // 
            tableLayoutPanelFiltros.ColumnCount = 6;
            tableLayoutPanelFiltros.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanelFiltros.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanelFiltros.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanelFiltros.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanelFiltros.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanelFiltros.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanelFiltros.Controls.Add(LblCodigo, 1, 0);
            tableLayoutPanelFiltros.Controls.Add(TxtFiltroCodigo, 2, 0);
            tableLayoutPanelFiltros.Controls.Add(LblDescripcion, 3, 0);
            tableLayoutPanelFiltros.Controls.Add(TxtFiltroDescripcion, 4, 0);
            tableLayoutPanelFiltros.Controls.Add(LblProveedor, 1, 1);
            tableLayoutPanelFiltros.Controls.Add(CmbFiltroProveedor, 2, 1);
            tableLayoutPanelFiltros.Controls.Add(LblEnVenta, 3, 1);
            tableLayoutPanelFiltros.Controls.Add(CmbFiltroEnVenta, 4, 1);
            tableLayoutPanelFiltros.Dock = DockStyle.Fill;
            tableLayoutPanelFiltros.Location = new Point(8, 8);
            tableLayoutPanelFiltros.Name = "tableLayoutPanelFiltros";
            tableLayoutPanelFiltros.RowCount = 2;
            tableLayoutPanelFiltros.RowStyles.Add(new RowStyle());
            tableLayoutPanelFiltros.RowStyles.Add(new RowStyle());
            tableLayoutPanelFiltros.Size = new Size(782, 93);
            tableLayoutPanelFiltros.TabIndex = 0;
            // 
            // LblCodigo
            // 
            LblCodigo.Dock = DockStyle.Fill;
            LblCodigo.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            LblCodigo.Location = new Point(23, 0);
            LblCodigo.Name = "LblCodigo";
            LblCodigo.Size = new Size(92, 35);
            LblCodigo.TabIndex = 0;
            LblCodigo.Text = "Código:";
            LblCodigo.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // TxtFiltroCodigo
            // 
            TxtFiltroCodigo.Dock = DockStyle.Fill;
            TxtFiltroCodigo.Font = new Font("Segoe UI", 12F);
            TxtFiltroCodigo.Location = new Point(121, 3);
            TxtFiltroCodigo.Name = "TxtFiltroCodigo";
            TxtFiltroCodigo.Size = new Size(263, 29);
            TxtFiltroCodigo.TabIndex = 1;
            TxtFiltroCodigo.TextChanged += Filtros_TextChanged;
            // 
            // LblDescripcion
            // 
            LblDescripcion.Dock = DockStyle.Fill;
            LblDescripcion.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            LblDescripcion.Location = new Point(390, 0);
            LblDescripcion.Name = "LblDescripcion";
            LblDescripcion.Size = new Size(100, 35);
            LblDescripcion.TabIndex = 2;
            LblDescripcion.Text = "Descripción:";
            LblDescripcion.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // TxtFiltroDescripcion
            // 
            TxtFiltroDescripcion.Dock = DockStyle.Fill;
            TxtFiltroDescripcion.Font = new Font("Segoe UI", 12F);
            TxtFiltroDescripcion.Location = new Point(496, 3);
            TxtFiltroDescripcion.Name = "TxtFiltroDescripcion";
            TxtFiltroDescripcion.Size = new Size(263, 29);
            TxtFiltroDescripcion.TabIndex = 3;
            TxtFiltroDescripcion.TextChanged += Filtros_TextChanged;
            // 
            // LblProveedor
            // 
            LblProveedor.Dock = DockStyle.Fill;
            LblProveedor.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            LblProveedor.Location = new Point(23, 35);
            LblProveedor.Name = "LblProveedor";
            LblProveedor.Size = new Size(92, 58);
            LblProveedor.TabIndex = 4;
            LblProveedor.Text = "Proveedor:";
            LblProveedor.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // CmbFiltroProveedor
            // 
            CmbFiltroProveedor.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            CmbFiltroProveedor.DropDownStyle = ComboBoxStyle.DropDownList;
            CmbFiltroProveedor.Font = new Font("Segoe UI", 12F);
            CmbFiltroProveedor.Location = new Point(121, 49);
            CmbFiltroProveedor.Name = "CmbFiltroProveedor";
            CmbFiltroProveedor.Size = new Size(263, 29);
            CmbFiltroProveedor.TabIndex = 5;
            CmbFiltroProveedor.SelectedIndexChanged += Filtros_TextChanged;
            // 
            // LblEnVenta
            // 
            LblEnVenta.Dock = DockStyle.Fill;
            LblEnVenta.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            LblEnVenta.Location = new Point(390, 35);
            LblEnVenta.Name = "LblEnVenta";
            LblEnVenta.Size = new Size(100, 58);
            LblEnVenta.TabIndex = 6;
            LblEnVenta.Text = "En Venta:";
            LblEnVenta.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // CmbFiltroEnVenta
            // 
            CmbFiltroEnVenta.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            CmbFiltroEnVenta.DropDownStyle = ComboBoxStyle.DropDownList;
            CmbFiltroEnVenta.Font = new Font("Segoe UI", 12F);
            CmbFiltroEnVenta.Items.AddRange(new object[] { "Todos", "Sí", "No" });
            CmbFiltroEnVenta.Location = new Point(496, 49);
            CmbFiltroEnVenta.Name = "CmbFiltroEnVenta";
            CmbFiltroEnVenta.Size = new Size(263, 29);
            CmbFiltroEnVenta.TabIndex = 7;
            CmbFiltroEnVenta.SelectedIndexChanged += Filtros_TextChanged;
            // 
            // PanelLista
            // 
            PanelLista.BackColor = Color.FromArgb(218, 218, 220);
            PanelLista.Controls.Add(tableLayoutPanel1);
            PanelLista.Dock = DockStyle.Fill;
            PanelLista.Location = new Point(3, 134);
            PanelLista.Name = "PanelLista";
            PanelLista.Padding = new Padding(0, 16, 0, 16);
            PanelLista.Size = new Size(315, 424);
            PanelLista.TabIndex = 3;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(LblLista, 0, 0);
            tableLayoutPanel1.Controls.Add(ListBArticulos, 0, 2);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 16);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 32F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(315, 392);
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
            LblLista.Text = "Lista de Productos";
            LblLista.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // ListBArticulos
            // 
            ListBArticulos.AllowUserToAddRows = false;
            ListBArticulos.AllowUserToDeleteRows = false;
            ListBArticulos.AllowUserToResizeColumns = false;
            ListBArticulos.AllowUserToResizeRows = false;
            ListBArticulos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            ListBArticulos.Columns.AddRange(new DataGridViewColumn[] { Cantidad, Descripcion });
            ListBArticulos.Dock = DockStyle.Fill;
            ListBArticulos.Location = new Point(3, 35);
            ListBArticulos.Name = "ListBArticulos";
            ListBArticulos.ReadOnly = true;
            ListBArticulos.RowHeadersVisible = false;
            ListBArticulos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            ListBArticulos.Size = new Size(309, 354);
            ListBArticulos.TabIndex = 2;
            ListBArticulos.DataError += ListBArticulos_DataError;
            ListBArticulos.SelectionChanged += ListBArticulos_SelectedIndexChanged;
            // 
            // Cantidad
            // 
            Cantidad.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            Cantidad.DataPropertyName = "Cod_Producto";
            Cantidad.HeaderText = "CÓDIGO";
            Cantidad.Name = "Cantidad";
            Cantidad.ReadOnly = true;
            Cantidad.Width = 95;
            // 
            // Descripcion
            // 
            Descripcion.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Descripcion.DataPropertyName = "Producto_Desc";
            Descripcion.HeaderText = "DESCRIPCIÓN";
            Descripcion.Name = "Descripcion";
            Descripcion.ReadOnly = true;
            // 
            // PanelMedio
            // 
            PanelMedio.Controls.Add(tableLayoutPanel4);
            PanelMedio.Dock = DockStyle.Fill;
            PanelMedio.Location = new Point(324, 134);
            PanelMedio.Name = "PanelMedio";
            PanelMedio.Size = new Size(477, 424);
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
            tableLayoutPanel4.Size = new Size(477, 424);
            tableLayoutPanel4.TabIndex = 2;
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            groupBox1.Controls.Add(TLPForm);
            groupBox1.Font = new Font("Segoe UI Black", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox1.ForeColor = Color.FromArgb(7, 100, 147);
            groupBox1.Location = new Point(3, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(471, 417);
            groupBox1.TabIndex = 16;
            groupBox1.TabStop = false;
            groupBox1.Text = "Formulario de Edición de Productos";
            // 
            // TLPForm
            // 
            TLPForm.BackColor = Color.FromArgb(249, 249, 251);
            TLPForm.ColumnCount = 3;
            TLPForm.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 27.95699F));
            TLPForm.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 59.5698929F));
            TLPForm.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.4731178F));
            TLPForm.Controls.Add(label3, 0, 4);
            TLPForm.Controls.Add(LblCuit, 0, 1);
            TLPForm.Controls.Add(TxtGanancia, 1, 4);
            TLPForm.Controls.Add(TxtCosto, 1, 3);
            TLPForm.Controls.Add(TxtCantidad, 1, 2);
            TLPForm.Controls.Add(TxtDescripcion, 1, 1);
            TLPForm.Controls.Add(label4, 0, 2);
            TLPForm.Controls.Add(label2, 0, 3);
            TLPForm.Controls.Add(tableLayoutPanel2, 1, 9);
            TLPForm.Controls.Add(CMBEntorno, 1, 8);
            TLPForm.Controls.Add(CMBTipoEntorno, 1, 7);
            TLPForm.Controls.Add(CMBProveedor, 1, 6);
            TLPForm.Controls.Add(label5, 0, 8);
            TLPForm.Controls.Add(label1, 0, 7);
            TLPForm.Controls.Add(label6, 0, 6);
            TLPForm.Controls.Add(label7, 0, 5);
            TLPForm.Controls.Add(LblPrecio, 1, 5);
            TLPForm.Dock = DockStyle.Fill;
            TLPForm.ForeColor = Color.FromArgb(26, 28, 30);
            TLPForm.Location = new Point(3, 29);
            TLPForm.Name = "TLPForm";
            TLPForm.RowCount = 11;
            TLPForm.RowStyles.Add(new RowStyle(SizeType.Absolute, 8F));
            TLPForm.RowStyles.Add(new RowStyle(SizeType.Percent, 10.8401089F));
            TLPForm.RowStyles.Add(new RowStyle(SizeType.Percent, 9.141274F));
            TLPForm.RowStyles.Add(new RowStyle(SizeType.Percent, 13.5734072F));
            TLPForm.RowStyles.Add(new RowStyle(SizeType.Percent, 11.1111107F));
            TLPForm.RowStyles.Add(new RowStyle(SizeType.Percent, 11.1111107F));
            TLPForm.RowStyles.Add(new RowStyle(SizeType.Percent, 11.1111107F));
            TLPForm.RowStyles.Add(new RowStyle(SizeType.Percent, 11.1111107F));
            TLPForm.RowStyles.Add(new RowStyle(SizeType.Percent, 11.1111107F));
            TLPForm.RowStyles.Add(new RowStyle(SizeType.Percent, 11.1111107F));
            TLPForm.RowStyles.Add(new RowStyle(SizeType.Absolute, 8F));
            TLPForm.Size = new Size(465, 385);
            TLPForm.TabIndex = 0;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F);
            label3.Location = new Point(33, 138);
            label3.Name = "label3";
            label3.Size = new Size(94, 21);
            label3.TabIndex = 3;
            label3.Text = "Ganancia: %";
            // 
            // LblCuit
            // 
            LblCuit.Anchor = AnchorStyles.Right;
            LblCuit.AutoSize = true;
            LblCuit.Font = new Font("Segoe UI", 12F);
            LblCuit.Location = new Point(33, 17);
            LblCuit.Name = "LblCuit";
            LblCuit.Size = new Size(94, 21);
            LblCuit.TabIndex = 0;
            LblCuit.Text = "Descripción:";
            // 
            // TxtGanancia
            // 
            TxtGanancia.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            TxtGanancia.BackColor = Color.FromArgb(238, 237, 240);
            TxtGanancia.Font = new Font("Segoe UI", 12F);
            TxtGanancia.ForeColor = Color.FromArgb(26, 28, 30);
            TxtGanancia.Location = new Point(133, 134);
            TxtGanancia.MaxLength = 12;
            TxtGanancia.Name = "TxtGanancia";
            TxtGanancia.Size = new Size(271, 29);
            TxtGanancia.TabIndex = 8;
            TxtGanancia.TextChanged += TxtDescripcion_TextChanged;
            TxtGanancia.KeyUp += TxtCosto_KeyUp;
            // 
            // TxtCosto
            // 
            TxtCosto.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            TxtCosto.BackColor = Color.FromArgb(238, 237, 240);
            TxtCosto.Font = new Font("Segoe UI", 12F);
            TxtCosto.ForeColor = Color.FromArgb(26, 28, 30);
            TxtCosto.Location = new Point(133, 90);
            TxtCosto.MaxLength = 12;
            TxtCosto.Name = "TxtCosto";
            TxtCosto.Size = new Size(271, 29);
            TxtCosto.TabIndex = 7;
            TxtCosto.TextChanged += TxtDescripcion_TextChanged;
            TxtCosto.KeyUp += TxtCosto_KeyUp;
            // 
            // TxtCantidad
            // 
            TxtCantidad.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            TxtCantidad.BackColor = Color.FromArgb(238, 237, 240);
            TxtCantidad.Font = new Font("Segoe UI", 12F);
            TxtCantidad.ForeColor = Color.FromArgb(26, 28, 30);
            TxtCantidad.Location = new Point(133, 50);
            TxtCantidad.MaxLength = 12;
            TxtCantidad.Name = "TxtCantidad";
            TxtCantidad.Size = new Size(271, 29);
            TxtCantidad.TabIndex = 6;
            TxtCantidad.TextChanged += TxtDescripcion_TextChanged;
            // 
            // TxtDescripcion
            // 
            TxtDescripcion.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            TxtDescripcion.BackColor = Color.FromArgb(238, 237, 240);
            TxtDescripcion.Font = new Font("Segoe UI", 12F);
            TxtDescripcion.ForeColor = Color.FromArgb(26, 28, 30);
            TxtDescripcion.Location = new Point(133, 13);
            TxtDescripcion.MaxLength = 50;
            TxtDescripcion.Name = "TxtDescripcion";
            TxtDescripcion.Size = new Size(271, 29);
            TxtDescripcion.TabIndex = 5;
            TxtDescripcion.TextChanged += TxtDescripcion_TextChanged;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Right;
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F);
            label4.Location = new Point(52, 53);
            label4.Name = "label4";
            label4.Size = new Size(75, 21);
            label4.TabIndex = 4;
            label4.Text = "Cantidad:";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(61, 94);
            label2.Name = "label2";
            label2.Size = new Size(66, 21);
            label2.TabIndex = 2;
            label2.Text = "Costo: $";
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Controls.Add(BtnGuardar, 0, 0);
            tableLayoutPanel2.Controls.Add(BtnEliminar, 1, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(133, 332);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            TLPForm.SetRowSpan(tableLayoutPanel2, 2);
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Size = new Size(271, 50);
            tableLayoutPanel2.TabIndex = 18;
            // 
            // BtnGuardar
            // 
            BtnGuardar.BackColor = Color.FromArgb(101, 89, 119);
            BtnGuardar.FlatAppearance.BorderColor = Color.FromArgb(203, 230, 255);
            BtnGuardar.FlatStyle = FlatStyle.Flat;
            BtnGuardar.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BtnGuardar.ForeColor = Color.FromArgb(255, 255, 255);
            BtnGuardar.Image = Properties.Resources.guardar;
            BtnGuardar.ImageAlign = ContentAlignment.MiddleRight;
            BtnGuardar.Location = new Point(0, 0);
            BtnGuardar.Margin = new Padding(0);
            BtnGuardar.Name = "BtnGuardar";
            BtnGuardar.Size = new Size(135, 48);
            BtnGuardar.TabIndex = 12;
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
            BtnEliminar.Location = new Point(179, 1);
            BtnEliminar.Margin = new Padding(0);
            BtnEliminar.Name = "BtnEliminar";
            BtnEliminar.Size = new Size(48, 48);
            BtnEliminar.TabIndex = 13;
            BtnEliminar.UseVisualStyleBackColor = false;
            BtnEliminar.Visible = false;
            BtnEliminar.EnabledChanged += BtnGuardar_EnabledChanged;
            BtnEliminar.Click += BtnEliminar_Click;
            // 
            // CMBEntorno
            // 
            CMBEntorno.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            CMBEntorno.DropDownStyle = ComboBoxStyle.DropDownList;
            CMBEntorno.Font = new Font("Segoe UI", 12F);
            CMBEntorno.FormattingEnabled = true;
            CMBEntorno.Location = new Point(133, 294);
            CMBEntorno.Name = "CMBEntorno";
            CMBEntorno.Size = new Size(271, 29);
            CMBEntorno.TabIndex = 11;
            // 
            // CMBTipoEntorno
            // 
            CMBTipoEntorno.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            CMBTipoEntorno.DropDownStyle = ComboBoxStyle.DropDownList;
            CMBTipoEntorno.Font = new Font("Segoe UI", 12F);
            CMBTipoEntorno.FormattingEnabled = true;
            CMBTipoEntorno.Location = new Point(133, 254);
            CMBTipoEntorno.Name = "CMBTipoEntorno";
            CMBTipoEntorno.Size = new Size(271, 29);
            CMBTipoEntorno.TabIndex = 10;
            CMBTipoEntorno.SelectedIndexChanged += CMBCategoria_SelectedIndexChanged;
            // 
            // CMBProveedor
            // 
            CMBProveedor.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            CMBProveedor.DropDownStyle = ComboBoxStyle.DropDownList;
            CMBProveedor.Font = new Font("Segoe UI", 12F);
            CMBProveedor.FormattingEnabled = true;
            CMBProveedor.Location = new Point(133, 214);
            CMBProveedor.Name = "CMBProveedor";
            CMBProveedor.Size = new Size(271, 29);
            CMBProveedor.TabIndex = 9;
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Right;
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F);
            label5.Location = new Point(59, 298);
            label5.Name = "label5";
            label5.Size = new Size(68, 21);
            label5.TabIndex = 12;
            label5.Text = "Entorno:";
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(4, 258);
            label1.Name = "label1";
            label1.Size = new Size(123, 21);
            label1.TabIndex = 1;
            label1.Text = "Tipo de Entorno:";
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Right;
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F);
            label6.Location = new Point(42, 218);
            label6.Name = "label6";
            label6.Size = new Size(85, 21);
            label6.TabIndex = 17;
            label6.Text = "Proveedor:";
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.Right;
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 12F);
            label7.Location = new Point(8, 178);
            label7.Name = "label7";
            label7.Size = new Size(119, 21);
            label7.TabIndex = 19;
            label7.Text = "Precio de venta:";
            // 
            // LblPrecio
            // 
            LblPrecio.Anchor = AnchorStyles.Left;
            LblPrecio.AutoSize = true;
            LblPrecio.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LblPrecio.Location = new Point(133, 178);
            LblPrecio.Name = "LblPrecio";
            LblPrecio.Size = new Size(19, 21);
            LblPrecio.TabIndex = 20;
            LblPrecio.Text = "0";
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
            // 
            // UCConsultaProducto
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.FromArgb(249, 249, 251);
            Controls.Add(tableLayoutPanel3);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ForeColor = Color.FromArgb(26, 28, 30);
            Margin = new Padding(4);
            Name = "UCConsultaProducto";
            Size = new Size(804, 561);
            Load += UCConsultaArticulos_Load;
            VisibleChanged += UCConsultaArticulos_VisibleChanged;
            tableLayoutPanel3.ResumeLayout(false);
            PanelFiltros.ResumeLayout(false);
            tableLayoutPanelFiltros.ResumeLayout(false);
            tableLayoutPanelFiltros.PerformLayout();
            PanelLista.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)ListBArticulos).EndInit();
            PanelMedio.ResumeLayout(false);
            tableLayoutPanel4.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            TLPForm.ResumeLayout(false);
            TLPForm.PerformLayout();
            tableLayoutPanel2.ResumeLayout(false);
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
        private Label label1;
        private Label label3;
        private Label LblCuit;
        private TextBox TxtGanancia;
        private TextBox TxtCosto;
        private TextBox TxtCantidad;
        private TextBox TxtDescripcion;
        private Label label4;
        private Label label2;
        private Label label5;
        private ComboBox CMBProveedor;
        private ComboBox CMBEntorno;
        private ComboBox CMBTipoEntorno;
        private Label label6;
        private TableLayoutPanel tableLayoutPanel2;
        private Button BtnGuardar;
        private Button BtnEliminar;
        private ProgressBar ProgressBar;
        private DataGridView ListBArticulos;
        private Label label7;
        private Label LblPrecio;
        private DataGridViewTextBoxColumn Cantidad;
        private DataGridViewTextBoxColumn Descripcion;
        private Panel PanelFiltros;
        private TableLayoutPanel tableLayoutPanelFiltros;
        private Label LblCodigo;
        private TextBox TxtFiltroCodigo;
        private Label LblDescripcion;
        private TextBox TxtFiltroDescripcion;
        private Label LblProveedor;
        private ComboBox CmbFiltroProveedor;
        private Label LblEnVenta;
        private ComboBox CmbFiltroEnVenta;
    }
}
