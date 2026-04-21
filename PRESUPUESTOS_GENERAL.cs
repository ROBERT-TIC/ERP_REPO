using ERP_LIEC;
using MySql.Data.MySqlClient;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace ERP_COMPLETO
{
    public partial class PRESUPUESTOS_GENERAL : Form
    {
        public PRESUPUESTOS_GENERAL()
        {
            InitializeComponent();
        }



        public void consulta_boton()
        {
            DGV_EVENTOS.Columns.Clear();

            DGV_EVENTOS.DataSource = null;
            DGV_EVENTOS.DataSource = conexion_contabilidad_local.Consultageneral("SELECT * FROM presupuestos_generales WHERE MES='" + mes.Texts + "' AND  AÑO='" + año.Texts + "' ");

            DataGridViewColumn columnas = new DataGridViewColumn(new DataGridViewButtonCell());
            columnas.Name = "CHECK";
            columnas.HeaderText = "Selección";
            columnas.Width = 35;

            DGV_EVENTOS.Columns.Insert(0, columnas);

            timer1.Start();



        }


        private void PRESUPUESTOS_GENERAL_Load(object sender, EventArgs e)
        {

            mes.Texts = DateTime.Today.ToString("MM");
            año.Texts = DateTime.Today.ToString("yyyy");
            consulta_boton();
        }




        public static CONCEPTOS_BASE_PRESUPUESTO CN = new CONCEPTOS_BASE_PRESUPUESTO();
        private void ag1_Click(object sender, EventArgs e)
        {

            ALTA_PRESUPUESTO AL = new ALTA_PRESUPUESTO();
            AL.mes = mes.Texts;
            AL.año = año.Texts;
            AL.ShowDialog();





        }


        private void DGV_EVENTOS_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (SESION.usuario == "SVALDES" || SESION.usuario == "RROJAS")
            {




                if (DGV_EVENTOS.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() == "ENVIADO")
                {
                    MENSAJE_GENERAL MN = new MENSAJE_GENERAL();
                    MN.BOTON.Text = "Operación No Disponible";
                    MN.BOTON.Inactive1 = System.Drawing.Color.Red; MN.BOTON.Inactive2 = System.Drawing.Color.Red;
                    MN.ShowDialog();
                }

                else if (DGV_EVENTOS.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() == "NO ENVIADO")
                {
                    string FECHAN = año.Texts + "-" + mes.Texts + "-01";

                    DialogResult DL = MessageBox.Show("¿Deseas Enviar este Presupuesto?", "Notificación de Operación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (DL == DialogResult.Yes)
                    {
                        conexion_contabilidad_local.USR.Open();//Se abre la conexión para evitar un error común

                        String Query = "UPDATE presupuestos_generales SET ESTATUS= 'ENVIADO'   WHERE ID_SEGUIMIENTO  = '" + DGV_EVENTOS.CurrentRow.Cells["ID_SEGUMIENTO"].Value.ToString() + "';";
                        MySqlCommand comando = new MySqlCommand(Query, conexion_contabilidad_local.USR);//Se interpreta el comando del query
                        comando.ExecuteNonQuery();//Se ejecuta el comando del query

                        conexion_contabilidad_local.USR.Close();//Se cierra la conexión
                        conexion_contabilidad.registrar("INSERT INTO presupuesto (ID_RUBRO, DESCRIPCIÓN, MONTO, FECHA) VALUES ('" + DGV_EVENTOS.CurrentRow.Cells["RUBRO"].Value.ToString() + "' , '" + DGV_EVENTOS.CurrentRow.Cells["AREA"].Value.ToString() + "', '" + DGV_EVENTOS.CurrentRow.Cells["TOTAL"].Value.ToString() + "', '" + FECHAN + "' )");


                        DGV_EVENTOS.CurrentRow.Cells["ESTATUS"].Value = "ENVIADO";
                        PRESUPUESTOS_GENERAL.CN.CONSULTACONCEPTOS();
                        MENSAJE_GENERAL MN = new MENSAJE_GENERAL();
                        MN.BOTON.Text = "Autorización Realizada";
                        MN.ShowDialog();

                    }
                    else if (DL == DialogResult.No)
                    {

                    }


                }


            }


            else
            {

            }







        }

        private void btn_consultar_Click(object sender, EventArgs e)
        {
            consulta_boton();
        }

        private void imprimirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SESION.name == DGV_EVENTOS.CurrentRow.Cells["COORDINADOR"].Value.ToString() || SESION.usuario == "SVALDES" || SESION.usuario == "ACAMPOS" || SESION.usuario == "RROJAS" || SESION.usuario == "AVALDES")
            {
                CN = new CONCEPTOS_BASE_PRESUPUESTO();
                CN.mes = DGV_EVENTOS.CurrentRow.Cells["MES"].Value.ToString();
                CN.año = DGV_EVENTOS.CurrentRow.Cells["AÑO"].Value.ToString();
                CN.area = DGV_EVENTOS.CurrentRow.Cells["AREA"].Value.ToString();
                CN.ShowDialog();
            }
            else
            {
                MENSAJE_GENERAL MN = new MENSAJE_GENERAL();
                MN.BOTON.Inactive1 = System.Drawing.Color.Red; MN.BOTON.Active2 = System.Drawing.Color.Red;
                MN.BOTON.Text = "Consulta Denegada";
                MN.ShowDialog();
            }



        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void titulo_Click(object sender, EventArgs e)
        {


        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in DGV_EVENTOS.Rows)
            {
                row.Cells["CHECK"].Value = row.Cells["ESTATUS"].Value.ToString();
                row.Cells["TOTAL"].Value = double.Parse(row.Cells["TOTAL"].Value.ToString());

            }


            timer1.Stop();
        }
    }
}
