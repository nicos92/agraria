namespace Agraria.UI.HojadeVida
{
    partial class UCConsultaHojadeVida
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
            ListBHojasVida = new DataGridView();
            PanelMedio = new Panel();
            tableLayoutPanel4 = new TableLayoutPanel();
            groupBox1 = new GroupBox();
            TLPForm = new TableLayoutPanel();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            TxtNombre = new TextBox();
            CMBTipoAnimal = new ComboBox();
            CMBSexo = new ComboBox();
            DTPFechaNacimiento = new DateTimePicker();
            TxtPeso = new TextBox();
            TxtEstadoSalud = new TextBox();
            TxtObservaciones = new TextBox();
            ChkActivo = new CheckBox();
            tableLayoutPanel2 = new TableLayoutPanel();
            BtnGuardar = new Button();
            BtnEliminar = new Button();
            label9 = new Label();
            ProgressBar = new ProgressBar();
            PanelFiltros = new Panel();
            tableLayoutPanelFiltros = new TableLayoutPanel();
            labelFiltroNombre = new Label();
            TxtFiltroNombre = new TextBox();
            labelFiltroTipoAnimal = new Label();
            CmbFiltroTipoAnimal = new ComboBox();
            labelFiltroSexo = new Label();
            CmbFiltroSexo = new ComboBox();
            labelFiltroPeso = new Label();
            TxtFiltroPeso = new TextBox();
            BtnLimpiarFiltro = new Button();
            BtnAplicarFiltro = new Button();
            tableLayoutPanel3.SuspendLayout();
            PanelLista.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ListBHojasVida).BeginInit();
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
            tableLayoutPanelFiltros.Controls.Add(labelFiltroTipoAnimal, 0, 1);
            tableLayoutPanelFiltros.Controls.Add(CmbFiltroTipoAnimal, 1, 1);
            tableLayoutPanelFiltros.Controls.Add(labelFiltroSexo, 0, 2);
            tableLayoutPanelFiltros.Controls.Add(CmbFiltroSexo, 1, 2);
            tableLayoutPanelFiltros.Controls.Add(labelFiltroPeso, 0, 3);
            tableLayoutPanelFiltros.Controls.Add(TxtFiltroPeso, 1, 3);
            tableLayoutPanelFiltros.Controls.Add(BtnLimpiarFiltro, 0, 4);
            tableLayoutPanelFiltros.Controls.Add(BtnAplicarFiltro, 1, 4);
            tableLayoutPanelFiltros.Dock = DockStyle.Fill;
            tableLayoutPanelFiltros.Location = new Point(0, 8);
            tableLayoutPanelFiltros.Name = "tableLayoutPanelFiltros";
            tableLayoutPanelFiltros.RowCount = 5;
            tableLayoutPanelFiltros.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanelFiltros.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanelFiltros.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanelFiltros.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanelFiltros.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
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
            // labelFiltroTipoAnimal
            // 
            labelFiltroTipoAnimal.Anchor = AnchorStyles.Right;
            labelFiltroTipoAnimal.AutoSize = true;
            labelFiltroTipoAnimal.Font = new Font("Segoe UI", 12F);
            labelFiltroTipoAnimal.Location = new Point(31, 35);
            labelFiltroTipoAnimal.Name = "labelFiltroTipoAnimal";
            labelFiltroTipoAnimal.Size = new Size(64, 21);
            labelFiltroTipoAnimal.TabIndex = 2;
            labelFiltroTipoAnimal.Text = "Tipo An:";
            // 
            // CmbFiltroTipoAnimal
            // 
            CmbFiltroTipoAnimal.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            CmbFiltroTipoAnimal.DropDownStyle = ComboBoxStyle.DropDownList;
            CmbFiltroTipoAnimal.Font = new Font("Segoe UI", 12F);
            CmbFiltroTipoAnimal.FormattingEnabled = true;
            CmbFiltroTipoAnimal.Location = new Point(113, 32);
            CmbFiltroTipoAnimal.Name = "CmbFiltroTipoAnimal";
            CmbFiltroTipoAnimal.Size = new Size(199, 29);
            CmbFiltroTipoAnimal.TabIndex = 3;
            // 
            // labelFiltroSexo
            // 
            labelFiltroSexo.Anchor = AnchorStyles.Right;
            labelFiltroSexo.AutoSize = true;
            labelFiltroSexo.Font = new Font("Segoe UI", 12F);
            labelFiltroSexo.Location = new Point(77, 63);
            labelFiltroSexo.Name = "labelFiltroSexo";
            labelFiltroSexo.Size = new Size(20, 21);
            labelFiltroSexo.TabIndex = 4;
            labelFiltroSexo.Text = "Sexo:";
            // 
            // CmbFiltroSexo
            // 
            CmbFiltroSexo.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            CmbFiltroSexo.DropDownStyle = ComboBoxStyle.DropDownList;
            CmbFiltroSexo.Font = new Font("Segoe UI", 12F);
            CmbFiltroSexo.FormattingEnabled = true;
            CmbFiltroSexo.Location = new Point(113, 60);
            CmbFiltroSexo.Name = "CmbFiltroSexo";
            CmbFiltroSexo.Size = new Size(199, 29);
            CmbFiltroSexo.TabIndex = 5;
            // 
            // labelFiltroPeso
            // 
            labelFiltroPeso.Anchor = AnchorStyles.Right;
            labelFiltroPeso.AutoSize = true;
            labelFiltroPeso.Font = new Font("Segoe UI", 12F);
            labelFiltroPeso.Location = new Point(78, 91);
            labelFiltroPeso.Name = "labelFiltroPeso";
            labelFiltroPeso.Size = new Size(19, 21);
            labelFiltroPeso.TabIndex = 6;
            labelFiltroPeso.Text = "Peso:";
            // 
            // TxtFiltroPeso
            // 
            TxtFiltroPeso.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            TxtFiltroPeso.BackColor = Color.FromArgb(238, 237, 240);
            TxtFiltroPeso.Font = new Font("Segoe UI", 12F);
            TxtFiltroPeso.ForeColor = Color.FromArgb(26, 28, 30);
            TxtFiltroPeso.Location = new Point(113, 88);
            TxtFiltroPeso.Margin = new Padding(3, 4, 3, 4);
            TxtFiltroPeso.Name = "TxtFiltroPeso";
            TxtFiltroPeso.Size = new Size(199, 29);
            TxtFiltroPeso.TabIndex = 7;
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
            BtnLimpiarFiltro.TabIndex = 8;
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
            BtnAplicarFiltro.TabIndex = 9;
            BtnAplicarFiltro.Text = "Aplicar";
            BtnAplicarFiltro.UseVisualStyleBackColor = false;
            BtnAplicarFiltro.Click += BtnAplicarFiltro_Click;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(LblLista, 0, 0);
            tableLayoutPanel1.Controls.Add(ListBHojasVida, 0, 1);
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
            LblLista.Text = "Lista de Hojas de Vida";
            LblLista.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // ListBHojasVida
            // 
            ListBHojasVida.AllowUserToAddRows = false;
            ListBHojasVida.AllowUserToDeleteRows = false;
            ListBHojasVida.AllowUserToResizeColumns = false;
            ListBHojasVida.AllowUserToResizeRows = false;
            ListBHojasVida.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            ListBHojasVida.Dock = DockStyle.Fill;
            ListBHojasVida.Location = new Point(3, 35);
            ListBHojasVida.Name = "ListBHojasVida";
            ListBHojasVida.ReadOnly = true;
            ListBHojasVida.RowHeadersVisible = false;
            ListBHojasVida.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            ListBHojasVida.Size = new Size(309, 469);
            ListBHojasVida.TabIndex = 2;
            ListBHojasVida.DataError += ListBHojasVida_DataError;
            ListBHojasVida.SelectionChanged += ListBHojasVida_SelectedIndexChanged;
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
            groupBox1.Location = new Point(3, 44);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(471, 450);
            groupBox1.TabIndex = 16;
            groupBox1.TabStop = false;
            groupBox1.Text = "Formulario de Edición de Hoja de Vida";
            // 
            // TLPForm
            // 
            TLPForm.BackColor = Color.FromArgb(249, 249, 251);
            TLPForm.ColumnCount = 3;
            TLPForm.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 27.95699F));
            TLPForm.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 59.5698929F));
            TLPForm.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.4731178F));
            TLPForm.Controls.Add(label1, 0, 1);
            TLPForm.Controls.Add(label2, 0, 2);
            TLPForm.Controls.Add(label3, 0, 3);
            TLPForm.Controls.Add(label4, 0, 4);
            TLPForm.Controls.Add(label5, 0, 5);
            TLPForm.Controls.Add(label6, 0, 6);
            TLPForm.Controls.Add(label7, 0, 7);
            TLPForm.Controls.Add(TxtNombre, 1, 1);
            TLPForm.Controls.Add(CMBTipoAnimal, 1, 2);
            TLPForm.Controls.Add(CMBSexo, 1, 3);
            TLPForm.Controls.Add(DTPFechaNacimiento, 1, 4);
            TLPForm.Controls.Add(TxtPeso, 1, 5);
            TLPForm.Controls.Add(TxtEstadoSalud, 1, 6);
            TLPForm.Controls.Add(TxtObservaciones, 1, 7);
            TLPForm.Controls.Add(ChkActivo, 1, 8);
            TLPForm.Controls.Add(tableLayoutPanel2, 1, 9);
            TLPForm.Controls.Add(label9, 0, 8);
            TLPForm.Dock = DockStyle.Fill;
            TLPForm.ForeColor = Color.FromArgb(26, 28, 30);
            TLPForm.Location = new Point(3, 29);
            TLPForm.Name = "TLPForm";
            TLPForm.RowCount = 10;
            TLPForm.RowStyles.Add(new RowStyle(SizeType.Absolute, 8F));
            TLPForm.RowStyles.Add(new RowStyle());
            TLPForm.RowStyles.Add(new RowStyle());
            TLPForm.RowStyles.Add(new RowStyle());
            TLPForm.RowStyles.Add(new RowStyle());
            TLPForm.RowStyles.Add(new RowStyle());
            TLPForm.RowStyles.Add(new RowStyle());
            TLPForm.RowStyles.Add(new RowStyle(SizeType.Percent, 48.60335F));
            TLPForm.RowStyles.Add(new RowStyle());
            TLPForm.RowStyles.Add(new RowStyle(SizeType.Percent, 51.39665F));
            TLPForm.Size = new Size(465, 418);
            TLPForm.TabIndex = 0;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(56, 15);
            label1.Name = "label1";
            label1.Size = new Size(71, 21);
            label1.TabIndex = 0;
            label1.Text = "Nombre:";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(31, 50);
            label2.Name = "label2";
            label2.Size = new Size(96, 21);
            label2.TabIndex = 1;
            label2.Text = "Tipo Animal:";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F);
            label3.Location = new Point(77, 85);
            label3.Name = "label3";
            label3.Size = new Size(50, 21);
            label3.TabIndex = 2;
            label3.Text = "Sexo: ";
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Right;
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F);
            label4.Location = new Point(4, 120);
            label4.Name = "label4";
            label4.Size = new Size(123, 21);
            label4.TabIndex = 3;
            label4.Text = "Fecha de Nacim:";
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Right;
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F);
            label5.Location = new Point(78, 155);
            label5.Name = "label5";
            label5.Size = new Size(49, 21);
            label5.TabIndex = 4;
            label5.Text = "Peso: ";
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Right;
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F);
            label6.Location = new Point(25, 190);
            label6.Name = "label6";
            label6.Size = new Size(102, 21);
            label6.TabIndex = 5;
            label6.Text = "Estado Salud:";
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.Right;
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 12F);
            label7.Location = new Point(27, 250);
            label7.Name = "label7";
            label7.Size = new Size(100, 21);
            label7.TabIndex = 6;
            label7.Text = "Observación:";
            // 
            // TxtNombre
            // 
            TxtNombre.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            TxtNombre.BackColor = Color.FromArgb(238, 237, 240);
            TxtNombre.Font = new Font("Segoe UI", 12F);
            TxtNombre.ForeColor = Color.FromArgb(26, 28, 30);
            TxtNombre.Location = new Point(133, 11);
            TxtNombre.MaxLength = 255;
            TxtNombre.Name = "TxtNombre";
            TxtNombre.Size = new Size(271, 29);
            TxtNombre.TabIndex = 7;
            TxtNombre.TextChanged += TxtCodigo_TextChanged;
            // 
            // CMBTipoAnimal
            // 
            CMBTipoAnimal.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            CMBTipoAnimal.DropDownStyle = ComboBoxStyle.DropDownList;
            CMBTipoAnimal.Font = new Font("Segoe UI", 12F);
            CMBTipoAnimal.FormattingEnabled = true;
            CMBTipoAnimal.Location = new Point(133, 46);
            CMBTipoAnimal.Name = "CMBTipoAnimal";
            CMBTipoAnimal.Size = new Size(271, 29);
            CMBTipoAnimal.TabIndex = 8;
            // 
            // CMBSexo
            // 
            CMBSexo.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            CMBSexo.DropDownStyle = ComboBoxStyle.DropDownList;
            CMBSexo.Font = new Font("Segoe UI", 12F);
            CMBSexo.FormattingEnabled = true;
            CMBSexo.Location = new Point(133, 81);
            CMBSexo.Name = "CMBSexo";
            CMBSexo.Size = new Size(271, 29);
            CMBSexo.TabIndex = 9;
            // 
            // DTPFechaNacimiento
            // 
            DTPFechaNacimiento.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            DTPFechaNacimiento.Font = new Font("Segoe UI", 12F);
            DTPFechaNacimiento.Location = new Point(133, 116);
            DTPFechaNacimiento.Name = "DTPFechaNacimiento";
            DTPFechaNacimiento.Size = new Size(271, 29);
            DTPFechaNacimiento.TabIndex = 10;
            // 
            // TxtPeso
            // 
            TxtPeso.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            TxtPeso.BackColor = Color.FromArgb(238, 237, 240);
            TxtPeso.Font = new Font("Segoe UI", 12F);
            TxtPeso.ForeColor = Color.FromArgb(26, 28, 30);
            TxtPeso.Location = new Point(133, 151);
            TxtPeso.MaxLength = 10;
            TxtPeso.Name = "TxtPeso";
            TxtPeso.Size = new Size(271, 29);
            TxtPeso.TabIndex = 11;
            TxtPeso.TextChanged += TxtCodigo_TextChanged;
            // 
            // TxtEstadoSalud
            // 
            TxtEstadoSalud.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            TxtEstadoSalud.BackColor = Color.FromArgb(238, 237, 240);
            TxtEstadoSalud.Font = new Font("Segoe UI", 12F);
            TxtEstadoSalud.ForeColor = Color.FromArgb(26, 28, 30);
            TxtEstadoSalud.Location = new Point(133, 186);
            TxtEstadoSalud.MaxLength = 100;
            TxtEstadoSalud.Name = "TxtEstadoSalud";
            TxtEstadoSalud.Size = new Size(271, 29);
            TxtEstadoSalud.TabIndex = 12;
            TxtEstadoSalud.TextChanged += TxtCodigo_TextChanged;
            // 
            // TxtObservaciones
            // 
            TxtObservaciones.BackColor = Color.FromArgb(238, 237, 240);
            TxtObservaciones.Dock = DockStyle.Fill;
            TxtObservaciones.Font = new Font("Segoe UI", 12F);
            TxtObservaciones.ForeColor = Color.FromArgb(26, 28, 30);
            TxtObservaciones.Location = new Point(133, 221);
            TxtObservaciones.MaxLength = 200;
            TxtObservaciones.Multiline = true;
            TxtObservaciones.Name = "TxtObservaciones";
            TxtObservaciones.Size = new Size(271, 79);
            TxtObservaciones.TabIndex = 13;
            // 
            // ChkActivo
            // 
            ChkActivo.Anchor = AnchorStyles.Left;
            ChkActivo.AutoSize = true;
            ChkActivo.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ChkActivo.Location = new Point(133, 311);
            ChkActivo.Margin = new Padding(3, 8, 3, 3);
            ChkActivo.Name = "ChkActivo";
            ChkActivo.Size = new Size(15, 14);
            ChkActivo.TabIndex = 20;
            ChkActivo.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Controls.Add(BtnGuardar, 0, 0);
            tableLayoutPanel2.Controls.Add(BtnEliminar, 1, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(133, 331);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Size = new Size(271, 84);
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
            BtnGuardar.Location = new Point(0, 18);
            BtnGuardar.Margin = new Padding(0);
            BtnGuardar.Name = "BtnGuardar";
            BtnGuardar.Size = new Size(135, 48);
            BtnGuardar.TabIndex = 14;
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
            BtnEliminar.Location = new Point(179, 18);
            BtnEliminar.Margin = new Padding(0);
            BtnEliminar.Name = "BtnEliminar";
            BtnEliminar.Size = new Size(48, 48);
            BtnEliminar.TabIndex = 15;
            BtnEliminar.UseVisualStyleBackColor = false;
            BtnEliminar.Visible = false;
            BtnEliminar.EnabledChanged += BtnGuardar_EnabledChanged;
            BtnEliminar.Click += BtnEliminar_Click;
            // 
            // label9
            // 
            label9.Anchor = AnchorStyles.Right;
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 12F);
            label9.Location = new Point(71, 305);
            label9.Name = "label9";
            label9.Size = new Size(56, 21);
            label9.TabIndex = 21;
            label9.Text = "Activo:";
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
            // UCConsultaHojadeVida
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.FromArgb(249, 249, 251);
            Controls.Add(tableLayoutPanel3);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ForeColor = Color.FromArgb(26, 28, 30);
            Margin = new Padding(4);
            Name = "UCConsultaHojadeVida";
            Size = new Size(804, 561);
            Load += UCConsultaHojadeVida_Load;
            VisibleChanged += UCConsultaHojadeVida_VisibleChanged;
            tableLayoutPanel3.ResumeLayout(false);
            PanelLista.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)ListBHojasVida).EndInit();
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
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private TextBox TxtNombre;
        private ComboBox CMBTipoAnimal;
        private ComboBox CMBSexo;
        private DateTimePicker DTPFechaNacimiento;
        private TextBox TxtPeso;
        private TextBox TxtEstadoSalud;
        private TextBox TxtObservaciones;
        private CheckBox ChkActivo;
        private TableLayoutPanel tableLayoutPanel2;
        private Button BtnGuardar;
        private Button BtnEliminar;
        private ProgressBar ProgressBar;
        private DataGridView ListBHojasVida;
        private Label label9;
        private Panel PanelFiltros;
        private TableLayoutPanel tableLayoutPanelFiltros;
        private Label labelFiltroNombre;
        private TextBox TxtFiltroNombre;
        private Label labelFiltroTipoAnimal;
        private ComboBox CmbFiltroTipoAnimal;
        private Label labelFiltroSexo;
        private ComboBox CmbFiltroSexo;
        private Label labelFiltroPeso;
        private TextBox TxtFiltroPeso;
        private Button BtnLimpiarFiltro;
        private Button BtnAplicarFiltro;
    }
}