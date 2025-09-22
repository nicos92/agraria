namespace Agraria.UI.EntornoFormativo
{
    partial class UCConsultaEntornoFormativo
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
            DgvEntornosFormativos = new DataGridView();
            PanelMedio = new Panel();
            tableLayoutPanel4 = new TableLayoutPanel();
            groupBox1 = new GroupBox();
            TLPForm = new TableLayoutPanel();
            label1 = new Label();
            CMBTipoEntorno = new ComboBox();
            label5 = new Label();
            CMBEntorno = new ComboBox();
            label6 = new Label();
            CMBUsuario = new ComboBox();
            label4 = new Label();
            TxtCursoAnio = new TextBox();
            label2 = new Label();
            TxtCursoDivision = new TextBox();
            label3 = new Label();
            TxtCursoGrupo = new TextBox();
            LblCuit = new Label();
            TxtObservacion = new TextBox();
            flowLayoutPanel1 = new FlowLayoutPanel();
            BtnGuardar = new Button();
            label7 = new Label();
            ChkActivo = new CheckBox();
            ProgressBar = new ProgressBar();
            tableLayoutPanel3.SuspendLayout();
            PanelLista.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DgvEntornosFormativos).BeginInit();
            PanelMedio.SuspendLayout();
            tableLayoutPanel4.SuspendLayout();
            groupBox1.SuspendLayout();
            TLPForm.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
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
            PanelLista.Dock = DockStyle.Fill;
            PanelLista.Location = new Point(3, 19);
            PanelLista.Name = "PanelLista";
            PanelLista.Padding = new Padding(0, 16, 0, 16);
            PanelLista.Size = new Size(315, 539);
            PanelLista.TabIndex = 3;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(LblLista, 0, 0);
            tableLayoutPanel1.Controls.Add(DgvEntornosFormativos, 0, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 16);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 32F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(315, 507);
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
            LblLista.Text = "Lista de Entornos Formativos";
            LblLista.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // DgvEntornosFormativos
            // 
            DgvEntornosFormativos.AllowUserToAddRows = false;
            DgvEntornosFormativos.AllowUserToDeleteRows = false;
            DgvEntornosFormativos.AllowUserToResizeColumns = false;
            DgvEntornosFormativos.AllowUserToResizeRows = false;
            DgvEntornosFormativos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DgvEntornosFormativos.Dock = DockStyle.Fill;
            DgvEntornosFormativos.Location = new Point(3, 35);
            DgvEntornosFormativos.Name = "DgvEntornosFormativos";
            DgvEntornosFormativos.ReadOnly = true;
            DgvEntornosFormativos.RowHeadersVisible = false;
            DgvEntornosFormativos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DgvEntornosFormativos.Size = new Size(309, 469);
            DgvEntornosFormativos.TabIndex = 2;
            DgvEntornosFormativos.SelectionChanged += DgvEntornosFormativos_SelectionChanged;
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
            groupBox1.Text = "Gestión de Entorno Formativo";
            // 
            // TLPForm
            // 
            TLPForm.BackColor = Color.FromArgb(249, 249, 251);
            TLPForm.ColumnCount = 3;
            TLPForm.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 28.60215F));
            TLPForm.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 56.55914F));
            TLPForm.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.6765194F));
            TLPForm.Controls.Add(label1, 0, 0);
            TLPForm.Controls.Add(CMBTipoEntorno, 1, 0);
            TLPForm.Controls.Add(label5, 0, 1);
            TLPForm.Controls.Add(CMBEntorno, 1, 1);
            TLPForm.Controls.Add(label6, 0, 2);
            TLPForm.Controls.Add(CMBUsuario, 1, 2);
            TLPForm.Controls.Add(label4, 0, 3);
            TLPForm.Controls.Add(TxtCursoAnio, 1, 3);
            TLPForm.Controls.Add(label2, 0, 4);
            TLPForm.Controls.Add(TxtCursoDivision, 1, 4);
            TLPForm.Controls.Add(label3, 0, 5);
            TLPForm.Controls.Add(TxtCursoGrupo, 1, 5);
            TLPForm.Controls.Add(LblCuit, 0, 6);
            TLPForm.Controls.Add(TxtObservacion, 1, 6);
            TLPForm.Controls.Add(flowLayoutPanel1, 1, 8);
            TLPForm.Controls.Add(label7, 0, 7);
            TLPForm.Controls.Add(ChkActivo, 1, 7);
            TLPForm.Dock = DockStyle.Fill;
            TLPForm.ForeColor = Color.FromArgb(26, 28, 30);
            TLPForm.Location = new Point(3, 29);
            TLPForm.Name = "TLPForm";
            TLPForm.RowCount = 9;
            TLPForm.RowStyles.Add(new RowStyle(SizeType.Percent, 9.090909F));
            TLPForm.RowStyles.Add(new RowStyle(SizeType.Percent, 9.090909F));
            TLPForm.RowStyles.Add(new RowStyle(SizeType.Percent, 9.090909F));
            TLPForm.RowStyles.Add(new RowStyle(SizeType.Percent, 9.090909F));
            TLPForm.RowStyles.Add(new RowStyle(SizeType.Percent, 9.090909F));
            TLPForm.RowStyles.Add(new RowStyle(SizeType.Percent, 9.090909F));
            TLPForm.RowStyles.Add(new RowStyle(SizeType.Percent, 29.09091F));
            TLPForm.RowStyles.Add(new RowStyle(SizeType.Percent, 6.49350643F));
            TLPForm.RowStyles.Add(new RowStyle(SizeType.Percent, 9.090909F));
            TLPForm.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            TLPForm.Size = new Size(465, 385);
            TLPForm.TabIndex = 1;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(7, 6);
            label1.Name = "label1";
            label1.Size = new Size(123, 21);
            label1.TabIndex = 1;
            label1.Text = "Tipo de Entorno:";
            // 
            // CMBTipoEntorno
            // 
            CMBTipoEntorno.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            CMBTipoEntorno.DropDownStyle = ComboBoxStyle.DropDownList;
            CMBTipoEntorno.Font = new Font("Segoe UI", 12F);
            CMBTipoEntorno.FormattingEnabled = true;
            CMBTipoEntorno.Location = new Point(136, 3);
            CMBTipoEntorno.Name = "CMBTipoEntorno";
            CMBTipoEntorno.Size = new Size(257, 29);
            CMBTipoEntorno.TabIndex = 11;
            CMBTipoEntorno.SelectedIndexChanged += CMBTipoEntorno_SelectedIndexChanged;
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Right;
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F);
            label5.Location = new Point(62, 39);
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
            CMBEntorno.Location = new Point(136, 36);
            CMBEntorno.Name = "CMBEntorno";
            CMBEntorno.Size = new Size(257, 29);
            CMBEntorno.TabIndex = 12;
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Right;
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F);
            label6.Location = new Point(29, 72);
            label6.Name = "label6";
            label6.Size = new Size(101, 21);
            label6.TabIndex = 17;
            label6.Text = "Responsable:";
            // 
            // CMBUsuario
            // 
            CMBUsuario.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            CMBUsuario.DropDownStyle = ComboBoxStyle.DropDownList;
            CMBUsuario.Font = new Font("Segoe UI", 12F);
            CMBUsuario.FormattingEnabled = true;
            CMBUsuario.Location = new Point(136, 69);
            CMBUsuario.Name = "CMBUsuario";
            CMBUsuario.Size = new Size(257, 29);
            CMBUsuario.TabIndex = 13;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Right;
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F);
            label4.Location = new Point(46, 105);
            label4.Name = "label4";
            label4.Size = new Size(84, 21);
            label4.TabIndex = 4;
            label4.Text = "Curso año:";
            // 
            // TxtCursoAnio
            // 
            TxtCursoAnio.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            TxtCursoAnio.BackColor = Color.FromArgb(238, 237, 240);
            TxtCursoAnio.Font = new Font("Segoe UI", 12F);
            TxtCursoAnio.ForeColor = Color.FromArgb(26, 28, 30);
            TxtCursoAnio.Location = new Point(136, 102);
            TxtCursoAnio.MaxLength = 12;
            TxtCursoAnio.Name = "TxtCursoAnio";
            TxtCursoAnio.Size = new Size(257, 29);
            TxtCursoAnio.TabIndex = 14;
            TxtCursoAnio.TextChanged += TxtCursoAnio_TextChanged;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(18, 138);
            label2.Name = "label2";
            label2.Size = new Size(112, 21);
            label2.TabIndex = 2;
            label2.Text = "Curso división:";
            // 
            // TxtCursoDivision
            // 
            TxtCursoDivision.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            TxtCursoDivision.BackColor = Color.FromArgb(238, 237, 240);
            TxtCursoDivision.Font = new Font("Segoe UI", 12F);
            TxtCursoDivision.ForeColor = Color.FromArgb(26, 28, 30);
            TxtCursoDivision.Location = new Point(136, 135);
            TxtCursoDivision.MaxLength = 12;
            TxtCursoDivision.Name = "TxtCursoDivision";
            TxtCursoDivision.Size = new Size(257, 29);
            TxtCursoDivision.TabIndex = 15;
            TxtCursoDivision.TextChanged += TxtCursoAnio_TextChanged;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F);
            label3.Location = new Point(28, 171);
            label3.Name = "label3";
            label3.Size = new Size(102, 21);
            label3.TabIndex = 3;
            label3.Text = "Curso Grupo:";
            // 
            // TxtCursoGrupo
            // 
            TxtCursoGrupo.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            TxtCursoGrupo.BackColor = Color.FromArgb(238, 237, 240);
            TxtCursoGrupo.Font = new Font("Segoe UI", 12F);
            TxtCursoGrupo.ForeColor = Color.FromArgb(26, 28, 30);
            TxtCursoGrupo.Location = new Point(136, 168);
            TxtCursoGrupo.MaxLength = 12;
            TxtCursoGrupo.Name = "TxtCursoGrupo";
            TxtCursoGrupo.Size = new Size(257, 29);
            TxtCursoGrupo.TabIndex = 16;
            TxtCursoGrupo.TextChanged += TxtCursoAnio_TextChanged;
            // 
            // LblCuit
            // 
            LblCuit.Anchor = AnchorStyles.Right;
            LblCuit.AutoSize = true;
            LblCuit.Font = new Font("Segoe UI", 12F);
            LblCuit.Location = new Point(30, 241);
            LblCuit.Name = "LblCuit";
            LblCuit.Size = new Size(100, 21);
            LblCuit.TabIndex = 0;
            LblCuit.Text = "Observación:";
            // 
            // TxtObservacion
            // 
            TxtObservacion.BackColor = Color.FromArgb(238, 237, 240);
            TxtObservacion.Dock = DockStyle.Fill;
            TxtObservacion.Font = new Font("Segoe UI", 12F);
            TxtObservacion.ForeColor = Color.FromArgb(26, 28, 30);
            TxtObservacion.Location = new Point(136, 201);
            TxtObservacion.MaxLength = 255;
            TxtObservacion.Multiline = true;
            TxtObservacion.Name = "TxtObservacion";
            TxtObservacion.Size = new Size(257, 101);
            TxtObservacion.TabIndex = 17;
            TxtObservacion.TextChanged += TxtCursoAnio_TextChanged;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(BtnGuardar);
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.Location = new Point(136, 331);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            TLPForm.SetRowSpan(flowLayoutPanel1, 2);
            flowLayoutPanel1.Size = new Size(257, 51);
            flowLayoutPanel1.TabIndex = 18;
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
            BtnGuardar.Location = new Point(0, 0);
            BtnGuardar.Margin = new Padding(0);
            BtnGuardar.Name = "BtnGuardar";
            BtnGuardar.Size = new Size(192, 47);
            BtnGuardar.TabIndex = 19;
            BtnGuardar.Text = "GUARDAR";
            BtnGuardar.TextImageRelation = TextImageRelation.TextBeforeImage;
            BtnGuardar.UseVisualStyleBackColor = false;
            BtnGuardar.Click += BtnGuardar_Click;
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.Right;
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.Location = new Point(74, 306);
            label7.Name = "label7";
            label7.Size = new Size(56, 21);
            label7.TabIndex = 19;
            label7.Text = "Activo:";
            // 
            // ChkActivo
            // 
            ChkActivo.Location = new Point(136, 308);
            ChkActivo.Name = "ChkActivo";
            ChkActivo.Size = new Size(104, 17);
            ChkActivo.TabIndex = 18;
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
            // UCConsultaEntornoFormativo
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.FromArgb(249, 249, 251);
            Controls.Add(tableLayoutPanel3);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ForeColor = Color.FromArgb(26, 28, 30);
            Margin = new Padding(4);
            Name = "UCConsultaEntornoFormativo";
            Size = new Size(804, 561);
            Load += UCConsultaEntornoFormativo_Load;
            VisibleChanged += UCConsultaEntornoFormativo_VisibleChanged;
            tableLayoutPanel3.ResumeLayout(false);
            PanelLista.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)DgvEntornosFormativos).EndInit();
            PanelMedio.ResumeLayout(false);
            tableLayoutPanel4.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            TLPForm.ResumeLayout(false);
            TLPForm.PerformLayout();
            flowLayoutPanel1.ResumeLayout(false);
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
        private ProgressBar ProgressBar;
        private DataGridView DgvEntornosFormativos;
        private TableLayoutPanel TLPForm;
        private Label label1;
        private ComboBox CMBTipoEntorno;
        private Label label5;
        private ComboBox CMBEntorno;
        private Label label6;
        private ComboBox CMBUsuario;
        private Label label4;
        private TextBox TxtCursoAnio;
        private Label label2;
        private TextBox TxtCursoDivision;
        private Label label3;
        private TextBox TxtCursoGrupo;
        private Label LblCuit;
        private TextBox TxtObservacion;
        private FlowLayoutPanel flowLayoutPanel1;
        private Button BtnGuardar;
        private Label label7;
        private CheckBox ChkActivo;
    }
}