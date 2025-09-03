namespace Agraria.UI.Proveedores
{
    partial class FormProveedores
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
            label1 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Dock = DockStyle.Fill;
            label1.Font = new Font("Segoe UI", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(0, 75, 113);
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(824, 579);
            label1.TabIndex = 0;
            label1.Text = "PROVEEDORES";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // FormActividad
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(203, 230, 255);
            ClientSize = new Size(824, 579);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormProveedores";
            Text = "FormProveedores";
            ResumeLayout(false);
        }

        #endregion
        private Label label1;
    }
}