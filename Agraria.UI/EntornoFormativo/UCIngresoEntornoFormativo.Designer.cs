namespace Agraria.UI.EntornoFormativo
{
    partial class UCIngresoEntornoFormativo
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
            PanelMedio = new Panel();
            TLPMedio = new TableLayoutPanel();
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
            label7 = new Label();
            ChkActivo = new CheckBox();
            BtnIngresar = new Button();
            ProgressBar = new ProgressBar();
            PanelMedio.SuspendLayout();
            TLPMedio.SuspendLayout();
            groupBox1.SuspendLayout();
            TLPForm.SuspendLayout();
            SuspendLayout();
            // 
            // PanelMedio
            // 
            PanelMedio.Controls.Add(TLPMedio);
            PanelMedio.Dock = DockStyle.Fill;
            PanelMedio.Location = new Point(0, 0);
            PanelMedio.Name = "PanelMedio";
            PanelMedio.Size = new Size(804, 561);
            PanelMedio.TabIndex = 4;
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
            groupBox1.Location = new Point(85, 54);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(633, 468);
            groupBox1.TabIndex = 15;
            groupBox1.TabStop = false;
            groupBox1.Text = "Formulario de Ingreso de Entorno Formativo";
            // 
            // TLPForm
            // 
            TLPForm.BackColor = Color.FromArgb(249, 249, 251);
            TLPForm.ColumnCount = 3;
            TLPForm.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 21.85008F));
            TLPForm.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 63.3173828F));
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
            TLPForm.Controls.Add(label7, 0, 7);
            TLPForm.Controls.Add(ChkActivo, 1, 7);
            TLPForm.Controls.Add(BtnIngresar, 1, 8);
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
            TLPForm.RowStyles.Add(new RowStyle(SizeType.Percent, 29.5871563F));
            TLPForm.RowStyles.Add(new RowStyle(SizeType.Percent, 6.19266033F));
            TLPForm.RowStyles.Add(new RowStyle(SizeType.Percent, 9.090909F));
            TLPForm.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            TLPForm.Size = new Size(627, 436);
            TLPForm.TabIndex = 0;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(11, 8);
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
            CMBTipoEntorno.Location = new Point(140, 4);
            CMBTipoEntorno.Name = "CMBTipoEntorno";
            CMBTipoEntorno.Size = new Size(391, 29);
            CMBTipoEntorno.TabIndex = 11;
            CMBTipoEntorno.SelectedIndexChanged += CMBCategoria_SelectedIndexChanged;
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Right;
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F);
            label5.Location = new Point(66, 46);
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
            CMBEntorno.Location = new Point(140, 42);
            CMBEntorno.Name = "CMBEntorno";
            CMBEntorno.Size = new Size(391, 29);
            CMBEntorno.TabIndex = 12;
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Right;
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F);
            label6.Location = new Point(33, 84);
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
            CMBUsuario.Location = new Point(140, 80);
            CMBUsuario.Name = "CMBUsuario";
            CMBUsuario.Size = new Size(391, 29);
            CMBUsuario.TabIndex = 13;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Right;
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F);
            label4.Location = new Point(50, 122);
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
            TxtCursoAnio.Location = new Point(140, 118);
            TxtCursoAnio.MaxLength = 14;
            TxtCursoAnio.Name = "TxtCursoAnio";
            TxtCursoAnio.Size = new Size(391, 29);
            TxtCursoAnio.TabIndex = 6;
            TxtCursoAnio.TextChanged += TxtDescripcion_TextChanged;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(22, 160);
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
            TxtCursoDivision.Location = new Point(140, 156);
            TxtCursoDivision.MaxLength = 12;
            TxtCursoDivision.Name = "TxtCursoDivision";
            TxtCursoDivision.Size = new Size(391, 29);
            TxtCursoDivision.TabIndex = 15;
            TxtCursoDivision.TextChanged += TxtDescripcion_TextChanged;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F);
            label3.Location = new Point(32, 198);
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
            TxtCursoGrupo.Location = new Point(140, 194);
            TxtCursoGrupo.MaxLength = 12;
            TxtCursoGrupo.Name = "TxtCursoGrupo";
            TxtCursoGrupo.Size = new Size(391, 29);
            TxtCursoGrupo.TabIndex = 16;
            TxtCursoGrupo.TextChanged += TxtDescripcion_TextChanged;
            // 
            // LblCuit
            // 
            LblCuit.Anchor = AnchorStyles.Right;
            LblCuit.AutoSize = true;
            LblCuit.Font = new Font("Segoe UI", 12F);
            LblCuit.Location = new Point(34, 279);
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
            TxtObservacion.Location = new Point(140, 231);
            TxtObservacion.MaxLength = 255;
            TxtObservacion.Multiline = true;
            TxtObservacion.Name = "TxtObservacion";
            TxtObservacion.Size = new Size(391, 117);
            TxtObservacion.TabIndex = 17;
            TxtObservacion.TextChanged += TxtDescripcion_TextChanged;
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.Right;
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 12F);
            label7.Location = new Point(78, 353);
            label7.Name = "label7";
            label7.Size = new Size(56, 21);
            label7.TabIndex = 18;
            label7.Text = "Activo:";
            // 
            // ChkActivo
            // 
            ChkActivo.Anchor = AnchorStyles.Left;
            ChkActivo.AutoSize = true;
            ChkActivo.Font = new Font("Segoe UI", 12F);
            ChkActivo.Location = new Point(140, 356);
            ChkActivo.Name = "ChkActivo";
            ChkActivo.Size = new Size(15, 14);
            ChkActivo.TabIndex = 18;
            ChkActivo.UseVisualStyleBackColor = true;
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
            BtnIngresar.Location = new Point(239, 382);
            BtnIngresar.Margin = new Padding(0);
            BtnIngresar.Name = "BtnIngresar";
            TLPForm.SetRowSpan(BtnIngresar, 2);
            BtnIngresar.Size = new Size(192, 47);
            BtnIngresar.TabIndex = 19;
            BtnIngresar.Text = "INGRESAR";
            BtnIngresar.TextImageRelation = TextImageRelation.TextBeforeImage;
            BtnIngresar.UseVisualStyleBackColor = false;
            BtnIngresar.Click += BtnIngresar_Click;
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
            // UCIngresoEntornoFormativo
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.FromArgb(249, 249, 251);
            Controls.Add(PanelMedio);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ForeColor = Color.FromArgb(26, 28, 30);
            Margin = new Padding(4);
            Name = "UCIngresoEntornoFormativo";
            Size = new Size(804, 561);
            Load += UCIngresoEntornoFormativo_Load;
            PanelMedio.ResumeLayout(false);
            TLPMedio.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            TLPForm.ResumeLayout(false);
            TLPForm.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel PanelMedio;
        private TableLayoutPanel TLPMedio;
        private GroupBox groupBox1;
        private TableLayoutPanel TLPForm;
        private Label label1;
        private Label label3;
        private Label LblCuit;
        private TextBox TxtCursoGrupo;
        private TextBox TxtCursoDivision;
        private TextBox TxtCursoAnio;
        private TextBox TxtObservacion;
        private Label label4;
        private Label label2;
        private Label label5;
        private ComboBox CMBUsuario;
        private Button BtnIngresar;
        private ComboBox CMBEntorno;
        private ComboBox CMBTipoEntorno;
        private Label label6;
        private ProgressBar ProgressBar;
        private Label label7;
        private CheckBox ChkActivo;
    }
}
