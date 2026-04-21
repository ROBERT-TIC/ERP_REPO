using System;   //DEFINEN UN AMBITO PARA UTILIZAR RECURSOS //
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ERP_COMPLETO;
using ERP_LIEC;
using MySql.Data.MySqlClient;
using SpreadsheetLight;
using DocumentFormat.OpenXml;
using System.IO;   //DEFINEN UN AMBITO PARA UTILIZAR RECURSOS //

namespace ERP_COMPLETO
{
    public partial class autos : Form  //CLASE PRINCIPAL DEL FORMULARIO ACTUAL
    {

        string usuario = SESION.usuario; //VARIABLES INICIALES
        string proceso = SESION.proceso; //VARIABLES INICIALES


        public autos()
        {
            InitializeComponent();
        }

        string EXCESO_K = "NO";
        string ID_VEHICULO = "ID_VEHICULO";


        private void pictureBox2_Click(object sender, EventArgs e)  //EVENTO DE BOTON 
        {
            INDEX_MANTENIMIENTO IND = new INDEX_MANTENIMIENTO();
            this.Hide();
            IND.ShowDialog();
            this.Close();
        }

        private void label23_Click(object sender, EventArgs e)
        {

        }

        private void textBox14_TextChanged(object sender, EventArgs e)
        {

        }

        private void BT1_Click(object sender, EventArgs e)
        {
            BT1.Visible = false;
            BT2.Visible = false;
            tabla.DataSource = conexion_mantenimineto.Consultageneral("SELECT * FROM autos_control_servicio where FOLIO  = '" + FOLIO.Text+"'");  //QUERY DE CONSULTA

            NOMBRE.Text = tabla.Rows[0].Cells[2].Value.ToString();
            ADSCRIPCION.Text = tabla.Rows[0].Cells[3].Value.ToString();
            FECHA_SOLICITUD.Text = tabla.Rows[0].Cells[4].Value.ToString();
            LECTURA_ODOMETRO_IN.Text = tabla.Rows[0].Cells[5].Value.ToString();  //DEPOSITO DE INFORMACION
            TANQUE_COM_INI.Text = tabla.Rows[0].Cells[6].Value.ToString();
            HERRAMIENTAS1.Text = tabla.Rows[0].Cells[7].Value.ToString();
            LLANTA_1.Text = tabla.Rows[0].Cells[8].Value.ToString();
            GATO1.Text = tabla.Rows[0].Cells[9].Value.ToString();
            LLAVE1.Text = tabla.Rows[0].Cells[10].Value.ToString();
            LIMPIADORES1.Text = tabla.Rows[0].Cells[11].Value.ToString();  //DEPOSITO DE INFORMACION
           EXTINTOR1.Text = tabla.Rows[0].Cells[12].Value.ToString();
           TAPONES1.Text = tabla.Rows[0].Cells[13].Value.ToString();
            TAPETES1.Text = tabla.Rows[0].Cells[14].Value.ToString();
           TAPON1.Text = tabla.Rows[0].Cells[15].Value.ToString();
            ENCENDEDOR1.Text = tabla.Rows[0].Cells[16].Value.ToString();
            CENICERO1.Text = tabla.Rows[0].Cells[17].Value.ToString();
            BAYONETA1.Text = tabla.Rows[0].Cells[18].Value.ToString();
            RADIO1.Text = tabla.Rows[0].Cells[19].Value.ToString();
            ANTENA1.Text = tabla.Rows[0].Cells[20].Value.ToString();
            ESPEJOS1.Text = tabla.Rows[0].Cells[21].Value.ToString();
            LECTURA_ODOMETRO_FIN.Text = tabla.Rows[0].Cells[22].Value.ToString();  //DEPOSITO DE INFORMACION
            TANQUE_COM_FIN.Text = tabla.Rows[0].Cells[23].Value.ToString();
            HERRAMIENTAS2.Text = tabla.Rows[0].Cells[24].Value.ToString();
            LLANTA_2.Text = tabla.Rows[0].Cells[25].Value.ToString();
            GATO2.Text = tabla.Rows[0].Cells[26].Value.ToString();
            LLAVE2.Text = tabla.Rows[0].Cells[27].Value.ToString();
           LIMPIADORES2.Text = tabla.Rows[0].Cells[28].Value.ToString();  //DEPOSITO DE INFORMACION
            EXTINTOR2.Text = tabla.Rows[0].Cells[29].Value.ToString();
            TAPONES2.Text = tabla.Rows[0].Cells[30].Value.ToString();
            TAPONES2.Text = tabla.Rows[0].Cells[31].Value.ToString();
            TAPON2.Text = tabla.Rows[0].Cells[32].Value.ToString();
            ENCENDEDOR2.Text = tabla.Rows[0].Cells[33].Value.ToString();
            CENICERO2.Text = tabla.Rows[0].Cells[34].Value.ToString();
            BAYONETA2.Text = tabla.Rows[0].Cells[35].Value.ToString();
            RADIO2.Text = tabla.Rows[0].Cells[35].Value.ToString();
            ANTENA2.Text = tabla.Rows[0].Cells[36].Value.ToString();
            ESPEJOS2.Text = tabla.Rows[0].Cells[37].Value.ToString();
            KM_RECORRIDOS.Text = tabla.Rows[0].Cells[38].Value.ToString();  //DEPOSITO DE INFORMACION
            PANEL_BASE.Visible = true;
        }


        private void control_autos_excel()
        {

            DateTime fecha_for = FECHA_SOLICITUD.Value.AddDays(0);
            string ruta = @"A:\FORMATOS\MANTENIMIENTO\CONTROL VEHÍCULAR.xlsx";   //RUTAS DE ACCESO A RECURSOS 
            string plantilla = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string pl = Path.Combine(plantilla, "SSV - " + FOLIO.Text + ".xlsx");
            SLDocument reporte = new SLDocument(ruta);
        
            
            reporte.SetCellValue("A2", NOMBRE.Text); //INFO DEPOSITADA EN COORDENADAS 
            reporte.SetCellValue("L2", FOLIO.Text);
            reporte.SetCellValue("P4", fecha_for.ToString("dd"));
            reporte.SetCellValue("Q4", fecha_for.ToString("MM"));
            reporte.SetCellValue("R4", fecha_for.ToString("yyyy"));
            reporte.SetCellValue("A6", marca.Text); //INFO DEPOSITADA EN COORDENADAS 
            reporte.SetCellValue("G6", modelo.Text);
            reporte.SetCellValue("M6", placas.Text);
            reporte.SetCellValue("A7", ADSCRIPCION.Text);
            reporte.SetCellValue("A8", LECTURA_ODOMETRO_IN.Text);
            reporte.SetCellValue("J8", LECTURA_ODOMETRO_FIN.Text); //INFO DEPOSITADA EN COORDENADAS 
            reporte.SetCellValue("P8", KM_RECORRIDOS.Text);
            reporte.SetCellValue("J11", TANQUE_COM_INI.Text);
            reporte.SetCellValue("K11", TANQUE_COM_FIN.Text); //INFO DEPOSITADA EN COORDENADAS 

            ///////
            if(HERRAMIENTAS1.Text == "SI") { reporte.SetCellValue("E14", "X"); } else { reporte.SetCellValue("F14", "X"); } //CONDICIONAL 
            if (LLANTA_1.Text == "SI") { reporte.SetCellValue("E15", "X"); } else { reporte.SetCellValue("F15", "X"); }
            if (GATO1.Text == "SI") { reporte.SetCellValue("E16", "X"); } else { reporte.SetCellValue("F16", "X"); }
            if (LLAVE1.Text == "SI") { reporte.SetCellValue("E17", "X"); } else { reporte.SetCellValue("F17", "X"); }
            if (LIMPIADORES1.Text == "SI") { reporte.SetCellValue("E18", "X"); } else { reporte.SetCellValue("F18", "X"); } //CONDICIONAL 
            if (EXTINTOR1.Text == "SI") { reporte.SetCellValue("E19", "X"); } else { reporte.SetCellValue("F19", "X"); }
            if (TAPONES1.Text == "SI") { reporte.SetCellValue("E20", "X"); } else { reporte.SetCellValue("F20", "X"); }
            if (TAPETES1.Text == "SI") { reporte.SetCellValue("E21", "X"); } else { reporte.SetCellValue("F21", "X"); }
            if (TAPON1.Text == "SI") { reporte.SetCellValue("E22", "X"); } else { reporte.SetCellValue("F22", "X"); }
            if (ENCENDEDOR1.Text == "SI") { reporte.SetCellValue("E23", "X"); } else { reporte.SetCellValue("F23", "X"); } //CONDICIONAL 
            if (CENICERO1.Text == "SI") { reporte.SetCellValue("E24", "X"); } else { reporte.SetCellValue("F24", "X"); }
            if (BAYONETA1.Text == "SI") { reporte.SetCellValue("E25", "X"); } else { reporte.SetCellValue("F25", "X"); }
            if (RADIO1.Text == "SI") { reporte.SetCellValue("E26", "X"); } else { reporte.SetCellValue("F26", "X"); }
            if (ANTENA1.Text == "SI") { reporte.SetCellValue("E27", "X"); } else { reporte.SetCellValue("F27", "X"); }
            if (ESPEJOS1.Text == "SI") { reporte.SetCellValue("E28", "X"); } else { reporte.SetCellValue("F28", "X"); } //CONDICIONAL 


            /////
            if (HERRAMIENTAS2.Text == "SI") { reporte.SetCellValue("G14", "X"); } else { reporte.SetCellValue("H14", "X"); }
            if (LLANTA_2.Text == "SI") { reporte.SetCellValue("G15", "X"); } else { reporte.SetCellValue("H15", "X"); }
            if (GATO2.Text == "SI") { reporte.SetCellValue("G16", "X"); } else { reporte.SetCellValue("H16", "X"); }
            if (LLAVE2.Text == "SI") { reporte.SetCellValue("G17", "X"); } else { reporte.SetCellValue("H17", "X"); }
            if (LIMPIADORES2.Text == "SI") { reporte.SetCellValue("G18", "X"); } else { reporte.SetCellValue("H18", "X"); } //CONDICIONAL 
            if (EXTINTOR2.Text == "SI") { reporte.SetCellValue("G19", "X"); } else { reporte.SetCellValue("H19", "X"); }
            if (TAPONES2.Text == "SI") { reporte.SetCellValue("G20", "X"); } else { reporte.SetCellValue("H20", "X"); }
            if (TAPETES2.Text == "SI") { reporte.SetCellValue("G21", "X"); } else { reporte.SetCellValue("H21", "X"); }
            if (TAPON2.Text == "SI") { reporte.SetCellValue("G22", "X"); } else { reporte.SetCellValue("H22", "X"); }
            if (ENCENDEDOR2.Text == "SI") { reporte.SetCellValue("G23", "X"); } else { reporte.SetCellValue("H23", "X"); }
            if (CENICERO2.Text == "SI") { reporte.SetCellValue("G24", "X"); } else { reporte.SetCellValue("H24", "X"); }
            if (BAYONETA2.Text == "SI") { reporte.SetCellValue("G25", "X"); } else { reporte.SetCellValue("H25", "X"); } //CONDICIONAL 
            if (RADIO2.Text == "SI") { reporte.SetCellValue("G26", "X"); } else { reporte.SetCellValue("H26", "X"); }
            if (ANTENA2.Text == "SI") { reporte.SetCellValue("G27", "X"); } else { reporte.SetCellValue("H27", "X"); }
            if (ESPEJOS2.Text == "SI") { reporte.SetCellValue("G28", "X"); } else { reporte.SetCellValue("H28", "X"); }


            reporte.SaveAs(pl);
            MessageBox.Show("REGISTRO GUARDADO CORRECTAMENTE", "OPERACIÓN EXITOSA", MessageBoxButtons.OK, MessageBoxIcon.Information);


        }

        private void BT2_Click(object sender, EventArgs e)
        {
            PANEL_BASE.Visible = true;

            
            
            
            BT1.Visible = false;
            BT2.Visible = false;

            tabla.DataSource = conexion_mantenimineto.Consultageneral("SELECT * FROM autos_control_servicio");   //QUERY DE CONSULTA
            int conteo = tabla.RowCount + 1;


            DateTime hoy = DateTime.Today.AddDays(0);
            string conmp = "LIE-SSV-"+hoy.ToString("MM-yyyy") + Convert.ToString(conteo);

            FOLIO.Text = conmp;

         



        }

        private void altoButton3_Click(object sender, EventArgs e)
        {
            tabla.DataSource = conexion_mantenimineto.Consultageneral("SELECT * FROM autos_control_servicio");   //QUERY DE CONSULTA
            int conteo = tabla.RowCount + 1;


            DateTime hoy = DateTime.Today.AddDays(0);
            string conmp = "LIE-SSV-" + hoy.ToString("MM-yyyy") + Convert.ToString(conteo);


            conexion_mantenimineto.registrar("INSERT INTO autos_control_servicio(FOLIO,NOMBRE,ADSCRIPCION,FECHA,LECTURA_INICIAL,TANQUE_INICIAL,HERRAMIENTAS1,LLANTAS1,GATO1,LLAVE1,LIMPIADORES1,EXTINTOR1,TAPONES1,TAPETES1,TAPON1,ENCENDEDOR1,CENICERO1,BAYONETA1,	RADIO1,ANTENA1,ESPEJOS1,LECTURA_FINAL,TANQUE_FINAL,HERRAMIENTAS2,LLANTAS2,GATO2,LLAVE2,LIMPIADORES2,EXTINTOR2,TAPONES2,TAPETES2,TAPON2,ENCENDEDOR2,CENICERO2,BAYONETA2,RADIO2,ANTENA2,ESPEJOS2,KM_RECORRIDOS,ESTATUS,OBSERVACIONES,RUTA1E,RUTA2E,RUTA3E,RUTA4E,RUTA1S,	RUTA2S,	RUTA3S,RUTA4S) VALUES ('" + conmp + "','" + NOMBRE.Text + "','" + ADSCRIPCION.Text + "','" + FECHA_SOLICITUD.Text + "','" + LECTURA_ODOMETRO_IN.Text + "','" + TANQUE_COM_INI.Text + "','" + HERRAMIENTAS1.Text + "','" + LLANTA_1.Text + "','" + GATO1.Text + "','" + LLAVE1.Text + "','" + LIMPIADORES1.Text + "','" + EXTINTOR1.Text + "','" + TAPONES1.Text + "','" + TAPETES1.Text + "','" + TAPON1.Text + "','" + ENCENDEDOR1.Text + "','" + CENICERO1.Text + "','" + BAYONETA1.Text + "','" + RADIO1.Text + "','" + ANTENA1.Text + "','" + ESPEJOS1.Text + "','" + LECTURA_ODOMETRO_FIN.Text + "','" + TANQUE_COM_FIN.Text + "','" + HERRAMIENTAS2.Text + "','" + LLANTA_2.Text + "','" + GATO2.Text + "','" + LLAVE2.Text + "','" + LIMPIADORES2.Text + "','" + EXTINTOR2.Text + "','" + TAPONES2.Text + "','" + TAPETES2.Text + "','" + TAPON2.Text + "','" + ENCENDEDOR2.Text + "','" + CENICERO2.Text + "','" + BAYONETA2.Text + "','" + RADIO2.Text + "','" + ANTENA2.Text + "','" + ESPEJOS2.Text + "','" + KM_RECORRIDOS.Text + "','PENDIENTE','OBSERVACIONES','rutapen','rutapen','rutapen','rutapen','rutapen','rutapen','rutapen','rutapen')");
            MessageBox.Show("REGISTRO EXÍTOSAMENTE REALIZADO", "NOTIFICACIÓN DE OPERACIONES", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void autos_Load(object sender, EventArgs e) //FUNCION PRINCIPAL DE ARRANQUE
        {
            folios_servicio();
            generacion_incidencia(); //FUNCIONES A LLAMAR AL INICIAR EL FORMULARIO
            generacion_MANTENIMIENTO();

        }
        private void generacion_incidencia()
        {
            tabla.DataSource = conexion_mantenimineto.Consultageneral("SELECT * FROM incidencias_autos");   //QUERY DE CONSULTA
            int conteo_incidencias = tabla.RowCount;
            DateTime hoy = DateTime.Today.AddDays(0);
            string id_in = "LIE-INC-" + hoy.ToString("yyyy-MM") + Convert.ToString(conteo_incidencias);
            id_incidencia.Text = id_in;

        }
        private void generacion_MANTENIMIENTO()
        {
            tabla.DataSource = conexion_mantenimineto.Consultageneral("SELECT * FROM mantenimiento_autos");   //QUERY DE CONSULTA
            int conteo_manteniminetos = tabla.RowCount;
            DateTime hoy = DateTime.Today.AddDays(0);
            string id_in = "LIE-MTN-" + hoy.ToString("yyyy-MM") + Convert.ToString(conteo_manteniminetos);
            ID_MANTENIMIENTO.Text = id_in;

        }

        private void folios_servicio()
        {

            MySqlConnection CONEXION1 = conexion_mantenimineto.USR;


            MySqlCommand comando = new MySqlCommand("SELECT DISTINCTROW FOLIO FROM autos_control_servicio ", CONEXION1);    //QUERY DE CONSULTA
            CONEXION1.Open();
            MySqlDataReader registro = comando.ExecuteReader();

            while (registro.Read())
            {

                FOLIO.Items.Add(registro["FOLIO"].ToString());  //DEPOSITO DE INFORMACION


            }

            CONEXION1.Close();




        }

        private void BT_ACTUALIZAR_Click(object sender, EventArgs e)
        {
           
            
            conexion_mantenimineto.USR.Open();
            String Query = "UPDATE autos_control_servicio SET  NOMBRE='" + NOMBRE.Text +   //QUERY DE CONSULTA
                           "',ADSCRIPCION='" + ADSCRIPCION.Text +
                           "',FECHA='" + FECHA_SOLICITUD.Text +
                           "',LECTURA_INICIAL='" + LECTURA_ODOMETRO_IN.Text +
                            "',TANQUE_INICIAL='" + TANQUE_COM_INI.Text +
                             "',HERRAMIENTAS1='" + HERRAMIENTAS1.Text +
                             "',LLANTAS1='" + LLANTA_1.Text+
                              "',GATO1='" + GATO1.Text +
                           "',LLAVE1='" + LLAVE1.Text +
                            "',LIMPIADORES1='" + LIMPIADORES1.Text +
                             "',EXTINTOR1='" + EXTINTOR1.Text +
                             "',TAPONES1='" + TAPONES1.Text +
                              "',TAPETES1='" + TAPETES1.Text +
                           "',TAPON1='" + TAPON1.Text +
                            "',ENCENDEDOR1='" + ENCENDEDOR1.Text +
                             "',CENICERO1='" + CENICERO1.Text +
                             "',BAYONETA1='" + BAYONETA1.Text +
                              "',RADIO1='" + RADIO1.Text +
                           "',ANTENA1='" + ANTENA1.Text +
                            "',ESPEJOS1='" + ESPEJOS1.Text +
                             "',LECTURA_FINAL='" + LECTURA_ODOMETRO_FIN.Text +
                             "',TANQUE_FINAL='" + TANQUE_COM_FIN.Text +
                                "',HERRAMIENTAS2='" + HERRAMIENTAS2.Text +
                            "',LLANTAS2='" + LLANTA_2.Text +
                             "',GATO2='" + GATO2.Text +
                             "',LLAVE2='" + LLAVE2.Text +
                              "',LIMPIADORES2='" + LIMPIADORES2.Text +
                           "',EXTINTOR2='" + EXTINTOR2.Text +
                            "',TAPONES2='" + TAPONES2.Text +
                             "',TAPETES2='" + TAPETES2.Text +
                             "',TAPON2='" + TAPON2.Text +
                                "',ENCENDEDOR2='" + ENCENDEDOR2.Text +
                            "',CENICERO2='" + CENICERO2.Text +
                             "',BAYONETA2='" + BAYONETA2.Text +
                             "',RADIO2='" + RADIO2.Text +
                              "',ANTENA2='" + ANTENA2.Text +
                           "',ESPEJOS2='" + ESPEJOS2.Text +
                            "',KM_RECORRIDOS='" + KM_RECORRIDOS.Text +
                             "',ESTATUS='" + "pendiente"+
                             "',OBSERVACIONES='" + "pendiente" +

                            

                           "'WHERE FOLIO = '" + FOLIO.Text +

                           "';";

            MySqlCommand comando = new MySqlCommand(Query, conexion.USR);  //CONEXION A DB 

            comando.ExecuteNonQuery();
            conexion_mantenimineto.USR.Close();

            MessageBox.Show("ACTUALIZACIÓN EXÍTOSAMENTE REALIZADA", "NOTIFICACIÓN DE OPERACIONES", MessageBoxButtons.OK, MessageBoxIcon.Information);


        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            control_autos_excel();
        }

        private void MOTIVO_INCIDENCIA_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(MOTIVO_INCIDENCIA.Text == "EXCESO DE VELOCIDAD")
            {
                label63.Visible = true;
                EXCESO_KM.Visible = true;
                EXCESO_K = "SI;";
            }
            else
            {
                label63.Visible = false;
                EXCESO_KM.Visible = false;
                EXCESO_K = "NO";
            }
        }

        private void altoButton1_Click(object sender, EventArgs e)
        {


            //QUERY DE CONSULTA
            conexion_mantenimineto.registrar("INSERT INTO incidencias_autos(ID_INCIDENCIA,ID_VEHICULO,PLACAS,MOTIVO,OBSERVACIONES,FECHA,ACCION_CORRECTIVA,EXCESO_VELOCIDAD,KM_EXCESO) VALUES ('" + id_incidencia.Text+ "','ID_VEHICULO','" + placas.Text + "','" + MOTIVO_INCIDENCIA.Text + "','" + observaciones.Text + "','" + fecha_incidencias.Text + "','accion','" + EXCESO_K+ "','" + EXCESO_KM.Text + "')");

            generacion_incidencia();
        
            MOTIVO_INCIDENCIA.Text = "";
            EXCESO_KM.Text = "";
            EXCESO_KM.Visible = false;
            label63.Visible = false;
            observaciones.Text = "";


            MessageBox.Show("REGISTRO DE INCIDENCIA EXÍTOSAMENTE REALIZADO", "NOTIFICACIÓN DE OPERACIONES", MessageBoxButtons.OK, MessageBoxIcon.Information); //MENSAJE ALERTA 

            DGV_USO.DataSource = conexion_mantenimineto.Consultageneral("SELECT * FROM autos_control_servicio");  //QUERY DE CONSULTA
            DGV_USO.DataSource = conexion_mantenimineto.Consultageneral("SELECT * FROM autos_control_servicio");  //QUERY DE CONSULTA



        }

        private void altoButton2_Click(object sender, EventArgs e)
        {


            conexion_mantenimineto.registrar("INSERT INTO mantenimiento_autos(ID_VEHICULO,MARCA,TIPO,	MODELO,PLACAS,TERMINACION,RESPONSABLE,UBICACIÓN,FECHA,SERVICIO,COSTO,REALIZO,OBSERVACIONES) VALUES ('" + ID_VEHICULO + "','" +marca.Text+"','" + tipo.Text + "','" + modelo.Text + "','" + placas.Text + "','TERMINACION','"+RESPONSABLE_MTN.Text+"','" + UBICACION_MTN.Text + "','" + FECHA_MTN.Text + "','" + SERVICIO_MTN.Text + "','" + COSTO_MTN.Text + "','" + REALIZO_MTN.Text + "','" + OBSERVACION_MTN.Text + "')");
            generacion_MANTENIMIENTO();
            MessageBox.Show("REGISTRO DE MANTENIMIENTO EXÍTOSAMENTE REALIZADO", "NOTIFICACIÓN DE OPERACIONES", MessageBoxButtons.OK, MessageBoxIcon.Information); //MENSAJE ALERTA 
            RESPONSABLE_MTN.Text = "";
            UBICACION_MTN.Text = "";
            SERVICIO_MTN.Text = "";
            COSTO_MTN.Text = "";
            REALIZO_MTN.Text = "";
            OBSERVACION_MTN.Text = "";
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void altoButton3_Click_1(object sender, EventArgs e)
        {

        }
    }
}
