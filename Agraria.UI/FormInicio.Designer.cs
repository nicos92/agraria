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
			label2 = new Label();
			tableLayoutPanel2 = new TableLayoutPanel();
			pictureBox4 = new PictureBox();
			pictureBox3 = new PictureBox();
			pictureBox2 = new PictureBox();
			panel1.SuspendLayout();
			tableLayoutPanel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			tableLayoutPanel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
			((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
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
			tableLayoutPanel1.Controls.Add(label2, 1, 1);
			tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 1, 3);
			tableLayoutPanel1.Dock = DockStyle.Fill;
			tableLayoutPanel1.Location = new Point(0, 0);
			tableLayoutPanel1.Name = "tableLayoutPanel1";
			tableLayoutPanel1.RowCount = 5;
			tableLayoutPanel1.RowStyles.Add(new RowStyle());
			tableLayoutPanel1.RowStyles.Add(new RowStyle());
			tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
			tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 64F));
			tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 8F));
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
			pictureBox1.Size = new Size(621, 266);
			pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
			pictureBox1.TabIndex = 1;
			pictureBox1.TabStop = false;
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
			// tableLayoutPanel2
			// 
			tableLayoutPanel2.ColumnCount = 4;
			tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
			tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
			tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
			tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
			tableLayoutPanel2.Controls.Add(pictureBox4, 1, 0);
			tableLayoutPanel2.Controls.Add(pictureBox3, 0, 0);
			tableLayoutPanel2.Controls.Add(pictureBox2, 3, 0);
			tableLayoutPanel2.Dock = DockStyle.Fill;
			tableLayoutPanel2.Location = new Point(78, 362);
			tableLayoutPanel2.Margin = new Padding(0);
			tableLayoutPanel2.Name = "tableLayoutPanel2";
			tableLayoutPanel2.RowCount = 1;
			tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
			tableLayoutPanel2.Size = new Size(627, 64);
			tableLayoutPanel2.TabIndex = 5;
			// 
			// pictureBox4
			// 
			tableLayoutPanel2.SetColumnSpan(pictureBox4, 2);
			pictureBox4.Dock = DockStyle.Fill;
			pictureBox4.Image = Properties.Resources.isft_500x500_r203g230b255_v4;
			pictureBox4.Location = new Point(156, 0);
			pictureBox4.Margin = new Padding(0);
			pictureBox4.Name = "pictureBox4";
			pictureBox4.Size = new Size(312, 64);
			pictureBox4.SizeMode = PictureBoxSizeMode.Zoom;
			pictureBox4.TabIndex = 6;
			pictureBox4.TabStop = false;
			// 
			// pictureBox3
			// 
			pictureBox3.Dock = DockStyle.Fill;
			pictureBox3.Image = Properties.Resources.svm_500_r203g230b255_v3;
			pictureBox3.Location = new Point(0, 0);
			pictureBox3.Margin = new Padding(0);
			pictureBox3.Name = "pictureBox3";
			pictureBox3.Size = new Size(156, 64);
			pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
			pictureBox3.TabIndex = 4;
			pictureBox3.TabStop = false;
			// 
			// pictureBox2
			// 
			pictureBox2.Dock = DockStyle.Fill;
			pictureBox2.Image = Properties.Resources.e732primarycontainer_v2;
			pictureBox2.Location = new Point(468, 0);
			pictureBox2.Margin = new Padding(0);
			pictureBox2.Name = "pictureBox2";
			pictureBox2.Size = new Size(159, 64);
			pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
			pictureBox2.TabIndex = 2;
			pictureBox2.TabStop = false;
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
			tableLayoutPanel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
			((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
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
		private PictureBox pictureBox3;
		private TableLayoutPanel tableLayoutPanel2;
		private PictureBox pictureBox4;
	}
}