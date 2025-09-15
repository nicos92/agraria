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
            GNEntornos = new GroupBox();
            tableLayoutPanel1 = new TableLayoutPanel();
            BtnActualizar = new Button();
            DgvEntornos = new DataGridView();
            GBFormEntornos = new GroupBox();
            tableLayoutPanel3 = new TableLayoutPanel();
            label1 = new Label();
            TxtEntorno = new TextBox();
            tableLayoutPanel4 = new TableLayoutPanel();
            BtnNuevaCategoria = new Button();
            BtnEliminarCategoria = new Button();
            BtnGuardarCategoria = new Button();
            PbProgreso = new ProgressBar();
            GBSubEntornos = new GroupBox();
            tableLayoutPanel5 = new TableLayoutPanel();
            tableLayoutPanel6 = new TableLayoutPanel();
            label3 = new Label();
            LblEntornoSeleccionado = new Label();
            DgvSubEntornos = new DataGridView();
            GBFormSubEntornos = new GroupBox();
            tableLayoutPanel7 = new TableLayoutPanel();
            label2 = new Label();
            TxtSubEntorno = new TextBox();
            tableLayoutPanel8 = new TableLayoutPanel();
            BtnNuevaSubcategoria = new Button();
            BtnEliminarSubcategoria = new Button();
            BtnGuardarSubcategoria = new Button();
            splitContainer1 = new SplitContainer();
            GNEntornos.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DgvEntornos).BeginInit();
            GBFormEntornos.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            tableLayoutPanel4.SuspendLayout();
            GBSubEntornos.SuspendLayout();
            tableLayoutPanel5.SuspendLayout();
            tableLayoutPanel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DgvSubEntornos).BeginInit();
            GBFormSubEntornos.SuspendLayout();
            tableLayoutPanel7.SuspendLayout();
            tableLayoutPanel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            SuspendLayout();
            // 
            // GNEntornos
            // 
            GNEntornos.Controls.Add(tableLayoutPanel1);
            GNEntornos.Dock = DockStyle.Fill;
            GNEntornos.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            GNEntornos.Location = new Point(0, 0);
            GNEntornos.Name = "GNEntornos";
            GNEntornos.Size = new Size(410, 493);
            GNEntornos.TabIndex = 0;
            GNEntornos.TabStop = false;
            GNEntornos.Text = "Entornos";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(BtnActualizar, 0, 0);
            tableLayoutPanel1.Controls.Add(DgvEntornos, 0, 2);
            tableLayoutPanel1.Controls.Add(GBFormEntornos, 0, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(3, 25);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(404, 465);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // BtnActualizar
            // 
            BtnActualizar.Anchor = AnchorStyles.None;
            BtnActualizar.BackColor = Color.FromArgb(7, 100, 147);
            BtnActualizar.FlatStyle = FlatStyle.Flat;
            BtnActualizar.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BtnActualizar.ForeColor = Color.White;
            BtnActualizar.Location = new Point(117, 3);
            BtnActualizar.Name = "BtnActualizar";
            BtnActualizar.Size = new Size(170, 32);
            BtnActualizar.TabIndex = 4;
            BtnActualizar.Text = "Actualizar Datos";
            BtnActualizar.UseVisualStyleBackColor = false;
            // 
            // DgvEntornos
            // 
            DgvEntornos.AllowUserToAddRows = false;
            DgvEntornos.AllowUserToDeleteRows = false;
            DgvEntornos.AllowUserToResizeColumns = false;
            DgvEntornos.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(240, 240, 245);
            DgvEntornos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            DgvEntornos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DgvEntornos.BackgroundColor = Color.White;
            DgvEntornos.BorderStyle = BorderStyle.Fixed3D;
            DgvEntornos.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            DgvEntornos.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(7, 100, 147);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            DgvEntornos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            DgvEntornos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DgvEntornos.Dock = DockStyle.Fill;
            DgvEntornos.EnableHeadersVisualStyles = false;
            DgvEntornos.GridColor = Color.FromArgb(220, 220, 225);
            DgvEntornos.Location = new Point(3, 209);
            DgvEntornos.Name = "DgvEntornos";
            DgvEntornos.ReadOnly = true;
            DgvEntornos.RowHeadersVisible = false;
            DgvEntornos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DgvEntornos.Size = new Size(398, 253);
            DgvEntornos.TabIndex = 0;
            DgvEntornos.SelectionChanged += DgvEntornos_SelectionChanged;
            // 
            // GBFormEntornos
            // 
            GBFormEntornos.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            GBFormEntornos.Controls.Add(tableLayoutPanel3);
            GBFormEntornos.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            GBFormEntornos.Location = new Point(3, 41);
            GBFormEntornos.Name = "GBFormEntornos";
            GBFormEntornos.Size = new Size(398, 162);
            GBFormEntornos.TabIndex = 2;
            GBFormEntornos.TabStop = false;
            GBFormEntornos.Text = "Formulario de Entorno";
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.ColumnCount = 1;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel3.Controls.Add(label1, 0, 0);
            tableLayoutPanel3.Controls.Add(TxtEntorno, 0, 1);
            tableLayoutPanel3.Controls.Add(tableLayoutPanel4, 0, 2);
            tableLayoutPanel3.Dock = DockStyle.Fill;
            tableLayoutPanel3.Location = new Point(3, 23);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 3;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel3.Size = new Size(392, 136);
            tableLayoutPanel3.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Fill;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(386, 30);
            label1.TabIndex = 0;
            label1.Text = "Nombre del Entorno:";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // TxtEntorno
            // 
            TxtEntorno.Dock = DockStyle.Fill;
            TxtEntorno.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            TxtEntorno.Location = new Point(3, 33);
            TxtEntorno.Name = "TxtEntorno";
            TxtEntorno.Size = new Size(386, 29);
            TxtEntorno.TabIndex = 1;
            // 
            // tableLayoutPanel4
            // 
            tableLayoutPanel4.ColumnCount = 3;
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33333F));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33333F));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33333F));
            tableLayoutPanel4.Controls.Add(BtnNuevaCategoria, 0, 0);
            tableLayoutPanel4.Controls.Add(BtnEliminarCategoria, 1, 0);
            tableLayoutPanel4.Controls.Add(BtnGuardarCategoria, 2, 0);
            tableLayoutPanel4.Dock = DockStyle.Fill;
            tableLayoutPanel4.Location = new Point(3, 63);
            tableLayoutPanel4.Name = "tableLayoutPanel4";
            tableLayoutPanel4.RowCount = 1;
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel4.Size = new Size(386, 70);
            tableLayoutPanel4.TabIndex = 2;
            // 
            // BtnNuevaCategoria
            // 
            BtnNuevaCategoria.Anchor = AnchorStyles.None;
            BtnNuevaCategoria.BackColor = Color.FromArgb(0, 123, 255);
            BtnNuevaCategoria.FlatStyle = FlatStyle.Flat;
            BtnNuevaCategoria.ForeColor = Color.White;
            BtnNuevaCategoria.Location = new Point(6, 19);
            BtnNuevaCategoria.Name = "BtnNuevaCategoria";
            BtnNuevaCategoria.Size = new Size(115, 32);
            BtnNuevaCategoria.TabIndex = 3;
            BtnNuevaCategoria.Text = "Nueva";
            BtnNuevaCategoria.UseVisualStyleBackColor = false;
            BtnNuevaCategoria.Click += BtnNuevoEntorno_Click;
            // 
            // BtnEliminarCategoria
            // 
            BtnEliminarCategoria.Anchor = AnchorStyles.None;
            BtnEliminarCategoria.BackColor = Color.FromArgb(220, 53, 69);
            BtnEliminarCategoria.FlatStyle = FlatStyle.Flat;
            BtnEliminarCategoria.ForeColor = Color.White;
            BtnEliminarCategoria.Location = new Point(134, 19);
            BtnEliminarCategoria.Name = "BtnEliminarCategoria";
            BtnEliminarCategoria.Size = new Size(115, 32);
            BtnEliminarCategoria.TabIndex = 1;
            BtnEliminarCategoria.Text = "Eliminar";
            BtnEliminarCategoria.UseVisualStyleBackColor = false;
            BtnEliminarCategoria.Click += BtnEliminarEntorno_Click;
            // 
            // BtnGuardarCategoria
            // 
            BtnGuardarCategoria.Anchor = AnchorStyles.None;
            BtnGuardarCategoria.BackColor = Color.FromArgb(40, 167, 69);
            BtnGuardarCategoria.FlatStyle = FlatStyle.Flat;
            BtnGuardarCategoria.ForeColor = Color.White;
            BtnGuardarCategoria.Location = new Point(263, 19);
            BtnGuardarCategoria.Name = "BtnGuardarCategoria";
            BtnGuardarCategoria.Size = new Size(115, 32);
            BtnGuardarCategoria.TabIndex = 2;
            BtnGuardarCategoria.Text = "Guardar";
            BtnGuardarCategoria.UseVisualStyleBackColor = false;
            BtnGuardarCategoria.Click += BtnGuardarEntorno_Click;
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
            // GBSubEntornos
            // 
            GBSubEntornos.Controls.Add(tableLayoutPanel5);
            GBSubEntornos.Dock = DockStyle.Fill;
            GBSubEntornos.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            GBSubEntornos.Location = new Point(0, 0);
            GBSubEntornos.Name = "GBSubEntornos";
            GBSubEntornos.Size = new Size(390, 493);
            GBSubEntornos.TabIndex = 2;
            GBSubEntornos.TabStop = false;
            GBSubEntornos.Text = "SubEntornos";
            // 
            // tableLayoutPanel5
            // 
            tableLayoutPanel5.ColumnCount = 1;
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel5.Controls.Add(tableLayoutPanel6, 0, 0);
            tableLayoutPanel5.Controls.Add(DgvSubEntornos, 0, 2);
            tableLayoutPanel5.Controls.Add(GBFormSubEntornos, 0, 1);
            tableLayoutPanel5.Dock = DockStyle.Fill;
            tableLayoutPanel5.Location = new Point(3, 25);
            tableLayoutPanel5.Name = "tableLayoutPanel5";
            tableLayoutPanel5.RowCount = 3;
            tableLayoutPanel5.RowStyles.Add(new RowStyle());
            tableLayoutPanel5.RowStyles.Add(new RowStyle());
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel5.Size = new Size(384, 465);
            tableLayoutPanel5.TabIndex = 0;
            // 
            // tableLayoutPanel6
            // 
            tableLayoutPanel6.ColumnCount = 2;
            tableLayoutPanel6.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35.4497337F));
            tableLayoutPanel6.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 64.55026F));
            tableLayoutPanel6.Controls.Add(label3, 0, 0);
            tableLayoutPanel6.Controls.Add(LblEntornoSeleccionado, 1, 0);
            tableLayoutPanel6.Location = new Point(3, 3);
            tableLayoutPanel6.Name = "tableLayoutPanel6";
            tableLayoutPanel6.RowCount = 1;
            tableLayoutPanel6.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel6.Size = new Size(378, 31);
            tableLayoutPanel6.TabIndex = 3;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Left;
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(3, 5);
            label3.Name = "label3";
            label3.Size = new Size(115, 21);
            label3.TabIndex = 2;
            label3.Text = "Entorno Actual:";
            label3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // LblEntornoSeleccionado
            // 
            LblEntornoSeleccionado.Anchor = AnchorStyles.Left;
            LblEntornoSeleccionado.AutoSize = true;
            LblEntornoSeleccionado.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LblEntornoSeleccionado.Location = new Point(136, 5);
            LblEntornoSeleccionado.Name = "LblEntornoSeleccionado";
            LblEntornoSeleccionado.Size = new Size(77, 21);
            LblEntornoSeleccionado.TabIndex = 1;
            LblEntornoSeleccionado.Text = "Ninguna";
            LblEntornoSeleccionado.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // DgvSubEntornos
            // 
            DgvSubEntornos.AllowUserToAddRows = false;
            DgvSubEntornos.AllowUserToDeleteRows = false;
            dataGridViewCellStyle3.BackColor = Color.FromArgb(240, 240, 245);
            DgvSubEntornos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            DgvSubEntornos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DgvSubEntornos.BackgroundColor = Color.White;
            DgvSubEntornos.BorderStyle = BorderStyle.Fixed3D;
            DgvSubEntornos.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            DgvSubEntornos.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = Color.FromArgb(7, 100, 147);
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dataGridViewCellStyle4.ForeColor = Color.White;
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            DgvSubEntornos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            DgvSubEntornos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DgvSubEntornos.Dock = DockStyle.Fill;
            DgvSubEntornos.EnableHeadersVisualStyles = false;
            DgvSubEntornos.GridColor = Color.FromArgb(220, 220, 225);
            DgvSubEntornos.Location = new Point(3, 209);
            DgvSubEntornos.Name = "DgvSubEntornos";
            DgvSubEntornos.ReadOnly = true;
            DgvSubEntornos.RowHeadersVisible = false;
            DgvSubEntornos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DgvSubEntornos.Size = new Size(378, 253);
            DgvSubEntornos.TabIndex = 0;
            DgvSubEntornos.SelectionChanged += DgvSubEntornos_SelectionChanged;
            // 
            // GBFormSubEntornos
            // 
            GBFormSubEntornos.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            GBFormSubEntornos.Controls.Add(tableLayoutPanel7);
            GBFormSubEntornos.Location = new Point(3, 40);
            GBFormSubEntornos.Name = "GBFormSubEntornos";
            GBFormSubEntornos.Size = new Size(378, 163);
            GBFormSubEntornos.TabIndex = 2;
            GBFormSubEntornos.TabStop = false;
            GBFormSubEntornos.Text = "Formulario de SubEntorno";
            // 
            // tableLayoutPanel7
            // 
            tableLayoutPanel7.ColumnCount = 1;
            tableLayoutPanel7.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel7.Controls.Add(label2, 0, 0);
            tableLayoutPanel7.Controls.Add(TxtSubEntorno, 0, 1);
            tableLayoutPanel7.Controls.Add(tableLayoutPanel8, 0, 2);
            tableLayoutPanel7.Dock = DockStyle.Fill;
            tableLayoutPanel7.Location = new Point(3, 25);
            tableLayoutPanel7.Name = "tableLayoutPanel7";
            tableLayoutPanel7.RowCount = 3;
            tableLayoutPanel7.RowStyles.Add(new RowStyle(SizeType.Percent, 21.4814816F));
            tableLayoutPanel7.RowStyles.Add(new RowStyle(SizeType.Percent, 26.666666F));
            tableLayoutPanel7.RowStyles.Add(new RowStyle(SizeType.Percent, 51.8518524F));
            tableLayoutPanel7.Size = new Size(372, 135);
            tableLayoutPanel7.TabIndex = 0;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Dock = DockStyle.Fill;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(3, 0);
            label2.Name = "label2";
            label2.Size = new Size(366, 29);
            label2.TabIndex = 0;
            label2.Text = "Nombre del SubEntorno:";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // TxtSubEntorno
            // 
            TxtSubEntorno.Dock = DockStyle.Fill;
            TxtSubEntorno.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            TxtSubEntorno.Location = new Point(3, 32);
            TxtSubEntorno.Name = "TxtSubEntorno";
            TxtSubEntorno.Size = new Size(366, 29);
            TxtSubEntorno.TabIndex = 1;
            // 
            // tableLayoutPanel8
            // 
            tableLayoutPanel8.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel8.ColumnCount = 3;
            tableLayoutPanel8.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33333F));
            tableLayoutPanel8.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33333F));
            tableLayoutPanel8.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33333F));
            tableLayoutPanel8.Controls.Add(BtnNuevaSubcategoria, 0, 0);
            tableLayoutPanel8.Controls.Add(BtnEliminarSubcategoria, 1, 0);
            tableLayoutPanel8.Controls.Add(BtnGuardarSubcategoria, 2, 0);
            tableLayoutPanel8.Location = new Point(3, 79);
            tableLayoutPanel8.Name = "tableLayoutPanel8";
            tableLayoutPanel8.RowCount = 1;
            tableLayoutPanel8.RowStyles.Add(new RowStyle());
            tableLayoutPanel8.Size = new Size(366, 42);
            tableLayoutPanel8.TabIndex = 2;
            // 
            // BtnNuevaSubcategoria
            // 
            BtnNuevaSubcategoria.Anchor = AnchorStyles.None;
            BtnNuevaSubcategoria.BackColor = Color.FromArgb(0, 123, 255);
            BtnNuevaSubcategoria.FlatStyle = FlatStyle.Flat;
            BtnNuevaSubcategoria.ForeColor = Color.White;
            BtnNuevaSubcategoria.Location = new Point(5, 5);
            BtnNuevaSubcategoria.Name = "BtnNuevaSubcategoria";
            BtnNuevaSubcategoria.Size = new Size(111, 32);
            BtnNuevaSubcategoria.TabIndex = 3;
            BtnNuevaSubcategoria.Text = "Nuevo";
            BtnNuevaSubcategoria.UseVisualStyleBackColor = false;
            BtnNuevaSubcategoria.Click += BtnNuevaSubEntorno_Click;
            // 
            // BtnEliminarSubcategoria
            // 
            BtnEliminarSubcategoria.Anchor = AnchorStyles.None;
            BtnEliminarSubcategoria.BackColor = Color.FromArgb(220, 53, 69);
            BtnEliminarSubcategoria.FlatStyle = FlatStyle.Flat;
            BtnEliminarSubcategoria.ForeColor = Color.White;
            BtnEliminarSubcategoria.Location = new Point(127, 5);
            BtnEliminarSubcategoria.Name = "BtnEliminarSubcategoria";
            BtnEliminarSubcategoria.Size = new Size(111, 32);
            BtnEliminarSubcategoria.TabIndex = 1;
            BtnEliminarSubcategoria.Text = "Eliminar";
            BtnEliminarSubcategoria.UseVisualStyleBackColor = false;
            BtnEliminarSubcategoria.Click += BtnEliminarSubEntorno_Click;
            // 
            // BtnGuardarSubcategoria
            // 
            BtnGuardarSubcategoria.Anchor = AnchorStyles.None;
            BtnGuardarSubcategoria.BackColor = Color.FromArgb(40, 167, 69);
            BtnGuardarSubcategoria.FlatStyle = FlatStyle.Flat;
            BtnGuardarSubcategoria.ForeColor = Color.White;
            BtnGuardarSubcategoria.Location = new Point(249, 5);
            BtnGuardarSubcategoria.Name = "BtnGuardarSubcategoria";
            BtnGuardarSubcategoria.Size = new Size(111, 32);
            BtnGuardarSubcategoria.TabIndex = 2;
            BtnGuardarSubcategoria.Text = "Guardar";
            BtnGuardarSubcategoria.UseVisualStyleBackColor = false;
            BtnGuardarSubcategoria.Click += BtnGuardarSubEntorno_Click;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(GNEntornos);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(GBSubEntornos);
            splitContainer1.Size = new Size(804, 493);
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
            Size = new Size(804, 493);
            Load += UCGestionEntornos_Load;
            GNEntornos.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)DgvEntornos).EndInit();
            GBFormEntornos.ResumeLayout(false);
            tableLayoutPanel3.ResumeLayout(false);
            tableLayoutPanel3.PerformLayout();
            tableLayoutPanel4.ResumeLayout(false);
            GBSubEntornos.ResumeLayout(false);
            tableLayoutPanel5.ResumeLayout(false);
            tableLayoutPanel6.ResumeLayout(false);
            tableLayoutPanel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)DgvSubEntornos).EndInit();
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

        private GroupBox GNEntornos;
        private TableLayoutPanel tableLayoutPanel1;
        private DataGridView DgvEntornos;
        private GroupBox GBFormEntornos;
        private TableLayoutPanel tableLayoutPanel3;
        private Label label1;
        private TextBox TxtEntorno;
        private TableLayoutPanel tableLayoutPanel4;
        private Button BtnEliminarCategoria;
        private Button BtnGuardarCategoria;
        private ProgressBar PbProgreso;
        private GroupBox GBSubEntornos;
        private TableLayoutPanel tableLayoutPanel5;
        private DataGridView DgvSubEntornos;
        private GroupBox GBFormSubEntornos;
        private TableLayoutPanel tableLayoutPanel7;
        private Label label2;
        private TextBox TxtSubEntorno;
        private TableLayoutPanel tableLayoutPanel8;
        private Button BtnEliminarSubcategoria;
        private Button BtnGuardarSubcategoria;
        private SplitContainer splitContainer1;
        private Button BtnActualizar;
        private TableLayoutPanel tableLayoutPanel6;
        private Label label3;
        private Label LblEntornoSeleccionado;
        private Button BtnNuevaCategoria;
        private Button BtnNuevaSubcategoria;
    }
}