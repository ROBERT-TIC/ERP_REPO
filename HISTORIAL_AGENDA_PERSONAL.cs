using ERP_LIEC;
using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace ERP_COMPLETO
{
    public partial class HISTORIAL_AGENDA_PERSONAL : Form
    {
        public HISTORIAL_AGENDA_PERSONAL()
        {
            InitializeComponent();
        }
        public string persona;
        public string categoria_historial;
        public string año_historial;
        public string semestre_historial;




        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void TAMAÑO_TABLA()
        {
            DGV.Columns[0].Width = 50;
            DGV.Columns[1].Width = 100;
            DGV.Columns[2].Width = 200;
            DGV.Columns[3].Width = 100;
            DGV.Columns[4].Width = 150;
            DGV.Columns[5].Width = 100;
            DGV.Columns[6].Width = 80;
            DGV.Columns[7].Width = 200;
            DGV.Columns[8].Width = 100;
            DGV.Columns[9].Width = 100;


        }


        private void DETALLE_DE_EGRESOS_Load(object sender, EventArgs e)
        {

            timer1.Start();
            consulta_egresos_prov();
            TAMAÑO_TABLA();
            TABLA_diseño();

        }
        private void consulta_egresos_prov()
        {
            MySqlConnection CONEXION = conexion_supervision_tecnica.USR;
            MySqlCommand comando = new MySqlCommand("SELECT * FROM  personal_agenda WHERE PERSONAL = '" + persona + "'", CONEXION);

            CONEXION.Open();
            MySqlDataReader consulta = comando.ExecuteReader();

            while (consulta.Read())
            {
                string a0 = consulta.IsDBNull(0) ? String.Empty : consulta.GetString(0);
                string a1 = consulta.IsDBNull(1) ? String.Empty : consulta.GetString(1);
                string a2 = consulta.IsDBNull(2) ? String.Empty : consulta.GetString(2);
                string a3 = consulta.IsDBNull(3) ? String.Empty : consulta.GetString(3);
                string a4 = consulta.IsDBNull(4) ? String.Empty : consulta.GetString(4);
                string a5 = consulta.IsDBNull(5) ? String.Empty : consulta.GetString(5);
                string a6 = consulta.IsDBNull(6) ? String.Empty : consulta.GetString(6);
                string a7 = consulta.IsDBNull(7) ? String.Empty : consulta.GetString(7);
                string a8 = consulta.IsDBNull(8) ? String.Empty : consulta.GetString(8);

                DGV.Rows.Add(a0, a1, a2, a3, a4, a5, a6, a7, a8, "Evaluar", "Eliminar");
            }
            CONEXION.Close();
        }



        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Opacity = this.Opacity + .20;


            if (this.Opacity == 1)
            {

                timer1.Stop();
            }
        }

        private void DGV_SelectionChanged_1(object sender, EventArgs e)
        {


        }

        public void saldo_via()
        {

        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DGV.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() == "Eliminar")
            {
                conexion_supervision_tecnica.USR.Open();//Se abre la conexión para evitar un error común

                String Query = "DELETE  FROM personal_agenda  WHERE ID_SEGUIMIENTO  = '" + DGV.CurrentRow.Cells[0].Value.ToString() + "';";
                MySqlCommand comando = new MySqlCommand(Query, conexion_supervision_tecnica.USR);//Se interpreta el comando del query
                comando.ExecuteNonQuery();//Se ejecuta el comando del query

                conexion_supervision_tecnica.USR.Close();//Se cierra la conexión
                DGV.Rows.RemoveAt(DGV.CurrentRow.Index);
            }
            else if (DGV.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() == "Evaluar")
            {
                año_historial = DGV.CurrentRow.Cells[3].Value.ToString();

                PAN_SUPERVISION.GEV.CATEG = DGV.CurrentRow.Cells[7].Value.ToString(); //CATEGORIA
                PAN_SUPERVISION.GEV.id_evaluaciones = DGV.CurrentRow.Cells[1].Value.ToString(); //CLAVE
                PAN_SUPERVISION.GEV.realizar_ejecucuion();
                PAN_SUPERVISION.GEV.AÑO = año_historial;
                PAN_SUPERVISION.GEV.semestre = DGV.CurrentRow.Cells[8].Value.ToString(); //semestre


                this.Close();


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

    }
}