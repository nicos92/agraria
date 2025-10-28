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
			pictureBox2 = new PictureBox();
			label2 = new Label();
			panel1.SuspendLayout();
			tableLayoutPanel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
			SuspendLayout();
			// 
			// panel1
			// 
			panel1.BackColor = Color.FromArgb(7, 100, 147);
			panel1.BackgroundImage = Properties.Resources.granero1;
			panel1.BackgroundImageLayout = ImageLayout.Stretch;
			panel1.Controls.Add(tableLayoutPanel1);
			panel1.Dock = DockStyle.Fill;
			panel1.Location = new Point(8, 8);
			panel1.Name = "panel1";
			panel1.Size = new Size(784, 434);
			panel1.TabIndex = 0;
			// 
			// tableLayoutPanel1
			// 
			tableLayoutPanel1.BackColor = Color.Transparent;
			tableLayoutPanel1.ColumnCount = 3;
			tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
			tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 80F));
			tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
			tableLayoutPanel1.Controls.Add(label1, 1, 0);
			tableLayoutPanel1.Controls.Add(pictureBox1, 1, 2);
			tableLayoutPanel1.Controls.Add(pictureBox2, 2, 2);
			tableLayoutPanel1.Controls.Add(label2, 1, 1);
			tableLayoutPanel1.Dock = DockStyle.Fill;
			tableLayoutPanel1.Location = new Point(0, 0);
			tableLayoutPanel1.Name = "tableLayoutPanel1";
			tableLayoutPanel1.RowCount = 3;
			tableLayoutPanel1.RowStyles.Add(new RowStyle());
			tableLayoutPanel1.RowStyles.Add(new RowStyle());
			tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
			tableLayoutPanel1.Size = new Size(784, 434);
			tableLayoutPanel1.TabIndex = 0;
			// 
			// label1
			// 
			label1.Anchor = AnchorStyles.None;
			label1.AutoSize = true;
			label1.Font = new Font("Segoe UI", 27.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label1.ForeColor = Color.FromArgb(203, 230, 255);
			label1.Location = new Point(274, 0);
			label1.Name = "label1";
			label1.Size = new Size(234, 50);
			label1.TabIndex = 0;
			label1.Text = "Bienvenidos";
			// 
			// pictureBox1
			// 
			pictureBox1.Dock = DockStyle.Fill;
			pictureBox1.Image = Properties.Resources.EA_C_256_;
			pictureBox1.Location = new Point(81, 93);
			pictureBox1.Name = "pictureBox1";
			pictureBox1.Size = new Size(621, 338);
			pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
			pictureBox1.TabIndex = 1;
			pictureBox1.TabStop = false;
			// 
			// pictureBox2
			// 
			pictureBox2.Dock = DockStyle.Bottom;
			pictureBox2.Image = Properties.Resources.e732primarycontainer;
			pictureBox2.Location = new Point(708, 376);
			pictureBox2.Margin = new Padding(3, 3, 3, 8);
			pictureBox2.Name = "pictureBox2";
			pictureBox2.Size = new Size(73, 50);
			pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
			pictureBox2.TabIndex = 2;
			pictureBox2.TabStop = false;
			// 
			// label2
			// 
			label2.Anchor = AnchorStyles.None;
			label2.AutoSize = true;
			label2.Font = new Font("Segoe UI", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label2.ForeColor = Color.FromArgb(203, 230, 255);
			label2.Location = new Point(109, 50);
			label2.Name = "label2";
			label2.Size = new Size(565, 40);
			label2.TabIndex = 3;
			label2.Text = "Sistema de Gestión de Escuelas Agrarias";
			// 
			// FormInicio
			// 
			AutoScaleMode = AutoScaleMode.None;
			BackColor = Color.FromArgb(203, 230, 255);
			ClientSize = new Size(800, 450);
			Controls.Add(panel1);
			DoubleBuffered = true;
			FormBorderStyle = FormBorderStyle.None;
			Name = "FormInicio";
			Padding = new Padding(8);
			Text = "FormInicio";
			panel1.ResumeLayout(false);
			tableLayoutPanel1.ResumeLayout(false);
			tableLayoutPanel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
			ResumeLayout(false);
		}

		#endregion

		private Panel panel1;
		private TableLayoutPanel tableLayoutPanel1;
		private Label label1;
		private PictureBox pictureBox1;
		private PictureBox pictureBox2;
		private Label label2;
	}
}