using ERP_LIEC;
using iTextSharp.text.pdf;
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
    public partial class PAN_PND : Form
    {
        public PAN_PND()
        {
            InitializeComponent();
        }

        private void labelTelefono_MouseLeave(object sender, EventArgs e)
        {


            var button = sender as Label;


            button.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));



        }
       
        private void labelTelefono_MouseMove(object sender, EventArgs e)
        {


            var button = sender as Label;



            button.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));



        }

        private void eventos()
        {         
            label3.MouseMove += new System.Windows.Forms.MouseEventHandler(labelTelefono_MouseMove);
            label3.MouseLeave += new System.EventHandler(labelTelefono_MouseLeave);


            label8.MouseMove += new System.Windows.Forms.MouseEventHandler(labelTelefono_MouseMove);
            label8.MouseLeave += new System.EventHandler(labelTelefono_MouseLeave);

            label11.MouseMove += new System.Windows.Forms.MouseEventHandler(labelTelefono_MouseMove);
            label11.MouseLeave += new System.EventHandler(labelTelefono_MouseLeave);


            label10.MouseMove += new System.Windows.Forms.MouseEventHandler(labelTelefono_MouseMove);
            label10.MouseLeave += new System.EventHandler(labelTelefono_MouseLeave);

            label4.MouseMove += new System.Windows.Forms.MouseEventHandler(labelTelefono_MouseMove);
            label4.MouseLeave += new System.EventHandler(labelTelefono_MouseLeave);

            label1.MouseMove += new System.Windows.Forms.MouseEventHandler(labelTelefono_MouseMove);
            label1.MouseLeave += new System.EventHandler(labelTelefono_MouseLeave);

            label7.MouseMove += new System.Windows.Forms.MouseEventHandler(labelTelefono_MouseMove);
            label7.MouseLeave += new System.EventHandler(labelTelefono_MouseLeave);

            label5.MouseMove += new System.Windows.Forms.MouseEventHandler(labelTelefono_MouseMove);
            label5.MouseLeave += new System.EventHandler(labelTelefono_MouseLeave);

        }

        private void TOPES()
        {

            eventos();


            pictureBox6.Size = new Size(25, 25);
            pictureBox7.Size = new Size(25, 25);
            pictureBox9.Size = new Size(25, 25);
            pictureBox4.Size = new Size(25, 25);

            int sd_l = Panel_sidebar.Width / 2;



            //b1.Width = sd_l;

            b2.Width = sd_l;
            b3.Width = sd_l;



            //b1.Left = 0;
            b2.Left = 0;
            b3.Left = sd_l ;


            //sb1.Left = (b1.Width - sb1.Width) / 2;
            sb2.Left = (b2.Width - sb2.Width) / 2;
            sb3.Left = (b3.Width - sb3.Width) / 2;

            Sub_ensayos.Left = b2.Left + panel2.Width;
            Sub_ensayos.Width = b2.Width;

            Sub_ot.Left = b3.Left + panel2.Width;
            Sub_ot.Width = b3.Width;
        }

        private void PAN_PND_Load(object sender, EventArgs e)
        {
            TOPES();
        }







        public bool en_ensayo = false;
        public string clave1;
        public static HIS_RECEPCION_PND recepcion = new HIS_RECEPCION_PND();
        private void label3_Click(object sender, EventArgs e)
        {
            /*contenido.Controls.Clear();
            HIS_RECEPCION_PND HIS = new HIS_RECEPCION_PND();
            HIS.TopLevel = false;
            contenido.Controls.Add(HIS);
            HIS.Show();*/

            panel2.Visible = true;
            en_ensayo = false;
            separador.Visible = false;
            Sub_ensayos.Visible = false;
            
            contenido.Controls.Clear();
            recepcion = new HIS_RECEPCION_PND();
            recepcion.TopLevel = false;
            recepcion.clave_obra.Text = clave1;

            contenido.Controls.Add(recepcion);
            recepcion.Show();
        }









        private void label4_MouseMove(object sender, MouseEventArgs e)
        {
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

        }

        private void label1_MouseMove(object sender, MouseEventArgs e)
        {
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

        }

        private void label7_MouseMove(object sender, MouseEventArgs e)
        {
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

        }

        private void label3_MouseMove(object sender, MouseEventArgs e)
        {
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

        }

      
        private void label3_MouseLeave(object sender, EventArgs e)
        {
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

        }

        private void label4_MouseLeave(object sender, EventArgs e)
        {
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

        }

        private void label1_MouseLeave(object sender, EventArgs e)
        {
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

        }

        private void label7_MouseLeave(object sender, EventArgs e)
        {
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

        }
    
        
        public static LIQUIDOS_PEN2v en = new LIQUIDOS_PEN2v();
        private void label4_Click(object sender, EventArgs e)
        {
            if (Sub_ensayos.Visible == true)
            {
                Sub_ensayos.Visible = false;

            }
            else
            {
                Sub_ensayos.Visible = true;
            }



                    en = new LIQUIDOS_PEN2v();
                    en.label42.Text = "LIQUÍDOS PENETRANTES";
                    en.pictureBox5.Image = Properties.Resources.MI_LQ;
                    en.ShowDialog();

        }
     
        
        public static LAB_ULTRASONIDO rea = new LAB_ULTRASONIDO();
        
        private void label1_Click(object sender, EventArgs e)
        {
           if (Sub_ensayos.Visible == true)
            {
                Sub_ensayos.Visible = false;

            }
            else
            {
                Sub_ensayos.Visible = true;
            }



               rea = new LAB_ULTRASONIDO();
               rea.ShowDialog();

              

           





        }

        private void label7_Click(object sender, EventArgs e)
        {
            contenido.Controls.Clear();
            LAB_TORQUE corta = new LAB_TORQUE();
   
            corta.TopLevel = false;
      

            contenido.Controls.Add(corta);
            corta.Show();
        }
     
        public static LAB_INSP_SOLDADURA CSL = new LAB_INSP_SOLDADURA();
     
        private void label5_Click(object sender, EventArgs e)
        {
            contenido.Controls.Clear();
            CSL = new LAB_INSP_SOLDADURA();
            CSL.TopLevel = false;


            contenido.Controls.Add(CSL);
            CSL.Show();
        }

        private void label5_MouseMove(object sender, MouseEventArgs e)
        {
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

        }

        private void label5_MouseLeave(object sender, EventArgs e)
        {
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

        }
   
        public static AGENDA_SOLICITUDES Agesol = new AGENDA_SOLICITUDES();
      
        private void label2_Click(object sender, EventArgs e)
        {
       
            contenido.Controls.Clear();
            Agesol = new AGENDA_SOLICITUDES();
            Agesol.TopLevel = false;
         



            contenido.Controls.Add(Agesol);



            Agesol.Show();


        }
     
        public static ORDENES_DE_TRABAJO orden_nw = new ORDENES_DE_TRABAJO();
        
        private void label11_Click(object sender, EventArgs e)
        {
            Sub_ot.Visible = false;
            tabla.DataSource = conexion_servicios_eventuales.Consultageneral("SELECT * FROM ordenes_trabajo WHERE SOL_COBRANZA= 'SOLICITA'");


            if (tabla.RowCount == 0)
            {



                contenido.Controls.Clear();

                /*


                contenido.Controls.Clear();
                FORMULARIO_ORDEN corta = new FORMULARIO_ORDEN();
                corta.TopLevel = false;
                corta.usuario = SESION.usuario;
                corta.proceso = SESION.proceso;

                contenido.Controls.Add(corta);
                corta.Show();
                */
                orden_nw = new ORDENES_DE_TRABAJO();
                orden_nw.TopLevel = false;
                orden_nw.labo.Texts = "Servicio de PND";
                orden_nw.tipo_ot.Texts = "PND";
                orden_nw.tipo_ot.Enabled = false;
                
                orden_nw.desde_pnd = true;
                // corta.usuario = SESION.usuario;
                //corta.proceso = SESION.proceso;

                contenido.Controls.Add(orden_nw);
                orden_nw.Show();
            }
            else
            {
                MENSAJE_GENERAL MN = new MENSAJE_GENERAL();
                MN.BOTON.Inactive1 = Color.Red;
                MN.BOTON.Inactive2 = Color.Red;
                MN.BOTON.Text = "No puedes realizar mas OT, actualiza tus solicitudes de revisión";
                MN.Show();

            }
        }
     
        public static sguimiento_ordenes_pnds cortasg = new sguimiento_ordenes_pnds();

        public void seguimiento_pasar()
        {
            cortasg = new sguimiento_ordenes_pnds();
            contenido.Controls.Clear();

            cortasg.TopLevel = false;
            cortasg.usuario = SESION.usuario;
            cortasg.proceso = SESION.proceso;

            contenido.Controls.Add(cortasg);
            cortasg.Show();
        }
     
        private void label10_Click(object sender, EventArgs e)
        {
            Sub_ot.Visible = false;
            seguimiento_pasar();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            if (Sub_ot.Visible == true)
            {
                Sub_ensayos.Visible = false;
                Sub_ot.Visible = false;

            }
            else
            {
                Sub_ensayos.Visible = false;
                Sub_ot.Visible = true;
            }
        }

        private void Sub_ot_Paint(object sender, PaintEventArgs e)
        {

        }





    }
}
