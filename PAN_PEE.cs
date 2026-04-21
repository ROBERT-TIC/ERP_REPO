using ERP_COMPLETO.PROCEDIMIENTOS._2_EQUIPAMIENTO.MANTENIMIENTO;
using ERP_COMPLETO.PROCEDIMIENTOS._2_EQUIPAMIENTO.TIC;
using ERP_LIEC;    //DEFINEN UN AMBITO PARA UTILIZAR RECURSOS //
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;  //DEFINEN UN AMBITO PARA UTILIZAR RECURSOS //

namespace ERP_COMPLETO  //NOMBRE DEL ESPACIO
{
    public partial class PAN_PEE : Form //CLASE PRINCIPAL DEL FORMULARIO ACTUAL
    {

        private void AddHoverEffect(Button btn)
        {
            // Color normal
            Color normalColor = Color.FromArgb(16, 77, 141);
            // Color al pasar el mouse o seleccionado
            Color hoverColor = Color.FromArgb(227, 76, 14);

            bool isSelected = false; // bandera para saber si está clicado

            // Evento cuando entra el mouse
            btn.MouseEnter += (s, e) =>
            {
                if (!isSelected) // solo cambia si no está seleccionado
                    btn.BackColor = hoverColor;
            };

            // Evento cuando sale el mouse
            btn.MouseLeave += (s, e) =>
            {
                if (!isSelected) // si no está seleccionado, vuelve al normal
                    btn.BackColor = normalColor;
            };

            // Evento cuando hago clic
            btn.Click += (s, e) =>
            {
                isSelected = !isSelected; // alterna entre seleccionado y no
                btn.BackColor = isSelected ? hoverColor : normalColor;
            };
        }


        private void AddHoverEffectsub(Button btn)
        {
            // Color normal
            Color normalColor = Color.FromArgb(255, 255, 255);
            // Color al pasar el mouse
            Color hoverColor = Color.FromArgb(197, 59, 3);

            // Evento cuando entra el mouse
            btn.MouseEnter += (s, e) =>
            {
                btn.BackColor = hoverColor;
                btn.ForeColor = Color.FromArgb(255, 255, 255);
            };

            btn.MouseLeave += (s, e) =>
            {
                btn.BackColor = normalColor;
                btn.ForeColor = Color.FromArgb(16, 77, 141); // o el color que quieras que regrese
            };
        }
        private void labelTelefono_MouseLeave(object sender, EventArgs e)
        {


            var button = sender as Label;


            button.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);



        }
        private void labelTelefono_MouseMove(object sender, EventArgs e)  //EVENTO MUEVE ELEMENTO
        {


            var button = sender as Label;



            button.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Underline, GraphicsUnit.Point, 0);



        }
        private void eventos()
        {
           
        }


        private void TOPES()
        {

            int sd_l = panel_sd.Width / 4;  //ESTILOS APLICABLES A ELEMENTOS 
            int ancho_botones = (panel_sd.Width / 4) - 10;  //ESTILOS APLICABLES A ELEMENTOS 

            int pc1 = (int)(sd_l * 0.105);
            int pc2 = (int)(sd_l * 0.04);
            int pc3 = (int)(sd_l * 0.100);
            int pc4 = (int)(sd_l * 0.028);

            personal_bt.Width = ancho_botones;  //POSICIONA BOTON RECLUTAMIENTO

            button1.Width = ancho_botones;  //POSICIONA BOTON RECLUTAMIENTO
            button2.Width = ancho_botones;
            button3.Width = ancho_botones;

            int ancho_estandar = panel_sd.Width;

            personal_bt.Width = sd_l;  //POSICIONA BOTON PERSONAL

            button1.Width = sd_l;  //POSICIONA BOTON RECLUTAMIENTO
            button2.Width = sd_l;
            button3.Width = sd_l;

            panel4.Width = button1.Width + 5;

            panel4.Left = button1.Left;
            panel4.Top = panel1.Height;


        }
        public PAN_PEE()
        {
            InitializeComponent();
        }


       

      

      

        private void PAN_MTN_Load(object sender, EventArgs e)  //FUNCION PRINCIPAL DE ARRANQUE
        {
            TOPES();  //FUNCIONES A LLAMAR AL INICIAR EL FORMULARIO
            eventos();



            // Aplica el efecto a los botones que quieras
            AddHoverEffect(personal_bt);
            AddHoverEffect(button1);
            AddHoverEffect(button2);
            AddHoverEffect(button3);
       


          
        }

     



    public static CONSULTA_INVENTARIO equ_cons = new CONSULTA_INVENTARIO();  //ABRE FORMULARIO
      

        private void label9_Click(object sender, EventArgs e)
        {

        
        }

        private void sb2_Paint(object sender, PaintEventArgs e)
        {

        }

     

        private void pictureBox15_Click(object sender, EventArgs e)
        {
            //Form nv = new Form();
            //using (RECEPCION_EQUIPO2 mn = new RECEPCION_EQUIPO2())
            //{
            //    nv.StartPosition = FormStartPosition.Manual;
            //    nv.FormBorderStyle = FormBorderStyle.None;
            //    nv.Opacity = .70d;
            //    nv.BackColor = Color.Black;
            //    nv.WindowState = FormWindowState.Maximized;
            //    nv.TopMost = false;
            //    nv.Location = this.Location;
            //    nv.ShowInTaskbar = false;
            //    nv.Show();
            //    mn.Owner = nv;
            //    mn.Opacity = 0;
            //    mn.TopMost = false;

            //    mn.ShowDialog();

            //    nv.Dispose();
            //}
        }
 
        private void label5_Click(object sender, EventArgs e)
        {
            contenido.Controls.Clear();
            IND_MTN = new indicadores_mtn();
            IND_MTN.TopLevel = false;
            contenido.Controls.Add(IND_MTN);


            IND_MTN.Show();

          
            
          
        }
        int cante = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            



        }
        Control_instalacion Agesol = new Control_instalacion();  //ABRE FORMULARIO
        private void label7_Click_1(object sender, EventArgs e)
        {

            contenido.Controls.Clear();
            Agesol = new Control_instalacion();
            Agesol.TopLevel = false;

            contenido.Controls.Add(Agesol);


            Agesol.Show();
        }

        private void OT_Click(object sender, EventArgs e)
        {
            contenido.Controls.Clear();
            Agesol = new Control_instalacion();
            Agesol.TopLevel = false;

            contenido.Controls.Add(Agesol);


            Agesol.Show();
        }
       indicadores_mtn IND_MTN = new indicadores_mtn();  //ABRE FORMULARIO
        private void label6_Click(object sender, EventArgs e)
        {
            
        }
       public static CONTROL_CASETAS equ_cons2 = new CONTROL_CASETAS();
        private void label8_Click_1(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {
            
        }

        private void label1_Click_2(object sender, EventArgs e)
        {
            
        }

     

       
    

        private void button4_Click(object sender, EventArgs e)
        {
            



            //sub3.Visible = false;
            //sub2.Visible = false;
            //contenido.Controls.Clear();
            //RECEPPCION_EQUIPO corta = new RECEPPCION_EQUIPO();
            //corta.TopLevel = false;




            //contenido.Controls.Add(corta);



            //corta.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            
        }


     

      
      

        private void button2_Click(object sender, EventArgs e)
        {
          


            contenido.Controls.Clear();
            reset();
            button2.BackColor = Color.FromArgb(227, 76, 14);  //POSICIONA BOTON PERSONAL

        }

        private void personal_bt_Click(object sender, EventArgs e)
        {
           
            reset();
            personal_bt.BackColor = Color.FromArgb(227, 76, 14);  //POSICIONA BOTON PERSONAL



        }

        private void reset()
        {
            personal_bt.BackColor = Color.FromArgb(16, 77, 141);  //POSICIONA BOTON PERSONAL

            button1.BackColor = Color.FromArgb(16, 77, 141);  //POSICIONA BOTON RECLUTAMIENTO
            button2.BackColor = Color.FromArgb(16, 77, 141);
            button3.BackColor = Color.FromArgb(16, 77, 141);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            reset();
            button1.BackColor = Color.FromArgb(227, 76, 14);  //POSICIONA BOTON PERSONAL

            if(panel4.Visible==true)
            {
                panel4.Visible = false;
            }
            else
            {
                panel4.Visible = true;
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            reset();

            button3.BackColor = Color.FromArgb(227, 76, 14);
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            SOLICITUD_EQUIPO_ALMACEN soli = new SOLICITUD_EQUIPO_ALMACEN();
            soli.ShowDialog();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            SOLICITUD_EQUIPO_ALMACEN soli = new SOLICITUD_EQUIPO_ALMACEN();
            soli.ShowDialog();
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            CATALOGO_EQUIPO soli = new CATALOGO_EQUIPO();
            soli.ShowDialog();
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            PROCEDIMIENTOS._2_EQUIPAMIENTO.MANTENIMIENTO.RECEPCION_EQUIPO_SOLICITUDES soli = new PROCEDIMIENTOS._2_EQUIPAMIENTO.MANTENIMIENTO.RECEPCION_EQUIPO_SOLICITUDES();
            soli.ShowDialog();
        }

        private void contenido_Paint(object sender, PaintEventArgs e)
        {

        }


        public static GESTION_DENSIMETRO equi = new GESTION_DENSIMETRO();
        private void button11_Click(object sender, EventArgs e)
        {
            contenido.Controls.Clear();
            equi = new GESTION_DENSIMETRO();
            equi.TopLevel = false;
            contenido.Controls.Add(equi);
            equi.Show();
        }








    }
}
