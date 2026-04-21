using ERP_LIEC;
using MySql.Data.MySqlClient;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ERP_COMPLETO
{
    public partial class SUP_SERV_PERM : Form
    {
        public SUP_SERV_PERM()
        {
            InitializeComponent();
        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //METODO QUE CARGA OBRAS DE LA BD AL SELECT
        private void CARGA_OBRAS()
        {
            /* MySqlConnection CONEXION = conexion_servicios_eventuales.USR;
             CONEXION.Open();
             MySqlCommand comando = new MySqlCommand("SELECT * FROM listado_obras WHERE TIPO_SERVICIO = 'PERMANENTE' ORDER BY NOMBRE_OBRA ASC ", CONEXION);

             MySqlDataReader registro = comando.ExecuteReader();

             while (registro.Read())
             {
                 OBRA.Items.Add(registro["NOMBRE_OBRA"].ToString());
             }
             CONEXION.Close();*/

            MySqlConnection CONEXION = conexion_rh.USR;
            CONEXION.Open();
            MySqlCommand comando = new MySqlCommand("SELECT * FROM pdr_personal1 WHERE CATEGORIA = '1 COORDINADOR CAMPO' OR CATEGORIA = '1 COORDINADOR REGIONAL' AND ESTATUS = 'Activo' AND AREA_2 = 'SERVICIOS PERMANENTES'  ORDER BY NOMBRE_AREA_TEC ASC", CONEXION);

            MySqlDataReader registro = comando.ExecuteReader();

            while (registro.Read())
            {
                OBRA.Items.Add(registro["NOMBRE_AREA_TEC"].ToString());
            }
            CONEXION.Close();
        }

        //INGRESA INFORMACION EN CAMPOS AL SELECCIONAR OPCION DEL SELECT
        private void OBRA_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            TABLE_OBRAS.DataSource = conexion_rh.Consultageneral("SELECT * FROM pdr_personal1 WHERE NOMBRE_AREA_TEC = '" + OBRA.Texts + "' ");
            if (TABLE_OBRAS.RowCount != 0)
            {
                COORD_OBRA.Texts = TABLE_OBRAS.Rows[0].Cells[1].Value.ToString();      //nombre persona        
                                                                                       //  CLAVE_OBRA.Texts = TABLE_OBRAS.Rows[0].Cells[1].Value.ToString();
            }
            else
            {
            }

            TABLE_CLAVE_OBRA.DataSource = conexion_servicios_eventuales.Consultageneral("SELECT * FROM listado_obras WHERE ALIAS = '" + OBRA.Texts + "' ");
            if (TABLE_CLAVE_OBRA.RowCount != 0)
            {
                CLAVE_OBRA.Texts = TABLE_CLAVE_OBRA.Rows[0].Cells[1].Value.ToString();
            }
            else
            {
                MessageBox.Show("No hay registro de Clave de Obra");
            }


        }


        //METODO QUE CONSULTA LOS REGISTROS DE BD
        private void CONSULTA()
        {

            DGV.Rows.Clear();
            MySqlConnection CONEXION = conexion_supervision_tecnica.USR;

            MySqlCommand comando = new MySqlCommand("SELECT ID_SEGUIMIENTO, FECHA_AGENDADA, MOTIVO, CLAVE_OBRA, NOMBRE_OBRA, COORD_OBRA, SEMESTRE, EVALUADOR, ESTATUS, OBSERVACIONES, FECHA_REGISTRO FROM agenda_actividades_sp", CONEXION);

            CONEXION.Open();
            MySqlDataReader consulta = comando.ExecuteReader();
            while (consulta.Read())
            {
                string a0 = consulta.IsDBNull(0) ? String.Empty : consulta.GetString(0); //ID SEGUIMIENTO
                string a1 = consulta.IsDBNull(1) ? String.Empty : consulta.GetString(1); //FECHA AGENDADA
                string a2 = consulta.IsDBNull(2) ? String.Empty : consulta.GetString(2); //MOTIVO
                string a3 = consulta.IsDBNull(3) ? String.Empty : consulta.GetString(3); //CLAVE OBRA
                string a4 = consulta.IsDBNull(4) ? String.Empty : consulta.GetString(4); //NOMBRE OBRA         
                string a5 = consulta.IsDBNull(5) ? String.Empty : consulta.GetString(5); //COORD OBRA
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
        private void BTN_REGISTRAR_Click(object sender, EventArgs e)
        {
            //FORMA DE FECHA
            DateTime HOY = DateTime.Now;

            conexion_supervision_tecnica.Consultageneral("INSERT INTO agenda_actividades_sp(FECHA_AGENDADA, MOTIVO, NOMBRE_OBRA, CLAVE_OBRA, COORD_OBRA, ESTATUS, OBSERVACIONES, FECHA_REGISTRO, EVALUADOR, SEMESTRE) VALUES('" + FECHA_AGENDADA.Text + "','" + MOTIVO.Texts.ToUpper() + "', '" + OBRA.Texts.ToUpper() + "', '" + CLAVE_OBRA.Texts + "', '" + COORD_OBRA.Texts.ToUpper() + "', 'PENDIENTE', '" + OBSERVACIONES.Texts.ToUpper() + "', '" + HOY.ToString("yyyy-MM-dd H:mm:ss") + "', '" + EVALUADOR.Texts.ToUpper() + "', '" + SEMESTRE + "')");

            MessageBox.Show("SE AGENDÓ CORRECTAMENTE");

            LIMPIA_CAMPOS();
            CONSULTA();

        }

        //METODO LIMPIA CAMPOS
        private void LIMPIA_CAMPOS()
        {
            MOTIVO.Texts = String.Empty;
            OBRA.Texts = String.Empty;
            CLAVE_OBRA.Texts = String.Empty;
            OBSERVACIONES.Texts = String.Empty;
            COORD_OBRA.Texts = String.Empty;
            EVALUADOR.Texts = String.Empty;

            DGV.Rows.Clear();
        }



        string a0;
        string a3;
        string a4;
        string a5;

        public static EJEMPLO_SP ej_sp = new EJEMPLO_SP();
        private void DGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DGV.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() == "Evaluar")
            {
                Form nv = new Form();
                using (ej_sp = new EJEMPLO_SP())
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
                    ej_sp.Owner = nv;
                    ej_sp.Opacity = 0;
                    ej_sp.TopMost = false;


                    foreach (DataGridViewRow row in DGV.Rows)
                    {
                        a0 = row.Cells[0].Value.ToString(); //id_seg
                        a3 = row.Cells[3].Value.ToString(); //nombre_obra
                        a4 = row.Cells[4].Value.ToString(); //clave_obra
                        a5 = row.Cells[5].Value.ToString(); //coord_obra

                        ej_sp.ID_SEG.Text = DGV.CurrentRow.Cells[0].Value.ToString();
                        ej_sp.FECHA.Text = DGV.CurrentRow.Cells[1].Value.ToString();
                        ej_sp.OBRA.Text = DGV.CurrentRow.Cells[3].Value.ToString();
                        ej_sp.rjButton1.Text = DGV.CurrentRow.Cells[4].Value.ToString();
                        ej_sp.SUPERVISADO.Text = DGV.CurrentRow.Cells[5].Value.ToString();

                    }


                    ej_sp.ShowDialog();

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

            String Query = "UPDATE agenda_actividades_sp SET FECHA_AGENDADA = '" + DGV.CurrentRow.Cells[1].Value.ToString() + "', MOTIVO = '" + DGV.CurrentRow.Cells[2].Value.ToString().ToUpper() + "', SEMESTRE = '" + DGV.CurrentRow.Cells[6].Value.ToString().ToUpper() + "', EVALUADOR = '" + DGV.CurrentRow.Cells[7].Value.ToString().ToUpper() + "', ESTATUS = '" + DGV.CurrentRow.Cells[8].Value.ToString().ToUpper() + "', OBSERVACIONES = '" + DGV.CurrentRow.Cells[9].Value.ToString().ToUpper() + "' WHERE ID_SEGUIMIENTO = '" + DGV.CurrentRow.Cells[0].Value.ToString() + "';";
            MySqlCommand comando = new MySqlCommand(Query, conexion_supervision_tecnica.USR);//Se interpreta el comando del query
            comando.ExecuteNonQuery();//Se ejecuta el comando del query

            conexion_supervision_tecnica.USR.Close();//Se cierra la conexión
            DGV.Rows.RemoveAt(DGV.CurrentRow.Index);
            MENSAJE_GENERAL mn = new MENSAJE_GENERAL();
            mn.BOTON.Text = "Se actualizó correctamente";
            mn.ShowDialog();
        }

        private void ELIMINAR()
        {
            conexion_supervision_tecnica.USR.Open();//Se abre la conexión para evitar un error común

            String Query = "DELETE FROM agenda_actividades_sp WHERE ID_SEGUIMIENTO  = '" + DGV.CurrentRow.Cells[0].Value.ToString() + "';";
            MySqlCommand comando = new MySqlCommand(Query, conexion_supervision_tecnica.USR);//Se interpreta el comando del query
            comando.ExecuteNonQuery();//Se ejecuta el comando del query

            conexion_supervision_tecnica.USR.Close();//Se cierra la conexión
            MENSAJE_GENERAL mn = new MENSAJE_GENERAL();
            mn.BOTON.Text = "Se eliminó correctamente";
            mn.ShowDialog();
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
            CARGA_OBRAS();
            CONSULTA();

            TABLA_diseño();

            timer1.Start();
        }

        private void TABLE_OBRAS_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void TABLA_COORD_OBRA_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void FECHA_AGENDADA_ValueChanged(object sender, EventArgs e)
        {
            fechas();
        }
    }
}
