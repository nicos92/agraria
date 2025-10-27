namespace Agraria.UI
{
	partial class FormInicio
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
			panel1 = new Panel();
			tableLayoutPanel1 = new TableLayoutPanel();
			label1 = new Label();
			pictureBox1 = new PictureBox();
			panel1.SuspendLayout();
			tableLayoutPanel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			SuspendLayout();
			// 
			// panel1
			// 
			panel1.BackColor = Color.FromArgb(7, 100, 147);
			panel1.Controls.Add(tableLayoutPanel1);
			panel1.Dock = DockStyle.Fill;
			panel1.Location = new Point(8, 8);
			panel1.Name = "panel1";
			panel1.Size = new Size(784, 434);
			panel1.TabIndex = 0;
			// 
			// tableLayoutPanel1
			// 
			tableLayoutPanel1.ColumnCount = 3;
			tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 7.863696F));
			tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 92.13631F));
			tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
			tableLayoutPanel1.Controls.Add(label1, 1, 0);
			tableLayoutPanel1.Controls.Add(pictureBox1, 1, 1);
			tableLayoutPanel1.Dock = DockStyle.Fill;
			tableLayoutPanel1.Location = new Point(0, 0);
			tableLayoutPanel1.Name = "tableLayoutPanel1";
			tableLayoutPanel1.RowCount = 2;
			tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 19.8156681F));
			tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 80.18433F));
			tableLayoutPanel1.Size = new Size(784, 434);
			tableLayoutPanel1.TabIndex = 0;
			// 
			// label1
			// 
			label1.Anchor = AnchorStyles.None;
			label1.AutoSize = true;
			label1.Font = new Font("Segoe UI", 27.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label1.ForeColor = Color.White;
			label1.Location = new Point(279, 18);
			label1.Name = "label1";
			label1.Size = new Size(264, 50);
			label1.TabIndex = 0;
			label1.Text = "Bienvenidos...";
			// 
			// pictureBox1
			// 
			pictureBox1.Dock = DockStyle.Fill;
			pictureBox1.Image = Properties.Resources.EA_C_256_;
			pictureBox1.Location = new Point(63, 89);
			pictureBox1.Name = "pictureBox1";
			pictureBox1.Size = new Size(697, 342);
			pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
			pictureBox1.TabIndex = 1;
			pictureBox1.TabStop = false;
			// 
			// FormInicio
			// 
			AutoScaleMode = AutoScaleMode.None;
			BackColor = Color.FromArgb(203, 230, 255);
			ClientSize = new Size(800, 450);
			Controls.Add(panel1);
			FormBorderStyle = FormBorderStyle.None;
			Name = "FormInicio";
			Padding = new Padding(8);
			Text = "FormInicio";
			panel1.ResumeLayout(false);
			tableLayoutPanel1.ResumeLayout(false);
			tableLayoutPanel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			ResumeLayout(false);
		}

		#endregion

		private Panel panel1;
		private TableLayoutPanel tableLayoutPanel1;
		private Label label1;
		private PictureBox pictureBox1;
	}
}