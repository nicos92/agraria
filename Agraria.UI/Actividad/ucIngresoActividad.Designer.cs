namespace Agraria.UI.Actividad
{
    partial class ucIngresoActividad
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            PanelMedio = new Panel();
            TLPMedio = new TableLayoutPanel();
            groupBox1 = new GroupBox();
            TLPForm = new TableLayoutPanel();
            label4 = new Label();
            label1 = new Label();
            CMBTipoEntorno = new ComboBox();
            label5 = new Label();
            CMBEntorno = new ComboBox();
            dateTimePicker1 = new DateTimePicker();
            LblCuit = new Label();
            TxtDescripcion = new TextBox();
            BtnIngresar = new Button();
            ListBArticulos = new DataGridView();
            Cantidad = new DataGridViewTextBoxColumn();
            Fecha_Hora = new DataGridViewTextBoxColumn();
            Entorno = new DataGridViewTextBoxColumn();
            Descripcion = new DataGridViewTextBoxColumn();
            ProgressBar = new ProgressBar();
            CMBEntornoFormativo = new ComboBox();
            label2 = new Label();
            PanelMedio.SuspendLayout();
            TLPMedio.SuspendLayout();
            groupBox1.SuspendLayout();
            TLPForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ListBArticulos).BeginInit();
            SuspendLayout();
            // 
            // PanelMedio
            // 
            PanelMedio.Controls.Add(TLPMedio);
            PanelMedio.Dock = DockStyle.Fill;
            PanelMedio.Location = new Point(0, 0);
            PanelMedio.Name = "PanelMedio";
            PanelMedio.Size = new Size(804, 561);
            PanelMedio.TabIndex = 5;
            // 
            // TLPMedio
            // 
            TLPMedio.BackColor = Color.FromArgb(218, 218, 220);
            TLPMedio.ColumnCount = 1;
            TLPMedio.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            TLPMedio.Controls.Add(groupBox1, 0, 1);
            TLPMedio.Controls.Add(ProgressBar, 0, 0);
            TLPMedio.Dock = DockStyle.Fill;
            TLPMedio.Location = new Point(0, 0);
            TLPMedio.Name = "TLPMedio";
            TLPMedio.RowCount = 2;
            TLPMedio.RowStyles.Add(new RowStyle(SizeType.Absolute, 16F));
            TLPMedio.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            TLPMedio.Size = new Size(804, 561);
            TLPMedio.TabIndex = 2;
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.None;
            groupBox1.Controls.Add(TLPForm);
            groupBox1.Font = new Font("Segoe UI Black", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox1.ForeColor = Color.FromArgb(7, 100, 147);
            groupBox1.Location = new Point(85, 34);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(633, 508);
            groupBox1.TabIndex = 15;
            groupBox1.TabStop = false;
            groupBox1.Text = "Formulario de Ingreso de Actividades";
            // 
            // TLPForm
            // 
            TLPForm.BackColor = Color.FromArgb(249, 249, 251);
            TLPForm.ColumnCount = 3;
            TLPForm.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20.12709F));
            TLPForm.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 65.1734543F));
            TLPForm.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.6994543F));
            TLPForm.Controls.Add(label1, 0, 0);
            TLPForm.Controls.Add(CMBTipoEntorno, 1, 0);
            TLPForm.Controls.Add(label5, 0, 1);
            TLPForm.Controls.Add(CMBEntorno, 1, 1);
            TLPForm.Controls.Add(dateTimePicker1, 1, 3);
            TLPForm.Controls.Add(TxtDescripcion, 1, 4);
            TLPForm.Controls.Add(ListBArticulos, 0, 6);
            TLPForm.Controls.Add(BtnIngresar, 1, 5);
            TLPForm.Controls.Add(LblCuit, 0, 4);
            TLPForm.Controls.Add(label4, 0, 3);
            TLPForm.Controls.Add(CMBEntornoFormativo, 1, 2);
            TLPForm.Controls.Add(label2, 0, 2);
            TLPForm.Dock = DockStyle.Fill;
            TLPForm.ForeColor = Color.FromArgb(26, 28, 30);
            TLPForm.Location = new Point(3, 29);
            TLPForm.Name = "TLPForm";
            TLPForm.RowCount = 7;
            TLPForm.RowStyles.Add(new RowStyle());
            TLPForm.RowStyles.Add(new RowStyle());
            TLPForm.RowStyles.Add(new RowStyle());
            TLPForm.RowStyles.Add(new RowStyle());
            TLPForm.RowStyles.Add(new RowStyle(SizeType.Percent, 43.45238F));
            TLPForm.RowStyles.Add(new RowStyle(SizeType.Percent, 19.6428566F));
            TLPForm.RowStyles.Add(new RowStyle(SizeType.Percent, 36.9047623F));
            TLPForm.Size = new Size(627, 476);
            TLPForm.TabIndex = 0;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Right;
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F);
            label4.Location = new Point(22, 112);
            label4.Name = "label4";
            label4.Size = new Size(101, 21);
            label4.TabIndex = 4;
            label4.Text = "Fecha y hora:";
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(21, 7);
            label1.Name = "label1";
            label1.Size = new Size(102, 21);
            label1.TabIndex = 1;
            label1.Text = "Tipo Entorno:";
            // 
            // CMBTipoEntorno
            // 
            CMBTipoEntorno.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            CMBTipoEntorno.DropDownStyle = ComboBoxStyle.DropDownList;
            CMBTipoEntorno.Font = new Font("Segoe UI", 12F);
            CMBTipoEntorno.FormattingEnabled = true;
            CMBTipoEntorno.Location = new Point(129, 3);
            CMBTipoEntorno.Name = "CMBTipoEntorno";
            CMBTipoEntorno.Size = new Size(402, 29);
            CMBTipoEntorno.TabIndex = 10;
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Right;
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F);
            label5.Location = new Point(55, 42);
            label5.Name = "label5";
            label5.Size = new Size(68, 21);
            label5.TabIndex = 12;
            label5.Text = "Entorno:";
            // 
            // CMBEntorno
            // 
            CMBEntorno.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            CMBEntorno.DropDownStyle = ComboBoxStyle.DropDownList;
            CMBEntorno.Font = new Font("Segoe UI", 12F);
            CMBEntorno.FormattingEnabled = true;
            CMBEntorno.Location = new Point(129, 38);
            CMBEntorno.Name = "CMBEntorno";
            CMBEntorno.Size = new Size(402, 29);
            CMBEntorno.TabIndex = 11;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            dateTimePicker1.Dock = DockStyle.Fill;
            dateTimePicker1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.Location = new Point(129, 108);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(402, 29);
            dateTimePicker1.TabIndex = 20;
            dateTimePicker1.ValueChanged += dateTimePicker1_ValueChanged;
            // 
            // LblCuit
            // 
            LblCuit.Anchor = AnchorStyles.Right;
            LblCuit.AutoSize = true;
            LblCuit.Font = new Font("Segoe UI", 12F);
            LblCuit.Location = new Point(29, 202);
            LblCuit.Name = "LblCuit";
            LblCuit.Size = new Size(94, 21);
            LblCuit.TabIndex = 0;
            LblCuit.Text = "Descripción:";
            // 
            // TxtDescripcion
            // 
            TxtDescripcion.BackColor = Color.FromArgb(238, 237, 240);
            TxtDescripcion.Dock = DockStyle.Fill;
            TxtDescripcion.Font = new Font("Segoe UI", 12F);
            TxtDescripcion.ForeColor = Color.FromArgb(26, 28, 30);
            TxtDescripcion.Location = new Point(129, 143);
            TxtDescripcion.MaxLength = 400;
            TxtDescripcion.Multiline = true;
            TxtDescripcion.Name = "TxtDescripcion";
            TxtDescripcion.Size = new Size(402, 140);
            TxtDescripcion.TabIndex = 5;
            // 
            // BtnIngresar
            // 
            BtnIngresar.Anchor = AnchorStyles.None;
            BtnIngresar.BackColor = Color.FromArgb(7, 100, 147);
            BtnIngresar.Enabled = false;
            BtnIngresar.FlatAppearance.BorderColor = Color.FromArgb(203, 230, 255);
            BtnIngresar.FlatStyle = FlatStyle.Flat;
            BtnIngresar.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BtnIngresar.ForeColor = Color.FromArgb(255, 255, 255);
            BtnIngresar.Image = Properties.Resources.ingresar;
            BtnIngresar.Location = new Point(234, 294);
            BtnIngresar.Margin = new Padding(0);
            BtnIngresar.Name = "BtnIngresar";
            BtnIngresar.Size = new Size(192, 49);
            BtnIngresar.TabIndex = 12;
            BtnIngresar.Text = "INGRESAR";
            BtnIngresar.TextImageRelation = TextImageRelation.TextBeforeImage;
            BtnIngresar.UseVisualStyleBackColor = false;
            // 
            // ListBArticulos
            // 
            ListBArticulos.AllowUserToAddRows = false;
            ListBArticulos.AllowUserToDeleteRows = false;
            ListBArticulos.AllowUserToResizeColumns = false;
            ListBArticulos.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            ListBArticulos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            ListBArticulos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            ListBArticulos.Columns.AddRange(new DataGridViewColumn[] { Cantidad, Fecha_Hora, Entorno, Descripcion });
            TLPForm.SetColumnSpan(ListBArticulos, 3);
            ListBArticulos.Dock = DockStyle.Fill;
            ListBArticulos.Location = new Point(4, 355);
            ListBArticulos.Margin = new Padding(4, 3, 4, 3);
            ListBArticulos.Name = "ListBArticulos";
            ListBArticulos.ReadOnly = true;
            ListBArticulos.RowHeadersVisible = false;
            ListBArticulos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            ListBArticulos.Size = new Size(619, 118);
            ListBArticulos.TabIndex = 21;
            // 
            // Cantidad
            // 
            Cantidad.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            Cantidad.DataPropertyName = "Cod_Articulo";
            Cantidad.HeaderText = "CÓDIGO";
            Cantidad.Name = "Cantidad";
            Cantidad.ReadOnly = true;
            Cantidad.Visible = false;
            // 
            // Fecha_Hora
            // 
            Fecha_Hora.HeaderText = "Fecha_Hora";
            Fecha_Hora.Name = "Fecha_Hora";
            Fecha_Hora.ReadOnly = true;
            // 
            // Entorno
            // 
            Entorno.HeaderText = "Entorno";
            Entorno.Name = "Entorno";
            Entorno.ReadOnly = true;
            // 
            // Descripcion
            // 
            Descripcion.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Descripcion.DataPropertyName = "Art_Desc";
            Descripcion.HeaderText = "DESCRIPCIÓN";
            Descripcion.Name = "Descripcion";
            Descripcion.ReadOnly = true;
            // 
            // ProgressBar
            // 
            ProgressBar.Dock = DockStyle.Fill;
            ProgressBar.Location = new Point(0, 0);
            ProgressBar.Margin = new Padding(0);
            ProgressBar.Name = "ProgressBar";
            ProgressBar.Size = new Size(804, 16);
            ProgressBar.TabIndex = 16;
            // 
            // CMBEntornoFormativo
            // 
            CMBEntornoFormativo.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            CMBEntornoFormativo.DropDownStyle = ComboBoxStyle.DropDownList;
            CMBEntornoFormativo.Font = new Font("Segoe UI", 12F);
            CMBEntornoFormativo.FormattingEnabled = true;
            CMBEntornoFormativo.Location = new Point(129, 73);
            CMBEntornoFormativo.Name = "CMBEntornoFormativo";
            CMBEntornoFormativo.Size = new Size(402, 29);
            CMBEntornoFormativo.TabIndex = 22;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(66, 77);
            label2.Name = "label2";
            label2.Size = new Size(57, 21);
            label2.TabIndex = 23;
            label2.Text = "Grupo:";
            // 
            // ucIngresoActividad
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(PanelMedio);
            Margin = new Padding(4, 3, 4, 3);
            Name = "ucIngresoActividad";
            Size = new Size(804, 561);
            PanelMedio.ResumeLayout(false);
            TLPMedio.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            TLPForm.ResumeLayout(false);
            TLPForm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)ListBArticulos).EndInit();
            ResumeLayout(false);
        }
        private Panel PanelMedio;
        private TableLayoutPanel TLPMedio;
        private GroupBox groupBox1;
        private TableLayoutPanel TLPForm;
        private Label label4;
        private Button BtnIngresar;
        private Label label1;
        private ComboBox CMBTipoEntorno;
        private TextBox TxtDescripcion;
        private Label LblCuit;
        private Label label5;
        private ComboBox CMBEntorno;
        private ProgressBar ProgressBar;
        private DateTimePicker dateTimePicker1;
        private DataGridView ListBArticulos;
        private DataGridViewTextBoxColumn Cantidad;
        private DataGridViewTextBoxColumn Fecha_Hora;
        private DataGridViewTextBoxColumn Entorno;
        private DataGridViewTextBoxColumn Descripcion;
        private ComboBox CMBEntornoFormativo;
        private Label label2;
    }
}
