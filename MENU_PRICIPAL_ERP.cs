using ERP_COMPLETO.PROCEDIMIENTOS;
using ERP_COMPLETO.PROCEDIMIENTOS._4_OPERACION;
using ERP_LIEC;
using MySql.Data.MySqlClient;
using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Speech.Synthesis;
using System.Text;
using System.Windows.Forms;

namespace ERP_COMPLETO
{
    public partial class MENU_PRICIPAL_ERP : Form
    {
        public MENU_PRICIPAL_ERP()
        {
            InitializeComponent();
            panel3.Width = 300; ;

        }


        bool ntf_vacio = false;
        int consulado = 0;

        private void actualia_horas_est()
        {

            MySqlConnection CONEXION = conexion_rh.USR;
            MySqlCommand comando = new MySqlCommand("SELECT NOMBRE FROM pdr_personal1 WHERE AREA_2 = 'ESTRUCTURAS' ", CONEXION);
            CONEXION.Open();
            MySqlDataReader consulta = comando.ExecuteReader();

            while (consulta.Read())
            {
                string a0 = consulta.IsDBNull(0) ? String.Empty : consulta.GetString(0);

                MySqlConnection CONEXION2 = conexion_arq.USR;
                MySqlCommand comando2 = new MySqlCommand("SELECT * FROM control_hh WHERE NOMBRE = '" + a0 + "' AND FECHA = '" + DateTime.Today.ToString("yyyy-MM-dd") + "'", CONEXION2);
                CONEXION2.Open();
                MySqlDataReader consulta2 = comando2.ExecuteReader();

                if (consulta2.Read() == false)
                {
                    CONEXION2.Close();
                    conexion_arq.registrar("INSERT INTO control_hh (NOMBRE,FECHA,CANT_HORAS) values ('" + a0 + "', '" + DateTime.Today.ToString("yyyy-MM-dd") + "' , '8' ) ");


                }
                else
                {
                    CONEXION2.Close();

                }



            }

            CONEXION.Close();
        }
        private void actualia_horas_MS()
        {

            MySqlConnection CONEXION = conexion_rh.USR;
            MySqlCommand comando = new MySqlCommand("SELECT NOMBRE FROM pdr_personal1 WHERE AREA_2 = 'MECÁNICA DE SUELOS' ", CONEXION);
            CONEXION.Open();
            MySqlDataReader consulta = comando.ExecuteReader();

            while (consulta.Read())
            {
                string a0 = consulta.IsDBNull(0) ? String.Empty : consulta.GetString(0);

                MySqlConnection CONEXION2 = CONEXION_GEOTECNIA.USR;
                MySqlCommand comando2 = new MySqlCommand("SELECT * FROM control_hh WHERE NOMBRE = '" + a0 + "' AND FECHA = '" + DateTime.Today.ToString("yyyy-MM-dd") + "'", CONEXION2);
                CONEXION2.Open();
                MySqlDataReader consulta2 = comando2.ExecuteReader();

                if (consulta2.Read() == false)
                {
                    CONEXION2.Close();
                    CONEXION_GEOTECNIA.registrar("INSERT INTO control_hh (NOMBRE,FECHA,CANT_HORAS) values ('" + a0 + "', '" + DateTime.Today.ToString("yyyy-MM-dd") + "' , '8' ) ");


                }
                else
                {
                    CONEXION2.Close();

                }



            }

            CONEXION.Close();

        }

        private void actualia_horas_arq()
        {

            MySqlConnection CONEXION = conexion_rh.USR;
            MySqlCommand comando = new MySqlCommand("SELECT NOMBRE FROM pdr_personal1 WHERE AREA_2 = 'ARQUITECTURA' ", CONEXION);
            CONEXION.Open();
            MySqlDataReader consulta = comando.ExecuteReader();

            while (consulta.Read())
            {
                string a0 = consulta.IsDBNull(0) ? String.Empty : consulta.GetString(0);

                MySqlConnection CONEXION2 = conexion_arq.USR;
                MySqlCommand comando2 = new MySqlCommand("SELECT * FROM control_hh WHERE NOMBRE = '" + a0 + "' AND FECHA = '" + DateTime.Today.ToString("yyyy-MM-dd") + "'", CONEXION2);
                CONEXION2.Open();
                MySqlDataReader consulta2 = comando2.ExecuteReader();

                if (consulta2.Read() == false)
                {
                    CONEXION2.Close();
                    conexion_arq.registrar("INSERT INTO control_hh (NOMBRE,FECHA,CANT_HORAS) values ('" + a0 + "', '" + DateTime.Today.ToString("yyyy-MM-dd") + "' , '8' ) ");


                }
                else
                {
                    CONEXION2.Close();

                }



            }

            CONEXION.Close();
        }

        // OPERACIONES - LABORATORIO
        public void concreto()
        {
            contenido.Controls.Clear();
            CACHE_CONCRETO.ND = new PAN_CONCRETO();
            CACHE_CONCRETO.ND.TopLevel = false;
            contenido.Controls.Add(CACHE_CONCRETO.ND);
            CACHE_CONCRETO.ND.Show();
        }
        public void PE()
        {
            contenido.Controls.Clear();
            CACHE_PEE.PAN = new PAN_PEE();
            CACHE_PEE.PAN.TopLevel = false;
            contenido.Controls.Add(CACHE_PEE.PAN);
            CACHE_PEE.PAN.Show();
        }
        public void terracerias()
        {
            contenido.Controls.Clear();
            TERRA.ND = new PAN_TERRA();
            TERRA.ND.TopLevel = false;
            contenido.Controls.Add(TERRA.ND);
            TERRA.ND.Show();
        }
        public void asfalto()
        {
            contenido.Controls.Clear();
            CACHE_ASFALTOS.MN = new PAN_ASFALTOS();
            CACHE_ASFALTOS.MN.TopLevel = false;
            contenido.Controls.Add(CACHE_ASFALTOS.MN);
            CACHE_ASFALTOS.MN.Show();
        }

        public static PAN_PND cortapn = new PAN_PND();
        public void pnd()
        {
            contenido.Controls.Clear();
            cortapn = new PAN_PND();
            cortapn.TopLevel = false;
            contenido.Controls.Add(cortapn);
            cortapn.Show();
        }
        public void acero()
        {
            contenido.Controls.Clear();
            CACHE_ACERO.ND = new PAN_ACERO();
            CACHE_ACERO.ND.TopLevel = false;
            contenido.Controls.Add(CACHE_ACERO.ND);
            CACHE_ACERO.ND.Show();
        }








        private void hablar(object texto)
        {
            SpeechSynthesizer BootCA = new SpeechSynthesizer();
            BootCA.SetOutputToDefaultAudioDevice();
            BootCA.Speak(texto.ToString());


        }




        private void MostrarDatosEnTextBox(string id)
        {
            tabla.DataSource = null;
            tabla.Rows.Clear();

            tabla.DataSource = conexion_rh.Consultageneral("SELECT DIA FROM dias_vacaciones WHERE ID_VACACIONES = '" + id + "'");

            StringBuilder datos = new StringBuilder();

            foreach (DataGridViewRow fila in tabla.Rows)
            {
                foreach (DataGridViewCell celda in fila.Cells)
                {
                    datos.Append(celda.Value.ToString());
                    datos.Append("    "); // Separador de columna, puedes cambiarlo según tus necesidades
                }

                //datos.AppendLine(); // Nueva línea para la siguiente fila
            }
            MENSAJE_GENERAL msn = new MENSAJE_GENERAL();
            msn.BOTON.Text = "Tus vacaciones han sido APROBADAS,\nlos dias son: '" + datos.ToString() + "' .\n Gracias.";
            msn.ShowDialog();

        }




        private void foto_perfil()
        {

            string path = @"A:\PERFILES\PERFIL IMAGES\" + SESION.usuario + ".JPG";
            bool result = File.Exists(path);
            if (result == true)
            {
                FOTO.Image = System.Drawing.Image.FromFile(path);

            }
            else
            {

            }

        }


        private bool dragging = false;
        private System.Drawing.Point dragCursorPoint;
        private System.Drawing.Point dragButtonPoint;

        public static PUBLICACIONES_LIEC cortaw = new PUBLICACIONES_LIEC();

        string lista_calendario = "";





        private void AjustarBotonesEnPanel()
        {
            var botones = new[] { personal_bt, equip_btn, oferta_btn, operaciones_btn, calidad_btn, admin_btn };

            int cantidadBotones = botones.Length;
            int altoBoton = botones[0].Height;
            int espacioEntre = 18; // Distancia fija entre botones

            // Altura total que ocuparán botones + espacios entre ellos
            int altoTotal = (cantidadBotones * altoBoton) + ((cantidadBotones - 1) * espacioEntre);

            // Calcular punto de inicio para que queden centrados verticalmente
            int y = panel5.Height + 5;

            foreach (var boton in botones)
            {
                boton.Top = y;
                boton.Height = 50;

                y += altoBoton + espacioEntre;
            }


            cerrar_sesion.Top = (panel1.Bottom - cerrar_sesion.Height) - 5;





        }



        private void eventos_color()
        {

            System.Drawing.Color hoverColor = System.Drawing.Color.FromArgb(225, 92, 0);

            var botones = new[] { personal_bt, equip_btn, oferta_btn, operaciones_btn, calidad_btn, admin_btn, cerrar_sesion };

            foreach (var btn in botones)
            {
                btn.FlatStyle = FlatStyle.Flat;                // Modo plano
                btn.FlatAppearance.BorderSize = 0;             // Sin borde
                btn.BackColor = System.Drawing.Color.Transparent;             // Fondo normal
                btn.FlatAppearance.MouseOverBackColor = hoverColor; // Color al pasar el mouse
                btn.FlatAppearance.MouseDownBackColor = hoverColor; // Opcional: color al hacer click
            }

        }

        private void MENU_PRICIPAL_ERP_Load(object sender, EventArgs e)
        {

            AjustarBotonesEnPanel();



            eventos_color();
            barra_operaciones();
            barra_operaciones();


            myBGWorker.RunWorkerAsync();

            // MENU_INICIO mn = new MENU_INICIO();
            timer3.Start();
            timer1.Start();
            cerrar_sesion.Top = (panel1.Height - cerrar_sesion.Height) - 5;
            cerrar_sesion.Left = personal_bt.Left;




        }


        private void BotonFlotante_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            dragCursorPoint = Cursor.Position;
            dragButtonPoint = ((PictureBox)sender).Location;
        }
        private void BotonWhatsApp_Click(object sender, EventArgs e)
        {
            string numero = "5215577430941";
            string mensaje = Uri.EscapeDataString("Necesito apoyo para una incidencia o duda de ERP:");
            string url = $"https://wa.me/{numero}?text={mensaje}";

            System.Diagnostics.Process.Start(url);
        }
        private void BotonFlotante_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                System.Drawing.Point diff = System.Drawing.Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                ((PictureBox)sender).Location = System.Drawing.Point.Add(dragButtonPoint, new Size(diff));
            }
        }

        private void BotonFlotante_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        private void button1_MouseHover(object sender, EventArgs e)
        {

        }

        private void sub_personal_Paint(object sender, PaintEventArgs e)
        {

        }




        public void reseteacolor_btns()
        {
            personal_bt.BackColor = System.Drawing.Color.Transparent;
            equip_btn.BackColor = System.Drawing.Color.Transparent;
            oferta_btn.BackColor = System.Drawing.Color.Transparent;
            operaciones_btn.BackColor = System.Drawing.Color.Transparent;
            calidad_btn.BackColor = System.Drawing.Color.Transparent;
            admin_btn.BackColor = System.Drawing.Color.Transparent;

        }


        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {



        }

        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {

            tabla.DataSource = conexion_login.Consultageneral("SELECT EQUIPAMIENTO FROM accesos WHERE USUARIO = '" + SESION.usuario + "'");
            string consulta = tabla.Rows[0].Cells[0].Value.ToString();
            if (consulta == "AUTORIZADO")
            {


            }
            else
            {
                MENSAJE_GENERAL MN = new MENSAJE_GENERAL();
                MN.BOTON.Text = "No Cuentas Con Acceso a Este Procedimiento";
                MN.ShowDialog();
            }


        }
        private void dns_btn_Click(object sender, EventArgs e)
        {




            // Elimina el botón "Talento"
            Control tal = contenido.Controls["dns"];
            if (tal != null)
            {
                tal.Visible = false;
            }
            // Busca y elimina el botón "Geope" si existe
            Control geope = contenido.Controls["rev"];
            if (geope != null)
            {
                geope.Visible = false;
            }




            tabla.DataSource = conexion_login.Consultageneral("SELECT DESARROLLO_NEGOCIOS FROM accesos WHERE USUARIO = '" + SESION.usuario + "'");
            string consulta = tabla.Rows[0].Cells[0].Value.ToString();
            if (consulta == "AUTORIZADO")
            {


                ordenes = new PAN_DNS();
                ordenes.TopLevel = false;
                contenido.Controls.Add(ordenes);
                ordenes.Show();

            }
            else
            {
                MENSAJE_GENERAL mn = new MENSAJE_GENERAL();
                mn.BOTON.Text = "No cuentas con acceso a esta área de trabajo, consultalo en control de calidad";
                mn.ShowDialog();
            }













            reseteacolor_btns();
        }

        private void rev_btn_Click(object sender, EventArgs e)
        {





            // Elimina el botón "Talento"
            Control tal = contenido.Controls["dns"];
            if (tal != null)
            {
                tal.Visible = false;
            }
            // Busca y elimina el botón "Geope" si existe
            Control geope = contenido.Controls["rev"];
            if (geope != null)
            {
                geope.Visible = false;
            }



            tabla.DataSource = conexion_login.Consultageneral("SELECT SERVICIOS_EVENTUALES FROM accesos WHERE USUARIO = '" + SESION.usuario + "'");
            string consulta = tabla.Rows[0].Cells[0].Value.ToString();
            if (consulta == "AUTORIZADO")
            {

                DNS.MN_REV = new PAN_SUP();
                DNS.MN_REV.TopLevel = false;
                contenido.Controls.Add(DNS.MN_REV);
                DNS.MN_REV.Show();

            }
            else
            {
                MENSAJE_GENERAL mn = new MENSAJE_GENERAL();
                mn.BOTON.Text = "No cuentas con acceso a esta área de trabajo, consultalo en control de calidad";
                mn.ShowDialog();
            }







            reseteacolor_btns();
        }


        private void bunifuFlatButton7_Click(object sender, EventArgs e)
        {

        }
        private void lab_btn_Click(object sender, EventArgs e)
        {



            // Elimina el botón "Talento"
            Control tal = contenido.Controls["lab"];
            if (tal != null)
            {
                tal.Visible = false;
            }
            // Busca y elimina el botón "Geope" si existe
            Control geope = contenido.Controls["ms"];
            if (geope != null)
            {
                geope.Visible = false;
            }

            // Busca y elimina el botón "Geope" si existe
            Control estct = contenido.Controls["est"];
            if (estct != null)
            {
                estct.Visible = false;
            }

            // Busca y elimina el botón "Geope" si existe
            Control arqu = contenido.Controls["arq"];
            if (arqu != null)
            {
                arqu.Visible = false;
            }


            SUB_MN_LABORATORIO sb = new SUB_MN_LABORATORIO();
            sb.Show();



            reseteacolor_btns();


        }

        private void ms_btn_Click(object sender, EventArgs e)
        {





            // Elimina el botón "Talento"
            Control tal = contenido.Controls["lab"];
            if (tal != null)
            {
                tal.Visible = false;
            }
            // Busca y elimina el botón "Geope" si existe
            Control geope = contenido.Controls["ms"];
            if (geope != null)
            {
                geope.Visible = false;
            }

            // Busca y elimina el botón "Geope" si existe
            Control estct = contenido.Controls["est"];
            if (estct != null)
            {
                estct.Visible = false;
            }

            // Busca y elimina el botón "Geope" si existe
            Control arqu = contenido.Controls["arq"];
            if (arqu != null)
            {
                arqu.Visible = false;
            }



            tabla.DataSource = conexion_login.Consultageneral("SELECT GEOTECNIA FROM accesos WHERE USUARIO = '" + SESION.usuario + "'");
            string consulta = tabla.Rows[0].Cells[0].Value.ToString();
            if (consulta == "AUTORIZADO")
            {
                pan_geo.Controls.Clear();
                pan_geo = new PAN_GEOTECNIA();
                pan_geo.TopLevel = false;
                contenido.Controls.Add(pan_geo);
                pan_geo.Show();

            }
            else
            {
                MENSAJE_GENERAL mn = new MENSAJE_GENERAL();
                mn.BOTON.Text = "No cuentas con acceso a esta área de trabajo, consultalo en control de calidad";
                mn.ShowDialog();
            }



            reseteacolor_btns();


        }

        private void est_btn_Click(object sender, EventArgs e)
        {



            // Elimina el botón "Talento"
            Control tal = contenido.Controls["lab"];
            if (tal != null)
            {
                tal.Visible = false;
            }
            // Busca y elimina el botón "Geope" si existe
            Control geope = contenido.Controls["ms"];
            if (geope != null)
            {
                geope.Visible = false;
            }

            // Busca y elimina el botón "Geope" si existe
            Control estct = contenido.Controls["est"];
            if (estct != null)
            {
                estct.Visible = false;
            }

            // Busca y elimina el botón "Geope" si existe
            Control arqu = contenido.Controls["arq"];
            if (arqu != null)
            {
                arqu.Visible = false;
            }




            reseteacolor_btns();


        }

        private void arq_btn_Click(object sender, EventArgs e)
        {



            // Elimina el botón "Talento"
            Control tal = contenido.Controls["lab"];
            if (tal != null)
            {
                tal.Visible = false;
            }
            // Busca y elimina el botón "Geope" si existe
            Control geope = contenido.Controls["ms"];
            if (geope != null)
            {
                geope.Visible = false;
            }

            // Busca y elimina el botón "Geope" si existe
            Control estct = contenido.Controls["est"];
            if (estct != null)
            {
                estct.Visible = false;
            }

            // Busca y elimina el botón "Geope" si existe
            Control arqu = contenido.Controls["arq"];
            if (arqu != null)
            {
                arqu.Visible = false;
            }




            reseteacolor_btns();


        }
        private void bunifuFlatButton10_Click(object sender, EventArgs e)
        {

        }

        private void cob_btn_Click(object sender, EventArgs e)
        {





            // Elimina el botón "Talento"
            Control tal = contenido.Controls["Cobranza"];
            if (tal != null)
            {
                tal.Visible = false;
            }
            // Busca y elimina el botón "Geope" si existe
            Control geope = contenido.Controls["Contabilidad"];
            if (geope != null)
            {
                geope.Visible = false;
            }

            // Busca y elimina el botón "Geope" si existe
            Control estct = contenido.Controls["Procuración"];
            if (estct != null)
            {
                estct.Visible = false;
            }

            tabla.DataSource = conexion_login.Consultageneral("SELECT COBRANZA FROM accesos WHERE USUARIO = '" + SESION.usuario + "'");
            string consulta = tabla.Rows[0].Cells[0].Value.ToString();
            if (consulta == "AUTORIZADO")
            {

                index_cob.Controls.Clear();
                DNS.MN_COB = new PAN_COB();
                DNS.MN_COB.TopLevel = false;
                contenido.Controls.Add(DNS.MN_COB);
                DNS.MN_COB.Show();

            }
            else
            {
                MENSAJE_GENERAL mn = new MENSAJE_GENERAL();
                mn.BOTON.Text = "No cuentas con acceso a esta área de trabajo, consultalo en control de calidad";
                mn.ShowDialog();
            }



            reseteacolor_btns();


        }
        private static PAN_CONTABILIDAD ordenesct = new PAN_CONTABILIDAD();
        private void con_btn_Click(object sender, EventArgs e)
        {





            // Elimina el botón "Talento"
            Control tal = contenido.Controls["Cobranza"];
            if (tal != null)
            {
                tal.Visible = false;
            }
            // Busca y elimina el botón "Geope" si existe
            Control geope = contenido.Controls["Contabilidad"];
            if (geope != null)
            {
                geope.Visible = false;
            }

            // Busca y elimina el botón "Geope" si existe
            Control estct = contenido.Controls["Procuración"];
            if (estct != null)
            {
                estct.Visible = false;
            }


            tabla.DataSource = conexion_login.Consultageneral("SELECT CONTABILIDAD FROM accesos WHERE USUARIO = '" + SESION.usuario + "'");
            string consulta = tabla.Rows[0].Cells[0].Value.ToString();
            if (consulta == "AUTORIZADO")
            {

                ordenesct = new PAN_CONTABILIDAD();
                ordenesct.TopLevel = false;
                contenido.Controls.Add(ordenesct);
                ordenesct.Show();

            }
            else
            {
                MENSAJE_GENERAL mn = new MENSAJE_GENERAL();
                mn.BOTON.Text = "No cuentas con acceso a esta área de trabajo, consultalo en control de calidad";
                mn.ShowDialog();
            }



            reseteacolor_btns();


        }

        private void pro_btn_Click(object sender, EventArgs e)
        {





            // Elimina el botón "Talento"
            Control tal = contenido.Controls["Cobranza"];
            if (tal != null)
            {
                tal.Visible = false;
            }
            // Busca y elimina el botón "Geope" si existe
            Control geope = contenido.Controls["Contabilidad"];
            if (geope != null)
            {
                geope.Visible = false;
            }

            // Busca y elimina el botón "Geope" si existe
            Control estct = contenido.Controls["Procuración"];
            if (estct != null)
            {
                estct.Visible = false;
            }

            tabla.DataSource = conexion_login.Consultageneral("SELECT COMPRAS FROM accesos WHERE USUARIO = '" + SESION.usuario + "'");
            string consulta = tabla.Rows[0].Cells[0].Value.ToString();
            if (consulta == "AUTORIZADO")
            {


                pro = new PAN_PROCURACION();
                pro.TopLevel = false;
                contenido.Controls.Add(pro);
                pro.Show();

            }
            else
            {
                MENSAJE_GENERAL mn = new MENSAJE_GENERAL();
                mn.BOTON.Text = "No cuentas con acceso a esta área de trabajo, consultalo en control de calidad";
                mn.ShowDialog();
            }



            reseteacolor_btns();


        }
        private void bunifuFlatButton14_Click(object sender, EventArgs e)
        {

        }


        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {




        }



        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {


            if (panel3.Visible == false)
            {


                SIDEBAR_PRINCIPAL_NOT agen = new SIDEBAR_PRINCIPAL_NOT();
                agen.TopLevel = false;
                agen.Dock = DockStyle.Fill;
                panel3.Controls.Add(agen);
                agen.Show();
                panel3.Visible = true;


            }
            else
            {
                panel3.Visible = false;
                panel3.Controls.Clear();
            }



        }

        private void bunifuImageButton3_Click(object sender, EventArgs e)
        {

        }

        private void bunifuFlatButton9_Click(object sender, EventArgs e)
        {


        }

        private void bunifuFlatButton22_Click(object sender, EventArgs e)
        {

        }


        private void sub_ofertas_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pana3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            ESPECIFICACIONES_TECNICAS esp_tec = new ESPECIFICACIONES_TECNICAS();
            esp_tec.Show();

        }

        private void rh_Click(object sender, EventArgs e)
        {
            contenido.Controls.Clear();
            PAN_RH ordenes = new PAN_RH();
            ordenes.TopLevel = false;
            contenido.Controls.Add(ordenes);
            ordenes.Show();
        }

        private void sup_Click(object sender, EventArgs e)
        {

        }

        private void bunifuFlatButton12_Click(object sender, EventArgs e)
        {

        }

        private void panel19_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel17_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dns_MouseLeave(object sender, EventArgs e)
        {

        }

        private void dns_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void dns_MouseHover(object sender, EventArgs e)
        {

        }

        private void dns_MouseDown(object sender, EventArgs e)
        {

        }

        private void l1_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void l1_MouseLeave(object sender, EventArgs e)
        {

        }

        private void l1_Load(object sender, EventArgs e)
        {

        }

        private void l1_Click(object sender, EventArgs e)
        {
            contenido.Controls.Clear();
            PAN_DNS ordenes = new PAN_DNS();
            ordenes.TopLevel = false;
            contenido.Controls.Add(ordenes);
            ordenes.Show();
        }
        public static PAN_DNS ordenes = new PAN_DNS();
        private void label6_Click(object sender, EventArgs e)
        {
            tabla.DataSource = conexion_login.Consultageneral("SELECT DESARROLLO_NEGOCIOS FROM accesos WHERE USUARIO = '" + SESION.usuario + "'");
            string consulta = tabla.Rows[0].Cells[0].Value.ToString();
            if (consulta == "AUTORIZADO")
            {

                contenido.Controls.Clear();
                ordenes = new PAN_DNS();
                ordenes.TopLevel = false;
                contenido.Controls.Add(ordenes);
                ordenes.Show();

            }
            else
            {
                MENSAJE_GENERAL mn = new MENSAJE_GENERAL();
                mn.BOTON.Text = "No cuentas con acceso a esta área de trabajo, consultalo en control de calidad";
                mn.ShowDialog();
            }



        }












        public static PAN_SUPERVISION cortaps = new PAN_SUPERVISION();
        private void label9_Click(object sender, EventArgs e)
        {
            tabla.DataSource = conexion_login.Consultageneral("SELECT 	SUPERVISIÓN FROM accesos WHERE USUARIO = '" + SESION.usuario + "'");
            string consulta = tabla.Rows[0].Cells[0].Value.ToString();
            if (consulta == "AUTORIZADO")
            {

                contenido.Controls.Clear();
                cortaps = new PAN_SUPERVISION();
                cortaps.TopLevel = false;
                contenido.Controls.Add(cortaps);
                cortaps.Show();

            }
            else
            {
                MENSAJE_GENERAL mn = new MENSAJE_GENERAL();
                mn.BOTON.Text = "No cuentas con acceso a esta área de trabajo, consultalo en control de calidad";
                mn.ShowDialog();
            }




        }

        private void label8_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void label8_MouseLeave(object sender, EventArgs e)
        {
        }

        private void label9_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void label9_MouseLeave(object sender, EventArgs e)
        {

        }
        public static PAN_CALIDAD ordenesw = new PAN_CALIDAD();





        private void bunifuFlatButton11_Click(object sender, EventArgs e)
        {




        }

        // Evento para recalcular cuando el panel cambie de tamaño
        private void panel1_Resize(object sender, EventArgs e)
        {
            AjustarBotonesEnPanel();
        }

        // Llamar al iniciar

        private void bunifuFlatButton18_Click(object sender, EventArgs e)
        {

        }

        private void miperfil_Click(object sender, EventArgs e)
        {



        }

        private void panel18_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuImageButton14_Click(object sender, EventArgs e)
        {







        }

        private void panel_n_Paint(object sender, PaintEventArgs e)
        {

        }

        private void timer2_Tick(object sender, EventArgs e)
        {


        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

            tabla.DataSource = conexion_login.Consultageneral("SELECT SERVICIOS_EVENTUALES FROM accesos WHERE USUARIO = '" + SESION.usuario + "'");
            string consulta = tabla.Rows[0].Cells[0].Value.ToString();
            if (consulta == "AUTORIZADO")
            {

                contenido.Controls.Clear();
                DNS.MN_REV = new PAN_SUP();
                DNS.MN_REV.TopLevel = false;
                contenido.Controls.Add(DNS.MN_REV);
                DNS.MN_REV.Show();

            }
            else
            {
                MENSAJE_GENERAL mn = new MENSAJE_GENERAL();
                mn.BOTON.Text = "No cuentas con acceso a esta área de trabajo, consultalo en control de calidad";
                mn.ShowDialog();
            }



        }

        private void panel16_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FOTO_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void FOTO_MouseLeave(object sender, EventArgs e)
        {

        }

        private void FOTO_MouseMove_1(object sender, MouseEventArgs e)
        {
            FOTO.Image = ERP_COMPLETO.Properties.Resources.mi_usuario_naranja3;

        }

        private void FOTO_MouseLeave_1(object sender, EventArgs e)
        {
            FOTO.Image = ERP_COMPLETO.Properties.Resources.mi_usuario;

        }


        private void barra_operaciones()
        {
            if (panel3.Visible == false)
            {


                SIDEBAR_PRINCIPAL_OP agen = new SIDEBAR_PRINCIPAL_OP();
                agen.TopLevel = false;
                agen.Dock = DockStyle.Fill;
                panel3.Controls.Add(agen);
                agen.Show();
                panel3.Visible = true;


            }
            else
            {
                panel3.Visible = false;
                panel3.Controls.Clear();
            }

        }

        private void FOTO_Click(object sender, EventArgs e)
        {

            barra_operaciones();



        }















        //  public static  PAN_GEOTECNIA pan_geo = new PAN_GEOTECNIA();
        /*    private void label13_Click(object sender, EventArgs e)
            {
                contenido.Controls.Clear();
               // PAN_GEOTECNIA pan_geo = new PAN_GEOTECNIA();
                pan_geo.TopLevel = false;
                contenido.Controls.Add(pan_geo);
                pan_geo.Show();
            }
        */
        private void label14_Click(object sender, EventArgs e)
        {
            contenido.Controls.Clear();
            PAN_PND ordenes = new PAN_PND();
            ordenes.TopLevel = false;
            contenido.Controls.Add(ordenes);
            ordenes.Show();
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click_1(object sender, EventArgs e)
        {
            contenido.Controls.Clear();
            pan_estructuras ordenes = new pan_estructuras();
            ordenes.TopLevel = false;
            contenido.Controls.Add(ordenes);
            ordenes.Show();
        }

        private void pana1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }



        private void rjButton1_Click(object sender, EventArgs e)
        {

        }

        private void panel10_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void pictureBox2_MouseMove(object sender, MouseEventArgs e)
        {


        }

        private void label15_Click(object sender, EventArgs e)
        {
            contenido.Controls.Clear();
            PAN_CONTABILIDAD ordenes = new PAN_CONTABILIDAD();
            ordenes.TopLevel = false;
            contenido.Controls.Add(ordenes);
            ordenes.Show();
        }



        private void label8_Click(object sender, EventArgs e)
        {
            tabla.DataSource = conexion_login.Consultageneral("SELECT RECURSOS_HUMANOS FROM accesos WHERE USUARIO = '" + SESION.usuario + "'");
            string consulta = tabla.Rows[0].Cells[0].Value.ToString();
            if (consulta == "AUTORIZADO")
            {
                contenido.Controls.Clear();
                PAN_RH ordenes = new PAN_RH();
                ordenes.TopLevel = false;
                contenido.Controls.Add(ordenes);
                ordenes.Show();

            }
            else
            {
                MENSAJE_GENERAL mn = new MENSAJE_GENERAL();
                mn.BOTON.Text = "No cuentas con acceso a esta área de trabajo, consultalo en control de calidad";
                mn.ShowDialog();
            }




        }















        private void label10_Click(object sender, EventArgs e)
        {
            Form nv = new Form();
            using (SUB_LABORATORIO mn = new SUB_LABORATORIO())
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
                mn.Opacity = 0;






                mn.ShowDialog();

                nv.Dispose();
            }






        }
        public static PAN_ARQUITECTURA arq = new PAN_ARQUITECTURA();
        private void label11_Click(object sender, EventArgs e)
        {
            contenido.Controls.Clear();
            arq = new PAN_ARQUITECTURA();
            arq.TopLevel = false;
            contenido.Controls.Add(arq);
            arq.Show();
        }

        private void label25_Click(object sender, EventArgs e)
        {
            tabla.DataSource = conexion_login.Consultageneral("SELECT MANTENIMIENTO FROM accesos WHERE USUARIO = '" + SESION.usuario + "'");
            string consulta = tabla.Rows[0].Cells[0].Value.ToString();
            if (consulta == "AUTORIZADO")
            {

                contenido.Controls.Clear();
                CACHE_MTN.ND = new PAN_MTN();
                CACHE_MTN.ND.TopLevel = false;
                contenido.Controls.Add(CACHE_MTN.ND);
                CACHE_MTN.ND.Show();

            }
            else
            {
                MENSAJE_GENERAL mn = new MENSAJE_GENERAL();
                mn.BOTON.Text = "No cuentas con acceso a esta área de trabajo, consultalo en control de calidad";
                mn.ShowDialog();
            }




        }

        private void label26_Click(object sender, EventArgs e)
        {
            tabla.DataSource = conexion_login.Consultageneral("SELECT TIC FROM accesos WHERE USUARIO = '" + SESION.usuario + "'");
            string consulta = tabla.Rows[0].Cells[0].Value.ToString();
            if (consulta == "AUTORIZADO")
            {

                contenido.Controls.Clear();
                CACHE_TIC.ND = new PAN_TIC();
                CACHE_TIC.ND.TopLevel = false;
                contenido.Controls.Add(CACHE_TIC.ND);
                CACHE_TIC.ND.Show();

            }
            else
            {
                MENSAJE_GENERAL mn = new MENSAJE_GENERAL();
                mn.BOTON.Text = "No cuentas con acceso a esta área de trabajo, consultalo en control de calidad";
                mn.ShowDialog();
            }



        }


















        private void sub_equipo_Paint(object sender, PaintEventArgs e)
        {

        }
        public static PAN_COB index_cob = new PAN_COB();
        private void label16_Click(object sender, EventArgs e)
        {
            index_cob.Controls.Clear();
            DNS.MN_COB = new PAN_COB();
            DNS.MN_COB.TopLevel = false;
            contenido.Controls.Add(DNS.MN_COB);
            DNS.MN_COB.Show();
        }


        public static PAN_GEOTECNIA pan_geo = new PAN_GEOTECNIA();
        private void label13_Click(object sender, EventArgs e)
        {
            pan_geo.Controls.Clear();
            pan_geo = new PAN_GEOTECNIA();
            pan_geo.TopLevel = false;
            contenido.Controls.Add(pan_geo);
            pan_geo.Show();
        }
        string fecha_hoy;


        private void myBGWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            Invoke(new MethodInvoker(() =>
            {



                string de = " de ";
                fecha_hoy = DateTime.Today.ToString("dddd") + ", " + DateTime.Today.ToString("dd") + de + DateTime.Today.ToString("MMMM") + " " + DateTime.Today.ToString("yyyy");
                fecha_hoy = fecha_hoy.Substring(0, 1).ToUpper() + fecha_hoy.Substring(1, fecha_hoy.Length - 1); ;




                //      timer1.Start();
                //  notifica();

                textBox1.Text = SESION.name.ToLower();
                copyrhigt.Left = (this.Width - copyrhigt.Width) / 2;

                tabla.Visible = false;








            }));



        }

        private void myBGWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            DateTime Horareal = DateTime.Now;
            OP.registrar("INSERT INTO procesos_cotidianos (USUARIO,FECHA,TIEMPO,ACCION,IP_ADREES) VALUES ('" + SESION.usuario + "', '" + Horareal.ToString("yyyy-MM-dd") + "' ,'" + Horareal.ToString("HH:mm:ss") + "' , 'HA INICIADO SESIÓN', '" + SESION.IP + "')");

            tabla.DataSource = notificaciones_local.Consultageneral("SELECT * FROM notificacion WHERE USUARIO = '" + SESION.usuario + "' ORDER BY ID_SEGUIMIENTO DESC ");








        }

        bool avisadelsg = true;
        private void MENU_PRICIPAL_ERP_Shown(object sender, EventArgs e)
        {






        }

        public static PAN_PROCURACION pro = new PAN_PROCURACION();
        private void label31_Click(object sender, EventArgs e)
        {
            pro.Controls.Clear();
            pro = new PAN_PROCURACION();
            pro.TopLevel = false;
            contenido.Controls.Add(pro);
            pro.Show();
        }



        public void lista_obras()
        {
            contenido.Controls.Clear();
            CONSULTA_SERVICIOS_PERMANENTES ordenes2 = new CONSULTA_SERVICIOS_PERMANENTES();


            ordenes2.TopLevel = false;
            contenido.Controls.Add(ordenes2);
            ordenes2.Show();


        }

        private void contenido_Click(object sender, EventArgs e)
        {

        }

        private void timer2_Tick_1(object sender, EventArgs e)
        {







            tabla.DataSource = notificaciones_local.Consultageneral("SELECT * FROM notificacion WHERE USUARIO = '" + SESION.usuario + "'");


            if (tabla.RowCount == 0)
            {
                ntf_vacio = false;
                noti.Image = Properties.Resources.mi_campana;
            }
            else
            {
                ntf_vacio = true;

            }

            if (ntf_vacio == true)

            {
                if (consulado < tabla.RowCount)
                {
                    consulado = tabla.RowCount;



                    noti.Image = Properties.Resources.Mi_campana2;
                    ntf_vacio = false;
                }
                else
                {
                    noti.Image = Properties.Resources.Mi_campana2;
                    ntf_vacio = false;
                }
            }

            tabla.DataSource = notificaciones_local.Consultageneral("SELECT * FROM agenda_sp WHERE ESTATUS = 'PENDIENTE' AND MONTH(FECHA)='" + DateTime.Now.ToString("MM") + "' ");

            if (tabla.RowCount > 0)
            {

                foreach (DataGridViewRow row in tabla.Rows)
                {

                    MySqlConnection CONEXION = notificaciones_local.USR;

                    MySqlCommand comando = new MySqlCommand("SELECT * FROM responsable_ag WHERE NOMBRE = '" + SESION.name + "' AND  FOLIO = '" + row.Cells["FOLIO"].Value.ToString() + "' ", CONEXION);

                    CONEXION.Open();
                    MySqlDataReader consulta = comando.ExecuteReader();
                    if (consulta.Read())
                    {


                        pictureBox16.Image = ERP_COMPLETO.Properties.Resources.mi_age2;

                    }

                    else
                    {
                        pictureBox16.Image = ERP_COMPLETO.Properties.Resources.mi_age1;
                    }
                    CONEXION.Close();

                }

            }
            else
            {
                pictureBox16.Image = ERP_COMPLETO.Properties.Resources.mi_age1;
            }













        }



        private void pictureBox16_Click(object sender, EventArgs e)
        {
            contenido.Controls.Clear();
            AGENDA agen = new AGENDA();


            agen.TopLevel = false;
            contenido.Controls.Add(agen);
            agen.Show();
        }

        public static PRESUPUESTOS_GENERAL psn = new PRESUPUESTOS_GENERAL();



        private void label2_Click(object sender, EventArgs e)
        {
            Form3 df = new Form3();
            df.ShowDialog();
        }

        private void prsg_Click(object sender, EventArgs e)
        {
            Form2 df = new Form2();
            df.ShowDialog();
        }

        private void noti_MouseMove(object sender, MouseEventArgs e)
        {

            this.noti.Image = global::ERP_COMPLETO.Properties.Resources.ICO_NOTI_NAR;



        }

        private void noti_MouseLeave(object sender, EventArgs e)
        {
            this.noti.Image = global::ERP_COMPLETO.Properties.Resources.ICO_NOTI;

        }





        private void timer3_Tick(object sender, EventArgs e)
        {

            timer3.Stop();
            /*   if (SESION.CONF_SUC == SESION.contraseña)
               {
                   MENSAJE_GENERAL mn = new MENSAJE_GENERAL();
                   mn.BOTON.Text = "Cambia tu contraseña por seguridad";
                   mn.ShowDialog();

                   RECUPERA_ACCESO RC = new RECUPERA_ACCESO();
                   RC.ShowDialog();


               }*/




            if (SESION.usuario == "")
            {

            }
            else
            {



                if (SESION.CONF_SUC == string.Empty)
                {
                    MessageBox.Show("Necesitas configuar una sucursal en tu ERP", "Notificación de Operación", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    CONFIGURA_SUCURSAL RC = new CONFIGURA_SUCURSAL();
                    RC.ShowDialog();

                    this.Text = "Enterprise Resources Planning      C.T. " + SESION.CONF_SUC + "         SG:" + SESION.CON_RUT;
                }

                else
                {

                    if (SESION.CONF_SUC == "C.T. CENTRAL") { SESION.CON_RUT = @"Z:\02 CONTROL DE REGISTROS\00 LAB CENTRAL\"; }
                    else if (SESION.CONF_SUC == "C.T. TEPÓTZOTLÁN") { SESION.CON_RUT = @"Z:\02 CONTROL DE REGISTROS\01 SUC TEPOTZOTLÁN\"; }
                    else if (SESION.CONF_SUC == "C.T. SAN LUIS POTOSI") { SESION.CON_RUT = @"Z:\02 CONTROL DE REGISTROS\02 SUC SLP\"; }
                    else if (SESION.CONF_SUC == "C.T. LERMA") { SESION.CON_RUT = @"Z:\02 CONTROL DE REGISTROS\03 SUC LERMA\"; }
                    else if (SESION.CONF_SUC == "C.T. MÉRIDA") { SESION.CON_RUT = @"Z:\02 CONTROL DE REGISTROS\04 SUC MÉRIDA\"; }
                    else if (SESION.CONF_SUC == "C.T. TAPACHULA") { SESION.CON_RUT = @"Z:\02 CONTROL DE REGISTROS\05 SUC TAPACHULA\"; }

                    this.Text = "Enterprise Resources Planning      C.T. " + fecha_hoy + "      " + SESION.CONF_SUC + "         SG:" + SESION.CON_RUT;

                }

            }


        }




        int con = 0;



        private void Personal_btn_Click(object sender, EventArgs e)
        {





            // Elimina el botón "Talento"
            Control tal = contenido.Controls["Talento"];
            if (tal != null)
            {
                tal.Visible = false;
            }
            // Busca y elimina el botón "Geope" si existe
            Control geope = contenido.Controls["Geope"];
            if (geope != null)
            {
                geope.Visible = false;
            }

            tabla.DataSource = conexion_login.Consultageneral("SELECT RECURSOS_HUMANOS FROM accesos WHERE USUARIO = '" + SESION.usuario + "'");
            string consulta = tabla.Rows[0].Cells[0].Value.ToString();
            if (consulta == "AUTORIZADO")
            {

                PAN_RH ordenes = new PAN_RH();
                ordenes.TopLevel = false;
                contenido.Controls.Add(ordenes);
                ordenes.Show();

            }
            else
            {
                MENSAJE_GENERAL mn = new MENSAJE_GENERAL();
                mn.BOTON.Text = "No cuentas con acceso a esta área de trabajo, consultalo en control de calidad";
                mn.ShowDialog();
            }








            reseteacolor_btns();
        }

        private void GEOP_btn_Click(object sender, EventArgs e)
        {





            // Elimina el botón "Talento"
            Control tal = contenido.Controls["Talento"];
            if (tal != null)
            {
                tal.Visible = false;
            }
            // Busca y elimina el botón "Geope" si existe
            Control geope = contenido.Controls["Geope"];
            if (geope != null)
            {
                geope.Visible = false;
            }


            tabla.DataSource = conexion_login.Consultageneral("SELECT 	SUPERVISIÓN FROM accesos WHERE USUARIO = '" + SESION.usuario + "'");
            string consulta = tabla.Rows[0].Cells[0].Value.ToString();
            if (consulta == "AUTORIZADO")
            {


                cortaps = new PAN_SUPERVISION();
                cortaps.TopLevel = false;
                contenido.Controls.Add(cortaps);
                cortaps.Show();

            }
            else
            {
                MENSAJE_GENERAL mn = new MENSAJE_GENERAL();
                mn.BOTON.Text = "No cuentas con acceso a esta área de trabajo, consultalo en control de calidad";
                mn.ShowDialog();
            }






            reseteacolor_btns();
        }
        private void personal_bt_Click(object sender, EventArgs e)
        {


            reseteacolor_btns();
            contenido.Controls.Clear();
            personal_bt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(92)))), ((int)(((byte)(0)))));



            ////////////elimina  si existen
            ///
            Control tal = contenido.Controls["Talento"];
            if (tal != null)
            {
                contenido.Controls.Remove(tal);
            }
            // Busca y elimina el botón "Geope" si existe
            Control geope = contenido.Controls["Geope"];
            if (geope != null)
            {
                contenido.Controls.Remove(geope);
            }













            // bunifuFlatButton1
            // 

            Bunifu.Framework.UI.BunifuFlatButton Talento = new Bunifu.Framework.UI.BunifuFlatButton();

            Talento.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(59)))), ((int)(((byte)(3)))));
            Talento.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(59)))), ((int)(((byte)(3)))));
            Talento.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            Talento.BorderRadius = 0;
            Talento.ButtonText = " Talento Humano";
            Talento.Cursor = System.Windows.Forms.Cursors.Hand;
            Talento.DisabledColor = System.Drawing.Color.Transparent;
            Talento.Font = new System.Drawing.Font("Poppins", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            Talento.Iconcolor = System.Drawing.Color.FromArgb(225, 90, 0);
            Talento.Iconimage = null;
            Talento.Iconimage_right = null;
            Talento.Iconimage_right_Selected = null;
            Talento.Iconimage_Selected = null;
            Talento.IconMarginLeft = 15;
            Talento.IconMarginRight = 0;
            Talento.IconRightVisible = true;
            Talento.IconRightZoom = 0D;
            Talento.IconVisible = true;
            Talento.IconZoom = 50D;
            Talento.IsTab = false;
            Talento.Location = new System.Drawing.Point(2, personal_bt.Top);
            Talento.Click += Personal_btn_Click;
            Talento.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Talento.Name = "Talento";
            Talento.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(92)))), ((int)(((byte)(0)))));
            Talento.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(59)))), ((int)(((byte)(3)))));
            Talento.OnHoverTextColor = System.Drawing.Color.White;
            Talento.selected = false;
            Talento.Size = new System.Drawing.Size(223, 42);
            Talento.TabIndex = 0;
            Talento.Text = "Talento Humano y C.O.";
            Talento.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            Talento.Textcolor = System.Drawing.Color.White;
            Talento.TextFont = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            contenido.Controls.Add(Talento);


            ///////////////////////
            ///



            Bunifu.Framework.UI.BunifuFlatButton Geope = new Bunifu.Framework.UI.BunifuFlatButton();

            Geope.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(59)))), ((int)(((byte)(3)))));
            Geope.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(59)))), ((int)(((byte)(3)))));
            Geope.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            Geope.BorderRadius = 0;
            Geope.ButtonText = "G.O.";
            Geope.Cursor = System.Windows.Forms.Cursors.Hand;
            Geope.DisabledColor = System.Drawing.Color.Transparent;
            Geope.Font = new System.Drawing.Font("Poppins", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            Geope.Iconcolor = System.Drawing.Color.FromArgb(225, 90, 0);
            Geope.Iconimage = null;
            Geope.Iconimage_right = null;
            Geope.Iconimage_right_Selected = null;
            Geope.Iconimage_Selected = null;
            Geope.IconMarginLeft = 15;
            Geope.IconMarginRight = 0;
            Geope.IconRightVisible = true;
            Geope.IconRightZoom = 0D;
            Geope.IconVisible = true;
            Geope.IconZoom = 50D;
            Geope.IsTab = false;
            Geope.Location = new System.Drawing.Point(2, Talento.Bottom + 3);
            Geope.Click += GEOP_btn_Click;
            Geope.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Geope.Name = "Geope";
            Geope.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(92)))), ((int)(((byte)(0)))));
            Geope.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(59)))), ((int)(((byte)(3)))));
            Geope.OnHoverTextColor = System.Drawing.Color.White;
            Geope.selected = false;
            Geope.Size = new System.Drawing.Size(223, 42);
            Geope.TabIndex = 0;
            Geope.Text = "Gerencia Operativa";
            Geope.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            Geope.Textcolor = System.Drawing.Color.White;
            Geope.TextFont = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            contenido.Controls.Add(Geope);







        }
        private void equipa_btn_Click(object sender, EventArgs e)
        {





            // Elimina el botón "Talento"
            Control tal = contenido.Controls["Infraestructura"];
            if (tal != null)
            {
                tal.Visible = false;
            }
            // Busca y elimina el botón "Geope" si existe
            Control geope = contenido.Controls["Tic"];
            if (geope != null)
            {
                geope.Visible = false;
            }

            tabla.DataSource = conexion_login.Consultageneral("SELECT MANTENIMIENTO FROM accesos WHERE USUARIO = '" + SESION.usuario + "'");
            string consulta = tabla.Rows[0].Cells[0].Value.ToString();
            if (consulta == "AUTORIZADO")
            {


                CACHE_MTN.ND = new PAN_MTN();
                CACHE_MTN.ND.TopLevel = false;
                contenido.Controls.Add(CACHE_MTN.ND);
                CACHE_MTN.ND.Show();

            }
            else
            {
                MENSAJE_GENERAL mn = new MENSAJE_GENERAL();
                mn.BOTON.Text = "No cuentas con acceso a esta área de trabajo, consultalo en control de calidad";
                mn.ShowDialog();
            }










            reseteacolor_btns();
        }

        private void tic_btn_Click(object sender, EventArgs e)
        {





            // Elimina el botón "Talento"
            Control tal = contenido.Controls["Infraestructura"];
            if (tal != null)
            {
                tal.Visible = false;
            }
            // Busca y elimina el botón "Geope" si existe
            Control geope = contenido.Controls["Tic"];
            if (geope != null)
            {
                geope.Visible = false;
            }

            tabla.DataSource = conexion_login.Consultageneral("SELECT TIC FROM accesos WHERE USUARIO = '" + SESION.usuario + "'");
            string consulta = tabla.Rows[0].Cells[0].Value.ToString();
            if (consulta == "AUTORIZADO")
            {


                CACHE_TIC.ND = new PAN_TIC();
                CACHE_TIC.ND.TopLevel = false;
                contenido.Controls.Add(CACHE_TIC.ND);
                CACHE_TIC.ND.Show();

            }
            else
            {
                MENSAJE_GENERAL mn = new MENSAJE_GENERAL();
                mn.BOTON.Text = "No cuentas con acceso a esta área de trabajo, consultalo en control de calidad";
                mn.ShowDialog();
            }








            reseteacolor_btns();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            reseteacolor_btns();
            contenido.Controls.Clear();
            equip_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(92)))), ((int)(((byte)(0)))));



            ////////////elimina  si existen
            ///
            Control infrae = contenido.Controls["Infraestructura"];
            if (infrae != null)
            {
                contenido.Controls.Remove(infrae);
            }
            // Busca y elimina el botón "Geope" si existe
            Control ti = contenido.Controls["Tic"];
            if (ti != null)
            {
                contenido.Controls.Remove(ti);
            }













            // bunifuFlatButton1
            // 

            Bunifu.Framework.UI.BunifuFlatButton Infraestructura = new Bunifu.Framework.UI.BunifuFlatButton();

            Infraestructura.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(59)))), ((int)(((byte)(3)))));
            Infraestructura.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(59)))), ((int)(((byte)(3)))));
            Infraestructura.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            Infraestructura.BorderRadius = 0;
            Infraestructura.ButtonText = " Infraestructura";
            Infraestructura.Cursor = System.Windows.Forms.Cursors.Hand;
            Infraestructura.DisabledColor = System.Drawing.Color.Transparent;
            Infraestructura.Font = new System.Drawing.Font("Poppins", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            Infraestructura.Iconcolor = System.Drawing.Color.FromArgb(225, 90, 0);
            Infraestructura.Iconimage = null;
            Infraestructura.Iconimage_right = null;
            Infraestructura.Iconimage_right_Selected = null;
            Infraestructura.Iconimage_Selected = null;
            Infraestructura.IconMarginLeft = 15;
            Infraestructura.IconMarginRight = 0;
            Infraestructura.IconRightVisible = true;
            Infraestructura.IconRightZoom = 0D;
            Infraestructura.IconVisible = true;
            Infraestructura.IconZoom = 50D;
            Infraestructura.IsTab = false;
            Infraestructura.Location = new System.Drawing.Point(2, equip_btn.Top);
            Infraestructura.Click += equipa_btn_Click;
            Infraestructura.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Infraestructura.Name = "Infraestructura";
            Infraestructura.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(92)))), ((int)(((byte)(0)))));
            Infraestructura.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(59)))), ((int)(((byte)(3)))));
            Infraestructura.OnHoverTextColor = System.Drawing.Color.White;
            Infraestructura.selected = false;
            Infraestructura.Size = new System.Drawing.Size(223, 42);
            Infraestructura.TabIndex = 0;
            Infraestructura.Text = "Infraestructura.";
            Infraestructura.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            Infraestructura.Textcolor = System.Drawing.Color.White;
            Infraestructura.TextFont = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            contenido.Controls.Add(Infraestructura);


            ///////////////////////
            ///



            Bunifu.Framework.UI.BunifuFlatButton tic = new Bunifu.Framework.UI.BunifuFlatButton();

            tic.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(59)))), ((int)(((byte)(3)))));
            tic.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(59)))), ((int)(((byte)(3)))));
            tic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            tic.BorderRadius = 0;
            tic.ButtonText = "TIC";
            tic.Cursor = System.Windows.Forms.Cursors.Hand;
            tic.DisabledColor = System.Drawing.Color.Transparent;
            tic.Font = new System.Drawing.Font("Poppins", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            tic.Iconcolor = System.Drawing.Color.FromArgb(225, 90, 0);
            tic.Iconimage = null;
            tic.Iconimage_right = null;
            tic.Iconimage_right_Selected = null;
            tic.Iconimage_Selected = null;
            tic.IconMarginLeft = 15;
            tic.IconMarginRight = 0;
            tic.IconRightVisible = true;
            tic.IconRightZoom = 0D;
            tic.IconVisible = true;
            tic.IconZoom = 50D;
            tic.IsTab = false;
            tic.Location = new System.Drawing.Point(2, Infraestructura.Bottom + 3);
            tic.Click += tic_btn_Click;
            tic.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tic.Name = "Tic";
            tic.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(92)))), ((int)(((byte)(0)))));
            tic.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(59)))), ((int)(((byte)(3)))));
            tic.OnHoverTextColor = System.Drawing.Color.White;
            tic.selected = false;
            tic.Size = new System.Drawing.Size(223, 42);
            tic.TabIndex = 0;
            tic.Text = "Tecnologías de la Información";
            tic.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            tic.Textcolor = System.Drawing.Color.White;
            tic.TextFont = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            contenido.Controls.Add(tic);




        }

        private void button2_Click(object sender, EventArgs e)
        {

            reseteacolor_btns();
            contenido.Controls.Clear();


            oferta_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(92)))), ((int)(((byte)(0)))));



            ////////////elimina  si existen
            ///
            Control dns_btn = contenido.Controls["dns"];
            if (dns_btn != null)
            {
                contenido.Controls.Remove(dns_btn);
            }
            // Busca y elimina el botón "Geope" si existe
            Control rev_btn = contenido.Controls["rev_btn"];
            if (rev_btn != null)
            {
                contenido.Controls.Remove(rev_btn);
            }




            // bunifuFlatButton1
            // 

            Bunifu.Framework.UI.BunifuFlatButton dns = new Bunifu.Framework.UI.BunifuFlatButton();

            dns.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(59)))), ((int)(((byte)(3)))));
            dns.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(59)))), ((int)(((byte)(3)))));
            dns.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            dns.BorderRadius = 0;
            dns.ButtonText = "dns";
            dns.Cursor = System.Windows.Forms.Cursors.Hand;
            dns.DisabledColor = System.Drawing.Color.Transparent;
            dns.Font = new System.Drawing.Font("Poppins", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dns.Iconcolor = System.Drawing.Color.FromArgb(225, 90, 0);
            dns.Iconimage = null;
            dns.Iconimage_right = null;
            dns.Iconimage_right_Selected = null;
            dns.Iconimage_Selected = null;
            dns.IconMarginLeft = 15;
            dns.IconMarginRight = 0;
            dns.IconRightVisible = true;
            dns.IconRightZoom = 0D;
            dns.IconVisible = true;
            dns.IconZoom = 50D;
            dns.IsTab = false;
            dns.Location = new System.Drawing.Point(2, oferta_btn.Top);
            dns.Click += dns_btn_Click;
            dns.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            dns.Name = "dns";
            dns.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(92)))), ((int)(((byte)(0)))));
            dns.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(59)))), ((int)(((byte)(3)))));
            dns.OnHoverTextColor = System.Drawing.Color.White;
            dns.selected = false;
            dns.Size = new System.Drawing.Size(223, 42);
            dns.TabIndex = 0;
            dns.Text = "Desarrollo de Negocios";
            dns.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            dns.Textcolor = System.Drawing.Color.White;
            dns.TextFont = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            contenido.Controls.Add(dns);


            ///////////////////////
            ///



            Bunifu.Framework.UI.BunifuFlatButton rev = new Bunifu.Framework.UI.BunifuFlatButton();

            rev.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(59)))), ((int)(((byte)(3)))));
            rev.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(59)))), ((int)(((byte)(3)))));
            rev.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            rev.BorderRadius = 0;
            rev.ButtonText = "Revisión de solicitudes";
            rev.Cursor = System.Windows.Forms.Cursors.Hand;
            rev.DisabledColor = System.Drawing.Color.Transparent;
            rev.Font = new System.Drawing.Font("Poppins", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            rev.Iconcolor = System.Drawing.Color.FromArgb(225, 90, 0);
            rev.Iconimage = null;
            rev.Iconimage_right = null;
            rev.Iconimage_right_Selected = null;
            rev.Iconimage_Selected = null;
            rev.IconMarginLeft = 15;
            rev.IconMarginRight = 0;
            rev.IconRightVisible = true;
            rev.IconRightZoom = 0D;
            rev.IconVisible = true;
            rev.IconZoom = 50D;
            rev.IsTab = false;
            rev.Location = new System.Drawing.Point(2, dns.Bottom + 3);
            rev.Click += rev_btn_Click;
            rev.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            rev.Name = "rev";
            rev.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(92)))), ((int)(((byte)(0)))));
            rev.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(59)))), ((int)(((byte)(3)))));
            rev.OnHoverTextColor = System.Drawing.Color.White;
            rev.selected = false;
            rev.Size = new System.Drawing.Size(223, 42);
            rev.TabIndex = 0;
            rev.Text = "Revisión de solicitudes";
            rev.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            rev.Textcolor = System.Drawing.Color.White;
            rev.TextFont = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            contenido.Controls.Add(rev);




















            /*
            tabla.DataSource = conexion_login.Consultageneral("SELECT OFERTAS FROM accesos WHERE USUARIO = '" + SESION.usuario + "'");
            string consulta = tabla.Rows[0].Cells[0].Value.ToString();
            if (consulta == "AUTORIZADO")
            {
               

            }
            else
            {
                MENSAJE_GENERAL MN = new MENSAJE_GENERAL();
                MN.BOTON.Text = "No Cuentas Con Acceso a Este Procedimiento";
                MN.ShowDialog();
            }
           */
        }

        private void button3_Click(object sender, EventArgs e)
        {
            reseteacolor_btns();
            contenido.Controls.Clear();

            operaciones_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(92)))), ((int)(((byte)(0)))));



            ////////////elimina  si existen
            ///

            // Elimina el botón "Talento"
            Control tal = contenido.Controls["lab"];
            if (tal != null)
            {
                contenido.Controls.Remove(tal);
            }
            // Busca y elimina el botón "Geope" si existe
            Control geope = contenido.Controls["ms"];
            if (geope != null)
            {
                contenido.Controls.Remove(geope); ;
            }

            // Busca y elimina el botón "Geope" si existe
            Control estct = contenido.Controls["est"];
            if (estct != null)
            {
                contenido.Controls.Remove(estct);
            }

            // Busca y elimina el botón "Geope" si existe
            Control arqu = contenido.Controls["arq"];
            if (arqu != null)
            {
                contenido.Controls.Remove(arqu);
            }



            // bunifuFlatButton1
            // 

            Bunifu.Framework.UI.BunifuFlatButton lab = new Bunifu.Framework.UI.BunifuFlatButton();

            lab.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(59)))), ((int)(((byte)(3)))));
            lab.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(59)))), ((int)(((byte)(3)))));
            lab.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            lab.BorderRadius = 0;
            lab.ButtonText = "lab";
            lab.Cursor = System.Windows.Forms.Cursors.Hand;
            lab.DisabledColor = System.Drawing.Color.Transparent;
            lab.Font = new System.Drawing.Font("Poppins", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lab.Iconcolor = System.Drawing.Color.FromArgb(225, 90, 0);
            lab.Iconimage = null;
            lab.Iconimage_right = null;
            lab.Iconimage_right_Selected = null;
            lab.Iconimage_Selected = null;
            lab.IconMarginLeft = 15;
            lab.IconMarginRight = 0;
            lab.IconRightVisible = true;
            lab.IconRightZoom = 0D;
            lab.IconVisible = true;
            lab.IconZoom = 50D;
            lab.IsTab = false;
            lab.Location = new System.Drawing.Point(2, operaciones_btn.Top);
            lab.Click += lab_btn_Click;
            lab.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            lab.Name = "lab";
            lab.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(92)))), ((int)(((byte)(0)))));
            lab.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(59)))), ((int)(((byte)(3)))));
            lab.OnHoverTextColor = System.Drawing.Color.White;
            lab.selected = false;
            lab.Size = new System.Drawing.Size(223, 42);
            lab.TabIndex = 0;
            lab.Text = "Laboratorio";
            lab.BringToFront();
            lab.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            lab.Textcolor = System.Drawing.Color.White;
            lab.TextFont = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            contenido.Controls.Add(lab);


            ///////////////////////
            ///



            Bunifu.Framework.UI.BunifuFlatButton ms = new Bunifu.Framework.UI.BunifuFlatButton();

            ms.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(59)))), ((int)(((byte)(3)))));
            ms.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(59)))), ((int)(((byte)(3)))));
            ms.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            ms.BorderRadius = 0;
            ms.ButtonText = "Mecánica de suelos";
            ms.Cursor = System.Windows.Forms.Cursors.Hand;
            ms.DisabledColor = System.Drawing.Color.Transparent;
            ms.Font = new System.Drawing.Font("Poppins", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ms.Iconcolor = System.Drawing.Color.FromArgb(225, 90, 0);
            ms.Iconimage = null;
            ms.Iconimage_right = null;
            ms.Iconimage_right_Selected = null;
            ms.Iconimage_Selected = null;
            ms.IconMarginLeft = 15;
            ms.IconMarginRight = 0;
            ms.IconRightVisible = true;
            ms.IconRightZoom = 0D;
            ms.IconVisible = true;
            ms.IconZoom = 50D;
            ms.IsTab = false;
            ms.Location = new System.Drawing.Point(2, lab.Bottom + 3);
            ms.Click += ms_btn_Click;
            ms.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            ms.Name = "ms";
            ms.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(92)))), ((int)(((byte)(0)))));
            ms.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(59)))), ((int)(((byte)(3)))));
            ms.OnHoverTextColor = System.Drawing.Color.White;
            ms.selected = false;
            ms.Size = new System.Drawing.Size(223, 42);
            ms.TabIndex = 0;
            ms.Text = "Mecánica de suelos";
            ms.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            ms.Textcolor = System.Drawing.Color.White;
            ms.TextFont = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ms.BringToFront();
            contenido.Controls.Add(ms);







            Bunifu.Framework.UI.BunifuFlatButton est = new Bunifu.Framework.UI.BunifuFlatButton();

            est.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(59)))), ((int)(((byte)(3)))));
            est.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(59)))), ((int)(((byte)(3)))));
            est.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            est.BorderRadius = 0;
            est.ButtonText = "Estructuras";
            est.Cursor = System.Windows.Forms.Cursors.Hand;
            est.DisabledColor = System.Drawing.Color.Transparent;
            est.Font = new System.Drawing.Font("Poppins", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            est.Iconcolor = System.Drawing.Color.FromArgb(225, 90, 0);
            est.Iconimage = null;
            est.Iconimage_right = null;
            est.Iconimage_right_Selected = null;
            est.Iconimage_Selected = null;
            est.IconMarginLeft = 15;
            est.IconMarginRight = 0;
            est.IconRightVisible = true;
            est.IconRightZoom = 0D;
            est.IconVisible = true;
            est.IconZoom = 50D;
            est.IsTab = false;
            est.Location = new System.Drawing.Point(2, ms.Bottom + 3);
            est.Click += est_btn_Click;
            est.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            est.Name = "est";
            est.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(92)))), ((int)(((byte)(0)))));
            est.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(59)))), ((int)(((byte)(3)))));
            est.OnHoverTextColor = System.Drawing.Color.White;
            est.selected = false;
            est.Size = new System.Drawing.Size(223, 42);
            est.TabIndex = 0;
            est.Text = "Estructuras";
            est.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            est.Textcolor = System.Drawing.Color.White;
            est.TextFont = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            est.BringToFront();
            contenido.Controls.Add(est);









            Bunifu.Framework.UI.BunifuFlatButton arq = new Bunifu.Framework.UI.BunifuFlatButton();

            arq.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(59)))), ((int)(((byte)(3)))));
            arq.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(59)))), ((int)(((byte)(3)))));
            arq.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            arq.BorderRadius = 0;
            arq.ButtonText = "Arquitectura";
            arq.Cursor = System.Windows.Forms.Cursors.Hand;
            arq.DisabledColor = System.Drawing.Color.Transparent;
            arq.Font = new System.Drawing.Font("Poppins", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            arq.Iconcolor = System.Drawing.Color.FromArgb(225, 90, 0);
            arq.Iconimage = null;
            arq.Iconimage_right = null;
            arq.Iconimage_right_Selected = null;
            arq.Iconimage_Selected = null;
            arq.IconMarginLeft = 15;
            arq.IconMarginRight = 0;
            arq.IconRightVisible = true;
            arq.IconRightZoom = 0D;
            arq.IconVisible = true;
            arq.IconZoom = 50D;
            arq.IsTab = false;
            arq.Location = new System.Drawing.Point(2, est.Bottom + 3);
            arq.Click += arq_btn_Click;
            arq.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            arq.Name = "arq";
            arq.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(92)))), ((int)(((byte)(0)))));
            arq.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(59)))), ((int)(((byte)(3)))));
            arq.OnHoverTextColor = System.Drawing.Color.White;
            arq.selected = false;
            arq.Size = new System.Drawing.Size(223, 42);
            arq.TabIndex = 0;
            arq.Text = "Arquitectura";
            arq.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            arq.Textcolor = System.Drawing.Color.White;
            arq.TextFont = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            arq.BringToFront();
            contenido.Controls.Add(arq);


















            /*

            tabla.DataSource = conexion_login.Consultageneral("SELECT OPERACIONES FROM accesos WHERE USUARIO = '" + SESION.usuario + "'");
            string consulta = tabla.Rows[0].Cells[0].Value.ToString();
            if (consulta == "AUTORIZADO")
            {
               

            }
            else
            {
                MENSAJE_GENERAL MN = new MENSAJE_GENERAL();
                MN.BOTON.Text = "No Cuentas Con Acceso a Este Procedimiento";
                MN.ShowDialog();
            }
            */

        }

        private void button4_Click(object sender, EventArgs e)
        {


            tabla.DataSource = conexion_login.Consultageneral("SELECT CALIDAD FROM accesos WHERE USUARIO = '" + SESION.usuario + "'");
            string consulta = tabla.Rows[0].Cells[0].Value.ToString();
            if (consulta == "AUTORIZADO")
            {

                contenido.Controls.Clear();
                ordenesw = new PAN_CALIDAD();
                ordenesw.TopLevel = false;
                contenido.Controls.Add(ordenesw);
                ordenesw.Show();

            }
            else
            {
                MENSAJE_GENERAL mn = new MENSAJE_GENERAL();
                mn.BOTON.Text = "No cuentas con acceso a esta área de trabajo, consultalo en control de calidad";
                mn.ShowDialog();
            }








            reseteacolor_btns();
        }

        private void button5_Click(object sender, EventArgs e)
        {


            reseteacolor_btns();

            contenido.Controls.Clear();

            admin_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(92)))), ((int)(((byte)(0)))));



            ////////////elimina  si existen
            ///

            // Elimina el botón "Talento"
            Control tal = contenido.Controls["Cobranza"];
            if (tal != null)
            {
                contenido.Controls.Remove(tal);
            }
            // Busca y elimina el botón "Geope" si existe
            Control geope = contenido.Controls["Contabilidad"];
            if (geope != null)
            {
                contenido.Controls.Remove(geope); ;
            }

            // Busca y elimina el botón "Geope" si existe
            Control estct = contenido.Controls["Procuración"];
            if (estct != null)
            {
                contenido.Controls.Remove(estct);
            }





            // bunifuFlatButton1
            // 

            Bunifu.Framework.UI.BunifuFlatButton lab = new Bunifu.Framework.UI.BunifuFlatButton();

            lab.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(59)))), ((int)(((byte)(3)))));
            lab.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(59)))), ((int)(((byte)(3)))));
            lab.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            lab.BorderRadius = 0;
            lab.ButtonText = "Cobranza";
            lab.Cursor = System.Windows.Forms.Cursors.Hand;
            lab.DisabledColor = System.Drawing.Color.Transparent;
            lab.Font = new System.Drawing.Font("Poppins", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lab.Iconcolor = System.Drawing.Color.FromArgb(225, 90, 0);
            lab.Iconimage = null;
            lab.Iconimage_right = null;
            lab.Iconimage_right_Selected = null;
            lab.Iconimage_Selected = null;
            lab.IconMarginLeft = 15;
            lab.IconMarginRight = 0;
            lab.IconRightVisible = true;
            lab.IconRightZoom = 0D;
            lab.IconVisible = true;
            lab.IconZoom = 50D;
            lab.IsTab = false;
            lab.Location = new System.Drawing.Point(2, admin_btn.Top);
            lab.Click += cob_btn_Click;
            lab.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            lab.Name = "Cobranza";
            lab.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(92)))), ((int)(((byte)(0)))));
            lab.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(59)))), ((int)(((byte)(3)))));
            lab.OnHoverTextColor = System.Drawing.Color.White;
            lab.selected = false;
            lab.Size = new System.Drawing.Size(223, 42);
            lab.TabIndex = 0;
            lab.Text = "Cobranza";
            lab.BringToFront();
            lab.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            lab.Textcolor = System.Drawing.Color.White;
            lab.TextFont = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            contenido.Controls.Add(lab);


            ///////////////////////
            ///



            Bunifu.Framework.UI.BunifuFlatButton ms = new Bunifu.Framework.UI.BunifuFlatButton();

            ms.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(59)))), ((int)(((byte)(3)))));
            ms.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(59)))), ((int)(((byte)(3)))));
            ms.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            ms.BorderRadius = 0;
            ms.ButtonText = "Contabilidad";
            ms.Cursor = System.Windows.Forms.Cursors.Hand;
            ms.DisabledColor = System.Drawing.Color.Transparent;
            ms.Font = new System.Drawing.Font("Poppins", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ms.Iconcolor = System.Drawing.Color.FromArgb(225, 90, 0);
            ms.Iconimage = null;
            ms.Iconimage_right = null;
            ms.Iconimage_right_Selected = null;
            ms.Iconimage_Selected = null;
            ms.IconMarginLeft = 15;
            ms.IconMarginRight = 0;
            ms.IconRightVisible = true;
            ms.IconRightZoom = 0D;
            ms.IconVisible = true;
            ms.IconZoom = 50D;
            ms.IsTab = false;
            ms.Location = new System.Drawing.Point(2, lab.Bottom + 3);
            ms.Click += con_btn_Click;
            ms.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            ms.Name = "Contabilidad";
            ms.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(92)))), ((int)(((byte)(0)))));
            ms.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(59)))), ((int)(((byte)(3)))));
            ms.OnHoverTextColor = System.Drawing.Color.White;
            ms.selected = false;
            ms.Size = new System.Drawing.Size(223, 42);
            ms.TabIndex = 0;
            ms.Text = "Contabilidad";
            ms.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            ms.Textcolor = System.Drawing.Color.White;
            ms.TextFont = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ms.BringToFront();
            contenido.Controls.Add(ms);







            Bunifu.Framework.UI.BunifuFlatButton est = new Bunifu.Framework.UI.BunifuFlatButton();

            est.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(59)))), ((int)(((byte)(3)))));
            est.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(59)))), ((int)(((byte)(3)))));
            est.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            est.BorderRadius = 0;
            est.ButtonText = "Procuración";
            est.Cursor = System.Windows.Forms.Cursors.Hand;
            est.DisabledColor = System.Drawing.Color.Transparent;
            est.Font = new System.Drawing.Font("Poppins", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            est.Iconcolor = System.Drawing.Color.FromArgb(225, 90, 0);
            est.Iconimage = null;
            est.Iconimage_right = null;
            est.Iconimage_right_Selected = null;
            est.Iconimage_Selected = null;
            est.IconMarginLeft = 15;
            est.IconMarginRight = 0;
            est.IconRightVisible = true;
            est.IconRightZoom = 0D;
            est.IconVisible = true;
            est.IconZoom = 50D;
            est.IsTab = false;
            est.Location = new System.Drawing.Point(2, ms.Bottom + 3);
            est.Click += pro_btn_Click;
            est.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            est.Name = "Procuración";
            est.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(92)))), ((int)(((byte)(0)))));
            est.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(59)))), ((int)(((byte)(3)))));
            est.OnHoverTextColor = System.Drawing.Color.White;
            est.selected = false;
            est.Size = new System.Drawing.Size(223, 42);
            est.TabIndex = 0;
            est.Text = "Procuración";
            est.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            est.Textcolor = System.Drawing.Color.White;
            est.TextFont = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            est.BringToFront();
            contenido.Controls.Add(est);






            /*
            tabla.DataSource = conexion_login.Consultageneral("SELECT ADMINISTRACION FROM accesos WHERE USUARIO = '" + SESION.usuario + "'");
            string consulta = tabla.Rows[0].Cells[0].Value.ToString();
            if (consulta == "AUTORIZADO")
            {
               
            }
            else
            {
                MENSAJE_GENERAL MN = new MENSAJE_GENERAL();
                MN.BOTON.Text = "No Cuentas Con Acceso a Este Procedimiento";
                MN.ShowDialog();
            }
               */
        }

        private void prsg_MouseMove(object sender, MouseEventArgs e)
        {
            this.prsg.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

        }

        private void prsg_MouseLeave(object sender, EventArgs e)
        {
            this.prsg.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

        }

        private void cerrar_sesion_Click(object sender, EventArgs e)
        {
            LOGIN lg = new LOGIN();
            this.Hide();
            lg.ShowDialog();
            this.Close();
        }

        private void contenido_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void MENU_PRICIPAL_ERP_FormClosed(object sender, FormClosedEventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            PUBLICACIONES_LIEC pl = new PUBLICACIONES_LIEC();
            pl.ShowDialog();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            /*
                       MENU_PRI.PNC.TopLevel = false;
                        contenido.Controls.Add(MENU_PRI.PNC);
                        MENU_PRI.PNC.Show();*/
            timer1.Stop();
        }
    }
}
