namespace ERP_COMPLETO
{
    partial class ALTA_PRESUPUESTO
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
            this.panel_titulo = new System.Windows.Forms.Panel();
            this.icono = new System.Windows.Forms.PictureBox();
            this.titulo = new System.Windows.Forms.Label();
            this.rubro = new RJCodeAdvance.RJControls.RJComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.RUBRO_ETIQUETA = new RJCodeAdvance.RJControls.RJTextBox();
            this.TIPO = new RJCodeAdvance.RJControls.RJTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.b1 = new AltoControls.AltoButton();
            this.b2 = new AltoControls.AltoButton();
            this.label4 = new System.Windows.Forms.Label();
            this.bunifuSeparator1 = new Bunifu.Framework.UI.BunifuSeparator();
            this.altoButton2 = new AltoControls.AltoButton();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.labelmes = new System.Windows.Forms.Label();
            this.labelaño = new System.Windows.Forms.Label();
            this.panel_titulo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.icono)).BeginInit();
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
            this.panel_titulo.Size = new System.Drawing.Size(636, 43);
            this.panel_titulo.TabIndex = 170;
            // 
            // icono
            // 
            this.icono.Image = global::ERP_COMPLETO.Properties.Resources.MI_REG_PRESU;
            this.icono.Location = new System.Drawing.Point(154, 6);
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
            this.titulo.Location = new System.Drawing.Point(190, 11);
            this.titulo.Name = "titulo";
            this.titulo.Size = new System.Drawing.Size(332, 18);
            this.titulo.TabIndex = 0;
            this.titulo.Text = "REGISTRO DE RUBRO A PRESUPUESTO";
            // 
            // rubro
            // 
            this.rubro.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.rubro.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.rubro.BackColor = System.Drawing.Color.White;
            this.rubro.BorderColor = System.Drawing.Color.Transparent;
            this.rubro.BorderSize = 0;
            this.rubro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.rubro.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rubro.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.rubro.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(77)))), ((int)(((byte)(141)))));
            this.rubro.Items.AddRange(new object[] {
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
            this.rubro.ListBackColor = System.Drawing.Color.White;
            this.rubro.ListTextColor = System.Drawing.Color.DimGray;
            this.rubro.Location = new System.Drawing.Point(12, 214);
            this.rubro.MinimumSize = new System.Drawing.Size(100, 25);
            this.rubro.Name = "rubro";
            this.rubro.Size = new System.Drawing.Size(596, 28);
            this.rubro.TabIndex = 260;
            this.rubro.Texts = "";
            this.rubro.OnSelectedIndexChanged += new System.EventHandler(this.rubro_OnSelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(77)))), ((int)(((byte)(141)))));
            this.label3.Location = new System.Drawing.Point(9, 193);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 16);
            this.label3.TabIndex = 259;
            this.label3.Text = "Rubro / Área";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(77)))), ((int)(((byte)(141)))));
            this.label1.Location = new System.Drawing.Point(9, 248);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 16);
            this.label1.TabIndex = 261;
            this.label1.Text = "Etiqueta";
            // 
            // RUBRO_ETIQUETA
            // 
            this.RUBRO_ETIQUETA.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RUBRO_ETIQUETA.BackColor = System.Drawing.Color.White;
            this.RUBRO_ETIQUETA.BorderColor = System.Drawing.Color.Transparent;
            this.RUBRO_ETIQUETA.BorderFocusColor = System.Drawing.Color.Transparent;
            this.RUBRO_ETIQUETA.BorderRadius = 5;
            this.RUBRO_ETIQUETA.BorderSize = 2;
            this.RUBRO_ETIQUETA.Enabled = false;
            this.RUBRO_ETIQUETA.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RUBRO_ETIQUETA.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.RUBRO_ETIQUETA.Location = new System.Drawing.Point(12, 268);
            this.RUBRO_ETIQUETA.Margin = new System.Windows.Forms.Padding(4);
            this.RUBRO_ETIQUETA.Multiline = true;
            this.RUBRO_ETIQUETA.Name = "RUBRO_ETIQUETA";
            this.RUBRO_ETIQUETA.Padding = new System.Windows.Forms.Padding(10, 9, 10, 7);
            this.RUBRO_ETIQUETA.PasswordChar = false;
            this.RUBRO_ETIQUETA.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.RUBRO_ETIQUETA.PlaceholderText = "";
            this.RUBRO_ETIQUETA.Size = new System.Drawing.Size(150, 35);
            this.RUBRO_ETIQUETA.TabIndex = 262;
            this.RUBRO_ETIQUETA.Texts = "";
            this.RUBRO_ETIQUETA.UnderlinedStyle = false;
            // 
            // TIPO
            // 
            this.TIPO.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TIPO.BackColor = System.Drawing.Color.White;
            this.TIPO.BorderColor = System.Drawing.Color.Transparent;
            this.TIPO.BorderFocusColor = System.Drawing.Color.Transparent;
            this.TIPO.BorderRadius = 5;
            this.TIPO.BorderSize = 2;
            this.TIPO.Enabled = false;
            this.TIPO.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TIPO.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.TIPO.Location = new System.Drawing.Point(194, 268);
            this.TIPO.Margin = new System.Windows.Forms.Padding(4);
            this.TIPO.Multiline = true;
            this.TIPO.Name = "TIPO";
            this.TIPO.Padding = new System.Windows.Forms.Padding(10, 9, 10, 7);
            this.TIPO.PasswordChar = false;
            this.TIPO.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.TIPO.PlaceholderText = "";
            this.TIPO.Size = new System.Drawing.Size(414, 35);
            this.TIPO.TabIndex = 264;
            this.TIPO.Texts = "";
            this.TIPO.UnderlinedStyle = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(77)))), ((int)(((byte)(141)))));
            this.label2.Location = new System.Drawing.Point(191, 248);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 16);
            this.label2.TabIndex = 263;
            this.label2.Text = "Tipo";
            // 
            // b1
            // 
            this.b1.Active1 = System.Drawing.Color.Gray;
            this.b1.Active2 = System.Drawing.Color.Gray;
            this.b1.BackColor = System.Drawing.Color.Transparent;
            this.b1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.b1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.b1.ForeColor = System.Drawing.Color.White;
            this.b1.Inactive1 = System.Drawing.Color.Gray;
            this.b1.Inactive2 = System.Drawing.Color.Gray;
            this.b1.Location = new System.Drawing.Point(128, 126);
            this.b1.Name = "b1";
            this.b1.Radius = 3;
            this.b1.Size = new System.Drawing.Size(146, 30);
            this.b1.Stroke = false;
            this.b1.StrokeColor = System.Drawing.Color.Gray;
            this.b1.TabIndex = 265;
            this.b1.Text = "Área";
            this.b1.Transparency = false;
            this.b1.Click += new System.EventHandler(this.btn_consultar_Click);
            // 
            // b2
            // 
            this.b2.Active1 = System.Drawing.Color.Gray;
            this.b2.Active2 = System.Drawing.Color.Gray;
            this.b2.BackColor = System.Drawing.Color.Transparent;
            this.b2.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.b2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.b2.ForeColor = System.Drawing.Color.White;
            this.b2.Inactive1 = System.Drawing.Color.Gray;
            this.b2.Inactive2 = System.Drawing.Color.Gray;
            this.b2.Location = new System.Drawing.Point(344, 126);
            this.b2.Name = "b2";
            this.b2.Radius = 3;
            this.b2.Size = new System.Drawing.Size(146, 30);
            this.b2.Stroke = false;
            this.b2.StrokeColor = System.Drawing.Color.Gray;
            this.b2.TabIndex = 266;
            this.b2.Text = "Servicio Permanente";
            this.b2.Transparency = false;
            this.b2.Click += new System.EventHandler(this.b2_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Gray;
            this.label4.Location = new System.Drawing.Point(193, 93);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(254, 16);
            this.label4.TabIndex = 267;
            this.label4.Text = "Selecciona primero la opción Área / Obra";
            // 
            // bunifuSeparator1
            // 
            this.bunifuSeparator1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuSeparator1.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(77)))), ((int)(((byte)(141)))));
            this.bunifuSeparator1.LineThickness = 1;
            this.bunifuSeparator1.Location = new System.Drawing.Point(42, 162);
            this.bunifuSeparator1.Name = "bunifuSeparator1";
            this.bunifuSeparator1.Size = new System.Drawing.Size(532, 13);
            this.bunifuSeparator1.TabIndex = 268;
            this.bunifuSeparator1.Transparency = 255;
            this.bunifuSeparator1.Vertical = false;
            // 
            // altoButton2
            // 
            this.altoButton2.Active1 = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(85)))), ((int)(((byte)(0)))));
            this.altoButton2.Active2 = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(85)))), ((int)(((byte)(0)))));
            this.altoButton2.BackColor = System.Drawing.Color.Transparent;
            this.altoButton2.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.altoButton2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.altoButton2.ForeColor = System.Drawing.Color.White;
            this.altoButton2.Inactive1 = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(92)))), ((int)(((byte)(0)))));
            this.altoButton2.Inactive2 = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(92)))), ((int)(((byte)(0)))));
            this.altoButton2.Location = new System.Drawing.Point(229, 335);
            this.altoButton2.Name = "altoButton2";
            this.altoButton2.Radius = 3;
            this.altoButton2.Size = new System.Drawing.Size(146, 30);
            this.altoButton2.Stroke = false;
            this.altoButton2.StrokeColor = System.Drawing.Color.Gray;
            this.altoButton2.TabIndex = 269;
            this.altoButton2.Text = "Registrar";
            this.altoButton2.Transparency = false;
            this.altoButton2.Click += new System.EventHandler(this.altoButton2_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(77)))), ((int)(((byte)(141)))));
            this.label5.Location = new System.Drawing.Point(12, 53);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 16);
            this.label5.TabIndex = 270;
            this.label5.Text = "AÑO:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(77)))), ((int)(((byte)(141)))));
            this.label6.Location = new System.Drawing.Point(125, 53);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 16);
            this.label6.TabIndex = 271;
            this.label6.Text = "MES:";
            // 
            // labelmes
            // 
            this.labelmes.AutoSize = true;
            this.labelmes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelmes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(77)))), ((int)(((byte)(141)))));
            this.labelmes.Location = new System.Drawing.Point(57, 53);
            this.labelmes.Name = "labelmes";
            this.labelmes.Size = new System.Drawing.Size(39, 16);
            this.labelmes.TabIndex = 272;
            this.labelmes.Text = "MES:";
            // 
            // labelaño
            // 
            this.labelaño.AutoSize = true;
            this.labelaño.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelaño.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(77)))), ((int)(((byte)(141)))));
            this.labelaño.Location = new System.Drawing.Point(170, 53);
            this.labelaño.Name = "labelaño";
            this.labelaño.Size = new System.Drawing.Size(39, 16);
            this.labelaño.TabIndex = 273;
            this.labelaño.Text = "MES:";
            // 
            // ALTA_PRESUPUESTO
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(636, 386);
            this.Controls.Add(this.labelaño);
            this.Controls.Add(this.labelmes);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.altoButton2);
            this.Controls.Add(this.bunifuSeparator1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.b2);
            this.Controls.Add(this.b1);
            this.Controls.Add(this.TIPO);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.RUBRO_ETIQUETA);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rubro);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel_titulo);
            this.Name = "ALTA_PRESUPUESTO";
            this.Text = "ALTA_PRESUPUESTO";
            this.Load += new System.EventHandler(this.ALTA_PRESUPUESTO_Load);
            this.panel_titulo.ResumeLayout(false);
            this.panel_titulo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.icono)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel_titulo;
        private System.Windows.Forms.PictureBox icono;
        public System.Windows.Forms.Label titulo;
        private RJCodeAdvance.RJControls.RJComboBox rubro;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private RJCodeAdvance.RJControls.RJTextBox RUBRO_ETIQUETA;
        private RJCodeAdvance.RJControls.RJTextBox TIPO;
        private System.Windows.Forms.Label label2;
        private AltoControls.AltoButton b1;
        private AltoControls.AltoButton b2;
        private System.Windows.Forms.Label label4;
        private Bunifu.Framework.UI.BunifuSeparator bunifuSeparator1;
        private AltoControls.AltoButton altoButton2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label labelmes;
        private System.Windows.Forms.Label labelaño;
    }
}