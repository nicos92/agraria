namespace Agraria.UI.Paniol
{
    partial class UCIngresoHerramienta
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
            LblNombre = new Label();
            TxtNombre = new TextBox();
            TxtDescripcion = new TextBox();
            label5 = new Label();
            BtnIngresar = new Button();
            TxtCantidad = new TextBox();
            label4 = new Label();
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
            groupBox1.Location = new Point(85, 80);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(633, 417);
            groupBox1.TabIndex = 15;
            groupBox1.TabStop = false;
            groupBox1.Text = "Formulario de Ingreso de Herramienta";
            // 
            // TLPForm
            // 
            TLPForm.BackColor = Color.FromArgb(249, 249, 251);
            TLPForm.ColumnCount = 3;
            TLPForm.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20.1270924F));
            TLPForm.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 65.1734543F));
            TLPForm.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.6994543F));
            TLPForm.Controls.Add(LblNombre, 0, 1);
            TLPForm.Controls.Add(TxtNombre, 1, 1);
            TLPForm.Controls.Add(TxtDescripcion, 1, 3);
            TLPForm.Controls.Add(label5, 0, 3);
            TLPForm.Controls.Add(BtnIngresar, 1, 4);
            TLPForm.Controls.Add(TxtCantidad, 1, 2);
            TLPForm.Controls.Add(label4, 0, 2);
            TLPForm.Dock = DockStyle.Fill;
            TLPForm.ForeColor = Color.FromArgb(26, 28, 30);
            TLPForm.Location = new Point(3, 29);
            TLPForm.Name = "TLPForm";
            TLPForm.RowCount = 6;
            TLPForm.RowStyles.Add(new RowStyle(SizeType.Percent, 14.0101862F));
            TLPForm.RowStyles.Add(new RowStyle(SizeType.Percent, 14.0101881F));
            TLPForm.RowStyles.Add(new RowStyle(SizeType.Percent, 14.0101881F));
            TLPForm.RowStyles.Add(new RowStyle(SizeType.Percent, 33.4061127F));
            TLPForm.RowStyles.Add(new RowStyle(SizeType.Percent, 20.3056736F));
            TLPForm.RowStyles.Add(new RowStyle(SizeType.Percent, 4.257642F));
            TLPForm.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            TLPForm.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            TLPForm.Size = new Size(627, 385);
            TLPForm.TabIndex = 0;
            // 
            // LblNombre
            // 
            LblNombre.Anchor = AnchorStyles.Right;
            LblNombre.AutoSize = true;
            LblNombre.Font = new Font("Segoe UI", 12F);
            LblNombre.Location = new Point(52, 69);
            LblNombre.Name = "LblNombre";
            LblNombre.Size = new Size(71, 21);
            LblNombre.TabIndex = 0;
            LblNombre.Text = "Nombre:";
            // 
            // TxtNombre
            // 
            TxtNombre.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            TxtNombre.BackColor = Color.FromArgb(238, 237, 240);
            TxtNombre.Font = new Font("Segoe UI", 12F);
            TxtNombre.ForeColor = Color.FromArgb(26, 28, 30);
            TxtNombre.Location = new Point(129, 65);
            TxtNombre.MaxLength = 50;
            TxtNombre.Name = "TxtNombre";
            TxtNombre.Size = new Size(402, 29);
            TxtNombre.TabIndex = 5;
            // 
            // TxtDescripcion
            // 
            TxtDescripcion.BackColor = Color.FromArgb(238, 237, 240);
            TxtDescripcion.Dock = DockStyle.Fill;
            TxtDescripcion.Font = new Font("Segoe UI", 12F);
            TxtDescripcion.ForeColor = Color.FromArgb(26, 28, 30);
            TxtDescripcion.Location = new Point(129, 162);
            TxtDescripcion.MaxLength = 400;
            TxtDescripcion.Multiline = true;
            TxtDescripcion.Name = "TxtDescripcion";
            TxtDescripcion.Size = new Size(402, 122);
            TxtDescripcion.TabIndex = 9;
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Right;
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F);
            label5.Location = new Point(29, 212);
            label5.Name = "label5";
            label5.Size = new Size(94, 21);
            label5.TabIndex = 12;
            label5.Text = "Descripción:";
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
            BtnIngresar.Location = new Point(234, 305);
            BtnIngresar.Margin = new Padding(0);
            BtnIngresar.Name = "BtnIngresar";
            BtnIngresar.Size = new Size(192, 42);
            BtnIngresar.TabIndex = 13;
            BtnIngresar.Text = "INGRESAR";
            BtnIngresar.TextImageRelation = TextImageRelation.TextBeforeImage;
            BtnIngresar.UseVisualStyleBackColor = false;
            // 
            // TxtCantidad
            // 
            TxtCantidad.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            TxtCantidad.BackColor = Color.FromArgb(238, 237, 240);
            TxtCantidad.Font = new Font("Segoe UI", 12F);
            TxtCantidad.ForeColor = Color.FromArgb(26, 28, 30);
            TxtCantidad.Location = new Point(129, 118);
            TxtCantidad.MaxLength = 12;
            TxtCantidad.Name = "TxtCantidad";
            TxtCantidad.Size = new Size(402, 29);
            TxtCantidad.TabIndex = 7;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Right;
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F);
            label4.Location = new Point(48, 122);
            label4.Name = "label4";
            label4.Size = new Size(75, 21);
            label4.TabIndex = 4;
            label4.Text = "Cantidad:";
            // 
            // ProgressBar
            // 
            ProgressBar.Dock = DockStyle.Fill;
            ProgressBar.Location = new Point(0, 0);
            ProgressBar.Margin = new Padding(0);
            ProgressBar.Name = "ProgressBar";
            ProgressBar.Size = new Size(804, 16);
            ProgressBar.TabIndex = 16;
            ProgressBar.Visible = false;
            // 
            // UCIngresoHerramienta
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.FromArgb(249, 249, 251);
            Controls.Add(PanelMedio);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ForeColor = Color.FromArgb(26, 28, 30);
            Margin = new Padding(4);
            Name = "UCIngresoHerramienta";
            Size = new Size(804, 561);
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
        private Label LblNombre;
        private TextBox TxtCantidad;
        private TextBox TxtNombre;
        private Label label4;
        private Label label5;
        private Button BtnIngresar;
        private TextBox TxtDescripcion;
        private ProgressBar ProgressBar;
    }
}
