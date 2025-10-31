namespace Agraria.UI
{
	partial class FormProgreso
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
			this.lblMensaje = new System.Windows.Forms.Label();
			this.progressBar = new System.Windows.Forms.ProgressBar();
			this.lblPorcentaje = new System.Windows.Forms.Label();
			this.SuspendLayout();

			// 
			// lblMensaje
			// 
			this.lblMensaje.AutoSize = false;
			this.lblMensaje.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.lblMensaje.Location = new System.Drawing.Point(20, 20);
			this.lblMensaje.Name = "lblMensaje";
			this.lblMensaje.Size = new System.Drawing.Size(400, 25);
			this.lblMensaje.TabIndex = 0;
			this.lblMensaje.Text = "Generando respaldo de la base de datos...";
			this.lblMensaje.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

			// 
			// progressBar
			// 
			this.progressBar.Location = new System.Drawing.Point(20, 55);
			this.progressBar.Name = "progressBar";
			this.progressBar.Size = new System.Drawing.Size(400, 30);
			this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
			this.progressBar.TabIndex = 1;
			this.progressBar.Minimum = 0;
			this.progressBar.Maximum = 100;
			this.progressBar.Value = 0;

			// 
			// lblPorcentaje
			// 
			this.lblPorcentaje.AutoSize = false;
			this.lblPorcentaje.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.lblPorcentaje.Location = new System.Drawing.Point(20, 90);
			this.lblPorcentaje.Name = "lblPorcentaje";
			this.lblPorcentaje.Size = new System.Drawing.Size(400, 20);
			this.lblPorcentaje.TabIndex = 2;
			this.lblPorcentaje.Text = "0% completado";
			this.lblPorcentaje.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

			// 
			// FormProgreso
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(440, 130);
			this.Controls.Add(this.lblPorcentaje);
			this.Controls.Add(this.progressBar);
			this.Controls.Add(this.lblMensaje);
			this.Name = "FormProgreso";
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.Label lblMensaje;
		private System.Windows.Forms.ProgressBar progressBar;
		private System.Windows.Forms.Label lblPorcentaje;
		#endregion
	}
}
