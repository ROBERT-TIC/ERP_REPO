using ERP_LIEC;
using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace ERP_COMPLETO
{
    public partial class CONTROL_CATEGORIAS : Form
    {
        public CONTROL_CATEGORIAS()
        {
            InitializeComponent();
        }

        private void rjButton1_Click(object sender, EventArgs e)
        {
            /* conexion_rh.Consultageneral("INSERT INTO areas_trabajo(AREA, DESCRIPCION, FECHA_REGISTRO, RANGO_ACTIVIDAD, COORDINADOR) VALUES('"+nom_area.Texts+"','"+observaciones.Texts+"','"+FECHA.Text+"','"+MOTIVO.Texts+"','"+NOMBRE.Texts+"')");
             MessageBox.Show("Se ha dado de alta una nueva área");*/
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void filtrar_coordinador()
        {
            MySqlConnection CONEXION = conexion_supervision_tecnica.USR;


            MySqlCommand comando = new MySqlCommand("SELECT DISTINCTROW NORMA FROM normas  ORDER BY NORMA ASC", CONEXION);
            CONEXION.Open();
            MySqlDataReader registro = comando.ExecuteReader();

            while (registro.Read())
            {

                ESTANDAR.Items.Add(registro["NORMA"].ToString());

            }

            CONEXION.Close();

        }

        private void filtrar_coordinador2()
        {
            MySqlConnection CONEXION = conexion_rh.USR;


            MySqlCommand comando = new MySqlCommand("SELECT DISTINCTROW CATEGORIA FROM categorias WHERE TIPO = 'TÉCNICO' ORDER BY CATEGORIA ASC", CONEXION);
            CONEXION.Open();
            MySqlDataReader registro = comando.ExecuteReader();

            while (registro.Read())
            {

                CATEGORIA.Items.Add(registro["CATEGORIA"].ToString());

            }

            CONEXION.Close();

        }

        private void consecutivo()
        {
            DGV.Rows.Clear();


            MySqlConnection CONEXION = conexion_supervision_tecnica.USR;


            MySqlCommand comando = new MySqlCommand("SELECT DISTINCTROW * FROM  categorias_norma WHERE CATEGORIA = '" + CATEGORIA.Texts + "'", CONEXION);
            CONEXION.Open();
            MySqlDataReader registro = comando.ExecuteReader();

            while (registro.Read())
            {
                string a0 = registro.IsDBNull(0) ? String.Empty : registro.GetString(0);
                string a1 = registro.IsDBNull(1) ? String.Empty : registro.GetString(1);
                string a2 = registro.IsDBNull(2) ? String.Empty : registro.GetString(2);





                DGV.Rows.Add(a0, a1, a2, "Eliminar");


            }


            CONEXION.Close();


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
            filtrar_coordinador();
            filtrar_coordinador2();
            consecutivo();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Opacity = this.Opacity + .20;


            if (this.Opacity == 1)
            {

                timer1.Stop();
            }
        }


        private void rjComboBox1_OnSelectedIndexChanged(object sender, EventArgs e)
        {

            consecutivo();
        }

        private void altoButton1_Click(object sender, EventArgs e)
        {
            conexion_supervision_tecnica.Consultageneral("INSERT INTO categorias_norma(CATEGORIA,NORMA) VALUES('" + CATEGORIA.Texts.ToUpper() + "','" + ESTANDAR.Texts.ToUpper() + "')");
            MENSAJE_GENERAL MN = new MENSAJE_GENERAL();
            MN.BOTON.Text = "ESTÁNDAR REGISTRADO A CATEGORIA CORRECTAMENTE";
            MN.ShowDialog();
            consecutivo();

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
    }
}
