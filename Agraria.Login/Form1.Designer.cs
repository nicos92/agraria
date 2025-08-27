using Agraria.Util;

namespace Agraria.Login;

partial class Form1
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
        TLPFondo = new TableLayoutPanel();
        TLPInicio = new TableLayoutPanel();
        BtnIngresar = new Button();
        LblInicioError = new Label();
        TxtContrasenia = new TextBox();
        label3 = new Label();
        TxtUsuario = new TextBox();
        LblUsuario = new Label();
        label1 = new Label();
        Logo = new PictureBox();
        LblOlvide = new LinkLabel();
        TLPFondo.SuspendLayout();
        TLPInicio.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)Logo).BeginInit();
        SuspendLayout();
        // 
        // TLPFondo
        // 
        TLPFondo.BackColor = Color.FromArgb(235, 231, 235);
        TLPFondo.ColumnCount = 2;
        TLPFondo.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 39.3589745F));
        TLPFondo.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60.6410255F));
        TLPFondo.Controls.Add(TLPInicio, 1, 0);
        TLPFondo.Controls.Add(Logo, 0, 0);
        TLPFondo.Dock = DockStyle.Fill;
        TLPFondo.Location = new Point(0, 0);
        TLPFondo.Name = "TLPFondo";
        TLPFondo.RowCount = 1;
        TLPFondo.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
        TLPFondo.Size = new Size(780, 457);
        TLPFondo.TabIndex = 0;
        // 
        // TLPInicio
        // 
        TLPInicio.BackColor = Color.FromArgb(241, 237, 240);
        TLPInicio.ColumnCount = 3;
        TLPInicio.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
        TLPInicio.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60F));
        TLPInicio.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
        TLPInicio.Controls.Add(BtnIngresar, 1, 7);
        TLPInicio.Controls.Add(LblInicioError, 1, 6);
        TLPInicio.Controls.Add(TxtContrasenia, 1, 5);
        TLPInicio.Controls.Add(label3, 1, 4);
        TLPInicio.Controls.Add(TxtUsuario, 1, 3);
        TLPInicio.Controls.Add(LblUsuario, 1, 2);
        TLPInicio.Controls.Add(label1, 1, 1);
        TLPInicio.Controls.Add(LblOlvide, 1, 8);
        TLPInicio.Dock = DockStyle.Fill;
        TLPInicio.ForeColor = Color.FromArgb(28, 27, 30);
        TLPInicio.Location = new Point(310, 3);
        TLPInicio.Name = "TLPInicio";
        TLPInicio.RowCount = 10;
        TLPInicio.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
        TLPInicio.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
        TLPInicio.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
        TLPInicio.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
        TLPInicio.RowStyles.Add(new RowStyle(SizeType.Percent, 8.088235F));
        TLPInicio.RowStyles.Add(new RowStyle(SizeType.Percent, 10.2941179F));
        TLPInicio.RowStyles.Add(new RowStyle(SizeType.Percent, 9.558824F));
        TLPInicio.RowStyles.Add(new RowStyle(SizeType.Percent, 22.0588226F));
        TLPInicio.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
        TLPInicio.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
        TLPInicio.Size = new Size(467, 451);
        TLPInicio.TabIndex = 0;
        // 
        // BtnIngresar
        // 
        BtnIngresar.Anchor = AnchorStyles.Top;
        BtnIngresar.BackColor = Color.FromArgb(92, 87, 151);
        BtnIngresar.Cursor = Cursors.Hand;
        BtnIngresar.FlatStyle = FlatStyle.Flat;
        BtnIngresar.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
        BtnIngresar.ForeColor = Color.FromArgb(255, 255, 255);
        BtnIngresar.Location = new Point(169, 290);
        BtnIngresar.Name = "BtnIngresar";
        BtnIngresar.Size = new Size(128, 48);
        BtnIngresar.TabIndex = 6;
        BtnIngresar.Text = "INGRESAR";
        BtnIngresar.UseVisualStyleBackColor = true;
        // 
        // LblInicioError
        // 
        LblInicioError.ForeColor = AppColorPalette.Light.Error;
        
        LblInicioError.Anchor = AnchorStyles.None;
        LblInicioError.AutoSize = true;
        LblInicioError.ForeColor = Color.IndianRed;
        LblInicioError.Location = new Point(114, 257);
        LblInicioError.Name = "LblInicioError";
        LblInicioError.Size = new Size(237, 21);
        LblInicioError.TabIndex = 7;
        LblInicioError.Text = "Usuario o contraseña incorrectas";
        LblInicioError.Visible = false;
        // 
        // TxtContrasenia
        // 
        TxtContrasenia.Anchor = AnchorStyles.Top;
        TxtContrasenia.Cursor = Cursors.Hand;
        TxtContrasenia.Location = new Point(96, 209);
        TxtContrasenia.Name = "TxtContrasenia";
        TxtContrasenia.Size = new Size(274, 29);
        TxtContrasenia.TabIndex = 5;
        // 
        // label3
        // 
        label3.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
        label3.AutoSize = true;
        label3.Location = new Point(96, 185);
        label3.Name = "label3";
        label3.Size = new Size(92, 21);
        label3.TabIndex = 2;
        label3.Text = "Contraseña:";
        // 
        // TxtUsuario
        // 
        TxtUsuario.Anchor = AnchorStyles.Top;
        TxtUsuario.Cursor = Cursors.Hand;
        TxtUsuario.Location = new Point(96, 125);
        TxtUsuario.Name = "TxtUsuario";
        TxtUsuario.Size = new Size(274, 29);
        TxtUsuario.TabIndex = 4;
        // 
        // LblUsuario
        // 
        LblUsuario.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
        LblUsuario.AutoSize = true;
        LblUsuario.Location = new Point(96, 101);
        LblUsuario.Name = "LblUsuario";
        LblUsuario.Size = new Size(67, 21);
        LblUsuario.TabIndex = 1;
        LblUsuario.Text = "Usuario:";
        // 
        // label1
        // 
        label1.Anchor = AnchorStyles.None;
        label1.AutoSize = true;
        label1.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
        label1.Location = new Point(113, 23);
        label1.Name = "label1";
        label1.Size = new Size(240, 45);
        label1.TabIndex = 0;
        label1.Text = "inicio de sesión";
        label1.Click += label1_Click;
        // 
        // Logo
        // 
        Logo.Anchor = AnchorStyles.None;
        Logo.Image = Properties.Resources.EA_C_256_;
        Logo.Location = new Point(25, 100);
        Logo.Name = "Logo";
        Logo.Size = new Size(256, 256);
        Logo.SizeMode = PictureBoxSizeMode.Zoom;
        Logo.TabIndex = 1;
        Logo.TabStop = false;
        // 
        // LblOlvide
        // 
        LblOlvide.LinkColor = AppColorPalette.Light.Tertiary;
        LblOlvide.VisitedLinkColor = AppColorPalette.Light.TertiaryContainer;
        LblOlvide.ActiveLinkColor = AppColorPalette.Light.Primary;
        LblOlvide.Anchor = AnchorStyles.None;
        LblOlvide.AutoSize = true;
        LblOlvide.Location = new Point(139, 381);
        LblOlvide.Name = "LblOlvide";
        LblOlvide.Size = new Size(187, 42);
        LblOlvide.TabIndex = 8;
        LblOlvide.TabStop = true;
        LblOlvide.Text = "¿Olvidaste tu contraseña?\r\nhaz click aquí";
        LblOlvide.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // Form1
        // 
        AutoScaleMode = AutoScaleMode.None;
        ClientSize = new Size(780, 457);
        Controls.Add(TLPFondo);
        Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
        FormBorderStyle = FormBorderStyle.Fixed3D;
        Name = "Form1";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Escuela Agraria";
        TLPFondo.ResumeLayout(false);
        TLPInicio.ResumeLayout(false);
        TLPInicio.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)Logo).EndInit();
        ResumeLayout(false);
    }

    #endregion

    private TableLayoutPanel TLPFondo;
    private TableLayoutPanel TLPInicio;
    private Label label1;
    private Label LblUsuario;
    private Label label3;
    private TextBox TxtUsuario;
    private TextBox TxtContrasenia;
    private Button BtnIngresar;
    private Label LblInicioError;
    private PictureBox Logo;
    private LinkLabel LblOlvide;
}
