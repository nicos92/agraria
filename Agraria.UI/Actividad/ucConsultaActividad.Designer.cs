namespace Agraria.UI.Actividad
{
    partial class ucConsultaActividad
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            label1 = new Label();
            tableLayoutPanel3 = new TableLayoutPanel();
            PanelLista = new Panel();
            tableLayoutPanel1 = new TableLayoutPanel();
            LblLista = new Label();
            ListBArticulos = new DataGridView();
            Cantidad = new DataGridViewTextBoxColumn();
            Fecha_Hora = new DataGridViewTextBoxColumn();
            Entorno = new DataGridViewTextBoxColumn();
            Descripcion = new DataGridViewTextBoxColumn();
            PanelMedio = new Panel();
            tableLayoutPanel4 = new TableLayoutPanel();
            groupBox1 = new GroupBox();
            TLPForm = new TableLayoutPanel();
            TxtDescripcion = new TextBox();
            tableLayoutPanel2 = new TableLayoutPanel();
            BtnGuardar = new Button();
            BtnEliminar = new Button();
            CMBCategoria = new ComboBox();
            CMBSubcategoria = new ComboBox();
            label5 = new Label();
            label3 = new Label();
            LblCuit = new Label();
            dateTimePicker1 = new DateTimePicker();
            label2 = new Label();
            ProgressBar = new ProgressBar();
            tableLayoutPanel3.SuspendLayout();
            PanelLista.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ListBArticulos).BeginInit();
            PanelMedio.SuspendLayout();
            tableLayoutPanel4.SuspendLayout();
            groupBox1.SuspendLayout();
            TLPForm.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(33, 42);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(107, 15);
            label1.TabIndex = 0;
            label1.Text = "Consulta Actividad";
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.BackColor = Color.FromArgb(218, 218, 220);
            tableLayoutPanel3.ColumnCount = 2;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60F));
            tableLayoutPanel3.Controls.Add(PanelLista, 0, 1);
            tableLayoutPanel3.Controls.Add(PanelMedio, 1, 1);
            tableLayoutPanel3.Controls.Add(ProgressBar, 0, 0);
            tableLayoutPanel3.Dock = DockStyle.Fill;
            tableLayoutPanel3.Location = new Point(0, 0);
            tableLayoutPanel3.Margin = new Padding(4, 3, 4, 3);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 2;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 18F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel3.Size = new Size(804, 561);
            tableLayoutPanel3.TabIndex = 4;
            // 
            // PanelLista
            // 
            PanelLista.BackColor = Color.FromArgb(218, 218, 220);
            PanelLista.Controls.Add(tableLayoutPanel1);
            PanelLista.Dock = DockStyle.Fill;
            PanelLista.Location = new Point(4, 21);
            PanelLista.Margin = new Padding(4, 3, 4, 3);
            PanelLista.Name = "PanelLista";
            PanelLista.Padding = new Padding(0, 18, 0, 18);
            PanelLista.Size = new Size(313, 537);
            PanelLista.TabIndex = 3;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(LblLista, 0, 0);
            tableLayoutPanel1.Controls.Add(ListBArticulos, 0, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 18);
            tableLayoutPanel1.Margin = new Padding(4, 3, 4, 3);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 37F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(313, 501);
            tableLayoutPanel1.TabIndex = 2;
            // 
            // LblLista
            // 
            LblLista.Dock = DockStyle.Top;
            LblLista.Font = new Font("Segoe UI Black", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LblLista.ForeColor = Color.FromArgb(7, 100, 147);
            LblLista.Location = new Point(4, 0);
            LblLista.Margin = new Padding(4, 0, 4, 0);
            LblLista.Name = "LblLista";
            LblLista.Size = new Size(305, 24);
            LblLista.TabIndex = 1;
            LblLista.Text = "Lista de Actividades";
            LblLista.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // ListBArticulos
            // 
            ListBArticulos.AllowUserToAddRows = false;
            ListBArticulos.AllowUserToDeleteRows = false;
            ListBArticulos.AllowUserToResizeColumns = false;
            ListBArticulos.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            ListBArticulos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            ListBArticulos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            ListBArticulos.Columns.AddRange(new DataGridViewColumn[] { Cantidad, Fecha_Hora, Entorno, Descripcion });
            ListBArticulos.Dock = DockStyle.Fill;
            ListBArticulos.Location = new Point(4, 40);
            ListBArticulos.Margin = new Padding(4, 3, 4, 3);
            ListBArticulos.Name = "ListBArticulos";
            ListBArticulos.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Control;
            dataGridViewCellStyle2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            ListBArticulos.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            ListBArticulos.RowHeadersVisible = false;
            ListBArticulos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            ListBArticulos.Size = new Size(305, 458);
            ListBArticulos.TabIndex = 2;
            // 
            // Cantidad
            // 
            Cantidad.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            Cantidad.DataPropertyName = "Cod_Articulo";
            Cantidad.HeaderText = "CÓDIGO";
            Cantidad.Name = "Cantidad";
            Cantidad.ReadOnly = true;
            Cantidad.Visible = false;
            // 
            // Fecha_Hora
            // 
            Fecha_Hora.HeaderText = "Fecha_Hora";
            Fecha_Hora.Name = "Fecha_Hora";
            Fecha_Hora.ReadOnly = true;
            // 
            // Entorno
            // 
            Entorno.HeaderText = "Entorno";
            Entorno.Name = "Entorno";
            Entorno.ReadOnly = true;
            // 
            // Descripcion
            // 
            Descripcion.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Descripcion.DataPropertyName = "Art_Desc";
            Descripcion.HeaderText = "DESCRIPCIÓN";
            Descripcion.Name = "Descripcion";
            Descripcion.ReadOnly = true;
            // 
            // PanelMedio
            // 
            PanelMedio.Controls.Add(tableLayoutPanel4);
            PanelMedio.Dock = DockStyle.Fill;
            PanelMedio.Location = new Point(325, 21);
            PanelMedio.Margin = new Padding(4, 3, 4, 3);
            PanelMedio.Name = "PanelMedio";
            PanelMedio.Size = new Size(475, 537);
            PanelMedio.TabIndex = 2;
            // 
            // tableLayoutPanel4
            // 
            tableLayoutPanel4.BackColor = Color.FromArgb(218, 218, 220);
            tableLayoutPanel4.ColumnCount = 1;
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel4.Controls.Add(groupBox1, 0, 0);
            tableLayoutPanel4.Dock = DockStyle.Fill;
            tableLayoutPanel4.Location = new Point(0, 0);
            tableLayoutPanel4.Margin = new Padding(4, 3, 4, 3);
            tableLayoutPanel4.Name = "tableLayoutPanel4";
            tableLayoutPanel4.RowCount = 1;
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Absolute, 622F));
            tableLayoutPanel4.Size = new Size(475, 537);
            tableLayoutPanel4.TabIndex = 2;
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            groupBox1.Controls.Add(TLPForm);
            groupBox1.Font = new Font("Segoe UI Black", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox1.ForeColor = Color.FromArgb(7, 100, 147);
            groupBox1.Location = new Point(4, 28);
            groupBox1.Margin = new Padding(4, 3, 4, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(4, 3, 4, 3);
            groupBox1.Size = new Size(467, 481);
            groupBox1.TabIndex = 16;
            groupBox1.TabStop = false;
            groupBox1.Text = "Formulario de Edición de Actividades";
            // 
            // TLPForm
            // 
            TLPForm.BackColor = Color.FromArgb(249, 249, 251);
            TLPForm.ColumnCount = 3;
            TLPForm.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 27.95699F));
            TLPForm.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 59.5698929F));
            TLPForm.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.4731178F));
            TLPForm.Controls.Add(TxtDescripcion, 1, 4);
            TLPForm.Controls.Add(tableLayoutPanel2, 1, 5);
            TLPForm.Controls.Add(CMBCategoria, 1, 1);
            TLPForm.Controls.Add(CMBSubcategoria, 1, 2);
            TLPForm.Controls.Add(label5, 0, 2);
            TLPForm.Controls.Add(label3, 0, 3);
            TLPForm.Controls.Add(LblCuit, 0, 4);
            TLPForm.Controls.Add(dateTimePicker1, 1, 3);
            TLPForm.Controls.Add(label2, 0, 1);
            TLPForm.Dock = DockStyle.Fill;
            TLPForm.ForeColor = Color.FromArgb(26, 28, 30);
            TLPForm.Location = new Point(4, 29);
            TLPForm.Margin = new Padding(4, 3, 4, 3);
            TLPForm.Name = "TLPForm";
            TLPForm.RowCount = 7;
            TLPForm.RowStyles.Add(new RowStyle(SizeType.Absolute, 9F));
            TLPForm.RowStyles.Add(new RowStyle());
            TLPForm.RowStyles.Add(new RowStyle());
            TLPForm.RowStyles.Add(new RowStyle());
            TLPForm.RowStyles.Add(new RowStyle());
            TLPForm.RowStyles.Add(new RowStyle());
            TLPForm.RowStyles.Add(new RowStyle(SizeType.Absolute, 9F));
            TLPForm.Size = new Size(459, 449);
            TLPForm.TabIndex = 0;
            // 
            // TxtDescripcion
            // 
            TxtDescripcion.BackColor = Color.FromArgb(238, 237, 240);
            TxtDescripcion.Dock = DockStyle.Fill;
            TxtDescripcion.Font = new Font("Segoe UI", 12F);
            TxtDescripcion.ForeColor = Color.FromArgb(26, 28, 30);
            TxtDescripcion.Location = new Point(132, 117);
            TxtDescripcion.Margin = new Padding(4, 3, 4, 3);
            TxtDescripcion.MaxLength = 400;
            TxtDescripcion.Multiline = true;
            TxtDescripcion.Name = "TxtDescripcion";
            TxtDescripcion.Size = new Size(265, 228);
            TxtDescripcion.TabIndex = 19;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Controls.Add(BtnGuardar, 0, 0);
            tableLayoutPanel2.Controls.Add(BtnEliminar, 1, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(132, 351);
            tableLayoutPanel2.Margin = new Padding(4, 3, 4, 3);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Size = new Size(265, 58);
            tableLayoutPanel2.TabIndex = 18;
            // 
            // BtnGuardar
            // 
            BtnGuardar.Anchor = AnchorStyles.None;
            BtnGuardar.BackColor = Color.FromArgb(101, 89, 119);
            BtnGuardar.FlatAppearance.BorderColor = Color.FromArgb(203, 230, 255);
            BtnGuardar.FlatStyle = FlatStyle.Flat;
            BtnGuardar.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BtnGuardar.ForeColor = Color.FromArgb(255, 255, 255);
            BtnGuardar.Image = Properties.Resources.guardar;
            BtnGuardar.ImageAlign = ContentAlignment.MiddleRight;
            BtnGuardar.Location = new Point(0, 1);
            BtnGuardar.Margin = new Padding(0);
            BtnGuardar.Name = "BtnGuardar";
            BtnGuardar.Size = new Size(132, 55);
            BtnGuardar.TabIndex = 12;
            BtnGuardar.Text = "Guardar";
            BtnGuardar.TextAlign = ContentAlignment.MiddleRight;
            BtnGuardar.TextImageRelation = TextImageRelation.ImageBeforeText;
            BtnGuardar.UseVisualStyleBackColor = false;
            BtnGuardar.Click += BtnGuardar_Click;
            // 
            // BtnEliminar
            // 
            BtnEliminar.Anchor = AnchorStyles.None;
            BtnEliminar.BackColor = Color.FromArgb(186, 26, 26);
            BtnEliminar.FlatAppearance.BorderColor = Color.FromArgb(203, 230, 255);
            BtnEliminar.FlatStyle = FlatStyle.Flat;
            BtnEliminar.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BtnEliminar.ForeColor = Color.FromArgb(255, 255, 255);
            BtnEliminar.Image = Properties.Resources.trash;
            BtnEliminar.Location = new Point(170, 1);
            BtnEliminar.Margin = new Padding(0);
            BtnEliminar.Name = "BtnEliminar";
            BtnEliminar.Size = new Size(56, 55);
            BtnEliminar.TabIndex = 13;
            BtnEliminar.UseVisualStyleBackColor = false;
            BtnEliminar.Click += BtnEliminar_Click;
            // 
            // CMBCategoria
            // 
            CMBCategoria.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            CMBCategoria.DropDownStyle = ComboBoxStyle.DropDownList;
            CMBCategoria.Font = new Font("Segoe UI", 12F);
            CMBCategoria.FormattingEnabled = true;
            CMBCategoria.Location = new Point(132, 12);
            CMBCategoria.Margin = new Padding(4, 3, 4, 3);
            CMBCategoria.Name = "CMBCategoria";
            CMBCategoria.Size = new Size(265, 29);
            CMBCategoria.TabIndex = 10;
            // 
            // CMBSubcategoria
            // 
            CMBSubcategoria.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            CMBSubcategoria.DropDownStyle = ComboBoxStyle.DropDownList;
            CMBSubcategoria.Font = new Font("Segoe UI", 12F);
            CMBSubcategoria.FormattingEnabled = true;
            CMBSubcategoria.Location = new Point(132, 47);
            CMBSubcategoria.Margin = new Padding(4, 3, 4, 3);
            CMBSubcategoria.Name = "CMBSubcategoria";
            CMBSubcategoria.Size = new Size(265, 29);
            CMBSubcategoria.TabIndex = 11;
            CMBSubcategoria.Visible = false;
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Right;
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F);
            label5.Location = new Point(29, 51);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(95, 21);
            label5.TabIndex = 12;
            label5.Text = "SubEntorno:";
            label5.Visible = false;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F);
            label3.Location = new Point(21, 86);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(103, 21);
            label3.TabIndex = 3;
            label3.Text = "Fecha y Hora:";
            // 
            // LblCuit
            // 
            LblCuit.Anchor = AnchorStyles.Right;
            LblCuit.AutoSize = true;
            LblCuit.Font = new Font("Segoe UI", 12F);
            LblCuit.Location = new Point(30, 220);
            LblCuit.Margin = new Padding(4, 0, 4, 0);
            LblCuit.Name = "LblCuit";
            LblCuit.Size = new Size(94, 21);
            LblCuit.TabIndex = 0;
            LblCuit.Text = "Descripción:";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            dateTimePicker1.Dock = DockStyle.Fill;
            dateTimePicker1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.Location = new Point(132, 82);
            dateTimePicker1.Margin = new Padding(4, 3, 4, 3);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(265, 29);
            dateTimePicker1.TabIndex = 21;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(56, 16);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(68, 21);
            label2.TabIndex = 22;
            label2.Text = "Entorno:";
            // 
            // ProgressBar
            // 
            tableLayoutPanel3.SetColumnSpan(ProgressBar, 2);
            ProgressBar.Dock = DockStyle.Fill;
            ProgressBar.Location = new Point(0, 0);
            ProgressBar.Margin = new Padding(0);
            ProgressBar.Name = "ProgressBar";
            ProgressBar.Size = new Size(804, 18);
            ProgressBar.TabIndex = 4;
            // 
            // ucConsultaActividad
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutPanel3);
            Controls.Add(label1);
            Load += ucConsultaActividad_Load;
            Margin = new Padding(4, 3, 4, 3);
            Name = "ucConsultaActividad";
            Size = new Size(804, 561);
            tableLayoutPanel3.ResumeLayout(false);
            PanelLista.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)ListBArticulos).EndInit();
            PanelMedio.ResumeLayout(false);
            tableLayoutPanel4.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            TLPForm.ResumeLayout(false);
            TLPForm.PerformLayout();
            tableLayoutPanel2.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.Label label1;
        private TableLayoutPanel tableLayoutPanel3;
        private Panel PanelLista;
        private TableLayoutPanel tableLayoutPanel1;
        private Label LblLista;
        private DataGridView ListBArticulos;
        private Panel PanelMedio;
        private TableLayoutPanel tableLayoutPanel4;
        private GroupBox groupBox1;
        private TableLayoutPanel TLPForm;
        private Label label3;
        private Label LblCuit;
        private TableLayoutPanel tableLayoutPanel2;
        private Button BtnGuardar;
        private Button BtnEliminar;
        private ComboBox CMBCategoria;
        private TextBox TxtDescripcion;
        private ComboBox CMBSubcategoria;
        private Label label5;
        private DateTimePicker dateTimePicker1;
        private ProgressBar ProgressBar;
        #endregion

        private Label label2;
        private DataGridViewTextBoxColumn Cantidad;
        private DataGridViewTextBoxColumn Fecha_Hora;
        private DataGridViewTextBoxColumn Entorno;
        private DataGridViewTextBoxColumn Descripcion;
    }
}
