
namespace ERP_COMPLETO
{
    partial class AGENDAR_PERSONAL_CENTRAL
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AGENDAR_PERSONAL_CENTRAL));
            this.panel2 = new System.Windows.Forms.Panel();
            this.tabla_3 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabla2 = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.FECHA = new RJCodeAdvance.RJControls.RJDatePicker();
            this.label5 = new System.Windows.Forms.Label();
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
            this.label4 = new System.Windows.Forms.Label();
            this.CATEGORIA = new RJCodeAdvance.RJControls.RJTextBox();
            this.myProgressBar = new System.Windows.Forms.ProgressBar();
            this.myBGWorker = new System.ComponentModel.BackgroundWorker();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.porc = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tabla = new System.Windows.Forms.DataGridView();
            this.EVALUADOR = new RJCodeAdvance.RJControls.RJComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabla_3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabla2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabla)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(77)))), ((int)(((byte)(141)))));
            this.panel2.Controls.Add(this.tabla_3);
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
            // tabla_3
            // 
            this.tabla_3.AllowUserToAddRows = false;
            this.tabla_3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tabla_3.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            this.tabla_3.Location = new System.Drawing.Point(222, 51);
            this.tabla_3.Name = "tabla_3";
            this.tabla_3.Size = new System.Drawing.Size(10, 10);
            this.tabla_3.TabIndex = 355;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Column1";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Column2";
            this.Column2.Name = "Column2";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(287, 7);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(28, 28);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 15;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::ERP_COMPLETO.Properties.Resources.Mi_cerrar;
            this.pictureBox1.Location = new System.Drawing.Point(733, 9);
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
            this.label1.Location = new System.Drawing.Point(317, 12);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(182, 18);
            this.label1.TabIndex = 2;
            this.label1.Text = "AGENDAR PERSONAL";
            // 
            // tabla2
            // 
            this.tabla2.AllowUserToAddRows = false;
            this.tabla2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tabla2.Location = new System.Drawing.Point(212, 18);
            this.tabla2.Name = "tabla2";
            this.tabla2.Size = new System.Drawing.Size(10, 10);
            this.tabla2.TabIndex = 354;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(77)))), ((int)(((byte)(141)))));
            this.label2.Location = new System.Drawing.Point(22, 107);
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
            this.label3.Location = new System.Drawing.Point(504, 61);
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
            this.FECHA.Location = new System.Drawing.Point(614, 54);
            this.FECHA.Margin = new System.Windows.Forms.Padding(4);
            this.FECHA.MinimumSize = new System.Drawing.Size(4, 30);
            this.FECHA.Name = "FECHA";
            this.FECHA.Size = new System.Drawing.Size(144, 30);
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
            this.label5.Location = new System.Drawing.Point(433, 107);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 16);
            this.label5.TabIndex = 8;
            this.label5.Text = "Motivo";
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
            this.MOTIVO.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.MOTIVO.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(77)))), ((int)(((byte)(141)))));
            this.MOTIVO.ListBackColor = System.Drawing.Color.White;
            this.MOTIVO.ListTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.MOTIVO.Location = new System.Drawing.Point(436, 128);
            this.MOTIVO.MinimumSize = new System.Drawing.Size(200, 30);
            this.MOTIVO.Name = "MOTIVO";
            this.MOTIVO.Padding = new System.Windows.Forms.Padding(1);
            this.MOTIVO.Size = new System.Drawing.Size(322, 30);
            this.MOTIVO.TabIndex = 14;
            this.MOTIVO.Texts = "";
            this.MOTIVO.OnSelectedIndexChanged += new System.EventHandler(this.MOTIVO_OnSelectedIndexChanged);
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
            this.NOMBRE.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.NOMBRE.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.NOMBRE.BackColor = System.Drawing.Color.White;
            this.NOMBRE.BorderColor = System.Drawing.Color.White;
            this.NOMBRE.BorderSize = 1;
            this.NOMBRE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.NOMBRE.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.NOMBRE.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.NOMBRE.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(77)))), ((int)(((byte)(141)))));
            this.NOMBRE.ListBackColor = System.Drawing.Color.White;
            this.NOMBRE.ListTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.NOMBRE.Location = new System.Drawing.Point(25, 128);
            this.NOMBRE.MinimumSize = new System.Drawing.Size(200, 30);
            this.NOMBRE.Name = "NOMBRE";
            this.NOMBRE.Padding = new System.Windows.Forms.Padding(1);
            this.NOMBRE.Size = new System.Drawing.Size(388, 30);
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
            this.label9.Location = new System.Drawing.Point(23, 62);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(89, 16);
            this.label9.TabIndex = 243;
            this.label9.Text = "Id Evaluación";
            // 
            // ID
            // 
            this.ID.BackColor = System.Drawing.Color.Transparent;
            this.ID.BackgroundColor = System.Drawing.Color.Transparent;
            this.ID.BorderColor = System.Drawing.Color.Transparent;
            this.ID.BorderRadius = 3;
            this.ID.BorderSize = 0;
            this.ID.FlatAppearance.BorderSize = 0;
            this.ID.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.ID.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.ID.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(92)))), ((int)(((byte)(0)))));
            this.ID.Location = new System.Drawing.Point(118, 54);
            this.ID.Name = "ID";
            this.ID.Size = new System.Drawing.Size(164, 30);
            this.ID.TabIndex = 242;
            this.ID.Text = "000";
            this.ID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ID.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(92)))), ((int)(((byte)(0)))));
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
            this.altoButton1.Location = new System.Drawing.Point(309, 254);
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
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(77)))), ((int)(((byte)(141)))));
            this.label4.Location = new System.Drawing.Point(22, 170);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 16);
            this.label4.TabIndex = 245;
            this.label4.Text = "Categoria";
            // 
            // CATEGORIA
            // 
            this.CATEGORIA.BackColor = System.Drawing.Color.White;
            this.CATEGORIA.BorderColor = System.Drawing.Color.White;
            this.CATEGORIA.BorderFocusColor = System.Drawing.Color.White;
            this.CATEGORIA.BorderRadius = 5;
            this.CATEGORIA.BorderSize = 1;
            this.CATEGORIA.Enabled = false;
            this.CATEGORIA.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CATEGORIA.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.CATEGORIA.Location = new System.Drawing.Point(26, 190);
            this.CATEGORIA.Margin = new System.Windows.Forms.Padding(5);
            this.CATEGORIA.Multiline = true;
            this.CATEGORIA.Name = "CATEGORIA";
            this.CATEGORIA.Padding = new System.Windows.Forms.Padding(7, 6, 0, 0);
            this.CATEGORIA.PasswordChar = false;
            this.CATEGORIA.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.CATEGORIA.PlaceholderText = "";
            this.CATEGORIA.Size = new System.Drawing.Size(387, 30);
            this.CATEGORIA.TabIndex = 349;
            this.CATEGORIA.Texts = "";
            this.CATEGORIA.UnderlinedStyle = false;
            // 
            // myProgressBar
            // 
            this.myProgressBar.Location = new System.Drawing.Point(25, 311);
            this.myProgressBar.Name = "myProgressBar";
            this.myProgressBar.Size = new System.Drawing.Size(682, 23);
            this.myProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.myProgressBar.TabIndex = 350;
            // 
            // myBGWorker
            // 
            this.myBGWorker.WorkerReportsProgress = true;
            this.myBGWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.myBGWorker_DoWork);
            this.myBGWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.myBGWorker_ProgressChanged);
            this.myBGWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.myBGWorker_RunWorkerCompleted);
            // 
            // timer2
            // 
            this.timer2.Interval = 1000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // porc
            // 
            this.porc.AutoSize = true;
            this.porc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.porc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(77)))), ((int)(((byte)(141)))));
            this.porc.Location = new System.Drawing.Point(714, 315);
            this.porc.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.porc.Name = "porc";
            this.porc.Size = new System.Drawing.Size(44, 16);
            this.porc.TabIndex = 351;
            this.porc.Text = "000 %";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(77)))), ((int)(((byte)(141)))));
            this.label7.Location = new System.Drawing.Point(335, 341);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(133, 16);
            this.label7.TabIndex = 352;
            this.label7.Text = "Agendando Registro";
            // 
            // tabla
            // 
            this.tabla.AllowUserToAddRows = false;
            this.tabla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tabla.Location = new System.Drawing.Point(235, 18);
            this.tabla.Name = "tabla";
            this.tabla.Size = new System.Drawing.Size(10, 10);
            this.tabla.TabIndex = 353;
            // 
            // EVALUADOR
            // 
            this.EVALUADOR.BackColor = System.Drawing.Color.White;
            this.EVALUADOR.BorderColor = System.Drawing.Color.White;
            this.EVALUADOR.BorderSize = 1;
            this.EVALUADOR.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.EVALUADOR.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.EVALUADOR.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.EVALUADOR.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(77)))), ((int)(((byte)(141)))));
            this.EVALUADOR.Items.AddRange(new object[] {
            "CONCEPCIÓN JIMÉNEZ MEDINA",
            "YAREM SADAHI ALONSO ALVARADO",
            "HEIDY MAYERLY HERNÁNDEZ MARTIN"});
            this.EVALUADOR.ListBackColor = System.Drawing.Color.White;
            this.EVALUADOR.ListTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.EVALUADOR.Location = new System.Drawing.Point(436, 190);
            this.EVALUADOR.MinimumSize = new System.Drawing.Size(200, 30);
            this.EVALUADOR.Name = "EVALUADOR";
            this.EVALUADOR.Padding = new System.Windows.Forms.Padding(1);
            this.EVALUADOR.Size = new System.Drawing.Size(322, 30);
            this.EVALUADOR.TabIndex = 356;
            this.EVALUADOR.Texts = "";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(77)))), ((int)(((byte)(141)))));
            this.label6.Location = new System.Drawing.Point(433, 170);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 16);
            this.label6.TabIndex = 355;
            this.label6.Text = "Evaluador";
            // 
            // AGENDAR_PERSONAL_CENTRAL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(783, 366);
            this.Controls.Add(this.EVALUADOR);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.porc);
            this.Controls.Add(this.myProgressBar);
            this.Controls.Add(this.CATEGORIA);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.altoButton1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.ID);
            this.Controls.Add(this.MOTIVO);
            this.Controls.Add(this.NOMBRE);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.FECHA);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.tabla);
            this.Controls.Add(this.tabla2);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(77)))), ((int)(((byte)(141)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "AGENDAR_PERSONAL_CENTRAL";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabla_3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabla2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabla)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private RJCodeAdvance.RJControls.RJDatePicker FECHA;
        private System.Windows.Forms.Label label5;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse2;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse3;
        private RJCodeAdvance.RJControls.RJComboBox NOMBRE;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timer1;
        private RJCodeAdvance.RJControls.RJComboBox MOTIVO;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse4;
        private System.Windows.Forms.Label label9;
        public RJCodeAdvance.RJControls.RJButton ID;
        private AltoControls.AltoButton altoButton1;
        private System.Windows.Forms.Label label4;
        private RJCodeAdvance.RJControls.RJTextBox CATEGORIA;
        private System.Windows.Forms.ProgressBar myProgressBar;
        private System.ComponentModel.BackgroundWorker myBGWorker;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label porc;
        private System.Windows.Forms.DataGridView tabla;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label6;
        public RJCodeAdvance.RJControls.RJComboBox EVALUADOR;
        public System.Windows.Forms.DataGridView tabla2;
        public System.Windows.Forms.DataGridView tabla_3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
    }
}