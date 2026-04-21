using DocumentFormat.OpenXml.Spreadsheet;
using ERP_LIEC;
////// LIBRERIAS PARA DISEÑO DE FORMATOS
using iTextSharp.text;
using iTextSharp.text.pdf;
using MySql.Data.MySqlClient;
using SpreadsheetLight;
using SpreadsheetLight.Drawing;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
////// LIBRERIAS PARA DISEÑO DE FORMATOS
///


namespace ERP_COMPLETO
{
    public partial class DASHBOARD_EV_PERSONAL : Form
    {
        public DASHBOARD_EV_PERSONAL()
        {
            InitializeComponent();
        }

        public string CATEG;
        public string id_evaluaciones;
        public string AÑO;
        public string semestre;

        public string metodo;



        public void realizar_ejecucuion()
        {
            NOMBRE_L.Visible = true;
            NOMBRE_L.Text = nombre.Texts;

            ID_V.Text = id_evaluaciones;
            ID_V.Visible = true;

            SEM.Visible = true;
            SEM.Text = semestre;

            pictureBox1.Visible = true;

            categoria.Visible = true;
            categoria.Text = CATEG;

            tiempo_ejecucion();
        }


        public string elmetodoconsultado;
        public string norma_eva_per;

        public void tiempo_ejecucion()
        {

            TABLE_3.Rows.Clear();

            tabla.DataSource = conexion_supervision_tecnica.Consultageneral("SELECT DISTINCTROW NORMA FROM evaluacion_personal WHERE ID_EVALUACION = '" + id_evaluaciones + "'   ");
            int x = 50;
            int y = 5;
            int lmh = this.Width - 50;

            foreach (DataGridViewRow row in tabla.Rows)
            {
                Panel pn = new Panel();  //TARJETA EN GENERAL 
                pn.Name = row.Cells[0].Value.ToString();



                pn.BackColor = System.Drawing.Color.White;
                pn.Size = new Size(225, 110);
                pn.Location = new Point(x, y);
                pn.Click += new System.EventHandler(funcion_click);

                bunifuElipse1.ApplyElipse(pn);
                x = x + 245;
                if (x > lmh) { x = 50; y = y + 165; }
                else { x = pn.Right + 15; }

                panel1.Controls.Add(pn);

                Panel pnz = new Panel();  //NORMA
                pnz.Name = row.Cells[0].Value.ToString() + "az";

                norma_eva_per = row.Cells[0].Value.ToString();

                pnz.BackColor = System.Drawing.Color.FromArgb(16, 77, 141);
                pnz.Width = 38;
                pnz.Height = pn.Height;
                pnz.Dock = DockStyle.Left;
                pn.Controls.Add(pnz);


                PictureBox pc = new PictureBox();  //ICONO
                pc.Size = new Size(28, 28);
                pc.Image = ERP_COMPLETO.Properties.Resources.MI_ALTA_RUBRO;
                pc.Top = (pnz.Height - pc.Height) / 2 - 25;
                pc.Left = (pnz.Width - pc.Width) / 2;
                pc.BackColor = System.Drawing.Color.Transparent;
                pc.SizeMode = PictureBoxSizeMode.StretchImage;
                pnz.Controls.Add(pc);



                PictureBox pc2 = new PictureBox();  //ICONO ELIMINAR
                pc2.Size = new Size(18, 18);
                pc2.Name = row.Cells[0].Value.ToString();
                pc2.Image = ERP_COMPLETO.Properties.Resources.Mi_bote_basura2;
                pc2.Top = (pnz.Height - pc2.Height) / 2 + 25;
                pc2.Left = (pnz.Width - pc2.Width) / 2;
                pc2.BackColor = System.Drawing.Color.Transparent;
                pc2.SizeMode = PictureBoxSizeMode.StretchImage;
                pnz.Controls.Add(pc2);
                pc2.Click += new EventHandler(funcion_click2);



                Label lb = new Label(); //CALIFICACION
                lb.Name = row.Cells[0].Value.ToString() + "l";
                lb.Text = row.Cells[0].Value.ToString();
                lb.ForeColor = System.Drawing.Color.FromArgb(16, 77, 141);
                lb.BackColor = System.Drawing.Color.Transparent;
                lb.AutoSize = true;
                lb.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                lb.Location = new Point(45, 10);
                pn.Controls.Add(lb);


                //////////////////////////////////////////////  CONSULTA CALIFICACION  ////////////////////////////////////////////////////

                tabla2.DataSource = conexion_supervision_tecnica2.Consultageneral("SELECT CALIFICACION, METODO FROM evaluacion_personal WHERE NORMA = '" + row.Cells[0].Value.ToString() + "' AND ID_EVALUACION = '" + id_evaluaciones + "' ");

                double calific = 0;

                foreach (DataGridViewRow sm in tabla2.Rows)
                {
                    calific = calific + double.Parse(sm.Cells[0].Value.ToString());
                    calific = Math.Round(calific, 2);

                    if (calific != 0)
                    {
                        pnz.BackColor = System.Drawing.Color.FromArgb(225, 92, 0);
                    }
                }


                Label lb2 = new Label();   //ETIQUETA CALIFICACION
                lb2.Name = row.Cells[0].Value.ToString() + "l2";
                lb2.Text = "Puntuación Obtenida: " + calific.ToString();
                lb2.ForeColor = System.Drawing.Color.FromArgb(16, 77, 141);
                lb2.BackColor = System.Drawing.Color.Transparent;
                lb2.AutoSize = true;
                lb2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                lb2.Location = new Point(45, 30);
                pn.Controls.Add(lb2);

                elmetodoconsultado = tabla2.Rows[0].Cells["METODO"].Value.ToString();


                //////////////////////////////////////////////  DEPOSITA EN EL DGV LOS TRES ELEMENTOS   ////////////////////////////////////////////////////
                TABLE_3.Rows.Add(row.Cells[0].Value.ToString(), elmetodoconsultado, calific.ToString());  //norma, metodo, resultado

            }

            this.AutoScroll = true;
            this.AutoScrollMinSize = new System.Drawing.Size(370, 250);



        }






        //FUNCION DE ELIMINAR TARJETA DE NORMAS
        private void funcion_click2(object sender, EventArgs e)
        {
            var button = sender as PictureBox; //el nombre del boton se mete en una variable "var"
            conexion_supervision_tecnica.USR.Open();//Se abre la conexión para evitar un error común

            String Query = "DELETE FROM evaluacion_personal WHERE NORMA = '" + button.Name + "' AND ID_EVALUACION = '" + id_evaluaciones + "' ";
            MySqlCommand comando = new MySqlCommand(Query, conexion_supervision_tecnica.USR);//Se interpreta el comando del query
            comando.ExecuteNonQuery();//Se ejecuta el comando del query

            conexion_supervision_tecnica.USR.Close();//Se cierra la conexión
            MENSAJE_GENERAL mn = new MENSAJE_GENERAL();
            mn.BOTON.Text = button.Name + "----->" + "Norma eliminada";
            mn.ShowDialog();

        }






        //FUNCION DE EVALUAR
        private void funcion_click(object sender, EventArgs e)
        {
            var button = sender as Panel;

            Form nv = new Form();
            using (HOJA_EVALUACION mn = new HOJA_EVALUACION())
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
                mn.Opacity = 0;
                mn.TopMost = false;
                mn.id_evaluacion = id_evaluaciones;
                mn.NORMA = button.Name;


                mn.ShowDialog();

                nv.Dispose();
            }
        }





        //AGREGAR NUEVA NORMA 
        private void pictureBox3_Click_2(object sender, EventArgs e)
        {
            Form nv = new Form();
            using (NUEVA_NORMA_DASHBOARD nva_norm_dash = new NUEVA_NORMA_DASHBOARD())
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
                nva_norm_dash.Owner = nv;
                nva_norm_dash.Opacity = 0;
                nva_norm_dash.TopMost = false;


                nva_norm_dash.id_evaluacion = id_evaluaciones;
                nva_norm_dash.nombre = NOMBRE_L.Text;
                nva_norm_dash.categoria = CATEG;



                nva_norm_dash.ShowDialog();

                nv.Dispose();
            }
        }


        private void dimensiones()
        {
            panel2.Width = this.Width;
            panel4.Width = this.Width;
            panel2.Height = 43;
            panel4.Height = 50;
            altoButton1.Height = 30;
            panel3.Height = 90;

            label11.Left = (panel2.Width - label11.Width) / 2;
            label11.Top = (panel2.Height - label11.Height) / 2;

            pictureBox2.Left = (label11.Left - pictureBox2.Width);
            pictureBox2.Top = (panel2.Height - pictureBox2.Height) / 2;

            label7.Left = 43;
            label7.Top = (panel4.Height - label7.Height) / 2;

            nombre.Left = ((label7.Left + nombre.Width) / 3) + 5;
            nombre.Top = (panel4.Height - nombre.Height) / 2;

            nombre.Height = 28;

            pictureBox2.Left = (label11.Left - pictureBox2.Width) - 3;

            label7.Top = (panel4.Height - label7.Height) / 2;

            nombre.Top = (panel4.Height - nombre.Height) / 2;
            nombre.Left = (label7.Left + label7.Width) + 5;


            altoButton1.Left = nombre.Right + 10;
            altoButton1.Top = (panel4.Height - altoButton1.Height) / 2;

            REPORTE_EXCEL.Size = new Size(25, 25);
            pictureBox4.Size = new Size(25, 25);
            REFRESH.Size = new Size(25, 25);
            pictureBox3.Size = new Size(28, 28);

            pictureBox4.Left = (panel4.Right - pictureBox4.Width) - 30;
            pictureBox4.Top = altoButton1.Top + 2;

            REPORTE_EXCEL.Left = (pictureBox4.Left - REPORTE_EXCEL.Width) - 15;
            REPORTE_EXCEL.Top = altoButton1.Top + 2;

            pictureBox3.Left = (altoButton1.Right) + 20;
            pictureBox3.Top = altoButton1.Top + 2;

            REFRESH.Left = (REPORTE_EXCEL.Left - REFRESH.Width) - 15;
            REFRESH.Top = REPORTE_EXCEL.Top;

            OBS.Width = nombre.Width - 10;
            OBS.Height = nombre.Height + 20;
            OBS.Left = (panel4.Right - OBS.Width) - 30;
            OBS.Top = (panel3.Height - OBS.Height) / 2;


            label_obs.Top = OBS.Top + 7;
            label_obs.Left = (OBS.Left - label_obs.Width) - 5;

            realizo_f.Left = (label_obs.Left - realizo_f.Width) - 20;
            label40.Left = (realizo_f.Left - label40.Width) - 5;

            realizo_f.Top = (panel3.Height - realizo_f.Height) / 2;
            label40.Top = (panel3.Height - label40.Height) / 2;

            realizo_f.Height = 30;

        }



        private void refrescar_form()
        {
            //MENU_PRICIPAL_ERP.cortaps.reinicia_gestion_evaluacion();

            PAN_SUPERVISION.GEV.panel1.Controls.Clear();
            PAN_SUPERVISION.GEV.realizar_ejecucuion();
        }



        private void DASHBOARD_EV_PERSONAL_Load(object sender, EventArgs e)
        {
            this.ET.SetToolTip(pictureBox3, "Agregar Normas");
            this.ET.SetToolTip(REFRESH, "Refrescar Vista");
            this.ET.SetToolTip(REPORTE_EXCEL, "Generar Reporte Excel");
            this.ET.SetToolTip(pictureBox4, "Generar Reporte PDF");



            dimensiones();
            filtrar_coordinador();

            realizo_f.Texts = SESION.usuario;
            // rjTextBox1.Texts = SESION.name;


            if (SESION.name == "CONCEPCIÓN JIMÉNEZ MEDINA")
            {
                rjTextBox1.Texts = "ARQ. CONCEPCIÓN JIMÉNEZ MEDINA";
            }
            else if (SESION.name == "YAREM SADAHI ALONSO ALVARADO")
            {
                rjTextBox1.Texts = "IQ. YAREM SADAHI ALONSO ALVARADO";
            }
            else if (SESION.name == "HEIDY MAYERLY HERNÁNDEZ MARTÍN")
            {
                rjTextBox1.Texts = "ARQ. HEIDY MAYERLY HERNÁNDEZ MARTÍN";
            }


        }


        private void filtrar_coordinador()
        {
            // MySqlConnection CONEXION = conexion_rh.USR;
            //  MySqlCommand comando = new MySqlCommand("SELECT * FROM pdr_personal1 WHERE AREA = 'TÉCNICO' ORDER BY NOMBRE ASC", CONEXION);

            MySqlConnection CONEXION = conexion_supervision_tecnica.USR;


            MySqlCommand comando = new MySqlCommand("SELECT PERSONAL FROM personal_agenda ", CONEXION);
            //  MySqlCommand comando = new MySqlCommand("SELECT PERSONAL FROM personal_agenda WHERE RESULTADO = '0' ", CONEXION);



            CONEXION.Open();
            MySqlDataReader registro = comando.ExecuteReader();

            while (registro.Read())
            {

                nombre.Items.Add(registro["PERSONAL"].ToString());
            }

            CONEXION.Close();
        }


        private void nombre_OnSelectedIndexChanged_1(object sender, EventArgs e)
        {
            TABLE_1.DataSource = conexion_supervision_tecnica.Consultageneral("SELECT * FROM personal_agenda WHERE PERSONAL = '" + nombre.Texts + "'  ");
            if (TABLE_1.RowCount != 0)
            {
                categoria.Texts = TABLE_1.Rows[0].Cells[7].Value.ToString();
            }


        }


        private void altoButton1_Click(object sender, EventArgs e)
        {

            if (nombre.Texts == string.Empty)
            {
                MENSAJE_GENERAL MN = new MENSAJE_GENERAL();
                MN.BOTON.Text = "Debes seleccionar el nombre de un personal";
                MN.ShowDialog();
            }
            else
            {
                Form nv = new Form();
                using (HISTORIAL_AGENDA_PERSONAL mn = new HISTORIAL_AGENDA_PERSONAL())
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
                    mn.Opacity = 0;
                    mn.TopMost = false;
                    mn.persona = nombre.Texts;
                    mn.categoria_historial = categoria.Texts;
                    //   mn.semestre_historial = SEM.Texts;

                    mn.ShowDialog();

                    nv.Dispose();
                }
            }
        }






        public bool encabezado_BANDERA = false;
        double cant_normas = 0;


        double resss = 0;






        public void DOCUMENTO()
        {
            DialogResult dl = MessageBox.Show("deseas agregar encabezados?", "notificacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dl == DialogResult.Yes)
            {
                encabezado_BANDERA = true;
            }
            else
            {
                encabezado_BANDERA = false;
            }


            //CREAMOS RECURSOS
            //encabezado y pie de página
            iTextSharp.text.Image encabezado = iTextSharp.text.Image.GetInstance(ERP_COMPLETO.Properties.Resources.ENCABEZADO_V_LAB, System.Drawing.Imaging.ImageFormat.Jpeg);
            iTextSharp.text.Image pie_pag = iTextSharp.text.Image.GetInstance(ERP_COMPLETO.Properties.Resources.PIE_LAB_VERTICAL, System.Drawing.Imaging.ImageFormat.Jpeg);

            iTextSharp.text.Image FIRMA_CONCEPCION = iTextSharp.text.Image.GetInstance(ERP_COMPLETO.Properties.Resources.CJIMENEZ, System.Drawing.Imaging.ImageFormat.Jpeg);
            iTextSharp.text.Image FIRMA_YAREM = iTextSharp.text.Image.GetInstance(ERP_COMPLETO.Properties.Resources.YALONSO, System.Drawing.Imaging.ImageFormat.Jpeg);
            iTextSharp.text.Image FIRMA_HEIDY = iTextSharp.text.Image.GetInstance(ERP_COMPLETO.Properties.Resources.HHERNANDEZ, System.Drawing.Imaging.ImageFormat.Jpeg);


            // Colores de informes 
            BaseColor azul_cielo = new BaseColor(141, 180, 226, 255);
            BaseColor gris_bordes = new BaseColor(50, 50, 50);
            BaseColor blanco = new BaseColor(255, 255, 255);
            BaseColor gris_contenido = new BaseColor(85, 85, 85);
            BaseColor gris_cotizaciones = new BaseColor(247, 247, 247);
            BaseColor gris_claro = new BaseColor(233, 233, 233);
            BaseColor gris_oscuro = new BaseColor(247, 247, 247);
            BaseColor negro_titulo = new BaseColor(10, 10, 10);

            BaseColor azul_liec = new BaseColor(16, 77, 141);
            BaseColor naranja_liec = new BaseColor(225, 92, 0);

            BaseColor gris_formatos = new BaseColor(58, 56, 56);
            BaseColor gris_formatos_tabla = new BaseColor(160, 160, 160);
            BaseColor azul_claro = new BaseColor(200, 209, 229);
            BaseColor verde_claro = new BaseColor(242, 245, 220);


            ///tipos y familias de letra
            BaseFont titulo = BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1250, true);
            BaseFont letra_normal = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1250, true);


            iTextSharp.text.Font titulo_principal_blanco = FontFactory.GetFont("Arial", 10, 1, blanco);
            iTextSharp.text.Font letra_titulo_celda_blanco = FontFactory.GetFont("Arial", 10, 1, blanco);


            iTextSharp.text.Font titulo_principal_azul = FontFactory.GetFont("Arial", 11, 1, azul_liec);
            iTextSharp.text.Font letra_azul_nombre = FontFactory.GetFont("Arial", 10, 1, azul_liec);
            iTextSharp.text.Font letra_azul_foreach = FontFactory.GetFont("Arial", 9, 1, azul_liec);
            iTextSharp.text.Font letra_azul_foreach_chica = FontFactory.GetFont("Arial", 7, 1, azul_liec);
            iTextSharp.text.Font letra_azul_foreach_chica2 = FontFactory.GetFont("Arial", 7, 0, azul_liec);
            iTextSharp.text.Font letra_naranja_liec = FontFactory.GetFont("Arial", 10, 1, naranja_liec);
            iTextSharp.text.Font letra_naranja_foreach = FontFactory.GetFont("Arial", 8, 0, naranja_liec);
            iTextSharp.text.Font letra_blanca = FontFactory.GetFont("Arial", 10, 1, blanco);
            iTextSharp.text.Font letra_negra = FontFactory.GetFont("Arial", 8, 0, negro_titulo);

            iTextSharp.text.Font letra_negra_resultados = FontFactory.GetFont("Arial", 8, 1, negro_titulo);





            string documentos = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string pdf_ENCABEZADO = System.IO.Path.Combine(documentos, NOMBRE_L.Text + "-" + "REPORTE DE SUPERVISIÓN.pdf");
            string informe_SIN_ENCABEZADO = System.IO.Path.Combine(documentos, NOMBRE_L.Text + "-" + "REPORTE DE SUPERVISIÓN.pdf");


            // DOCUMENTO CREADO EN ITEXSHARP
            // Creamos el documento con el tamaño de página tradicional
            Document doc = new Document(PageSize.LETTER);
            // Indicamos donde vamos a guardar el documento
            PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(informe_SIN_ENCABEZADO, FileMode.Create));
            // Abrimos el archivo
            doc.Open();



            ///////////////////////////////INICIO DE EDICION////////////////////////////////////////////////////////////////////////
            // ENCABEZADO
            try
            {

                var T_encabezado = new iTextSharp.text.Paragraph("\r\nESTE PDF ES LA PRIMER PRUEBA \r\n DEL TIO ROBERT", titulo_principal_blanco); //titulo con estilo
                T_encabezado.SpacingBefore = 750;//Espacio de escritura hacia arriba
                T_encabezado.Alignment = 1; //0-Left, 1 middle,2 Right

                doc.Add(T_encabezado);


                var T_encabezado3 = new iTextSharp.text.Paragraph("PND-LAB-01", letra_titulo_celda_blanco);
                T_encabezado3.SpacingBefore = 0;//Espacio de escritura arriba
                T_encabezado3.SpacingAfter = 0; //espacio hacia abajo
                T_encabezado3.Alignment = 1; //0-Left, 1 middle,2 Right

                doc.Add(T_encabezado3);
                doc.Add(Chunk.NEWLINE);//salTo de linea

                encabezado.ScaleToFit(535f, 80F);//coordenadas para tamaño carta ENCABEZADO

                pie_pag.ScaleToFit(535f, 80F);//coordenadas para tamaño carta PIE DE PAGINA


                encabezado.SetAbsolutePosition(35, 690);  //top //left 
                if (encabezado_BANDERA == true) { doc.Add(encabezado); }

                pie_pag.SetAbsolutePosition(35, 15);  //LADOS  //ARRIBA (-) ABAJO (+)
                if (encabezado_BANDERA == true) { doc.Add(pie_pag); }


            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString(), ex);
            }



            //REPORTE
            try
            {
                PdfPTable table = new PdfPTable(13);//total de columnas del formato

                table.TotalWidth = 500f;
                table.LockedWidth = true;
                table.SpacingBefore = 0;//Espacio de escritura hacia arriba
                table.SpacingAfter = 0;//espacio despues

                PdfPCell cell = new PdfPCell(new Phrase("REPORTE DE EVALUACIÓN SEMESTRAL", titulo_principal_azul));//se agregan celdas
                cell.BackgroundColor = blanco;
                cell.Border = 0;

                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell.PaddingBottom = 4f; //dimensiones de padding
                cell.PaddingLeft = 1f;
                cell.PaddingTop = 1f;
                cell.FixedHeight = 23f;
                cell.Colspan = 13;  //la celda abarcara las 13 columnas 
                table.AddCell(cell); //agrega la celda 


                //agregamos tabla
                doc.Add(table); //agrega la tabla 
            }
            catch { }


            //NOMBRE
            try
            {
                PdfPTable table = new PdfPTable(45);//total de columnas del formato
                table.TotalWidth = 530f;
                table.LockedWidth = true;
                table.SpacingBefore = 5;//Espacio de escritura hacia arriba
                table.SpacingAfter = 0;//espacio despues

                PdfPCell cell = new PdfPCell(new Phrase("", letra_azul_nombre));//se agregan celdas
                cell.BackgroundColor = azul_liec;
                cell.Border = 0;
                cell.BorderColorBottom = blanco;
                cell.BorderWidthBottom = 0.2f;
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell.PaddingBottom = 4f; //dimensiones de padding
                cell.PaddingLeft = 1f;
                cell.PaddingTop = 1f;
                cell.Colspan = 1;  //la celda abarcara las 13 columnas
                table.AddCell(cell); //agrega la celda 

                cell = new PdfPCell(new Phrase("NOMBRE:", letra_naranja_liec));//se agregan celdas
                cell.BackgroundColor = blanco;
                cell.Border = 0;
                cell.HorizontalAlignment = Element.ALIGN_RIGHT;
                cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell.PaddingBottom = 4f; //dimensiones de padding
                cell.PaddingLeft = 1f;
                cell.PaddingTop = 1f;
                cell.Colspan = 6;  //la celda abarcara las 13 columnas 
                table.AddCell(cell); //agrega la celda

                cell = new PdfPCell(new Phrase(NOMBRE_L.Text, letra_azul_nombre));//se agregan celdas
                cell.BackgroundColor = blanco;
                cell.Border = 0;
                cell.HorizontalAlignment = Element.ALIGN_LEFT;
                cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell.PaddingBottom = 4f; //dimensiones de padding
                cell.PaddingLeft = 1f;
                cell.PaddingTop = 1f;
                cell.Colspan = 38;  //la celda abarcara las 13 columnas 
                table.AddCell(cell); //agrega la celda


                //agregamos tabla
                doc.Add(table); //agrega la tabla 
            }
            catch { }


            //CATEGORIA
            try
            {
                PdfPTable table = new PdfPTable(45);//total de columnas del formato
                table.TotalWidth = 530f;
                table.LockedWidth = true;
                table.SpacingBefore = 0;//Espacio de escritura hacia arriba
                table.SpacingAfter = 0;//espacio despues

                PdfPCell cell = new PdfPCell(new Phrase("", letra_azul_nombre));//se agregan celdas
                cell.BackgroundColor = azul_liec;
                cell.Border = 0;
                cell.BorderColorBottom = blanco;
                cell.BorderWidthBottom = 0.2f;
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell.PaddingBottom = 4f; //dimensiones de padding
                cell.PaddingLeft = 1f;
                cell.PaddingTop = 1f;
                cell.Colspan = 1;  //la celda abarcara las 13 columnas
                table.AddCell(cell); //agrega la celda 


                cell = new PdfPCell(new Phrase("CATEGORÍA:", letra_naranja_liec));//se agregan celdas
                cell.BackgroundColor = blanco;
                cell.Border = 0;
                cell.HorizontalAlignment = Element.ALIGN_RIGHT;
                cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell.PaddingBottom = 4f; //dimensiones de padding
                cell.PaddingLeft = 1f;
                cell.PaddingTop = 1f;
                cell.Colspan = 6;  //la celda abarcara las 13 columnas 
                table.AddCell(cell); //agrega la celda

                cell = new PdfPCell(new Phrase(categoria.Texts, letra_azul_nombre));//se agregan celdas
                cell.BackgroundColor = blanco;
                cell.Border = 0;
                cell.HorizontalAlignment = Element.ALIGN_LEFT;
                cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell.PaddingBottom = 4f; //dimensiones de padding
                cell.PaddingLeft = 1f;
                cell.PaddingTop = 1f;
                cell.Colspan = 38;  //la celda abarcara las 13 columnas 
                table.AddCell(cell); //agrega la celda





                //agregamos tabla
                doc.Add(table); //agrega la tabla 
            }
            catch { }


            //SEMESTRE
            try
            {
                PdfPTable table = new PdfPTable(45);//total de columnas del formato
                table.TotalWidth = 530f;
                table.LockedWidth = true;
                table.SpacingBefore = 0;//Espacio de escritura hacia arriba
                table.SpacingAfter = 0;//espacio despues

                PdfPCell cell = new PdfPCell(new Phrase("", letra_azul_nombre));//se agregan celdas
                cell.BackgroundColor = azul_liec;
                cell.Border = 0;
                cell.BorderColorBottom = blanco;
                cell.BorderWidthBottom = 0.2f;
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell.PaddingBottom = 4f; //dimensiones de padding
                cell.PaddingLeft = 1f;
                cell.PaddingTop = 1f;
                cell.Colspan = 1;  //la celda abarcara las 13 columnas
                table.AddCell(cell); //agrega la celda 


                cell = new PdfPCell(new Phrase("SEMESTRE:", letra_naranja_liec));//se agregan celdas
                cell.BackgroundColor = blanco;
                cell.Border = 0;
                cell.HorizontalAlignment = Element.ALIGN_RIGHT;
                cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell.PaddingBottom = 4f; //dimensiones de padding
                cell.PaddingLeft = 1f;
                cell.PaddingTop = 1f;
                cell.Colspan = 6;  //la celda abarcara las 13 columnas 
                table.AddCell(cell); //agrega la celda

                cell = new PdfPCell(new Phrase(semestre, letra_azul_nombre));//se agregan celdas
                cell.BackgroundColor = blanco;
                cell.Border = 0;
                cell.HorizontalAlignment = Element.ALIGN_LEFT;
                cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell.PaddingBottom = 4f; //dimensiones de padding
                cell.PaddingLeft = 1f;
                cell.PaddingTop = 1f;
                cell.Colspan = 38;  //la celda abarcara las 13 columnas 
                table.AddCell(cell); //agrega la celda





                //agregamos tabla
                doc.Add(table); //agrega la tabla 
            }
            catch { }


            //AÑO
            try
            {
                PdfPTable table = new PdfPTable(45);//total de columnas del formato
                table.TotalWidth = 530f;
                table.LockedWidth = true;
                table.SpacingBefore = 0;//Espacio de escritura hacia arriba
                table.SpacingAfter = 0;//espacio despues

                PdfPCell cell = new PdfPCell(new Phrase("", letra_azul_nombre));//se agregan celdas
                cell.BackgroundColor = azul_liec;
                cell.Border = 0;
                cell.BorderColorBottom = blanco;
                cell.BorderWidthBottom = 0.2f;
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell.PaddingBottom = 4f; //dimensiones de padding
                cell.PaddingLeft = 1f;
                cell.PaddingTop = 1f;
                cell.Colspan = 1;  //la celda abarcara las 13 columnas
                table.AddCell(cell); //agrega la celda 


                cell = new PdfPCell(new Phrase("AÑO:", letra_naranja_liec));//se agregan celdas
                cell.BackgroundColor = blanco;
                cell.Border = 0;
                cell.HorizontalAlignment = Element.ALIGN_RIGHT;
                cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell.PaddingBottom = 4f; //dimensiones de padding
                cell.PaddingLeft = 1f;
                cell.PaddingTop = 1f;
                cell.Colspan = 6;  //la celda abarcara las 13 columnas 
                table.AddCell(cell); //agrega la celda


                DateTime año_s = DateTime.Parse(AÑO);
                cell = new PdfPCell(new Phrase(año_s.ToString("yyyy"), letra_azul_nombre));//se agregan celdas
                cell.BackgroundColor = blanco;
                cell.Border = 0;
                cell.HorizontalAlignment = Element.ALIGN_LEFT;
                cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell.PaddingBottom = 4f; //dimensiones de padding
                cell.PaddingLeft = 1f;
                cell.PaddingTop = 1f;
                cell.Colspan = 38;  //la celda abarcara las 13 columnas 
                table.AddCell(cell); //agrega la celda





                //agregamos tabla
                doc.Add(table); //agrega la tabla 
            }
            catch { }


            //FOLIO
            try
            {
                PdfPTable table = new PdfPTable(45);//total de columnas del formato
                table.TotalWidth = 530f;
                table.LockedWidth = true;
                table.SpacingBefore = 0;//Espacio de escritura hacia arriba
                table.SpacingAfter = 0;//espacio despues

                PdfPCell cell = new PdfPCell(new Phrase("", letra_azul_nombre));//se agregan celdas
                cell.BackgroundColor = azul_liec;
                cell.Border = 0;
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell.PaddingBottom = 4f; //dimensiones de padding
                cell.PaddingLeft = 1f;
                cell.PaddingTop = 1f;
                cell.Colspan = 1;  //la celda abarcara las 13 columnas
                table.AddCell(cell); //agrega la celda 


                cell = new PdfPCell(new Phrase("FOLIO:", letra_naranja_liec));//se agregan celdas
                cell.BackgroundColor = blanco;
                cell.Border = 0;
                cell.HorizontalAlignment = Element.ALIGN_RIGHT;
                cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell.PaddingBottom = 4f; //dimensiones de padding
                cell.PaddingLeft = 1f;
                cell.PaddingTop = 1f;
                cell.Colspan = 6;  //la celda abarcara las 13 columnas 
                table.AddCell(cell); //agrega la celda


                cell = new PdfPCell(new Phrase(ID_V.Text, letra_azul_nombre));//se agregan celdas
                cell.BackgroundColor = blanco;
                cell.Border = 0;
                cell.HorizontalAlignment = Element.ALIGN_LEFT;
                cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell.PaddingBottom = 4f; //dimensiones de padding
                cell.PaddingLeft = 1f;
                cell.PaddingTop = 1f;
                cell.Colspan = 38;  //la celda abarcara las 13 columnas 
                table.AddCell(cell); //agrega la celda





                //agregamos tabla
                doc.Add(table); //agrega la tabla 
            }
            catch { }


            //NORMA
            try
            {
                PdfPTable table = new PdfPTable(15);//total de columnas del formato
                table.TotalWidth = 530f;
                table.LockedWidth = true;
                table.SpacingBefore = 5;//Espacio de escritura hacia arriba
                table.SpacingAfter = 0;//espacio despues

                PdfPCell cell = new PdfPCell(new Phrase("Norma", letra_blanca));//se agregan celdas
                cell.BackgroundColor = azul_liec;
                cell.Border = 0;
                cell.BorderColorRight = blanco;
                cell.BorderWidthRight = 1.2f;
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell.PaddingBottom = 4f; //dimensiones de padding
                cell.PaddingLeft = 1f;
                cell.PaddingTop = 1f;
                cell.Colspan = 3;  //la celda abarcara las 13 columnas
                table.AddCell(cell); //agrega la celda 

                cell = new PdfPCell(new Phrase("Método", letra_blanca));//se agregan celdas
                cell.BackgroundColor = azul_liec;
                cell.Border = 0;
                cell.BorderColorRight = blanco;
                cell.BorderWidthRight = 1.2f;
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell.PaddingBottom = 4f; //dimensiones de padding
                cell.PaddingLeft = 1f;
                cell.PaddingTop = 1f;
                cell.Colspan = 10;  //la celda abarcara las 13 columnas
                table.AddCell(cell); //agrega la celda

                cell = new PdfPCell(new Phrase("Resultado", letra_blanca));//se agregan celdas
                cell.BackgroundColor = azul_liec;
                cell.Border = 0;
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell.PaddingBottom = 4f; //dimensiones de padding
                cell.PaddingLeft = 1f;
                cell.PaddingTop = 1f;
                cell.Colspan = 2;  //la celda abarcara las 13 columnas 
                table.AddCell(cell); //agrega la celda


                //agregamos tabla
                doc.Add(table); //agrega la tabla 
            }
            catch { }






            string descripcion_norma = ""; //se declara la variable que deposita informacion en el formato           
            string descripcion_metodo = ""; //se declara la variable que deposita informacion en el formato           
            string resul = ""; //se declara la variable que deposita informacion en el formato     

            double suma_total = 0;
            cant_normas = 0;
            string o_original = "";
            string o_actual = "";

            //NORMAS Y RESULTADOS 
            try
            {

                /*    foreach (DataGridViewRow row in TABLE_3.Rows)
                    {
                        if(TABLE_3.RowCount > 0){

                            cant_normas = cant_normas + 1;

                            suma_total += double.Parse(row.Cells[2].Value.ToString());

                            promedio_total2.Texts = Convert.ToString(Math.Round(suma_total / cant_normas, 1));
                        }





                        tabla.DataSource = conexion_supervision_tecnica.Consultageneral("SELECT DESCRIPCION, AREA FROM normas WHERE NORMA= '" + row.Cells[0].Value.ToString() + "' ");
                        //el foreach busca en la tabla el unico dato(descripcion) con indice "0" para depositarlo despues en la coordenada correcta del formato      

                        if (tabla.RowCount > 0)
                        {
                            descripcion_norma = tabla.Rows[0].Cells[0].Value.ToString();
                            o_actual = tabla.Rows[0].Cells[1].Value.ToString();
                          //  cant_normas = cant_normas + 1;
                        }
                        else
                        {
                            descripcion_norma = "Desconocida";
                        }








                        if (o_original != o_actual)
                        {                     
                            if (o_actual == "CONCRETO")
                            {


                            }


                            else if (o_actual == "AGREGADOS")
                            {


                            }


                            else if (o_actual == "TERRACERÍA")
                            {

                            }


                            else if (o_actual == "MS")
                            {

                            }


                            else if (o_actual == "ASFALTO")
                            {

                            }


                            else if (o_actual == "ACERO")
                            {

                            }


                            else if (o_actual == "PND")
                            {

                            }



                            o_original = o_actual;


                        }
                        else
                        {
                        }




                        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                          PdfPTable table = new PdfPTable(13);//total de columnas del formato
                          table.TotalWidth = 500f;
                          table.LockedWidth = true;
                          table.SpacingBefore = 0;//Espacio de escritura hacia arriba
                          table.SpacingAfter = 0;//espacio despues

                          PdfPCell cell = new PdfPCell(new Phrase(row.Cells[0].Value.ToString(), letra_naranja_foreach));//NORMA
                          cell.BackgroundColor = blanco;
                          cell.Border = 0;
                          cell.HorizontalAlignment = Element.ALIGN_CENTER;
                          cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                          cell.PaddingBottom = 4f; //dimensiones de padding
                          cell.PaddingLeft = 1f;
                          cell.PaddingTop = 1f;
                          cell.Colspan = 3;  //la celda abarcara las 13 columnas 
                          table.AddCell(cell); //agrega la celda 


                          cell = new PdfPCell(new Phrase(descripcion_norma, letra_azul_foreach_chica2));//descripcion_norma
                          cell.BackgroundColor = blanco;
                          cell.Border = 0;
                          cell.HorizontalAlignment = Element.ALIGN_CENTER;
                          cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                          cell.PaddingBottom = 4f; //dimensiones de padding
                          cell.PaddingLeft = 1f;
                          cell.PaddingTop = 1f;
                          cell.Colspan = 8;  //la celda abarcara las 13 columnas 
                          table.AddCell(cell); //agrega la celda


                          cell = new PdfPCell(new Phrase(row.Cells[2].Value.ToString(), letra_negra));////RESULTADO
                          cell.BackgroundColor = blanco;
                          cell.Border = 0;
                          cell.HorizontalAlignment = Element.ALIGN_CENTER;
                          cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                          cell.PaddingBottom = 4f; //dimensiones de padding
                          cell.PaddingLeft = 1f;
                          cell.PaddingTop = 1f;
                          cell.Colspan = 2;  //la celda abarcara las 13 columnas 
                          table.AddCell(cell); //agrega la celda


                          //agregamos tabla
                          doc.Add(table); //agrega la tabla                  
                    }*/

            }
            catch { }



            //AQUI ME QUEDE EL VIERNES , REPITE LAS NORMAS EN EL FORMATO 




            try
            {
                foreach (DataGridViewRow row in TABLE_3.Rows)
                {
                    //HACE EL CONTEO DE LA CANTIDAD DE NORMAS Y SACA EL PROMEDIO
                    if (TABLE_3.RowCount > 0)
                    {
                        cant_normas = cant_normas + 1;
                        suma_total += double.Parse(row.Cells[2].Value.ToString());
                        promedio_total2.Texts = Convert.ToString(Math.Round(suma_total / cant_normas, 1));
                    }



                    /*  if (TABLA_METODO.RowCount > 0)
                      {
                          descripcion_norma = TABLA_METODO.Rows[0].Cells[3].Value.ToString();  //norma
                          descripcion_metodo = TABLA_METODO.Rows[0].Cells[6].Value.ToString();  //METODO
                          resul = TABLA_METODO.Rows[0].Cells[5].Value.ToString();  //calificacion
                          o_actual = TABLA_METODO.Rows[0].Cells[9].Value.ToString(); //AREA




                         cant_normas = cant_normas + 1;
                         suma_total += double.Parse(row.Cells[2].Value.ToString());
                         promedio_total2.Texts = Convert.ToString(Math.Round(suma_total / cant_normas, 1));
                     }
                      else
                      {
                          descripcion_norma = "Desconocida";
                      }*/





                    PdfPTable table = new PdfPTable(15);//total de columnas del formato
                    table.TotalWidth = 530f;
                    table.LockedWidth = true;
                    table.SpacingBefore = 0;//Espacio de escritura hacia arriba
                    table.SpacingAfter = 0;//espacio despues

                    PdfPCell cell = new PdfPCell(new Phrase(row.Cells[0].Value.ToString(), letra_naranja_foreach));//NORMA
                    cell.BackgroundColor = blanco;
                    cell.Border = 0;
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                    cell.PaddingBottom = 4f; //dimensiones de padding
                    cell.PaddingLeft = 1f;
                    cell.PaddingTop = 1f;
                    cell.Colspan = 3;  //la celda abarcara las 13 columnas 
                    table.AddCell(cell); //agrega la celda 


                    cell = new PdfPCell(new Phrase(row.Cells[1].Value.ToString(), letra_azul_foreach_chica2));//metodo
                    cell.BackgroundColor = blanco;
                    cell.Border = 0;
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                    cell.PaddingBottom = 4f; //dimensiones de padding
                    cell.PaddingLeft = 1f;
                    cell.PaddingTop = 1f;
                    cell.Colspan = 10;  //la celda abarcara las 13 columnas 
                    table.AddCell(cell); //agrega la celda


                    cell = new PdfPCell(new Phrase(row.Cells[2].Value.ToString(), letra_negra));////RESULTADO
                    cell.BackgroundColor = blanco;
                    cell.Border = 0;
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                    cell.PaddingBottom = 4f; //dimensiones de padding
                    cell.PaddingLeft = 1f;
                    cell.PaddingTop = 1f;
                    cell.Colspan = 2;  //la celda abarcara las 13 columnas 
                    table.AddCell(cell); //agrega la celda


                    //agregamos tabla
                    doc.Add(table); //agrega la tabla                            
                }
            }
            catch
            {

            }

























            //EVA. MAX.
            try
            {
                PdfPTable table = new PdfPTable(15);//total de columnas del formato
                table.TotalWidth = 530f;
                table.LockedWidth = true;
                table.SpacingBefore = 5;//Espacio de escritura hacia arriba
                table.SpacingAfter = 0;//espacio despues

                PdfPCell cell = new PdfPCell(new Phrase("EVALUACIÓN MAX.", letra_azul_nombre));//se agregan celdas
                cell.BackgroundColor = blanco;
                cell.Border = 0;
                cell.HorizontalAlignment = Element.ALIGN_RIGHT;
                cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell.PaddingBottom = 4f; //dimensiones de padding
                cell.PaddingLeft = 1f;
                cell.PaddingTop = 1f;
                cell.Colspan = 13;  //la celda abarcara las 13 columnas
                table.AddCell(cell); //agrega la celda 



                cell = new PdfPCell(new Phrase(promedio_total2.Texts, letra_naranja_liec));//se agregan celdas
                cell.BackgroundColor = blanco;
                cell.Border = 0;
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell.PaddingBottom = 4f; //dimensiones de padding
                cell.PaddingLeft = 1f;
                cell.PaddingTop = 1f;
                cell.Colspan = 2;  //la celda abarcara las 13 columnas
                table.AddCell(cell); //agrega la celda



                //agregamos tabla
                doc.Add(table); //agrega la tabla 
            }
            catch { }


            // OBS GENERALES
            try
            {
                PdfPTable table = new PdfPTable(13);//total de columnas del formato
                table.TotalWidth = 500f;
                table.LockedWidth = true;
                table.SpacingBefore = 5;//Espacio de escritura hacia arriba
                table.SpacingAfter = 0;//espacio despues

                PdfPCell cell = new PdfPCell(new Phrase("OBSERVACIONES GENERALES", letra_azul_nombre));//se agregan celdas
                cell.BackgroundColor = blanco;
                cell.Border = 0;
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell.PaddingBottom = 4f; //dimensiones de padding
                cell.PaddingLeft = 1f;
                cell.PaddingTop = 1f;
                cell.Colspan = 13;  //la celda abarcara las 13 columnas
                cell.FixedHeight = 20f;
                table.AddCell(cell); //agrega la celda 


                //agregamos tabla
                doc.Add(table); //agrega la tabla 
            }
            catch { }







            resss = double.Parse(promedio_total2.Texts);


            // OBS GENERALES TEXTO
            try
            {
                PdfPTable table = new PdfPTable(13);//total de columnas del formato
                table.TotalWidth = 530f;
                table.LockedWidth = true;
                table.SpacingBefore = 0;//Espacio de escritura hacia arriba
                table.SpacingAfter = 0;//espacio despues


                resss = double.Parse(promedio_total2.Texts);


                if (resss <= 59)
                {
                    PdfPCell cell = new PdfPCell(new Phrase("NO DEMUESTRA CONOCIMIENTOS TEÓRICO-PRÁCTICOS DE LOS PROCEDIMIENTOS TÉCNICOS", letra_negra));//se agregan celdas
                    cell.BackgroundColor = blanco;
                    cell.Border = 0;
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                    cell.PaddingBottom = 4f; //dimensiones de padding
                    cell.PaddingLeft = 1f;
                    cell.PaddingTop = 1f;
                    cell.Colspan = 13;  //la celda abarcara las 13 columnas
                    table.AddCell(cell); //agrega la celda 
                }

                else if (resss >= 60 && resss <= 79)
                {
                    PdfPCell cell = new PdfPCell(new Phrase("REFORZAR CONOCIMIENTOS TEÓRICO-PRÁCTICOS DE LOS PROCEDIMIENTOS TÉCNICOS", letra_negra));//se agregan celdas
                    cell.BackgroundColor = blanco;
                    cell.Border = 0;
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                    cell.PaddingBottom = 4f; //dimensiones de padding
                    cell.PaddingLeft = 1f;
                    cell.PaddingTop = 1f;
                    cell.Colspan = 13;  //la celda abarcara las 13 columnas
                    table.AddCell(cell); //agrega la celda 
                }

                else if (resss >= 80 && resss <= 100)
                {
                    PdfPCell cell = new PdfPCell(new Phrase("BUENA EJECUCIÓN TEÓRICO-PRACTICA DE LOS PROCEDIMIENTOS TÉCNICOS", letra_negra));//se agregan celdas
                    cell.BackgroundColor = blanco;
                    cell.Border = 0;
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                    cell.PaddingBottom = 4f; //dimensiones de padding
                    cell.PaddingLeft = 1f;
                    cell.PaddingTop = 1f;
                    cell.Colspan = 13;  //la celda abarcara las 13 columnas
                    table.AddCell(cell); //agrega la celda 
                }

                else
                {
                    PdfPCell cell = new PdfPCell(new Phrase("-----------------------------------", letra_negra));//se agregan celdas
                    cell.BackgroundColor = blanco;
                    cell.Border = 0;
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                    cell.PaddingBottom = 4f; //dimensiones de padding
                    cell.PaddingLeft = 1f;
                    cell.PaddingTop = 1f;
                    cell.Colspan = 13;  //la celda abarcara las 13 columnas
                    table.AddCell(cell); //agrega la celda 
                }


                //agregamos tabla
                doc.Add(table); //agrega la tabla 
            }
            catch { }


            //RESULTADOS
            try
            {
                PdfPTable table = new PdfPTable(13);//total de columnas del formato
                table.TotalWidth = 500f;
                table.LockedWidth = true;
                table.SpacingBefore = 5;//Espacio de escritura hacia arriba
                table.SpacingAfter = 0;//espacio despues

                PdfPCell cell = new PdfPCell(new Phrase("RESULTADOS", letra_naranja_liec));//se agregan celdas
                cell.BackgroundColor = blanco;
                cell.Border = 0;
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell.PaddingBottom = 4f; //dimensiones de padding
                cell.PaddingLeft = 1f;
                cell.PaddingTop = 1f;
                cell.Colspan = 13;  //la celda abarcara las 13 columnas
                cell.FixedHeight = 20f;
                table.AddCell(cell); //agrega la celda 


                //agregamos tabla
                doc.Add(table); //agrega la tabla 
            }
            catch { }


            //DEFICIENTE
            try
            {
                PdfPTable table = new PdfPTable(13);//total de columnas del formato
                table.TotalWidth = 500f;
                table.LockedWidth = true;
                table.SpacingBefore = 0;//Espacio de escritura hacia arriba
                table.SpacingAfter = 0;//espacio despues

                PdfPCell cell = new PdfPCell(new Phrase("DEFICIENTE", letra_azul_nombre));//se agregan celdas
                cell.BackgroundColor = blanco;
                cell.Border = 0;
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell.PaddingBottom = 4f; //dimensiones de padding
                cell.PaddingLeft = 1f;
                cell.PaddingTop = 1f;
                cell.Colspan = 5;  //la celda abarcara las 13 columnas
                cell.FixedHeight = 20f;
                table.AddCell(cell); //agrega la celda 


                cell = new PdfPCell(new Phrase("REGULAR", letra_azul_nombre));//se agregan celdas
                cell.BackgroundColor = blanco;
                cell.Border = 0;
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell.PaddingBottom = 4f; //dimensiones de padding
                cell.PaddingLeft = 1f;
                cell.PaddingTop = 1f;
                cell.Colspan = 3;  //la celda abarcara las 13 columnas 
                cell.FixedHeight = 20f;
                table.AddCell(cell); //agrega la celda


                cell = new PdfPCell(new Phrase("APROBATORIO", letra_azul_nombre));//se agregan celdas
                cell.BackgroundColor = blanco;
                cell.Border = 0;
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell.PaddingBottom = 4f; //dimensiones de padding
                cell.PaddingLeft = 1f;
                cell.PaddingTop = 1f;
                cell.Colspan = 5;  //la celda abarcara las 13 columnas
                cell.FixedHeight = 20f;
                table.AddCell(cell); //agrega la celda

                //agregamos tabla
                doc.Add(table); //agrega la tabla 
            }
            catch { }


            //<60
            try
            {
                PdfPTable table = new PdfPTable(13);//total de columnas del formato
                table.TotalWidth = 500f;
                table.LockedWidth = true;
                table.SpacingBefore = 0;//Espacio de escritura hacia arriba
                table.SpacingAfter = 0;//espacio despues

                PdfPCell cell = new PdfPCell(new Phrase("<60", letra_negra_resultados));//se agregan celdas
                cell.BackgroundColor = blanco;
                cell.Border = 0;
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell.PaddingBottom = 4f; //dimensiones de padding
                cell.PaddingLeft = 1f;
                cell.PaddingTop = 1f;
                cell.Colspan = 5;  //la celda abarcara las 13 columnas
                cell.FixedHeight = 20f;
                table.AddCell(cell); //agrega la celda 


                cell = new PdfPCell(new Phrase("60 - 80", letra_negra_resultados));//se agregan celdas
                cell.BackgroundColor = blanco;
                cell.Border = 0;
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell.PaddingBottom = 4f; //dimensiones de padding
                cell.PaddingLeft = 1f;
                cell.PaddingTop = 1f;
                cell.Colspan = 3;  //la celda abarcara las 13 columnas 
                cell.FixedHeight = 20f;
                table.AddCell(cell); //agrega la celda


                cell = new PdfPCell(new Phrase("> 80", letra_negra_resultados));//se agregan celdas
                cell.BackgroundColor = blanco;
                cell.Border = 0;
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell.PaddingBottom = 4f; //dimensiones de padding
                cell.PaddingLeft = 1f;
                cell.PaddingTop = 1f;
                cell.Colspan = 5;  //la celda abarcara las 13 columnas
                cell.FixedHeight = 20f;
                table.AddCell(cell); //agrega la celda

                //agregamos tabla
                doc.Add(table); //agrega la tabla 
            }
            catch { }


            //FIRMA
            try
            {
                PdfPTable table = new PdfPTable(14);//total de columnas del formato
                table.TotalWidth = 500f;
                table.LockedWidth = true;
                table.SpacingBefore = 0;//Espacio de escritura hacia arriba
                table.SpacingAfter = 0;//espacio despues



                //AQUI VA LA FIRMA
                PdfPCell cell = new PdfPCell(new Phrase("", letra_azul_foreach));//se agregan celdas

                if (SESION.usuario == "CJIMENEZ")
                {
                    cell = new PdfPCell(FIRMA_CONCEPCION);
                    cell.Colspan = 14;
                    cell.Border = 0;
                    FIRMA_CONCEPCION.ScalePercent(30);
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    table.AddCell(cell);
                }

                if (SESION.usuario == "YALONSO")
                {

                    cell = new PdfPCell(FIRMA_YAREM);
                    cell.Colspan = 14;
                    cell.Border = 0;
                    FIRMA_YAREM.ScalePercent(30);
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    table.AddCell(cell);
                }


                if (SESION.usuario == "HHERNANDEZ")
                {

                    cell = new PdfPCell(FIRMA_HEIDY);
                    cell.Colspan = 14;
                    cell.Border = 0;
                    FIRMA_HEIDY.ScalePercent(30);
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    table.AddCell(cell);
                }




                //agregamos tabla
                doc.Add(table); //agrega la tabla 
            }
            catch { }













            doc.Close();

        }







        //METODO QUE GENERA REPORTE EXCEL, PDF
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            //PAN_SUPERVISION.GEV.panel1.Controls.Clear();
            //PAN_SUPERVISION.GEV.realizar_ejecucuion();



            genera_reporte();

            MENSAJE_GENERAL MN = new MENSAJE_GENERAL();
            MN.BOTON.Text = "DOCUMENTO CREADO CON ÉXITO";
            MN.ShowDialog();

        }







        private void genera_reporte()
        {

            string plantilla = @"A:\FORMATOS\SUPERVISION\reporte_semestral_sup_personal.xlsx"; //SE ALOJA LA PLANTILLA 

            string documentos = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string ruta_rt = Path.Combine(documentos, nombre.Texts + " - Reporte de Supervisión.xlsx");  //ruta excel/pdf
            string ruta_pdf = Path.Combine(documentos, nombre.Texts + " - Reporte de Supervisión.pdf");  //ruta excel/pdf


            SLDocument reporte = new SLDocument(plantilla);





            if (DECICION_REMOTA.concretos_remota == true)
            {
                tabla_fir.DataSource = logueo_remoto.Consultageneral("SELECT * FROM usuarios WHERE usuario = '" + realizo_f.Texts + "' ");
            }
            else
            {
                tabla_fir.DataSource = conexion_login.Consultageneral("SELECT * FROM usuarios WHERE usuario = '" + realizo_f.Texts + "' ");
            }

            string realizo = tabla_fir.Rows[0].Cells[5].Value.ToString();
            string nonmbre_realizo = tabla_fir.Rows[0].Cells[1].Value.ToString();
            SLPicture pic = new SLPicture(@"A:\FIRMAS\" + realizo_f.Texts + ".PNG");
            pic.ResizeInPixels(120, 120);


            //ESTILOS///////////////////////////////////////////////////
            SLStyle AREA_concreto = reporte.CreateStyle();
            AREA_concreto.Alignment.JustifyLastLine = true;
            AREA_concreto.Alignment.Horizontal = HorizontalAlignmentValues.Center;
            AREA_concreto.Alignment.Vertical = VerticalAlignmentValues.Center;
            AREA_concreto.Font.FontName = "Arial";
            AREA_concreto.Font.FontSize = 10;
            AREA_concreto.Font.Bold = true;
            AREA_concreto.Font.FontColor = System.Drawing.Color.FromArgb(16, 77, 141);
            AREA_concreto.SetWrapText(true);




            SLStyle NORM = reporte.CreateStyle();
            NORM.Alignment.JustifyLastLine = true;
            NORM.Alignment.Horizontal = HorizontalAlignmentValues.Center;
            NORM.Alignment.Vertical = VerticalAlignmentValues.Center;
            NORM.Font.FontName = "Arial";
            NORM.Font.FontSize = 10;
            NORM.Font.Bold = true;
            NORM.Font.FontColor = System.Drawing.Color.FromArgb(225, 92, 0);
            NORM.SetWrapText(true);

            SLStyle METOD = reporte.CreateStyle();
            METOD.Alignment.JustifyLastLine = true;
            METOD.Alignment.Horizontal = HorizontalAlignmentValues.Center;
            METOD.Alignment.Vertical = VerticalAlignmentValues.Center;
            METOD.Font.FontName = "Arial";
            METOD.Font.FontSize = 9;
            METOD.Font.Bold = false;
            METOD.Font.FontColor = System.Drawing.Color.FromArgb(16, 77, 141);
            METOD.SetWrapText(true);

            SLStyle RES_NORMA = reporte.CreateStyle();
            RES_NORMA.Alignment.JustifyLastLine = true;
            RES_NORMA.Alignment.Horizontal = HorizontalAlignmentValues.Right;
            RES_NORMA.Alignment.Vertical = VerticalAlignmentValues.Center;
            RES_NORMA.Font.FontName = "Arial";
            RES_NORMA.Font.FontSize = 11;
            RES_NORMA.Font.Bold = true;
            RES_NORMA.Font.FontColor = System.Drawing.Color.FromArgb(0, 0, 0);
            RES_NORMA.SetWrapText(true);

            SLStyle EVAL_MAX = reporte.CreateStyle();
            EVAL_MAX.Alignment.JustifyLastLine = true;
            EVAL_MAX.Alignment.Horizontal = HorizontalAlignmentValues.Right;
            EVAL_MAX.Alignment.Vertical = VerticalAlignmentValues.Center;
            EVAL_MAX.Font.FontName = "Arial";
            EVAL_MAX.Font.FontSize = 11;
            EVAL_MAX.Font.Bold = true;
            EVAL_MAX.Font.FontColor = System.Drawing.Color.FromArgb(16, 77, 141);
            EVAL_MAX.SetWrapText(true);

            SLStyle SUMA_TOT = reporte.CreateStyle();
            SUMA_TOT.Alignment.JustifyLastLine = true;
            SUMA_TOT.Alignment.Horizontal = HorizontalAlignmentValues.Right;
            SUMA_TOT.Alignment.Vertical = VerticalAlignmentValues.Center;
            SUMA_TOT.Font.FontName = "Arial";
            SUMA_TOT.Font.FontSize = 11;
            SUMA_TOT.Font.Bold = true;
            SUMA_TOT.Font.FontColor = System.Drawing.Color.FromArgb(225, 92, 0);
            SUMA_TOT.SetWrapText(true);

            SLStyle RESULT = reporte.CreateStyle();
            RESULT.Alignment.JustifyLastLine = true;
            RESULT.Alignment.Horizontal = HorizontalAlignmentValues.Center;
            RESULT.Alignment.Vertical = VerticalAlignmentValues.Center;
            RESULT.Font.FontName = "Arial";
            RESULT.Font.FontSize = 11;
            RESULT.Font.Bold = true;
            RESULT.Font.FontColor = System.Drawing.Color.FromArgb(225, 92, 0);
            RESULT.SetWrapText(true);

            SLStyle RESULT_LEYEN = reporte.CreateStyle();
            RESULT_LEYEN.Alignment.JustifyLastLine = true;
            RESULT_LEYEN.Alignment.Horizontal = HorizontalAlignmentValues.Center;
            RESULT_LEYEN.Alignment.Vertical = VerticalAlignmentValues.Center;
            RESULT_LEYEN.Font.FontName = "Arial";
            RESULT_LEYEN.Font.FontSize = 10;
            RESULT_LEYEN.Font.Bold = true;
            RESULT_LEYEN.Font.FontColor = System.Drawing.Color.FromArgb(16, 77, 141);
            RESULT_LEYEN.SetWrapText(true);

            SLStyle RESULT_PONDE = reporte.CreateStyle();
            RESULT_PONDE.Alignment.JustifyLastLine = true;
            RESULT_PONDE.Alignment.Horizontal = HorizontalAlignmentValues.Center;
            RESULT_PONDE.Alignment.Vertical = VerticalAlignmentValues.Center;
            RESULT_PONDE.Font.FontName = "Arial";
            RESULT_PONDE.Font.FontSize = 10;
            RESULT_PONDE.Font.Bold = true;
            RESULT_PONDE.Font.FontColor = System.Drawing.Color.FromArgb(0, 0, 0);
            RESULT_PONDE.SetWrapText(true);

            SLStyle OBSER = reporte.CreateStyle();
            OBSER.Alignment.JustifyLastLine = true;
            OBSER.Alignment.Horizontal = HorizontalAlignmentValues.Center;
            OBSER.Alignment.Vertical = VerticalAlignmentValues.Center;
            OBSER.Font.FontName = "Arial";
            OBSER.Font.FontSize = 10;
            OBSER.Font.Bold = true;
            OBSER.Font.FontColor = System.Drawing.Color.FromArgb(16, 77, 141);
            OBSER.SetWrapText(true);

            SLStyle OBSER_TEXTO = reporte.CreateStyle();
            OBSER_TEXTO.Alignment.JustifyLastLine = true;
            OBSER_TEXTO.Alignment.Horizontal = HorizontalAlignmentValues.Center;
            OBSER_TEXTO.Alignment.Vertical = VerticalAlignmentValues.Center;
            OBSER_TEXTO.Font.FontName = "Arial";
            OBSER_TEXTO.Font.FontSize = 10;
            OBSER_TEXTO.Font.Bold = true;
            OBSER_TEXTO.Font.FontColor = System.Drawing.Color.FromArgb(0, 0, 0);
            OBSER_TEXTO.SetWrapText(true);


            ///////////////////////////////////////////////////////////////////////////////////////////




            reporte.SelectWorksheet("Hoja1");
            reporte.SetCellValue("C3", NOMBRE_L.Text.ToUpper()); //NOMBRE
            reporte.SetCellValue("C4", categoria.Texts.ToUpper()); //CATEGORIA
            reporte.SetCellValue("C5", semestre.ToUpper()); //SEMESTRE
            DateTime año_s = DateTime.Parse(AÑO);

            reporte.SetCellValue("C6", año_s.ToString("yyyy")); //AÑO
            reporte.SetCellValue("C7", ID_V.Text.ToUpper()); //FOLIO
            reporte.SetCellValue("C20", rjTextBox1.Texts.ToUpper());  //SUPERVISOR






            int contador_conceptos = (TABLE_3.RowCount) + 10;
            int fila_activa = 12;  //INICIA DEPOSITO DE INFO         
            string descripcion_norma = ""; //se declara la variable que deposita informacion en el formato
            int filas_nuevas = 12 + TABLE_3.RowCount + 21;
            double suma_total = 0;
            cant_normas = 0;

            string o_original = "";
            string o_actual = "";


            /////////////////////

            reporte.InsertRow(12, filas_nuevas);

            foreach (DataGridViewRow row in TABLE_3.Rows)
            {
                tabla.DataSource = conexion_supervision_tecnica.Consultageneral("SELECT DESCRIPCION, AREA FROM normas WHERE NORMA= '" + row.Cells[0].Value.ToString() + "' ");
                //el foreach busca en la tabla el unico dato(descripcion) con indice "0" para depositarlo despues en la coordenada correcta del formato      

                if (tabla.RowCount > 0)
                {
                    descripcion_norma = tabla.Rows[0].Cells[0].Value.ToString();
                    o_actual = tabla.Rows[0].Cells[1].Value.ToString();
                    //   cant_normas = cant_normas + 1;
                }
                else
                {
                    descripcion_norma = "Desconocida";
                }



                if (o_original != o_actual)
                {

                    if (o_actual == "CONCRETO")
                    {
                        fila_activa = fila_activa + 1;
                        reporte.SetCellValue(fila_activa, 1, "CN"); //AREA
                        reporte.SetCellStyle(fila_activa, 1, AREA_concreto);

                    }
                    else if (o_actual == "AGREGADOS")
                    {
                        fila_activa = fila_activa + 1;
                        reporte.SetCellValue(fila_activa, 1, "AGR"); //AREA
                        reporte.SetCellStyle(fila_activa, 1, AREA_concreto);
                    }
                    else if (o_actual == "TERRACERÍA")
                    {
                        fila_activa = fila_activa + 1;
                        reporte.SetCellValue(fila_activa, 1, "TER"); //AREA
                        reporte.SetCellStyle(fila_activa, 1, AREA_concreto);
                    }
                    else if (o_actual == "MS")
                    {
                        fila_activa = fila_activa + 1;
                        reporte.SetCellValue(fila_activa, 1, "MS"); //AREA
                        reporte.SetCellStyle(fila_activa, 1, AREA_concreto);
                    }
                    else if (o_actual == "ASFALTO")
                    {
                        fila_activa = fila_activa + 1;
                        reporte.SetCellValue(fila_activa, 1, "ASF"); //AREA
                        reporte.SetCellStyle(fila_activa, 1, AREA_concreto);

                    }
                    else if (o_actual == "ACERO")
                    {
                        fila_activa = fila_activa + 1;
                        reporte.SetCellValue(fila_activa, 1, "ACR"); //AREA
                        reporte.SetCellStyle(fila_activa, 1, AREA_concreto);
                    }
                    else if (o_actual == "PND")
                    {
                        fila_activa = fila_activa + 1;
                        reporte.SetCellValue(fila_activa, 1, "PND"); //AREA
                        reporte.SetCellStyle(fila_activa, 1, AREA_concreto);
                    }

                    o_original = o_actual;

                }
                else
                {

                }



                reporte.SetCellValue(fila_activa, 2, row.Cells[0].Value.ToString()); //NORMA
                reporte.SetCellStyle(fila_activa, 2, NORM);

                reporte.SetCellValue(fila_activa, 3, descripcion_norma); //aqui se deposita esa variable que contiene el dato unico de la busqueda de "tabla" //METODO
                reporte.SetCellStyle(fila_activa, 3, METOD);

                reporte.SetCellValue(fila_activa, 5, row.Cells[2].Value.ToString()); //RESULTADO
                reporte.SetCellStyle(fila_activa, 5, RES_NORMA);


                suma_total += double.Parse(row.Cells[2].Value.ToString());







                cant_normas = cant_normas + 1;
                promedio_total2.Texts = Convert.ToString(suma_total / cant_normas);

                fila_activa = fila_activa + 1;
            }




            //  pic.SetPosition(filas_nuevas + 15, 2.4);
            //  reporte.InsertPicture(pic);

            //CALIFICACION TOTAL 
            reporte.SetCellValue(fila_activa + 1, 3, "EVALUACIÓN MAX.");
            reporte.SetCellStyle(fila_activa + 1, 3, EVAL_MAX);

            reporte.SetCellValue(fila_activa + 1, 5, promedio_total2.Texts);
            reporte.SetCellStyle(fila_activa + 1, 5, SUMA_TOT);
            fila_activa = fila_activa + 4;

            //OBSERVACIONES 
            reporte.SetCellValue(fila_activa, 3, "OBSERVACIONES GENERALES");
            reporte.SetCellStyle(fila_activa, 3, OBSER);
            fila_activa = fila_activa + 1;

            // reporte.SetCellValue(fila_activa, 3, OBS.Texts);
            if (OBS.Texts == string.Empty) { reporte.SetCellValue(fila_activa, 3, "-------------------"); } else { reporte.SetCellValue(fila_activa, 3, OBS.Texts); }
            reporte.SetCellStyle(fila_activa, 3, OBSER_TEXTO);
            fila_activa = fila_activa + 3;



            //RESULTADOS
            reporte.SetCellValue(fila_activa, 3, "RESULTADOS");
            reporte.SetCellStyle(fila_activa, 3, RESULT);
            fila_activa = fila_activa + 1;

            reporte.SetCellValue(fila_activa, 2, "DEFICIENTE");
            reporte.SetCellValue(fila_activa, 3, "REGULAR");
            reporte.SetCellValue(fila_activa, 5, "APROBATORIO");
            reporte.SetCellStyle(fila_activa, 2, RESULT_LEYEN);
            reporte.SetCellStyle(fila_activa, 3, RESULT_LEYEN);
            reporte.SetCellStyle(fila_activa, 5, RESULT_LEYEN);
            fila_activa = fila_activa + 1;

            reporte.SetCellValue(fila_activa, 2, "< 60");
            reporte.SetCellStyle(fila_activa, 2, RESULT_PONDE);

            reporte.SetCellValue(fila_activa, 3, "60 - 80");
            reporte.SetCellStyle(fila_activa, 3, RESULT_PONDE);

            reporte.SetCellValue(fila_activa, 5, "> 80");
            reporte.SetCellStyle(fila_activa, 5, RESULT_PONDE);
            fila_activa = fila_activa + 1;

            pic.SetPosition(filas_nuevas + 15, 2.4);
            reporte.InsertPicture(pic);


            //RUTA PARA FOTO 
            string ruta1 = @"Z:\LIEP-01 PERSONAL\2023\REGISTROS\01 RRHH\3 DOCUMENTOS PERSONAL\DOCUMENTOS ERP\FOTOGRAFIA\" + NOMBRE_L.Text + @"\" + NOMBRE_L.Text + " - FOTOGRAFIA" + ".PNG";
            //Z:\LIEP-01 PERSONAL\2023\REGISTROS\01 RRHH\3 DOCUMENTOS PERSONAL\DOCUMENTOS ERP\FOTOGRAFIA
            SLPicture pic2 = new SLPicture(ruta1);
            /////////////////////////////////////////////////////////////////////////////
            if (File.Exists(ruta1))
            {
                pic2.ResizeInPixels(300, 310);

                pic2.SetPosition(2.1, 4.5); //arriba -- lados
                reporte.InsertPicture(pic2);
            }
            //RUTA PARA FOTO 


            reporte.SaveAs(ruta_rt);


            Microsoft.Office.Interop.Excel.Application myexcelApplication = new Microsoft.Office.Interop.Excel.Application();
            if (myexcelApplication != null)
            {
                Microsoft.Office.Interop.Excel.Workbook myexcelWorkbook = myexcelApplication.Workbooks.Add(ruta_rt);
                myexcelApplication.ActiveWorkbook.ExportAsFixedFormat(Microsoft.Office.Interop.Excel.XlFixedFormatType.xlTypePDF, ruta_pdf, OpenAfterPublish: false);
                myexcelWorkbook.Close(ruta_rt);
                myexcelApplication.Quit();
            }


        }


        private void ID_V_Click(object sender, EventArgs e)
        {

        }


        //METODO QUE REFRESCA
        private void pictureBox5_Click(object sender, EventArgs e)
        {
            refrescar_form();
        }



        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            DOCUMENTO();


            /*  resss = double.Parse(promedio_total2.Texts);

              if (resss <= 59)
              {
                  MessageBox.Show("muy malo");
              }
              else if (resss >= 80)
              {
                  MessageBox.Show("muy bien");
              }


              MessageBox.Show(promedio_total2.Texts);*/



            MENSAJE_GENERAL MN = new MENSAJE_GENERAL();
            MN.BOTON.Text = "DOCUMENTO CREADO CON ÉXITO";
            MN.ShowDialog();
        }




    }
}
