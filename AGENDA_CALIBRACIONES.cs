using ERP_LIEC;  //DEFINEN UN AMBITO PARA UTILIZAR RECURSOS//
using System;
using System.Drawing;
using System.Windows.Forms;  //DEFINEN UN AMBITO PARA UTILIZAR RECURSOS//

namespace ERP_COMPLETO  //NOMBRE DEL ESPACIO
{
    public partial class AGENDA_CALIBRACIONES : Form  //CLASE PRINCIPAL DEL FORMULARIO ACTUAL
    {
        public AGENDA_CALIBRACIONES()
        {
            InitializeComponent();  //INICIALIZA COMPONENTE
            contextMenuStrip1.Renderer = new MyRenderer();
            DGV.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));   //ESTILOS APLICABLES A ELEMENTOS 
            DGV.RowsDefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));   //ESTILOS APLICABLES A ELEMENTOS 

            DGV.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            DGV.RowHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

        }

        private class MyRenderer : ToolStripProfessionalRenderer
        {
            public MyRenderer() : base(new MyColors()) { }
        }
        private class MyColors : ProfessionalColorTable
        {
            public override System.Drawing.Color MenuItemSelected
            {
                get { return System.Drawing.Color.FromArgb(225, 92, 0); }   //ESTILOS APLICABLES A ELEMENTOS 
            }
            public override System.Drawing.Color MenuItemSelectedGradientBegin
            {
                get { return System.Drawing.Color.Orange; }
            }
            public override System.Drawing.Color MenuItemSelectedGradientEnd   //ESTILOS APLICABLES A ELEMENTOS 
            {
                get { return System.Drawing.Color.Yellow; }
            }
        }


        DateTime mes_actual = DateTime.Now.AddMonths(0);
        DateTime mes_sig1 = DateTime.Now.AddMonths(1);
        DateTime mes_sig2 = DateTime.Now.AddMonths(2);
        DateTime mes_ant = DateTime.Now.AddMonths(-1);


        private void estetica()
        {
            label7.Left = (panel3.Width - label7.Width) / 2;
            pictureBox5.Left = (label7.Left - pictureBox5.Width) - 3;


        }

        private void consulta_datos()
        {


            DGV.DataSource = conexion_mantenimineto.Consultageneral("SELECT ID_SEGUIMIENTO,CLAVE_EQUIPO,FECHA_1,FECHA_2,ESTADO_OPERACIÓN FROM calibraciones WHERE ESTADO_OPERACIÓN = 'NO REALIZADO' ORDER BY FECHA_1");
            DGV.Columns["ID_SEGUIMIENTO"].HeaderText = "ID";
            DGV.Columns["CLAVE_EQUIPO"].HeaderText = "Clave de Equipo";
            DGV.Columns["FECHA_1"].HeaderText = "Fecha de Calibración";
            DGV.Columns["FECHA_2"].HeaderText = "Proxima Fecha de Calibración";
            DGV.Columns["ESTADO_OPERACIÓN"].HeaderText = "Estado";



        }
        private void AGENDA_CALIBRACIONES_Load(object sender, EventArgs e)   //FUNCION PRINCIPAL DE ARRANQUE
        {
            consulta_datos();

            estetica();   //FUNCIONES A LLAMAR AL INICIAR EL FORMULARIO


        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            this.Close();   //CIERRA VENTANA
        }

        private void Fecha_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DGV.DataSource = null;


            DGV.DataSource = conexion_mantenimineto.Consultageneral("SELECT ID_SEGUIMIENTO,CLAVE_EQUIPO,FECHA_1,FECHA_2,ESTADO_OPERACIÓN FROM calibraciones WHERE ESTADO_OPERACIÓN = 'NO REALIZADO' ORDER BY FECHA_1");

            DGV.Columns["ID_SEGUIMIENTO"].HeaderText = "ID";
            DGV.Columns["CLAVE_EQUIPO"].HeaderText = "Clave de Equipo";
            DGV.Columns["FECHA_1"].HeaderText = "Fecha de Calibración";
            DGV.Columns["FECHA_2"].HeaderText = "Proxima Fecha de Calibración";
            DGV.Columns["ESTADO_OPERACIÓN"].HeaderText = "Estado";




        }

        private void vacacionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DGV.DataSource = null;

            DGV.DataSource = conexion_mantenimineto.Consultageneral("SELECT ID_SEGUIMIENTO,CLAVE_EQUIPO,FECHA_1,FECHA_2,ESTADO_OPERACIÓN FROM calibraciones WHERE ESTADO_OPERACIÓN = 'REALIZADO' ORDER BY FECHA_1");
            DGV.Columns["ID_SEGUIMIENTO"].HeaderText = "ID";
            DGV.Columns["CLAVE_EQUIPO"].HeaderText = "Clave de Equipo";
            DGV.Columns["FECHA_1"].HeaderText = "Fecha de Calibración";
            DGV.Columns["FECHA_2"].HeaderText = "Proxima Fecha de Calibración";
            DGV.Columns["ESTADO_OPERACIÓN"].HeaderText = "Estado";




        }

        private void cursosYAcreditacionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DGV.DataSource = null;

            DGV.DataSource = conexion_mantenimineto.Consultageneral("SELECT ID_SEGUIMIENTO,CLAVE_EQUIPO,FECHA_1,FECHA_2,ESTADO_OPERACIÓN FROM calibraciones ORDER BY FECHA_1");

            DGV.Columns["ID_SEGUIMIENTO"].HeaderText = "ID";
            DGV.Columns["CLAVE_EQUIPO"].HeaderText = "Clave de Equipo";
            DGV.Columns["FECHA_1"].HeaderText = "Fecha de Calibración";
            DGV.Columns["FECHA_2"].HeaderText = "Proxima Fecha de Calibración";
            DGV.Columns["ESTADO_OPERACIÓN"].HeaderText = "Estado";
        }



        private void DGV_DoubleClick(object sender, EventArgs e)
        {

        }

        private void DGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void horafecha_Tick(object sender, EventArgs e)
        {
            label2.Text = DateTime.Now.ToLongDateString();
        }

        private void buscador__TextChanged(object sender, EventArgs e)
        {

            BindingSource bs = new BindingSource();

            bs.DataSource = DGV.DataSource;//NOMBRE DE TABLA
            bs.Filter = ("CLAVE_EQUIPO like '%" + buscador.Texts + "%' "); // CONSULTA

            DGV.DataSource = bs;

        }

        private void advancedDataGridView1_DoubleClick(object sender, EventArgs e)
        {
            OP.registrar("INSERT INTO procesos_cotidianos (USUARIO,FECHA,TIEMPO,ACCION,IP_ADREES,AREA,OBRA) VALUES ('" + SESION.usuario + "',  '" + DateTime.Today.ToString("yyyy-MM-dd") + "', '" + DateTime.Now.ToString("HH:mm:ss") + "' , '" + "CONSULTO CALIBRACIÓN DE EQUIPO" + DGV.CurrentRow.Cells["CLAVE_EQUIPO"].Value.ToString() + " ', '" + SESION.IP + "','" + SESION.puesto + "', '" + SESION.obra + "' )");

            Form nv = new Form();
            using (DETALLE_CALIBRACIONES mn = new DETALLE_CALIBRACIONES())  //ABRE FORMULARIO 
            {
                nv.StartPosition = FormStartPosition.Manual;
                nv.FormBorderStyle = FormBorderStyle.None;
                nv.Opacity = .70d;
                nv.BackColor = Color.Black;
                nv.WindowState = FormWindowState.Maximized;    //ESTILOS APLICABLES A ELEMENTOS 
                nv.TopMost = false;
                nv.Location = this.Location;
                nv.ShowInTaskbar = false;
                nv.Show();
                mn.Owner = nv;

                mn.didi = DGV.CurrentRow.Cells[0].Value.ToString();
                mn.ID = DGV.CurrentRow.Cells[1].Value.ToString();
                mn.label7.Text = "CALIBRACIÓN - " + DGV.CurrentRow.Cells[1].Value.ToString();

                mn.apertura = false;

                mn.ShowDialog();

                nv.Dispose();

            }
        }
    }
}
