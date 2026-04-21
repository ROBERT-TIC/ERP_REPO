using System;  //DEFINEN UN AMBITO PARA UTILIZAR RECURSOS //
using System.Windows.Forms;  //DEFINEN UN AMBITO PARA UTILIZAR RECURSOS //

namespace ERP_COMPLETO.PROCEDIMIENTOS._2_EQUIPAMIENTO.MANTENIMIENTO
{
    public partial class Agregar_Vehiculo : Form  //CLASE PRINCIPAL DEL FORMULARIO ACTUAL
    {
        public Agregar_Vehiculo()
        {
            InitializeComponent();  //INICIALIZA COMPONENTE
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Opacity = this.Opacity + .20;


            if (this.Opacity == 1)
            {

                timer1.Stop();
            }
        }

        private void Agregar_Vehiculo_Load(object sender, EventArgs e)  //FUNCION PRINCIPAL DE ARRANQUE
        {
            timer1.Start();
            bunifuElipse1.ApplyElipse(MARCA);
            bunifuElipse1.ApplyElipse(TIPO);

            bunifuElipse1.ApplyElipse(MODELO);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();   //CIERRA VENTANA
        }
    }
}
