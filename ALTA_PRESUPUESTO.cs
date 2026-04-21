using ERP_LIEC;
using MySql.Data.MySqlClient;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ERP_COMPLETO
{
    public partial class ALTA_PRESUPUESTO : Form
    {
        public ALTA_PRESUPUESTO()
        {
            InitializeComponent();
        }
        private void CARGA_RUBROS()
        {
            rubro.Items.Clear();
            MySqlConnection CONEXION = conexion_rh.USR;

            CONEXION.Open();
            MySqlCommand comando = new MySqlCommand("SELECT   AREA FROM areas_trabajo", CONEXION);

            MySqlDataReader registro = comando.ExecuteReader();

            while (registro.Read())
            {

                rubro.Items.Add(registro["AREA"].ToString());

            }

            CONEXION.Close();

        }

        private void CARGAR_OBRAS()
        {
            rubro.Items.Clear();
            MySqlConnection CONEXION = conexion_servicios_eventuales.USR;

            CONEXION.Open();
            MySqlCommand comando = new MySqlCommand("SELECT DISTINCTROW ALIAS FROM listado_obras", CONEXION);

            MySqlDataReader registro = comando.ExecuteReader();

            while (registro.Read())
            {

                rubro.Items.Add(registro["ALIAS"].ToString());

            }

            CONEXION.Close();

        }
        private void btn_consultar_Click(object sender, EventArgs e)
        {

            b1.Inactive1 = Color.FromArgb(255, 92, 0);
            b1.Inactive2 = Color.FromArgb(255, 92, 0);

            b2.Inactive1 = Color.Gray;
            b2.Inactive2 = Color.Gray;


            TIPO.Texts = "ÁREA";
            CARGA_RUBROS();
        }

        private void b2_Click(object sender, EventArgs e)
        {


            b1.Inactive1 = Color.Gray;
            b1.Inactive2 = Color.Gray;



            b2.Inactive1 = Color.FromArgb(255, 92, 0);
            b2.Inactive2 = Color.FromArgb(255, 92, 0);

            TIPO.Texts = "SERVICIO PERMANENTE";
            CARGAR_OBRAS();
        }
        bool existeyapresupuesto;

        public string mes;
        public string año;
        private void revisarsiexistepreuspuesto()
        {
            MySqlConnection CONEXION = conexion_contabilidad_local.USR;

            MySqlCommand comando = new MySqlCommand("SELECT * FROM presupuestos_generales   WHERE (MES = '" + mes + "' AND AÑO = '" + año + "') AND (AREA = '" + rubro.Texts + "')", CONEXION);

            CONEXION.Open();
            MySqlDataReader consulta = comando.ExecuteReader();
            if (consulta.Read())
            {
                existeyapresupuesto = true;

            }
            else
            {
                existeyapresupuesto = false;

            }
            CONEXION.Close();




        }
        private void altoButton2_Click(object sender, EventArgs e)
        {
            if (existeyapresupuesto == true)
            {
                MENSAJE_GENERAL MN = new MENSAJE_GENERAL();
                MN.BOTON.Text = "Presupuesto Existente";
                MN.BOTON.Inactive1 = System.Drawing.Color.Red; MN.BOTON.Inactive2 = System.Drawing.Color.Red;
                MN.ShowDialog();
            }
            else
            {
                conexion_contabilidad_local.registrar("INSERT INTO presupuestos_generales  (AÑO,MES,AREA,COORDINADOR,ESTATUS,PP,RUBRO,TIPO) values ('" + año + "', '" + mes + "' , '" + rubro.Texts + "' , '" + SESION.name + "', 'NO ENVIADO' ,'0', '" + RUBRO_ETIQUETA.Texts + "', '" + TIPO.Texts + "') ");
                MENSAJE_GENERAL MN = new MENSAJE_GENERAL();
                MN.BOTON.Text = "Apertura de Presupuesto Lista";
                MN.ShowDialog();
                MENU_PRICIPAL_ERP.psn.consulta_boton();
                this.Close();
            }
        }

        private void ALTA_PRESUPUESTO_Load(object sender, EventArgs e)
        {
            labelmes.Text = mes;
            labelaño.Text = año;
        }

        private void rubro_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            if (TIPO.Texts == "ÁREA")
            {

                MySqlConnection CONEXION = conexion_rh.USR;

                CONEXION.Open();
                MySqlCommand comando = new MySqlCommand("SELECT   ETIQUETA FROM areas_trabajo WHERE AREA = '" + rubro.Texts + "'", CONEXION);

                MySqlDataReader registro = comando.ExecuteReader();

                if (registro.Read())
                {

                    RUBRO_ETIQUETA.Texts = (registro["ETIQUETA"].ToString());

                }

                CONEXION.Close();
            }
            else
            {

                MySqlConnection CONEXION = conexion_servicios_eventuales.USR;

                CONEXION.Open();
                MySqlCommand comando = new MySqlCommand("SELECT  CLAVE_OBRA FROM listado_obras WHERE ALIAS = '" + rubro.Texts + "'", CONEXION);

                MySqlDataReader registro = comando.ExecuteReader();

                if (registro.Read())
                {

                    RUBRO_ETIQUETA.Texts = (registro["CLAVE_OBRA"].ToString());

                }

                CONEXION.Close();


            }
        }
    }
}
