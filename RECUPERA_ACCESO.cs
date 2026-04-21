using ERP_LIEC;
using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace ERP_COMPLETO
{
    public partial class RECUPERA_ACCESO : Form
    {
        public RECUPERA_ACCESO()
        {
            InitializeComponent();
        }
        string foleo;
        int ran;

        private void oersonal()
        {


            MySqlConnection CONEXION1 = conexion_rh.USR;
            MySqlCommand comando = new MySqlCommand("SELECT DISTINCTROW NOMBRE FROM pdr_personal1  WHERE ESTATUS = 'ACTIVO' ", CONEXION1);
            CONEXION1.Open();
            MySqlDataReader registro = comando.ExecuteReader();

            while (registro.Read())
            {

                usuario.Items.Add(registro["NOMBRE"].ToString());


            }

            CONEXION1.Close();








        }
        private void consulta_datos()
        {
            MySqlConnection CONEXION = conexion_rh.USR;

            MySqlCommand comando = new MySqlCommand("SELECT * FROM  pdr_personal1 WHERE NOMBRE = '" + usuario.Texts + "' AND EMAIL = '" + email.Texts + "'", CONEXION);

            CONEXION.Open();
            MySqlDataReader consulta = comando.ExecuteReader();
            if (consulta.Read() == false)
            {
                MENSAJE_GENERAL MN = new MENSAJE_GENERAL();
                MN.BOTON.Text = "No tenemos registro de los datos capturados, verifica tu captura";
                MN.ShowDialog();
            }
            else
            {
                Random ins = new Random();
                ran = ins.Next(1, 562);

                var outlook = new Microsoft.Office.Interop.Outlook.Application();

                //crear objeto MailItem
                var mailitem = (Microsoft.Office.Interop.Outlook.MailItem)outlook.CreateItem(Microsoft.Office.Interop.Outlook.OlItemType.olMailItem);

                //configuracion de los campos para el envio del correo
                mailitem.Subject = "RECUPERACIÓN DE CONTRASEÑA";
                mailitem.To = email.Texts;
                mailitem.BodyFormat = Microsoft.Office.Interop.Outlook.OlBodyFormat.olFormatHTML;

                mailitem.GetInspector.Display(false); // Necesario para obtener la firma
                string firma = mailitem.HTMLBody;


                mailitem.HTMLBody = "TU FOLIO DE RECUPERACIÓN ES: " + ran.ToString() + firma;


                mailitem.Send();


                System.Runtime.InteropServices.Marshal.ReleaseComObject(mailitem);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(outlook);

                MENSAJE_GENERAL mn = new MENSAJE_GENERAL();
                mn.BOTON.Text = "VERIFICA TÚ CORREO";
                mn.ShowDialog();




                /* Random ins = new Random();
                 ran = ins.Next(1,562);

                 string to = email.Texts;
                 string emisor = "rokavillegas@outlook.com";
                 string contrase = "Tusabescual9.";
                 string asunto = "RECUPERACIÓN DE CONTRASEÑA ";
                 string cuerpo = "TU FOLIO DE RECUPERACIÓN ES: " + ran.ToString();


                 MailMessage mensaje = new MailMessage(emisor, to, asunto, cuerpo);
                // mensaje.Attachments.Add(new Attachment(ruta3));
                 mensaje.IsBodyHtml = true;
                 SmtpClient oSmtpClient = new SmtpClient("smtp.office365.com");
                 oSmtpClient.EnableSsl = true;
                 oSmtpClient.UseDefaultCredentials = false;
                 oSmtpClient.Host = "smtp.office365.com";
                 oSmtpClient.Port = 587;


                 oSmtpClient.Credentials = new System.Net.NetworkCredential(emisor, contrase);
                 oSmtpClient.Send(mensaje);
                 oSmtpClient.Dispose();*/


                /*
                MailMessage correo = new MailMessage();
                correo.From = new MailAddress("rokavillegas@outlook.com", foleo, System.Text.Encoding.UTF8);//Correo de salida
                correo.To.Add(email.Texts); //Correo destino?
                correo.Subject = "sd"; //Asunto
                correo.Body = "El folio para recuperar tu acceso es: " + foleo; //Mensaje del correo
                correo.IsBodyHtml = true;
                correo.Priority = MailPriority.Normal;
                SmtpClient smtp = new SmtpClient();
                smtp.UseDefaultCredentials = false;
                smtp.Host = "smtp.office365.com"; //Host del servidor de correo
                smtp.Port = 587; //Puerto de salida
                smtp.Credentials = new System.Net.NetworkCredential("rokavillegas@outlook.com", "Tusabescual9");//Cuenta de correo
                ServicePointManager.ServerCertificateValidationCallback = delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) { return true; };
                smtp.EnableSsl = true;//True si el servidor de correo permite ssl
              
                smtp.Send(correo);
                */

                abre_formulario();
                panel1.Enabled = true;

            }



            CONEXION.Close();
        }

        private void abre_formulario()
        {

            this.Width = 661;
            estatica();



        }

        private void estatica()
        {



            label2.Left = (this.Width - label2.Width) / 2;
            pictureBox11.Left = (this.Width - pictureBox11.Width) - 10;

        }
        private void altoButton1_Click(object sender, EventArgs e)
        {

            consulta_datos();






        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RECUPERA_ACCESO_Load(object sender, EventArgs e)
        {

            oersonal();
        }

        private void label32_Click(object sender, EventArgs e)
        {

        }

        private void altoButton2_Click(object sender, EventArgs e)
        {

            if (folio.Texts == ran.ToString())
            {
                conexion_login.USR.Close();///Importante cerrar porque anteriormente  se mantiene abierta la conexión al iniciar el formulario del LOGUEO

                conexion_login.USR.Open();//Se abre la conexión para evitar un error común

                String Query = "UPDATE usuarios SET password= '" + nueva.Texts + "', validar_password= '" + nueva.Texts + "'   WHERE nombre  = '" + usuario.Texts + "';";
                MySqlCommand comando = new MySqlCommand(Query, conexion_login.USR);//Se interpreta el comando del query
                comando.ExecuteNonQuery();//Se ejecuta el comando del query

                conexion_login.USR.Close();//Se cierra la conexión


                login_remota.USR.Open();//Se abre la conexión para evitar un error común

                String Query2 = "UPDATE usuarios SET password= '" + nueva.Texts + "', validar_password= '" + nueva.Texts + "'   WHERE nombre  = '" + usuario.Texts + "';";
                MySqlCommand comando2 = new MySqlCommand(Query2, login_remota.USR);//Se interpreta el comando del query
                comando2.ExecuteNonQuery();//Se ejecuta el comando del query

                login_remota.USR.Close();//Se cierra la conexión



                DateTime Horareal = DateTime.Now;//obtengo tiempo real en variable de fecha
                OP.registrar("INSERT INTO procesos_cotidianos (USUARIO,FECHA,TIEMPO,ACCION,IP_ADREES) VALUES ('" + SESION.usuario + "', '" + Horareal.ToString("yyyy-MM-dd") + "' ,'" + Horareal.ToString("HH:mm:ss") + "' , 'CAMBIO SU CONTRASEÑA DE ACCESO', '" + SESION.IP + "')");//se ejecuta insercion de operación


                MENSAJE_GENERAL mn = new MENSAJE_GENERAL();
                mn.BOTON.Text = "CONTRASEÑA DE ACCESO MODIFICADA CORRECTAMENTE";
                mn.ShowDialog();
                this.Close();
            }
            else
            {
                MENSAJE_GENERAL mn = new MENSAJE_GENERAL();
                mn.BOTON.Text = "FOLIO DE AUTENTICIDAD INCORRECTO";
                mn.ShowDialog();
            }



        }

        private void usuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Char.ToUpper(e.KeyChar);
        }
    }
}
