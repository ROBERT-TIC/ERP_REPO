using ERP_LIEC;
using System;
using System.Windows.Forms;

namespace ERP_COMPLETO.PROCEDIMIENTOS._2_EQUIPAMIENTO.MANTENIMIENTO
{
    public partial class ACTUALIZAR_ID_VEHICULO : Form
    {
        public ACTUALIZAR_ID_VEHICULO()
        {
            InitializeComponent();
        }

        MODIFICAR_VER_AUTO mod = new MODIFICAR_VER_AUTO();

        public string id_ve;

        private void actualizar_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show(
                "¿Estas seguro de querer actualizar este ID?",
                "ADVERTENCIA", MessageBoxButtons.YesNo
                );

            if (res == DialogResult.Yes)
            {

                mod.placas.Texts = placas.Texts;
                mod.año.Texts = año.Texts;
                mod.modelo.Texts = modelo.Texts;

                actualizar_tablas_bd();

                MessageBox.Show("Se ha actualizado con exito el ID", "ALERTA");

                this.Close();
            }
            else { }

        }

        private void placas__TextChanged(object sender, EventArgs e)
        {
            id_vehiculo_actualizado.Text = modelo.Texts + "-" + año.Texts + "-" + placas.Texts;
        }

        private void año__TextChanged(object sender, EventArgs e)
        {
            id_vehiculo_actualizado.Text = modelo.Texts + "-" + año.Texts + "-" + placas.Texts;
        }

        private void modelo__TextChanged(object sender, EventArgs e)
        {
            id_vehiculo_actualizado.Text = modelo.Texts + "-" + año.Texts + "-" + placas.Texts;
        }

        private void actualizar_tablas_bd()
        {
            conexion_mantenimineto.registrar("UPDATE asignacion_vehicular SET ID_VEHICULO='" + id_vehiculo_actualizado.Text + "', PLACAS = '" + placas.Texts + "' WHERE ID_VEHICULO = '" + id_ve + "'");

            conexion_mantenimineto.registrar("UPDATE autos_control_servicio SET ID_VEHICULO='" + id_vehiculo_actualizado.Text + "', MODELO = '" + modelo.Texts + "', AÑO = '" + año.Texts + "' WHERE ID_VEHICULO = '" + id_ve + "'");

            conexion_mantenimineto.registrar("UPDATE incidencias_autos SET ID_VEHICULO='" + id_vehiculo_actualizado.Text + "', PLACAS = '" + placas.Texts + "', MODELO='" + modelo.Texts + "', AÑO ='" + año.Texts + "' WHERE ID_VEHICULO = '" + id_ve + "'");

            conexion_mantenimineto.registrar("UPDATE verificacion_circulacion SET ID_VEHICULO='" + id_vehiculo_actualizado.Text + "' WHERE ID_VEHICULO = '" + id_ve + "'");

            conexion_mantenimineto.registrar("UPDATE verificacion_poliza SET ID_VEHICULO='" + id_vehiculo_actualizado.Text + "' WHERE ID_VEHICULO = '" + id_ve + "'");

            conexion_mantenimineto.registrar("UPDATE verificacion_vehicular SET ID_VEHICULO='" + id_vehiculo_actualizado.Text + "', MODELO = '" + modelo.Texts + "', PLACAS = '" + placas.Texts + "' WHERE ID_VEHICULO = '" + id_ve + "'");

            conexion_mantenimineto.registrar("UPDATE autos SET ID_VEHICULO='" + id_vehiculo_actualizado.Text + "', PLACAS = '" + placas.Texts + "', MODELO='" + modelo.Texts + "', AÑO ='" + año.Texts + "' WHERE ID_VEHICULO = '" + id_ve + "'");
        }

        private void ACTUALIZAR_ID_VEHICULO_Load(object sender, EventArgs e)
        {
            id_vehiculo_actualizado.Left = (PANEL_REFERENCIA.Width - id_vehiculo_actualizado.Width) / 2;
        }
    }
}
