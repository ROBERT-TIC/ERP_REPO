using ERP_LIEC;   //DEFINEN UN AMBITO PARA UTILIZAR RECURSOS //
using MySql.Data.MySqlClient;
using System;
using System.ComponentModel;
using System.Windows.Forms;   //DEFINEN UN AMBITO PARA UTILIZAR RECURSOS //

namespace ERP_COMPLETO   //NOMBRE DEL ESPACIO
{
    public partial class ASIGNACION_VEHICULO : Form
    {
        public ASIGNACION_VEHICULO()
        {
            InitializeComponent();
            contextMenuStrip1.Renderer = new MyRenderer();
        }

        private class MyRenderer : ToolStripProfessionalRenderer
        {
            public MyRenderer() : base(new MyColors()) { }
        }
        private class MyColors : ProfessionalColorTable
        {
            public override System.Drawing.Color MenuItemSelected
            {
                get { return System.Drawing.Color.FromArgb(225, 92, 0); }  //ESTILOS APLICABLES A ELEMENTOS 
            }
            public override System.Drawing.Color MenuItemSelectedGradientBegin
            {
                get { return System.Drawing.Color.Orange; }
            }
            public override System.Drawing.Color MenuItemSelectedGradientEnd  //ESTILOS APLICABLES A ELEMENTOS 
            {
                get { return System.Drawing.Color.Yellow; }
            }
        }

        private void ASIGNACION_VEHICULO_Load(object sender, EventArgs e)
        {
            DGV.DataSource = conexion_mantenimineto.Consultageneral("SELECT * FROM asignacion_vehicular WHERE ID_VEHICULO = '" + id_vehiculo.Text + "'");  //QUERY DE CONSULTA
            can_m.Text = Convert.ToString(DGV.RowCount); // CONTEO DE REGISTROS DESDE LA TABLA

            consulta_responsable();
            colorea_tabla();
            estetica();


        }

        private void consulta_responsable()
        {
            MySqlConnection CONEXION = conexion_rh.USR;

            CONEXION.Open();
            MySqlCommand comando = new MySqlCommand("select NOMBRE from pdr_personal1 ORDER BY NOMBRE ASC", CONEXION);

            MySqlDataReader registro = comando.ExecuteReader();

            while (registro.Read())
            {

                responsable.Items.Add(registro["NOMBRE"].ToString());

            }

            CONEXION.Close();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void estetica()
        {
            //this.ET.SetToolTip(pictureBox9, "Generar Informe Técnico");
            int tam = pac.Width / 2;

            pac1.Width = tam;
            pac2.Width = tam;  //ESTILOS APLICABLES A ELEMENTOS 

            lb1.Left = (pac1.Width - lb1.Width) / 2;
            lb2.Left = (pac2.Width - lb2.Width) / 2;

            label9.Left = (PANEL_REFERENCIA.Width - label9.Width) / 2;  //ESTILOS APLICABLES A ELEMENTOS 
            label9.Top = (PANEL_REFERENCIA.Height - label9.Height) / 2;
            pictureBox1.Left = (label9.Left - pictureBox1.Width) - 3;
            pictureBox1.Top = (PANEL_REFERENCIA.Height - pictureBox1.Height) / 2;  //ESTILOS APLICABLES A ELEMENTOS 
        }
        private void rest_pest()
        {
            BA1.Visible = false;
            BA2.Visible = false;

        }

        private void lb1_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage1;
            rest_pest();
            BA1.Visible = true;
        }

        private void lb2_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage2;
            rest_pest();
            BA2.Visible = true;
            DGV.DataSource = conexion_mantenimineto.Consultageneral("SELECT * FROM asignacion_vehicular WHERE ID_VEHICULO = '" + id_vehiculo.Text + "'");   //QUERY DE CONSULTA

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
        public void colorea_tabla()
        {


            DGV.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            DGV.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            DGV.RowHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            DGV.Columns[0].HeaderText = "ID";  //DEPOSITO DE INFORMACION
            DGV.Columns[1].HeaderText = "ID de Asignación";  //DEPOSITO DE INFORMACION
            DGV.Columns[2].HeaderText = "ID de Vehiculo   ";
            DGV.Columns[3].HeaderText = "Placas      ";
            DGV.Columns[4].HeaderText = "Fecha de Solicitud        ";
            DGV.Columns[5].HeaderText = "Fecha de Entrega";
            DGV.Columns[6].HeaderText = "Responsable               ";
            DGV.Columns[7].HeaderText = "Km Inicial    ";
            DGV.Columns[8].HeaderText = "Km Final    ";
            DGV.Columns[9].HeaderText = "Nivel de Gasolina Inicial";  //DEPOSITO DE INFORMACION
            DGV.Columns[10].HeaderText = "Nivel de Gasolina Final";
            DGV.Columns[11].HeaderText = "Número de Tarjeta de Gasolina";
            DGV.Columns[12].HeaderText = "Ubicación";  //DEPOSITO DE INFORMACION


        }
        private void claveo_Click(object sender, EventArgs e)
        {


            try
            {
                Random random = new Random();
                int numero = random.Next(1, 2000);
                string id_asignacion = "LIE-AS-" + Convert.ToString(numero);
                conexion_mantenimineto.registrar("INSERT INTO asignacion_vehicular (ID_ASIGNACION, ID_VEHICULO, PLACAS,TAR_GAS,FECHA_SOLICITUD, KM_INICIO, GASOLINA_INICIO, RESPONSABLE) values ('" + id_asignacion + "','" + id_vehiculo.Text + "','" + placas.Texts + "' , '" + tar_gasolina.Texts + "' , '" + fecha_sol.Text + "' , '" + km_ini.Texts + "' , '" + gasolina.Texts + "' , '" + responsable.Texts + "')");

                //UPDATE ESTATUS
                conexion_mantenimineto.registrar("UPDATE autos SET ESTATUS = 'ASIGNADO' WHERE ID_VEHICULO  = '" + id_vehiculo.Text + "'");
                conexion_mantenimineto.registrar("UPDATE autos SET RESPONSABLE = '" + responsable.Texts + "' WHERE ID_VEHICULO  = '" + id_vehiculo.Text + "'");
                // conexion_mantenimineto.registrar("INSERT INTO verificacion_vehicular (ID_VEHICULO, MARCA, MODELO, PLACAS, ENGOMADO, BIMESTRE_A, BIMESTRE_B, DIA_DESCANSO) values ('" + id_recepcion + "','" + marca.Texts + "' , '" + modelo.Texts + "' , '" + placas.Texts + "' , '" + engomado.Texts + "', '" + primero.Texts + "', '" + segundo.Texts + "', '" + descanso.Texts + "' )");

                DGV.DataSource = conexion_mantenimineto.Consultageneral("SELECT * FROM asignacion_vehicular WHERE ID_VEHICULO = '" + id_vehiculo.Text + "'");
                can_m.Text = Convert.ToString(DGV.RowCount); // CONTEO DE REGISTROS DESDE LA TABLA

                MENSAJE_GENERAL MN = new MENSAJE_GENERAL();
                MN.BOTON.Text = "Registro exitoso";
                MN.Show();





            }

            catch
            {
                MENSAJE_GENERAL MN = new MENSAJE_GENERAL();
                MN.BOTON.Text = "Error al realizar el registro";   //MENSAJE ALERTA 
                MN.Show();
            }

            DateTime Horareal = DateTime.Now;
            OP.registrar("INSERT INTO procesos_cotidianos (USUARIO,FECHA,TIEMPO,ACCION,IP_ADREES,AREA,OBRA) VALUES ('" + SESION.usuario + "',  '" + DateTime.Today.ToString("yyyy-MM-dd") + "', '" + DateTime.Now.ToString("HH:mm:ss") + "' , '" + "ASIGNO UN VEHICULO" + " ', '" + SESION.IP + "','" + SESION.puesto + "', '" + SESION.obra + "' )");



        }

        private void DGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void EntregarVehiculo_Click(object sender, EventArgs e)
        {
            Form nv = new Form();
            using (ENTREGA_VEHICULO mn = new ENTREGA_VEHICULO())
            {
                nv.StartPosition = FormStartPosition.Manual;     //ESTILOS APLICABLES A ELEMENTOS
                nv.FormBorderStyle = FormBorderStyle.None;
                nv.Opacity = .70d;
                nv.BackColor = System.Drawing.Color.Black;
                nv.WindowState = FormWindowState.Maximized;    //ESTILOS APLICABLES A ELEMENTOS
                nv.TopMost = false;
                nv.Location = this.Location;
                nv.ShowInTaskbar = false;
                nv.Show();
                mn.Owner = nv;
                // mn.Opacity = 0;
                mn.ID = DGV.CurrentRow.Cells[1].Value.ToString();
                mn.id_vehiculo.Text = DGV.CurrentRow.Cells[1].Value.ToString();

                //CONEXION TABLA recepcion_equipo CON VENTANA EMERGENTE DETALLES_EQUIPO

                mn.id_vehiculo.Text = id_vehiculo.Text;
                mn.marca.Texts = marca.Texts;
                mn.modelo.Texts = modelo.Texts;
                mn.año.Texts = año.Texts;
                mn.placas.Texts = placas.Texts;
                mn.tar_gasolina.Texts = tar_gasolina.Texts;


                //mn.combustible.Texts = DGV_PADRON.CurrentRow.Cells[8].Value.ToString();
                //mn.reponsable.Texts = DGV_PADRON.CurrentRow.Cells[11].Value.ToString();
                //mn.estatus.Texts = DGV_PADRON.CurrentRow.Cells[10].Value.ToString();
                //mn.engomado.Texts = DGV_PADRON.CurrentRow.Cells[9].Value.ToString();
                mn.ShowDialog();

                nv.Dispose();
            }
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show(
               "Esta seguro que desea eliminar este vehiculo", "PRECAUCIÓN", MessageBoxButtons.YesNo);

            if (res == DialogResult.Yes)
            {
                conexion_mantenimineto.registrar("DELETE FROM asignacion_vehicular WHERE ID_VEHICULO = '" + DGV.CurrentRow.Cells["ID_VEHICULO"].Value.ToString() + "'");

                DGV.DataSource = conexion_mantenimineto.Consultageneral("SELECT ID_VEHICULO, PLACAS, ESTATUS FROM autos");
                MessageBox.Show("El vehiculo seleccionado se a eliminado correctamente", "ALERTA");

                DGV.DataSource = conexion_mantenimineto.Consultageneral("SELECT * FROM asignacion_vehicular WHERE ID_VEHICULO = '" + id_vehiculo.Text + "'");
            }
            else { }

        }

        private void responsable_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = conexion_rh.Consultageneral("SELECT NOMBRE,NOMBRE_AREA_TEC FROM pdr_personal1 WHERE NOMBRE = '" + responsable.Texts + "'");

            if (responsable.Texts == dataGridView1.CurrentRow.Cells["NOMBRE"].Value.ToString())
            {
                dataGridView2.DataSource = conexion_servicios_eventuales.Consultageneral("SELECT DIRECCION_OBRA FROM listado_obras WHERE ALIAS = '" + dataGridView1.CurrentRow.Cells["NOMBRE_AREA_TEC"].Value.ToString() + "'");

                if (dataGridView2.Rows.Count > 0)
                {
                    domicilio.Texts = dataGridView2.CurrentRow.Cells["DIRECCION_OBRA"].Value.ToString();
                }
                else
                {

                }
            }
            else { }
        }
    }
}
