using ERP_LIEC;
using LiveCharts;
using MySql.Data.MySqlClient;
using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;


namespace ERP_COMPLETO
{
    public partial class Indicadores_SUP : Form
    {
        public Indicadores_SUP()
        {
            InitializeComponent();
        }
        int alto = 0;  //VARIABLES INICIALES
        int medio = 0;
        int bajo = 0;
        int muy_bajo = 0;
        int no_realizadas = 0;
        int PORCENTAJEFUNCION = 0;
        private void Indicadores_SUP_Load(object sender, EventArgs e)
        {

            estatica();
            consulta_reportes();

            consulta_reportes2();
            consulta_reportes3();
            consulta_porc_reporte();
            //tomar_categorias();




            label30.Text = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(f1.ToString("MMM"));
            label9.Text = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(f2.ToString("MMM"));
            label13.Text = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(f3.ToString("MMM"));


            //  altoButton1.Enabled = false;

            myBGWorker.RunWorkerAsync();

        }



        int s1_1 = 0;
        int s2_1 = 0;
        int s3_1 = 0;
        int s4_1 = 0;
        int s5_1 = 0;
        int s6_1 = 0;
        int s7_1 = 0;

        int s1_2 = 0;
        int s2_2 = 0;
        int s3_2 = 0;
        int s4_2 = 0;
        int s5_2 = 0;
        int s6_2 = 0;
        int s7_2 = 0;

        int s1_3 = 0;
        int s2_3 = 0;
        int s3_3 = 0;
        int s4_3 = 0;
        int s5_3 = 0;
        int s6_3 = 0;
        int s7_3 = 0;



        DateTime f1 = DateTime.Today.AddMonths(-2);
        DateTime f2 = DateTime.Today.AddMonths(-1);
        DateTime f3 = DateTime.Today;
        private void consulta_reportes()
        {


            MySqlConnection CONEXIONs = conexion_supervision_tecnica.USR;

            MySqlCommand comandos = new MySqlCommand("SELECT ID_SEGUIMIENTO FROM    reporte_supervision WHERE (YEAR(FECHA) = '" + f1.ToString("yyyy") + "' AND MONTH(FECHA) = '" + f1.ToString("MM") + "') AND (NOMBRE = 'CONCEPCIÓN JIMÉNEZ MEDINA') ", CONEXIONs);    //QUERY DE CONSULTA

            CONEXIONs.Open();
            MySqlDataReader consultas = comandos.ExecuteReader();
            if (consultas.Read())
            {
                CLIM1.Image = ERP_COMPLETO.Properties.Resources.ICO_DOC_NAR;


                s1_1 = s1_1 + 1;


            }
            else
            {
                CLIM1.Image = ERP_COMPLETO.Properties.Resources.ICO_DOC_GRIS;
            }
            CONEXIONs.Close();
            /////////////////////////////////////////////////////////////////////////////////////////////////////////
            MySqlConnection CONEXION2 = conexion_supervision_tecnica.USR;

            MySqlCommand comando2 = new MySqlCommand("SELECT ID_SEGUIMIENTO FROM    reporte_supervision WHERE (YEAR(FECHA) = '" + f1.ToString("yyyy") + "' AND MONTH(FECHA) = '" + f1.ToString("MM") + "') AND (NOMBRE = 'ROBERTO CERÓN ÁLVAREZ') ", CONEXION2);    //QUERY DE CONSULTA

            CONEXION2.Open();
            MySqlDataReader consulta2 = comando2.ExecuteReader();
            if (consulta2.Read())
            {
                CLIM2.Image = ERP_COMPLETO.Properties.Resources.ICO_DOC_NAR;


                s2_1 = s2_1 + 1;


            }
            else
            {
                CLIM2.Image = ERP_COMPLETO.Properties.Resources.ICO_DOC_GRIS;
            }
            CONEXION2.Close();
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////
            /////////////////////////////////////////////////////////////////////////////////////////////////////////////
            MySqlConnection CONEXION3 = conexion_supervision_tecnica.USR;

            MySqlCommand comando3 = new MySqlCommand("SELECT ID_SEGUIMIENTO FROM    reporte_supervision WHERE (YEAR(FECHA) = '" + f1.ToString("yyyy") + "' AND MONTH(FECHA) = '" + f1.ToString("MM") + "') AND (NOMBRE = 'BERTÍN LAGUNAS RAMÍREZ') ", CONEXION3);    //QUERY DE CONSULTA

            CONEXION3.Open();
            MySqlDataReader consulta3 = comando3.ExecuteReader();
            if (consulta3.Read())
            {
                CLIM3.Image = ERP_COMPLETO.Properties.Resources.ICO_DOC_NAR;



                s3_1 = s3_1 + 1;

            }
            else
            {
                CLIM3.Image = ERP_COMPLETO.Properties.Resources.ICO_DOC_GRIS;
            }
            CONEXION3.Close();
            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            ///
             /////////////////////////////////////////////////////////////////////////////////////////////////////////
            MySqlConnection CONEXION4 = conexion_supervision_tecnica.USR;

            MySqlCommand comando4 = new MySqlCommand("SELECT ID_SEGUIMIENTO FROM    reporte_supervision WHERE (YEAR(FECHA) = '" + f1.ToString("yyyy") + "' AND MONTH(FECHA) = '" + f1.ToString("MM") + "') AND (NOMBRE = 'DIEGO MORENO ROMERO') ", CONEXION4);    //QUERY DE CONSULTA

            CONEXION4.Open();
            MySqlDataReader consulta4 = comando4.ExecuteReader();
            if (consulta4.Read())
            {
                CLIM4.Image = ERP_COMPLETO.Properties.Resources.ICO_DOC_NAR;


                s4_1 = s4_1 + 1;


            }
            else
            {
                CLIM4.Image = ERP_COMPLETO.Properties.Resources.ICO_DOC_GRIS;
            }
            CONEXION4.Close();
            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            /////////////////////////////////////////////////////////////////////////////////////////////////////////
            MySqlConnection CONEXION5 = conexion_supervision_tecnica.USR;

            MySqlCommand comando5 = new MySqlCommand("SELECT ID_SEGUIMIENTO FROM    reporte_supervision WHERE (YEAR(FECHA) = '" + f1.ToString("yyyy") + "' AND MONTH(FECHA) = '" + f1.ToString("MM") + "') AND (NOMBRE = 'JORGE DAVID RUTILIO CONSTANTINO') ", CONEXION5);    //QUERY DE CONSULTA

            CONEXION5.Open();
            MySqlDataReader consulta5 = comando5.ExecuteReader();
            if (consulta5.Read())
            {
                CLIM5.Image = ERP_COMPLETO.Properties.Resources.ICO_DOC_NAR;
                s5_1 = s5_1 + 1;




            }
            else
            {
                CLIM5.Image = ERP_COMPLETO.Properties.Resources.ICO_DOC_GRIS;
            }
            CONEXION5.Close();
            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            ///
             /////////////////////////////////////////////////////////////////////////////////////////////////////////
            MySqlConnection CONEXION6 = conexion_supervision_tecnica.USR;

            MySqlCommand comando6 = new MySqlCommand("SELECT ID_SEGUIMIENTO FROM    reporte_supervision WHERE (YEAR(FECHA) = '" + f1.ToString("yyyy") + "' AND MONTH(FECHA) = '" + f1.ToString("MM") + "') AND (NOMBRE = 'JOSÉ GUSTAVO MONTOYA AGUILAR') ", CONEXION6);    //QUERY DE CONSULTA

            CONEXION6.Open();
            MySqlDataReader consulta6 = comando6.ExecuteReader();
            if (consulta6.Read())
            {
                CLIM6.Image = ERP_COMPLETO.Properties.Resources.ICO_DOC_NAR;
                s6_1 = s6_1 + 1;




            }
            else
            {
                CLIM6.Image = ERP_COMPLETO.Properties.Resources.ICO_DOC_GRIS;
            }
            CONEXION6.Close();
            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            ///
             /////////////////////////////////////////////////////////////////////////////////////////////////////////
            MySqlConnection CONEXION7 = conexion_supervision_tecnica.USR;

            MySqlCommand comando7 = new MySqlCommand("SELECT ID_SEGUIMIENTO FROM    reporte_supervision WHERE (YEAR(FECHA) = '" + f1.ToString("yyyy") + "' AND MONTH(FECHA) = '" + f1.ToString("MM") + "') AND (NOMBRE = 'DANIEL MORENO CRUZ') ", CONEXION7);    //QUERY DE CONSULTA

            CONEXION7.Open();
            MySqlDataReader consulta7 = comando7.ExecuteReader();
            if (consulta7.Read())
            {
                CLIM7.Image = ERP_COMPLETO.Properties.Resources.ICO_DOC_NAR;
                s7_1 = s7_1 + 1;




            }
            else
            {
                CLIM7.Image = ERP_COMPLETO.Properties.Resources.ICO_DOC_GRIS;
            }
            CONEXION7.Close();
            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        }

        private void consulta_reportes2()
        {


            MySqlConnection CONEXIONs = conexion_supervision_tecnica.USR;

            MySqlCommand comandos = new MySqlCommand("SELECT ID_SEGUIMIENTO FROM    reporte_supervision WHERE (YEAR(FECHA) = '" + f2.ToString("yyyy") + "' AND MONTH(FECHA) = '" + f2.ToString("MM") + "') AND (NOMBRE = 'CONCEPCIÓN JIMÉNEZ MEDINA') ", CONEXIONs);    //QUERY DE CONSULTA

            CONEXIONs.Open();
            MySqlDataReader consultas = comandos.ExecuteReader();
            if (consultas.Read())
            {
                CLIM1_1.Image = ERP_COMPLETO.Properties.Resources.ICO_DOC_NAR;
                s1_2 = s1_2 + 1;




            }
            else
            {
                CLIM1_1.Image = ERP_COMPLETO.Properties.Resources.ICO_DOC_GRIS;
            }
            CONEXIONs.Close();
            /////////////////////////////////////////////////////////////////////////////////////////////////////////
            MySqlConnection CONEXION2 = conexion_supervision_tecnica.USR;

            MySqlCommand comando2 = new MySqlCommand("SELECT ID_SEGUIMIENTO FROM    reporte_supervision WHERE (YEAR(FECHA) = '" + f2.ToString("yyyy") + "' AND MONTH(FECHA) = '" + f2.ToString("MM") + "') AND (NOMBRE = 'ROBERTO CERÓN ÁLVAREZ') ", CONEXION2);    //QUERY DE CONSULTA

            CONEXION2.Open();
            MySqlDataReader consulta2 = comando2.ExecuteReader();
            if (consulta2.Read())
            {
                CLIM2_1.Image = ERP_COMPLETO.Properties.Resources.ICO_DOC_NAR;
                s2_2 = s2_2 + 1;




            }
            else
            {
                CLIM2_1.Image = ERP_COMPLETO.Properties.Resources.ICO_DOC_GRIS;
            }
            CONEXION2.Close();
            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            /// /////////////////////////////////////////////////////////////////////////////////////////////////////////
            MySqlConnection CONEXION3 = conexion_supervision_tecnica.USR;

            MySqlCommand comando3 = new MySqlCommand("SELECT ID_SEGUIMIENTO FROM    reporte_supervision WHERE (YEAR(FECHA) = '" + f2.ToString("yyyy") + "' AND MONTH(FECHA) = '" + f2.ToString("MM") + "') AND (NOMBRE = 'BERTÍN LAGUNAS RAMÍREZ') ", CONEXION3);    //QUERY DE CONSULTA

            CONEXION3.Open();
            MySqlDataReader consulta3 = comando3.ExecuteReader();
            if (consulta3.Read())
            {
                CLIM3_1.Image = ERP_COMPLETO.Properties.Resources.ICO_DOC_NAR;
                s3_2 = s3_2 + 1;




            }
            else
            {
                CLIM3_1.Image = ERP_COMPLETO.Properties.Resources.ICO_DOC_GRIS;
            }
            CONEXION3.Close();
            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            ///
             /////////////////////////////////////////////////////////////////////////////////////////////////////////
            MySqlConnection CONEXION4 = conexion_supervision_tecnica.USR;

            MySqlCommand comando4 = new MySqlCommand("SELECT ID_SEGUIMIENTO FROM    reporte_supervision WHERE (YEAR(FECHA) = '" + f2.ToString("yyyy") + "' AND MONTH(FECHA) = '" + f2.ToString("MM") + "') AND (NOMBRE = 'DIEGO MORENO ROMERO') ", CONEXION4);    //QUERY DE CONSULTA

            CONEXION4.Open();
            MySqlDataReader consulta4 = comando4.ExecuteReader();
            if (consulta4.Read())
            {
                CLIM4_1.Image = ERP_COMPLETO.Properties.Resources.ICO_DOC_NAR;

                s4_2 = s4_2 + 1;



            }
            else
            {
                CLIM4_1.Image = ERP_COMPLETO.Properties.Resources.ICO_DOC_GRIS;
            }
            CONEXION4.Close();
            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            /////////////////////////////////////////////////////////////////////////////////////////////////////////
            MySqlConnection CONEXION5 = conexion_supervision_tecnica.USR;

            MySqlCommand comando5 = new MySqlCommand("SELECT ID_SEGUIMIENTO FROM    reporte_supervision WHERE (YEAR(FECHA) = '" + f2.ToString("yyyy") + "' AND MONTH(FECHA) = '" + f2.ToString("MM") + "') AND (NOMBRE = 'JORGE DAVID RUTILIO CONSTANTINO') ", CONEXION5);    //QUERY DE CONSULTA

            CONEXION5.Open();
            MySqlDataReader consulta5 = comando5.ExecuteReader();
            if (consulta5.Read())
            {
                CLIM5_1.Image = ERP_COMPLETO.Properties.Resources.ICO_DOC_NAR;
                s5_2 = s5_2 + 1;




            }
            else
            {
                CLIM5_1.Image = ERP_COMPLETO.Properties.Resources.ICO_DOC_GRIS;
            }
            CONEXION5.Close();
            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            ///
             /////////////////////////////////////////////////////////////////////////////////////////////////////////
            MySqlConnection CONEXION6 = conexion_supervision_tecnica.USR;

            MySqlCommand comando6 = new MySqlCommand("SELECT ID_SEGUIMIENTO FROM    reporte_supervision WHERE (YEAR(FECHA) = '" + f2.ToString("yyyy") + "' AND MONTH(FECHA) = '" + f2.ToString("MM") + "') AND (NOMBRE = 'JOSÉ GUSTAVO MONTOYA AGUILAR') ", CONEXION6);    //QUERY DE CONSULTA

            CONEXION6.Open();
            MySqlDataReader consulta6 = comando6.ExecuteReader();
            if (consulta6.Read())
            {
                CLIM6_1.Image = ERP_COMPLETO.Properties.Resources.ICO_DOC_NAR;

                s6_2 = s6_2 + 1;



            }
            else
            {
                CLIM6_1.Image = ERP_COMPLETO.Properties.Resources.ICO_DOC_GRIS;
            }
            CONEXION6.Close();
            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            ///
             /////////////////////////////////////////////////////////////////////////////////////////////////////////
            MySqlConnection CONEXION7 = conexion_supervision_tecnica.USR;

            MySqlCommand comando7 = new MySqlCommand("SELECT ID_SEGUIMIENTO FROM    reporte_supervision WHERE (YEAR(FECHA) = '" + f2.ToString("yyyy") + "' AND MONTH(FECHA) = '" + f2.ToString("MM") + "') AND (NOMBRE = 'DANIEL MORENO CRUZ') ", CONEXION7);    //QUERY DE CONSULTA

            CONEXION7.Open();
            MySqlDataReader consulta7 = comando7.ExecuteReader();
            if (consulta7.Read())
            {
                CLIM7_1.Image = ERP_COMPLETO.Properties.Resources.ICO_DOC_NAR;

                s7_2 = s7_2 + 1;



            }
            else
            {
                CLIM7_1.Image = ERP_COMPLETO.Properties.Resources.ICO_DOC_GRIS;
            }
            CONEXION7.Close();
            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        }

        private void consulta_reportes3()
        {


            MySqlConnection CONEXIONs = conexion_supervision_tecnica.USR;

            MySqlCommand comandos = new MySqlCommand("SELECT ID_SEGUIMIENTO FROM    reporte_supervision WHERE (YEAR(FECHA) = '" + f3.ToString("yyyy") + "' AND MONTH(FECHA) = '" + f3.ToString("MM") + "') AND (NOMBRE = 'CONCEPCIÓN JIMÉNEZ MEDINA') ", CONEXIONs);    //QUERY DE CONSULTA

            CONEXIONs.Open();
            MySqlDataReader consultas = comandos.ExecuteReader();
            if (consultas.Read())
            {
                CLIM1_2.Image = ERP_COMPLETO.Properties.Resources.ICO_DOC_NAR;

                s1_3 = s1_3 + 1;



            }
            else
            {
                CLIM1_2.Image = ERP_COMPLETO.Properties.Resources.ICO_DOC_GRIS;
            }
            CONEXIONs.Close();
            /////////////////////////////////////////////////////////////////////////////////////////////////////////
            MySqlConnection CONEXION2 = conexion_supervision_tecnica.USR;

            MySqlCommand comando2 = new MySqlCommand("SELECT ID_SEGUIMIENTO FROM    reporte_supervision WHERE (YEAR(FECHA) = '" + f3.ToString("yyyy") + "' AND MONTH(FECHA) = '" + f3.ToString("MM") + "') AND (NOMBRE = 'ROBERTO CERÓN ÁLVAREZ') ", CONEXION2);    //QUERY DE CONSULTA

            CONEXION2.Open();
            MySqlDataReader consulta2 = comando2.ExecuteReader();
            if (consulta2.Read())
            {
                CLIM2_2.Image = ERP_COMPLETO.Properties.Resources.ICO_DOC_NAR;
                s2_3 = s2_3 + 1;




            }
            else
            {
                CLIM2_2.Image = ERP_COMPLETO.Properties.Resources.ICO_DOC_GRIS;
            }
            CONEXION2.Close();
            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            /// /////////////////////////////////////////////////////////////////////////////////////////////////////////
            MySqlConnection CONEXION3 = conexion_supervision_tecnica.USR;

            MySqlCommand comando3 = new MySqlCommand("SELECT ID_SEGUIMIENTO FROM    reporte_supervision WHERE (YEAR(FECHA) = '" + f3.ToString("yyyy") + "' AND MONTH(FECHA) = '" + f3.ToString("MM") + "') AND (NOMBRE = 'BERTÍN LAGUNAS RAMÍREZ') ", CONEXION3);    //QUERY DE CONSULTA

            CONEXION3.Open();
            MySqlDataReader consulta3 = comando3.ExecuteReader();
            if (consulta3.Read())
            {
                CLIM3_2.Image = ERP_COMPLETO.Properties.Resources.ICO_DOC_NAR;
                s3_3 = s3_3 + 1;




            }
            else
            {
                CLIM3_2.Image = ERP_COMPLETO.Properties.Resources.ICO_DOC_GRIS;
            }
            CONEXION3.Close();
            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            ///
             /////////////////////////////////////////////////////////////////////////////////////////////////////////
            MySqlConnection CONEXION4 = conexion_supervision_tecnica.USR;

            MySqlCommand comando4 = new MySqlCommand("SELECT ID_SEGUIMIENTO FROM    reporte_supervision WHERE (YEAR(FECHA) = '" + f3.ToString("yyyy") + "' AND MONTH(FECHA) = '" + f3.ToString("MM") + "') AND (NOMBRE = 'DIEGO MORENO ROMERO') ", CONEXION4);    //QUERY DE CONSULTA

            CONEXION4.Open();
            MySqlDataReader consulta4 = comando4.ExecuteReader();
            if (consulta4.Read())
            {
                CLIM4_2.Image = ERP_COMPLETO.Properties.Resources.ICO_DOC_NAR;
                s4_3 = s4_3 + 1;




            }
            else
            {
                CLIM4_2.Image = ERP_COMPLETO.Properties.Resources.ICO_DOC_GRIS;
            }
            CONEXION4.Close();
            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            /////////////////////////////////////////////////////////////////////////////////////////////////////////
            MySqlConnection CONEXION5 = conexion_supervision_tecnica.USR;

            MySqlCommand comando5 = new MySqlCommand("SELECT ID_SEGUIMIENTO FROM    reporte_supervision WHERE (YEAR(FECHA) = '" + f3.ToString("yyyy") + "' AND MONTH(FECHA) = '" + f3.ToString("MM") + "') AND (NOMBRE = 'JORGE DAVID RUTILIO CONSTANTINO') ", CONEXION5);    //QUERY DE CONSULTA

            CONEXION5.Open();
            MySqlDataReader consulta5 = comando5.ExecuteReader();
            if (consulta5.Read())
            {
                CLIM5_2.Image = ERP_COMPLETO.Properties.Resources.ICO_DOC_NAR;
                s5_3 = s5_3 + 1;




            }
            else
            {
                CLIM5_2.Image = ERP_COMPLETO.Properties.Resources.ICO_DOC_GRIS;
            }
            CONEXION5.Close();
            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            ///
             /////////////////////////////////////////////////////////////////////////////////////////////////////////
            MySqlConnection CONEXION6 = conexion_supervision_tecnica.USR;

            MySqlCommand comando6 = new MySqlCommand("SELECT ID_SEGUIMIENTO FROM    reporte_supervision WHERE (YEAR(FECHA) = '" + f3.ToString("yyyy") + "' AND MONTH(FECHA) = '" + f3.ToString("MM") + "') AND (NOMBRE = 'JOSÉ GUSTAVO MONTOYA AGUILAR') ", CONEXION6);    //QUERY DE CONSULTA

            CONEXION6.Open();
            MySqlDataReader consulta6 = comando6.ExecuteReader();
            if (consulta6.Read())
            {
                CLIM6_2.Image = ERP_COMPLETO.Properties.Resources.ICO_DOC_NAR;
                s6_3 = s6_3 + 1;




            }
            else
            {
                CLIM6_2.Image = ERP_COMPLETO.Properties.Resources.ICO_DOC_GRIS;
            }
            CONEXION6.Close();
            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            ///

            /////////////////////////////////////////////////////////////////////////////////////////////////////////
            MySqlConnection CONEXION7 = conexion_supervision_tecnica.USR;

            MySqlCommand comando7 = new MySqlCommand("SELECT ID_SEGUIMIENTO FROM    reporte_supervision WHERE (YEAR(FECHA) = '" + f3.ToString("yyyy") + "' AND MONTH(FECHA) = '" + f3.ToString("MM") + "') AND (NOMBRE = 'DANIEL MORENO CRUZ') ", CONEXION7);    //QUERY DE CONSULTA

            CONEXION7.Open();
            MySqlDataReader consulta7 = comando7.ExecuteReader();
            if (consulta7.Read())
            {
                CLIM7_2.Image = ERP_COMPLETO.Properties.Resources.ICO_DOC_NAR;
                s7_3 = s7_3 + 1;




            }
            else
            {
                CLIM7_2.Image = ERP_COMPLETO.Properties.Resources.ICO_DOC_GRIS;
            }
            CONEXION7.Close();
            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        }
        private void consulta_porc_reporte()
        {

            porc1.ButtonText = (s1_1 + s2_1 + s3_1 + s4_1 + s5_1 + s6_1).ToString("f1");

            porc2.ButtonText = (s1_2 + s2_2 + s3_2 + s4_2 + s5_2 + s6_2).ToString("f1");

            porc3.ButtonText = (s1_3 + s2_3 + s3_3 + s4_3 + s5_3 + s6_3).ToString("f1");

            porc1.ButtonText = ((double.Parse(porc1.ButtonText) / 6) * 100).ToString("f1");
            porc2.ButtonText = ((double.Parse(porc2.ButtonText) / 6) * 100).ToString("f1");
            porc3.ButtonText = ((double.Parse(porc3.ButtonText) / 6) * 100).ToString("f1");
            porc1.Height = 40;
            porc2.Height = 40;
            porc3.Height = 40;

        }
        private void label11_Click(object sender, EventArgs e)
        {

        }
        DateTime FECHA_REFERENCIA;
        string nombre_supervisor;

        private void CLIM1_Click(object sender, EventArgs e)
        {
            FECHA_REFERENCIA = f1;
            nombre_supervisor = "CONCEPCIÓN JIMÉNEZ MEDINA";
            contextMenuStrip1.Show(CLIM1, 5, 5);
        }

        private void CLIM2_Click(object sender, EventArgs e)
        {
            FECHA_REFERENCIA = f1;
            nombre_supervisor = "ROBERTO CERÓN ÁLVAREZ";
            contextMenuStrip1.Show(CLIM2, 5, 5);
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void CLIM3_Click(object sender, EventArgs e)
        {
            FECHA_REFERENCIA = f1;
            nombre_supervisor = "BERTÍN LAGUNAS RAMÍREZ";
            contextMenuStrip1.Show(CLIM3, 5, 5);
        }

        private void CLIM4_Click(object sender, EventArgs e)
        {
            FECHA_REFERENCIA = f1;
            nombre_supervisor = "DIEGO MORENO ROMERO";
            contextMenuStrip1.Show(CLIM4, 5, 5);
        }

        private void CLIM5_Click(object sender, EventArgs e)
        {
            FECHA_REFERENCIA = f1;
            nombre_supervisor = "JORGE DAVID RUTILIO CONSTANTINO";
            contextMenuStrip1.Show(CLIM5, 5, 5);
        }

        private void CLIM6_Click(object sender, EventArgs e)
        {
            FECHA_REFERENCIA = f1;
            nombre_supervisor = "JOSÉ GUSTAVO MONTOYA AGUILAR";
            contextMenuStrip1.Show(CLIM6, 5, 5);
        }

        private void CLIM1_1_Click(object sender, EventArgs e)
        {
            FECHA_REFERENCIA = f2;
            nombre_supervisor = "CONCEPCIÓN JIMÉNEZ MEDINA";
            contextMenuStrip1.Show(CLIM1_1, 5, 5);
        }

        private void CLIM2_1_Click(object sender, EventArgs e)
        {
            FECHA_REFERENCIA = f2;
            nombre_supervisor = "ROBERTO CERÓN ÁLVAREZ";
            contextMenuStrip1.Show(CLIM2_1, 5, 5);
        }

        private void CLIM3_1_Click(object sender, EventArgs e)
        {
            FECHA_REFERENCIA = f2;
            nombre_supervisor = "BERTÍN LAGUNAS RAMÍREZ";
            contextMenuStrip1.Show(CLIM3_1, 5, 5);
        }

        private void CLIM4_1_Click(object sender, EventArgs e)
        {
            FECHA_REFERENCIA = f2;
            nombre_supervisor = "DIEGO MORENO ROMERO";
            contextMenuStrip1.Show(CLIM4_1, 5, 5);
        }

        private void CLIM5_1_Click(object sender, EventArgs e)
        {
            FECHA_REFERENCIA = f2;
            nombre_supervisor = "JORGE DAVID RUTILIO CONSTANTINO";
            contextMenuStrip1.Show(CLIM5_1, 5, 5);
        }

        private void CLIM6_1_Click(object sender, EventArgs e)
        {
            FECHA_REFERENCIA = f2;
            nombre_supervisor = "JOSÉ GUSTAVO MONTOYA AGUILAR";
            contextMenuStrip1.Show(CLIM6_1, 5, 5);
        }

        private void CLIM1_2_Click(object sender, EventArgs e)
        {
            FECHA_REFERENCIA = f3;
            nombre_supervisor = "CONCEPCIÓN JIMÉNEZ MEDINA";
            contextMenuStrip1.Show(CLIM1_2, 5, 5);
        }

        private void CLIM2_2_Click(object sender, EventArgs e)
        {
            FECHA_REFERENCIA = f3;
            nombre_supervisor = "ROBERTO CERÓN ÁLVAREZ";
            contextMenuStrip1.Show(CLIM2_2, 5, 5);
        }

        private void CLIM3_2_Click(object sender, EventArgs e)
        {
            FECHA_REFERENCIA = f3;
            nombre_supervisor = "BERTÍN LAGUNAS RAMÍREZ";
            contextMenuStrip1.Show(CLIM3_2, 5, 5);
        }

        private void CLIM4_2_Click(object sender, EventArgs e)
        {
            FECHA_REFERENCIA = f3;
            nombre_supervisor = "DIEGO MORENO ROMERO";
            contextMenuStrip1.Show(CLIM4_2, 5, 5);
        }

        private void CLIM5_2_Click(object sender, EventArgs e)
        {
            FECHA_REFERENCIA = f3;
            nombre_supervisor = "JORGE DAVID RUTILIO CONSTANTINO";
            contextMenuStrip1.Show(CLIM5_2, 5, 5);
        }

        private void CLIM6_2_Click(object sender, EventArgs e)
        {
            FECHA_REFERENCIA = f3;
            nombre_supervisor = "JOSÉ GUSTAVO MONTOYA AGUILAR";
            contextMenuStrip1.Show(CLIM6_2, 5, 5);
        }
        /* private void tomar_categorias()
         {
             MySqlConnection CONEXION = conexion_rh.USR;   //CONEXION A DB 
             MySqlCommand comando = new MySqlCommand("SELECT * FROM  categorias ORDER BY CATEGORIA ", CONEXION);  //QUERY DE CONSULTA


             CONEXION.Open();
             MySqlDataReader consulta = comando.ExecuteReader();

             while (consulta.Read())
             {
                 area.Items.Add(consulta["CATEGORIA"].ToString());  //DEPOSITO DE INFORMACION


             }

             CONEXION.Close();   //CIERRE DE CONEXION


         }*/
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Lee el archivo seleccionado en un arreglo de bytes
                byte[] archivoBytes = File.ReadAllBytes(openFileDialog.FileName);

                // Conecta a la base de datos MySQL
                MySqlConnection conexion = conexion_supervision_tecnica.USR;
                conexion.Open();

                // Crea una consulta SQL para insertar el archivo en la tabla de tu base de datos
                MySqlCommand comando = new MySqlCommand("INSERT INTO  reporte_supervision (NOMBRE,FECHA ,1_CATORCENA) VALUES (@nombre, @fecha, @evidencia)", conexion);  //QUERY DE CONSULTA
                comando.Parameters.AddWithValue("@nombre", nombre_supervisor);
                comando.Parameters.AddWithValue("@fecha", FECHA_REFERENCIA.ToString("yyyy-MM-dd"));
                comando.Parameters.AddWithValue("@evidencia", archivoBytes);

                comando.ExecuteNonQuery();

                // Cierra la conexión a la base de datos
                conexion.Close();


                // Muestra un mensaje de confirmación
                MENSAJE_GENERAL MN = new MENSAJE_GENERAL();
                MN.BOTON.Text = "Formato Registrado Correctamente";
                MN.Show();
            }







        }


        private void estatica()
        {
            panel3.Height = 30;


            label30.Top = (panel3.Height - label30.Height) / 2;
            label9.Top = (panel3.Height - label9.Height) / 2;
            label13.Top = (panel3.Height - label13.Height) / 2;


        }

        private void myBGWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            int percentage = 0;
            percentage = percentage + 20;
            myBGWorker.ReportProgress(percentage);

            System.Threading.Thread.Sleep(1500);

            Invoke(new MethodInvoker(() =>
            {

                //primer_semest();
                //ss1.Visible = true;
            }));

            System.Threading.Thread.Sleep(3000);
            percentage = percentage + 30;
            myBGWorker.ReportProgress(percentage);

            Invoke(new MethodInvoker(() =>
            {


                //segundo_semest();
                //ss2.Visible = true;

            }));

            System.Threading.Thread.Sleep(1500);
            percentage = percentage + 50;
            myBGWorker.ReportProgress(percentage);


        }

        private void pieChart1_DataClick(object sender, ChartPoint chartPoint)
        {








            string dato = chartPoint.SeriesView.Title;


            if (dato == "Alto rendimiento")
            {
                Form nv = new Form();
                using (DETALLES_SUPREVISION_PERSONAL mn = new DETALLES_SUPREVISION_PERSONAL())  //ABRE FORMULARIO 
                {
                    nv.StartPosition = FormStartPosition.Manual;
                    nv.FormBorderStyle = FormBorderStyle.None;
                    nv.Opacity = .70d;
                    nv.BackColor = Color.Black;
                    nv.WindowState = FormWindowState.Maximized;   //ESTILOS APLICABLES A ELEMENTOS 
                    nv.TopMost = false;
                    nv.Location = this.Location;
                    nv.ShowInTaskbar = false;
                    nv.Show();
                    mn.Owner = nv;
                    mn.Opacity = 0;
                    mn.titulo.Text = "Alto rendimiento";

                    mn.semestre_primero = true;
                    mn.rango1 = 80;
                    mn.rango2 = 100;

                    // mn.semestre = Año.Texts + "-06-01";
                    // mn.filtro = area.Texts;
                    mn.no_realizado = false;


                    mn.ShowDialog();

                    nv.Dispose();
                }



            }
            if (dato == "Rendimiento Regular")
            {
                Form nv = new Form();
                using (DETALLES_SUPREVISION_PERSONAL mn = new DETALLES_SUPREVISION_PERSONAL())  //ABRE FORMULARIO 
                {
                    nv.StartPosition = FormStartPosition.Manual;
                    nv.FormBorderStyle = FormBorderStyle.None;
                    nv.Opacity = .70d;
                    nv.BackColor = Color.Black;
                    nv.WindowState = FormWindowState.Maximized;   //ESTILOS APLICABLES A ELEMENTOS 
                    nv.TopMost = false;
                    nv.Location = this.Location;
                    nv.ShowInTaskbar = false;
                    nv.Show();
                    mn.Owner = nv;
                    mn.Opacity = 0;

                    mn.semestre_primero = true;
                    mn.rango1 = 60;
                    mn.rango2 = 80;
                    mn.titulo.Text = "Rendimiento Regular";
                    // mn.semestre = Año.Texts + "-06-01";
                    // mn.filtro = area.Texts;
                    mn.no_realizado = false;


                    mn.ShowDialog();

                    nv.Dispose();
                }

            }
            if (dato == "Rendimiento Insuficiente")
            {
                Form nv = new Form();
                using (DETALLES_SUPREVISION_PERSONAL mn = new DETALLES_SUPREVISION_PERSONAL())   //ABRE FORMULARIO 
                {
                    nv.StartPosition = FormStartPosition.Manual;
                    nv.FormBorderStyle = FormBorderStyle.None;
                    nv.Opacity = .70d;
                    nv.BackColor = Color.Black;
                    nv.WindowState = FormWindowState.Maximized;   //ESTILOS APLICABLES A ELEMENTOS 
                    nv.TopMost = false;
                    nv.Location = this.Location;
                    nv.ShowInTaskbar = false;
                    nv.Show();
                    mn.Owner = nv;
                    mn.Opacity = 0;

                    mn.semestre_primero = true;
                    mn.rango1 = 40;
                    mn.rango2 = 60;
                    mn.titulo.Text = "Rendimiento Insuficiente";
                    //mn.semestre = Año.Texts + "-06-01";
                    // mn.filtro = area.Texts;
                    mn.no_realizado = false;


                    mn.ShowDialog();

                    nv.Dispose();
                }
            }
        }

        private void pieChart2_DataClick(object sender, ChartPoint chartPoint)
        {







            string dato = chartPoint.SeriesView.Title;


            if (dato == "Alto rendimiento")
            {
                Form nv = new Form();
                using (DETALLES_SUPREVISION_PERSONAL mn = new DETALLES_SUPREVISION_PERSONAL())  //ABRE FORMULARIO
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
                    mn.Opacity = 0;

                    mn.semestre_primero = false;
                    mn.rango1 = 80;
                    mn.rango2 = 100;

                    //  mn.semestre = Año.Texts + "-06-01";
                    //  mn.filtro = area.Texts;
                    mn.no_realizado = false;


                    mn.ShowDialog();

                    nv.Dispose();
                }



            }
            else if (dato == "Rendimiento Regular")
            {
                Form nv = new Form();
                using (DETALLES_SUPREVISION_PERSONAL mn = new DETALLES_SUPREVISION_PERSONAL())  //ABRE FORMULARIO
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
                    mn.Opacity = 0;

                    mn.semestre_primero = false;
                    mn.rango1 = 60;
                    mn.rango2 = 80;

                    //  mn.semestre = Año.Texts + "-06-01";
                    //   mn.filtro = area.Texts;
                    mn.no_realizado = false;


                    mn.ShowDialog();

                    nv.Dispose();
                }

            }
            else if (dato == "Rendimiento Insuficiente")
            {
                Form nv = new Form();
                using (DETALLES_SUPREVISION_PERSONAL mn = new DETALLES_SUPREVISION_PERSONAL())  //ABRE FORMULARIO
                {
                    nv.StartPosition = FormStartPosition.Manual;
                    nv.FormBorderStyle = FormBorderStyle.None;
                    nv.Opacity = .70d;
                    nv.BackColor = Color.Black;
                    nv.WindowState = FormWindowState.Maximized;   //ESTILOS APLICABLES A ELEMENTOS 
                    nv.TopMost = false;
                    nv.Location = this.Location;
                    nv.ShowInTaskbar = false;
                    nv.Show();
                    mn.Owner = nv;
                    mn.Opacity = 0;

                    mn.semestre_primero = false;
                    mn.rango1 = 40;
                    mn.rango2 = 60;
                    //  mn.semestre = Año.Texts + "-06-01";
                    //   mn.filtro = area.Texts;
                    mn.no_realizado = false;


                    mn.ShowDialog();

                    nv.Dispose();
                }
            }
            else if (dato == "Bajo Rendimiento")
            {
                Form nv = new Form();
                using (DETALLES_SUPREVISION_PERSONAL mn = new DETALLES_SUPREVISION_PERSONAL())  //ABRE FORMULARIO
                {
                    nv.StartPosition = FormStartPosition.Manual;
                    nv.FormBorderStyle = FormBorderStyle.None;
                    nv.Opacity = .70d;
                    nv.BackColor = Color.Black;
                    nv.WindowState = FormWindowState.Maximized;   //ESTILOS APLICABLES A ELEMENTOS 
                    nv.TopMost = false;
                    nv.Location = this.Location;
                    nv.ShowInTaskbar = false;
                    nv.Show();
                    mn.Owner = nv;
                    mn.Opacity = 0;

                    mn.semestre_primero = false;
                    mn.rango1 = 0;
                    mn.rango2 = 40;

                    // mn.semestre = Año.Texts + "-06-01";
                    // mn.filtro = area.Texts;
                    mn.no_realizado = false;


                    mn.ShowDialog();

                    nv.Dispose();
                }
            }
            else if (dato == "No realizadas")
            {
                Form nv = new Form();
                using (DETALLES_SUPREVISION_PERSONAL mn = new DETALLES_SUPREVISION_PERSONAL())  //ABRE FORMULARIO
                {
                    nv.StartPosition = FormStartPosition.Manual;
                    nv.FormBorderStyle = FormBorderStyle.None;
                    nv.Opacity = .70d;
                    nv.BackColor = Color.Black;
                    nv.WindowState = FormWindowState.Maximized;   //ESTILOS APLICABLES A ELEMENTOS 
                    nv.TopMost = false;
                    nv.Location = this.Location;
                    nv.ShowInTaskbar = false;
                    nv.Show();
                    mn.Owner = nv;
                    mn.Opacity = 0;

                    mn.semestre_primero = false;
                    mn.rango1 = 0;
                    mn.rango2 = 0;

                    //  mn.semestre = Año.Texts + "-06-01";
                    // mn.filtro = area.Texts;
                    mn.no_realizado = true;


                    mn.ShowDialog();

                    nv.Dispose();
                }
            }

        }

        private void altoButton2_Click(object sender, EventArgs e)
        {
            //  altoButton1.Enabled = false;

            myBGWorker.RunWorkerAsync();

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        //public DataGridView dgv_sup = new DataGridView();




        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            MySqlConnection CONEXIONs = conexion_supervision_tecnica.USR;

            MySqlCommand comandos = new MySqlCommand("SELECT 1_CATORCENA FROM    reporte_supervision WHERE (YEAR(FECHA) = '" + FECHA_REFERENCIA.ToString("yyyy") + "' AND MONTH(FECHA) = '" + FECHA_REFERENCIA.ToString("MM") + "') AND (NOMBRE = '" + nombre_supervisor + "') ", CONEXIONs);    //QUERY DE CONSULTA

            CONEXIONs.Open();
            MySqlDataReader consultas = comandos.ExecuteReader();
            if (consultas.Read())
            {

                string carpeta = @"C:\TEMP ERP";

                if (Directory.Exists(carpeta)) //VALIDA EXISTENCIA DE CARPETA 
                {

                }
                else
                {
                    Directory.CreateDirectory(carpeta); //VALIDA EXISTENCIA DE CARPETA 

                }


                byte[] archivoBytes = (byte[])consultas["1_CATORCENA"];
                System.IO.MemoryStream pdfStream = new System.IO.MemoryStream(archivoBytes);


                File.WriteAllBytes(@"C:\TEMP ERP\EVIDENCIA.pdf", archivoBytes);
                System.Diagnostics.Process.Start(@"C:\TEMP ERP\EVIDENCIA.pdf");



            }
            else
            {
                MENSAJE_GENERAL MN = new MENSAJE_GENERAL();   //MENSAJE ALERTA 
                MN.BOTON.Text = "No tenemos Evidencia";
                MN.ShowDialog();
            }
            CONEXIONs.Close();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            FECHA_REFERENCIA = f1;
            nombre_supervisor = "DANIEL MORENO CRUZ";
            contextMenuStrip1.Show(CLIM7, 5, 5);
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            FECHA_REFERENCIA = f2;
            nombre_supervisor = "DANIEL MORENO CRUZ";
            contextMenuStrip1.Show(CLIM7_1, 5, 5);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            FECHA_REFERENCIA = f3;
            nombre_supervisor = "DANIEL MORENO CRUZ";
            contextMenuStrip1.Show(CLIM7_2, 5, 5);
        }

        private void label46_Click(object sender, EventArgs e)
        {

        }
    }
}
