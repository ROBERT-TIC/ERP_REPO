
namespace ERP_COMPLETO
{
    partial class LOGIN
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

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.user = new System.Windows.Forms.TextBox();
            this.pass = new System.Windows.Forms.TextBox();
            this.TABLA = new System.Windows.Forms.DataGridView();
            this.myBGWorker = new System.ComponentModel.BackgroundWorker();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.proceso = new RJCodeAdvance.RJControls.RJTextBox();
            this.rjTextBox1 = new RJCodeAdvance.RJControls.RJTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.altoButton3 = new AltoControls.AltoButton();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.altoButton1 = new AltoControls.AltoButton();
            ((System.ComponentModel.ISupportInitialize)(this.TABLA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // user
            // 
            this.user.BackColor = System.Drawing.Color.White;
            this.user.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.user.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.user.Font = new System.Drawing.Font("Poppins", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.user.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(132)))), ((int)(((byte)(139)))));
            this.user.Location = new System.Drawing.Point(539, 230);
            this.user.Name = "user";
            this.user.Size = new System.Drawing.Size(130, 23);
            this.user.TabIndex = 2;
            this.user.Text = "USUARIO";
            this.user.TabIndexChanged += new System.EventHandler(this.user_TabIndexChanged);
            this.user.TextChanged += new System.EventHandler(this.user_TextChanged);
            this.user.Enter += new System.EventHandler(this.user_Enter_1);
            this.user.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.user_KeyPress_3);
            this.user.Leave += new System.EventHandler(this.user_Leave_1);
            // 
            // pass
            // 
            this.pass.BackColor = System.Drawing.Color.White;
            this.pass.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.pass.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pass.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(132)))), ((int)(((byte)(139)))));
            this.pass.Location = new System.Drawing.Point(539, 300);
            this.pass.Name = "pass";
            this.pass.PasswordChar = '*';
            this.pass.Size = new System.Drawing.Size(130, 24);
            this.pass.TabIndex = 3;
            this.pass.Text = "ACCESO";
            this.pass.TextChanged += new System.EventHandler(this.pass_TextChanged_2);
            this.pass.Enter += new System.EventHandler(this.pass_Enter_1);
            this.pass.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.pass_KeyPress_4);
            this.pass.Leave += new System.EventHandler(this.pass_Leave_1);
            // 
            // TABLA
            // 
            this.TABLA.AllowUserToAddRows = false;
            this.TABLA.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(64)))), ((int)(((byte)(119)))));
            this.TABLA.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TABLA.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TABLA.Location = new System.Drawing.Point(887, 550);
            this.TABLA.Name = "TABLA";
            this.TABLA.Size = new System.Drawing.Size(20, 21);
            this.TABLA.TabIndex = 66;
            // 
            // myBGWorker
            // 
            this.myBGWorker.WorkerReportsProgress = true;
            this.myBGWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.myBGWorker_DoWork);
            this.myBGWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.myBGWorker_ProgressChanged);
            this.myBGWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.myBGWorker_RunWorkerCompleted);
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(64)))), ((int)(((byte)(119)))));
            this.dgv.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Location = new System.Drawing.Point(760, 570);
            this.dgv.Name = "dgv";
            this.dgv.Size = new System.Drawing.Size(20, 21);
            this.dgv.TabIndex = 176;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Poppins", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(82)))), ((int)(((byte)(82)))));
            this.label1.Location = new System.Drawing.Point(564, 406);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(184, 26);
            this.label1.TabIndex = 177;
            this.label1.Text = "Recuperar Contraseña";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            this.label1.MouseLeave += new System.EventHandler(this.label1_MouseLeave);
            this.label1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.label1_MouseMove);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Poppins", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(82)))), ((int)(((byte)(82)))));
            this.label2.Location = new System.Drawing.Point(526, 266);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 26);
            this.label2.TabIndex = 179;
            this.label2.Text = "Contraseña";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            this.label2.MouseLeave += new System.EventHandler(this.label2_MouseLeave);
            this.label2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.label2_MouseMove);
            // 
            // panel2
            // 
            this.panel2.BackgroundImage = global::ERP_COMPLETO.Properties.Resources.Fondo_login;
            this.panel2.Controls.Add(this.label3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(381, 540);
            this.panel2.TabIndex = 182;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint_1);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Poppins SemiBold", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.Control;
            this.label3.Location = new System.Drawing.Point(70, 234);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(228, 56);
            this.label3.TabIndex = 180;
            this.label3.Text = "¡Bienvenido!";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // proceso
            // 
            this.proceso.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.proceso.BorderColor = System.Drawing.Color.Gainsboro;
            this.proceso.BorderFocusColor = System.Drawing.Color.Gainsboro;
            this.proceso.BorderRadius = 0;
            this.proceso.BorderSize = 1;
            this.proceso.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.proceso.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(132)))), ((int)(((byte)(139)))));
            this.proceso.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.proceso.Location = new System.Drawing.Point(529, 223);
            this.proceso.Margin = new System.Windows.Forms.Padding(4);
            this.proceso.Multiline = false;
            this.proceso.Name = "proceso";
            this.proceso.Padding = new System.Windows.Forms.Padding(10, 7, 5, 5);
            this.proceso.PasswordChar = false;
            this.proceso.PlaceholderColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(132)))), ((int)(((byte)(139)))));
            this.proceso.PlaceholderText = "";
            this.proceso.Size = new System.Drawing.Size(257, 36);
            this.proceso.TabIndex = 452;
            this.proceso.Texts = "";
            this.proceso.UnderlinedStyle = false;
            this.proceso._TextChanged += new System.EventHandler(this.proceso__TextChanged);
            // 
            // rjTextBox1
            // 
            this.rjTextBox1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.rjTextBox1.BorderColor = System.Drawing.Color.Gainsboro;
            this.rjTextBox1.BorderFocusColor = System.Drawing.Color.Gainsboro;
            this.rjTextBox1.BorderRadius = 0;
            this.rjTextBox1.BorderSize = 1;
            this.rjTextBox1.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rjTextBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(132)))), ((int)(((byte)(139)))));
            this.rjTextBox1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rjTextBox1.Location = new System.Drawing.Point(529, 293);
            this.rjTextBox1.Margin = new System.Windows.Forms.Padding(4);
            this.rjTextBox1.Multiline = false;
            this.rjTextBox1.Name = "rjTextBox1";
            this.rjTextBox1.Padding = new System.Windows.Forms.Padding(10, 7, 5, 5);
            this.rjTextBox1.PasswordChar = false;
            this.rjTextBox1.PlaceholderColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(132)))), ((int)(((byte)(139)))));
            this.rjTextBox1.PlaceholderText = "";
            this.rjTextBox1.Size = new System.Drawing.Size(257, 36);
            this.rjTextBox1.TabIndex = 453;
            this.rjTextBox1.Texts = "";
            this.rjTextBox1.UnderlinedStyle = false;
            this.rjTextBox1._TextChanged += new System.EventHandler(this.rjTextBox1__TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Poppins SemiBold", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(77)))), ((int)(((byte)(141)))));
            this.label4.Location = new System.Drawing.Point(521, 136);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(273, 56);
            this.label4.TabIndex = 454;
            this.label4.Text = "Inicio de sesión";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // altoButton3
            // 
            this.altoButton3.Active1 = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(59)))), ((int)(((byte)(3)))));
            this.altoButton3.Active2 = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(59)))), ((int)(((byte)(3)))));
            this.altoButton3.BackColor = System.Drawing.Color.Transparent;
            this.altoButton3.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.altoButton3.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.altoButton3.ForeColor = System.Drawing.Color.White;
            this.altoButton3.Inactive1 = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(76)))), ((int)(((byte)(14)))));
            this.altoButton3.Inactive2 = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(76)))), ((int)(((byte)(14)))));
            this.altoButton3.Location = new System.Drawing.Point(529, 346);
            this.altoButton3.Name = "altoButton3";
            this.altoButton3.Radius = 0;
            this.altoButton3.Size = new System.Drawing.Size(250, 48);
            this.altoButton3.Stroke = false;
            this.altoButton3.StrokeColor = System.Drawing.Color.Gray;
            this.altoButton3.TabIndex = 455;
            this.altoButton3.Text = "Iniciar";
            this.altoButton3.Transparency = false;
            this.altoButton3.Click += new System.EventHandler(this.altoButton3_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Poppins", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(82)))), ((int)(((byte)(82)))));
            this.label5.Location = new System.Drawing.Point(526, 194);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 26);
            this.label5.TabIndex = 456;
            this.label5.Text = "Usuario";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(77)))), ((int)(((byte)(141)))));
            this.label6.Location = new System.Drawing.Point(808, 495);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(140, 22);
            this.label6.TabIndex = 457;
            this.label6.Text = "Buzón LIEC (Anónimo)";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            this.label6.Leave += new System.EventHandler(this.label6_Leave);
            this.label6.MouseLeave += new System.EventHandler(this.label6_MouseLeave);
            this.label6.MouseMove += new System.Windows.Forms.MouseEventHandler(this.label6_MouseMove);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::ERP_COMPLETO.Properties.Resources.LOGO_LIEC__1;
            this.pictureBox1.Location = new System.Drawing.Point(617, 56);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(70, 70);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 459;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(76)))), ((int)(((byte)(14)))));
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(381, 520);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(579, 20);
            this.panel3.TabIndex = 459;
            // 
            // altoButton1
            // 
            this.altoButton1.Active1 = System.Drawing.SystemColors.Control;
            this.altoButton1.Active2 = System.Drawing.SystemColors.Control;
            this.altoButton1.BackColor = System.Drawing.Color.Transparent;
            this.altoButton1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.altoButton1.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.altoButton1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.altoButton1.Inactive1 = System.Drawing.SystemColors.Control;
            this.altoButton1.Inactive2 = System.Drawing.SystemColors.Control;
            this.altoButton1.Location = new System.Drawing.Point(914, 0);
            this.altoButton1.Name = "altoButton1";
            this.altoButton1.Radius = 0;
            this.altoButton1.Size = new System.Drawing.Size(46, 48);
            this.altoButton1.Stroke = false;
            this.altoButton1.StrokeColor = System.Drawing.Color.Gainsboro;
            this.altoButton1.TabIndex = 460;
            this.altoButton1.Text = "❌";
            this.altoButton1.Transparency = false;
            this.altoButton1.Click += new System.EventHandler(this.altoButton1_Click);
            // 
            // LOGIN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(960, 540);
            this.Controls.Add(this.altoButton1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.TABLA);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pass);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.altoButton3);
            this.Controls.Add(this.user);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.proceso);
            this.Controls.Add(this.rjTextBox1);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.Transparent;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "LOGIN";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.DoubleClick += new System.EventHandler(this.LOGIN_DoubleClick);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.LOGIN_MouseMove);
            ((System.ComponentModel.ISupportInitialize)(this.TABLA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox pass;
        private System.Windows.Forms.TextBox user;
        private System.Windows.Forms.DataGridView TABLA;
        public System.ComponentModel.BackgroundWorker myBGWorker;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label3;
        public RJCodeAdvance.RJControls.RJTextBox rjTextBox1;
        public RJCodeAdvance.RJControls.RJTextBox proceso;
        private System.Windows.Forms.Label label4;
        public AltoControls.AltoButton altoButton3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel3;
        public AltoControls.AltoButton altoButton1;
    }
}

