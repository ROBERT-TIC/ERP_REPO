using ERP_LIEC;
using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace ERP_COMPLETO
{
    public partial class CONCEPTOS_DESGLOSE_PRESUPUESTO : Form
    {
        public CONCEPTOS_DESGLOSE_PRESUPUESTO()
        {
            InitializeComponent();
        }
        public string id;

        private void CONSULTADESGLOSE()
        {
            DGV.Rows.Clear();
            MySqlConnection CONEXION = conexion_contabilidad_local.USR;

            MySqlCommand comando = new MySqlCommand("SELECT * FROM conceptos_desglose   WHERE ID_DESGLOSE = '" + id + "'", CONEXION);

            CONEXION.Open();
            MySqlDataReader consulta = comando.ExecuteReader();
            while (consulta.Read())
            {
                string a1 = (consulta["ID_SEGUIMIENTO"].ToString());
                string a2 = (consulta["CONCEPTO"].ToString());
                string a3 = (consulta["UNIDAD"].ToString());
                string a4 = (consulta["CANTIDAD"].ToString());
                string a5 = (consulta["PU"].ToString());
                string a6 = (consulta["TOTAL"].ToString());
                string a7 = (consulta["ESTATUS"].ToString());

                string REF = (consulta["REFERENCIA"].ToString());

                DGV.Rows.Add(a1, a2, REF, a3, a4, a5, a6, a7);

            }
            CONEXION.Close();
            sumafilas();
        }



        private void CONCEPTOS_DESGLOSE_PRESUPUESTO_Load(object sender, EventArgs e)
        {
            CONSULTADESGLOSE();
            suma();
        }

        double sumatoria = 0;
        double sumatoria2 = 0;
        private void suma()
        {
            sumatoria = 0;
            sumatoria2 = 0;
            foreach (DataGridViewRow row in DGV.Rows)
            {
                if (row.Cells["ESTATUS"].Value.ToString() == "AUTORIZADA")
                {
                    sumatoria2 = sumatoria2 + double.Parse(row.Cells["SUBTOTAL"].Value.ToString());
                }


                sumatoria = sumatoria + double.Parse(row.Cells["SUBTOTAL"].Value.ToString());


            }
            pagar2.Text = sumatoria.ToString("N2");
            pagar.Text = sumatoria2.ToString("N2");
        }

        private void sumafilas()
        {

            foreach (DataGridViewRow row in DGV.Rows)
            {
                row.Cells["SUBTOTAL"].Value = (double.Parse(row.Cells["PU"].Value.ToString()) * double.Parse(row.Cells["CANTIDAD"].Value.ToString())).ToString("N2");


            }


        }

        private void DGV_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

            sumafilas();


            suma();
            actualiza();
        }
        private void actualiza()
        {

            conexion_contabilidad_local.USR.Open();//Se abre la conexión para evitar un error común

            String Query = "UPDATE conceptos_desglose SET CONCEPTO= '" + DGV.CurrentRow.Cells["CONCEPTO"].Value.ToString() + "',UNIDAD= '" + DGV.CurrentRow.Cells["UNIDAD"].Value.ToString() + "',CANTIDAD= '" + DGV.CurrentRow.Cells["CANTIDAD"].Value.ToString() + "',PU= '" + DGV.CurrentRow.Cells["PU"].Value.ToString() + "',TOTAL= '" + double.Parse(DGV.CurrentRow.Cells["SUBTOTAL"].Value.ToString()) + "', REFERENCIA= '" + DGV.CurrentRow.Cells["REFERENCIA"].Value.ToString() + "'   WHERE ID_SEGUIMIENTO  = '" + DGV.CurrentRow.Cells["ID_SEGUMIENTO"].Value.ToString() + "';";
            MySqlCommand comando = new MySqlCommand(Query, conexion_contabilidad_local.USR);//Se interpreta el comando del query
            comando.ExecuteNonQuery();//Se ejecuta el comando del query

            conexion_contabilidad_local.USR.Close();//Se cierra la conexión


        }
        private void ag1_Click(object sender, EventArgs e)
        {

            conexion_contabilidad_local.registrar("INSERT INTO conceptos_desglose  (ID_DESGLOSE,CONCEPTO,UNIDAD,CANTIDAD,PU,TOTAL,ESTATUS,REFERENCIA) values ('" + id + "','CONCEPTO NUEVO', 'UNIDAD','1','0.00' , '0.00', 'PENDIENTE','---' ) ");

            DGV.Rows.Clear();

            CONSULTADESGLOSE();



        }

        private void DGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {




            var senderGrid = (DataGridView)sender;
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
            e.RowIndex >= 0)
            {
                if (SESION.usuario == "SVALDES")
                {

                    if (DGV.CurrentRow.Cells["ESTATUS"].Value.ToString() == "AUTORIZADA" || DGV.CurrentRow.Cells["ESTATUS"].Value.ToString() == "DENEGADA")
                    {
                        MENSAJE_GENERAL MN = new MENSAJE_GENERAL();
                        MN.BOTON.Text = "Operación No Disponible";
                        MN.BOTON.Inactive1 = System.Drawing.Color.Red; MN.BOTON.Inactive2 = System.Drawing.Color.Red;
                        MN.ShowDialog();
                    }

                    else if (DGV.CurrentRow.Cells["ESTATUS"].Value.ToString() == "PENDIENTE")
                    {


                        DialogResult DL = MessageBox.Show("¿Deseas Autorizar este Concepto?", "Notificación de Operación", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                        if (DL == DialogResult.Yes)
                        {
                            conexion_contabilidad_local.USR.Open();//Se abre la conexión para evitar un error común

                            String Query = "UPDATE conceptos_desglose SET ESTATUS= 'AUTORIZADA'   WHERE ID_SEGUIMIENTO  = '" + DGV.CurrentRow.Cells["ID_SEGUMIENTO"].Value.ToString() + "';";
                            MySqlCommand comando = new MySqlCommand(Query, conexion_contabilidad_local.USR);//Se interpreta el comando del query
                            comando.ExecuteNonQuery();//Se ejecuta el comando del query

                            conexion_contabilidad_local.USR.Close();//Se cierra la conexión


                            DGV.CurrentRow.Cells["ESTATUS"].Value = "AUTORIZADA";
                            PRESUPUESTOS_GENERAL.CN.CONSULTACONCEPTOS();
                            MENSAJE_GENERAL MN = new MENSAJE_GENERAL();
                            MN.BOTON.Text = "Autorización Realizada";
                            MN.ShowDialog();

                        }
                        else if (DL == DialogResult.No)
                        {
                            conexion_contabilidad_local.USR.Open();//Se abre la conexión para evitar un error común

                            String Query = "UPDATE conceptos_desglose SET ESTATUS= 'DENEGADA'   WHERE ID_SEGUIMIENTO  = '" + DGV.CurrentRow.Cells["ID_SEGUMIENTO"].Value.ToString() + "';";
                            MySqlCommand comando = new MySqlCommand(Query, conexion_contabilidad_local.USR);//Se interpreta el comando del query
                            comando.ExecuteNonQuery();//Se ejecuta el comando del query

                            conexion_contabilidad_local.USR.Close();//Se cierra la conexión


                            DGV.CurrentRow.Cells["ESTATUS"].Value = "DENEGADA";
                            PRESUPUESTOS_GENERAL.CN.CONSULTACONCEPTOS();
                            MENSAJE_GENERAL MN = new MENSAJE_GENERAL();
                            MN.BOTON.Text = "Denegación Realizada";
                            MN.ShowDialog();
                        }


                    }

                }


                else
                {


                    MENSAJE_GENERAL MN = new MENSAJE_GENERAL();
                    MN.BOTON.Text = "Solo Dirección General";
                    MN.ShowDialog();




                }
            }

            else
            {
                if (DGV.CurrentRow.Cells["ESTATUS"].Value.ToString() == "AUTORIZADA")
                {
                    DGV.CurrentRow.Cells["CONCEPTO"].ReadOnly = true;
                    DGV.CurrentRow.Cells["UNIDAD"].ReadOnly = true;
                    DGV.CurrentRow.Cells["PU"].ReadOnly = true;

                }
                else
                {
                    DGV.CurrentRow.Cells["CONCEPTO"].ReadOnly = false;
                    DGV.CurrentRow.Cells["UNIDAD"].ReadOnly = false;
                    DGV.CurrentRow.Cells["PU"].ReadOnly = false;
                }
            }

        }

        private void DGV_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {

                if (DGV.CurrentRow.Cells["ESTATUS"].Value.ToString() == "AUTORIZADA" || DGV.CurrentRow.Cells["ESTATUS"].Value.ToString() == "DENEGADA")
                {
                    MENSAJE_GENERAL MN = new MENSAJE_GENERAL();
                    MN.BOTON.Text = "Operación no Disponible";
                    MN.ShowDialog();
                }
                else
                {



                    DialogResult DL = MessageBox.Show("¿Deseas Eliminar el Concepto " + DGV.CurrentRow.Cells["ID_SEGUMIENTO"].Value.ToString() + " ?", "Notificación de Operación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (DL == DialogResult.Yes)
                    {
                        conexion_contabilidad_local.USR.Open();//Se abre la conexión para evitar un error común
                        String Query = "DELETE FROM conceptos_desglose WHERE ID_SEGUIMIENTO = '" + DGV.CurrentRow.Cells["ID_SEGUMIENTO"].Value.ToString() + "';";

                        MySqlCommand comando = new MySqlCommand(Query, conexion_contabilidad_local.USR);//Se interpreta el comando del query
                        comando.ExecuteNonQuery();//Se ejecuta el comando del query

                        conexion_contabilidad_local.USR.Close();//Se cierra la conexión
                        PRESUPUESTOS_GENERAL.CN.CONSULTACONCEPTOS();
                        DGV.Rows.RemoveAt(DGV.SelectedRows[0].Index);

                        suma();

                        PRESUPUESTOS_GENERAL.CN.CONSULTACONCEPTOS();
                        MENSAJE_GENERAL MN = new MENSAJE_GENERAL();
                        MN.BOTON.Text = "Eliminación Realizada";
                        MN.ShowDialog();
                    }

                    else
                    {

                    }
                }


            }
        }
    }
}
