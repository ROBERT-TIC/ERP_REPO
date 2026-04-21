namespace ERP_COMPLETO
{
    partial class BASE_DE_ACUMULADOS
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.NOMBRE = new RJCodeAdvance.RJControls.RJComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.altoButton1 = new AltoControls.AltoButton();
            this.label5 = new System.Windows.Forms.Label();
            this.CLAVE = new RJCodeAdvance.RJControls.RJTextBox();
            this.tabla = new System.Windows.Forms.DataGridView();
            this.tabla2 = new System.Windows.Forms.DataGridView();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabla)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabla2)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(77)))), ((int)(((byte)(141)))));
            this.panel2.Controls.Add(this.pictureBox2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(678, 43);
            this.panel2.TabIndex = 2;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::ERP_COMPLETO.Properties.Resources.MI_ALTA_AREA;
            this.pictureBox2.Location = new System.Drawing.Point(164, 7);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(28, 28);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 14;
            this.pictureBox2.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(198, 12);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(275, 18);
            this.label1.TabIndex = 2;
            this.label1.Text = "ACUMULADOS EN BASE TÉCNICA";
            // 
            // NOMBRE
            // 
            this.NOMBRE.BackColor = System.Drawing.Color.White;
            this.NOMBRE.BorderColor = System.Drawing.Color.White;
            this.NOMBRE.BorderSize = 1;
            this.NOMBRE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.NOMBRE.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.NOMBRE.ForeColor = System.Drawing.Color.DimGray;
            this.NOMBRE.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(77)))), ((int)(((byte)(141)))));
            this.NOMBRE.Items.AddRange(new object[] {
            "CONTROL DE CALIDAD DEL CONCRETO  kgf/cm2"});
            this.NOMBRE.ListBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(228)))), ((int)(((byte)(245)))));
            this.NOMBRE.ListTextColor = System.Drawing.Color.DimGray;
            this.NOMBRE.Location = new System.Drawing.Point(34, 96);
            this.NOMBRE.MinimumSize = new System.Drawing.Size(200, 30);
            this.NOMBRE.Name = "NOMBRE";
            this.NOMBRE.Padding = new System.Windows.Forms.Padding(1);
            this.NOMBRE.Size = new System.Drawing.Size(439, 30);
            this.NOMBRE.TabIndex = 15;
            this.NOMBRE.Texts = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(77)))), ((int)(((byte)(141)))));
            this.label4.Location = new System.Drawing.Point(31, 70);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(125, 16);
            this.label4.TabIndex = 14;
            this.label4.Text = "Tipo de Acumulado";
            // 
            // altoButton1
            // 
            this.altoButton1.Active1 = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(85)))), ((int)(((byte)(0)))));
            this.altoButton1.Active2 = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(85)))), ((int)(((byte)(0)))));
            this.altoButton1.BackColor = System.Drawing.Color.Transparent;
            this.altoButton1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.altoButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.altoButton1.ForeColor = System.Drawing.Color.White;
            this.altoButton1.Inactive1 = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(92)))), ((int)(((byte)(0)))));
            this.altoButton1.Inactive2 = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(92)))), ((int)(((byte)(0)))));
            this.altoButton1.Location = new System.Drawing.Point(241, 155);
            this.altoButton1.Name = "altoButton1";
            this.altoButton1.Radius = 3;
            this.altoButton1.Size = new System.Drawing.Size(190, 30);
            this.altoButton1.Stroke = false;
            this.altoButton1.StrokeColor = System.Drawing.Color.Gray;
            this.altoButton1.TabIndex = 245;
            this.altoButton1.Text = "Agendar";
            this.altoButton1.Transparency = false;
            this.altoButton1.Click += new System.EventHandler(this.altoButton1_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(77)))), ((int)(((byte)(141)))));
            this.label5.Location = new System.Drawing.Point(482, 70);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 16);
            this.label5.TabIndex = 246;
            this.label5.Text = "Clave de Obra";
            // 
            // CLAVE
            // 
            this.CLAVE.BackColor = System.Drawing.SystemColors.Window;
            this.CLAVE.BorderColor = System.Drawing.Color.White;
            this.CLAVE.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(92)))), ((int)(((byte)(0)))));
            this.CLAVE.BorderRadius = 3;
            this.CLAVE.BorderSize = 2;
            this.CLAVE.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CLAVE.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(111)))), ((int)(((byte)(111)))));
            this.CLAVE.Location = new System.Drawing.Point(485, 96);
            this.CLAVE.Margin = new System.Windows.Forms.Padding(4);
            this.CLAVE.Multiline = true;
            this.CLAVE.Name = "CLAVE";
            this.CLAVE.Padding = new System.Windows.Forms.Padding(7, 6, 7, 3);
            this.CLAVE.PasswordChar = false;
            this.CLAVE.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.CLAVE.PlaceholderText = "";
            this.CLAVE.Size = new System.Drawing.Size(180, 30);
            this.CLAVE.TabIndex = 247;
            this.CLAVE.Texts = "";
            this.CLAVE.UnderlinedStyle = false;
            // 
            // tabla
            // 
            this.tabla.AllowUserToAddRows = false;
            this.tabla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tabla.Location = new System.Drawing.Point(378, 24);
            this.tabla.Name = "tabla";
            this.tabla.Size = new System.Drawing.Size(10, 10);
            this.tabla.TabIndex = 248;
            // 
            // tabla2
            // 
            this.tabla2.AllowUserToAddRows = false;
            this.tabla2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tabla2.Location = new System.Drawing.Point(464, 20);
            this.tabla2.Name = "tabla2";
            this.tabla2.Size = new System.Drawing.Size(10, 10);
            this.tabla2.TabIndex = 249;
            // 
            // BASE_DE_ACUMULADOS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(678, 208);
            this.Controls.Add(this.CLAVE);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.altoButton1);
            this.Controls.Add(this.NOMBRE);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.tabla);
            this.Controls.Add(this.tabla2);
            this.Name = "BASE_DE_ACUMULADOS";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BASE_DE_ACUMULADOS";
            this.Load += new System.EventHandler(this.BASE_DE_ACUMULADOS_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabla)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabla2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label1;
        private RJCodeAdvance.RJControls.RJComboBox NOMBRE;
        private System.Windows.Forms.Label label4;
        private AltoControls.AltoButton altoButton1;
        private System.Windows.Forms.Label label5;
        public RJCodeAdvance.RJControls.RJTextBox CLAVE;
        private System.Windows.Forms.DataGridView tabla;
        private System.Windows.Forms.DataGridView tabla2;
    }
}