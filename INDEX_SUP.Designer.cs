namespace ERP_COMPLETO
{
    partial class INDEX_SUP
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(INDEX_SUP));
            this.p_azul = new System.Windows.Forms.Panel();
            this.REFRESH = new System.Windows.Forms.PictureBox();
            this.area = new RJCodeAdvance.RJControls.RJComboBox();
            this.label_area = new System.Windows.Forms.Label();
            this.altoButton1 = new AltoControls.AltoButton();
            this.Año = new RJCodeAdvance.RJControls.RJComboBox();
            this.label_año = new System.Windows.Forms.Label();
            this.p_titulo = new System.Windows.Forms.Panel();
            this.tabla2 = new System.Windows.Forms.DataGridView();
            this.img_titulo = new System.Windows.Forms.PictureBox();
            this.titulo = new System.Windows.Forms.Label();
            this.tabla = new System.Windows.Forms.DataGridView();
            this.myProgressBar = new System.Windows.Forms.ProgressBar();
            this.p1 = new System.Windows.Forms.Panel();
            this.pieChart1 = new LiveCharts.WinForms.PieChart();
            this.ps1 = new System.Windows.Forms.Panel();
            this.ss1 = new System.Windows.Forms.Label();
            this.p2 = new System.Windows.Forms.Panel();
            this.pieChart2 = new LiveCharts.WinForms.PieChart();
            this.ps2 = new System.Windows.Forms.Panel();
            this.ss2 = new System.Windows.Forms.Label();
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.bunifuElipse2 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.bunifuElipse3 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.myBGWorker = new System.ComponentModel.BackgroundWorker();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ET = new System.Windows.Forms.ToolTip(this.components);
            this.p_azul.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.REFRESH)).BeginInit();
            this.p_titulo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabla2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.img_titulo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabla)).BeginInit();
            this.p1.SuspendLayout();
            this.ps1.SuspendLayout();
            this.p2.SuspendLayout();
            this.ps2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // p_azul
            // 
            this.p_azul.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(77)))), ((int)(((byte)(141)))));
            this.p_azul.Controls.Add(this.REFRESH);
            this.p_azul.Controls.Add(this.area);
            this.p_azul.Controls.Add(this.label_area);
            this.p_azul.Controls.Add(this.altoButton1);
            this.p_azul.Controls.Add(this.Año);
            this.p_azul.Controls.Add(this.label_año);
            this.p_azul.Dock = System.Windows.Forms.DockStyle.Top;
            this.p_azul.Location = new System.Drawing.Point(0, 43);
            this.p_azul.Name = "p_azul";
            this.p_azul.Size = new System.Drawing.Size(1132, 50);
            this.p_azul.TabIndex = 47;
            // 
            // REFRESH
            // 
            this.REFRESH.Image = ((System.Drawing.Image)(resources.GetObject("REFRESH.Image")));
            this.REFRESH.Location = new System.Drawing.Point(862, 12);
            this.REFRESH.Name = "REFRESH";
            this.REFRESH.Size = new System.Drawing.Size(27, 27);
            this.REFRESH.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.REFRESH.TabIndex = 250;
            this.REFRESH.TabStop = false;
            this.REFRESH.Click += new System.EventHandler(this.REFRESH_Click);
            // 
            // area
            // 
            this.area.BorderColor = System.Drawing.Color.Empty;
            this.area.BorderSize = 0;
            this.area.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.area.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.area.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.area.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(77)))), ((int)(((byte)(141)))));
            this.area.ListBackColor = System.Drawing.Color.White;
            this.area.ListTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.area.Location = new System.Drawing.Point(364, 10);
            this.area.MinimumSize = new System.Drawing.Size(100, 10);
            this.area.Name = "area";
            this.area.Size = new System.Drawing.Size(276, 30);
            this.area.TabIndex = 250;
            this.area.Texts = "";
            this.area.OnSelectedIndexChanged += new System.EventHandler(this.area_OnSelectedIndexChanged);
            // 
            // label_area
            // 
            this.label_area.AutoSize = true;
            this.label_area.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_area.ForeColor = System.Drawing.Color.White;
            this.label_area.Location = new System.Drawing.Point(293, 16);
            this.label_area.Name = "label_area";
            this.label_area.Size = new System.Drawing.Size(66, 16);
            this.label_area.TabIndex = 249;
            this.label_area.Text = "Categoría";
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
            this.altoButton1.Location = new System.Drawing.Point(914, 10);
            this.altoButton1.Name = "altoButton1";
            this.altoButton1.Radius = 3;
            this.altoButton1.Size = new System.Drawing.Size(190, 30);
            this.altoButton1.Stroke = false;
            this.altoButton1.StrokeColor = System.Drawing.Color.Gray;
            this.altoButton1.TabIndex = 248;
            this.altoButton1.Text = "Consultar";
            this.altoButton1.Transparency = false;
            this.altoButton1.Click += new System.EventHandler(this.altoButton1_Click);
            // 
            // Año
            // 
            this.Año.BorderColor = System.Drawing.Color.Empty;
            this.Año.BorderSize = 0;
            this.Año.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.Año.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Año.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.Año.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(77)))), ((int)(((byte)(141)))));
            this.Año.Items.AddRange(new object[] {
            "2022",
            "2023",
            "2024",
            "2025"});
            this.Año.ListBackColor = System.Drawing.Color.White;
            this.Año.ListTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.Año.Location = new System.Drawing.Point(121, 10);
            this.Año.MinimumSize = new System.Drawing.Size(100, 10);
            this.Año.Name = "Año";
            this.Año.Size = new System.Drawing.Size(165, 30);
            this.Año.TabIndex = 247;
            this.Año.Texts = "";
            // 
            // label_año
            // 
            this.label_año.AutoSize = true;
            this.label_año.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_año.ForeColor = System.Drawing.Color.White;
            this.label_año.Location = new System.Drawing.Point(13, 16);
            this.label_año.Name = "label_año";
            this.label_año.Size = new System.Drawing.Size(102, 16);
            this.label_año.TabIndex = 37;
            this.label_año.Text = "Selecciona Año";
            // 
            // p_titulo
            // 
            this.p_titulo.BackColor = System.Drawing.SystemColors.Control;
            this.p_titulo.Controls.Add(this.tabla2);
            this.p_titulo.Controls.Add(this.img_titulo);
            this.p_titulo.Controls.Add(this.titulo);
            this.p_titulo.Controls.Add(this.tabla);
            this.p_titulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.p_titulo.Location = new System.Drawing.Point(0, 0);
            this.p_titulo.Name = "p_titulo";
            this.p_titulo.Size = new System.Drawing.Size(1132, 43);
            this.p_titulo.TabIndex = 46;
            // 
            // tabla2
            // 
            this.tabla2.AllowUserToAddRows = false;
            this.tabla2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tabla2.Location = new System.Drawing.Point(829, 51);
            this.tabla2.Name = "tabla2";
            this.tabla2.Size = new System.Drawing.Size(10, 10);
            this.tabla2.TabIndex = 1;
            // 
            // img_titulo
            // 
            this.img_titulo.Image = global::ERP_COMPLETO.Properties.Resources.MI_COT_CCA2;
            this.img_titulo.Location = new System.Drawing.Point(273, 6);
            this.img_titulo.Name = "img_titulo";
            this.img_titulo.Size = new System.Drawing.Size(30, 30);
            this.img_titulo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.img_titulo.TabIndex = 45;
            this.img_titulo.TabStop = false;
            // 
            // titulo
            // 
            this.titulo.AutoSize = true;
            this.titulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(77)))), ((int)(((byte)(141)))));
            this.titulo.Location = new System.Drawing.Point(303, 13);
            this.titulo.Name = "titulo";
            this.titulo.Size = new System.Drawing.Size(282, 16);
            this.titulo.TabIndex = 43;
            this.titulo.Text = "RESUMEN DE SUPERVISIÓN TÉCNICA";
            // 
            // tabla
            // 
            this.tabla.AllowUserToAddRows = false;
            this.tabla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tabla.Location = new System.Drawing.Point(646, 61);
            this.tabla.Name = "tabla";
            this.tabla.Size = new System.Drawing.Size(10, 10);
            this.tabla.TabIndex = 0;
            // 
            // myProgressBar
            // 
            this.myProgressBar.Location = new System.Drawing.Point(16, 8);
            this.myProgressBar.Name = "myProgressBar";
            this.myProgressBar.Size = new System.Drawing.Size(1088, 17);
            this.myProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.myProgressBar.TabIndex = 351;
            // 
            // p1
            // 
            this.p1.Controls.Add(this.pieChart1);
            this.p1.Controls.Add(this.ps1);
            this.p1.Dock = System.Windows.Forms.DockStyle.Left;
            this.p1.Location = new System.Drawing.Point(0, 93);
            this.p1.Name = "p1";
            this.p1.Size = new System.Drawing.Size(553, 492);
            this.p1.TabIndex = 48;
            // 
            // pieChart1
            // 
            this.pieChart1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pieChart1.Location = new System.Drawing.Point(0, 28);
            this.pieChart1.Name = "pieChart1";
            this.pieChart1.Size = new System.Drawing.Size(553, 464);
            this.pieChart1.TabIndex = 0;
            this.pieChart1.Text = "C";
            this.pieChart1.DataClick += new LiveCharts.Events.DataClickHandler(this.pieChart1_DataClick);
            this.pieChart1.ChildChanged += new System.EventHandler<System.Windows.Forms.Integration.ChildChangedEventArgs>(this.pieChart1_ChildChanged);
            // 
            // ps1
            // 
            this.ps1.Controls.Add(this.ss1);
            this.ps1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ps1.Location = new System.Drawing.Point(0, 0);
            this.ps1.Name = "ps1";
            this.ps1.Size = new System.Drawing.Size(553, 28);
            this.ps1.TabIndex = 1;
            // 
            // ss1
            // 
            this.ss1.AutoSize = true;
            this.ss1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ss1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(77)))), ((int)(((byte)(141)))));
            this.ss1.Location = new System.Drawing.Point(203, 5);
            this.ss1.Name = "ss1";
            this.ss1.Size = new System.Drawing.Size(122, 16);
            this.ss1.TabIndex = 250;
            this.ss1.Text = "Primer Semestre";
            this.ss1.Visible = false;
            // 
            // p2
            // 
            this.p2.BackColor = System.Drawing.Color.Gainsboro;
            this.p2.Controls.Add(this.pieChart2);
            this.p2.Controls.Add(this.ps2);
            this.p2.Dock = System.Windows.Forms.DockStyle.Right;
            this.p2.Location = new System.Drawing.Point(559, 93);
            this.p2.Name = "p2";
            this.p2.Size = new System.Drawing.Size(573, 492);
            this.p2.TabIndex = 49;
            // 
            // pieChart2
            // 
            this.pieChart2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pieChart2.Location = new System.Drawing.Point(0, 28);
            this.pieChart2.Name = "pieChart2";
            this.pieChart2.Size = new System.Drawing.Size(573, 464);
            this.pieChart2.TabIndex = 1;
            this.pieChart2.Text = "pieChart2";
            this.pieChart2.DataClick += new LiveCharts.Events.DataClickHandler(this.pieChart2_DataClick);
            this.pieChart2.ChildChanged += new System.EventHandler<System.Windows.Forms.Integration.ChildChangedEventArgs>(this.pieChart2_ChildChanged);
            // 
            // ps2
            // 
            this.ps2.Controls.Add(this.ss2);
            this.ps2.Dock = System.Windows.Forms.DockStyle.Top;
            this.ps2.Location = new System.Drawing.Point(0, 0);
            this.ps2.Name = "ps2";
            this.ps2.Size = new System.Drawing.Size(573, 28);
            this.ps2.TabIndex = 2;
            // 
            // ss2
            // 
            this.ss2.AutoSize = true;
            this.ss2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ss2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(77)))), ((int)(((byte)(141)))));
            this.ss2.Location = new System.Drawing.Point(225, 6);
            this.ss2.Name = "ss2";
            this.ss2.Size = new System.Drawing.Size(139, 16);
            this.ss2.TabIndex = 251;
            this.ss2.Text = "Segundo Semestre";
            this.ss2.Visible = false;
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 5;
            this.bunifuElipse1.TargetControl = this;
            // 
            // bunifuElipse2
            // 
            this.bunifuElipse2.ElipseRadius = 5;
            this.bunifuElipse2.TargetControl = this.Año;
            // 
            // bunifuElipse3
            // 
            this.bunifuElipse3.ElipseRadius = 5;
            this.bunifuElipse3.TargetControl = this.area;
            // 
            // myBGWorker
            // 
            this.myBGWorker.WorkerReportsProgress = true;
            this.myBGWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.myBGWorker_DoWork);
            this.myBGWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.myBGWorker_ProgressChanged);
            this.myBGWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.myBGWorker_RunWorkerCompleted);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.myProgressBar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 585);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1132, 35);
            this.panel1.TabIndex = 50;
            // 
            // ET
            // 
            this.ET.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ET.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(77)))), ((int)(((byte)(141)))));
            this.ET.IsBalloon = true;
            // 
            // INDEX_SUP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1132, 620);
            this.Controls.Add(this.p2);
            this.Controls.Add(this.p1);
            this.Controls.Add(this.p_azul);
            this.Controls.Add(this.p_titulo);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "INDEX_SUP";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "INDEX_SUP";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.INDEX_SUP_Load);
            this.p_azul.ResumeLayout(false);
            this.p_azul.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.REFRESH)).EndInit();
            this.p_titulo.ResumeLayout(false);
            this.p_titulo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabla2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.img_titulo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabla)).EndInit();
            this.p1.ResumeLayout(false);
            this.ps1.ResumeLayout(false);
            this.ps1.PerformLayout();
            this.p2.ResumeLayout(false);
            this.ps2.ResumeLayout(false);
            this.ps2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel p_azul;
        private AltoControls.AltoButton altoButton1;
        private RJCodeAdvance.RJControls.RJComboBox Año;
        private System.Windows.Forms.Label label_año;
        private System.Windows.Forms.Panel p_titulo;
        private System.Windows.Forms.PictureBox img_titulo;
        private System.Windows.Forms.Label titulo;
        private System.Windows.Forms.Panel p1;
        private System.Windows.Forms.Panel p2;
        private RJCodeAdvance.RJControls.RJComboBox area;
        private System.Windows.Forms.Label label_area;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse2;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse3;
        private LiveCharts.WinForms.PieChart pieChart1;
        private System.Windows.Forms.DataGridView tabla2;
        private System.Windows.Forms.DataGridView tabla;
        private LiveCharts.WinForms.PieChart pieChart2;
        private System.ComponentModel.BackgroundWorker myBGWorker;
        private System.Windows.Forms.ProgressBar myProgressBar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel ps1;
        private System.Windows.Forms.Label ss1;
        private System.Windows.Forms.Panel ps2;
        private System.Windows.Forms.Label ss2;
        private System.Windows.Forms.PictureBox REFRESH;
        public System.Windows.Forms.ToolTip ET;
    }
}