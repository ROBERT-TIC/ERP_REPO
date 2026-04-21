using ERP_LIEC;   //DEFINEN UN AMBITO PARA UTILIZAR RECURSOS //
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;   //DEFINEN UN AMBITO PARA UTILIZAR RECURSOS //


namespace ERP_COMPLETO  //NOMBRE DEL ESPACIO
{
    public partial class AGREGAR_VER_TRAZABILIDAD : Form  //CLASE PRINCIPAL DEL FORMULARIO ACTUAL
    {
        public AGREGAR_VER_TRAZABILIDAD()
        {
            InitializeComponent();
        }

        private void AGREGAR_VER_TRAZABILIDAD_Load(object sender, EventArgs e)  //FUNCION PRINCIPAL DE ARRANQUE
        { 
            estetica();
            timer1.Start();
        }

        private void estetica()
        {
            label9.Left = (PANEL_REFERENCIA.Width - label9.Width) / 2;   //ESTILOS APLICABLES A ELEMENTOS 
            label9.Top = (PANEL_REFERENCIA.Height - label9.Height) / 2;
            pictureBox1.Left = (label9.Left - pictureBox1.Width) - 3;
            pictureBox1.Top = (PANEL_REFERENCIA.Height - pictureBox1.Height) / 2;   //ESTILOS APLICABLES A ELEMENTOS 
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Opacity = this.Opacity + .20;


            if (this.Opacity == 1)
            {

                timer1.Stop();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            try
            {

                System.Diagnostics.Process.Start(@"Z:\LIEP-02 EQUIPAMIENTO\REGISTROS\2022\01 MANTENIMIENTO\MANTENIMIENTO\ERP\INVENTARIO\" + id_recepcion.Texts + @"\" + id_recepcion.Texts + " - TRAZABILIDAD" + ".pdf"); //RUTAS DE ACCESO A RECURSOS 

            }
            catch
            {
                MENSAJE_GENERAL MN = new MENSAJE_GENERAL();
                MN.BOTON.Text = "No se encontro ningún documento cargado";   //MENSAJE ALERTA 
                MN.Show();


            }
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            string ruta = @"Z:\LIEP-02 EQUIPAMIENTO\REGISTROS\2022\01 MANTENIMIENTO\MANTENIMIENTO\ERP\INVENTARIO\" + id_recepcion.Texts + @"\" + id_recepcion.Texts + " - TRAZABILIDAD" + ".pdf";  //RUTAS DE ACCESO A RECURSOS 

            if (File.Exists(ruta))   //VALIDA EXISTENCIA DE CARPETA 
            {
                File.Delete(ruta);
                MENSAJE_GENERAL MN = new MENSAJE_GENERAL();
                MN.BOTON.Text = "Documento eliminado, no olvides actualizarlo posteriormente";
                MN.Show();
            }
            else
            {
                MENSAJE_GENERAL MN = new MENSAJE_GENERAL();
                MN.BOTON.Text = "Error al eliminar el documento";   //MENSAJE ALERTA 
                MN.Show();
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            // FUNCIÓN PARA CREAR UNA CARPETA CON LA CLAVE DEL EQUIPO Y Y SUBIR UNA TRAZABILIDAD EN .PDF

            try
            {
                OpenFileDialog archivo = new OpenFileDialog();



                archivo.InitialDirectory = "C:\\";
                archivo.Filter = "Todos los archivos (*.*)|*.*";
                archivo.FilterIndex = 1;
                archivo.RestoreDirectory = true;
                string ruta = @"Z:\LIEP-02 EQUIPAMIENTO\REGISTROS\2022\01 MANTENIMIENTO\MANTENIMIENTO\ERP\INVENTARIO\" + id_recepcion.Texts + @"\" + id_recepcion.Texts + " - TRAZABILIDAD" + ".pdf";  //RUTAS DE ACCESO A RECURSOS 
                string carpeta = @"Z:\LIEP-02 EQUIPAMIENTO\REGISTROS\2022\01 MANTENIMIENTO\MANTENIMIENTO\ERP\INVENTARIO\" + id_recepcion.Texts + " ";  //RUTAS DE ACCESO A RECURSOS 

                if (Directory.Exists(carpeta))  //VALIDA EXISTENCIA DE CARPETA 
                {

                }
                else
                {
                    Directory.CreateDirectory(carpeta);  //VALIDA EXISTENCIA DE CARPETA 

                }

                if (archivo.ShowDialog() == DialogResult.OK)
                {

                    if (File.Exists(ruta))
                    {
                        File.Delete(ruta);
                    }

                    MessageBox.Show("Favor de esperar unos segundos", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    File.Copy(archivo.FileName, ruta);

                    MENSAJE_GENERAL MN = new MENSAJE_GENERAL();   //MENSAJE ALERTA 
                    MN.BOTON.Text = "Documento cargado con exito";
                    MN.Show();
                }



            }

            catch
            {
                MENSAJE_GENERAL MN = new MENSAJE_GENERAL();
                MN.BOTON.Text = "Tuvimos problemas al cargar el documento";   //MENSAJE ALERTA 
                MN.Show();

            }
        }
    }

}
