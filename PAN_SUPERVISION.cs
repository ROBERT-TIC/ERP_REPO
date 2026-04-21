using System;
using System.Drawing;
using System.Windows.Forms;     //DEFINEN UN AMBITO PARA UTILIZAR RECURSOS //

namespace ERP_COMPLETO    //NOMBRE DEL ESPACIO
{
    public partial class PAN_SUPERVISION : Form   //CLASE PRINCIPAL DEL FORMULARIO ACTUAL
    {
        public PAN_SUPERVISION()
        {
            InitializeComponent();  //INICIALIZA COMPONENTE
        }


        public string claveo; //VARIABLES INICIALES
        public string fecha_muestreo;
        public string observaciones;
        public string descripcio;
        public string proce;
        public string almacen; //VARIABLES INICIALES
        public string calidad;
        public string tipo;
        public string envia;
        public string uso;
        public string muestreado; //VARIABLES INICIALES







        private void eventos()
        {

            //  reporte.MouseMove += new System.Windows.Forms.MouseEventHandler(labelTelefono_MouseMove);
            //    reporte.MouseLeave += new System.EventHandler(labelTelefono_MouseLeave);


        }
        private void labelTelefono_MouseLeave(object sender, EventArgs e)
        {


            var button = sender as Button;


            button.Font = new Font("Poppins", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);   //ESTILOS APLICABLES A ELEMENTOS 



        }
        private void labelTelefono_MouseMove(object sender, EventArgs e)
        {


            var button = sender as Button;



            button.Font = new Font("Poppins", 11F, FontStyle.Underline, GraphicsUnit.Point, 0);   //ESTILOS APLICABLES A ELEMENTOS 



        }




        private void PAN_TERRA_Load(object sender, EventArgs e)  //FUNCION PRINCIPAL DE ARRANQUE
        {
            eventos();  //FUNCIONES A LLAMAR AL INICIAR EL FORMULARIO

            contenido.Controls.Clear();
            Indicadores_SUP SU = new Indicadores_SUP();
            SU.TopLevel = false;
            contenido.Controls.Add(SU);
            SU.Show();


        }






        //PERSONAL TÉCNICO


        //PERSONAL CENTRAL
        public static CALENDARIO_DE_MANTENIMIENTO drB = new CALENDARIO_DE_MANTENIMIENTO();



        //SERVICIOS PERMANENTES










        public static INVENTARIO_TIC cortaw = new INVENTARIO_TIC();
        private void label10_Click(object sender, EventArgs e)
        {


        }
        public void reiniciaaviso()
        {


        }

        private void contenido_Paint(object sender, PaintEventArgs e)
        {

        }




        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
        public static MIS_REPORTES_TIC jn = new MIS_REPORTES_TIC();
        private void label1_Click_1(object sender, EventArgs e)
        {
            Form nv = new Form();
            using (BASE_DE_ACUMULADOS mn = new BASE_DE_ACUMULADOS()) //ABRE FORM
            {
                nv.StartPosition = FormStartPosition.Manual;
                nv.FormBorderStyle = FormBorderStyle.None;
                nv.Opacity = .70d;
                nv.BackColor = Color.Black;
                nv.WindowState = FormWindowState.Maximized;  //ESTILOS APLICABLES A ELEMENTOS 
                nv.TopMost = false;
                nv.Location = this.Location;
                nv.ShowInTaskbar = false;
                nv.Show();
                mn.Owner = nv;


                mn.ShowDialog();
                nv.Dispose();
            }

        }




        public static NORMAS prE = new NORMAS();




        public static CUESTIONAMINETO aes = new CUESTIONAMINETO(); //ABRE FORM






        //SUPERVISION SERVICIOS PERMANENTES
        public static SUP_SERV_PERM serv_perm = new SUP_SERV_PERM();  //ABRE FORM


        //SUPERVISION LABORATORIO CENTRAL
        public static SUP_LABO_CENTRAL labo_cent = new SUP_LABO_CENTRAL();  //ABRE FORM


        //AGENDA PERSONAL CENTRAL
        // public static AGENDAR_PERSONAL_CENTRAL AG_PER_CENT = new AGENDAR_PERSONAL_CENTRAL();



        //AGENDA SERVICIOS PERMANENTES (OBRA)
        public static AGENDAR_OBRA AG_OBRA = new AGENDAR_OBRA();





        public void REINICIA_ANALISIS_EVALUACION()
        {
            contenido.Controls.Clear();
            AN_EVA = new INDEX_SUP();
            AN_EVA.TopLevel = false;
            contenido.Controls.Add(AN_EVA);
            AN_EVA.Show();
        }




        public static DASHBOARD_EV_PERSONAL GEV = new DASHBOARD_EV_PERSONAL();





        public static INDEX_SUP AN_EVA = new INDEX_SUP();








    }
}
