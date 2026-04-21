using ERP_LIEC;  //DEFINEN UN AMBITO PARA UTILIZAR RECURSOS //
using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;  //DEFINEN UN AMBITO PARA UTILIZAR RECURSOS //

namespace ERP_COMPLETO   //NOMBRE DEL ESPACIO
{
    public partial class CONSULTA_NORMA : Form   //CLASE PRINCIPAL DEL FORMULARIO ACTUAL
    {
        public CONSULTA_NORMA()
        {
            InitializeComponent();  //INICIALIZA COMPONENTE
        }


        public string norma;  //VARIABLES INICIALES



        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }



        private void DETALLE_DE_EGRESOS_Load(object sender, EventArgs e)  //FUNCION PRINCIPAL DE ARRANQUE
        {

            timer1.Start();
            consulta_egresos_prov();  //FUNCIONES A LLAMAR AL INICIAR EL FORMULARIO
            TABLA_diseño();

        }
        private void consulta_egresos_prov()
        {
            MySqlConnection CONEXION = conexion_supervision_tecnica.USR;  //CONEXION A DB 
            MySqlCommand comando = new MySqlCommand("SELECT * FROM  cuestionaminetos_norma WHERE NORMA = '" + norma + "'", CONEXION);  //QUERY DE CONSULTA

            CONEXION.Open();
            MySqlDataReader consulta = comando.ExecuteReader();

            while (consulta.Read())
            {
                string a0 = consulta.IsDBNull(0) ? String.Empty : consulta.GetString(0);  //DEPOSITO DE INFORMACION
                string a1 = consulta.IsDBNull(1) ? String.Empty : consulta.GetString(1);
                string a2 = consulta.IsDBNull(2) ? String.Empty : consulta.GetString(2);  //DEPOSITO DE INFORMACION
                string a3 = consulta.IsDBNull(3) ? String.Empty : consulta.GetString(3);



                DGV.Rows.Add(a0, a1, a2, a3, "Eliminar");  //DEPOSITO DE INFORMACION
            }

            CONEXION.Close();   //CIERRE DE CONEXION
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
            this.Close();  //CIERRE DE FORM
        }

        private void DGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
            e.RowIndex >= 0)
            {




                conexion_supervision_tecnica.USR.Open();//Se abre la conexión para evitar un error común

                String Query = "DELETE  FROM cuestionaminetos_norma  WHERE ID_SEGUIMIENTO  = '" + DGV.CurrentRow.Cells[0].Value.ToString() + "';";   //QUERY DE CONSULTA
                MySqlCommand comando = new MySqlCommand(Query, conexion_supervision_tecnica.USR);//Se interpreta el comando del query
                comando.ExecuteNonQuery();//Se ejecuta el comando del query

                conexion_supervision_tecnica.USR.Close();//Se cierra la conexión
                DGV.Rows.RemoveAt(DGV.CurrentRow.Index);


            }
        }

        public void TABLA_diseño()   //ESTILOS APLICABLES A ELEMENTOS 
        {
            DGV.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));   //ESTILOS APLICABLES A ELEMENTOS 

            DGV.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DGV.RowHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            for (int i = 0; i < DGV.ColumnCount; i = i + 2)
            {
                DGV.Columns[i].DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(244, 244, 244);
            }
        }



    }
}