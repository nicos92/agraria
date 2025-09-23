using Agraria.Util;

namespace Agraria.UI.Usuarios
{
    partial class USConsultaUsuario
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
            CMBTipoUsuario = new ComboBox();
            label5 = new Label();
            label8 = new Label();
            TxtRespues = new TextBox();
            CMBPregunta = new ComboBox();
            label9 = new Label();
            LblError = new Label();
            tableLayoutPanel2 = new TableLayoutPanel();
            BtnGuardar = new Button();
            ChkActivo = new CheckBox();
            PanelLista = new Panel();
            tableLayoutPanel1 = new TableLayoutPanel();
            LblLista = new Label();
            ListBUsuarios = new DataGridView();
            DNI = new DataGridViewTextBoxColumn();
            ColumnApellido = new DataGridViewTextBoxColumn();
            ColumnNombre = new DataGridViewTextBoxColumn();
            tableLayoutPanel3 = new TableLayoutPanel();
            PanelMedio.SuspendLayout();
            tableLayoutPanel4.SuspendLayout();
            groupBox1.SuspendLayout();
            TLPForm.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            PanelLista.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ListBUsuarios).BeginInit();
            tableLayoutPanel3.SuspendLayout();
            SuspendLayout();
            // 
            // PanelMedio
            // 
            PanelMedio.Controls.Add(tableLayoutPanel4);
            PanelMedio.Dock = DockStyle.Fill;
            PanelMedio.Location = new Point(324, 3);
            PanelMedio.Name = "PanelMedio";
            PanelMedio.Size = new Size(477, 555);
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
            tableLayoutPanel4.Size = new Size(477, 555);
            tableLayoutPanel4.TabIndex = 2;
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.None;
            groupBox1.Controls.Add(TLPForm);
            groupBox1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox1.ForeColor = Color.FromArgb(7, 100, 147);
            groupBox1.Location = new Point(3, 14);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(471, 526);
            groupBox1.TabIndex = 16;
            groupBox1.TabStop = false;
            groupBox1.Text = "Formulario de ingreso de Usuario";
            // 
            // TLPForm
            // 
            TLPForm.BackColor = Color.FromArgb(249, 249, 251);
            TLPForm.ColumnCount = 3;
            TLPForm.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25.5913982F));
            TLPForm.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 61.5053749F));
            TLPForm.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.6881723F));
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
            TLPForm.Controls.Add(CMBTipoUsuario, 1, 11);
            TLPForm.Controls.Add(label5, 0, 11);
            TLPForm.Controls.Add(label8, 0, 10);
            TLPForm.Controls.Add(TxtRespues, 1, 10);
            TLPForm.Controls.Add(CMBPregunta, 1, 9);
            TLPForm.Controls.Add(label9, 0, 9);
            TLPForm.Controls.Add(LblError, 1, 8);
            TLPForm.Controls.Add(tableLayoutPanel2, 1, 13);
            TLPForm.Controls.Add(ChkActivo, 1, 12);
            TLPForm.Dock = DockStyle.Fill;
            TLPForm.ForeColor = Color.FromArgb(26, 28, 30);
            TLPForm.Location = new Point(3, 29);
            TLPForm.Name = "TLPForm";
            TLPForm.RowCount = 15;
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
            TLPForm.RowStyles.Add(new RowStyle(SizeType.Absolute, 47F));
            TLPForm.RowStyles.Add(new RowStyle(SizeType.Absolute, 8F));
            TLPForm.Size = new Size(465, 494);
            TLPForm.TabIndex = 0;
            // 
            // TxtEmail
            // 
            TxtEmail.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            TxtEmail.BackColor = Color.FromArgb(238, 237, 240);
            TxtEmail.Font = new Font("Segoe UI", 12F);
            TxtEmail.ForeColor = Color.FromArgb(26, 28, 30);
            TxtEmail.Location = new Point(123, 160);
            TxtEmail.Margin = new Padding(4);
            TxtEmail.MaxLength = 255;
            TxtEmail.Name = "TxtEmail";
            TxtEmail.Size = new Size(278, 29);
            TxtEmail.TabIndex = 9;
            TxtEmail.TextChanged += TxtDni_TextChanged;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(65, 164);
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
            label3.Location = new Point(82, 127);
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
            LblCuit.Location = new Point(76, 16);
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
            TxtTel.Location = new Point(123, 123);
            TxtTel.Margin = new Padding(4);
            TxtTel.MaxLength = 11;
            TxtTel.Name = "TxtTel";
            TxtTel.Size = new Size(278, 29);
            TxtTel.TabIndex = 8;
            TxtTel.TextChanged += TxtDni_TextChanged;
            // 
            // TxtApellido
            // 
            TxtApellido.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            TxtApellido.BackColor = Color.FromArgb(238, 237, 240);
            TxtApellido.Font = new Font("Segoe UI", 12F);
            TxtApellido.ForeColor = Color.FromArgb(26, 28, 30);
            TxtApellido.Location = new Point(123, 86);
            TxtApellido.Margin = new Padding(4);
            TxtApellido.MaxLength = 50;
            TxtApellido.Name = "TxtApellido";
            TxtApellido.Size = new Size(278, 29);
            TxtApellido.TabIndex = 7;
            TxtApellido.TextChanged += TxtDni_TextChanged;
            // 
            // TxtNombre
            // 
            TxtNombre.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            TxtNombre.BackColor = Color.FromArgb(238, 237, 240);
            TxtNombre.Font = new Font("Segoe UI", 12F);
            TxtNombre.ForeColor = Color.FromArgb(26, 28, 30);
            TxtNombre.Location = new Point(123, 49);
            TxtNombre.Margin = new Padding(4);
            TxtNombre.MaxLength = 50;
            TxtNombre.Name = "TxtNombre";
            TxtNombre.Size = new Size(278, 29);
            TxtNombre.TabIndex = 6;
            TxtNombre.TextChanged += TxtDni_TextChanged;
            // 
            // TxtDni
            // 
            TxtDni.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            TxtDni.BackColor = Color.FromArgb(238, 237, 240);
            TxtDni.Font = new Font("Segoe UI", 12F);
            TxtDni.ForeColor = Color.FromArgb(26, 28, 30);
            TxtDni.Location = new Point(123, 12);
            TxtDni.Margin = new Padding(4);
            TxtDni.MaxLength = 8;
            TxtDni.Name = "TxtDni";
            TxtDni.Size = new Size(278, 29);
            TxtDni.TabIndex = 5;
            TxtDni.TextChanged += TxtDni_TextChanged;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Right;
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F);
            label4.Location = new Point(45, 53);
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
            label2.Location = new Point(46, 90);
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
            TxtContra.Location = new Point(123, 197);
            TxtContra.Margin = new Padding(4);
            TxtContra.MaxLength = 255;
            TxtContra.Name = "TxtContra";
            TxtContra.PasswordChar = '*';
            TxtContra.Size = new Size(278, 29);
            TxtContra.TabIndex = 10;
            TxtContra.TextChanged += TxtDni_TextChanged;
            // 
            // TxtContraDos
            // 
            TxtContraDos.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            TxtContraDos.BackColor = Color.FromArgb(238, 237, 240);
            TxtContraDos.Font = new Font("Segoe UI", 12F);
            TxtContraDos.ForeColor = Color.FromArgb(26, 28, 30);
            TxtContraDos.Location = new Point(122, 236);
            TxtContraDos.MaxLength = 255;
            TxtContraDos.Name = "TxtContraDos";
            TxtContraDos.PasswordChar = '*';
            TxtContraDos.Size = new Size(280, 29);
            TxtContraDos.TabIndex = 11;
            TxtContraDos.TextChanged += TxtDni_TextChanged;
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Right;
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F);
            label6.Location = new Point(24, 201);
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
            label7.Location = new Point(27, 230);
            label7.Name = "label7";
            label7.Size = new Size(89, 42);
            label7.TabIndex = 19;
            label7.Text = "Repita la\r\nContraseña";
            // 
            // CMBTipoUsuario
            // 
            CMBTipoUsuario.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            CMBTipoUsuario.DropDownStyle = ComboBoxStyle.DropDownList;
            CMBTipoUsuario.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            CMBTipoUsuario.FormattingEnabled = true;
            CMBTipoUsuario.Location = new Point(123, 375);
            CMBTipoUsuario.Margin = new Padding(4);
            CMBTipoUsuario.Name = "CMBTipoUsuario";
            CMBTipoUsuario.Size = new Size(278, 29);
            CMBTipoUsuario.TabIndex = 14;
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Right;
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F);
            label5.Location = new Point(73, 379);
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
            label8.Location = new Point(32, 342);
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
            TxtRespues.Location = new Point(123, 338);
            TxtRespues.Margin = new Padding(4);
            TxtRespues.MaxLength = 255;
            TxtRespues.Name = "TxtRespues";
            TxtRespues.Size = new Size(278, 29);
            TxtRespues.TabIndex = 13;
            TxtRespues.TextChanged += TxtDni_TextChanged;
            // 
            // CMBPregunta
            // 
            CMBPregunta.DropDownStyle = ComboBoxStyle.DropDownList;
            CMBPregunta.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            CMBPregunta.FormattingEnabled = true;
            CMBPregunta.Location = new Point(123, 301);
            CMBPregunta.Margin = new Padding(4);
            CMBPregunta.Name = "CMBPregunta";
            CMBPregunta.Size = new Size(278, 29);
            CMBPregunta.TabIndex = 12;
            // 
            // label9
            // 
            label9.Anchor = AnchorStyles.Right;
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 12F);
            label9.Location = new Point(40, 305);
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
            LblError.Location = new Point(122, 272);
            LblError.Margin = new Padding(3, 0, 3, 4);
            LblError.Name = "LblError";
            LblError.Size = new Size(280, 21);
            LblError.TabIndex = 24;
            LblError.Text = "Las Contraseñas no coinciden";
            LblError.Visible = false;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Controls.Add(BtnGuardar, 0, 0);
            tableLayoutPanel2.Location = new Point(122, 442);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Size = new Size(280, 41);
            tableLayoutPanel2.TabIndex = 25;
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
            BtnGuardar.Location = new Point(2, 0);
            BtnGuardar.Margin = new Padding(0);
            BtnGuardar.Name = "BtnGuardar";
            BtnGuardar.Size = new Size(136, 41);
            BtnGuardar.TabIndex = 10;
            BtnGuardar.Text = "Guardar";
            BtnGuardar.TextAlign = ContentAlignment.MiddleRight;
            BtnGuardar.TextImageRelation = TextImageRelation.ImageBeforeText;
            BtnGuardar.UseVisualStyleBackColor = false;
            BtnGuardar.Click += BtnGuardar_Click;
            // 
            // ChkActivo
            // 
            ChkActivo.AutoSize = true;
            ChkActivo.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ChkActivo.Location = new Point(122, 411);
            ChkActivo.Name = "ChkActivo";
            ChkActivo.Size = new Size(76, 25);
            ChkActivo.TabIndex = 27;
            ChkActivo.Text = "Activo";
            ChkActivo.UseVisualStyleBackColor = true;
            // 
            // PanelLista
            // 
            PanelLista.BackColor = Color.FromArgb(218, 218, 220);
            PanelLista.Controls.Add(tableLayoutPanel1);
            PanelLista.Dock = DockStyle.Fill;
            PanelLista.Location = new Point(3, 3);
            PanelLista.Name = "PanelLista";
            PanelLista.Padding = new Padding(0, 16, 0, 16);
            PanelLista.Size = new Size(315, 555);
            PanelLista.TabIndex = 3;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(LblLista, 0, 0);
            tableLayoutPanel1.Controls.Add(ListBUsuarios, 0, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 16);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 32F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(315, 523);
            tableLayoutPanel1.TabIndex = 2;
            // 
            // LblLista
            // 
            LblLista.Dock = DockStyle.Top;
            LblLista.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LblLista.ForeColor = Color.FromArgb(7, 100, 147);
            LblLista.Location = new Point(3, 0);
            LblLista.Name = "LblLista";
            LblLista.Size = new Size(309, 21);
            LblLista.TabIndex = 1;
            LblLista.Text = "Lista de Usuarios";
            LblLista.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // ListBUsuarios
            // 
            ListBUsuarios.AllowUserToAddRows = false;
            ListBUsuarios.AllowUserToDeleteRows = false;
            ListBUsuarios.AllowUserToResizeColumns = false;
            ListBUsuarios.AllowUserToResizeRows = false;
            ListBUsuarios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            ListBUsuarios.Columns.AddRange(new DataGridViewColumn[] { DNI, ColumnApellido, ColumnNombre });
            ListBUsuarios.Dock = DockStyle.Fill;
            ListBUsuarios.Location = new Point(3, 35);
            ListBUsuarios.MultiSelect = false;
            ListBUsuarios.Name = "ListBUsuarios";
            ListBUsuarios.ReadOnly = true;
            ListBUsuarios.RowHeadersVisible = false;
            ListBUsuarios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            ListBUsuarios.Size = new Size(309, 485);
            ListBUsuarios.TabIndex = 2;
            ListBUsuarios.SelectionChanged += ListBUsuarios_SelectionChanged;
            // 
            // DNI
            // 
            DNI.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            DNI.DataPropertyName = "DNI";
            DNI.HeaderText = "DNI";
            DNI.MaxInputLength = 8;
            DNI.Name = "DNI";
            DNI.ReadOnly = true;
            DNI.Width = 62;
            // 
            // ColumnApellido
            // 
            ColumnApellido.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            ColumnApellido.DataPropertyName = "Apellido";
            ColumnApellido.HeaderText = "Apellido";
            ColumnApellido.MaxInputLength = 50;
            ColumnApellido.Name = "ColumnApellido";
            ColumnApellido.ReadOnly = true;
            // 
            // ColumnNombre
            // 
            ColumnNombre.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            ColumnNombre.DataPropertyName = "Nombre";
            ColumnNombre.HeaderText = "Nombre";
            ColumnNombre.MaxInputLength = 50;
            ColumnNombre.Name = "ColumnNombre";
            ColumnNombre.ReadOnly = true;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.BackColor = Color.FromArgb(218, 218, 220);
            tableLayoutPanel3.ColumnCount = 2;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60F));
            tableLayoutPanel3.Controls.Add(PanelLista, 0, 0);
            tableLayoutPanel3.Controls.Add(PanelMedio, 1, 0);
            tableLayoutPanel3.Dock = DockStyle.Fill;
            tableLayoutPanel3.Location = new Point(0, 0);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 1;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel3.Size = new Size(804, 561);
            tableLayoutPanel3.TabIndex = 2;
            // 
            // USConsultaUsuario
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.FromArgb(249, 249, 251);
            Controls.Add(tableLayoutPanel3);
            Font = new Font("Segoe UI", 12F);
            ForeColor = Color.FromArgb(26, 28, 30);
            Margin = new Padding(4);
            Name = "USConsultaUsuario";
            Size = new Size(804, 561);
            Load += USConsultaUsuario_Load;
            PanelMedio.ResumeLayout(false);
            tableLayoutPanel4.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            TLPForm.ResumeLayout(false);
            TLPForm.PerformLayout();
            tableLayoutPanel2.ResumeLayout(false);
            PanelLista.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)ListBUsuarios).EndInit();
            tableLayoutPanel3.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel PanelMedio;
        private TableLayoutPanel tableLayoutPanel4;
        private Panel PanelLista;
        private Label LblLista;
        private TableLayoutPanel tableLayoutPanel3;
        private TableLayoutPanel tableLayoutPanel1;
        private DataGridView ListBUsuarios;
        private DataGridViewTextBoxColumn DNI;
        private DataGridViewTextBoxColumn ColumnApellido;
        private DataGridViewTextBoxColumn ColumnNombre;
        private GroupBox groupBox1;
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
        private TextBox TxtContra;
        private TextBox TxtContraDos;
        private Label label6;
        private Label label7;
        private ComboBox CMBTipoUsuario;
        private Label label5;
        private Label label8;
        private TextBox TxtRespues;
        private ComboBox CMBPregunta;
        private Label label9;
        private Label LblError;
        private TableLayoutPanel tableLayoutPanel2;
        private Button BtnGuardar;
        private CheckBox ChkActivo;
    }
}
