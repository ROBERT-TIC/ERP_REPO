
namespace ERP_COMPLETO
{
    partial class AGENDAR_OBRA
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.FECHA = new RJCodeAdvance.RJControls.RJDatePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.rjButton1 = new RJCodeAdvance.RJControls.RJButton();
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.MOTIVO = new RJCodeAdvance.RJControls.RJComboBox();
            this.bunifuElipse2 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.bunifuElipse3 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.NOMBRE = new RJCodeAdvance.RJControls.RJComboBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.bunifuElipse4 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.label9 = new System.Windows.Forms.Label();
            this.ID = new RJCodeAdvance.RJControls.RJButton();
            this.altoButton1 = new AltoControls.AltoButton();
            this.CATEGORIA = new RJCodeAdvance.RJControls.RJComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(77)))), ((int)(((byte)(141)))));
            this.panel2.Controls.Add(this.pictureBox2);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(783, 43);
            this.panel2.TabIndex = 1;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::ERP_COMPLETO.Properties.Resources.MI_ALTA_AREA;
            this.pictureBox2.Location = new System.Drawing.Point(235, 6);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(28, 28);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 14;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::ERP_COMPLETO.Properties.Resources.Mi_cerrar;
            this.pictureBox1.Location = new System.Drawing.Point(745, 8);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(25, 25);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(266, 13);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(311, 18);
            this.label1.TabIndex = 2;
            this.label1.Text = "AGENDAR SERVICIOS PERMANENTES";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(77)))), ((int)(((byte)(141)))));
            this.label2.Location = new System.Drawing.Point(40, 118);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(136, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Nombre del Personal";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(77)))), ((int)(((byte)(141)))));
            this.label3.Location = new System.Drawing.Point(488, 144);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Fecha Tentativa";
            // 
            // FECHA
            // 
            this.FECHA.BorderColor = System.Drawing.Color.White;
            this.FECHA.BorderSize = 0;
            this.FECHA.CalendarMonthBackground = System.Drawing.Color.White;
            this.FECHA.CustomFormat = "yyyy-MM-dd";
            this.FECHA.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.FECHA.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.FECHA.Location = new System.Drawing.Point(600, 138);
            this.FECHA.Margin = new System.Windows.Forms.Padding(4);
            this.FECHA.MinimumSize = new System.Drawing.Size(4, 32);
            this.FECHA.Name = "FECHA";
            this.FECHA.Size = new System.Drawing.Size(144, 32);
            this.FECHA.SkinColor = System.Drawing.Color.White;
            this.FECHA.TabIndex = 6;
            this.FECHA.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(130)))), ((int)(((byte)(130)))));
            this.FECHA.ValueChanged += new System.EventHandler(this.FECHA_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(77)))), ((int)(((byte)(141)))));
            this.label5.Location = new System.Drawing.Point(488, 187);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 16);
            this.label5.TabIndex = 8;
            this.label5.Text = "Motivo";
            // 
            // rjButton1
            // 
            this.rjButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(92)))), ((int)(((byte)(0)))));
            this.rjButton1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(92)))), ((int)(((byte)(0)))));
            this.rjButton1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(92)))), ((int)(((byte)(0)))));
            this.rjButton1.BorderRadius = 3;
            this.rjButton1.BorderSize = 0;
            this.rjButton1.FlatAppearance.BorderSize = 0;
            this.rjButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rjButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rjButton1.ForeColor = System.Drawing.Color.White;
            this.rjButton1.Location = new System.Drawing.Point(335, 324);
            this.rjButton1.Margin = new System.Windows.Forms.Padding(4);
            this.rjButton1.Name = "rjButton1";
            this.rjButton1.Size = new System.Drawing.Size(190, 30);
            this.rjButton1.TabIndex = 12;
            this.rjButton1.Text = "Registrar";
            this.rjButton1.TextColor = System.Drawing.Color.White;
            this.rjButton1.UseVisualStyleBackColor = false;
            this.rjButton1.Click += new System.EventHandler(this.rjButton1_Click);
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 5;
            this.bunifuElipse1.TargetControl = this.MOTIVO;
            // 
            // MOTIVO
            // 
            this.MOTIVO.BackColor = System.Drawing.Color.White;
            this.MOTIVO.BorderColor = System.Drawing.Color.White;
            this.MOTIVO.BorderSize = 1;
            this.MOTIVO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.MOTIVO.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.MOTIVO.ForeColor = System.Drawing.Color.DimGray;
            this.MOTIVO.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(77)))), ((int)(((byte)(141)))));
            this.MOTIVO.Items.AddRange(new object[] {
            "ADMINISTRATIVA",
            "TÉCNICA",
            "OPERATIVA"});
            this.MOTIVO.ListBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(228)))), ((int)(((byte)(245)))));
            this.MOTIVO.ListTextColor = System.Drawing.Color.DimGray;
            this.MOTIVO.Location = new System.Drawing.Point(491, 213);
            this.MOTIVO.MinimumSize = new System.Drawing.Size(200, 30);
            this.MOTIVO.Name = "MOTIVO";
            this.MOTIVO.Padding = new System.Windows.Forms.Padding(1);
            this.MOTIVO.Size = new System.Drawing.Size(253, 30);
            this.MOTIVO.TabIndex = 14;
            this.MOTIVO.Texts = "";
            // 
            // bunifuElipse2
            // 
            this.bunifuElipse2.ElipseRadius = 3;
            this.bunifuElipse2.TargetControl = this;
            // 
            // bunifuElipse3
            // 
            this.bunifuElipse3.ElipseRadius = 3;
            this.bunifuElipse3.TargetControl = this.FECHA;
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
            this.NOMBRE.ListBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(228)))), ((int)(((byte)(245)))));
            this.NOMBRE.ListTextColor = System.Drawing.Color.DimGray;
            this.NOMBRE.Location = new System.Drawing.Point(43, 144);
            this.NOMBRE.MinimumSize = new System.Drawing.Size(200, 30);
            this.NOMBRE.Name = "NOMBRE";
            this.NOMBRE.Padding = new System.Windows.Forms.Padding(1);
            this.NOMBRE.Size = new System.Drawing.Size(422, 30);
            this.NOMBRE.TabIndex = 13;
            this.NOMBRE.Texts = "";
            this.NOMBRE.OnSelectedIndexChanged += new System.EventHandler(this.rjComboBox1_OnSelectedIndexChanged);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // bunifuElipse4
            // 
            this.bunifuElipse4.ElipseRadius = 5;
            this.bunifuElipse4.TargetControl = this.NOMBRE;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(77)))), ((int)(((byte)(141)))));
            this.label9.Location = new System.Drawing.Point(41, 68);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(108, 16);
            this.label9.TabIndex = 243;
            this.label9.Text = "Id de Evaluacion";
            // 
            // ID
            // 
            this.ID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(92)))), ((int)(((byte)(0)))));
            this.ID.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(92)))), ((int)(((byte)(0)))));
            this.ID.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(92)))), ((int)(((byte)(0)))));
            this.ID.BorderRadius = 3;
            this.ID.BorderSize = 0;
            this.ID.FlatAppearance.BorderSize = 0;
            this.ID.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(92)))), ((int)(((byte)(0)))));
            this.ID.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(92)))), ((int)(((byte)(0)))));
            this.ID.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID.ForeColor = System.Drawing.Color.White;
            this.ID.Location = new System.Drawing.Point(154, 61);
            this.ID.Name = "ID";
            this.ID.Size = new System.Drawing.Size(121, 30);
            this.ID.TabIndex = 242;
            this.ID.Text = "000";
            this.ID.TextColor = System.Drawing.Color.White;
            this.ID.UseVisualStyleBackColor = false;
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
            this.altoButton1.Location = new System.Drawing.Point(288, 278);
            this.altoButton1.Name = "altoButton1";
            this.altoButton1.Radius = 3;
            this.altoButton1.Size = new System.Drawing.Size(190, 30);
            this.altoButton1.Stroke = false;
            this.altoButton1.StrokeColor = System.Drawing.Color.Gray;
            this.altoButton1.TabIndex = 244;
            this.altoButton1.Text = "Agendar";
            this.altoButton1.Transparency = false;
            this.altoButton1.Click += new System.EventHandler(this.altoButton1_Click);
            // 
            // CATEGORIA
            // 
            this.CATEGORIA.BackColor = System.Drawing.Color.White;
            this.CATEGORIA.BorderColor = System.Drawing.Color.White;
            this.CATEGORIA.BorderSize = 1;
            this.CATEGORIA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.CATEGORIA.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.CATEGORIA.ForeColor = System.Drawing.Color.DimGray;
            this.CATEGORIA.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(77)))), ((int)(((byte)(141)))));
            this.CATEGORIA.ListBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(228)))), ((int)(((byte)(245)))));
            this.CATEGORIA.ListTextColor = System.Drawing.Color.DimGray;
            this.CATEGORIA.Location = new System.Drawing.Point(43, 213);
            this.CATEGORIA.MinimumSize = new System.Drawing.Size(200, 30);
            this.CATEGORIA.Name = "CATEGORIA";
            this.CATEGORIA.Padding = new System.Windows.Forms.Padding(1);
            this.CATEGORIA.Size = new System.Drawing.Size(422, 30);
            this.CATEGORIA.TabIndex = 246;
            this.CATEGORIA.Texts = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(77)))), ((int)(((byte)(141)))));
            this.label4.Location = new System.Drawing.Point(40, 187);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 16);
            this.label4.TabIndex = 245;
            this.label4.Text = "Categoria";
            // 
            // AGENDAR_OBRA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(783, 320);
            this.Controls.Add(this.CATEGORIA);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.altoButton1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.ID);
            this.Controls.Add(this.MOTIVO);
            this.Controls.Add(this.NOMBRE);
            this.Controls.Add(this.rjButton1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.FECHA);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel2);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(77)))), ((int)(((byte)(141)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "AGENDAR_OBRA";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private RJCodeAdvance.RJControls.RJDatePicker FECHA;
        private System.Windows.Forms.Label label5;
        private RJCodeAdvance.RJControls.RJButton rjButton1;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse2;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse3;
        private RJCodeAdvance.RJControls.RJComboBox NOMBRE;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timer1;
        private RJCodeAdvance.RJControls.RJComboBox MOTIVO;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse4;
        private System.Windows.Forms.Label label9;
        public RJCodeAdvance.RJControls.RJButton ID;
        private AltoControls.AltoButton altoButton1;
        private RJCodeAdvance.RJControls.RJComboBox CATEGORIA;
        private System.Windows.Forms.Label label4;
    }
}