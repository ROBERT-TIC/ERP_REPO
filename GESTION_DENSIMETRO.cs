using ERP_LIEC;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERP_COMPLETO
{
    public partial class GESTION_DENSIMETRO : Form
    {
        public GESTION_DENSIMETRO()
        {
            InitializeComponent();
        }


        private void dimensiones()
        {
            panel4.Height = 43; panel2.Height = 34; panel3.Height = 43;
 
            total.Left = DGV_PADRON.Width - total.Width - 20;
            label8.Left = total.Left - label8.Width - 5;

            label8.Top = (panel3.Height - label8.Height) / 2;
            total.Top = (panel3.Height - total.Height) / 2;
        }

        private void consulta_densimetro()
        {

            DGV_PADRON.DataSource = CONEXION_REMOTO_PND.CONSULTA_GENERAL("SELECT ID_SEGUIMIENTO, CLAVE_OBRA,NO_INFORME, FECHA_ENSAYE, OBRA, USUARIO  FROM densimetro_referencias  ");
          
            DGV_PADRON.Columns[0].HeaderText = "Id";
            DGV_PADRON.Columns[1].HeaderText = "Clave de obra";
            DGV_PADRON.Columns[2].HeaderText = "Informe";
            DGV_PADRON.Columns[3].HeaderText = "Fecha de ensayo";
            DGV_PADRON.Columns[4].HeaderText = "Obra";
            DGV_PADRON.Columns[5].HeaderText = "Usuario que registro";

            DGV_PADRON.Columns[0].Width = 30;
            DGV_PADRON.Columns[1].Width = 200;
            DGV_PADRON.Columns[2].Width = 200;
            DGV_PADRON.Columns[3].Width = 200;
            DGV_PADRON.Columns[4].Width = 200;
            DGV_PADRON.Columns[5].Width = 200;
        }

        private void GESTION_DENSIMETRO_Load(object sender, EventArgs e)
        {

            dimensiones();
            consulta_densimetro();

        }


        public DENSIMETRO_ELECTROMAGNETICO dn = new DENSIMETRO_ELECTROMAGNETICO();
        private void consultarEstaÓrdenDeTrabajoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dn = new DENSIMETRO_ELECTROMAGNETICO();
            dn.didi = DGV_PADRON.CurrentRow.Cells["ID_SEGUIMIENTO"].Value.ToString();
            dn.ShowDialog();
        }



    }
}
