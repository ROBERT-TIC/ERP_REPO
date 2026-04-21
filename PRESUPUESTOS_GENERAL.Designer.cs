namespace ERP_COMPLETO
{
    partial class PRESUPUESTOS_GENERAL
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
            this.panel_titulo = new System.Windows.Forms.Panel();
            this.icono = new System.Windows.Forms.PictureBox();
            this.titulo = new System.Windows.Forms.Label();
            this.panel_azul = new System.Windows.Forms.Panel();
            this.ag1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.mes = new RJCodeAdvance.RJControls.RJComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.año = new RJCodeAdvance.RJControls.RJComboBox();
            this.btn_consultar = new AltoControls.AltoButton();
            this.lbl_Proyecto = new System.Windows.Forms.Label();
            this.DGV_EVENTOS = new Zuby.ADGV.AdvancedDataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.imprimirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel_titulo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.icono)).BeginInit();
            this.panel_azul.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ag1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_EVENTOS)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_titulo
            // 
            this.panel_titulo.Controls.Add(this.icono);
            this.panel_titulo.Controls.Add(this.titulo);
            this.panel_titulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_titulo.Location = new System.Drawing.Point(0, 0);
            this.panel_titulo.Name = "panel_titulo";
            this.panel_titulo.Size = new System.Drawing.Size(1039, 43);
            this.panel_titulo.TabIndex = 168;
            // 
            // icono
            // 
            this.icono.Image = global::ERP_COMPLETO.Properties.Resources.MI_REG_PRESU2;
            this.icono.Location = new System.Drawing.Point(368, 7);
            this.icono.Name = "icono";
            this.icono.Size = new System.Drawing.Size(30, 30);
            this.icono.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.icono.TabIndex = 211;
            this.icono.TabStop = false;
            // 
            // titulo
            // 
            this.titulo.AutoSize = true;
            this.titulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(77)))), ((int)(((byte)(141)))));
            this.titulo.Location = new System.Drawing.Point(404, 12);
            this.titulo.Name = "titulo";
            this.titulo.Size = new System.Drawing.Size(271, 18);
            this.titulo.TabIndex = 0;
            this.titulo.Text = "CONSULTA DE  PRESUPUESTOS";
            this.titulo.Click += new System.EventHandler(this.titulo_Click);
            // 
            // panel_azul
            // 
            this.panel_azul.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(77)))), ((int)(((byte)(141)))));
            this.panel_azul.Controls.Add(this.ag1);
            this.panel_azul.Controls.Add(this.label2);
            this.panel_azul.Controls.Add(this.mes);
            this.panel_azul.Controls.Add(this.label1);
            this.panel_azul.Controls.Add(this.año);
            this.panel_azul.Controls.Add(this.btn_consultar);
            this.panel_azul.Controls.Add(this.lbl_Proyecto);
            this.panel_azul.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_azul.Location = new System.Drawing.Point(0, 43);
            this.panel_azul.Name = "panel_azul";
            this.panel_azul.Size = new System.Drawing.Size(1039, 50);
            this.panel_azul.TabIndex = 169;
            // 
            // ag1
            // 
            this.ag1.BackColor = System.Drawing.Color.Transparent;
            this.ag1.Image = global::ERP_COMPLETO.Properties.Resources.MI_AGREGAR;
            this.ag1.InitialImage = null;
            this.ag1.Location = new System.Drawing.Point(989, 13);
            this.ag1.Name = "ag1";
            this.ag1.Size = new System.Drawing.Size(25, 25);
            this.ag1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ag1.TabIndex = 256;
            this.ag1.TabStop = false;
            this.ag1.Click += new System.EventHandler(this.ag1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(858, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 16);
            this.label2.TabIndex = 255;
            this.label2.Text = "Nuevo Presupuesto";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // mes
            // 
            this.mes.BackColor = System.Drawing.Color.White;
            this.mes.BorderColor = System.Drawing.Color.Transparent;
            this.mes.BorderSize = 0;
            this.mes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.mes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.mes.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(77)))), ((int)(((byte)(141)))));
            this.mes.Items.AddRange(new object[] {
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12"});
            this.mes.ListBackColor = System.Drawing.Color.White;
            this.mes.ListTextColor = System.Drawing.Color.DimGray;
            this.mes.Location = new System.Drawing.Point(246, 10);
            this.mes.MinimumSize = new System.Drawing.Size(100, 25);
            this.mes.Name = "mes";
            this.mes.Size = new System.Drawing.Size(121, 28);
            this.mes.TabIndex = 254;
            this.mes.Texts = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(209, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 16);
            this.label1.TabIndex = 253;
            this.label1.Text = "Mes";
            // 
            // año
            // 
            this.año.BackColor = System.Drawing.Color.White;
            this.año.BorderColor = System.Drawing.Color.Transparent;
            this.año.BorderSize = 0;
            this.año.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.año.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.año.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.año.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(77)))), ((int)(((byte)(141)))));
            this.año.Items.AddRange(new object[] {
            "2023",
            "2024",
            "2025"});
            this.año.ListBackColor = System.Drawing.Color.White;
            this.año.ListTextColor = System.Drawing.Color.DimGray;
            this.año.Location = new System.Drawing.Point(78, 10);
            this.año.MinimumSize = new System.Drawing.Size(100, 25);
            this.año.Name = "año";
            this.año.Size = new System.Drawing.Size(121, 28);
            this.año.TabIndex = 252;
            this.año.Texts = "2024";
            // 
            // btn_consultar
            // 
            this.btn_consultar.Active1 = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(85)))), ((int)(((byte)(0)))));
            this.btn_consultar.Active2 = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(85)))), ((int)(((byte)(0)))));
            this.btn_consultar.BackColor = System.Drawing.Color.Transparent;
            this.btn_consultar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btn_consultar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_consultar.ForeColor = System.Drawing.Color.White;
            this.btn_consultar.Inactive1 = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(92)))), ((int)(((byte)(0)))));
            this.btn_consultar.Inactive2 = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(92)))), ((int)(((byte)(0)))));
            this.btn_consultar.Location = new System.Drawing.Point(385, 10);
            this.btn_consultar.Name = "btn_consultar";
            this.btn_consultar.Radius = 3;
            this.btn_consultar.Size = new System.Drawing.Size(146, 30);
            this.btn_consultar.Stroke = false;
            this.btn_consultar.StrokeColor = System.Drawing.Color.Gray;
            this.btn_consultar.TabIndex = 160;
            this.btn_consultar.Text = "Consultar";
            this.btn_consultar.Transparency = false;
            this.btn_consultar.Click += new System.EventHandler(this.btn_consultar_Click);
            // 
            // lbl_Proyecto
            // 
            this.lbl_Proyecto.AutoSize = true;
            this.lbl_Proyecto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Proyecto.ForeColor = System.Drawing.Color.White;
            this.lbl_Proyecto.Location = new System.Drawing.Point(41, 15);
            this.lbl_Proyecto.Name = "lbl_Proyecto";
            this.lbl_Proyecto.Size = new System.Drawing.Size(31, 16);
            this.lbl_Proyecto.TabIndex = 155;
            this.lbl_Proyecto.Text = "Año";
            // 
            // DGV_EVENTOS
            // 
            this.DGV_EVENTOS.AllowUserToAddRows = false;
            this.DGV_EVENTOS.AllowUserToDeleteRows = false;
            this.DGV_EVENTOS.AllowUserToOrderColumns = true;
            this.DGV_EVENTOS.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DGV_EVENTOS.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGV_EVENTOS.BackgroundColor = System.Drawing.Color.White;
            this.DGV_EVENTOS.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DGV_EVENTOS.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(92)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGV_EVENTOS.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DGV_EVENTOS.ColumnHeadersHeight = 40;
            this.DGV_EVENTOS.ContextMenuStrip = this.contextMenuStrip1;
            this.DGV_EVENTOS.Cursor = System.Windows.Forms.Cursors.Default;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGV_EVENTOS.DefaultCellStyle = dataGridViewCellStyle2;
            this.DGV_EVENTOS.EnableHeadersVisualStyles = false;
            this.DGV_EVENTOS.FilterAndSortEnabled = true;
            this.DGV_EVENTOS.FilterStringChangedInvokeBeforeDatasourceUpdate = false;
            this.DGV_EVENTOS.GridColor = System.Drawing.Color.Gainsboro;
            this.DGV_EVENTOS.Location = new System.Drawing.Point(43, 127);
            this.DGV_EVENTOS.Name = "DGV_EVENTOS";
            this.DGV_EVENTOS.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.DGV_EVENTOS.RowHeadersVisible = false;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(149)))), ((int)(((byte)(149)))));
            this.DGV_EVENTOS.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.DGV_EVENTOS.RowTemplate.Height = 70;
            this.DGV_EVENTOS.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGV_EVENTOS.Size = new System.Drawing.Size(955, 585);
            this.DGV_EVENTOS.SortStringChangedInvokeBeforeDatasourceUpdate = false;
            this.DGV_EVENTOS.TabIndex = 195;
            this.DGV_EVENTOS.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_EVENTOS_CellContentClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(77)))), ((int)(((byte)(141)))));
            this.contextMenuStrip1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.imprimirToolStripMenuItem});
            this.contextMenuStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.contextMenuStrip1.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.contextMenuStrip1.ShowImageMargin = false;
            this.contextMenuStrip1.Size = new System.Drawing.Size(106, 26);
            this.contextMenuStrip1.Text = "Opciones";
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // imprimirToolStripMenuItem
            // 
            this.imprimirToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.imprimirToolStripMenuItem.Name = "imprimirToolStripMenuItem";
            this.imprimirToolStripMenuItem.Size = new System.Drawing.Size(105, 22);
            this.imprimirToolStripMenuItem.Text = "Consultar";
            this.imprimirToolStripMenuItem.Click += new System.EventHandler(this.imprimirToolStripMenuItem_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // PRESUPUESTOS_GENERAL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(1039, 747);
            this.Controls.Add(this.DGV_EVENTOS);
            this.Controls.Add(this.panel_azul);
            this.Controls.Add(this.panel_titulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PRESUPUESTOS_GENERAL";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PRESUPUESTOS_GENERAL";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.PRESUPUESTOS_GENERAL_Load);
            this.panel_titulo.ResumeLayout(false);
            this.panel_titulo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.icono)).EndInit();
            this.panel_azul.ResumeLayout(false);
            this.panel_azul.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ag1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_EVENTOS)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel_titulo;
        private System.Windows.Forms.PictureBox icono;
        public System.Windows.Forms.Label titulo;
        private System.Windows.Forms.Panel panel_azul;
        private AltoControls.AltoButton btn_consultar;
        private System.Windows.Forms.Label lbl_Proyecto;
        private RJCodeAdvance.RJControls.RJComboBox mes;
        private System.Windows.Forms.Label label1;
        private RJCodeAdvance.RJControls.RJComboBox año;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.PictureBox ag1;
        private Zuby.ADGV.AdvancedDataGridView DGV_EVENTOS;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem imprimirToolStripMenuItem;
        public System.Windows.Forms.Timer timer1;
    }
}