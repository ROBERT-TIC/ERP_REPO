using ERP_LIEC;
using MySql.Data.MySqlClient;
using System;     //DEFINEN UN AMBITO PARA UTILIZAR RECURSOS //
//LIBRERIAS PARA EXCEL Y PDF
using System.IO; // VENTANAS DE MENSAJES DE ERRORES
using System.Windows.Forms;





namespace ERP_COMPLETO   //NOMBRE DEL ESPACIO
{
    public partial class HISTORIAL_EVALUACION_SUPERVISORES : Form  //CLASE PRINCIPAL DEL FORMULARIO ACTUAL
    {
        public HISTORIAL_EVALUACION_SUPERVISORES()
        {
            InitializeComponent();  //INICIALIZA COMPONENTE
        }


        int alto = 0;   //VARIABLES INICIALES
        int medio = 0;
        int bajo = 0;
        int muy_bajo = 0;
        int no_realizadas = 0;
        int PORCENTAJEFUNCION = 0;   //VARIABLES INICIALES



        private void HISTORIAL_EVALUACION_SUPERVISORES_Load(object sender, EventArgs e)  //FUNCION PRINCIPAL DE ARRANQUE
        {
            timer1.Start();
        }




        private void CONSULTA_PERSONAS_PRIMER_SEMESTRE()
        {
            if (DGV_PRIMER_SEMESTRE.RowCount == 0)
            {
                MySqlConnection CONEXION = conexion_supervision_tecnica.USR;
                MySqlCommand comando = new MySqlCommand("SELECT * FROM personal_agenda WHERE EVALUADOR = '" + SUPERVISOR.Texts + "' AND FECHA_TENTATIVA < '" + Año.Texts + "-06-01" + "'  ", CONEXION);   //QUERY DE CONSULTA
                CONEXION.Open();
                MySqlDataReader consulta = comando.ExecuteReader();
                while (consulta.Read())
                {
                    string a0 = consulta.IsDBNull(0) ? String.Empty : consulta.GetString(0); //ID SEG
                    string a1 = consulta.IsDBNull(1) ? String.Empty : consulta.GetString(1); //ID EV   //DEPOSITO DE INFORMACION
                    string a2 = consulta.IsDBNull(2) ? String.Empty : consulta.GetString(2);  //PERSONA
                    string a3 = consulta.IsDBNull(7) ? String.Empty : consulta.GetString(7);  //CATEG
                    string a4 = consulta.IsDBNull(4) ? String.Empty : consulta.GetString(4);  //MOTIVO
                    string a5 = consulta.IsDBNull(3) ? String.Empty : consulta.GetString(3);  //FECHA EV
                    string a6 = consulta.IsDBNull(6) ? String.Empty : consulta.GetString(6);  //CALIF
                    string a7 = consulta.IsDBNull(10) ? String.Empty : consulta.GetString(10);  //SUP   //DEPOSITO DE INFORMACION
                    DGV_PRIMER_SEMESTRE.Rows.Add(a0, a1, a2, a3, a4, a5, a6, a7);

                }
                CONEXION.Close();   //CIERRE DE CONEXION
            }


        }


        private void CONSULTA_PERSONAS_SEGUNDO_SEMESTRE()
        {
            if (DGV_SEGUNDO_SEMESTRE.RowCount == 0)
            {
                MySqlConnection CONEXION = conexion_supervision_tecnica.USR;
                MySqlCommand comando = new MySqlCommand("SELECT * FROM personal_agenda WHERE EVALUADOR = '" + SUPERVISOR.Texts + "' AND FECHA_TENTATIVA > '" + Año.Texts + "-06-01" + "'  ", CONEXION);   //QUERY DE CONSULTA
                CONEXION.Open();
                MySqlDataReader consulta = comando.ExecuteReader();
                while (consulta.Read())
                {
                    string a0 = consulta.IsDBNull(0) ? String.Empty : consulta.GetString(0); //ID SEG   //DEPOSITO DE INFORMACION
                    string a1 = consulta.IsDBNull(1) ? String.Empty : consulta.GetString(1); //ID EV
                    string a2 = consulta.IsDBNull(2) ? String.Empty : consulta.GetString(2);  //PERSONA
                    string a3 = consulta.IsDBNull(7) ? String.Empty : consulta.GetString(7);  //CATEG
                    string a4 = consulta.IsDBNull(4) ? String.Empty : consulta.GetString(4);  //MOTIVO
                    string a5 = consulta.IsDBNull(3) ? String.Empty : consulta.GetString(3);  //FECHA EV   //DEPOSITO DE INFORMACION
                    string a6 = consulta.IsDBNull(6) ? String.Empty : consulta.GetString(6);  //CALIF
                    string a7 = consulta.IsDBNull(10) ? String.Empty : consulta.GetString(10);  //SUP
                    DGV_SEGUNDO_SEMESTRE.Rows.Add(a0, a1, a2, a3, a4, a5, a6, a7);

                }
                CONEXION.Close();
            }


        }



        //PINTA DE COLOR LAS FILAS CON FORMULAS EN EL DGV
        private void COLORES_TABLA()
        {
            /* string var;
             var = PAN_SUPERVISION.GEV.promedio_total2.Texts;

             double promedio = double.Parse(var);


             foreach (DataGridViewRow row in DGV_PRIMER_SEMESTRE.Rows)
             {
                 if (row.Cells[6].Value.ToString() <=)
                 {
                     row.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(245, 245, 245);
                 }
                 if (row.Cells[6].Value.ToString() == dos)
                 {
                     row.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(245, 245, 245);
                 }
                 if (row.Cells[6].Value.ToString() == tres)
                 {
                     row.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(245, 245, 245);
                 }
                 if (row.Cells[6].Value.ToString() == cuatro)
                 {
                     row.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(245, 245, 245);
                 }
                 if (row.Cells[6].Value.ToString() == cinco)
                 {
                     row.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(245, 245, 245);
                 }
                 if (row.Cells[6].Value.ToString() == seis)
                 {
                     row.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(245, 245, 245);
                 }





                 if (promedio <= 59)
                 {
                     row.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(174, 206, 243);
                 }

                 else if (promedio >= 60 && promedio <= 79)
                 {                  
                         row.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(243, 239, 197);                 
                 }
                 else if (promedio >= 80 && promedio <= 100)
                 {              
                         row.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(255, 218, 185);                 
                 }
             }
            */








        }






        private void refrescar_form()
        {
            //  MENU_PRICIPAL_ERP.cortaps.REINICIA_ANALISIS_EVALUACION();
        }


        private void REFRESH_Click(object sender, EventArgs e)
        {
            refrescar_form();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Opacity = this.Opacity + .20;


            if (this.Opacity == 1)
            {

                timer1.Stop();
            }
        }

        private void ss2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SUPERVISOR_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            DGV_PRIMER_SEMESTRE.Rows.Clear();
            DGV_SEGUNDO_SEMESTRE.Rows.Clear();


            CONSULTA_PERSONAS_PRIMER_SEMESTRE();   //FUNCIONES A LLAMAR 
            CONSULTA_PERSONAS_SEGUNDO_SEMESTRE();  //FUNCIONES A LLAMAR 

            COLORES_TABLA();
        }

        private void DGV_PRIMER_SEMESTRE_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // CONSULTA_LISTAS_VERIFICACION();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            string ruta = @"Z:\LIEP-01 PERSONAL\" + Año.Texts + @"\REGISTROS\02 SUPERVISION\LISTAS DE VERIFICACION\000. ERP\YAREM\" + DGV_PRIMER_SEMESTRE.CurrentRow.Cells[2].Value.ToString() + "-REPORTE DE SUPERVISIÓN" + ".pdf";

            if (File.Exists(ruta))
            {
                System.Diagnostics.Process.Start(ruta);
            }
            else
            {
                MENSAJE_GENERAL MN = new MENSAJE_GENERAL();
                MN.BOTON.Text = "NO TENEMOS REGISTRO DE ESTE DOCUMENTO";
                MN.Show();
            }
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {

            /*   string ruta = @"Z:\LIEP-01 PERSONAL\" + Año.Texts + @"\REGISTROS\02 SUPERVISION\LISTAS DE VERIFICACION\000. ERP\YAREM\" + DGV_PRIMER_SEMESTRE.CurrentRow.Cells[2].Value.ToString()+"-REPORTE DE SUPERVISIÓN"+".pdf";

               if (File.Exists(ruta))
               {
                   System.Diagnostics.Process.Start(ruta);
               }
               else
               {
                   MENSAJE_GENERAL MN = new MENSAJE_GENERAL();
                   MN.BOTON.Text = "NO TENEMOS REGISTRO DE ESTE DOCUMENTO";
                   MN.Show();
               }*/
        }



    }
}
