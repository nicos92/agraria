using Agraria.Util;

namespace Agraria.Login;

partial class FormLogin
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
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

	#region Windows Form Designer generated code

	/// <summary>
	///  Required method for Designer support - do not modify
	///  the contents of this method with the code editor.
	/// </summary>
	private void InitializeComponent()
	{
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLogin));
		TLPFondo = new TableLayoutPanel();
		TLPLogo = new TableLayoutPanel();
		Logo = new PictureBox();
		TLPInicio = new TableLayoutPanel();
		BtnIngresar = new Button();
		LblInicioError = new Label();
		TxtContra = new TextBox();
		label3 = new Label();
		TxtDni = new TextBox();
		LblUsuario = new Label();
		LblOlvide = new LinkLabel();
		LblTitulo = new Label();
		LblEye = new Label();
		ProgressBar = new ProgressBar();
		TLPFondo.SuspendLayout();
		TLPLogo.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)Logo).BeginInit();
		TLPInicio.SuspendLayout();
		SuspendLayout();
		// 
		// TLPFondo
		// 
		TLPFondo.BackColor = Color.FromArgb(203, 230, 255);
		TLPFondo.ColumnCount = 2;
		TLPFondo.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 39.3589745F));
		TLPFondo.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60.6410255F));
		TLPFondo.Controls.Add(TLPLogo, 0, 0);
		TLPFondo.Controls.Add(TLPInicio, 1, 0);
		TLPFondo.Dock = DockStyle.Fill;
		TLPFondo.Location = new Point(0, 16);
		TLPFondo.Name = "TLPFondo";
		TLPFondo.RowCount = 1;
		TLPFondo.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
		TLPFondo.Size = new Size(940, 541);
		TLPFondo.TabIndex = 0;
		// 
		// TLPLogo
		// 
		TLPLogo.BackColor = Color.FromArgb(7, 100, 147);
		TLPLogo.ColumnCount = 1;
		TLPLogo.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
		TLPLogo.Controls.Add(Logo, 0, 0);
		TLPLogo.Dock = DockStyle.Fill;
		TLPLogo.Location = new Point(3, 3);
		TLPLogo.Name = "TLPLogo";
		TLPLogo.RowCount = 1;
		TLPLogo.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
		TLPLogo.Size = new Size(363, 535);
		TLPLogo.TabIndex = 9;
		// 
		// Logo
		// 
		Logo.Anchor = AnchorStyles.None;
		Logo.Image = Properties.Resources.EA_C_256_;
		Logo.Location = new Point(53, 139);
		Logo.Name = "Logo";
		Logo.Size = new Size(256, 256);
		Logo.SizeMode = PictureBoxSizeMode.Zoom;
		Logo.TabIndex = 1;
		Logo.TabStop = false;
		// 
		// TLPInicio
		// 
		TLPInicio.BackColor = Color.FromArgb(7, 100, 147);
		TLPInicio.ColumnCount = 3;
		TLPInicio.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
		TLPInicio.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60F));
		TLPInicio.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
		TLPInicio.Controls.Add(BtnIngresar, 1, 7);
		TLPInicio.Controls.Add(LblInicioError, 1, 6);
		TLPInicio.Controls.Add(TxtContra, 1, 5);
		TLPInicio.Controls.Add(label3, 1, 4);
		TLPInicio.Controls.Add(TxtDni, 1, 3);
		TLPInicio.Controls.Add(LblUsuario, 1, 2);
		TLPInicio.Controls.Add(LblOlvide, 1, 8);
		TLPInicio.Controls.Add(LblTitulo, 0, 1);
		TLPInicio.Controls.Add(LblEye, 2, 5);
		TLPInicio.Dock = DockStyle.Fill;
		TLPInicio.ForeColor = Color.FromArgb(255, 255, 255);
		TLPInicio.Location = new Point(372, 3);
		TLPInicio.Name = "TLPInicio";
		TLPInicio.RowCount = 10;
		TLPInicio.RowStyles.Add(new RowStyle(SizeType.Absolute, 64F));
		TLPInicio.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
		TLPInicio.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
		TLPInicio.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
		TLPInicio.RowStyles.Add(new RowStyle(SizeType.Percent, 7.913669F));
		TLPInicio.RowStyles.Add(new RowStyle(SizeType.Percent, 14.1486807F));
		TLPInicio.RowStyles.Add(new RowStyle(SizeType.Percent, 11.7506F));
		TLPInicio.RowStyles.Add(new RowStyle(SizeType.Percent, 16.3069553F));
		TLPInicio.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
		TLPInicio.RowStyles.Add(new RowStyle(SizeType.Absolute, 64F));
		TLPInicio.Size = new Size(565, 535);
		TLPInicio.TabIndex = 0;
		// 
		// BtnIngresar
		// 
		BtnIngresar.Anchor = AnchorStyles.Top;
		BtnIngresar.BackColor = Color.FromArgb(83, 96, 108);
		BtnIngresar.Cursor = Cursors.Hand;
		BtnIngresar.Enabled = false;
		BtnIngresar.FlatAppearance.BorderColor = Color.White;
		BtnIngresar.FlatStyle = FlatStyle.Flat;
		BtnIngresar.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
		BtnIngresar.ForeColor = Color.FromArgb(0, 75, 113);
		BtnIngresar.Location = new Point(218, 353);
		BtnIngresar.Name = "BtnIngresar";
		BtnIngresar.Size = new Size(128, 48);
		BtnIngresar.TabIndex = 3;
		BtnIngresar.Text = "INGRESAR";
		BtnIngresar.UseVisualStyleBackColor = false;
		BtnIngresar.EnabledChanged += BtnIngresar_EnabledChanged;
		BtnIngresar.Click += BtnIngresar_Click;
		// 
		// LblInicioError
		// 
		LblInicioError.Anchor = AnchorStyles.Top;
		LblInicioError.AutoSize = true;
		LblInicioError.BackColor = Color.FromArgb(255, 218, 214);
		LblInicioError.ForeColor = Color.FromArgb(65, 0, 2);
		LblInicioError.Location = new Point(155, 303);
		LblInicioError.Name = "LblInicioError";
		LblInicioError.Size = new Size(254, 21);
		LblInicioError.TabIndex = 7;
		LblInicioError.Text = "Usuario y/o Contraseña Incorrectas";
		// 
		// TxtContra
		// 
		TxtContra.Anchor = AnchorStyles.Top;
		TxtContra.Cursor = Cursors.Hand;
		TxtContra.Location = new Point(116, 249);
		TxtContra.MaxLength = 255;
		TxtContra.Name = "TxtContra";
		TxtContra.PasswordChar = '*';
		TxtContra.Size = new Size(333, 29);
		TxtContra.TabIndex = 2;
		TxtContra.Text = "@Director123";
		TxtContra.TextChanged += TxtDni_TextChanged;
		TxtContra.KeyPress += TxtContra_KeyPress;
		// 
		// label3
		// 
		label3.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		label3.AutoSize = true;
		label3.Location = new Point(116, 225);
		label3.Name = "label3";
		label3.Size = new Size(92, 21);
		label3.TabIndex = 2;
		label3.Text = "Contraseña:";
		// 
		// TxtDni
		// 
		TxtDni.Anchor = AnchorStyles.Top;
		TxtDni.Cursor = Cursors.Hand;
		TxtDni.Location = new Point(116, 167);
		TxtDni.MaxLength = 8;
		TxtDni.Name = "TxtDni";
		TxtDni.Size = new Size(333, 29);
		TxtDni.TabIndex = 1;
		TxtDni.Text = "11111111";
		TxtDni.TextChanged += TxtDni_TextChanged;
		TxtDni.KeyPress += TxtContra_KeyPress;
		// 
		// LblUsuario
		// 
		LblUsuario.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		LblUsuario.AutoSize = true;
		LblUsuario.Location = new Point(116, 143);
		LblUsuario.Name = "LblUsuario";
		LblUsuario.Size = new Size(98, 21);
		LblUsuario.TabIndex = 1;
		LblUsuario.Text = "DNI Usuario:";
		// 
		// LblOlvide
		// 
		LblOlvide.ActiveLinkColor = Color.FromArgb(92, 87, 151);
		LblOlvide.Anchor = AnchorStyles.None;
		LblOlvide.AutoSize = true;
		LblOlvide.LinkColor = Color.FromArgb(255, 255, 255);
		LblOlvide.Location = new Point(187, 420);
		LblOlvide.Name = "LblOlvide";
		LblOlvide.Size = new Size(190, 42);
		LblOlvide.TabIndex = 4;
		LblOlvide.TabStop = true;
		LblOlvide.Text = "¿Olvidaste tu Contraseña?\r\nHaz click aquí";
		LblOlvide.TextAlign = ContentAlignment.MiddleCenter;
		LblOlvide.VisitedLinkColor = Color.FromArgb(255, 216, 232);
		LblOlvide.LinkClicked += LblOlvide_LinkClicked;
		// 
		// LblTitulo
		// 
		LblTitulo.Anchor = AnchorStyles.None;
		TLPInicio.SetColumnSpan(LblTitulo, 3);
		LblTitulo.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
		LblTitulo.ForeColor = Color.FromArgb(255, 255, 255);
		LblTitulo.Location = new Point(132, 66);
		LblTitulo.Name = "LblTitulo";
		LblTitulo.Size = new Size(301, 45);
		LblTitulo.TabIndex = 0;
		LblTitulo.Text = "INICIO DE SESIÓN";
		// 
		// LblEye
		// 
		LblEye.Cursor = Cursors.Hand;
		LblEye.Image = Properties.Resources.eyeLowVision;
		LblEye.Location = new Point(455, 246);
		LblEye.Name = "LblEye";
		LblEye.Size = new Size(48, 32);
		LblEye.TabIndex = 8;
		LblEye.Click += LblEye_Click;
		// 
		// ProgressBar
		// 
		ProgressBar.Dock = DockStyle.Top;
		ProgressBar.Location = new Point(0, 0);
		ProgressBar.Name = "ProgressBar";
		ProgressBar.Size = new Size(940, 16);
		ProgressBar.Step = 20;
		ProgressBar.Style = ProgressBarStyle.Marquee;
		ProgressBar.TabIndex = 8;
		ProgressBar.Visible = false;
		// 
		// FormLogin
		// 
		AutoScaleMode = AutoScaleMode.None;
		ClientSize = new Size(940, 557);
		Controls.Add(TLPFondo);
		Controls.Add(ProgressBar);
		Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
		FormBorderStyle = FormBorderStyle.Fixed3D;
		Icon = (Icon)resources.GetObject("$this.Icon");
		MaximizeBox = false;
		MaximumSize = new Size(960, 600);
		MinimizeBox = false;
		MinimumSize = new Size(960, 600);
		Name = "FormLogin";
		StartPosition = FormStartPosition.CenterScreen;
		Text = "Escuela Agraria";
		Activated += FormLogin_Activated;
		Load += FormLogin_Load;
		TLPFondo.ResumeLayout(false);
		TLPLogo.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)Logo).EndInit();
		TLPInicio.ResumeLayout(false);
		TLPInicio.PerformLayout();
		ResumeLayout(false);
	}

	#endregion

	private TableLayoutPanel TLPFondo;
    private TableLayoutPanel TLPInicio;
    private Label LblTitulo;
    private Label LblUsuario;
    private Label label3;
    private TextBox TxtDni;
    private TextBox TxtContra;
    private Button BtnIngresar;
    private Label LblInicioError;
    private PictureBox Logo;
    private LinkLabel LblOlvide;
    private TableLayoutPanel TLPLogo;
    private ProgressBar ProgressBar;
    private Label LblEye;
}
