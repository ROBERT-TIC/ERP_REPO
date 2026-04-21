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
    public partial class EQUIPAMIENTO : Form
    {
        public EQUIPAMIENTO()
        {
            InitializeComponent();
        }
        public string usuario;
        public string proceso;
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            
        }

        private void EQUIPAMIENTO_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            MENU_INICIO menu = new MENU_INICIO();
            this.Hide();
            menu.usuario = usuario;
            menu.proceso = proceso;
            menu.ShowDialog();
            this.Close();
           
        }
    }
}
