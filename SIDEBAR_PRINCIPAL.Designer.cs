namespace ERP_COMPLETO
{
    partial class SIDEBAR_PRINCIPAL_NOT
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
            this.titulo_noti = new System.Windows.Forms.Panel();
            this.tabla = new System.Windows.Forms.DataGridView();
            this.bunifuImageButton19 = new Bunifu.Framework.UI.BunifuImageButton();
            this.NT6 = new Bunifu.Framework.UI.BunifuCheckbox();
            this.label27 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel_n = new System.Windows.Forms.Panel();
            this.titulo_noti.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabla)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bunifuImageButton19)).BeginInit();
            this.SuspendLayout();
            // 
            // titulo_noti
            // 
            this.titulo_noti.Controls.Add(this.tabla);
            this.titulo_noti.Controls.Add(this.bunifuImageButton19);
            this.titulo_noti.Controls.Add(this.NT6);
            this.titulo_noti.Controls.Add(this.label27);
            this.titulo_noti.Controls.Add(this.label3);
            this.titulo_noti.Dock = System.Windows.Forms.DockStyle.Top;
            this.titulo_noti.Location = new System.Drawing.Point(0, 0);
            this.titulo_noti.Name = "titulo_noti";
            this.titulo_noti.Size = new System.Drawing.Size(336, 106);
            this.titulo_noti.TabIndex = 6;
            // 
            // tabla
            // 
            this.tabla.AllowUserToAddRows = false;
            this.tabla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tabla.Location = new System.Drawing.Point(232, -24);
            this.tabla.Name = "tabla";
            this.tabla.Size = new System.Drawing.Size(10, 10);
            this.tabla.TabIndex = 0;
            // 
            // bunifuImageButton19
            // 
            this.bunifuImageButton19.BackColor = System.Drawing.Color.Transparent;
            this.bunifuImageButton19.Image = global::ERP_COMPLETO.Properties.Resources.Mi_bote_basura2;
            this.bunifuImageButton19.ImageActive = null;
            this.bunifuImageButton19.Location = new System.Drawing.Point(269, 58);
            this.bunifuImageButton19.Name = "bunifuImageButton19";
            this.bunifuImageButton19.Size = new System.Drawing.Size(15, 15);
            this.bunifuImageButton19.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.bunifuImageButton19.TabIndex = 266;
            this.bunifuImageButton19.TabStop = false;
            this.bunifuImageButton19.Zoom = 10;
            this.bunifuImageButton19.Click += new System.EventHandler(this.bunifuImageButton19_Click);
            // 
            // NT6
            // 
            this.NT6.BackColor = System.Drawing.Color.White;
            this.NT6.ChechedOffColor = System.Drawing.Color.White;
            this.NT6.Checked = false;
            this.NT6.CheckedOnColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(90)))), ((int)(((byte)(0)))));
            this.NT6.ForeColor = System.Drawing.Color.White;
            this.NT6.Location = new System.Drawing.Point(27, 56);
            this.NT6.Name = "NT6";
            this.NT6.Size = new System.Drawing.Size(20, 20);
            this.NT6.TabIndex = 265;
            this.NT6.OnChange += new System.EventHandler(this.NT6_OnChange);
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.BackColor = System.Drawing.Color.Transparent;
            this.label27.Font = new System.Drawing.Font("Poppins", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.ForeColor = System.Drawing.Color.White;
            this.label27.Location = new System.Drawing.Point(52, 55);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(151, 26);
            this.label27.TabIndex = 264;
            this.label27.Text = "Seleccionar Todas";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Poppins", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(0, 15);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.label3.Size = new System.Drawing.Size(129, 26);
            this.label3.TabIndex = 2;
            this.label3.Text = "Notificaciones";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panel_n
            // 
            this.panel_n.AutoScroll = true;
            this.panel_n.AutoScrollMargin = new System.Drawing.Size(0, 10);
            this.panel_n.AutoScrollMinSize = new System.Drawing.Size(0, 10);
            this.panel_n.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(77)))), ((int)(((byte)(141)))));
            this.panel_n.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_n.Location = new System.Drawing.Point(0, 106);
            this.panel_n.Name = "panel_n";
            this.panel_n.Size = new System.Drawing.Size(336, 631);
            this.panel_n.TabIndex = 5;
            this.panel_n.Paint += new System.Windows.Forms.PaintEventHandler(this.panel_n_Paint);
            // 
            // SIDEBAR_PRINCIPAL_NOT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(77)))), ((int)(((byte)(141)))));
            this.ClientSize = new System.Drawing.Size(336, 737);
            this.Controls.Add(this.panel_n);
            this.Controls.Add(this.titulo_noti);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SIDEBAR_PRINCIPAL_NOT";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SIDEBAR_PRINCIPAL";
            this.Load += new System.EventHandler(this.SIDEBAR_PRINCIPAL_NOT_Load);
            this.titulo_noti.ResumeLayout(false);
            this.titulo_noti.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabla)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bunifuImageButton19)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel titulo_noti;
        private Bunifu.Framework.UI.BunifuImageButton bunifuImageButton19;
        private Bunifu.Framework.UI.BunifuCheckbox NT6;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel_n;
        private System.Windows.Forms.DataGridView tabla;
    }
}