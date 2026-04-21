using System;
using System.Windows.Forms;

namespace ERP_COMPLETO
{
    public partial class SUB_LABORATORIO : Form
    {
        public SUB_LABORATORIO()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Opacity = this.Opacity + .20;


            if (this.Opacity == 1)
            {

                timer1.Stop();
            }
        }

        private void SUB_LABORATORIO_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {



        }

        private void pictureBox3_Click_1(object sender, EventArgs e)
        {



        }

        private void pictureBox15_Click(object sender, EventArgs e)
        {


        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {



        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {



        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {


        }

        private void pictureBox5_Click_1(object sender, EventArgs e)
        {


        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {


        }

        private void pictureBox16_Click(object sender, EventArgs e)
        {

        }
    }
}
