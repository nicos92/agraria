using Agraria.Util;

namespace Agraria.UI.Usuarios
{
    partial class UCIngresoUsuarios
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
            tableLayoutPanel4 = new TableLayoutPanel();
            groupBox1 = new GroupBox();
            TLPForm = new TableLayoutPanel();
            TxtEmail = new TextBox();
            label1 = new Label();
            label3 = new Label();
            LblCuit = new Label();
            TxtTel = new TextBox();
            TxtApellido = new TextBox();
            TxtNombre = new TextBox();
            TxtDni = new TextBox();
            label4 = new Label();
            label2 = new Label();
            TxtContra = new TextBox();
            TxtContraDos = new TextBox();
            label6 = new Label();
            label7 = new Label();
            BtnIngresar = new Button();
            CMBTipoUsuario = new ComboBox();
            label5 = new Label();
            label8 = new Label();
            TxtRespues = new TextBox();
            CMBPregunta = new ComboBox();
            label9 = new Label();
            LblError = new Label();
            PanelMedio.SuspendLayout();
            tableLayoutPanel4.SuspendLayout();
            groupBox1.SuspendLayout();
            TLPForm.SuspendLayout();
            SuspendLayout();
            // 
            // PanelMedio
            // 
            PanelMedio.Controls.Add(tableLayoutPanel4);
            PanelMedio.Dock = DockStyle.Fill;
            PanelMedio.Location = new Point(0, 0);
            PanelMedio.Name = "PanelMedio";
            PanelMedio.Size = new Size(804, 561);
            PanelMedio.TabIndex = 3;
            // 
            // tableLayoutPanel4
            // 
            tableLayoutPanel4.BackColor = Color.FromArgb(218, 218, 220);
            tableLayoutPanel4.ColumnCount = 1;
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel4.Controls.Add(groupBox1, 0, 0);
            tableLayoutPanel4.Dock = DockStyle.Fill;
            tableLayoutPanel4.Location = new Point(0, 0);
            tableLayoutPanel4.Name = "tableLayoutPanel4";
            tableLayoutPanel4.RowCount = 1;
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel4.Size = new Size(804, 561);
            tableLayoutPanel4.TabIndex = 2;
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.None;
            groupBox1.Controls.Add(TLPForm);
            groupBox1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox1.ForeColor = Color.FromArgb(7, 100, 147);
            groupBox1.Location = new Point(85, 34);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(633, 492);
            groupBox1.TabIndex = 15;
            groupBox1.TabStop = false;
            groupBox1.Text = "Formulario de ingreso de Usuario";
            // 
            // TLPForm
            // 
            TLPForm.BackColor = Color.FromArgb(249, 249, 251);
            TLPForm.ColumnCount = 3;
            TLPForm.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            TLPForm.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60F));
            TLPForm.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            TLPForm.Controls.Add(TxtEmail, 1, 5);
            TLPForm.Controls.Add(label1, 0, 5);
            TLPForm.Controls.Add(label3, 0, 4);
            TLPForm.Controls.Add(LblCuit, 0, 1);
            TLPForm.Controls.Add(TxtTel, 1, 4);
            TLPForm.Controls.Add(TxtApellido, 1, 3);
            TLPForm.Controls.Add(TxtNombre, 1, 2);
            TLPForm.Controls.Add(TxtDni, 1, 1);
            TLPForm.Controls.Add(label4, 0, 2);
            TLPForm.Controls.Add(label2, 0, 3);
            TLPForm.Controls.Add(TxtContra, 1, 6);
            TLPForm.Controls.Add(TxtContraDos, 1, 7);
            TLPForm.Controls.Add(label6, 0, 6);
            TLPForm.Controls.Add(label7, 0, 7);
            TLPForm.Controls.Add(BtnIngresar, 1, 12);
            TLPForm.Controls.Add(CMBTipoUsuario, 1, 11);
            TLPForm.Controls.Add(label5, 0, 11);
            TLPForm.Controls.Add(label8, 0, 10);
            TLPForm.Controls.Add(TxtRespues, 1, 10);
            TLPForm.Controls.Add(CMBPregunta, 1, 9);
            TLPForm.Controls.Add(label9, 0, 9);
            TLPForm.Controls.Add(LblError, 1, 8);
            TLPForm.Dock = DockStyle.Fill;
            TLPForm.ForeColor = Color.FromArgb(26, 28, 30);
            TLPForm.Location = new Point(3, 29);
            TLPForm.Name = "TLPForm";
            TLPForm.RowCount = 13;
            TLPForm.RowStyles.Add(new RowStyle(SizeType.Absolute, 8F));
            TLPForm.RowStyles.Add(new RowStyle());
            TLPForm.RowStyles.Add(new RowStyle());
            TLPForm.RowStyles.Add(new RowStyle());
            TLPForm.RowStyles.Add(new RowStyle());
            TLPForm.RowStyles.Add(new RowStyle());
            TLPForm.RowStyles.Add(new RowStyle());
            TLPForm.RowStyles.Add(new RowStyle());
            TLPForm.RowStyles.Add(new RowStyle());
            TLPForm.RowStyles.Add(new RowStyle());
            TLPForm.RowStyles.Add(new RowStyle());
            TLPForm.RowStyles.Add(new RowStyle());
            TLPForm.RowStyles.Add(new RowStyle());
            TLPForm.Size = new Size(627, 460);
            TLPForm.TabIndex = 0;
            // 
            // TxtEmail
            // 
            TxtEmail.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            TxtEmail.BackColor = Color.FromArgb(238, 237, 240);
            TxtEmail.Font = new Font("Segoe UI", 12F);
            TxtEmail.ForeColor = Color.FromArgb(26, 28, 30);
            TxtEmail.Location = new Point(129, 160);
            TxtEmail.Margin = new Padding(4);
            TxtEmail.MaxLength = 255;
            TxtEmail.Name = "TxtEmail";
            TxtEmail.Size = new Size(368, 29);
            TxtEmail.TabIndex = 9;
            TxtEmail.TextChanged += TxtDni_TextChanged;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(71, 164);
            label1.Name = "label1";
            label1.Size = new Size(51, 21);
            label1.TabIndex = 1;
            label1.Text = "Email:";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F);
            label3.Location = new Point(88, 127);
            label3.Name = "label3";
            label3.Size = new Size(34, 21);
            label3.TabIndex = 3;
            label3.Text = "Tel.:";
            // 
            // LblCuit
            // 
            LblCuit.Anchor = AnchorStyles.Right;
            LblCuit.AutoSize = true;
            LblCuit.Font = new Font("Segoe UI", 12F);
            LblCuit.Location = new Point(82, 16);
            LblCuit.Name = "LblCuit";
            LblCuit.Size = new Size(40, 21);
            LblCuit.TabIndex = 0;
            LblCuit.Text = "DNI:";
            // 
            // TxtTel
            // 
            TxtTel.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            TxtTel.BackColor = Color.FromArgb(238, 237, 240);
            TxtTel.Font = new Font("Segoe UI", 12F);
            TxtTel.ForeColor = Color.FromArgb(26, 28, 30);
            TxtTel.Location = new Point(129, 123);
            TxtTel.Margin = new Padding(4);
            TxtTel.MaxLength = 11;
            TxtTel.Name = "TxtTel";
            TxtTel.Size = new Size(368, 29);
            TxtTel.TabIndex = 8;
            TxtTel.TextChanged += TxtDni_TextChanged;
            // 
            // TxtApellido
            // 
            TxtApellido.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            TxtApellido.BackColor = Color.FromArgb(238, 237, 240);
            TxtApellido.Font = new Font("Segoe UI", 12F);
            TxtApellido.ForeColor = Color.FromArgb(26, 28, 30);
            TxtApellido.Location = new Point(129, 86);
            TxtApellido.Margin = new Padding(4);
            TxtApellido.MaxLength = 50;
            TxtApellido.Name = "TxtApellido";
            TxtApellido.Size = new Size(368, 29);
            TxtApellido.TabIndex = 7;
            TxtApellido.TextChanged += TxtDni_TextChanged;
            // 
            // TxtNombre
            // 
            TxtNombre.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            TxtNombre.BackColor = Color.FromArgb(238, 237, 240);
            TxtNombre.Font = new Font("Segoe UI", 12F);
            TxtNombre.ForeColor = Color.FromArgb(26, 28, 30);
            TxtNombre.Location = new Point(129, 49);
            TxtNombre.Margin = new Padding(4);
            TxtNombre.MaxLength = 50;
            TxtNombre.Name = "TxtNombre";
            TxtNombre.Size = new Size(368, 29);
            TxtNombre.TabIndex = 6;
            TxtNombre.TextChanged += TxtDni_TextChanged;
            // 
            // TxtDni
            // 
            TxtDni.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            TxtDni.BackColor = Color.FromArgb(238, 237, 240);
            TxtDni.Font = new Font("Segoe UI", 12F);
            TxtDni.ForeColor = Color.FromArgb(26, 28, 30);
            TxtDni.Location = new Point(129, 12);
            TxtDni.Margin = new Padding(4);
            TxtDni.MaxLength = 8;
            TxtDni.Name = "TxtDni";
            TxtDni.Size = new Size(368, 29);
            TxtDni.TabIndex = 5;
            TxtDni.TextChanged += TxtDni_TextChanged;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Right;
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F);
            label4.Location = new Point(51, 53);
            label4.Name = "label4";
            label4.Size = new Size(71, 21);
            label4.TabIndex = 4;
            label4.Text = "Nombre:";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(52, 90);
            label2.Name = "label2";
            label2.Size = new Size(70, 21);
            label2.TabIndex = 2;
            label2.Text = "Apellido:";
            // 
            // TxtContra
            // 
            TxtContra.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            TxtContra.BackColor = Color.FromArgb(238, 237, 240);
            TxtContra.Font = new Font("Segoe UI", 12F);
            TxtContra.ForeColor = Color.FromArgb(26, 28, 30);
            TxtContra.Location = new Point(129, 197);
            TxtContra.Margin = new Padding(4);
            TxtContra.MaxLength = 255;
            TxtContra.Name = "TxtContra";
            TxtContra.PasswordChar = '*';
            TxtContra.Size = new Size(368, 29);
            TxtContra.TabIndex = 10;
            TxtContra.TextChanged += TxtDni_TextChanged;
            // 
            // TxtContraDos
            // 
            TxtContraDos.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            TxtContraDos.BackColor = Color.FromArgb(238, 237, 240);
            TxtContraDos.Font = new Font("Segoe UI", 12F);
            TxtContraDos.ForeColor = Color.FromArgb(26, 28, 30);
            TxtContraDos.Location = new Point(128, 236);
            TxtContraDos.MaxLength = 255;
            TxtContraDos.Name = "TxtContraDos";
            TxtContraDos.PasswordChar = '*';
            TxtContraDos.Size = new Size(370, 29);
            TxtContraDos.TabIndex = 11;
            TxtContraDos.TextChanged += TxtDni_TextChanged;
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Right;
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F);
            label6.Location = new Point(30, 201);
            label6.Name = "label6";
            label6.Size = new Size(92, 21);
            label6.TabIndex = 18;
            label6.Text = "Contraseña:";
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.Right;
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 12F);
            label7.Location = new Point(33, 230);
            label7.Name = "label7";
            label7.Size = new Size(89, 42);
            label7.TabIndex = 19;
            label7.Text = "Repita la\r\nContraseña";
            // 
            // BtnIngresar
            // 
            BtnIngresar.Anchor = AnchorStyles.None;
            BtnIngresar.BackColor = Color.FromArgb(83, 96, 108);
            BtnIngresar.Enabled = false;
            BtnIngresar.FlatAppearance.BorderColor = Color.FromArgb(203, 230, 255);
            BtnIngresar.FlatStyle = FlatStyle.Flat;
            BtnIngresar.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BtnIngresar.ForeColor = Color.FromArgb(255, 255, 255);
            BtnIngresar.Image = Properties.Resources.ingresar;
            BtnIngresar.Location = new Point(217, 413);
            BtnIngresar.Margin = new Padding(4);
            BtnIngresar.Name = "BtnIngresar";
            BtnIngresar.Size = new Size(192, 42);
            BtnIngresar.TabIndex = 15;
            BtnIngresar.Text = "INGRESAR";
            BtnIngresar.TextImageRelation = TextImageRelation.TextBeforeImage;
            BtnIngresar.UseVisualStyleBackColor = false;
            BtnIngresar.EnabledChanged += BtnIngresar_EnabledChanged;
            BtnIngresar.Click += BtnIngresar_Click;
            // 
            // CMBTipoUsuario
            // 
            CMBTipoUsuario.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            CMBTipoUsuario.DropDownStyle = ComboBoxStyle.DropDownList;
            CMBTipoUsuario.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            CMBTipoUsuario.FormattingEnabled = true;
            CMBTipoUsuario.Location = new Point(129, 375);
            CMBTipoUsuario.Margin = new Padding(4);
            CMBTipoUsuario.Name = "CMBTipoUsuario";
            CMBTipoUsuario.Size = new Size(368, 29);
            CMBTipoUsuario.TabIndex = 14;
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Right;
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F);
            label5.Location = new Point(79, 379);
            label5.Name = "label5";
            label5.Size = new Size(43, 21);
            label5.TabIndex = 12;
            label5.Text = "Tipo:";
            // 
            // label8
            // 
            label8.Anchor = AnchorStyles.Right;
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 12F);
            label8.Location = new Point(38, 342);
            label8.Name = "label8";
            label8.Size = new Size(84, 21);
            label8.TabIndex = 20;
            label8.Text = "Respuesta:";
            // 
            // TxtRespues
            // 
            TxtRespues.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            TxtRespues.BackColor = Color.FromArgb(238, 237, 240);
            TxtRespues.Font = new Font("Segoe UI", 12F);
            TxtRespues.ForeColor = Color.FromArgb(26, 28, 30);
            TxtRespues.Location = new Point(129, 338);
            TxtRespues.Margin = new Padding(4);
            TxtRespues.MaxLength = 255;
            TxtRespues.Name = "TxtRespues";
            TxtRespues.Size = new Size(368, 29);
            TxtRespues.TabIndex = 13;
            TxtRespues.TextChanged += TxtDni_TextChanged;
            // 
            // CMBPregunta
            // 
            CMBPregunta.DropDownStyle = ComboBoxStyle.DropDownList;
            CMBPregunta.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            CMBPregunta.FormattingEnabled = true;
            CMBPregunta.Location = new Point(129, 301);
            CMBPregunta.Margin = new Padding(4);
            CMBPregunta.Name = "CMBPregunta";
            CMBPregunta.Size = new Size(368, 29);
            CMBPregunta.TabIndex = 12;
            // 
            // label9
            // 
            label9.Anchor = AnchorStyles.Right;
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 12F);
            label9.Location = new Point(46, 305);
            label9.Name = "label9";
            label9.Size = new Size(76, 21);
            label9.TabIndex = 22;
            label9.Text = "Pregunta:";
            // 
            // LblError
            // 
            LblError.AutoSize = true;
            LblError.BackColor = Color.FromArgb(255, 218, 214);
            LblError.Dock = DockStyle.Top;
            LblError.Font = new Font("Segoe UI", 12F);
            LblError.ForeColor = Color.FromArgb(186, 26, 26);
            LblError.Location = new Point(128, 272);
            LblError.Margin = new Padding(3, 0, 3, 4);
            LblError.Name = "LblError";
            LblError.Size = new Size(370, 21);
            LblError.TabIndex = 24;
            LblError.Text = "Las Contraseñas no coinciden";
            LblError.Visible = false;
            // 
            // UCIngresoUsuarios
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.FromArgb(249, 249, 251);
            Controls.Add(PanelMedio);
            Font = new Font("Segoe UI", 12F);
            ForeColor = Color.FromArgb(26, 28, 30);
            Name = "UCIngresoUsuarios";
            Size = new Size(804, 561);
            Load += UCIngresoUsuarios_Load;
            PanelMedio.ResumeLayout(false);
            tableLayoutPanel4.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            TLPForm.ResumeLayout(false);
            TLPForm.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel PanelMedio;
        private TableLayoutPanel tableLayoutPanel4;
        private TableLayoutPanel TLPForm;
        private TextBox TxtEmail;
        private Label label1;
        private Label label3;
        private Label LblCuit;
        private TextBox TxtTel;
        private TextBox TxtApellido;
        private TextBox TxtNombre;
        private TextBox TxtDni;
        private Label label4;
        private Label label2;
        private Label label5;
        private ComboBox CMBTipoUsuario;
        private Button BtnIngresar;
        private GroupBox groupBox1;
        private TextBox TxtContra;
        private TextBox TxtContraDos;
        private Label label6;
        private Label label7;
        private Label label8;
        private TextBox TxtRespues;
        private Label label9;
        private ComboBox CMBPregunta;
        private Label LblError;
    }
}
