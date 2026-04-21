using ERP_LIEC;
using MySql.Data.MySqlClient;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ERP_COMPLETO
{
    public partial class CUESTIONAMINETO : Form
    {
        public CUESTIONAMINETO()
        {
            InitializeComponent();
        }

        private void rjButton1_Click(object sender, EventArgs e)
        {
            conexion_supervision_tecnica.Consultageneral("INSERT INTO cuestionaminetos_norma(ID_CUESTION, NORMA,CUESTION,RESPUESTA) VALUES('" + ID.Text + "','" + ESTANDAR.Texts.ToUpper() + "','" + CUESTIONAMIENTO.Texts.ToUpper() + "','" + RESPUESTA.Texts.ToUpper() + "')   ");
            MessageBox.Show("Se ha registrado un nuevo parametro");

            CUESTIONAMIENTO.Texts = string.Empty;
            RESPUESTA.Texts = string.Empty;
            consecutivo();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void filtrar_coordinador()
        {
            MySqlConnection CONEXION = conexion_supervision_tecnica.USR;


            MySqlCommand comando = new MySqlCommand("SELECT DISTINCTROW NORMA FROM normas ORDER BY NORMA ASC", CONEXION);
            CONEXION.Open();
            MySqlDataReader registro = comando.ExecuteReader();

            while (registro.Read())
            {

                ESTANDAR.Items.Add(registro["NORMA"].ToString());

            }

            CONEXION.Close();

        }

        private void consecutivo()
        {
            int contador = 0;
            Random MND = new Random();
            int CSS = MND.Next(1, 10000);

            MySqlConnection CONEXION = conexion_supervision_tecnica.USR;


            MySqlCommand comando = new MySqlCommand("SELECT DISTINCTROW * FROM  cuestionaminetos_norma", CONEXION);
            CONEXION.Open();
            MySqlDataReader registro = comando.ExecuteReader();

            while (registro.Read())
            {

                contador = contador + 1;

            }
            contador = contador + 1;

            CONEXION.Close();
            ID.Text = "LIE-S.CS-" + CSS.ToString() + contador.ToString();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
            filtrar_coordinador();
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

        }

        private void altoButton1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Form nv = new Form();
            using (CONSULTA_NORMA aes = new CONSULTA_NORMA())
            {
                nv.StartPosition = FormStartPosition.Manual;
                nv.FormBorderStyle = FormBorderStyle.None;
                nv.Opacity = .70d;
                nv.BackColor = Color.Black;
                nv.WindowState = FormWindowState.Maximized;
                nv.TopMost = false;
                nv.Location = this.Location;
                nv.ShowInTaskbar = false;
                nv.Show();
                aes.Owner = nv;
                aes.Opacity = 0;
                aes.TopMost = false;
                aes.norma = ESTANDAR.Texts;
                aes.ShowDialog();

                nv.Dispose();
            }
        }
    }
}
