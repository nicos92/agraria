namespace Agraria.UI.Articulos
{
    partial class UCGestionEntornos
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
			GNTipoEntornos = new GroupBox();
			tableLayoutPanel1 = new TableLayoutPanel();
			BtnActualizar = new Button();
			DgvTipoEntornos = new DataGridView();
			GBFormEntornos = new GroupBox();
			tableLayoutPanel3 = new TableLayoutPanel();
			label1 = new Label();
			TxtTipoEntorno = new TextBox();
			tableLayoutPanel4 = new TableLayoutPanel();
			BtnNuevoTipoEntorno = new Button();
			BtnEliminarTipoEntorno = new Button();
			BtnGuardarTipoEntorno = new Button();
			PbProgreso = new ProgressBar();
			GBEntornos = new GroupBox();
			tableLayoutPanel5 = new TableLayoutPanel();
			tableLayoutPanel6 = new TableLayoutPanel();
			label3 = new Label();
			LblEntornoSeleccionado = new Label();
			DgvEntornos = new DataGridView();
			GBFormSubEntornos = new GroupBox();
			tableLayoutPanel7 = new TableLayoutPanel();
			label2 = new Label();
			TxtEntorno = new TextBox();
			tableLayoutPanel8 = new TableLayoutPanel();
			BtnNuevoEntorno = new Button();
			BtnEliminarEntorno = new Button();
			BtnGuardarEntorno = new Button();
			splitContainer1 = new SplitContainer();
			GNTipoEntornos.SuspendLayout();
			tableLayoutPanel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)DgvTipoEntornos).BeginInit();
			GBFormEntornos.SuspendLayout();
			tableLayoutPanel3.SuspendLayout();
			tableLayoutPanel4.SuspendLayout();
			GBEntornos.SuspendLayout();
			tableLayoutPanel5.SuspendLayout();
			tableLayoutPanel6.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)DgvEntornos).BeginInit();
			GBFormSubEntornos.SuspendLayout();
			tableLayoutPanel7.SuspendLayout();
			tableLayoutPanel8.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
			splitContainer1.Panel1.SuspendLayout();
			splitContainer1.Panel2.SuspendLayout();
			splitContainer1.SuspendLayout();
			SuspendLayout();
			// 
			// GNTipoEntornos
			// 
			GNTipoEntornos.Controls.Add(tableLayoutPanel1);
			GNTipoEntornos.Dock = DockStyle.Fill;
			GNTipoEntornos.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
			GNTipoEntornos.Location = new Point(8, 8);
			GNTipoEntornos.Name = "GNTipoEntornos";
			GNTipoEntornos.Size = new Size(394, 461);
			GNTipoEntornos.TabIndex = 0;
			GNTipoEntornos.TabStop = false;
			GNTipoEntornos.Text = "Areas";
			// 
			// tableLayoutPanel1
			// 
			tableLayoutPanel1.ColumnCount = 1;
			tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
			tableLayoutPanel1.Controls.Add(BtnActualizar, 0, 0);
			tableLayoutPanel1.Controls.Add(DgvTipoEntornos, 0, 2);
			tableLayoutPanel1.Controls.Add(GBFormEntornos, 0, 1);
			tableLayoutPanel1.Dock = DockStyle.Fill;
			tableLayoutPanel1.Location = new Point(3, 25);
			tableLayoutPanel1.Name = "tableLayoutPanel1";
			tableLayoutPanel1.RowCount = 3;
			tableLayoutPanel1.RowStyles.Add(new RowStyle());
			tableLayoutPanel1.RowStyles.Add(new RowStyle());
			tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
			tableLayoutPanel1.Size = new Size(388, 433);
			tableLayoutPanel1.TabIndex = 0;
			// 
			// BtnActualizar
			// 
			BtnActualizar.Anchor = AnchorStyles.None;
			BtnActualizar.BackColor = Color.FromArgb(7, 100, 147);
			BtnActualizar.FlatStyle = FlatStyle.Flat;
			BtnActualizar.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
			BtnActualizar.ForeColor = Color.White;
			BtnActualizar.Location = new Point(109, 3);
			BtnActualizar.Name = "BtnActualizar";
			BtnActualizar.Size = new Size(170, 32);
			BtnActualizar.TabIndex = 4;
			BtnActualizar.Text = "Actualizar Datos";
			BtnActualizar.UseVisualStyleBackColor = false;
			BtnActualizar.Visible = false;
			// 
			// DgvTipoEntornos
			// 
			DgvTipoEntornos.AllowUserToAddRows = false;
			DgvTipoEntornos.AllowUserToDeleteRows = false;
			DgvTipoEntornos.AllowUserToResizeColumns = false;
			DgvTipoEntornos.AllowUserToResizeRows = false;
			dataGridViewCellStyle1.BackColor = Color.FromArgb(240, 240, 245);
			DgvTipoEntornos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
			DgvTipoEntornos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			DgvTipoEntornos.BackgroundColor = Color.White;
			DgvTipoEntornos.BorderStyle = BorderStyle.Fixed3D;
			DgvTipoEntornos.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
			DgvTipoEntornos.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
			dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle2.BackColor = Color.FromArgb(7, 100, 147);
			dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
			dataGridViewCellStyle2.ForeColor = Color.White;
			dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
			dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
			dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
			DgvTipoEntornos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
			DgvTipoEntornos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			DgvTipoEntornos.Dock = DockStyle.Fill;
			DgvTipoEntornos.EnableHeadersVisualStyles = false;
			DgvTipoEntornos.GridColor = Color.FromArgb(220, 220, 225);
			DgvTipoEntornos.Location = new Point(3, 209);
			DgvTipoEntornos.Name = "DgvTipoEntornos";
			DgvTipoEntornos.ReadOnly = true;
			DgvTipoEntornos.RowHeadersVisible = false;
			DgvTipoEntornos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			DgvTipoEntornos.Size = new Size(382, 221);
			DgvTipoEntornos.TabIndex = 0;
			DgvTipoEntornos.SelectionChanged += DgvtipoEntornos_SelectionChanged;
			// 
			// GBFormEntornos
			// 
			GBFormEntornos.Anchor = AnchorStyles.Left | AnchorStyles.Right;
			GBFormEntornos.Controls.Add(tableLayoutPanel3);
			GBFormEntornos.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
			GBFormEntornos.Location = new Point(3, 41);
			GBFormEntornos.Name = "GBFormEntornos";
			GBFormEntornos.Size = new Size(382, 162);
			GBFormEntornos.TabIndex = 2;
			GBFormEntornos.TabStop = false;
			GBFormEntornos.Text = "Formulario de Areas";
			// 
			// tableLayoutPanel3
			// 
			tableLayoutPanel3.ColumnCount = 1;
			tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
			tableLayoutPanel3.Controls.Add(label1, 0, 0);
			tableLayoutPanel3.Controls.Add(TxtTipoEntorno, 0, 1);
			tableLayoutPanel3.Controls.Add(tableLayoutPanel4, 0, 2);
			tableLayoutPanel3.Dock = DockStyle.Fill;
			tableLayoutPanel3.Location = new Point(3, 23);
			tableLayoutPanel3.Name = "tableLayoutPanel3";
			tableLayoutPanel3.RowCount = 3;
			tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
			tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
			tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
			tableLayoutPanel3.Size = new Size(376, 136);
			tableLayoutPanel3.TabIndex = 0;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Dock = DockStyle.Fill;
			label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
			label1.Location = new Point(3, 0);
			label1.Name = "label1";
			label1.Size = new Size(370, 30);
			label1.TabIndex = 0;
			label1.Text = "Nombre del Area";
			label1.TextAlign = ContentAlignment.MiddleLeft;
			// 
			// TxtTipoEntorno
			// 
			TxtTipoEntorno.Dock = DockStyle.Fill;
			TxtTipoEntorno.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
			TxtTipoEntorno.Location = new Point(3, 33);
			TxtTipoEntorno.Name = "TxtTipoEntorno";
			TxtTipoEntorno.Size = new Size(370, 29);
			TxtTipoEntorno.TabIndex = 1;
			// 
			// tableLayoutPanel4
			// 
			tableLayoutPanel4.ColumnCount = 3;
			tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33333F));
			tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33333F));
			tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33333F));
			tableLayoutPanel4.Controls.Add(BtnNuevoTipoEntorno, 0, 0);
			tableLayoutPanel4.Controls.Add(BtnEliminarTipoEntorno, 1, 0);
			tableLayoutPanel4.Controls.Add(BtnGuardarTipoEntorno, 2, 0);
			tableLayoutPanel4.Dock = DockStyle.Fill;
			tableLayoutPanel4.Location = new Point(3, 63);
			tableLayoutPanel4.Name = "tableLayoutPanel4";
			tableLayoutPanel4.RowCount = 1;
			tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
			tableLayoutPanel4.Size = new Size(370, 70);
			tableLayoutPanel4.TabIndex = 2;
			// 
			// BtnNuevoTipoEntorno
			// 
			BtnNuevoTipoEntorno.Anchor = AnchorStyles.None;
			BtnNuevoTipoEntorno.BackColor = Color.FromArgb(7, 100, 147);
			BtnNuevoTipoEntorno.FlatStyle = FlatStyle.Flat;
			BtnNuevoTipoEntorno.ForeColor = Color.White;
			BtnNuevoTipoEntorno.Location = new Point(4, 19);
			BtnNuevoTipoEntorno.Name = "BtnNuevoTipoEntorno";
			BtnNuevoTipoEntorno.Size = new Size(115, 32);
			BtnNuevoTipoEntorno.TabIndex = 3;
			BtnNuevoTipoEntorno.Text = "Nuevo";
			BtnNuevoTipoEntorno.UseVisualStyleBackColor = false;
			BtnNuevoTipoEntorno.Click += BtnNuevoTipoEntorno_Click;
			// 
			// BtnEliminarTipoEntorno
			// 
			BtnEliminarTipoEntorno.Anchor = AnchorStyles.None;
			BtnEliminarTipoEntorno.BackColor = Color.FromArgb(186, 26, 26);
			BtnEliminarTipoEntorno.FlatStyle = FlatStyle.Flat;
			BtnEliminarTipoEntorno.ForeColor = Color.White;
			BtnEliminarTipoEntorno.Location = new Point(127, 19);
			BtnEliminarTipoEntorno.Name = "BtnEliminarTipoEntorno";
			BtnEliminarTipoEntorno.Size = new Size(115, 32);
			BtnEliminarTipoEntorno.TabIndex = 1;
			BtnEliminarTipoEntorno.Text = "Eliminar";
			BtnEliminarTipoEntorno.UseVisualStyleBackColor = false;
			BtnEliminarTipoEntorno.Click += BtnEliminarEntorno_Click;
			// 
			// BtnGuardarTipoEntorno
			// 
			BtnGuardarTipoEntorno.Anchor = AnchorStyles.None;
			BtnGuardarTipoEntorno.BackColor = Color.FromArgb(101, 89, 119);
			BtnGuardarTipoEntorno.FlatStyle = FlatStyle.Flat;
			BtnGuardarTipoEntorno.ForeColor = Color.White;
			BtnGuardarTipoEntorno.Location = new Point(250, 19);
			BtnGuardarTipoEntorno.Name = "BtnGuardarTipoEntorno";
			BtnGuardarTipoEntorno.Size = new Size(115, 32);
			BtnGuardarTipoEntorno.TabIndex = 2;
			BtnGuardarTipoEntorno.Text = "Guardar";
			BtnGuardarTipoEntorno.UseVisualStyleBackColor = false;
			BtnGuardarTipoEntorno.Click += BtnGuardarEntorno_Click;
			// 
			// PbProgreso
			// 
			PbProgreso.Dock = DockStyle.Top;
			PbProgreso.Location = new Point(0, 0);
			PbProgreso.Name = "PbProgreso";
			PbProgreso.Size = new Size(804, 10);
			PbProgreso.Style = ProgressBarStyle.Marquee;
			PbProgreso.TabIndex = 1;
			PbProgreso.Visible = false;
			// 
			// GBEntornos
			// 
			GBEntornos.Controls.Add(tableLayoutPanel5);
			GBEntornos.Dock = DockStyle.Fill;
			GBEntornos.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
			GBEntornos.Location = new Point(8, 8);
			GBEntornos.Name = "GBEntornos";
			GBEntornos.Size = new Size(374, 461);
			GBEntornos.TabIndex = 2;
			GBEntornos.TabStop = false;
			GBEntornos.Text = "Entornos";
			// 
			// tableLayoutPanel5
			// 
			tableLayoutPanel5.ColumnCount = 1;
			tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
			tableLayoutPanel5.Controls.Add(tableLayoutPanel6, 0, 0);
			tableLayoutPanel5.Controls.Add(DgvEntornos, 0, 2);
			tableLayoutPanel5.Controls.Add(GBFormSubEntornos, 0, 1);
			tableLayoutPanel5.Dock = DockStyle.Fill;
			tableLayoutPanel5.Location = new Point(3, 25);
			tableLayoutPanel5.Name = "tableLayoutPanel5";
			tableLayoutPanel5.RowCount = 3;
			tableLayoutPanel5.RowStyles.Add(new RowStyle());
			tableLayoutPanel5.RowStyles.Add(new RowStyle());
			tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
			tableLayoutPanel5.Size = new Size(368, 433);
			tableLayoutPanel5.TabIndex = 0;
			// 
			// tableLayoutPanel6
			// 
			tableLayoutPanel6.ColumnCount = 2;
			tableLayoutPanel6.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 29.2817688F));
			tableLayoutPanel6.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 70.71823F));
			tableLayoutPanel6.Controls.Add(label3, 0, 0);
			tableLayoutPanel6.Controls.Add(LblEntornoSeleccionado, 1, 0);
			tableLayoutPanel6.Location = new Point(3, 3);
			tableLayoutPanel6.Name = "tableLayoutPanel6";
			tableLayoutPanel6.RowCount = 1;
			tableLayoutPanel6.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
			tableLayoutPanel6.Size = new Size(362, 31);
			tableLayoutPanel6.TabIndex = 3;
			// 
			// label3
			// 
			label3.Anchor = AnchorStyles.Left;
			label3.AutoSize = true;
			label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
			label3.Location = new Point(3, 5);
			label3.Name = "label3";
			label3.Size = new Size(92, 21);
			label3.TabIndex = 2;
			label3.Text = "Area Actual:";
			label3.TextAlign = ContentAlignment.MiddleLeft;
			// 
			// LblEntornoSeleccionado
			// 
			LblEntornoSeleccionado.Anchor = AnchorStyles.Left;
			LblEntornoSeleccionado.AutoSize = true;
			LblEntornoSeleccionado.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
			LblEntornoSeleccionado.Location = new Point(109, 5);
			LblEntornoSeleccionado.Name = "LblEntornoSeleccionado";
			LblEntornoSeleccionado.Size = new Size(78, 21);
			LblEntornoSeleccionado.TabIndex = 1;
			LblEntornoSeleccionado.Text = "Ninguno";
			LblEntornoSeleccionado.TextAlign = ContentAlignment.MiddleLeft;
			// 
			// DgvEntornos
			// 
			DgvEntornos.AllowUserToAddRows = false;
			DgvEntornos.AllowUserToDeleteRows = false;
			dataGridViewCellStyle3.BackColor = Color.FromArgb(240, 240, 245);
			DgvEntornos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
			DgvEntornos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			DgvEntornos.BackgroundColor = Color.White;
			DgvEntornos.BorderStyle = BorderStyle.Fixed3D;
			DgvEntornos.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
			DgvEntornos.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
			dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle4.BackColor = Color.FromArgb(7, 100, 147);
			dataGridViewCellStyle4.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
			dataGridViewCellStyle4.ForeColor = Color.White;
			dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
			dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
			dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
			DgvEntornos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
			DgvEntornos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			DgvEntornos.Dock = DockStyle.Fill;
			DgvEntornos.EnableHeadersVisualStyles = false;
			DgvEntornos.GridColor = Color.FromArgb(220, 220, 225);
			DgvEntornos.Location = new Point(3, 209);
			DgvEntornos.Name = "DgvEntornos";
			DgvEntornos.ReadOnly = true;
			DgvEntornos.RowHeadersVisible = false;
			DgvEntornos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			DgvEntornos.Size = new Size(362, 221);
			DgvEntornos.TabIndex = 0;
			DgvEntornos.SelectionChanged += DgvEntornos_SelectionChanged;
			// 
			// GBFormSubEntornos
			// 
			GBFormSubEntornos.Anchor = AnchorStyles.Left | AnchorStyles.Right;
			GBFormSubEntornos.Controls.Add(tableLayoutPanel7);
			GBFormSubEntornos.Location = new Point(3, 40);
			GBFormSubEntornos.Name = "GBFormSubEntornos";
			GBFormSubEntornos.Size = new Size(362, 163);
			GBFormSubEntornos.TabIndex = 2;
			GBFormSubEntornos.TabStop = false;
			GBFormSubEntornos.Text = "Formulario de Entorno";
			// 
			// tableLayoutPanel7
			// 
			tableLayoutPanel7.ColumnCount = 1;
			tableLayoutPanel7.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
			tableLayoutPanel7.Controls.Add(label2, 0, 0);
			tableLayoutPanel7.Controls.Add(TxtEntorno, 0, 1);
			tableLayoutPanel7.Controls.Add(tableLayoutPanel8, 0, 2);
			tableLayoutPanel7.Dock = DockStyle.Fill;
			tableLayoutPanel7.Location = new Point(3, 25);
			tableLayoutPanel7.Name = "tableLayoutPanel7";
			tableLayoutPanel7.RowCount = 3;
			tableLayoutPanel7.RowStyles.Add(new RowStyle(SizeType.Percent, 21.4814816F));
			tableLayoutPanel7.RowStyles.Add(new RowStyle(SizeType.Percent, 26.666666F));
			tableLayoutPanel7.RowStyles.Add(new RowStyle(SizeType.Percent, 51.8518524F));
			tableLayoutPanel7.Size = new Size(356, 135);
			tableLayoutPanel7.TabIndex = 0;
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Dock = DockStyle.Fill;
			label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
			label2.Location = new Point(3, 0);
			label2.Name = "label2";
			label2.Size = new Size(350, 29);
			label2.TabIndex = 0;
			label2.Text = "Nombre del Entorno:";
			label2.TextAlign = ContentAlignment.MiddleLeft;
			// 
			// TxtEntorno
			// 
			TxtEntorno.Dock = DockStyle.Fill;
			TxtEntorno.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
			TxtEntorno.Location = new Point(3, 32);
			TxtEntorno.Name = "TxtEntorno";
			TxtEntorno.Size = new Size(350, 29);
			TxtEntorno.TabIndex = 1;
			// 
			// tableLayoutPanel8
			// 
			tableLayoutPanel8.Anchor = AnchorStyles.Left | AnchorStyles.Right;
			tableLayoutPanel8.ColumnCount = 3;
			tableLayoutPanel8.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33333F));
			tableLayoutPanel8.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33333F));
			tableLayoutPanel8.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33333F));
			tableLayoutPanel8.Controls.Add(BtnNuevoEntorno, 0, 0);
			tableLayoutPanel8.Controls.Add(BtnEliminarEntorno, 1, 0);
			tableLayoutPanel8.Controls.Add(BtnGuardarEntorno, 2, 0);
			tableLayoutPanel8.Location = new Point(3, 79);
			tableLayoutPanel8.Name = "tableLayoutPanel8";
			tableLayoutPanel8.RowCount = 1;
			tableLayoutPanel8.RowStyles.Add(new RowStyle());
			tableLayoutPanel8.Size = new Size(350, 42);
			tableLayoutPanel8.TabIndex = 2;
			// 
			// BtnNuevoEntorno
			// 
			BtnNuevoEntorno.Anchor = AnchorStyles.None;
			BtnNuevoEntorno.BackColor = Color.FromArgb(7, 100, 147);
			BtnNuevoEntorno.FlatStyle = FlatStyle.Flat;
			BtnNuevoEntorno.ForeColor = Color.White;
			BtnNuevoEntorno.Location = new Point(3, 5);
			BtnNuevoEntorno.Name = "BtnNuevoEntorno";
			BtnNuevoEntorno.Size = new Size(110, 32);
			BtnNuevoEntorno.TabIndex = 3;
			BtnNuevoEntorno.Text = "Nuevo";
			BtnNuevoEntorno.UseVisualStyleBackColor = false;
			BtnNuevoEntorno.Click += BtnNuevaSubEntorno_Click;
			// 
			// BtnEliminarEntorno
			// 
			BtnEliminarEntorno.Anchor = AnchorStyles.None;
			BtnEliminarEntorno.BackColor = Color.FromArgb(186, 26, 26);
			BtnEliminarEntorno.FlatStyle = FlatStyle.Flat;
			BtnEliminarEntorno.ForeColor = Color.White;
			BtnEliminarEntorno.Location = new Point(119, 5);
			BtnEliminarEntorno.Name = "BtnEliminarEntorno";
			BtnEliminarEntorno.Size = new Size(110, 32);
			BtnEliminarEntorno.TabIndex = 1;
			BtnEliminarEntorno.Text = "Eliminar";
			BtnEliminarEntorno.UseVisualStyleBackColor = false;
			BtnEliminarEntorno.Click += BtnEliminarSubEntorno_Click;
			// 
			// BtnGuardarEntorno
			// 
			BtnGuardarEntorno.Anchor = AnchorStyles.None;
			BtnGuardarEntorno.BackColor = Color.FromArgb(101, 89, 119);
			BtnGuardarEntorno.FlatStyle = FlatStyle.Flat;
			BtnGuardarEntorno.ForeColor = Color.White;
			BtnGuardarEntorno.Location = new Point(235, 5);
			BtnGuardarEntorno.Name = "BtnGuardarEntorno";
			BtnGuardarEntorno.Size = new Size(111, 32);
			BtnGuardarEntorno.TabIndex = 2;
			BtnGuardarEntorno.Text = "Guardar";
			BtnGuardarEntorno.UseVisualStyleBackColor = false;
			BtnGuardarEntorno.Click += BtnGuardarSubEntorno_Click;
			// 
			// splitContainer1
			// 
			splitContainer1.Dock = DockStyle.Fill;
			splitContainer1.Location = new Point(0, 0);
			splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			splitContainer1.Panel1.Controls.Add(GNTipoEntornos);
			splitContainer1.Panel1.Padding = new Padding(8);
			// 
			// splitContainer1.Panel2
			// 
			splitContainer1.Panel2.Controls.Add(GBEntornos);
			splitContainer1.Panel2.Padding = new Padding(8);
			splitContainer1.Size = new Size(804, 477);
			splitContainer1.SplitterDistance = 410;
			splitContainer1.TabIndex = 1;
			// 
			// UCGestionEntornos
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			Controls.Add(PbProgreso);
			Controls.Add(splitContainer1);
			Name = "UCGestionEntornos";
			Padding = new Padding(0, 0, 0, 16);
			Size = new Size(804, 493);
			Load += UCGestionEntornos_Load;
			VisibleChanged += UCGestionEntornos_VisibleChanged;
			GNTipoEntornos.ResumeLayout(false);
			tableLayoutPanel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)DgvTipoEntornos).EndInit();
			GBFormEntornos.ResumeLayout(false);
			tableLayoutPanel3.ResumeLayout(false);
			tableLayoutPanel3.PerformLayout();
			tableLayoutPanel4.ResumeLayout(false);
			GBEntornos.ResumeLayout(false);
			tableLayoutPanel5.ResumeLayout(false);
			tableLayoutPanel6.ResumeLayout(false);
			tableLayoutPanel6.PerformLayout();
			((System.ComponentModel.ISupportInitialize)DgvEntornos).EndInit();
			GBFormSubEntornos.ResumeLayout(false);
			tableLayoutPanel7.ResumeLayout(false);
			tableLayoutPanel7.PerformLayout();
			tableLayoutPanel8.ResumeLayout(false);
			splitContainer1.Panel1.ResumeLayout(false);
			splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
			splitContainer1.ResumeLayout(false);
			ResumeLayout(false);
		}

		#endregion

		private GroupBox GNTipoEntornos;
        private TableLayoutPanel tableLayoutPanel1;
        private DataGridView DgvTipoEntornos;
        private GroupBox GBFormEntornos;
        private TableLayoutPanel tableLayoutPanel3;
        private Label label1;
        private TextBox TxtTipoEntorno;
        private TableLayoutPanel tableLayoutPanel4;
        private Button BtnEliminarTipoEntorno;
        private Button BtnGuardarTipoEntorno;
        private ProgressBar PbProgreso;
        private GroupBox GBEntornos;
        private TableLayoutPanel tableLayoutPanel5;
        private DataGridView DgvEntornos;
        private GroupBox GBFormSubEntornos;
        private TableLayoutPanel tableLayoutPanel7;
        private Label label2;
        private TextBox TxtEntorno;
        private TableLayoutPanel tableLayoutPanel8;
        private Button BtnEliminarEntorno;
        private Button BtnGuardarEntorno;
        private SplitContainer splitContainer1;
        private Button BtnActualizar;
        private TableLayoutPanel tableLayoutPanel6;
        private Label label3;
        private Label LblEntornoSeleccionado;
        private Button BtnNuevoTipoEntorno;
        private Button BtnNuevoEntorno;
    }
}