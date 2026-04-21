using ERP_LIEC;
using MySql.Data.MySqlClient;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ERP_COMPLETO
{
    public partial class AGENDAR_PERSONAL_CENTRAL : Form
    {
        public AGENDAR_PERSONAL_CENTRAL()
        {
            InitializeComponent();
        }
        int PORCENTAJEFUNCION = 0;

        string SEMESTRE2 = "";
        private void rjButton1_Click(object sender, EventArgs e)
        {
            /* conexion_rh.Consultageneral("INSERT INTO areas_trabajo(AREA, DESCRIPCION, FECHA_REGISTRO, RANGO_ACTIVIDAD, COORDINADOR) VALUES('"+nom_area.Texts+"','"+observaciones.Texts+"','"+FECHA.Text+"','"+MOTIVO.Texts+"','"+NOMBRE.Texts+"')");
             MessageBox.Show("Se ha dado de alta una nueva área");*/
        }



        private void Form1_Load(object sender, EventArgs e)
        {

            this.Size = new Size(783, 295);
            timer1.Start();
            filtrar_coordinador();
            consecutivo();
            fechas();
            ESTILOS();

            myProgressBar.MarqueeAnimationSpeed = 0;
        }




        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        private void filtrar_coordinador()
        {
            MySqlConnection CONEXION = conexion_rh.USR;

            MySqlCommand comando = new MySqlCommand("SELECT NOMBRE, AREA, CATEGORIA FROM pdr_personal1 WHERE AREA LIKE '%TÉCNICO%' ORDER BY NOMBRE ASC", CONEXION);


            CONEXION.Open();
            MySqlDataReader registro = comando.ExecuteReader();

            while (registro.Read())
            {

                NOMBRE.Items.Add(registro["NOMBRE"].ToString());
            }

            CONEXION.Close();
        }


        private void rjComboBox1_OnSelectedIndexChanged(object sender, EventArgs e)
        {

            if (NOMBRE.Texts == string.Empty)
            {
                CATEGORIA.Texts = string.Empty;
            }

            MySqlConnection CONEXION = conexion_rh.USR;
            MySqlCommand comando = new MySqlCommand("SELECT CATEGORIA FROM pdr_personal1 WHERE NOMBRE = '" + NOMBRE.Texts + "'", CONEXION);
            CONEXION.Open();
            MySqlDataReader registro = comando.ExecuteReader();

            while (registro.Read())
            {

                CATEGORIA.Texts = registro.IsDBNull(0) ? String.Empty : registro.GetString(0);

            }

            CONEXION.Close();



        }

        private void consecutivo()
        {
            int contador = 0;


            MySqlConnection CONEXION = conexion_supervision_tecnica.USR;


            MySqlCommand comando = new MySqlCommand("SELECT DISTINCTROW * FROM  personal_agenda", CONEXION);
            CONEXION.Open();
            MySqlDataReader registro = comando.ExecuteReader();

            while (registro.Read())
            {

                contador = contador + 1;

            }
            contador = contador + 1;

            CONEXION.Close();
            ID.Text = "EV.P." + DateTime.Today.ToString("yy") + "." + contador.ToString();

        }


        public void ESTILOS()
        {
            bunifuElipse1.ApplyElipse(MOTIVO);
            bunifuElipse1.ApplyElipse(EVALUADOR);

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Opacity = this.Opacity + .20;


            if (this.Opacity == 1)
            {

                timer1.Stop();
            }
        }



        string aa2;
        string aa8;

        public void CARGA_DATOS()
        {
            //LLAMA DATOS DE LA CONSULTA Y LOS DEPOSITA EN EL DATAGRID
            MySqlConnection CONEXION = conexion_supervision_tecnica.USR;
            MySqlCommand comando = new MySqlCommand("SELECT * FROM personal_agenda WHERE PERSONAL = '" + NOMBRE.Texts + "'   ", CONEXION);
            CONEXION.Open();
            MySqlDataReader consulta = comando.ExecuteReader();

            while (consulta.Read())
            {
                aa2 = consulta.IsDBNull(2) ? String.Empty : consulta.GetString(2); //NOMBRE
                aa8 = consulta.IsDBNull(8) ? String.Empty : consulta.GetString(8); //SEMESTRE

                string a2 = consulta.IsDBNull(2) ? String.Empty : consulta.GetString(2); //NOMBRE
                string a8 = consulta.IsDBNull(8) ? String.Empty : consulta.GetString(8); //SEMESTRE

                tabla_3.Rows.Add(aa2, aa8);
            }
            CONEXION.Close();
        }



        public void COMPARA_DATOS()
        {
            if (aa2 == NOMBRE.Texts || aa8 == "PRIMER SEMESTRE")
            {
                MessageBox.Show("PRIMERO");
                altoButton1.Enabled = false;
            }
            else if (aa2 == NOMBRE.Texts || aa8 == "SEGUNDO SEMESTRE")
            {
                MessageBox.Show("SEGUNDO");
                altoButton1.Enabled = false;
            }
            else if (aa2 != NOMBRE.Texts || aa8 != "PRIMER SEMESTRE")
            {
                MessageBox.Show("SEGUNDO");
                altoButton1.Enabled = true;
            }
            else if (aa2 != NOMBRE.Texts || aa8 != "SEGUNDO SEMESTRE")
            {
                MessageBox.Show("SEGUNDO");
                altoButton1.Enabled = true;
            }
            else
            {
                altoButton1.Enabled = true;
                MessageBox.Show("mmmmmmm");
            }
        }








        private void altoButton1_Click(object sender, EventArgs e)
        {
            fechas();

            this.Size = new Size(783, 358);
            //myBGWorker.RunWorkerAsync();


            conexion_supervision_tecnica.Consultageneral("INSERT INTO personal_agenda(ID_EVALUACION, PERSONAL, FECHA_TENTATIVA, MOTIVO, ESTATUS, RESULTADO, CATEGORIA, SEMESTRE, EVALUADOR, USUARIO, PROCESO, FECHA_HOY) VALUES('" + ID.Text + "', '" + NOMBRE.Texts.ToUpper() + "','" + FECHA.Text + "','" + MOTIVO.Texts.ToUpper() + "','PENDIENTE', '0.00', '" + CATEGORIA.Texts.ToUpper() + "', '" + SEMESTRE2 + "', '" + EVALUADOR.Texts.ToUpper() + "', '" + SESION.usuario + "', '" + SESION.proceso + "', '" + HOY.ToString("yyyy-MM-dd H:mm:ss") + "')   ");
        }


        private void fechas()
        {

            MOTIVO.Items.Clear();
            DateTime fec = DateTime.Parse(FECHA.Text);
            DateTime actual = DateTime.Parse(fec.ToString("yyyy") + "-06-01");

            if (fec < actual)
            {
                MOTIVO.Items.Add("SUPERVISIÓN PRIMER SEMESTRE");
                MOTIVO.Items.Add("CATEGORIZACIÓN");
                SEMESTRE2 = "PRIMER SEMESTRE";
            }
            else
            {
                MOTIVO.Items.Add("SUPERVISIÓN SEGUNDO SEMESTRE");
                MOTIVO.Items.Add("CATEGORIZACIÓN");
                SEMESTRE2 = "SEGUNDO SEMESTRE";
            }
        }



        private void FECHA_ValueChanged(object sender, EventArgs e)
        {
            fechas();
        }



        string met = "";
        string met_uno = "";

        //FORMA DE FECHA
        DateTime HOY = DateTime.Now;

        private void myBGWorker_DoWork(object sender, DoWorkEventArgs e)
        {

            int percentage = 0;

            Random idv = new Random();
            int valoraev = idv.Next(1, 500);
            percentage = percentage + 20;
            myBGWorker.ReportProgress(percentage);

            string lieev = "LIE-S.EV-" + valoraev.ToString();

            conexion_supervision_tecnica.Consultageneral("INSERT INTO personal_agenda(ID_EVALUACION, PERSONAL, FECHA_TENTATIVA, MOTIVO, ESTATUS, RESULTADO, CATEGORIA, SEMESTRE, EVALUADOR, USUARIO, PROCESO, FECHA_HOY) VALUES('" + lieev + "','" + NOMBRE.Texts + "','" + FECHA.Text + "','" + MOTIVO.Texts + "','PENDIENTE', '0.00', '" + CATEGORIA.Texts + "', '" + SEMESTRE2 + "', '" + EVALUADOR.Texts + "', '" + SESION.usuario + "', '" + SESION.proceso + "', '" + HOY.ToString("yyyy-MM-dd H:mm:ss") + "')");

            percentage = percentage + 20;
            myBGWorker.ReportProgress(percentage);

            MySqlConnection CONEXION = conexion_supervision_tecnica.USR;


            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            if (CATEGORIA.Texts == "4 LABORATORISTA C CAMPO")
            {
                MySqlCommand comando = new MySqlCommand("SELECT NORMA FROM categorias_norma  WHERE CATEGORIA = '" + CATEGORIA.Texts + "' ORDER BY NORMA ASC", CONEXION);
                CONEXION.Open();
                MySqlDataReader consulta = comando.ExecuteReader();

                percentage = percentage + 20;
                myBGWorker.ReportProgress(percentage);


                while (consulta.Read())
                {
                    string nor = consulta.IsDBNull(0) ? String.Empty : consulta.GetString(0);

                    int contador = 5;
                    Invoke(new MethodInvoker(() =>
                    {

                        tabla.DataSource = conexion_supervision_tecnica3.Consultageneral("SELECT DESCRIPCION, AREA FROM normas WHERE NORMA = '" + nor + "'");
                        if (tabla.RowCount > 0)
                        {
                            met = tabla.Rows[0].Cells[0].Value.ToString();
                            met_uno = tabla.Rows[0].Cells[1].Value.ToString();
                        }
                        else
                        {
                            met = "Desconocidos";
                            met_uno = "Desconocidos";
                        }
                    }));

                    ComboBox COM = new ComboBox();
                    MySqlConnection CONEXION2 = conexion_supervision_tecnica2.USR;
                    MySqlCommand comando2 = new MySqlCommand("SELECT ID_CUESTION FROM cuestionaminetos_norma  WHERE NORMA = '" + nor + "' ", CONEXION2);
                    CONEXION2.Open();
                    MySqlDataReader consulta2 = comando2.ExecuteReader();
                    Random rnd = new Random();
                    while (consulta2.Read())
                    {
                        COM.Items.Add(consulta2["ID_CUESTION"].ToString());
                    }


                    while (contador > 0)
                    {

                        int index = rnd.Next(0, COM.Items.Count);
                        string dada = COM.Items[index].ToString();
                        conexion_supervision_tecnica3.Consultageneral("INSERT INTO evaluacion_personal (ID_EVALUACION, ID_CUESTION, NORMA, CALIFICACION, METODO, FECHA, NOMBRE, AREA) VALUES('" + lieev + "', '" + dada + "', '" + nor + "', '0.00', '" + met + "', '" + FECHA.Text + "', '" + NOMBRE.Texts + "', '" + met_uno + "')");

                        contador = contador - 1;

                        COM.Items.RemoveAt(index);
                    }


                    CONEXION2.Close();
                    PORCENTAJEFUNCION = 80;

                    percentage = PORCENTAJEFUNCION;
                    myBGWorker.ReportProgress(percentage);
                }



                CONEXION.Close();

                percentage = percentage + 20;
                myBGWorker.ReportProgress(percentage);
            }


            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////



            if (CATEGORIA.Texts == "4 LABORATORISTA C (TERRACERIAS Y ASFALTO)")
            {
                MySqlCommand comando = new MySqlCommand("SELECT NORMA FROM categorias_norma  WHERE CATEGORIA = '" + CATEGORIA.Texts + "' ORDER BY NORMA ASC", CONEXION);
                CONEXION.Open();
                MySqlDataReader consulta = comando.ExecuteReader();

                percentage = percentage + 20;
                myBGWorker.ReportProgress(percentage);


                while (consulta.Read())
                {
                    string nor = consulta.IsDBNull(0) ? String.Empty : consulta.GetString(0);

                    int contador = 5;
                    Invoke(new MethodInvoker(() =>
                    {

                        tabla.DataSource = conexion_supervision_tecnica3.Consultageneral("SELECT DESCRIPCION, AREA FROM normas WHERE NORMA = '" + nor + "'");
                        if (tabla.RowCount > 0)
                        {
                            met = tabla.Rows[0].Cells[0].Value.ToString();
                            met_uno = tabla.Rows[0].Cells[1].Value.ToString();
                        }
                        else
                        {
                            met = "Desconocidos";
                            met_uno = "Desconocidos";
                        }
                    }));

                    ComboBox COM = new ComboBox();
                    MySqlConnection CONEXION2 = conexion_supervision_tecnica2.USR;
                    MySqlCommand comando2 = new MySqlCommand("SELECT ID_CUESTION FROM cuestionaminetos_norma  WHERE NORMA = '" + nor + "' ", CONEXION2);
                    CONEXION2.Open();
                    MySqlDataReader consulta2 = comando2.ExecuteReader();
                    Random rnd = new Random();
                    while (consulta2.Read())
                    {
                        COM.Items.Add(consulta2["ID_CUESTION"].ToString());
                    }


                    while (contador > 0)
                    {

                        int index = rnd.Next(0, COM.Items.Count);
                        string dada = COM.Items[index].ToString();
                        conexion_supervision_tecnica3.Consultageneral("INSERT INTO evaluacion_personal (ID_EVALUACION, ID_CUESTION, NORMA, CALIFICACION, METODO, FECHA, NOMBRE, AREA) VALUES('" + lieev + "', '" + dada + "', '" + nor + "', '0.00', '" + met + "', '" + FECHA.Text + "', '" + NOMBRE.Texts + "', '" + met_uno + "')");

                        contador = contador - 1;

                        COM.Items.RemoveAt(index);
                    }


                    CONEXION2.Close();
                    PORCENTAJEFUNCION = 80;

                    percentage = PORCENTAJEFUNCION;
                    myBGWorker.ReportProgress(percentage);
                }



                CONEXION.Close();

                percentage = percentage + 20;
                myBGWorker.ReportProgress(percentage);
            }


            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////



            if (CATEGORIA.Texts == "4 INGENIERÍA MS C")
            {
                MySqlCommand comando = new MySqlCommand("SELECT NORMA FROM categorias_norma  WHERE CATEGORIA = '" + CATEGORIA.Texts + "' ORDER BY NORMA ASC", CONEXION);
                CONEXION.Open();
                MySqlDataReader consulta = comando.ExecuteReader();

                percentage = percentage + 20;
                myBGWorker.ReportProgress(percentage);


                while (consulta.Read())
                {
                    string nor = consulta.IsDBNull(0) ? String.Empty : consulta.GetString(0);

                    int contador = 5;
                    Invoke(new MethodInvoker(() =>
                    {

                        tabla.DataSource = conexion_supervision_tecnica3.Consultageneral("SELECT DESCRIPCION, AREA FROM normas WHERE NORMA = '" + nor + "'");
                        if (tabla.RowCount > 0)
                        {
                            met = tabla.Rows[0].Cells[0].Value.ToString();
                            met_uno = tabla.Rows[0].Cells[1].Value.ToString();
                        }
                        else
                        {
                            met = "Desconocidos";
                            met_uno = "Desconocidos";
                        }
                    }));

                    ComboBox COM = new ComboBox();
                    MySqlConnection CONEXION2 = conexion_supervision_tecnica2.USR;
                    MySqlCommand comando2 = new MySqlCommand("SELECT ID_CUESTION FROM cuestionaminetos_norma  WHERE NORMA = '" + nor + "' ", CONEXION2);
                    CONEXION2.Open();
                    MySqlDataReader consulta2 = comando2.ExecuteReader();
                    Random rnd = new Random();
                    while (consulta2.Read())
                    {
                        COM.Items.Add(consulta2["ID_CUESTION"].ToString());
                    }


                    while (contador > 0)
                    {

                        int index = rnd.Next(0, COM.Items.Count);
                        string dada = COM.Items[index].ToString();
                        conexion_supervision_tecnica3.Consultageneral("INSERT INTO evaluacion_personal (ID_EVALUACION, ID_CUESTION, NORMA, CALIFICACION, METODO, FECHA, NOMBRE, AREA) VALUES('" + lieev + "', '" + dada + "', '" + nor + "', '0.00', '" + met + "', '" + FECHA.Text + "', '" + NOMBRE.Texts + "', '" + met_uno + "')");

                        contador = contador - 1;

                        COM.Items.RemoveAt(index);
                    }


                    CONEXION2.Close();
                    PORCENTAJEFUNCION = 80;

                    percentage = PORCENTAJEFUNCION;
                    myBGWorker.ReportProgress(percentage);
                }



                CONEXION.Close();

                percentage = percentage + 20;
                myBGWorker.ReportProgress(percentage);
            }


            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////










            if (CATEGORIA.Texts == "5 AUXILIAR LABORATORISTA")
            {

            }

            if (CATEGORIA.Texts == "5 AUXILIAR LABORATORISTA (PND)")
            {

            }

            if (CATEGORIA.Texts == "5 AUXILIAR DE CAMPO")
            {

            }

            if (CATEGORIA.Texts == "5 AUXILIAR OPERATIVO")
            {

            }









            if (MOTIVO.Texts == "CATEGORIZACIÓN")
            {
                MySqlCommand comando = new MySqlCommand("SELECT NORMA FROM categorias_norma  WHERE CATEGORIA = '" + CATEGORIA.Texts + "' ORDER BY NORMA ASC", CONEXION);
                CONEXION.Open();
                MySqlDataReader consulta = comando.ExecuteReader();

                percentage = percentage + 20;
                myBGWorker.ReportProgress(percentage);


                while (consulta.Read())
                {
                    string nor = consulta.IsDBNull(0) ? String.Empty : consulta.GetString(0);

                    int contador = 5;
                    Invoke(new MethodInvoker(() =>
                    {

                        tabla.DataSource = conexion_supervision_tecnica3.Consultageneral("SELECT DESCRIPCION, AREA FROM normas WHERE NORMA = '" + nor + "'");
                        if (tabla.RowCount > 0)
                        {
                            met = tabla.Rows[0].Cells[0].Value.ToString();
                            met_uno = tabla.Rows[0].Cells[1].Value.ToString();
                        }
                        else
                        {
                            met = "Desconocidos";
                            met_uno = "Desconocidos";
                        }
                    }));

                    ComboBox COM = new ComboBox();
                    MySqlConnection CONEXION2 = conexion_supervision_tecnica2.USR;
                    MySqlCommand comando2 = new MySqlCommand("SELECT ID_CUESTION FROM cuestionaminetos_norma  WHERE NORMA = '" + nor + "' ", CONEXION2);
                    CONEXION2.Open();
                    MySqlDataReader consulta2 = comando2.ExecuteReader();
                    Random rnd = new Random();
                    while (consulta2.Read())
                    {
                        COM.Items.Add(consulta2["ID_CUESTION"].ToString());
                    }


                    while (contador > 0)
                    {

                        int index = rnd.Next(0, COM.Items.Count);
                        string dada = COM.Items[index].ToString();
                        conexion_supervision_tecnica3.Consultageneral("INSERT INTO evaluacion_personal (ID_EVALUACION, ID_CUESTION, NORMA, CALIFICACION, METODO, FECHA, NOMBRE, AREA) VALUES('" + lieev + "', '" + dada + "', '" + nor + "', '0.00', '" + met + "', '" + FECHA.Text + "', '" + NOMBRE.Texts + "', '" + met_uno + "')");

                        contador = contador - 1;

                        COM.Items.RemoveAt(index);
                    }


                    CONEXION2.Close();
                    PORCENTAJEFUNCION = 80;

                    percentage = PORCENTAJEFUNCION;
                    myBGWorker.ReportProgress(percentage);
                }



                CONEXION.Close();

                percentage = percentage + 20;
                myBGWorker.ReportProgress(percentage);

            }




            else
            {
                MySqlCommand comando = new MySqlCommand("SELECT NORMA FROM categorias_norma  WHERE CATEGORIA = '" + CATEGORIA.Texts + "' ORDER BY RAND() LIMIT 0,10 ", CONEXION);
                CONEXION.Open();
                MySqlDataReader consulta = comando.ExecuteReader();

                percentage = percentage + 20;
                myBGWorker.ReportProgress(percentage);


                while (consulta.Read())
                {
                    string nor = consulta.IsDBNull(0) ? String.Empty : consulta.GetString(0);

                    int contador = 5;
                    Invoke(new MethodInvoker(() =>
                    {

                        tabla.DataSource = conexion_supervision_tecnica3.Consultageneral("SELECT DESCRIPCION, AREA FROM normas WHERE NORMA = '" + nor + "'");
                        if (tabla.RowCount > 0)
                        {
                            met = tabla.Rows[0].Cells[0].Value.ToString();
                            met_uno = tabla.Rows[0].Cells[1].Value.ToString();
                        }
                        else
                        {
                            met = "Desconocidos";
                            met_uno = "Desconocidos";
                        }
                    }));

                    ComboBox COM = new ComboBox();
                    MySqlConnection CONEXION2 = conexion_supervision_tecnica2.USR;
                    MySqlCommand comando2 = new MySqlCommand("SELECT ID_CUESTION FROM cuestionaminetos_norma  WHERE NORMA = '" + nor + "' ", CONEXION2);
                    CONEXION2.Open();
                    MySqlDataReader consulta2 = comando2.ExecuteReader();
                    Random rnd = new Random();
                    while (consulta2.Read())
                    {
                        COM.Items.Add(consulta2["ID_CUESTION"].ToString());
                    }


                    while (contador > 0)
                    {

                        int index = rnd.Next(0, COM.Items.Count);
                        string dada = COM.Items[index].ToString();
                        conexion_supervision_tecnica3.Consultageneral("INSERT INTO evaluacion_personal (ID_EVALUACION, ID_CUESTION, NORMA, CALIFICACION, METODO, FECHA, NOMBRE, AREA) VALUES('" + lieev + "', '" + dada + "', '" + nor + "', '0.00', '" + met + "', '" + FECHA.Text + "', '" + NOMBRE.Texts + "', '" + met_uno + "')");

                        contador = contador - 1;

                        COM.Items.RemoveAt(index);
                    }

                    CONEXION2.Close();
                    PORCENTAJEFUNCION = 80;

                    percentage = PORCENTAJEFUNCION;
                    myBGWorker.ReportProgress(percentage);
                }



                CONEXION.Close();

                percentage = percentage + 20;
                myBGWorker.ReportProgress(percentage);

            }









        }

        private void myBGWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            myProgressBar.Value = e.ProgressPercentage;
            porc.Text = Convert.ToString(e.ProgressPercentage) + " %";
        }

        private void myBGWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

            this.Size = new Size(783, 295);

            MENSAJE_GENERAL MN = new MENSAJE_GENERAL();
            MN.BOTON.Text = "¡Personal agendado correctamente!";
            MN.ShowDialog();

            PORCENTAJEFUNCION = 0;

            this.Close();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {

        }

        private void MOTIVO_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            //COMPARA_DATOS();


        }




    }
}
