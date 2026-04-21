using ERP_COMPLETO.PROCEDIMIENTOS._2_EQUIPAMIENTO.MANTENIMIENTO;
using ERP_LIEC;
using iTextSharp.text;
using iTextSharp.text.pdf;
using MySql.Data.MySqlClient;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;


namespace ERP_COMPLETO.PROCEDIMIENTOS
{
    public partial class SIDEBAR_PRINCIPAL_OP : Form
    {
        public SIDEBAR_PRINCIPAL_OP()
        {
            InitializeComponent();


            // Recorremos todos los labels del formulario y les asignamos eventos
            foreach (Control c in this.Controls)
            {
                if (c is Label lbl)
                {
                    lbl.MouseEnter += Label_MouseEnter;
                    lbl.MouseLeave += Label_MouseLeave;
                }
            }

        }

        private void label23_Click(object sender, EventArgs e)
        {
            contextMenuStrip1.Show(label23, new Point(5, 5));
        }

        private void verListaToolStripMenuItem_Click(object sender, EventArgs e)
        {


            Form nv = new Form();
            using (AGENDAR_SALA_DE_JUNTAS mn = new AGENDAR_SALA_DE_JUNTAS())
            {
                nv.StartPosition = FormStartPosition.Manual;
                nv.FormBorderStyle = FormBorderStyle.None;
                nv.Opacity = .70d;
                nv.BackColor = System.Drawing.Color.Black;
                nv.WindowState = FormWindowState.Maximized;
                nv.TopMost = false;
                nv.Location = this.Location;
                nv.ShowInTaskbar = false;
                nv.Show();
                mn.Owner = nv;
                mn.TopMost = false;
                mn.Opacity = 0;






                mn.ShowDialog();

                nv.Dispose();
            }
        }

        private void cargarListaToolStripMenuItem_Click(object sender, EventArgs e)
        {


            Form nv = new Form();
            using (AGENDAR_SALA_DE_JUNTAS2 mn = new AGENDAR_SALA_DE_JUNTAS2())
            {
                nv.StartPosition = FormStartPosition.Manual;
                nv.FormBorderStyle = FormBorderStyle.None;
                nv.Opacity = .70d;
                nv.BackColor = System.Drawing.Color.Black;
                nv.WindowState = FormWindowState.Maximized;
                nv.TopMost = false;
                nv.Location = this.Location;
                nv.ShowInTaskbar = false;
                nv.Show();
                mn.Owner = nv;
                mn.TopMost = false;
                mn.Opacity = 0;






                mn.ShowDialog();

                nv.Dispose();
            }
        }

        private void label20_Click(object sender, EventArgs e)
        {
            SOLICITUD_REPORTE_ERP mn = new SOLICITUD_REPORTE_ERP();
            mn.deconsulta = false;
            mn.ShowDialog();
        }

        private void label21_Click(object sender, EventArgs e)
        {
            Form nv = new Form();
            using (BUZON_QUEJAS mn = new BUZON_QUEJAS())
            {
                nv.StartPosition = FormStartPosition.Manual;
                nv.FormBorderStyle = FormBorderStyle.None;
                nv.Opacity = .70d;
                nv.BackColor = System.Drawing.Color.Black;
                nv.WindowState = FormWindowState.Maximized;
                nv.TopMost = true;
                nv.Location = this.Location;
                nv.ShowInTaskbar = false;
                nv.Show();
                mn.Owner = nv;
                mn.Opacity = 0;


                mn.ShowDialog();

                nv.Dispose();
            }
        }




        private void Label_MouseEnter(object sender, EventArgs e)
        {
            Label lbl = sender as Label;

            lbl.Font = new System.Drawing.Font("Poppins", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

        }

        private void Label_MouseLeave(object sender, EventArgs e)
        {
            Label lbl = sender as Label;

            lbl.Font = new System.Drawing.Font("Poppins", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

        }








        private void label28_Click(object sender, EventArgs e)
        {

            Form nv = new Form();
            using (REPORTE_INSTALACIONES mn = new REPORTE_INSTALACIONES())
            {
                nv.StartPosition = FormStartPosition.Manual;
                nv.FormBorderStyle = FormBorderStyle.None;
                nv.Opacity = .70d;
                nv.BackColor = System.Drawing.Color.Black;
                nv.WindowState = FormWindowState.Maximized;
                nv.TopMost = false;
                nv.Location = this.Location;
                nv.ShowInTaskbar = false;
                nv.Show();
                mn.Owner = nv;
                mn.TopMost = false;
                mn.Opacity = 0;






                mn.ShowDialog();

                nv.Dispose();
            }
        }

        private void label32_Click(object sender, EventArgs e)
        {


            MENU_PRI.MNM.contenido.Controls.Clear();
            CONSULTA_SERVICIOS_PERMANENTES ordenes2 = new CONSULTA_SERVICIOS_PERMANENTES();


            ordenes2.TopLevel = false;
            MENU_PRI.MNM.contenido.Controls.Add(ordenes2);
            ordenes2.Show();
        }

        private void label14_Click(object sender, EventArgs e)
        {

            // Colores de informes 
            BaseColor zu = new BaseColor(16, 77, 141);
            BaseColor bo = new BaseColor(50, 50, 50);
            BaseColor wt = new BaseColor(255, 255, 255);
            BaseColor gr = new BaseColor(85, 85, 85);
            BaseColor ng = new BaseColor(10, 10, 10);

            ///estilachos
            BaseFont titulo = BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1250, true);
            BaseFont regulares = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1250, true);

            iTextSharp.text.Font title = FontFactory.GetFont("Arial", 10, 1, ng);
            iTextSharp.text.Font standardFont = FontFactory.GetFont("Arial", 6, 1, BaseColor.BLACK);
            iTextSharp.text.Font standardFont2 = FontFactory.GetFont("Arial", 5, 1, BaseColor.BLACK);
            iTextSharp.text.Font small = FontFactory.GetFont("Arial", 6, 0, ng);
            iTextSharp.text.Font small_n = FontFactory.GetFont("Arial", 6, 1, wt);

            string plantilla = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string pl = Path.Combine(plantilla, "Directorio de Correos.pdf");

            string pdf_f = Path.Combine(plantilla, "Directorio de Correos.pdf");


            iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(ERP_COMPLETO.Properties.Resources.ENCABEZADO_V_LAB, System.Drawing.Imaging.ImageFormat.Jpeg);
            iTextSharp.text.Image img2 = iTextSharp.text.Image.GetInstance(ERP_COMPLETO.Properties.Resources.PIE_LAB_VERTICAL, System.Drawing.Imaging.ImageFormat.Jpeg);





            // DOCUMENTO CREADO EN ITEXSHARP

            // Creamos el documento con el tamaño de página tradicional
            Document doc = new Document(PageSize.LETTER);
            // Indicamos donde vamos a guardar el documento
            PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(pdf_f, FileMode.Create, FileAccess.Write, FileShare.None));

            // Abrimos el archivo
            doc.Open();
            try
            {


                //var logo = iTextSharp.text.Image.GetInstance("Logo.png");
                var T_encabezado = new iTextSharp.text.Paragraph("\r\nDIRECTORIO DE CORREOS \r\n CORPORATIVOS\r\n", title);
                T_encabezado.SpacingBefore = 200;//Espacio de escritura
                T_encabezado.Alignment = 1; //0-Left, 1 middle,2 Right

                doc.Add(T_encabezado);

                //var logo = iTextSharp.text.Image.GetInstance("Logo.png");
                var T_encabezado2 = new iTextSharp.text.Paragraph("\r\nFR-LIEC-02_25", standardFont);
                T_encabezado2.SpacingBefore = 3;//Espacio de escritura
                T_encabezado2.Alignment = 1; //0-Left, 1 middle,2 Right

                doc.Add(T_encabezado2);





                doc.Add(Chunk.NEWLINE);


                //   encabezado.ScaleAbsolute(525, 70);
                img.ScaleToFit(535f, 80F);
                //Imagen - Esquina inferior izquierda
                img.SetAbsolutePosition(35, 690);
                doc.Add(img);


            }
            catch (System.Exception ex)
            {
                throw new System.Exception(ex.ToString(), ex);
            }

            try
            {


                PdfPTable table = new PdfPTable(13);

                table.TotalWidth = 500f;
                table.LockedWidth = true;

                PdfPCell cell = new PdfPCell(new Phrase("NOMBRE", small_n));
                cell.BackgroundColor = zu;
                cell.BorderColor = bo;
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                cell.VerticalAlignment = Element.ALIGN_MIDDLE;

                cell.Rowspan = 9;
                cell.Colspan = 5;
                table.AddCell(cell);


                cell = new PdfPCell(new Phrase("CORREO CORPORATIVO", small_n));
                cell.BackgroundColor = zu;
                cell.BorderColor = bo;
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell.PaddingBottom = 4f;
                cell.PaddingLeft = 3f;
                cell.PaddingTop = 1f;
                cell.Rowspan = 9;
                cell.Colspan = 8;
                table.AddCell(cell);






                //table.AddCell(FINSPECCION.Text);
                doc.Add(table);
            }
            catch { }

            MySqlConnection CONEXION2 = conexion_rh.USR;
            CONEXION2.Open();
            MySqlCommand comando2 = new MySqlCommand("SELECT NOMBRE, EMAIL FROM  pdr_personal1 WHERE ESTATUS = 'ACTIVO' AND EMAIL != '' ORDER BY NOMBRE ASC", CONEXION2);

            MySqlDataReader consulta2 = comando2.ExecuteReader();



            while (consulta2.Read())
            {

                string a1 = consulta2["NOMBRE"].ToString();
                string a2 = consulta2["EMAIL"].ToString();
                try
                {


                    PdfPTable table = new PdfPTable(13);

                    table.TotalWidth = 500f;
                    table.LockedWidth = true;

                    PdfPCell cell = new PdfPCell(new Phrase(a1, small));
                    cell.BackgroundColor = wt;
                    cell.BorderColor = bo;
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell.VerticalAlignment = Element.ALIGN_MIDDLE;

                    cell.Rowspan = 9;
                    cell.Colspan = 5;
                    table.AddCell(cell);


                    cell = new PdfPCell(new Phrase(a2, small));
                    cell.BackgroundColor = wt;
                    cell.BorderColor = bo;
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                    cell.PaddingBottom = 4f;
                    cell.PaddingLeft = 3f;
                    cell.PaddingTop = 1f;
                    cell.Rowspan = 9;
                    cell.Colspan = 8;
                    table.AddCell(cell);






                    //table.AddCell(FINSPECCION.Text);
                    doc.Add(table);
                }
                catch { }

            }
            CONEXION2.Close();


            doc.Close();

            MENSAJE_GENERAL MN = new MENSAJE_GENERAL();
            MN.BOTON.Text = "Directorio Generado";
            MN.ShowDialog();


        }

        private void label24_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {
            Form nv = new Form();
            using (FORMULARIO_CONSULTA_PERSONAL mn = new FORMULARIO_CONSULTA_PERSONAL())
            {
                nv.StartPosition = FormStartPosition.Manual;
                nv.FormBorderStyle = FormBorderStyle.None;
                nv.Opacity = .70d;
                nv.BackColor = System.Drawing.Color.Black;
                nv.WindowState = FormWindowState.Maximized;
                nv.TopMost = true;
                nv.Location = this.Location;
                nv.ShowInTaskbar = false;
                nv.Show();
                mn.Owner = nv;
                mn.Opacity = 0;
                mn.proceso = SESION.proceso;
                mn.usuario = SESION.usuario;





                mn.ShowDialog();

                nv.Dispose();
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

            Form nv = new Form();
            using (PERMISOS mn = new PERMISOS())
            {
                nv.StartPosition = FormStartPosition.Manual;
                nv.FormBorderStyle = FormBorderStyle.None;
                nv.Opacity = .70d;
                nv.BackColor = System.Drawing.Color.Black;
                nv.WindowState = FormWindowState.Maximized;
                nv.TopMost = true;
                nv.Location = this.Location;
                nv.ShowInTaskbar = false;
                nv.Show();
                mn.Owner = nv;
                mn.Opacity = 0;
                mn.proceso = SESION.proceso;
                mn.usuario = SESION.usuario;
                mn.comboBox1.Texts = SESION.usuario;
                mn.solo_consulta = true;

                if (SESION.puesto == "TECNOLOGÍA DE LA INFORMACIÓN")
                {
                    mn.comboBox1.Enabled = true;
                    mn.altoButton1.Visible = true;

                    mn.personal.Enabled = true;
                    mn.equipamiento.Enabled = true;
                    mn.ofertas.Enabled = true;
                    mn.operaciones.Enabled = true;
                    mn.calidad.Enabled = true;
                    mn.administracion.Enabled = true;
                    mn.generales.Enabled = true;


                    mn.recursos_humanos.Enabled = true;
                    mn.supervision.Enabled = true;

                    mn.mantenimiento.Enabled = true;
                    mn.tic.Enabled = true;

                    mn.revision_solicitudes.Enabled = true;
                    mn.dns.Enabled = true;

                    mn.concreto.Enabled = true;
                    mn.tereracerias.Enabled = true;
                    mn.acero_refuerzo.Enabled = true;
                    mn.priebas_no_destructivas.Enabled = true;
                    mn.asfaltos.Enabled = true;

                    mn.contabilidad.Enabled = true;
                    mn.cobranza.Enabled = true;

                }


                mn.ShowDialog();

                nv.Dispose();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            CONFIGURA_SUCURSAL cf = new CONFIGURA_SUCURSAL();
            cf.ShowDialog();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            SOLICITUD_EQUIPO_USUARIO sOLICITUD_EQUIPO_USUARIO = new SOLICITUD_EQUIPO_USUARIO();
            sOLICITUD_EQUIPO_USUARIO.ShowDialog();
        }
    }
}
