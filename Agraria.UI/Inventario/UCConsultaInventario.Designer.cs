namespace Agraria.UI.Inventario
{
    partial class UCConsultaInventario
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
			label6 = new Label();
			LblCodigo = new Label();
			TxtFiltroCodigo = new TextBox();
			TxtFiltroNombre = new TextBox();
			LblDescripcion = new Label();
			TxtFiltroDescripcion = new TextBox();
			LblUnidadMedida = new Label();
			CmbFiltroUnidadMedida = new ComboBox();
			PanelLista = new Panel();
			tableLayoutPanel1 = new TableLayoutPanel();
			LblLista = new Label();
			ListBArticulos = new DataGridView();
			PanelMedio = new Panel();
			tableLayoutPanel4 = new TableLayoutPanel();
			groupBox1 = new GroupBox();
			TLPForm = new TableLayoutPanel();
			LblNombre = new Label();
			TxtPrecio = new TextBox();
			TxtCantidad = new TextBox();
			TxtNombre = new TextBox();
			label4 = new Label();
			label2 = new Label();
			tableLayoutPanel2 = new TableLayoutPanel();
			BtnGuardar = new Button();
			BtnEliminar = new Button();
			CMBUnidadMedida = new ComboBox();
			label1 = new Label();
			TxtDescripcion = new TextBox();
			label5 = new Label();
			CMBProveedor = new ComboBox();
			label3 = new Label();
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
			tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 17.9816513F));
			tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 82.01835F));
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
			PanelFiltros.Size = new Size(798, 92);
			PanelFiltros.TabIndex = 3;
			// 
			// tableLayoutPanelFiltros
			// 
			tableLayoutPanelFiltros.ColumnCount = 7;
			tableLayoutPanelFiltros.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
			tableLayoutPanelFiltros.ColumnStyles.Add(new ColumnStyle());
			tableLayoutPanelFiltros.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
			tableLayoutPanelFiltros.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
			tableLayoutPanelFiltros.ColumnStyles.Add(new ColumnStyle());
			tableLayoutPanelFiltros.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
			tableLayoutPanelFiltros.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
			tableLayoutPanelFiltros.Controls.Add(label6, 4, 0);
			tableLayoutPanelFiltros.Controls.Add(LblCodigo, 1, 0);
			tableLayoutPanelFiltros.Controls.Add(TxtFiltroCodigo, 2, 0);
			tableLayoutPanelFiltros.Controls.Add(TxtFiltroNombre, 5, 0);
			tableLayoutPanelFiltros.Controls.Add(LblDescripcion, 1, 1);
			tableLayoutPanelFiltros.Controls.Add(TxtFiltroDescripcion, 2, 1);
			tableLayoutPanelFiltros.Controls.Add(LblUnidadMedida, 4, 1);
			tableLayoutPanelFiltros.Controls.Add(CmbFiltroUnidadMedida, 5, 1);
			tableLayoutPanelFiltros.Dock = DockStyle.Fill;
			tableLayoutPanelFiltros.Location = new Point(8, 8);
			tableLayoutPanelFiltros.Name = "tableLayoutPanelFiltros";
			tableLayoutPanelFiltros.RowCount = 2;
			tableLayoutPanelFiltros.RowStyles.Add(new RowStyle());
			tableLayoutPanelFiltros.RowStyles.Add(new RowStyle());
			tableLayoutPanelFiltros.Size = new Size(782, 76);
			tableLayoutPanelFiltros.TabIndex = 0;
			// 
			// label6
			// 
			label6.Anchor = AnchorStyles.Right;
			label6.AutoSize = true;
			label6.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
			label6.Location = new Point(442, 7);
			label6.Name = "label6";
			label6.Size = new Size(75, 21);
			label6.TabIndex = 8;
			label6.Text = "Nombre:";
			label6.TextAlign = ContentAlignment.MiddleLeft;
			// 
			// LblCodigo
			// 
			LblCodigo.Anchor = AnchorStyles.Right;
			LblCodigo.AutoSize = true;
			LblCodigo.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
			LblCodigo.Location = new Point(55, 7);
			LblCodigo.Name = "LblCodigo";
			LblCodigo.Size = new Size(68, 21);
			LblCodigo.TabIndex = 0;
			LblCodigo.Text = "Código:";
			LblCodigo.TextAlign = ContentAlignment.MiddleLeft;
			// 
			// TxtFiltroCodigo
			// 
			TxtFiltroCodigo.Dock = DockStyle.Fill;
			TxtFiltroCodigo.Font = new Font("Segoe UI", 12F);
			TxtFiltroCodigo.Location = new Point(129, 3);
			TxtFiltroCodigo.Name = "TxtFiltroCodigo";
			TxtFiltroCodigo.Size = new Size(236, 29);
			TxtFiltroCodigo.TabIndex = 1;
			TxtFiltroCodigo.TextChanged += Filtros_TextChanged;
			// 
			// TxtFiltroNombre
			// 
			TxtFiltroNombre.Dock = DockStyle.Fill;
			TxtFiltroNombre.Font = new Font("Segoe UI", 12F);
			TxtFiltroNombre.Location = new Point(523, 3);
			TxtFiltroNombre.Name = "TxtFiltroNombre";
			TxtFiltroNombre.Size = new Size(236, 29);
			TxtFiltroNombre.TabIndex = 3;
			TxtFiltroNombre.TextChanged += Filtros_TextChanged;
			// 
			// LblDescripcion
			// 
			LblDescripcion.Anchor = AnchorStyles.Right;
			LblDescripcion.AutoSize = true;
			LblDescripcion.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
			LblDescripcion.Location = new Point(23, 45);
			LblDescripcion.Name = "LblDescripcion";
			LblDescripcion.Size = new Size(100, 21);
			LblDescripcion.TabIndex = 4;
			LblDescripcion.Text = "Descripción:";
			LblDescripcion.TextAlign = ContentAlignment.MiddleLeft;
			// 
			// TxtFiltroDescripcion
			// 
			TxtFiltroDescripcion.Dock = DockStyle.Fill;
			TxtFiltroDescripcion.Font = new Font("Segoe UI", 12F);
			TxtFiltroDescripcion.Location = new Point(129, 38);
			TxtFiltroDescripcion.Name = "TxtFiltroDescripcion";
			TxtFiltroDescripcion.Size = new Size(236, 29);
			TxtFiltroDescripcion.TabIndex = 5;
			TxtFiltroDescripcion.TextChanged += Filtros_TextChanged;
			// 
			// LblUnidadMedida
			// 
			LblUnidadMedida.Anchor = AnchorStyles.Right;
			LblUnidadMedida.AutoSize = true;
			LblUnidadMedida.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
			LblUnidadMedida.Location = new Point(391, 45);
			LblUnidadMedida.Name = "LblUnidadMedida";
			LblUnidadMedida.Size = new Size(126, 21);
			LblUnidadMedida.TabIndex = 6;
			LblUnidadMedida.Text = "Unidad Medida:";
			LblUnidadMedida.TextAlign = ContentAlignment.MiddleLeft;
			// 
			// CmbFiltroUnidadMedida
			// 
			CmbFiltroUnidadMedida.Dock = DockStyle.Fill;
			CmbFiltroUnidadMedida.DropDownStyle = ComboBoxStyle.DropDownList;
			CmbFiltroUnidadMedida.Font = new Font("Segoe UI", 12F);
			CmbFiltroUnidadMedida.Location = new Point(523, 38);
			CmbFiltroUnidadMedida.Name = "CmbFiltroUnidadMedida";
			CmbFiltroUnidadMedida.Size = new Size(236, 29);
			CmbFiltroUnidadMedida.TabIndex = 7;
			CmbFiltroUnidadMedida.SelectedIndexChanged += Filtros_TextChanged;
			// 
			// PanelLista
			// 
			PanelLista.BackColor = Color.FromArgb(218, 218, 220);
			PanelLista.Controls.Add(tableLayoutPanel1);
			PanelLista.Dock = DockStyle.Fill;
			PanelLista.Location = new Point(3, 117);
			PanelLista.Name = "PanelLista";
			PanelLista.Padding = new Padding(0, 16, 0, 16);
			PanelLista.Size = new Size(315, 441);
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
			tableLayoutPanel1.Size = new Size(315, 409);
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
			LblLista.Text = "Lista de Inventario";
			LblLista.TextAlign = ContentAlignment.MiddleCenter;
			// 
			// ListBArticulos
			// 
			ListBArticulos.AllowUserToAddRows = false;
			ListBArticulos.AllowUserToDeleteRows = false;
			ListBArticulos.AllowUserToResizeColumns = false;
			ListBArticulos.AllowUserToResizeRows = false;
			ListBArticulos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			ListBArticulos.Dock = DockStyle.Fill;
			ListBArticulos.Location = new Point(3, 35);
			ListBArticulos.Name = "ListBArticulos";
			ListBArticulos.ReadOnly = true;
			ListBArticulos.RowHeadersVisible = false;
			ListBArticulos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			ListBArticulos.Size = new Size(309, 371);
			ListBArticulos.TabIndex = 2;
			ListBArticulos.DataError += ListBArticulos_DataError;
			ListBArticulos.SelectionChanged += ListBArticulos_SelectedIndexChanged;
			// 
			// PanelMedio
			// 
			PanelMedio.Controls.Add(tableLayoutPanel4);
			PanelMedio.Dock = DockStyle.Fill;
			PanelMedio.Location = new Point(324, 117);
			PanelMedio.Name = "PanelMedio";
			PanelMedio.Size = new Size(477, 441);
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
			tableLayoutPanel4.Size = new Size(477, 441);
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
			groupBox1.Size = new Size(471, 435);
			groupBox1.TabIndex = 16;
			groupBox1.TabStop = false;
			groupBox1.Text = "Formulario de Edición de Inventario";
			// 
			// TLPForm
			// 
			TLPForm.BackColor = Color.FromArgb(249, 249, 251);
			TLPForm.ColumnCount = 3;
			TLPForm.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 27.95699F));
			TLPForm.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 59.5698929F));
			TLPForm.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.4731178F));
			TLPForm.Controls.Add(LblNombre, 0, 1);
			TLPForm.Controls.Add(TxtPrecio, 1, 4);
			TLPForm.Controls.Add(TxtCantidad, 1, 3);
			TLPForm.Controls.Add(TxtNombre, 1, 1);
			TLPForm.Controls.Add(label4, 0, 3);
			TLPForm.Controls.Add(label2, 0, 4);
			TLPForm.Controls.Add(tableLayoutPanel2, 1, 7);
			TLPForm.Controls.Add(CMBUnidadMedida, 1, 2);
			TLPForm.Controls.Add(label1, 0, 2);
			TLPForm.Controls.Add(TxtDescripcion, 1, 5);
			TLPForm.Controls.Add(label5, 0, 5);
			TLPForm.Controls.Add(CMBProveedor, 1, 6);
			TLPForm.Controls.Add(label3, 0, 6);
			TLPForm.Dock = DockStyle.Fill;
			TLPForm.ForeColor = Color.FromArgb(26, 28, 30);
			TLPForm.Location = new Point(3, 29);
			TLPForm.Name = "TLPForm";
			TLPForm.RowCount = 9;
			TLPForm.RowStyles.Add(new RowStyle(SizeType.Percent, 11.1111107F));
			TLPForm.RowStyles.Add(new RowStyle(SizeType.Percent, 11.1111107F));
			TLPForm.RowStyles.Add(new RowStyle(SizeType.Percent, 11.1111107F));
			TLPForm.RowStyles.Add(new RowStyle(SizeType.Percent, 11.1111107F));
			TLPForm.RowStyles.Add(new RowStyle(SizeType.Percent, 11.1111107F));
			TLPForm.RowStyles.Add(new RowStyle(SizeType.Percent, 11.1111107F));
			TLPForm.RowStyles.Add(new RowStyle(SizeType.Percent, 11.1111107F));
			TLPForm.RowStyles.Add(new RowStyle(SizeType.Percent, 13.3995037F));
			TLPForm.RowStyles.Add(new RowStyle(SizeType.Percent, 10.1736975F));
			TLPForm.Size = new Size(465, 403);
			TLPForm.TabIndex = 0;
			// 
			// LblNombre
			// 
			LblNombre.Anchor = AnchorStyles.Right;
			LblNombre.AutoSize = true;
			LblNombre.Font = new Font("Segoe UI", 12F);
			LblNombre.Location = new Point(56, 55);
			LblNombre.Name = "LblNombre";
			LblNombre.Size = new Size(71, 21);
			LblNombre.TabIndex = 0;
			LblNombre.Text = "Nombre:";
			LblNombre.TextAlign = ContentAlignment.MiddleLeft;
			// 
			// TxtPrecio
			// 
			TxtPrecio.Anchor = AnchorStyles.Left | AnchorStyles.Right;
			TxtPrecio.BackColor = Color.FromArgb(238, 237, 240);
			TxtPrecio.Font = new Font("Segoe UI", 12F);
			TxtPrecio.ForeColor = Color.FromArgb(26, 28, 30);
			TxtPrecio.Location = new Point(133, 183);
			TxtPrecio.MaxLength = 12;
			TxtPrecio.Name = "TxtPrecio";
			TxtPrecio.Size = new Size(271, 29);
			TxtPrecio.TabIndex = 8;
			TxtPrecio.TextChanged += TxtNombre_TextChanged;
			// 
			// TxtCantidad
			// 
			TxtCantidad.Anchor = AnchorStyles.Left | AnchorStyles.Right;
			TxtCantidad.BackColor = Color.FromArgb(238, 237, 240);
			TxtCantidad.Font = new Font("Segoe UI", 12F);
			TxtCantidad.ForeColor = Color.FromArgb(26, 28, 30);
			TxtCantidad.Location = new Point(133, 139);
			TxtCantidad.MaxLength = 12;
			TxtCantidad.Name = "TxtCantidad";
			TxtCantidad.Size = new Size(271, 29);
			TxtCantidad.TabIndex = 7;
			TxtCantidad.TextChanged += TxtNombre_TextChanged;
			// 
			// TxtNombre
			// 
			TxtNombre.Anchor = AnchorStyles.Left | AnchorStyles.Right;
			TxtNombre.BackColor = Color.FromArgb(238, 237, 240);
			TxtNombre.Font = new Font("Segoe UI", 12F);
			TxtNombre.ForeColor = Color.FromArgb(26, 28, 30);
			TxtNombre.Location = new Point(133, 51);
			TxtNombre.MaxLength = 50;
			TxtNombre.Name = "TxtNombre";
			TxtNombre.Size = new Size(271, 29);
			TxtNombre.TabIndex = 5;
			TxtNombre.TextChanged += TxtNombre_TextChanged;
			// 
			// label4
			// 
			label4.Anchor = AnchorStyles.Right;
			label4.AutoSize = true;
			label4.Font = new Font("Segoe UI", 12F);
			label4.Location = new Point(52, 143);
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
			label2.Location = new Point(61, 187);
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
			tableLayoutPanel2.Location = new Point(133, 311);
			tableLayoutPanel2.Name = "tableLayoutPanel2";
			tableLayoutPanel2.RowCount = 1;
			tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
			tableLayoutPanel2.Size = new Size(271, 47);
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
			BtnGuardar.Location = new Point(0, 2);
			BtnGuardar.Margin = new Padding(0);
			BtnGuardar.Name = "BtnGuardar";
			BtnGuardar.Size = new Size(135, 43);
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
			BtnEliminar.Location = new Point(179, 2);
			BtnEliminar.Margin = new Padding(0);
			BtnEliminar.Name = "BtnEliminar";
			BtnEliminar.Size = new Size(48, 43);
			BtnEliminar.TabIndex = 13;
			BtnEliminar.UseVisualStyleBackColor = false;
			BtnEliminar.Visible = false;
			BtnEliminar.EnabledChanged += BtnGuardar_EnabledChanged;
			BtnEliminar.Click += BtnEliminar_Click;
			// 
			// CMBUnidadMedida
			// 
			CMBUnidadMedida.Anchor = AnchorStyles.Left | AnchorStyles.Right;
			CMBUnidadMedida.DropDownStyle = ComboBoxStyle.DropDownList;
			CMBUnidadMedida.Font = new Font("Segoe UI", 12F);
			CMBUnidadMedida.FormattingEnabled = true;
			CMBUnidadMedida.Location = new Point(133, 95);
			CMBUnidadMedida.Name = "CMBUnidadMedida";
			CMBUnidadMedida.Size = new Size(271, 29);
			CMBUnidadMedida.TabIndex = 6;
			// 
			// label1
			// 
			label1.Anchor = AnchorStyles.Right;
			label1.AutoSize = true;
			label1.Font = new Font("Segoe UI", 12F);
			label1.Location = new Point(8, 99);
			label1.Name = "label1";
			label1.Size = new Size(119, 21);
			label1.TabIndex = 1;
			label1.Text = "Unidad Medida:";
			// 
			// TxtDescripcion
			// 
			TxtDescripcion.BackColor = Color.FromArgb(238, 237, 240);
			TxtDescripcion.Dock = DockStyle.Fill;
			TxtDescripcion.Font = new Font("Segoe UI", 12F);
			TxtDescripcion.ForeColor = Color.FromArgb(26, 28, 30);
			TxtDescripcion.Location = new Point(133, 223);
			TxtDescripcion.MaxLength = 400;
			TxtDescripcion.Multiline = true;
			TxtDescripcion.Name = "TxtDescripcion";
			TxtDescripcion.Size = new Size(271, 38);
			TxtDescripcion.TabIndex = 9;
			TxtDescripcion.TextChanged += TxtNombre_TextChanged;
			// 
			// label5
			// 
			label5.Anchor = AnchorStyles.Right;
			label5.AutoSize = true;
			label5.Font = new Font("Segoe UI", 12F);
			label5.Location = new Point(33, 231);
			label5.Name = "label5";
			label5.Size = new Size(94, 21);
			label5.TabIndex = 12;
			label5.Text = "Descripción:";
			// 
			// CMBProveedor
			// 
			CMBProveedor.Anchor = AnchorStyles.Left | AnchorStyles.Right;
			CMBProveedor.DropDownStyle = ComboBoxStyle.DropDownList;
			CMBProveedor.Font = new Font("Segoe UI", 12F);
			CMBProveedor.FormattingEnabled = true;
			CMBProveedor.Location = new Point(132, 273);
			CMBProveedor.Margin = new Padding(2, 8, 4, 4);
			CMBProveedor.Name = "CMBProveedor";
			CMBProveedor.Size = new Size(271, 29);
			CMBProveedor.TabIndex = 19;
			// 
			// label3
			// 
			label3.Anchor = AnchorStyles.Right;
			label3.AutoSize = true;
			label3.Font = new Font("Segoe UI", 12F);
			label3.Location = new Point(42, 275);
			label3.Name = "label3";
			label3.Size = new Size(85, 21);
			label3.TabIndex = 20;
			label3.Text = "Proveedor:";
			label3.TextAlign = ContentAlignment.MiddleLeft;
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
			// UCConsultaInventario
			// 
			AutoScaleMode = AutoScaleMode.None;
			BackColor = Color.FromArgb(249, 249, 251);
			Controls.Add(tableLayoutPanel3);
			Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
			ForeColor = Color.FromArgb(26, 28, 30);
			Margin = new Padding(4);
			Name = "UCConsultaInventario";
			Size = new Size(804, 561);
			Load += UCConsultaInventario_Load;
			VisibleChanged += UCConsultaInventario_VisibleChanged;
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
        private Label LblNombre;
        private Label LblFiltroNombre;
        private TextBox TxtFiltroNombre;
        private TextBox TxtPrecio;
        private TextBox TxtCantidad;
        private TextBox TxtNombre;
        private Label label4;
        private Label label2;
        private Label label5;
        private TableLayoutPanel tableLayoutPanel2;
        private Button BtnGuardar;
        private Button BtnEliminar;
        private ProgressBar ProgressBar;
        private DataGridView ListBArticulos;
        private ComboBox CMBUnidadMedida;
        private TextBox TxtDescripcion;
        private Panel PanelFiltros;
        private TableLayoutPanel tableLayoutPanelFiltros;
        private Label LblCodigo;
        private TextBox TxtFiltroCodigo;
        private Label LblDescripcion;
        private TextBox TxtFiltroDescripcion;
        private Label LblUnidadMedida;
        private ComboBox CmbFiltroUnidadMedida;
        private Label label3;
        private ComboBox CMBProveedor;
        private Label label6;
    }
}