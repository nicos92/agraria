namespace Agraria.UI.Actividad
{
    partial class ucConsultaActividad
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            label1 = new Label();
            tableLayoutPanel3 = new TableLayoutPanel();
            PanelLista = new Panel();
            tableLayoutPanel1 = new TableLayoutPanel();
            LblLista = new Label();
            ListBArticulos = new DataGridView();
            PanelMedio = new Panel();
            tableLayoutPanel4 = new TableLayoutPanel();
            groupBox1 = new GroupBox();
            TLPForm = new TableLayoutPanel();
            dateTimePicker1 = new DateTimePicker();
            TxtDescripcion = new TextBox();
            BtnGuardar = new Button();
            LblCuit = new Label();
            label4 = new Label();
            label3 = new Label();
            label5 = new Label();
            label2 = new Label();
            CMBEntornoFormativo = new ComboBox();
            CMBEntorno = new ComboBox();
            CMBTipoEntorno = new ComboBox();
            ProgressBar = new ProgressBar();
            tableLayoutPanel3.SuspendLayout();
            PanelLista.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ListBArticulos).BeginInit();
            PanelMedio.SuspendLayout();
            tableLayoutPanel4.SuspendLayout();
            groupBox1.SuspendLayout();
            TLPForm.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(33, 42);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(107, 15);
            label1.TabIndex = 0;
            label1.Text = "Consulta Actividad";
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
            tableLayoutPanel3.Margin = new Padding(4, 3, 4, 3);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 2;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 18F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel3.Size = new Size(804, 561);
            tableLayoutPanel3.TabIndex = 4;
            // 
            // PanelLista
            // 
            PanelLista.BackColor = Color.FromArgb(218, 218, 220);
            PanelLista.Controls.Add(tableLayoutPanel1);
            PanelLista.Dock = DockStyle.Fill;
            PanelLista.Location = new Point(4, 21);
            PanelLista.Margin = new Padding(4, 3, 4, 3);
            PanelLista.Name = "PanelLista";
            PanelLista.Padding = new Padding(0, 18, 0, 18);
            PanelLista.Size = new Size(313, 537);
            PanelLista.TabIndex = 3;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(LblLista, 0, 0);
            tableLayoutPanel1.Controls.Add(ListBArticulos, 0, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 18);
            tableLayoutPanel1.Margin = new Padding(4, 3, 4, 3);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 37F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(313, 501);
            tableLayoutPanel1.TabIndex = 2;
            // 
            // LblLista
            // 
            LblLista.Dock = DockStyle.Top;
            LblLista.Font = new Font("Segoe UI Black", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LblLista.ForeColor = Color.FromArgb(7, 100, 147);
            LblLista.Location = new Point(4, 0);
            LblLista.Margin = new Padding(4, 0, 4, 0);
            LblLista.Name = "LblLista";
            LblLista.Size = new Size(305, 24);
            LblLista.TabIndex = 1;
            LblLista.Text = "Lista de Actividades";
            LblLista.TextAlign = ContentAlignment.MiddleCenter;
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
            ListBArticulos.Dock = DockStyle.Fill;
            ListBArticulos.Location = new Point(4, 40);
            ListBArticulos.Margin = new Padding(4, 3, 4, 3);
            ListBArticulos.Name = "ListBArticulos";
            ListBArticulos.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Control;
            dataGridViewCellStyle2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            ListBArticulos.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            ListBArticulos.RowHeadersVisible = false;
            ListBArticulos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            ListBArticulos.Size = new Size(305, 458);
            ListBArticulos.TabIndex = 2;
            ListBArticulos.SelectionChanged += ListBArticulos_SelectionChanged;
            // 
            // PanelMedio
            // 
            PanelMedio.Controls.Add(tableLayoutPanel4);
            PanelMedio.Dock = DockStyle.Fill;
            PanelMedio.Location = new Point(325, 21);
            PanelMedio.Margin = new Padding(4, 3, 4, 3);
            PanelMedio.Name = "PanelMedio";
            PanelMedio.Size = new Size(475, 537);
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
            tableLayoutPanel4.Margin = new Padding(4, 3, 4, 3);
            tableLayoutPanel4.Name = "tableLayoutPanel4";
            tableLayoutPanel4.RowCount = 1;
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Absolute, 622F));
            tableLayoutPanel4.Size = new Size(475, 537);
            tableLayoutPanel4.TabIndex = 2;
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            groupBox1.Controls.Add(TLPForm);
            groupBox1.Font = new Font("Segoe UI Black", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox1.ForeColor = Color.FromArgb(7, 100, 147);
            groupBox1.Location = new Point(4, 28);
            groupBox1.Margin = new Padding(4, 3, 4, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(4, 3, 4, 3);
            groupBox1.Size = new Size(467, 481);
            groupBox1.TabIndex = 16;
            groupBox1.TabStop = false;
            groupBox1.Text = "Formulario de Edición de Actividades";
            // 
            // TLPForm
            // 
            TLPForm.BackColor = Color.FromArgb(249, 249, 251);
            TLPForm.ColumnCount = 3;
            TLPForm.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 24.1830063F));
            TLPForm.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 61.00218F));
            TLPForm.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.6994543F));
            TLPForm.Controls.Add(dateTimePicker1, 1, 4);
            TLPForm.Controls.Add(TxtDescripcion, 1, 5);
            TLPForm.Controls.Add(BtnGuardar, 1, 6);
            TLPForm.Controls.Add(LblCuit, 0, 5);
            TLPForm.Controls.Add(label4, 0, 4);
            TLPForm.Controls.Add(label3, 0, 3);
            TLPForm.Controls.Add(label5, 0, 2);
            TLPForm.Controls.Add(label2, 0, 1);
            TLPForm.Controls.Add(CMBEntornoFormativo, 1, 3);
            TLPForm.Controls.Add(CMBEntorno, 1, 2);
            TLPForm.Controls.Add(CMBTipoEntorno, 1, 1);
            TLPForm.Dock = DockStyle.Fill;
            TLPForm.ForeColor = Color.FromArgb(26, 28, 30);
            TLPForm.Location = new Point(4, 29);
            TLPForm.Name = "TLPForm";
            TLPForm.RowCount = 8;
            TLPForm.RowStyles.Add(new RowStyle(SizeType.Absolute, 21F));
            TLPForm.RowStyles.Add(new RowStyle());
            TLPForm.RowStyles.Add(new RowStyle());
            TLPForm.RowStyles.Add(new RowStyle());
            TLPForm.RowStyles.Add(new RowStyle());
            TLPForm.RowStyles.Add(new RowStyle());
            TLPForm.RowStyles.Add(new RowStyle());
            TLPForm.RowStyles.Add(new RowStyle(SizeType.Absolute, 61F));
            TLPForm.Size = new Size(459, 449);
            TLPForm.TabIndex = 1;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            dateTimePicker1.Dock = DockStyle.Fill;
            dateTimePicker1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.Location = new Point(114, 129);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(274, 29);
            dateTimePicker1.TabIndex = 20;
            // 
            // TxtDescripcion
            // 
            TxtDescripcion.BackColor = Color.FromArgb(238, 237, 240);
            TxtDescripcion.Dock = DockStyle.Fill;
            TxtDescripcion.Font = new Font("Segoe UI", 12F);
            TxtDescripcion.ForeColor = Color.FromArgb(26, 28, 30);
            TxtDescripcion.Location = new Point(114, 164);
            TxtDescripcion.MaxLength = 255;
            TxtDescripcion.Multiline = true;
            TxtDescripcion.Name = "TxtDescripcion";
            TxtDescripcion.Size = new Size(274, 188);
            TxtDescripcion.TabIndex = 5;
            // 
            // BtnGuardar
            // 
            BtnGuardar.Anchor = AnchorStyles.None;
            BtnGuardar.BackColor = Color.FromArgb(7, 100, 147);
            BtnGuardar.Enabled = false;
            BtnGuardar.FlatAppearance.BorderColor = Color.FromArgb(203, 230, 255);
            BtnGuardar.FlatStyle = FlatStyle.Flat;
            BtnGuardar.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BtnGuardar.ForeColor = Color.FromArgb(255, 255, 255);
            BtnGuardar.Image = Properties.Resources.ingresar;
            BtnGuardar.Location = new Point(155, 363);
            BtnGuardar.Margin = new Padding(0, 8, 0, 0);
            BtnGuardar.Name = "BtnGuardar";
            BtnGuardar.Size = new Size(192, 49);
            BtnGuardar.TabIndex = 12;
            BtnGuardar.Text = "GUARDAR";
            BtnGuardar.TextImageRelation = TextImageRelation.TextBeforeImage;
            BtnGuardar.UseVisualStyleBackColor = false;
            BtnGuardar.Click += BtnGuardar_Click;
            // 
            // LblCuit
            // 
            LblCuit.Anchor = AnchorStyles.Right;
            LblCuit.AutoSize = true;
            LblCuit.Font = new Font("Segoe UI", 12F);
            LblCuit.Location = new Point(14, 247);
            LblCuit.Name = "LblCuit";
            LblCuit.Size = new Size(94, 21);
            LblCuit.TabIndex = 0;
            LblCuit.Text = "Descripción:";
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Right;
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F);
            label4.Location = new Point(7, 133);
            label4.Name = "label4";
            label4.Size = new Size(101, 21);
            label4.TabIndex = 4;
            label4.Text = "Fecha y hora:";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F);
            label3.Location = new Point(51, 98);
            label3.Name = "label3";
            label3.Size = new Size(57, 21);
            label3.TabIndex = 23;
            label3.Text = "Grupo:";
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Right;
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F);
            label5.Location = new Point(40, 63);
            label5.Name = "label5";
            label5.Size = new Size(68, 21);
            label5.TabIndex = 12;
            label5.Text = "Entorno:";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(6, 28);
            label2.Name = "label2";
            label2.Size = new Size(102, 21);
            label2.TabIndex = 1;
            label2.Text = "Tipo Entorno:";
            // 
            // CMBEntornoFormativo
            // 
            CMBEntornoFormativo.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            CMBEntornoFormativo.DropDownStyle = ComboBoxStyle.DropDownList;
            CMBEntornoFormativo.Font = new Font("Segoe UI", 12F);
            CMBEntornoFormativo.FormattingEnabled = true;
            CMBEntornoFormativo.Location = new Point(114, 94);
            CMBEntornoFormativo.Name = "CMBEntornoFormativo";
            CMBEntornoFormativo.Size = new Size(274, 29);
            CMBEntornoFormativo.TabIndex = 22;
            // 
            // CMBEntorno
            // 
            CMBEntorno.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            CMBEntorno.DropDownStyle = ComboBoxStyle.DropDownList;
            CMBEntorno.Font = new Font("Segoe UI", 12F);
            CMBEntorno.FormattingEnabled = true;
            CMBEntorno.Location = new Point(114, 59);
            CMBEntorno.Name = "CMBEntorno";
            CMBEntorno.Size = new Size(274, 29);
            CMBEntorno.TabIndex = 11;
            CMBEntorno.SelectedIndexChanged += CMBEntorno_SelectedIndexChanged;
            // 
            // CMBTipoEntorno
            // 
            CMBTipoEntorno.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            CMBTipoEntorno.DropDownStyle = ComboBoxStyle.DropDownList;
            CMBTipoEntorno.Font = new Font("Segoe UI", 12F);
            CMBTipoEntorno.FormattingEnabled = true;
            CMBTipoEntorno.Location = new Point(114, 24);
            CMBTipoEntorno.Name = "CMBTipoEntorno";
            CMBTipoEntorno.Size = new Size(274, 29);
            CMBTipoEntorno.TabIndex = 10;
            CMBTipoEntorno.SelectedIndexChanged += CMBTipoEntorno_SelectedIndexChanged;
            // 
            // ProgressBar
            // 
            tableLayoutPanel3.SetColumnSpan(ProgressBar, 2);
            ProgressBar.Dock = DockStyle.Fill;
            ProgressBar.Location = new Point(0, 0);
            ProgressBar.Margin = new Padding(0);
            ProgressBar.Name = "ProgressBar";
            ProgressBar.Size = new Size(804, 18);
            ProgressBar.TabIndex = 4;
            // 
            // ucConsultaActividad
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutPanel3);
            Controls.Add(label1);
            Margin = new Padding(4, 3, 4, 3);
            Name = "ucConsultaActividad";
            Size = new Size(804, 561);
            Load += ucConsultaActividad_Load;
            tableLayoutPanel3.ResumeLayout(false);
            PanelLista.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)ListBArticulos).EndInit();
            PanelMedio.ResumeLayout(false);
            tableLayoutPanel4.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            TLPForm.ResumeLayout(false);
            TLPForm.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.Label label1;
        private TableLayoutPanel tableLayoutPanel3;
        private Panel PanelLista;
        private TableLayoutPanel tableLayoutPanel1;
        private Label LblLista;
        private DataGridView ListBArticulos;
        private Panel PanelMedio;
        private TableLayoutPanel tableLayoutPanel4;
        private GroupBox groupBox1;
        private ProgressBar ProgressBar;

        #endregion
        private TableLayoutPanel TLPForm;
        private DateTimePicker dateTimePicker1;
        private TextBox TxtDescripcion;
        private Button BtnGuardar;
        private Label LblCuit;
        private Label label4;
        private Label label3;
        private Label label5;
        private Label label2;
        private ComboBox CMBEntornoFormativo;
        private ComboBox CMBEntorno;
        private ComboBox CMBTipoEntorno;
    }
}
