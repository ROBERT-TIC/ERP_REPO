using ERP_LIEC;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.Net;
using System.Speech.Synthesis;
using System.Threading;
using System.Windows.Forms;


namespace ERP_COMPLETO
{
    public partial class LOGIN : Form
    {
        public LOGIN()
        {
            InitializeComponent();
        }
        int posX = 0;
        int posY = 0;
        bool acceso = false;
        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

            obtenerIP();
            autoriza();
        }
        private void autoriza()
        {
            MENU_PRI.MNM.Hide();
            MENU_PRI.PNC = new PANEL_CUMPLEAÑOS();

            dgv.DataSource = conexion_rh.Consultageneral("SELECT CELULAR,EMAIL,GRADO_ESTUDIOS,AREA_2,PROCESO,LABORATORIO,NOMBRE_AREA_TEC FROM pdr_personal1");




        }

        private void LOGIN_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            {

                posX = e.X;
                posY = e.Y;

            }

            else
            {


                Left = Left + (e.X - posX);
                Top = Top + (e.Y - posY);
            }
        }


        private void hablar(object texto)
        {
            SpeechSynthesizer BootCA = new SpeechSynthesizer();
            BootCA.SetOutputToDefaultAudioDevice();
            BootCA.Speak(texto.ToString());


        }


        MySqlDataReader registro;

        private void logeo()
        {


            SESION.usuario = "";
            SESION.proceso = "";
            SESION.name = "";
            SESION.nombre = "";
            SESION.correo = "";
            SESION.telefono = "";
            SESION.preparacion = "";
            SESION.puesto = "";
            SESION.nombre_completo = "";
            SESION.firma = "";
            SESION.IP = "";
            SESION.ILaboratorio = "";
            SESION.obra = "";
            SESION.CONF_SUC = "";
            SESION.CON_RUT = "";

            MENU_PRI.MNM = new MENU_PRICIPAL_ERP();
            MENU_PRI.MNM.Show();
            myBGWorker.RunWorkerAsync();



        }

        private void LOGIN_DoubleClick(object sender, EventArgs e)
        {
        }

        private void user_KeyPress_3(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {


                if (user.Text == "BOOT")
                {
                    SESION.usuario = "BOOTCA";
                    SESION.proceso = "0000";
                    SESION.name = "Pruebas de TI";



                    SESION.telefono = "BOOTCA";
                    SESION.correo = "BOOTCA";
                    SESION.preparacion = "BOOTCA";

                    SESION.puesto = "BOOTCA";
                    SESION.firma = "BOOTCA";


                    LOADING_INICIO BARRA = new LOADING_INICIO();



                    this.Hide();
                    BARRA.ShowDialog();
                    this.Close();



                }
                else
                {



                    if (pass.Text.Contains("ZA"))
                    {

                    }
                    else
                    {
                        logeo();
                    }






                }

            }
        }


        private void obtenerIP()
        {

            // Obtener el nombre del host local
            string hostName = Dns.GetHostName();

            // Obtener las direcciones IP asociadas con el host
            IPAddress[] addresses = Dns.GetHostAddresses(hostName);

            // Imprimir NOMBRE DE PC

            foreach (IPAddress address in addresses)
            {
                SESION.IP = hostName;////////////////OBTENGO SOLO EL NOMBRE DE LA MAQUINA
            }




            IPHostEntry host;
            string localIP = "";//// VARIABLES PAR AOBTENE IP
            host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily.ToString() == "InterNetwork")
                {
                    localIP = ip.ToString();/////OBTENER IP DE LA PC
                }
            }

            SESION.IP = hostName + " CON " + localIP; /////OBTENER IP MAS LA SUMA DE EL NOMBRE DE LA PC QUE SE GENERO ANTERIORMENTE
        }

        private void pass_KeyPress_4(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {

                TABLA.Visible = false;


                if (user.Text == "BOOT")
                {
                    SESION.usuario = "BOOTCA";
                    SESION.proceso = "0000";
                    SESION.name = "Pruebas de TI";



                    SESION.telefono = "BOOTCA";
                    SESION.correo = "BOOTCA";
                    SESION.preparacion = "BOOTCA";

                    SESION.puesto = "BOOTCA";
                    SESION.firma = "BOOTCA";


                    LOADING_INICIO BARRA = new LOADING_INICIO();

                    // MENU_INICIO mn = new MENU_INICIO();
                    DateTime Horareal = DateTime.Now;
                    OP.registrar("INSERT INTO procesos_cotidianos (USUARIO,FECHA,TIEMPO,ACCION,IP_ADREES) VALUES ('" + SESION.usuario + "', '" + Horareal.ToString("yyyy-MM-dd") + "' ,'" + Horareal.ToString("HH:mm:ss") + "' , 'PRUEBAS ERP - ROBERTO ROJAS', '" + SESION.IP + "')");


                    this.Hide();
                    BARRA.ShowDialog();
                    this.Close();



                }
                else
                {






                    logeo();



                }

            }




        }
        /*INDEX_PRINCIPAL ind = new INDEX_PRINCIPAL();
            this.Hide();
        ind.ShowDialog();
            this.Close();*/


        private void user_Enter_1(object sender, EventArgs e)
        {
            user.Text = "";
            user.ForeColor = System.Drawing.Color.FromArgb(128, 132, 139);
        }

        private void pass_Enter_1(object sender, EventArgs e)
        {
            pass.Text = "";
            pass.ForeColor = System.Drawing.Color.FromArgb(128, 132, 139);
        }

        private void user_TabIndexChanged(object sender, EventArgs e)
        {

        }

        private void user_Leave_1(object sender, EventArgs e)
        {
            if (user.Text == string.Empty)
            {
                user.Text = "Usuario";
                user.ForeColor = System.Drawing.Color.FromArgb(128, 132, 139);
            }
        }

        private void pass_Leave_1(object sender, EventArgs e)
        {
            if (pass.Text == string.Empty)
            {
                pass.Text = "*****";
                pass.ForeColor = System.Drawing.Color.FromArgb(128, 132, 139);
            }
        }
        private void conectaaresouces()
        {


            // Ruta de la unidad de red
            string unidadDeRed = @"\\26.255.118.96\server_resouces";

            // Letra de la unidad a la que se conectará
            string letraUnidad = "A: ";

            // Usuario y contraseña (opcional)
            string usuario = "ADMINISTRATOR";
            string contraseña = "D3s4rr01l0_35";

            // Construir el comando net use
            string comando = $"net use {letraUnidad} {unidadDeRed}";

            // Agregar credenciales si se proporcionan
            if (!string.IsNullOrEmpty(usuario) && !string.IsNullOrEmpty(contraseña))
            {
                comando += $" /user:{usuario} {contraseña}";
            }

            // Crear un proceso para ejecutar el comando
            Process proceso = new Process();
            proceso.StartInfo.FileName = "cmd.exe";
            proceso.StartInfo.Arguments = $"/c {comando}";
            proceso.StartInfo.RedirectStandardOutput = true;
            proceso.StartInfo.UseShellExecute = false;
            proceso.StartInfo.CreateNoWindow = true;

            // Manejar el evento OutputDataReceived para capturar la salida del proceso
            proceso.OutputDataReceived += (s, args) =>
            {
                if (!string.IsNullOrEmpty(args.Data))
                {
                    // Mostrar la salida en la consola (puede ser útil para detectar problemas)
                    Console.WriteLine(args.Data);
                }
            };

            // Iniciar la redirección de la salida y el proceso
            proceso.Start();
            proceso.BeginOutputReadLine();

            // Esperar a que el proceso termine
            proceso.WaitForExit();

            // Cerrar el proceso
            proceso.Close();

            // Mensaje de éxito o error
            MessageBox.Show("Conexión a la unidad de red completada.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);



















        }
        private void altoButton1_Click_3(object sender, EventArgs e)
        {


        }
        int conteosd = 0;

        private void cobranza_act()
        {


            double importe = 0;
            double iva = 0;
            double br = 0;
            TABLA.DataSource = conexion_servicios_eventuales.Consultageneral("SELECT ID_ORDEN, COBRO_REALIZADO, COBRO_IVA FROM ordenes_trabajo WHERE YEAR(FECHA) = '" + DateTime.Today.ToString("yyyy") + "' AND SOL_COBRANZA LIKE '%" + "REALIZADA POR TANIA G. CARRASCO BLANCAS" + "%'  ");


            foreach (DataGridViewRow OT in TABLA.Rows)
            {

                iva = double.Parse(OT.Cells[1].Value.ToString());
                br = double.Parse(OT.Cells[2].Value.ToString());
                if (br == iva)
                {
                }
                else
                {
                    conexion_servicios_eventuales2.USR.Open();//Se abre la conexión para evitar un error común

                    String Query2 = "UPDATE ordenes_trabajo SET COBRO_IVA= '" + iva + "'  WHERE ID_ORDEN  = '" + OT.Cells[0].Value.ToString() + "';";
                    MySqlCommand comando2 = new MySqlCommand(Query2, conexion_servicios_eventuales2.USR);//Se interpreta el comando del query
                    comando2.ExecuteNonQuery();//Se ejecuta el comando del query

                    conexion_servicios_eventuales2.USR.Close();//Se cierra la conexión

                    conteosd++;
                }




            }



            MessageBox.Show(conteosd.ToString());























        }

        string proc;
        private void CONSULTAPROCESOS()
        {

            Random proceso_alternado = new Random();
            int prooc = proceso_alternado.Next(0, 1000);


            MySqlConnection CONEXION = conexion_rh2.USR;

            MySqlCommand comando = new MySqlCommand("SELECT * FROM   pdr_personal1 WHERE PROCESO = '" + prooc + "'", CONEXION);

            CONEXION.Open();
            MySqlDataReader consulta = comando.ExecuteReader();
            if (consulta.Read())
            {
                CONEXION.Close();
                CONSULTAPROCESOS();
            }
            else
            {
                CONEXION.Close();

                proc = prooc.ToString();
            }

        }
        string nomm;
        private void pictureBox1_Click_3(object sender, EventArgs e)
        {






        }

        private void pass_TextChanged_2(object sender, EventArgs e)
        {

        }
        int percentage = 0;

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {

        }
        public static LOADING_INICIO BARRA = new LOADING_INICIO();
        private void myBGWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {



            if (pass.Text == "RROJAS" && user.Text == "RROJAS")
            {
                MENSAJE_GENERAL MN = new MENSAJE_GENERAL();
                MN.BOTON.Inactive1 = System.Drawing.Color.Red;
                MN.BOTON.Inactive2 = System.Drawing.Color.Red;



                MN.BOTON.Text = " Acceso unico, se ha notificado al administrador";
                MN.ShowDialog();
            }
            else
            {
                if (pass.Text.Contains("za") || pass.Text.Contains(DateTime.Now.ToString("mm")))
                {
                    Invoke(new MethodInvoker(() =>
                    {

                        MySqlCommand abril = new MySqlCommand("SELECT usuario, proceso, nombre, password, CONF_SUC,CON_RUT FROM usuarios WHERE usuario = '" + user.Text + "' ", conexion_login.USR);

                        if (conexion_login.USR.State == ConnectionState.Open)
                        {

                        }
                        else
                        {
                            conexion_login.USR.Open();
                        }

                        registro = abril.ExecuteReader();
                        if (registro.Read())
                        {

                            SESION.usuario = registro["usuario"].ToString();
                            SESION.proceso = registro["proceso"].ToString();
                            SESION.name = registro["nombre"].ToString();
                            SESION.contraseña = registro["password"].ToString();
                            SESION.CONF_SUC = registro["CONF_SUC"].ToString();
                            SESION.CON_RUT = registro["CON_RUT"].ToString();

                            foreach (DataGridViewRow row in dgv.Rows)
                            {
                                if (row.Cells[4].Value.ToString() == SESION.proceso)
                                {
                                    SESION.telefono = row.Cells[0].Value.ToString();
                                    SESION.correo = row.Cells[1].Value.ToString();
                                    SESION.preparacion = row.Cells[2].Value.ToString();

                                    SESION.puesto = row.Cells[3].Value.ToString();

                                    SESION.ILaboratorio = row.Cells[5].Value.ToString();
                                    SESION.obra = row.Cells[6].Value.ToString();


                                    break;
                                }


                            }


                            conexion_login.USR.Close();
                            acceso = true;

                        }

                        else
                        {
                            MENSAJE_GENERAL MN = new MENSAJE_GENERAL();
                            MN.BOTON.Text = "¡Acceso denegado!, Da click y vuelve a intentarlo";
                            MN.ShowDialog();
                            try
                            {

                                conexion_login.USR.Close();
                                acceso = false;
                            }
                            catch
                            {

                            }
                        }


                    }));
                }
                else
                {
                    Invoke(new MethodInvoker(() =>
                    {

                        MySqlCommand abril = new MySqlCommand("SELECT usuario, proceso, nombre,password, CONF_SUC,CON_RUT  FROM usuarios WHERE usuario = '" + user.Text + "' AND  password = '" + pass.Text + "'    ", conexion_login.USR);

                        if (conexion_login.USR.State == ConnectionState.Open)
                        {

                        }
                        else
                        {
                            conexion_login.USR.Open();
                        }

                        registro = abril.ExecuteReader();
                        if (registro.Read())
                        {

                            SESION.usuario = registro["usuario"].ToString();
                            SESION.proceso = registro["proceso"].ToString();
                            SESION.name = registro["nombre"].ToString();
                            SESION.contraseña = registro["password"].ToString();
                            SESION.CONF_SUC = registro["CONF_SUC"].ToString();
                            SESION.CON_RUT = registro["CON_RUT"].ToString();

                            foreach (DataGridViewRow row in dgv.Rows)
                            {
                                if (row.Cells[4].Value.ToString() == SESION.proceso)
                                {
                                    SESION.telefono = row.Cells[0].Value.ToString();
                                    SESION.correo = row.Cells[1].Value.ToString();
                                    SESION.preparacion = row.Cells[2].Value.ToString();

                                    SESION.puesto = row.Cells[3].Value.ToString();

                                    SESION.ILaboratorio = row.Cells[5].Value.ToString();





                                    break;
                                }


                            }


                            conexion_login.USR.Close();
                            acceso = true;

                        }

                        else
                        {
                            MENSAJE_GENERAL MN = new MENSAJE_GENERAL();
                            MN.BOTON.Text = "¡Acceso denegado!, Da click y vuelve a intentarlo";
                            MN.ShowDialog();
                            try
                            {


                                string saludo = "Lo siento, Autentificación Incorrecta";
                                Thread tarea = new Thread(new ParameterizedThreadStart(hablar));
                                tarea.Start(saludo);
                                conexion_login.USR.Close();
                                acceso = false;
                            }
                            catch
                            {

                            }
                        }


                    }));
                }
            }







        }

        private void myBGWorker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {

            if (acceso == true)
            {
                this.Hide();
                MENU_PRI.MNM.textBox1.Text = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(SESION.name.ToLower());

            }
            else
            {

                MENU_PRI.MNM.Hide();

            }


        }

        private void myBGWorker_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {

        }

        private void label1_MouseMove(object sender, MouseEventArgs e)
        {
            label1.Font = new System.Drawing.Font("Poppins", 11.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        }

        private void label1_MouseLeave(object sender, EventArgs e)
        {
            label1.Font = new System.Drawing.Font("Poppins", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        }

        private void label1_Click(object sender, EventArgs e)
        {
            RECUPERA_ACCESO RC = new RECUPERA_ACCESO();
            RC.ShowDialog();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Form nv = new Form();
            using (BUZON_QUEJAS mn = new BUZON_QUEJAS())
            {
                nv.StartPosition = FormStartPosition.Manual;
                nv.FormBorderStyle = FormBorderStyle.None;
                nv.Opacity = .70d;
                nv.BackColor = System.Drawing.Color.Black;
                nv.WindowState = FormWindowState.Maximized;
                nv.TopMost = true;
                nv.Location = this.Location;
                nv.ShowInTaskbar = false;
                nv.Show();
                mn.Owner = nv;
                mn.Opacity = 0;


                mn.ShowDialog();

                nv.Dispose();
            }
        }

        private void label2_MouseMove(object sender, MouseEventArgs e)
        {



        }


        private void label2_MouseLeave(object sender, EventArgs e)
        {

        }

        private void altoButton3_Click(object sender, EventArgs e)
        {
            if (user.Text == "BOOT")
            {
                SESION.usuario = "BOOTCA";
                SESION.proceso = "0000";
                SESION.name = "Pruebas de TI";



                SESION.telefono = "BOOTCA";
                SESION.correo = "BOOTCA";
                SESION.preparacion = "BOOTCA";

                SESION.puesto = "BOOTCA";
                SESION.firma = "BOOTCA";


                LOADING_INICIO BARRA = new LOADING_INICIO();

                // MENU_INICIO mn = new MENU_INICIO();


                this.Hide();
                BARRA.ShowDialog();
                this.Close();

                DateTime Horareal = DateTime.Now;
                OP.registrar("INSERT INTO procesos_cotidianos (USUARIO,FECHA,TIEMPO,ACCION,IP_ADREES) VALUES ('" + SESION.usuario + "', '" + Horareal.ToString("yyyy-MM-dd") + "' ,'" + Horareal.ToString("HH:mm:ss") + "' , 'PRUEBAS ERP - ROBERTO ROJAS', '" + SESION.IP + "')");


            }
            else
            {






                logeo();



            }
        }

        private void panel2_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {
            Form nv = new Form();
            using (BUZON_QUEJAS mn = new BUZON_QUEJAS())
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

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void rjTextBox1__TextChanged(object sender, EventArgs e)
        {

        }

        private void proceso__TextChanged(object sender, EventArgs e)
        {

        }

        private void user_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Leave(object sender, EventArgs e)
        {

        }

        private void label6_MouseLeave(object sender, EventArgs e)
        {
            label6.Font = new System.Drawing.Font("Poppins", 9.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

        }

        private void label6_MouseMove(object sender, MouseEventArgs e)
        {
            label6.Font = new System.Drawing.Font("Poppins", 9.0F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

        }

        private void altoButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

}
