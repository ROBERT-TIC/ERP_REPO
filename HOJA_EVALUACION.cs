using ERP_LIEC;
using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace ERP_COMPLETO
{
    public partial class HOJA_EVALUACION : Form
    {
        public HOJA_EVALUACION()
        {
            InitializeComponent();
        }
        public string id_evaluacion;
        public string NORMA;
        public string METODO;

        public string DD1;
        public string DD2;
        public string DD3;
        public string DD4;
        public string DD5;
        int q1 = 1;
        double puntos = 0;

        private void HOJA_EVALUACION_Load(object sender, EventArgs e)
        {
            estandar.Text = NORMA;
            ID.Text = id_evaluacion;
            label11.Text = "EVALUACIÓN DE ESTÁNDAR   " + estandar.Text;

            tabla.DataSource = conexion_supervision_tecnica.Consultageneral("SELECT ID_CUESTION , RESPUESTA, CALIFICACION, ID_SEGUIMIENTO FROM evaluacion_personal WHERE ID_EVALUACION = '" + id_evaluacion + "' AND NORMA = '" + NORMA + "'");
            foreach (DataGridViewRow row in tabla.Rows)
            {
                tabla2.DataSource = conexion_supervision_tecnica2.Consultageneral("SELECT cuestion FROM cuestionaminetos_norma WHERE ID_CUESTION = '" + row.Cells[0].Value.ToString() + "'");
                if (tabla2.RowCount != 0)
                {

                    if (q1 == 1)
                    {

                        P1.Texts = tabla2.Rows[0].Cells[0].Value.ToString();
                        C1.Texts = row.Cells[2].Value.ToString();
                        q1 = 2;
                        DD1 = row.Cells[3].Value.ToString();
                    }
                    else if (q1 == 2)
                    {

                        P2.Texts = tabla2.Rows[0].Cells[0].Value.ToString();
                        C2.Texts = row.Cells[2].Value.ToString();
                        q1 = 3;
                        DD2 = row.Cells[3].Value.ToString();
                    }
                    else if (q1 == 3)
                    {

                        P3.Texts = tabla2.Rows[0].Cells[0].Value.ToString();
                        C3.Texts = row.Cells[2].Value.ToString();
                        q1 = 4;
                        DD3 = row.Cells[3].Value.ToString();
                    }
                    else if (q1 == 4)
                    {

                        P4.Texts = tabla2.Rows[0].Cells[0].Value.ToString();
                        C4.Texts = row.Cells[2].Value.ToString();
                        q1 = 5;
                        DD4 = row.Cells[3].Value.ToString();
                    }
                    else if (q1 == 5)
                    {

                        P5.Texts = tabla2.Rows[0].Cells[0].Value.ToString();
                        C5.Texts = row.Cells[2].Value.ToString();

                        DD5 = row.Cells[3].Value.ToString();
                    }

                }
            }

            METODO_NORMA();

            timer1.Start();
        }


        private void METODO_NORMA()
        {
            TABLA_3.DataSource = conexion_supervision_tecnica.Consultageneral("SELECT * FROM normas WHERE NORMA = '" + estandar.Text + "' ");
            if (TABLA_3.RowCount != 0)
            {
                DESC_METODO.Text = TABLA_3.Rows[0].Cells[2].Value.ToString();
            }
        }


        private void datos_evaluacion1()
        {
            conexion_supervision_tecnica.USR.Open();//Se abre la conexión para evitar un error común

            String Query = "UPDATE evaluacion_personal SET CALIFICACION = '" + C1.Texts + "', METODO = '" + DESC_METODO.Text + "' WHERE ID_SEGUIMIENTO  = '" + DD1 + "';";
            MySqlCommand comando = new MySqlCommand(Query, conexion_supervision_tecnica.USR);//Se interpreta el comando del query
            comando.ExecuteNonQuery();//Se ejecuta el comando del query

            conexion_supervision_tecnica.USR.Close();//Se cierra la conexión
        }
        private void datos_evaluacion2()
        {
            conexion_supervision_tecnica.USR.Open();//Se abre la conexión para evitar un error común

            String Query = "UPDATE evaluacion_personal SET CALIFICACION= '" + C2.Texts + "', METODO = '" + DESC_METODO.Text + "' WHERE ID_SEGUIMIENTO  = '" + DD2 + "';";
            MySqlCommand comando = new MySqlCommand(Query, conexion_supervision_tecnica.USR);//Se interpreta el comando del query
            comando.ExecuteNonQuery();//Se ejecuta el comando del query

            conexion_supervision_tecnica.USR.Close();//Se cierra la conexión
        }
        private void datos_evaluacion3()
        {
            conexion_supervision_tecnica.USR.Open();//Se abre la conexión para evitar un error común

            String Query = "UPDATE evaluacion_personal SET CALIFICACION= '" + C3.Texts + "', METODO = '" + DESC_METODO.Text + "' WHERE ID_SEGUIMIENTO  = '" + DD3 + "';";
            MySqlCommand comando = new MySqlCommand(Query, conexion_supervision_tecnica.USR);//Se interpreta el comando del query
            comando.ExecuteNonQuery();//Se ejecuta el comando del query

            conexion_supervision_tecnica.USR.Close();//Se cierra la conexión
        }

        private void datos_evaluacion4()
        {
            conexion_supervision_tecnica.USR.Open();//Se abre la conexión para evitar un error común

            String Query = "UPDATE evaluacion_personal SET CALIFICACION= '" + C4.Texts + "', METODO = '" + DESC_METODO.Text + "' WHERE ID_SEGUIMIENTO  = '" + DD4 + "';";
            MySqlCommand comando = new MySqlCommand(Query, conexion_supervision_tecnica.USR);//Se interpreta el comando del query
            comando.ExecuteNonQuery();//Se ejecuta el comando del query

            conexion_supervision_tecnica.USR.Close();//Se cierra la conexión
        }

        private void datos_evaluacion5()
        {
            conexion_supervision_tecnica.USR.Open();//Se abre la conexión para evitar un error común

            String Query = "UPDATE evaluacion_personal SET CALIFICACION= '" + C5.Texts + "', METODO = '" + DESC_METODO.Text + "' WHERE ID_SEGUIMIENTO  = '" + DD5 + "';";
            MySqlCommand comando = new MySqlCommand(Query, conexion_supervision_tecnica.USR);//Se interpreta el comando del query
            comando.ExecuteNonQuery();//Se ejecuta el comando del query

            conexion_supervision_tecnica.USR.Close();//Se cierra la conexión
        }
        private void actualiza_promedios()
        {

            tabla.DataSource = conexion_supervision_tecnica.Consultageneral("SELECT CALIFICACION FROM evaluacion_personal WHERE ID_EVALUACION = '" + ID.Text + "'");
            foreach (DataGridViewRow row in tabla.Rows)
            {

                puntos = puntos + double.Parse(row.Cells[0].Value.ToString());




            }
            puntos = Math.Round((puntos * 5) / tabla.RowCount, 2);
            conexion_supervision_tecnica2.USR.Open();//Se abre la conexión para evitar un error común

            String Query = "UPDATE personal_agenda SET RESULTADO= '" + puntos.ToString() + "'  WHERE ID_EVALUACION  = '" + ID.Text + "';";
            MySqlCommand comando = new MySqlCommand(Query, conexion_supervision_tecnica2.USR);//Se interpreta el comando del query
            comando.ExecuteNonQuery();//Se ejecuta el comando del query

            conexion_supervision_tecnica2.USR.Close();//Se cierra la conexión



        }

        //BOTON GUARDAR EVALUACION
        private void altoButton1_Click(object sender, EventArgs e)
        {
            datos_evaluacion1();
            datos_evaluacion2();
            datos_evaluacion3();
            datos_evaluacion4();
            datos_evaluacion5();
            actualiza_promedios();
            PAN_SUPERVISION.GEV.panel1.Controls.Clear();
            PAN_SUPERVISION.GEV.realizar_ejecucuion();

            MENSAJE_GENERAL mn = new MENSAJE_GENERAL();
            mn.BOTON.Text = "Datos guardados correctamente";
            mn.ShowDialog();

            this.Close();

        }

        private void P1__TextChanged(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Opacity = this.Opacity + .20;


            if (this.Opacity == 1)
            {

                timer1.Stop();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
