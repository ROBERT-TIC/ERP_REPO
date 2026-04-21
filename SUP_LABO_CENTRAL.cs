using ERP_LIEC;
using MySql.Data.MySqlClient;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ERP_COMPLETO
{
    public partial class SUP_LABO_CENTRAL : Form
    {
        public SUP_LABO_CENTRAL()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LUGAR_OnSelectedIndexChanged(object sender, EventArgs e)
        {

            CARGA_1();
        }

        //METODO QUE CARGA PERSONAL DE LA BD AL SELECT
        private void CARGA_1()
        {
            if (LUGAR.Texts == "LABORATORIO CENTRAL")
            {
                MySqlConnection CONEXION = conexion_rh.USR;
                CONEXION.Open();

                MySqlCommand comando = new MySqlCommand("SELECT DISTINCT AREA_2 FROM pdr_personal1 WHERE AREA_2 LIKE '%LC TERRACERIAS Y ASFALTOS%' or AREA_2 LIKE '%LC CONCRETO Y ACERO%' or AREA_2 LIKE '%LC PRUEBAS NO DESTRUCTIVAS%' or AREA_2 LIKE '%MECÁNICA DE SUELOS%' ORDER BY AREA_2 ASC", CONEXION);

                MySqlDataReader registro = comando.ExecuteReader();

                while (registro.Read())
                {
                    AREAS_CENTRAL.Items.Add(registro["AREA_2"].ToString());
                }
                CONEXION.Close();
            }
            else if (LUGAR.Texts == "LABORATORIO TEPOTZOTLÁN")
            {

                AREAS_CENTRAL.Texts = "LC TEPOTZOTLAN";

                MySqlConnection CONEXION = conexion_rh.USR;
                CONEXION.Open();
                MySqlCommand comando = new MySqlCommand("SELECT DISTINCT NOMBRE FROM pdr_personal1 WHERE AREA_2 = 'LC TEPOTZOTLAN' AND CATEGORIA = '1 COORDINADOR DE LABORATORIO' ORDER BY NOMBRE ASC", CONEXION);

                MySqlDataReader registro = comando.ExecuteReader();
                while (registro.Read())
                {
                    COORDINADOR.Items.Add(registro["NOMBRE"].ToString());
                }
                CONEXION.Close();
            }

        }

        private void AREAS_CENTRAL_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            // AREAS_CENTRAL.Items.Clear();

            if (AREAS_CENTRAL.Texts == "LC TERRACERIAS Y ASFALTOS")
            {
                MySqlConnection CONEXION = conexion_rh.USR;
                CONEXION.Open();
                MySqlCommand comando = new MySqlCommand("SELECT DISTINCT NOMBRE FROM pdr_personal1 WHERE AREA_2 = 'LC TERRACERIAS Y ASFALTOS' AND CATEGORIA = '1 COORDINADOR DE LABORATORIO (TERRACERÍAS Y ASFALTO)' ORDER BY NOMBRE ASC", CONEXION);

                MySqlDataReader registro = comando.ExecuteReader();
                while (registro.Read())
                {
                    COORDINADOR.Items.Clear();
                    COORDINADOR.Items.Add(registro["NOMBRE"].ToString());
                }
                CONEXION.Close();
            }
            else if (AREAS_CENTRAL.Texts == "LC CONCRETO Y ACERO")
            {
                MySqlConnection CONEXION = conexion_rh.USR;
                CONEXION.Open();
                MySqlCommand comando = new MySqlCommand("SELECT DISTINCT NOMBRE FROM pdr_personal1 WHERE AREA_2 = 'LC CONCRETO Y ACERO' AND CATEGORIA = '1 COORDINADOR DE LABORATORIO (CONCRETO Y ACERO)' ORDER BY NOMBRE ASC", CONEXION);

                MySqlDataReader registro = comando.ExecuteReader();
                while (registro.Read())
                {
                    COORDINADOR.Items.Clear();
                    COORDINADOR.Items.Add(registro["NOMBRE"].ToString());
                }
                CONEXION.Close();
            }
            else if (AREAS_CENTRAL.Texts == "LC PRUEBAS NO DESTRUCTIVAS")
            {
                MySqlConnection CONEXION = conexion_rh.USR;
                CONEXION.Open();
                MySqlCommand comando = new MySqlCommand("SELECT DISTINCT NOMBRE FROM pdr_personal1 WHERE AREA_2 = 'LC PRUEBAS NO DESTRUCTIVAS' AND CATEGORIA = '1 COORDINADOR DE LABORATORIO (PND)' ORDER BY NOMBRE ASC", CONEXION);

                MySqlDataReader registro = comando.ExecuteReader();
                while (registro.Read())
                {
                    COORDINADOR.Items.Clear();
                    COORDINADOR.Items.Add(registro["NOMBRE"].ToString());
                }
                CONEXION.Close();
            }
            else if (AREAS_CENTRAL.Texts == "MECÁNICA DE SUELOS")
            {
                MySqlConnection CONEXION = conexion_rh.USR;
                CONEXION.Open();
                MySqlCommand comando = new MySqlCommand("SELECT DISTINCT NOMBRE FROM pdr_personal1 WHERE AREA_2 = 'MECÁNICA DE SUELOS' AND CATEGORIA  = '1 COORDINADOR INGENIERÍA MS' ORDER BY NOMBRE ASC", CONEXION);

                MySqlDataReader registro = comando.ExecuteReader();
                while (registro.Read())
                {
                    COORDINADOR.Items.Clear();
                    COORDINADOR.Items.Add(registro["NOMBRE"].ToString());
                }
                CONEXION.Close();
            }

        }

        private void COORDINADOR_OnSelectedIndexChanged_1(object sender, EventArgs e)
        {
            COORDINADOR.Items.Clear();
        }

        private void COORDINADOR_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            TABLE.DataSource = conexion_rh.Consultageneral("SELECT * FROM areas_trabajo WHERE COORDINADOR = '" + COORDINADOR.Texts + "' ");
            if (TABLE.RowCount != 0)
            {
                //  LUGAR.Texts = TABLE.Rows[0].Cells[4].Value.ToString();
                //   AREA.Texts = TABLE.Rows[0].Cells[4].Value.ToString();
            }
            else
            {
            }
        }




        //METODO QUE CONSULTA LOS REGISTROS DE BD
        private void CONSULTA()
        {
            DGV.Rows.Clear();

            MySqlConnection CONEXION = conexion_supervision_tecnica.USR;

            MySqlCommand comando = new MySqlCommand("SELECT ID_SEGUIMIENTO, FECHA_AGENDADA, MOTIVO, AREA, LUGAR, COORDINADOR, SEMESTRE, EVALUADOR, ESTATUS, OBSERVACIONES, FECHA_REGISTRO FROM agenda_actividades_central", CONEXION);

            CONEXION.Open();
            MySqlDataReader consulta = comando.ExecuteReader();
            while (consulta.Read())
            {
                string a0 = consulta.IsDBNull(0) ? String.Empty : consulta.GetString(0); //ID SEGUIMIENTO
                string a1 = consulta.IsDBNull(1) ? String.Empty : consulta.GetString(1); //FECHA AGENDADA
                string a2 = consulta.IsDBNull(2) ? String.Empty : consulta.GetString(2); //MOTIVO
                string a3 = consulta.IsDBNull(3) ? String.Empty : consulta.GetString(3); //AREA
                string a4 = consulta.IsDBNull(4) ? String.Empty : consulta.GetString(4); //LUGAR
                string a5 = consulta.IsDBNull(5) ? String.Empty : consulta.GetString(5); //COORDINADOR
                string a6 = consulta.IsDBNull(6) ? String.Empty : consulta.GetString(6); //SEMESTRE
                string a7 = consulta.IsDBNull(7) ? String.Empty : consulta.GetString(7); //EVALUADOR
                string a8 = consulta.IsDBNull(8) ? String.Empty : consulta.GetString(8); //ESTATUS
                string a9 = consulta.IsDBNull(9) ? String.Empty : consulta.GetString(9); //OBSERVACIONES
                string a10 = consulta.IsDBNull(10) ? String.Empty : consulta.GetString(10); //FECHA REGISTRO

                DGV.Rows.Add(a0, a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, "Evaluar", "Actualizar", "Eliminar");
            }
            CONEXION.Close();
        }



        //BOTON REGISTRAR
        private void rjButton1_Click_1(object sender, EventArgs e)
        {
            //FORMA DE FECHA
            DateTime HOY = DateTime.Now;

            conexion_supervision_tecnica.Consultageneral("INSERT INTO agenda_actividades_central(FECHA_AGENDADA, MOTIVO, LUGAR, AREA, COORDINADOR, ESTATUS, OBSERVACIONES, FECHA_REGISTRO, EVALUADOR, SEMESTRE) VALUES ('" + FECHA_AGENDADA.Text + "','" + MOTIVO.Texts.ToUpper() + "', '" + LUGAR.Texts.ToUpper() + "', '" + AREAS_CENTRAL.Texts.ToUpper() + "', '" + COORDINADOR.Texts.ToUpper() + "', 'PENDIENTE', '" + OBSERVACIONES.Texts.ToUpper() + "', '" + HOY.ToString("yyyy-MM-dd H:mm:ss") + "', '" + EVALUADOR.Texts.ToUpper() + "', '" + SEMESTRE + "')");

            MessageBox.Show("SE AGENDÓ CORRECTAMENTE");


            LIMPIA_CAMPOS();

            CONSULTA();

        }

        string a0;
        string a3;
        string a4;

        public static EJEMPLO2_SP ej2_sp = new EJEMPLO2_SP();
        private void DGV_EVENTOS_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (DGV.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() == "Evaluar")
            {
                Form nv = new Form();
                using (ej2_sp = new EJEMPLO2_SP())
                {
                    nv.StartPosition = FormStartPosition.Manual;
                    nv.FormBorderStyle = FormBorderStyle.None;
                    nv.Opacity = .70d;
                    nv.BackColor = Color.Black;
                    nv.WindowState = FormWindowState.Maximized;
                    nv.TopMost = false;
                    nv.Location = this.Location;
                    nv.ShowInTaskbar = false;
                    nv.Show();
                    ej2_sp.Owner = nv;
                    ej2_sp.Opacity = 0;
                    ej2_sp.TopMost = false;

                    foreach (DataGridViewRow row in DGV.Rows)
                    {
                        a0 = row.Cells[0].Value.ToString();
                        a3 = row.Cells[3].Value.ToString();
                        a4 = row.Cells[4].Value.ToString();

                        ej2_sp.ID_SEG.Text = DGV.CurrentRow.Cells[0].Value.ToString();
                        ej2_sp.OBRA.Text = DGV.CurrentRow.Cells[3].Value.ToString() + " / " + DGV.CurrentRow.Cells[4].Value.ToString();      // LUGAR + AREA [3] + [4]
                        ej2_sp.SUPERVISADO.Text = DGV.CurrentRow.Cells[5].Value.ToString();
                        ej2_sp.FECHA.Text = DGV.CurrentRow.Cells[1].Value.ToString();
                    }

                    ej2_sp.ShowDialog();

                    nv.Dispose();
                }
            }
            else if (DGV.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() == "Actualizar")
            {
                ACTUALIZAR();
                CONSULTA();
            }
            else if (DGV.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() == "Eliminar")
            {
                ELIMINAR();
                CONSULTA();
            }
        }

        private void ACTUALIZAR()
        {
            conexion_supervision_tecnica.USR.Open();//Se abre la conexión para evitar un error común

            String Query = "UPDATE agenda_actividades_central SET FECHA_AGENDADA = '" + DGV.CurrentRow.Cells[1].Value.ToString() + "', MOTIVO = '" + DGV.CurrentRow.Cells[2].Value.ToString().ToUpper() + "', SEMESTRE = '" + DGV.CurrentRow.Cells[6].Value.ToString().ToUpper() + "', EVALUADOR = '" + DGV.CurrentRow.Cells[7].Value.ToString().ToUpper() + "', ESTATUS = '" + DGV.CurrentRow.Cells[8].Value.ToString().ToUpper() + "', OBSERVACIONES = '" + DGV.CurrentRow.Cells[9].Value.ToString().ToUpper() + "' WHERE ID_SEGUIMIENTO = '" + DGV.CurrentRow.Cells[0].Value.ToString() + "';";
            MySqlCommand comando = new MySqlCommand(Query, conexion_supervision_tecnica.USR);//Se interpreta el comando del query
            comando.ExecuteNonQuery();//Se ejecuta el comando del query

            conexion_supervision_tecnica.USR.Close();//Se cierra la conexión
            DGV.Rows.RemoveAt(DGV.CurrentRow.Index);
            MENSAJE_GENERAL mn = new MENSAJE_GENERAL();
            mn.BOTON.Text = "Se ha actualizado exitosamente";
            mn.ShowDialog();
        }

        private void ELIMINAR()
        {
            conexion_supervision_tecnica.USR.Open();//Se abre la conexión para evitar un error común

            String Query = "DELETE FROM agenda_actividades_central WHERE ID_SEGUIMIENTO  = '" + DGV.CurrentRow.Cells[0].Value.ToString() + "';";
            MySqlCommand comando = new MySqlCommand(Query, conexion_supervision_tecnica.USR);//Se interpreta el comando del query
            comando.ExecuteNonQuery();//Se ejecuta el comando del query

            conexion_supervision_tecnica.USR.Close();//Se cierra la conexión
            MENSAJE_GENERAL mn = new MENSAJE_GENERAL();
            mn.BOTON.Text = "Se ha eliminado exitosamente";
            mn.ShowDialog();
        }



        //METODO LIMPIA CAMPOS
        private void LIMPIA_CAMPOS()
        {
            MOTIVO.Texts = String.Empty;
            LUGAR.Texts = String.Empty;
            AREAS_CENTRAL.Texts = String.Empty;
            COORDINADOR.Texts = String.Empty;
            OBSERVACIONES.Texts = String.Empty;
            EVALUADOR.Texts = String.Empty;

            DGV.Rows.Clear();
        }

        public void TABLA_diseño()
        {
            DGV.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            DGV.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DGV.RowHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            for (int i = 0; i < DGV.ColumnCount; i = i + 2)
            {
                DGV.Columns[i].DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(244, 244, 244);

            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Opacity = this.Opacity + .20;


            if (this.Opacity == 1)
            {

                timer1.Stop();
            }
        }

        private void DGV_EVENTOS_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

            DGV.Rows[e.RowIndex].ErrorText = "Concisely describe the error and how to fix it";
            e.Cancel = true;
        }



        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
            CARGA_1();
            CONSULTA();

            TABLA_diseño();
        }


        string SEMESTRE = "";
        private void fechas()
        {

            MOTIVO.Items.Clear();
            DateTime fec = DateTime.Parse(FECHA_AGENDADA.Text);
            DateTime actual = DateTime.Parse(fec.ToString("yyyy") + "-06-01");

            if (fec < actual)
            {
                MOTIVO.Items.Add("EV.SEMESTRAL");
                MOTIVO.Items.Add("OTROS");
                SEMESTRE = "PRIMER SEMESTRE";
            }
            else
            {
                MOTIVO.Items.Add("EV.SEMESTRAL");
                MOTIVO.Items.Add("OTROS");
                SEMESTRE = "SEGUNDO SEMESTRE";
            }
        }


        private void FECHA_AGENDADA_ValueChanged(object sender, EventArgs e)
        {
            fechas();
        }



    }
}
