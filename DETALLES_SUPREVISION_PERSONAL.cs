using ERP_LIEC;
using MySql.Data.MySqlClient;  //DEFINEN UN AMBITO PARA UTILIZAR RECURSOS//
using System;  //DEFINEN UN AMBITO PARA UTILIZAR RECURSOS//
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ERP_COMPLETO   //NOMBRE DEL ESPACIO
{
    public partial class DETALLES_SUPREVISION_PERSONAL : Form  //CLASE PRINCIPAL DEL FORMULARIO ACTUAL
    {
        public DETALLES_SUPREVISION_PERSONAL()
        {
            InitializeComponent();   //INICIALIZA COMPONENTE
        }


        public bool semestre_primero = true;  //VARIABLES INICIALES
        public string semestre = null;
        public bool no_realizado = false;

        public string categoria = null;  //VARIABLES INICIALES
        public string filtro = null;

        public double rango1 = 0;
        public double rango2 = 0;  //VARIABLES INICIALES

        public string name_ev = "";
        public string id_ev = "";





        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();   //CIERRA VENTANA
        }

        string norm;
        double cal;

        private void no_real_1s()
        {
            tabla.DataSource = conexion_rh.Consultageneral("SELECT NOMBRE  FROM  pdr_personal1  WHERE CATEGORIA = '" + filtro + "'");  //QUERY DE CONSULTA

            foreach (DataGridViewRow row in tabla.Rows)   //RECORRIDO DE INFORMACION
            {
                MySqlConnection CONEXION = conexion_supervision_tecnica2.USR;   //CONEXION A DB 
                                                                                //QUERY DE CONSULTA
                MySqlCommand comando = new MySqlCommand("SELECT PERSONAL, RESULTADO FROM personal_agenda WHERE (PERSONAL = '" + row.Cells[0].Value.ToString() + "') AND ( CATEGORIA LIKE '%" + filtro + "%' AND FECHA_TENTATIVA < '" + semestre + "')", CONEXION);

                CONEXION.Open();   //CONEXION A DB 
                MySqlDataReader consulta = comando.ExecuteReader();
                if (consulta.Read())
                {


                }
                else
                {


                    TABLA_PESONAL.Rows.Add(row.Cells[0].Value.ToString(), "-");    //DEPOSITO DE INFORMACION

                }
                CONEXION.Close();   //CIERRE DE CONEXION


            }






        }

        private void no_real_2s()
        {
            tabla.DataSource = conexion_rh.Consultageneral("SELECT NOMBRE  FROM  pdr_personal1  WHERE CATEGORIA = '" + filtro + "'");  //QUERY DE CONSULTA

            foreach (DataGridViewRow row in tabla.Rows)   //RECORRIDO DE INFORMACION
            {
                MySqlConnection CONEXION = conexion_supervision_tecnica2.USR;   //CONEXION A DB 
                                                                                //QUERY DE CONSULTA
                MySqlCommand comando = new MySqlCommand("SELECT PERSONAL, RESULTADO FROM personal_agenda WHERE (PERSONAL = '" + row.Cells[0].Value.ToString() + "') AND ( CATEGORIA LIKE '%" + filtro + "%' AND FECHA_TENTATIVA > '" + semestre + "')", CONEXION);

                CONEXION.Open();    //CONEXION A DB 
                MySqlDataReader consulta = comando.ExecuteReader();
                if (consulta.Read())
                {


                }
                else
                {
                    TABLA_PESONAL.Rows.Add(row.Cells[0].Value.ToString(), "-");   //DEPOSITO DE INFORMACION

                }


                CONEXION.Close();   //CIERRE DE CONEXION
            }






        }
        private void normas_acordes_general()
        {

            tabla.DataSource = conexion_supervision_tecnica2.Consultageneral("SELECT NORMA FROM categorias_norma WHERE CATEGORIA = '" + categoria + "'");   //QUERY DE CONSULTA
            tabla2.DataSource = conexion_supervision_tecnica.Consultageneral("SELECT PERSONAL, RESULTADO , ID_EVALUACION FROM personal_agenda WHERE (CATEGORIA LIKE '%" + filtro + "%' AND FECHA_TENTATIVA < '" + semestre + "') AND (RESULTADO >= '0' AND RESULTADO <= '100' )");

            foreach (DataGridViewRow row in tabla.Rows)   //RECORRIDO DE INFORMACION
            {
                norm = "";
                cal = 0;





                foreach (DataGridViewRow row2 in tabla2.Rows)   //RECORRIDO DE INFORMACION
                {
                    MySqlConnection CONEXION = conexion_supervision_tecnica3.USR;
                    //QUERY DE CONSULTA
                    MySqlCommand comando = new MySqlCommand("SELECT NORMA, CALIFICACION FROM evaluacion_personal WHERE ID_EVALUACION = '" + row2.Cells[2].Value.ToString() + "' AND NORMA = '" + row.Cells[0].Value.ToString() + "' ", CONEXION);

                    CONEXION.Open();  //CONEXION A DB 
                    MySqlDataReader consulta = comando.ExecuteReader();
                    while (consulta.Read())
                    {


                        norm = consulta.IsDBNull(0) ? String.Empty : consulta.GetString(0);   //DEPOSITO DE INFORMACION
                        string a1 = consulta.IsDBNull(1) ? String.Empty : consulta.GetString(1);   //DEPOSITO DE INFORMACION

                        cal = double.Parse(a1) + cal;

                    }
                    CONEXION.Close();   //CIERRE DE CONEXION




                }


                double rang = TABLA_PESONAL.RowCount;
                double total_norma = cal / rang;
                NOMRAS_TAB.Rows.Add(norm, total_norma);


            }

        }
        private void normas_acordes_general2()
        {

            tabla.DataSource = conexion_supervision_tecnica2.Consultageneral("SELECT NORMA FROM categorias_norma WHERE CATEGORIA = '" + categoria + "'");   //QUERY DE CONSULTA
            tabla2.DataSource = conexion_supervision_tecnica.Consultageneral("SELECT PERSONAL, RESULTADO , ID_EVALUACION FROM personal_agenda WHERE (CATEGORIA LIKE '%" + filtro + "%' AND FECHA_TENTATIVA >'" + semestre + "') AND (RESULTADO >= '0' AND RESULTADO <= '100' )");

            foreach (DataGridViewRow row in tabla.Rows)   //RECORRIDO DE INFORMACION
            {
                norm = "";
                cal = 0;





                foreach (DataGridViewRow row2 in tabla2.Rows)   //RECORRIDO DE INFORMACION
                {
                    MySqlConnection CONEXION = conexion_supervision_tecnica3.USR;   //CONEXION A DB
                                                                                    //QUERY DE CONSULTA
                    MySqlCommand comando = new MySqlCommand("SELECT NORMA, CALIFICACION FROM evaluacion_personal WHERE ID_EVALUACION = '" + row2.Cells[2].Value.ToString() + "' AND NORMA = '" + row.Cells[0].Value.ToString() + "' ", CONEXION);

                    CONEXION.Open();   //CONEXION A DB
                    MySqlDataReader consulta = comando.ExecuteReader();
                    while (consulta.Read())
                    {


                        norm = consulta.IsDBNull(0) ? String.Empty : consulta.GetString(0);   //DEPOSITO DE INFORMACION
                        string a1 = consulta.IsDBNull(1) ? String.Empty : consulta.GetString(1);   //DEPOSITO DE INFORMACION

                        cal = double.Parse(a1) + cal;

                    }
                    CONEXION.Close();   //CIERRE DE CONEXION




                }


                double rang = TABLA_PESONAL.RowCount;
                double total_norma = cal / rang;
                NOMRAS_TAB.Rows.Add(norm, total_norma);


            }

        }


        private void colores_esc()
        {


            foreach (DataGridViewRow row in NOMRAS_TAB.Rows)    //RECORRIDO DE INFORMACION
            {

                double ade = double.Parse(row.Cells[1].Value.ToString());
                if (ade >= 0 && ade < 40) { row.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(240, 179, 179); }   //CONDICIONAL 
                if (ade >= 40 && ade < 60) { row.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(217, 228, 152); }   //CONDICIONAL 
                if (ade >= 60 && ade < 80) { row.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(179, 224, 240); }   //CONDICIONAL 
                if (ade >= 80 && ade <= 100) { row.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(182, 228, 152); }   //CONDICIONAL 




            }

        }




        private void normas_acordes_filtro()
        {


            tabla.DataSource = conexion_supervision_tecnica2.Consultageneral("SELECT NORMA FROM categorias_norma WHERE CATEGORIA = '" + categoria + "'");   //QUERY DE CONSULTA
            foreach (DataGridViewRow row in tabla.Rows)  //RECORRIDO DE INFORMACION
            {
                norm = "";
                cal = 0;
                foreach (DataGridViewRow row2 in TABLA_PESONAL.Rows)  //RECORRIDO DE INFORMACION
                {
                    MySqlConnection CONEXION = conexion_supervision_tecnica3.USR;   //CONEXION A DB 
                                                                                    //QUERY DE CONSULTA
                    MySqlCommand comando = new MySqlCommand("SELECT NORMA, CALIFICACION FROM evaluacion_personal WHERE ID_EVALUACION = '" + row2.Cells[2].Value.ToString() + "' AND NORMA = '" + row.Cells[0].Value.ToString() + "' ", CONEXION);

                    CONEXION.Open();
                    MySqlDataReader consulta = comando.ExecuteReader();
                    while (consulta.Read())
                    {


                        norm = consulta.IsDBNull(0) ? String.Empty : consulta.GetString(0);  //DEPOSITO DE INFORMACION
                        string a1 = consulta.IsDBNull(1) ? String.Empty : consulta.GetString(1);  //DEPOSITO DE INFORMACION

                        cal = double.Parse(a1) + cal;

                    }
                    CONEXION.Close();   //CIERRE DE CONEXION




                }

                double rang = TABLA_PESONAL.RowCount;
                double total_norma = cal / rang;
                NOMRAS_TAB.Rows.Add(norm, total_norma);


            }
        }

        private void consulta_perso_1SE()
        {

            MySqlConnection CONEXION = conexion_supervision_tecnica.USR;    //CONEXION A DB 
                                                                            //QUERY DE CONSULTA
            MySqlCommand comando = new MySqlCommand("SELECT PERSONAL, RESULTADO , ID_EVALUACION FROM personal_agenda WHERE (CATEGORIA LIKE '%" + filtro + "%' AND FECHA_TENTATIVA < '" + semestre + "') AND (RESULTADO >= '" + rango1 + "' AND RESULTADO <= '" + rango2 + "' )", CONEXION);

            CONEXION.Open();   //CONEXION A DB 
            MySqlDataReader consulta = comando.ExecuteReader();
            while (consulta.Read())
            {
                string a0 = consulta.IsDBNull(0) ? String.Empty : consulta.GetString(0);   //DEPOSITO DE INFORMACION
                string a1 = consulta.IsDBNull(1) ? String.Empty : consulta.GetString(1);   //DEPOSITO DE INFORMACION
                string a2 = consulta.IsDBNull(2) ? String.Empty : consulta.GetString(2);   //DEPOSITO DE INFORMACION



                TABLA_PESONAL.Rows.Add(a0, a1, a2);
            }
            CONEXION.Close();   //CIERRE DE CONEXION
        }

        private void consulta_perso_2SE()
        {
            MySqlConnection CONEXION = conexion_supervision_tecnica.USR;   //CONEXION A DB 
                                                                           //QUERY DE CONSULTA
            MySqlCommand comando = new MySqlCommand("SELECT PERSONAL, RESULTADO , ID_EVALUACION FROM personal_agenda WHERE (CATEGORIA LIKE '%" + filtro + "%' AND FECHA_TENTATIVA > '" + semestre + "') AND (RESULTADO >= '" + rango1 + "' AND  RESULTADO <= '" + rango2 + "')", CONEXION);

            CONEXION.Open();  //CONEXION A DB 
            MySqlDataReader consulta = comando.ExecuteReader();
            while (consulta.Read())
            {
                string a0 = consulta.IsDBNull(0) ? String.Empty : consulta.GetString(0);    //DEPOSITO DE INFORMACION
                string a1 = consulta.IsDBNull(1) ? String.Empty : consulta.GetString(1);    //DEPOSITO DE INFORMACION
                string a2 = consulta.IsDBNull(2) ? String.Empty : consulta.GetString(2);    //DEPOSITO DE INFORMACION



                TABLA_PESONAL.Rows.Add(a0, a1, a2);    //DEPOSITO DE INFORMACION
            }
            CONEXION.Close();   //CIERRE DE CONEXION
        }
        private void consulta_norma()
        {

        }

        private void DETALLES_SUPREVISION_PERSONAL_Load(object sender, EventArgs e)  //FUNCION PRINCIPAL DE ARRANQUE
        {
            this.Size = new Size(890, 602);
            categoria = filtro;


            img_titulo.Size = new Size(30, 30);  //ESTILOS APLICABLES A ELEMENTOS 
            titulo.Left = (p_titulo.Width - titulo.Width) / 2;
            titulo.Top = (p_titulo.Height - titulo.Height) / 2;  //ESTILOS APLICABLES A ELEMENTOS 

            img_titulo.Left = (titulo.Left - img_titulo.Width) - 5;
            img_titulo.Top = (img_titulo.Height - img_titulo.Height) / 2;  //ESTILOS APLICABLES A ELEMENTOS 


            if (no_realizado == true)  //CONDICIONAL 
            {

                if (semestre_primero == true)
                {
                    no_real_1s();

                }
                else
                {
                    no_real_2s();
                }

            }
            else
            {

                if (semestre_primero == true)  //CONDICIONAL 
                {
                    consulta_perso_1SE();

                }
                else
                {
                    consulta_perso_2SE();
                }

            }

            timer1.Start();

        }

        private void DGV_EVENTOS_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            tabla2.DataSource = conexion_rh.Consultageneral("SELECT NOMBRE, AREA_2, CATEGORIA, FECHA_INGRESO FROM pdr_personal1 WHERE NOMBRE = '" + TABLA_PESONAL.CurrentRow.Cells[0].Value.ToString() + "'");  //QUERY DE CONSULTA

            if (tabla2.Rows.Count > 0)
            {
                panel1.Visible = true;

                this.Size = new Size(890, 751);

                nombre.Text = tabla2.Rows[0].Cells[0].Value.ToString();  //INFO DEPOSITADA EN COORDENADAS 
                area.Text = tabla2.Rows[0].Cells[1].Value.ToString();  //INFO DEPOSITADA EN COORDENADAS 
                cate.Text = tabla2.Rows[0].Cells[2].Value.ToString();  //INFO DEPOSITADA EN COORDENADAS 
                fecha_in.Text = tabla2.Rows[0].Cells[3].Value.ToString();  //INFO DEPOSITADA EN COORDENADAS 

                string ruta1 = @"Z:\LIEP-01 PERSONAL\2023\REGISTROS\01 RRHH\3 DOCUMENTOS PERSONAL\DOCUMENTOS ERP\FOTOGRAFIA\" + nombre.Text + @"\" + nombre.Text + " - FOTOGRAFIA" + ".PNG";    //RUTAS DE ACCESO A RECURSOS 

                if (File.Exists(ruta1))  //VALIDA EXISTENCIA DE CARPETA 
                {
                    pictureBox2.Image = System.Drawing.Image.FromFile(ruta1);
                    pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                else
                {
                    pictureBox2.Image = ERP_COMPLETO.Properties.Resources.MI_FOTOGRAFIA_2;
                }
            }
            else
            {
                panel1.Visible = false;

                this.Size = new Size(890, 602);

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

        private void altoButton1_Click(object sender, EventArgs e)
        {
            NOMRAS_TAB.Rows.Clear();
            label2.Text = "PUNTAJE PROMEDIO DE NORMAS: " + filtro;  //MENSAJE ALERTA 
            normas_acordes_filtro();
            colores_esc();
            MENSAJE_GENERAL MN = new MENSAJE_GENERAL();
            MN.BOTON.Text = "Información cargada con exíto";
            MN.Show();
        }

        private void altoButton2_Click(object sender, EventArgs e)
        {


            if (semestre_primero == true)
            {
                label7.Text = "PUNTAJE PROMEDIO DE NORMAS: " + filtro;
                normas_acordes_general();
                colores_esc();
                MENSAJE_GENERAL MN = new MENSAJE_GENERAL();  //MENSAJE ALERTA 
                MN.BOTON.Text = "Información cargada con exíto";
                MN.Show();
            }
            else
            {
                label7.Text = "PUNTAJE PROMEDIO DE NORMAS: GENERAL";
                normas_acordes_general2();
                colores_esc();
                MENSAJE_GENERAL MN = new MENSAJE_GENERAL();  //MENSAJE ALERTA 
                MN.BOTON.Text = "Información cargada con exíto";
                MN.Show();
            }




        }
    }
}
