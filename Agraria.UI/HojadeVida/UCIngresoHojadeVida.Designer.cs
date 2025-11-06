namespace Agraria.UI.HojadeVida
{
    partial class UCIngresoHojadeVida
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
			label2 = new Label();
			label3 = new Label();
			label4 = new Label();
			label5 = new Label();
			label6 = new Label();
			label7 = new Label();
			label8 = new Label();
			TxtNombre = new TextBox();
			CMBTipoAnimal = new ComboBox();
			CMBSexo = new ComboBox();
			DTPFechaNacimiento = new DateTimePicker();
			TxtPeso = new TextBox();
			TxtEstadoSalud = new TextBox();
			TxtObservaciones = new TextBox();
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
			groupBox1.Location = new Point(85, 63);
			groupBox1.Name = "groupBox1";
			groupBox1.Size = new Size(633, 451);
			groupBox1.TabIndex = 15;
			groupBox1.TabStop = false;
			groupBox1.Text = "Formulario de Ingreso de Hoja de Vida";
			// 
			// TLPForm
			// 
			TLPForm.BackColor = Color.FromArgb(249, 249, 251);
			TLPForm.ColumnCount = 3;
			TLPForm.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20.1270924F));
			TLPForm.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 65.1734543F));
			TLPForm.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.6994543F));
			TLPForm.Controls.Add(label1, 0, 1);
			TLPForm.Controls.Add(label2, 0, 2);
			TLPForm.Controls.Add(label3, 0, 3);
			TLPForm.Controls.Add(label4, 0, 4);
			TLPForm.Controls.Add(label5, 0, 5);
			TLPForm.Controls.Add(label6, 0, 6);
			TLPForm.Controls.Add(label7, 0, 7);
			TLPForm.Controls.Add(label8, 0, 8);
			TLPForm.Controls.Add(TxtNombre, 1, 1);
			TLPForm.Controls.Add(CMBTipoAnimal, 1, 2);
			TLPForm.Controls.Add(CMBSexo, 1, 3);
			TLPForm.Controls.Add(DTPFechaNacimiento, 1, 4);
			TLPForm.Controls.Add(TxtPeso, 1, 5);
			TLPForm.Controls.Add(TxtEstadoSalud, 1, 6);
			TLPForm.Controls.Add(TxtObservaciones, 1, 7);
			TLPForm.Controls.Add(ChkActivo, 1, 8);
			TLPForm.Controls.Add(BtnIngresar, 1, 9);
			TLPForm.Dock = DockStyle.Fill;
			TLPForm.ForeColor = Color.FromArgb(26, 28, 30);
			TLPForm.Location = new Point(3, 29);
			TLPForm.Name = "TLPForm";
			TLPForm.RowCount = 11;
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
			TLPForm.RowStyles.Add(new RowStyle(SizeType.Absolute, 8F));
			TLPForm.Size = new Size(627, 419);
			TLPForm.TabIndex = 0;
			// 
			// label1
			// 
			label1.Anchor = AnchorStyles.Right;
			label1.AutoSize = true;
			label1.Font = new Font("Segoe UI", 12F);
			label1.Location = new Point(52, 15);
			label1.Name = "label1";
			label1.Size = new Size(71, 21);
			label1.TabIndex = 0;
			label1.Text = "Número:";
			// 
			// label2
			// 
			label2.Anchor = AnchorStyles.Right;
			label2.AutoSize = true;
			label2.Font = new Font("Segoe UI", 12F);
			label2.Location = new Point(27, 50);
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
			label3.Location = new Point(73, 85);
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
			label4.Location = new Point(48, 113);
			label4.Name = "label4";
			label4.Size = new Size(75, 42);
			label4.TabIndex = 3;
			label4.Text = "Fecha de Nacim:";
			// 
			// label5
			// 
			label5.Anchor = AnchorStyles.Right;
			label5.AutoSize = true;
			label5.Font = new Font("Segoe UI", 12F);
			label5.Location = new Point(74, 162);
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
			label6.Location = new Point(21, 197);
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
			label7.Location = new Point(23, 265);
			label7.Name = "label7";
			label7.Size = new Size(100, 21);
			label7.TabIndex = 6;
			label7.Text = "Observación:";
			// 
			// label8
			// 
			label8.Anchor = AnchorStyles.Right;
			label8.AutoSize = true;
			label8.Font = new Font("Segoe UI", 12F);
			label8.Location = new Point(67, 327);
			label8.Name = "label8";
			label8.Size = new Size(56, 21);
			label8.TabIndex = 15;
			label8.Text = "Activo:";
			// 
			// TxtNombre
			// 
			TxtNombre.Anchor = AnchorStyles.Left | AnchorStyles.Right;
			TxtNombre.BackColor = Color.FromArgb(238, 237, 240);
			TxtNombre.Font = new Font("Segoe UI", 12F);
			TxtNombre.ForeColor = Color.FromArgb(26, 28, 30);
			TxtNombre.Location = new Point(129, 11);
			TxtNombre.MaxLength = 9;
			TxtNombre.Name = "TxtNombre";
			TxtNombre.Size = new Size(402, 29);
			TxtNombre.TabIndex = 7;
			TxtNombre.TextChanged += TxtCodigo_TextChanged;
			// 
			// CMBTipoAnimal
			// 
			CMBTipoAnimal.Anchor = AnchorStyles.Left | AnchorStyles.Right;
			CMBTipoAnimal.DropDownStyle = ComboBoxStyle.DropDownList;
			CMBTipoAnimal.Font = new Font("Segoe UI", 12F);
			CMBTipoAnimal.FormattingEnabled = true;
			CMBTipoAnimal.Location = new Point(129, 46);
			CMBTipoAnimal.Name = "CMBTipoAnimal";
			CMBTipoAnimal.Size = new Size(402, 29);
			CMBTipoAnimal.TabIndex = 8;
			// 
			// CMBSexo
			// 
			CMBSexo.Anchor = AnchorStyles.Left | AnchorStyles.Right;
			CMBSexo.DropDownStyle = ComboBoxStyle.DropDownList;
			CMBSexo.Font = new Font("Segoe UI", 12F);
			CMBSexo.FormattingEnabled = true;
			CMBSexo.Location = new Point(129, 81);
			CMBSexo.Name = "CMBSexo";
			CMBSexo.Size = new Size(402, 29);
			CMBSexo.TabIndex = 9;
			// 
			// DTPFechaNacimiento
			// 
			DTPFechaNacimiento.Anchor = AnchorStyles.Left | AnchorStyles.Right;
			DTPFechaNacimiento.Font = new Font("Segoe UI", 12F);
			DTPFechaNacimiento.Location = new Point(129, 119);
			DTPFechaNacimiento.Name = "DTPFechaNacimiento";
			DTPFechaNacimiento.Size = new Size(402, 29);
			DTPFechaNacimiento.TabIndex = 10;
			// 
			// TxtPeso
			// 
			TxtPeso.Anchor = AnchorStyles.Left | AnchorStyles.Right;
			TxtPeso.BackColor = Color.FromArgb(238, 237, 240);
			TxtPeso.Font = new Font("Segoe UI", 12F);
			TxtPeso.ForeColor = Color.FromArgb(26, 28, 30);
			TxtPeso.Location = new Point(129, 158);
			TxtPeso.MaxLength = 10;
			TxtPeso.Name = "TxtPeso";
			TxtPeso.Size = new Size(402, 29);
			TxtPeso.TabIndex = 11;
			TxtPeso.TextChanged += TxtCodigo_TextChanged;
			// 
			// TxtEstadoSalud
			// 
			TxtEstadoSalud.Anchor = AnchorStyles.Left | AnchorStyles.Right;
			TxtEstadoSalud.BackColor = Color.FromArgb(238, 237, 240);
			TxtEstadoSalud.Font = new Font("Segoe UI", 12F);
			TxtEstadoSalud.ForeColor = Color.FromArgb(26, 28, 30);
			TxtEstadoSalud.Location = new Point(129, 193);
			TxtEstadoSalud.MaxLength = 100;
			TxtEstadoSalud.Name = "TxtEstadoSalud";
			TxtEstadoSalud.Size = new Size(402, 29);
			TxtEstadoSalud.TabIndex = 12;
			TxtEstadoSalud.TextChanged += TxtCodigo_TextChanged;
			// 
			// TxtObservaciones
			// 
			TxtObservaciones.BackColor = Color.FromArgb(238, 237, 240);
			TxtObservaciones.Dock = DockStyle.Fill;
			TxtObservaciones.Font = new Font("Segoe UI", 12F);
			TxtObservaciones.ForeColor = Color.FromArgb(26, 28, 30);
			TxtObservaciones.Location = new Point(129, 228);
			TxtObservaciones.MaxLength = 200;
			TxtObservaciones.Multiline = true;
			TxtObservaciones.Name = "TxtObservaciones";
			TxtObservaciones.Size = new Size(402, 96);
			TxtObservaciones.TabIndex = 13;
			// 
			// ChkActivo
			// 
			ChkActivo.Anchor = AnchorStyles.Left;
			ChkActivo.AutoSize = true;
			ChkActivo.Checked = true;
			ChkActivo.CheckState = CheckState.Checked;
			ChkActivo.Font = new Font("Segoe UI", 12F);
			ChkActivo.Location = new Point(129, 330);
			ChkActivo.Name = "ChkActivo";
			ChkActivo.Size = new Size(15, 14);
			ChkActivo.TabIndex = 14;
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
			BtnIngresar.Location = new Point(234, 348);
			BtnIngresar.Margin = new Padding(0);
			BtnIngresar.Name = "BtnIngresar";
			BtnIngresar.Size = new Size(192, 47);
			BtnIngresar.TabIndex = 15;
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
			// UCIngresoHojadeVida
			// 
			AutoScaleMode = AutoScaleMode.None;
			BackColor = Color.FromArgb(249, 249, 251);
			Controls.Add(PanelMedio);
			Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
			ForeColor = Color.FromArgb(26, 28, 30);
			Margin = new Padding(4);
			Name = "UCIngresoHojadeVida";
			Size = new Size(804, 561);
			Load += UCIngresoHojadeVida_Load;
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
        private Label label8;
        private Button BtnIngresar;
        private ProgressBar ProgressBar;
    }
}