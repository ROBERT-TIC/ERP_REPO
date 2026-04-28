using Aspose.Cells.Drawing;
using Bonsai.Reactive;
using DocumentFormat.OpenXml.Drawing.Charts;
using DocumentFormat.OpenXml.Math;
using DocumentFormat.OpenXml.Presentation;
using DocumentFormat.OpenXml.Wordprocessing;
using Emgu.Util.TypeEnum;
using ERP_LIEC;
using Irony.Parsing;
using iTextSharp.text;
using iTextSharp.text.pdf;
using MySql.Data.MySqlClient;
using SpreadsheetLight;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Media.Media3D;
using ZXing.PDF417.Internal;
using static Syncfusion.Windows.Forms.TabBar;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TreeView;
using Excel = Microsoft.Office.Interop.Excel;
using Font = iTextSharp.text.Font;
using Image = iTextSharp.text.Image;
using Label = System.Windows.Forms.Label;
using Paragraph = iTextSharp.text.Paragraph;
using Rectangle = iTextSharp.text.Rectangle;

namespace ERP_COMPLETO
{
    public partial class DENSIMETRO_ELECTROMAGNETICO : Form
    {
        public DENSIMETRO_ELECTROMAGNETICO()
        {
            InitializeComponent();
        }

        public string didi = "";
        public string clave_mues = "";



        private void DENSIMETRO_ELECTROMAGNETICO_Load(object sender, EventArgs e)
        {
            consulta_densimetro();
            CargarTecnicosActivos();

            label32.MouseMove += new System.Windows.Forms.MouseEventHandler(labelTelefono_MouseMove);
            label20.MouseMove += new System.Windows.Forms.MouseEventHandler(labelTelefono_MouseMove);
            label33.MouseMove += new System.Windows.Forms.MouseEventHandler(labelTelefono_MouseMove);
            label34.MouseMove += new System.Windows.Forms.MouseEventHandler(labelTelefono_MouseMove);

            label32.MouseLeave += new System.EventHandler(labelTelefono_MouseLeave);
            label20.MouseLeave += new System.EventHandler(labelTelefono_MouseLeave);
            label33.MouseLeave += new System.EventHandler(labelTelefono_MouseLeave);
            label34.MouseLeave += new System.EventHandler(labelTelefono_MouseLeave);
        }



        private void consulta_densimetro()
        {
            MySqlCommand query = new MySqlCommand();
            query.CommandText = "SELECT * FROM densimetro_referencias WHERE ID_SEGUIMIENTO = '" + didi + "' ";  //QUERY DE CONSULTA
            MySqlDataReader consulta;
            query.Connection = CONEXION_REMOTO_PND.USR;
            query.Connection.Open();
            consulta = query.ExecuteReader();

            while (consulta.Read())
            {
                ID.Texts = (consulta["ID_SEGUIMIENTO"].ToString());
                FECHA_ENSAYE.Text = (consulta["FECHA_ENSAYE"].ToString());
                CLAVE_OBRA.Texts = (consulta["CLAVE_OBRA"].ToString());
                NO_INFORME.Texts = (consulta["NO_INFORME"].ToString());
                OBRA.Texts = (consulta["OBRA"].ToString());
                CLIENTE.Texts = (consulta["CLIENTE"].ToString());
                ATENCION.Texts = (consulta["ATENCION"].ToString());
                if (FECHA_INFORME.Text == "0001-01-01")
                {
                    FECHA_INFORME.Text = DateTime.Today.ToString("yyyy-MM-dd");
                }
                MATERIAL.Texts = (consulta["MATERIAL"].ToString());
                COMPACTACION_PROYECTO.Texts = (consulta["COMPACTACION_PROYECTO"].ToString());
                PROCEDENCIA.Texts = (consulta["PROCEDENCIA"].ToString());
                HUMEDAD_OPTIMA.Texts = (consulta["HUMEDAD_OPTIMA"].ToString());
                USO_MATERIAL.Texts = (consulta["USO_MATERIAL"].ToString());
                UBICACION.Texts = (consulta["UBICACION"].ToString());
                MEDIDOR.Texts = (consulta["MEDIDOR"].ToString());
                MARCA.Texts = (consulta["MARCA"].ToString());
                MODELO.Texts = (consulta["MODELO"].ToString());
                NO_SERIE.Texts = (consulta["NO_SERIE"].ToString());
                USUARIO.Texts = (consulta["USUARIO"].ToString());
                if (FECHA_REGISTRO.Text == "0001-01-01")
                {
                    FECHA_REGISTRO.Text = DateTime.Today.ToString("yyyy-MM-dd");
                }
                OBSERVACIONES.Texts = (consulta["OBSERVACIONES"].ToString());
                TEMPERATURA.Texts = (consulta["TEMPERATURA"].ToString());
                HUMEDAD_RELATIVA.Texts = (consulta["HUMEDAD_RELATIVA"].ToString());
                clave_mues = (consulta["CLAVE_MUESTRA"].ToString());
                REVISO.Texts = (consulta["REVISO"].ToString());
                REALIZO.Texts = (consulta["REALIZO"].ToString());
                TIPO_CAPA.Texts = (consulta["TIPO_CAPA"].ToString());
                TIPO_ENSAYE.Texts = (consulta["TIPO_ENSAYE"].ToString());
                NO_CALIDAD.Texts = (consulta["NO_CALIDAD"].ToString());
                MVSM.Texts = (consulta["MVSM"].ToString());
            }

            query.Connection.Close();


            DGV_PADRON.DataSource = CONEXION_REMOTO_PND.CONSULTA_GENERAL("SELECT ID_SEGUIMIENTO, NUMERO_SONDEO , LOCALIZACION_SONDEO, NUMERO_CAPA, ESPESOR_CAPA_CM, NUMERO_TARA, MASA_TARA, MASA_TARA_MAT_HUM, MASA_MAT_HUM, MASA_TARA_MAT_SECO, MASA_MAT_SECO, 	CONTEN_AGUA, MASA_VOL_MAT_HUMEDO, MASA_VOL_SEC_LUG, MASA_VOL_SEC_MAX_MAT, COMPACTACION       FROM sondeos_densimetro WHERE CLAVE_MUESTRA = '" + clave_mues + "'  ");

            DGV_PADRON.Columns[0].HeaderText = "Id";
            DGV_PADRON.Columns[1].HeaderText = "No.";
            DGV_PADRON.Columns[2].HeaderText = "Localización";
            DGV_PADRON.Columns[3].HeaderText = "No. de capa";
            DGV_PADRON.Columns[4].HeaderText = "Espesor de capa (cm)";
            DGV_PADRON.Columns[5].HeaderText = "No. de tara";
            DGV_PADRON.Columns[6].HeaderText = "Masa de tara";
            DGV_PADRON.Columns[7].HeaderText = "Masa de tara + Mat. Hum";
            DGV_PADRON.Columns[8].HeaderText = "Masa de mat. Hum";
            DGV_PADRON.Columns[9].HeaderText = "Masa de tara + Mat. Seco";
            DGV_PADRON.Columns[10].HeaderText = "Masa de Mat. Seco";
            DGV_PADRON.Columns[11].HeaderText = "Contenido de agua";
            DGV_PADRON.Columns[12].HeaderText = "Masa Vol de Mat. Hum";
            DGV_PADRON.Columns[13].HeaderText = "Masa Vol. Seca del lugar";
            DGV_PADRON.Columns[14].HeaderText = "MVSM del material";
            DGV_PADRON.Columns[15].HeaderText = "Compactación (%)";

            DGV_PADRON.Columns[0].Width = 80;
            DGV_PADRON.Columns[1].Width = 80;
            DGV_PADRON.Columns[2].Width = 150;
            DGV_PADRON.Columns[3].Width = 80;

            //if(DGV_PADRON.Rows.Count != 0 ||  DGV_PADRON.Rows[0].Cells["MVSM"].Value.ToString() != "" || DGV_PADRON.Rows[0].Cells["MVSM"].Value != null)
            //{
            // MVSM.Texts = DGV_PADRON.Rows[0].Cells["MASA_VOL_SEC_MAX_MAT"].Value.ToString();
            //}


        }




        // ** =====  FIRMAS ===== ** //
        private byte[] firmaBytes;  //
        private byte[] firma2Bytes;  //
        private void REVISO_OnSelectedIndexChanged_1(object sender, EventArgs e)
        {
            string nombreSeleccionado = REVISO.SelectedItem?.ToString();
            if (!string.IsNullOrEmpty(nombreSeleccionado))
            {
                CONSULTA_FIRMA(nombreSeleccionado);
            }
        }
        private void CONSULTA_FIRMA(string nombre)
        {
            try
            {
                using (MySqlConnection CONEXION = conexion_rh.USR)
                {
                    CONEXION.Open();

                    string query = "SELECT FIRMA_PNG FROM pdr_personal1 WHERE NOMBRE = @nombre";
                    using (MySqlCommand cmd = new MySqlCommand(query, CONEXION))
                    {
                        cmd.Parameters.AddWithValue("@nombre", nombre);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read() && !reader.IsDBNull(reader.GetOrdinal("FIRMA_PNG")))
                            {
                                firmaBytes = (byte[])reader["FIRMA_PNG"];
                                using (MemoryStream ms = new MemoryStream(firmaBytes))
                                {
                                    recibe_firma.Image = System.Drawing.Image.FromStream(ms);
                                }
                            }
                            else
                            {
                                firmaBytes = null;
                                recibe_firma.Image = null;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Error al obtener la firma: " + ex.Message);
                firmaBytes = null;
                recibe_firma.Image = null;
            }
        }


        private void CargarTecnicosActivos()
        {
            try
            {
                using (MySqlConnection CONEXION = conexion_rh.USR)
                {
                    CONEXION.Open();
                    string query = @"SELECT NOMBRE 
                             FROM pdr_personal1 
                             WHERE ESTATUS = 'ACTIVO' 
                             AND AREA_2 IN ('LC TERRACERIAS Y ASFALTOS', 'SERVICIOS EVENTUALES') ORDER BY NOMBRE ASC";

                    using (MySqlCommand cmd = new MySqlCommand(query, CONEXION))
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        REALIZO.Items.Clear();
                        while (reader.Read())
                        {
                            REALIZO.Items.Add(reader.GetString("NOMBRE"));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Error al cargar técnicos");
            }
        }

        
        private void REALIZO_OnSelectedIndexChanged_1(object sender, EventArgs e)
        {
            string nombreSeleccionado = REALIZO.SelectedItem?.ToString();
            if (!string.IsNullOrEmpty(nombreSeleccionado))
            {
                CONSULTA_FIRMA2(nombreSeleccionado);
            }
        }
        private void CONSULTA_FIRMA2(string nombre)
        {
            try
            {
                using (MySqlConnection CONEXION = conexion_rh.USR)
                {
                    CONEXION.Open();

                    string query = "SELECT FIRMA_PNG FROM pdr_personal1 WHERE NOMBRE = @nombre";
                    using (MySqlCommand cmd = new MySqlCommand(query, CONEXION))
                    {
                        cmd.Parameters.AddWithValue("@nombre", nombre);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read() && !reader.IsDBNull(reader.GetOrdinal("FIRMA_PNG")))
                            {
                                firma2Bytes = (byte[])reader["FIRMA_PNG"];

                                using (MemoryStream ms = new MemoryStream(firma2Bytes))
                                {
                                    recibe_firma2.Image = System.Drawing.Image.FromStream(ms);
                                }
                            }
                            else
                            {
                                firma2Bytes = null;
                                recibe_firma2.Image = null;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("El usuario no cuenta con firma");
                firma2Bytes = null;
                recibe_firma2.Image = null;
            }
        }
        // ** =====  FIRMAS ===== ** //





        //MASA DEL MATERIAL HÚMEDO, g
        public void FORMULA_1(int rowIndex)
        {
            DataGridViewRow row = DGV_PADRON.Rows[rowIndex];

            if (!double.TryParse(row.Cells[6].Value?.ToString(), out double a6) ||
                !double.TryParse(row.Cells[7].Value?.ToString(), out double a7))
            {
                row.Cells[8].Value = "";
                return;
            }

            double valor = a7 - a6;
            row.Cells[8].Value = valor.ToString();
        }

        //MASA DEl MATERIAL SECO, g
        public void FORMULA_2(int rowIndex)
        {
            DataGridViewRow row = DGV_PADRON.Rows[rowIndex];

            if (!double.TryParse(row.Cells[6].Value?.ToString(), out double b6) ||
                !double.TryParse(row.Cells[9].Value?.ToString(), out double b9))
            {
                row.Cells[10].Value = "";
                return;
            }

            double valor = b9 - b6;
            row.Cells[10].Value = valor.ToString();
        }

        //CONTENIDO DE HUMEDAD, %
        public void FORMULA_3(int rowIndex)
        {
            DataGridViewRow row = DGV_PADRON.Rows[rowIndex];

            if (!double.TryParse(row.Cells[8].Value?.ToString(), out double c8) ||
                !double.TryParse(row.Cells[10].Value?.ToString(), out double c10) || c10 == 0)
            {
                row.Cells[11].Value = "";
                return;
            }

            double valor = c8 - c10;
            double valor2 = valor / c10;
            double valor3 = valor2 * 100;

            row.Cells[11].Value = valor3.ToString();
        }


        //MASA VOL. DEL MATERIAL SECO DEL LUGAR, kg/m3
        public void FORMULA_4(int rowIndex)
        {
            DataGridViewRow row = DGV_PADRON.Rows[rowIndex];

            if (!double.TryParse(row.Cells[11].Value?.ToString(), out double d11) ||
                !double.TryParse(row.Cells[12].Value?.ToString(), out double d12) || d12 == 0)
            {
                row.Cells[13].Value = "";
                return;
            }

            double porcentaje = d11 / 100.0;
            double divisor = 1 + porcentaje;

            if (divisor == 0)
                return;

            double resultado = d12 / divisor;
            row.Cells[13].Value = resultado.ToString();
        }

        //COMPACIDAD DE MATERIAL, %
        public void FORMULA_5(int rowIndex)
        {
            DataGridViewRow row = DGV_PADRON.Rows[rowIndex];

            if (!double.TryParse(row.Cells[13].Value?.ToString(), out double e13) ||
                !double.TryParse(row.Cells[14].Value?.ToString(), out double e14) || e14 == 0)
            {
                row.Cells[15].Value = "";
                return;
            }

            double valor = e13 / e14;
            double valor2 = valor * 100;
            row.Cells[15].Value = valor2.ToString();
        }





        private void DGV_PADRON_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            FORMULA_1(e.RowIndex);
            FORMULA_2(e.RowIndex);
            FORMULA_3(e.RowIndex);
            FORMULA_4(e.RowIndex);
            FORMULA_5(e.RowIndex);

            actualiza_sondeos();
            try
            {
                //formulacion();
            }
            catch (Exception ex)
            {
            }

        }








        private void INFO_GRAL()
        {
            MySqlConnection CONEXION = CONEXION_REMOTO_PND.USR;
            CONEXION.Open();

            string checkQuery = "SELECT COUNT(*) FROM densimetro_referencias WHERE CLAVE_OBRA = @clave AND NO_INFORME = @n_inf";
            MySqlCommand checkCommand = new MySqlCommand(checkQuery, CONEXION);
            checkCommand.Parameters.AddWithValue("@clave", CLAVE_OBRA.Texts);
            checkCommand.Parameters.AddWithValue("@n_inf", NO_INFORME.Texts);
            int exists = Convert.ToInt32(checkCommand.ExecuteScalar());

            string clave_muestra = CLAVE_OBRA.Texts.ToUpper() + "-" + NO_INFORME.Texts.ToUpper();

            if (exists == 0) // Si el registro no existe INSERTA
            {
                string insertQuery = "INSERT INTO densimetro_referencias(FECHA_ENSAYE, CLAVE_OBRA, NO_INFORME, OBRA, CLIENTE, ATENCION, FECHA_INFORME, " +
                    "MATERIAL, COMPACTACION_PROYECTO,PROCEDENCIA,HUMEDAD_OPTIMA,USO_MATERIAL,UBICACION,MEDIDOR,MARCA,MODELO,NO_SERIE,USUARIO,FECHA_REGISTRO," +
                    "OBSERVACIONES,TEMPERATURA,HUMEDAD_RELATIVA,ESTANDAR_REFERENCIA,CLAVE_MUESTRA,REVISO,REALIZO,TIPO_CAPA,TIPO_ENSAYE,NO_CALIDAD,MVSM)" +
                "VALUES('" + FECHA_ENSAYE.Text + "','" + CLAVE_OBRA.Texts.ToUpper() + "','" + NO_INFORME.Texts.ToUpper() + "','" + OBRA.Texts.ToUpper() + "'," +
                "'" + CLIENTE.Texts.ToUpper() + "','" + ATENCION.Texts.ToUpper() + "','" + FECHA_INFORME.Text + "','" + MATERIAL.Texts.ToUpper() + "'," +
                "'" + COMPACTACION_PROYECTO.Texts.ToUpper() + "','" + PROCEDENCIA.Texts.ToUpper() + "','" + HUMEDAD_OPTIMA.Texts.ToUpper() + "'," +
                "'" + USO_MATERIAL.Texts.ToUpper() + "','" + UBICACION.Texts.ToUpper() + "','" + MEDIDOR.Texts.ToUpper() + "','" + MARCA.Texts.ToUpper() + "'," +
                "'" + MODELO.Texts.ToUpper() + "','" + NO_SERIE.Texts.ToUpper() + "','" + SESION.usuario + "','" + FECHA_REGISTRO.Text+ "'," +
                "'" + OBSERVACIONES.Texts.ToUpper() + "','" + TEMPERATURA.Texts.ToUpper() + "','" + HUMEDAD_RELATIVA.Texts.ToUpper() + "','ASTM D7830/D7830M - 13','" + clave_muestra+"'," +
                "'"+REVISO.Texts.ToUpper()+"','"+REALIZO.Texts.ToUpper()+"','"+TIPO_CAPA.Texts.ToUpper()+"','"+TIPO_ENSAYE.Texts.ToUpper()+"','"+NO_CALIDAD.Texts.ToUpper()+"'," +
                "'"+MVSM.Texts.ToUpper()+"' ) ";

                MySqlCommand insertCommand = new MySqlCommand(insertQuery, CONEXION);
                insertCommand.ExecuteNonQuery();

                MENSAJE_GENERAL MN = new MENSAJE_GENERAL();
                MN.BOTON.Text = "INFORMACIÓN REGISTRADA";
                MN.ShowDialog();
            }
            else // Si el registro ya existe ACTUALIZA  
            {
                string updateQuery = "UPDATE densimetro_referencias SET FECHA_ENSAYE = '" + FECHA_ENSAYE.Text + "', ATENCION = '" + ATENCION.Texts.ToUpper() + "', FECHA_INFORME = '" + FECHA_INFORME.Text + "', " +
               "MATERIAL = '" + MATERIAL.Texts.ToUpper() + "', COMPACTACION_PROYECTO = '" + COMPACTACION_PROYECTO.Texts.ToUpper() + "',PROCEDENCIA='" + PROCEDENCIA.Texts.ToUpper() + "'," +
               "HUMEDAD_OPTIMA = '" + HUMEDAD_OPTIMA.Texts.ToUpper() + "', USO_MATERIAL = '" + USO_MATERIAL.Texts.ToUpper() + "',UBICACION = '" + UBICACION.Texts.ToUpper() + "'," +
               "MEDIDOR = '" + MEDIDOR.Texts.ToUpper() + "',MARCA = '" + MARCA.Texts.ToUpper() + "', MODELO = '" + MODELO.Texts.ToUpper() + "',NO_SERIE = '" + NO_SERIE.Texts.ToUpper() + "'," +
               "USUARIO = '" + SESION.usuario + "', FECHA_REGISTRO = '" + FECHA_REGISTRO.Text + "',OBSERVACIONES = '" + OBSERVACIONES.Texts.ToUpper() + "',TEMPERATURA = '" + TEMPERATURA.Texts.ToUpper() + "'," +
               "HUMEDAD_RELATIVA = '" + HUMEDAD_RELATIVA.Texts.ToUpper() + "',REVISO = '" + REVISO.Texts + "',REALIZO = '" + REALIZO.Texts + "'," +
               "TIPO_CAPA='" + TIPO_CAPA.Texts.ToUpper() + "',TIPO_ENSAYE='" + TIPO_ENSAYE.Texts.ToUpper() + "',NO_CALIDAD='" + NO_CALIDAD.Texts.ToUpper() + "'," +
               "MVSM = '" + MVSM.Texts.ToUpper() + "' " +
               "WHERE CLAVE_OBRA  = '" + CLAVE_OBRA.Texts.ToUpper() + "' AND NO_INFORME = '" + NO_INFORME.Texts.ToUpper() + "' AND CLAVE_MUESTRA = '" + clave_muestra + "'    ";

                MySqlCommand updateCommand = new MySqlCommand(updateQuery, CONEXION);
                updateCommand.ExecuteNonQuery();

                MENSAJE_GENERAL MN = new MENSAJE_GENERAL();
                MN.BOTON.Text = "INFORMACIÓN ACTUALIZADA";
                MN.ShowDialog();
            }

            CONEXION.Close();
        }


        private void INFO_DGV()
        {
            MySqlConnection CONEXION = CONEXION_REMOTO_PND.USR;
            CONEXION.Open();

            string clave_muestra = CLAVE_OBRA.Texts.ToUpper() + "-" + NO_INFORME.Texts.ToUpper();

            string checkQuery = "SELECT COUNT(*) FROM sondeos_densimetro WHERE CLAVE_OBRA = @clave AND NO_INFORME = @n_inf AND CLAVE_MUESTRA = @clave_muestra";
            MySqlCommand checkCommand = new MySqlCommand(checkQuery, CONEXION);
            checkCommand.Parameters.AddWithValue("@clave", CLAVE_OBRA.Texts);
            checkCommand.Parameters.AddWithValue("@n_inf", NO_INFORME.Texts);
            checkCommand.Parameters.AddWithValue("@clave_muestra", clave_muestra);
            int exists = Convert.ToInt32(checkCommand.ExecuteScalar());

            if (exists == 0) // Si el registro no existe, INSERTA
            {
                string insertQuery = "INSERT INTO sondeos_densimetro(CLAVE_OBRA,NO_INFORME,NUMERO_SONDEO,LOCALIZACION_SONDEO,NUMERO_CAPA,ESPESOR_CAPA_CM,NUMERO_TARA,MASA_TARA," +
                    "MASA_TARA_MAT_HUM,MASA_MAT_HUM,MASA_TARA_MAT_SECO,MASA_MAT_SECO,CONTEN_AGUA,MASA_VOL_MAT_HUMEDO,MASA_VOL_SEC_LUG,MASA_VOL_SEC_MAX_MAT,COMPACTACION,USUARIO,CLAVE_MUESTRA)" +
                    " VALUES ('" + CLAVE_OBRA.Texts.ToUpper() + "','" + NO_INFORME.Texts.ToUpper() + "',?N_SONDEO,?LOC_SOND,?N_CAPA,?ESP_CAPA_CM,?N_TARA,?MA_TARA,?MA_TA_MA_HUM,?MA_MAT_HU," +
                    "?MA_TA_MA_SE,?MA_MA_SEC,?CON_AGU,?MA_VOL_MA_HU,?MA_VOL_SE_LU,?MA_VO_SE_MAX_MAT,?POR_COMP,'"+SESION.usuario+"','" + clave_muestra + "')  ";

                MySqlCommand insertCommand = new MySqlCommand(insertQuery, CONEXION);
                foreach (DataGridViewRow row in DGV_PADRON.Rows)
                {
                    insertCommand.Parameters.Clear();
                    insertCommand.Parameters.AddWithValue("?N_SONDEO", Convert.ToString(row.Cells[1].Value).ToUpper());
                    insertCommand.Parameters.AddWithValue("?LOC_SOND", Convert.ToString(row.Cells[2].Value).ToUpper());
                    insertCommand.Parameters.AddWithValue("?N_CAPA", Convert.ToString(row.Cells[3].Value).ToUpper());
                    insertCommand.Parameters.AddWithValue("?ESP_CAPA_CM", Convert.ToString(row.Cells[4].Value).ToUpper());
                    insertCommand.Parameters.AddWithValue("?N_TARA", Convert.ToString(row.Cells[5].Value).ToUpper());
                    insertCommand.Parameters.AddWithValue("?MA_TARA", Convert.ToString(row.Cells[6].Value).ToUpper());
                    insertCommand.Parameters.AddWithValue("?MA_TA_MA_HUM", Convert.ToString(row.Cells[7].Value).ToUpper());
                    insertCommand.Parameters.AddWithValue("?MA_MAT_HU", Convert.ToString(row.Cells[8].Value).ToUpper());
                    insertCommand.Parameters.AddWithValue("?MA_TA_MA_SE", Convert.ToString(row.Cells[9].Value).ToUpper());
                    insertCommand.Parameters.AddWithValue("?MA_MA_SEC", Convert.ToString(row.Cells[10].Value).ToUpper());
                    insertCommand.Parameters.AddWithValue("?CON_AGU", Convert.ToString(row.Cells[11].Value).ToUpper());
                    insertCommand.Parameters.AddWithValue("?MA_VOL_MA_HU", Convert.ToString(row.Cells[12].Value).ToUpper());
                    insertCommand.Parameters.AddWithValue("?MA_VOL_SE_LU", Convert.ToString(row.Cells[13].Value).ToUpper());
                    insertCommand.Parameters.AddWithValue("?MA_VO_SE_MAX_MAT", Convert.ToString(row.Cells[14].Value).ToUpper());
                    insertCommand.Parameters.AddWithValue("?POR_COMP", Convert.ToString(row.Cells[15].Value).ToUpper());
                    insertCommand.ExecuteNonQuery();
                }

            }
            else // Si el registro ya existe, ACTUALIZA
            {
                foreach (DataGridViewRow row in DGV_PADRON.Rows)
                {
                    string updateQuery = "UPDATE sondeos_densimetro SET NUMERO_SONDEO = ?N_SOND, LOCALIZACION_SONDEO = ?LOC_SOND, NUMERO_CAPA=?N_CAPA," +
                        " ESPESOR_CAPA_CM=?ESP_CAPA_CM,NUMERO_TARA=?N_TARA, MASA_TARA=?M_TARA, MASA_TARA_MAT_HUM=?M_TARA_M_HUM," +
                        "MASA_MAT_HUM=?M_MAT_HUM, MASA_TARA_MAT_SECO=?M_TARA_M_SECO, MASA_MAT_SECO=?MASA_MAT_SECO,CONTEN_AGUA=?CONT_AGUA," +
                        "MASA_VOL_MAT_HUMEDO=?MASA_V_MAT_HUM,MASA_VOL_SEC_LUG=?MAS_V_SEC_LUG,MASA_VOL_SEC_MAX_MAT=?MVSM,COMPACTACION=?COMPACT,USUARIO=?USU WHERE ID_SEGUIMIENTO= ?ID AND CLAVE_OBRA = ?CLAVE AND NO_INFORME = ?N_INF AND CLAVE_MUESTRA = ?CLAV_MUES    ";

                    MySqlCommand updateCommand = new MySqlCommand(updateQuery, CONEXION);
                    updateCommand.Parameters.AddWithValue("?ID", Convert.ToString(row.Cells[0].Value)); // clave para la fila
                    updateCommand.Parameters.AddWithValue("?N_SOND", Convert.ToString(row.Cells[1].Value).ToUpper());
                    updateCommand.Parameters.AddWithValue("?LOC_SOND", Convert.ToString(row.Cells[2].Value).ToUpper());
                    updateCommand.Parameters.AddWithValue("?N_CAPA", Convert.ToString(row.Cells[3].Value).ToUpper());
                    updateCommand.Parameters.AddWithValue("?ESP_CAPA_CM", Convert.ToString(row.Cells[4].Value).ToUpper());
                    updateCommand.Parameters.AddWithValue("?N_TARA", Convert.ToString(row.Cells[5].Value).ToUpper());
                    updateCommand.Parameters.AddWithValue("?M_TARA", Convert.ToString(row.Cells[6].Value).ToUpper());
                    updateCommand.Parameters.AddWithValue("?M_TARA_M_HUM", Convert.ToString(row.Cells[7].Value).ToUpper());
                    updateCommand.Parameters.AddWithValue("?M_MAT_HUM", Convert.ToString(row.Cells[8].Value).ToUpper());
                    updateCommand.Parameters.AddWithValue("?M_TARA_M_SECO", Convert.ToString(row.Cells[9].Value).ToUpper());
                    updateCommand.Parameters.AddWithValue("?MASA_MAT_SECO", Convert.ToString(row.Cells[10].Value).ToUpper());
                    updateCommand.Parameters.AddWithValue("?CONT_AGUA", Convert.ToString(row.Cells[11].Value).ToUpper());
                    updateCommand.Parameters.AddWithValue("?MASA_V_MAT_HUM", Convert.ToString(row.Cells[12].Value).ToUpper());
                    updateCommand.Parameters.AddWithValue("?MAS_V_SEC_LUG", Convert.ToString(row.Cells[13].Value).ToUpper());
                    updateCommand.Parameters.AddWithValue("?MVSM", Convert.ToString(row.Cells[14].Value).ToUpper());
                    updateCommand.Parameters.AddWithValue("?COMPACT", Convert.ToString(row.Cells[15].Value).ToUpper());
                    updateCommand.Parameters.AddWithValue("?USU", SESION.usuario);
                    updateCommand.Parameters.AddWithValue("?CLAVE", CLAVE_OBRA.Texts.ToUpper());
                    updateCommand.Parameters.AddWithValue("?N_INF", NO_INFORME.Texts.ToUpper());
                    updateCommand.Parameters.AddWithValue("?CLAV_MUES", clave_muestra);
                    updateCommand.ExecuteNonQuery();
                }

            }

            CONEXION.Close();
        }




        private void altoButton1_Click(object sender, EventArgs e)
        {
            INFO_GRAL();
            INFO_DGV();
        }












        double masa_seca_sitio = 0; double mvsm = 0; double compactacion = 0;

        public void formulacion()
        {

            masa_seca_sitio = 0;

           foreach (DataGridViewRow row in DGV_PADRON.Rows)
            {
                if (row.Cells["MASA_VOL_SEC_LUG"].Value.ToString() != "" && MVSM.Texts != "")
                {
                    masa_seca_sitio = Convert.ToDouble(row.Cells["MASA_VOL_SEC_LUG"].Value.ToString());
                    mvsm = Convert.ToDouble(MVSM.Texts);
                    compactacion = (masa_seca_sitio / mvsm) * 100;
                    row.Cells["COMPACTACION"].Value = Math.Round(compactacion, 2).ToString();
                }
            }

        }


     
        private void labelTelefono_MouseLeave(object sender, EventArgs e)
        {
            var button = sender as Label;
            button.Font = new System.Drawing.Font("Poppins", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        }

        private void labelTelefono_MouseMove(object sender, EventArgs e)
        {
            var button = sender as Label;
            button.Font = new System.Drawing.Font("Poppins", 11.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        }
    

        private void label32_Click(object sender, EventArgs e)
        {
            total = false;
            
            DGV_PADRON.DataSource = CONEXION_REMOTO_PND.CONSULTA_GENERAL("SELECT ID_SEGUIMIENTO, NUMERO_SONDEO , LOCALIZACION_SONDEO, NUMERO_CAPA, ESPESOR_CAPA_CM,  MASA_VOL_MAT_HUMEDO, MASA_VOL_SEC_LUG, COMPACTACION       FROM sondeos_densimetro WHERE CLAVE_MUESTRA = '" + clave_mues + "'  ");

            DGV_PADRON.Columns[0].HeaderText = "Id";
            DGV_PADRON.Columns[1].HeaderText = "No.";
            DGV_PADRON.Columns[2].HeaderText = "Localización";
            DGV_PADRON.Columns[3].HeaderText = "No. de capa";
            DGV_PADRON.Columns[4].HeaderText = "Espesor de capa (cm)"; 
            DGV_PADRON.Columns[5].HeaderText = "Masa Vol de Mat. Hum";
            DGV_PADRON.Columns[6].HeaderText = "Masa Vol. Seca del lugar";
            DGV_PADRON.Columns[7].HeaderText = "Compactación (%)";

            DGV_PADRON.Columns[0].Width = 80;
            DGV_PADRON.Columns[1].Width = 80;
            DGV_PADRON.Columns[2].Width = 150;
            DGV_PADRON.Columns[3].Width = 80;
        }

        bool total = true;

        private void label20_Click(object sender, EventArgs e)
        {
            total = true;

            DGV_PADRON.DataSource = CONEXION_REMOTO_PND.CONSULTA_GENERAL("SELECT ID_SEGUIMIENTO, NUMERO_SONDEO , LOCALIZACION_SONDEO, NUMERO_CAPA, ESPESOR_CAPA_CM, NUMERO_TARA, MASA_TARA, MASA_TARA_MAT_HUM, MASA_MAT_HUM, MASA_TARA_MAT_SECO, MASA_MAT_SECO, 	CONTEN_AGUA, MASA_VOL_MAT_HUMEDO, MASA_VOL_SEC_LUG, MASA_VOL_SEC_MAX_MAT, COMPACTACION       FROM sondeos_densimetro WHERE CLAVE_MUESTRA = '" + clave_mues + "'  ");

            DGV_PADRON.Columns[0].HeaderText = "Id";
            DGV_PADRON.Columns[1].HeaderText = "No.";
            DGV_PADRON.Columns[2].HeaderText = "Localización";
            DGV_PADRON.Columns[3].HeaderText = "No. de capa";
            DGV_PADRON.Columns[4].HeaderText = "Espesor de capa (cm)";
            DGV_PADRON.Columns[5].HeaderText = "No. de tara";
            DGV_PADRON.Columns[6].HeaderText = "Masa de tara";
            DGV_PADRON.Columns[7].HeaderText = "Masa de tara + Mat. Hum";
            DGV_PADRON.Columns[8].HeaderText = "Masa de mat. Hum";
            DGV_PADRON.Columns[9].HeaderText = "Masa de tara + Mat. Seco";
            DGV_PADRON.Columns[10].HeaderText = "Masa de Mat. Seco";
            DGV_PADRON.Columns[11].HeaderText = "Contenido de agua";
            DGV_PADRON.Columns[12].HeaderText = "Masa Vol de Mat. Hum";
            DGV_PADRON.Columns[13].HeaderText = "Masa Vol. Seca del lugar";
            DGV_PADRON.Columns[14].HeaderText = "MVSM del material";
            DGV_PADRON.Columns[15].HeaderText = "Compactación (%)";

            DGV_PADRON.Columns[0].Width = 80;
            DGV_PADRON.Columns[1].Width = 80;
            DGV_PADRON.Columns[2].Width = 150;
            DGV_PADRON.Columns[3].Width = 80;
        }

        private void DGV_PADRON_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {              
                DialogResult DL = System.Windows.Forms.MessageBox.Show("¿Deseas eliminar el sondeo con id:  " + DGV_PADRON.CurrentRow.Cells["ID_SEGUIMIENTO"].Value.ToString() + " ?", "Notificación de Operación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (DL == DialogResult.Yes)
                {
                    int filaIndex = DGV_PADRON.SelectedCells[0].RowIndex;
                    DataGridViewRow fila = DGV_PADRON.Rows[filaIndex];

                    CONEXION_REMOTO_PND.USR.Open();//Se abre la conexión para evitar un error común
                    String Query = "DELETE FROM sondeos_densimetro WHERE ID_SEGUIMIENTO = '" + DGV_PADRON.CurrentRow.Cells["ID_SEGUIMIENTO"].Value.ToString() + "';";
                    MySqlCommand comando = new MySqlCommand(Query, CONEXION_REMOTO_PND.USR);//Se interpreta el comando del query
                    comando.ExecuteNonQuery();//Se ejecuta el comando del query
                    CONEXION_REMOTO_PND.USR.Close();//Se cierra la conexión
             
                    // Elimina visualmente
                    DGV_PADRON.Rows.RemoveAt(filaIndex);

                    MENSAJE_GENERAL MN = new MENSAJE_GENERAL();
                    MN.BOTON.Text = "Eliminación Realizada";
                    MN.ShowDialog();
                }
                else
                {

                }
            }
        }






     










      
        public void generar_informe()
        {
            informe_encabezado(); 
            informe_sin_encabezado();
        }





        private void actualiza_sondeos()
        {
            CONEXION_REMOTO_PND.USR.Open();//Se abre la conexión para evitar un error común
            String Query = "UPDATE sondeos_densimetro SET NUMERO_SONDEO= '" + DGV_PADRON.CurrentRow.Cells["NUMERO_SONDEO"].Value.ToString() + "', LOCALIZACION_SONDEO= '" + DGV_PADRON.CurrentRow.Cells["LOCALIZACION_SONDEO"].Value.ToString() + "', NUMERO_CAPA= '" + DGV_PADRON.CurrentRow.Cells["NUMERO_CAPA"].Value.ToString() + "',  ESPESOR_CAPA_CM= '" + DGV_PADRON.CurrentRow.Cells["ESPESOR_CAPA_CM"].Value.ToString() + "', NUMERO_TARA= '" + DGV_PADRON.CurrentRow.Cells["NUMERO_TARA"].Value.ToString() + "', MASA_TARA= '" + DGV_PADRON.CurrentRow.Cells["MASA_TARA"].Value.ToString() + "',  MASA_TARA_MAT_HUM= '" + DGV_PADRON.CurrentRow.Cells["MASA_TARA_MAT_HUM"].Value.ToString() + "',  MASA_MAT_HUM= '" + DGV_PADRON.CurrentRow.Cells["MASA_MAT_HUM"].Value.ToString() + "' , MASA_TARA_MAT_SECO= '" + DGV_PADRON.CurrentRow.Cells["MASA_TARA_MAT_SECO"].Value.ToString() + "',  MASA_MAT_SECO= '" + DGV_PADRON.CurrentRow.Cells["MASA_MAT_SECO"].Value.ToString() + "',  CONTEN_AGUA= '" + DGV_PADRON.CurrentRow.Cells["CONTEN_AGUA"].Value.ToString() + "',   MASA_VOL_MAT_HUMEDO= '" + DGV_PADRON.CurrentRow.Cells["MASA_VOL_MAT_HUMEDO"].Value.ToString() + "',  MASA_VOL_SEC_LUG= '" + DGV_PADRON.CurrentRow.Cells["MASA_VOL_SEC_LUG"].Value.ToString() + "', MASA_VOL_SEC_MAX_MAT= '" + DGV_PADRON.CurrentRow.Cells["MASA_VOL_SEC_MAX_MAT"].Value.ToString() + "', COMPACTACION = '" + DGV_PADRON.CurrentRow.Cells["COMPACTACION"].Value.ToString() + "'   WHERE ID_SEGUIMIENTO  = '" + DGV_PADRON.CurrentRow.Cells["ID_SEGUIMIENTO"].Value.ToString() + "';";
            MySqlCommand comando = new MySqlCommand(Query, CONEXION_REMOTO_PND.USR);//Se interpreta el comando del query
            comando.ExecuteNonQuery();//Se ejecuta el comando del query
            CONEXION_REMOTO_PND.USR.Close();//Se cierra la conexión       
        }

        private void informe_encabezado()
        {

            MySqlConnection CONEXIONC = conexion_calidad.USR;
            MySqlCommand comandoC = new MySqlCommand("SELECT DOCUMENTO FROM  formatos WHERE CODIGO = 'DEN93'  ORDER BY ID_SEGUIMIENTO ASC", CONEXIONC);
            CONEXIONC.Open();
            MySqlDataReader consultaC = comandoC.ExecuteReader();

            string carpetaC = @"C:\TEMP ERP";       
            if (Directory.Exists(carpetaC))
            {

            }
            else
            {
                Directory.CreateDirectory(carpetaC);

            }
            while (consultaC.Read())
            {

                byte[] archivoBytes = (byte[])consultaC["DOCUMENTO"];
                System.IO.MemoryStream pdfStream = new System.IO.MemoryStream(archivoBytes);


                File.WriteAllBytes(@"C:\TEMP ERP\DEN93.xlsx", archivoBytes);
                // System.Diagnostics.Process.Start(@"C:\TEMP ERP\04-TER-CALMTRELL.xlsx");

            }
            CONEXIONC.Close();

            string carpetaDocumentos = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                    string rutaXlsx = Path.Combine(carpetaDocumentos, "DEN93.xlsx");
            string rutaPdf = Path.Combine(carpetaDocumentos, "DEN93.pdf");


            string ruta = @"C:\TEMP ERP\DEN93.xlsx";
            SLDocument reporte = new SLDocument(ruta);


            reporte.SetCellValue("L1", NO_INFORME.Texts);
                reporte.SetCellValue("C2", FECHA_INFORME.Text);
                reporte.SetCellValue("K2", CLAVE_OBRA.Texts);
                reporte.SetCellValue("B3", CLIENTE.Texts);
                reporte.SetCellValue("B4",OBRA.Texts);
                reporte.SetCellValue("C5", ATENCION.Texts);
                reporte.SetCellValue("K5", FECHA_REGISTRO.Text);

                reporte.SetCellValue("C8", TIPO_ENSAYE.Texts);
                reporte.SetCellValue("K8", COMPACTACION_PROYECTO.Texts);
                reporte.SetCellValue("C9", TIPO_CAPA.Texts);
                reporte.SetCellValue("K9", COMPACTACION_PROYECTO.Texts);
                reporte.SetCellValue("C10", PROCEDENCIA.Texts);
                reporte.SetCellValue("K10",HUMEDAD_OPTIMA.Texts);
                reporte.SetCellValue("K11", NO_CALIDAD.Texts);


                reporte.SetCellValue("C13", MEDIDOR.Texts);
                reporte.SetCellValue("G13", MODELO.Texts);
                reporte.SetCellValue("K13", NO_SERIE.Texts);
                int fila = 17; // La fila inicial en Excel es 16


                foreach (DataGridViewRow row in DGV_PADRON.Rows)
                {
                      reporte.SetCellValue("A" + fila.ToString(),int.Parse( row.Cells["NUMERO_SONDEO"].Value?.ToString()));
                    reporte.SetCellValue("B" + fila.ToString(), row.Cells["LOCALIZACION_SONDEO"].Value?.ToString());
                    reporte.SetCellValue("G" + fila.ToString(), row.Cells["NUMERO_CAPA"].Value?.ToString());
                    reporte.SetCellValue("H" + fila.ToString(),double.Parse( row.Cells["ESPESOR_CAPA_CM"].Value?.ToString()));
                    reporte.SetCellValue("I" + fila.ToString(),double.Parse( row.Cells["MASA_VOL_MAT_HUMEDO"].Value?.ToString()));
                    reporte.SetCellValue("J" + fila.ToString(),double.Parse( row.Cells["MASA_VOL_SEC_LUG"].Value?.ToString()));
                    reporte.SetCellValue("L" + fila.ToString(), double.Parse( row.Cells["COMPACTACION"].Value?.ToString()));


                    fila++;

                }
              

                reporte.SetCellValue("C28", OBSERVACIONES.Texts);
                    







                // Guardar el archivo Excel modificado
                reporte.SaveAs(rutaXlsx);





            string rutaExcel = rutaXlsx;  // C:\Users\...\Documents\DEN93.xlsx
            string rutaPDF = rutaPdf;     // C:\Users\...\Documents\DEN93.pdf

            Excel.Application excelApp = new Excel.Application();
            excelApp.Visible = false;

            Excel.Workbook workbook = excelApp.Workbooks.Open(rutaExcel);
            Excel.Worksheet worksheet = workbook.Sheets[1];

            // Configurar hoja a tamaño carta y ajustar al ancho
            worksheet.PageSetup.Orientation = Excel.XlPageOrientation.xlPortrait;

            try
            {
                worksheet.PageSetup.PaperSize = Excel.XlPaperSize.xlPaperLetter;
            }
            catch
            {
                // Si no se puede asignar, usa el tamaño por defecto
            }

            worksheet.PageSetup.Zoom = false;
            worksheet.PageSetup.FitToPagesWide = 1;
            worksheet.PageSetup.FitToPagesTall = false;

            // Exportar a PDF
            workbook.ExportAsFixedFormat(
                Excel.XlFixedFormatType.xlTypePDF,
                rutaPDF,
                Excel.XlFixedFormatQuality.xlQualityStandard,
                IncludeDocProperties: true,
                IgnorePrintAreas: false
            );

            // Cerrar Excel
            workbook.Close(false);
            excelApp.Quit();

            // Liberar memoria COM
            System.Runtime.InteropServices.Marshal.ReleaseComObject(worksheet);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(workbook);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);

            System.Windows.Forms.MessageBox.Show("Archivo PDF generado exitosamente en: " + rutaPDF, "Exportación Completa", MessageBoxButtons.OK, MessageBoxIcon.Information);




        }

        private void informe_sin_encabezado()
        {


            MySqlConnection CONEXIONC = conexion_calidad.USR;

            MySqlCommand comandoC = new MySqlCommand("SELECT DOCUMENTO FROM  formatos WHERE CODIGO = 'DEN93_SEN'  ORDER BY ID_SEGUIMIENTO ASC", CONEXIONC);

            CONEXIONC.Open();
            MySqlDataReader consultaC = comandoC.ExecuteReader();

            string carpetaC = @"C:\TEMP ERP";

            if (Directory.Exists(carpetaC))
            {

            }
            else
            {
                Directory.CreateDirectory(carpetaC);

            }
            while (consultaC.Read())
            {

                byte[] archivoBytes = (byte[])consultaC["DOCUMENTO"];
                System.IO.MemoryStream pdfStream = new System.IO.MemoryStream(archivoBytes);


                File.WriteAllBytes(@"C:\TEMP ERP\DEN93_SEN.xlsx", archivoBytes);
                // System.Diagnostics.Process.Start(@"C:\TEMP ERP\04-TER-CALMTRELL.xlsx");

            }
            CONEXIONC.Close();

            string carpetaDocumentos = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string rutaXlsx = Path.Combine(carpetaDocumentos, "DEN93_SEN.xlsx");
            string rutaPdf = Path.Combine(carpetaDocumentos, "DEN93_SEN.pdf");


            string ruta = @"C:\TEMP ERP\DEN93_SEN.xlsx";
            SLDocument reporte = new SLDocument(ruta);


            reporte.SetCellValue("B1", NO_INFORME.Texts);
            reporte.SetCellValue("C2", FECHA_INFORME.Text);
            reporte.SetCellValue("K2", CLAVE_OBRA.Texts);
            reporte.SetCellValue("B3", CLIENTE.Texts);
            reporte.SetCellValue("B4", OBRA.Texts);
            reporte.SetCellValue("C5", ATENCION.Texts);
            reporte.SetCellValue("K5", FECHA_REGISTRO.Text);

            reporte.SetCellValue("C8", TIPO_ENSAYE.Texts);
            reporte.SetCellValue("K8", COMPACTACION_PROYECTO.Texts);
            reporte.SetCellValue("C9", "TIPO DE CAPA");
            reporte.SetCellValue("K9", COMPACTACION_PROYECTO.Texts);
            reporte.SetCellValue("C10", PROCEDENCIA.Texts);
            reporte.SetCellValue("K10", HUMEDAD_OPTIMA.Texts);
            reporte.SetCellValue("K11", NO_CALIDAD.Texts);


            reporte.SetCellValue("C13", MEDIDOR.Texts);
            reporte.SetCellValue("G13", MODELO.Texts);
            reporte.SetCellValue("K13", NO_SERIE.Texts);
            int fila = 17; // La fila inicial en Excel es 16


            foreach (DataGridViewRow row in DGV_PADRON.Rows)
            {
                reporte.SetCellValue("A" + fila.ToString(), int.Parse(row.Cells["NUMERO_SONDEO"].Value?.ToString()));
                reporte.SetCellValue("B" + fila.ToString(), row.Cells["LOCALIZACION_SONDEO"].Value?.ToString());
                reporte.SetCellValue("G" + fila.ToString(), row.Cells["NUMERO_CAPA"].Value?.ToString());
                reporte.SetCellValue("H" + fila.ToString(), double.Parse(row.Cells["ESPESOR_CAPA_CM"].Value?.ToString()));
                reporte.SetCellValue("I" + fila.ToString(), double.Parse(row.Cells["MASA_VOL_MAT_HUMEDO"].Value?.ToString()));
                reporte.SetCellValue("J" + fila.ToString(), double.Parse(row.Cells["MASA_VOL_SEC_LUG"].Value?.ToString()));
                reporte.SetCellValue("L" + fila.ToString(), double.Parse(row.Cells["COMPACTACION"].Value?.ToString()));

                fila++;

            }


            reporte.SetCellValue("C28", OBSERVACIONES.Texts);








            // Guardar el archivo Excel modificado
            reporte.SaveAs(rutaXlsx);




            string rutaExcel = rutaXlsx;  // C:\Users\...\Documents\DEN93.xlsx
            string rutaPDF = rutaPdf;     // C:\Users\...\Documents\DEN93.pdf

            Excel.Application excelApp = new Excel.Application();
            excelApp.Visible = false;

            Excel.Workbook workbook = excelApp.Workbooks.Open(rutaExcel);
            Excel.Worksheet worksheet = workbook.Sheets[1];

            // Configurar hoja a tamaño carta y ajustar al ancho
            worksheet.PageSetup.Orientation = Excel.XlPageOrientation.xlPortrait;

            try
            {
                worksheet.PageSetup.PaperSize = Excel.XlPaperSize.xlPaperLetter;
            }
            catch
            {
                // Si no se puede asignar, usa el tamaño por defecto
            }

            worksheet.PageSetup.Zoom = false;
            worksheet.PageSetup.FitToPagesWide = 1;
            worksheet.PageSetup.FitToPagesTall = false;

            // Exportar a PDF
            workbook.ExportAsFixedFormat(
                Excel.XlFixedFormatType.xlTypePDF,
                rutaPDF,
                Excel.XlFixedFormatQuality.xlQualityStandard,
                IncludeDocProperties: true,
                IgnorePrintAreas: false
            );

            // Cerrar Excel
            workbook.Close(false);
            excelApp.Quit();

            // Liberar memoria COM
            System.Runtime.InteropServices.Marshal.ReleaseComObject(worksheet);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(workbook);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);

            System.Windows.Forms.MessageBox.Show("Archivo PDF generado exitosamente en: " + rutaPDF, "Exportación Completa", MessageBoxButtons.OK, MessageBoxIcon.Information);




        }
     

        private void MVSM__TextChanged(object sender, EventArgs e)
        {

            try
            {


                formulacion();
            }
            catch (Exception ex)
            {

            }
    }

        private void actualiza()
        {

            



        }

     










       









        // Clase para dibujar firma con transparencia y nombre abajo       
        public class FirmaConNombreEvent : IPdfPCellEvent
        {
            private Image img;
            private string nombre;
            private Font font;

            public FirmaConNombreEvent(Image imagen, string nombrePersona)
            {
                img = imagen;
                nombre = nombrePersona;
                font = FontFactory.GetFont(FontFactory.HELVETICA, 6.5f, BaseColor.BLACK);
            }

            public void CellLayout(PdfPCell cell, Rectangle position, PdfContentByte[] canvases)
            {
                PdfContentByte canvas = canvases[PdfPTable.BACKGROUNDCANVAS];

                // -----------------------------
                // Dibujar firma centrada con transparencia
                // -----------------------------
                float imgX = position.Left + (position.Width - img.ScaledWidth) / 2;
                float imgY = position.Bottom + (position.Height - img.ScaledHeight) / 2;
                img.SetAbsolutePosition(imgX, imgY);

                PdfGState gs = new PdfGState();
                gs.FillOpacity = 1f; // 0 = invisible, 1 = opaco
                canvas.SaveState();
                canvas.SetGState(gs);
                canvas.AddImage(img);
                canvas.RestoreState();

                // -----------------------------
                // Dibujar nombre centrado en la parte inferior de la celda
                // -----------------------------
                ColumnText.ShowTextAligned(
                    canvas,
                    Element.ALIGN_CENTER,
                    new Phrase(nombre, font),
                    position.GetLeft(position.Width / 2), // centro horizontal
                    position.Bottom + 2f,
                    0
                );
            }
        }


        public static bool encabeza_rt = false;
        public static bool sinencabeza_rt = false;
        public class PAGE_RT : PdfPageEventHelper
        {
            PdfTemplate totalPagesTemplate;
            BaseFont baseFont;

            //PARA LAS FIRMAS
            private readonly byte[] firmaBytes;
            private readonly byte[] firmaBytes2;

            // Constructor recibe las dos firmas
            public PAGE_RT(byte[] firmaBytes, byte[] firmaBytes2)
            {
                this.firmaBytes = firmaBytes;
                this.firmaBytes2 = firmaBytes2;
            }
            public override void OnOpenDocument(PdfWriter writer, iTextSharp.text.Document document)
            {
                baseFont = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, false);
                totalPagesTemplate = writer.DirectContent.CreateTemplate(50, 50);
            }


            public override void OnEndPage(PdfWriter writer, iTextSharp.text.Document doc) //DATOS
            {
                if (encabeza_rt == true)
                {
                    BaseColor negro = new BaseColor(10, 10, 10);
                    BaseColor blanco = new BaseColor(255, 255, 255);
                    BaseColor gris_oscuro = new BaseColor(191, 191, 191);
                    BaseColor gris_claro = new BaseColor(217, 217, 217);
                    BaseColor gris_oscuro_border = new BaseColor(176, 176, 176);

                    iTextSharp.text.Font title = FontFactory.GetFont("Arial", 11, 1, negro);
                    iTextSharp.text.Font subtitle = FontFactory.GetFont("Arial", 8, 0, negro);
                    iTextSharp.text.Font letra_negra_regular_5 = FontFactory.GetFont("Arial", 5, 0, negro);
                    iTextSharp.text.Font letra_negra_bold_7 = FontFactory.GetFont("Arial", 7f, 1, negro);
                    iTextSharp.text.Font letra_negra_regular_7 = FontFactory.GetFont("Arial", 7f, 0, negro);


                    iTextSharp.text.Image encabezado = iTextSharp.text.Image.GetInstance(ERP_COMPLETO.Properties.Resources.ENCABEZADO_HORIZONTAL_LAB, System.Drawing.Imaging.ImageFormat.Jpeg);
                    iTextSharp.text.Image pie_pag = iTextSharp.text.Image.GetInstance(ERP_COMPLETO.Properties.Resources.PIE_DE_PÁGINA_V_LAB, System.Drawing.Imaging.ImageFormat.Jpeg);

                    PdfContentByte cb2 = writer.DirectContent;
                    encabezado = iTextSharp.text.Image.GetInstance(ERP_COMPLETO.Properties.Resources.ENCABEZADO_HORIZONTAL_LAB, System.Drawing.Imaging.ImageFormat.Jpeg);
                    encabezado.ScaleAbsolute(570f, 73f);
                    encabezado.SetAbsolutePosition(21, 713);  // + izq.  - der   //21, 690
                    cb2.AddImage(encabezado);


                    PdfContentByte canvas = writer.DirectContent;
                    Paragraph paragraph1 = new Paragraph("DETERMINACIÓN DEL PORCENTAJE DE COMPACTACIÓN\r\nEN CAMPO MEDIANTE DENSÍMETRO ELECTROMAGNÉTICO", title);
                    Paragraph paragraph2 = new Paragraph("EE-RT-14", subtitle);
                    AddParagraphAtPosition(paragraph1, canvas, 12, 758);    // X  -  Y
                    AddParagraphAtPosition(paragraph2, canvas, 12, 737);   // X  -  Y
                
                   
                // OBSERVACIONES: 
                try
                {
                    PdfPTable table2 = new PdfPTable(14);
                    table2.TotalWidth = 560;
                    table2.LockedWidth = true;
                    table2.SpacingBefore = 0;
                    table2.SpacingAfter = 0;

                    PdfPCell cell2 = new PdfPCell(new Phrase("OBSERVACIONES:", letra_negra_bold_7));
                    cell2.BackgroundColor = gris_oscuro;
                    cell2.BorderColor = gris_oscuro_border;
                    cell2.BorderWidth = 0.7f;
                    cell2.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell2.VerticalAlignment = Element.ALIGN_MIDDLE;
                    cell2.PaddingTop = 1f;
                    cell2.PaddingBottom = 4f;
                    cell2.PaddingLeft = 1f;
                    cell2.Colspan = 3;
                    cell2.FixedHeight = 35f;
                    table2.AddCell(cell2);


                    string TXT_OBS = PAN_PEE.equi.dn.OBSERVACIONES.Texts.ToUpper();
                    float tamañoFuente = 7f;
                    float tamañoMinimo = 5.9f;
                    float anchoCelda = (560f / 18f) * 16f - 4f;  //560->TotalWidth = 560;  // 18f->PdfPTable table2 = new PdfPTable(14);  //   16f->cell2.Colspan = 8;  // 4f ->padding interno de la celda

                    BaseFont bf = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, false);
                    while (tamañoFuente >= tamañoMinimo)
                    {
                        float anchoTexto = bf.GetWidthPoint(TXT_OBS, tamañoFuente);

                        if (anchoTexto <= anchoCelda)
                            break;

                        tamañoFuente -= 0.2f;
                    }
                    Font letraDinamica = new Font(bf, tamañoFuente, 0, negro);

                    cell2 = new PdfPCell(new Phrase(TXT_OBS, letraDinamica));
                    cell2.BackgroundColor = blanco;
                    cell2.BorderColor = gris_oscuro_border;
                    cell2.BorderWidth = 0.7f;
                    cell2.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell2.VerticalAlignment = Element.ALIGN_MIDDLE;
                    cell2.PaddingTop = 1f;
                    cell2.PaddingBottom = 4f;
                    cell2.PaddingLeft = 1f;
                    cell2.Colspan = 11;
                    table2.AddCell(cell2);
                    
                    table2.WriteSelectedRows(0, -1, doc.LeftMargin - 10, writer.PageSize.GetBottom(doc.BottomMargin) + 125, writer.DirectContent);
                }
                catch { }
                // TEMPERATURA °C
                try
                {
                    PdfPTable table2 = new PdfPTable(14);
                    table2.TotalWidth = 560;
                    table2.LockedWidth = true;
                    table2.SpacingBefore = 0;
                    table2.SpacingAfter = 0;

                    PdfPCell cell2 = new PdfPCell(new Phrase("TEMPERATURA °C:", letra_negra_regular_7));
                    cell2.BackgroundColor = gris_claro;
                    cell2.BorderColor = gris_oscuro_border;
                    cell2.BorderWidth = 0.7f;
                    cell2.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell2.VerticalAlignment = Element.ALIGN_MIDDLE;
                    cell2.PaddingTop = 1f;
                    cell2.PaddingBottom = 4f;
                    cell2.PaddingLeft = 1f;
                    cell2.Colspan = 3;
                    cell2.FixedHeight = 14f;
                    table2.AddCell(cell2);

                    cell2 = new PdfPCell(new Phrase(PAN_PEE.equi.dn.TEMPERATURA.Texts, letra_negra_regular_7));
                    cell2.BackgroundColor = blanco;
                    cell2.BorderColor = gris_oscuro_border;
                    cell2.BorderWidth = 0.7f;
                    cell2.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell2.VerticalAlignment = Element.ALIGN_MIDDLE;
                    cell2.PaddingTop = 1f;
                    cell2.PaddingBottom = 4f;
                    cell2.PaddingLeft = 1f;
                    cell2.Colspan = 4;
                    table2.AddCell(cell2);

                    cell2 = new PdfPCell(new Phrase("HUMEDAD RELATIVA %:", letra_negra_regular_7));
                    cell2.BackgroundColor = gris_claro;
                    cell2.BorderColor = gris_oscuro_border;
                    cell2.BorderWidth = 0.7f;
                    cell2.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell2.VerticalAlignment = Element.ALIGN_MIDDLE;
                    cell2.PaddingTop = 1f;
                    cell2.PaddingBottom = 4f;
                    cell2.PaddingLeft = 1f;
                    cell2.Colspan = 3;
                    table2.AddCell(cell2);

                    cell2 = new PdfPCell(new Phrase(PAN_PEE.equi.dn.HUMEDAD_RELATIVA.Texts, letra_negra_regular_7));
                    cell2.BackgroundColor = blanco;
                    cell2.BorderColor = gris_oscuro_border;
                    cell2.BorderWidth = 0.7f;
                    cell2.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell2.VerticalAlignment = Element.ALIGN_MIDDLE;
                    cell2.PaddingTop = 1f;
                    cell2.PaddingBottom = 4f;
                    cell2.PaddingLeft = 1f;
                    cell2.Colspan = 4;
                    table2.AddCell(cell2);

                    table2.WriteSelectedRows(0, -1, doc.LeftMargin - 10, writer.PageSize.GetBottom(doc.BottomMargin) + 85, writer.DirectContent);
                }
                catch { }
                // REALIZÓ
                try
                {
                    PdfPTable table2 = new PdfPTable(14);
                    table2.TotalWidth = 560;
                    table2.LockedWidth = true;
                    table2.SpacingBefore = 0;
                    table2.SpacingAfter = 0;

                    float alturaSuperior = 35f;

                    PdfPCell cell2 = new PdfPCell(new Phrase("REALIZÓ:", letra_negra_regular_7));
                    cell2.BackgroundColor = gris_claro;
                    cell2.BorderColor = gris_oscuro_border;
                    cell2.BorderWidth = 0.7f;
                    cell2.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell2.VerticalAlignment = Element.ALIGN_MIDDLE;
                    cell2.PaddingTop = 1f;
                    cell2.PaddingBottom = 4f;
                    cell2.PaddingLeft = 1f;
                    cell2.Colspan = 3;
                    cell2.FixedHeight = alturaSuperior;
                    table2.AddCell(cell2);

                    string nombre = PAN_PEE.equi.dn.REALIZO.Texts;
                    cell2 = new PdfPCell();
                    cell2.BackgroundColor = blanco;
                    cell2.BorderColor = gris_oscuro_border;
                    cell2.BorderWidth = 0.7f;
                    cell2.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell2.VerticalAlignment = Element.ALIGN_MIDDLE;
                    cell2.PaddingTop = 1f;
                    cell2.PaddingBottom = 4f;
                    cell2.PaddingLeft = 1f;
                    cell2.Colspan = 4;
                    cell2.FixedHeight = alturaSuperior;

                    // Dibujar la firma y el nombre en la celda
                    if (firmaBytes2 != null && firmaBytes2.Length > 0)
                    {
                        try
                        {
                            Image firmaImg = Image.GetInstance(firmaBytes2);
                            if (nombre == "RICARDO DAVID GÓNZALEZ OLALDE")
                                firmaImg.ScaleToFit(50f, 30f);
                            else if (nombre == "TERESA JIMÉNEZ MEDINA")
                                firmaImg.ScaleToFit(50f, 30f);
                            else if (nombre == "ARMANDO ABOITES CHÁVEZ")
                                firmaImg.ScaleToFit(50f, 25f);
                            else if (nombre == "CRISTIAN GONZÁLEZ BARRERA")
                                firmaImg.ScaleToFit(95f, 75f);
                            else if (nombre == "EDGAR GUILLERMO CRUZ MURILLO")
                                firmaImg.ScaleToFit(75f, 60f);
                            else if (nombre == "DAVID OMAR JIMÉNEZ CARRADA")
                                firmaImg.ScaleToFit(90f, 76f);
                            else if (nombre == "DERIAN URIEL RIVERA SEVERINO")
                                firmaImg.ScaleToFit(100f, 80f);
                            else
                                firmaImg.ScaleToFit(80f, 40f);
                            cell2.CellEvent = new FirmaConNombreEvent(firmaImg, nombre);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Error al agregar la firma: " + ex.Message);
                        }
                    }
                    table2.AddCell(cell2);


                    // =============================================================================================================//


                    cell2 = new PdfPCell(new Phrase("REVISÓ:", letra_negra_regular_7));
                    cell2.BackgroundColor = gris_claro;
                    cell2.BorderColor = gris_oscuro_border;
                    cell2.BorderWidth = 0.7f;
                    cell2.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell2.VerticalAlignment = Element.ALIGN_MIDDLE;
                    cell2.PaddingTop = 1f;
                    cell2.PaddingBottom = 4f;
                    cell2.PaddingLeft = 1f;
                    cell2.Colspan = 3;
                    cell2.FixedHeight = alturaSuperior;
                    table2.AddCell(cell2);

                    string nombre_co = PAN_PEE.equi.dn.REVISO.Texts;
                    cell2 = new PdfPCell();
                    cell2.BackgroundColor = blanco;
                    cell2.BorderColor = gris_oscuro_border;
                    cell2.BorderWidth = 0.7f;
                    cell2.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell2.VerticalAlignment = Element.ALIGN_MIDDLE;
                    cell2.PaddingTop = 1f;
                    cell2.PaddingBottom = 4f;
                    cell2.PaddingLeft = 1f;
                    cell2.Colspan = 4;
                    cell2.FixedHeight = alturaSuperior;

                    // Dibujar la firma y el nombre en la celda
                    if (firmaBytes != null && firmaBytes.Length > 0)
                    {
                        try
                        {
                            Image firmaImg_co = Image.GetInstance(firmaBytes); 
                            if (nombre_co == "JAZMÍN BETANZOS SÁNCHEZ")
                                firmaImg_co.ScaleToFit(95f, 30f);
                            else if (nombre_co == "NICANOR RAMÍREZ RAMÍREZ")
                                firmaImg_co.ScaleToFit(100f, 35f);
                            else if (nombre_co == "CECILIA SÁNCHEZ ALANIS")
                                firmaImg_co.ScaleToFit(100f, 37f);
                            else if (nombre_co == "ALAN SOLÍS PÉREZ")
                                firmaImg_co.ScaleToFit(95f, 30f);
                            else if (nombre_co == "JULIO LÓPEZ ROSALES")
                                firmaImg_co.ScaleToFit(100f, 50f);
                            else
                                firmaImg_co.ScaleToFit(100f, 50f);

                            cell2.CellEvent = new FirmaConNombreEvent(firmaImg_co, nombre_co);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Error al agregar la firma: " + ex.Message);
                        }
                    }
                    table2.AddCell(cell2);


                    table2.WriteSelectedRows(0, -1, doc.LeftMargin - 10, writer.PageSize.GetBottom(doc.BottomMargin) + 71, writer.DirectContent);
                }
                catch { }
                // ESTÁNDAR DE REFERENCIA: 
                try
                {
                    PdfPTable table2 = new PdfPTable(14);
                    table2.TotalWidth = 560;
                    table2.LockedWidth = true;
                    table2.SpacingBefore = 0;
                    table2.SpacingAfter = 0;

                    PdfPCell cell2 = new PdfPCell(new Phrase("ESTÁNDAR DE REFERENCIA:", letra_negra_bold_7));
                    cell2.BackgroundColor = gris_oscuro;
                    cell2.BorderColor = gris_oscuro_border;
                    cell2.BorderWidth = 0.7f;
                    cell2.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell2.VerticalAlignment = Element.ALIGN_MIDDLE;
                    cell2.PaddingTop = 1f;
                    cell2.PaddingBottom = 4f;
                    cell2.PaddingLeft = 1f;
                    cell2.Colspan = 3;
                    table2.AddCell(cell2);

                    cell2 = new PdfPCell(new Phrase("ASTM D7830/D7830M - 13", letra_negra_regular_7));
                    cell2.BackgroundColor = blanco;
                    cell2.BorderColor = gris_oscuro_border;
                    cell2.BorderWidth = 0.7f;
                    cell2.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell2.VerticalAlignment = Element.ALIGN_MIDDLE;
                    cell2.PaddingTop = 1f;
                    cell2.PaddingBottom = 4f;
                    cell2.PaddingLeft = 1f;
                    cell2.Colspan = 11;
                    table2.AddCell(cell2);

                    table2.WriteSelectedRows(0, -1, doc.LeftMargin - 10, writer.PageSize.GetBottom(doc.BottomMargin) + 30, writer.DirectContent);
                }
                catch { }
                //ESTE INFORME CORRESPONDE ÚNICAMENTE
                try
                {
                    PdfPTable table2 = new PdfPTable(10);
                    table2.TotalWidth = 550;
                    table2.LockedWidth = true;
                    table2.SpacingBefore = 0;

                    PdfPCell cell2 = new PdfPCell(new Phrase("ESTE REPORTE CORRESPONDE ÚNICAMENTE A LA(S) MUESTRA(S) ENSAYADA(S).", letra_negra_regular_5));
                    cell2.BackgroundColor = blanco;
                    cell2.Border = 0;
                    cell2.HorizontalAlignment = Element.ALIGN_RIGHT;
                    cell2.VerticalAlignment = Element.ALIGN_MIDDLE;
                    cell2.PaddingBottom = 4f;
                    cell2.PaddingLeft = 1f;
                    cell2.PaddingTop = 1f;
                    cell2.Colspan = 10;
                    table2.AddCell(cell2);

                    table2.WriteSelectedRows(0, -1, doc.LeftMargin - 3, writer.PageSize.GetBottom(doc.BottomMargin) + 8, writer.DirectContent); //-15
                }
                catch { }


                    pie_pag.ScaleAbsolute(560f, 73f);
                    pie_pag.SetAbsolutePosition(25, 2);
                    cb2.AddImage(pie_pag);

                    sinencabeza_rt = false;
                }
                if (sinencabeza_rt == true)
                {
                    BaseColor negro = new BaseColor(10, 10, 10);
                    BaseColor blanco = new BaseColor(255, 255, 255);
                    BaseColor gris_oscuro = new BaseColor(191, 191, 191);
                    BaseColor gris_claro = new BaseColor(217, 217, 217);
                    BaseColor gris_oscuro_border = new BaseColor(176, 176, 176);

                    iTextSharp.text.Font title = FontFactory.GetFont("Arial", 11, 1, negro);
                    iTextSharp.text.Font subtitle = FontFactory.GetFont("Arial", 8, 0, negro);
                    iTextSharp.text.Font letra_negra_regular_5 = FontFactory.GetFont("Arial", 5, 0, negro);
                    iTextSharp.text.Font letra_negra_bold_7 = FontFactory.GetFont("Arial", 7f, 1, negro);
                    iTextSharp.text.Font letra_negra_regular_7 = FontFactory.GetFont("Arial", 7f, 0, negro);

                    
                    PdfContentByte canvas = writer.DirectContent;
                    Paragraph paragraph1 = new Paragraph("DETERMINACIÓN DEL PORCENTAJE DE COMPACTACIÓN\r\nEN CAMPO MEDIANTE DENSÍMETRO ELECTROMAGNÉTICO", title);
                    Paragraph paragraph2 = new Paragraph("EE-RT-14", subtitle);
                    AddParagraphAtPosition(paragraph1, canvas, 12, 758);    // X  -  Y
                    AddParagraphAtPosition(paragraph2, canvas, 12, 737);   // X  -  Y


                    // OBSERVACIONES: 
                    try
                    {
                        PdfPTable table2 = new PdfPTable(14);
                        table2.TotalWidth = 560;
                        table2.LockedWidth = true;
                        table2.SpacingBefore = 0;
                        table2.SpacingAfter = 0;

                        PdfPCell cell2 = new PdfPCell(new Phrase("OBSERVACIONES:", letra_negra_bold_7));
                        cell2.BackgroundColor = gris_oscuro;
                        cell2.BorderColor = gris_oscuro_border;
                        cell2.BorderWidth = 0.7f;
                        cell2.HorizontalAlignment = Element.ALIGN_CENTER;
                        cell2.VerticalAlignment = Element.ALIGN_MIDDLE;
                        cell2.PaddingTop = 1f;
                        cell2.PaddingBottom = 4f;
                        cell2.PaddingLeft = 1f;
                        cell2.Colspan = 3;
                        cell2.FixedHeight = 35f;
                        table2.AddCell(cell2);


                        string TXT_OBS = PAN_PEE.equi.dn.OBSERVACIONES.Texts.ToUpper();
                        float tamañoFuente = 7f;
                        float tamañoMinimo = 5.9f;
                        float anchoCelda = (560f / 18f) * 16f - 4f;  //560->TotalWidth = 560;  // 18f->PdfPTable table2 = new PdfPTable(14);  //   16f->cell2.Colspan = 8;  // 4f ->padding interno de la celda

                        BaseFont bf = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, false);
                        while (tamañoFuente >= tamañoMinimo)
                        {
                            float anchoTexto = bf.GetWidthPoint(TXT_OBS, tamañoFuente);

                            if (anchoTexto <= anchoCelda)
                                break;

                            tamañoFuente -= 0.2f;
                        }
                        Font letraDinamica = new Font(bf, tamañoFuente, 0, negro);

                        cell2 = new PdfPCell(new Phrase(TXT_OBS, letraDinamica));
                        cell2.BackgroundColor = blanco;
                        cell2.BorderColor = gris_oscuro_border;
                        cell2.BorderWidth = 0.7f;
                        cell2.HorizontalAlignment = Element.ALIGN_CENTER;
                        cell2.VerticalAlignment = Element.ALIGN_MIDDLE;
                        cell2.PaddingTop = 1f;
                        cell2.PaddingBottom = 4f;
                        cell2.PaddingLeft = 1f;
                        cell2.Colspan = 11;
                        table2.AddCell(cell2);

                        table2.WriteSelectedRows(0, -1, doc.LeftMargin - 10, writer.PageSize.GetBottom(doc.BottomMargin) + 125, writer.DirectContent);
                    }
                    catch { }
                    // TEMPERATURA °C
                    try
                    {
                        PdfPTable table2 = new PdfPTable(14);
                        table2.TotalWidth = 560;
                        table2.LockedWidth = true;
                        table2.SpacingBefore = 0;
                        table2.SpacingAfter = 0;

                        PdfPCell cell2 = new PdfPCell(new Phrase("TEMPERATURA °C:", letra_negra_regular_7));
                        cell2.BackgroundColor = gris_claro;
                        cell2.BorderColor = gris_oscuro_border;
                        cell2.BorderWidth = 0.7f;
                        cell2.HorizontalAlignment = Element.ALIGN_CENTER;
                        cell2.VerticalAlignment = Element.ALIGN_MIDDLE;
                        cell2.PaddingTop = 1f;
                        cell2.PaddingBottom = 4f;
                        cell2.PaddingLeft = 1f;
                        cell2.Colspan = 3;
                        cell2.FixedHeight = 14f;
                        table2.AddCell(cell2);

                        cell2 = new PdfPCell(new Phrase(PAN_PEE.equi.dn.TEMPERATURA.Texts, letra_negra_regular_7));
                        cell2.BackgroundColor = blanco;
                        cell2.BorderColor = gris_oscuro_border;
                        cell2.BorderWidth = 0.7f;
                        cell2.HorizontalAlignment = Element.ALIGN_CENTER;
                        cell2.VerticalAlignment = Element.ALIGN_MIDDLE;
                        cell2.PaddingTop = 1f;
                        cell2.PaddingBottom = 4f;
                        cell2.PaddingLeft = 1f;
                        cell2.Colspan = 4;
                        table2.AddCell(cell2);

                        cell2 = new PdfPCell(new Phrase("HUMEDAD RELATIVA %:", letra_negra_regular_7));
                        cell2.BackgroundColor = gris_claro;
                        cell2.BorderColor = gris_oscuro_border;
                        cell2.BorderWidth = 0.7f;
                        cell2.HorizontalAlignment = Element.ALIGN_CENTER;
                        cell2.VerticalAlignment = Element.ALIGN_MIDDLE;
                        cell2.PaddingTop = 1f;
                        cell2.PaddingBottom = 4f;
                        cell2.PaddingLeft = 1f;
                        cell2.Colspan = 3;
                        table2.AddCell(cell2);

                        cell2 = new PdfPCell(new Phrase(PAN_PEE.equi.dn.HUMEDAD_RELATIVA.Texts, letra_negra_regular_7));
                        cell2.BackgroundColor = blanco;
                        cell2.BorderColor = gris_oscuro_border;
                        cell2.BorderWidth = 0.7f;
                        cell2.HorizontalAlignment = Element.ALIGN_CENTER;
                        cell2.VerticalAlignment = Element.ALIGN_MIDDLE;
                        cell2.PaddingTop = 1f;
                        cell2.PaddingBottom = 4f;
                        cell2.PaddingLeft = 1f;
                        cell2.Colspan = 4;
                        table2.AddCell(cell2);

                        table2.WriteSelectedRows(0, -1, doc.LeftMargin - 10, writer.PageSize.GetBottom(doc.BottomMargin) + 85, writer.DirectContent);
                    }
                    catch { }
                    // REALIZÓ
                    try
                    {
                        PdfPTable table2 = new PdfPTable(14);
                        table2.TotalWidth = 560;
                        table2.LockedWidth = true;
                        table2.SpacingBefore = 0;
                        table2.SpacingAfter = 0;

                        float alturaSuperior = 35f;

                        PdfPCell cell2 = new PdfPCell(new Phrase("REALIZÓ:", letra_negra_regular_7));
                        cell2.BackgroundColor = gris_claro;
                        cell2.BorderColor = gris_oscuro_border;
                        cell2.BorderWidth = 0.7f;
                        cell2.HorizontalAlignment = Element.ALIGN_CENTER;
                        cell2.VerticalAlignment = Element.ALIGN_MIDDLE;
                        cell2.PaddingTop = 1f;
                        cell2.PaddingBottom = 4f;
                        cell2.PaddingLeft = 1f;
                        cell2.Colspan = 3;
                        cell2.FixedHeight = alturaSuperior;
                        table2.AddCell(cell2);

                        string nombre = PAN_PEE.equi.dn.REALIZO.Texts;
                        cell2 = new PdfPCell();
                        cell2.BackgroundColor = blanco;
                        cell2.BorderColor = gris_oscuro_border;
                        cell2.BorderWidth = 0.7f;
                        cell2.HorizontalAlignment = Element.ALIGN_CENTER;
                        cell2.VerticalAlignment = Element.ALIGN_MIDDLE;
                        cell2.PaddingTop = 1f;
                        cell2.PaddingBottom = 4f;
                        cell2.PaddingLeft = 1f;
                        cell2.Colspan = 4;
                        cell2.FixedHeight = alturaSuperior;

                        // Dibujar la firma y el nombre en la celda
                        if (firmaBytes2 != null && firmaBytes2.Length > 0)
                        {
                            try
                            {
                                Image firmaImg = Image.GetInstance(firmaBytes2);
                                if (nombre == "RICARDO DAVID GÓNZALEZ OLALDE")
                                    firmaImg.ScaleToFit(50f, 30f);
                                else if (nombre == "TERESA JIMÉNEZ MEDINA")
                                    firmaImg.ScaleToFit(50f, 30f);
                                else if (nombre == "ARMANDO ABOITES CHÁVEZ")
                                    firmaImg.ScaleToFit(50f, 25f);
                                else if (nombre == "CRISTIAN GONZÁLEZ BARRERA")
                                    firmaImg.ScaleToFit(95f, 75f);
                                else if (nombre == "EDGAR GUILLERMO CRUZ MURILLO")
                                    firmaImg.ScaleToFit(75f, 60f);
                                else if (nombre == "DAVID OMAR JIMÉNEZ CARRADA")
                                    firmaImg.ScaleToFit(90f, 76f);
                                else if (nombre == "DERIAN URIEL RIVERA SEVERINO")
                                    firmaImg.ScaleToFit(100f, 80f);
                                else
                                    firmaImg.ScaleToFit(80f, 40f);
                                cell2.CellEvent = new FirmaConNombreEvent(firmaImg, nombre);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("Error al agregar la firma: " + ex.Message);
                            }
                        }
                        table2.AddCell(cell2);


                        // =============================================================================================================//


                        cell2 = new PdfPCell(new Phrase("REVISÓ:", letra_negra_regular_7));
                        cell2.BackgroundColor = gris_claro;
                        cell2.BorderColor = gris_oscuro_border;
                        cell2.BorderWidth = 0.7f;
                        cell2.HorizontalAlignment = Element.ALIGN_CENTER;
                        cell2.VerticalAlignment = Element.ALIGN_MIDDLE;
                        cell2.PaddingTop = 1f;
                        cell2.PaddingBottom = 4f;
                        cell2.PaddingLeft = 1f;
                        cell2.Colspan = 3;
                        cell2.FixedHeight = alturaSuperior;
                        table2.AddCell(cell2);

                        string nombre_co = PAN_PEE.equi.dn.REVISO.Texts;
                        cell2 = new PdfPCell();
                        cell2.BackgroundColor = blanco;
                        cell2.BorderColor = gris_oscuro_border;
                        cell2.BorderWidth = 0.7f;
                        cell2.HorizontalAlignment = Element.ALIGN_CENTER;
                        cell2.VerticalAlignment = Element.ALIGN_MIDDLE;
                        cell2.PaddingTop = 1f;
                        cell2.PaddingBottom = 4f;
                        cell2.PaddingLeft = 1f;
                        cell2.Colspan = 4;
                        cell2.FixedHeight = alturaSuperior;

                        // Dibujar la firma y el nombre en la celda
                        if (firmaBytes != null && firmaBytes.Length > 0)
                        {
                            try
                            {
                                Image firmaImg_co = Image.GetInstance(firmaBytes);
                                if (nombre_co == "JAZMÍN BETANZOS SÁNCHEZ")
                                    firmaImg_co.ScaleToFit(95f, 30f);
                                else if (nombre_co == "NICANOR RAMÍREZ RAMÍREZ")
                                    firmaImg_co.ScaleToFit(100f, 35f);
                                else if (nombre_co == "CECILIA SÁNCHEZ ALANIS")
                                    firmaImg_co.ScaleToFit(100f, 37f);
                                else if (nombre_co == "ALAN SOLÍS PÉREZ")
                                    firmaImg_co.ScaleToFit(95f, 30f);
                                else if (nombre_co == "JULIO LÓPEZ ROSALES")
                                    firmaImg_co.ScaleToFit(100f, 50f);
                                else
                                    firmaImg_co.ScaleToFit(100f, 50f);

                                cell2.CellEvent = new FirmaConNombreEvent(firmaImg_co, nombre_co);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("Error al agregar la firma: " + ex.Message);
                            }
                        }
                        table2.AddCell(cell2);


                        table2.WriteSelectedRows(0, -1, doc.LeftMargin - 10, writer.PageSize.GetBottom(doc.BottomMargin) + 71, writer.DirectContent);
                    }
                    catch { }
                    // ESTÁNDAR DE REFERENCIA: 
                    try
                    {
                        PdfPTable table2 = new PdfPTable(14);
                        table2.TotalWidth = 560;
                        table2.LockedWidth = true;
                        table2.SpacingBefore = 0;
                        table2.SpacingAfter = 0;

                        PdfPCell cell2 = new PdfPCell(new Phrase("ESTÁNDAR DE REFERENCIA:", letra_negra_bold_7));
                        cell2.BackgroundColor = gris_oscuro;
                        cell2.BorderColor = gris_oscuro_border;
                        cell2.BorderWidth = 0.7f;
                        cell2.HorizontalAlignment = Element.ALIGN_CENTER;
                        cell2.VerticalAlignment = Element.ALIGN_MIDDLE;
                        cell2.PaddingTop = 1f;
                        cell2.PaddingBottom = 4f;
                        cell2.PaddingLeft = 1f;
                        cell2.Colspan = 3;
                        table2.AddCell(cell2);

                        cell2 = new PdfPCell(new Phrase("ASTM D7830/D7830M - 13", letra_negra_regular_7));
                        cell2.BackgroundColor = blanco;
                        cell2.BorderColor = gris_oscuro_border;
                        cell2.BorderWidth = 0.7f;
                        cell2.HorizontalAlignment = Element.ALIGN_CENTER;
                        cell2.VerticalAlignment = Element.ALIGN_MIDDLE;
                        cell2.PaddingTop = 1f;
                        cell2.PaddingBottom = 4f;
                        cell2.PaddingLeft = 1f;
                        cell2.Colspan = 11;
                        table2.AddCell(cell2);

                        table2.WriteSelectedRows(0, -1, doc.LeftMargin - 10, writer.PageSize.GetBottom(doc.BottomMargin) + 30, writer.DirectContent);
                    }
                    catch { }
                    //ESTE INFORME CORRESPONDE ÚNICAMENTE
                    try
                    {
                        PdfPTable table2 = new PdfPTable(10);
                        table2.TotalWidth = 550;
                        table2.LockedWidth = true;
                        table2.SpacingBefore = 0;

                        PdfPCell cell2 = new PdfPCell(new Phrase("ESTE REPORTE CORRESPONDE ÚNICAMENTE A LA(S) MUESTRA(S) ENSAYADA(S).", letra_negra_regular_5));
                        cell2.BackgroundColor = blanco;
                        cell2.Border = 0;
                        cell2.HorizontalAlignment = Element.ALIGN_RIGHT;
                        cell2.VerticalAlignment = Element.ALIGN_MIDDLE;
                        cell2.PaddingBottom = 4f;
                        cell2.PaddingLeft = 1f;
                        cell2.PaddingTop = 1f;
                        cell2.Colspan = 10;
                        table2.AddCell(cell2);

                        table2.WriteSelectedRows(0, -1, doc.LeftMargin - 3, writer.PageSize.GetBottom(doc.BottomMargin) + 8, writer.DirectContent); //-15
                    }
                    catch { }


                    encabeza_rt = false;
                }

            }



            public override void OnCloseDocument(PdfWriter writer, iTextSharp.text.Document document) //DA EL NUMERO FILA DE HOJAS 
            {
                int totalPages = writer.CurrentPageNumber - 1;  //DA EL NUMERO FILA DE HOJAS 
                totalPagesTemplate.BeginText();
                totalPagesTemplate.SetFontAndSize(baseFont, 5);
                totalPagesTemplate.SetTextMatrix(0, 0);
                totalPagesTemplate.ShowText("" + totalPages);
                totalPagesTemplate.EndText();
            }
            static void AddParagraphAtPosition(Paragraph paragraph, PdfContentByte canvas, float x, float y)
            {
                ColumnText columnText = new ColumnText(canvas);
                columnText.SetSimpleColumn(new Phrase(paragraph),
                    x, y, // Coordenadas X e Y
                    600, 36, // Ancho y altura máxima
                    10, // Espaciado
                    Element.ALIGN_CENTER); // Alineación
                columnText.Go();
            }

        }



        public void DOCUMENTO_RT_PDF()
        {
            MENSAJE_GENERAL MN = new MENSAJE_GENERAL();
            MN.BOTON.Text = "PDF GENERADO";
            MN.ShowDialog();

            BaseColor blanco = new BaseColor(255, 255, 255);
            BaseColor negro = new BaseColor(10, 10, 10);
            BaseColor azul_liec = new BaseColor(16, 77, 141);
            BaseColor gris_oscuro = new BaseColor(208, 206, 206);
            BaseColor gris_oscuro_border = new BaseColor(176, 176, 176);
            BaseColor gris_claro = new BaseColor(217, 217, 217);

            iTextSharp.text.Font letra_negra_bold_8 = FontFactory.GetFont("Arial", 8, 1, negro);
            iTextSharp.text.Font letra_negra_bold_7 = FontFactory.GetFont("Arial", 7, 1, negro);
            iTextSharp.text.Font letra_negra_regular_7 = FontFactory.GetFont("Arial", 7, 0, negro);
            iTextSharp.text.Font letra_negra_bold_6 = FontFactory.GetFont("Arial", 6, 1, negro);
            iTextSharp.text.Font letra_negra_regular_6 = FontFactory.GetFont("Arial", 6, 0, negro);


            string documentos = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string nombrePDF;


            if (encabeza_rt == true)
            {
                nombrePDF = "EE-RT-14-" + CLAVE_OBRA.Texts + "-E-" + NO_INFORME.Texts.ToUpper() + ".pdf";
            }
            else if (sinencabeza_rt == true)
            {
                nombrePDF = "EE-RT-14-" + CLAVE_OBRA.Texts + "-D-" + NO_INFORME.Texts.ToUpper() + ".pdf";
            }
            else
            {
                nombrePDF = "DENSIMETRO ELECTROMAGNETICO - GENERICO.pdf";
            }


            string PDF = System.IO.Path.Combine(documentos, nombrePDF);
            iTextSharp.text.Document doc = new iTextSharp.text.Document(iTextSharp.text.PageSize.LETTER);
            doc.SetMargins(36, 36, 86, 80);  //left - rigth - top - bottom

            PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(PDF, FileMode.Create));
            PAGE_RT encabezados = new PAGE_RT(firmaBytes, firma2Bytes);
            writer.PageEvent = encabezados;

            doc.Open();


            //==== INFORMACION GENERAL ====
            // FECHA DE ENSAYE
            try
            {
                PdfPTable table2 = new PdfPTable(14);
                table2.TotalWidth = 560;
                table2.LockedWidth = true;
                table2.SpacingBefore = 0;
                table2.SpacingAfter = 0;

                PdfPCell cell2 = new PdfPCell(new Phrase("FECHA DE ENSAYE:", letra_negra_bold_7));
                cell2.BackgroundColor = gris_oscuro;
                cell2.BorderColor = gris_oscuro_border;
                cell2.BorderWidth = 0.7f;
                cell2.HorizontalAlignment = Element.ALIGN_LEFT;
                cell2.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell2.PaddingTop = 1f;
                cell2.PaddingBottom = 4f;
                cell2.PaddingLeft = 3f;
                cell2.Colspan = 3;
                table2.AddCell(cell2);

                cell2 = new PdfPCell(new Phrase(FECHA_ENSAYE.Text, letra_negra_regular_7));
                cell2.BackgroundColor = blanco;
                cell2.BorderColor = gris_oscuro_border;
                cell2.BorderWidth = 0.7f;
                cell2.HorizontalAlignment = Element.ALIGN_CENTER;
                cell2.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell2.PaddingTop = 1f;
                cell2.PaddingBottom = 4f;
                cell2.PaddingLeft = 2f;
                cell2.Colspan = 4;
                table2.AddCell(cell2);

                cell2 = new PdfPCell(new Phrase("CLAVE DE OBRA:", letra_negra_bold_7));
                cell2.BackgroundColor = gris_oscuro;
                cell2.BorderColor = gris_oscuro_border;
                cell2.BorderWidth = 0.7f;
                cell2.HorizontalAlignment = Element.ALIGN_CENTER;
                cell2.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell2.PaddingTop = 1f;
                cell2.PaddingBottom = 4f;
                cell2.PaddingLeft = 1f;
                cell2.Colspan = 3;
                table2.AddCell(cell2);

                cell2 = new PdfPCell(new Phrase(CLAVE_OBRA.Texts, letra_negra_regular_7));
                cell2.BackgroundColor = blanco;
                cell2.BorderColor = gris_oscuro_border;
                cell2.BorderWidth = 0.7f;
                cell2.HorizontalAlignment = Element.ALIGN_CENTER;
                cell2.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell2.PaddingTop = 1f;
                cell2.PaddingBottom = 4f;
                cell2.PaddingLeft = 1f;
                cell2.Colspan = 4;
                table2.AddCell(cell2);

                doc.Add(table2);
            }
            catch { }
            // OBRA
            try
            {
                PdfPTable table2 = new PdfPTable(18);
                table2.TotalWidth = 560;
                table2.LockedWidth = true;

                PdfPCell cell2 = new PdfPCell(new Phrase("OBRA:", letra_negra_bold_7));
                cell2.BackgroundColor = gris_oscuro;
                cell2.BorderColor = gris_oscuro_border;
                cell2.BorderWidth = 0.7f;
                cell2.HorizontalAlignment = Element.ALIGN_LEFT;
                cell2.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell2.PaddingTop = 1f;
                cell2.PaddingBottom = 4f;
                cell2.PaddingLeft = 3f;
                cell2.Colspan = 2;
                cell2.FixedHeight = 33f;
                table2.AddCell(cell2);


                string textoObra = OBRA.Texts.ToUpper();
                float tamañoFuente = 7f;
                float tamañoMinimo = 5.9f;
                float anchoCelda = (560f / 18f) * 16f - 4f;  //560->TotalWidth = 560;  // 18f->PdfPTable table2 = new PdfPTable(14);  //   16f->cell2.Colspan = 8;  // 4f ->padding interno de la celda

                BaseFont bf = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, false);
                while (tamañoFuente >= tamañoMinimo)
                {
                    float anchoTexto = bf.GetWidthPoint(textoObra, tamañoFuente);

                    if (anchoTexto <= anchoCelda)
                        break;

                    tamañoFuente -= 0.2f;
                }
                Font letraDinamica = new Font(bf, tamañoFuente, 0, negro);

                cell2 = new PdfPCell(new Phrase(textoObra, letraDinamica));
                cell2.BackgroundColor = blanco;
                cell2.BorderColor = gris_oscuro_border;
                cell2.BorderWidth = 0.7f;
                cell2.HorizontalAlignment = Element.ALIGN_CENTER;
                cell2.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell2.PaddingTop = 1f;
                cell2.PaddingBottom = 4f;
                cell2.PaddingLeft = 1f;
                cell2.Colspan = 16;
                table2.AddCell(cell2);

                doc.Add(table2);
            }
            catch { }
            // CLIENTE
            try
            {
                PdfPTable table2 = new PdfPTable(18);
                table2.TotalWidth = 560;
                table2.LockedWidth = true;

                PdfPCell cell2 = new PdfPCell(new Phrase("CLIENTE:", letra_negra_bold_7));
                cell2.BackgroundColor = gris_oscuro;
                cell2.BorderColor = gris_oscuro_border;
                cell2.BorderWidth = 0.7f;
                cell2.HorizontalAlignment = Element.ALIGN_LEFT;
                cell2.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell2.PaddingTop = 1f;
                cell2.PaddingBottom = 4f;
                cell2.PaddingLeft = 3f;
                cell2.Colspan = 2;
                cell2.FixedHeight = 17f;
                table2.AddCell(cell2);


                string textoCliente = CLIENTE.Texts.ToUpper();
                float tamañoFuente = 7f;
                float tamañoMinimo = 5.5f;
                float anchoCelda = (560f / 18f) * 16f - 4f;  //560->TotalWidth = 560;  // 18f->PdfPTable table2 = new PdfPTable(14);  //   16f->cell2.Colspan = 8;  // 4f ->padding interno de la celda

                BaseFont bf = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, false);
                while (tamañoFuente >= tamañoMinimo)
                {
                    float anchoTexto = bf.GetWidthPoint(textoCliente, tamañoFuente);

                    if (anchoTexto <= anchoCelda)
                        break;

                    tamañoFuente -= 0.2f;
                }
                Font letraDinamica = new Font(bf, tamañoFuente, 0, negro);

                cell2 = new PdfPCell(new Phrase(textoCliente, letraDinamica));
                cell2.BackgroundColor = blanco;
                cell2.BorderColor = gris_oscuro_border;
                cell2.BorderWidth = 0.7f;
                cell2.HorizontalAlignment = Element.ALIGN_CENTER;
                cell2.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell2.PaddingTop = 1f;
                cell2.PaddingBottom = 4f;
                cell2.PaddingLeft = 1f;
                cell2.Colspan = 16;
                table2.AddCell(cell2);

                doc.Add(table2);
            }
            catch { }
            // CON ATENCIÓN A
            try
            {
                PdfPTable table2 = new PdfPTable(18);
                table2.TotalWidth = 560;
                table2.LockedWidth = true;

                PdfPCell cell2 = new PdfPCell(new Phrase("CON ATENCIÓN A:", letra_negra_bold_7));
                cell2.BackgroundColor = gris_oscuro;
                cell2.BorderColor = gris_oscuro_border;
                cell2.BorderWidth = 0.7f;
                cell2.HorizontalAlignment = Element.ALIGN_LEFT;
                cell2.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell2.PaddingTop = 1f;
                cell2.PaddingBottom = 4f;
                cell2.PaddingLeft = 3f;
                cell2.Colspan = 4;
                cell2.FixedHeight = 17f;
                table2.AddCell(cell2);


                string textoAtención = ATENCION.Texts.ToUpper();
                float tamañoFuente = 7f;
                float tamañoMinimo = 5.5f;
                float anchoCelda = (560f / 18f) * 16f - 4f;  //560->TotalWidth = 560;  // 18f->PdfPTable table2 = new PdfPTable(14);  //   16f->cell2.Colspan = 8;  // 4f ->padding interno de la celda

                BaseFont bf = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, false);
                while (tamañoFuente >= tamañoMinimo)
                {
                    float anchoTexto = bf.GetWidthPoint(textoAtención, tamañoFuente);

                    if (anchoTexto <= anchoCelda)
                        break;

                    tamañoFuente -= 0.2f;
                }
                Font letraDinamica = new Font(bf, tamañoFuente, 0, negro);

                cell2 = new PdfPCell(new Phrase(textoAtención, letraDinamica));
                cell2.BackgroundColor = blanco;
                cell2.BorderColor = gris_oscuro_border;
                cell2.BorderWidth = 0.7f;
                cell2.HorizontalAlignment = Element.ALIGN_CENTER;
                cell2.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell2.PaddingTop = 1f;
                cell2.PaddingBottom = 4f;
                cell2.PaddingLeft = 1f;
                cell2.Colspan = 14;
                table2.AddCell(cell2);

                doc.Add(table2);
            }
            catch { }
            // DATOS DEL PROYECTO
            try
            {
                PdfPTable table2 = new PdfPTable(14);
                table2.TotalWidth = 560;
                table2.LockedWidth = true;
                table2.SpacingBefore = 8;
                table2.SpacingAfter = 0;

                PdfPCell cell2 = new PdfPCell(new Phrase("DATOS DEL PROYECTO:", letra_negra_bold_7));
                cell2.BackgroundColor = gris_oscuro;
                cell2.BorderColor = gris_oscuro_border;
                cell2.BorderWidth = 0.7f;
                cell2.HorizontalAlignment = Element.ALIGN_CENTER;
                cell2.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell2.PaddingTop = 2f;
                cell2.PaddingBottom = 3f;
                cell2.PaddingLeft = 1f;
                cell2.Colspan = 14;
                table2.AddCell(cell2);

                doc.Add(table2);
            }
            catch { }
            // MATERIAL
            try
            {
                PdfPTable table2 = new PdfPTable(14);
                table2.TotalWidth = 560;
                table2.LockedWidth = true;
                table2.SpacingBefore = 0;
                table2.SpacingAfter = 0;

                PdfPCell cell2 = new PdfPCell(new Phrase("MATERIAL:", letra_negra_bold_7));
                cell2.BackgroundColor = gris_oscuro;
                cell2.BorderColor = gris_oscuro_border;
                cell2.BorderWidth = 0.7f;
                cell2.HorizontalAlignment = Element.ALIGN_LEFT;
                cell2.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell2.PaddingTop = 1f;
                cell2.PaddingBottom = 4f;
                cell2.PaddingLeft = 3f;
                cell2.Colspan = 3;
                cell2.FixedHeight = 12f;
                table2.AddCell(cell2);

                cell2 = new PdfPCell(new Phrase(MATERIAL.Texts.ToUpper(), letra_negra_regular_7));
                cell2.BackgroundColor = blanco;
                cell2.BorderColor = gris_oscuro_border;
                cell2.BorderWidth = 0.7f;
                cell2.HorizontalAlignment = Element.ALIGN_CENTER;
                cell2.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell2.PaddingTop = 1f;
                cell2.PaddingBottom = 4f;
                cell2.PaddingLeft = 1f;
                cell2.Colspan = 4;
                table2.AddCell(cell2);

                cell2 = new PdfPCell(new Phrase("COMPACTACIÓN DE PROYECTO, %", letra_negra_bold_6));
                cell2.BackgroundColor = gris_oscuro;
                cell2.BorderColor = gris_oscuro_border;
                cell2.BorderWidth = 0.7f;
                cell2.HorizontalAlignment = Element.ALIGN_LEFT;
                cell2.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell2.PaddingTop = 1f;
                cell2.PaddingBottom = 4f;
                cell2.PaddingLeft = 3f;
                cell2.PaddingTop = 1f;
                cell2.Colspan = 3;
                table2.AddCell(cell2);

                cell2 = new PdfPCell(new Phrase(COMPACTACION_PROYECTO.Texts, letra_negra_bold_7));
                cell2.BackgroundColor = blanco;
                cell2.BorderColor = gris_oscuro_border;
                cell2.BorderWidth = 0.7f;
                cell2.HorizontalAlignment = Element.ALIGN_CENTER;
                cell2.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell2.PaddingTop = 1f;
                cell2.PaddingBottom = 4f;
                cell2.PaddingLeft = 1f;
                cell2.Colspan = 4;
                table2.AddCell(cell2);

                doc.Add(table2);
            }
            catch { }
            // PROCEDENCIA
            try
            {
                PdfPTable table2 = new PdfPTable(14);
                table2.TotalWidth = 560;
                table2.LockedWidth = true;
                table2.SpacingBefore = 0;
                table2.SpacingAfter = 0;

                PdfPCell cell2 = new PdfPCell(new Phrase("PROCEDENCIA:", letra_negra_bold_7));
                cell2.BackgroundColor = gris_oscuro;
                cell2.BorderColor = gris_oscuro_border;
                cell2.BorderWidth = 0.7f;
                cell2.HorizontalAlignment = Element.ALIGN_LEFT;
                cell2.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell2.PaddingTop = 1f;
                cell2.PaddingBottom = 4f;
                cell2.PaddingLeft = 3f;
                cell2.Colspan = 3;
                cell2.FixedHeight = 15f;
                table2.AddCell(cell2);

                cell2 = new PdfPCell(new Phrase(PROCEDENCIA.Texts.ToUpper(), letra_negra_regular_7));
                cell2.BackgroundColor = blanco;
                cell2.BorderColor = gris_oscuro_border;
                cell2.BorderWidth = 0.7f;
                cell2.HorizontalAlignment = Element.ALIGN_CENTER;
                cell2.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell2.PaddingTop = 1f;
                cell2.PaddingBottom = 4f;
                cell2.PaddingLeft = 1f;
                cell2.Colspan = 4;
                table2.AddCell(cell2);

                cell2 = new PdfPCell(new Phrase("HUMEDAD ÓPTIMA (%):", letra_negra_bold_7));
                cell2.BackgroundColor = gris_oscuro;
                cell2.BorderColor = gris_oscuro_border;
                cell2.BorderWidth = 0.7f;
                cell2.HorizontalAlignment = Element.ALIGN_LEFT;
                cell2.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell2.PaddingTop = 1f;
                cell2.PaddingBottom = 4f;
                cell2.PaddingLeft = 3f;
                cell2.Colspan = 3;
                table2.AddCell(cell2);

                cell2 = new PdfPCell(new Phrase(HUMEDAD_OPTIMA.Texts, letra_negra_bold_7));
                cell2.BackgroundColor = blanco;
                cell2.BorderColor = gris_oscuro_border;
                cell2.BorderWidth = 0.7f;
                cell2.HorizontalAlignment = Element.ALIGN_CENTER;
                cell2.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell2.PaddingTop = 1f;
                cell2.PaddingBottom = 4f;
                cell2.PaddingLeft = 1f;
                cell2.Colspan = 4;
                table2.AddCell(cell2);

                doc.Add(table2);
            }
            catch { }
            // USO DEL MATERIAL
            try
            {
                PdfPTable table2 = new PdfPTable(14);
                table2.TotalWidth = 560;
                table2.LockedWidth = true;

                PdfPCell cell2 = new PdfPCell(new Phrase("USO DEL MATERIAL:", letra_negra_bold_7));
                cell2.BackgroundColor = gris_oscuro;
                cell2.BorderColor = gris_oscuro_border;
                cell2.BorderWidth = 0.7f;
                cell2.HorizontalAlignment = Element.ALIGN_LEFT;
                cell2.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell2.PaddingTop = 1f;
                cell2.PaddingBottom = 4f;
                cell2.PaddingLeft = 3f;
                cell2.Colspan = 3;
                cell2.FixedHeight = 15f;
                table2.AddCell(cell2);

                cell2 = new PdfPCell(new Phrase(USO_MATERIAL.Texts.ToUpper(), letra_negra_regular_7));
                cell2.BackgroundColor = blanco;
                cell2.BorderColor = gris_oscuro_border;
                cell2.BorderWidth = 0.7f;
                cell2.HorizontalAlignment = Element.ALIGN_CENTER;
                cell2.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell2.PaddingTop = 1f;
                cell2.PaddingBottom = 4f;
                cell2.PaddingLeft = 1f;
                cell2.Colspan = 11;
                table2.AddCell(cell2);

                doc.Add(table2);
            }
            catch { }
            // UBICACION
            try
            {
                PdfPTable table2 = new PdfPTable(14);
                table2.TotalWidth = 560;
                table2.LockedWidth = true;

                PdfPCell cell2 = new PdfPCell(new Phrase("UBICACIÓN:", letra_negra_bold_7));
                cell2.BackgroundColor = gris_oscuro;
                cell2.BorderColor = gris_oscuro_border;
                cell2.BorderWidth = 0.7f;
                cell2.HorizontalAlignment = Element.ALIGN_LEFT;
                cell2.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell2.PaddingTop = 1f;
                cell2.PaddingBottom = 4f;
                cell2.PaddingLeft = 3f;
                cell2.Colspan = 3;
                cell2.FixedHeight = 18f;
                table2.AddCell(cell2);

                cell2 = new PdfPCell(new Phrase(UBICACION.Texts.ToUpper(), letra_negra_regular_7));
                cell2.BackgroundColor = blanco;
                cell2.BorderColor = gris_oscuro_border;
                cell2.BorderWidth = 0.7f;
                cell2.HorizontalAlignment = Element.ALIGN_CENTER;
                cell2.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell2.PaddingTop = 1f;
                cell2.PaddingBottom = 4f;
                cell2.PaddingLeft = 1f;
                cell2.Colspan = 11;
                table2.AddCell(cell2);

                doc.Add(table2);
            }
            catch { }
            // EQUIPO UTILIZADO
            try
            {
                PdfPTable table2 = new PdfPTable(14);
                table2.TotalWidth = 560;
                table2.LockedWidth = true;
                table2.SpacingBefore = 8;
                table2.SpacingAfter = 0;

                PdfPCell cell2 = new PdfPCell(new Phrase("EQUIPO UTILIZADO:", letra_negra_bold_7));
                cell2.BackgroundColor = gris_oscuro;
                cell2.BorderColor = gris_oscuro_border;
                cell2.BorderWidth = 0.7f;
                cell2.HorizontalAlignment = Element.ALIGN_CENTER;
                cell2.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell2.PaddingTop = 2f;
                cell2.PaddingBottom = 3f;
                cell2.PaddingLeft = 1f;
                cell2.Colspan = 14;
                table2.AddCell(cell2);

                doc.Add(table2);
            }
            catch { }
            // MEDIDOR
            try
            {
                PdfPTable table2 = new PdfPTable(14);
                table2.TotalWidth = 560;
                table2.LockedWidth = true;
                table2.SpacingBefore = 0;
                table2.SpacingAfter = 0;

                PdfPCell cell2 = new PdfPCell(new Phrase("MEDIDOR:", letra_negra_bold_7));
                cell2.BackgroundColor = gris_oscuro;
                cell2.BorderColor = gris_oscuro_border;
                cell2.BorderWidth = 0.7f;
                cell2.HorizontalAlignment = Element.ALIGN_CENTER;
                cell2.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell2.PaddingTop = 1f;
                cell2.PaddingBottom = 4f;
                cell2.PaddingLeft = 1f;
                cell2.Colspan = 3;
                table2.AddCell(cell2);

                cell2 = new PdfPCell(new Phrase(MEDIDOR.Texts.ToUpper(), letra_negra_regular_7));
                cell2.BackgroundColor = blanco;
                cell2.BorderColor = gris_oscuro_border;
                cell2.BorderWidth = 0.7f;
                cell2.HorizontalAlignment = Element.ALIGN_CENTER;
                cell2.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell2.PaddingTop = 1f;
                cell2.PaddingBottom = 4f;
                cell2.PaddingLeft = 1f;
                cell2.Colspan = 4;
                table2.AddCell(cell2);

                cell2 = new PdfPCell(new Phrase("MODELO:", letra_negra_bold_7));
                cell2.BackgroundColor = gris_oscuro;
                cell2.BorderColor = gris_oscuro_border;
                cell2.BorderWidth = 0.7f;
                cell2.HorizontalAlignment = Element.ALIGN_CENTER;
                cell2.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell2.PaddingTop = 1f;
                cell2.PaddingBottom = 4f;
                cell2.PaddingLeft = 1f;
                cell2.PaddingTop = 1f;
                cell2.Colspan = 3;
                table2.AddCell(cell2);

                cell2 = new PdfPCell(new Phrase(MODELO.Texts.ToUpper(), letra_negra_regular_7));
                cell2.BackgroundColor = blanco;
                cell2.BorderColor = gris_oscuro_border;
                cell2.BorderWidth = 0.7f;
                cell2.HorizontalAlignment = Element.ALIGN_CENTER;
                cell2.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell2.PaddingTop = 1f;
                cell2.PaddingBottom = 4f;
                cell2.PaddingLeft = 1f;
                cell2.Colspan = 4;
                table2.AddCell(cell2);

                doc.Add(table2);
            }
            catch { }
            // MARCA
            try
            {
                PdfPTable table2 = new PdfPTable(14);
                table2.TotalWidth = 560;
                table2.LockedWidth = true;
                table2.SpacingBefore = 0;
                table2.SpacingAfter = 0;

                PdfPCell cell2 = new PdfPCell(new Phrase("MARCA:", letra_negra_bold_7));
                cell2.BackgroundColor = gris_oscuro;
                cell2.BorderColor = gris_oscuro_border;
                cell2.BorderWidth = 0.7f;
                cell2.HorizontalAlignment = Element.ALIGN_CENTER;
                cell2.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell2.PaddingTop = 1f;
                cell2.PaddingBottom = 4f;
                cell2.PaddingLeft = 1f;
                cell2.Colspan = 3;
                table2.AddCell(cell2);

                cell2 = new PdfPCell(new Phrase(MARCA.Texts.ToUpper(), letra_negra_regular_7));
                cell2.BackgroundColor = blanco;
                cell2.BorderColor = gris_oscuro_border;
                cell2.BorderWidth = 0.7f;
                cell2.HorizontalAlignment = Element.ALIGN_CENTER;
                cell2.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell2.PaddingTop = 1f;
                cell2.PaddingBottom = 4f;
                cell2.PaddingLeft = 1f;
                cell2.Colspan = 4;
                table2.AddCell(cell2);

                cell2 = new PdfPCell(new Phrase("No. DE SERIE:", letra_negra_bold_7));
                cell2.BackgroundColor = gris_oscuro;
                cell2.BorderColor = gris_oscuro_border;
                cell2.BorderWidth = 0.7f;
                cell2.HorizontalAlignment = Element.ALIGN_CENTER;
                cell2.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell2.PaddingTop = 1f;
                cell2.PaddingBottom = 4f;
                cell2.PaddingLeft = 1f;
                cell2.PaddingTop = 1f;
                cell2.Colspan = 3;
                table2.AddCell(cell2);

                cell2 = new PdfPCell(new Phrase(NO_SERIE.Texts.ToUpper(), letra_negra_regular_7));
                cell2.BackgroundColor = blanco;
                cell2.BorderColor = gris_oscuro_border;
                cell2.BorderWidth = 0.7f;
                cell2.HorizontalAlignment = Element.ALIGN_CENTER;
                cell2.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell2.PaddingTop = 1f;
                cell2.PaddingBottom = 4f;
                cell2.PaddingLeft = 1f;
                cell2.Colspan = 4;
                table2.AddCell(cell2);

                doc.Add(table2);
            }
            catch { }
            // DATOS COMPLEMENTARIOS:
            try
            {
                PdfPTable table2 = new PdfPTable(14);
                table2.TotalWidth = 560;
                table2.LockedWidth = true;
                table2.SpacingBefore = 8;
                table2.SpacingAfter = 0;

                PdfPCell cell2 = new PdfPCell(new Phrase("DATOS COMPLEMENTARIOS:", letra_negra_bold_7));
                cell2.BackgroundColor = gris_oscuro;
                cell2.BorderColor = gris_oscuro_border;
                cell2.BorderWidth = 0.7f;
                cell2.HorizontalAlignment = Element.ALIGN_CENTER;
                cell2.VerticalAlignment = Element.ALIGN_CENTER;
                cell2.PaddingTop = 2f;
                cell2.PaddingBottom = 4f;
                cell2.PaddingLeft = 1f;
                cell2.Colspan = 14;
                table2.AddCell(cell2);

                doc.Add(table2);
            }
            catch { }


            //DATOS FOREACH TABLA SONDEOS
            int filasPorBloque = 5;
            int maxFilas = DGV_PADRON.Rows.Count;
            // Obtener el total de filas de cada tabla
            int totalFilasS = DGV_PADRON.Rows.Count;


            // ───────────── TABLA DGV SONDEOS ─────────────
            for (int inicio = 0; inicio < maxFilas; inicio += filasPorBloque)
            {
                // Nueva página solo si NO es la primera
                if (inicio != 0)
                {
                    doc.NewPage();

                    // ───────────── ENCABEZADO (inicio de página) ─────────────
                    try
                    {
                        // FECHA DE ENSAYE
                        try
                        {
                            PdfPTable table2 = new PdfPTable(14);
                            table2.TotalWidth = 560;
                            table2.LockedWidth = true;
                            table2.SpacingBefore = 0;
                            table2.SpacingAfter = 0;

                            PdfPCell cell2 = new PdfPCell(new Phrase("FECHA DE ENSAYE:", letra_negra_bold_7));
                            cell2.BackgroundColor = gris_oscuro;
                            cell2.BorderColor = gris_oscuro_border;
                            cell2.BorderWidth = 0.7f;
                            cell2.HorizontalAlignment = Element.ALIGN_LEFT;
                            cell2.VerticalAlignment = Element.ALIGN_MIDDLE;
                            cell2.PaddingTop = 1f;
                            cell2.PaddingBottom = 4f;
                            cell2.PaddingLeft = 3f;
                            cell2.Colspan = 3;
                            table2.AddCell(cell2);

                            cell2 = new PdfPCell(new Phrase(FECHA_ENSAYE.Text, letra_negra_regular_7));
                            cell2.BackgroundColor = blanco;
                            cell2.BorderColor = gris_oscuro_border;
                            cell2.BorderWidth = 0.7f;
                            cell2.HorizontalAlignment = Element.ALIGN_CENTER;
                            cell2.VerticalAlignment = Element.ALIGN_MIDDLE;
                            cell2.PaddingTop = 1f;
                            cell2.PaddingBottom = 4f;
                            cell2.PaddingLeft = 2f;
                            cell2.Colspan = 4;
                            table2.AddCell(cell2);

                            cell2 = new PdfPCell(new Phrase("CLAVE DE OBRA:", letra_negra_bold_7));
                            cell2.BackgroundColor = gris_oscuro;
                            cell2.BorderColor = gris_oscuro_border;
                            cell2.BorderWidth = 0.7f;
                            cell2.HorizontalAlignment = Element.ALIGN_CENTER;
                            cell2.VerticalAlignment = Element.ALIGN_MIDDLE;
                            cell2.PaddingTop = 1f;
                            cell2.PaddingBottom = 4f;
                            cell2.PaddingLeft = 1f;
                            cell2.Colspan = 3;
                            table2.AddCell(cell2);

                            cell2 = new PdfPCell(new Phrase(CLAVE_OBRA.Texts, letra_negra_regular_7));
                            cell2.BackgroundColor = blanco;
                            cell2.BorderColor = gris_oscuro_border;
                            cell2.BorderWidth = 0.7f;
                            cell2.HorizontalAlignment = Element.ALIGN_CENTER;
                            cell2.VerticalAlignment = Element.ALIGN_MIDDLE;
                            cell2.PaddingTop = 1f;
                            cell2.PaddingBottom = 4f;
                            cell2.PaddingLeft = 1f;
                            cell2.Colspan = 4;
                            table2.AddCell(cell2);

                            doc.Add(table2);
                        }
                        catch { }
                        // OBRA
                        try
                        {
                            PdfPTable table2 = new PdfPTable(18);
                            table2.TotalWidth = 560;
                            table2.LockedWidth = true;

                            PdfPCell cell2 = new PdfPCell(new Phrase("OBRA:", letra_negra_bold_7));
                            cell2.BackgroundColor = gris_oscuro;
                            cell2.BorderColor = gris_oscuro_border;
                            cell2.BorderWidth = 0.7f;
                            cell2.HorizontalAlignment = Element.ALIGN_LEFT;
                            cell2.VerticalAlignment = Element.ALIGN_MIDDLE;
                            cell2.PaddingTop = 1f;
                            cell2.PaddingBottom = 4f;
                            cell2.PaddingLeft = 3f;
                            cell2.Colspan = 2;
                            cell2.FixedHeight = 33f;
                            table2.AddCell(cell2);


                            string textoObra = OBRA.Texts.ToUpper();
                            float tamañoFuente = 7f;
                            float tamañoMinimo = 5.9f;
                            float anchoCelda = (560f / 18f) * 16f - 4f;  //560->TotalWidth = 560;  // 18f->PdfPTable table2 = new PdfPTable(14);  //   16f->cell2.Colspan = 8;  // 4f ->padding interno de la celda

                            BaseFont bf = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, false);
                            while (tamañoFuente >= tamañoMinimo)
                            {
                                float anchoTexto = bf.GetWidthPoint(textoObra, tamañoFuente);

                                if (anchoTexto <= anchoCelda)
                                    break;

                                tamañoFuente -= 0.2f;
                            }
                            Font letraDinamica = new Font(bf, tamañoFuente, 0, negro);

                            cell2 = new PdfPCell(new Phrase(textoObra, letraDinamica));
                            cell2.BackgroundColor = blanco;
                            cell2.BorderColor = gris_oscuro_border;
                            cell2.BorderWidth = 0.7f;
                            cell2.HorizontalAlignment = Element.ALIGN_CENTER;
                            cell2.VerticalAlignment = Element.ALIGN_MIDDLE;
                            cell2.PaddingTop = 1f;
                            cell2.PaddingBottom = 4f;
                            cell2.PaddingLeft = 1f;
                            cell2.Colspan = 16;
                            table2.AddCell(cell2);

                            doc.Add(table2);
                        }
                        catch { }
                        // CLIENTE
                        try
                        {
                            PdfPTable table2 = new PdfPTable(18);
                            table2.TotalWidth = 560;
                            table2.LockedWidth = true;

                            PdfPCell cell2 = new PdfPCell(new Phrase("CLIENTE:", letra_negra_bold_7));
                            cell2.BackgroundColor = gris_oscuro;
                            cell2.BorderColor = gris_oscuro_border;
                            cell2.BorderWidth = 0.7f;
                            cell2.HorizontalAlignment = Element.ALIGN_LEFT;
                            cell2.VerticalAlignment = Element.ALIGN_MIDDLE;
                            cell2.PaddingTop = 1f;
                            cell2.PaddingBottom = 4f;
                            cell2.PaddingLeft = 3f;
                            cell2.Colspan = 2;
                            cell2.FixedHeight = 17f;
                            table2.AddCell(cell2);


                            string textoCliente = CLIENTE.Texts.ToUpper();
                            float tamañoFuente = 7f;
                            float tamañoMinimo = 5.5f;
                            float anchoCelda = (560f / 18f) * 16f - 4f;  //560->TotalWidth = 560;  // 18f->PdfPTable table2 = new PdfPTable(14);  //   16f->cell2.Colspan = 8;  // 4f ->padding interno de la celda

                            BaseFont bf = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, false);
                            while (tamañoFuente >= tamañoMinimo)
                            {
                                float anchoTexto = bf.GetWidthPoint(textoCliente, tamañoFuente);

                                if (anchoTexto <= anchoCelda)
                                    break;

                                tamañoFuente -= 0.2f;
                            }
                            Font letraDinamica = new Font(bf, tamañoFuente, 0, negro);

                            cell2 = new PdfPCell(new Phrase(textoCliente, letraDinamica));
                            cell2.BackgroundColor = blanco;
                            cell2.BorderColor = gris_oscuro_border;
                            cell2.BorderWidth = 0.7f;
                            cell2.HorizontalAlignment = Element.ALIGN_CENTER;
                            cell2.VerticalAlignment = Element.ALIGN_MIDDLE;
                            cell2.PaddingTop = 1f;
                            cell2.PaddingBottom = 4f;
                            cell2.PaddingLeft = 1f;
                            cell2.Colspan = 16;
                            table2.AddCell(cell2);

                            doc.Add(table2);
                        }
                        catch { }
                        // CON ATENCIÓN A
                        try
                        {
                            PdfPTable table2 = new PdfPTable(18);
                            table2.TotalWidth = 560;
                            table2.LockedWidth = true;

                            PdfPCell cell2 = new PdfPCell(new Phrase("CON ATENCIÓN A:", letra_negra_bold_7));
                            cell2.BackgroundColor = gris_oscuro;
                            cell2.BorderColor = gris_oscuro_border;
                            cell2.BorderWidth = 0.7f;
                            cell2.HorizontalAlignment = Element.ALIGN_LEFT;
                            cell2.VerticalAlignment = Element.ALIGN_MIDDLE;
                            cell2.PaddingTop = 1f;
                            cell2.PaddingBottom = 4f;
                            cell2.PaddingLeft = 3f;
                            cell2.Colspan = 4;
                            cell2.FixedHeight = 17f;
                            table2.AddCell(cell2);


                            string textoAtención = ATENCION.Texts.ToUpper();
                            float tamañoFuente = 7f;
                            float tamañoMinimo = 5.5f;
                            float anchoCelda = (560f / 18f) * 16f - 4f;  //560->TotalWidth = 560;  // 18f->PdfPTable table2 = new PdfPTable(14);  //   16f->cell2.Colspan = 8;  // 4f ->padding interno de la celda

                            BaseFont bf = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, false);
                            while (tamañoFuente >= tamañoMinimo)
                            {
                                float anchoTexto = bf.GetWidthPoint(textoAtención, tamañoFuente);

                                if (anchoTexto <= anchoCelda)
                                    break;

                                tamañoFuente -= 0.2f;
                            }
                            Font letraDinamica = new Font(bf, tamañoFuente, 0, negro);

                            cell2 = new PdfPCell(new Phrase(textoAtención, letraDinamica));
                            cell2.BackgroundColor = blanco;
                            cell2.BorderColor = gris_oscuro_border;
                            cell2.BorderWidth = 0.7f;
                            cell2.HorizontalAlignment = Element.ALIGN_CENTER;
                            cell2.VerticalAlignment = Element.ALIGN_MIDDLE;
                            cell2.PaddingTop = 1f;
                            cell2.PaddingBottom = 4f;
                            cell2.PaddingLeft = 1f;
                            cell2.Colspan = 14;
                            table2.AddCell(cell2);

                            doc.Add(table2);
                        }
                        catch { }
                        // DATOS DEL PROYECTO
                        try
                        {
                            PdfPTable table2 = new PdfPTable(14);
                            table2.TotalWidth = 560;
                            table2.LockedWidth = true;
                            table2.SpacingBefore = 8;
                            table2.SpacingAfter = 0;

                            PdfPCell cell2 = new PdfPCell(new Phrase("DATOS DEL PROYECTO:", letra_negra_bold_7));
                            cell2.BackgroundColor = gris_oscuro;
                            cell2.BorderColor = gris_oscuro_border;
                            cell2.BorderWidth = 0.7f;
                            cell2.HorizontalAlignment = Element.ALIGN_CENTER;
                            cell2.VerticalAlignment = Element.ALIGN_MIDDLE;
                            cell2.PaddingTop = 2f;
                            cell2.PaddingBottom = 3f;
                            cell2.PaddingLeft = 1f;
                            cell2.Colspan = 14;
                            table2.AddCell(cell2);

                            doc.Add(table2);
                        }
                        catch { }
                        // MATERIAL
                        try
                        {
                            PdfPTable table2 = new PdfPTable(14);
                            table2.TotalWidth = 560;
                            table2.LockedWidth = true;
                            table2.SpacingBefore = 0;
                            table2.SpacingAfter = 0;

                            PdfPCell cell2 = new PdfPCell(new Phrase("MATERIAL:", letra_negra_bold_7));
                            cell2.BackgroundColor = gris_oscuro;
                            cell2.BorderColor = gris_oscuro_border;
                            cell2.BorderWidth = 0.7f;
                            cell2.HorizontalAlignment = Element.ALIGN_LEFT;
                            cell2.VerticalAlignment = Element.ALIGN_MIDDLE;
                            cell2.PaddingTop = 1f;
                            cell2.PaddingBottom = 4f;
                            cell2.PaddingLeft = 3f;
                            cell2.Colspan = 3;
                            cell2.FixedHeight = 12f;
                            table2.AddCell(cell2);

                            cell2 = new PdfPCell(new Phrase(MATERIAL.Texts.ToUpper(), letra_negra_regular_7));
                            cell2.BackgroundColor = blanco;
                            cell2.BorderColor = gris_oscuro_border;
                            cell2.BorderWidth = 0.7f;
                            cell2.HorizontalAlignment = Element.ALIGN_CENTER;
                            cell2.VerticalAlignment = Element.ALIGN_MIDDLE;
                            cell2.PaddingTop = 1f;
                            cell2.PaddingBottom = 4f;
                            cell2.PaddingLeft = 1f;
                            cell2.Colspan = 4;
                            table2.AddCell(cell2);

                            cell2 = new PdfPCell(new Phrase("COMPACTACIÓN DE PROYECTO, %", letra_negra_bold_6));
                            cell2.BackgroundColor = gris_oscuro;
                            cell2.BorderColor = gris_oscuro_border;
                            cell2.BorderWidth = 0.7f;
                            cell2.HorizontalAlignment = Element.ALIGN_LEFT;
                            cell2.VerticalAlignment = Element.ALIGN_MIDDLE;
                            cell2.PaddingTop = 1f;
                            cell2.PaddingBottom = 4f;
                            cell2.PaddingLeft = 3f;
                            cell2.PaddingTop = 1f;
                            cell2.Colspan = 3;
                            table2.AddCell(cell2);

                            cell2 = new PdfPCell(new Phrase(COMPACTACION_PROYECTO.Texts, letra_negra_bold_7));
                            cell2.BackgroundColor = blanco;
                            cell2.BorderColor = gris_oscuro_border;
                            cell2.BorderWidth = 0.7f;
                            cell2.HorizontalAlignment = Element.ALIGN_CENTER;
                            cell2.VerticalAlignment = Element.ALIGN_MIDDLE;
                            cell2.PaddingTop = 1f;
                            cell2.PaddingBottom = 4f;
                            cell2.PaddingLeft = 1f;
                            cell2.Colspan = 4;
                            table2.AddCell(cell2);

                            doc.Add(table2);
                        }
                        catch { }
                        // PROCEDENCIA
                        try
                        {
                            PdfPTable table2 = new PdfPTable(14);
                            table2.TotalWidth = 560;
                            table2.LockedWidth = true;
                            table2.SpacingBefore = 0;
                            table2.SpacingAfter = 0;

                            PdfPCell cell2 = new PdfPCell(new Phrase("PROCEDENCIA:", letra_negra_bold_7));
                            cell2.BackgroundColor = gris_oscuro;
                            cell2.BorderColor = gris_oscuro_border;
                            cell2.BorderWidth = 0.7f;
                            cell2.HorizontalAlignment = Element.ALIGN_LEFT;
                            cell2.VerticalAlignment = Element.ALIGN_MIDDLE;
                            cell2.PaddingTop = 1f;
                            cell2.PaddingBottom = 4f;
                            cell2.PaddingLeft = 3f;
                            cell2.Colspan = 3;
                            cell2.FixedHeight = 15f;
                            table2.AddCell(cell2);

                            cell2 = new PdfPCell(new Phrase(PROCEDENCIA.Texts.ToUpper(), letra_negra_regular_7));
                            cell2.BackgroundColor = blanco;
                            cell2.BorderColor = gris_oscuro_border;
                            cell2.BorderWidth = 0.7f;
                            cell2.HorizontalAlignment = Element.ALIGN_CENTER;
                            cell2.VerticalAlignment = Element.ALIGN_MIDDLE;
                            cell2.PaddingTop = 1f;
                            cell2.PaddingBottom = 4f;
                            cell2.PaddingLeft = 1f;
                            cell2.Colspan = 4;
                            table2.AddCell(cell2);

                            cell2 = new PdfPCell(new Phrase("HUMEDAD ÓPTIMA (%):", letra_negra_bold_7));
                            cell2.BackgroundColor = gris_oscuro;
                            cell2.BorderColor = gris_oscuro_border;
                            cell2.BorderWidth = 0.7f;
                            cell2.HorizontalAlignment = Element.ALIGN_LEFT;
                            cell2.VerticalAlignment = Element.ALIGN_MIDDLE;
                            cell2.PaddingTop = 1f;
                            cell2.PaddingBottom = 4f;
                            cell2.PaddingLeft = 3f;
                            cell2.Colspan = 3;
                            table2.AddCell(cell2);

                            cell2 = new PdfPCell(new Phrase(HUMEDAD_OPTIMA.Texts, letra_negra_bold_7));
                            cell2.BackgroundColor = blanco;
                            cell2.BorderColor = gris_oscuro_border;
                            cell2.BorderWidth = 0.7f;
                            cell2.HorizontalAlignment = Element.ALIGN_CENTER;
                            cell2.VerticalAlignment = Element.ALIGN_MIDDLE;
                            cell2.PaddingTop = 1f;
                            cell2.PaddingBottom = 4f;
                            cell2.PaddingLeft = 1f;
                            cell2.Colspan = 4;
                            table2.AddCell(cell2);

                            doc.Add(table2);
                        }
                        catch { }
                        // USO DEL MATERIAL
                        try
                        {
                            PdfPTable table2 = new PdfPTable(14);
                            table2.TotalWidth = 560;
                            table2.LockedWidth = true;

                            PdfPCell cell2 = new PdfPCell(new Phrase("USO DEL MATERIAL:", letra_negra_bold_7));
                            cell2.BackgroundColor = gris_oscuro;
                            cell2.BorderColor = gris_oscuro_border;
                            cell2.BorderWidth = 0.7f;
                            cell2.HorizontalAlignment = Element.ALIGN_LEFT;
                            cell2.VerticalAlignment = Element.ALIGN_MIDDLE;
                            cell2.PaddingTop = 1f;
                            cell2.PaddingBottom = 4f;
                            cell2.PaddingLeft = 3f;
                            cell2.Colspan = 3;
                            cell2.FixedHeight = 15f;
                            table2.AddCell(cell2);

                            cell2 = new PdfPCell(new Phrase(USO_MATERIAL.Texts.ToUpper(), letra_negra_regular_7));
                            cell2.BackgroundColor = blanco;
                            cell2.BorderColor = gris_oscuro_border;
                            cell2.BorderWidth = 0.7f;
                            cell2.HorizontalAlignment = Element.ALIGN_CENTER;
                            cell2.VerticalAlignment = Element.ALIGN_MIDDLE;
                            cell2.PaddingTop = 1f;
                            cell2.PaddingBottom = 4f;
                            cell2.PaddingLeft = 1f;
                            cell2.Colspan = 11;
                            table2.AddCell(cell2);

                            doc.Add(table2);
                        }
                        catch { }
                        // UBICACION
                        try
                        {
                            PdfPTable table2 = new PdfPTable(14);
                            table2.TotalWidth = 560;
                            table2.LockedWidth = true;

                            PdfPCell cell2 = new PdfPCell(new Phrase("UBICACIÓN:", letra_negra_bold_7));
                            cell2.BackgroundColor = gris_oscuro;
                            cell2.BorderColor = gris_oscuro_border;
                            cell2.BorderWidth = 0.7f;
                            cell2.HorizontalAlignment = Element.ALIGN_LEFT;
                            cell2.VerticalAlignment = Element.ALIGN_MIDDLE;
                            cell2.PaddingTop = 1f;
                            cell2.PaddingBottom = 4f;
                            cell2.PaddingLeft = 3f;
                            cell2.Colspan = 3;
                            cell2.FixedHeight = 18f;
                            table2.AddCell(cell2);

                            cell2 = new PdfPCell(new Phrase(UBICACION.Texts.ToUpper(), letra_negra_regular_7));
                            cell2.BackgroundColor = blanco;
                            cell2.BorderColor = gris_oscuro_border;
                            cell2.BorderWidth = 0.7f;
                            cell2.HorizontalAlignment = Element.ALIGN_CENTER;
                            cell2.VerticalAlignment = Element.ALIGN_MIDDLE;
                            cell2.PaddingTop = 1f;
                            cell2.PaddingBottom = 4f;
                            cell2.PaddingLeft = 1f;
                            cell2.Colspan = 11;
                            table2.AddCell(cell2);

                            doc.Add(table2);
                        }
                        catch { }
                        // EQUIPO UTILIZADO
                        try
                        {
                            PdfPTable table2 = new PdfPTable(14);
                            table2.TotalWidth = 560;
                            table2.LockedWidth = true;
                            table2.SpacingBefore = 8;
                            table2.SpacingAfter = 0;

                            PdfPCell cell2 = new PdfPCell(new Phrase("EQUIPO UTILIZADO:", letra_negra_bold_7));
                            cell2.BackgroundColor = gris_oscuro;
                            cell2.BorderColor = gris_oscuro_border;
                            cell2.BorderWidth = 0.7f;
                            cell2.HorizontalAlignment = Element.ALIGN_CENTER;
                            cell2.VerticalAlignment = Element.ALIGN_MIDDLE;
                            cell2.PaddingTop = 2f;
                            cell2.PaddingBottom = 3f;
                            cell2.PaddingLeft = 1f;
                            cell2.Colspan = 14;
                            table2.AddCell(cell2);

                            doc.Add(table2);
                        }
                        catch { }
                        // MEDIDOR
                        try
                        {
                            PdfPTable table2 = new PdfPTable(14);
                            table2.TotalWidth = 560;
                            table2.LockedWidth = true;
                            table2.SpacingBefore = 0;
                            table2.SpacingAfter = 0;

                            PdfPCell cell2 = new PdfPCell(new Phrase("MEDIDOR:", letra_negra_bold_7));
                            cell2.BackgroundColor = gris_oscuro;
                            cell2.BorderColor = gris_oscuro_border;
                            cell2.BorderWidth = 0.7f;
                            cell2.HorizontalAlignment = Element.ALIGN_CENTER;
                            cell2.VerticalAlignment = Element.ALIGN_MIDDLE;
                            cell2.PaddingTop = 1f;
                            cell2.PaddingBottom = 4f;
                            cell2.PaddingLeft = 1f;
                            cell2.Colspan = 3;
                            table2.AddCell(cell2);

                            cell2 = new PdfPCell(new Phrase(MEDIDOR.Texts.ToUpper(), letra_negra_regular_7));
                            cell2.BackgroundColor = blanco;
                            cell2.BorderColor = gris_oscuro_border;
                            cell2.BorderWidth = 0.7f;
                            cell2.HorizontalAlignment = Element.ALIGN_CENTER;
                            cell2.VerticalAlignment = Element.ALIGN_MIDDLE;
                            cell2.PaddingTop = 1f;
                            cell2.PaddingBottom = 4f;
                            cell2.PaddingLeft = 1f;
                            cell2.Colspan = 4;
                            table2.AddCell(cell2);

                            cell2 = new PdfPCell(new Phrase("MODELO:", letra_negra_bold_7));
                            cell2.BackgroundColor = gris_oscuro;
                            cell2.BorderColor = gris_oscuro_border;
                            cell2.BorderWidth = 0.7f;
                            cell2.HorizontalAlignment = Element.ALIGN_CENTER;
                            cell2.VerticalAlignment = Element.ALIGN_MIDDLE;
                            cell2.PaddingTop = 1f;
                            cell2.PaddingBottom = 4f;
                            cell2.PaddingLeft = 1f;
                            cell2.PaddingTop = 1f;
                            cell2.Colspan = 3;
                            table2.AddCell(cell2);

                            cell2 = new PdfPCell(new Phrase(MODELO.Texts.ToUpper(), letra_negra_regular_7));
                            cell2.BackgroundColor = blanco;
                            cell2.BorderColor = gris_oscuro_border;
                            cell2.BorderWidth = 0.7f;
                            cell2.HorizontalAlignment = Element.ALIGN_CENTER;
                            cell2.VerticalAlignment = Element.ALIGN_MIDDLE;
                            cell2.PaddingTop = 1f;
                            cell2.PaddingBottom = 4f;
                            cell2.PaddingLeft = 1f;
                            cell2.Colspan = 4;
                            table2.AddCell(cell2);

                            doc.Add(table2);
                        }
                        catch { }
                        // MARCA
                        try
                        {
                            PdfPTable table2 = new PdfPTable(14);
                            table2.TotalWidth = 560;
                            table2.LockedWidth = true;
                            table2.SpacingBefore = 0;
                            table2.SpacingAfter = 0;

                            PdfPCell cell2 = new PdfPCell(new Phrase("MARCA:", letra_negra_bold_7));
                            cell2.BackgroundColor = gris_oscuro;
                            cell2.BorderColor = gris_oscuro_border;
                            cell2.BorderWidth = 0.7f;
                            cell2.HorizontalAlignment = Element.ALIGN_CENTER;
                            cell2.VerticalAlignment = Element.ALIGN_MIDDLE;
                            cell2.PaddingTop = 1f;
                            cell2.PaddingBottom = 4f;
                            cell2.PaddingLeft = 1f;
                            cell2.Colspan = 3;
                            table2.AddCell(cell2);

                            cell2 = new PdfPCell(new Phrase(MARCA.Texts.ToUpper(), letra_negra_regular_7));
                            cell2.BackgroundColor = blanco;
                            cell2.BorderColor = gris_oscuro_border;
                            cell2.BorderWidth = 0.7f;
                            cell2.HorizontalAlignment = Element.ALIGN_CENTER;
                            cell2.VerticalAlignment = Element.ALIGN_MIDDLE;
                            cell2.PaddingTop = 1f;
                            cell2.PaddingBottom = 4f;
                            cell2.PaddingLeft = 1f;
                            cell2.Colspan = 4;
                            table2.AddCell(cell2);

                            cell2 = new PdfPCell(new Phrase("No. DE SERIE:", letra_negra_bold_7));
                            cell2.BackgroundColor = gris_oscuro;
                            cell2.BorderColor = gris_oscuro_border;
                            cell2.BorderWidth = 0.7f;
                            cell2.HorizontalAlignment = Element.ALIGN_CENTER;
                            cell2.VerticalAlignment = Element.ALIGN_MIDDLE;
                            cell2.PaddingTop = 1f;
                            cell2.PaddingBottom = 4f;
                            cell2.PaddingLeft = 1f;
                            cell2.PaddingTop = 1f;
                            cell2.Colspan = 3;
                            table2.AddCell(cell2);

                            cell2 = new PdfPCell(new Phrase(NO_SERIE.Texts.ToUpper(), letra_negra_regular_7));
                            cell2.BackgroundColor = blanco;
                            cell2.BorderColor = gris_oscuro_border;
                            cell2.BorderWidth = 0.7f;
                            cell2.HorizontalAlignment = Element.ALIGN_CENTER;
                            cell2.VerticalAlignment = Element.ALIGN_MIDDLE;
                            cell2.PaddingTop = 1f;
                            cell2.PaddingBottom = 4f;
                            cell2.PaddingLeft = 1f;
                            cell2.Colspan = 4;
                            table2.AddCell(cell2);

                            doc.Add(table2);
                        }
                        catch { }
                        // DATOS COMPLEMENTARIOS:
                        try
                        {
                            PdfPTable table2 = new PdfPTable(14);
                            table2.TotalWidth = 560;
                            table2.LockedWidth = true;
                            table2.SpacingBefore = 8;
                            table2.SpacingAfter = 0;

                            PdfPCell cell2 = new PdfPCell(new Phrase("DATOS COMPLEMENTARIOS:", letra_negra_bold_7));
                            cell2.BackgroundColor = gris_oscuro;
                            cell2.BorderColor = gris_oscuro_border;
                            cell2.BorderWidth = 0.7f;
                            cell2.HorizontalAlignment = Element.ALIGN_CENTER;
                            cell2.VerticalAlignment = Element.ALIGN_CENTER;
                            cell2.PaddingTop = 2f;
                            cell2.PaddingBottom = 4f;
                            cell2.PaddingLeft = 1f;
                            cell2.Colspan = 14;
                            table2.AddCell(cell2);

                            doc.Add(table2);
                        }
                        catch { }
                    }
                    catch { }
                }


                // ───────────── TABLA SONDEOS ─────────────
                {
                    int maxColumnasPorHoja_s = 5;
                    int totalColumnas_s = 1 + maxColumnasPorHoja_s;
                    PdfPTable tabla_s = new PdfPTable(totalColumnas_s);
                    tabla_s.TotalWidth = 560;
                    tabla_s.LockedWidth = true;

                    float[] widths_s = { 13f, 4f, 4f, 4f, 4f, 4f };
                    tabla_s.SetWidths(widths_s);

                    string[] descripciones_s = { "NÚMERO DE SONDEO:", "LOCALIZACIÓN DEL SONDEO:", "NÚMERO DE CAPA:", "ESPESOR DE CAPA, cm" };

                    // Encabezado de la tabla
                    for (int i = 0; i < descripciones_s.Length; i++)
                    {
                        PdfPCell cellDesc = new PdfPCell(new Phrase(descripciones_s[i], letra_negra_bold_8));
                        cellDesc.BackgroundColor = gris_oscuro;
                        cellDesc.BorderColor = gris_oscuro_border;
                        cellDesc.BorderWidth = 0.7f;
                        cellDesc.HorizontalAlignment = Element.ALIGN_CENTER;
                        cellDesc.VerticalAlignment = Element.ALIGN_MIDDLE;
                        cellDesc.PaddingTop = 1f;
                        cellDesc.PaddingBottom = 4f;
                        cellDesc.FixedHeight = 15f;
                        tabla_s.AddCell(cellDesc);

                        // Crear celdas vacías ya centradas
                        for (int j = 0; j < maxColumnasPorHoja_s; j++)
                        {
                            PdfPCell emptyCell = new PdfPCell(new Phrase(""));
                            emptyCell.HorizontalAlignment = Element.ALIGN_CENTER;
                            emptyCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                            tabla_s.AddCell(emptyCell);
                        }
                    }

                    // LLENA FILAS DE DGV FOREACH
                    for (int filaIdx = 0; filaIdx < filasPorBloque; filaIdx++)
                    {
                        int actualFila = inicio + filaIdx;
                        string[] valores = new string[4];
                        if (actualFila < totalFilasS && !DGV_PADRON.Rows[actualFila].IsNewRow)
                        {
                            valores[0] = DGV_PADRON.Rows[actualFila].Cells[1].Value?.ToString() ?? "";
                            valores[1] = DGV_PADRON.Rows[actualFila].Cells[2].Value?.ToString().ToUpper() ?? "";
                            valores[2] = DGV_PADRON.Rows[actualFila].Cells[3].Value?.ToString() ?? "";
                            valores[3] = DGV_PADRON.Rows[actualFila].Cells[4].Value?.ToString() ?? "";
                        }
                        else
                        {
                            valores[0] = valores[1] = valores[2] = valores[3] = "---";
                        }

                        //ESTILOS DE FILAS DE DGV FOREACH
                        for (int filaTabla = 0; filaTabla < 4; filaTabla++)
                        {                      
                            PdfPCell celda = tabla_s.Rows[filaTabla].GetCells()[1 + filaIdx];
                            celda.Phrase = new Phrase(valores[filaTabla], letra_negra_regular_7);
                            celda.BackgroundColor = blanco;
                            celda.BorderColor = gris_oscuro_border;
                            celda.BorderWidth = 0.7f;
                            celda.HorizontalAlignment = Element.ALIGN_CENTER;
                            celda.VerticalAlignment = Element.ALIGN_MIDDLE;

                            if (filaTabla == 1)
                            {
                                celda.Phrase = new Phrase(valores[filaTabla], letra_negra_regular_6);
                                celda.FixedHeight = 22f;
                            }
                        }
                    }
                    doc.Add(tabla_s);
                }



                // ───────────── DETERMINACIÓN DEL CONTENIDO DE HUMEDAD DEL MATERIAL ─────────────
                try
                {
                    PdfPTable table2 = new PdfPTable(23);
                    table2.TotalWidth = 560;
                    table2.LockedWidth = true;
                    table2.SpacingBefore = 8;
                    table2.SpacingAfter = 0;

                    PdfPCell cell2 = new PdfPCell(new Phrase("DETERMINACIÓN DEL CONTENIDO DE HUMEDAD DEL MATERIAL", letra_negra_bold_7));
                    cell2.BackgroundColor = gris_oscuro;
                    cell2.BorderColor = gris_oscuro_border;
                    cell2.BorderWidth = 0.7f;
                    cell2.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell2.VerticalAlignment = Element.ALIGN_MIDDLE;
                    cell2.PaddingTop = 2f;
                    cell2.PaddingBottom = 4f;
                    cell2.PaddingLeft = 1f;
                    cell2.Colspan = 23;
                    table2.AddCell(cell2);

                    doc.Add(table2);
                }
                catch { }
                // ───────────── DETERMINACIÓN DEL CONTENIDO DE HUMEDAD DEL MATERIAL ─────────────  DATOS DGV ─────────────
                {   
                    int maxColumnasPorHoja = 5;
                    int totalColumnas = 1 + maxColumnasPorHoja;
                    PdfPTable tabla = new PdfPTable(totalColumnas);
                    tabla.TotalWidth = 560;
                    tabla.LockedWidth = true;

                    float[] widths = { 13f, 4f, 4f, 4f, 4f, 4f };
                    tabla.SetWidths(widths);

                    string[] descripciones =
                    {
                        "NÚMERO DE TARA",
                        "MASA DE TARA, g",
                        "MASA DE LA TARA + MATERIAL HÚMEDO, g",
                        "MASA DEL MATERIAL HÚMEDO, g",
                        "MASA DE LA TARA +  MATERIAL SECO, g",
                        "MASA DE MATERIAL SECO, g",
                        "CONTENIDO DE HUMEDAD, %"
                    };

                    // Encabezado de la tabla
                    for (int i = 0; i < descripciones.Length; i++)
                    {
                        PdfPCell celdaDesc;
                        celdaDesc = new PdfPCell(new Phrase(descripciones[i], letra_negra_regular_7));
                        celdaDesc.BackgroundColor = blanco;
                        celdaDesc.BorderColor = gris_oscuro_border;
                        celdaDesc.BorderWidth = 0.7f;
                        celdaDesc.HorizontalAlignment = Element.ALIGN_LEFT;
                        celdaDesc.VerticalAlignment = Element.ALIGN_MIDDLE;
                        celdaDesc.PaddingTop = 1f;
                        celdaDesc.PaddingBottom = 4f;
                        celdaDesc.PaddingLeft = 3f;
                        celdaDesc.FixedHeight = 15f;
                        tabla.AddCell(celdaDesc);

                        // Crear celdas vacías ya centradas
                        for (int j = 0; j < maxColumnasPorHoja; j++)
                        {
                            PdfPCell emptyCell = new PdfPCell(new Phrase(""));
                            emptyCell.HorizontalAlignment = Element.ALIGN_CENTER;
                            emptyCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                            tabla.AddCell(emptyCell);
                        }
                    }

                    // LLENA FILAS DE DGV FOREACH
                    for (int filaIdx = 0; filaIdx < filasPorBloque; filaIdx++)
                    {
                        int actualFila = inicio + filaIdx;
                        string[] valores = new string[7];
                        if (actualFila < totalFilasS && !DGV_PADRON.Rows[actualFila].IsNewRow)
                        {
                            valores[0] = DGV_PADRON.Rows[actualFila].Cells[5].Value?.ToString().ToUpper() ?? "";// numero tara
                            valores[1] = DGV_PADRON.Rows[actualFila].Cells[6].Value?.ToString() ?? "";  //masa tara
                            //valores[2] = DGV_PADRON.Rows[actualFila].Cells[7].Value?.ToString() ?? "";

                            valores[2] = DGV_PADRON.Rows[actualFila].Cells[7].Value != null && decimal.TryParse(DGV_PADRON.Rows[actualFila].Cells[7].Value.ToString(),
                            NumberStyles.Any, CultureInfo.InvariantCulture, out decimal num1)
                            ? num1.ToString("F2", CultureInfo.InvariantCulture) : ""; // si es (1050) -> lo deja en 1050.00. si es (1050.1) -> lo deja en 1050.10


                            valores[3] = DGV_PADRON.Rows[actualFila].Cells[8].Value != null && decimal.TryParse(DGV_PADRON.Rows[actualFila].Cells[8].Value.ToString(), out decimal num2)
                            ? Math.Round(num2, 0, MidpointRounding.AwayFromZero).ToString("0") : "";  //si es (678.5-678.6) -> sube a 679. si es 678.4 -> baja a 678  CON CERO DECIMALES


                            valores[4] = DGV_PADRON.Rows[actualFila].Cells[9].Value != null && decimal.TryParse(DGV_PADRON.Rows[actualFila].Cells[9].Value.ToString(),
                            NumberStyles.Any, CultureInfo.InvariantCulture, out decimal num11)
                            ? Math.Round(num11, 0, MidpointRounding.AwayFromZero).ToString("0", CultureInfo.InvariantCulture) : "";


                            valores[5] = DGV_PADRON.Rows[actualFila].Cells[10].Value != null && decimal.TryParse(DGV_PADRON.Rows[actualFila].Cells[10].Value.ToString(), out decimal num3)
                            ? Math.Round(num3, 0, MidpointRounding.AwayFromZero).ToString("0") : "";


                            valores[6] = DGV_PADRON.Rows[actualFila].Cells[11].Value != null && decimal.TryParse(DGV_PADRON.Rows[actualFila].Cells[11].Value.ToString(), NumberStyles.Any,
                            CultureInfo.InvariantCulture, out decimal num4) ? Math.Round(num4, 1, MidpointRounding.AwayFromZero).ToString("F1", CultureInfo.InvariantCulture) : "";   //contenido humedad
                        }
                        else
                        {
                            valores[0] = valores[1] = valores[2] = valores[3] = valores[4] = valores[5] = valores[6] = "---";
                        }


                        //ESTILOS DE FILAS DE DGV FOREACH
                        for (int filaTabla = 0; filaTabla < 7; filaTabla++)
                        {
                            PdfPCell celda = tabla.Rows[filaTabla].GetCells()[1 + filaIdx];
                            celda.Phrase = new Phrase(valores[filaTabla], letra_negra_regular_7);
                            celda.BackgroundColor = blanco;
                            celda.BorderColor = gris_oscuro_border;
                            celda.BorderWidth = 0.7f;
                            celda.HorizontalAlignment = Element.ALIGN_CENTER;
                            celda.VerticalAlignment = Element.ALIGN_MIDDLE;
                        }
                    }              
                    doc.Add(tabla);
                }



                // ───────────── DETERMINACIÓN DEL PORCENTAJE DE COMPACTACIÓN EN CAMPO ─────────────
                try
                {
                    PdfPTable table2 = new PdfPTable(23);
                    table2.TotalWidth = 560;
                    table2.LockedWidth = true;
                    table2.SpacingBefore = 0;
                    table2.SpacingAfter = 0;

                    PdfPCell cell2 = new PdfPCell(new Phrase("DETERMINACIÓN DEL PORCENTAJE DE COMPACTACIÓN EN CAMPO", letra_negra_bold_7));
                    cell2.BackgroundColor = gris_oscuro;
                    cell2.BorderColor = gris_oscuro_border;
                    cell2.BorderWidth = 0.7f;
                    cell2.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell2.VerticalAlignment = Element.ALIGN_MIDDLE;
                    cell2.PaddingTop = 2f;
                    cell2.PaddingBottom = 4f;
                    cell2.PaddingLeft = 1f;
                    cell2.Colspan = 23;
                    table2.AddCell(cell2);
                    doc.Add(table2);
                }
                catch { }
                // ───────────── DETERMINACIÓN DEL PORCENTAJE DE COMPACTACIÓN EN CAMPO ─────────────  DATOS DGV ─────────────
                {
                    int maxColumnasPorHoja = 5;
                    int totalColumnas = 1 + maxColumnasPorHoja;
                    PdfPTable tabla = new PdfPTable(totalColumnas);
                    tabla.TotalWidth = 560;
                    tabla.LockedWidth = true;

                    float[] widths = { 13f, 4f, 4f, 4f, 4f, 4f };
                    tabla.SetWidths(widths);

                    string[] descripciones =
                    {
                        "MASA VOL. DEL MATERIAL HUM. DEL LUGAR, kg/m3",
                        "MASA VOL. DEL MATERIAL SECO DEL LUGAR, kg/m3",
                        "MASA VOL. SECA MÁXIMA DEL MATERIAL, kg/m³",
                        "COMPACIDAD DE MATERIAL, %"
                    };

                    int[] columnas = { 12, 13, 14, 15 };
                    for (int filaTabla = 0; filaTabla < 4; filaTabla++)
                    {
                        PdfPCell celdaDesc = new PdfPCell(new Phrase(descripciones[filaTabla], letra_negra_regular_7));
                        celdaDesc.BackgroundColor = blanco;
                        celdaDesc.BorderColor = gris_oscuro_border;
                        celdaDesc.BorderWidth = 0.7f;
                        celdaDesc.HorizontalAlignment = Element.ALIGN_LEFT;
                        celdaDesc.VerticalAlignment = Element.ALIGN_MIDDLE;
                        celdaDesc.PaddingTop = 1f;
                        celdaDesc.PaddingBottom = 4f;
                        celdaDesc.PaddingLeft = 3f;
                        celdaDesc.FixedHeight = 15f;
                        tabla.AddCell(celdaDesc);


                        // FILA UNIFICADA
                        if (filaTabla == 2)
                        {
                            string valorUnificado = "---";

                            if (inicio < totalFilasS && !DGV_PADRON.Rows[inicio].IsNewRow)
                            {
                                valorUnificado = DGV_PADRON.Rows[inicio].Cells[columnas[2]].Value?.ToString() ?? "---";
                            }

                            PdfPCell celdaUnificada = new PdfPCell(new Phrase(valorUnificado, letra_negra_bold_8));
                            celdaUnificada.Colspan = maxColumnasPorHoja;
                            celdaUnificada.BackgroundColor = blanco;
                            celdaUnificada.BorderColor = gris_oscuro_border;
                            celdaUnificada.BorderWidth = 0.7f;
                            celdaUnificada.HorizontalAlignment = Element.ALIGN_CENTER;
                            celdaUnificada.VerticalAlignment = Element.ALIGN_MIDDLE;
                            tabla.AddCell(celdaUnificada);                         
                        }
                        else
                        {
                            for (int filaIdx = 0; filaIdx < filasPorBloque; filaIdx++)
                            {
                                int actualFila = inicio + filaIdx;

                                string valor = "---";

                                if (actualFila < totalFilasS && !DGV_PADRON.Rows[actualFila].IsNewRow)
                                {
                                    var cellValue = DGV_PADRON.Rows[actualFila].Cells[columnas[filaTabla]].Value;

                                    // FILA 0 y FILA 1 → REDONDEO A ENTERO SIN DECIMALES
                                    if (filaTabla == 0 || filaTabla == 1)
                                    {
                                        valor = cellValue != null &&
                                        decimal.TryParse(cellValue.ToString(), NumberStyles.Any, CultureInfo.InvariantCulture, out decimal num)
                                        ? Math.Round(num, 0, MidpointRounding.AwayFromZero).ToString("0", CultureInfo.InvariantCulture)
                                        : "";
                                    }
                                    // FILA 3 → SIN REDONDEO CON 1 DECIMAL
                                    else if (filaTabla == 3)
                                    {
                                        valor = cellValue != null &&
                                        decimal.TryParse(cellValue.ToString(), NumberStyles.Any, CultureInfo.InvariantCulture, out decimal num)
                                        ? Math.Round(num, 1, MidpointRounding.AwayFromZero).ToString("F1", CultureInfo.InvariantCulture)
                                        : "";
                                    }
                                    // OTROS CASOS
                                    else
                                    {
                                        valor = cellValue?.ToString() ?? "";
                                    }
                                }

                                PdfPCell celda = new PdfPCell(new Phrase(valor, letra_negra_regular_7));
                                celda.BackgroundColor = blanco;
                                celda.BorderColor = gris_oscuro_border;
                                celda.BorderWidth = 0.7f;
                                celda.HorizontalAlignment = Element.ALIGN_CENTER;
                                celda.VerticalAlignment = Element.ALIGN_MIDDLE;
                                

                                if (filaTabla == 3)
                                {
                                    celda = new PdfPCell(new Phrase(valor, letra_negra_bold_8));
                                    celda.BackgroundColor = blanco;
                                    celda.BorderColor = gris_oscuro_border;
                                    celda.BorderWidth = 0.7f;
                                    celda.HorizontalAlignment = Element.ALIGN_CENTER;
                                    celda.VerticalAlignment = Element.ALIGN_MIDDLE;
                                }
                                tabla.AddCell(celda);
                            }
                        }                       
                    }
                    doc.Add(tabla);
                }




                // Nueva página solo si quedan más filas
                if (inicio + filasPorBloque < maxFilas)
                    doc.NewPage();
            }


            doc.Close();
        }


        // RT CON ENCABEZADO
        private void rt_cabeza_Click(object sender, EventArgs e)
        {
            encabeza_rt = true;
            sinencabeza_rt = false;

            string nombre_realizo1 = REALIZO.Texts;
            string nombre_reviso1 = REVISO.Texts;

            if (string.IsNullOrWhiteSpace(nombre_realizo1) || string.IsNullOrWhiteSpace(nombre_reviso1))
            {
                System.Windows.MessageBox.Show("Debes seleccionar un TÉCNICO y un SIGNATARIO antes de generar el PDF.");
                return; // cancela la generación
            }
            else
            {
                DOCUMENTO_RT_PDF();
            }
        }

        // RT SIN ENCABEZADO
        private void rt_sin_cabeza_Click(object sender, EventArgs e)
        {
            sinencabeza_rt = true;
            encabeza_rt = false;

            string nombre_realizo2 = REALIZO.Texts;
            string nombre_reviso2 = REVISO.Texts;

            if (string.IsNullOrWhiteSpace(nombre_realizo2) || string.IsNullOrWhiteSpace(nombre_reviso2))
            {
                System.Windows.MessageBox.Show("Debes seleccionar un TÉCNICO y un SIGNATARIO antes de generar el PDF.");
                return; // cancela la generación
            }
            else
            {
                DOCUMENTO_RT_PDF();
            }
        }


        //LABEL "CREAR RT" CON BOTON DERECHO/IZQUIERDO
        private void label34_Click(object sender, EventArgs e)
        {
            context_rt.Show(label34, 3, 3);
        }






        // Clase para dibujar firma con transparencia y nombre abajo       
        public class FirmaConNombreEvent_Lab : IPdfPCellEvent
        {
            private Image img;
            private string nombre;
            private Font font;

            public FirmaConNombreEvent_Lab(Image imagen, string nombrePersona)
            {
                img = imagen;
                nombre = nombrePersona;
                font = FontFactory.GetFont(FontFactory.HELVETICA, 6.5f, BaseColor.BLACK);
            }

            public void CellLayout(PdfPCell cell, Rectangle position, PdfContentByte[] canvases)
            {
                PdfContentByte canvas = canvases[PdfPTable.BACKGROUNDCANVAS];

                // -----------------------------
                // Dibujar firma centrada con transparencia
                // -----------------------------
                float imgX = position.Left + (position.Width - img.ScaledWidth) / 2;
                float imgY = position.Bottom + (position.Height - img.ScaledHeight) / 2;
                img.SetAbsolutePosition(imgX, imgY);

                PdfGState gs = new PdfGState();
                gs.FillOpacity = 1f; // 0 = invisible, 1 = opaco
                canvas.SaveState();
                canvas.SetGState(gs);
                canvas.AddImage(img);
                canvas.RestoreState();

                // -----------------------------
                // Dibujar nombre centrado en la parte inferior de la celda
                // -----------------------------
                ColumnText.ShowTextAligned(
                    canvas,
                    Element.ALIGN_CENTER,
                    new Phrase(nombre, font),
                    position.GetLeft(position.Width / 2), // centro horizontal
                    position.Bottom + 2f,
                    0
                );
            }

        }

        public static bool encabeza_lab = false;
        public static bool sinencabeza_lab = false;

        public class PAGE_LAB : PdfPageEventHelper
        {
            PdfTemplate totalPagesTemplate;
            BaseFont baseFont;

            //PARA LAS FIRMAS
            private readonly byte[] firmaBytes;
            private readonly byte[] firmaBytes2;

            // Constructor recibe las dos firmas
            public PAGE_LAB(byte[] firmaBytes, byte[] firmaBytes2)
            {
                this.firmaBytes = firmaBytes;
                this.firmaBytes2 = firmaBytes2;
            }
            public override void OnOpenDocument(PdfWriter writer, iTextSharp.text.Document document)
            {
                baseFont = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, false);
                totalPagesTemplate = writer.DirectContent.CreateTemplate(50, 50);
            }


            public override void OnEndPage(PdfWriter writer, iTextSharp.text.Document doc) //DATOS
            {
                if (encabeza_lab == true)
                {
                    BaseColor negro = new BaseColor(10, 10, 10);
                    BaseColor blanco = new BaseColor(255, 255, 255);
                    BaseColor azul_claro = new BaseColor(197, 217, 241);
                    BaseColor azul_oscuro = new BaseColor(83, 141, 213);
                    BaseColor gris_oscuro_border = new BaseColor(176, 176, 176);

                    iTextSharp.text.Font title = FontFactory.GetFont("Arial", 11, 1, negro);
                    iTextSharp.text.Font subtitle = FontFactory.GetFont("Arial", 8, 0, negro);
                    iTextSharp.text.Font letra_negra_regular_4 = FontFactory.GetFont("Arial", 4, 0, negro);
                    iTextSharp.text.Font letra_negra_regular_5 = FontFactory.GetFont("Arial", 5, 0, negro);
                    iTextSharp.text.Font letra_negra_bold_6 = FontFactory.GetFont("Arial", 6, 1, negro);
                    iTextSharp.text.Font letra_negra_regular_6 = FontFactory.GetFont("Arial", 6, 0, negro);
                    iTextSharp.text.Font letra_negra_bold_7 = FontFactory.GetFont("Arial", 7f, 1, negro);
                    iTextSharp.text.Font letra_negra_regular_7 = FontFactory.GetFont("Arial", 7f, 0, negro);


                    iTextSharp.text.Image encabezado = iTextSharp.text.Image.GetInstance(ERP_COMPLETO.Properties.Resources.ENCABEZADO_HORIZONTAL_LAB, System.Drawing.Imaging.ImageFormat.Jpeg);
                    iTextSharp.text.Image pie_pag = iTextSharp.text.Image.GetInstance(ERP_COMPLETO.Properties.Resources.PIE_DE_PÁGINA_V_LAB, System.Drawing.Imaging.ImageFormat.Jpeg);

                    PdfContentByte cb2 = writer.DirectContent;
                    encabezado = iTextSharp.text.Image.GetInstance(ERP_COMPLETO.Properties.Resources.ENCABEZADO_HORIZONTAL_LAB, System.Drawing.Imaging.ImageFormat.Jpeg);
                    encabezado.ScaleAbsolute(570f, 73f);
                    encabezado.SetAbsolutePosition(21, 713);  // + izq.  - der   //21, 690
                    cb2.AddImage(encabezado);


                    PdfContentByte canvas = writer.DirectContent;
                    Paragraph paragraph1 = new Paragraph("PORCENTAJE DE COMPACTACIÓN", title);
                    Paragraph paragraph1_1 = new Paragraph("MEDIANTE DENSÍMETRO ELECTROMAGNÉTICO", title);
                    Paragraph paragraph2 = new Paragraph("EE-LAB-21", subtitle);
                    AddParagraphAtPosition(paragraph1, canvas, 12, 758);    // X  -  Y
                    AddParagraphAtPosition(paragraph1_1, canvas, 12, 745);    // X  -  Y
                    AddParagraphAtPosition(paragraph2, canvas, 12, 732);   // X  -  Y




                    // INICIO DE FIRMA
                    base.OnEndPage(writer, doc);
                    PdfContentByte cb = writer.DirectContent;
                    if (firmaBytes2 != null && firmaBytes2.Length > 0)
                    {
                        try
                        {
                            float firmaX, firmaY;

                            if (PAN_PEE.equi.dn.REALIZO.Texts == "ALAN SOLÍS PÉREZ")
                            {
                                Image firmaImg = Image.GetInstance(firmaBytes2);
                                firmaImg.ScaleToFit(110f, 30f);

                                float center = writer.PageSize.Left + 98;
                                firmaX = center - (firmaImg.ScaledWidth / 2);
                                firmaY = writer.PageSize.GetBottom(doc.BottomMargin) + 12;

                                firmaImg.SetAbsolutePosition(firmaX, firmaY);
                                cb.AddImage(firmaImg);
                            }
                            else if (PAN_PEE.equi.dn.REALIZO.Texts == "CRISTIAN GONZÁLEZ BARRERA")
                            {
                                Image firmaImg = Image.GetInstance(firmaBytes2);
                                firmaImg.ScaleToFit(110f, 80f);

                                float center = writer.PageSize.Left + 85;
                                firmaX = center - (firmaImg.ScaledWidth / 2);
                                firmaY = writer.PageSize.GetBottom(doc.BottomMargin - 10);

                                firmaImg.SetAbsolutePosition(firmaX, firmaY);
                                cb.AddImage(firmaImg);
                            }
                            else if (PAN_PEE.equi.dn.REALIZO.Texts == "DAVID OMAR JIMÉNEZ CARRADA")
                            {
                                Image firmaImg = Image.GetInstance(firmaBytes2);
                                firmaImg.ScaleToFit(135f, 90f);

                                float center = writer.PageSize.Left + 99;
                                firmaX = center - (firmaImg.ScaledWidth / 2);
                                firmaY = writer.PageSize.GetBottom(doc.BottomMargin - 15);

                                firmaImg.SetAbsolutePosition(firmaX, firmaY);
                                cb.AddImage(firmaImg);
                            }
                            else if (PAN_PEE.equi.dn.REALIZO.Texts == "DERIAN URIEL RIVERA SEVERINO")
                            {
                                Image firmaImg = Image.GetInstance(firmaBytes2);
                                firmaImg.ScaleToFit(140f, 100f);

                                float center = writer.PageSize.Left + 97;
                                firmaX = center - (firmaImg.ScaledWidth / 2);
                                firmaY = writer.PageSize.GetBottom(doc.BottomMargin - 23);

                                firmaImg.SetAbsolutePosition(firmaX, firmaY);
                                cb.AddImage(firmaImg);
                            }
                            else if (PAN_PEE.equi.dn.REALIZO.Texts == "DIANA NAYELI BALDERAS REYES")
                            {
                                Image firmaImg = Image.GetInstance(firmaBytes2);
                                firmaImg.ScaleToFit(100f, 67f);

                                float center = writer.PageSize.Left + 100;
                                firmaX = center - (firmaImg.ScaledWidth / 2);
                                firmaY = writer.PageSize.GetBottom(doc.BottomMargin + 15);

                                firmaImg.SetAbsolutePosition(firmaX, firmaY);
                                cb.AddImage(firmaImg);
                            }
                            else if (PAN_PEE.equi.dn.REALIZO.Texts == "JONATHAN YOVANI GONZÁLEZ GÓMEZ")
                            {
                                Image firmaImg = Image.GetInstance(firmaBytes2);
                                firmaImg.ScaleToFit(100f, 90f);

                                float center = writer.PageSize.Left + 95;
                                firmaX = center - (firmaImg.ScaledWidth / 2);
                                firmaY = writer.PageSize.GetBottom(doc.BottomMargin + 15);

                                firmaImg.SetAbsolutePosition(firmaX, firmaY);
                                cb.AddImage(firmaImg);
                            }
                            else if (PAN_PEE.equi.dn.REALIZO.Texts == "JOSÉ ANTONIO GÁLVEZ DOMÍNGUEZ")
                            {
                                Image firmaImg = Image.GetInstance(firmaBytes2);
                                firmaImg.ScaleToFit(110f, 90f);

                                float center = writer.PageSize.Left + 95;
                                firmaX = center - (firmaImg.ScaledWidth / 2);
                                firmaY = writer.PageSize.GetBottom(doc.BottomMargin + 7);

                                firmaImg.SetAbsolutePosition(firmaX, firmaY);
                                cb.AddImage(firmaImg);
                            }
                            else if (PAN_PEE.equi.dn.REALIZO.Texts == "MAURICIO ESPINOZA NIETO")
                            {
                                Image firmaImg = Image.GetInstance(firmaBytes2);
                                firmaImg.ScaleToFit(95f, 80f);

                                float center = writer.PageSize.Left + 98;
                                firmaX = center - (firmaImg.ScaledWidth / 2);
                                firmaY = writer.PageSize.GetBottom(doc.BottomMargin + 17);

                                firmaImg.SetAbsolutePosition(firmaX, firmaY);
                                cb.AddImage(firmaImg);
                            }
                            else if (PAN_PEE.equi.dn.REALIZO.Texts == "CECILIA SÁNCHEZ ALANIS")
                            {
                                Image firmaImg = Image.GetInstance(firmaBytes2);
                                firmaImg.ScaleToFit(70f, 38f);

                                float center = writer.PageSize.Left + 98;
                                firmaX = center - (firmaImg.ScaledWidth / 2);
                                firmaY = writer.PageSize.GetBottom(doc.BottomMargin + 9);

                                firmaImg.SetAbsolutePosition(firmaX, firmaY);
                                cb.AddImage(firmaImg);
                            }
                            else if (PAN_PEE.equi.dn.REALIZO.Texts == "EDGAR GUILLERMO CRUZ MURILLO")
                            {
                                Image firmaImg = Image.GetInstance(firmaBytes2);
                                firmaImg.ScaleToFit(80f, 43f);

                                float center = writer.PageSize.Left + 100;
                                firmaX = center - (firmaImg.ScaledWidth / 2);
                                firmaY = writer.PageSize.GetBottom(doc.BottomMargin + 7);

                                firmaImg.SetAbsolutePosition(firmaX, firmaY);
                                cb.AddImage(firmaImg);
                            }
                            else if (PAN_PEE.equi.dn.REALIZO.Texts == "RICARDO DAVID GÓNZALEZ OLALDE")
                            {
                                Image firmaImg = Image.GetInstance(firmaBytes2);
                                firmaImg.ScaleToFit(80f, 40f);

                                float center = writer.PageSize.Left + 95;
                                firmaX = center - (firmaImg.ScaledWidth / 2);
                                firmaY = writer.PageSize.GetBottom(doc.BottomMargin + 9);

                                firmaImg.SetAbsolutePosition(firmaX, firmaY);
                                cb.AddImage(firmaImg);
                            }
                            else if (PAN_PEE.equi.dn.REALIZO.Texts == "TERESA JIMÉNEZ MEDINA")
                            {
                                Image firmaImg = Image.GetInstance(firmaBytes2);
                                firmaImg.ScaleToFit(70f, 30f);

                                float center = writer.PageSize.Left + 100;
                                firmaX = center - (firmaImg.ScaledWidth / 2);
                                firmaY = writer.PageSize.GetBottom(doc.BottomMargin + 12);

                                firmaImg.SetAbsolutePosition(firmaX, firmaY);
                                cb.AddImage(firmaImg);
                            }
                            else
                            {
                                Image firmaImg = Image.GetInstance(firmaBytes2);
                                firmaImg.ScaleToFit(100f, 47f);

                                float center = writer.PageSize.Left + 98;
                                firmaX = center - (firmaImg.ScaledWidth / 2);
                                firmaY = writer.PageSize.GetBottom(doc.BottomMargin);

                                firmaImg.SetAbsolutePosition(firmaX, firmaY);
                                cb.AddImage(firmaImg);
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Error al agregar la firma: " + ex.Message);
                        }
                    }





                    PdfContentByte fc = writer.DirectContent;
                    BaseFont fuente = BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                    fc.BeginText();
                    fc.SetFontAndSize(fuente, 6);
                    fc.SetColorFill(BaseColor.BLACK);

                    // -------------------------- *** REVISO Y APROBO --------------------------    
                    float baseY = writer.PageSize.GetBottom(doc.BottomMargin) + 45;
                    float leftX = writer.PageSize.Left + 100; // izquierda
                    float centerX = (writer.PageSize.Left + writer.PageSize.Right) / 2; // centro
                    float rightX = writer.PageSize.Right - 100; // derecha

                    fc.ShowTextAligned(Element.ALIGN_CENTER, "REALIZÒ / APROBÓ:", leftX, baseY, 0);
                    fc.ShowTextAligned(Element.ALIGN_CENTER, "________________________________________", leftX, baseY - 25, 0);
                    fc.ShowTextAligned(Element.ALIGN_CENTER, PAN_PEE.equi.dn.REALIZO.Texts, leftX, baseY - 33, 0);
                    // fc.ShowTextAligned(Element.ALIGN_CENTER, "CARGO", leftX, baseY - 40, 0);  //44
                    fc.EndText();


                    // ------------------------- **FIRMA DEL CLIENTE -------------------------
                    fc.BeginText();
                    fc.ShowTextAligned(Element.ALIGN_CENTER, "FIRMA DEL CLIENTE:", rightX, baseY, 0);
                    fc.ShowTextAligned(Element.ALIGN_CENTER, "________________________________________", rightX, baseY - 25, 0);
                    fc.EndText();

                    PdfContentByte fcliente = writer.DirectContent;
                    BaseFont fuente_cliente = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                    fcliente.BeginText();
                    fcliente.SetFontAndSize(fuente_cliente, 6);
                    fcliente.SetColorFill(BaseColor.BLACK);
                    fcliente.ShowTextAligned(Element.ALIGN_CENTER, "Nombre y Firma", rightX, baseY - 33, 0);
                    fcliente.EndText();



                    // OBSERVACIONES: 
                    try
                    {
                        PdfPTable table2 = new PdfPTable(25);
                        table2.TotalWidth = 560;
                        table2.LockedWidth = true;
                        table2.SpacingBefore = 0;
                        table2.SpacingAfter = 0;

                        PdfPCell cell2 = new PdfPCell(new Phrase("OBSERVACIONES:", letra_negra_bold_7));
                        cell2.BackgroundColor = azul_oscuro;
                        cell2.BorderColor = azul_oscuro;
                        cell2.BorderWidth = 0.7f;
                        cell2.HorizontalAlignment = Element.ALIGN_CENTER;
                        cell2.VerticalAlignment = Element.ALIGN_MIDDLE;
                        cell2.PaddingTop = 1f;
                        cell2.PaddingBottom = 3f;
                        cell2.PaddingLeft = 1f;
                        cell2.Colspan = 4;
                        cell2.FixedHeight = 35f;
                        table2.AddCell(cell2);


                        string TXT_OBS = PAN_PEE.equi.dn.OBSERVACIONES.Texts.ToUpper();
                        float tamañoFuente = 7f;
                        float tamañoMinimo = 5.9f;
                        float anchoCelda = (560f / 18f) * 16f - 4f;  //560->TotalWidth = 560;  // 18f->PdfPTable table2 = new PdfPTable(14);  //   16f->cell2.Colspan = 8;  // 4f ->padding interno de la celda

                        BaseFont bf = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, false);
                        while (tamañoFuente >= tamañoMinimo)
                        {
                            float anchoTexto = bf.GetWidthPoint(TXT_OBS, tamañoFuente);

                            if (anchoTexto <= anchoCelda)
                                break;

                            tamañoFuente -= 0.2f;
                        }
                        Font letraDinamica = new Font(bf, tamañoFuente, 0, negro);

                        cell2 = new PdfPCell(new Phrase(TXT_OBS, letraDinamica));
                        cell2.BackgroundColor = blanco;
                        cell2.BorderColor = azul_oscuro;
                        cell2.BorderWidth = 0.7f;
                        cell2.HorizontalAlignment = Element.ALIGN_CENTER;
                        cell2.VerticalAlignment = Element.ALIGN_MIDDLE;
                        cell2.PaddingTop = 1f;
                        cell2.PaddingBottom = 3f;
                        cell2.PaddingLeft = 1f;
                        cell2.Colspan = 21;
                        table2.AddCell(cell2);

                        table2.WriteSelectedRows(0, -1, doc.LeftMargin - 10, writer.PageSize.GetBottom(doc.BottomMargin) + 120, writer.DirectContent);
                    }
                    catch { }

                    // MÉTODOS DE REFERENCIA:
                    try
                    {
                        PdfPTable table2 = new PdfPTable(25);
                        table2.TotalWidth = 560;
                        table2.LockedWidth = true;

                        PdfPCell cell2 = new PdfPCell(new Phrase("MÉTODOS DE\r\nREFERENCIA:", letra_negra_bold_7));
                        cell2.BackgroundColor = azul_claro;
                        cell2.BorderColor = azul_oscuro;
                        cell2.BorderWidth = 0.7f;
                        cell2.HorizontalAlignment = Element.ALIGN_CENTER;
                        cell2.VerticalAlignment = Element.ALIGN_MIDDLE;
                        cell2.PaddingTop = 1f;
                        cell2.PaddingBottom = 3f;
                        cell2.Colspan = 4;
                        table2.AddCell(cell2);

                        cell2 = new PdfPCell();
                        cell2.BackgroundColor = blanco;
                        cell2.BorderColor = azul_oscuro;
                        cell2.BorderWidth = 0.7f;
                        cell2.HorizontalAlignment = Element.ALIGN_CENTER;
                        cell2.VerticalAlignment = Element.ALIGN_MIDDLE;
                        cell2.PaddingTop = 1f;
                        cell2.PaddingBottom = 3f;
                        cell2.Colspan = 21;

                        // Primer bloque de texto
                        Paragraph p1 = new Paragraph(
                            "ASTM D7830/D7830M-14(2021)e1, ASTM D698 − 12, ASTM D1557 − 12, ASTM D2216 - 10, ASTM D4959 - 16,",
                            letra_negra_bold_6
                        );
                        p1.Alignment = Element.ALIGN_CENTER;

                        // Segundo bloque con separación
                        Paragraph p2 = new Paragraph(
                            "PLAN DE MUESTREO \"LIEP-04b MUESTREO\"",
                            letra_negra_bold_6
                        );
                        p2.Alignment = Element.ALIGN_CENTER;
                        p2.SpacingBefore = 2f; // aquí controlas el espacio sin usar \r\n\r\n

                        cell2.AddElement(p1);
                        cell2.AddElement(p2);
                        table2.AddCell(cell2);

                        table2.WriteSelectedRows(0, -1, doc.LeftMargin - 10, writer.PageSize.GetBottom(doc.BottomMargin) + 85, writer.DirectContent);
                    }
                    catch { }



                    //ESTE REPORTE SOLO CORRESPONDE
                    try
                    {
                        PdfPTable table2 = new PdfPTable(14);
                        table2.TotalWidth = 550;
                        table2.LockedWidth = true;
                        table2.SpacingBefore = 0;
                        table2.SpacingAfter = 0;

                        PdfPCell cell2 = new PdfPCell(new Phrase(" ", letra_negra_regular_4));
                        cell2.BackgroundColor = blanco;
                        cell2.Border = 0;
                        cell2.HorizontalAlignment = Element.ALIGN_LEFT;
                        cell2.VerticalAlignment = Element.ALIGN_MIDDLE;
                        cell2.PaddingBottom = 4f;
                        cell2.PaddingLeft = 1f;
                        cell2.PaddingTop = 1f;
                        cell2.Colspan = 4;
                        table2.AddCell(cell2);

                        cell2 = new PdfPCell(new Phrase("ESTE REPORTE SOLO CORRESPONDE A LA(S) MUESTRA(S) ENSAYADA(S)", letra_negra_regular_4));
                        cell2.BackgroundColor = blanco;
                        cell2.Border = 0;
                        cell2.HorizontalAlignment = Element.ALIGN_RIGHT;
                        cell2.VerticalAlignment = Element.ALIGN_MIDDLE;
                        cell2.PaddingBottom = 4f;
                        cell2.PaddingLeft = 1f;
                        cell2.PaddingTop = 1f;
                        cell2.Colspan = 10;
                        table2.AddCell(cell2);

                        table2.WriteSelectedRows(0, -1, doc.LeftMargin - 2, writer.PageSize.GetBottom(doc.BottomMargin) + 1, writer.DirectContent);
                    }
                    catch { }





                    pie_pag.ScaleAbsolute(560f, 73f);
                    pie_pag.SetAbsolutePosition(25, 2);
                    cb2.AddImage(pie_pag);

                    sinencabeza_lab = false;
                }
                
                if (sinencabeza_lab == true)
                {
                    BaseColor negro = new BaseColor(10, 10, 10);
                    BaseColor blanco = new BaseColor(255, 255, 255);
                    BaseColor azul_claro = new BaseColor(197, 217, 241);
                    BaseColor azul_oscuro = new BaseColor(83, 141, 213);
                    BaseColor gris_oscuro_border = new BaseColor(176, 176, 176);

                    iTextSharp.text.Font title = FontFactory.GetFont("Arial", 11, 1, negro);
                    iTextSharp.text.Font subtitle = FontFactory.GetFont("Arial", 8, 0, negro);
                    iTextSharp.text.Font letra_negra_regular_4 = FontFactory.GetFont("Arial", 4, 0, negro);
                    iTextSharp.text.Font letra_negra_regular_5 = FontFactory.GetFont("Arial", 5, 0, negro);
                    iTextSharp.text.Font letra_negra_bold_6 = FontFactory.GetFont("Arial", 6, 1, negro);
                    iTextSharp.text.Font letra_negra_regular_6 = FontFactory.GetFont("Arial", 6, 0, negro);
                    iTextSharp.text.Font letra_negra_bold_7 = FontFactory.GetFont("Arial", 7f, 1, negro);
                    iTextSharp.text.Font letra_negra_regular_7 = FontFactory.GetFont("Arial", 7f, 0, negro);
               
                    PdfContentByte canvas = writer.DirectContent;
                    Paragraph paragraph1 = new Paragraph("PORCENTAJE DE COMPACTACIÓN", title);
                    Paragraph paragraph1_1 = new Paragraph("MEDIANTE DENSÍMETRO ELECTROMAGNÉTICO", title);
                    Paragraph paragraph2 = new Paragraph("EE-LAB-21", subtitle);
                    AddParagraphAtPosition(paragraph1, canvas, 12, 758);    // X  -  Y
                    AddParagraphAtPosition(paragraph1_1, canvas, 12, 745);    // X  -  Y
                    AddParagraphAtPosition(paragraph2, canvas, 12, 732);   // X  -  Y



                    // INICIO DE FIRMA
                    base.OnEndPage(writer, doc);
                    PdfContentByte cb = writer.DirectContent;
                    if (firmaBytes2 != null && firmaBytes2.Length > 0)
                    {
                        try
                        {
                            float firmaX, firmaY;

                            if (PAN_PEE.equi.dn.REALIZO.Texts == "ALAN SOLÍS PÉREZ")
                            {
                                Image firmaImg = Image.GetInstance(firmaBytes2);
                                firmaImg.ScaleToFit(110f, 30f);

                                float center = writer.PageSize.Left + 98;
                                firmaX = center - (firmaImg.ScaledWidth / 2);
                                firmaY = writer.PageSize.GetBottom(doc.BottomMargin) + 12;

                                firmaImg.SetAbsolutePosition(firmaX, firmaY);
                                cb.AddImage(firmaImg);
                            }
                            else if (PAN_PEE.equi.dn.REALIZO.Texts == "CRISTIAN GONZÁLEZ BARRERA")
                            {
                                Image firmaImg = Image.GetInstance(firmaBytes2);
                                firmaImg.ScaleToFit(110f, 80f);

                                float center = writer.PageSize.Left + 85;
                                firmaX = center - (firmaImg.ScaledWidth / 2);
                                firmaY = writer.PageSize.GetBottom(doc.BottomMargin - 10);

                                firmaImg.SetAbsolutePosition(firmaX, firmaY);
                                cb.AddImage(firmaImg);
                            }
                            else if (PAN_PEE.equi.dn.REALIZO.Texts == "DAVID OMAR JIMÉNEZ CARRADA")
                            {
                                Image firmaImg = Image.GetInstance(firmaBytes2);
                                firmaImg.ScaleToFit(135f, 90f);

                                float center = writer.PageSize.Left + 99;
                                firmaX = center - (firmaImg.ScaledWidth / 2);
                                firmaY = writer.PageSize.GetBottom(doc.BottomMargin - 15);

                                firmaImg.SetAbsolutePosition(firmaX, firmaY);
                                cb.AddImage(firmaImg);
                            }
                            else if (PAN_PEE.equi.dn.REALIZO.Texts == "DERIAN URIEL RIVERA SEVERINO")
                            {
                                Image firmaImg = Image.GetInstance(firmaBytes2);
                                firmaImg.ScaleToFit(140f, 100f);

                                float center = writer.PageSize.Left + 97;
                                firmaX = center - (firmaImg.ScaledWidth / 2);
                                firmaY = writer.PageSize.GetBottom(doc.BottomMargin - 23);

                                firmaImg.SetAbsolutePosition(firmaX, firmaY);
                                cb.AddImage(firmaImg);
                            }
                            else if (PAN_PEE.equi.dn.REALIZO.Texts == "DIANA NAYELI BALDERAS REYES")
                            {
                                Image firmaImg = Image.GetInstance(firmaBytes2);
                                firmaImg.ScaleToFit(100f, 67f);

                                float center = writer.PageSize.Left + 100;
                                firmaX = center - (firmaImg.ScaledWidth / 2);
                                firmaY = writer.PageSize.GetBottom(doc.BottomMargin + 15);

                                firmaImg.SetAbsolutePosition(firmaX, firmaY);
                                cb.AddImage(firmaImg);
                            }
                            else if (PAN_PEE.equi.dn.REALIZO.Texts == "JONATHAN YOVANI GONZÁLEZ GÓMEZ")
                            {
                                Image firmaImg = Image.GetInstance(firmaBytes2);
                                firmaImg.ScaleToFit(100f, 90f);

                                float center = writer.PageSize.Left + 95;
                                firmaX = center - (firmaImg.ScaledWidth / 2);
                                firmaY = writer.PageSize.GetBottom(doc.BottomMargin + 15);

                                firmaImg.SetAbsolutePosition(firmaX, firmaY);
                                cb.AddImage(firmaImg);
                            }
                            else if (PAN_PEE.equi.dn.REALIZO.Texts == "JOSÉ ANTONIO GÁLVEZ DOMÍNGUEZ")
                            {
                                Image firmaImg = Image.GetInstance(firmaBytes2);
                                firmaImg.ScaleToFit(110f, 90f);

                                float center = writer.PageSize.Left + 95;
                                firmaX = center - (firmaImg.ScaledWidth / 2);
                                firmaY = writer.PageSize.GetBottom(doc.BottomMargin + 7);

                                firmaImg.SetAbsolutePosition(firmaX, firmaY);
                                cb.AddImage(firmaImg);
                            }
                            else if (PAN_PEE.equi.dn.REALIZO.Texts == "MAURICIO ESPINOZA NIETO")
                            {
                                Image firmaImg = Image.GetInstance(firmaBytes2);
                                firmaImg.ScaleToFit(95f, 80f);

                                float center = writer.PageSize.Left + 98;
                                firmaX = center - (firmaImg.ScaledWidth / 2);
                                firmaY = writer.PageSize.GetBottom(doc.BottomMargin + 17);

                                firmaImg.SetAbsolutePosition(firmaX, firmaY);
                                cb.AddImage(firmaImg);
                            }
                            else if (PAN_PEE.equi.dn.REALIZO.Texts == "CECILIA SÁNCHEZ ALANIS")
                            {
                                Image firmaImg = Image.GetInstance(firmaBytes2);
                                firmaImg.ScaleToFit(70f, 38f);

                                float center = writer.PageSize.Left + 98;
                                firmaX = center - (firmaImg.ScaledWidth / 2);
                                firmaY = writer.PageSize.GetBottom(doc.BottomMargin + 9);

                                firmaImg.SetAbsolutePosition(firmaX, firmaY);
                                cb.AddImage(firmaImg);
                            }
                            else if (PAN_PEE.equi.dn.REALIZO.Texts == "EDGAR GUILLERMO CRUZ MURILLO")
                            {
                                Image firmaImg = Image.GetInstance(firmaBytes2);
                                firmaImg.ScaleToFit(80f, 43f);

                                float center = writer.PageSize.Left + 100;
                                firmaX = center - (firmaImg.ScaledWidth / 2);
                                firmaY = writer.PageSize.GetBottom(doc.BottomMargin + 7);

                                firmaImg.SetAbsolutePosition(firmaX, firmaY);
                                cb.AddImage(firmaImg);
                            }
                            else if (PAN_PEE.equi.dn.REALIZO.Texts == "RICARDO DAVID GÓNZALEZ OLALDE")
                            {
                                Image firmaImg = Image.GetInstance(firmaBytes2);
                                firmaImg.ScaleToFit(80f, 40f);

                                float center = writer.PageSize.Left + 95;
                                firmaX = center - (firmaImg.ScaledWidth / 2);
                                firmaY = writer.PageSize.GetBottom(doc.BottomMargin + 9);

                                firmaImg.SetAbsolutePosition(firmaX, firmaY);
                                cb.AddImage(firmaImg);
                            }
                            else if (PAN_PEE.equi.dn.REALIZO.Texts == "TERESA JIMÉNEZ MEDINA")
                            {
                                Image firmaImg = Image.GetInstance(firmaBytes2);
                                firmaImg.ScaleToFit(70f, 30f);

                                float center = writer.PageSize.Left + 100;
                                firmaX = center - (firmaImg.ScaledWidth / 2);
                                firmaY = writer.PageSize.GetBottom(doc.BottomMargin + 12);

                                firmaImg.SetAbsolutePosition(firmaX, firmaY);
                                cb.AddImage(firmaImg);
                            }
                            else
                            {
                                Image firmaImg = Image.GetInstance(firmaBytes2);
                                firmaImg.ScaleToFit(100f, 47f);

                                float center = writer.PageSize.Left + 98;
                                firmaX = center - (firmaImg.ScaledWidth / 2);
                                firmaY = writer.PageSize.GetBottom(doc.BottomMargin);

                                firmaImg.SetAbsolutePosition(firmaX, firmaY);
                                cb.AddImage(firmaImg);
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Error al agregar la firma: " + ex.Message);
                        }
                    }



                    PdfContentByte fc = writer.DirectContent;
                    BaseFont fuente = BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                    fc.BeginText();
                    fc.SetFontAndSize(fuente, 6);
                    fc.SetColorFill(BaseColor.BLACK);

                    // -------------------------- *** REVISO Y APROBO --------------------------    
                    float baseY = writer.PageSize.GetBottom(doc.BottomMargin) + 45;
                    float leftX = writer.PageSize.Left + 100; // izquierda
                    float centerX = (writer.PageSize.Left + writer.PageSize.Right) / 2; // centro
                    float rightX = writer.PageSize.Right - 100; // derecha

                    fc.ShowTextAligned(Element.ALIGN_CENTER, "REALIZÒ / APROBÓ:", leftX, baseY, 0);
                    fc.ShowTextAligned(Element.ALIGN_CENTER, "________________________________________", leftX, baseY - 25, 0);
                    fc.ShowTextAligned(Element.ALIGN_CENTER, PAN_PEE.equi.dn.REALIZO.Texts, leftX, baseY - 33, 0);
                    // fc.ShowTextAligned(Element.ALIGN_CENTER, "CARGO", leftX, baseY - 40, 0);  //44
                    fc.EndText();


                    // ------------------------- **FIRMA DEL CLIENTE -------------------------
                    fc.BeginText();
                    fc.ShowTextAligned(Element.ALIGN_CENTER, "FIRMA DEL CLIENTE:", rightX, baseY, 0);
                    fc.ShowTextAligned(Element.ALIGN_CENTER, "________________________________________", rightX, baseY - 25, 0);
                    fc.EndText();

                    PdfContentByte fcliente = writer.DirectContent;
                    BaseFont fuente_cliente = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                    fcliente.BeginText();
                    fcliente.SetFontAndSize(fuente_cliente, 6);
                    fcliente.SetColorFill(BaseColor.BLACK);
                    fcliente.ShowTextAligned(Element.ALIGN_CENTER, "Nombre y Firma", rightX, baseY - 33, 0);
                    fcliente.EndText();



                    // OBSERVACIONES: 
                    try
                    {
                        PdfPTable table2 = new PdfPTable(25);
                        table2.TotalWidth = 560;
                        table2.LockedWidth = true;
                        table2.SpacingBefore = 0;
                        table2.SpacingAfter = 0;

                        PdfPCell cell2 = new PdfPCell(new Phrase("OBSERVACIONES:", letra_negra_bold_7));
                        cell2.BackgroundColor = azul_oscuro;
                        cell2.BorderColor = azul_oscuro;
                        cell2.BorderWidth = 0.7f;
                        cell2.HorizontalAlignment = Element.ALIGN_CENTER;
                        cell2.VerticalAlignment = Element.ALIGN_MIDDLE;
                        cell2.PaddingTop = 1f;
                        cell2.PaddingBottom = 3f;
                        cell2.PaddingLeft = 1f;
                        cell2.Colspan = 4;
                        cell2.FixedHeight = 35f;
                        table2.AddCell(cell2);


                        string TXT_OBS = PAN_PEE.equi.dn.OBSERVACIONES.Texts.ToUpper();
                        float tamañoFuente = 7f;
                        float tamañoMinimo = 5.9f;
                        float anchoCelda = (560f / 18f) * 16f - 4f;  //560->TotalWidth = 560;  // 18f->PdfPTable table2 = new PdfPTable(14);  //   16f->cell2.Colspan = 8;  // 4f ->padding interno de la celda

                        BaseFont bf = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, false);
                        while (tamañoFuente >= tamañoMinimo)
                        {
                            float anchoTexto = bf.GetWidthPoint(TXT_OBS, tamañoFuente);

                            if (anchoTexto <= anchoCelda)
                                break;

                            tamañoFuente -= 0.2f;
                        }
                        Font letraDinamica = new Font(bf, tamañoFuente, 0, negro);

                        cell2 = new PdfPCell(new Phrase(TXT_OBS, letraDinamica));
                        cell2.BackgroundColor = blanco;
                        cell2.BorderColor = azul_oscuro;
                        cell2.BorderWidth = 0.7f;
                        cell2.HorizontalAlignment = Element.ALIGN_CENTER;
                        cell2.VerticalAlignment = Element.ALIGN_MIDDLE;
                        cell2.PaddingTop = 1f;
                        cell2.PaddingBottom = 3f;
                        cell2.PaddingLeft = 1f;
                        cell2.Colspan = 21;
                        table2.AddCell(cell2);

                        table2.WriteSelectedRows(0, -1, doc.LeftMargin - 10, writer.PageSize.GetBottom(doc.BottomMargin) + 120, writer.DirectContent);
                    }
                    catch { }

                    // MÉTODOS DE REFERENCIA:
                    try
                    {
                        PdfPTable table2 = new PdfPTable(25);
                        table2.TotalWidth = 560;
                        table2.LockedWidth = true;

                        PdfPCell cell2 = new PdfPCell(new Phrase("MÉTODOS DE\r\nREFERENCIA:", letra_negra_bold_7));
                        cell2.BackgroundColor = azul_claro;
                        cell2.BorderColor = azul_oscuro;
                        cell2.BorderWidth = 0.7f;
                        cell2.HorizontalAlignment = Element.ALIGN_CENTER;
                        cell2.VerticalAlignment = Element.ALIGN_MIDDLE;
                        cell2.PaddingTop = 1f;
                        cell2.PaddingBottom = 3f;
                        cell2.Colspan = 4;
                        table2.AddCell(cell2);

                        cell2 = new PdfPCell();
                        cell2.BackgroundColor = blanco;
                        cell2.BorderColor = azul_oscuro;
                        cell2.BorderWidth = 0.7f;
                        cell2.HorizontalAlignment = Element.ALIGN_CENTER;
                        cell2.VerticalAlignment = Element.ALIGN_MIDDLE;
                        cell2.PaddingTop = 1f;
                        cell2.PaddingBottom = 3f;
                        cell2.Colspan = 21;

                        // Primer bloque de texto
                        Paragraph p1 = new Paragraph(
                            "ASTM D7830/D7830M-14(2021)e1, ASTM D698 − 12, ASTM D1557 − 12, ASTM D2216 - 10, ASTM D4959 - 16,",
                            letra_negra_bold_6
                        );
                        p1.Alignment = Element.ALIGN_CENTER;

                        // Segundo bloque con separación
                        Paragraph p2 = new Paragraph(
                            "PLAN DE MUESTREO \"LIEP-04b MUESTREO\"",
                            letra_negra_bold_6
                        );
                        p2.Alignment = Element.ALIGN_CENTER;
                        p2.SpacingBefore = 2f; // aquí controlas el espacio sin usar \r\n\r\n

                        cell2.AddElement(p1);
                        cell2.AddElement(p2);
                        table2.AddCell(cell2);

                        table2.WriteSelectedRows(0, -1, doc.LeftMargin - 10, writer.PageSize.GetBottom(doc.BottomMargin) + 85, writer.DirectContent);
                    }
                    catch { }

                    //ESTE REPORTE SOLO CORRESPONDE
                    try
                    {
                        PdfPTable table2 = new PdfPTable(14);
                        table2.TotalWidth = 550;
                        table2.LockedWidth = true;
                        table2.SpacingBefore = 0;
                        table2.SpacingAfter = 0;

                        PdfPCell cell2 = new PdfPCell(new Phrase(" ", letra_negra_regular_4));
                        cell2.BackgroundColor = blanco;
                        cell2.Border = 0;
                        cell2.HorizontalAlignment = Element.ALIGN_LEFT;
                        cell2.VerticalAlignment = Element.ALIGN_MIDDLE;
                        cell2.PaddingBottom = 4f;
                        cell2.PaddingLeft = 1f;
                        cell2.PaddingTop = 1f;
                        cell2.Colspan = 4;
                        table2.AddCell(cell2);

                        cell2 = new PdfPCell(new Phrase("ESTE REPORTE SOLO CORRESPONDE A LA(S) MUESTRA(S) ENSAYADA(S)", letra_negra_regular_4));
                        cell2.BackgroundColor = blanco;
                        cell2.Border = 0;
                        cell2.HorizontalAlignment = Element.ALIGN_RIGHT;
                        cell2.VerticalAlignment = Element.ALIGN_MIDDLE;
                        cell2.PaddingBottom = 4f;
                        cell2.PaddingLeft = 1f;
                        cell2.PaddingTop = 1f;
                        cell2.Colspan = 10;
                        table2.AddCell(cell2);

                        table2.WriteSelectedRows(0, -1, doc.LeftMargin - 2, writer.PageSize.GetBottom(doc.BottomMargin) + 1, writer.DirectContent);
                    }
                    catch { }


                    encabeza_lab = false;
                }

            }



            public override void OnCloseDocument(PdfWriter writer, iTextSharp.text.Document document) //DA EL NUMERO FILA DE HOJAS 
            {
                int totalPages = writer.CurrentPageNumber - 1;  //DA EL NUMERO FILA DE HOJAS 
                totalPagesTemplate.BeginText();
                totalPagesTemplate.SetFontAndSize(baseFont, 5);
                totalPagesTemplate.SetTextMatrix(0, 0);
                totalPagesTemplate.ShowText("" + totalPages);
                totalPagesTemplate.EndText();
            }
            static void AddParagraphAtPosition(Paragraph paragraph, PdfContentByte canvas, float x, float y)
            {
                ColumnText columnText = new ColumnText(canvas);
                columnText.SetSimpleColumn(new Phrase(paragraph),
                    x, y, // Coordenadas X e Y
                    600, 36, // Ancho y altura máxima
                    10, // Espaciado
                    Element.ALIGN_CENTER); // Alineación
                columnText.Go();
            }

        }


        int contadordesalto_lab = 0;
        public void DOCUMENTO_LAB_PDF()
        {
            MENSAJE_GENERAL MN = new MENSAJE_GENERAL();
            MN.BOTON.Text = "PDF GENERADO";
            MN.ShowDialog();

            BaseColor blanco = new BaseColor(255, 255, 255);
            BaseColor negro = new BaseColor(10, 10, 10);
            BaseColor azul_claro = new BaseColor(197, 217, 241);
            BaseColor azul_oscuro = new BaseColor(83, 141, 213);
            BaseColor gris_oscuro_border = new BaseColor(176, 176, 176);

            iTextSharp.text.Font letra_negra_bold_8 = FontFactory.GetFont("Arial", 8, 1, negro);
            iTextSharp.text.Font letra_negra_bold_7 = FontFactory.GetFont("Arial", 7, 1, negro);
            iTextSharp.text.Font letra_negra_regular_7 = FontFactory.GetFont("Arial", 7, 0, negro);
            iTextSharp.text.Font letra_negra_bold_6 = FontFactory.GetFont("Arial", 6, 1, negro);
            iTextSharp.text.Font letra_negra_regular_6 = FontFactory.GetFont("Arial", 6, 0, negro);


            string documentos = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string nombrePDF;

            contadordesalto_lab = -1;


            if (encabeza_lab == true)
            {
                nombrePDF = "EE-LAB-21-" + CLAVE_OBRA.Texts + "-E-" + NO_INFORME.Texts.ToUpper() + ".pdf";
            }
            else if (sinencabeza_lab == true)
            {
                nombrePDF = "EE-LAB-21-" + CLAVE_OBRA.Texts + "-D-" + NO_INFORME.Texts.ToUpper() + ".pdf";
            }
            else
            {
                nombrePDF = "DENSIMETRO ELECTROMAGNETICO - GENERICO.pdf";
            }


            string PDF = System.IO.Path.Combine(documentos, nombrePDF);
            iTextSharp.text.Document doc = new iTextSharp.text.Document(iTextSharp.text.PageSize.LETTER);
            doc.SetMargins(36, 36, 86, 80);  //left - rigth - top - bottom

            PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(PDF, FileMode.Create));
            PAGE_LAB encabezados = new PAGE_LAB(firmaBytes, firma2Bytes);
            writer.PageEvent = encabezados;

            doc.Open();


            //==== INFORMACION GENERAL ====
            // No. DE INFORME
            try
            {
                PdfPTable table2 = new PdfPTable(25);
                table2.TotalWidth = 560;
                table2.LockedWidth = true;
                table2.SpacingBefore = 0;
                table2.SpacingAfter = 0;

                PdfPCell cell2 = new PdfPCell(new Phrase("", letra_negra_bold_7));
                cell2.BackgroundColor = blanco;
                cell2.BorderColor = blanco;
                cell2.HorizontalAlignment = Element.ALIGN_LEFT;
                cell2.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell2.PaddingTop = 1f;
                cell2.PaddingBottom = 4f;
                cell2.PaddingLeft = 3f;
                cell2.Colspan = 17;
                table2.AddCell(cell2);

                cell2 = new PdfPCell(new Phrase("No. DE INFORME:", letra_negra_bold_7));
                cell2.BackgroundColor = azul_oscuro;
                cell2.BorderColor = gris_oscuro_border;
                cell2.BorderWidth = 0.7f;
                cell2.HorizontalAlignment = Element.ALIGN_LEFT;
                cell2.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell2.PaddingTop = 1f;
                cell2.PaddingBottom = 3f;
                cell2.PaddingLeft = 3f;
                cell2.Colspan = 4;
                table2.AddCell(cell2);

                cell2 = new PdfPCell(new Phrase("LIE.DE." + NO_INFORME.Texts, letra_negra_regular_7));
                cell2.BackgroundColor = blanco;
                cell2.BorderColor = gris_oscuro_border;
                cell2.BorderWidth = 0.7f;
                cell2.HorizontalAlignment = Element.ALIGN_CENTER;
                cell2.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell2.PaddingTop = 1f;
                cell2.PaddingBottom = 3f;
                cell2.PaddingLeft = 1f;
                cell2.Colspan = 4;
                table2.AddCell(cell2);

                doc.Add(table2);
            }
            catch { }
            // FECHA DE ENSAYE
            try
            {
                PdfPTable table2 = new PdfPTable(25);
                table2.TotalWidth = 560;
                table2.LockedWidth = true;
                table2.SpacingBefore = 0;
                table2.SpacingAfter = 0;

                PdfPCell cell2 = new PdfPCell(new Phrase("FECHA DE INFORME:", letra_negra_bold_7));
                cell2.BackgroundColor = azul_oscuro;
                cell2.BorderColor = gris_oscuro_border;
                cell2.BorderWidth = 0.7f;
                cell2.HorizontalAlignment = Element.ALIGN_LEFT;
                cell2.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell2.PaddingTop = 1f;
                cell2.PaddingBottom = 3f;
                cell2.PaddingLeft = 3f;
                cell2.Colspan = 4;
                table2.AddCell(cell2);

                cell2 = new PdfPCell(new Phrase(FECHA_INFORME.Text, letra_negra_regular_7));
                cell2.BackgroundColor = blanco;
                cell2.BorderColor = gris_oscuro_border;
                cell2.BorderWidth = 0.7f;
                cell2.HorizontalAlignment = Element.ALIGN_CENTER;
                cell2.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell2.PaddingTop = 1f;
                cell2.PaddingBottom = 3f;
                cell2.PaddingLeft = 2f;
                cell2.Colspan = 13;
                table2.AddCell(cell2);

                cell2 = new PdfPCell(new Phrase("CLAVE DE OBRA:", letra_negra_bold_7));
                cell2.BackgroundColor = azul_oscuro;
                cell2.BorderColor = gris_oscuro_border;
                cell2.BorderWidth = 0.7f;
                cell2.HorizontalAlignment = Element.ALIGN_LEFT;
                cell2.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell2.PaddingTop = 1f;
                cell2.PaddingBottom = 3f;
                cell2.PaddingLeft = 3f;
                cell2.Colspan = 4;
                table2.AddCell(cell2);

                cell2 = new PdfPCell(new Phrase(CLAVE_OBRA.Texts, letra_negra_bold_7));
                cell2.BackgroundColor = blanco;
                cell2.BorderColor = gris_oscuro_border;
                cell2.BorderWidth = 0.7f;
                cell2.HorizontalAlignment = Element.ALIGN_CENTER;
                cell2.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell2.PaddingTop = 1f;
                cell2.PaddingBottom = 3f;
                cell2.PaddingLeft = 1f;
                cell2.Colspan = 4;
                table2.AddCell(cell2);

                doc.Add(table2);
            }
            catch { }
            // CLIENTE
            try
            {
                PdfPTable table2 = new PdfPTable(25);
                table2.TotalWidth = 560;
                table2.LockedWidth = true;

                PdfPCell cell2 = new PdfPCell(new Phrase("CLIENTE:", letra_negra_bold_7));
                cell2.BackgroundColor = azul_oscuro;
                cell2.BorderColor = gris_oscuro_border;
                cell2.BorderWidth = 0.7f;
                cell2.HorizontalAlignment = Element.ALIGN_LEFT;
                cell2.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell2.PaddingTop = 1f;
                cell2.PaddingBottom = 4f;
                cell2.PaddingLeft = 3f;
                cell2.Colspan = 2;
                cell2.FixedHeight = 22f;
                table2.AddCell(cell2);


                string textoCliente = CLIENTE.Texts.ToUpper();
                float tamañoFuente = 7f;
                float tamañoMinimo = 5.5f;
                float anchoCelda = (560f / 18f) * 16f - 4f;  //560->TotalWidth = 560;  // 18f->PdfPTable table2 = new PdfPTable(14);  //   16f->cell2.Colspan = 8;  // 4f ->padding interno de la celda

                BaseFont bf = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, false);
                while (tamañoFuente >= tamañoMinimo)
                {
                    float anchoTexto = bf.GetWidthPoint(textoCliente, tamañoFuente);

                    if (anchoTexto <= anchoCelda)
                        break;

                    tamañoFuente -= 0.2f;
                }
                Font letraDinamica = new Font(bf, tamañoFuente, 1, negro);

                cell2 = new PdfPCell(new Phrase(textoCliente, letraDinamica));
                cell2.BackgroundColor = blanco;
                cell2.BorderColor = gris_oscuro_border;
                cell2.BorderWidth = 0.7f;
                cell2.HorizontalAlignment = Element.ALIGN_CENTER;
                cell2.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell2.PaddingTop = 1f;
                cell2.PaddingBottom = 4f;
                cell2.PaddingLeft = 1f;
                cell2.Colspan = 23;
                table2.AddCell(cell2);

                doc.Add(table2);
            }
            catch { }
            // OBRA
            try
            {
                PdfPTable table2 = new PdfPTable(18);
                table2.TotalWidth = 560;
                table2.LockedWidth = true;

                PdfPCell cell2 = new PdfPCell(new Phrase("OBRA:", letra_negra_bold_7));
                cell2.BackgroundColor = azul_oscuro;
                cell2.BorderColor = gris_oscuro_border;
                cell2.BorderWidth = 0.7f;
                cell2.HorizontalAlignment = Element.ALIGN_LEFT;
                cell2.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell2.PaddingTop = 1f;
                cell2.PaddingBottom = 4f;
                cell2.PaddingLeft = 3f;
                cell2.Colspan = 2;
                cell2.FixedHeight = 37f;
                table2.AddCell(cell2);


                string textoObra = OBRA.Texts.ToUpper();
                float tamañoFuente = 7f;
                float tamañoMinimo = 5.9f;
                float anchoCelda = (560f / 18f) * 16f - 4f;  //560->TotalWidth = 560;  // 18f->PdfPTable table2 = new PdfPTable(14);  //   16f->cell2.Colspan = 8;  // 4f ->padding interno de la celda

                BaseFont bf = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, false);
                while (tamañoFuente >= tamañoMinimo)
                {
                    float anchoTexto = bf.GetWidthPoint(textoObra, tamañoFuente);

                    if (anchoTexto <= anchoCelda)
                        break;

                    tamañoFuente -= 0.2f;
                }
                Font letraDinamica = new Font(bf, tamañoFuente, 1, negro);

                cell2 = new PdfPCell(new Phrase(textoObra, letraDinamica));
                cell2.BackgroundColor = blanco;
                cell2.BorderColor = gris_oscuro_border;
                cell2.BorderWidth = 0.7f;
                cell2.HorizontalAlignment = Element.ALIGN_CENTER;
                cell2.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell2.PaddingTop = 1f;
                cell2.PaddingBottom = 4f;
                cell2.PaddingLeft = 1f;
                cell2.Colspan = 16;
                table2.AddCell(cell2);

                doc.Add(table2);
            }
            catch { }
            // CON ATENCIÓN A
            try
            {
                PdfPTable table2 = new PdfPTable(25);
                table2.TotalWidth = 560;
                table2.LockedWidth = true;
                table2.SpacingBefore = 0;
                table2.SpacingAfter = 0;

                PdfPCell cell2 = new PdfPCell(new Phrase("CON ATENCIÓN A:", letra_negra_bold_7));
                cell2.BackgroundColor = azul_oscuro;
                cell2.BorderColor = gris_oscuro_border;
                cell2.BorderWidth = 0.7f;
                cell2.HorizontalAlignment = Element.ALIGN_LEFT;
                cell2.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell2.PaddingTop = 1f;
                cell2.PaddingBottom = 3f;
                cell2.PaddingLeft = 3f;
                cell2.Colspan = 4;
                cell2.FixedHeight = 20f;
                table2.AddCell(cell2);

                cell2 = new PdfPCell(new Phrase(ATENCION.Texts, letra_negra_bold_7));
                cell2.BackgroundColor = blanco;
                cell2.BorderColor = gris_oscuro_border;
                cell2.BorderWidth = 0.7f;
                cell2.HorizontalAlignment = Element.ALIGN_CENTER;
                cell2.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell2.PaddingTop = 1f;
                cell2.PaddingBottom = 4f;
                cell2.PaddingLeft = 2f;
                cell2.Colspan = 13;
                table2.AddCell(cell2);

                cell2 = new PdfPCell(new Phrase("FECHA DE PRUEBA:", letra_negra_bold_7));
                cell2.BackgroundColor = azul_oscuro;
                cell2.BorderColor = gris_oscuro_border;
                cell2.BorderWidth = 0.7f;
                cell2.HorizontalAlignment = Element.ALIGN_LEFT;
                cell2.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell2.PaddingTop = 1f;
                cell2.PaddingBottom = 3f;
                cell2.PaddingLeft = 3f;
                cell2.Colspan = 4;
                table2.AddCell(cell2);

                cell2 = new PdfPCell(new Phrase(FECHA_ENSAYE.Text, letra_negra_regular_7));
                cell2.BackgroundColor = blanco;
                cell2.BorderColor = gris_oscuro_border;
                cell2.BorderWidth = 0.7f;
                cell2.HorizontalAlignment = Element.ALIGN_CENTER;
                cell2.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell2.PaddingTop = 1f;
                cell2.PaddingBottom = 3f;
                cell2.PaddingLeft = 1f;
                cell2.Colspan = 4;
                table2.AddCell(cell2);

                doc.Add(table2);
            }
            catch { }
            // DATOS DE PROYECTO
            try
            {
                PdfPTable table2 = new PdfPTable(14);
                table2.TotalWidth = 560;
                table2.LockedWidth = true;
                table2.SpacingBefore = 8;
                table2.SpacingAfter = 0;

                PdfPCell cell2 = new PdfPCell(new Phrase("DATOS DE PROYECTO", letra_negra_bold_7));
                cell2.BackgroundColor = azul_oscuro;
                cell2.BorderColor = azul_oscuro;
                cell2.BorderWidth = 0.7f;
                cell2.HorizontalAlignment = Element.ALIGN_CENTER;
                cell2.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell2.PaddingTop = 1f;
                cell2.PaddingBottom = 3f;
                cell2.PaddingLeft = 1f;
                cell2.Colspan = 14;
                table2.AddCell(cell2);

                doc.Add(table2);
            }
            catch { }
            // TIPO DE ENSAYE:
            try
            {
                PdfPTable table2 = new PdfPTable(25);
                table2.TotalWidth = 560;
                table2.LockedWidth = true;
                table2.SpacingBefore = 0;
                table2.SpacingAfter = 0;

                PdfPCell cell2 = new PdfPCell(new Phrase("TIPO DE ENSAYE:", letra_negra_bold_7));
                cell2.BackgroundColor = azul_claro;
                cell2.BorderColor = azul_oscuro;
                cell2.BorderWidth = 0.7f;
                cell2.HorizontalAlignment = Element.ALIGN_LEFT;
                cell2.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell2.PaddingTop = 1f;
                cell2.PaddingBottom = 3f;
                cell2.PaddingLeft = 3f;
                cell2.Colspan = 4;
                table2.AddCell(cell2);

                cell2 = new PdfPCell(new Phrase(TIPO_ENSAYE.Texts, letra_negra_bold_7));
                cell2.BackgroundColor = blanco;
                cell2.BorderColor = azul_oscuro;
                cell2.BorderWidth = 0.7f;
                cell2.HorizontalAlignment = Element.ALIGN_CENTER;
                cell2.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell2.PaddingTop = 1f;
                cell2.PaddingBottom = 3f;
                cell2.PaddingLeft = 2f;
                cell2.Colspan = 9;
                table2.AddCell(cell2);

                cell2 = new PdfPCell(new Phrase("% DE COMPACTACIÓN DEL PROYECTO:", letra_negra_bold_7));
                cell2.BackgroundColor = azul_claro;
                cell2.BorderColor = azul_oscuro;
                cell2.BorderWidth = 0.7f;
                cell2.HorizontalAlignment = Element.ALIGN_LEFT;
                cell2.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell2.PaddingTop = 1f;
                cell2.PaddingBottom = 3f;
                cell2.PaddingLeft = 3f;
                cell2.Colspan = 8;
                table2.AddCell(cell2);

                cell2 = new PdfPCell(new Phrase(COMPACTACION_PROYECTO.Texts, letra_negra_bold_7));
                cell2.BackgroundColor = blanco;
                cell2.BorderColor = azul_oscuro;
                cell2.BorderWidth = 0.7f;
                cell2.HorizontalAlignment = Element.ALIGN_CENTER;
                cell2.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell2.PaddingTop = 1f;
                cell2.PaddingBottom = 3f;
                cell2.PaddingLeft = 1f;
                cell2.Colspan = 4;
                table2.AddCell(cell2);

                doc.Add(table2);
            }
            catch { }
            // TIPO DE CAPA:
            try
            {
                PdfPTable table2 = new PdfPTable(25);
                table2.TotalWidth = 560;
                table2.LockedWidth = true;
                table2.SpacingBefore = 0;
                table2.SpacingAfter = 0;

                PdfPCell cell2 = new PdfPCell(new Phrase("TIPO DE CAPA:", letra_negra_bold_7));
                cell2.BackgroundColor = azul_claro;
                cell2.BorderColor = azul_oscuro;
                cell2.BorderWidth = 0.7f;
                cell2.HorizontalAlignment = Element.ALIGN_LEFT;
                cell2.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell2.PaddingTop = 1f;
                cell2.PaddingBottom = 3f;
                cell2.PaddingLeft = 3f;
                cell2.Colspan = 4;
                table2.AddCell(cell2);

                cell2 = new PdfPCell(new Phrase(TIPO_CAPA.Texts, letra_negra_bold_7));
                cell2.BackgroundColor = blanco;
                cell2.BorderColor = azul_oscuro;
                cell2.BorderWidth = 0.7f;
                cell2.HorizontalAlignment = Element.ALIGN_CENTER;
                cell2.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell2.PaddingTop = 1f;
                cell2.PaddingBottom = 3f;
                cell2.PaddingLeft = 2f;
                cell2.Colspan = 9;
                table2.AddCell(cell2);

                cell2 = new PdfPCell(new Phrase("MASA VOLUMÉTRICA SECA MÁXIMA, kg·m⁻³:", letra_negra_bold_7));
                cell2.BackgroundColor = azul_claro;
                cell2.BorderColor = azul_oscuro;
                cell2.BorderWidth = 0.7f;
                cell2.HorizontalAlignment = Element.ALIGN_LEFT;
                cell2.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell2.PaddingTop = 1f;
                cell2.PaddingBottom = 3f;
                cell2.PaddingLeft = 3f;
                cell2.Colspan = 8;
                table2.AddCell(cell2);

                cell2 = new PdfPCell(new Phrase(MVSM.Texts, letra_negra_bold_7));
                cell2.BackgroundColor = blanco;
                cell2.BorderColor = azul_oscuro;
                cell2.BorderWidth = 0.7f;
                cell2.HorizontalAlignment = Element.ALIGN_CENTER;
                cell2.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell2.PaddingTop = 1f;
                cell2.PaddingBottom = 3f;
                cell2.PaddingLeft = 1f;
                cell2.Colspan = 4;
                table2.AddCell(cell2);

                doc.Add(table2);
            }
            catch { }
            // PROCEDENCIA:
            try
            {
                PdfPTable table2 = new PdfPTable(25);
                table2.TotalWidth = 560;
                table2.LockedWidth = true;
                table2.SpacingBefore = 0;
                table2.SpacingAfter = 0;

                PdfPCell cell2 = new PdfPCell(new Phrase("PROCEDENCIA:", letra_negra_bold_7));
                cell2.BackgroundColor = azul_claro;
                cell2.BorderColor = azul_oscuro;
                cell2.BorderWidth = 0.7f;
                cell2.HorizontalAlignment = Element.ALIGN_LEFT;
                cell2.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell2.PaddingTop = 1f;
                cell2.PaddingBottom = 4f;
                cell2.PaddingLeft = 3f;
                cell2.Colspan = 4;
                cell2.FixedHeight = 18f;
                table2.AddCell(cell2);

                cell2 = new PdfPCell(new Phrase(PROCEDENCIA.Texts, letra_negra_regular_7));
                cell2.BackgroundColor = blanco;
                cell2.BorderColor = azul_oscuro;
                cell2.BorderWidth = 0.7f;
                cell2.HorizontalAlignment = Element.ALIGN_CENTER;
                cell2.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell2.PaddingTop = 1f;
                cell2.PaddingBottom = 4f;
                cell2.PaddingLeft = 1f;
                cell2.Colspan = 13;
                table2.AddCell(cell2);

                cell2 = new PdfPCell(new Phrase("HUMEDAD OPTIMA, %:", letra_negra_bold_7));
                cell2.BackgroundColor = azul_claro;
                cell2.BorderColor = azul_oscuro;
                cell2.BorderWidth = 0.7f;
                cell2.HorizontalAlignment = Element.ALIGN_CENTER;
                cell2.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell2.PaddingTop = 1f;
                cell2.PaddingBottom = 4f;
                cell2.PaddingLeft = 1f;
                cell2.Colspan = 4;
                table2.AddCell(cell2);

                cell2 = new PdfPCell(new Phrase(HUMEDAD_OPTIMA.Texts, letra_negra_bold_7));
                cell2.BackgroundColor = blanco;
                cell2.BorderColor = azul_oscuro;
                cell2.BorderWidth = 0.7f;
                cell2.HorizontalAlignment = Element.ALIGN_CENTER;
                cell2.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell2.PaddingTop = 1f;
                cell2.PaddingBottom = 4f;
                cell2.PaddingLeft = 1f;
                cell2.Colspan = 4;
                table2.AddCell(cell2);

                doc.Add(table2);
            }
            catch { }
            // DATOS DEL EQUIPO
            try
            {
                PdfPTable table2 = new PdfPTable(14);
                table2.TotalWidth = 560;
                table2.LockedWidth = true;
                table2.SpacingBefore = 8;
                table2.SpacingAfter = 0;

                PdfPCell cell2 = new PdfPCell(new Phrase("DATOS DEL EQUIPO", letra_negra_bold_7));
                cell2.BackgroundColor = azul_oscuro;
                cell2.BorderColor = azul_oscuro;
                cell2.BorderWidth = 0.7f;
                cell2.HorizontalAlignment = Element.ALIGN_CENTER;
                cell2.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell2.PaddingTop = 1f;
                cell2.PaddingBottom = 3f;
                cell2.PaddingLeft = 1f;
                cell2.Colspan = 14;
                table2.AddCell(cell2);

                doc.Add(table2);
            }
            catch { }
            // EQUIPO:
            try
            {
                PdfPTable table2 = new PdfPTable(25);
                table2.TotalWidth = 560;
                table2.LockedWidth = true;
                table2.SpacingBefore = 0;
                table2.SpacingAfter = 0;

                PdfPCell cell2 = new PdfPCell(new Phrase("EQUIPO:", letra_negra_bold_7));
                cell2.BackgroundColor = azul_claro;
                cell2.BorderColor = azul_oscuro;
                cell2.BorderWidth = 0.7f;
                cell2.HorizontalAlignment = Element.ALIGN_CENTER;
                cell2.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell2.PaddingTop = 1f;
                cell2.PaddingBottom = 3f;
                cell2.PaddingLeft = 1f;
                cell2.Colspan = 4;
                cell2.FixedHeight = 18f;
                table2.AddCell(cell2);

                cell2 = new PdfPCell(new Phrase(MEDIDOR.Texts, letra_negra_regular_7));
                cell2.BackgroundColor = blanco;
                cell2.BorderColor = azul_oscuro;
                cell2.BorderWidth = 0.7f;
                cell2.HorizontalAlignment = Element.ALIGN_CENTER;
                cell2.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell2.PaddingTop = 1f;
                cell2.PaddingBottom = 3f;
                cell2.PaddingLeft = 1f;
                cell2.Colspan = 5;
                table2.AddCell(cell2);

                cell2 = new PdfPCell(new Phrase("MODELO:", letra_negra_bold_7));
                cell2.BackgroundColor = azul_claro;
                cell2.BorderColor = azul_oscuro;
                cell2.BorderWidth = 0.7f;
                cell2.HorizontalAlignment = Element.ALIGN_CENTER;
                cell2.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell2.PaddingTop = 1f;
                cell2.PaddingBottom = 3f;
                cell2.PaddingLeft = 1f;
                cell2.Colspan = 4;
                table2.AddCell(cell2);

                cell2 = new PdfPCell(new Phrase(MODELO.Texts, letra_negra_regular_7));
                cell2.BackgroundColor = blanco;
                cell2.BorderColor = azul_oscuro;
                cell2.BorderWidth = 0.7f;
                cell2.HorizontalAlignment = Element.ALIGN_CENTER;
                cell2.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell2.PaddingTop = 1f;
                cell2.PaddingBottom = 3f;
                cell2.PaddingLeft = 1f;
                cell2.Colspan = 4;
                table2.AddCell(cell2);

                cell2 = new PdfPCell(new Phrase("No. DE SERIE:", letra_negra_bold_7));
                cell2.BackgroundColor = azul_claro;
                cell2.BorderColor = azul_oscuro;
                cell2.BorderWidth = 0.7f;
                cell2.HorizontalAlignment = Element.ALIGN_CENTER;
                cell2.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell2.PaddingTop = 1f;
                cell2.PaddingBottom = 3f;
                cell2.PaddingLeft = 1f;
                cell2.Colspan = 4;
                table2.AddCell(cell2);

                cell2 = new PdfPCell(new Phrase(NO_SERIE.Texts, letra_negra_regular_7));
                cell2.BackgroundColor = blanco;
                cell2.BorderColor = azul_oscuro;
                cell2.BorderWidth = 0.7f;
                cell2.HorizontalAlignment = Element.ALIGN_CENTER;
                cell2.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell2.PaddingTop = 1f;
                cell2.PaddingBottom = 3f;
                cell2.PaddingLeft = 1f;
                cell2.Colspan = 4;
                table2.AddCell(cell2);

                doc.Add(table2);
            }
            catch { }
            // Nº SONDEO
            try
            {
                PdfPTable table2 = new PdfPTable(25);
                table2.TotalWidth = 560;
                table2.LockedWidth = true;
                table2.SpacingBefore = 8;
                table2.SpacingAfter = 0;

                PdfPCell cell2 = new PdfPCell(new Phrase("Nº SONDEO", letra_negra_bold_6));
                cell2.BackgroundColor = azul_oscuro;
                cell2.BorderColor = gris_oscuro_border;
                cell2.BorderWidth = 0.7f;
                cell2.HorizontalAlignment = Element.ALIGN_CENTER;
                cell2.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell2.PaddingTop = 1f;
                cell2.PaddingBottom = 3f;
                cell2.PaddingLeft = 1f;
                cell2.Colspan = 2;
                table2.AddCell(cell2);

                cell2 = new PdfPCell(new Phrase("LOCALIZACIÓN", letra_negra_bold_6));
                cell2.BackgroundColor = azul_oscuro;
                cell2.BorderColor = gris_oscuro_border;
                cell2.BorderWidth = 0.7f;
                cell2.HorizontalAlignment = Element.ALIGN_CENTER;
                cell2.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell2.PaddingTop = 1f;
                cell2.PaddingBottom = 3f;
                cell2.PaddingLeft = 1f;
                cell2.Colspan = 11;
                table2.AddCell(cell2);

                cell2 = new PdfPCell(new Phrase("CAPA", letra_negra_bold_6));
                cell2.BackgroundColor = azul_oscuro;
                cell2.BorderColor = gris_oscuro_border;
                cell2.BorderWidth = 0.7f;
                cell2.HorizontalAlignment = Element.ALIGN_CENTER;
                cell2.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell2.PaddingTop = 1f;
                cell2.PaddingBottom = 3f;
                cell2.PaddingLeft = 1f;
                cell2.Colspan = 2;
                table2.AddCell(cell2);

                cell2 = new PdfPCell(new Phrase("ESPESOR \r\ncm", letra_negra_bold_6));
                cell2.BackgroundColor = azul_oscuro;
                cell2.BorderColor = gris_oscuro_border;
                cell2.BorderWidth = 0.7f;
                cell2.HorizontalAlignment = Element.ALIGN_CENTER;
                cell2.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell2.PaddingTop = 1f;
                cell2.PaddingBottom = 3f;
                cell2.PaddingLeft = 1f;
                cell2.Colspan = 2;
                table2.AddCell(cell2);

                cell2 = new PdfPCell(new Phrase("HUMEDAD \r\nEN SITIO\r\n %", letra_negra_bold_6));
                cell2.BackgroundColor = azul_oscuro;
                cell2.BorderColor = gris_oscuro_border;
                cell2.BorderWidth = 0.7f;
                cell2.HorizontalAlignment = Element.ALIGN_CENTER;
                cell2.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell2.PaddingTop = 1f;
                cell2.PaddingBottom = 3f;
                cell2.PaddingLeft = 1f;
                cell2.Colspan = 2;
                table2.AddCell(cell2);

                cell2 = new PdfPCell(new Phrase("MASA VOLUMÉTRICA SECA EN SITIO\r\nkg·m⁻³", letra_negra_bold_6));
                cell2.BackgroundColor = azul_oscuro;
                cell2.BorderColor = gris_oscuro_border;
                cell2.BorderWidth = 0.7f;
                cell2.HorizontalAlignment = Element.ALIGN_CENTER;
                cell2.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell2.PaddingTop = 1f;
                cell2.PaddingBottom = 3f;
                cell2.PaddingLeft = 1f;
                cell2.Colspan = 3;
                table2.AddCell(cell2);

                cell2 = new PdfPCell(new Phrase("% DE COMPACTACIÓN", letra_negra_bold_6));
                cell2.BackgroundColor = azul_oscuro;
                cell2.BorderColor = gris_oscuro_border;
                cell2.BorderWidth = 0.7f;
                cell2.HorizontalAlignment = Element.ALIGN_CENTER;
                cell2.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell2.PaddingTop = 1f;
                cell2.PaddingBottom = 3f;
                cell2.PaddingLeft = 1f;
                cell2.Colspan = 3;
                table2.AddCell(cell2);

                doc.Add(table2);
            }
            catch { }


            int paginaActual = 1;  //AUMENTA HEIGHT A LAS FILAS DE LA SEGUNDA HOJA
            foreach (DataGridViewRow dr in DGV_PADRON.Rows)
            {
                if (contadordesalto_lab == 9)
                {
                    doc.NewPage();  //SE AGREGAN INTERMEDIO
                    paginaActual++;

                    // No. DE INFORME
                    try
                    {
                        PdfPTable table2 = new PdfPTable(25);
                        table2.TotalWidth = 560;
                        table2.LockedWidth = true;
                        table2.SpacingBefore = 0;
                        table2.SpacingAfter = 0;

                        PdfPCell cell2 = new PdfPCell(new Phrase("", letra_negra_bold_7));
                        cell2.BackgroundColor = blanco;
                        cell2.BorderColor = blanco;
                        cell2.HorizontalAlignment = Element.ALIGN_LEFT;
                        cell2.VerticalAlignment = Element.ALIGN_MIDDLE;
                        cell2.PaddingTop = 1f;
                        cell2.PaddingBottom = 4f;
                        cell2.PaddingLeft = 3f;
                        cell2.Colspan = 17;
                        table2.AddCell(cell2);

                        cell2 = new PdfPCell(new Phrase("No. DE INFORME:", letra_negra_bold_7));
                        cell2.BackgroundColor = azul_oscuro;
                        cell2.BorderColor = gris_oscuro_border;
                        cell2.BorderWidth = 0.7f;
                        cell2.HorizontalAlignment = Element.ALIGN_LEFT;
                        cell2.VerticalAlignment = Element.ALIGN_MIDDLE;
                        cell2.PaddingTop = 1f;
                        cell2.PaddingBottom = 3f;
                        cell2.PaddingLeft = 3f;
                        cell2.Colspan = 4;
                        table2.AddCell(cell2);

                        cell2 = new PdfPCell(new Phrase("LIE.DE." + NO_INFORME.Texts, letra_negra_regular_7));
                        cell2.BackgroundColor = blanco;
                        cell2.BorderColor = gris_oscuro_border;
                        cell2.BorderWidth = 0.7f;
                        cell2.HorizontalAlignment = Element.ALIGN_CENTER;
                        cell2.VerticalAlignment = Element.ALIGN_MIDDLE;
                        cell2.PaddingTop = 1f;
                        cell2.PaddingBottom = 3f;
                        cell2.PaddingLeft = 1f;
                        cell2.Colspan = 4;
                        table2.AddCell(cell2);

                        doc.Add(table2);
                    }
                    catch { }
                    // FECHA DE ENSAYE
                    try
                    {
                        PdfPTable table2 = new PdfPTable(25);
                        table2.TotalWidth = 560;
                        table2.LockedWidth = true;
                        table2.SpacingBefore = 0;
                        table2.SpacingAfter = 0;

                        PdfPCell cell2 = new PdfPCell(new Phrase("FECHA DE INFORME:", letra_negra_bold_7));
                        cell2.BackgroundColor = azul_oscuro;
                        cell2.BorderColor = gris_oscuro_border;
                        cell2.BorderWidth = 0.7f;
                        cell2.HorizontalAlignment = Element.ALIGN_LEFT;
                        cell2.VerticalAlignment = Element.ALIGN_MIDDLE;
                        cell2.PaddingTop = 1f;
                        cell2.PaddingBottom = 3f;
                        cell2.PaddingLeft = 3f;
                        cell2.Colspan = 4;
                        table2.AddCell(cell2);

                        cell2 = new PdfPCell(new Phrase(FECHA_INFORME.Text, letra_negra_regular_7));
                        cell2.BackgroundColor = blanco;
                        cell2.BorderColor = gris_oscuro_border;
                        cell2.BorderWidth = 0.7f;
                        cell2.HorizontalAlignment = Element.ALIGN_CENTER;
                        cell2.VerticalAlignment = Element.ALIGN_MIDDLE;
                        cell2.PaddingTop = 1f;
                        cell2.PaddingBottom = 3f;
                        cell2.PaddingLeft = 2f;
                        cell2.Colspan = 13;
                        table2.AddCell(cell2);

                        cell2 = new PdfPCell(new Phrase("CLAVE DE OBRA:", letra_negra_bold_7));
                        cell2.BackgroundColor = azul_oscuro;
                        cell2.BorderColor = gris_oscuro_border;
                        cell2.BorderWidth = 0.7f;
                        cell2.HorizontalAlignment = Element.ALIGN_LEFT;
                        cell2.VerticalAlignment = Element.ALIGN_MIDDLE;
                        cell2.PaddingTop = 1f;
                        cell2.PaddingBottom = 3f;
                        cell2.PaddingLeft = 3f;
                        cell2.Colspan = 4;
                        table2.AddCell(cell2);

                        cell2 = new PdfPCell(new Phrase(CLAVE_OBRA.Texts, letra_negra_bold_7));
                        cell2.BackgroundColor = blanco;
                        cell2.BorderColor = gris_oscuro_border;
                        cell2.BorderWidth = 0.7f;
                        cell2.HorizontalAlignment = Element.ALIGN_CENTER;
                        cell2.VerticalAlignment = Element.ALIGN_MIDDLE;
                        cell2.PaddingTop = 1f;
                        cell2.PaddingBottom = 3f;
                        cell2.PaddingLeft = 1f;
                        cell2.Colspan = 4;
                        table2.AddCell(cell2);

                        doc.Add(table2);
                    }
                    catch { }
                    // CLIENTE
                    try
                    {
                        PdfPTable table2 = new PdfPTable(25);
                        table2.TotalWidth = 560;
                        table2.LockedWidth = true;

                        PdfPCell cell2 = new PdfPCell(new Phrase("CLIENTE:", letra_negra_bold_7));
                        cell2.BackgroundColor = azul_oscuro;
                        cell2.BorderColor = gris_oscuro_border;
                        cell2.BorderWidth = 0.7f;
                        cell2.HorizontalAlignment = Element.ALIGN_LEFT;
                        cell2.VerticalAlignment = Element.ALIGN_MIDDLE;
                        cell2.PaddingTop = 1f;
                        cell2.PaddingBottom = 4f;
                        cell2.PaddingLeft = 3f;
                        cell2.Colspan = 2;
                        cell2.FixedHeight = 22f;
                        table2.AddCell(cell2);


                        string textoCliente = CLIENTE.Texts.ToUpper();
                        float tamañoFuente = 7f;
                        float tamañoMinimo = 5.5f;
                        float anchoCelda = (560f / 18f) * 16f - 4f;  //560->TotalWidth = 560;  // 18f->PdfPTable table2 = new PdfPTable(14);  //   16f->cell2.Colspan = 8;  // 4f ->padding interno de la celda

                        BaseFont bf = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, false);
                        while (tamañoFuente >= tamañoMinimo)
                        {
                            float anchoTexto = bf.GetWidthPoint(textoCliente, tamañoFuente);

                            if (anchoTexto <= anchoCelda)
                                break;

                            tamañoFuente -= 0.2f;
                        }
                        Font letraDinamica = new Font(bf, tamañoFuente, 1, negro);

                        cell2 = new PdfPCell(new Phrase(textoCliente, letraDinamica));
                        cell2.BackgroundColor = blanco;
                        cell2.BorderColor = gris_oscuro_border;
                        cell2.BorderWidth = 0.7f;
                        cell2.HorizontalAlignment = Element.ALIGN_CENTER;
                        cell2.VerticalAlignment = Element.ALIGN_MIDDLE;
                        cell2.PaddingTop = 1f;
                        cell2.PaddingBottom = 4f;
                        cell2.PaddingLeft = 1f;
                        cell2.Colspan = 23;
                        table2.AddCell(cell2);

                        doc.Add(table2);
                    }
                    catch { }
                    // OBRA
                    try
                    {
                        PdfPTable table2 = new PdfPTable(18);
                        table2.TotalWidth = 560;
                        table2.LockedWidth = true;

                        PdfPCell cell2 = new PdfPCell(new Phrase("OBRA:", letra_negra_bold_7));
                        cell2.BackgroundColor = azul_oscuro;
                        cell2.BorderColor = gris_oscuro_border;
                        cell2.BorderWidth = 0.7f;
                        cell2.HorizontalAlignment = Element.ALIGN_LEFT;
                        cell2.VerticalAlignment = Element.ALIGN_MIDDLE;
                        cell2.PaddingTop = 1f;
                        cell2.PaddingBottom = 4f;
                        cell2.PaddingLeft = 3f;
                        cell2.Colspan = 2;
                        cell2.FixedHeight = 37f;
                        table2.AddCell(cell2);


                        string textoObra = OBRA.Texts.ToUpper();
                        float tamañoFuente = 7f;
                        float tamañoMinimo = 5.9f;
                        float anchoCelda = (560f / 18f) * 16f - 4f;  //560->TotalWidth = 560;  // 18f->PdfPTable table2 = new PdfPTable(14);  //   16f->cell2.Colspan = 8;  // 4f ->padding interno de la celda

                        BaseFont bf = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, false);
                        while (tamañoFuente >= tamañoMinimo)
                        {
                            float anchoTexto = bf.GetWidthPoint(textoObra, tamañoFuente);

                            if (anchoTexto <= anchoCelda)
                                break;

                            tamañoFuente -= 0.2f;
                        }
                        Font letraDinamica = new Font(bf, tamañoFuente, 1, negro);

                        cell2 = new PdfPCell(new Phrase(textoObra, letraDinamica));
                        cell2.BackgroundColor = blanco;
                        cell2.BorderColor = gris_oscuro_border;
                        cell2.BorderWidth = 0.7f;
                        cell2.HorizontalAlignment = Element.ALIGN_CENTER;
                        cell2.VerticalAlignment = Element.ALIGN_MIDDLE;
                        cell2.PaddingTop = 1f;
                        cell2.PaddingBottom = 4f;
                        cell2.PaddingLeft = 1f;
                        cell2.Colspan = 16;
                        table2.AddCell(cell2);

                        doc.Add(table2);
                    }
                    catch { }
                    // CON ATENCIÓN A
                    try
                    {
                        PdfPTable table2 = new PdfPTable(25);
                        table2.TotalWidth = 560;
                        table2.LockedWidth = true;
                        table2.SpacingBefore = 0;
                        table2.SpacingAfter = 0;

                        PdfPCell cell2 = new PdfPCell(new Phrase("CON ATENCIÓN A:", letra_negra_bold_7));
                        cell2.BackgroundColor = azul_oscuro;
                        cell2.BorderColor = gris_oscuro_border;
                        cell2.BorderWidth = 0.7f;
                        cell2.HorizontalAlignment = Element.ALIGN_LEFT;
                        cell2.VerticalAlignment = Element.ALIGN_MIDDLE;
                        cell2.PaddingTop = 1f;
                        cell2.PaddingBottom = 3f;
                        cell2.PaddingLeft = 3f;
                        cell2.Colspan = 4;
                        cell2.FixedHeight = 20f;
                        table2.AddCell(cell2);

                        cell2 = new PdfPCell(new Phrase(ATENCION.Texts, letra_negra_bold_7));
                        cell2.BackgroundColor = blanco;
                        cell2.BorderColor = gris_oscuro_border;
                        cell2.BorderWidth = 0.7f;
                        cell2.HorizontalAlignment = Element.ALIGN_CENTER;
                        cell2.VerticalAlignment = Element.ALIGN_MIDDLE;
                        cell2.PaddingTop = 1f;
                        cell2.PaddingBottom = 4f;
                        cell2.PaddingLeft = 2f;
                        cell2.Colspan = 13;
                        table2.AddCell(cell2);

                        cell2 = new PdfPCell(new Phrase("FECHA DE PRUEBA:", letra_negra_bold_7));
                        cell2.BackgroundColor = azul_oscuro;
                        cell2.BorderColor = gris_oscuro_border;
                        cell2.BorderWidth = 0.7f;
                        cell2.HorizontalAlignment = Element.ALIGN_LEFT;
                        cell2.VerticalAlignment = Element.ALIGN_MIDDLE;
                        cell2.PaddingTop = 1f;
                        cell2.PaddingBottom = 3f;
                        cell2.PaddingLeft = 3f;
                        cell2.Colspan = 4;
                        table2.AddCell(cell2);

                        cell2 = new PdfPCell(new Phrase(FECHA_ENSAYE.Text, letra_negra_regular_7));
                        cell2.BackgroundColor = blanco;
                        cell2.BorderColor = gris_oscuro_border;
                        cell2.BorderWidth = 0.7f;
                        cell2.HorizontalAlignment = Element.ALIGN_CENTER;
                        cell2.VerticalAlignment = Element.ALIGN_MIDDLE;
                        cell2.PaddingTop = 1f;
                        cell2.PaddingBottom = 3f;
                        cell2.PaddingLeft = 1f;
                        cell2.Colspan = 4;
                        table2.AddCell(cell2);

                        doc.Add(table2);
                    }
                    catch { }
                    // DATOS DE PROYECTO
                    try
                    {
                        PdfPTable table2 = new PdfPTable(14);
                        table2.TotalWidth = 560;
                        table2.LockedWidth = true;
                        table2.SpacingBefore = 8;
                        table2.SpacingAfter = 0;

                        PdfPCell cell2 = new PdfPCell(new Phrase("DATOS DE PROYECTO", letra_negra_bold_7));
                        cell2.BackgroundColor = azul_oscuro;
                        cell2.BorderColor = azul_oscuro;
                        cell2.BorderWidth = 0.7f;
                        cell2.HorizontalAlignment = Element.ALIGN_CENTER;
                        cell2.VerticalAlignment = Element.ALIGN_MIDDLE;
                        cell2.PaddingTop = 1f;
                        cell2.PaddingBottom = 3f;
                        cell2.PaddingLeft = 1f;
                        cell2.Colspan = 14;
                        table2.AddCell(cell2);

                        doc.Add(table2);
                    }
                    catch { }
                    // TIPO DE ENSAYE:
                    try
                    {
                        PdfPTable table2 = new PdfPTable(25);
                        table2.TotalWidth = 560;
                        table2.LockedWidth = true;
                        table2.SpacingBefore = 0;
                        table2.SpacingAfter = 0;

                        PdfPCell cell2 = new PdfPCell(new Phrase("TIPO DE ENSAYE:", letra_negra_bold_7));
                        cell2.BackgroundColor = azul_claro;
                        cell2.BorderColor = azul_oscuro;
                        cell2.BorderWidth = 0.7f;
                        cell2.HorizontalAlignment = Element.ALIGN_LEFT;
                        cell2.VerticalAlignment = Element.ALIGN_MIDDLE;
                        cell2.PaddingTop = 1f;
                        cell2.PaddingBottom = 3f;
                        cell2.PaddingLeft = 3f;
                        cell2.Colspan = 4;
                        table2.AddCell(cell2);

                        cell2 = new PdfPCell(new Phrase(TIPO_ENSAYE.Texts, letra_negra_bold_7));
                        cell2.BackgroundColor = blanco;
                        cell2.BorderColor = azul_oscuro;
                        cell2.BorderWidth = 0.7f;
                        cell2.HorizontalAlignment = Element.ALIGN_CENTER;
                        cell2.VerticalAlignment = Element.ALIGN_MIDDLE;
                        cell2.PaddingTop = 1f;
                        cell2.PaddingBottom = 3f;
                        cell2.PaddingLeft = 2f;
                        cell2.Colspan = 9;
                        table2.AddCell(cell2);

                        cell2 = new PdfPCell(new Phrase("% DE COMPACTACIÓN DEL PROYECTO:", letra_negra_bold_7));
                        cell2.BackgroundColor = azul_claro;
                        cell2.BorderColor = azul_oscuro;
                        cell2.BorderWidth = 0.7f;
                        cell2.HorizontalAlignment = Element.ALIGN_LEFT;
                        cell2.VerticalAlignment = Element.ALIGN_MIDDLE;
                        cell2.PaddingTop = 1f;
                        cell2.PaddingBottom = 3f;
                        cell2.PaddingLeft = 3f;
                        cell2.Colspan = 8;
                        table2.AddCell(cell2);

                        cell2 = new PdfPCell(new Phrase(COMPACTACION_PROYECTO.Texts, letra_negra_bold_7));
                        cell2.BackgroundColor = blanco;
                        cell2.BorderColor = azul_oscuro;
                        cell2.BorderWidth = 0.7f;
                        cell2.HorizontalAlignment = Element.ALIGN_CENTER;
                        cell2.VerticalAlignment = Element.ALIGN_MIDDLE;
                        cell2.PaddingTop = 1f;
                        cell2.PaddingBottom = 3f;
                        cell2.PaddingLeft = 1f;
                        cell2.Colspan = 4;
                        table2.AddCell(cell2);

                        doc.Add(table2);
                    }
                    catch { }
                    // TIPO DE CAPA:
                    try
                    {
                        PdfPTable table2 = new PdfPTable(25);
                        table2.TotalWidth = 560;
                        table2.LockedWidth = true;
                        table2.SpacingBefore = 0;
                        table2.SpacingAfter = 0;

                        PdfPCell cell2 = new PdfPCell(new Phrase("TIPO DE CAPA:", letra_negra_bold_7));
                        cell2.BackgroundColor = azul_claro;
                        cell2.BorderColor = azul_oscuro;
                        cell2.BorderWidth = 0.7f;
                        cell2.HorizontalAlignment = Element.ALIGN_LEFT;
                        cell2.VerticalAlignment = Element.ALIGN_MIDDLE;
                        cell2.PaddingTop = 1f;
                        cell2.PaddingBottom = 3f;
                        cell2.PaddingLeft = 3f;
                        cell2.Colspan = 4;
                        table2.AddCell(cell2);

                        cell2 = new PdfPCell(new Phrase(TIPO_CAPA.Texts, letra_negra_bold_7));
                        cell2.BackgroundColor = blanco;
                        cell2.BorderColor = azul_oscuro;
                        cell2.BorderWidth = 0.7f;
                        cell2.HorizontalAlignment = Element.ALIGN_CENTER;
                        cell2.VerticalAlignment = Element.ALIGN_MIDDLE;
                        cell2.PaddingTop = 1f;
                        cell2.PaddingBottom = 3f;
                        cell2.PaddingLeft = 2f;
                        cell2.Colspan = 9;
                        table2.AddCell(cell2);

                        cell2 = new PdfPCell(new Phrase("MASA VOLUMÉTRICA SECA MÁXIMA, kg·m⁻³:", letra_negra_bold_7));
                        cell2.BackgroundColor = azul_claro;
                        cell2.BorderColor = azul_oscuro;
                        cell2.BorderWidth = 0.7f;
                        cell2.HorizontalAlignment = Element.ALIGN_LEFT;
                        cell2.VerticalAlignment = Element.ALIGN_MIDDLE;
                        cell2.PaddingTop = 1f;
                        cell2.PaddingBottom = 3f;
                        cell2.PaddingLeft = 3f;
                        cell2.Colspan = 8;
                        table2.AddCell(cell2);

                        cell2 = new PdfPCell(new Phrase(MVSM.Texts, letra_negra_bold_7));
                        cell2.BackgroundColor = blanco;
                        cell2.BorderColor = azul_oscuro;
                        cell2.BorderWidth = 0.7f;
                        cell2.HorizontalAlignment = Element.ALIGN_CENTER;
                        cell2.VerticalAlignment = Element.ALIGN_MIDDLE;
                        cell2.PaddingTop = 1f;
                        cell2.PaddingBottom = 3f;
                        cell2.PaddingLeft = 1f;
                        cell2.Colspan = 4;
                        table2.AddCell(cell2);

                        doc.Add(table2);
                    }
                    catch { }
                    // PROCEDENCIA:
                    try
                    {
                        PdfPTable table2 = new PdfPTable(25);
                        table2.TotalWidth = 560;
                        table2.LockedWidth = true;
                        table2.SpacingBefore = 0;
                        table2.SpacingAfter = 0;

                        PdfPCell cell2 = new PdfPCell(new Phrase("PROCEDENCIA:", letra_negra_bold_7));
                        cell2.BackgroundColor = azul_claro;
                        cell2.BorderColor = azul_oscuro;
                        cell2.BorderWidth = 0.7f;
                        cell2.HorizontalAlignment = Element.ALIGN_LEFT;
                        cell2.VerticalAlignment = Element.ALIGN_MIDDLE;
                        cell2.PaddingTop = 1f;
                        cell2.PaddingBottom = 4f;
                        cell2.PaddingLeft = 3f;
                        cell2.Colspan = 4;
                        cell2.FixedHeight = 18f;
                        table2.AddCell(cell2);

                        cell2 = new PdfPCell(new Phrase(PROCEDENCIA.Texts, letra_negra_regular_7));
                        cell2.BackgroundColor = blanco;
                        cell2.BorderColor = azul_oscuro;
                        cell2.BorderWidth = 0.7f;
                        cell2.HorizontalAlignment = Element.ALIGN_CENTER;
                        cell2.VerticalAlignment = Element.ALIGN_MIDDLE;
                        cell2.PaddingTop = 1f;
                        cell2.PaddingBottom = 4f;
                        cell2.PaddingLeft = 1f;
                        cell2.Colspan = 13;
                        table2.AddCell(cell2);

                        cell2 = new PdfPCell(new Phrase("HUMEDAD OPTIMA, %:", letra_negra_bold_7));
                        cell2.BackgroundColor = azul_claro;
                        cell2.BorderColor = azul_oscuro;
                        cell2.BorderWidth = 0.7f;
                        cell2.HorizontalAlignment = Element.ALIGN_CENTER;
                        cell2.VerticalAlignment = Element.ALIGN_MIDDLE;
                        cell2.PaddingTop = 1f;
                        cell2.PaddingBottom = 4f;
                        cell2.PaddingLeft = 1f;
                        cell2.Colspan = 4;
                        table2.AddCell(cell2);

                        cell2 = new PdfPCell(new Phrase(HUMEDAD_OPTIMA.Texts, letra_negra_bold_7));
                        cell2.BackgroundColor = blanco;
                        cell2.BorderColor = azul_oscuro;
                        cell2.BorderWidth = 0.7f;
                        cell2.HorizontalAlignment = Element.ALIGN_CENTER;
                        cell2.VerticalAlignment = Element.ALIGN_MIDDLE;
                        cell2.PaddingTop = 1f;
                        cell2.PaddingBottom = 4f;
                        cell2.PaddingLeft = 1f;
                        cell2.Colspan = 4;
                        table2.AddCell(cell2);

                        doc.Add(table2);
                    }
                    catch { }
                    // DATOS DEL EQUIPO
                    try
                    {
                        PdfPTable table2 = new PdfPTable(14);
                        table2.TotalWidth = 560;
                        table2.LockedWidth = true;
                        table2.SpacingBefore = 8;
                        table2.SpacingAfter = 0;

                        PdfPCell cell2 = new PdfPCell(new Phrase("DATOS DEL EQUIPO", letra_negra_bold_7));
                        cell2.BackgroundColor = azul_oscuro;
                        cell2.BorderColor = azul_oscuro;
                        cell2.BorderWidth = 0.7f;
                        cell2.HorizontalAlignment = Element.ALIGN_CENTER;
                        cell2.VerticalAlignment = Element.ALIGN_MIDDLE;
                        cell2.PaddingTop = 1f;
                        cell2.PaddingBottom = 3f;
                        cell2.PaddingLeft = 1f;
                        cell2.Colspan = 14;
                        table2.AddCell(cell2);

                        doc.Add(table2);
                    }
                    catch { }
                    // EQUIPO:
                    try
                    {
                        PdfPTable table2 = new PdfPTable(25);
                        table2.TotalWidth = 560;
                        table2.LockedWidth = true;
                        table2.SpacingBefore = 0;
                        table2.SpacingAfter = 0;

                        PdfPCell cell2 = new PdfPCell(new Phrase("EQUIPO:", letra_negra_bold_7));
                        cell2.BackgroundColor = azul_claro;
                        cell2.BorderColor = azul_oscuro;
                        cell2.BorderWidth = 0.7f;
                        cell2.HorizontalAlignment = Element.ALIGN_CENTER;
                        cell2.VerticalAlignment = Element.ALIGN_MIDDLE;
                        cell2.PaddingTop = 1f;
                        cell2.PaddingBottom = 3f;
                        cell2.PaddingLeft = 1f;
                        cell2.Colspan = 4;
                        cell2.FixedHeight = 18f;
                        table2.AddCell(cell2);

                        cell2 = new PdfPCell(new Phrase(MEDIDOR.Texts, letra_negra_regular_7));
                        cell2.BackgroundColor = blanco;
                        cell2.BorderColor = azul_oscuro;
                        cell2.BorderWidth = 0.7f;
                        cell2.HorizontalAlignment = Element.ALIGN_CENTER;
                        cell2.VerticalAlignment = Element.ALIGN_MIDDLE;
                        cell2.PaddingTop = 1f;
                        cell2.PaddingBottom = 3f;
                        cell2.PaddingLeft = 1f;
                        cell2.Colspan = 5;
                        table2.AddCell(cell2);

                        cell2 = new PdfPCell(new Phrase("MODELO:", letra_negra_bold_7));
                        cell2.BackgroundColor = azul_claro;
                        cell2.BorderColor = azul_oscuro;
                        cell2.BorderWidth = 0.7f;
                        cell2.HorizontalAlignment = Element.ALIGN_CENTER;
                        cell2.VerticalAlignment = Element.ALIGN_MIDDLE;
                        cell2.PaddingTop = 1f;
                        cell2.PaddingBottom = 3f;
                        cell2.PaddingLeft = 1f;
                        cell2.Colspan = 4;
                        table2.AddCell(cell2);

                        cell2 = new PdfPCell(new Phrase(MODELO.Texts, letra_negra_regular_7));
                        cell2.BackgroundColor = blanco;
                        cell2.BorderColor = azul_oscuro;
                        cell2.BorderWidth = 0.7f;
                        cell2.HorizontalAlignment = Element.ALIGN_CENTER;
                        cell2.VerticalAlignment = Element.ALIGN_MIDDLE;
                        cell2.PaddingTop = 1f;
                        cell2.PaddingBottom = 3f;
                        cell2.PaddingLeft = 1f;
                        cell2.Colspan = 4;
                        table2.AddCell(cell2);

                        cell2 = new PdfPCell(new Phrase("No. DE SERIE:", letra_negra_bold_7));
                        cell2.BackgroundColor = azul_claro;
                        cell2.BorderColor = azul_oscuro;
                        cell2.BorderWidth = 0.7f;
                        cell2.HorizontalAlignment = Element.ALIGN_CENTER;
                        cell2.VerticalAlignment = Element.ALIGN_MIDDLE;
                        cell2.PaddingTop = 1f;
                        cell2.PaddingBottom = 3f;
                        cell2.PaddingLeft = 1f;
                        cell2.Colspan = 4;
                        table2.AddCell(cell2);

                        cell2 = new PdfPCell(new Phrase(NO_SERIE.Texts, letra_negra_regular_7));
                        cell2.BackgroundColor = blanco;
                        cell2.BorderColor = azul_oscuro;
                        cell2.BorderWidth = 0.7f;
                        cell2.HorizontalAlignment = Element.ALIGN_CENTER;
                        cell2.VerticalAlignment = Element.ALIGN_MIDDLE;
                        cell2.PaddingTop = 1f;
                        cell2.PaddingBottom = 3f;
                        cell2.PaddingLeft = 1f;
                        cell2.Colspan = 4;
                        table2.AddCell(cell2);

                        doc.Add(table2);
                    }
                    catch { }
                    // Nº SONDEO
                    try
                    {
                        PdfPTable table2 = new PdfPTable(25);
                        table2.TotalWidth = 560;
                        table2.LockedWidth = true;
                        table2.SpacingBefore = 8;
                        table2.SpacingAfter = 0;

                        PdfPCell cell2 = new PdfPCell(new Phrase("Nº SONDEO", letra_negra_bold_6));
                        cell2.BackgroundColor = azul_oscuro;
                        cell2.BorderColor = gris_oscuro_border;
                        cell2.BorderWidth = 0.7f;
                        cell2.HorizontalAlignment = Element.ALIGN_CENTER;
                        cell2.VerticalAlignment = Element.ALIGN_MIDDLE;
                        cell2.PaddingTop = 1f;
                        cell2.PaddingBottom = 3f;
                        cell2.PaddingLeft = 1f;
                        cell2.Colspan = 2;
                        table2.AddCell(cell2);

                        cell2 = new PdfPCell(new Phrase("LOCALIZACIÓN", letra_negra_bold_6));
                        cell2.BackgroundColor = azul_oscuro;
                        cell2.BorderColor = gris_oscuro_border;
                        cell2.BorderWidth = 0.7f;
                        cell2.HorizontalAlignment = Element.ALIGN_CENTER;
                        cell2.VerticalAlignment = Element.ALIGN_MIDDLE;
                        cell2.PaddingTop = 1f;
                        cell2.PaddingBottom = 3f;
                        cell2.PaddingLeft = 1f;
                        cell2.Colspan = 11;
                        table2.AddCell(cell2);

                        cell2 = new PdfPCell(new Phrase("CAPA", letra_negra_bold_6));
                        cell2.BackgroundColor = azul_oscuro;
                        cell2.BorderColor = gris_oscuro_border;
                        cell2.BorderWidth = 0.7f;
                        cell2.HorizontalAlignment = Element.ALIGN_CENTER;
                        cell2.VerticalAlignment = Element.ALIGN_MIDDLE;
                        cell2.PaddingTop = 1f;
                        cell2.PaddingBottom = 3f;
                        cell2.PaddingLeft = 1f;
                        cell2.Colspan = 2;
                        table2.AddCell(cell2);

                        cell2 = new PdfPCell(new Phrase("ESPESOR \r\ncm", letra_negra_bold_6));
                        cell2.BackgroundColor = azul_oscuro;
                        cell2.BorderColor = gris_oscuro_border;
                        cell2.BorderWidth = 0.7f;
                        cell2.HorizontalAlignment = Element.ALIGN_CENTER;
                        cell2.VerticalAlignment = Element.ALIGN_MIDDLE;
                        cell2.PaddingTop = 1f;
                        cell2.PaddingBottom = 3f;
                        cell2.PaddingLeft = 1f;
                        cell2.Colspan = 2;
                        table2.AddCell(cell2);

                        cell2 = new PdfPCell(new Phrase("HUMEDAD \r\nEN SITIO\r\n %", letra_negra_bold_6));
                        cell2.BackgroundColor = azul_oscuro;
                        cell2.BorderColor = gris_oscuro_border;
                        cell2.BorderWidth = 0.7f;
                        cell2.HorizontalAlignment = Element.ALIGN_CENTER;
                        cell2.VerticalAlignment = Element.ALIGN_MIDDLE;
                        cell2.PaddingTop = 1f;
                        cell2.PaddingBottom = 3f;
                        cell2.PaddingLeft = 1f;
                        cell2.Colspan = 2;
                        table2.AddCell(cell2);

                        cell2 = new PdfPCell(new Phrase("MASA VOLUMÉTRICA SECA EN SITIO\r\nkg·m⁻³", letra_negra_bold_6));
                        cell2.BackgroundColor = azul_oscuro;
                        cell2.BorderColor = gris_oscuro_border;
                        cell2.BorderWidth = 0.7f;
                        cell2.HorizontalAlignment = Element.ALIGN_CENTER;
                        cell2.VerticalAlignment = Element.ALIGN_MIDDLE;
                        cell2.PaddingTop = 1f;
                        cell2.PaddingBottom = 3f;
                        cell2.PaddingLeft = 1f;
                        cell2.Colspan = 3;
                        table2.AddCell(cell2);

                        cell2 = new PdfPCell(new Phrase("% DE COMPACTACIÓN", letra_negra_bold_6));
                        cell2.BackgroundColor = azul_oscuro;
                        cell2.BorderColor = gris_oscuro_border;
                        cell2.BorderWidth = 0.7f;
                        cell2.HorizontalAlignment = Element.ALIGN_CENTER;
                        cell2.VerticalAlignment = Element.ALIGN_MIDDLE;
                        cell2.PaddingTop = 1f;
                        cell2.PaddingBottom = 3f;
                        cell2.PaddingLeft = 1f;
                        cell2.Colspan = 3;
                        table2.AddCell(cell2);

                        doc.Add(table2);
                    }
                    catch { }


                    contadordesalto_lab = 0;
                }
                else
                {
                    contadordesalto_lab = contadordesalto_lab + 1;
                }

                // DATOS DGV
                try
                {                 
                    PdfPTable table = new PdfPTable(25);
                    table.TotalWidth = 560;
                    table.LockedWidth = true;

                    PdfPCell cell1 = new PdfPCell(new Phrase(dr.Cells[1].Value.ToString(), letra_negra_bold_6));
                    cell1.BackgroundColor = blanco;
                    cell1.BorderColor = azul_oscuro;
                    cell1.BorderWidth = 0.7f;
                    cell1.PaddingLeft = 1f;
                    cell1.PaddingTop = 1f;
                    cell1.PaddingBottom = 3f;
                    cell1.Colspan = 2;
                    cell1.FixedHeight = (paginaActual == 1) ? 27f : 27f;
                    cell1.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell1.VerticalAlignment = Element.ALIGN_MIDDLE;
                    table.AddCell(cell1);

                    cell1 = new PdfPCell(new Phrase(dr.Cells[2].Value.ToString().ToUpper(), letra_negra_regular_6));
                    cell1.BackgroundColor = blanco;
                    cell1.BorderColor = azul_oscuro;
                    cell1.BorderWidth = 0.7f;
                    cell1.PaddingLeft = 1f;
                    cell1.PaddingTop = 1f;
                    cell1.PaddingBottom = 3f;
                    cell1.Colspan = 11;
                    cell1.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell1.VerticalAlignment = Element.ALIGN_MIDDLE;
                    table.AddCell(cell1);

                    cell1 = new PdfPCell(new Phrase(dr.Cells[3].Value.ToString(), letra_negra_regular_6));
                    cell1.BackgroundColor = blanco;
                    cell1.BorderColor = azul_oscuro;
                    cell1.BorderWidth = 0.7f;
                    cell1.PaddingLeft = 1f;
                    cell1.PaddingTop = 1f;
                    cell1.PaddingBottom = 3f;
                    cell1.Colspan = 2;
                    cell1.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell1.VerticalAlignment = Element.ALIGN_MIDDLE;
                    table.AddCell(cell1);

                    cell1 = new PdfPCell(new Phrase(dr.Cells[4].Value.ToString(), letra_negra_regular_6));
                    cell1.BackgroundColor = blanco;
                    cell1.BorderColor = azul_oscuro;
                    cell1.BorderWidth = 0.7f;
                    cell1.PaddingLeft = 1f;
                    cell1.PaddingTop = 1f;
                    cell1.PaddingBottom = 3f;
                    cell1.Colspan = 2;
                    cell1.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell1.VerticalAlignment = Element.ALIGN_MIDDLE;
                    table.AddCell(cell1);


                    var cellValue = dr.Cells[5].Value;
                    string valor = cellValue != null &&
                    decimal.TryParse(cellValue.ToString(), NumberStyles.Any, CultureInfo.InvariantCulture, out decimal num)
                    ? Math.Round(num, 1, MidpointRounding.AwayFromZero).ToString("0.0", CultureInfo.InvariantCulture)
                    : "";

                    cell1 = new PdfPCell(new Phrase(valor, letra_negra_regular_6));
                    cell1.BackgroundColor = blanco;
                    cell1.BorderColor = azul_oscuro;
                    cell1.BorderWidth = 0.7f;
                    cell1.PaddingLeft = 1f;
                    cell1.PaddingTop = 1f;
                    cell1.PaddingBottom = 3f;
                    cell1.Colspan = 2;
                    cell1.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell1.VerticalAlignment = Element.ALIGN_MIDDLE;
                    table.AddCell(cell1);





                    var cellValue6 = dr.Cells[6].Value;
                    string valor6 = cellValue6 != null &&
                    decimal.TryParse(cellValue6.ToString(), NumberStyles.Any, CultureInfo.InvariantCulture, out decimal num6)
                        ? Math.Round(num6, 0, MidpointRounding.AwayFromZero).ToString("0", CultureInfo.InvariantCulture)
                        : "";

                    cell1 = new PdfPCell(new Phrase(valor6, letra_negra_regular_6));
                    cell1.BackgroundColor = blanco;
                    cell1.BorderColor = azul_oscuro;
                    cell1.BorderWidth = 0.7f;
                    cell1.PaddingLeft = 1f;
                    cell1.PaddingTop = 1f;
                    cell1.PaddingBottom = 3f;
                    cell1.Colspan = 3;
                    cell1.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell1.VerticalAlignment = Element.ALIGN_MIDDLE;
                    table.AddCell(cell1);





                    var cellValue7 = dr.Cells[7].Value;
                    string valor7 = cellValue7 != null &&
                    decimal.TryParse(cellValue7.ToString(), NumberStyles.Any, CultureInfo.InvariantCulture, out decimal num7)
                    ? Math.Round(num7, 1, MidpointRounding.AwayFromZero).ToString("F1", CultureInfo.InvariantCulture)
                    : "";

                    cell1 = new PdfPCell(new Phrase(valor7, letra_negra_bold_6));
                    cell1.BackgroundColor = blanco;
                    cell1.BorderColor = azul_oscuro;
                    cell1.BorderWidth = 0.7f;
                    cell1.PaddingLeft = 1f;
                    cell1.PaddingTop = 1f;
                    cell1.PaddingBottom = 3f;
                    cell1.Colspan = 3;
                    cell1.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell1.VerticalAlignment = Element.ALIGN_MIDDLE;
                    table.AddCell(cell1);


                    doc.Add(table);
                }
                catch
                {

                }
            }







            // RELLENA LA ULTIMA PAGINA
            // agregamos la leyenda justo después del último dato
            PdfPTable tablaLeyenda = new PdfPTable(14);
            tablaLeyenda.TotalWidth = 560f;
            tablaLeyenda.LockedWidth = true;

            PdfPCell leyendaCell = new PdfPCell(new Phrase("---------------- FIN DE DATOS ----------------", letra_negra_regular_6));
            leyendaCell.BackgroundColor = blanco;
            leyendaCell.BorderColor = azul_oscuro;
            leyendaCell.BorderWidth = 0.7f;
            leyendaCell.PaddingLeft = 1f;
            leyendaCell.PaddingTop = 1f;
            leyendaCell.PaddingBottom = 3f;
            leyendaCell.HorizontalAlignment = Element.ALIGN_CENTER;
            leyendaCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            leyendaCell.FixedHeight = (paginaActual == 1) ? 27f : 27f;
            leyendaCell.Colspan = 14;
            tablaLeyenda.AddCell(leyendaCell);
            doc.Add(tablaLeyenda);


            // rellena con filas de "---" hasta llegar a 20
            int filasTotales = 10;
            int filasFaltantes = filasTotales - (contadordesalto_lab + 2); // +2 por la leyenda, SI SE QUITA EL +2 REBASA LA CANTIDAD DE FILAS

            for (int i = 0; i < filasFaltantes; i++)
            {
                PdfPTable table_r = new PdfPTable(25);
                table_r.TotalWidth = 560f;
                table_r.LockedWidth = true;

                PdfPCell cell_r = new PdfPCell(new Phrase("---", letra_negra_regular_6));
                cell_r.BackgroundColor = blanco;
                cell_r.BorderColor = azul_oscuro;
                cell_r.BorderWidth = 0.7f;
                cell_r.PaddingLeft = 1f;
                cell_r.PaddingTop = 1f;
                cell_r.PaddingBottom = 3f;
                cell_r.Colspan = 2;
                cell_r.FixedHeight = (paginaActual == 1) ? 27f : 27f;
                cell_r.HorizontalAlignment = Element.ALIGN_CENTER;
                cell_r.VerticalAlignment = Element.ALIGN_MIDDLE;
                table_r.AddCell(cell_r);

                cell_r = new PdfPCell(new Phrase("---", letra_negra_regular_6));
                cell_r.BackgroundColor = blanco;
                cell_r.BorderColor = azul_oscuro;
                cell_r.BorderWidth = 0.7f;
                cell_r.PaddingLeft = 1f;
                cell_r.PaddingTop = 1f;
                cell_r.PaddingBottom = 3f;
                cell_r.Colspan = 11;
                cell_r.HorizontalAlignment = Element.ALIGN_CENTER;
                cell_r.VerticalAlignment = Element.ALIGN_MIDDLE;
                table_r.AddCell(cell_r);

                cell_r = new PdfPCell(new Phrase("---", letra_negra_regular_6));
                cell_r.BackgroundColor = blanco;
                cell_r.BorderColor = azul_oscuro;
                cell_r.BorderWidth = 0.7f;
                cell_r.PaddingLeft = 1f;
                cell_r.PaddingTop = 1f;
                cell_r.PaddingBottom = 3f;
                cell_r.Colspan = 2;
                cell_r.HorizontalAlignment = Element.ALIGN_CENTER;
                cell_r.VerticalAlignment = Element.ALIGN_MIDDLE;
                table_r.AddCell(cell_r);

                cell_r = new PdfPCell(new Phrase("---", letra_negra_regular_6));
                cell_r.BackgroundColor = blanco;
                cell_r.BorderColor = azul_oscuro;
                cell_r.BorderWidth = 0.7f;
                cell_r.PaddingLeft = 1f;
                cell_r.PaddingTop = 1f;
                cell_r.PaddingBottom = 3f;
                cell_r.Colspan = 2;
                cell_r.HorizontalAlignment = Element.ALIGN_CENTER;
                cell_r.VerticalAlignment = Element.ALIGN_MIDDLE;
                table_r.AddCell(cell_r);

                cell_r = new PdfPCell(new Phrase("---", letra_negra_regular_6));
                cell_r.BackgroundColor = blanco;
                cell_r.BorderColor = azul_oscuro;
                cell_r.BorderWidth = 0.7f;
                cell_r.PaddingLeft = 1f;
                cell_r.PaddingTop = 1f;
                cell_r.PaddingBottom = 3f;
                cell_r.Colspan = 2;
                cell_r.HorizontalAlignment = Element.ALIGN_CENTER;
                cell_r.VerticalAlignment = Element.ALIGN_MIDDLE;
                table_r.AddCell(cell_r);

                cell_r = new PdfPCell(new Phrase("---", letra_negra_regular_6));
                cell_r.BackgroundColor = blanco;
                cell_r.BorderColor = azul_oscuro;
                cell_r.BorderWidth = 0.7f;
                cell_r.PaddingLeft = 1f;
                cell_r.PaddingTop = 1f;
                cell_r.PaddingBottom = 3f;
                cell_r.Colspan = 3;
                cell_r.HorizontalAlignment = Element.ALIGN_CENTER;
                cell_r.VerticalAlignment = Element.ALIGN_MIDDLE;
                table_r.AddCell(cell_r);

                cell_r = new PdfPCell(new Phrase("---", letra_negra_regular_6));
                cell_r.BackgroundColor = blanco;
                cell_r.BorderColor = azul_oscuro;
                cell_r.BorderWidth = 0.7f;
                cell_r.PaddingLeft = 1f;
                cell_r.PaddingTop = 1f;
                cell_r.PaddingBottom = 3f;
                cell_r.Colspan = 3;
                cell_r.HorizontalAlignment = Element.ALIGN_CENTER;
                cell_r.VerticalAlignment = Element.ALIGN_MIDDLE;
                table_r.AddCell(cell_r);

                doc.Add(table_r);
            }



            doc.Close();
        }




        private void lab_cabeza_Click(object sender, EventArgs e)
        {
            encabeza_lab = true;
            sinencabeza_lab = false;

            string nombre_realizo1 = REALIZO.Texts;
            string nombre_reviso1 = REVISO.Texts;

            if (string.IsNullOrWhiteSpace(nombre_realizo1) || string.IsNullOrWhiteSpace(nombre_reviso1))
            {
                System.Windows.MessageBox.Show("Debes seleccionar un TÉCNICO y un SIGNATARIO antes de generar el PDF.");
                return; // cancela la generación
            }
            else
            {
                DOCUMENTO_LAB_PDF();
            }
        }

        private void lab_sin_cabeza_Click(object sender, EventArgs e)
        {
            sinencabeza_lab = true;
            encabeza_lab = false;

            string nombre_realizo2 = REALIZO.Texts;
            string nombre_reviso2 = REVISO.Texts;

            if (string.IsNullOrWhiteSpace(nombre_realizo2) || string.IsNullOrWhiteSpace(nombre_reviso2))
            {
                System.Windows.MessageBox.Show("Debes seleccionar un TÉCNICO y un SIGNATARIO antes de generar el PDF.");
                return; // cancela la generación
            }
            else
            {
                DOCUMENTO_LAB_PDF();
            }
        }














        private void label33_Click(object sender, EventArgs e)
        {
            context_lab.Show(label34, 3, 3);


            if (total == true)
            {
                total = false;

                DGV_PADRON.DataSource = CONEXION_REMOTO_PND.CONSULTA_GENERAL("SELECT ID_SEGUIMIENTO, NUMERO_SONDEO , LOCALIZACION_SONDEO, NUMERO_CAPA, ESPESOR_CAPA_CM,  MASA_VOL_MAT_HUMEDO, MASA_VOL_SEC_LUG, COMPACTACION       FROM sondeos_densimetro WHERE CLAVE_MUESTRA = '" + clave_mues + "'  ");

                DGV_PADRON.Columns[0].HeaderText = "Id";
                DGV_PADRON.Columns[1].HeaderText = "No.";
                DGV_PADRON.Columns[2].HeaderText = "Localización";
                DGV_PADRON.Columns[3].HeaderText = "No. de capa";
                DGV_PADRON.Columns[4].HeaderText = "Espesor de capa (cm)";
                DGV_PADRON.Columns[5].HeaderText = "Masa Vol de Mat. Hum";
                DGV_PADRON.Columns[6].HeaderText = "Masa Vol. Seca del lugar";
                DGV_PADRON.Columns[7].HeaderText = "Compactación (%)";

                DGV_PADRON.Columns[0].Width = 80;
                DGV_PADRON.Columns[1].Width = 80;
                DGV_PADRON.Columns[2].Width = DGV_PADRON.Width / 3;
                DGV_PADRON.Columns[3].Width = 80;
            }
            else
            {
                //generar_informe();
                //MENSAJE_GENERAL MN = new MENSAJE_GENERAL();
                //MN.BOTON.Text = "Informe Generado";
                //MN.ShowDialog();
            }
        }

       
    }
}