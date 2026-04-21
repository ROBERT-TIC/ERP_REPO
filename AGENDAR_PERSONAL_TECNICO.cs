using ERP_LIEC;  //DEFINEN UN AMBITO PARA UTILIZAR RECURSOS//
using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;  //DEFINEN UN AMBITO PARA UTILIZAR RECURSOS//

namespace ERP_COMPLETO  //NOMBRE DEL ESPACIO
{
    public partial class AGENDAR_PERSONAL_TECNICO : Form   //CLASE PRINCIPAL DEL FORMULARIO ACTUAL
    {
        public AGENDAR_PERSONAL_TECNICO()
        {
            InitializeComponent();
        }

        private void rjButton1_Click(object sender, EventArgs e)
        {
            /* conexion_rh.Consultageneral("INSERT INTO areas_trabajo(AREA, DESCRIPCION, FECHA_REGISTRO, RANGO_ACTIVIDAD, COORDINADOR) VALUES('"+nom_area.Texts+"','"+observaciones.Texts+"','"+FECHA.Text+"','"+MOTIVO.Texts+"','"+NOMBRE.Texts+"')");
             MessageBox.Show("Se ha dado de alta una nueva área");*/
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();  //CIERRE DE FORM
        }

        private void filtrar_coordinador()
        {
            MySqlConnection CONEXION = conexion_rh.USR;  //CONEXION 


            MySqlCommand comando = new MySqlCommand("SELECT DISTINCTROW NOMBRE FROM pdr_personal1 WHERE AREA = 'TÉCNICO' ORDER BY NOMBRE ASC", CONEXION);   //QUERY DE CONSULTA

            CONEXION.Open();
            MySqlDataReader registro = comando.ExecuteReader();

            while (registro.Read())
            {

                NOMBRE.Items.Add(registro["NOMBRE"].ToString());  //DEPOSITO DE INFORMACION

            }

            CONEXION.Close();  //CIERRE DE CONEXION 

        }

        private void consecutivo()
        {
            int contador = 0;


            MySqlConnection CONEXION = conexion_supervision_tecnica.USR;  //CONEXION 


            MySqlCommand comando = new MySqlCommand("SELECT DISTINCTROW * FROM  personal_agenda", CONEXION);   //QUERY DE CONSULTA
            CONEXION.Open();
            MySqlDataReader registro = comando.ExecuteReader();

            while (registro.Read())
            {

                contador = contador + 1;

            }
            contador = contador + 1;

            CONEXION.Close();   //CIERRE DE CONEXION 
            ID.Text = "LIE-SP-" + contador.ToString();

        }

        private void Form1_Load(object sender, EventArgs e)   //FUNCION PRINCIPAL DE ARRANQUE
        {
            timer1.Start();
            filtrar_coordinador();    //FUNCIONES A LLAMAR AL INICIAR EL FORMULARIO
            consecutivo();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Opacity = this.Opacity + .20;


            if (this.Opacity == 1)
            {

                timer1.Stop();
            }
        }

        private void rjComboBox1_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            MySqlConnection CONEXION = conexion_rh.USR;  //CONEXION A DB 


            MySqlCommand comando = new MySqlCommand("SELECT CATEGORIA FROM pdr_personal1 WHERE NOMBRE = '" + NOMBRE.Texts + "'", CONEXION);   //QUERY DE CONSULTA
            CONEXION.Open();
            MySqlDataReader registro = comando.ExecuteReader();

            while (registro.Read())
            {

                CATEGORIA.Texts = registro.IsDBNull(0) ? String.Empty : registro.GetString(0);   //DEPOSITO DE INFORMACION

            }

            CONEXION.Close();   //CIERRE DE CONEXION






        }

        private void altoButton1_Click(object sender, EventArgs e)
        {
            Random idv = new Random();
            int valoraev = idv.Next(1, 500);
            string lieev = "LIE-S.EV" + valoraev.ToString();  //INFORMACION ALEATORIA 
                                                              //QUERY DE CONSULTA
            conexion_supervision_tecnica.Consultageneral("INSERT INTO personal_agenda(ID_EVALUACION, PERSONAL, FECHA_TENTATIVA, MOTIVO, ESTATUS, RESULTADO,CATEGORIA) VALUES('" + lieev + "','" + NOMBRE.Texts + "','" + FECHA.Text + "','" + MOTIVO.Texts + "','PENDIENTE', '0.00', '" + CATEGORIA.Texts + "')");



            MySqlConnection CONEXION = conexion_supervision_tecnica.USR;  //CONEXION A DB 
            MySqlCommand comando = new MySqlCommand("SELECT NORMA FROM categorias_norma  WHERE CATEGORIA = '" + CATEGORIA.Texts + "' ", CONEXION);   //QUERY DE CONSULTA
            CONEXION.Open();  //CONEXION 
            MySqlDataReader consulta = comando.ExecuteReader();
            while (consulta.Read())
            {

                string nor = consulta.IsDBNull(0) ? String.Empty : consulta.GetString(0);    //INFO DEPOSITADA EN VARIABLES 
                int contador = 5;

                ComboBox COM = new ComboBox();
                MySqlConnection CONEXION2 = conexion_supervision_tecnica2.USR;  //CONEXION A DB 
                MySqlCommand comando2 = new MySqlCommand("SELECT ID_CUESTION FROM cuestionaminetos_norma  WHERE NORMA = '" + nor + "' ", CONEXION2);   //QUERY DE CONSULTA
                CONEXION2.Open();   //CONEXION 
                MySqlDataReader consulta2 = comando2.ExecuteReader();
                Random rnd = new Random();
                while (consulta2.Read())
                {
                    COM.Items.Add(consulta2["ID_CUESTION"].ToString());    //DEPOSITO DE INFORMACION

                    int index = rnd.Next(0, COM.Items.Count);
                    string dada = COM.Items[index].ToString();

                    if (contador > 0)
                    {                                                                //QUERY DE CONSULTA
                        conexion_supervision_tecnica3.Consultageneral("INSERT INTO evaluacion_personal (ID_EVALUACION, ID_CUESTION, NORMA, RESPUESTA, CALIFICACION) VALUES('" + lieev + "','" + dada + "','" + nor + "','SIN RESPUESTA','0.00')");


                        contador = contador - 1;

                    }

                    COM.Items.RemoveAt(index);



                }
                CONEXION2.Close();   //CIERRE DE CONEXION








            }
            CONEXION.Close();   //CIERRE DE CONEXION












            MessageBox.Show("Se ha dado de alta una nueva área");  //MENSAJE ALERTA 

        }

        private void FECHA_ValueChanged(object sender, EventArgs e)
        {






        }
    }
}
