using ERP_LIEC;
using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace ERP_COMPLETO
{
    public partial class AGREGAR_INVENTARIO : Form
    {
        public AGREGAR_INVENTARIO()
        {
            InitializeComponent();
        }


        public string ct = "";

        private void PegarDesdeExcel(DataGridView dgv)
        {
            try
            {
                string clipboardText = Clipboard.GetText();
                string[] lines = clipboardText.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

                int rowIndex = dgv.CurrentCell?.RowIndex ?? 0;
                int colIndex = dgv.CurrentCell?.ColumnIndex ?? 0;

                foreach (string line in lines)
                {
                    string[] cells = line.Split('\t');

                    // Si se requieren más filas, se agregan
                    if (rowIndex >= dgv.Rows.Count)
                        dgv.Rows.Add();

                    for (int i = 0; i < cells.Length && (colIndex + i) < dgv.ColumnCount; i++)
                    {
                        dgv.Rows[rowIndex].Cells[colIndex + i].Value = cells[i];
                    }

                    rowIndex++;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al pegar desde Excel: " + ex.Message);
            }
        }

        private void DGV_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.V)
            {
                PegarDesdeExcel(DGV);
                e.Handled = true;
            }
        }

        private void rjButton3_Click(object sender, EventArgs e)
        {




            if (ct == "C.T. CENTRAL CDMX")
            {

            }
            else if (ct == "C.T. TEPOTZOTLÁN")
            {

            }
            else if (ct == "C.T. SAN LUIS POTOSÍ")
            {
                conexion_mantenimineto.USR.Open();//Se abre la conexión para evitar un error común
                String Query = "DELETE FROM inventario_snl ;";

                MySqlCommand comando = new MySqlCommand(Query, conexion_mantenimineto.USR);//Se interpreta el comando del query
                comando.ExecuteNonQuery();//Se ejecuta el comando del query

                conexion_mantenimineto.USR.Close();//Se cierra la conexión



                System.Windows.MessageBox.Show("ELIMINACIÓN EXITOSA");

                foreach (DataGridViewRow row in DGV.Rows)
                {



                    string query = @"INSERT INTO inventario_snl (
                        AREA, CLAVE, EQUIPO, MARCA,MODELO_SERIE, DESCRIPCION, 
                        RESOLUCION, CAPACIDAD, ESTADO, UBICACION_ACTUAL, OBSERVACIONES, USUARIO_ACTUALIZO, 
                       FECHA_ACTUALIZO) 
                    VALUES (@area, @clave, @equipo, @marca, @modelo, @descripcion, 
                            @resolucion, @capacidad, @estado, @ubicacion, @observaciones, @usuario, @fecha_actualizacion)";

                    using (MySqlCommand cmd = new MySqlCommand(query, conexion_mantenimineto.USR))
                    {
                        // Asignar valores directamente desde los TextBox y otros controles
                        cmd.Parameters.AddWithValue("@area", row.Cells[0].Value.ToString());
                        cmd.Parameters.AddWithValue("@clave", row.Cells[1].Value.ToString());
                        cmd.Parameters.AddWithValue("@equipo", row.Cells[2].Value.ToString());
                        cmd.Parameters.AddWithValue("@marca", row.Cells[3].Value.ToString());
                        cmd.Parameters.AddWithValue("@modelo", row.Cells[4].Value.ToString());
                        cmd.Parameters.AddWithValue("@descripcion", row.Cells[5].Value.ToString());
                        cmd.Parameters.AddWithValue("@resolucion", row.Cells[6].Value.ToString());
                        cmd.Parameters.AddWithValue("@capacidad", row.Cells[7].Value.ToString());  // Asumo que col no es un TextBox
                        cmd.Parameters.AddWithValue("@estado", row.Cells[8].Value.ToString());
                        cmd.Parameters.AddWithValue("@ubicacion", row.Cells[8].Value.ToString());
                        cmd.Parameters.AddWithValue("@observaciones", row.Cells[9].Value.ToString());
                        cmd.Parameters.AddWithValue("@usuario", "ERP");
                        cmd.Parameters.AddWithValue("@fecha_actualizacion", DateTime.Today.ToString("yyyy-MM-dd"));


                        try
                        {
                            conexion_mantenimineto.USR.Open();
                            cmd.ExecuteNonQuery();
                            conexion_mantenimineto.USR.Close();
                        }
                        catch (Exception q)
                        {
                            System.Windows.MessageBox.Show(q.Message);
                        }
                        finally
                        {
                            conexion_mantenimineto.USR.Close();
                        }


                    }

                    System.Windows.MessageBox.Show("Listo");

                }












            }
            else if (ct == "C.T. LERMA")
            {

            }









        }
    }
}
