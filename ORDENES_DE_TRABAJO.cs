using DocumentFormat.OpenXml.Spreadsheet;
using ERP_LIEC;
using GroupDocs.Merger;
using iTextSharp.text;
using iTextSharp.text.pdf;
using MySql.Data.MySqlClient;
using SpreadsheetLight;
using SweetAlertSharp;
using SweetAlertSharp.Enums;
using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Document = iTextSharp.text.Document;
using Excel = Microsoft.Office.Interop.Excel;
using File = System.IO.File;
using Size = System.Drawing.Size;

namespace ERP_COMPLETO
{
    public partial class ORDENES_DE_TRABAJO : Form
    {
        public ORDENES_DE_TRABAJO()
        {
            InitializeComponent();

            contextMenuStrip1.Renderer = new MyRenderer();

        }
        private class MyRenderer : ToolStripProfessionalRenderer
        {
            public MyRenderer() : base(new MyColors()) { }








        }
        public bool bolita = true;
        public bool ligada = false;
        public bool modifico_cop = false;

        public bool decision_cambio = false;
        public bool decision_cotizacion = false;
        public string folio_ot;


        public bool desde_pnd = false;








        public bool id = false;

        public string usuario = SESION.usuario;
        public string proceso = SESION.proceso;
        public string modificaciones;
        public double monto_recabado = 0; public double monto_recabado_IVA = 0;
        public string id_cotizacion = string.Empty;
        public string estatss;
        public DateTime fe_cot = DateTime.Today;
        public string servicios = "";
        public bool ot_por_cot = false;
        public bool cambiacotunavez = true;

        public bool copia = false;

        string TIEMPO;
        /// <summary>
        /// //ESTATICA
        /// </summary> 
        private void estatica()
        {


            clave_obra.MouseWheel += new MouseEventHandler(comboBox1_MouseWheel);
            this.ET.SetToolTip(pictureBox3, "Registro de Clientes");
            this.ET.SetToolTip(pictureBox6, "Generar Excel");
            this.ET.SetToolTip(pictureBox9, "Generar PDF");

            ///REDIMENSIONES
            pictureBox11.Size = new Size(30, 30);
            pictureBox6.Size = new Size(25, 25);
            pictureBox9.Size = new Size(25, 25);
            ID_COT.Height = 30;
            FOLIOO.Height = 30;
            MODI.Height = 30;
            tipo_ot.Height = 30;


            NOMBRE.Height = 30;
            EMPRESA.Height = 30;
            CODIGO_POSTAL.Height = 30;
            RFC.Height = 30;
            TELEFONO.Height = 30;
            EMAIL.Height = 30;

            NOMBRE_OBRA.Height = 30;
            DIRIGIDO.Height = 30;
            RECIB.Height = 30;
            AUTORIZA.Height = 30;
            NOMBRE_TEC.Height = 30;
            GRADO.Height = 30;
            PROGRAMA.Height = 30;

            RESGUARDO.Height = 30;

            PROPIEDAD.Height = 30;

            GRADO.Height = 30;

            clave_obra.Height = 30;


            registrar.Height = 30;
            modificar.Height = 30;
            borrar.Height = 30;

            NAM.Height = 30;
            CON.Height = 30;

            HORA.Height = 30;
            MINUTOS.Height = 30;
            informes_dirigidos.Height = 30;

            ////
            ///




            panel10.Height = 43;
            panel6.Height = 50;

            panel4.Left = (panel10.Width - panel4.Width) / 2;
            panel4.Top = (panel10.Height - panel4.Height) / 2;
            pictureBox11.Left = (label2.Left - pictureBox11.Width) - 3;

            pictureBox2.Size = new Size(30, 30);
            label22.Top = (panel6.Height - label22.Height) / 2;
            pictureBox2.Top = (panel6.Height - pictureBox2.Height) / 2;
            label37.Top = label22.Top;
            label34.Top = label22.Top;


            label22.Left = 30;
            ID_COT.Left = label22.Right + 5;

            pictureBox2.Left = ID_COT.Right + 7;
            label37.Left = pictureBox2.Right + 10;
            FOLIOO.Left = label37.Right + 5;
            label34.Left = FOLIOO.Right + 5;
            MODI.Left = label34.Right + 5;

            pictureBox6.Left = (this.Width - pictureBox6.Width) - 25;
            pictureBox9.Left = (pictureBox6.Left - pictureBox9.Width) - 5;
            pictureBox6.Top = (panel6.Height - pictureBox6.Height) / 2;
            pictureBox9.Top = (panel6.Height - pictureBox9.Height) / 2;
            pictureBox3.Top = (panel6.Height - pictureBox3.Height) / 2;
            pictureBox3.Left = (pictureBox9.Left - pictureBox3.Width) - 5;

            int cua1 = this.Width / 4;
            int cua2 = this.Width / 4 * 2;
            int cua3 = this.Width / 4 * 3;
            int cua4 = this.Width / 4 * 4;

            label11.Left = label22.Left;
            label11.Top = 15;
            int pm1 = label11.Left;

            label4.Left = pm1;
            label4.Top = label11.Bottom + 20;
            NOMBRE.Top = label4.Bottom + 5;
            NOMBRE.Left = pm1;
            NOMBRE.Width = cua2 - NOMBRE.Left;

            label5.Left = NOMBRE.Right + 10;
            label5.Top = label4.Top;

            EMPRESA.Left = NOMBRE.Right + 5;
            EMPRESA.Top = NOMBRE.Top;
            EMPRESA.Width = (pictureBox6.Right - EMPRESA.Left) - 5;


            label3.Left = pm1;
            label3.Top = NOMBRE.Bottom + 20;

            clave_obra.Left = pm1;
            clave_obra.Top = label3.Bottom + 10;
            clave_obra.Width = cua2 - clave_obra.Left;



            label7.Top = clave_obra.Top;
            label7.Left = EMPRESA.Left;
            CODIGO_POSTAL.Left = label7.Left;
            CODIGO_POSTAL.Top = label7.Bottom + 5;
            CODIGO_POSTAL.Width = EMPRESA.Width / 2;


            RFC.Left = CODIGO_POSTAL.Right + 5;
            RFC.Top = CODIGO_POSTAL.Top;
            RFC.Width = pictureBox6.Right - RFC.Left;
            label8.Top = label7.Top;
            label8.Left = RFC.Left;



            TELEFONO.Top = clave_obra.Bottom - TELEFONO.Height;
            TELEFONO.Left = CODIGO_POSTAL.Left;
            TELEFONO.Width = CODIGO_POSTAL.Width;

            label9.Top = (TELEFONO.Top - label9.Height) - 5;
            label9.Left = TELEFONO.Left;

            label10.Left = RFC.Left;
            label10.Top = label9.Top;
            EMAIL.Left = label8.Left;
            EMAIL.Top = TELEFONO.Top;
            EMAIL.Width = RFC.Width;
            pictureBox6.Left = (this.Width - pictureBox6.Width) - 25;
            pictureBox9.Left = (pictureBox6.Left - pictureBox9.Width) - 5;
            pictureBox6.Top = (panel6.Height - pictureBox6.Height) / 2;
            pictureBox9.Top = (panel6.Height - pictureBox9.Height) / 2;


            sepa1.Left = pm1;
            sepa1.Top = clave_obra.Bottom + 10;
            sepa1.Width = pictureBox6.Right - sepa1.Left;

            label12.Left = pm1;
            label12.Top = sepa1.Bottom + 15;


            label14.Left = pm1;
            label14.Top = label12.Bottom + 20;

            FECHA.Left = label14.Right + 10;
            FECHA.Top = label14.Top - 5;

            label15.Left = FECHA.Right + 5;
            label15.Top = label14.Top;

            HORA.Left = label15.Right + 5;
            HORA.Top = FECHA.Top;

            MINUTOS.Left = HORA.Right + 5;
            MINUTOS.Top = HORA.Top;



            label19.Top = FECHA.Bottom + 10;
            label19.Left = pm1;

            NOMBRE_OBRA.Top = label19.Bottom + 5;
            NOMBRE_OBRA.Left = pm1;
            NOMBRE_OBRA.Width = pictureBox6.Right - NOMBRE_OBRA.Left;



            label13.Top = NOMBRE_OBRA.Bottom + 10;
            label13.Left = pm1;

            DOMICILIO.Top = label13.Bottom + 5;
            DOMICILIO.Left = pm1;
            DOMICILIO.Width = pictureBox6.Right - DOMICILIO.Left;

            mapa_apoyo.Width = 165;
            mapa_apoyo.Height = 30;

            mapa_apoyo.Top = DOMICILIO.Bottom + 10;
            mapa_apoyo.Left = DOMICILIO.Right - mapa_apoyo.Width;


            label48.Top = DOMICILIO.Bottom + 5;
            label48.Left = pm1;

            informes_dirigidos.Left = pm1;
            informes_dirigidos.Top = label48.Bottom + 5;
            informes_dirigidos.Width = pictureBox6.Right - pm1;

            label17.Top = informes_dirigidos.Bottom + 10;
            label17.Left = pm1;

            DIRIGIDO.Left = pm1;
            DIRIGIDO.Top = label17.Bottom + 5;
            DIRIGIDO.Width = pictureBox6.Right - pm1;

            label18.Top = DIRIGIDO.Bottom + 10;
            label18.Left = pm1;
            RECIB.Left = pm1;
            RECIB.Top = label18.Bottom + 5;
            RECIB.Width = pictureBox6.Right - pm1;

            label23.Top = RECIB.Bottom + 10;
            label23.Left = pm1;
            AUTORIZA.Left = pm1;
            AUTORIZA.Top = label23.Bottom + 5;
            AUTORIZA.Width = pictureBox6.Right - pm1;


            label24.Top = AUTORIZA.Bottom + 10;
            label24.Left = pm1;
            NOMBRE_TEC.Left = pm1;
            NOMBRE_TEC.Top = label24.Bottom + 5;
            NOMBRE_TEC.Width = pictureBox6.Right - cua2;

            label26.Top = label24.Top;
            label26.Left = NOMBRE_TEC.Right + 5;
            GRADO.Left = label26.Left;
            GRADO.Top = NOMBRE_TEC.Top;
            GRADO.Width = cua3 - GRADO.Left;


            label20.Left = pm1;
            label20.Top = GRADO.Bottom + 10;

            PROGRAMA.Left = pm1;
            PROGRAMA.Top = label20.Bottom + 5;
            PROGRAMA.Width = pictureBox6.Right - PROGRAMA.Left;


            sepa2.Top = PROGRAMA.Bottom + 13;
            sepa2.Left = pm1;
            sepa2.Width = pictureBox6.Right - sepa2.Left;


            label21.Left = pm1;
            label21.Top = sepa2.Bottom + 13;




            label31.Top = label21.Top + 25;
            label31.Left = pm1;
            NAM.Top = label31.Top - 3;
            NAM.Left = FOLIOO.Right;
            sepa3.Top = label31.Bottom + 4;
            sepa3.Left = pm1;
            sepa3.Width = NAM.Right - sepa3.Left;
            label30.Left = pm1;
            label30.Top = sepa3.Bottom + 4;
            CON.Left = NAM.Left;
            CON.Top = label30.Top - 3;

            label6.Left = NAM.Right + 5;
            label6.Top = label31.Top;

            ESP_NAM.Height = 30;
            ESP_NAM.Left = label6.Right + 5;
            ESP_NAM.Top = NAM.Top;







            label28.Top = CON.Bottom + 10;
            label28.Left = pm1;

            RESGUARDO.Left = pm1;
            RESGUARDO.Top = label28.Bottom + 5;
            RESGUARDO.Width = pictureBox6.Right - RESGUARDO.Left;



            label35.Top = RESGUARDO.Bottom + 10;
            label35.Left = pm1;
            PROPIEDAD.Left = pm1;
            PROPIEDAD.Top = label35.Bottom + 5;
            PROPIEDAD.Width = pictureBox6.Right - pm1;



            sepa4.Top = PROPIEDAD.Bottom + 10;
            sepa4.Left = pm1;
            sepa4.Width = sepa1.Width;

            label41.Top = sepa4.Bottom + 10;
            label41.Left = pm1;
            label42.Left = pm1;
            label42.Top = label41.Bottom + 10;

            OBSERVACIONES.Left = pm1;
            OBSERVACIONES.Top = label42.Bottom + 5;
            OBSERVACIONES.Width = clave_obra.Width;
            CLIENTE_COMENTATRIOS.Left = CODIGO_POSTAL.Left;
            CLIENTE_COMENTATRIOS.Width = pictureBox6.Right - CLIENTE_COMENTATRIOS.Left;
            CLIENTE_COMENTATRIOS.Top = OBSERVACIONES.Top;
            label43.Top = label42.Top;
            label43.Left = CLIENTE_COMENTATRIOS.Left;

            ESTADO.Width = CLIENTE_COMENTATRIOS.Width;

            label16.Top = (CLIENTE_COMENTATRIOS.Top + CLIENTE_COMENTATRIOS.Height) + 25;
            label16.Left = (CLIENTE_COMENTATRIOS.Left - label16.Width);

            ESTADO.Top = (label16.Top + label16.Height) + 10;
            ESTADO.Left = label16.Left;






            label16.Left = CLIENTE_COMENTATRIOS.Left;
            label16.Top = CLIENTE_COMENTATRIOS.Bottom + 15;
            ESTADO.Top = CLIENTE_COMENTATRIOS.Bottom + 5;
            ESTADO.Left = label16.Right + 10;
            ESTADO.Width = CLIENTE_COMENTATRIOS.Right - ESTADO.Left;



            registrar.Left = (this.Width - registrar.Width) / 2;
            registrar.Top = ESTADO.Bottom + 35;

            borrar.Left = (registrar.Left - borrar.Width) - 15;
            borrar.Top = registrar.Top;

            modificar.Left = registrar.Right + 15;
            modificar.Top = borrar.Top;


            añoes.Height = 30;
            añoes.Left = EMPRESA.Right - añoes.Width;
            label38.Left = (añoes.Left - label38.Width) - 10;




            label44.Left = EMPRESA.Left;
            labo.Left = label44.Right + 10;

            labo.Width = label38.Left - labo.Left;
            labo.Height = 30;






            label16.Top = label42.Top;
            label16.Left = OBSERVACIONES.Right + 10;

            ESTADO.Top = label16.Bottom + 5;
            ESTADO.Left = label16.Left;



            tipo_ot.Left = (label44.Left - tipo_ot.Width) - 5;
            tipo_ot.Top = labo.Top;
            label47.Left = (tipo_ot.Left - label47.Width) - 5;
            label47.Top = label44.Top;



            label1.Top = clave_obra.Bottom + 3;
            label1.Left = clave_obra.Right - label1.Width;



            DGV.Left = OBSERVACIONES.Left;
            DGV.Top = registrar.Bottom + 10;
            DGV.Width = CLIENTE_COMENTATRIOS.Right - DGV.Left;




            PANEL_DINERO.Left = (DGV.Right - PANEL_DINERO.Width);
            PANEL_DINERO.Top = DGV.Bottom + 5;



            AG1.Left = (DGV.Right - AG1.Width) - 10;
            label25.Left = AG1.Left - label25.Width;
            AG1.Top = (DGV.Top - AG1.Height) - 20;
            label25.Top = AG1.Top;

            label27.Left = DGV.Left; label27.Top = label25.Top;

            precotiz.Height = 30;


            label29.Top = DGV.Bottom + 10;
            precotiz.Top = label29.Top;
            altoButton2.Top = label29.Top;

            altoButton2.Left = (PANEL_DINERO.Left - altoButton2.Width) - 10;
            precotiz.Left = (altoButton2.Left - precotiz.Width) - 10;
            label29.Left = (precotiz.Left - label29.Width) - 10;


            label32.Left = (this.Width - label29.Width) / 2;
            label32.Top = DGV.Top - 5;

            DGV.Columns[0].Width = 80;
            DGV.Columns[1].Width = (DGV.Width / 3) * 1;
            DGV.Columns[2].Width = 200;

            DGV.Columns[3].Width = 200;
            DGV.Columns[4].Width = 200;
            DGV.Columns[5].Width = 200;
            DGV.Columns[6].Width = 200;

            DGV.Columns[7].Width = 200;
            DGV.Columns[8].Width = 200;
            DGV.Columns[9].Width = 200;

            DGV.Columns[10].Width = 90;

        }


        private class MyColors : ProfessionalColorTable
        {
            public override System.Drawing.Color MenuItemSelected
            {
                get { return System.Drawing.Color.FromArgb(225, 92, 0); }
            }
            public override System.Drawing.Color MenuItemSelectedGradientBegin
            {
                get { return System.Drawing.Color.Orange; }
            }
            public override System.Drawing.Color MenuItemSelectedGradientEnd
            {
                get { return System.Drawing.Color.Yellow; }
            }
        }
        private void LISTADO()
        {
            if (desde_pnd == true)
            {

                MySqlConnection CONEXION1 = conexion_rh.USR;
                MySqlCommand comando = new MySqlCommand("SELECT DISTINCTROW NOMBRE FROM pdr_personal1  WHERE AREA_2 = 'LC PRUEBAS NO DESTRUCTIVAS' AND ESTATUS = 'ACTIVO'", CONEXION1);
                CONEXION1.Open();
                MySqlDataReader registro = comando.ExecuteReader();

                while (registro.Read())
                {

                    NOMBRE_TEC.Items.Add(registro["NOMBRE"].ToString());


                }

                CONEXION1.Close();
            }
            else
            {
                MySqlConnection CONEXION1 = conexion_rh.USR;
                MySqlCommand comando = new MySqlCommand("SELECT DISTINCTROW NOMBRE FROM pdr_personal1  WHERE (CATEGORIA NOT LIKE '%" + "ADMINISTRATIVO" + "%'  ) AND (ESTATUS = 'ACTIVO')", CONEXION1);
                CONEXION1.Open();
                MySqlDataReader registro = comando.ExecuteReader();

                while (registro.Read())
                {

                    NOMBRE_TEC.Items.Add(registro["NOMBRE"].ToString());


                }

                CONEXION1.Close();
            }








        }

        private void RECIBE_PND()
        {


            MySqlConnection CONEXION1 = conexion_servicios_eventuales.USR;
            MySqlCommand comando = new MySqlCommand("SELECT DISTINCTROW RECIBIO FROM ordenes_trabajo_pnd", CONEXION1);
            CONEXION1.Open();
            MySqlDataReader registro = comando.ExecuteReader();

            while (registro.Read())
            {

                RECIB.Items.Add(registro["RECIBIO"].ToString());


            }

            CONEXION1.Close();

            ///////////////
            MySqlConnection CONEXION2 = conexion_servicios_eventuales.USR;
            MySqlCommand comando2 = new MySqlCommand("SELECT DISTINCTROW PROGRAMA FROM ordenes_trabajo_pnd", CONEXION2);
            CONEXION2.Open();
            MySqlDataReader registro2 = comando2.ExecuteReader();

            while (registro2.Read())
            {


                PROGRAMA.Items.Add(registro2["PROGRAMA"].ToString());

            }

            CONEXION2.Close();






        }
        private void RECIBE_SEE()
        {


            MySqlConnection CONEXION1 = conexion_servicios_eventuales.USR;
            MySqlCommand comando = new MySqlCommand("SELECT DISTINCTROW RECIBIO FROM ordenes_trabajo", CONEXION1);
            CONEXION1.Open();
            MySqlDataReader registro = comando.ExecuteReader();

            while (registro.Read())
            {

                RECIB.Items.Add(registro["RECIBIO"].ToString());


            }

            CONEXION1.Close();

            ///////////////
            MySqlConnection CONEXION2 = conexion_servicios_eventuales.USR;
            MySqlCommand comando2 = new MySqlCommand("SELECT DISTINCTROW PROGRAMA FROM ordenes_trabajo", CONEXION2);
            CONEXION2.Open();
            MySqlDataReader registro2 = comando2.ExecuteReader();

            while (registro2.Read())
            {


                PROGRAMA.Items.Add(registro2["PROGRAMA"].ToString());

            }

            CONEXION2.Close();








        }
        private void claves_obra()
        {

            MySqlConnection CONEXION1 = conexion_servicios_eventuales.USR;
            MySqlCommand comando = new MySqlCommand("SELECT DISTINCTROW CLAVE_OBRA FROM listado_obras ORDER BY CLAVE_OBRA ASC", CONEXION1);

            CONEXION1.Open();
            MySqlDataReader registro = comando.ExecuteReader();

            while (registro.Read())
            {

                clave_obra.Items.Add(registro["CLAVE_OBRA"].ToString());

            }

            CONEXION1.Close();

        }

        ToolTip tooltip = new ToolTip();
        private void comboBox1_MouseWheel(object sender, MouseEventArgs e)
        {
            ((HandledMouseEventArgs)e).Handled = true;
        }

        string texto3 = "";
        private void verificar_retorno()
        {


            MySqlConnection CONEXION1 = conexion_cobranza.USR;
            MySqlCommand comando = new MySqlCommand("SELECT * FROM retornos_ot WHERE ID_OT ='" + FOLIOO.Texts + "' ", CONEXION1);

            CONEXION1.Open();
            MySqlDataReader registro = comando.ExecuteReader();

            while (registro.Read())
            {

                // se muestra aunque el control no tenga foco

                // Ejemplo de uso
                string texto = (registro["FECHA_RETORNO"].ToString());
                string texto2 = (registro["MOTIVO"].ToString());
                texto3 = DateTime.Parse(texto).ToString("yyyy-MM-dd") + "\n" + texto2;




            }

            CONEXION1.Close();

            if (ESTADO.Texts == "VERIFICAR")
            {

                tooltip = new ToolTip();
                tooltip.ShowAlways = true;


                tooltip.Show(texto3, FOLIOO, FOLIOO.Left, FOLIOO.Top, int.MaxValue);


            }

            /*Label lblTooltip = new Label();
            lblTooltip.Text = texto3;
            lblTooltip.AutoSize = true;
            lblTooltip.Font = new System.Drawing.Font("Poppins SemiBold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lblTooltip.ForeColor = System.Drawing.Color.FromArgb(227,92,0);
            lblTooltip.Location = new System.Drawing.Point(label11.Right + 10, label11.Bottom + 5);
            panel1.Controls.Add(lblTooltip);*/




        }

        private void ORDENES_DE_TRABAJO_Load(object sender, EventArgs e)
        {
            estatica();

            añoes.Texts = DateTime.Now.ToString("yyyy");



            this.ET.SetToolTip(pictureBox6, "Genera OT");
            this.ET.SetToolTip(NOMBRE_TEC, "Da click aqui para ampliar la lista de técnicos");

            if (decision_cambio == true)
            {

                precotiz.Texts = ID_COT.Text;
                registrar.Visible = true;
                modificar.Visible = true;
                borrar.Visible = true;
                labo.Enabled = false;
                añoes.Enabled = false;
                labo.Visible = false;
                label44.Visible = false;

                label47.Visible = false;
                tipo_ot.Visible = false;

                busca_conceptos();
                verificar_retorno();

                if (ESTADO.Texts.Contains("REVISADO") == true || ESTADO.Texts == "CANCELADA")
                {
                    ESTADO.Enabled = true;
                    pictureBox2.Enabled = true;
                    modificar.Enabled = true;
                    modificar.Visible = false;
                    borrar.Enabled = false;
                    DGV.ReadOnly = true;
                    AG1.Enabled = false;


                }



            }
            else if (decision_cambio == false)
            {
                consecutivo();
                this.FormBorderStyle = FormBorderStyle.None;

                int conteo_orden = 0;
                string datofe = añoes.Texts + "-01-01";

                if (desde_pnd == true)
                {
                    cargar_ot_segunsucursal();
                }
                else
                {
                    cargar_ot_segunsucursal();
                }




                registrar.Visible = true;
                modificar.Visible = false;
                borrar.Visible = false;
                registrar.Enabled = true;
                FECHA.Text = DateTime.Today.ToString("yyyy-MM-dd");


                if (RECIB.Texts == string.Empty) { RECIB.Texts = SESION.name; }


                if (ESTADO.Texts == "SIN OT")
                {
                    ESTADO.Texts = "PENDIENTE";
                }



            }

            if (copia == true)
            {
                cargar_ot_segunsucursal();
                registrar.Visible = true;
                modificar.Visible = false;
                borrar.Visible = false;

            }

            LISTADO();

            if (ESTADO.Texts == "")
            {
                ESTADO.Texts = "PENDIENTE";
            }


            if (ESTADO.Texts == "SIN OT")
            {
                ot_por_cot = true;
            }
            claves_obra();
            revisar_importes();


            consulta_dirigidosainforme();

            if (SESION.puesto == "COBRANZA")
            {
                altoButton1.Visible = true;

            }
            altoButton1.Left = DGV.Left;

            if (desde_pnd == true) { RECIBE_PND(); }
            else
            {
                RECIBE_SEE();

            }
            if (PROGRAMA.Texts == string.Empty) { PROGRAMA.Texts = SESION.name; }

            if (SESION.usuario == "ARAMOSM" || SESION.usuario == "ARAMIREZB" || SESION.usuario == "TJIMENEZ" || SESION.usuario == "RROJAS")
            {
                borrar.Enabled = true;



            }
            else
            {
                borrar.Enabled = false;

            }


            ///////VALIDA LA SUMATORIA
            ///
            if (DGV.RowCount > 0)
            {



                if (DGV.CurrentRow.Cells[3].Value == null || DGV.CurrentRow.Cells[4].Value == null)
                {

                }
                else
                {
                    double val1 = double.Parse(DGV.CurrentRow.Cells["CANTIDAD"].Value.ToString());
                    double val2 = double.Parse(DGV.CurrentRow.Cells["PU"].Value.ToString());
                    double res = Math.Round(val1 * val2);
                    DGV.CurrentRow.Cells["IMPORTE"].Value = res.ToString("N2");

                }

            }
            revisar_importes();










        }


        //esta funcion es lo mismo que Load  solo que se utiliza para cargar todo lo del formulario  desde fuera  para autogenerar el PDF
        public void load_paraautogenerar()
        {

            añoes.Texts = DateTime.Now.ToString("yyyy");



            this.ET.SetToolTip(pictureBox6, "Genera OT");
            this.ET.SetToolTip(NOMBRE_TEC, "Da click aqui para ampliar la lista de técnicos");

            if (decision_cambio == true)
            {

                precotiz.Texts = ID_COT.Text;
                registrar.Visible = true;
                modificar.Visible = true;
                borrar.Visible = true;
                labo.Enabled = false;
                añoes.Enabled = false;
                labo.Visible = false;
                label44.Visible = false;



                MySqlConnection CONEXION = conexion.USR;

                MySqlCommand comando = new MySqlCommand("SELECT ID_SEGUIMIENTO, CONCEPTO, UNIDAD, CANTIDAD, PU, IMPORTE,CLAVE,ALCANCES,NORMAS_CALIFICACION,TIEMPOS,REFERENCIAS FROM   conceptos_cotizaciones WHERE ID_COTIZACION = '" + ID_COT.Text + "'  AND OT = '" + FOLIOO.Texts + "' ", CONEXION);

                CONEXION.Open();
                MySqlDataReader consulta = comando.ExecuteReader();

                while (consulta.Read())
                {
                    string a0 = consulta.IsDBNull(0) ? String.Empty : consulta.GetString(0);
                    string a1 = consulta.IsDBNull(1) ? String.Empty : consulta.GetString(1);
                    string a2 = consulta.IsDBNull(2) ? String.Empty : consulta.GetString(2);
                    string a3 = consulta.IsDBNull(3) ? String.Empty : consulta.GetString(3);
                    string a4 = consulta.IsDBNull(4) ? String.Empty : consulta.GetString(4);
                    string a5 = consulta.IsDBNull(5) ? String.Empty : consulta.GetString(5);
                    string a6 = consulta.IsDBNull(6) ? String.Empty : consulta.GetString(6);
                    string a7 = consulta.IsDBNull(7) ? String.Empty : consulta.GetString(7);
                    string a8 = consulta.IsDBNull(8) ? String.Empty : consulta.GetString(8);
                    string a9 = consulta.IsDBNull(9) ? String.Empty : consulta.GetString(9);
                    string a10 = consulta.IsDBNull(10) ? String.Empty : consulta.GetString(10);

                    DGV.Rows.Add(a0, a1, a2, double.Parse(a3).ToString("N2"), double.Parse(a4).ToString("N2"), double.Parse(a5).ToString("N2"), a6, a7, a8, a9, a10);
                }
                CONEXION.Close();



                if (DGV.RowCount == 0 || decision_cambio == false)
                {
                    MySqlConnection CONEXION2 = conexion.USR;

                    MySqlCommand comando2 = new MySqlCommand("SELECT ID_SEGUIMIENTO, CONCEPTO, UNIDAD, CANTIDAD, PU, IMPORTE,CLAVE,ALCANCES,NORMAS_CALIFICACION,TIEMPOS,REFERENCIAS FROM   conceptos_cotizaciones WHERE ID_COTIZACION = '" + ID_COT.Text + "'  AND OT = '' ", CONEXION2);

                    CONEXION2.Open();
                    MySqlDataReader consulta2 = comando2.ExecuteReader();

                    while (consulta2.Read())
                    {
                        string a0 = consulta2.IsDBNull(0) ? String.Empty : consulta2.GetString(0);
                        string a1 = consulta2.IsDBNull(1) ? String.Empty : consulta2.GetString(1);
                        string a2 = consulta2.IsDBNull(2) ? String.Empty : consulta2.GetString(2);
                        string a3 = consulta2.IsDBNull(3) ? String.Empty : consulta2.GetString(3);
                        string a4 = consulta2.IsDBNull(4) ? String.Empty : consulta2.GetString(4);
                        string a5 = consulta2.IsDBNull(5) ? String.Empty : consulta2.GetString(5);
                        string a6 = consulta2.IsDBNull(6) ? String.Empty : consulta2.GetString(6);
                        string a7 = consulta2.IsDBNull(7) ? String.Empty : consulta2.GetString(7);
                        string a8 = consulta2.IsDBNull(8) ? String.Empty : consulta2.GetString(8);
                        string a9 = consulta2.IsDBNull(9) ? String.Empty : consulta2.GetString(9);
                        string a10 = consulta2.IsDBNull(10) ? String.Empty : consulta2.GetString(10);

                        DGV.Rows.Add(a0, a1, a2, a3, a4, a5, a6, a7, a8, a9, a10);
                    }
                    CONEXION2.Close();
                }

                if (ESTADO.Texts.Contains("REVISADO") == true || ESTADO.Texts == "CANCELADA")
                {
                    ESTADO.Enabled = true;
                    pictureBox2.Enabled = true;
                    modificar.Enabled = true;
                    borrar.Enabled = false;
                    DGV.ReadOnly = true;
                    AG1.Enabled = false;

                }



            }
            else if (decision_cambio == false)
            {
                consecutivo();
                this.FormBorderStyle = FormBorderStyle.None;
                cargar_ot_segunsucursal();
                registrar.Visible = true;
                modificar.Visible = false;
                borrar.Visible = false;
                registrar.Enabled = true;
                FECHA.Text = DateTime.Today.ToString("yyyy-MM-dd");


                if (RECIB.Texts == string.Empty) { RECIB.Texts = SESION.name; }


                if (ESTADO.Texts == "SIN OT")
                {
                    ESTADO.Texts = "PENDIENTE";
                }



            }

            if (copia == true)
            {
                if (desde_pnd == true)
                {
                    TABLA.DataSource = conexion_servicios_eventuales.Consultageneral("SELECT * FROM ordenes_trabajo_pnd WHERE YEAR(FECHA) = '" + DateTime.Today.ToString("yyyy") + "'");


                }
                else
                {
                    TABLA.DataSource = conexion_servicios_eventuales.Consultageneral("SELECT * FROM ordenes_trabajo WHERE YEAR(FECHA) = '" + DateTime.Today.ToString("yyyy") + "'");


                }

                int conteo_orden = TABLA.RowCount + 1;
                string conteo = "LC-" + proceso + "." + DateTime.Today.ToString("yy") + "-" + Convert.ToString(conteo_orden);
                FOLIOO.Texts = conteo;
                registrar.Visible = true;
                modificar.Visible = false;
                borrar.Visible = false;

            }

            LISTADO();

            if (ESTADO.Texts == "")
            {
                ESTADO.Texts = "PENDIENTE";
            }


            if (ESTADO.Texts == "SIN OT")
            {
                ot_por_cot = true;
            }

            monto_recabado = 0;

            foreach (DataGridViewRow row in DGV.Rows)
            {
                monto_recabado = monto_recabado + double.Parse(row.Cells[5].Value.ToString());




            }
            monto_recabado_IVA = monto_recabado + (monto_recabado * 0.16);

            imp.Text = monto_recabado.ToString("f2");
            iva.Text = (monto_recabado * 0.16).ToString("f2");
            pagar.Text = monto_recabado_IVA.ToString("f2");

            consulta_dirigidosainforme();

            if (SESION.puesto == "COBRANZA")
            {
                altoButton1.Visible = true;

            }
            altoButton1.Left = DGV.Left;


            if (PROGRAMA.Texts == string.Empty) { PROGRAMA.Texts = SESION.name; }

            if (SESION.usuario == "ARAMOSM" || SESION.usuario == "ARAMIREZB" || SESION.usuario == "TJIMENEZ" || SESION.usuario == "RROJAS")
            {
                borrar.Enabled = true;



            }
            else
            {
                borrar.Enabled = false;

            }


            ///////VALIDA LA SUMATORIA
            ///







        }

        private void consulta_dirigidosainforme()
        {
            if (desde_pnd == true)
            {
                MySqlConnection CONEXION = conexion_servicios_eventuales.USR;

                MySqlCommand comando = new MySqlCommand("SELECT INFORMES_DIRIGIDOS FROM  ordenes_trabajo_pnd WHERE ID_ORDEN='" + FOLIOO.Texts + "'", CONEXION);

                CONEXION.Open();
                MySqlDataReader consulta = comando.ExecuteReader();
                while (consulta.Read())
                {


                    informes_dirigidos.Texts = consulta.IsDBNull(0) ? String.Empty : consulta.GetString(0);
                }
                CONEXION.Close();
            }
            else
            {
                MySqlConnection CONEXION = conexion_servicios_eventuales.USR;

                MySqlCommand comando = new MySqlCommand("SELECT INFORMES_DIRIGIDOS FROM  ordenes_trabajo WHERE ID_ORDEN='" + FOLIOO.Texts + "'", CONEXION);

                CONEXION.Open();
                MySqlDataReader consulta = comando.ExecuteReader();
                while (consulta.Read())
                {


                    informes_dirigidos.Texts = consulta.IsDBNull(0) ? String.Empty : consulta.GetString(0);
                }
                CONEXION.Close();
            }


        }
        public void revisar_importes()
        {
            monto_recabado = 0;

            foreach (DataGridViewRow row in DGV.Rows)
            {
                monto_recabado = monto_recabado + double.Parse(row.Cells[5].Value.ToString());




            }
            monto_recabado_IVA = monto_recabado + (monto_recabado * 0.16);

            imp.Text = monto_recabado.ToString("f2");
            iva.Text = (monto_recabado * 0.16).ToString("f2");
            pagar.Text = monto_recabado_IVA.ToString("f2");
        }
        int nconsecutivo = 0;
        private void consecutivo()
        {
            nconsecutivo = 0;
            MySqlConnection CONEXION = conexion.USR;

            MySqlCommand comando = new MySqlCommand("SELECT COUNT(*) FROM  seguimiento_cotizacion WHERE (PROCESO = '0'  AND YEAR(FECHA_REGISTRO) = '" + DateTime.Today.ToString("yyyy") + "') AND (LATERAL = 'NO APLICA' )", CONEXION);


            CONEXION.Open();
            MySqlDataReader consulta = comando.ExecuteReader();

            while (consulta.Read())
            {
                string a0 = consulta.IsDBNull(0) ? String.Empty : consulta.GetString(0);
                nconsecutivo = int.Parse(a0);
            }
            nconsecutivo = nconsecutivo + 1;
            CONEXION.Close();


            ID_COT.Text = "CSE" + "." + "0" + "." + DateTime.Today.ToString("yy") + "." + nconsecutivo.ToString() + "-A";
            id_cotizacion = ID_COT.Text;
            ya = true;
        }
        private void regi()
        {
            revisar_importes();



            if (desde_pnd == true)
            {
                conexion_servicios_eventuales.registrar("INSERT INTO ordenes_trabajo_pnd(ID_ORDEN, ID_COTIZACION, NOMBRE, EMPRESA, DOMICILIO_FISCAL, CODIGO_POSTAL, TELEFONO, RFC, CORREO, OBRA, DOMICILIO_OBRA, DIRIGIRSE, FECHA, HORA, RECIBIO, AUTORIZA, PROGRAMA, GRADO_PESONAL, PERSONAL_ASIGNADO, NORMAS_AMERICANAS, CONDICIONES_CORRECTAS, ALCANCE, NORMA_CALIFICACION, INFORME_PROPIEDAD, BAJO_RESGUARDO, MINUTARIO, CLAVE_OBRA, NO_MUESTRA, OBSERVACIONES, COMENTARIOS_CLIENTE, USUARIO, MODIFICACIONES, ESTATUS, OTROS, SERVICIO, TIEMPO_ENTREGA,FECHA_AG, TIPO_SERVICIO,SONDEO,INFORME,SOL_COBRANZA, COBRO_PENDIENTE, COBRO_IVA,TIPO_OT,INFORMES_DIRIGIDOS,USUARIO_CREA) VALUES ('" + FOLIOO.Texts + "' , '" + id_cotizacion + "' , '" + NOMBRE.Texts + "' , '" + EMPRESA.Texts + "', 'NO APLICA', '" + CODIGO_POSTAL.Texts + "', '" + TELEFONO.Texts + "', '" + RFC.Texts + "', '" + EMAIL.Texts + "', '" + NOMBRE_OBRA.Texts + "', '" + DOMICILIO.Texts + "', '" + DIRIGIDO.Texts + "', '" + FECHA.Text + "', '" + HORA.Texts + "', '" + RECIB.Texts + "', '" + AUTORIZA.Texts + "', '" + PROGRAMA.Texts + "', '" + GRADO.Texts + "', '" + NOMBRE_TEC.Texts + "', '" + NAM.Texts + "', '" + CON.Texts + "', 'NO APLICA', 'NO APLICA', '" + PROPIEDAD.Texts + "', '" + RESGUARDO.Texts + "', 'NO APLICA', '" + clave_obra.Texts + "', 'NO APLICA', '" + OBSERVACIONES.Texts + "', '" + CLIENTE_COMENTATRIOS.Texts + "', '" + SESION.usuario + "', '1', 'PENDIENTE', 'OTROS', 'NO APLICA', 'NO APLICA', '" + DateTime.Today.ToString("yyyy-MM-dd") + "', '" + servicios + "','NO APLICA','NO APLICA','SIN ASIGNAR', '" + monto_recabado + "', '" + monto_recabado_IVA + "','" + tipo_ot.Texts + "', '" + informes_dirigidos.Texts + "','" + SESION.name + "' )");
                Random random = new Random();
                int aut = random.Next(0, 5966);
                string FOl = "AG-" + DateTime.Now.ToString("yy.dd") + SESION.proceso + "-" + aut.ToString();
                random = new Random();
                int idr = random.Next(0, 5966);

            }
            else
            {
                conexion_servicios_eventuales.registrar("INSERT INTO ordenes_trabajo(ID_ORDEN, ID_COTIZACION, NOMBRE, EMPRESA, DOMICILIO_FISCAL, CODIGO_POSTAL, TELEFONO, RFC, CORREO, OBRA, DOMICILIO_OBRA, DIRIGIRSE, FECHA, HORA, RECIBIO, AUTORIZA, PROGRAMA, GRADO_PESONAL, PERSONAL_ASIGNADO, NORMAS_AMERICANAS, CONDICIONES_CORRECTAS, ALCANCE, NORMA_CALIFICACION, INFORME_PROPIEDAD, BAJO_RESGUARDO, MINUTARIO, CLAVE_OBRA, NO_MUESTRA, OBSERVACIONES, COMENTARIOS_CLIENTE, USUARIO, MODIFICACIONES, ESTATUS, OTROS, SERVICIO, TIEMPO_ENTREGA,FECHA_AG, TIPO_SERVICIO,SONDEO,INFORME,SOL_COBRANZA, COBRO_PENDIENTE, COBRO_IVA,TIPO_OT,INFORMES_DIRIGIDOS,USUARIO_CREA,SUCURSAL) VALUES ('" + FOLIOO.Texts + "' , '" + id_cotizacion + "' , '" + NOMBRE.Texts + "' , '" + EMPRESA.Texts + "', 'NO APLICA', '" + CODIGO_POSTAL.Texts + "', '" + TELEFONO.Texts + "', '" + RFC.Texts + "', '" + EMAIL.Texts + "', '" + NOMBRE_OBRA.Texts + "', '" + DOMICILIO.Texts + "', '" + DIRIGIDO.Texts + "', '" + FECHA.Text + "', '" + HORA.Texts + "', '" + RECIB.Texts + "', '" + AUTORIZA.Texts + "', '" + PROGRAMA.Texts + "', '" + GRADO.Texts + "', '" + NOMBRE_TEC.Texts + "', '" + NAM.Texts + "', '" + CON.Texts + "', 'NO APLICA', 'NO APLICA', '" + PROPIEDAD.Texts + "', '" + RESGUARDO.Texts + "', 'NO APLICA', '" + clave_obra.Texts + "', 'NO APLICA', '" + OBSERVACIONES.Texts + "', '" + CLIENTE_COMENTATRIOS.Texts + "', '" + SESION.usuario + "', '1', 'PENDIENTE', 'OTROS', 'NO APLICA', 'NO APLICA', '" + DateTime.Today.ToString("yyyy-MM-dd") + "', '" + servicios + "','NO APLICA','NO APLICA','SIN ASIGNAR', '" + monto_recabado + "', '" + monto_recabado_IVA + "','" + tipo_ot.Texts + "', '" + informes_dirigidos.Texts + "', '" + SESION.name + "', '" + SESION.CONF_SUC + "' )");
                Random random = new Random();
                int aut = random.Next(0, 5966);
                string FOl = "AG-" + DateTime.Now.ToString("yy.dd") + SESION.proceso + "-" + aut.ToString();
                random = new Random();
                int idr = random.Next(0, 5966);


            }


            DOCUMENTO();
            // DOCUMENTO2();


            /*
            FSD.CSE2 = new FORMULARIO_COTIZACIONES();
            var cortas = FSD.CSE2;
            AddOwnedForm(cortas);
            cortas.decision_consulta = true;


            cortas.correo_a = SESION.correo;
            cortas.telefono_a = SESION.telefono;
            cortas.preparacion = SESION.preparacion;
            cortas.puesto = SESION.puesto;
            cortas.nombre_completo = SESION.name;
            cortas.referencia.Text = ID_COT.Text;

            cortas.altoButton1.Visible = false;
            cortas.TopLevel = false;
            cortas.pictureBox10.Visible = false;
            cortas.SOLOPARAAUTOGENERAR = true;

            cortas.Show();
            cortas.generadesdefuerapdf();

            */





            if (desde_pnd == true)
            {
                MENU_PRICIPAL_ERP.cortapn.seguimiento_pasar();

                this.Close();
            }
            else
            {
                DNS.MN_REV.seguimiento_pasar();
                this.Close();
            }
        }


        /// NO ESTA LIGADA ESTA FUNCIÓN SOLO ES MUESTRA DE APOYO




        //REGISTRA NUEVA ORDEN

        private void MostrarVentana()
        {
            CARGANDO_ARCHIVO VentanaMensaje = new CARGANDO_ARCHIVO();
            VentanaMensaje.ShowDialog();
        }
        private void ligar_conceptos()
        {
            foreach (DataGridViewRow row in DGV.Rows)
            {
                conexion.USR.Open();//Se abre la conexión para evitar un error común
                String Query = "UPDATE conceptos_cotizaciones SET COBRANZA= 'NO ASIGNADA',OT= '" + FOLIOO.Texts + "'   WHERE ID_SEGUIMIENTO  = '" + row.Cells[0].Value.ToString() + "';";
                MySqlCommand comando = new MySqlCommand(Query, conexion.USR);//Se interpreta el comando del query
                comando.ExecuteNonQuery();//Se ejecuta el comando del query
                conexion.USR.Close();//Se cierra la conexión
            }
        }
        string dide = "0";
        string cadena_muestra = "";
        private void registra_app_concreto()
        {

            var alert = new SweetAlert();
            alert.Caption = "ATENCIÓN";
            alert.Message = "¿Deseas registrar en App de concreto?";
            alert.MsgButton = SweetAlertButton.YesNo;
            alert.OkText = "Si";
            alert.CancelText = "No";
            SweetAlertResult result = alert.ShowDialog();
            if (result == SweetAlertResult.YES)
            {
                foreach (DataGridViewRow row in DGV.Rows)
                {
                    string CONCEPT = row.Cells[1].Value.ToString();

                    cadena_muestra = row.Cells[10].Value.ToString();
                    remota_concreto.registrar("INSERT INTO cont_y_ver_de_concreto_f (fecha_de_colado,clave_de_obra,cliente,obra,con_atencion_a,usuario,fecha_de_registro) values ('" + FECHA.Text + "', '" + clave_obra.Texts + "' , '" + EMPRESA.Texts + "' , '" + NOMBRE_OBRA.Texts + "','" + informes_dirigidos.Texts + "','" + NOMBRE_TEC.Texts + "','" + DateTime.Today.ToString("yyyy-MM-dd") + "' ) ");
                    TABLA.DataSource = remota_concreto.Consultageneral("SELECT id FROM cont_y_ver_de_concreto_f WHERE clave_de_obra = '" + clave_obra.Texts + "' AND fecha_de_colado = '" + FECHA.Text + "' ");
                    if (TABLA.RowCount != 0)
                    {
                        dide = TABLA.Rows[0].Cells[0].Value.ToString();

                        remota_concreto.registrar("INSERT INTO concreto_fresco (clave_de_obra,id_seguimiento,fecha_de_colado,usuario,no_de_muestra) values ('" + clave_obra.Texts + "', '" + dide + "' , '" + FECHA.Text + "' , '" + NOMBRE_TEC.Texts + "', '" + cadena_muestra + "') ");

                    }


                    if (CONCEPT.Contains("VISITA PARA CONTROL DE COMPACTACIÓN") == true)
                    {
                        cadena_muestra = row.Cells[10].Value.ToString();

                        CONEXION_TERRACERIAS.registrar("INSERT INTO compactaciones (CLAVE_OBRA,SONDEO,FECHA_INFORME,FECHA_PRUEBA,OT,REALIZO, OBSERVACION) values ('" + clave_obra.Texts + "', '" + cadena_muestra + "' , '" + DateTime.Today.ToString("yyyy-MM-dd") + "' , '" + FECHA.Text + "','" + FOLIOO.Texts + "','" + NOMBRE_TEC.Texts + "', 'NO CONSULTADA') ");











                    }


                }






            }








            string tipos_serv = "";
            foreach (DataGridViewRow row in DGV.Rows)
            {

                string texto = row.Cells[1].Value.ToString();
                string cant = row.Cells[3].Value.ToString();
                int posicion = texto.IndexOf(".");
                if (posicion == -1)
                    posicion = texto.Length;
                string substring = row.Cells[1].Value.ToString().Substring(0, posicion);
                tipos_serv = substring;

                remota_concreto.registrar("INSERT INTO notificaciones_eventuales_campo (usuario, fecha, hora, tipo_servicio,  cliente, 	atencion, lugar,  observaciones, estatus, ot) VALUES ('" + NOMBRE_TEC.Texts + "' ,'" + FECHA.Text + "' , '" + HORA.Texts + "', '" + tipos_serv + "', '" + EMPRESA.Texts + "','" + DIRIGIDO.Texts + "', '" + DOMICILIO.Texts + "', '" + OBSERVACIONES.Texts + "', 'NO EJECUTADO', '" + FOLIOO.Texts + "')");

            }




        }




        private void registrar_Click(object sender, EventArgs e)
        {




            if (ESTADO.Texts == string.Empty)
            {
                MENSAJE_GENERAL MN = new MENSAJE_GENERAL();
                MN.BOTON.Text = "El estado de tu OT esta vacío";
                MN.BOTON.Inactive1 = System.Drawing.Color.Red;
                MN.BOTON.Inactive2 = System.Drawing.Color.Red;
                MN.ShowDialog();
            }
            else
            {


                ;

                if (DGV.RowCount == 0)
                {
                    MENSAJE_GENERAL MN = new MENSAJE_GENERAL();
                    MN.BOTON.Text = "No tienes ningun concepto ligado a esta órden";
                    MN.BOTON.Inactive1 = System.Drawing.Color.Red;
                    MN.BOTON.Inactive2 = System.Drawing.Color.Red;
                    MN.ShowDialog();

                }
                else
                {


                    if (FOLIOO.Texts != string.Empty)
                    {
                        var alert = new SweetAlert();
                        alert.Caption = "ATENCIÓN";
                        alert.Message = "¿Deseas registrar esta OT " + tipo_ot.Texts + " ahora?";
                        alert.MsgButton = SweetAlertButton.YesNo;
                        alert.OkText = "Yes.";
                        alert.CancelText = "No!";
                        SweetAlertResult result = alert.ShowDialog();
                        if (result == SweetAlertResult.OK)
                        {

                            cargar_ot_segunsucursal();

                            registra_clave_nx();


                            rastrea_servicios();

                            ligar_conceptos();
                            OP.registrar("INSERT INTO procesos_cotidianos (USUARIO,FECHA,TIEMPO,ACCION,IP_ADREES,AREA,OBRA) VALUES ('" + SESION.usuario + "',  '" + DateTime.Today.ToString("yyyy-MM-dd") + "', '" + DateTime.Now.ToString("HH:mm:ss") + "' , '" + "Registro orden de trabajo: " + FOLIOO.Texts + " ', '" + SESION.IP + "','" + SESION.puesto + "', '" + SESION.obra + "' )");

                            regi();



                        }
                        else
                        {

                        }
                    }

                    else
                    {
                        MessageBox.Show("NO TIENES CAPTURADO EL FOLIO DEL DOCUMENTO", "NOTIFICACIÓN DE OPERACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }




            if (File.Exists(ruta_abrir_archivo_OT))
            {
                System.Diagnostics.Process.Start(ruta_abrir_archivo_OT);

            }
            else
            {

            }

        }
        bool existe_cot = false;
        public bool ya = false;
        public void registra_nuevos()
        {


            TABLA.DataSource = conexion.Consultageneral("SELECT ID_SEGUIMIENTO FROM   seguimiento_cotizacion WHERE ID_COTIZACION = '" + ID_COT.Text + "'");

            if (TABLA.RowCount == 0)
            {

                if (decision_cambio == false)
                {
                    conexion.registrar("INSERT INTO seguimiento_cotizacion (ID_COTIZACION,FECHA_REGISTRO,nombre, EMPRESA, OBRA, TELEFONO, CORREO, MONTO_COTIZADO,MODIFICACIONES,COTIZADOR,ESTADO,OBSERVACIONES,PROCESO,FSD,FSL,LATERAL) values ('" + ID_COT.Text + "', '" + DateTime.Today.ToString("yyyy-MM-dd H:mm:ss") + "', '" + DIRIGIDO.Texts + "' , '" + EMPRESA.Texts + "','" + NOMBRE_OBRA.Texts + "', '" + TELEFONO.Texts + "','" + EMAIL.Texts + "','" + double.Parse(pagar.Text) + "', '0', 'ERP','ADJUDICADA','NINGUNA','0', '1.0', '1.0','NO APLICA' ) ");

                }
                else
                {
                    conexion.registrar("INSERT INTO seguimiento_cotizacion (ID_COTIZACION,FECHA_REGISTRO,nombre, EMPRESA, OBRA, TELEFONO, CORREO, MONTO_COTIZADO,MODIFICACIONES,COTIZADOR,ESTADO,OBSERVACIONES,PROCESO,FSD,FSL,LATERAL,NOMBRE_COTIZADOR) values ('" + ID_COT.Text + "', '" + DateTime.Today.ToString("yyyy-MM-dd H:mm:ss") + "', '" + DIRIGIDO.Texts + "' , '" + EMPRESA.Texts + "','" + NOMBRE_OBRA.Texts + "', '" + TELEFONO.Texts + "','" + EMAIL.Texts + "','" + double.Parse(pagar.Text) + "', '0', 'ERP','ADJUDICADA','NINGUNA','0', '1.0', '1.0','APLICA', '" + RECIB.Texts + "' ) ");

                }

            }
            else
            {

            }







            conexion.USR.Open();
            String Query_eliminar = "DELETE FROM conceptos_cotizaciones WHERE  ID_COTIZACION = '" + ID_COT.Text + "' AND OT='" + FOLIOO.Texts + "'";
            MySqlCommand comando1 = new MySqlCommand(Query_eliminar, conexion.USR);
            comando1.ExecuteNonQuery();
            conexion.USR.Close();


            foreach (DataGridViewRow rowi in DGV.Rows)
            {

                conexion.registrar("INSERT INTO conceptos_cotizaciones (ID_COTIZACION,CLAVE,CONCEPTO,UNIDAD, CANTIDAD, PU, IMPORTE, OBSERVACIONES, FECHA_INGRESO,USUARIOS_INGRESO,FSD,FSL,COBRANZA,OT,ALCANCES,NORMAS_CALIFICACION,TIEMPOS,REFERENCIAS) values ('" + ID_COT.Text + "', '" + rowi.Cells["clave"].Value.ToString() + "' , '" + rowi.Cells["CONCEPTOS"].Value.ToString() + "' , '" + rowi.Cells["UNIDAD"].Value.ToString() + "','" + rowi.Cells["CANTIDAD"].Value.ToString() + "', '" + double.Parse(rowi.Cells["PU"].Value.ToString()) + "', '" + double.Parse(rowi.Cells["IMPORTE"].Value.ToString()) + "', '" + FOLIOO.Texts + "','" + DateTime.Today.ToString("yyyy-MM-dd") + "','ERP','1.0', '1.0', 'NO ASIGNADA','" + FOLIOO.Texts + "', '" + rowi.Cells["ALCANCES"].Value.ToString() + "', '" + rowi.Cells["NORMAS"].Value.ToString() + "', '" + rowi.Cells["ENTREGAS"].Value.ToString() + "', '" + rowi.Cells["REFERENCIA"].Value.ToString() + "' ) ");

            }



            DGV.Rows.Clear();



            MySqlConnection CONEXION = conexion.USR;

            MySqlCommand comando = new MySqlCommand("SELECT ID_SEGUIMIENTO, CONCEPTO, UNIDAD, CANTIDAD, PU, IMPORTE,CLAVE,ALCANCES,NORMAS_CALIFICACION,TIEMPOS,REFERENCIAS FROM   conceptos_cotizaciones WHERE ID_COTIZACION = '" + ID_COT.Text + "'  AND OT = '" + FOLIOO.Texts + "' ", CONEXION);

            CONEXION.Open();
            MySqlDataReader consulta = comando.ExecuteReader();

            while (consulta.Read())
            {
                string a0 = consulta.IsDBNull(0) ? String.Empty : consulta.GetString(0);
                string a1 = consulta.IsDBNull(1) ? String.Empty : consulta.GetString(1);
                string a2 = consulta.IsDBNull(2) ? String.Empty : consulta.GetString(2);
                string a3 = consulta.IsDBNull(3) ? String.Empty : consulta.GetString(3);
                string a4 = consulta.IsDBNull(4) ? String.Empty : consulta.GetString(4);
                string a5 = consulta.IsDBNull(5) ? String.Empty : consulta.GetString(5);
                string a6 = consulta.IsDBNull(6) ? String.Empty : consulta.GetString(6);
                string a7 = consulta.IsDBNull(7) ? String.Empty : consulta.GetString(7);
                string a8 = consulta.IsDBNull(8) ? String.Empty : consulta.GetString(8);
                string a9 = consulta.IsDBNull(9) ? String.Empty : consulta.GetString(9);
                string a10 = consulta.IsDBNull(10) ? String.Empty : consulta.GetString(10);

                DGV.Rows.Add(a0, a1, a2, a3, a4, a5, a6, a7, a8, a9, a10);
            }
            CONEXION.Close();



        }
        private void registra_clave_nx()
        {
            TABLA.DataSource = conexion_servicios_eventuales.Consultageneral("SELECT * FROM listado_obras WHERE CLAVE_OBRA = '" + clave_obra.Texts + "'");
            if (TABLA.RowCount == 0)
            {
                conexion_servicios_eventuales.registrar("INSERT INTO listado_obras (CLAVE_OBRA,TIPO_SERVICIO,NOMBRE_OBRA,EMPRESA,CON_ATENCION,DIRIGIRSE_A,OBSERVACIONES,FECHA,CORREO_ELECTRONICO, ALIAS,EMISION_LAB) VALUES ('" + clave_obra.Texts + "', 'EVENTUAL' ,'" + NOMBRE_OBRA.Texts + "' , '" + EMPRESA.Texts + "', '" + NOMBRE.Texts + "','" + informes_dirigidos.Texts + "' , 'NO USUALES', '" + DateTime.Today.ToString("yyyy-MM-dd") + "','" + EMAIL.Texts + "',  '" + NOMBRE_OBRA.Texts + "', 'AUTORIZADO')");
                MENSAJE_GENERAL MN = new MENSAJE_GENERAL();
                MN.BOTON.Text = "Se ha registrado automaticamente una clave de obra de manera automática";
                MN.ShowDialog();



            }


        }







        //////////////////////////////////////////////////////////////////////////
        ///CREACIÓN DE PDF Y EXCEL ---------------------------------------------------------------------------------
        public string plantilla;
        public string plantilla2;

        private void descarga_documentos_pnd()
        {
            MySqlConnection CONEXION = conexion_calidad.USR;

            MySqlCommand comando = new MySqlCommand("SELECT DOCUMENTO FROM  formatos WHERE CODIGO = 'OT_PND'  ORDER BY ID_SEGUIMIENTO ASC", CONEXION);

            CONEXION.Open();
            MySqlDataReader consulta = comando.ExecuteReader();

            string carpeta = @"C:\TEMP ERP";

            if (Directory.Exists(carpeta))
            {

            }
            else
            {
                Directory.CreateDirectory(carpeta);

            }
            while (consulta.Read())
            {

                byte[] archivoBytes = (byte[])consulta["DOCUMENTO"];
                System.IO.MemoryStream pdfStream = new System.IO.MemoryStream(archivoBytes);


                File.WriteAllBytes(@"C:\TEMP ERP\OT_PND.xlsx", archivoBytes);
                // System.Diagnostics.Process.Start(@"C:\TEMP ERP\04-TER-CALMTRELL.xlsx");

            }
            CONEXION.Close();

        }

        private void descarga_encuesta()
        {
            MySqlConnection CONEXION = conexion_calidad.USR;

            MySqlCommand comando = new MySqlCommand("SELECT DOCUMENTO FROM  formatos WHERE CODIGO = 'ENC_SEE'  ORDER BY ID_SEGUIMIENTO ASC", CONEXION);

            CONEXION.Open();
            MySqlDataReader consulta = comando.ExecuteReader();

            string carpeta = @"C:\TEMP ERP";

            if (Directory.Exists(carpeta))
            {

            }
            else
            {
                Directory.CreateDirectory(carpeta);

            }



            while (consulta.Read())
            {

                byte[] archivoBytes = (byte[])consulta["DOCUMENTO"];
                System.IO.MemoryStream pdfStream = new System.IO.MemoryStream(archivoBytes);


                File.WriteAllBytes(@"C:\TEMP ERP\ENC_SEE.pdf", archivoBytes);
                // System.Diagnostics.Process.Start(@"C:\TEMP ERP\04-TER-CALMTRELL.xlsx");

            }
            CONEXION.Close();

        }

        private void descarga_documentos_see()
        {


            if (FOLIOO.Texts.Contains("LT"))
            {
                MySqlConnection CONEXION = conexion_calidad.USR;

                MySqlCommand comando = new MySqlCommand("SELECT DOCUMENTO FROM  formatos WHERE CODIGO = 'OT_TZ'  ORDER BY ID_SEGUIMIENTO ASC", CONEXION);

                CONEXION.Open();
                MySqlDataReader consulta = comando.ExecuteReader();

                string carpeta = @"C:\TEMP ERP";

                if (Directory.Exists(carpeta))
                {

                }
                else
                {
                    Directory.CreateDirectory(carpeta);

                }
                while (consulta.Read())
                {

                    byte[] archivoBytes = (byte[])consulta["DOCUMENTO"];
                    System.IO.MemoryStream pdfStream = new System.IO.MemoryStream(archivoBytes);


                    File.WriteAllBytes(@"C:\TEMP ERP\OT_SEE.xlsx", archivoBytes);
                    // System.Diagnostics.Process.Start(@"C:\TEMP ERP\04-TER-CALMTRELL.xlsx");

                }
                CONEXION.Close();

            }
            else if (FOLIOO.Texts.Contains("LP"))
            {
                MySqlConnection CONEXION = conexion_calidad.USR;

                MySqlCommand comando = new MySqlCommand("SELECT DOCUMENTO FROM  formatos WHERE CODIGO = 'OT_SL'  ORDER BY ID_SEGUIMIENTO ASC", CONEXION);

                CONEXION.Open();
                MySqlDataReader consulta = comando.ExecuteReader();

                string carpeta = @"C:\TEMP ERP";

                if (Directory.Exists(carpeta))
                {

                }
                else
                {
                    Directory.CreateDirectory(carpeta);

                }
                while (consulta.Read())
                {

                    byte[] archivoBytes = (byte[])consulta["DOCUMENTO"];
                    System.IO.MemoryStream pdfStream = new System.IO.MemoryStream(archivoBytes);


                    File.WriteAllBytes(@"C:\TEMP ERP\OT_SEE.xlsx", archivoBytes);
                    // System.Diagnostics.Process.Start(@"C:\TEMP ERP\04-TER-CALMTRELL.xlsx");

                }
                CONEXION.Close();

            }
            else if (FOLIOO.Texts.Contains("LM-"))
            {
                MySqlConnection CONEXION = conexion_calidad.USR;

                MySqlCommand comando = new MySqlCommand("SELECT DOCUMENTO FROM  formatos WHERE CODIGO = 'OT_LM'  ORDER BY ID_SEGUIMIENTO ASC", CONEXION);

                CONEXION.Open();
                MySqlDataReader consulta = comando.ExecuteReader();

                string carpeta = @"C:\TEMP ERP";

                if (Directory.Exists(carpeta))
                {

                }
                else
                {
                    Directory.CreateDirectory(carpeta);

                }
                while (consulta.Read())
                {

                    byte[] archivoBytes = (byte[])consulta["DOCUMENTO"];
                    System.IO.MemoryStream pdfStream = new System.IO.MemoryStream(archivoBytes);


                    File.WriteAllBytes(@"C:\TEMP ERP\OT_SEE.xlsx", archivoBytes);
                    // System.Diagnostics.Process.Start(@"C:\TEMP ERP\04-TER-CALMTRELL.xlsx");

                }
                CONEXION.Close();

            }
            else if (FOLIOO.Texts.Contains("LMT"))
            {

                MySqlConnection CONEXION = conexion_calidad.USR;

                MySqlCommand comando = new MySqlCommand("SELECT DOCUMENTO FROM  formatos WHERE CODIGO = 'OT_LAMT'  ORDER BY ID_SEGUIMIENTO ASC", CONEXION);

                CONEXION.Open();
                MySqlDataReader consulta = comando.ExecuteReader();

                string carpeta = @"C:\TEMP ERP";

                if (Directory.Exists(carpeta))
                {

                }
                else
                {
                    Directory.CreateDirectory(carpeta);

                }
                while (consulta.Read())
                {

                    byte[] archivoBytes = (byte[])consulta["DOCUMENTO"];
                    System.IO.MemoryStream pdfStream = new System.IO.MemoryStream(archivoBytes);


                    File.WriteAllBytes(@"C:\TEMP ERP\OT_SEE.xlsx", archivoBytes);
                    // System.Diagnostics.Process.Start(@"C:\TEMP ERP\04-TER-CALMTRELL.xlsx");

                }
                CONEXION.Close();

            }
            else if (FOLIOO.Texts.Contains("LL"))
            {
                MySqlConnection CONEXION = conexion_calidad.USR;

                MySqlCommand comando = new MySqlCommand("SELECT DOCUMENTO FROM  formatos WHERE CODIGO = 'OT_LL'  ORDER BY ID_SEGUIMIENTO ASC", CONEXION);

                CONEXION.Open();
                MySqlDataReader consulta = comando.ExecuteReader();

                string carpeta = @"C:\TEMP ERP";

                if (Directory.Exists(carpeta))
                {

                }
                else
                {
                    Directory.CreateDirectory(carpeta);

                }
                while (consulta.Read())
                {

                    byte[] archivoBytes = (byte[])consulta["DOCUMENTO"];
                    System.IO.MemoryStream pdfStream = new System.IO.MemoryStream(archivoBytes);


                    File.WriteAllBytes(@"C:\TEMP ERP\OT_SEE.xlsx", archivoBytes);
                    // System.Diagnostics.Process.Start(@"C:\TEMP ERP\04-TER-CALMTRELL.xlsx");

                }
                CONEXION.Close();

            }
            else if (FOLIOO.Texts.Contains("LH"))
            {
                MySqlConnection CONEXION = conexion_calidad.USR;

                MySqlCommand comando = new MySqlCommand("SELECT DOCUMENTO FROM  formatos WHERE CODIGO = 'OT_LH'  ORDER BY ID_SEGUIMIENTO ASC", CONEXION);

                CONEXION.Open();
                MySqlDataReader consulta = comando.ExecuteReader();

                string carpeta = @"C:\TEMP ERP";

                if (Directory.Exists(carpeta))
                {

                }
                else
                {
                    Directory.CreateDirectory(carpeta);

                }
                while (consulta.Read())
                {

                    byte[] archivoBytes = (byte[])consulta["DOCUMENTO"];
                    System.IO.MemoryStream pdfStream = new System.IO.MemoryStream(archivoBytes);


                    File.WriteAllBytes(@"C:\TEMP ERP\OT_SEE.xlsx", archivoBytes);
                    // System.Diagnostics.Process.Start(@"C:\TEMP ERP\04-TER-CALMTRELL.xlsx");

                }
                CONEXION.Close();

            }
            else
            {
                MySqlConnection CONEXION = conexion_calidad.USR;

                MySqlCommand comando = new MySqlCommand("SELECT DOCUMENTO FROM  formatos WHERE CODIGO = 'OT_SEE'  ORDER BY ID_SEGUIMIENTO ASC", CONEXION);

                CONEXION.Open();
                MySqlDataReader consulta = comando.ExecuteReader();

                string carpeta = @"C:\TEMP ERP";

                if (Directory.Exists(carpeta))
                {

                }
                else
                {
                    Directory.CreateDirectory(carpeta);

                }
                while (consulta.Read())
                {

                    byte[] archivoBytes = (byte[])consulta["DOCUMENTO"];
                    System.IO.MemoryStream pdfStream = new System.IO.MemoryStream(archivoBytes);


                    File.WriteAllBytes(@"C:\TEMP ERP\OT_SEE.xlsx", archivoBytes);
                    // System.Diagnostics.Process.Start(@"C:\TEMP ERP\04-TER-CALMTRELL.xlsx");

                }
                CONEXION.Close();



            }









        }

        public void DOCUMENTOAUTO()
        {
            folio_ot = FOLIOO.Texts;
            descarga_documentos_pnd();
            descarga_documentos_see();



            // Ruta inicial en la unidad de red
            string carpeta_asignada = SESION.CON_RUT + @"\LIEP-03 OFERTAS\" + DateTime.Today.ToString("yyyy") + @"\02 REVISIÓN DE SOLICITUDES\ORDENES ERP1\";

            // Carpeta de Documentos del usuario
            string documentosUsuario = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            // Carpeta de Documentos del usuario porque solo se autogenera sin afectar los demas
            string ruta3 = Path.Combine(documentosUsuario, "ORDEN DE TRABAJO - " + FOLIOO.Texts + ".pdf");



            string ruta = @"C:\TEMP ERP\" + FOLIOO.Texts + ".xlsx";
            string ruta2 = @"C:\TEMP ERP\" + FOLIOO.Texts + "TEMP" + ".pdf";

            string pl = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            ruta_abrir_archivo_OT = ruta3;                                                                                                                                                       //   string ruta3 = @"A:\FORMATOS\SERVICIOS_EVENTUALES\EVENTUALES\" + FOLIO.Text + ".pdf";




            if (desde_pnd == true)
            {
                plantilla = @"C:\TEMP ERP\OT_PND.xlsx";
            }
            else
            {
                plantilla = @"C:\TEMP ERP\OT_SEE.xlsx";

            }





            SLDocument reporte = new SLDocument(plantilla);
            reporte.SelectWorksheet("Hoja1");
            reporte.SetCellValue("B4", FOLIOO.Texts);
            reporte.SetCellValue("H4", id_cotizacion);
            reporte.SetCellValue("C8", NOMBRE.Texts);
            reporte.SetCellValue("K8", EMPRESA.Texts);

            reporte.SetCellValue("C9", TELEFONO.Texts);
            reporte.SetCellValue("K9", EMAIL.Texts);

            reporte.SetCellValue("C13", NOMBRE_OBRA.Texts);
            reporte.SetCellValue("M13", informes_dirigidos.Texts);
            reporte.SetCellValue("C14", DOMICILIO.Texts);
            reporte.SetCellValue("C15", DIRIGIDO.Texts);

            reporte.SetCellValue("K15", FECHA.Value.ToString("yyyy-MM-dd"));


            reporte.SetCellValue("N15", HORA.Texts); //  = TIEMPO
            reporte.SetCellValue("C16", RECIB.Texts);
            reporte.SetCellValue("L16", AUTORIZA.Texts);
            reporte.SetCellValue("C17", PROGRAMA.Texts);
            reporte.SetCellValue("L17", GRADO.Texts + " " + NOMBRE_TEC.Texts);
            reporte.SetCellValue("B29", OBSERVACIONES.Texts);

            reporte.SetCellValue("J21", NAM.Texts);
            reporte.SetCellValue("J22", CON.Texts);


            // TABLA DE CHECKLIST

            /*  if (bunifuCheckbox33.Checked == true) { reporte.SetCellValue("H36", "X"); }
           if (bunifuCheckbox22.Checked == true) { reporte.SetCellValue("H37", "X"); }*/





            reporte.SetCellValue("C23", PROPIEDAD.Texts);
            reporte.SetCellValue("L23", RESGUARDO.Texts);
            reporte.SetCellValue("L24", "VARIOS 2026");
            reporte.SetCellValue("P23", clave_obra.Texts);


            reporte.SetCellValue("A39", OBSERVACIONES.Texts);


            int tyn = 33;

            SLStyle ax = reporte.CreateStyle();
            ax.Alignment.WrapText = true;



            ax.Border.BottomBorder.BorderStyle = BorderStyleValues.Thin;
            ax.Border.BottomBorder.Color = System.Drawing.Color.FromArgb(225, 225, 225);
            ax.Border.TopBorder.BorderStyle = BorderStyleValues.Thin;
            ax.Border.TopBorder.Color = System.Drawing.Color.FromArgb(225, 225, 225);
            ax.Alignment.Vertical = VerticalAlignmentValues.Center;

            foreach (DataGridViewRow row in DGV.Rows)
            {


                string texto = row.Cells[1].Value.ToString();
                string cant = row.Cells[3].Value.ToString();

                string alcance = row.Cells[7].Value.ToString();
                string norma = row.Cells[8].Value.ToString();
                string tiempo = row.Cells[9].Value.ToString();
                string items = row.Cells[10].Value.ToString();


                int posicion = texto.IndexOf(".");
                if (posicion == -1)
                    posicion = texto.Length;
                string substring = row.Cells[1].Value.ToString().Substring(0, posicion);
                string nm = substring;

                string concepto_completo = "";
                string ACED = "-";

                TABLA.DataSource = conexion.Consultageneral("SELECT ACREDITADO FROM servicios_eventuales WHERE clave ='" + row.Cells[6].Value.ToString() + "'");

                if (TABLA.RowCount != 0)
                {
                    ACED = TABLA.Rows[0].Cells[0].Value.ToString();

                }
                else
                {
                    concepto_completo = "";
                }







                reporte.SetCellValue(tyn, 1, double.Parse(cant));
                reporte.SetCellValue(tyn, 2, nm);
                reporte.SetCellValue(tyn, 9, alcance);
                reporte.SetCellValue(tyn, 12, norma);
                //  reporte.SetCellValue(tyn, 14, ACED);
                reporte.SetCellValue(tyn, 15, tiempo);
                reporte.SetCellValue(tyn, 17, items);

                tyn = tyn + 1;
            }





            reporte.SaveAs(ruta);




            Excel.Application myexcelApplication = new Excel.Application();
            if (myexcelApplication != null)
            {
                Excel.Workbook myexcelWorkbook = myexcelApplication.Workbooks.Add(ruta);




                myexcelApplication.ActiveWorkbook.ExportAsFixedFormat(Excel.XlFixedFormatType.xlTypePDF, ruta3, OpenAfterPublish: false);

                myexcelWorkbook.Close(false, ruta);
                myexcelApplication.Quit();


            }

            MENSAJE_GENERAL MN = new MENSAJE_GENERAL();
            MN.BOTON.Text = "¡ BUEN TRABAJO! ÓRDEN DE TRABAJO GENERADA EN PDF";
            MN.ShowDialog();


            this.Close();
        }


        private void DOCUMENTO()
        {
            folio_ot = FOLIOO.Texts;
            descarga_documentos_pnd();
            descarga_documentos_see();



            string ruta3 = "";
            // Ruta inicial en la unidad de red
            string carpeta_asignada = SESION.CON_RUT + @"\LIEP-03 OFERTAS\" + DateTime.Today.ToString("yyyy") + @"\02 REVISIÓN DE SOLICITUDES\ORDENES ERP1\";

            // Carpeta de Documentos del usuario
            string documentosUsuario = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);


            // Ruta final donde se guardará el documento
            string rutaalterna = Path.Combine(documentosUsuario, "ORDEN DE TRABAJO - " + FOLIOO.Texts + ".pdf");

            if (Directory.Exists(carpeta_asignada))
            {
                ruta3 = SESION.CON_RUT + @"\LIEP-03 OFERTAS\" + DateTime.Today.ToString("yyyy") + @"\02 REVISIÓN DE SOLICITUDES\ORDENES ERP1\ORDEN DE TRABAJO - " + FOLIOO.Texts + ".pdf"; // HORA.Texts + ":" + MINUTOS.Texts

            }
            else
            {
                ruta3 = rutaalterna;

            }

            string ruta = @"C:\TEMP ERP\" + FOLIOO.Texts + ".xlsx";
            string ruta2 = @"C:\TEMP ERP\" + FOLIOO.Texts + "TEMP" + ".pdf";

            string pl = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            ruta_abrir_archivo_OT = ruta3;                                                                                                                                                       //   string ruta3 = @"A:\FORMATOS\SERVICIOS_EVENTUALES\EVENTUALES\" + FOLIO.Text + ".pdf";




            if (desde_pnd == true)
            {
                plantilla = @"C:\TEMP ERP\OT_PND.xlsx";
            }
            else
            {
                plantilla = @"C:\TEMP ERP\OT_SEE.xlsx";

            }





            SLDocument reporte = new SLDocument(plantilla);
            reporte.SelectWorksheet("Hoja1");
            reporte.SetCellValue("B4", FOLIOO.Texts);
            reporte.SetCellValue("H4", id_cotizacion);
            reporte.SetCellValue("C8", NOMBRE.Texts);
            reporte.SetCellValue("K8", EMPRESA.Texts);

            reporte.SetCellValue("C9", TELEFONO.Texts);
            reporte.SetCellValue("K9", EMAIL.Texts);

            reporte.SetCellValue("C13", NOMBRE_OBRA.Texts);
            reporte.SetCellValue("M13", informes_dirigidos.Texts);
            reporte.SetCellValue("C14", DOMICILIO.Texts);
            reporte.SetCellValue("C15", DIRIGIDO.Texts);
            DateTime fes = DateTime.Parse(FECHA.Text);
            reporte.SetCellValue("K15", fes.ToString("yyyy-MM-dd"));


            reporte.SetCellValue("N15", HORA.Texts); //  = TIEMPO
            reporte.SetCellValue("C16", RECIB.Texts);
            reporte.SetCellValue("L16", AUTORIZA.Texts);
            reporte.SetCellValue("C17", PROGRAMA.Texts);
            reporte.SetCellValue("L17", GRADO.Texts + " " + NOMBRE_TEC.Texts);
            reporte.SetCellValue("B29", OBSERVACIONES.Texts);

            reporte.SetCellValue("J21", NAM.Texts);
            reporte.SetCellValue("J22", CON.Texts);


            // TABLA DE CHECKLIST

            /*  if (bunifuCheckbox33.Checked == true) { reporte.SetCellValue("H36", "X"); }
           if (bunifuCheckbox22.Checked == true) { reporte.SetCellValue("H37", "X"); }*/



            reporte.SetCellValue("C23", PROPIEDAD.Texts);
            reporte.SetCellValue("L23", RESGUARDO.Texts);
            reporte.SetCellValue("L24", "VARIOS 2026");
            reporte.SetCellValue("P23", clave_obra.Texts);


            reporte.SetCellValue("A39", OBSERVACIONES.Texts);


            int tyn = 33;

            SLStyle ax = reporte.CreateStyle();
            ax.Alignment.WrapText = true;



            ax.Border.BottomBorder.BorderStyle = BorderStyleValues.Thin;
            ax.Border.BottomBorder.Color = System.Drawing.Color.FromArgb(225, 225, 225);
            ax.Border.TopBorder.BorderStyle = BorderStyleValues.Thin;
            ax.Border.TopBorder.Color = System.Drawing.Color.FromArgb(225, 225, 225);
            ax.Alignment.Vertical = VerticalAlignmentValues.Center;

            foreach (DataGridViewRow row in DGV.Rows)
            {


                string texto = row.Cells[1].Value.ToString();
                string cant = row.Cells[3].Value.ToString();

                string alcance = row.Cells[7].Value.ToString();
                string norma = row.Cells[8].Value.ToString();
                string tiempo = row.Cells[9].Value.ToString();
                string items = row.Cells[10].Value.ToString();


                int posicion = texto.IndexOf(".");
                if (posicion == -1)
                    posicion = texto.Length;
                string substring = row.Cells[1].Value.ToString().Substring(0, posicion);
                string nm = substring;

                string concepto_completo = "";
                string ACED = "-";

                TABLA.DataSource = conexion.Consultageneral("SELECT ACREDITADO FROM servicios_eventuales WHERE clave ='" + row.Cells[6].Value.ToString() + "'");

                if (TABLA.RowCount != 0)
                {
                    ACED = TABLA.Rows[0].Cells[0].Value.ToString();

                }
                else
                {
                    concepto_completo = "";
                }







                reporte.SetCellValue(tyn, 1, double.Parse(cant));
                reporte.SetCellValue(tyn, 2, nm);
                reporte.SetCellValue(tyn, 9, alcance);
                reporte.SetCellValue(tyn, 12, norma);
                //  reporte.SetCellValue(tyn, 14, ACED);
                reporte.SetCellValue(tyn, 15, tiempo);
                reporte.SetCellValue(tyn, 17, items);

                tyn = tyn + 1;
            }





            reporte.SaveAs(ruta);




            Excel.Application myexcelApplication = new Excel.Application();
            if (myexcelApplication != null)
            {
                Excel.Workbook myexcelWorkbook = myexcelApplication.Workbooks.Add(ruta);




                myexcelApplication.ActiveWorkbook.ExportAsFixedFormat(Excel.XlFixedFormatType.xlTypePDF, ruta3, OpenAfterPublish: false);

                myexcelWorkbook.Close(false, ruta);
                myexcelApplication.Quit();


            }
            var alert = new SweetAlert();
            alert.Caption = "ATENCIÓN";
            alert.Message = "¿¿Deseas agregar una encuesta de satisfacción?";
            alert.MsgButton = SweetAlertButton.YesNo;
            alert.OkText = "Yes.";
            alert.CancelText = "No!";
            SweetAlertResult result = alert.ShowDialog();
            if (result == SweetAlertResult.OK)

            {
                descarga_encuesta();
                encuesta_doc();

            }
        }

        private void DOCUMENTO2()
        {

            descarga_documentos_pnd();
            descarga_documentos_see();

            string ruta3 = "";

            string carpeta_asignada = SESION.CON_RUT + @"\LIEP-03 OFERTAS\" + DateTime.Today.ToString("yyyy") + @"\02 REVISIÓN DE SOLICITUDES\ORDENES ERP EXCEL1\";


            // Carpeta de Documentos del usuario
            string documentosUsuario = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);


            // Ruta final donde se guardará el documento
            string rutaalterna = Path.Combine(documentosUsuario, "ORDEN DE TRABAJO - " + FOLIOO.Texts + ".xlsx");

            if (Directory.Exists(carpeta_asignada))
            {
                // string documentos = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                ruta3 = SESION.CON_RUT + @"\LIEP-03 OFERTAS\" + DateTime.Today.ToString("yyyy") + @"\02 REVISIÓN DE SOLICITUDES\ORDENES ERP EXCEL1\ORDEN DE TRABAJO - " + FOLIOO.Texts + ".xlsx"; // HORA.Texts + ":" + MINUTOS.Texts

            }
            else
            {
                ruta3 = rutaalterna;

            }

            //   string ruta3 = @"A:\FORMATOS\SERVICIOS_EVENTUALES\EVENTUALES\" + FOLIO.Text + ".pdf";









            if (bolita == true)
            {
                if (desde_pnd == true)
                {
                    plantilla = @"C:\TEMP ERP\OT_PND.xlsx";
                }
                else
                {
                    plantilla = @"C:\TEMP ERP\OT_SEE.xlsx";

                }


            }
            else
            {

                if (desde_pnd == true)
                {
                    plantilla = @"C:\TEMP ERP\OT_PND.xlsx";
                }
                else
                {
                    plantilla = @"C:\TEMP ERP\OT_SEE.xlsx";

                }


            }



            SLDocument reporte = new SLDocument(plantilla);
            reporte.SelectWorksheet("Hoja1");
            reporte.SetCellValue("B4", FOLIOO.Texts);
            reporte.SetCellValue("H4", id_cotizacion);
            reporte.SetCellValue("C8", NOMBRE.Texts);
            reporte.SetCellValue("K8", EMPRESA.Texts);

            reporte.SetCellValue("C9", TELEFONO.Texts);
            reporte.SetCellValue("K9", EMAIL.Texts);

            reporte.SetCellValue("C13", NOMBRE_OBRA.Texts);
            reporte.SetCellValue("M13", informes_dirigidos.Texts);
            reporte.SetCellValue("C14", DOMICILIO.Texts);
            reporte.SetCellValue("C15", DIRIGIDO.Texts);
            DateTime fes = DateTime.Parse(FECHA.Text);
            reporte.SetCellValue("K15", fes.ToString("yyyy-MM-dd"));


            reporte.SetCellValue("N15", HORA.Texts); //  = TIEMPO
            reporte.SetCellValue("C16", RECIB.Texts);
            reporte.SetCellValue("L16", AUTORIZA.Texts);
            reporte.SetCellValue("C17", PROGRAMA.Texts);
            reporte.SetCellValue("L17", GRADO.Texts + " " + NOMBRE_TEC.Texts);
            reporte.SetCellValue("B29", OBSERVACIONES.Texts);

            reporte.SetCellValue("J21", NAM.Texts);
            reporte.SetCellValue("J22", CON.Texts);


            // TABLA DE CHECKLIST

            /*  if (bunifuCheckbox33.Checked == true) { reporte.SetCellValue("H36", "X"); }
           if (bunifuCheckbox22.Checked == true) { reporte.SetCellValue("H37", "X"); }*/



            reporte.SetCellValue("C23", PROPIEDAD.Texts);
            reporte.SetCellValue("L23", RESGUARDO.Texts);
            reporte.SetCellValue("L24", "VARIOS 2026");
            reporte.SetCellValue("P23", clave_obra.Texts);


            reporte.SetCellValue("A39", CLIENTE_COMENTATRIOS.Texts);


            int tyn = 33;

            SLStyle ax = reporte.CreateStyle();
            ax.Alignment.WrapText = true;



            ax.Border.BottomBorder.BorderStyle = BorderStyleValues.Thin;
            ax.Border.BottomBorder.Color = System.Drawing.Color.FromArgb(225, 225, 225);
            ax.Border.TopBorder.BorderStyle = BorderStyleValues.Thin;
            ax.Border.TopBorder.Color = System.Drawing.Color.FromArgb(225, 225, 225);
            ax.Alignment.Vertical = VerticalAlignmentValues.Center;

            foreach (DataGridViewRow row in DGV.Rows)
            {


                string texto = row.Cells[1].Value.ToString();
                string cant = row.Cells[3].Value.ToString();

                string alcance = row.Cells[7].Value.ToString();
                string norma = row.Cells[8].Value.ToString();
                string tiempo = row.Cells[9].Value.ToString();
                string items = row.Cells[10].Value.ToString();


                int posicion = texto.IndexOf(".");
                if (posicion == -1)
                    posicion = texto.Length;
                string substring = row.Cells[1].Value.ToString().Substring(0, posicion);
                string nm = substring;

                string concepto_completo = "";
                string ACED = "-";

                TABLA.DataSource = conexion.Consultageneral("SELECT ACREDITADO FROM servicios_eventuales WHERE clave ='" + row.Cells[6].Value.ToString() + "'");

                if (TABLA.RowCount != 0)
                {
                    ACED = TABLA.Rows[0].Cells[0].Value.ToString();

                }
                else
                {
                    concepto_completo = "";
                }







                reporte.SetCellValue(tyn, 1, double.Parse(cant));
                reporte.SetCellValue(tyn, 2, nm);
                reporte.SetCellValue(tyn, 9, alcance);
                reporte.SetCellValue(tyn, 12, norma);
                // reporte.SetCellValue(tyn, 14, ACED);
                reporte.SetCellValue(tyn, 15, tiempo);
                reporte.SetCellValue(tyn, 17, items);

                tyn = tyn + 1;
            }








            reporte.SaveAs(ruta3);



        }


        string ruta_abrir_archivo = "";

        string ruta_abrir_archivo_OT = "";












        private void GENERA_COTIZACIONPDF()
        {





        }
        public void encuesta_doc()
        {
            // Combine dos o más tipos diferentes de archivos en uno usando C#
            using (Merger merger = new Merger(ruta_abrir_archivo_OT))
            {

                merger.Join(@"C:\TEMP ERP\ENC_SEE.pdf");

                string pl = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                string DOC_ENC = Path.Combine(pl, folio_ot + " CON ENCUESTA DE SATISFACCIÓN" + ".pdf");

                merger.Save(DOC_ENC);

                if (File.Exists(DOC_ENC))
                {
                    System.Diagnostics.Process.Start(DOC_ENC);
                }

            }


        }
        private void pictureBox9_Click(object sender, EventArgs e)
        {


            DOCUMENTO();
            DOCUMENTO2();


            MENSAJE_GENERAL MN = new MENSAJE_GENERAL();
            MN.BOTON.Text = "¡ BUEN TRABAJO! ÓRDEN DE TRABAJO GENERADA EN PDF";
            MN.ShowDialog();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {



            DOCUMENTO2();

            MENSAJE_GENERAL MN = new MENSAJE_GENERAL();
            MN.BOTON.Text = "¡ BUEN TRABAJO! ÓRDEN DE TRABAJO GENERADA EN EXCEL";
            MN.ShowDialog();
        }



        /////////////////////////////////////////////////////////////////
        ///


        //ELIMINAR Y MODIFICAR ÓRDEN
        private void borrar_Click(object sender, EventArgs e)
        {

            if (FOLIOO.Texts != string.Empty)
            {
                if (desde_pnd == true)
                {
                    //borrado
                    conexion_servicios_eventuales.registrar("DELETE FROM ordenes_trabajo_pnd WHERE ID_ORDEN  = '" + FOLIOO.Texts + "' ");

                    //actualizacion
                    conexion_servicios_eventuales.actualizar("DELETE FROM servicios WHERE ID_ORDEN  = '" + FOLIOO.Texts + "'");
                    consulta_registros_nube();
                    MessageBox.Show("OT ELIMINADA CORRECTAMENTE", "NOTIFICACIÓN DE OPERACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DNS.MN_REV.seguimiento_pasar();
                    this.Close();
                }
                else
                {   //borrado
                    conexion_servicios_eventuales.registrar("DELETE FROM ordenes_trabajo WHERE ID_ORDEN  = '" + FOLIOO.Texts + "' ");

                    //actualizacion
                    conexion_servicios_eventuales.actualizar("DELETE FROM servicios WHERE ID_ORDEN  = '" + FOLIOO.Texts + "'");
                    consulta_registros_nube();

                    OP.registrar("INSERT INTO procesos_cotidianos (USUARIO,FECHA,TIEMPO,ACCION,IP_ADREES,AREA,OBRA) VALUES ('" + SESION.usuario + "',  '" + DateTime.Today.ToString("yyyy-MM-dd") + "', '" + DateTime.Now.ToString("HH:mm:ss") + "' , '" + "Elimino orden de trabajo: " + FOLIOO.Texts + " ', '" + SESION.IP + "','" + SESION.puesto + "', '" + SESION.obra + "' )");


                    MessageBox.Show("OT ELIMINADA CORRECTAMENTE", "NOTIFICACIÓN DE OPERACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DNS.MN_REV.seguimiento_pasar();
                    this.Close();

                }


            }

            else
            {
                MessageBox.Show("NO TIENES CAPTURADO EL FOLIO DEL DOCUMENTO", "NOTIFICACIÓN DE OPERACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }


        public void cambia_itemas()
        {


            ESTADO.Items.Clear();
            ESTADO.Texts = "PENDIENTE CON MD";
            ESTADO.Items.Add("PENDIENTE CON MD");
            ESTADO.Items.Add("REVISADO CON MD");
            ESTADO.Items.Add("CANCELADA");


        }

        private void md()
        {
            revisar_importes();



            if (ot_por_cot == true)
            {
                rastrea_servicios();
            }
            if (desde_pnd == true)
            {


                conexion_servicios_eventuales.actualizar("UPDATE ordenes_trabajo_pnd SET NOMBRE = '" + NOMBRE.Texts + "', EMPRESA = '" + EMPRESA.Texts + "', DOMICILIO_FISCAL = 'NO APLICA', CODIGO_POSTAL = '" + CODIGO_POSTAL.Texts + "', TELEFONO = '" + TELEFONO.Texts + "', RFC = '" + RFC.Texts + "', CORREO = '" + EMAIL.Texts + "', OBRA = '" + NOMBRE_OBRA.Texts + "', DOMICILIO_OBRA = '" + DOMICILIO.Texts + "', DIRIGIRSE = '" + DIRIGIDO.Texts + "', FECHA = '" + FECHA.Text + "', HORA = '" + HORA.Texts + "', RECIBIO = '" + RECIB.Texts + "', AUTORIZA = '" + AUTORIZA.Texts + "', PROGRAMA = '" + PROGRAMA.Texts + "', GRADO_PESONAL = '" + GRADO.Texts + "', PERSONAL_ASIGNADO = '" + NOMBRE_TEC.Texts + "', NORMAS_AMERICANAS = 'NO APLICA', CONDICIONES_CORRECTAS = '" + CON.Texts + "', ALCANCE = 'NO APLICA', NORMA_CALIFICACION = 'NO APLICA', INFORME_PROPIEDAD = '" + PROPIEDAD.Texts + "', BAJO_RESGUARDO = '" + RESGUARDO.Texts + "', MINUTARIO = 'NO APLICA', CLAVE_OBRA = '" + clave_obra.Texts + "', NO_MUESTRA = 'NO APLICA', OBSERVACIONES = '" + OBSERVACIONES.Texts + "', COMENTARIOS_CLIENTE = '" + CLIENTE_COMENTATRIOS.Texts + "', OTROS = 'OTROS', SERVICIO = 'NO APLICA', TIEMPO_ENTREGA = 'NO APLICA', ESTATUS = '" + ESTADO.Texts + "', TIPO_SERVICIO = '" + servicios + "',SONDEO = 'NO APLICA',INFORME = 'NO APLICA', COBRO_PENDIENTE = '" + monto_recabado + "', COBRO_IVA = '" + monto_recabado_IVA + "', TIPO_OT = '" + tipo_ot.Texts + "',  INFORMES_DIRIGIDOS = '" + informes_dirigidos.Texts + "',ID_COTIZACION = '" + id_cotizacion + "' WHERE ID_ORDEN  = '" + FOLIOO.Texts + "' ");

            }
            else
            {
                conexion_servicios_eventuales.actualizar("UPDATE ordenes_trabajo SET NOMBRE = '" + NOMBRE.Texts + "', EMPRESA = '" + EMPRESA.Texts + "', DOMICILIO_FISCAL = 'NO APLICA', CODIGO_POSTAL = '" + CODIGO_POSTAL.Texts + "', TELEFONO = '" + TELEFONO.Texts + "', RFC = '" + RFC.Texts + "', CORREO = '" + EMAIL.Texts + "', OBRA = '" + NOMBRE_OBRA.Texts + "', DOMICILIO_OBRA = '" + DOMICILIO.Texts + "', DIRIGIRSE = '" + DIRIGIDO.Texts + "', FECHA = '" + FECHA.Text + "', HORA = '" + HORA.Texts + "', RECIBIO = '" + RECIB.Texts + "', AUTORIZA = '" + AUTORIZA.Texts + "', PROGRAMA = '" + PROGRAMA.Texts + "', GRADO_PESONAL = '" + GRADO.Texts + "', PERSONAL_ASIGNADO = '" + NOMBRE_TEC.Texts + "', NORMAS_AMERICANAS = 'NO APLICA', CONDICIONES_CORRECTAS = '" + CON.Texts + "', ALCANCE = 'NO APLICA', NORMA_CALIFICACION = 'NO APLICA', INFORME_PROPIEDAD = '" + PROPIEDAD.Texts + "', BAJO_RESGUARDO = '" + RESGUARDO.Texts + "', MINUTARIO = 'NO APLICA', CLAVE_OBRA = '" + clave_obra.Texts + "', NO_MUESTRA = 'NO APLICA', OBSERVACIONES = '" + OBSERVACIONES.Texts + "', COMENTARIOS_CLIENTE = '" + CLIENTE_COMENTATRIOS.Texts + "', OTROS = 'OTROS', SERVICIO = 'NO APLICA', TIEMPO_ENTREGA = 'NO APLICA', ESTATUS = '" + ESTADO.Texts + "', TIPO_SERVICIO = '" + servicios + "',SONDEO = 'NO APLICA',INFORME = 'NO APLICA', COBRO_PENDIENTE = '" + monto_recabado + "', COBRO_IVA = '" + monto_recabado_IVA + "', TIPO_OT = '" + tipo_ot.Texts + "',INFORMES_DIRIGIDOS = '" + informes_dirigidos.Texts + "', ID_COTIZACION = '" + id_cotizacion + "' WHERE ID_ORDEN  = '" + FOLIOO.Texts + "' ");

            }

            //actualizacion
            if (desde_pnd == false)
            {

                estado();
                DOCUMENTO();
                DOCUMENTO2();




                DNS.MN_REV.seguimiento_pasar();
                this.Close();

            }
            else
            {
                estado();
                DOCUMENTO();
                DOCUMENTO2();








                MENU_PRICIPAL_ERP.cortapn.seguimiento_pasar();
                this.Close();


            }

















        }



        private void consulta_registros_nube()
        {

            // FUNCION  DISPONIBLE, AQUÍ PUEDES RELAIZAR UNA CONSULTA O ACCIÓN A LA NUBE SI ES NECESARIO CUANDO SE MODIFIQUE UNA OT


        }


        public void estado()
        {

            if (ESTADO.Texts.Contains("REVISADO"))
            {
                if (estatss == "VERIFICAR")
                {



                }
                else
                {


                    string var2 = ID_COT.Text;

                    conexion.USR.Open();//Se abre la conexión para evitar un error común

                    String QueryES = "UPDATE conceptos_cotizaciones SET ESTATUS_OP= 'REALIZADA'  WHERE ID_COTIZACION  = '" + var2 + "';";
                    MySqlCommand comandoES = new MySqlCommand(QueryES, conexion.USR);//Se interpreta el comando del query
                    comandoES.ExecuteNonQuery();//Se ejecuta el comando del query

                    conexion.USR.Close();//Se cierra la conexión


                    conexion_cobranza.registrar("INSERT INTO ot_cobranza(ID_COT,ID_OT,CLAVE_OBRA,EMPRESA,OBRA,ESTATUS,FECHA) VALUES ( '" + ID_COT.Text + "','" + FOLIOO.Texts + "','" + clave_obra.Texts + "','" + EMPRESA.Texts + "','" + NOMBRE_OBRA.Texts + "','" + ESTADO.Texts + "','" + DateTime.Today.ToString("yyyy-MM-dd") + "')");

                    conexion_servicios_eventuales.USR.Open();//Se abre la conexión para evitar un error común

                    if (ESTADO.Texts.Contains("REVISADO CON MD"))
                    {
                        if (desde_pnd == true)
                        {
                            String Query = "UPDATE ordenes_trabajo_pnd SET SOL_COBRANZA= '" + "SIN ASIGNAR" + "' , ESTATUS= '" + "REVISADO CON MD EL " + DateTime.Today.ToString("yyyy-MM-dd") + " POR " + SESION.name + "' WHERE ID_ORDEN  = '" + FOLIOO.Texts + "';";
                            MySqlCommand comando = new MySqlCommand(Query, conexion_servicios_eventuales.USR);//Se interpreta el comando del query
                            comando.ExecuteNonQuery();//Se ejecuta el comando del query
                            conexion_servicios_eventuales.USR.Close();//Se cierra la conexión

                        }
                        else
                        {
                            String Query = "UPDATE ordenes_trabajo SET SOL_COBRANZA= '" + "SIN ASIGNAR" + "' , ESTATUS= '" + "REVISADO CON MD EL " + DateTime.Today.ToString("yyyy-MM-dd") + " POR " + SESION.name + "' WHERE ID_ORDEN  = '" + FOLIOO.Texts + "';";
                            MySqlCommand comando = new MySqlCommand(Query, conexion_servicios_eventuales.USR);//Se interpreta el comando del query
                            comando.ExecuteNonQuery();//Se ejecuta el comando del query
                            conexion_servicios_eventuales.USR.Close();//Se cierra la conexión


                        }
                    }
                    else
                    {
                        if (desde_pnd == true)
                        {
                            String Query = "UPDATE ordenes_trabajo_pnd SET SOL_COBRANZA= '" + "SIN ASIGNAR" + "' , ESTATUS= '" + "REVISADO EL " + DateTime.Today.ToString("yyyy-MM-dd") + " POR " + SESION.name + "' WHERE ID_ORDEN  = '" + FOLIOO.Texts + "';";
                            MySqlCommand comando = new MySqlCommand(Query, conexion_servicios_eventuales.USR);//Se interpreta el comando del query
                            comando.ExecuteNonQuery();//Se ejecuta el comando del query
                            conexion_servicios_eventuales.USR.Close();//Se cierra la conexión

                        }
                        else
                        {
                            String Query = "UPDATE ordenes_trabajo SET SOL_COBRANZA= '" + "SIN ASIGNAR" + "' , ESTATUS= '" + "REVISADO EL " + DateTime.Today.ToString("yyyy-MM-dd") + " POR " + SESION.name + "' WHERE ID_ORDEN  = '" + FOLIOO.Texts + "';";
                            MySqlCommand comando = new MySqlCommand(Query, conexion_servicios_eventuales.USR);//Se interpreta el comando del query
                            comando.ExecuteNonQuery();//Se ejecuta el comando del query
                            conexion_servicios_eventuales.USR.Close();//Se cierra la conexión


                        }
                    }

                }
            }

            else if (ESTADO.Texts.Contains("CANCELADA"))
            {
                consulta_registros_nube();




            }

            else
            {

            }


        }

        private void modificar_Click(object sender, EventArgs e)
        {
            var alert = new SweetAlert();
            alert.Caption = "ATENCIÓN";
            alert.Message = "¿¿Deseas modificar esta OT ahora??";
            alert.MsgButton = SweetAlertButton.YesNo;
            alert.OkText = "Yes.";
            alert.CancelText = "No!";
            SweetAlertResult result = alert.ShowDialog();
            if (result == SweetAlertResult.OK)
            {

                if (ESTADO.Texts == string.Empty)
                {
                    MENSAJE_GENERAL MN = new MENSAJE_GENERAL();
                    MN.BOTON.Text = "El estado de tu OT esta vacío";
                    MN.BOTON.Inactive1 = System.Drawing.Color.Red;
                    MN.BOTON.Inactive2 = System.Drawing.Color.Red;
                    MN.ShowDialog();
                }
                else
                {


                    if (FOLIOO.Texts != string.Empty)
                    {

                        bool hayNegativos = false;

                        foreach (DataGridViewRow fila in DGV.Rows)
                        {
                            if (fila.Cells["Importe"].Value != null)
                            {
                                decimal importe = Convert.ToDecimal(fila.Cells["Importe"].Value);

                                if (importe <= 0)
                                {
                                    hayNegativos = true;
                                    break;
                                }
                            }
                        }

                        if (hayNegativos)
                        {
                            DialogResult resultado = MessageBox.Show(
                                "Tienes números negativos o en cero en tu tabla, ¿Deseas continuar?",
                                "Advertencia",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Warning);

                            if (resultado == DialogResult.No)
                            {
                                return;
                            }
                            else
                            {
                                registra_clave_nx();

                                ligar_conceptos();
                                registra_nuevos();
                                OP.registrar("INSERT INTO procesos_cotidianos (USUARIO,FECHA,TIEMPO,ACCION,IP_ADREES,AREA,OBRA) VALUES ('" + SESION.usuario + "',  '" + DateTime.Today.ToString("yyyy-MM-dd") + "', '" + DateTime.Now.ToString("HH:mm:ss") + "' , '" + "Modifico orden de trabajo: " + FOLIOO.Texts + " ', '" + SESION.IP + "','" + SESION.puesto + "', '" + SESION.obra + "' )");

                                md();
                            }
                        }
                        else
                        {
                            registra_clave_nx();

                            ligar_conceptos();
                            registra_nuevos();
                            OP.registrar("INSERT INTO procesos_cotidianos (USUARIO,FECHA,TIEMPO,ACCION,IP_ADREES,AREA,OBRA) VALUES ('" + SESION.usuario + "',  '" + DateTime.Today.ToString("yyyy-MM-dd") + "', '" + DateTime.Now.ToString("HH:mm:ss") + "' , '" + "Modifico orden de trabajo: " + FOLIOO.Texts + " ', '" + SESION.IP + "','" + SESION.puesto + "', '" + SESION.obra + "' )");

                            md();

                        }





                      






                    }

                    else
                    {
                        MessageBox.Show("NO TIENES CAPTURADO EL FOLIO DEL DOCUMENTO", "NOTIFICACIÓN DE OPERACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                }
            }
            else
            {

            }




        }










        private void rjComboBox1_OnSelectedIndexChanged(object sender, EventArgs e)
        {

        }








        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }



        private void cargar_conceptos()
        {

            MySqlConnection CONEXION = conexion.USR;

            MySqlCommand comando = new MySqlCommand("SELECT ID_SEGUIMIENTO, CONCEPTO, UNIDAD, CANTIDAD, PU, IMPORTE FROM   conceptos_cotizaciones WHERE ID_COTIZACION = '" + ID_COT.Text + "' AND OT = '" + FOLIOO.Texts + "'", CONEXION);

            CONEXION.Open();
            MySqlDataReader consulta = comando.ExecuteReader();

            while (consulta.Read())
            {
                string a0 = consulta.IsDBNull(0) ? String.Empty : consulta.GetString(0);
                string a1 = consulta.IsDBNull(1) ? String.Empty : consulta.GetString(1);
                string a2 = consulta.IsDBNull(2) ? String.Empty : consulta.GetString(2);
                string a3 = consulta.IsDBNull(3) ? String.Empty : consulta.GetString(3);
                string a4 = consulta.IsDBNull(4) ? String.Empty : consulta.GetString(4);
                string a5 = consulta.IsDBNull(5) ? String.Empty : consulta.GetString(5);


                DGV.Rows.Add(a0, a1, a2, a3, a4, a5);
            }
            CONEXION.Close();


        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

            if (ESTADO.Texts == "VERIFICAR")
            {

                tooltip = new ToolTip();
                tooltip.ShowAlways = true;


                tooltip.Show(texto3, FOLIOO, FOLIOO.Left, FOLIOO.Top, int.MaxValue);


            }


        }

        private void ID_COT_Click(object sender, EventArgs e)
        {



        }

        private void label16_Click(object sender, EventArgs e)
        {
            busca_conceptos();
        }

        private void clave_obra_OnSelectedIndexChanged(object sender, EventArgs e)
        {




        }

        private void clave_obra_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {







        }
        public static CONCEPTOS_CTZ_OT mn = new CONCEPTOS_CTZ_OT();
        private void pictureBox2_Click(object sender, EventArgs e)
        {

            if (decision_cambio == true)
            {
                Form nv = new Form();
                using (mn = new CONCEPTOS_CTZ_OT())
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

                    mn.ligada = true;
                    mn.ID_COT.Text = ID_COT.Text;
                    mn.de_consulta = true;

                    if (cambiacotunavez == true)
                    {
                        mn.cambiacotunavez = true;
                    }
                    else
                    {
                        mn.cambiacotunavez = false;
                    }


                    foreach (DataGridViewRow row in DGV.Rows)
                    {

                        string a0 = "0"; string a1 = "0"; string a2 = "0"; string a3 = "0"; string a6 = "0"; string a7 = "0"; string a8 = "0"; string a9 = "0"; string a10 = "0";
                        double a4 = 0; double a5 = 0;

                        if (row.Cells[0].Value != null) { a0 = row.Cells[0].Value.ToString(); }
                        if (row.Cells[1].Value != null) { a1 = row.Cells[1].Value.ToString(); }
                        if (row.Cells[2].Value != null) { a2 = row.Cells[2].Value.ToString(); }
                        if (row.Cells[3].Value != null) { a3 = row.Cells[3].Value.ToString(); }
                        if (row.Cells[4].Value != null) { a4 = double.Parse(row.Cells[4].Value.ToString()); }
                        if (row.Cells[5].Value != null) { a5 = double.Parse(row.Cells[5].Value.ToString()); }
                        if (row.Cells[6].Value != null) { a6 = row.Cells[6].Value.ToString(); }
                        if (row.Cells[7].Value != null) { a7 = row.Cells[7].Value.ToString(); }
                        if (row.Cells[8].Value != null) { a8 = row.Cells[8].Value.ToString(); }
                        if (row.Cells[9].Value != null) { a9 = row.Cells[9].Value.ToString(); }
                        if (row.Cells[10].Value != null) { a10 = row.Cells[10].Value.ToString(); }


                        mn.DGV.Rows.Add(a0, a1, a2, a3, a4.ToString("N2"), a5.ToString("N2"), a6, a7, a8, a9, a10, "Actualizar", "Eliminar", 1);

                    }

                    if (desde_pnd == true) { mn.desde_pnd = true; }
                    mn.OT = FOLIOO.Texts;
                    mn.ShowDialog();

                    nv.Dispose();
                }
            }
            else
            {
                Form nv = new Form();
                using (mn = new CONCEPTOS_CTZ_OT())
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
                    if (ID_COT.Text == "SIN CTZN")
                    {
                        mn.ligada = false;
                    }
                    else
                    {
                        mn.ligada = true;
                        mn.ya = ya;
                        mn.ID_COT.Text = ID_COT.Text;
                    }
                    if (desde_pnd == true) { mn.desde_pnd = true; }

                    foreach (DataGridViewRow row in DGV.Rows)
                    {
                        string a0 = "0"; string a1 = "0"; string a2 = "0"; string a3 = "0"; string a6 = "0"; string a7 = "0"; string a8 = "0"; string a9 = "0"; string a10 = "0";
                        double a4 = 0; double a5 = 0;

                        if (row.Cells[0].Value != null) { a0 = row.Cells[0].Value.ToString(); }
                        if (row.Cells[1].Value != null) { a1 = row.Cells[1].Value.ToString(); }
                        if (row.Cells[2].Value != null) { a2 = row.Cells[2].Value.ToString(); }
                        if (row.Cells[3].Value != null) { a3 = row.Cells[3].Value.ToString(); }
                        if (row.Cells[4].Value != null) { a4 = double.Parse(row.Cells[4].Value.ToString()); }
                        if (row.Cells[5].Value != null) { a5 = double.Parse(row.Cells[5].Value.ToString()); }
                        if (row.Cells[6].Value != null) { a6 = row.Cells[6].Value.ToString(); }
                        if (row.Cells[7].Value != null) { a7 = row.Cells[7].Value.ToString(); }
                        if (row.Cells[8].Value != null) { a8 = row.Cells[8].Value.ToString(); }
                        if (row.Cells[9].Value != null) { a9 = row.Cells[9].Value.ToString(); }
                        if (row.Cells[10].Value != null) { a10 = row.Cells[10].Value.ToString(); }


                        mn.DGV.Rows.Add(a0, a1, a2, a3, a4.ToString("N2"), a5.ToString("N2"), a6, a7, a8, a9, a10, "Actualizar", "Eliminar", 1);

                    }
                    DateTime fe_cot = DateTime.Parse(FECHA.Text);
                    mn.fe_cot = fe_cot;
                    mn.OT = FOLIOO.Texts;
                    mn.ShowDialog();

                    nv.Dispose();
                }
            }

        }

        public void busca_datos_cot()
        {
            MySqlConnection CONEXION = conexion.USR;

            MySqlCommand comando = new MySqlCommand("SELECT * FROM   seguimiento_cotizacion WHERE ID_COTIZACION = '" + ID_COT.Text + "' AND YEAR(FECHA_REGISTRO) = '" + fe_cot.ToString("yyyy") + "' ", CONEXION);

            CONEXION.Open();
            MySqlDataReader consulta = comando.ExecuteReader();

            while (consulta.Read())
            {
                string V_ID_COTIZACION = consulta.IsDBNull(1) ? String.Empty : consulta.GetString(1);
                string V_FECHA_REGISTRO = consulta.IsDBNull(2) ? String.Empty : consulta.GetString(2);
                string V_nombre = consulta.IsDBNull(3) ? String.Empty : consulta.GetString(3);
                string V_EMPRESA = consulta.IsDBNull(4) ? String.Empty : consulta.GetString(4);
                string V_OBRA = consulta.IsDBNull(5) ? String.Empty : consulta.GetString(5);
                string V_TELEFONO = consulta.IsDBNull(6) ? String.Empty : consulta.GetString(6);
                string V_CORREO = consulta.IsDBNull(7) ? String.Empty : consulta.GetString(7);
                string V_MONTO_COTIZADO = consulta.IsDBNull(8) ? String.Empty : consulta.GetString(8);
                string V_MODIFICACIONES = consulta.IsDBNull(9) ? String.Empty : consulta.GetString(9);
                string V_COTIZADOR = consulta.IsDBNull(10) ? String.Empty : consulta.GetString(10);
                string V_ESTADO = consulta.IsDBNull(11) ? String.Empty : consulta.GetString(11);
                string V_OBSERVACIONES = consulta.IsDBNull(12) ? String.Empty : consulta.GetString(12);
                string V_PROCESO = consulta.IsDBNull(13) ? String.Empty : consulta.GetString(13);
                string V_FSD = consulta.IsDBNull(14) ? String.Empty : consulta.GetString(14);
                string V_FSL = consulta.IsDBNull(15) ? String.Empty : consulta.GetString(15);
                string V_RFC = consulta.IsDBNull(16) ? String.Empty : consulta.GetString(16);
                string V_REGIMEN = consulta.IsDBNull(17) ? String.Empty : consulta.GetString(17);
                string V_CALLE = consulta.IsDBNull(18) ? String.Empty : consulta.GetString(18);
                string V_N_EXTERIOR = consulta.IsDBNull(19) ? String.Empty : consulta.GetString(19);
                string V_N_INTERIOR = consulta.IsDBNull(20) ? String.Empty : consulta.GetString(20);
                string V_COLONIA = consulta.IsDBNull(21) ? String.Empty : consulta.GetString(21);
                string V_CP = consulta.IsDBNull(22) ? String.Empty : consulta.GetString(22);
                string V_CIUDAD_MUNICIPIO = consulta.IsDBNull(23) ? String.Empty : consulta.GetString(23);
                string V_PAIS = consulta.IsDBNull(24) ? String.Empty : consulta.GetString(24);
                string V_ENTIDAD = consulta.IsDBNull(25) ? String.Empty : consulta.GetString(25);
                string V_dom_obra = consulta.IsDBNull(25) ? String.Empty : consulta.GetString(25);


                NOMBRE.Texts = V_nombre;
                EMPRESA.Texts = V_EMPRESA;
                CODIGO_POSTAL.Texts = V_CP;
                RFC.Texts = V_RFC;
                TELEFONO.Texts = V_TELEFONO;
                EMAIL.Texts = V_CORREO;
                NOMBRE_OBRA.Texts = V_OBRA;
                DOMICILIO.Texts = V_dom_obra;






            }
            CONEXION.Close();
        }

        public void busca_conceptos2()
        {

            MySqlConnection CONEXION = conexion.USR;

            MySqlCommand comando = new MySqlCommand("SELECT ID_SEGUIMIENTO, CONCEPTO, UNIDAD, CANTIDAD, PU, IMPORTE,CLAVE,ALCANCES,NORMAS_CALIFICACION,TIEMPOS,REFERENCIAS FROM   conceptos_cotizaciones WHERE ID_COTIZACION = '" + ID_COT.Text + "'  AND OT = '' ", CONEXION);

            CONEXION.Open();
            MySqlDataReader consulta = comando.ExecuteReader();

            while (consulta.Read())
            {
                string a0 = consulta.IsDBNull(0) ? String.Empty : consulta.GetString(0);
                string a1 = consulta.IsDBNull(1) ? String.Empty : consulta.GetString(1);
                string a2 = consulta.IsDBNull(2) ? String.Empty : consulta.GetString(2);
                string a3 = consulta.IsDBNull(3) ? String.Empty : consulta.GetString(3);
                string a4 = consulta.IsDBNull(4) ? String.Empty : consulta.GetString(4);
                string a5 = consulta.IsDBNull(5) ? String.Empty : consulta.GetString(5);
                string a6 = consulta.IsDBNull(6) ? String.Empty : consulta.GetString(6);
                string a7 = consulta.IsDBNull(7) ? String.Empty : consulta.GetString(7);
                string a8 = consulta.IsDBNull(8) ? String.Empty : consulta.GetString(8);
                string a9 = consulta.IsDBNull(9) ? String.Empty : consulta.GetString(9);
                string a10 = consulta.IsDBNull(10) ? String.Empty : consulta.GetString(10);

                DGV.Rows.Add(a0, a1, a2, a3, a4, a5, a6, a7, a8, a9, a10);
            }
            CONEXION.Close();





        }
        public void busca_conceptos()
        {

            MySqlConnection CONEXION = conexion.USR;

            MySqlCommand comando = new MySqlCommand("SELECT ID_SEGUIMIENTO, CONCEPTO, UNIDAD, CANTIDAD, PU, IMPORTE,CLAVE,ALCANCES,NORMAS_CALIFICACION,TIEMPOS,REFERENCIAS FROM   conceptos_cotizaciones WHERE ID_COTIZACION = '" + ID_COT.Text + "'  AND OT = '" + FOLIOO.Texts + "' ", CONEXION);

            CONEXION.Open();
            MySqlDataReader consulta = comando.ExecuteReader();

            while (consulta.Read())
            {
                string a0 = consulta.IsDBNull(0) ? String.Empty : consulta.GetString(0);
                string a1 = consulta.IsDBNull(1) ? String.Empty : consulta.GetString(1);
                string a2 = consulta.IsDBNull(2) ? String.Empty : consulta.GetString(2);
                string a3 = consulta.IsDBNull(3) ? String.Empty : consulta.GetString(3);
                string a4 = consulta.IsDBNull(4) ? String.Empty : consulta.GetString(4);
                string a5 = consulta.IsDBNull(5) ? String.Empty : consulta.GetString(5);
                string a6 = consulta.IsDBNull(6) ? String.Empty : consulta.GetString(6);
                string a7 = consulta.IsDBNull(7) ? String.Empty : consulta.GetString(7);
                string a8 = consulta.IsDBNull(8) ? String.Empty : consulta.GetString(8);
                string a9 = consulta.IsDBNull(9) ? String.Empty : consulta.GetString(9);
                string a10 = consulta.IsDBNull(10) ? String.Empty : consulta.GetString(10);

                DGV.Rows.Add(a0, a1, a2, double.Parse(a3).ToString("N2"), double.Parse(a4).ToString("N2"), double.Parse(a5).ToString("N2"), a6, a7, a8, a9, a10);
            }
            CONEXION.Close();



            if (DGV.RowCount == 0 || decision_cambio == false)
            {
                busca_conceptos2();
            }


        }



        private void pictureBox3_Click(object sender, EventArgs e)
        {
            CARTERA_CLIENTE CT = new CARTERA_CLIENTE();
            CT.desde_fuera = true;
            CT.ShowDialog();




        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void clave_obra_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void clave_obra_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void timer2_Tick(object sender, EventArgs e)
        {


        }

        private void label22_Click(object sender, EventArgs e)
        {



        }

        private void FECHA_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                DateTime VA1 = DateTime.Parse(FECHA.Text);


                DateTime VA2 = DateTime.Parse(añoes.Texts + "-12-31");

                if (VA1 > VA2)
                {
                    MENSAJE_GENERAL mn = new MENSAJE_GENERAL();
                    mn.BOTON.Text = "La fecha que elegiste no corresponde al año que estableces en principio del registro";
                    mn.BOTON.Inactive1 = System.Drawing.Color.Red;
                    mn.BOTON.Inactive2 = System.Drawing.Color.Red;
                    mn.Show();
                    FECHA.Text = DateTime.Parse(añoes.Texts + "-01-01").ToString("yyyy-MM-dd");
                }

            }
            catch
            {

            }


        }


        //////////////////////////////////
        private void rastrea_servicios()
        {
            servicios = "";
            foreach (DataGridViewRow row in DGV.Rows)
            {
                string cadena = row.Cells[6].Value.ToString();


                if (cadena == "")
                {

                }
                else
                {



                    if (cadena == "-" || cadena == "0" || cadena == string.Empty)
                    {
                        if (servicios.Contains("OTROS "))
                        {

                        }
                        else
                        {
                            servicios = servicios + "OTROS ";
                        }
                    }


                    else
                    {
                        if (cadena.Substring(0, 2) == "GE")
                        {
                            if (servicios.Contains("GENERALES "))
                            {

                            }
                            else
                            {
                                servicios = servicios + "GENERALES ";
                            }

                        }
                        if (cadena.Substring(0, 2) == "CN")
                        {
                            if (servicios.Contains("CONCRETO "))
                            {

                            }
                            else
                            {
                                servicios = servicios + "CONCRETO ";
                            }

                        }
                        if (cadena.Substring(0, 2) == "GT")
                        {
                            if (servicios.Contains("GEOTÉCNIA "))
                            {

                            }
                            else
                            {
                                servicios = servicios + "GEOTÉCNIA ";
                            }

                        }
                        if (cadena.Substring(0, 2) == "AS")
                        {
                            if (servicios.Contains("ASFALTOS "))
                            {

                            }
                            else
                            {
                                servicios = servicios + "ASFALTOS ";
                            }

                        }
                        if (cadena.Substring(0, 2) == "AR")
                        {
                            if (servicios.Contains("ACERO "))
                            {

                            }
                            else
                            {
                                servicios = servicios + "ACERO ";
                            }

                        }
                        if (cadena.Substring(0, 2) == "PN")
                        {
                            if (servicios.Contains("PND "))
                            {

                            }
                            else
                            {
                                servicios = servicios + "PND ";
                            }

                        }
                        if (cadena.Substring(0, 2) == "PE")
                        {
                            if (servicios.Contains("ESPECIALES "))
                            {

                            }
                            else
                            {
                                servicios = servicios + "ESPECIALES ";
                            }

                        }
                        if (cadena.Substring(0, 2) == "CP")
                        {
                            if (servicios.Contains("CONCRETO POLIMÉTRICO "))
                            {

                            }
                            else
                            {
                                servicios = servicios + "CONCRETO POLIMÉTRICO ";
                            }

                        }
                        if (cadena.Substring(0, 2) == "MS")
                        {
                            if (servicios.Contains("MECÁNICA DE SUELOS "))
                            {

                            }
                            else
                            {
                                servicios = servicios + "MECÁNICA DE SUELOS ";
                            }

                        }
                        if (cadena.Substring(0, 2) == "SE")
                        {
                            if (servicios.Contains("SERVICIOS ESPECIALES "))
                            {

                            }
                            else
                            {
                                servicios = servicios + "SERVICIOS ESPECIALES ";
                            }

                        }

                    }

                }



            }


        }

        private void mapa_apoyo_Click(object sender, EventArgs e)
        {
            Form nv = new Form();
            AddOwnedForm(nv);

            using (MAPA_GOOGLE mn = new MAPA_GOOGLE())
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

                mn.Opacity = 0;
                mn.Owner = nv;
                mn.ShowDialog();

                nv.Dispose();
            }
        }

        private void cues1_Click(object sender, EventArgs e)
        {
            Form nv = new Form();
            using (CONSULTA_MUESTRAS_SONDEOS_INFORMES mn = new CONSULTA_MUESTRAS_SONDEOS_INFORMES())
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
                mn.c_o = clave_obra.Texts;
                mn.ShowDialog();

                nv.Dispose();
            }
        }

        private void label41_Click(object sender, EventArgs e)
        {
            MessageBox.Show(monto_recabado_IVA.ToString());
        }

        private void tipo_ot_OnSelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void NOMBRE_TEC_DoubleClick(object sender, EventArgs e)
        {

        }

        private void label24_Click(object sender, EventArgs e)
        {

            MySqlConnection CONEXION1 = conexion_rh.USR;
            MySqlCommand comando = new MySqlCommand("SELECT DISTINCTROW NOMBRE FROM pdr_personal1  WHERE AREA_2 = 'SERVICIOS EVENTUALES' OR CATEGORIA LIKE '%" + "OPERATIVO" + "%'", CONEXION1);
            CONEXION1.Open();
            MySqlDataReader registro = comando.ExecuteReader();

            while (registro.Read())
            {

                NOMBRE_TEC.Items.Add(registro["NOMBRE"].ToString());


            }

            CONEXION1.Close();
        }

        private void NOMBRE_TEC_Enter(object sender, EventArgs e)
        {
            ET.Show("Da click sobre la etiqueta \n - Realiza servicio - para \n ampliar la lista de técnicos", NOMBRE_TEC, 5000);
        }

        private void NOMBRE_TEC_Leave(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {


            //encabezado y pie de página
            iTextSharp.text.Image encabezado = iTextSharp.text.Image.GetInstance(ERP_COMPLETO.Properties.Resources.ENCABEZADO_V_LAB, System.Drawing.Imaging.ImageFormat.Jpeg);
            iTextSharp.text.Image pie_pag = iTextSharp.text.Image.GetInstance(ERP_COMPLETO.Properties.Resources.PIE_COT_DNS, System.Drawing.Imaging.ImageFormat.Jpeg);

            //se agrega la ruta de la imagen
            iTextSharp.text.Image logo_liec = iTextSharp.text.Image.GetInstance(ERP_COMPLETO.Properties.Resources.LOGO_LIEC, System.Drawing.Imaging.ImageFormat.Png);
            iTextSharp.text.Image CODIGO_QR = iTextSharp.text.Image.GetInstance(ERP_COMPLETO.Properties.Resources.QRAZUL, System.Drawing.Imaging.ImageFormat.Png);
            iTextSharp.text.Image ENCUESTA = iTextSharp.text.Image.GetInstance(ERP_COMPLETO.Properties.Resources.ENCUESTA_OT, System.Drawing.Imaging.ImageFormat.Png);




            // Colores
            BaseColor azul_cielo = new BaseColor(141, 180, 226, 255);
            BaseColor gris_bordes = new BaseColor(250, 250, 250);
            BaseColor blanco = new BaseColor(255, 255, 255);
            BaseColor gris_contenido = new BaseColor(85, 85, 85);
            BaseColor gris_cotizaciones = new BaseColor(247, 247, 247);
            BaseColor gris_claro = new BaseColor(233, 233, 233);
            BaseColor gris_oscuro_l = new BaseColor(89, 89, 89);
            BaseColor gris_oscuro = new BaseColor(200, 200, 200);
            BaseColor negro = new BaseColor(10, 10, 10);

            BaseColor azul_liec = new BaseColor(16, 77, 141);
            BaseColor naranja_liec = new BaseColor(225, 92, 0);


            //tipos y familias de letra
            BaseFont titulo = BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1250, true);
            BaseFont letra_normal = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1250, true);


            //combinacion de::: ------>  letra, tamaño, color de letra
            iTextSharp.text.Font letra_azul_max_grande = FontFactory.GetFont("Microsoft Sans Serif", 14, 1, azul_liec);
            iTextSharp.text.Font letra_azul_grande = FontFactory.GetFont("Microsoft Sans Serif", 12, 1, azul_liec);
            iTextSharp.text.Font letra_azul_mediana = FontFactory.GetFont("Microsoft Sans Serif", 10, 1, azul_liec);
            iTextSharp.text.Font letra_azul_chica = FontFactory.GetFont("Microsoft Sans Serif", 9, 1, azul_liec);
            iTextSharp.text.Font letra_azul_mas_chica = FontFactory.GetFont("Microsoft Sans Serif", 7, 1, azul_liec);
            iTextSharp.text.Font letra_azul_mas_chica_normal = FontFactory.GetFont("Microsoft Sans Serif", 7, 0, azul_liec);
            iTextSharp.text.Font letra_azul_8 = FontFactory.GetFont("Microsoft Sans Serif", 7, 1, azul_liec);
            iTextSharp.text.Font letra_azul_mas_mas_chica = FontFactory.GetFont("Microsoft Sans Serif", 5, 1, azul_liec);

            iTextSharp.text.Font letra_gris = FontFactory.GetFont("Microsoft Sans Serif", 8, 1, gris_oscuro_l);
            iTextSharp.text.Font letra_gris_chica = FontFactory.GetFont("Microsoft Sans Serif", 8, 1, gris_oscuro_l);
            iTextSharp.text.Font letra_gris_mas_chica = FontFactory.GetFont("Microsoft Sans Serif", 7, 0, gris_oscuro_l);
            iTextSharp.text.Font letra_gris_mas_chica_bold = FontFactory.GetFont("Microsoft Sans Serif", 7, 1, gris_oscuro_l);
            iTextSharp.text.Font letra_gris_mas_mas_chica = FontFactory.GetFont("Microsoft Sans Serif", 6, 0, gris_oscuro_l);

            iTextSharp.text.Font letra_negra_chica = FontFactory.GetFont("Microsoft Sans Serif", 7, 1, negro);
            iTextSharp.text.Font letra_negra_mas_chica = FontFactory.GetFont("Microsoft Sans Serif", 6, 1, gris_oscuro_l);
            iTextSharp.text.Font letra_negra_mas_chica_5 = FontFactory.GetFont("Microsoft Sans Serif", 5, 1, gris_oscuro_l);
            iTextSharp.text.Font letra_negra_mas_chica_normal = FontFactory.GetFont("Microsoft Sans Serif", 5, 0, gris_oscuro_l);

            iTextSharp.text.Font letra_leyenda_final = FontFactory.GetFont("ArialNarrow", 5, 0, gris_oscuro_l);

            iTextSharp.text.Font letra_nota = FontFactory.GetFont("ArialNarrow", 4, 0, gris_oscuro_l);

            iTextSharp.text.Font letra_naranja = FontFactory.GetFont("Microsoft Sans Serif", 8, 1, naranja_liec);

            iTextSharp.text.Font PREGUNTAS = FontFactory.GetFont("ArialNarrow", 6, 1, azul_liec);
            iTextSharp.text.Font FOREACH = FontFactory.GetFont("ArialNarrow", 5, 0, gris_oscuro_l); //cero = normal; 1 == negritas

            //forma y ruta de guardado de documento
            string documentos = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string pdf_ENCABEZADO = System.IO.Path.Combine(documentos, "ORDEN DE TRABAJO" + "-" + FOLIOO.Texts + "pdf");
            string informe_SIN_ENCABEZADO = System.IO.Path.Combine(documentos, FOLIOO.Texts + "-" + "ORDEN DE TRABAJO.pdf");


            // DOCUMENTO CREADO EN ITEXSHARP
            // Creamos el documento con el tamaño de página tradicional
            Document doc = new Document(PageSize.LETTER);
            // Indicamos donde vamos a guardar el documento
            PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(informe_SIN_ENCABEZADO, FileMode.Create));
            // Abrimos el archivo
            doc.Open();





            //ORDEN DE TRABAJO
            try
            {


                PdfPTable table = new PdfPTable(13);
                table.TotalWidth = 350f;
                table.HorizontalAlignment = Element.ALIGN_LEFT;
                table.SpacingAfter = 5;

                PdfPCell cell = new PdfPCell(new Phrase("ORDEN DE TRABAJO", letra_azul_grande));//se agregan celdas
                cell.BackgroundColor = blanco;
                cell.Border = 0;
                cell.HorizontalAlignment = Element.ALIGN_LEFT;
                cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell.PaddingBottom = 4f; //
                cell.PaddingLeft = 19f;
                cell.PaddingTop = 1f;

                cell.Colspan = 13;  //
                table.AddCell(cell); //

                PdfPCell cell2;
                cell2 = new PdfPCell(new Phrase("         FR-LIEC-03.08", letra_azul_mas_chica_normal));
                cell2.Border = 0;
                cell2.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell2.HorizontalAlignment = Element.ALIGN_LEFT;
                cell2.Colspan = 13;
                table.AddCell(cell2);



                doc.Add(table);

            }
            catch { }
            try
            {

                PdfPTable table = new PdfPTable(13);
                table.TotalWidth = 500f;
                table.HorizontalAlignment = Element.ALIGN_LEFT;

                PdfPCell cell3;
                cell3 = new PdfPCell(new Phrase("No. Folio:", letra_azul_chica));
                cell3.Border = 0;
                cell3.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell3.HorizontalAlignment = Element.ALIGN_LEFT;
                cell3.Colspan = 2;
                cell3.PaddingLeft = 19f;
                table.AddCell(cell3);

                cell3 = new PdfPCell(new Phrase(FOLIOO.Texts, letra_naranja));
                cell3.Border = 0;
                cell3.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell3.HorizontalAlignment = Element.ALIGN_LEFT;
                cell3.Colspan = 2;
                // cell3.PaddingLeft = 13f;
                table.AddCell(cell3);

                cell3 = new PdfPCell(new Phrase("Cotización:", letra_azul_chica));
                cell3.Border = 0;
                cell3.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell3.HorizontalAlignment = Element.ALIGN_RIGHT;
                cell3.Colspan = 2;
                // cell3.PaddingLeft = 17f;
                table.AddCell(cell3);

                cell3 = new PdfPCell(new Phrase(ID_COT.Text, letra_naranja));
                cell3.Border = 0;
                cell3.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell3.HorizontalAlignment = Element.ALIGN_LEFT;
                cell3.Colspan = 7;
                // cell3.PaddingLeft = 13f;
                table.AddCell(cell3);
                doc.Add(table);
            }
            catch { }


            //LINEA
            try
            {
                PdfPTable table = new PdfPTable(13);//total de columnas del formato
                table.TotalWidth = 500f;
                table.LockedWidth = true;
                table.SpacingBefore = 1;//Espacio de escritura hacia arriba
                table.SpacingAfter = 0;//espacio despues
                table.HorizontalAlignment = Element.ALIGN_CENTER;

                PdfPCell cell = new PdfPCell(new Phrase("", letra_azul_grande));//se agregan celdas
                cell.BackgroundColor = naranja_liec;
                cell.Border = 0;
                cell.HorizontalAlignment = Element.ALIGN_RIGHT;
                cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell.PaddingBottom = 4f; //dimensiones de padding
                cell.PaddingLeft = 1f;
                cell.PaddingTop = 1f;
                cell.FixedHeight = 0.5f;
                cell.Colspan = 1;  //la celda abarcara las 13 columnas 
                table.AddCell(cell); //agrega la celda 

                cell = new PdfPCell(new Phrase("", letra_naranja));//se agregan celdas
                cell.BackgroundColor = azul_liec;
                cell.Border = 0;
                cell.HorizontalAlignment = Element.ALIGN_LEFT;
                cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell.PaddingBottom = 4f; //dimensiones de padding
                cell.PaddingLeft = 1f;
                cell.PaddingTop = 1f;
                cell.FixedHeight = 0.5f;
                cell.Colspan = 6;  //la celda abarcara las 13 columnas 
                table.AddCell(cell); //agrega la celda

                cell = new PdfPCell(new Phrase("", letra_naranja));//se agregan celdas
                cell.BackgroundColor = blanco;
                cell.Border = 0;
                cell.HorizontalAlignment = Element.ALIGN_LEFT;
                cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell.PaddingBottom = 4f; //dimensiones de padding
                cell.PaddingLeft = 1f;
                cell.PaddingTop = 1f;
                cell.FixedHeight = 0.5f;
                cell.Colspan = 6;  //la celda abarcara las 13 columnas 
                table.AddCell(cell); //agrega la celda

                doc.Add(table); //agrega la tabla 
            }
            catch { }



















            //DATOS SOLICITANTE
            try
            {
                PdfPTable table = new PdfPTable(11);//total de columnas del formato
                table.TotalWidth = 500f;
                table.LockedWidth = true;
                table.SpacingBefore = 2;//Espacio de escritura hacia arriba
                table.SpacingAfter = 0;//espacio despues

                PdfPCell cell = new PdfPCell(new Phrase("DATOS DEL SOLICITANTE", letra_azul_8));//se agregan celdas
                cell.BackgroundColor = blanco;
                cell.Border = 0;
                cell.HorizontalAlignment = Element.ALIGN_LEFT;
                cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell.PaddingBottom = 4f; //dimensiones de padding
                cell.PaddingLeft = 1f;
                cell.PaddingTop = 1f;
                cell.FixedHeight = 23f;
                cell.Colspan = 11;  //la celda abarcara las 13 columnas 
                table.AddCell(cell); //agrega la celda 

                doc.Add(table); //agrega la tabla 
            }
            catch { }

            //LINEA
            try
            {
                PdfPTable table = new PdfPTable(13);//total de columnas del formato
                table.TotalWidth = 500f;
                table.LockedWidth = true;
                table.SpacingBefore = 1;//Espacio de escritura hacia arriba
                table.SpacingAfter = 0;//espacio despues

                PdfPCell cell = new PdfPCell(new Phrase("", letra_azul_grande));//se agregan celdas
                cell.BackgroundColor = naranja_liec;
                cell.Border = 0;
                cell.HorizontalAlignment = Element.ALIGN_RIGHT;
                cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell.PaddingBottom = 4f; //dimensiones de padding
                cell.PaddingLeft = 1f;
                cell.PaddingTop = 1f;
                cell.FixedHeight = 0.5f;
                cell.Colspan = 1;  //la celda abarcara las 13 columnas 
                table.AddCell(cell); //agrega la celda 

                cell = new PdfPCell(new Phrase("", letra_naranja));//se agregan celdas
                cell.BackgroundColor = azul_liec;
                cell.Border = 0;
                cell.HorizontalAlignment = Element.ALIGN_LEFT;
                cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell.PaddingBottom = 4f; //dimensiones de padding
                cell.PaddingLeft = 1f;
                cell.PaddingTop = 1f;
                cell.FixedHeight = 0.5f;
                cell.Colspan = 12;  //la celda abarcara las 13 columnas 
                table.AddCell(cell); //agrega la celda

                doc.Add(table); //agrega la tabla 
            }
            catch { }







            //NOMBRE
            try
            {
                PdfPTable table = new PdfPTable(13);//total de columnas del formato
                table.TotalWidth = 500f;
                table.LockedWidth = true;
                table.SpacingBefore = 1;//Espacio de escritura hacia arriba
                table.SpacingAfter = 0;//espacio despues

                PdfPCell cell = new PdfPCell(new Phrase("Nombre:", letra_azul_mas_chica));//se agregan celdas
                cell.BackgroundColor = blanco;
                cell.Border = 0;
                cell.HorizontalAlignment = Element.ALIGN_LEFT;
                cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell.PaddingBottom = 4f; //dimensiones de padding
                cell.PaddingLeft = 1f;
                cell.PaddingTop = 1f;
                cell.Colspan = 2;  //la celda abarcara las 13 columnas 
                table.AddCell(cell); //agrega la celda 

                cell = new PdfPCell(new Phrase(NOMBRE.Texts, letra_gris_mas_chica_bold));//se agregan celdas
                cell.BackgroundColor = blanco;
                cell.Border = 0;
                cell.HorizontalAlignment = Element.ALIGN_LEFT;
                cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell.PaddingBottom = 4f; //dimensiones de padding
                cell.PaddingLeft = 1f;
                cell.PaddingTop = 1f;
                cell.Colspan = 4;  //la celda abarcara las 13 columnas 
                table.AddCell(cell); //agrega la celda

                cell = new PdfPCell(new Phrase("Empresa:", letra_azul_mas_chica));//se agregan celdas
                cell.BackgroundColor = blanco;
                cell.Border = 0;
                cell.HorizontalAlignment = Element.ALIGN_RIGHT;
                cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell.PaddingBottom = 4f; //dimensiones de padding
                cell.PaddingLeft = 1f;
                cell.PaddingTop = 1f;
                cell.Colspan = 2;  //la celda abarcara las 13 columnas 
                table.AddCell(cell); //agrega la celda

                cell = new PdfPCell(new Phrase(EMPRESA.Texts, letra_gris_mas_chica_bold));//se agregan celdas
                cell.BackgroundColor = blanco;
                cell.Border = 0;
                cell.HorizontalAlignment = Element.ALIGN_LEFT;
                cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell.PaddingBottom = 4f; //dimensiones de padding
                cell.PaddingLeft = 1f;
                cell.PaddingTop = 1f;
                cell.Colspan = 5;  //la celda abarcara las 13 columnas 
                table.AddCell(cell); //agrega la celda

                doc.Add(table); //agrega la tabla 
            }
            catch { }

            //LINEA
            try
            {
                PdfPTable table = new PdfPTable(13);//total de columnas del formato
                table.TotalWidth = 500f;
                table.LockedWidth = true;
                table.SpacingBefore = 1;//Espacio de escritura hacia arriba
                table.SpacingAfter = 0;//espacio despues

                PdfPCell cell = new PdfPCell(new Phrase("", letra_azul_grande));//se agregan celdas
                cell.BackgroundColor = blanco;
                cell.Border = 0;
                cell.HorizontalAlignment = Element.ALIGN_RIGHT;
                cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell.PaddingBottom = 4f; //dimensiones de padding
                cell.PaddingLeft = 1f;
                cell.PaddingTop = 1f;
                cell.Colspan = 2;  //la celda abarcara las 13 columnas 
                table.AddCell(cell); //agrega la celda 

                cell = new PdfPCell(new Phrase("", letra_naranja));//se agregan celdas
                cell.BackgroundColor = gris_oscuro;
                cell.Border = 0;
                cell.HorizontalAlignment = Element.ALIGN_LEFT;
                cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell.PaddingBottom = 4f; //dimensiones de padding
                cell.PaddingLeft = 1f;
                cell.PaddingTop = 1f;
                cell.Colspan = 4;  //la celda abarcara las 13 columnas 
                table.AddCell(cell); //agrega la celda

                cell = new PdfPCell(new Phrase("", letra_azul_chica));//se agregan celdas
                cell.BackgroundColor = blanco;
                cell.Border = 0;
                cell.HorizontalAlignment = Element.ALIGN_LEFT;
                cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell.PaddingBottom = 4f; //dimensiones de padding
                cell.PaddingLeft = 1f;
                cell.PaddingTop = 1f;
                cell.Colspan = 2;  //la celda abarcara las 13 columnas 
                table.AddCell(cell); //agrega la celda

                cell = new PdfPCell(new Phrase("", letra_gris));//se agregan celdas
                cell.BackgroundColor = gris_oscuro;
                cell.Border = 0;
                cell.HorizontalAlignment = Element.ALIGN_LEFT;
                cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell.PaddingBottom = 4f; //dimensiones de padding
                cell.PaddingLeft = 1f;
                cell.PaddingTop = 1f;
                cell.Colspan = 5;  //la celda abarcara las 13 columnas 
                table.AddCell(cell); //agrega la celda

                doc.Add(table); //agrega la tabla 
            }
            catch { }

            //TELEFONO
            try
            {
                PdfPTable table = new PdfPTable(13);//total de columnas del formato
                table.TotalWidth = 500f;
                table.LockedWidth = true;
                table.SpacingBefore = 1;//Espacio de escritura hacia arriba
                table.SpacingAfter = 0;//espacio despues

                PdfPCell cell = new PdfPCell(new Phrase("Teléfono:", letra_azul_mas_chica));//se agregan celdas
                cell.BackgroundColor = blanco;
                cell.Border = 0;
                cell.HorizontalAlignment = Element.ALIGN_LEFT;
                cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell.PaddingBottom = 4f; //dimensiones de padding
                cell.PaddingLeft = 1f;
                cell.PaddingTop = 1f;
                cell.Colspan = 2;  //la celda abarcara las 13 columnas 
                table.AddCell(cell); //agrega la celda 

                cell = new PdfPCell(new Phrase(TELEFONO.Texts, letra_gris_mas_chica_bold));//se agregan celdas
                cell.BackgroundColor = blanco;
                cell.Border = 0;
                cell.HorizontalAlignment = Element.ALIGN_LEFT;
                cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell.PaddingBottom = 4f; //dimensiones de padding
                cell.PaddingLeft = 1f;
                cell.PaddingTop = 1f;
                cell.Colspan = 4;  //la celda abarcara las 13 columnas 
                table.AddCell(cell); //agrega la celda

                cell = new PdfPCell(new Phrase("E-mail:", letra_azul_mas_chica));//se agregan celdas
                cell.BackgroundColor = blanco;
                cell.Border = 0;
                cell.HorizontalAlignment = Element.ALIGN_RIGHT;
                cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell.PaddingBottom = 4f; //dimensiones de padding
                cell.PaddingLeft = 1f;
                cell.PaddingTop = 1f;
                cell.Colspan = 2;  //la celda abarcara las 13 columnas 
                table.AddCell(cell); //agrega la celda

                cell = new PdfPCell(new Phrase(EMAIL.Texts, letra_gris_mas_chica_bold));//se agregan celdas
                cell.BackgroundColor = blanco;
                cell.Border = 0;
                cell.HorizontalAlignment = Element.ALIGN_LEFT;
                cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell.PaddingBottom = 4f; //dimensiones de padding
                cell.PaddingLeft = 1f;
                cell.PaddingTop = 1f;
                cell.Colspan = 5;  //la celda abarcara las 13 columnas 
                table.AddCell(cell); //agrega la celda

                doc.Add(table); //agrega la tabla 
            }
            catch { }

            //LINEA
            try
            {
                PdfPTable table = new PdfPTable(13);//total de columnas del formato
                table.TotalWidth = 500f;
                table.LockedWidth = true;
                table.SpacingBefore = 1;//Espacio de escritura hacia arriba
                table.SpacingAfter = 0;//espacio despues

                PdfPCell cell = new PdfPCell(new Phrase("", letra_azul_grande));//se agregan celdas
                cell.BackgroundColor = blanco;
                cell.Border = 0;
                cell.HorizontalAlignment = Element.ALIGN_RIGHT;
                cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell.PaddingBottom = 4f; //dimensiones de padding
                cell.PaddingLeft = 1f;
                cell.PaddingTop = 1f;
                cell.Colspan = 2;  //la celda abarcara las 13 columnas 
                table.AddCell(cell); //agrega la celda 

                cell = new PdfPCell(new Phrase("", letra_naranja));//se agregan celdas
                cell.BackgroundColor = gris_oscuro;
                cell.Border = 0;
                cell.HorizontalAlignment = Element.ALIGN_LEFT;
                cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell.PaddingBottom = 4f; //dimensiones de padding
                cell.PaddingLeft = 1f;
                cell.PaddingTop = 1f;
                cell.Colspan = 4;  //la celda abarcara las 13 columnas 
                table.AddCell(cell); //agrega la celda

                cell = new PdfPCell(new Phrase("", letra_azul_chica));//se agregan celdas
                cell.BackgroundColor = blanco;
                cell.Border = 0;
                cell.HorizontalAlignment = Element.ALIGN_LEFT;
                cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell.PaddingBottom = 4f; //dimensiones de padding
                cell.PaddingLeft = 1f;
                cell.PaddingTop = 1f;
                cell.Colspan = 2;  //la celda abarcara las 13 columnas 
                table.AddCell(cell); //agrega la celda

                cell = new PdfPCell(new Phrase("", letra_gris));//se agregan celdas
                cell.BackgroundColor = gris_oscuro;
                cell.Border = 0;
                cell.HorizontalAlignment = Element.ALIGN_LEFT;
                cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell.PaddingBottom = 4f; //dimensiones de padding
                cell.PaddingLeft = 1f;
                cell.PaddingTop = 1f;
                cell.Colspan = 5;  //la celda abarcara las 13 columnas 
                table.AddCell(cell); //agrega la celda

                doc.Add(table); //agrega la tabla 
            }
            catch { }

            ///////////////////////////////INICIO DE EDICION////////////////////////////////////////////////////////////////////////
            // PIE DE PÁGINA
            try
            {
                pie_pag.ScaleToFit(670f, 60F);//coordenadas para tamaño carta PIE DE PAGINA

                pie_pag.SetAbsolutePosition(60, 3);  //LADOS  //ARRIBA (-) ABAJO (+)

                doc.Add(pie_pag);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString(), ex);
            }


            try
            {
                logo_liec.ScalePercent(9f);
                logo_liec.SetAbsolutePosition(493, 706);
                doc.Add(logo_liec);

            }
            catch { }



            //NOMBRE OBRA
            try
            {
                PdfPTable table = new PdfPTable(13);//total de columnas del formato
                table.TotalWidth = 500f;
                table.LockedWidth = true;
                table.SpacingBefore = 1;//Espacio de escritura hacia arriba
                table.SpacingAfter = 0;//espacio despues

                PdfPCell cell = new PdfPCell(new Phrase("Nombre de Obra:", letra_azul_mas_chica));//se agregan celdas
                cell.BackgroundColor = blanco;
                cell.Border = 0;
                cell.HorizontalAlignment = Element.ALIGN_LEFT;
                cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell.PaddingBottom = 4f; //dimensiones de padding
                cell.PaddingLeft = 1f;
                cell.PaddingTop = 1f;
                cell.Colspan = 2;  //la celda abarcara las 13 columnas 
                table.AddCell(cell); //agrega la celda 

                cell = new PdfPCell(new Phrase(NOMBRE_OBRA.Texts, letra_gris_mas_chica));//se agregan celdas
                cell.BackgroundColor = blanco;
                cell.Border = 0;
                cell.HorizontalAlignment = Element.ALIGN_LEFT;
                cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell.PaddingBottom = 4f; //dimensiones de padding
                cell.PaddingLeft = 1f;
                cell.PaddingTop = 1f;
                cell.Colspan = 11;  //la celda abarcara las 13 columnas 
                table.AddCell(cell); //agrega la celda

                doc.Add(table); //agrega la tabla 
            }
            catch { }

            //LINEA
            try
            {
                PdfPTable table = new PdfPTable(13);//total de columnas del formato
                table.TotalWidth = 500f;
                table.LockedWidth = true;
                table.SpacingBefore = 1;//Espacio de escritura hacia arriba
                table.SpacingAfter = 0;//espacio despues

                PdfPCell cell = new PdfPCell(new Phrase("", letra_azul_grande));//se agregan celdas
                cell.BackgroundColor = blanco;
                cell.Border = 0;
                cell.HorizontalAlignment = Element.ALIGN_RIGHT;
                cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell.PaddingBottom = 4f; //dimensiones de padding
                cell.PaddingLeft = 1f;
                cell.PaddingTop = 1f;
                cell.Colspan = 2;  //la celda abarcara las 13 columnas 
                table.AddCell(cell); //agrega la celda 

                cell = new PdfPCell(new Phrase("", letra_naranja));//se agregan celdas
                cell.BackgroundColor = gris_oscuro;
                cell.Border = 0;
                cell.HorizontalAlignment = Element.ALIGN_LEFT;
                cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell.PaddingBottom = 4f; //dimensiones de padding
                cell.PaddingLeft = 1f;
                cell.PaddingTop = 1f;
                cell.Colspan = 11;  //la celda abarcara las 13 columnas 
                table.AddCell(cell); //agrega la celda

                doc.Add(table); //agrega la tabla 
            }
            catch { }

            //DOMICILIO
            try
            {
                PdfPTable table = new PdfPTable(13);//total de columnas del formato
                table.TotalWidth = 500f;
                table.LockedWidth = true;
                table.SpacingBefore = 1;//Espacio de escritura hacia arriba
                table.SpacingAfter = 0;//espacio despues

                PdfPCell cell = new PdfPCell(new Phrase("Domicilio:", letra_azul_mas_chica));//se agregan celdas
                cell.BackgroundColor = blanco;
                cell.Border = 0;
                cell.HorizontalAlignment = Element.ALIGN_LEFT;
                cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell.PaddingBottom = 4f; //dimensiones de padding
                cell.PaddingLeft = 1f;
                cell.PaddingTop = 1f;
                cell.Colspan = 2;  //la celda abarcara las 13 columnas 
                table.AddCell(cell); //agrega la celda 

                cell = new PdfPCell(new Phrase(DOMICILIO.Texts, letra_gris_mas_chica));//se agregan celdas
                cell.BackgroundColor = blanco;
                cell.Border = 0;
                cell.HorizontalAlignment = Element.ALIGN_LEFT;
                cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell.PaddingBottom = 4f; //dimensiones de padding
                cell.PaddingLeft = 1f;
                cell.PaddingTop = 1f;
                cell.Colspan = 11;  //la celda abarcara las 13 columnas 
                table.AddCell(cell); //agrega la celda

                doc.Add(table); //agrega la tabla 
            }
            catch { }

            //LINEA
            try
            {
                PdfPTable table = new PdfPTable(13);//total de columnas del formato
                table.TotalWidth = 500f;
                table.LockedWidth = true;
                table.SpacingBefore = 1;//Espacio de escritura hacia arriba
                table.SpacingAfter = 0;//espacio despues

                PdfPCell cell = new PdfPCell(new Phrase("", letra_azul_grande));//se agregan celdas
                cell.BackgroundColor = blanco;
                cell.Border = 0;
                cell.HorizontalAlignment = Element.ALIGN_RIGHT;
                cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell.PaddingBottom = 4f; //dimensiones de padding
                cell.PaddingLeft = 1f;
                cell.PaddingTop = 1f;
                cell.Colspan = 2;  //la celda abarcara las 13 columnas 
                table.AddCell(cell); //agrega la celda 

                cell = new PdfPCell(new Phrase("", letra_naranja));//se agregan celdas
                cell.BackgroundColor = gris_oscuro;
                cell.Border = 0;
                cell.HorizontalAlignment = Element.ALIGN_LEFT;
                cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell.PaddingBottom = 4f; //dimensiones de padding
                cell.PaddingLeft = 1f;
                cell.PaddingTop = 1f;
                cell.Colspan = 11;  //la celda abarcara las 13 columnas 
                table.AddCell(cell); //agrega la celda

                doc.Add(table); //agrega la tabla 
            }
            catch { }

            //DIRIGIRSE
            try
            {
                PdfPTable table = new PdfPTable(13);//total de columnas del formato
                table.TotalWidth = 500f;
                table.LockedWidth = true;
                table.SpacingBefore = 1;//Espacio de escritura hacia arriba
                table.SpacingAfter = 0;//espacio despues

                PdfPCell cell = new PdfPCell(new Phrase("Dirigirse a:", letra_azul_mas_chica));//se agregan celdas
                cell.BackgroundColor = blanco;
                cell.Border = 0;
                cell.HorizontalAlignment = Element.ALIGN_LEFT;
                cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell.PaddingBottom = 4f; //dimensiones de padding
                cell.PaddingLeft = 1f;
                cell.PaddingTop = 1f;
                cell.Colspan = 2;  //la celda abarcara las 13 columnas 
                table.AddCell(cell); //agrega la celda 

                cell = new PdfPCell(new Phrase(DIRIGIDO.Texts, letra_gris_mas_chica));//se agregan celdas
                cell.BackgroundColor = blanco;
                cell.Border = 0;
                cell.HorizontalAlignment = Element.ALIGN_LEFT;
                cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell.PaddingBottom = 4f; //dimensiones de padding
                cell.PaddingLeft = 1f;
                cell.PaddingTop = 1f;
                cell.Colspan = 4;  //la celda abarcara las 13 columnas 
                table.AddCell(cell); //agrega la celda

                cell = new PdfPCell(new Phrase("Fecha:", letra_azul_mas_chica));//se agregan celdas
                cell.BackgroundColor = blanco;
                cell.Border = 0;
                cell.HorizontalAlignment = Element.ALIGN_RIGHT;
                cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell.PaddingBottom = 4f; //dimensiones de padding
                cell.PaddingLeft = 1f;
                cell.PaddingTop = 1f;
                cell.Colspan = 1;  //la celda abarcara las 13 columnas 
                table.AddCell(cell); //agrega la celda

                cell = new PdfPCell(new Phrase(FECHA.Text, letra_gris_mas_mas_chica));//se agregan celdas
                cell.BackgroundColor = blanco;
                cell.Border = 0;
                cell.HorizontalAlignment = Element.ALIGN_LEFT;
                cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell.PaddingBottom = 4f; //dimensiones de padding
                cell.PaddingLeft = 1f;
                cell.PaddingTop = 1f;
                cell.Colspan = 1;  //la celda abarcara las 13 columnas 
                table.AddCell(cell); //agrega la celda

                cell = new PdfPCell(new Phrase("Inicia:", letra_azul_mas_chica));//se agregan celdas
                cell.BackgroundColor = blanco;
                cell.Border = 0;
                cell.HorizontalAlignment = Element.ALIGN_RIGHT;
                cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell.PaddingBottom = 4f; //dimensiones de padding
                cell.PaddingLeft = 1f;
                cell.PaddingTop = 1f;
                cell.Colspan = 1;  //la celda abarcara las 13 columnas 
                table.AddCell(cell); //agrega la celda

                cell = new PdfPCell(new Phrase(HORA.Texts, letra_gris_mas_chica));//se agregan celdas
                cell.BackgroundColor = blanco;
                cell.Border = 0;
                cell.HorizontalAlignment = Element.ALIGN_LEFT;
                cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell.PaddingBottom = 4f; //dimensiones de padding
                cell.PaddingLeft = 1f;
                cell.PaddingTop = 1f;
                cell.Colspan = 1;  //la celda abarcara las 13 columnas 
                table.AddCell(cell); //agrega la celda

                cell = new PdfPCell(new Phrase("Termina:", letra_azul_mas_chica));//se agregan celdas
                cell.BackgroundColor = blanco;
                cell.Border = 0;
                cell.HorizontalAlignment = Element.ALIGN_RIGHT;
                cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell.PaddingBottom = 4f; //dimensiones de padding
                cell.PaddingLeft = 1f;
                cell.PaddingTop = 1f;
                cell.Colspan = 2;  //la celda abarcara las 13 columnas 
                table.AddCell(cell); //agrega la celda

                cell = new PdfPCell(new Phrase(MINUTOS.Texts + "hrs", letra_gris_mas_chica));//se agregan celdas
                cell.BackgroundColor = blanco;
                cell.Border = 0;
                cell.HorizontalAlignment = Element.ALIGN_LEFT;
                cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell.PaddingBottom = 4f; //dimensiones de padding
                cell.PaddingLeft = 1f;
                cell.PaddingTop = 1f;
                cell.Colspan = 1;  //la celda abarcara las 13 columnas 
                table.AddCell(cell); //agrega la celda

                doc.Add(table); //agrega la tabla 
            }
            catch { }

            //LINEA
            try
            {
                PdfPTable table = new PdfPTable(13);//total de columnas del formato
                table.TotalWidth = 500f;
                table.LockedWidth = true;
                table.SpacingBefore = 1;//Espacio de escritura hacia arriba
                table.SpacingAfter = 0;//espacio despues

                PdfPCell cell = new PdfPCell(new Phrase("", letra_azul_grande));//se agregan celdas
                cell.BackgroundColor = blanco;
                cell.Border = 0;
                cell.HorizontalAlignment = Element.ALIGN_RIGHT;
                cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell.PaddingBottom = 4f; //dimensiones de padding
                cell.PaddingLeft = 1f;
                cell.PaddingTop = 1f;
                cell.Colspan = 2;  //la celda abarcara las 13 columnas 
                table.AddCell(cell); //agrega la celda 

                cell = new PdfPCell(new Phrase("", letra_naranja));//se agregan celdas
                cell.BackgroundColor = gris_oscuro;
                cell.Border = 0;
                cell.HorizontalAlignment = Element.ALIGN_LEFT;
                cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell.PaddingBottom = 4f; //dimensiones de padding
                cell.PaddingLeft = 1f;
                cell.PaddingTop = 1f;
                cell.Colspan = 4;  //la celda abarcara las 13 columnas 
                table.AddCell(cell); //agrega la celda

                cell = new PdfPCell(new Phrase("", letra_naranja));//se agregan celdas
                cell.BackgroundColor = blanco;
                cell.Border = 0;
                cell.HorizontalAlignment = Element.ALIGN_LEFT;
                cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell.PaddingBottom = 4f; //dimensiones de padding
                cell.PaddingLeft = 1f;
                cell.PaddingTop = 1f;
                cell.Colspan = 1;  //la celda abarcara las 13 columnas 
                table.AddCell(cell); //agrega la celda

                cell = new PdfPCell(new Phrase("", letra_naranja));//se agregan celdas
                cell.BackgroundColor = gris_oscuro;
                cell.Border = 0;
                cell.HorizontalAlignment = Element.ALIGN_LEFT;
                cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell.PaddingBottom = 4f; //dimensiones de padding
                cell.PaddingLeft = 1f;
                cell.PaddingTop = 1f;
                cell.Colspan = 1;  //la celda abarcara las 13 columnas 
                table.AddCell(cell); //agrega la celda

                cell = new PdfPCell(new Phrase("", letra_naranja));//se agregan celdas
                cell.BackgroundColor = blanco;
                cell.Border = 0;
                cell.HorizontalAlignment = Element.ALIGN_LEFT;
                cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell.PaddingBottom = 4f; //dimensiones de padding
                cell.PaddingLeft = 1f;
                cell.PaddingTop = 1f;
                cell.Colspan = 1;  //la celda abarcara las 13 columnas 
                table.AddCell(cell); //agrega la celda

                cell = new PdfPCell(new Phrase("", letra_naranja));//se agregan celdas
                cell.BackgroundColor = gris_oscuro;
                cell.Border = 0;
                cell.HorizontalAlignment = Element.ALIGN_LEFT;
                cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell.PaddingBottom = 4f; //dimensiones de padding
                cell.PaddingLeft = 1f;
                cell.PaddingTop = 1f;
                cell.Colspan = 1;  //la celda abarcara las 13 columnas 
                table.AddCell(cell); //agrega la celda

                cell = new PdfPCell(new Phrase("", letra_naranja));//se agregan celdas
                cell.BackgroundColor = blanco;
                cell.Border = 0;
                cell.HorizontalAlignment = Element.ALIGN_LEFT;
                cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell.PaddingBottom = 4f; //dimensiones de padding
                cell.PaddingLeft = 1f;
                cell.PaddingTop = 1f;
                cell.Colspan = 1;  //la celda abarcara las 13 columnas 
                table.AddCell(cell); //agrega la celda

                cell = new PdfPCell(new Phrase("", letra_naranja));//se agregan celdas
                cell.BackgroundColor = blanco;
                cell.Border = 0;
                cell.HorizontalAlignment = Element.ALIGN_LEFT;
                cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell.PaddingBottom = 4f; //dimensiones de padding
                cell.PaddingLeft = 1f;
                cell.PaddingTop = 1f;
                cell.Colspan = 1;  //la celda abarcara las 13 columnas 
                table.AddCell(cell); //agrega la celda

                cell = new PdfPCell(new Phrase("", letra_naranja));//se agregan celdas
                cell.BackgroundColor = gris_oscuro;
                cell.Border = 0;
                cell.HorizontalAlignment = Element.ALIGN_LEFT;
                cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell.PaddingBottom = 4f; //dimensiones de padding
                cell.PaddingLeft = 1f;
                cell.PaddingTop = 1f;
                cell.Colspan = 1;  //la celda abarcara las 13 columnas 
                table.AddCell(cell); //agrega la celda
                doc.Add(table); //agrega la tabla 
            }
            catch { }

            //RECIBE SOLICITUD
            try
            {
                PdfPTable table = new PdfPTable(13);//total de columnas del formato
                table.TotalWidth = 500f;
                table.LockedWidth = true;
                table.SpacingBefore = 1;//Espacio de escritura hacia arriba
                table.SpacingAfter = 0;//espacio despues

                PdfPCell cell = new PdfPCell(new Phrase("Recibe solicitud:", letra_azul_mas_chica));//se agregan celdas
                cell.BackgroundColor = blanco;
                cell.Border = 0;
                cell.HorizontalAlignment = Element.ALIGN_LEFT;
                cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell.PaddingBottom = 4f; //dimensiones de padding
                cell.PaddingLeft = 1f;
                cell.PaddingTop = 1f;
                cell.Colspan = 2;  //la celda abarcara las 13 columnas 
                table.AddCell(cell); //agrega la celda 

                cell = new PdfPCell(new Phrase(RECIB.Texts, letra_gris_mas_chica));//se agregan celdas
                cell.BackgroundColor = blanco;
                cell.Border = 0;
                cell.HorizontalAlignment = Element.ALIGN_LEFT;
                cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell.PaddingBottom = 4f; //dimensiones de padding
                cell.PaddingLeft = 1f;
                cell.PaddingTop = 1f;
                cell.Colspan = 4;  //la celda abarcara las 13 columnas 
                table.AddCell(cell); //agrega la celda

                cell = new PdfPCell(new Phrase("Autoriza solicitud:", letra_azul_mas_chica));//se agregan celdas
                cell.BackgroundColor = blanco;
                cell.Border = 0;
                cell.HorizontalAlignment = Element.ALIGN_RIGHT;
                cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell.PaddingBottom = 4f; //dimensiones de padding
                cell.PaddingLeft = 1f;
                cell.PaddingTop = 1f;
                cell.Colspan = 2;  //la celda abarcara las 13 columnas 
                table.AddCell(cell); //agrega la celda

                cell = new PdfPCell(new Phrase(AUTORIZA.Texts, letra_gris_mas_chica));//se agregan celdas
                cell.BackgroundColor = blanco;
                cell.Border = 0;
                cell.HorizontalAlignment = Element.ALIGN_LEFT;
                cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell.PaddingBottom = 4f; //dimensiones de padding
                cell.PaddingLeft = 1f;
                cell.PaddingTop = 1f;
                cell.Colspan = 5;  //la celda abarcara las 13 columnas 
                table.AddCell(cell); //agrega la celda

                doc.Add(table); //agrega la tabla 
            }
            catch { }

            //LINEA
            try
            {
                PdfPTable table = new PdfPTable(13);//total de columnas del formato
                table.TotalWidth = 500f;
                table.LockedWidth = true;
                table.SpacingBefore = 1;//Espacio de escritura hacia arriba
                table.SpacingAfter = 0;//espacio despues

                PdfPCell cell = new PdfPCell(new Phrase("", letra_azul_grande));//se agregan celdas
                cell.BackgroundColor = blanco;
                cell.Border = 0;
                cell.HorizontalAlignment = Element.ALIGN_RIGHT;
                cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell.PaddingBottom = 4f; //dimensiones de padding
                cell.PaddingLeft = 1f;
                cell.PaddingTop = 1f;
                cell.Colspan = 2;  //la celda abarcara las 13 columnas 
                table.AddCell(cell); //agrega la celda 

                cell = new PdfPCell(new Phrase("", letra_naranja));//se agregan celdas
                cell.BackgroundColor = gris_oscuro;
                cell.Border = 0;
                cell.HorizontalAlignment = Element.ALIGN_LEFT;
                cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell.PaddingBottom = 4f; //dimensiones de padding
                cell.PaddingLeft = 1f;
                cell.PaddingTop = 1f;
                cell.Colspan = 4;  //la celda abarcara las 13 columnas 
                table.AddCell(cell); //agrega la celda

                cell = new PdfPCell(new Phrase("", letra_azul_chica));//se agregan celdas
                cell.BackgroundColor = blanco;
                cell.Border = 0;
                cell.HorizontalAlignment = Element.ALIGN_LEFT;
                cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell.PaddingBottom = 4f; //dimensiones de padding
                cell.PaddingLeft = 1f;
                cell.PaddingTop = 1f;
                cell.Colspan = 2;  //la celda abarcara las 13 columnas 
                table.AddCell(cell); //agrega la celda

                cell = new PdfPCell(new Phrase("", letra_gris));//se agregan celdas
                cell.BackgroundColor = gris_oscuro;
                cell.Border = 0;
                cell.HorizontalAlignment = Element.ALIGN_LEFT;
                cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell.PaddingBottom = 4f; //dimensiones de padding
                cell.PaddingLeft = 1f;
                cell.PaddingTop = 1f;
                cell.Colspan = 5;  //la celda abarcara las 13 columnas 
                table.AddCell(cell); //agrega la celda

                doc.Add(table); //agrega la tabla 
            }
            catch { }

            //PROGRAMA SERVICIOS
            try
            {
                PdfPTable table = new PdfPTable(13);//total de columnas del formato
                table.TotalWidth = 500f;
                table.LockedWidth = true;
                table.SpacingBefore = 1;//Espacio de escritura hacia arriba
                table.SpacingAfter = 0;//espacio despues

                PdfPCell cell = new PdfPCell(new Phrase("Programa servicios:", letra_azul_mas_chica));//se agregan celdas
                cell.BackgroundColor = blanco;
                cell.Border = 0;
                cell.HorizontalAlignment = Element.ALIGN_LEFT;
                cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell.PaddingBottom = 4f; //dimensiones de padding
                cell.PaddingLeft = 1f;
                cell.PaddingTop = 1f;
                cell.Colspan = 2;  //la celda abarcara las 13 columnas 
                table.AddCell(cell); //agrega la celda 

                cell = new PdfPCell(new Phrase(PROGRAMA.Texts, letra_gris_mas_chica));//se agregan celdas
                cell.BackgroundColor = blanco;
                cell.Border = 0;
                cell.HorizontalAlignment = Element.ALIGN_LEFT;
                cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell.PaddingBottom = 4f; //dimensiones de padding
                cell.PaddingLeft = 1f;
                cell.PaddingTop = 1f;
                cell.Colspan = 4;  //la celda abarcara las 13 columnas 
                table.AddCell(cell); //agrega la celda

                cell = new PdfPCell(new Phrase("Realiza servicios:", letra_azul_mas_chica));//se agregan celdas
                cell.BackgroundColor = blanco;
                cell.Border = 0;
                cell.HorizontalAlignment = Element.ALIGN_RIGHT;
                cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell.PaddingBottom = 4f; //dimensiones de padding
                cell.PaddingLeft = 1f;
                cell.PaddingTop = 1f;
                cell.Colspan = 2;  //la celda abarcara las 13 columnas 
                table.AddCell(cell); //agrega la celda

                cell = new PdfPCell(new Phrase(NOMBRE_TEC.Texts, letra_gris_mas_chica));//se agregan celdas
                cell.BackgroundColor = blanco;
                cell.Border = 0;
                cell.HorizontalAlignment = Element.ALIGN_LEFT;
                cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell.PaddingBottom = 4f; //dimensiones de padding
                cell.PaddingLeft = 1f;
                cell.PaddingTop = 1f;
                cell.Colspan = 5;  //la celda abarcara las 13 columnas 
                table.AddCell(cell); //agrega la celda

                doc.Add(table); //agrega la tabla 
            }
            catch { }

            //LINEA
            try
            {
                PdfPTable table = new PdfPTable(13);//total de columnas del formato
                table.TotalWidth = 500f;
                table.LockedWidth = true;
                table.SpacingBefore = 1;//Espacio de escritura hacia arriba
                table.SpacingAfter = 0;//espacio despues

                PdfPCell cell = new PdfPCell(new Phrase("", letra_azul_grande));//se agregan celdas
                cell.BackgroundColor = blanco;
                cell.Border = 0;
                cell.HorizontalAlignment = Element.ALIGN_RIGHT;
                cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell.PaddingBottom = 4f; //dimensiones de padding
                cell.PaddingLeft = 1f;
                cell.PaddingTop = 1f;
                cell.Colspan = 2;  //la celda abarcara las 13 columnas 
                table.AddCell(cell); //agrega la celda 

                cell = new PdfPCell(new Phrase("", letra_naranja));//se agregan celdas
                cell.BackgroundColor = gris_oscuro;
                cell.Border = 0;
                cell.HorizontalAlignment = Element.ALIGN_LEFT;
                cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell.PaddingBottom = 4f; //dimensiones de padding
                cell.PaddingLeft = 1f;
                cell.PaddingTop = 1f;
                cell.Colspan = 4;  //la celda abarcara las 13 columnas 
                table.AddCell(cell); //agrega la celda

                cell = new PdfPCell(new Phrase("", letra_azul_chica));//se agregan celdas
                cell.BackgroundColor = blanco;
                cell.Border = 0;
                cell.HorizontalAlignment = Element.ALIGN_LEFT;
                cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell.PaddingBottom = 4f; //dimensiones de padding
                cell.PaddingLeft = 1f;
                cell.PaddingTop = 1f;
                cell.Colspan = 2;  //la celda abarcara las 13 columnas 
                table.AddCell(cell); //agrega la celda

                cell = new PdfPCell(new Phrase("", letra_gris));//se agregan celdas
                cell.BackgroundColor = gris_oscuro;
                cell.Border = 0;
                cell.HorizontalAlignment = Element.ALIGN_LEFT;
                cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell.PaddingBottom = 4f; //dimensiones de padding
                cell.PaddingLeft = 1f;
                cell.PaddingTop = 1f;
                cell.Colspan = 5;  //la celda abarcara las 13 columnas 
                table.AddCell(cell); //agrega la celda

                doc.Add(table); //agrega la tabla 
            }
            catch { }

            //ESPECIFICACIONES TÉCNICAS
            try
            {
                PdfPTable table = new PdfPTable(13);//total de columnas del formato
                table.TotalWidth = 500f;
                table.LockedWidth = true;
                table.SpacingBefore = 2;//Espacio de escritura hacia arriba
                table.SpacingAfter = 0;//espacio despues

                PdfPCell cell = new PdfPCell(new Phrase("ESPECIFICACIONES TÉCNICAS DEL SERVICIO", letra_azul_8));//se agregan celdas
                cell.BackgroundColor = blanco;
                cell.Border = 0;
                cell.HorizontalAlignment = Element.ALIGN_LEFT;
                cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell.PaddingBottom = 4f; //dimensiones de padding
                cell.PaddingLeft = 1f;
                cell.PaddingTop = 1f;
                cell.FixedHeight = 23f;
                cell.Colspan = 13;  //la celda abarcara las 13 columnas 
                table.AddCell(cell); //agrega la celda 

                doc.Add(table); //agrega la tabla 
            }
            catch { }

            //LINEA
            try
            {
                PdfPTable table = new PdfPTable(13);//total de columnas del formato
                table.TotalWidth = 500f;
                table.LockedWidth = true;
                table.SpacingBefore = 1;//Espacio de escritura hacia arriba
                table.SpacingAfter = 0;//espacio despues

                PdfPCell cell = new PdfPCell(new Phrase("", letra_azul_grande));//se agregan celdas
                cell.BackgroundColor = naranja_liec;
                cell.Border = 0;
                cell.HorizontalAlignment = Element.ALIGN_RIGHT;
                cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell.PaddingBottom = 4f; //dimensiones de padding
                cell.PaddingLeft = 1f;
                cell.PaddingTop = 1f;
                cell.FixedHeight = 0.5f;
                cell.Colspan = 1;  //la celda abarcara las 13 columnas 
                table.AddCell(cell); //agrega la celda 

                cell = new PdfPCell(new Phrase("", letra_naranja));//se agregan celdas
                cell.BackgroundColor = azul_liec;
                cell.Border = 0;
                cell.HorizontalAlignment = Element.ALIGN_LEFT;
                cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell.PaddingBottom = 4f; //dimensiones de padding
                cell.PaddingLeft = 1f;
                cell.PaddingTop = 1f;
                cell.FixedHeight = 0.5f;
                cell.Colspan = 12;  //la celda abarcara las 13 columnas 
                table.AddCell(cell); //agrega la celda

                doc.Add(table); //agrega la tabla 
            }
            catch { }

            //LA CALIFICACION
            try
            {
                PdfPTable table = new PdfPTable(13);//total de columnas del formato
                table.TotalWidth = 500f;
                table.LockedWidth = true;
                table.SpacingBefore = 3;//Espacio de escritura hacia arriba
                table.SpacingAfter = 0;//espacio despues



                PdfPCell cell = new PdfPCell(new Phrase("La prueba se llevará a acabo de acuerdo con Estándares", letra_azul_mas_chica));//se agregan celdas
                cell.BackgroundColor = blanco;
                cell.Border = 0;
                cell.HorizontalAlignment = Element.ALIGN_LEFT;
                cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell.PaddingBottom = 4f; //dimensiones de padding
                cell.PaddingLeft = 1f;
                cell.PaddingTop = 1f;
                cell.Colspan = 5;  //la celda abarcara las 13 columnas 
                table.AddCell(cell); //agrega la celda

                cell = new PdfPCell(new Phrase(NAM.Texts, letra_gris_mas_mas_chica));//se agregan celdas
                cell.BackgroundColor = blanco;
                cell.Border = 0;
                cell.HorizontalAlignment = Element.ALIGN_LEFT;
                cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell.PaddingBottom = 4f; //dimensiones de padding
                cell.PaddingLeft = 1f;
                cell.PaddingTop = 1f;
                cell.Colspan = 1;  //la celda abarcara las 13 columnas 
                table.AddCell(cell); //agrega la celda



                cell = new PdfPCell(new Phrase("En caso de NO, especificar a continuación", letra_azul_mas_chica_normal));//se agregan celdas
                cell.BackgroundColor = blanco;
                cell.Border = 0;
                cell.HorizontalAlignment = Element.ALIGN_RIGHT;
                cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell.PaddingBottom = 4f; //dimensiones de padding
                cell.PaddingLeft = 1f;
                cell.PaddingTop = 1f;
                cell.Colspan = 4;  //la celda abarcara las 13 columnas 
                table.AddCell(cell); //agrega la celda 


                cell = new PdfPCell(new Phrase("  \n   ", letra_azul_mas_chica_normal));//se agregan celdas
                cell.BackgroundColor = blanco;
                cell.BorderColor = gris_oscuro;
                cell.HorizontalAlignment = Element.ALIGN_LEFT;
                cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell.PaddingBottom = 4f; //dimensiones de padding
                cell.PaddingLeft = 1f;
                cell.PaddingTop = 1f;
                cell.Colspan = 3;  //la celda abarcara las 13 columnas 
                table.AddCell(cell); //agrega la celda 


                doc.Add(table); //agrega la tabla 
            }
            catch { }

            //SE CUENTA
            try
            {
                PdfPTable table = new PdfPTable(13);//total de columnas del formato
                table.TotalWidth = 500f;
                table.LockedWidth = true;
                table.SpacingBefore = 1;//Espacio de escritura hacia arriba
                table.SpacingAfter = 0;//espacio despues


                PdfPCell cell = new PdfPCell(new Phrase("Se cuenta con la capacidad instalada para realizar el servicio", letra_azul_mas_chica));//se agregan celdas
                cell.BackgroundColor = blanco;
                cell.Border = 0;
                cell.HorizontalAlignment = Element.ALIGN_LEFT;
                cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell.PaddingBottom = 4f; //dimensiones de padding
                cell.PaddingLeft = 1f;
                cell.PaddingTop = 1f;
                cell.Colspan = 5;  //la celda abarcara las 13 columnas 
                table.AddCell(cell); //agrega la celda

                cell = new PdfPCell(new Phrase(NAM.Texts, letra_gris_mas_mas_chica));//se agregan celdas
                cell.BackgroundColor = blanco;
                cell.Border = 0;
                cell.HorizontalAlignment = Element.ALIGN_LEFT;
                cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell.PaddingBottom = 4f; //dimensiones de padding
                cell.PaddingLeft = 1f;
                cell.PaddingTop = 1f;
                cell.Colspan = 8;  //la celda abarcara las 13 columnas 
                table.AddCell(cell); //agrega la celda





                doc.Add(table); //agrega la tabla 
            }
            catch { }



            //PROPIEDAD DEL INFORME
            try
            {
                PdfPTable table = new PdfPTable(13);//total de columnas del formato
                table.TotalWidth = 500f;
                table.LockedWidth = true;
                table.SpacingBefore = 4;//Espacio de escritura hacia arriba
                table.SpacingAfter = 0;//espacio despues

                PdfPCell cell = new PdfPCell(new Phrase("Propiedad del Informe:", letra_azul_mas_chica));//se agregan celdas
                cell.BackgroundColor = blanco;
                cell.Border = 0;
                cell.HorizontalAlignment = Element.ALIGN_LEFT;
                cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell.PaddingBottom = 4f; //dimensiones de padding
                cell.PaddingLeft = 1f;
                cell.PaddingTop = 1f;
                cell.Colspan = 3;  //la celda abarcara las 13 columnas 
                table.AddCell(cell); //agrega la celda 

                cell = new PdfPCell(new Phrase(PROPIEDAD.Texts, letra_gris_mas_chica));//se agregan celdas
                cell.BackgroundColor = blanco;
                cell.Border = 0;
                cell.HorizontalAlignment = Element.ALIGN_LEFT;
                cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell.PaddingBottom = 4f; //dimensiones de padding
                cell.PaddingLeft = 1f;
                cell.PaddingTop = 1f;
                cell.Colspan = 10;  //la celda abarcara las 13 columnas 
                table.AddCell(cell); //agrega la celda             

                doc.Add(table); //agrega la tabla 
            }
            catch { }

            //LINEA
            try
            {
                PdfPTable table = new PdfPTable(13);//total de columnas del formato
                table.TotalWidth = 500f;
                table.LockedWidth = true;
                table.SpacingBefore = 1;//Espacio de escritura hacia arriba
                table.SpacingAfter = 0;//espacio despues

                PdfPCell cell = new PdfPCell(new Phrase("", letra_azul_chica));//se agregan celdas
                cell.BackgroundColor = blanco;
                cell.Border = 0;
                cell.HorizontalAlignment = Element.ALIGN_LEFT;
                cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell.PaddingBottom = 4f; //dimensiones de padding
                cell.PaddingLeft = 1f;
                cell.PaddingTop = 1f;
                cell.Colspan = 2;  //la celda abarcara las 13 columnas 
                table.AddCell(cell); //agrega la celda 

                cell = new PdfPCell(new Phrase("", letra_azul_chica));//se agregan celdas
                cell.BackgroundColor = gris_oscuro;
                cell.Border = 0;
                cell.HorizontalAlignment = Element.ALIGN_JUSTIFIED;
                cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell.PaddingBottom = 4f; //dimensiones de padding
                cell.PaddingLeft = 1f;
                cell.PaddingTop = 1f;
                cell.Colspan = 11;  //la celda abarcara las 13 columnas 
                table.AddCell(cell); //agrega la celda

                doc.Add(table); //agrega la tabla 
            }
            catch { }

            //BAJO RESGUARDO DE 
            try
            {
                PdfPTable table = new PdfPTable(13);//total de columnas del formato
                table.TotalWidth = 500f;
                table.LockedWidth = true;
                table.SpacingBefore = 1;//Espacio de escritura hacia arriba
                table.SpacingAfter = 0;//espacio despues

                PdfPCell cell = new PdfPCell(new Phrase("Bajo resguardo de:", letra_azul_mas_chica));//se agregan celdas
                cell.BackgroundColor = blanco;
                cell.Border = 0;
                cell.HorizontalAlignment = Element.ALIGN_LEFT;
                cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell.PaddingBottom = 4f; //dimensiones de padding
                cell.PaddingLeft = 1f;
                cell.PaddingTop = 1f;
                cell.Colspan = 3;  //la celda abarcara las 13 columnas 
                table.AddCell(cell); //agrega la celda 

                cell = new PdfPCell(new Phrase(RESGUARDO.Texts, letra_gris_mas_chica));//se agregan celdas
                cell.BackgroundColor = blanco;
                cell.Border = 0;
                cell.HorizontalAlignment = Element.ALIGN_LEFT;
                cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell.PaddingBottom = 4f; //dimensiones de padding
                cell.PaddingLeft = 1f;
                cell.PaddingTop = 1f;
                cell.Colspan = 2;  //la celda abarcara las 13 columnas 
                table.AddCell(cell); //agrega la celda             

                cell = new PdfPCell(new Phrase("Informe en Minutarios:", letra_azul_mas_chica));//se agregan celdas
                cell.BackgroundColor = blanco;
                cell.Border = 0;
                cell.HorizontalAlignment = Element.ALIGN_RIGHT;
                cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell.PaddingBottom = 4f; //dimensiones de padding
                cell.PaddingLeft = 1f;
                cell.PaddingTop = 1f;
                cell.Colspan = 3;  //la celda abarcara las 13 columnas 
                table.AddCell(cell); //agrega la celda             

                cell = new PdfPCell(new Phrase("OBRAS VARIAS 2025", letra_gris_mas_chica));//se agregan celdas
                cell.BackgroundColor = blanco;
                cell.Border = 0;
                cell.HorizontalAlignment = Element.ALIGN_LEFT;
                cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell.PaddingBottom = 4f; //dimensiones de padding
                cell.PaddingLeft = 1f;
                cell.PaddingTop = 1f;
                cell.Colspan = 2;  //la celda abarcara las 13 columnas 
                table.AddCell(cell); //agrega la celda         



                cell = new PdfPCell(new Phrase("Clave de Obra:", letra_azul_mas_chica));//se agregan celdas
                cell.BackgroundColor = blanco;
                cell.Border = 0;
                cell.HorizontalAlignment = Element.ALIGN_RIGHT;
                cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell.PaddingBottom = 4f; //dimensiones de padding
                cell.PaddingLeft = 1f;
                cell.PaddingTop = 1f;
                cell.Colspan = 2;  //la celda abarcara las 13 columnas 
                table.AddCell(cell); //agrega la celda             

                cell = new PdfPCell(new Phrase(clave_obra.Texts, letra_naranja));//se agregan celdas
                cell.BackgroundColor = blanco;
                cell.Border = 0;
                cell.HorizontalAlignment = Element.ALIGN_LEFT;
                cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell.PaddingBottom = 4f; //dimensiones de padding
                cell.PaddingLeft = 1f;
                cell.PaddingTop = 1f;
                cell.Colspan = 1;  //la celda abarcara las 13 columnas 
                table.AddCell(cell); //agrega la celda         


                doc.Add(table); //agrega la tabla 
            }
            catch { }

            //LINEA
            try
            {
                PdfPTable table = new PdfPTable(13);//total de columnas del formato
                table.TotalWidth = 500f;
                table.LockedWidth = true;
                table.SpacingBefore = 1;//Espacio de escritura hacia arriba
                table.SpacingAfter = 10;//espacio despues

                PdfPCell cell = new PdfPCell(new Phrase("", letra_azul_chica));//se agregan celdas
                cell.BackgroundColor = blanco;
                cell.Border = 0;
                cell.HorizontalAlignment = Element.ALIGN_LEFT;
                cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell.PaddingBottom = 4f; //dimensiones de padding
                cell.PaddingLeft = 1f;
                cell.PaddingTop = 1f;
                cell.Colspan = 2;  //la celda abarcara las 13 columnas 
                table.AddCell(cell); //agrega la celda 

                cell = new PdfPCell(new Phrase("", letra_azul_chica));//se agregan celdas
                cell.BackgroundColor = gris_oscuro;
                cell.Border = 0;
                cell.HorizontalAlignment = Element.ALIGN_JUSTIFIED;
                cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell.PaddingBottom = 4f; //dimensiones de padding
                cell.PaddingLeft = 1f;
                cell.PaddingTop = 1f;
                cell.Colspan = 4;  //la celda abarcara las 13 columnas 
                table.AddCell(cell); //agrega la celda

                cell = new PdfPCell(new Phrase("", letra_azul_chica));//se agregan celdas
                cell.BackgroundColor = blanco;
                cell.Border = 0;
                cell.HorizontalAlignment = Element.ALIGN_JUSTIFIED;
                cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell.PaddingBottom = 4f; //dimensiones de padding
                cell.PaddingLeft = 1f;
                cell.PaddingTop = 1f;
                cell.Colspan = 2;  //la celda abarcara las 13 columnas 
                table.AddCell(cell); //agrega la celda

                cell = new PdfPCell(new Phrase("", letra_azul_chica));//se agregan celdas
                cell.BackgroundColor = gris_oscuro;
                cell.Border = 0;
                cell.HorizontalAlignment = Element.ALIGN_JUSTIFIED;
                cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell.PaddingBottom = 4f; //dimensiones de padding
                cell.PaddingLeft = 1f;
                cell.PaddingTop = 1f;
                cell.Colspan = 2;  //la celda abarcara las 13 columnas 
                table.AddCell(cell); //agrega la celda

                cell = new PdfPCell(new Phrase("", letra_azul_chica));//se agregan celdas
                cell.BackgroundColor = blanco;
                cell.Border = 0;
                cell.HorizontalAlignment = Element.ALIGN_JUSTIFIED;
                cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell.PaddingBottom = 4f; //dimensiones de padding
                cell.PaddingLeft = 1f;
                cell.PaddingTop = 1f;
                cell.Colspan = 2;  //la celda abarcara las 13 columnas 
                table.AddCell(cell); //agrega la celda

                cell = new PdfPCell(new Phrase("", letra_azul_chica));//se agregan celdas
                cell.BackgroundColor = gris_oscuro;
                cell.Border = 0;
                cell.HorizontalAlignment = Element.ALIGN_JUSTIFIED;
                cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell.PaddingBottom = 4f; //dimensiones de padding
                cell.PaddingLeft = 1f;
                cell.PaddingTop = 1f;
                cell.Colspan = 1;  //la celda abarcara las 13 columnas 
                table.AddCell(cell); //agrega la celda



                doc.Add(table); //agrega la tabla 
            }
            catch { }


            //CONCEPTOS
            try
            {
                PdfPTable table = new PdfPTable(13);//total de columnas del formato
                table.TotalWidth = 500f;
                table.LockedWidth = true;
                table.SpacingBefore = 1;//Espacio de escritura hacia arriba
                table.SpacingAfter = 0;//espacio despues

                PdfPCell cell = new PdfPCell(new Phrase("CONCEPTOS", letra_azul_8));//se agregan celdas
                cell.BackgroundColor = blanco;
                cell.Border = 0;
                cell.HorizontalAlignment = Element.ALIGN_LEFT;
                cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell.PaddingBottom = 4f; //dimensiones de padding
                cell.PaddingLeft = 1f;
                cell.PaddingTop = 1f;
                cell.Colspan = 13;  //la celda abarcara las 13 columnas 
                table.AddCell(cell); //agrega la celda 

                doc.Add(table); //agrega la tabla 
            }
            catch { }


            //LINEA
            try
            {
                PdfPTable table = new PdfPTable(13);//total de columnas del formato
                table.TotalWidth = 500f;
                table.LockedWidth = true;
                table.SpacingBefore = 1;//Espacio de escritura hacia arriba
                table.SpacingAfter = 0;//espacio despues

                PdfPCell cell = new PdfPCell(new Phrase("", letra_azul_grande));//se agregan celdas
                cell.BackgroundColor = naranja_liec;
                cell.Border = 0;
                cell.HorizontalAlignment = Element.ALIGN_RIGHT;
                cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell.PaddingBottom = 4f; //dimensiones de padding
                cell.PaddingLeft = 1f;
                cell.PaddingTop = 1f;
                cell.FixedHeight = 0.5f;
                cell.Colspan = 1;  //la celda abarcara las 13 columnas 
                table.AddCell(cell); //agrega la celda 

                cell = new PdfPCell(new Phrase("", letra_naranja));//se agregan celdas
                cell.BackgroundColor = azul_liec;
                cell.Border = 0;
                cell.HorizontalAlignment = Element.ALIGN_LEFT;
                cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell.PaddingBottom = 4f; //dimensiones de padding
                cell.PaddingLeft = 1f;
                cell.PaddingTop = 1f;
                cell.FixedHeight = 0.5f;
                cell.Colspan = 12;  //la celda abarcara las 13 columnas 
                table.AddCell(cell); //agrega la celda

                doc.Add(table); //agrega la tabla 
            }
            catch { }


            //CANTIDAD
            try
            {
                PdfPTable table = new PdfPTable(13);//total de columnas del formato
                table.TotalWidth = 500f;
                table.LockedWidth = true;
                table.SpacingBefore = 2;//Espacio de escritura hacia arriba
                table.SpacingAfter = 0;//espacio despues

                PdfPCell cell = new PdfPCell(new Phrase("Cantidad", PREGUNTAS));//se agregan celdas
                cell.BackgroundColor = blanco;
                cell.Border = 0;
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell.PaddingBottom = 4f; //dimensiones de padding
                cell.PaddingLeft = 1f;
                cell.PaddingTop = 1f;
                cell.Colspan = 1;  //la celda abarcara las 13 columnas 
                table.AddCell(cell); //agrega la celda 

                cell = new PdfPCell(new Phrase("Concepto", PREGUNTAS));//se agregan celdas
                cell.BackgroundColor = blanco;
                cell.Border = 0;
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell.PaddingBottom = 4f; //dimensiones de padding
                cell.PaddingLeft = 1f;
                cell.PaddingTop = 1f;
                cell.Colspan = 4;  //la celda abarcara las 13 columnas 
                table.AddCell(cell); //agrega la celda             

                cell = new PdfPCell(new Phrase("Alcances", PREGUNTAS));//se agregan celdas
                cell.BackgroundColor = blanco;
                cell.Border = 0;
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell.PaddingBottom = 4f; //dimensiones de padding
                cell.PaddingLeft = 1f;
                cell.PaddingTop = 1f;
                cell.Colspan = 2;  //la celda abarcara las 13 columnas 
                table.AddCell(cell); //agrega la celda 

                cell = new PdfPCell(new Phrase("Norma(s)/Estándar(es)", PREGUNTAS));//se agregan celdas
                cell.BackgroundColor = blanco;
                cell.Border = 0;
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell.PaddingBottom = 4f; //dimensiones de padding
                cell.PaddingLeft = 1f;
                cell.PaddingTop = 1f;
                cell.Colspan = 2;  //la celda abarcara las 13 columnas 
                table.AddCell(cell); //agrega la celda 

                cell = new PdfPCell(new Phrase("M.A.", PREGUNTAS));//se agregan celdas
                cell.BackgroundColor = blanco;
                cell.Border = 0;
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell.PaddingBottom = 4f; //dimensiones de padding
                cell.PaddingLeft = 1f;
                cell.PaddingTop = 1f;
                cell.Colspan = 1;  //la celda abarcara las 13 columnas 
                table.AddCell(cell); //agrega la celda 

                doc.Add(table); //agrega la tabla 

                cell = new PdfPCell(new Phrase("Tiempo Entrega", PREGUNTAS));//se agregan celdas
                cell.BackgroundColor = blanco;
                cell.Border = 0;
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell.PaddingBottom = 4f; //dimensiones de padding
                cell.PaddingLeft = 1f;
                cell.PaddingTop = 1f;
                cell.Colspan = 2;  //la celda abarcara las 13 columnas 
                table.AddCell(cell); //agrega la celda 

                cell = new PdfPCell(new Phrase("Items", PREGUNTAS));//se agregan celdas
                cell.BackgroundColor = blanco;
                cell.Border = 0;
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell.PaddingBottom = 4f; //dimensiones de padding
                cell.PaddingLeft = 1f;
                cell.PaddingTop = 1f;
                cell.Colspan = 1;  //la celda abarcara las 13 columnas 
                table.AddCell(cell); //agrega la celda 

                doc.Add(table); //agrega la tabla 


            }
            catch { }


            //LINEA
            try
            {
                PdfPTable table = new PdfPTable(13);//total de columnas del formato
                table.TotalWidth = 500f;
                table.LockedWidth = true;
                table.SpacingBefore = 1;//Espacio de escritura hacia arriba
                table.SpacingAfter = 0;//espacio despues

                PdfPCell cell = new PdfPCell(new Phrase("", PREGUNTAS));//se agregan celdas
                cell.BackgroundColor = naranja_liec;
                cell.Border = 0;
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell.PaddingBottom = 4f; //dimensiones de padding
                cell.PaddingLeft = 1f;
                cell.PaddingTop = 1f;
                cell.Colspan = 1;  //la celda abarcara las 13 columnas 
                table.AddCell(cell); //agrega la celda 

                cell = new PdfPCell(new Phrase("", PREGUNTAS));//se agregan celdas
                cell.BackgroundColor = azul_liec;
                cell.Border = 0;
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell.PaddingBottom = 4f; //dimensiones de padding
                cell.PaddingLeft = 1f;
                cell.PaddingTop = 1f;
                cell.Colspan = 12;  //la celda abarcara las 13 columnas 
                table.AddCell(cell); //agrega la celda             

                doc.Add(table); //agrega la tabla 
            }
            catch { }


            //CONCEPTOS DE FOREACH
            try
            {
                PdfPTable table = new PdfPTable(13);//total de columnas del formato
                table.TotalWidth = 500f;
                table.LockedWidth = true;
                table.SpacingBefore = 1;//Espacio de escritura hacia arriba
                table.SpacingAfter = 0;//espacio despues
                string acred = "-";

                PdfPCell cell = new PdfPCell(new Phrase("", letra_negra_mas_chica));
                foreach (DataGridViewRow row in DGV.Rows)
                {

                    string texto = row.Cells[1].Value.ToString();
                    int posicion = texto.IndexOf(".");
                    if (posicion == -1)
                        posicion = texto.Length;
                    string substring = row.Cells[1].Value.ToString().Substring(0, posicion);

                    string cant = row.Cells[3].Value.ToString();///1 CANTIDAD
                    // string CONCEPTOFINAL = substring;//// 2 CONCEPTO
                    string CONCEPTOFINAL = row.Cells[1].Value.ToString(); //concepto
                    string ALCANCE = row.Cells[7].Value.ToString(); //alcances              
                    string NORMA = row.Cells[8].Value.ToString(); //norma
                    string TIEMPO = row.Cells[9].Value.ToString(); //tiempo entrega
                    string informe = row.Cells[10].Value.ToString(); //INFORME

                    acred = "-"; //ACRED

                    MySqlConnection CONEXION = conexion.USR;

                    MySqlCommand comando = new MySqlCommand("SELECT ACREDITADO FROM  servicios_eventuales WHERE clave = '" + row.Cells[6].Value.ToString() + "'", CONEXION);

                    CONEXION.Open();
                    MySqlDataReader consulta = comando.ExecuteReader();
                    while (consulta.Read())
                    {
                        acred = consulta.IsDBNull(0) ? String.Empty : consulta.GetString(0);

                    }
                    CONEXION.Close();





                    //   string ALCANCE = "ALCANCES";//3 ALCANCES
                    //string NORMA = "NORMA";//4 NORMA
                    //string TIEMPO = "TIEMPO"; /// 5 TIEMPO
                    //string informe = "informe";// 6 INFORME

                    cell = new PdfPCell(new Phrase(cant, FOREACH));//se agregan celdas
                    cell.BackgroundColor = blanco;
                    cell.Border = 0;
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                    cell.PaddingBottom = 4f; //dimensiones de padding
                    cell.PaddingLeft = 1f;
                    cell.PaddingTop = 1f;
                    cell.Colspan = 1;  //la celda abarcara las 13 columnas 
                    table.AddCell(cell); //agrega la celda 

                    cell = new PdfPCell(new Phrase(substring, FOREACH));//se agregan celdas
                    cell.BackgroundColor = blanco;
                    cell.Border = 0;
                    cell.HorizontalAlignment = Element.ALIGN_JUSTIFIED;
                    cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                    cell.PaddingBottom = 4f; //dimensiones de padding
                    cell.PaddingLeft = 1f;
                    cell.PaddingTop = 1f;
                    cell.Colspan = 4;  //la celda abarcara las 13 columnas 
                    table.AddCell(cell); //agrega la celda             

                    cell = new PdfPCell(new Phrase(ALCANCE, FOREACH));//se agregan celdas
                    cell.BackgroundColor = blanco;
                    cell.Border = 0;
                    cell.HorizontalAlignment = Element.ALIGN_JUSTIFIED;
                    cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                    cell.PaddingBottom = 4f; //dimensiones de padding
                    cell.PaddingLeft = 1f;
                    cell.PaddingTop = 1f;
                    cell.Colspan = 2;  //la celda abarcara las 13 columnas 
                    table.AddCell(cell); //agrega la celda 

                    cell = new PdfPCell(new Phrase(NORMA, FOREACH));//se agregan celdas
                    cell.BackgroundColor = blanco;
                    cell.Border = 0;
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                    cell.PaddingBottom = 4f; //dimensiones de padding
                    cell.PaddingLeft = 1f;
                    cell.PaddingTop = 1f;
                    cell.Colspan = 2;  //la celda abarcara las 13 columnas 
                    table.AddCell(cell); //agrega la celda 

                    cell = new PdfPCell(new Phrase(acred, FOREACH));//se agregan celdas
                    cell.BackgroundColor = blanco;
                    cell.Border = 0;
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                    cell.PaddingBottom = 4f; //dimensiones de padding
                    cell.PaddingLeft = 1f;
                    cell.PaddingTop = 1f;
                    cell.Colspan = 1;  //la celda abarcara las 13 columnas 
                    table.AddCell(cell); //agrega la celda 

                    cell = new PdfPCell(new Phrase(TIEMPO, FOREACH));//se agregan celdas
                    cell.BackgroundColor = blanco;
                    cell.Border = 0;
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                    cell.PaddingBottom = 4f; //dimensiones de padding
                    cell.PaddingLeft = 1f;
                    cell.PaddingTop = 1f;
                    cell.Colspan = 2;  //la celda abarcara las 13 columnas 
                    table.AddCell(cell); //agrega la celda 

                    cell = new PdfPCell(new Phrase(informe, FOREACH));//se agregan celdas
                    cell.BackgroundColor = blanco;
                    cell.Border = 0;
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                    cell.PaddingBottom = 4f; //dimensiones de padding
                    cell.PaddingLeft = 1f;
                    cell.PaddingTop = 1f;
                    cell.Colspan = 1;  //la celda abarcara las 13 columnas 
                    table.AddCell(cell); //agrega la celda 



                }



                doc.Add(table); //agrega la tabla 

            }
            catch { }






            //ANEXOS
            try
            {
                PdfPTable table = new PdfPTable(13);//total de columnas del formato
                table.TotalWidth = 500f;
                table.LockedWidth = true;
                table.SpacingBefore = 5;//Espacio de escritura hacia arriba
                table.SpacingAfter = 5;//espacio despues

                PdfPCell cell = new PdfPCell(new Phrase(" Observaciones", letra_azul_mas_chica));//se agregan celdas
                cell.BackgroundColor = blanco;
                cell.Border = 0;
                cell.HorizontalAlignment = Element.ALIGN_LEFT;
                cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell.PaddingBottom = 4f; //dimensiones de padding
                cell.PaddingLeft = 1f;
                cell.PaddingTop = 1f;
                cell.Colspan = 2;  //la celda abarcara las 13 columnas 
                table.AddCell(cell); //agrega la celda 

                cell = new PdfPCell(new Phrase(OBSERVACIONES.Texts + "  \n    \n  ", letra_azul_mas_chica));//se agregan celdas
                cell.BackgroundColor = blanco;
                cell.BorderColor = gris_claro;
                cell.HorizontalAlignment = Element.ALIGN_LEFT;
                cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell.PaddingBottom = 4f; //dimensiones de padding
                cell.PaddingLeft = 1f;
                cell.PaddingTop = 1f;
                cell.Colspan = 11;  //la celda abarcara las 13 columnas 
                table.AddCell(cell); //agrega la celda             



                doc.Add(table); //agrega la tabla 
            }
            catch { }













            //FIRMA
            try
            {
                PdfPTable table = new PdfPTable(13);
                table.TotalWidth = 500f;
                table.LockedWidth = true;
                table.HorizontalAlignment = 1; //0=Left, 1=Centre, 2=Right

                PdfPCell points = new PdfPCell(new Phrase("and is therefore entitled to 2 points", letra_azul_grande));
                points.Colspan = 2;
                points.Border = 0;
                points.PaddingTop = 40f;
                points.HorizontalAlignment = 1;//0=Left, 1=Centre, 2=Right

                // add a image
                iTextSharp.text.Image jpg = iTextSharp.text.Image.GetInstance(@"A:\FIRMAS\ASOLIS.png");
                PdfPCell imageCell = new PdfPCell(jpg);
                imageCell.Colspan = 4; // either 1 if you need to insert one cell
                imageCell.Border = 0;
                imageCell.HorizontalAlignment = Element.ALIGN_CENTER;
                imageCell.BackgroundColor = blanco;

                jpg.ScalePercent(9f);
                jpg.SetAbsolutePosition(250, 100);
                /*   jpg.ScaleAbsoluteWidth(90);
                   jpg.ScaleAbsoluteHeight(50);
                   jpg.SetAbsolutePosition(255, 150);*/
                //    table.AddCell(points);
                // add a image
                table.AddCell(imageCell);



                PdfPCell cell = new PdfPCell(new Phrase("\r\n────────────────\r\n" + NOMBRE_TEC.Texts, letra_negra_mas_chica_normal));//se agregan celdas
                cell.BackgroundColor = blanco;
                cell.Border = 0;
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                cell.VerticalAlignment = Element.ALIGN_BOTTOM;
                cell.PaddingBottom = 4f; //dimensiones de padding
                cell.PaddingLeft = 1f;
                cell.PaddingTop = 1f;
                cell.Colspan = 4;  //la celda abarcara las 13 columnas 
                table.AddCell(cell); //agrega la celda             



                cell = new PdfPCell(new Phrase(NOMBRE.Texts, letra_negra_mas_chica_normal));//se agregan celdas
                cell.BackgroundColor = blanco;
                cell.Border = 0;
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                cell.VerticalAlignment = Element.ALIGN_BOTTOM;
                cell.PaddingBottom = 4f; //dimensiones de padding
                cell.PaddingLeft = 1f;
                cell.PaddingTop = 1f;
                cell.Colspan = 5;  //la celda abarcara las 13 columnas 
                table.AddCell(cell); //agrega la celda 

                doc.Add(table);
            }
            catch { }











            //LEYENDA DE FIRMA
            try
            {
                PdfPTable table = new PdfPTable(13);//total de columnas del formato
                table.TotalWidth = 500f;
                table.LockedWidth = true;
                table.SpacingBefore = 1;//Espacio de escritura hacia arriba
                table.SpacingAfter = 0;//espacio despues

                PdfPCell cell = new PdfPCell(new Phrase("AUTORIZA SOLICITUD DE SERVICIO", letra_azul_mas_mas_chica));//se agregan celdas
                cell.BackgroundColor = blanco;
                cell.Border = 0;
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell.PaddingBottom = 4f; //dimensiones de padding
                cell.PaddingLeft = 1f;
                cell.PaddingTop = 1f;
                cell.Colspan = 4;  //la celda abarcara las 13 columnas 
                table.AddCell(cell); //agrega la celda 

                cell = new PdfPCell(new Phrase("TÉCNICO DE SERVICIO", letra_azul_mas_mas_chica));//se agregan celdas
                cell.BackgroundColor = blanco;
                cell.Border = 0;
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell.PaddingBottom = 4f; //dimensiones de padding
                cell.PaddingLeft = 1f;
                cell.PaddingTop = 1f;
                cell.Colspan = 4;  //la celda abarcara las 13 columnas 
                table.AddCell(cell); //agrega la celda             

                cell = new PdfPCell(new Phrase("NOMBRE Y FIRMA DE ACEPTACIÓN DEL CLIENTE", letra_azul_mas_mas_chica));//se agregan celdas
                cell.BackgroundColor = blanco;
                cell.Border = 0;
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell.PaddingBottom = 4f; //dimensiones de padding
                cell.PaddingLeft = 1f;
                cell.PaddingTop = 1f;
                cell.Colspan = 5;  //la celda abarcara las 13 columnas 
                table.AddCell(cell); //agrega la celda 

                doc.Add(table); //agrega la tabla 
            }
            catch { }




            //EL LABORATORIO NO REALIZA...
            try
            {
                PdfPTable table = new PdfPTable(13);//total de columnas del formato
                table.TotalWidth = 500f;
                table.LockedWidth = true;
                table.SpacingBefore = 2;//Espacio de escritura hacia arriba
                table.SpacingAfter = 0;//espacio despues

                PdfPCell cell = new PdfPCell(new Phrase("El laboratorio no realiza declaración de conformidad, únicamente incluye una leyenda de interpretación de resultados.", letra_negra_mas_chica_5));//se agregan celdas
                cell.BackgroundColor = blanco;
                cell.Border = 0;
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell.PaddingBottom = 4f; //dimensiones de padding
                cell.PaddingLeft = 1f;
                cell.PaddingTop = 1f;
                cell.FixedHeight = 23f;
                cell.Colspan = 13;  //la celda abarcara las 13 columnas 
                table.AddCell(cell); //agrega la celda 

                doc.Add(table); //agrega la tabla 
            }
            catch { }




            //EL LABORATORIO DE ENSAYE...
            try
            {
                PdfPTable table = new PdfPTable(4);
                table.TotalWidth = 500f;
                table.HorizontalAlignment = Element.ALIGN_CENTER;
                table.SpacingBefore = 1;//Espacio de escritura hacia arriba

                PdfPCell cell;
                cell = new PdfPCell(new Phrase("EL LABORATORIO DE ENSAYE LIEC S.A. DE C.V., está acreditado por la Entidad Mexicana de Acreditación A.C. en las áreas de: Concreto (ASTM C172/C172M − 14a, ASTM C31/C31M − 15a, ASTM C143/C143M − 15a, ASTM C138/C138M − 16a, ASTM C617/C617M − 15, ASTM C39/C39M − 16b, ASTM C469/C469M − 14, ASTM C1064/C1064M-17, ASTM C173/C173M-16, MC-23, ASTM C42/C42M-18a y ASTM C78/C78M-18, ASTM C1202-19), Geotecnia (ASTM D2488 − 09a, ASTM C702/C702M − 11, ASTM D2216 − 10, ASTM D698 − 12, ASTM D1557 − 12, ASTM D4959-16 y ASTM D1556/D1556M − 15, ASTM D1883-16, ASTM D2419-14, ASTM D4318-17e1, ASTM C136/C136M-14 y ASTM C117-17, ASTM C131/C131M-20), Agregados (ASTM D75/D75M-14) y Asfaltos (ASTM D 979-15, ASTM D 6927-15, ASTM D 2172-11, ASTM D 5444-15, ASTM D 1188-07(15) y MA-07-21, ASTM D6928-17) con la 'Acreditación No.C - 0120 - 015 / 12 VIGENTE A PARTIR DE: 2012 - 01 - 27' y en el área de Metal Mecánica (ASTM A615/A615M − 16, ASTM E8/E8M − 16a, ASTM A370 − 17, ASTM E290 − 14 y ASTM E165/E165M-12 AWS D1.1/D1.1M:2015, ASTM E164 – 19/ AWS D1.1/D1.1M:2015) con la “Acreditación No. MM-0791-117-16 VIGENTE A PARTIR DE: 2016-12-09. Para mayor información consulta www.ema.org.mx", letra_leyenda_final));
                cell.Border = 0;
                cell.Colspan = 3;
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                table.AddCell(cell);


                //AQUI VA EL LOGO
                cell = new PdfPCell(CODIGO_QR);
                cell.Rowspan = 2;  //hacia abajo dos 
                cell.Colspan = 1;
                cell.Border = 0;
                CODIGO_QR.ScalePercent(18f);
                cell.HorizontalAlignment = Element.ALIGN_RIGHT;
                table.AddCell(cell);

                doc.Add(table);

            }
            catch { }






            //EL LABORATORIO DE ENSAYE...
            try
            {
                /*  PdfPTable table = new PdfPTable(13);//total de columnas del formato
                  table.TotalWidth = 500f;
                  table.LockedWidth = true;
                  table.SpacingBefore = 3;//Espacio de escritura hacia arriba
                  table.SpacingAfter = 0;//espacio despues
                  table.HorizontalAlignment = Element.ALIGN_CENTER;

                  PdfPCell cell = new PdfPCell(new Phrase("EL LABORATORIO DE ENSAYE LIEC S.A. DE C.V., está acreditado por la Entidad Mexicana de Acreditación A.C. en las áreas de: Concreto (ASTM C172/C172M − 14a, ASTM C31/C31M − 15a, ASTM C143/C143M − 15a, ASTM C138/C138M − 16a, ASTM C617/C617M − 15, ASTM C39/C39M − 16b, ASTM C469/C469M − 14, ASTM C1064/C1064M-17, ASTM C173/C173M-16, MC-23, ASTM C42/C42M-18a y ASTM C78/C78M-18, ASTM C1202-19), Geotecnia (ASTM D2488 − 09a, ASTM C702/C702M − 11, ASTM D2216 − 10, ASTM D698 − 12, ASTM D1557 − 12, ASTM D4959-16 y ASTM D1556/D1556M − 15, ASTM D1883-16, ASTM D2419-14, ASTM D4318-17e1, ASTM C136/C136M-14 y ASTM C117-17, ASTM C131/C131M-20), Agregados (ASTM D75/D75M-14) y Asfaltos (ASTM D 979-15, ASTM D 6927-15, ASTM D 2172-11, ASTM D 5444-15, ASTM D 1188-07(15) y MA-07-21, ASTM D6928-17) con la 'Acreditación No.C - 0120 - 015 / 12 VIGENTE A PARTIR DE: 2012 - 01 - 27' y en el área de Metal Mecánica (ASTM A615/A615M − 16, ASTM E8/E8M − 16a, ASTM A370 − 17, ASTM E290 − 14 y ASTM E165/E165M-12 AWS D1.1/D1.1M:2015, ASTM E164 – 19/ AWS D1.1/D1.1M:2015) con la “Acreditación No. MM-0791-117-16 VIGENTE A PARTIR DE: 2016-12-09.", letra_leyenda_final));//se agregan celdas       
                  cell.Border = 0;
                  cell.HorizontalAlignment = Element.ALIGN_CENTER;
                  cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                  cell.PaddingBottom = 4f; //dimensiones de padding
                  cell.PaddingLeft = 1f;
                  cell.PaddingTop = 1f;
                  cell.Colspan = 11;  //la celda abarcara las 13 columnas 
                  table.AddCell(cell); //agrega la celda 

                  cell = new PdfPCell(new Phrase("", letra_azul_mas_mas_chica));//se agregan celdas
                  cell.Border = 0;
                  cell.HorizontalAlignment = Element.ALIGN_CENTER;
                  cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                  cell.PaddingBottom = 4f; //dimensiones de padding
                  cell.PaddingLeft = 1f;
                  cell.PaddingTop = 1f;
                  cell.Colspan = 2;  //la celda abarcara las 13 columnas 
                  table.AddCell(cell); //agrega la celda 

                  doc.Add(table); //agrega la tabla */
            }
            catch { }















            doc.Close();
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {












        }

        private void EMPRESA_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*NOMBRE.Texts = "";
            MySqlConnection CONEXION1 = conexion.USR;
            MySqlCommand comando = new MySqlCommand("SELECT DISTINCTROW Nombre_completo FROM clientes_registrados WHERE Empresa= '" + EMPRESA.Texts + "' ORDER BY Nombre_completo ASC", CONEXION1);

            CONEXION1.Open();
            MySqlDataReader registro = comando.ExecuteReader();

            while (registro.Read())
            {

                NOMBRE.Texts = (registro["Nombre_completo"].ToString());

            }

            CONEXION1.Close();

            MessageBox.Show("Se han cargado Personas involucradas con esta razón social");*/
        }

        private void altoButton1_Click(object sender, EventArgs e)
        {
            estado();
        }

        private void ESTADO_OnSelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void solidGauge1_ChildChanged(object sender, System.Windows.Forms.Integration.ChildChangedEventArgs e)
        {

        }

        private void NAM_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            /*  if (NAM.Texts == "OTRO") { ESP_NAM.Visible = true; label6.Visible = true; }
              else { ESP_NAM.Visible = false; label6.Visible = false; }*/
        }

        private void NOMBRE_TEC_OnSelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_MouseLeave(object sender, EventArgs e)
        {
            label1.ForeColor = System.Drawing.Color.FromArgb(16, 77, 141);
        }


        private void consultaclaves()
        {
            DialogResult dl = MessageBox.Show("¿Cargar ultima OT?", "Notificación de Operación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dl == DialogResult.Yes)
            {
                if (desde_pnd == true)
                {
                    TABLA.DataSource = conexion_servicios_eventuales.Consultageneral("SELECT * FROM ordenes_trabajo_pnd WHERE CLAVE_OBRA = '" + clave_obra.Texts + "' ORDER BY ID_SEGUIMIENTO DESC"); ;

                    if (TABLA.RowCount > 0)
                    {
                        NOMBRE.Texts = TABLA.Rows[0].Cells[3].Value.ToString();
                        EMPRESA.Texts = TABLA.Rows[0].Cells[4].Value.ToString();

                        CODIGO_POSTAL.Texts = TABLA.Rows[0].Cells[6].Value.ToString();
                        TELEFONO.Texts = TABLA.Rows[0].Cells[7].Value.ToString();
                        RFC.Texts = TABLA.Rows[0].Cells[8].Value.ToString();
                        EMAIL.Texts = TABLA.Rows[0].Cells[9].Value.ToString();
                        NOMBRE_OBRA.Texts = TABLA.Rows[0].Cells[10].Value.ToString();
                        DOMICILIO.Texts = TABLA.Rows[0].Cells[11].Value.ToString();
                        DIRIGIDO.Texts = TABLA.Rows[0].Cells[12].Value.ToString();

                        RECIB.Texts = TABLA.Rows[0].Cells[15].Value.ToString();
                        AUTORIZA.Texts = TABLA.Rows[0].Cells[16].Value.ToString();
                        PROGRAMA.Texts = TABLA.Rows[0].Cells[17].Value.ToString();
                        GRADO.Texts = TABLA.Rows[0].Cells[18].Value.ToString();
                        NOMBRE_TEC.Texts = TABLA.Rows[0].Cells[19].Value.ToString();
                        NAM.Texts = TABLA.Rows[0].Cells[20].Value.ToString();
                        CON.Texts = TABLA.Rows[0].Cells[21].Value.ToString();


                        PROPIEDAD.Texts = TABLA.Rows[0].Cells[24].Value.ToString();
                        RESGUARDO.Texts = TABLA.Rows[0].Cells[25].Value.ToString();
                        informes_dirigidos.Texts = TABLA.Rows[0].Cells["INFORMES_DIRIGIDOS"].Value.ToString();

                    }
                }
                else
                {
                    TABLA.DataSource = conexion_servicios_eventuales.Consultageneral("SELECT * FROM ordenes_trabajo WHERE CLAVE_OBRA = '" + clave_obra.Texts + "' ORDER BY ID_SEGUIMIENTO DESC"); ;

                    if (TABLA.RowCount > 0)
                    {
                        NOMBRE.Texts = TABLA.Rows[0].Cells[3].Value.ToString();
                        EMPRESA.Texts = TABLA.Rows[0].Cells[4].Value.ToString();

                        CODIGO_POSTAL.Texts = TABLA.Rows[0].Cells[6].Value.ToString();
                        TELEFONO.Texts = TABLA.Rows[0].Cells[7].Value.ToString();
                        RFC.Texts = TABLA.Rows[0].Cells[8].Value.ToString();
                        EMAIL.Texts = TABLA.Rows[0].Cells[9].Value.ToString();
                        NOMBRE_OBRA.Texts = TABLA.Rows[0].Cells[10].Value.ToString();
                        DOMICILIO.Texts = TABLA.Rows[0].Cells[11].Value.ToString();
                        DIRIGIDO.Texts = TABLA.Rows[0].Cells[12].Value.ToString();

                        RECIB.Texts = TABLA.Rows[0].Cells[15].Value.ToString();
                        AUTORIZA.Texts = TABLA.Rows[0].Cells[16].Value.ToString();
                        PROGRAMA.Texts = TABLA.Rows[0].Cells[17].Value.ToString();
                        GRADO.Texts = TABLA.Rows[0].Cells[18].Value.ToString();
                        NOMBRE_TEC.Texts = TABLA.Rows[0].Cells[19].Value.ToString();
                        NAM.Texts = TABLA.Rows[0].Cells[20].Value.ToString();
                        CON.Texts = TABLA.Rows[0].Cells[21].Value.ToString();


                        PROPIEDAD.Texts = TABLA.Rows[0].Cells[24].Value.ToString();
                        RESGUARDO.Texts = TABLA.Rows[0].Cells[25].Value.ToString();
                        informes_dirigidos.Texts = TABLA.Rows[0].Cells["INFORMES_DIRIGIDOS"].Value.ToString();

                    }
                }
            }

            else
            {
                TABLA.DataSource = conexion_servicios_eventuales.Consultageneral("SELECT * FROM listado_obras WHERE CLAVE_OBRA = '" + clave_obra.Texts + "'"); ;

                if (TABLA.RowCount != 0)
                {
                    NOMBRE_OBRA.Texts = TABLA.Rows[0].Cells[3].Value.ToString();
                    EMPRESA.Texts = TABLA.Rows[0].Cells[4].Value.ToString();
                    NOMBRE.Texts = TABLA.Rows[0].Cells[5].Value.ToString();
                    informes_dirigidos.Texts = TABLA.Rows[0].Cells["DIRIGIRSE_A"].Value.ToString();
                    EMAIL.Texts = TABLA.Rows[0].Cells["CORREO_ELECTRONICO"].Value.ToString();
                    DOMICILIO.Texts = TABLA.Rows[0].Cells["DIRECCION_OBRA"].Value.ToString();
                    TELEFONO.Texts = TABLA.Rows[0].Cells["TELEFONO"].Value.ToString();
                    informes_dirigidos.Texts = TABLA.Rows[0].Cells["DIRIGIRSE_A"].Value.ToString();



                }
            }

        }
        private void label1_Click(object sender, EventArgs e)
        {


            consultaclaves();
            consultaestatusdeclave();



        }
        private void consultaestatusdeclave()
        {
            MySqlConnection CONEXION2 = conexion_servicios_eventuales.USR;


            MySqlCommand comando2 = new MySqlCommand("SELECT EMISION_LAB FROM listado_obras WHERE CLAVE_OBRA= '" + clave_obra.Texts + "'", CONEXION2);
            CONEXION2.Open();
            MySqlDataReader registro2 = comando2.ExecuteReader();

            while (registro2.Read())
            {







                if ((registro2["EMISION_LAB"].ToString()) == "NO INFORMES Y SERVICOS")
                {
                    clave_obra.Texts = "Restricción de Servicio";
                    clave_obra.BackColor = System.Drawing.Color.LightCoral;
                }
                else
                {

                    clave_obra.BackColor = System.Drawing.Color.White;
                }







            }
            CONEXION2.Close();





        }
        private void label1_MouseMove(object sender, MouseEventArgs e)
        {
            label1.ForeColor = System.Drawing.Color.FromArgb(225, 92, 0);
        }

        private void label4_Click(object sender, EventArgs e)
        {
            NOMBRE.Enabled = true;
        }

        private void label5_Click(object sender, EventArgs e)
        {
            EMPRESA.Enabled = true;
        }


        private void labo_OnSelectedIndexChanged(object sender, EventArgs e)
        {


        }

        private void AG1_Click(object sender, EventArgs e)
        {


            if (decision_cambio == true)
            {

                if (cambiacotunavez == true)
                {

                    cambia_itemas();
                    cambia_laterales();
                    ID_COT.BackColor = System.Drawing.Color.DimGray;
                    DGV.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.MediumSeaGreen;
                    label27.Visible = true;
                    cambiacotunavez = false;

                }


            }



            DialogResult dl = MessageBox.Show("¿Deseas Agregar Iguala Semanal?", "Notificación de Operación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);


            if (dl == DialogResult.Yes)


            {


                CATALOGO_DNS mn = new CATALOGO_DNS();

                if (desde_pnd == true) { mn.desde_pnd = true; }

                mn.DGVDATOS_carrito.DataSource = conexion_servicios.Consultageneral("SELECT * FROM servicios_permanentes");
                mn.DGVDATOS_carrito.Sort(mn.DGVDATOS_carrito.Columns[0], ListSortDirection.Ascending);
                mn.cn2();
                mn.TABLA_CATALOGO();
                mn.de_fuera = true;
                mn.igualas = true;

                if (decision_cambio == true) { mn.consulta_ot = true; }
                mn.ShowDialog();






            }
            else
            {


                CATALOGO_DNS mn = new CATALOGO_DNS();



                if (desde_pnd == true) { mn.desde_pnd = true; }


                mn.DGVDATOS_carrito.DataSource = conexion_servicios.Consultageneral("SELECT * FROM servicios_eventuales");
                mn.DGVDATOS_carrito.Sort(mn.DGVDATOS_carrito.Columns[0], ListSortDirection.Ascending);
                mn.cn();
                mn.TABLA_CATALOGO();
                mn.de_fuera = true;
                if (decision_cambio == true) { mn.consulta_ot = true; }
                mn.ShowDialog();



            }

        }
        string idcot_paralaterales;
        string ULTIMOCARACTER;
        public void cambia_laterales()
        {
            if (ID_COT.Text.Contains("-A") || ID_COT.Text.Contains("-B") || ID_COT.Text.Contains("-C")
                        || ID_COT.Text.Contains("-D") || ID_COT.Text.Contains("-E") || ID_COT.Text.Contains("-F")
                        || ID_COT.Text.Contains("-G") || ID_COT.Text.Contains("-H") || ID_COT.Text.Contains("-I")
                        || ID_COT.Text.Contains("-J") || ID_COT.Text.Contains("-K") || ID_COT.Text.Contains("-L")
                        || ID_COT.Text.Contains("-M") || ID_COT.Text.Contains("-N") || ID_COT.Text.Contains("-Ñ")
                        || ID_COT.Text.Contains("-O") || ID_COT.Text.Contains("-P") || ID_COT.Text.Contains("-Q")
                        || ID_COT.Text.Contains("-R") || ID_COT.Text.Contains("-S") || ID_COT.Text.Contains("-T")
                        || ID_COT.Text.Contains("-U") || ID_COT.Text.Contains("-V") || ID_COT.Text.Contains("-W")
                        || ID_COT.Text.Contains("-X") || ID_COT.Text.Contains("-Y") || ID_COT.Text.Contains("-Z"))
            {



                MySqlConnection CONEXION = conexion.USR;

                MySqlCommand comando = new MySqlCommand("SELECT ID_COTIZACION FROM  seguimiento_cotizacion WHERE ID_COTIZACION = '" + ID_COT.Text + "'", CONEXION);

                CONEXION.Open();
                MySqlDataReader consulta = comando.ExecuteReader();
                if (consulta.Read())
                {


                    string texto = id_cotizacion;

                    ULTIMOCARACTER = texto.Substring(texto.Length - 1);


                    char letra = char.Parse(ULTIMOCARACTER); // La letra de inicio

                    int valor = (int)letra; // Convertir la letra a su valor ASCII
                    valor++; // Incrementar en 1
                    char siguienteLetra = (char)valor; // Convertir el valor de regreso a una letra

                    ID_COT.Text = ID_COT.Text.Remove(ID_COT.Text.Length - 1);
                    ID_COT.Text = ID_COT.Text + Convert.ToString(siguienteLetra);
                    id_cotizacion = ID_COT.Text;
                    id_cotizacion = ID_COT.Text;


                    CONEXION.Close();
                    cambia_laterales();

                }

                else
                {
                    CONEXION.Close();
                    id_cotizacion = ID_COT.Text;
                }


            }
            else
            {
                ID_COT.Text = ID_COT.Text + "-A";
                id_cotizacion = ID_COT.Text + "-A";
                MySqlConnection CONEXION = conexion.USR;

                MySqlCommand comando = new MySqlCommand("SELECT ID_COTIZACION FROM  seguimiento_cotizacion WHERE ID_COTIZACION = '" + ID_COT.Text + "'", CONEXION);

                CONEXION.Open();
                MySqlDataReader consulta = comando.ExecuteReader();
                if (consulta.Read())
                {


                    string texto = id_cotizacion;

                    ULTIMOCARACTER = texto.Substring(texto.Length - 1);


                    char letra = char.Parse(ULTIMOCARACTER); // La letra de inicio

                    int valor = (int)letra; // Convertir la letra a su valor ASCII
                    valor++; // Incrementar en 1
                    char siguienteLetra = (char)valor; // Convertir el valor de regreso a una letra

                    ID_COT.Text = ID_COT.Text.Remove(ID_COT.Text.Length - 1);
                    ID_COT.Text = ID_COT.Text + Convert.ToString(siguienteLetra);
                    id_cotizacion = ID_COT.Text;
                    id_cotizacion = ID_COT.Text;

                    CONEXION.Close();
                    cambia_laterales();

                }

                else
                {
                    CONEXION.Close();
                    id_cotizacion = ID_COT.Text;
                }





            }
            cambiacotunavez = false;
        }


        private void editar_fila()
        {


            if (DGV.CurrentRow.Cells[3].Value == null || DGV.CurrentRow.Cells[4].Value == null)
            {

            }
            else
            {
                double val1 = double.Parse(DGV.CurrentRow.Cells["CANTIDAD"].Value.ToString());
                double val2 = double.Parse(DGV.CurrentRow.Cells["PU"].Value.ToString());
                double res = Math.Round(val1 * val2);
                DGV.CurrentRow.Cells["IMPORTE"].Value = res.ToString("N2");

            }


            revisar_importes();
        }


        private void actualizaconcepto()
        {
            conexion.USR.Open();//Se abre la conexión para evitar un error común
            String Query = "UPDATE conceptos_cotizaciones SET UNIDAD= '" + DGV.CurrentRow.Cells["UNIDAD"].Value.ToString() + "' , CANTIDAD= '" + DGV.CurrentRow.Cells["CANTIDAD"].Value.ToString() + "', PU= '" + double.Parse(DGV.CurrentRow.Cells["PU"].Value.ToString()) + "', IMPORTE= '" + double.Parse(DGV.CurrentRow.Cells["IMPORTE"].Value.ToString()) + "', CONCEPTO= '" + DGV.CurrentRow.Cells["CONCEPTOS"].Value.ToString() + "' , ALCANCES= '" + DGV.CurrentRow.Cells["ALCANCES"].Value.ToString() + "',  NORMAS_CALIFICACION= '" + DGV.CurrentRow.Cells["NORMAS"].Value.ToString() + "', TIEMPOS= '" + DGV.CurrentRow.Cells["ENTREGAS"].Value.ToString() + "', REFERENCIAS= '" + DGV.CurrentRow.Cells["REFERENCIA"].Value.ToString() + "'  WHERE ID_SEGUIMIENTO  = '" + DGV.CurrentRow.Cells["CLAVES"].Value.ToString() + "' AND ID_COTIZACION ='" + ID_COT.Text + "' ;";
            MySqlCommand comando = new MySqlCommand(Query, conexion.USR);//Se interpreta el comando del query
            comando.ExecuteNonQuery();//Se ejecuta el comando del query
            conexion.USR.Close();//Se cierra la conexión

        }
        private void DGV_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {





            editar_fila();


            if (decision_cambio == true)
            {

                if (cambiacotunavez == true)
                {



                    string nombrecolumna = DGV.Columns[e.ColumnIndex].HeaderText;
                    if (nombrecolumna == "Unidad" || nombrecolumna == "Cant." || nombrecolumna == "P.U." || nombrecolumna == "Alcances")
                    {


                        cambia_itemas();
                        cambia_laterales();
                        ID_COT.Inactive1 = System.Drawing.Color.MediumSeaGreen;
                        ID_COT.Inactive2 = System.Drawing.Color.MediumSeaGreen;
                        DGV.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.MediumSeaGreen;
                        label27.Visible = true;


                        cambiacotunavez = false;




                    }
                }
            }

            actualizaconcepto();

        }

        private void label25_Click(object sender, EventArgs e)
        {

            if (decision_cambio == true)
            {

                if (cambiacotunavez == true)
                {

                    cambia_itemas();
                    cambia_laterales();
                    ID_COT.Inactive1 = System.Drawing.Color.MediumSeaGreen;
                    ID_COT.Inactive2 = System.Drawing.Color.MediumSeaGreen;
                    DGV.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.MediumSeaGreen;
                    label27.Visible = true;
                    cambiacotunavez = false;

                }


            }



            DialogResult dl = MessageBox.Show("¿Deseas Agregar Iguala Semanal?", "Notificación de Operación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);


            if (dl == DialogResult.Yes)


            {


                CATALOGO_DNS mn = new CATALOGO_DNS();

                if (desde_pnd == true) { mn.desde_pnd = true; }

                mn.DGVDATOS_carrito.DataSource = conexion_servicios.Consultageneral("SELECT * FROM servicios_permanentes");
                mn.DGVDATOS_carrito.Sort(mn.DGVDATOS_carrito.Columns[0], ListSortDirection.Ascending);
                mn.cn2();
                mn.TABLA_CATALOGO();
                mn.de_fuera = true;
                mn.igualas = true;

                if (decision_cambio == true) { mn.consulta_ot = true; }
                mn.ShowDialog();






            }
            else
            {


                CATALOGO_DNS mn = new CATALOGO_DNS();



                if (desde_pnd == true) { mn.desde_pnd = true; }


                mn.DGVDATOS_carrito.DataSource = conexion_servicios.Consultageneral("SELECT * FROM servicios_eventuales");
                mn.DGVDATOS_carrito.Sort(mn.DGVDATOS_carrito.Columns[0], ListSortDirection.Ascending);
                mn.cn();
                mn.TABLA_CATALOGO();
                mn.de_fuera = true;
                if (decision_cambio == true) { mn.consulta_ot = true; }
                mn.ShowDialog();



            }
        }

        private void altoButton2_Click(object sender, EventArgs e)
        {

            if (decision_cambio == true)
            {
                if (cambiacotunavez == true)
                {

                    cambia_itemas();
                    cambia_laterales();
                    ID_COT.Inactive1 = System.Drawing.Color.MediumSeaGreen;
                    ID_COT.Inactive2 = System.Drawing.Color.MediumSeaGreen;
                    DGV.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.MediumSeaGreen;
                    label27.Visible = true;
                    cambiacotunavez = false;

                }

            }
            else
            {

            }

            MySqlConnection CONEXION = conexion.USR;

            MySqlCommand comando = new MySqlCommand("SELECT * FROM  conceptos_cotizaciones WHERE ID_COTIZACION = '" + precotiz.Texts + "'", CONEXION);

            CONEXION.Open();
            MySqlDataReader consulta = comando.ExecuteReader();
            while (consulta.Read())
            {


                string a1 = (consulta["CLAVE"].ToString().ToUpper());
                string a2 = (consulta["CONCEPTO"].ToString().ToUpper());
                string a3 = (consulta["UNIDAD"].ToString().ToUpper());
                string a4 = (consulta["CANTIDAD"].ToString().ToUpper());
                string a5 = (consulta["PU"].ToString().ToUpper());
                string a6 = (consulta["IMPORTE"].ToString().ToUpper());

                DGV.Rows.Add("-", (consulta["CONCEPTO"].ToString().ToUpper()), (consulta["UNIDAD"].ToString().ToUpper()), (consulta["CANTIDAD"].ToString().ToUpper()), (consulta["PU"].ToString().ToUpper()), (consulta["IMPORTE"].ToString().ToUpper()), (consulta["CLAVE"].ToString().ToUpper()), (consulta["ALCANCES"].ToString().ToUpper()), (consulta["NORMAS_CALIFICACION"].ToString().ToUpper()), (consulta["TIEMPOS"].ToString().ToUpper()), (consulta["REFERENCIAS"].ToString().ToUpper()));


            }


            CONEXION.Close();
            registra_nuevos();

        }

        private void DGV_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {




                DialogResult DL = MessageBox.Show("¿Deseas Eliminar el Concepto " + DGV.CurrentRow.Cells["CLAVES"].Value.ToString() + " ?", "Notificación de Operación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (DL == DialogResult.Yes)
                {


                    if (decision_cambio == true)
                    {
                        DGV.Rows.RemoveAt(DGV.SelectedRows[0].Index);

                        editar_fila();
                        if (cambiacotunavez == true)
                        {



                            cambia_itemas();
                            cambia_laterales();
                            ID_COT.Inactive1 = System.Drawing.Color.MediumSeaGreen;
                            ID_COT.Inactive2 = System.Drawing.Color.MediumSeaGreen;
                            DGV.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.MediumSeaGreen;
                            label27.Visible = true;




                        }
                    }




                    else
                    {
                        conexion.USR.Open();//Se abre la conexión para evitar un error común
                        String Query = "DELETE FROM conceptos_cotizaciones WHERE ID_SEGUIMIENTO = '" + DGV.CurrentRow.Cells["CLAVES"].Value.ToString() + "';";

                        MySqlCommand comando = new MySqlCommand(Query, conexion.USR);//Se interpreta el comando del query
                        comando.ExecuteNonQuery();//Se ejecuta el comando del query

                        conexion.USR.Close();//Se cierra la conexión

                        DGV.Rows.RemoveAt(DGV.SelectedRows[0].Index);

                    }


                    MENSAJE_GENERAL MN = new MENSAJE_GENERAL();
                    MN.BOTON.Text = "Eliminación Realizada";
                    MN.ShowDialog();
                }

                else
                {

                }



            }
        }

        private void DGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void informes_dirigidos__TextChanged(object sender, EventArgs e)
        {

        }

        private void verCotizaciónToolStripMenuItem_Click(object sender, EventArgs e)
        {

            DialogResult dl = MessageBox.Show("Deseas Registrar en App Inspección de Torque", "Notificación de Operación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dl == DialogResult.Yes)
            {

                CONEXION_GEOBASE.registrar("INSERT INTO torque_inspeccion (obra,clave_de_obra,cliente,fecha_de_inspeccion,responsable_con_atencion,usuario,programo_orden,id_orden_de_trabajo) values ('" + NOMBRE_OBRA.Texts + "', '" + clave_obra.Texts + "' , '" + EMPRESA.Texts + "' , '" + FECHA.Text + "','" + DIRIGIDO.Texts + "','" + NOMBRE_TEC.Texts + "', '" + PROGRAMA.Texts + "', '" + FOLIOO.Texts + "'  ) ");
                MENSAJE_GENERAL MN = new MENSAJE_GENERAL();
                MN.BOTON.Text = "Registro Realizado";
                MN.Show();

            }





        }

        private void apprevendimiento_Click(object sender, EventArgs e)
        {

            cadena_muestra = DGV.CurrentRow.Cells["REFERENCIA"].Value.ToString();

            DialogResult dl = MessageBox.Show("Deseas Registrar en App Concreto Fresco", "Notificación de Operación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dl == DialogResult.Yes)
            {
                remota_concreto.registrar("INSERT INTO cont_y_ver_de_concreto_f (fecha_de_colado,clave_de_obra,cliente,obra,con_atencion_a,usuario,fecha_de_registro) values ('" + FECHA.Text + "', '" + clave_obra.Texts + "' , '" + EMPRESA.Texts + "' , '" + NOMBRE_OBRA.Texts + "','" + informes_dirigidos.Texts + "','" + NOMBRE_TEC.Texts + "','" + DateTime.Today.ToString("yyyy-MM-dd") + "' ) ");

                TABLA.DataSource = remota_concreto.Consultageneral("SELECT id FROM cont_y_ver_de_concreto_f WHERE clave_de_obra = '" + clave_obra.Texts + "' AND fecha_de_colado = '" + FECHA.Text + "' ");
                if (TABLA.RowCount != 0)
                {
                    dide = TABLA.Rows[0].Cells[0].Value.ToString();

                    remota_concreto.registrar("INSERT INTO concreto_fresco (clave_de_obra,id_seguimiento,fecha_de_colado,usuario,no_de_muestra) values ('" + clave_obra.Texts + "', '" + dide + "' , '" + FECHA.Text + "' , '" + NOMBRE_TEC.Texts + "', '" + cadena_muestra + "') ");

                }


                MENSAJE_GENERAL MN = new MENSAJE_GENERAL();
                MN.BOTON.Text = "Registro Realizado";
                MN.Show();

            }

        }

        private void appcompactaciones_Click(object sender, EventArgs e)
        {
            DialogResult dl = MessageBox.Show("Deseas Registrar en App Compactación", "Notificación de Operación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dl == DialogResult.Yes)
            {
                cadena_muestra = DGV.CurrentRow.Cells["REFERENCIA"].Value.ToString();


                CONEXION_TERRACERIAS.registrar("INSERT INTO compactaciones (CLAVE_OBRA,SONDEO,FECHA_INFORME,FECHA_PRUEBA,OT,REALIZO, OBSERVACION) values ('" + clave_obra.Texts + "', '" + cadena_muestra + "' , '" + DateTime.Today.ToString("yyyy-MM-dd") + "' , '" + FECHA.Text + "','" + FOLIOO.Texts + "','" + NOMBRE_TEC.Texts + "', 'NO CONSULTADA') ");




                MENSAJE_GENERAL MN = new MENSAJE_GENERAL();
                MN.BOTON.Text = "Registro Realizado";
                MN.Show();

            }

        }

        private void registrarEnAppNúcleosDeAsfaltoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dl = MessageBox.Show("Deseas Registrar en App Compactación", "Notificación de Operación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dl == DialogResult.Yes)
            {


                remota_terra.registrar("INSERT INTO  referencias_nucleos_asfalto (clave_obra,no_sondeo,fecha_extraccion,empresa,atencion_a,fecha_muestreo, obra,ESTATUS) values ('" + clave_obra.Texts + "', '1' , '" + FECHA.Value.ToString("yyyy-MM-dd") + "' , '" + EMPRESA.Texts + "','" + NOMBRE.Texts + "','" + FECHA.Value.ToString("yyyy-MM-dd") + "', '" + NOMBRE_OBRA.Texts + "' ,  '1') ");




                MENSAJE_GENERAL MN = new MENSAJE_GENERAL();
                MN.BOTON.Text = "Registro Realizado";
                MN.Show();

            }

        }

        private void añoes_OnSelectedIndexChanged(object sender, EventArgs e)
        {

            consecutivo_manual();











        }

        private void NAM_Click(object sender, EventArgs e)
        {

        }

        private void cargar_ot_segunsucursal()
        {


            if (SESION.CONF_SUC == "C.T. CENTRAL") { labo.Texts = "Laboratorio Central"; }
            else if (SESION.CONF_SUC == "C.T. TEPÓTZOTLÁN") { labo.Texts = "Laboratorio Tepotzotlán"; }
            else if (SESION.CONF_SUC == "C.T. SAN LUIS POTOSI") { labo.Texts = "Laboratorio San Luis Potosí"; }
            else if (SESION.CONF_SUC == "C.T. LERMA") { labo.Texts = "Laboratorio Lerma"; }
            else if (SESION.CONF_SUC == "C.T. MÉRIDA") { labo.Texts = "Laboratorio Mérida"; }
            else if (SESION.CONF_SUC == "C.T. TAPACHULA") { labo.Texts = "Laboratorio Chiapas"; }
            else if (SESION.CONF_SUC == "C.T. MONTERREY") { labo.Texts = "Laboratorio Monterrey"; }




            int conteo_orden = 0;
            string datofe = añoes.Texts + "-01-01";


            if (desde_pnd == true)
            {
                TABLA.DataSource = conexion_servicios_eventuales.Consultageneral("SELECT * FROM ordenes_trabajo_pnd WHERE YEAR(FECHA) = '" + añoes.Texts + "'  ");
                conteo_orden = TABLA.RowCount + 1;
                string conteo = "PN-" + proceso + "." + DateTime.Parse(datofe).ToString("yy") + "-" + Convert.ToString(conteo_orden);

                FOLIOO.Texts = conteo;
            }
            else
            {
                if (SESION.CONF_SUC == "C.T. TEPÓTZOTLÁN")
                {
                    TABLA.DataSource = conexion_servicios_eventuales.Consultageneral("SELECT * FROM ordenes_trabajo WHERE YEAR(FECHA) = '" + DateTime.Today.ToString("yyyy") + "' AND ID_ORDEN LIKE '%LT%' ");

                    conteo_orden = TABLA.RowCount + 1;


                    labo.Texts = "Laboratorio Tepotzotlán";
                    string conteo = "LT-" + proceso + "." + DateTime.Parse(datofe).ToString("yy") + "-" + Convert.ToString(conteo_orden);
                    FOLIOO.Texts = conteo;

                }
                else if (SESION.CONF_SUC == "C.T. SAN LUIS POTOSI")
                {
                    TABLA.DataSource = conexion_servicios_eventuales.Consultageneral("SELECT * FROM ordenes_trabajo WHERE YEAR(FECHA) = '" + DateTime.Today.ToString("yyyy") + "'  AND ID_ORDEN LIKE '%LP%' ");
                    conteo_orden = TABLA.RowCount + 1;


                    labo.Texts = "Laboratorio San Luis Potosí";
                    string conteo = "LP-" + proceso + "." + DateTime.Parse(datofe).ToString("yy") + "-" + Convert.ToString(conteo_orden);
                    FOLIOO.Texts = conteo;

                }
                else if (SESION.CONF_SUC == "C.T. LERMA")
                {
                    TABLA.DataSource = conexion_servicios_eventuales.Consultageneral("SELECT * FROM ordenes_trabajo WHERE  YEAR(FECHA) = '" + DateTime.Today.ToString("yyyy") + "'  AND ID_ORDEN LIKE '%LL%' ");
                    conteo_orden = TABLA.RowCount + 1;


                    labo.Texts = "Laboratorio Lerma";
                    string conteo = "LL-" + proceso + "." + DateTime.Parse(datofe).ToString("yy") + "-" + Convert.ToString(conteo_orden);
                    FOLIOO.Texts = conteo;

                }
                else if (SESION.CONF_SUC == "C.T. MÉRIDA")
                {
                    TABLA.DataSource = conexion_servicios_eventuales.Consultageneral("SELECT * FROM ordenes_trabajo WHERE  YEAR(FECHA) = '" + DateTime.Today.ToString("yyyy") + "'  AND ID_ORDEN LIKE '%LM-%' ");
                    conteo_orden = TABLA.RowCount + 1;

                    labo.Texts = "Laboratorio Mérida";
                    string conteo = "LM-" + proceso + "." + DateTime.Parse(datofe).ToString("yy") + "-" + Convert.ToString(conteo_orden);
                    FOLIOO.Texts = conteo;

                }
                else if (SESION.CONF_SUC == "C.T. TAPACHULA")
                {
                    TABLA.DataSource = conexion_servicios_eventuales.Consultageneral("SELECT * FROM ordenes_trabajo WHERE  YEAR(FECHA) = '" + DateTime.Today.ToString("yyyy") + "'  AND ID_ORDEN LIKE '%LH%' ");
                    conteo_orden = TABLA.RowCount + 1;


                    labo.Texts = "Laboratorio Chiapas";
                    string conteo = "LH-" + proceso + "." + DateTime.Parse(datofe).ToString("yy") + "-" + Convert.ToString(conteo_orden);
                    FOLIOO.Texts = conteo;
                }
                else if (SESION.CONF_SUC == "C.T. MONTERREY")
                {
                    TABLA.DataSource = conexion_servicios_eventuales.Consultageneral("SELECT * FROM ordenes_trabajo WHERE  YEAR(FECHA) = '" + DateTime.Today.ToString("yyyy") + "'  AND ID_ORDEN LIKE '%LMT%'");
                    conteo_orden = TABLA.RowCount + 1;


                    labo.Texts = "Laboratorio Monterrey";
                    string conteo = "LMT-" + proceso + "." + DateTime.Parse(datofe).ToString("yy") + "-" + Convert.ToString(conteo_orden);
                    FOLIOO.Texts = conteo;

                }

                else
                {
                    labo.Enabled = true;
                    TABLA.DataSource = conexion_servicios_eventuales.Consultageneral("SELECT * FROM ordenes_trabajo WHERE  (YEAR(FECHA) = '" + DateTime.Today.ToString("yyyy") + "' AND ID_ORDEN LIKE '%LC%') OR (YEAR(FECHA) = '" + DateTime.Today.ToString("yyyy") + "' AND ID_ORDEN LIKE '%SP%') OR (YEAR(FECHA) = '" + DateTime.Today.ToString("yyyy") + "' AND ID_ORDEN LIKE '%SF%')    OR (YEAR(FECHA) = '" + DateTime.Today.ToString("yyyy") + "' AND ID_ORDEN LIKE '%SE%') ");
                    conteo_orden = TABLA.RowCount + 1;


                    if (labo.Texts == "Laboratorio Central")
                    {

                        string conteo = "LC-" + proceso + "." + DateTime.Parse(datofe).ToString("yy") + "-" + Convert.ToString(conteo_orden);
                        FOLIOO.Texts = conteo;

                    }
                    if (labo.Texts == "Servicio Permanente")
                    {
                        string conteo = "SP-" + proceso + "." + DateTime.Parse(datofe).ToString("yy") + "-" + Convert.ToString(conteo_orden);
                        FOLIOO.Texts = conteo;
                    }
                    if (labo.Texts == "Servicio de PND")
                    {
                        string conteo = "PN-" + proceso + "." + DateTime.Parse(datofe).ToString("yy") + "-" + Convert.ToString(conteo_orden);
                        FOLIOO.Texts = conteo;
                    }

                    if (labo.Texts == "Servicio Eventual")
                    {
                        string conteo = "SE-" + proceso + "." + DateTime.Parse(datofe).ToString("yy") + "-" + Convert.ToString(conteo_orden);
                        FOLIOO.Texts = conteo;
                    }
                    if (labo.Texts == "Servicio Foráneo")
                    {
                        string conteo = "SF-" + proceso + "." + DateTime.Parse(datofe).ToString("yy") + "-" + Convert.ToString(conteo_orden);
                        FOLIOO.Texts = conteo;
                    }


                }





            }






        }

        private void consecutivo_manual()
        {




            int conteo_orden = 0;
            string datofe = añoes.Texts + "-01-01";


            if (desde_pnd == true)
            {
                TABLA.DataSource = conexion_servicios_eventuales.Consultageneral("SELECT * FROM ordenes_trabajo_pnd WHERE YEAR(FECHA) = '" + añoes.Texts + "'  ");

                conteo_orden = TABLA.RowCount + 1;
                string conteo = "PN-" + proceso + "." + DateTime.Parse(datofe).ToString("yy") + "-" + Convert.ToString(conteo_orden);

                FOLIOO.Texts = conteo;
            }
            else
            {
                if (SESION.CONF_SUC == "C.T. TEPÓTZOTLÁN")
                {
                    TABLA.DataSource = conexion_servicios_eventuales.Consultageneral("SELECT * FROM ordenes_trabajo WHERE YEAR(FECHA) = '" + DateTime.Today.ToString("yyyy") + "' AND ID_ORDEN LIKE '%LT%' ");

                    conteo_orden = TABLA.RowCount + 1;


                    labo.Texts = "Laboratorio Tepotzotlán";
                    string conteo = "LT-" + proceso + "." + DateTime.Parse(datofe).ToString("yy") + "-" + Convert.ToString(conteo_orden);
                    FOLIOO.Texts = conteo;

                }
                else if (SESION.CONF_SUC == "C.T. SAN LUIS POTOSI")
                {
                    TABLA.DataSource = conexion_servicios_eventuales.Consultageneral("SELECT * FROM ordenes_trabajo WHERE YEAR(FECHA) = '" + DateTime.Today.ToString("yyyy") + "'  AND ID_ORDEN LIKE '%LP%' ");
                    conteo_orden = TABLA.RowCount + 1;


                    labo.Texts = "Laboratorio San Luis Potosí";
                    string conteo = "LP-" + proceso + "." + DateTime.Parse(datofe).ToString("yy") + "-" + Convert.ToString(conteo_orden);
                    FOLIOO.Texts = conteo;

                }
                else if (SESION.CONF_SUC == "C.T. LERMA")
                {
                    TABLA.DataSource = conexion_servicios_eventuales.Consultageneral("SELECT * FROM ordenes_trabajo WHERE  YEAR(FECHA) = '" + DateTime.Today.ToString("yyyy") + "'  AND ID_ORDEN LIKE '%LL%' ");
                    conteo_orden = TABLA.RowCount + 1;


                    labo.Texts = "Laboratorio Lerma";
                    string conteo = "LL-" + proceso + "." + DateTime.Parse(datofe).ToString("yy") + "-" + Convert.ToString(conteo_orden);
                    FOLIOO.Texts = conteo;

                }
                else if (SESION.CONF_SUC == "C.T. MÉRIDA")
                {
                    TABLA.DataSource = conexion_servicios_eventuales.Consultageneral("SELECT * FROM ordenes_trabajo WHERE  YEAR(FECHA) = '" + DateTime.Today.ToString("yyyy") + "'  AND ID_ORDEN LIKE '%LM-%' ");
                    conteo_orden = TABLA.RowCount + 1;

                    labo.Texts = "Laboratorio Mérida";
                    string conteo = "LM-" + proceso + "." + DateTime.Parse(datofe).ToString("yy") + "-" + Convert.ToString(conteo_orden);
                    FOLIOO.Texts = conteo;

                }
                else if (SESION.CONF_SUC == "C.T. TAPACHULA")
                {
                    TABLA.DataSource = conexion_servicios_eventuales.Consultageneral("SELECT * FROM ordenes_trabajo WHERE  YEAR(FECHA) = '" + DateTime.Today.ToString("yyyy") + "'  AND ID_ORDEN LIKE '%LH%' ");
                    conteo_orden = TABLA.RowCount + 1;


                    labo.Texts = "Laboratorio Chiapas";
                    string conteo = "LH-" + proceso + "." + DateTime.Parse(datofe).ToString("yy") + "-" + Convert.ToString(conteo_orden);
                    FOLIOO.Texts = conteo;
                }
                else if (SESION.CONF_SUC == "C.T. MONTERREY")
                {
                    TABLA.DataSource = conexion_servicios_eventuales.Consultageneral("SELECT * FROM ordenes_trabajo WHERE  YEAR(FECHA) = '" + DateTime.Today.ToString("yyyy") + "'  AND ID_ORDEN LIKE '%LMT%'");
                    conteo_orden = TABLA.RowCount + 1;


                    labo.Texts = "Laboratorio Monterrey";
                    string conteo = "LMT-" + proceso + "." + DateTime.Parse(datofe).ToString("yy") + "-" + Convert.ToString(conteo_orden);
                    FOLIOO.Texts = conteo;

                }

                else
                {
                    labo.Enabled = true;
                    TABLA.DataSource = conexion_servicios_eventuales.Consultageneral("SELECT * FROM ordenes_trabajo  WHERE (YEAR(FECHA) = '" + DateTime.Today.ToString("yyyy") + "' AND ID_ORDEN LIKE '%LC%') OR (YEAR(FECHA) = '" + DateTime.Today.ToString("yyyy") + "' AND ID_ORDEN LIKE '%SP%') OR (YEAR(FECHA) = '" + DateTime.Today.ToString("yyyy") + "' AND ID_ORDEN LIKE '%SF%')    OR (YEAR(FECHA) = '" + DateTime.Today.ToString("yyyy") + "' AND ID_ORDEN LIKE '%SE%')    ");
                    conteo_orden = TABLA.RowCount + 1;


                    if (labo.Texts == "Laboratorio Central")
                    {

                        string conteo = "LC-" + proceso + "." + DateTime.Parse(datofe).ToString("yy") + "-" + Convert.ToString(conteo_orden);
                        FOLIOO.Texts = conteo;

                    }
                    if (labo.Texts == "Servicio Permanente")
                    {
                        string conteo = "SP-" + proceso + "." + DateTime.Parse(datofe).ToString("yy") + "-" + Convert.ToString(conteo_orden);
                        FOLIOO.Texts = conteo;
                    }
                    if (labo.Texts == "Servicio de PND")
                    {
                        string conteo = "PN-" + proceso + "." + DateTime.Parse(datofe).ToString("yy") + "-" + Convert.ToString(conteo_orden);
                        FOLIOO.Texts = conteo;
                    }

                    if (labo.Texts == "Servicio Eventual")
                    {
                        string conteo = "SE-" + proceso + "." + DateTime.Parse(datofe).ToString("yy") + "-" + Convert.ToString(conteo_orden);
                        FOLIOO.Texts = conteo;
                    }
                    if (labo.Texts == "Servicio Foráneo")
                    {
                        string conteo = "SF-" + proceso + "." + DateTime.Parse(datofe).ToString("yy") + "-" + Convert.ToString(conteo_orden);
                        FOLIOO.Texts = conteo;
                    }


                }



            }



        }

        private void titulo_convocatoria_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            consecutivo_manual();

        }

        private void ET_Popup(object sender, PopupEventArgs e)
        {
            e.ToolTipSize = new Size(300, 100); // Tamaño máximo del tooltip
        }

        private void ET_Draw(object sender, DrawToolTipEventArgs e)
        {
            // Fondo estándar
            e.Graphics.FillRectangle(SystemBrushes.Info, e.Bounds);
            e.Graphics.DrawRectangle(SystemPens.InfoText, new System.Drawing.Rectangle(System.Drawing.Point.Empty, new Size(e.Bounds.Width - 1, e.Bounds.Height - 1)));

            // Texto del tooltip
            string texto = e.ToolTipText;
            string primeraLinea = "FECHA DE RETORNO:";
            string resto = "";

            if (texto.StartsWith(primeraLinea))
                resto = texto.Substring(primeraLinea.Length);
            else
                primeraLinea = texto;

            // Fuentes
            System.Drawing.Font boldFont = new System.Drawing.Font(e.Font, System.Drawing.FontStyle.Bold);
            System.Drawing.Font normalFont = e.Font;

            // Dibuja "FECHA DE RETORNO:" en negrita
            e.Graphics.DrawString(primeraLinea, boldFont, Brushes.Black, new PointF(4, 4));

            // Dibuja el resto del texto
            e.Graphics.DrawString(resto, normalFont, Brushes.Black, new RectangleF(4, 24, e.Bounds.Width - 8, e.Bounds.Height - 8));
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }
    }
}
