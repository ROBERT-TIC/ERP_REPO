using ERP_LIEC;  //DEFINEN UN AMBITO PARA UTILIZAR RECURSOS //
//LIBRERIAS PARA EXCEL Y PDF
using LiveCharts;
using LiveCharts.Wpf;  //DEFINEN UN AMBITO PARA UTILIZAR RECURSOS //
using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;



namespace ERP_COMPLETO  //NOMBRE DEL ESPACIO
{
    public partial class CALENDARIO_OPERACIONES : Form  //CLASE PRINCIPAL DEL FORMULARIO ACTUAL
    {
        public CALENDARIO_OPERACIONES()
        {
            InitializeComponent();  //INICIALIZA COMPONENTE
        }


        int pendientes = 0;  //VARIABLES INICIALES
        int terminadas = 0;


        //METODO QUE CONSULTA LOS REGISTROS DE BD
        private void CONSULTA_REGISTROS()
        {
            MySqlConnection CONEXION = conexion_supervision_tecnica.USR;   //CONEXION A DB 
            MySqlCommand comando = new MySqlCommand("SELECT ID_EVALUACION, FECHA_TENTATIVA, PERSONAL, CATEGORIA, MOTIVO, SEMESTRE, ESTATUS, EVALUADOR FROM personal_agenda WHERE YEAR(FECHA_TENTATIVA) = '" + DateTime.Today.ToString("yyyy") + "' AND MONTH(FECHA_TENTATIVA) = '" + DateTime.Today.ToString("MM") + "' UNION SELECT ID_SEGUIMIENTO, FECHA_AGENDADA, COORDINADOR, CONCAT(LUGAR, ' / ', AREA) AS LUGAR, MOTIVO, SEMESTRE, ESTATUS, EVALUADOR FROM agenda_actividades_central WHERE YEAR(FECHA_AGENDADA) = '" + DateTime.Today.ToString("yyyy") + "' AND MONTH(FECHA_AGENDADA) = '" + DateTime.Today.ToString("MM") + "' UNION SELECT ID_SEGUIMIENTO, FECHA_AGENDADA, COORD_OBRA, CONCAT(CLAVE_OBRA, ' / ', NOMBRE_OBRA) As NOMBRE_OBRA, MOTIVO, SEMESTRE, ESTATUS, EVALUADOR FROM agenda_actividades_sp WHERE YEAR(FECHA_AGENDADA) = '" + DateTime.Today.ToString("yyyy") + "' AND MONTH(FECHA_AGENDADA) = '" + DateTime.Today.ToString("MM") + "'", CONEXION);

            CONEXION.Open();   //CONEXION 
            MySqlDataReader consulta = comando.ExecuteReader();
            while (consulta.Read())
            {
                string a0 = consulta.IsDBNull(0) ? String.Empty : consulta.GetString(0); //ID SEGUIMIENTO     //DEPOSITO DE INFORMACION
                string a1 = consulta.IsDBNull(1) ? String.Empty : consulta.GetString(1); //FECHA AGENDADA
                string a2 = consulta.IsDBNull(2) ? String.Empty : consulta.GetString(2); //MOTIVO
                string a3 = consulta.IsDBNull(3) ? String.Empty : consulta.GetString(3); //LUGAR
                string a4 = consulta.IsDBNull(4) ? String.Empty : consulta.GetString(4); //AREA
                string a5 = consulta.IsDBNull(5) ? String.Empty : consulta.GetString(5); //COORDINADOR
                string a6 = consulta.IsDBNull(6) ? String.Empty : consulta.GetString(6); //ESTATUS

                DGV2.Rows.Add(a0, a1, a2, a3, a4, a5, a6);   //DEPOSITO DE INFORMACION
            }
            CONEXION.Close();   //CIERRE DE CONEXION
        }



        private void grafica()
        {

            // Defina la etiqueta que aparecerá sobre la parte del gráfico.
            // en este caso mostraremos el valor dado y el porcentaje, por ejemplo, 123 (8%)
            Func<ChartPoint, string> labelPoint = chartPoint => string.Format("{0} ({1:P})", chartPoint.Y, chartPoint.Participation);  //ELEMENTOS PARA GRAFICA 

            // Definir una colección de elementos para mostrar en el gráfico.
            SeriesCollection piechartData = new SeriesCollection
            {
                new PieSeries
                {
                    Title = "Actividades Pendientes",
                    Values = new ChartValues<double> {pendientes},   //ELEMENTOS PARA GRAFICA 
                    DataLabels = true,
                    LabelPoint = labelPoint,
                    Fill = System.Windows.Media.Brushes.Goldenrod,
                },
                new PieSeries
                {
                    Title = "Actividades Realizadas",
                    Values = new ChartValues<double> {terminadas},  //ELEMENTOS PARA GRAFICA 
                    DataLabels = true,
                    LabelPoint = labelPoint,
                      Fill = System.Windows.Media.Brushes.MediumSeaGreen,
                }

            };



            // Definir la colección de valores para mostrar en el gráfico circular
            pieChart1.Series = piechartData;

            // Establecer la ubicación de la leyenda para que aparezca en el lado derecho del gráfico
            pieChart1.LegendLocation = LegendLocation.Bottom;


        }

        private void resumen()
        {


            foreach (DataGridViewRow row in DGV2.Rows)   //RECORRIDO DE INFORMACION
            {

                if (row.Cells[6].Value.ToString() == "PENDIENTE")  //CONDICIONALES 
                {
                    pendientes = pendientes + 1;
                }
                else if (row.Cells[6].Value.ToString() == "TERMINADA")
                {
                    terminadas = terminadas + 1;
                }
                else
                {

                }
            }

            grafica();


        }

        private void Form1_Load(object sender, EventArgs e)  //FUNCION PRINCIPAL DE ARRANQUE
        {

            CONSULTA_REGISTROS();  //FUNCIONES A LLAMAR AL INICIAR EL FORMULARIO


            resumen();
            TABLA_diseño();

            timer1.Start();
        }











        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();   //CIERRA VENTANA
        }


        public void TABLA_diseño()    //ESTILOS APLICABLES A ELEMENTOS 
        {
            DGV2.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            DGV2.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            DGV2.RowHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            for (int i = 0; i < DGV2.ColumnCount; i = i + 2)
            {
                DGV2.Columns[i].DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(244, 244, 244);
            }
        }



        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Opacity = this.Opacity + .20;


            if (this.Opacity == 1)
            {

                timer1.Stop();
            }
        }


        private void DGV_EVENTOS_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

            DGV2.Rows[e.RowIndex].ErrorText = "Concisely describe the error and how to fix it";
            e.Cancel = true;
        }


        //EVALUACIÓN PERSONAL TÉCNICO 
        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            /* Form nv = new Form();
             using (AGENDAR_PERSONAL_TECNICO mn = new AGENDAR_PERSONAL_TECNICO())
             {
                 nv.StartPosition = FormStartPosition.Manual;
                 nv.FormBorderStyle = FormBorderStyle.None;
                 nv.Opacity = .70d;
                 nv.BackColor = System.Drawing.Color.Black;
                 nv.WindowState = FormWindowState.Maximized;
                 nv.TopMost = false;
                 nv.Location = this.Location;
                 nv.ShowInTaskbar = false;
                 nv.Show();
                 mn.Owner = nv;

                 mn.ShowDialog();

                 nv.Dispose();
             }*/
        }


        //EVALUACION PERSONAL CENTRAL
        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            /*  Form nv = new Form();
              using (AGENDAR_PERSONAL_CENTRAL mn = new AGENDAR_PERSONAL_CENTRAL())
              {
                  nv.StartPosition = FormStartPosition.Manual;
                  nv.FormBorderStyle = FormBorderStyle.None;
                  nv.Opacity = .70d;
                  nv.BackColor = System.Drawing.Color.Black;
                  nv.WindowState = FormWindowState.Maximized;
                  nv.TopMost = false;
                  nv.Location = this.Location;
                  nv.ShowInTaskbar = false;
                  nv.Show();
                  mn.Owner = nv;

                  mn.ShowDialog();

                  nv.Dispose();
              }*/
        }


        //VISITA A OBRA
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            /*  Form nv = new Form();
              using (AGENDAR_OBRA mn = new AGENDAR_OBRA())
              {
                  nv.StartPosition = FormStartPosition.Manual;
                  nv.FormBorderStyle = FormBorderStyle.None;
                  nv.Opacity = .70d;
                  nv.BackColor = System.Drawing.Color.Black;
                  nv.WindowState = FormWindowState.Maximized;
                  nv.TopMost = false;
                  nv.Location = this.Location;
                  nv.ShowInTaskbar = false;
                  nv.Show();
                  mn.Owner = nv;

                  mn.ShowDialog();

                  nv.Dispose();
              }*/
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();   //CIERRA VENTANA 
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
