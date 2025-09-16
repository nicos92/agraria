namespace Agraria.UI.Actividad
{
    partial class FormActividad
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            PanelMedio = new Panel();
            PanelOpcion = new Panel();
            tableLayoutPanel2 = new TableLayoutPanel();
            BtnOpcionEditar = new Button();
            BtnOpcionIngresar = new Button();
            PanelOpcion.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // PanelMedio
            // 
            PanelMedio.Dock = DockStyle.Fill;
            PanelMedio.Location = new Point(0, 64);
            PanelMedio.Name = "PanelMedio";
            PanelMedio.Size = new Size(824, 515);
            PanelMedio.TabIndex = 1;
            // 
            // PanelOpcion
            // 
            PanelOpcion.Controls.Add(tableLayoutPanel2);
            PanelOpcion.Dock = DockStyle.Top;
            PanelOpcion.Location = new Point(0, 0);
            PanelOpcion.Name = "PanelOpcion";
            PanelOpcion.Size = new Size(824, 64);
            PanelOpcion.TabIndex = 10;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33333F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33333F));
            tableLayoutPanel2.Controls.Add(BtnOpcionEditar, 1, 0);
            tableLayoutPanel2.Controls.Add(BtnOpcionIngresar, 0, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(0, 0);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Size = new Size(824, 64);
            tableLayoutPanel2.TabIndex = 1;
            // 
            // BtnOpcionEditar
            // 
            BtnOpcionEditar.BackColor = Color.FromArgb(83, 96, 108);
            BtnOpcionEditar.Dock = DockStyle.Fill;
            BtnOpcionEditar.FlatAppearance.BorderColor = Color.FromArgb(59, 72, 84);
            BtnOpcionEditar.FlatStyle = FlatStyle.Flat;
            BtnOpcionEditar.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BtnOpcionEditar.ForeColor = Color.FromArgb(255, 255, 255);
            BtnOpcionEditar.Image = Properties.Resources.pen;
            BtnOpcionEditar.ImageAlign = ContentAlignment.MiddleLeft;
            BtnOpcionEditar.Location = new Point(412, 0);
            BtnOpcionEditar.Margin = new Padding(0);
            BtnOpcionEditar.Name = "BtnOpcionEditar";
            BtnOpcionEditar.Size = new Size(412, 64);
            BtnOpcionEditar.TabIndex = 1;
            BtnOpcionEditar.Text = "Consultar Actividades";
            BtnOpcionEditar.TextAlign = ContentAlignment.MiddleRight;
            BtnOpcionEditar.TextImageRelation = TextImageRelation.TextBeforeImage;
            BtnOpcionEditar.UseVisualStyleBackColor = false;
            BtnOpcionEditar.Click += BtnOpcionIngresar_Click;
            // 
            // BtnOpcionIngresar
            // 
            BtnOpcionIngresar.BackColor = Color.FromArgb(7, 100, 147);
            BtnOpcionIngresar.Dock = DockStyle.Fill;
            BtnOpcionIngresar.FlatAppearance.BorderColor = Color.FromArgb(203, 230, 255);
            BtnOpcionIngresar.FlatStyle = FlatStyle.Flat;
            BtnOpcionIngresar.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BtnOpcionIngresar.ForeColor = Color.FromArgb(255, 255, 255);
            BtnOpcionIngresar.Image = Properties.Resources.ingresar;
            BtnOpcionIngresar.ImageAlign = ContentAlignment.MiddleLeft;
            BtnOpcionIngresar.Location = new Point(0, 0);
            BtnOpcionIngresar.Margin = new Padding(0);
            BtnOpcionIngresar.Name = "BtnOpcionIngresar";
            BtnOpcionIngresar.Size = new Size(412, 64);
            BtnOpcionIngresar.TabIndex = 0;
            BtnOpcionIngresar.Text = "Ingresar Actividad";
            BtnOpcionIngresar.TextAlign = ContentAlignment.MiddleRight;
            BtnOpcionIngresar.TextImageRelation = TextImageRelation.TextBeforeImage;
            BtnOpcionIngresar.UseVisualStyleBackColor = false;
            BtnOpcionIngresar.Click += BtnOpcionIngresar_Click;
            // 
            // FormActividad
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(203, 230, 255);
            ClientSize = new Size(824, 579);
            Controls.Add(PanelMedio);
            Controls.Add(PanelOpcion);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormActividad";
            Text = "FormActividad";
            Load += FormActividad_Load;
            PanelOpcion.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel PanelMedio;
        private Panel PanelOpcion;
        private TableLayoutPanel tableLayoutPanel2;
        private Button BtnOpcionEditar;
        private Button BtnOpcionIngresar;
    }
}
