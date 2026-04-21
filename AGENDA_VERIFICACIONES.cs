using ERP_LIEC;   //DEFINEN UN AMBITO PARA UTILIZAR RECURSOS //
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;   //DEFINEN UN AMBITO PARA UTILIZAR RECURSOS //

namespace ERP_COMPLETO  //NOMBRE DEL ESPACIO
{
    public partial class AGENDA_VERIFICACIONES : Form  //CLASE PRINCIPAL DEL FORMULARIO ACTUAL
    {
        public AGENDA_VERIFICACIONES()
        {
            InitializeComponent();
            contextMenuStrip1.Renderer = new MyRenderer();
            DGV.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));   //ESTILOS APLICABLES A ELEMENTOS 
            DGV.RowsDefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));   //ESTILOS APLICABLES A ELEMENTOS 

            DGV.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            DGV.RowHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

        }

        Double ANTEPRO = 0.35;




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
                get { return System.Drawing.Color.Orange; }   //ESTILOS APLICABLES A ELEMENTOS 
            }
            public override System.Drawing.Color MenuItemSelectedGradientEnd
            {
                get { return System.Drawing.Color.Yellow; }   //ESTILOS APLICABLES A ELEMENTOS 
            }
        }


        DateTime mes_actual = DateTime.Now.AddMonths(0);  //FORMATOS DE FECHA 
        DateTime mes_sig1 = DateTime.Now.AddMonths(1);
        DateTime mes_sig2 = DateTime.Now.AddMonths(2);
        DateTime mes_ant = DateTime.Now.AddMonths(-1);

        private void calibracion_proxima()
        {
            foreach (DataGridViewRow row in DGV.Rows)
            {


                DateTime ev = DateTime.Parse(row.Cells[5].Value.ToString());
                DateTime ev2 = DateTime.Parse(row.Cells[5].Value.ToString()).AddMonths(3);

                string estatus = row.Cells[7].Value.ToString(); //estatus de realizado o no



                if (mes_sig1.Month >= ev.Month && mes_sig1.Year == ev.Year) //amarillo
                {
                    row.DefaultCellStyle.BackColor = Color.FromArgb(253, 253, 150);



                }

                if (mes_actual.Month == ev.Month && mes_actual.Year == ev.Year) //rojo
                {
                    row.DefaultCellStyle.BackColor = Color.FromArgb(247, 145, 128);


                }
                if (mes_ant.Month >= ev.Month && mes_ant.Year >= ev.Year) //blanco
                {
                    row.DefaultCellStyle.BackColor = Color.White;

                }
                if (mes_ant.Month >= ev2.Month && mes_ant.Year >= ev2.Year) //blanco
                {
                    row.DefaultCellStyle.BackColor = Color.FromArgb(189, 236, 182);

                }

            }





        }
        private void estetica()
        {
            label7.Left = (panel3.Width - label7.Width) / 2;
            pictureBox5.Left = (label7.Left - pictureBox5.Width) - 3;



        }

        private void consulta_datos()
        {
            DGV.Rows.Clear();
            DGV.DataSource = conexion_mantenimineto.Consultageneral("SELECT ID_SEGUIMIENTO,CLAVE_EQUIPO,FECHA_1,FECHA_2,ESTADO_OPERACIÓN FROM verificaciones WHERE ESTADO_OPERACIÓN = 'NO REALIZADO' ORDER BY FECHA_1");
            DGV.Columns["ID_SEGUIMIENTO"].HeaderText = "ID";
            DGV.Columns["CLAVE_EQUIPO"].HeaderText = "Clave de Equipo";
            DGV.Columns["FECHA_1"].HeaderText = "Fecha de Verificación";
            DGV.Columns["FECHA_2"].HeaderText = "Proxima Fecha de Verificación";
            DGV.Columns["ESTADO_OPERACIÓN"].HeaderText = "Estado";




        }
        private void AGENDA_CALIBRACIONES_Load(object sender, EventArgs e)  //FUNCION PRINCIPAL DE ARRANQUE
        {

            consulta_datos();

            estetica();

        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Fecha_Click(object sender, EventArgs e)
        {
            // calibracion_proxima();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

            DGV.Rows.Clear();


            DGV.DataSource = conexion_mantenimineto.Consultageneral("SELECT ID_SEGUIMIENTO,CLAVE_EQUIPO,FECHA_1,FECHA_2,ESTADO_OPERACIÓN FROM verificaciones WHERE ESTADO_OPERACIÓN = 'NO REALIZADO' ORDER BY FECHA_1");

            DGV.Columns["ID_SEGUIMIENTO"].HeaderText = "ID";
            DGV.Columns["CLAVE_EQUIPO"].HeaderText = "Clave de Equipo";
            DGV.Columns["FECHA_1"].HeaderText = "Fecha de Verificación";
            DGV.Columns["FECHA_2"].HeaderText = "Proxima Fecha de Verificación";
            DGV.Columns["ESTADO_OPERACIÓN"].HeaderText = "Estado";

        }

        private void vacacionesToolStripMenuItem_Click(object sender, EventArgs e)
        {

            DGV.Rows.Clear();

            DGV.DataSource = conexion_mantenimineto.Consultageneral("SELECT ID_SEGUIMIENTO,CLAVE_EQUIPO,FECHA_1,FECHA_2,ESTADO_OPERACIÓN FROM verificaciones WHERE ESTADO_OPERACIÓN = 'REALIZADO' ORDER BY FECHA_1");

            DGV.Columns["ID_SEGUIMIENTO"].HeaderText = "ID";
            DGV.Columns["CLAVE_EQUIPO"].HeaderText = "Clave de Equipo";
            DGV.Columns["FECHA_1"].HeaderText = "Fecha de Verificación";
            DGV.Columns["FECHA_2"].HeaderText = "Proxima Fecha de Verificación";
            DGV.Columns["ESTADO_OPERACIÓN"].HeaderText = "Estado";



        }

        private void cursosYAcreditacionesToolStripMenuItem_Click(object sender, EventArgs e)
        {

            DGV.Rows.Clear();


            DGV.DataSource = conexion_mantenimineto.Consultageneral("SELECT ID_SEGUIMIENTO,CLAVE_EQUIPO,FECHA_1,FECHA_2,ESTADO_OPERACIÓN FROM verificaciones ORDER BY FECHA_1");

            DGV.Columns["ID_SEGUIMIENTO"].HeaderText = "ID";
            DGV.Columns["CLAVE_EQUIPO"].HeaderText = "Clave de Equipo";
            DGV.Columns["FECHA_1"].HeaderText = "Fecha de Verificación";
            DGV.Columns["FECHA_2"].HeaderText = "Proxima Fecha de Verificación";
            DGV.Columns["ESTADO_OPERACIÓN"].HeaderText = "Estado";


        }


        private void DGV_DoubleClick(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void DGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void horafecha_Tick(object sender, EventArgs e)
        {
            Fecha.Text = DateTime.Now.ToLongDateString();
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void rojo_Click(object sender, EventArgs e)
        {

        }

        private void verde_Click(object sender, EventArgs e)
        {

        }

        private void amarillo_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void buscador__TextChanged(object sender, EventArgs e)
        {



            BindingSource bs = new BindingSource();

            bs.DataSource = DGV.DataSource;//NOMBRE DE TABLA
            bs.Filter = ("CLAVE_EQUIPO like '%" + buscador.Texts + "%' "); // CONSULTA
            DGV.DataSource = null;
            DGV.DataSource = bs;
        }

        private void advancedDataGridView1_DoubleClick(object sender, EventArgs e)
        {
            OP.registrar("INSERT INTO procesos_cotidianos (USUARIO,FECHA,TIEMPO,ACCION,IP_ADREES,AREA,OBRA) VALUES ('" + SESION.usuario + "',  '" + DateTime.Today.ToString("yyyy-MM-dd") + "', '" + DateTime.Now.ToString("HH:mm:ss") + "' , '" + "CONSULTO VERIFICACIÓN DE EQUIPO" + DGV.CurrentRow.Cells["CLAVE_EQUIPO"].Value.ToString() + " ', '" + SESION.IP + "','" + SESION.puesto + "', '" + SESION.obra + "' )");

            Form nv = new Form();
            using (DETALLE_VERIFICACIONES mn = new DETALLE_VERIFICACIONES())  //ABRE FORMULARIO 
            {
                nv.StartPosition = FormStartPosition.Manual;
                nv.FormBorderStyle = FormBorderStyle.None;
                nv.Opacity = .70d;
                nv.BackColor = Color.Black;
                nv.WindowState = FormWindowState.Maximized;
                nv.TopMost = false;
                nv.Location = this.Location;
                nv.ShowInTaskbar = false;
                nv.Show();
                mn.Owner = nv;

                mn.didi = DGV.CurrentRow.Cells[0].Value.ToString();


                mn.apertura = false;

                mn.ShowDialog();

                nv.Dispose();
            }
        }
    }
}
