using ERP_LIEC;
using SpreadsheetLight;
using SpreadsheetLight.Drawing;
using System;
using System.IO;
using System.Windows.Forms;


namespace ERP_COMPLETO
{
    public partial class EJEMPLO_SP : Form
    {
        public EJEMPLO_SP()
        {
            InitializeComponent();
        }



        private void BUZON_QUEJAS_Load(object sender, EventArgs e)
        {

            timer1.Start();
            realizo_f.Text = SESION.usuario;

        }


        //BOTON CERRAR
        private void pictureBox11_Click(object sender, EventArgs e)
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


        //BOTON GUARDAR
        private void altoButton1_Click(object sender, EventArgs e)
        {
            //FORMA DE FECHA
            DateTime HOY = DateTime.Now;

            conexion_supervision_tecnica.Consultageneral("INSERT INTO lista_supervision_sp(FECHA_EVALUACION,SUPERVISOR,SUPERVISADO,LUGAR,ESTATUS,SP_1,OBS_1,SP_2,OBS_2,SP_3,OBS_3,SP_4,OBS_4,SP_5,OBS_5,SP_6,OBS_6,SP_7,OBS_7,SP_8,OBS_8,SP_9,OBS_9,SP_10,OBS_10,SP_11,OBS_11,SP_12,OBS_12,SP_13,OBS_13,SP_14,OBS_14,SP_15,OBS_15,SP_16,OBS_16,SP_17,OBS_17,SP_18,OBS_18,SP_19,OBS_19,SP_20,OBS_20,SP_21,OBS_21,SP_22,OBS_22,SP_23,OBS_23,SP_24,OBS_24,SP_25,OBS_25,SP_26,OBS_26,SP_27,OBS_27,SP_28,OBS_28,SP_29,OBS_29,OBS_GRAL,FECHA_HOY) VALUES ('" + FECHA.Text + "', '" + SESION.name + "', '" + SUPERVISADO.Text + "', '" + OBRA.Text + "', 'EVALUADO', '" + V1.Texts + "', '" + OBS1.Texts.ToUpper() + "', '" + V2.Texts + "', '" + OBS2.Texts.ToUpper() + "', '" + V3.Texts + "', '" + OBS3.Texts.ToUpper() + "', '" + V4.Texts + "', '" + OBS4.Texts.ToUpper() + "', '" + V5.Texts + "', '" + OBS5.Texts.ToUpper() + "', '" + V6.Texts + "', '" + OBS6.Texts.ToUpper() + "', '" + V7.Texts + "', '" + OBS7.Texts.ToUpper() + "', '" + V8.Texts + "', '" + OBS8.Texts.ToUpper() + "', '" + V9.Texts + "', '" + OBS9.Texts.ToUpper() + "', '" + V10.Texts + "', '" + OBS10.Texts.ToUpper() + "', '" + V11.Texts + "', '" + OBS11.Texts.ToUpper() + "', '" + V12.Texts + "', '" + OBS12.Texts.ToUpper() + "', '" + V13.Texts + "', '" + OBS13.Texts.ToUpper() + "', '" + V14.Texts + "', '" + OBS14.Texts.ToUpper() + "', '" + V15.Texts + "', '" + OBS15.Texts.ToUpper() + "', '" + V16.Texts + "', '" + OBS16.Texts.ToUpper() + "', '" + V17.Texts + "', '" + OBS17.Texts.ToUpper() + "', '" + V18.Texts + "', '" + OBS18.Texts.ToUpper() + "', '" + V19.Texts + "', '" + OBS19.Texts.ToUpper() + "', '" + V20.Texts + "', '" + OBS20.Texts.ToUpper() + "', '" + V21.Texts + "', '" + OBS21.Texts.ToUpper() + "', '" + V22.Texts + "', '" + OBS22.Texts.ToUpper() + "', '" + V23.Texts + "', '" + OBS23.Texts.ToUpper() + "', '" + V24.Texts + "', '" + OBS24.Texts.ToUpper() + "', '" + V25.Texts + "', '" + OBS25.Texts.ToUpper() + "', '" + V26.Texts + "', '" + OBS26.Texts.ToUpper() + "', '" + V27.Texts + "', '" + OBS27.Texts.ToUpper() + "', '" + V28.Texts + "', '" + OBS28.Texts.ToUpper() + "', '" + V29.Texts + "', '" + OBS29.Texts.ToUpper() + "', '" + OBSERVACIONES_GRAL.Texts.ToUpper() + "', '" + HOY.ToString("yyyy-MM-dd H:mm:ss") + "')   ");
            MessageBox.Show("SE HA EVALUADO CORRECTAMENTE");

            //genera_reporte();
            MENSAJE_GENERAL MN = new MENSAJE_GENERAL();
            MN.BOTON.Text = "Lista de Supervisión Generada";
            MN.ShowDialog();

            this.Close();

        }

        private void genera_reporte()
        {

            string plantilla = @"Z:\LIEP-08 ERP\2023\LIERP-01\SUPERVISIÓN SERVICIO PERMANENTE.xlsx"; //SE ALOJA LA PLANTILLA 

            string documentos = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string ruta_rt = Path.Combine(documentos, SUPERVISADO.Text + " - LISTA_SUPERVISIÓN_INSTALACIONES_TEMPORALES.xlsx");  //ruta excel/pdf
            string ruta_pdf = Path.Combine(documentos, SUPERVISADO.Text + " - LISTA_SUPERVISIÓN_INSTALACIONES_TEMPORALES.pdf");  //ruta excel/pdf


            SLDocument reporte = new SLDocument(plantilla);

            if (DECICION_REMOTA.concretos_remota == true)
            {
                tabla_fir.DataSource = logueo_remoto.Consultageneral("SELECT * FROM usuarios WHERE usuario = '" + realizo_f.Text + "' ");
            }
            else
            {
                tabla_fir.DataSource = conexion_login.Consultageneral("SELECT * FROM usuarios WHERE usuario = '" + realizo_f.Text + "' ");
            }

            string realizo = tabla_fir.Rows[0].Cells[5].Value.ToString();
            string nonmbre_realizo = tabla_fir.Rows[0].Cells[1].Value.ToString();
            SLPicture pic = new SLPicture(@"A:\FIRMAS\" + realizo_f.Text + ".PNG");
            pic.ResizeInPixels(80, 80);

            pic.SetPosition(81, 1.3);
            reporte.InsertPicture(pic);    //FIRMA + NOMBRE REALIZO

            reporte.SelectWorksheet("Hoja1");

            reporte.SetCellValue("C3", FECHA.Text); //FECHA
            reporte.SetCellValue("C4", OBRA.Text.ToUpper()); //LUGAR

            //PUNTUACION
            reporte.SetCellValue("E9", V1.Texts.ToUpper()); //
            reporte.SetCellValue("E11", V2.Texts.ToUpper()); //
            reporte.SetCellValue("E13", V3.Texts.ToUpper()); //
            reporte.SetCellValue("E15", V4.Texts.ToUpper()); //
            reporte.SetCellValue("E17", V5.Texts.ToUpper()); //
            reporte.SetCellValue("E19", V6.Texts.ToUpper()); //
            reporte.SetCellValue("E21", V7.Texts.ToUpper()); //
            reporte.SetCellValue("E23", V8.Texts.ToUpper()); //
            reporte.SetCellValue("E25", V9.Texts.ToUpper()); //
            reporte.SetCellValue("E27", V10.Texts.ToUpper()); //
            reporte.SetCellValue("E30", V11.Texts.ToUpper());
            reporte.SetCellValue("E32", V12.Texts.ToUpper()); //
            reporte.SetCellValue("E34", V13.Texts.ToUpper()); //
            reporte.SetCellValue("E36", V14.Texts.ToUpper()); //
            reporte.SetCellValue("E38", V15.Texts.ToUpper()); //
            reporte.SetCellValue("E40", V16.Texts.ToUpper()); //
            reporte.SetCellValue("E42", V17.Texts.ToUpper()); //
            reporte.SetCellValue("E44", V18.Texts.ToUpper()); //
            reporte.SetCellValue("E46", V19.Texts.ToUpper()); //
            reporte.SetCellValue("E48", V20.Texts.ToUpper()); //
            reporte.SetCellValue("E50", V21.Texts.ToUpper()); //
            reporte.SetCellValue("E52", V22.Texts.ToUpper()); //
            reporte.SetCellValue("E54", V23.Texts.ToUpper()); //
            reporte.SetCellValue("E57", V24.Texts.ToUpper()); //
            reporte.SetCellValue("E59", V25.Texts.ToUpper()); //
            reporte.SetCellValue("E61", V26.Texts.ToUpper()); //
            reporte.SetCellValue("E63", V27.Texts.ToUpper()); //
            reporte.SetCellValue("E65", V28.Texts.ToUpper()); //
            reporte.SetCellValue("E67", V29.Texts.ToUpper()); //

            //OBSERVACIONES
            if (OBS1.Texts == string.Empty) { reporte.SetCellValue("F9", "-------------------"); } else { reporte.SetCellValue("F9", OBS1.Texts); }
            if (OBS2.Texts == string.Empty) { reporte.SetCellValue("F11", "-------------------"); } else { reporte.SetCellValue("F11", OBS2.Texts); }
            if (OBS3.Texts == string.Empty) { reporte.SetCellValue("F13", "-------------------"); } else { reporte.SetCellValue("F13", OBS3.Texts); }
            if (OBS4.Texts == string.Empty) { reporte.SetCellValue("F15", "-------------------"); } else { reporte.SetCellValue("F15", OBS4.Texts); }
            if (OBS5.Texts == string.Empty) { reporte.SetCellValue("F17", "-------------------"); } else { reporte.SetCellValue("F17", OBS5.Texts); }
            if (OBS6.Texts == string.Empty) { reporte.SetCellValue("F19", "-------------------"); } else { reporte.SetCellValue("F19", OBS6.Texts); }
            if (OBS7.Texts == string.Empty) { reporte.SetCellValue("F21", "-------------------"); } else { reporte.SetCellValue("F21", OBS7.Texts); }
            if (OBS8.Texts == string.Empty) { reporte.SetCellValue("F23", "-------------------"); } else { reporte.SetCellValue("F23", OBS8.Texts); }
            if (OBS9.Texts == string.Empty) { reporte.SetCellValue("F25", "-------------------"); } else { reporte.SetCellValue("F25", OBS9.Texts); }
            if (OBS10.Texts == string.Empty) { reporte.SetCellValue("F27", "-------------------"); } else { reporte.SetCellValue("F27", OBS10.Texts); }
            if (OBS11.Texts == string.Empty) { reporte.SetCellValue("F30", "-------------------"); } else { reporte.SetCellValue("F30", OBS11.Texts); }
            if (OBS12.Texts == string.Empty) { reporte.SetCellValue("F32", "-------------------"); } else { reporte.SetCellValue("F32", OBS12.Texts); }
            if (OBS13.Texts == string.Empty) { reporte.SetCellValue("F34", "-------------------"); } else { reporte.SetCellValue("F34", OBS13.Texts); }
            if (OBS14.Texts == string.Empty) { reporte.SetCellValue("F36", "-------------------"); } else { reporte.SetCellValue("F36", OBS14.Texts); }
            if (OBS15.Texts == string.Empty) { reporte.SetCellValue("F38", "-------------------"); } else { reporte.SetCellValue("F38", OBS15.Texts); }
            if (OBS16.Texts == string.Empty) { reporte.SetCellValue("F40", "-------------------"); } else { reporte.SetCellValue("F40", OBS16.Texts); }
            if (OBS17.Texts == string.Empty) { reporte.SetCellValue("F42", "-------------------"); } else { reporte.SetCellValue("F42", OBS17.Texts); }
            if (OBS18.Texts == string.Empty) { reporte.SetCellValue("F44", "-------------------"); } else { reporte.SetCellValue("F44", OBS18.Texts); }
            if (OBS19.Texts == string.Empty) { reporte.SetCellValue("F46", "-------------------"); } else { reporte.SetCellValue("F46", OBS19.Texts); }
            if (OBS20.Texts == string.Empty) { reporte.SetCellValue("F48", "-------------------"); } else { reporte.SetCellValue("F48", OBS20.Texts); }
            if (OBS21.Texts == string.Empty) { reporte.SetCellValue("F50", "-------------------"); } else { reporte.SetCellValue("F50", OBS21.Texts); }
            if (OBS22.Texts == string.Empty) { reporte.SetCellValue("F52", "-------------------"); } else { reporte.SetCellValue("F52", OBS22.Texts); }
            if (OBS23.Texts == string.Empty) { reporte.SetCellValue("F54", "-------------------"); } else { reporte.SetCellValue("F54", OBS23.Texts); }
            if (OBS24.Texts == string.Empty) { reporte.SetCellValue("F57", "-------------------"); } else { reporte.SetCellValue("F57", OBS24.Texts); }
            if (OBS25.Texts == string.Empty) { reporte.SetCellValue("F59", "-------------------"); } else { reporte.SetCellValue("F59", OBS25.Texts); }
            if (OBS26.Texts == string.Empty) { reporte.SetCellValue("F61", "-------------------"); } else { reporte.SetCellValue("F61", OBS26.Texts); }
            if (OBS27.Texts == string.Empty) { reporte.SetCellValue("F63", "-------------------"); } else { reporte.SetCellValue("F63", OBS27.Texts); }
            if (OBS28.Texts == string.Empty) { reporte.SetCellValue("F65", "-------------------"); } else { reporte.SetCellValue("F65", OBS28.Texts); }
            if (OBS29.Texts == string.Empty) { reporte.SetCellValue("F67", "-------------------"); } else { reporte.SetCellValue("F67", OBS29.Texts); }
            if (OBSERVACIONES_GRAL.Texts == string.Empty) { reporte.SetCellValue("A72", "-------------------"); } else { reporte.SetCellValue("A72", OBSERVACIONES_GRAL.Texts); }

            //  reporte.SetCellValue("F9", OBS1.Texts.ToUpper()); //
            //  reporte.SetCellValue("F11", OBS2.Texts.ToUpper()); //
            // reporte.SetCellValue("F13", OBS3.Texts.ToUpper()); //
            // reporte.SetCellValue("F15", OBS4.Texts.ToUpper()); //
            //reporte.SetCellValue("F17", OBS5.Texts.ToUpper()); //
            //reporte.SetCellValue("F19", OBS6.Texts.ToUpper()); //
            //reporte.SetCellValue("F21", OBS7.Texts.ToUpper()); //
            //reporte.SetCellValue("F23", OBS8.Texts.ToUpper()); //
            //reporte.SetCellValue("F25", OBS9.Texts.ToUpper()); //
            //reporte.SetCellValue("F27", OBS10.Texts.ToUpper()); //
            //reporte.SetCellValue("F30", OBS11.Texts.ToUpper()); //
            //reporte.SetCellValue("F32", OBS12.Texts.ToUpper()); //
            //reporte.SetCellValue("F34", OBS13.Texts.ToUpper()); //
            //reporte.SetCellValue("F36", OBS14.Texts.ToUpper()); //
            //reporte.SetCellValue("F38", OBS15.Texts.ToUpper()); //
            //reporte.SetCellValue("F40", OBS16.Texts.ToUpper()); //
            //reporte.SetCellValue("F42", OBS17.Texts.ToUpper()); //
            //reporte.SetCellValue("F44", OBS18.Texts.ToUpper()); //
            //reporte.SetCellValue("F46", OBS19.Texts.ToUpper()); //
            //reporte.SetCellValue("F48", OBS20.Texts.ToUpper()); //
            //reporte.SetCellValue("F50", OBS21.Texts.ToUpper()); //
            //reporte.SetCellValue("F52", OBS22.Texts.ToUpper()); //
            //reporte.SetCellValue("F54", OBS23.Texts.ToUpper()); //
            //reporte.SetCellValue("F57", OBS24.Texts.ToUpper()); //
            //reporte.SetCellValue("F59", OBS25.Texts.ToUpper()); //
            //reporte.SetCellValue("F61", OBS26.Texts.ToUpper()); //
            //reporte.SetCellValue("F63", OBS27.Texts.ToUpper()); //
            //reporte.SetCellValue("F65", OBS28.Texts.ToUpper()); //
            //reporte.SetCellValue("F67", OBS29.Texts.ToUpper()); //
            //reporte.SetCellValue("A72", OBSERVACIONES_GRAL.Texts.ToUpper()); //OBSERVACIONES GENERALES

            reporte.SetCellValue("B85", SESION.name.ToUpper()); //SUPERVISOR
            reporte.SetCellValue("E85", SUPERVISADO.Text.ToUpper()); //SUPERVISADO


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


        //BOTON QUE GENERA EL EXCEL Y PDF
        private void pictureBox9_Click(object sender, EventArgs e)
        {
            genera_reporte();
            MENSAJE_GENERAL MN = new MENSAJE_GENERAL();
            MN.BOTON.Text = "Lista de Supervisión Generada";
            MN.ShowDialog();
        }

        private void OBRA_Click(object sender, EventArgs e)
        {

        }
    }
}
