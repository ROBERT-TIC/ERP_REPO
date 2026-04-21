using ERP_LIEC;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERP_COMPLETO
{
    public partial class SALA_JUNTAS : Form
    {
        public SALA_JUNTAS()
        {
            InitializeComponent();
        }

        public string usuario;
        public string proceso;



        bool h1 = false;

        bool h2 = false;
        bool h3 = false;
        bool h4 = false;
        bool h5 = false;
        bool h6 = false;
        bool h7 = false;
        bool h8 = false;
        bool h9 = false;
        bool h10 = false;
        bool h11 = false;
        bool h12 = false;
        bool h13 = false;
        bool h14 = false;
        bool h15 = false;
        bool h16 = false;
        bool h17 = false;
        bool h18 = false;
        bool h19 = false;
        bool h20 = false;








        int cLeft = 1;
        int baja = 0;
        string contador = "";
        private void SALA_JUNTAS_Load(object sender, EventArgs e)
        {

            dgv.DataSource = conexion_notificaciones.Consultageneral("SELECT * FROM citas");
            int conteo = dgv.RowCount + 1;
            contador = Convert.ToString(conteo);
            ID_REUN.Text = "LIERN-" + contador;



            MySqlConnection CONEXION1 = conexion_login.USR;


            MySqlCommand comando = new MySqlCommand("SELECT DISTINCTROW nombre FROM  usuarios   ", CONEXION1);
            CONEXION1.Open();
            MySqlDataReader registro = comando.ExecuteReader();

            while (registro.Read())
            {

                comboBox1.Items.Add(registro["nombre"].ToString());


            }

            CONEXION1.Close();











        }
        /*
                public Bunifu.Framework.UI.BunifuCards cartas()
                {


                    Bunifu.Framework.UI.BunifuCards carta = new Bunifu.Framework.UI.BunifuCard(1, 1);
                    carta.Size = new Size(200, 200);

                    panel1.Controls.Add(carta);
                    //  carta.Top = 
                    cLeft = cLeft + 220;

                    carta.Left = cLeft ;
                    carta.Top = baja;
                    carta.Text = "TextBox ";
                    carta.ForeColor = Color.Black;

                    if(cLeft > 600)
                    {
                        cLeft = 0;
                        baja = baja + 220;
                    }


                    return carta;

                }
            */
        private void button1_Click(object sender, EventArgs e)
        {







        }

        private void bunifuCards2_Click(object sender, EventArgs e)
        {

        }

        private void bunifuCards2_DoubleClick(object sender, EventArgs e)
        {
            if (h1 == true)
            {

            }


            else
            {


                if (bunifuCards2.BackColor == Color.LightGray)
                {
                    bunifuCards2.BackColor = Color.White;

                    foreach (DataGridViewRow row in tabla.Rows)
                    {
                        if (row.Cells[3].Value == "1")
                        {
                            tabla.Rows.Remove(row);
                        }


                    }



                }
                else
                {


                    if (motv.Text == string.Empty || descr.Text == string.Empty)
                    {
                        MessageBox.Show("TIENES ESPACIOS DE REFERENCIA SIN CAPTURAR");
                    }
                    else
                    {
                        tabla.Rows.Add("ID", "USUARIO", "1PROCESO", "1", motv.Text, descr.Text);
                        bunifuCards2.BackColor = Color.LightGray;
                    }
                }
            }

        }

        private void bunifuCards1_DoubleClick(object sender, EventArgs e)
        {
            if (h2 == true)
            {

            }

            if (bunifuCards1.BackColor == Color.LightGray)
            {
                bunifuCards1.BackColor = Color.White;

                foreach (DataGridViewRow row in tabla.Rows)
                {
                    if (row.Cells[3].Value.ToString() == "2")
                    {
                        tabla.Rows.Remove(row);
                    }


                }



            }
            else
            {


                if (motv.Text == string.Empty || descr.Text == string.Empty)
                {
                    MessageBox.Show("TIENES ESPACIOS DE REFERENCIA SIN CAPTURAR");
                }
                else
                {
                    tabla.Rows.Add("ID", "USUARIO", "1PROCESO", "2", motv.Text, descr.Text);
                    bunifuCards1.BackColor = Color.LightGray;
                }
            }
        }

        private void bunifuCards3_DoubleClick(object sender, EventArgs e)
        {
            if (h3 == true)
            {

            }
            else
            {
                if (bunifuCards3.BackColor == Color.LightGray)
                {
                    bunifuCards3.BackColor = Color.White;

                    foreach (DataGridViewRow row in tabla.Rows)
                    {
                        if (row.Cells[3].Value == "3")
                        {
                            tabla.Rows.Remove(row);
                        }


                    }



                }
                else
                {


                    if (motv.Text == string.Empty || descr.Text == string.Empty)
                    {
                        MessageBox.Show("TIENES ESPACIOS DE REFERENCIA SIN CAPTURAR");
                    }
                    else
                    {
                        tabla.Rows.Add("ID", "USUARIO", "1PROCESO", "3", motv.Text, descr.Text);
                        bunifuCards3.BackColor = Color.LightGray;
                    }
                }
            }
        }

        private void bunifuCards4_DoubleClick(object sender, EventArgs e)
        {
            if (h4 == true)
            {

            }
            else
            {



                if (bunifuCards4.BackColor == Color.LightGray)
                {
                    bunifuCards4.BackColor = Color.White;

                    foreach (DataGridViewRow row in tabla.Rows)
                    {
                        if (row.Cells[3].Value == "4")
                        {
                            tabla.Rows.Remove(row);
                        }


                    }



                }
                else
                {


                    if (motv.Text == string.Empty || descr.Text == string.Empty)
                    {
                        MessageBox.Show("TIENES ESPACIOS DE REFERENCIA SIN CAPTURAR");
                    }
                    else
                    {
                        tabla.Rows.Add("ID", "USUARIO", "1PROCESO", "4", motv.Text, descr.Text);
                        bunifuCards4.BackColor = Color.LightGray;
                    }
                }
            }
        }

        private void bunifuCards8_DoubleClick(object sender, EventArgs e)
        {
            if (h5 == true)
            {

            }
            else
            {

            
            if (bunifuCards8.BackColor == Color.LightGray)
            {
                bunifuCards8.BackColor = Color.White;

                foreach (DataGridViewRow row in tabla.Rows)
                {
                    if (row.Cells[3].Value == "5")
                    {
                        tabla.Rows.Remove(row);
                    }


                }



            }
            else
            {


                if (motv.Text == string.Empty || descr.Text == string.Empty)
                {
                    MessageBox.Show("TIENES ESPACIOS DE REFERENCIA SIN CAPTURAR");
                }
                else
                {
                    tabla.Rows.Add("ID", "USUARIO", "1PROCESO", "5", motv.Text, descr.Text);
                    bunifuCards8.BackColor = Color.LightGray;
                }
            }
        }
    }

        private void bunifuCards7_DoubleClick(object sender, EventArgs e)
        {

            if (h6 == true)
            {

            }
            else
            {


                if (bunifuCards7.BackColor == Color.LightGray)
                {
                    bunifuCards7.BackColor = Color.White;

                    foreach (DataGridViewRow row in tabla.Rows)
                    {
                        if (row.Cells[3].Value == "6")
                        {
                            tabla.Rows.Remove(row);
                        }


                    }



                }
                else
                {


                    if (motv.Text == string.Empty || descr.Text == string.Empty)
                    {
                        MessageBox.Show("TIENES ESPACIOS DE REFERENCIA SIN CAPTURAR");
                    }
                    else
                    {
                        tabla.Rows.Add("ID", "USUARIO", "1PROCESO", "6", motv.Text, descr.Text);
                        bunifuCards7.BackColor = Color.LightGray;
                    }
                }
            }
        }

        private void bunifuCards6_DoubleClick(object sender, EventArgs e)
        {
            if (h7 == true)
            {

            }
            else
            {


                if (bunifuCards6.BackColor == Color.LightGray)
                {
                    bunifuCards6.BackColor = Color.White;

                    foreach (DataGridViewRow row in tabla.Rows)
                    {
                        if (row.Cells[3].Value == "7")
                        {
                            tabla.Rows.Remove(row);
                        }


                    }



                }
                else
                {


                    if (motv.Text == string.Empty || descr.Text == string.Empty)
                    {
                        MessageBox.Show("TIENES ESPACIOS DE REFERENCIA SIN CAPTURAR");
                    }
                    else
                    {
                        tabla.Rows.Add("ID", "USUARIO", "1PROCESO", "7", motv.Text, descr.Text);
                        bunifuCards6.BackColor = Color.LightGray;
                    }
                }
            }
        }

        private void bunifuCards5_DoubleClick(object sender, EventArgs e)
        {
            if (h8 == true)
            {

            }
            else
            {


                if (bunifuCards5.BackColor == Color.LightGray)
                {
                    bunifuCards5.BackColor = Color.White;

                    foreach (DataGridViewRow row in tabla.Rows)
                    {
                        if (row.Cells[3].Value == "8")
                        {
                            tabla.Rows.Remove(row);
                        }


                    }



                }
                else
                {


                    if (motv.Text == string.Empty || descr.Text == string.Empty)
                    {
                        MessageBox.Show("TIENES ESPACIOS DE REFERENCIA SIN CAPTURAR");
                    }
                    else
                    {
                        tabla.Rows.Add("ID", "USUARIO", "1PROCESO", "8", motv.Text, descr.Text);
                        bunifuCards5.BackColor = Color.LightGray;
                    }
                }
            }
        }

        private void bunifuCards12_DoubleClick(object sender, EventArgs e)
        {
            if (h9 == true)
            {

            }
            else
            {


                if (bunifuCards12.BackColor == Color.LightGray)
                {
                    bunifuCards12.BackColor = Color.White;

                    foreach (DataGridViewRow row in tabla.Rows)
                    {
                        if (row.Cells[3].Value == "9")
                        {
                            tabla.Rows.Remove(row);
                        }


                    }



                }
                else
                {


                    if (motv.Text == string.Empty || descr.Text == string.Empty)
                    {
                        MessageBox.Show("TIENES ESPACIOS DE REFERENCIA SIN CAPTURAR");
                    }
                    else
                    {
                        tabla.Rows.Add("ID", "USUARIO", "1PROCESO", "9", motv.Text, descr.Text);
                        bunifuCards12.BackColor = Color.LightGray;
                    }
                }
            }
        }

        private void bunifuCards11_DoubleClick(object sender, EventArgs e)
        {
            if (h10 == true)
            {

            }
            else
            {


                if (bunifuCards11.BackColor == Color.LightGray)
                {
                    bunifuCards11.BackColor = Color.White;

                    foreach (DataGridViewRow row in tabla.Rows)
                    {
                        if (row.Cells[3].Value == "10")
                        {
                            tabla.Rows.Remove(row);
                        }


                    }



                }
                else
                {


                    if (motv.Text == string.Empty || descr.Text == string.Empty)
                    {
                        MessageBox.Show("TIENES ESPACIOS DE REFERENCIA SIN CAPTURAR");
                    }
                    else
                    {
                        tabla.Rows.Add("ID", "USUARIO", "1PROCESO", "10", motv.Text, descr.Text);
                        bunifuCards11.BackColor = Color.LightGray;
                    }
                }
            }
        }

        private void bunifuCards10_DoubleClick(object sender, EventArgs e)
        {
            if (h11 == true)
            {

            }
            else
            {

            
            if (bunifuCards10.BackColor == Color.LightGray)
            {
                bunifuCards10.BackColor = Color.White;

                foreach (DataGridViewRow row in tabla.Rows)
                {
                    if (row.Cells[3].Value == "11")
                    {
                        tabla.Rows.Remove(row);
                    }


                }



            }
            else
            {


                if (motv.Text == string.Empty || descr.Text == string.Empty)
                {
                    MessageBox.Show("TIENES ESPACIOS DE REFERENCIA SIN CAPTURAR");
                }
                else
                {
                    tabla.Rows.Add("ID", "USUARIO", "1PROCESO", "11", motv.Text, descr.Text);
                    bunifuCards10.BackColor = Color.LightGray;
                }
            }
                 }
        }

        private void bunifuCards9_DoubleClick(object sender, EventArgs e)
        {

            if (h12 == true)
            {

            }
            else
            {


                if (bunifuCards9.BackColor == Color.LightGray)
                {
                    bunifuCards9.BackColor = Color.White;

                    foreach (DataGridViewRow row in tabla.Rows)
                    {
                        if (row.Cells[3].Value == "12")
                        {
                            tabla.Rows.Remove(row);
                        }


                    }



                }
                else
                {


                    if (motv.Text == string.Empty || descr.Text == string.Empty)
                    {
                        MessageBox.Show("TIENES ESPACIOS DE REFERENCIA SIN CAPTURAR");
                    }
                    else
                    {
                        tabla.Rows.Add("ID", "USUARIO", "1PROCESO", "12", motv.Text, descr.Text);
                        bunifuCards9.BackColor = Color.LightGray;
                    }
                }
            }
        }

        private void bunifuCards14_DoubleClick(object sender, EventArgs e)
        {
            if (h13 == true)
            {

            }
            else
            {


                if (bunifuCards14.BackColor == Color.LightGray)
                {
                    bunifuCards14.BackColor = Color.White;

                    foreach (DataGridViewRow row in tabla.Rows)
                    {
                        if (row.Cells[3].Value == "13")
                        {
                            tabla.Rows.Remove(row);
                        }


                    }



                }
                else
                {


                    if (motv.Text == string.Empty || descr.Text == string.Empty)
                    {
                        MessageBox.Show("TIENES ESPACIOS DE REFERENCIA SIN CAPTURAR");
                    }
                    else
                    {
                        tabla.Rows.Add("ID", "USUARIO", "1PROCESO", "13", motv.Text, descr.Text);
                        bunifuCards14.BackColor = Color.LightGray;
                    }
                }
            }
        }

        private void bunifuCards13_DoubleClick(object sender, EventArgs e)
        {

            if (h14 == true)
            {

            }
            else
            {


                if (bunifuCards13.BackColor == Color.LightGray)
                {
                    bunifuCards13.BackColor = Color.White;

                    foreach (DataGridViewRow row in tabla.Rows)
                    {
                        if (row.Cells[3].Value == "14")
                        {
                            tabla.Rows.Remove(row);
                        }


                    }



                }
                else
                {


                    if (motv.Text == string.Empty || descr.Text == string.Empty)
                    {
                        MessageBox.Show("TIENES ESPACIOS DE REFERENCIA SIN CAPTURAR");
                    }
                    else
                    {
                        tabla.Rows.Add("ID", "USUARIO", "1PROCESO", "14", motv.Text, descr.Text);
                        bunifuCards13.BackColor = Color.LightGray;
                    }
                }
            }
        }

        private void bunifuCards16_DoubleClick(object sender, EventArgs e)
        {

            if (h15 == true)
            {

            }
            else
            {


                if (bunifuCards16.BackColor == Color.LightGray)
                {
                    bunifuCards16.BackColor = Color.White;

                    foreach (DataGridViewRow row in tabla.Rows)
                    {
                        if (row.Cells[3].Value == "15")
                        {
                            tabla.Rows.Remove(row);
                        }


                    }



                }
                else
                {


                    if (motv.Text == string.Empty || descr.Text == string.Empty)
                    {
                        MessageBox.Show("TIENES ESPACIOS DE REFERENCIA SIN CAPTURAR");
                    }
                    else
                    {
                        tabla.Rows.Add("ID", "USUARIO", "1PROCESO", "15", motv.Text, descr.Text);
                        bunifuCards16.BackColor = Color.LightGray;
                    }
                }
            }
        }

        private void bunifuCards15_DoubleClick(object sender, EventArgs e)
        {
            if (h16 == true)
            {

            }
            else
            {


                if (bunifuCards15.BackColor == Color.LightGray)
                {
                    bunifuCards15.BackColor = Color.White;

                    foreach (DataGridViewRow row in tabla.Rows)
                    {
                        if (row.Cells[3].Value == "16")
                        {
                            tabla.Rows.Remove(row);
                        }


                    }



                }
                else
                {


                    if (motv.Text == string.Empty || descr.Text == string.Empty)
                    {
                        MessageBox.Show("TIENES ESPACIOS DE REFERENCIA SIN CAPTURAR");
                    }
                    else
                    {
                        tabla.Rows.Add("ID", "USUARIO", "1PROCESO", "16", motv.Text, descr.Text);
                        bunifuCards15.BackColor = Color.LightGray;
                    }
                }
            }
        }

        private void bunifuCards18_DoubleClick(object sender, EventArgs e)
        {
            if (h17 == true)
            {

            }
            else
            {


                if (bunifuCards18.BackColor == Color.LightGray)
                {
                    bunifuCards18.BackColor = Color.White;

                    foreach (DataGridViewRow row in tabla.Rows)
                    {
                        if (row.Cells[3].Value == "17")
                        {
                            tabla.Rows.Remove(row);
                        }


                    }



                }
                else
                {


                    if (motv.Text == string.Empty || descr.Text == string.Empty)
                    {
                        MessageBox.Show("TIENES ESPACIOS DE REFERENCIA SIN CAPTURAR");
                    }
                    else
                    {
                        tabla.Rows.Add("ID", "USUARIO", "1PROCESO", "17", motv.Text, descr.Text);
                        bunifuCards18.BackColor = Color.LightGray;
                    }
                }
            }
        }

        private void bunifuCards17_DoubleClick(object sender, EventArgs e)
        {
            if (h18 == true)
            {

            }
            else
            {


                if (bunifuCards17.BackColor == Color.LightGray)
                {
                    bunifuCards17.BackColor = Color.White;

                    foreach (DataGridViewRow row in tabla.Rows)
                    {
                        if (row.Cells[3].Value == "18")
                        {
                            tabla.Rows.Remove(row);
                        }


                    }



                }
                else
                {


                    if (motv.Text == string.Empty || descr.Text == string.Empty)
                    {
                        MessageBox.Show("TIENES ESPACIOS DE REFERENCIA SIN CAPTURAR");
                    }
                    else
                    {
                        tabla.Rows.Add("ID", "USUARIO", "1PROCESO", "18", motv.Text, descr.Text);
                        bunifuCards17.BackColor = Color.LightGray;
                    }
                }
            }
        }

        private void bunifuCards20_DoubleClick(object sender, EventArgs e)
        {
            if (h19 == true)
            {

            }
            else
            {


                if (bunifuCards20.BackColor == Color.LightGray)
                {
                    bunifuCards20.BackColor = Color.White;

                    foreach (DataGridViewRow row in tabla.Rows)
                    {
                        if (row.Cells[3].Value == "19")
                        {
                            tabla.Rows.Remove(row);
                        }


                    }



                }
                else
                {


                    if (motv.Text == string.Empty || descr.Text == string.Empty)
                    {
                        MessageBox.Show("TIENES ESPACIOS DE REFERENCIA SIN CAPTURAR");
                    }
                    else
                    {
                        tabla.Rows.Add("ID", "USUARIO", "1PROCESO", "19", motv.Text, descr.Text);
                        bunifuCards20.BackColor = Color.LightGray;
                    }
                }
            }
        }

        private void bunifuCards19_DoubleClick(object sender, EventArgs e)
        {
            if (h20 == true)
            {

            }
            else
            {


                if (bunifuCards19.BackColor == Color.LightGray)
                {
                    bunifuCards19.BackColor = Color.White;

                    foreach (DataGridViewRow row in tabla.Rows)
                    {
                        if (row.Cells[3].Value == "20")
                        {
                            tabla.Rows.Remove(row);
                        }


                    }



                }
                else
                {


                    if (motv.Text == string.Empty || descr.Text == string.Empty)
                    {
                        MessageBox.Show("TIENES ESPACIOS DE REFERENCIA SIN CAPTURAR");
                    }
                    else
                    {
                        tabla.Rows.Add("ID", "USUARIO", "1PROCESO", "20", motv.Text, descr.Text);
                        bunifuCards19.BackColor = Color.LightGray;
                    }
                }
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)        {
            label22.Text = "DA DOBLE CLICK SOBRE LOS ESPACIOS QUE DESEAS AGENDAR";
            dgv.DataSource = conexion_notificaciones.Consultageneral("SELECT * FROM citas WHERE FECHA = '" + dateTimePicker1.Text + "'");



            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (row.Cells[4].Value.ToString() == "1")
                {
                    h1 = true;
                    P1.Visible = true;
                }
              
                
                if (row.Cells[4].Value.ToString() == "2")
                {
                    h2 = true;
                    P2.Visible = true;
                }


                if (row.Cells[4].Value.ToString() == "3")
                {
                    h3 = true;
                    P3.Visible = true;
                }


                if (row.Cells[4].Value.ToString() == "4")
                {
                    h4 = true;
                    P4.Visible = true;
                }


                if (row.Cells[4].Value.ToString() == "5")
                {
                    h5 = true;
                    P5.Visible = true;
                }


                if (row.Cells[4].Value.ToString() == "6")
                {
                    h6 = true;
                    P6.Visible = true;
                }


                if (row.Cells[4].Value.ToString() == "7")
                {
                    h7 = true;
                    P7.Visible = true;
                }


                if (row.Cells[4].Value.ToString() == "8")
                {
                    h8 = true;
                    P8.Visible = true;
                }


                if (row.Cells[4].Value.ToString() == "9")
                {
                    h9 = true;
                    P9.Visible = true;
                }


                if (row.Cells[4].Value.ToString() == "10")
                {
                    h10 = true;
                    P10.Visible = true;
                }


                if (row.Cells[4].Value.ToString() == "11")
                {
                    h11 = true;
                    P11.Visible = true;
                }


                if (row.Cells[4].Value.ToString() == "12")
                {
                    h12 = true;
                    P12.Visible = true;
                }


                if (row.Cells[4].Value.ToString() == "13")
                {
                    h13 = true;
                    P13.Visible = true;
                }


                if (row.Cells[4].Value.ToString() == "14")
                {
                    h14 = true;
                    P14.Visible = true;
                }

                if (row.Cells[4].Value.ToString() == "15")
                {
                    h15 = true;
                    P15.Visible = true;
                }


                if (row.Cells[4].Value.ToString() == "16")
                {
                    h16 = true;
                    P16.Visible = true;
                }


                if (row.Cells[4].Value.ToString() == "17")
                {
                    h17 = true;
                    P17.Visible = true;
                }


                if (row.Cells[4].Value.ToString() == "18")
                {
                    h18 = true;
                    P18.Visible = true;
                }

                if (row.Cells[4].Value.ToString() == "19")
                {
                    h19 = true;
                    P19.Visible = true;
                }

                if (row.Cells[4].Value.ToString() == "20")
                {
                    h20 = true;
                    P20.Visible = true;
                }

            }






           


            animacion.ShowSync(panel4);
            animacion.ShowSync(panel1);


        }

        private void AGENDAR_Click(object sender, EventArgs e)
        {

            if(tabla.RowCount == 0)
            {
                MessageBox.Show("NO PUEDES AGENDAR UNA FECHA SI NO TIENES SELECCIONADO UN ESPACIO", "NOTIFICACIÓN DE OPERACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else
            {

          
            conexion_notificaciones.USR.Open();
          

            string query = "INSERT INTO citas (	ID_CITA, USUARIO, PROCESO, ESPACIO, MOTIVO  , OBSERVACIONES, FECHA, ESTADO) VALUES (?param0, ?param1, ?param2, ?param3, ?param4, ?param5,  ?param6, ?param7)";
            MySqlCommand cmd = new MySqlCommand(query, conexion_notificaciones.USR);


            foreach (DataGridViewRow row in tabla.Rows)
            {


               

                cmd.Parameters.Clear();

                cmd.Parameters.AddWithValue("?param0", ID_REUN.Text);

                cmd.Parameters.AddWithValue("?param1", usuario);
                cmd.Parameters.AddWithValue("?param2", proceso);
                cmd.Parameters.AddWithValue("?param3", Convert.ToString(row.Cells[3].Value));
                cmd.Parameters.AddWithValue("?param4", motv.Text);
                cmd.Parameters.AddWithValue("?param5", descr.Text);
                cmd.Parameters.AddWithValue("?param6", dateTimePicker1.Text);
                cmd.Parameters.AddWithValue("?param7", "PENDIENTE");



                    cmd.ExecuteNonQuery();
            }
            conexion_notificaciones.USR.Close();
                string leyenda = "EL USUARIO" + usuario + "REQUIERE LA SALA DE JUNTAS EN FECHA DE " + dateTimePicker1.Text ;
            conexion_notificaciones.registrar("INSERT INTO notificacion (USUARIO,TIPO_NOTIFICACION,NOTIFICACION,FECHA,AREA,USUARIO_CONSECUENTE) VALUES ('JRUIZ', 'SOLICITUD DE SALA DE REUNIÓN' , '" + leyenda + "','" + DateTime.Today.ToString("yyyy-MM-dd H:mm:ss") + "' , '" + "SERVICIOS GENERALES" + "','" + usuario + "')");

                MessageBox.Show("ESPACIO AGENDADO");

                


            invitados();



            this.Close();

            }

        }


        private void invitados()
        {
            conexion_notificaciones.USR.Open();


            string query = "INSERT INTO convocados_citas (NOMBRE, USUARIO, PROCESO,ID_CITA) VALUES (?param0, ?param1, ?param2, ?param3)";
            MySqlCommand cmd = new MySqlCommand(query, conexion_notificaciones.USR);


            foreach (DataGridViewRow row in dataGridView1.Rows)
            {




                cmd.Parameters.Clear();

                cmd.Parameters.AddWithValue("?param0", Convert.ToString(row.Cells[0].Value));

                cmd.Parameters.AddWithValue("?param1", Convert.ToString(row.Cells[1].Value));
                cmd.Parameters.AddWithValue("?param2", Convert.ToString(row.Cells[2].Value));
                cmd.Parameters.AddWithValue("?param3", Convert.ToString(row.Cells[3].Value));
                cmd.Parameters.AddWithValue("?param4", ID_REUN.Text);





                cmd.ExecuteNonQuery();
            }
            conexion_notificaciones.USR.Close();

            MessageBox.Show("INVITADOS AGENDADOS AGENDADO");



        }
        private void bunifuCards2_Paint(object sender, PaintEventArgs e)
        {

        }


        private void vaciados()
        {
          
           
        }

        private void bunifuImageButton6_Click(object sender, EventArgs e)
        {
            MUESTRA_AGENDA MN = new MUESTRA_AGENDA();
            MN.dateTimePicker1.Text = dateTimePicker1.Text;
            MN.espacio = "1";
            MN.ShowDialog();


        }

        private void bunifuImageButton9_Click(object sender, EventArgs e)
        {
            MUESTRA_AGENDA MN = new MUESTRA_AGENDA();
            MN.dateTimePicker1.Text = dateTimePicker1.Text;
            MN.espacio = "2";
            MN.ShowDialog();
        }

        private void bunifuImageButton11_Click(object sender, EventArgs e)
        {
            MUESTRA_AGENDA MN = new MUESTRA_AGENDA();
            MN.dateTimePicker1.Text = dateTimePicker1.Text;
            MN.espacio = "3";
            MN.ShowDialog();
        }

        private void bunifuImageButton13_Click(object sender, EventArgs e)
        {
            MUESTRA_AGENDA MN = new MUESTRA_AGENDA();
            MN.espacio = "4";
            MN.ShowDialog();
        }

        private void bunifuImageButton15_Click(object sender, EventArgs e)
        {
            MUESTRA_AGENDA MN = new MUESTRA_AGENDA();
            MN.espacio = "5";
            MN.ShowDialog();
        }

        private void bunifuImageButton17_Click(object sender, EventArgs e)
        {
            MUESTRA_AGENDA MN = new MUESTRA_AGENDA();
            MN.dateTimePicker1.Text = dateTimePicker1.Text;
            MN.espacio = "6";
            MN.ShowDialog();
        }

        private void bunifuImageButton19_Click(object sender, EventArgs e)
        {
            MUESTRA_AGENDA MN = new MUESTRA_AGENDA();
            MN.dateTimePicker1.Text = dateTimePicker1.Text;
            MN.espacio = "7";
            MN.ShowDialog();
        }

        private void bunifuImageButton21_Click(object sender, EventArgs e)
        {
            MUESTRA_AGENDA MN = new MUESTRA_AGENDA();
            MN.dateTimePicker1.Text = dateTimePicker1.Text;
            MN.espacio = "8";
            MN.ShowDialog();
        }

        private void bunifuImageButton23_Click(object sender, EventArgs e)
        {
            MUESTRA_AGENDA MN = new MUESTRA_AGENDA();
            MN.dateTimePicker1.Text = dateTimePicker1.Text;
            MN.espacio = "9";
            MN.ShowDialog();
        }

        private void bunifuImageButton25_Click(object sender, EventArgs e)
        {
            MUESTRA_AGENDA MN = new MUESTRA_AGENDA();
            MN.dateTimePicker1.Text = dateTimePicker1.Text;
            MN.espacio = "10";
            MN.ShowDialog();
        }

        private void bunifuImageButton27_Click(object sender, EventArgs e)
        {
            MUESTRA_AGENDA MN = new MUESTRA_AGENDA();
            MN.dateTimePicker1.Text = dateTimePicker1.Text;
            MN.espacio = "11";
            MN.ShowDialog();
        }

        private void bunifuImageButton29_Click(object sender, EventArgs e)
        {
            MUESTRA_AGENDA MN = new MUESTRA_AGENDA();
            MN.dateTimePicker1.Text = dateTimePicker1.Text;
            MN.espacio = "12";
            MN.ShowDialog();
        }

        private void bunifuImageButton31_Click(object sender, EventArgs e)
        {
            MUESTRA_AGENDA MN = new MUESTRA_AGENDA();
            MN.dateTimePicker1.Text = dateTimePicker1.Text;
            MN.espacio = "13";
            MN.ShowDialog();
        }

        private void bunifuImageButton33_Click(object sender, EventArgs e)
        {
            MUESTRA_AGENDA MN = new MUESTRA_AGENDA();
            MN.dateTimePicker1.Text = dateTimePicker1.Text;
            MN.espacio = "14";
            MN.ShowDialog();
        }

        private void bunifuImageButton35_Click(object sender, EventArgs e)
        {
            MUESTRA_AGENDA MN = new MUESTRA_AGENDA();
            MN.dateTimePicker1.Text = dateTimePicker1.Text;
            MN.espacio = "15";
            MN.ShowDialog();
        }

        private void bunifuImageButton37_Click(object sender, EventArgs e)
        {
            MUESTRA_AGENDA MN = new MUESTRA_AGENDA();
            MN.dateTimePicker1.Text = dateTimePicker1.Text;
            MN.espacio = "16";
            MN.ShowDialog();
        }

        private void bunifuImageButton45_Click(object sender, EventArgs e)
        {
            MUESTRA_AGENDA MN = new MUESTRA_AGENDA();
            MN.dateTimePicker1.Text = dateTimePicker1.Text;
            MN.espacio = "17";
            MN.ShowDialog();
        }

        private void bunifuImageButton43_Click(object sender, EventArgs e)
        {
            MUESTRA_AGENDA MN = new MUESTRA_AGENDA();
            MN.dateTimePicker1.Text = dateTimePicker1.Text;
            MN.espacio = "18";
            MN.ShowDialog();
        }

        private void bunifuImageButton39_Click(object sender, EventArgs e)
        {
            MUESTRA_AGENDA MN = new MUESTRA_AGENDA();
            MN.dateTimePicker1.Text = dateTimePicker1.Text;
            MN.espacio = "19";
            MN.ShowDialog();
        }

        private void bunifuImageButton41_Click(object sender, EventArgs e)
        {
            MUESTRA_AGENDA MN = new MUESTRA_AGENDA();
            MN.dateTimePicker1.Text = dateTimePicker1.Text;
            MN.espacio = "20";
            MN.ShowDialog();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {



        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {



            dgv.DataSource = conexion_login.Consultageneral("SELECT nombre, usuario, proceso FROM usuarios WHERE nombre = '" + comboBox1.Text + "'");

            string p1 = dgv.Rows[0].Cells[0].Value.ToString();
            string p2 = dgv.Rows[0].Cells[1].Value.ToString();
            string p3 = dgv.Rows[0].Cells[2].Value.ToString();
            string p4 = ID_REUN.Text;

            dataGridView1.Rows.Add(p1, p2, p3, p4);

        }
    }
}
