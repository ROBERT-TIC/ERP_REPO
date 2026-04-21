namespace ERP_COMPLETO
{
    partial class CONCEPTOS_BASE_PRESUPUESTO
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel_titulo = new System.Windows.Forms.Panel();
            this.icono = new System.Windows.Forms.PictureBox();
            this.titulo = new System.Windows.Forms.Label();
            this.DGV = new System.Windows.Forms.DataGridView();
            this.ID_SEGUMIENTO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CONCEPTO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OBSERVACIONES = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SUBTOTAL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AUTORIZAR = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ag1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.PANEL_DINERO = new System.Windows.Forms.Panel();
            this.label45 = new System.Windows.Forms.Label();
            this.pagar = new WindowsFormsControlLibrary1.BunifuCustomTextbox();
            this.label34 = new System.Windows.Forms.Label();
            this.panel_titulo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.icono)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ag1)).BeginInit();
            this.PANEL_DINERO.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_titulo
            // 
            this.panel_titulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(77)))), ((int)(((byte)(141)))));
            this.panel_titulo.Controls.Add(this.icono);
            this.panel_titulo.Controls.Add(this.titulo);
            this.panel_titulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_titulo.Location = new System.Drawing.Point(0, 0);
            this.panel_titulo.Name = "panel_titulo";
            this.panel_titulo.Size = new System.Drawing.Size(1053, 43);
            this.panel_titulo.TabIndex = 169;
            // 
            // icono
            // 
            this.icono.Image = global::ERP_COMPLETO.Properties.Resources.MI_REG_PRESU;
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
            this.titulo.ForeColor = System.Drawing.Color.White;
            this.titulo.Location = new System.Drawing.Point(404, 12);
            this.titulo.Name = "titulo";
            this.titulo.Size = new System.Drawing.Size(305, 18);
            this.titulo.TabIndex = 0;
            this.titulo.Text = "CLASIFICACIÓN  DE PRESUPUESTOS";
            this.titulo.Click += new System.EventHandler(this.titulo_Click);
            // 
            // DGV
            // 
            this.DGV.AllowUserToAddRows = false;
            this.DGV.AllowUserToDeleteRows = false;
            this.DGV.AllowUserToOrderColumns = true;
            this.DGV.AllowUserToResizeRows = false;
            this.DGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGV.BackgroundColor = System.Drawing.Color.White;
            this.DGV.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DGV.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(92)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGV.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID_SEGUMIENTO,
            this.CONCEPTO,
            this.OBSERVACIONES,
            this.SUBTOTAL,
            this.AUTORIZAR});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            dataGridViewCellStyle4.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.ControlDarkDark;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGV.DefaultCellStyle = dataGridViewCellStyle4;
            this.DGV.EnableHeadersVisualStyles = false;
            this.DGV.GridColor = System.Drawing.Color.Gainsboro;
            this.DGV.Location = new System.Drawing.Point(42, 87);
            this.DGV.Name = "DGV";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGV.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.DGV.RowHeadersVisible = false;
            this.DGV.RowHeadersWidth = 45;
            this.DGV.RowTemplate.Height = 60;
            this.DGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGV.Size = new System.Drawing.Size(983, 384);
            this.DGV.TabIndex = 334;
            this.DGV.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_CellContentClick);
            this.DGV.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_CellEndEdit);
            this.DGV.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.DGV_UserDeletingRow);
            this.DGV.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DGV_KeyDown);
            // 
            // ID_SEGUMIENTO
            // 
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ID_SEGUMIENTO.DefaultCellStyle = dataGridViewCellStyle2;
            this.ID_SEGUMIENTO.FillWeight = 78.86345F;
            this.ID_SEGUMIENTO.HeaderText = "Id";
            this.ID_SEGUMIENTO.Name = "ID_SEGUMIENTO";
            this.ID_SEGUMIENTO.ReadOnly = true;
            // 
            // CONCEPTO
            // 
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.CONCEPTO.DefaultCellStyle = dataGridViewCellStyle3;
            this.CONCEPTO.FillWeight = 394.3172F;
            this.CONCEPTO.HeaderText = "Concepto";
            this.CONCEPTO.Name = "CONCEPTO";
            // 
            // OBSERVACIONES
            // 
            this.OBSERVACIONES.FillWeight = 228.4264F;
            this.OBSERVACIONES.HeaderText = "Comentarios";
            this.OBSERVACIONES.Name = "OBSERVACIONES";
            // 
            // SUBTOTAL
            // 
            this.SUBTOTAL.FillWeight = 119.5295F;
            this.SUBTOTAL.HeaderText = "Sub Total";
            this.SUBTOTAL.Name = "SUBTOTAL";
            this.SUBTOTAL.ReadOnly = true;
            // 
            // AUTORIZAR
            // 
            this.AUTORIZAR.FillWeight = 78.86345F;
            this.AUTORIZAR.HeaderText = "";
            this.AUTORIZAR.Name = "AUTORIZAR";
            this.AUTORIZAR.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.AUTORIZAR.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // ag1
            // 
            this.ag1.BackColor = System.Drawing.Color.Transparent;
            this.ag1.Image = global::ERP_COMPLETO.Properties.Resources.MI_AGRRGA_DINAMICO;
            this.ag1.InitialImage = null;
            this.ag1.Location = new System.Drawing.Point(994, 53);
            this.ag1.Name = "ag1";
            this.ag1.Size = new System.Drawing.Size(25, 25);
            this.ag1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ag1.TabIndex = 336;
            this.ag1.TabStop = false;
            this.ag1.Click += new System.EventHandler(this.ag1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(77)))), ((int)(((byte)(141)))));
            this.label2.Location = new System.Drawing.Point(866, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 16);
            this.label2.TabIndex = 335;
            this.label2.Text = "Nueva Clasificación";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // PANEL_DINERO
            // 
            this.PANEL_DINERO.BackColor = System.Drawing.Color.White;
            this.PANEL_DINERO.Controls.Add(this.label45);
            this.PANEL_DINERO.Controls.Add(this.pagar);
            this.PANEL_DINERO.Controls.Add(this.label34);
            this.PANEL_DINERO.Location = new System.Drawing.Point(817, 487);
            this.PANEL_DINERO.Name = "PANEL_DINERO";
            this.PANEL_DINERO.Size = new System.Drawing.Size(208, 42);
            this.PANEL_DINERO.TabIndex = 337;
            // 
            // label45
            // 
            this.label45.AutoSize = true;
            this.label45.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label45.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(77)))), ((int)(((byte)(141)))));
            this.label45.Location = new System.Drawing.Point(58, 11);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(15, 15);
            this.label45.TabIndex = 158;
            this.label45.Text = "$";
            // 
            // pagar
            // 
            this.pagar.BackColor = System.Drawing.Color.White;
            this.pagar.BorderColor = System.Drawing.Color.OrangeRed;
            this.pagar.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.pagar.Enabled = false;
            this.pagar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pagar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(77)))), ((int)(((byte)(141)))));
            this.pagar.Location = new System.Drawing.Point(66, 11);
            this.pagar.Multiline = true;
            this.pagar.Name = "pagar";
            this.pagar.Size = new System.Drawing.Size(133, 19);
            this.pagar.TabIndex = 56;
            this.pagar.Text = "00.00";
            this.pagar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label34.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(77)))), ((int)(((byte)(141)))));
            this.label34.Location = new System.Drawing.Point(9, 11);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(43, 15);
            this.label34.TabIndex = 155;
            this.label34.Text = "Total ";
            // 
            // CONCEPTOS_BASE_PRESUPUESTO
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(1053, 569);
            this.Controls.Add(this.PANEL_DINERO);
            this.Controls.Add(this.ag1);
            this.Controls.Add(this.DGV);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel_titulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "CONCEPTOS_BASE_PRESUPUESTO";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CONCEPTOS_BASE_PRESUPUESTO";
            this.Load += new System.EventHandler(this.CONCEPTOS_BASE_PRESUPUESTO_Load);
            this.panel_titulo.ResumeLayout(false);
            this.panel_titulo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.icono)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ag1)).EndInit();
            this.PANEL_DINERO.ResumeLayout(false);
            this.PANEL_DINERO.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel_titulo;
        private System.Windows.Forms.PictureBox icono;
        public System.Windows.Forms.Label titulo;
        public System.Windows.Forms.DataGridView DGV;
        public System.Windows.Forms.PictureBox ag1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel PANEL_DINERO;
        private System.Windows.Forms.Label label45;
        public WindowsFormsControlLibrary1.BunifuCustomTextbox pagar;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID_SEGUMIENTO;
        private System.Windows.Forms.DataGridViewTextBoxColumn CONCEPTO;
        private System.Windows.Forms.DataGridViewTextBoxColumn OBSERVACIONES;
        private System.Windows.Forms.DataGridViewTextBoxColumn SUBTOTAL;
        private System.Windows.Forms.DataGridViewButtonColumn AUTORIZAR;
    }
}