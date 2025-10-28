namespace Agraria.UI.Acerca
{
	partial class FormAcercaDe
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAcercaDe));
			tableLayoutPanel1 = new TableLayoutPanel();
			groupBox1 = new GroupBox();
			tableLayoutPanel2 = new TableLayoutPanel();
			LblNombreProducto = new Label();
			LblSo = new Label();
			LblNet = new Label();
			LblFecha = new Label();
			label1 = new Label();
			LblVersion = new Label();
			groupBox2 = new GroupBox();
			tableLayoutPanel3 = new TableLayoutPanel();
			linkLabel7 = new LinkLabel();
			linkLabel6 = new LinkLabel();
			linkLabel5 = new LinkLabel();
			linkLabel4 = new LinkLabel();
			linkLabel3 = new LinkLabel();
			label8 = new Label();
			linkLabel2 = new LinkLabel();
			linkLabel1 = new LinkLabel();
			tableLayoutPanel1.SuspendLayout();
			groupBox1.SuspendLayout();
			tableLayoutPanel2.SuspendLayout();
			groupBox2.SuspendLayout();
			tableLayoutPanel3.SuspendLayout();
			SuspendLayout();
			// 
			// tableLayoutPanel1
			// 
			tableLayoutPanel1.BackColor = Color.Transparent;
			tableLayoutPanel1.ColumnCount = 4;
			tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
			tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
			tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
			tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
			tableLayoutPanel1.Controls.Add(groupBox1, 1, 1);
			tableLayoutPanel1.Controls.Add(groupBox2, 2, 1);
			tableLayoutPanel1.Dock = DockStyle.Fill;
			tableLayoutPanel1.Location = new Point(0, 0);
			tableLayoutPanel1.Name = "tableLayoutPanel1";
			tableLayoutPanel1.RowCount = 3;
			tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
			tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
			tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
			tableLayoutPanel1.Size = new Size(780, 457);
			tableLayoutPanel1.TabIndex = 0;
			// 
			// groupBox1
			// 
			groupBox1.Controls.Add(tableLayoutPanel2);
			groupBox1.Dock = DockStyle.Fill;
			groupBox1.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
			groupBox1.Location = new Point(23, 23);
			groupBox1.Name = "groupBox1";
			groupBox1.Size = new Size(364, 411);
			groupBox1.TabIndex = 2;
			groupBox1.TabStop = false;
			// 
			// tableLayoutPanel2
			// 
			tableLayoutPanel2.ColumnCount = 1;
			tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
			tableLayoutPanel2.Controls.Add(LblNombreProducto, 0, 5);
			tableLayoutPanel2.Controls.Add(LblSo, 0, 4);
			tableLayoutPanel2.Controls.Add(LblNet, 0, 3);
			tableLayoutPanel2.Controls.Add(LblFecha, 0, 2);
			tableLayoutPanel2.Controls.Add(label1, 0, 0);
			tableLayoutPanel2.Controls.Add(LblVersion, 0, 1);
			tableLayoutPanel2.Dock = DockStyle.Fill;
			tableLayoutPanel2.Location = new Point(3, 29);
			tableLayoutPanel2.Name = "tableLayoutPanel2";
			tableLayoutPanel2.RowCount = 11;
			tableLayoutPanel2.RowStyles.Add(new RowStyle());
			tableLayoutPanel2.RowStyles.Add(new RowStyle());
			tableLayoutPanel2.RowStyles.Add(new RowStyle());
			tableLayoutPanel2.RowStyles.Add(new RowStyle());
			tableLayoutPanel2.RowStyles.Add(new RowStyle());
			tableLayoutPanel2.RowStyles.Add(new RowStyle());
			tableLayoutPanel2.RowStyles.Add(new RowStyle());
			tableLayoutPanel2.RowStyles.Add(new RowStyle());
			tableLayoutPanel2.RowStyles.Add(new RowStyle());
			tableLayoutPanel2.RowStyles.Add(new RowStyle());
			tableLayoutPanel2.RowStyles.Add(new RowStyle());
			tableLayoutPanel2.Size = new Size(358, 379);
			tableLayoutPanel2.TabIndex = 0;
			// 
			// LblNombreProducto
			// 
			LblNombreProducto.AutoSize = true;
			LblNombreProducto.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold);
			LblNombreProducto.Location = new Point(4, 174);
			LblNombreProducto.Margin = new Padding(4);
			LblNombreProducto.Name = "LblNombreProducto";
			LblNombreProducto.Size = new Size(95, 25);
			LblNombreProducto.TabIndex = 5;
			LblNombreProducto.Text = "Producto:";
			// 
			// LblSo
			// 
			LblSo.AutoSize = true;
			LblSo.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold);
			LblSo.Location = new Point(4, 141);
			LblSo.Margin = new Padding(4);
			LblSo.Name = "LblSo";
			LblSo.Size = new Size(41, 25);
			LblSo.TabIndex = 4;
			LblSo.Text = "SO:";
			// 
			// LblNet
			// 
			LblNet.AutoSize = true;
			LblNet.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold);
			LblNet.Location = new Point(4, 108);
			LblNet.Margin = new Padding(4);
			LblNet.Name = "LblNet";
			LblNet.Size = new Size(57, 25);
			LblNet.TabIndex = 3;
			LblNet.Text = ".NET:";
			// 
			// LblFecha
			// 
			LblFecha.AutoSize = true;
			LblFecha.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold);
			LblFecha.Location = new Point(4, 75);
			LblFecha.Margin = new Padding(4);
			LblFecha.Name = "LblFecha";
			LblFecha.Size = new Size(67, 25);
			LblFecha.TabIndex = 2;
			LblFecha.Text = "Fecha:";
			// 
			// label1
			// 
			label1.Anchor = AnchorStyles.Left;
			label1.AutoSize = true;
			label1.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label1.Location = new Point(3, 0);
			label1.Margin = new Padding(3, 0, 3, 8);
			label1.Name = "label1";
			label1.Size = new Size(255, 30);
			label1.TabIndex = 0;
			label1.Text = "Proyecto Escuela Agraria";
			label1.TextAlign = ContentAlignment.MiddleLeft;
			// 
			// LblVersion
			// 
			LblVersion.AutoSize = true;
			LblVersion.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold);
			LblVersion.Location = new Point(4, 42);
			LblVersion.Margin = new Padding(4);
			LblVersion.Name = "LblVersion";
			LblVersion.Size = new Size(80, 25);
			LblVersion.TabIndex = 1;
			LblVersion.Text = "Version:";
			// 
			// groupBox2
			// 
			groupBox2.Controls.Add(tableLayoutPanel3);
			groupBox2.Dock = DockStyle.Fill;
			groupBox2.Location = new Point(393, 23);
			groupBox2.Name = "groupBox2";
			groupBox2.Size = new Size(364, 411);
			groupBox2.TabIndex = 3;
			groupBox2.TabStop = false;
			// 
			// tableLayoutPanel3
			// 
			tableLayoutPanel3.ColumnCount = 1;
			tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
			tableLayoutPanel3.Controls.Add(linkLabel7, 0, 7);
			tableLayoutPanel3.Controls.Add(linkLabel6, 0, 6);
			tableLayoutPanel3.Controls.Add(linkLabel5, 0, 5);
			tableLayoutPanel3.Controls.Add(linkLabel4, 0, 4);
			tableLayoutPanel3.Controls.Add(linkLabel3, 0, 3);
			tableLayoutPanel3.Controls.Add(label8, 0, 0);
			tableLayoutPanel3.Controls.Add(linkLabel2, 0, 2);
			tableLayoutPanel3.Controls.Add(linkLabel1, 0, 1);
			tableLayoutPanel3.Dock = DockStyle.Fill;
			tableLayoutPanel3.Location = new Point(3, 25);
			tableLayoutPanel3.Name = "tableLayoutPanel3";
			tableLayoutPanel3.RowCount = 11;
			tableLayoutPanel3.RowStyles.Add(new RowStyle());
			tableLayoutPanel3.RowStyles.Add(new RowStyle());
			tableLayoutPanel3.RowStyles.Add(new RowStyle());
			tableLayoutPanel3.RowStyles.Add(new RowStyle());
			tableLayoutPanel3.RowStyles.Add(new RowStyle());
			tableLayoutPanel3.RowStyles.Add(new RowStyle());
			tableLayoutPanel3.RowStyles.Add(new RowStyle());
			tableLayoutPanel3.RowStyles.Add(new RowStyle());
			tableLayoutPanel3.RowStyles.Add(new RowStyle());
			tableLayoutPanel3.RowStyles.Add(new RowStyle());
			tableLayoutPanel3.RowStyles.Add(new RowStyle());
			tableLayoutPanel3.Size = new Size(358, 383);
			tableLayoutPanel3.TabIndex = 1;
			// 
			// linkLabel7
			// 
			linkLabel7.ActiveLinkColor = Color.White;
			linkLabel7.AutoSize = true;
			linkLabel7.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold);
			linkLabel7.LinkColor = Color.White;
			linkLabel7.Location = new Point(3, 188);
			linkLabel7.Name = "linkLabel7";
			linkLabel7.Size = new Size(113, 25);
			linkLabel7.TabIndex = 11;
			linkLabel7.TabStop = true;
			linkLabel7.Text = "Lautaro Fen";
			linkLabel7.VisitedLinkColor = Color.White;
			// 
			// linkLabel6
			// 
			linkLabel6.ActiveLinkColor = Color.White;
			linkLabel6.AutoSize = true;
			linkLabel6.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold);
			linkLabel6.LinkColor = Color.White;
			linkLabel6.Location = new Point(3, 163);
			linkLabel6.Name = "linkLabel6";
			linkLabel6.Size = new Size(123, 25);
			linkLabel6.TabIndex = 10;
			linkLabel6.TabStop = true;
			linkLabel6.Text = "Ulises Trujillo";
			linkLabel6.VisitedLinkColor = Color.White;
			// 
			// linkLabel5
			// 
			linkLabel5.ActiveLinkColor = Color.White;
			linkLabel5.AutoSize = true;
			linkLabel5.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold);
			linkLabel5.LinkColor = Color.White;
			linkLabel5.Location = new Point(3, 138);
			linkLabel5.Name = "linkLabel5";
			linkLabel5.Size = new Size(125, 25);
			linkLabel5.TabIndex = 9;
			linkLabel5.TabStop = true;
			linkLabel5.Text = "Lautaro Arias";
			linkLabel5.VisitedLinkColor = Color.White;
			// 
			// linkLabel4
			// 
			linkLabel4.ActiveLinkColor = Color.White;
			linkLabel4.AutoSize = true;
			linkLabel4.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold);
			linkLabel4.LinkColor = Color.White;
			linkLabel4.Location = new Point(3, 113);
			linkLabel4.Name = "linkLabel4";
			linkLabel4.Size = new Size(143, 25);
			linkLabel4.TabIndex = 8;
			linkLabel4.TabStop = true;
			linkLabel4.Text = "Matias Sposaro";
			linkLabel4.VisitedLinkColor = Color.White;
			// 
			// linkLabel3
			// 
			linkLabel3.ActiveLinkColor = Color.White;
			linkLabel3.AutoSize = true;
			linkLabel3.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold);
			linkLabel3.LinkColor = Color.White;
			linkLabel3.Location = new Point(3, 88);
			linkLabel3.Name = "linkLabel3";
			linkLabel3.Size = new Size(128, 25);
			linkLabel3.TabIndex = 7;
			linkLabel3.TabStop = true;
			linkLabel3.Text = "Luciano Nitto";
			linkLabel3.VisitedLinkColor = Color.White;
			// 
			// label8
			// 
			label8.Anchor = AnchorStyles.Left;
			label8.AutoSize = true;
			label8.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 0);
			label8.Location = new Point(3, 0);
			label8.Margin = new Padding(3, 0, 3, 8);
			label8.Name = "label8";
			label8.Size = new Size(165, 30);
			label8.TabIndex = 0;
			label8.Text = "Desarrolladores";
			label8.TextAlign = ContentAlignment.MiddleCenter;
			// 
			// linkLabel2
			// 
			linkLabel2.ActiveLinkColor = Color.White;
			linkLabel2.AutoSize = true;
			linkLabel2.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold);
			linkLabel2.LinkColor = Color.White;
			linkLabel2.Location = new Point(3, 63);
			linkLabel2.Name = "linkLabel2";
			linkLabel2.Size = new Size(159, 25);
			linkLabel2.TabIndex = 6;
			linkLabel2.TabStop = true;
			linkLabel2.Text = "Federico Feressin";
			linkLabel2.VisitedLinkColor = Color.White;
			// 
			// linkLabel1
			// 
			linkLabel1.ActiveLinkColor = Color.White;
			linkLabel1.AutoSize = true;
			linkLabel1.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold);
			linkLabel1.LinkColor = Color.White;
			linkLabel1.Location = new Point(3, 38);
			linkLabel1.Name = "linkLabel1";
			linkLabel1.Size = new Size(238, 25);
			linkLabel1.TabIndex = 5;
			linkLabel1.TabStop = true;
			linkLabel1.Text = "Nicolás Salomón Sandoval";
			linkLabel1.VisitedLinkColor = Color.White;
			linkLabel1.LinkClicked += linkLabel1_LinkClicked;
			// 
			// FormAcercaDe
			// 
			AutoScaleDimensions = new SizeF(9F, 21F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = Color.FromArgb(7, 100, 147);
			BackgroundImage = Properties.Resources.e7;
			BackgroundImageLayout = ImageLayout.Zoom;
			ClientSize = new Size(780, 457);
			Controls.Add(tableLayoutPanel1);
			DoubleBuffered = true;
			Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
			ForeColor = Color.White;
			FormBorderStyle = FormBorderStyle.Fixed3D;
			Icon = (Icon)resources.GetObject("$this.Icon");
			Margin = new Padding(4);
			MaximizeBox = false;
			MinimizeBox = false;
			Name = "FormAcercaDe";
			StartPosition = FormStartPosition.CenterScreen;
			Text = "Acerca de ...";
			Load += FormAcercaDe_Load;
			tableLayoutPanel1.ResumeLayout(false);
			groupBox1.ResumeLayout(false);
			tableLayoutPanel2.ResumeLayout(false);
			tableLayoutPanel2.PerformLayout();
			groupBox2.ResumeLayout(false);
			tableLayoutPanel3.ResumeLayout(false);
			tableLayoutPanel3.PerformLayout();
			ResumeLayout(false);
		}

		#endregion

		private TableLayoutPanel tableLayoutPanel1;
		private TableLayoutPanel tableLayoutPanel2;
		private Label LblNet;
		private Label LblFecha;
		private Label label1;
		private Label LblVersion;
		private Label LblSo;
		private Label LblCompany;
		private Label LblDescripcion;
		private Label LblNombreProducto;
		private TableLayoutPanel tableLayoutPanel3;
		private Label label8;
		private GroupBox groupBox1;
		private GroupBox groupBox2;
		private LinkLabel linkLabel1;
		private LinkLabel linkLabel4;
		private LinkLabel linkLabel3;
		private LinkLabel linkLabel2;
		private LinkLabel linkLabel7;
		private LinkLabel linkLabel6;
		private LinkLabel linkLabel5;
	}
}