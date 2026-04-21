using ERP_LIEC;
using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace ERP_COMPLETO
{
    public partial class NUEVA_NORMA_DASHBOARD : Form
    {
        public NUEVA_NORMA_DASHBOARD()
        {
            InitializeComponent();
        }

        public string id_evaluacion;
        public string nombre;
        public string categoria;




        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
            FILTRA_NORMA();
            TABLA_diseño();

            ID_V.Text = id_evaluacion;
            NOMBRE_L.Text = nombre;
            CATE.Text = categoria;
        }


        //FILTRA NORMA
        private void FILTRA_NORMA()
        {
            MySqlConnection CONEXION = conexion_supervision_tecnica.USR;
            CONEXION.Open();
            MySqlCommand comando = new MySqlCommand("SELECT DISTINCTROW NORMA FROM normas ORDER BY NORMA ASC", CONEXION);

            MySqlDataReader registro = comando.ExecuteReader();

            while (registro.Read())
            {
                NORMA.Items.Add(registro["NORMA"].ToString());
            }
            CONEXION.Close();
        }



        private void OBRA_OnSelectedIndexChanged(object sender, EventArgs e)
        {

            TABLE_NORMAS.DataSource = conexion_supervision_tecnica.Consultageneral("SELECT * FROM normas WHERE NORMA = '" + NORMA.Texts + "' ");
            if (TABLE_NORMAS.RowCount != 0)
            {
                AREA.Texts = TABLE_NORMAS.Rows[0].Cells[3].Value.ToString();
            }
            else
            {
            }
        }

        private void altoButton2_Click(object sender, EventArgs e)
        {
            if (NORMA.Texts != string.Empty)
            {
                DGV.Rows.Add(NORMA.Texts, "Eliminar");

                // DGV.Rows.Clear();
            }
        }





        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }





        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Opacity = this.Opacity + .20;


            if (this.Opacity == 1)
            {

                timer1.Stop();
            }
        }


        string met;
        int contador = 0;

        private void altoButton1_Click(object sender, EventArgs e)
        {


            foreach (DataGridViewRow row in DGV.Rows)
            {


                contador = 5;




                tabla.DataSource = conexion_supervision_tecnica3.Consultageneral("SELECT DESCRIPCION FROM normas WHERE NORMA = '" + row.Cells[0].Value.ToString() + "'");
                if (tabla.RowCount > 0)
                {
                    met = tabla.Rows[0].Cells[0].Value.ToString();
                }
                else
                {
                    met = "Desconocidos";
                }


                ComboBox COM = new ComboBox();
                MySqlConnection CONEXION2 = conexion_supervision_tecnica2.USR;
                MySqlCommand comando2 = new MySqlCommand("SELECT ID_CUESTION FROM cuestionaminetos_norma  WHERE NORMA = '" + row.Cells[0].Value.ToString() + "' ", CONEXION2);
                CONEXION2.Open();
                MySqlDataReader consulta2 = comando2.ExecuteReader();
                Random rnd = new Random();
                while (consulta2.Read())
                {
                    COM.Items.Add(consulta2["ID_CUESTION"].ToString());


                }



                while (contador > 0)
                {

                    int index = rnd.Next(0, COM.Items.Count);
                    string dada = COM.Items[index].ToString();
                    conexion_supervision_tecnica3.Consultageneral("INSERT INTO evaluacion_personal (ID_EVALUACION, ID_CUESTION, NORMA, RESPUESTA, CALIFICACION, METODO, FECHA, NOMBRE, AREA) VALUES ('" + id_evaluacion + "', '" + dada + "', '" + row.Cells[0].Value.ToString() + "', '', '0.00', '" + met + "', '" + DateTime.Today.ToString("yyyy-MM-dd") + "', '" + nombre + "', '" + AREA.Texts + "')");


                    contador = contador - 1;

                    COM.Items.RemoveAt(index);
                }



                CONEXION2.Close();

                this.Close();

            }


            PAN_SUPERVISION.GEV.panel1.Controls.Clear();
            PAN_SUPERVISION.GEV.realizar_ejecucuion();

        }

        private void DGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
            e.RowIndex >= 0)
            {




                conexion_supervision_tecnica.USR.Open();//Se abre la conexión para evitar un error común

                String Query = "DELETE  FROM categorias_norma WHERE ID_SEGUIMIENTO  = '" + DGV.CurrentRow.Cells[0].Value.ToString() + "';";
                MySqlCommand comando = new MySqlCommand(Query, conexion_supervision_tecnica.USR);//Se interpreta el comando del query
                comando.ExecuteNonQuery();//Se ejecuta el comando del query

                conexion_supervision_tecnica.USR.Close();//Se cierra la conexión
                DGV.Rows.RemoveAt(DGV.CurrentRow.Index);


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
