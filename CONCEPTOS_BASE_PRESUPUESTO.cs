using ERP_LIEC;
using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace ERP_COMPLETO
{
    public partial class CONCEPTOS_BASE_PRESUPUESTO : Form
    {
        public CONCEPTOS_BASE_PRESUPUESTO()
        {
            InitializeComponent();
        }
        public string id;
        double SUBTOTAL_conceptos;

        private void actualizatotales()
        {

            foreach (DataGridViewRow row in DGV.Rows)
            {
                conexion_contabilidad_local.USR.Open();//Se abre la conexión para evitar un error común

                String Query = "UPDATE conceptos_presupuesto SET TOTAL= '" + row.Cells["SUBTOTAL"].Value.ToString() + "'   WHERE ID_SEGUIMIENTO  = '" + row.Cells["ID_SEGUMIENTO"].Value.ToString() + "';";
                MySqlCommand comando = new MySqlCommand(Query, conexion_contabilidad_local.USR);//Se interpreta el comando del query
                comando.ExecuteNonQuery();//Se ejecuta el comando del query

                conexion_contabilidad_local.USR.Close();//Se cierra la conexión
            }


        }
        double sumadeconceptos = 0;
        private void CONSULTAsubtotalesCONCEPTOS()
        {
            double toma = 0;
            foreach (DataGridViewRow row in DGV.Rows)
            {
                toma = 0;
                MySqlConnection CONEXION = conexion_contabilidad_local.USR;

                MySqlCommand comando = new MySqlCommand("SELECT TOTAL FROM conceptos_desglose  WHERE ID_DESGLOSE = '" + row.Cells["ID_SEGUMIENTO"].Value.ToString() + "' AND ESTATUS = 'AUTORIZADA' ", CONEXION);

                CONEXION.Open();
                MySqlDataReader consulta = comando.ExecuteReader();
                while (consulta.Read())
                {
                    toma = toma + double.Parse(consulta["TOTAL"].ToString());


                }
                row.Cells["SUBTOTAL"].Value = toma;
                CONEXION.Close();
            }

            sumadeconceptos = 0;
            foreach (DataGridViewRow row1 in DGV.Rows)
            {


                row1.Cells["SUBTOTAL"].Value = double.Parse(row1.Cells["SUBTOTAL"].Value.ToString()).ToString("N2");
                sumadeconceptos = sumadeconceptos + double.Parse(row1.Cells["SUBTOTAL"].Value.ToString());
            }
            ACTUALIZAGENERALES();
            MENU_PRICIPAL_ERP.psn.consulta_boton();
            pagar.Text = sumadeconceptos.ToString("N2");




            actualizatotales();


        }
        public string mes;
        public string año;
        public string area;


        private void ACTUALIZAGENERALES()
        {
            conexion_contabilidad_local.USR.Open();//Se abre la conexión para evitar un error común

            String Query = "UPDATE presupuestos_generales SET TOTAL= '" + sumadeconceptos + "'  WHERE (MES = '" + mes + "' AND AÑO = '" + año + "') AND (AREA = '" + area + "');";
            MySqlCommand comando = new MySqlCommand(Query, conexion_contabilidad_local.USR);//Se interpreta el comando del query
            comando.ExecuteNonQuery();//Se ejecuta el comando del query

            conexion_contabilidad_local.USR.Close();//Se cierra la conexión

        }
        public void CONSULTACONCEPTOS()
        {
            DGV.Rows.Clear();


            MySqlConnection CONEXION = conexion_contabilidad_local.USR;

            MySqlCommand comando = new MySqlCommand("SELECT * FROM conceptos_presupuesto   WHERE (MES = '" + mes + "' AND AÑO = '" + año + "') AND (AREA = '" + area + "')", CONEXION);

            CONEXION.Open();
            MySqlDataReader consulta = comando.ExecuteReader();
            while (consulta.Read())
            {
                string a1 = (consulta["ID_SEGUIMIENTO"].ToString());
                string a2 = (consulta["CONCEPTO"].ToString());
                string a3 = (consulta["TOTAL"].ToString());

                string aOBS = (consulta["OBSERVACIONES"].ToString());
                DGV.Rows.Add(a1, a2, aOBS, a3, "DETALLES");

            }
            CONEXION.Close();


            CONSULTAsubtotalesCONCEPTOS();
        }

        private void CONCEPTOS_BASE_PRESUPUESTO_Load(object sender, EventArgs e)
        {
            CONSULTACONCEPTOS();
        }

        private void ag1_Click(object sender, EventArgs e)
        {
            conexion_contabilidad_local.registrar("INSERT INTO conceptos_presupuesto  (CONCEPTO,TOTAL,MES,AÑO,AREA) values ('CONCEPTO NUEVO', '0.00' , '" + mes + "' , '" + año + "', '" + area + "' ) ");

            CONSULTACONCEPTOS();



        }
        private void actualiza()
        {
            foreach (DataGridViewRow row in DGV.Rows)
            {
                conexion_contabilidad_local.USR.Open();//Se abre la conexión para evitar un error común

                String Query = "UPDATE conceptos_presupuesto SET CONCEPTO= '" + row.Cells["CONCEPTO"].Value.ToString() + "', TOTAL= '" + double.Parse(row.Cells["SUBTOTAL"].Value.ToString()) + "'  , OBSERVACIONES= '" + row.Cells["OBSERVACIONES"].Value.ToString() + "' WHERE ID_SEGUIMIENTO  = '" + row.Cells["ID_SEGUMIENTO"].Value.ToString() + "';";
                MySqlCommand comando = new MySqlCommand(Query, conexion_contabilidad_local.USR);//Se interpreta el comando del query
                comando.ExecuteNonQuery();//Se ejecuta el comando del query

                conexion_contabilidad_local.USR.Close();//Se cierra la conexión
            }

        }
        private void DGV_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            actualiza();


        }

        private void DGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
            e.RowIndex >= 0)
            {

                CONCEPTOS_DESGLOSE_PRESUPUESTO CNZ = new CONCEPTOS_DESGLOSE_PRESUPUESTO();
                CNZ.id = DGV.CurrentRow.Cells["ID_SEGUMIENTO"].Value.ToString();

                CNZ.ShowDialog();



            }
        }
        private void elimina_desgloses()
        {
            conexion_contabilidad_local.USR.Open();//Se abre la conexión para evitar un error común
            String Query = "DELETE FROM conceptos_desglose WHERE ID_DESGLOSE = '" + DGV.CurrentRow.Cells["ID_SEGUMIENTO"].Value.ToString() + "';";

            MySqlCommand comando = new MySqlCommand(Query, conexion_contabilidad_local.USR);//Se interpreta el comando del query
            comando.ExecuteNonQuery();//Se ejecuta el comando del query

            conexion_contabilidad_local.USR.Close();//Se cierra la conexión
        }
        private void elimina_concepto()
        {
            conexion_contabilidad_local.USR.Open();//Se abre la conexión para evitar un error común
            String Query = "DELETE FROM conceptos_presupuesto WHERE ID_SEGUIMIENTO = '" + DGV.CurrentRow.Cells["ID_SEGUMIENTO"].Value.ToString() + "';";

            MySqlCommand comando = new MySqlCommand(Query, conexion_contabilidad_local.USR);//Se interpreta el comando del query
            comando.ExecuteNonQuery();//Se ejecuta el comando del query

            conexion_contabilidad_local.USR.Close();//Se cierra la conexión
        }
        private void DGV_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                DialogResult DL = MessageBox.Show("¿Deseas Eliminar el Concepto " + DGV.CurrentRow.Cells["ID_SEGUMIENTO"].Value.ToString() + " ?", "Notificación de Operación", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (DL == DialogResult.OK)
                {
                    elimina_desgloses();
                    elimina_concepto();
                    MENSAJE_GENERAL MN = new MENSAJE_GENERAL();
                    MN.BOTON.Text = "Eliminación Realizada";
                    MN.ShowDialog();
                    CONSULTACONCEPTOS();
                }

                else
                {

                }

            }

        }

        private void titulo_Click(object sender, EventArgs e)
        {


        }

        private void DGV_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {

        }
    }
}
