namespace ERP_COMPLETO
{
    partial class AGENDA_CALIBRACIONES
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox11 = new System.Windows.Forms.PictureBox();
            this.label7 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.buscador = new RJCodeAdvance.RJControls.RJTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.vacacionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cursosYAcreditacionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.horafecha = new System.Windows.Forms.Timer(this.components);
            this.ET = new System.Windows.Forms.ToolTip(this.components);
            this.DGV = new Zuby.ADGV.AdvancedDataGridView();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox11)).BeginInit();
            this.panel4.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).BeginInit();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(77)))), ((int)(((byte)(141)))));
            this.panel3.Controls.Add(this.pictureBox5);
            this.panel3.Controls.Add(this.pictureBox11);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1044, 40);
            this.panel3.TabIndex = 96;
            this.panel3.Paint += new System.Windows.Forms.PaintEventHandler(this.panel3_Paint);
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = global::ERP_COMPLETO.Properties.Resources.MI_AGENDAR_OT;
            this.pictureBox5.Location = new System.Drawing.Point(370, 8);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(25, 25);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox5.TabIndex = 167;
            this.pictureBox5.TabStop = false;
            // 
            // pictureBox11
            // 
            this.pictureBox11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox11.Image = global::ERP_COMPLETO.Properties.Resources.Mi_cerrar;
            this.pictureBox11.Location = new System.Drawing.Point(1013, 7);
            this.pictureBox11.Name = "pictureBox11";
            this.pictureBox11.Size = new System.Drawing.Size(25, 25);
            this.pictureBox11.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox11.TabIndex = 166;
            this.pictureBox11.TabStop = false;
            this.pictureBox11.Click += new System.EventHandler(this.pictureBox11_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(398, 10);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(279, 20);
            this.label7.TabIndex = 87;
            this.label7.Text = "CALENDARIO DE CALIBRACIÓN";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.buscador);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Controls.Add(this.label1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 40);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1044, 41);
            this.panel4.TabIndex = 166;
            this.panel4.Paint += new System.Windows.Forms.PaintEventHandler(this.panel4_Paint);
            // 
            // buscador
            // 
            this.buscador.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buscador.BackColor = System.Drawing.Color.White;
            this.buscador.BorderColor = System.Drawing.Color.White;
            this.buscador.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(92)))), ((int)(((byte)(0)))));
            this.buscador.BorderRadius = 3;
            this.buscador.BorderSize = 2;
            this.buscador.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buscador.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(149)))), ((int)(((byte)(149)))));
            this.buscador.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.buscador.Location = new System.Drawing.Point(755, 6);
            this.buscador.Margin = new System.Windows.Forms.Padding(4);
            this.buscador.Multiline = false;
            this.buscador.Name = "buscador";
            this.buscador.Padding = new System.Windows.Forms.Padding(10, 5, 5, 5);
            this.buscador.PasswordChar = false;
            this.buscador.PlaceholderColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(149)))), ((int)(((byte)(149)))));
            this.buscador.PlaceholderText = "";
            this.buscador.Size = new System.Drawing.Size(258, 27);
            this.buscador.TabIndex = 290;
            this.buscador.Texts = "";
            this.buscador.UnderlinedStyle = false;
            this.buscador._TextChanged += new System.EventHandler(this.buscador__TextChanged);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(77)))), ((int)(((byte)(141)))));
            this.label4.Location = new System.Drawing.Point(679, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 16);
            this.label4.TabIndex = 289;
            this.label4.Text = "Busqueda";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(77)))), ((int)(((byte)(141)))));
            this.label2.Location = new System.Drawing.Point(71, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 16);
            this.label2.TabIndex = 190;
            this.label2.Text = "000-00-00";
            this.label2.Click += new System.EventHandler(this.label2_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(77)))), ((int)(((byte)(141)))));
            this.label1.Location = new System.Drawing.Point(27, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 16);
            this.label1.TabIndex = 96;
            this.label1.Text = "Fecha:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(77)))), ((int)(((byte)(141)))));
            this.label3.Location = new System.Drawing.Point(581, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(432, 13);
            this.label3.TabIndex = 189;
            this.label3.Text = "Dar doble clic en una fecha para consultar actividades y clic derecho para filtra" +
    "r opciones.";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(77)))), ((int)(((byte)(141)))));
            this.contextMenuStrip1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.vacacionesToolStripMenuItem,
            this.cursosYAcreditacionesToolStripMenuItem});
            this.contextMenuStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.contextMenuStrip1.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.contextMenuStrip1.ShowImageMargin = false;
            this.contextMenuStrip1.Size = new System.Drawing.Size(180, 70);
            this.contextMenuStrip1.Text = "Opciones";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.CheckOnClick = true;
            this.toolStripMenuItem1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripMenuItem1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.toolStripMenuItem1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(179, 22);
            this.toolStripMenuItem1.Text = "Calibraciones No realizadas";
            this.toolStripMenuItem1.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // vacacionesToolStripMenuItem
            // 
            this.vacacionesToolStripMenuItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vacacionesToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.vacacionesToolStripMenuItem.Name = "vacacionesToolStripMenuItem";
            this.vacacionesToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.vacacionesToolStripMenuItem.Text = "Calibraciones Realizadas";
            this.vacacionesToolStripMenuItem.Click += new System.EventHandler(this.vacacionesToolStripMenuItem_Click);
            // 
            // cursosYAcreditacionesToolStripMenuItem
            // 
            this.cursosYAcreditacionesToolStripMenuItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cursosYAcreditacionesToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.cursosYAcreditacionesToolStripMenuItem.Name = "cursosYAcreditacionesToolStripMenuItem";
            this.cursosYAcreditacionesToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.cursosYAcreditacionesToolStripMenuItem.Text = "Todas las Calibraciones";
            this.cursosYAcreditacionesToolStripMenuItem.Click += new System.EventHandler(this.cursosYAcreditacionesToolStripMenuItem_Click);
            // 
            // horafecha
            // 
            this.horafecha.Enabled = true;
            this.horafecha.Tick += new System.EventHandler(this.horafecha_Tick);
            // 
            // ET
            // 
            this.ET.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ET.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(77)))), ((int)(((byte)(141)))));
            this.ET.IsBalloon = true;
            // 
            // DGV
            // 
            this.DGV.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGV.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGV.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.DGV.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DGV.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(92)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGV.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV.ContextMenuStrip = this.contextMenuStrip1;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGV.DefaultCellStyle = dataGridViewCellStyle3;
            this.DGV.EnableHeadersVisualStyles = false;
            this.DGV.FilterAndSortEnabled = true;
            this.DGV.FilterStringChangedInvokeBeforeDatasourceUpdate = true;
            this.DGV.Location = new System.Drawing.Point(30, 96);
            this.DGV.Name = "DGV";
            this.DGV.RightToLeft = System.Windows.Forms.RightToLeft.No;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGV.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.DGV.RowTemplate.DividerHeight = 5;
            this.DGV.RowTemplate.Height = 50;
            this.DGV.RowTemplate.ReadOnly = true;
            this.DGV.Size = new System.Drawing.Size(981, 450);
            this.DGV.SortStringChangedInvokeBeforeDatasourceUpdate = true;
            this.DGV.TabIndex = 291;
            this.DGV.DoubleClick += new System.EventHandler(this.advancedDataGridView1_DoubleClick);
            // 
            // AGENDA_CALIBRACIONES
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(1044, 576);
            this.Controls.Add(this.DGV);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AGENDA_CALIBRACIONES";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AGENDA_CALIBRACIONES";
            this.Load += new System.EventHandler(this.AGENDA_CALIBRACIONES_Load);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox11)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        public System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.PictureBox pictureBox11;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label label3;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem vacacionesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cursosYAcreditacionesToolStripMenuItem;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer horafecha;
        private System.Windows.Forms.ToolTip ET;
        public RJCodeAdvance.RJControls.RJTextBox buscador;
        public System.Windows.Forms.Label label4;
        public Zuby.ADGV.AdvancedDataGridView DGV;
    }
}