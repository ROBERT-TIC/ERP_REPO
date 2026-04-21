using ERP_LIEC;
using System;
using System.Windows.Forms;

namespace ERP_COMPLETO
{
    public partial class NORMAS : Form
    {
        public NORMAS()
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
            this.Close();
        }



        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Opacity = this.Opacity + .20;


            if (this.Opacity == 1)
            {

                timer1.Stop();
            }
        }



        private void altoButton1_Click(object sender, EventArgs e)
        {
            conexion_supervision_tecnica.Consultageneral("INSERT INTO normas(NORMA,DESCRIPCION) VALUES('" + NORMA.Texts.ToUpper() + "','" + DESCRIPCION.Texts.ToUpper() + "')  ");

            MENSAJE_GENERAL MN = new MENSAJE_GENERAL();
            MN.BOTON.Text = "NORMA REGISTRADA";
            MN.ShowDialog();

        }



    }
}
