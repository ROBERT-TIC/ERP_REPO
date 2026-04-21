using ERP_LIEC;
using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace ERP_COMPLETO
{
    public partial class CONFIGURA_SUCURSAL : Form
    {
        public CONFIGURA_SUCURSAL()
        {
            InitializeComponent();
        }

        string ruta_definida = "";
        private void FILTRA_SUC()
        {

            MySqlConnection CONEXION1 = conexion_rh.USR;
            MySqlCommand comando = new MySqlCommand("SELECT DISTINCTROW NOMBRE FROM sucursales ", CONEXION1);
            CONEXION1.Open();
            MySqlDataReader registro = comando.ExecuteReader();

            while (registro.Read())
            {

                usuario.Items.Add(registro["NOMBRE"].ToString());


            }

            CONEXION1.Close();


        }

        private void CONFIGURA_SUCURSAL_Load(object sender, EventArgs e)
        {
            FILTRA_SUC();
        }

        private void definesucursales()
        {


            if (usuario.Texts == "C.T. CENTRAL") { ruta_definida = @"Z:\02 CONTROL DE REGISTROS\00 LAB CENTRAL\"; }
            else if (usuario.Texts == "C.T. TEPÓTZOTLÁN") { ruta_definida = @"Z:\02 CONTROL DE REGISTROS\01 SUC TEPOTZOTLÁN\"; }
            else if (usuario.Texts == "C.T. SAN LUIS POTOSI") { ruta_definida = @"Z:\02 CONTROL DE REGISTROS\02 SUC SLP\"; }
            else if (usuario.Texts == "C.T. LERMA") { ruta_definida = @"Z:\02 CONTROL DE REGISTROS\03 SUC LERMA\"; }
            else if (usuario.Texts == "C.T. MÉRIDA") { ruta_definida = @"Z:\02 CONTROL DE REGISTROS\04 SUC MÉRIDA\"; }
            else if (usuario.Texts == "C.T. TAPACHULA") { ruta_definida = @"Z:\02 CONTROL DE REGISTROS\05 SUC TAPACHULA\"; }
            else if (usuario.Texts == "C.T. MONTERREY") { ruta_definida = @"Z:\02 CONTROL DE REGISTROS\06 SUC MONTERREY\"; }



        }


        private void altoButton1_Click(object sender, EventArgs e)
        {
            definesucursales();

            conexion_login.USR.Open();//Se abre la conexión para evitar un error común

            string query = "UPDATE usuarios SET CONF_SUC = @confSuc, CON_RUT = @conRut WHERE usuario = @usuario";
            using (MySqlCommand comando = new MySqlCommand(query, conexion_login.USR))
            {
                comando.Parameters.AddWithValue("@usuario", SESION.usuario);
                comando.Parameters.AddWithValue("@confSuc", usuario.Texts);
                comando.Parameters.AddWithValue("@conRut", ruta_definida);


                comando.ExecuteNonQuery();
            }
            conexion_login.USR.Close();//Se cierra la conexión




            SESION.CONF_SUC = usuario.Texts;
            SESION.CON_RUT = ruta_definida;


            MENU_PRI.MNM.Text = "Enterprise Resources Planning      C.T. " + SESION.CONF_SUC + "         SG:" + SESION.CON_RUT;

            MENSAJE_GENERAL mn = new MENSAJE_GENERAL();
            mn.BOTON.Text = "Sucursal Actualizada";
            mn.Show();
            this.Close();






        }
    }
}
