using SpreadsheetLight;
using System;
using System.IO;
using System.Windows.Forms;  //DEFINEN UN AMBITO PARA UTILIZAR RECURSOS //

namespace ERP_COMPLETO  //NOMBRE DEL ESPACIO
{
    public partial class BASE_DE_ACUMULADOS : Form  //CLASE PRINCIPAL DEL FORMULARIO ACTUAL
    {
        public BASE_DE_ACUMULADOS()
        {
            InitializeComponent();   //INICIALIZA COMPONENTE
        }




        private void control_concreto()
        {                                                                      //QUERY DE CONSULTA
            tabla.DataSource = CONEXION_CONCRETOS.Consultageneral("SELECT CLAVE_OBRA, TIPO_CONCRETO, CLASE, DOCIFICACION, REV_CO, TMA_CO, FC, PROCEDENCIA, NO_MUESTRA, NO_SERIE, TIPO_ESPECIMEN, LOCALIZACION, FECHA_COLADO, ELEMENTO  FROM registro_general WHERE CLAVE_OBRA = '" + CLAVE.Texts + "' ORDER BY NO_MUESTRA ASC ");

            if (tabla.RowCount != 0)  //CONDICIONAL 
            {

                string pl = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                string ruta = Path.Combine(pl, CLAVE.Texts + " ACUMULADO TÉCNICO.xlsx");


                string plantilla = @"Z:\LIEP-08 ERP\2023\LIERP-01\01 FORMATOS\ACUMULADO CONCRETO1.xlsx";  //RUTAS DE ACCESO A RECURSOS 

                SLDocument reporte = new SLDocument(plantilla);
                reporte.SelectWorksheet("Hoja1");


                int fila = 11;  //VARIABLE 

                reporte.SetCellValue("A1", "CONTROL DE CALIDAD DEL CONCRETO -  kgf/cm2 DE " + CLAVE.Texts);

                foreach (DataGridViewRow row in tabla.Rows)  //RECORRE INFORMACION 
                {

                    reporte.SetCellValue(fila, 15, row.Cells[1].Value.ToString());   //DEPOSITO DE INFORMACION
                    reporte.SetCellValue(fila, 16, row.Cells[7].Value.ToString());   //DEPOSITO DE INFORMACION
                    reporte.SetCellValue(fila, 17, row.Cells[3].Value.ToString());   //DEPOSITO DE INFORMACION
                    reporte.SetCellValue(fila, 18, double.Parse(row.Cells[6].Value.ToString()));
                    if (int.TryParse(row.Cells[4].Value.ToString(), out int num)) { reporte.SetCellValue(fila, 19, num); } else { reporte.SetCellValue(fila, 19, row.Cells[4].Value.ToString()); }   //DEPOSITO DE INFORMACION
                    if (int.TryParse(row.Cells[5].Value.ToString(), out int num2)) { reporte.SetCellValue(fila, 20, num2); } else { reporte.SetCellValue(fila, 20, row.Cells[5].Value.ToString()); }   //DEPOSITO DE INFORMACION




                    reporte.SetCellValue(fila, 1, row.Cells[9].Value.ToString());   //DEPOSITO DE INFORMACION
                    reporte.SetCellValue(fila, 2, DateTime.Parse(row.Cells[12].Value.ToString()).ToString("yyyy-MM-dd"));
                    reporte.SetCellValue(fila, 4, row.Cells[11].Value.ToString() + ", " + row.Cells[13].Value.ToString());   //DEPOSITO DE INFORMACION





                    tabla2.DataSource = CONEXION_CONCRETOS.Consultageneral("SELECT CLAVE_OBRA, EDAD, ESFUERZOP FROM ensayados WHERE CLAVE_OBRA = '" + CLAVE.Texts + "-" + row.Cells[9].Value.ToString() + "' ");    //QUERY DE CONSULTA
                    foreach (DataGridViewRow row2 in tabla2.Rows)
                    {
                        if (row2.Cells[1].Value.ToString() == "1") { reporte.SetCellValue(fila, 10, double.Parse(row2.Cells[2].Value.ToString())); }  //CONDICIONALES 
                        else if (row2.Cells[1].Value.ToString() == "3") { reporte.SetCellValue(fila, 11, double.Parse(row2.Cells[2].Value.ToString())); }  //CONDICIONALES 
                        else if (row2.Cells[1].Value.ToString() == "7") { reporte.SetCellValue(fila, 12, double.Parse(row2.Cells[2].Value.ToString())); }  //CONDICIONALES 
                        else if (row2.Cells[1].Value.ToString() == "14") { reporte.SetCellValue(fila, 13, double.Parse(row2.Cells[2].Value.ToString())); }  //CONDICIONALES 
                        else if (row2.Cells[1].Value.ToString() == "28") { reporte.SetCellValue(fila, 14, double.Parse(row2.Cells[2].Value.ToString())); }
                        else { reporte.SetCellValue(fila, 10, "FR"); }
                    }

                    fila = fila + 1;

                }



                reporte.SaveAs(ruta);  //GUARDA FORMATO 





                MENSAJE_GENERAL mn = new MENSAJE_GENERAL();
                mn.BOTON.Text = "Acumulado Técnico generado correctamente, revisa tus documentos";   //MENSAJE ALERTA 
                mn.ShowDialog();


            }
            else
            {
                MENSAJE_GENERAL mn = new MENSAJE_GENERAL();
                mn.BOTON.Text = "No se encontro ningun registro con respecto a esta clave de obra o rango de fechas";   //MENSAJE ALERTA 
                mn.BOTON.Inactive1 = System.Drawing.Color.Red;
                mn.BOTON.Inactive2 = System.Drawing.Color.Red;
                mn.ShowDialog();
            }


        }


        private void BASE_DE_ACUMULADOS_Load(object sender, EventArgs e)
        {

        }

        private void altoButton1_Click(object sender, EventArgs e)
        {

            if (CLAVE.Texts != string.Empty)  //CONDICIONALES 
            {
                altoButton1.Enabled = false;

                if (NOMBRE.Texts == "CONTROL DE CALIDAD DEL CONCRETO  kgf/cm2") { control_concreto(); }

            }
            else
            {

                MENSAJE_GENERAL mn = new MENSAJE_GENERAL();
                mn.BOTON.Text = "No tienes ninguna Clave de Obra registrada";  //MENSAJE ALERTA 
                mn.BOTON.Inactive1 = System.Drawing.Color.Red;
                mn.BOTON.Inactive2 = System.Drawing.Color.Red;
                mn.ShowDialog();

            }







        }
    }
}
