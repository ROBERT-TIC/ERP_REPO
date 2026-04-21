using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace ERP_COMPLETO
{
    public partial class FORMULARIO_DE_PRUEBAS : Form
    {
        public FORMULARIO_DE_PRUEBAS()
        {
            InitializeComponent();
        }


        double val1 = 0;
        double val2 = 0;
        double val3 = 0;
        double val4 = 0;
        double val5 = 0;
        double val6 = 0;
        double val7 = 0;
        double val8 = 0;
        double val9 = 0;
        double val10 = 0;
        double val11 = 0;
        double val12 = 0;
        double val13 = 0;





        private void FORMULARIO_DE_PRUEBAS_Load(object sender, EventArgs e)
        {



        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {


            if (GR1.Texts != string.Empty) { val1 = double.Parse(GR1.Texts); }
            if (GR2.Texts != string.Empty) { val2 = double.Parse(GR2.Texts); }
            if (GR3.Texts != string.Empty) { val3 = double.Parse(GR3.Texts); }
            if (GR4.Texts != string.Empty) { val4 = double.Parse(GR4.Texts); }
            if (GR5.Texts != string.Empty) { val5 = double.Parse(GR5.Texts); }
            if (GR6.Texts != string.Empty) { val6 = double.Parse(GR6.Texts); }
            if (GR7.Texts != string.Empty) { val7 = double.Parse(GR7.Texts); }
            if (GR8.Texts != string.Empty) { val8 = double.Parse(GR8.Texts); }
            if (GR9.Texts != string.Empty) { val9 = double.Parse(GR9.Texts); }
            if (GR10.Texts != string.Empty) { val10 = double.Parse(GR10.Texts); }
            if (GR11.Texts != string.Empty) { val11 = double.Parse(GR11.Texts); }
            if (GR12.Texts != string.Empty) { val12 = double.Parse(GR12.Texts); }
            if (GR13.Texts != string.Empty) { val13 = double.Parse(GR13.Texts); }





            // Configuración del eje X (logarítmico y con inversión)
            chart.ChartAreas[0].AxisX.IsLogarithmic = true;
            chart.ChartAreas[0].AxisX.LabelStyle.Format = "0.00";
            chart.ChartAreas[0].AxisX.Title = "ABERTURA (mm)";
            chart.ChartAreas[0].AxisX.TitleFont = new System.Drawing.Font("Arial", 12, System.Drawing.FontStyle.Bold); // Tamaño y negrita

            // Establecer los límites del eje X
            chart.ChartAreas[0].AxisX.Minimum = 0.01; // Límite mínimo
            chart.ChartAreas[0].AxisX.Maximum = 100; // Límite máximo


            // Invertir el eje X
            chart.ChartAreas[0].AxisX.IsReversed = true;


            // Habilitar el eje Y
            chart.ChartAreas[0].AxisY.Enabled = AxisEnabled.False;
            chart.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
            chart.ChartAreas[0].AxisY.MajorGrid.LineColor = System.Drawing.Color.Gray;

            chart.ChartAreas[0].AxisY.Title = "PORCENTAJE QUE PASA(%)";
            chart.ChartAreas[0].AxisY.TitleFont = new System.Drawing.Font("Arial", 12, System.Drawing.FontStyle.Bold);
            chart.ChartAreas[0].AxisY.Minimum = 0;
            chart.ChartAreas[0].AxisY.Interval = 10;
            chart.ChartAreas[0].AxisY.Maximum = 105;

            // Habilitar el eje Y2
            chart.ChartAreas[0].AxisY2.Enabled = AxisEnabled.True;
            chart.ChartAreas[0].AxisY2.MajorGrid.Enabled = true;
            chart.ChartAreas[0].AxisY2.MajorGrid.LineColor = System.Drawing.Color.LightGray;

            chart.ChartAreas[0].AxisY2.Title = "PORCENTAJE QUE PASA(%)";
            chart.ChartAreas[0].AxisY2.TitleFont = new System.Drawing.Font("Arial", 12, System.Drawing.FontStyle.Bold);
            chart.ChartAreas[0].AxisY2.Minimum = 0;
            chart.ChartAreas[0].AxisY2.Interval = 10;
            chart.ChartAreas[0].AxisY2.Maximum = 105;

            // Datos actualizados
            double[] xValues = { val1, val2, val3, val4, val5, val6, val7, val8, val9, val10, val11, val12, val13 }; //////////// En este campo van las variables
            double[] yValues = { 100, 100, 88.9, 83.9, 69.5, 55.1, 49.4, 29.3, 19.2, 12.8, 8.5, 4.5, 0.2 };

            // Agregar una serie al gráfico para la línea de la granulometría
            Series series = new Series
            {
                Name = "Granulometría",
                Color = System.Drawing.Color.Black,
                IsVisibleInLegend = false,
                ChartType = SeriesChartType.Spline,
                BorderWidth = 3 // Aumentar el grosor de la línea
            };

            // Arreglo con los valores que deseas mostrar en las etiquetas
            string[] labels = new string[] { "2", "1 1/2", "1", "3/4", "1/2", "3/8", "4", "10", "20", "40", "60", "100", "200" };

            // Agregar puntos a la serie de granulometría
            for (int i = 0; i < xValues.Length; i++)
            {
                series.Points.AddXY(xValues[i], yValues[i]);

                /*

                 // Agregar un marcador en cada punto
                 series.Points[i].MarkerStyle = MarkerStyle.Circle; // Estilo del marcador
                 series.Points[i].MarkerSize = 7; // Tamaño del marcador
                 series.Points[i].MarkerColor = System.Drawing.Color.Red; // Color del marcador


                 */




                // Agregar una línea vertical para cada punto
                Series lineSeries = new Series
                {
                    Name = $"Línea {i}",
                    Color = System.Drawing.Color.LightGray,
                    ChartType = SeriesChartType.Line,
                    BorderDashStyle = ChartDashStyle.Solid // Línea sólida
                };

                // Líneas desde el eje X hasta el valor máximo del eje Y
                lineSeries.Points.AddXY(xValues[i], 0); // Línea desde Y=0
                lineSeries.Points.AddXY(xValues[i], 100); // Línea hasta el valor máximo Y (100)

                // Añadir la línea al gráfico
                chart.Series.Add(lineSeries);

                // Agregar etiqueta con el valor correspondiente
                if (i < labels.Length) // Verificar que no se exceda el tamaño del arreglo
                {
                    DataPoint lastPoint = lineSeries.Points[1]; // Último punto de la línea
                    lastPoint.Label = labels[i].ToString(); // Establecer la etiqueta con el valor
                    lastPoint.LabelBackColor = System.Drawing.Color.Transparent; // Color de fondo de la etiqueta
                    lastPoint.Font = new System.Drawing.Font("Arial", 8, System.Drawing.FontStyle.Bold); // Fuente de la etiqueta
                }
            }

            // Añadir la serie de granulometría al gráfico
            chart.Series.Add(series);
            /*
            // Asignar etiquetas a la serie de granulometría
            for (int i = 0; i < series.Points.Count; i++)
            {
                series.Points[i].Label = yValues[i].ToString();
                series.Points[i].LabelForeColor = System.Drawing.Color.FromArgb(16, 77, 141); // Color de la etiqueta
                series.Points[i].LabelBackColor = System.Drawing.Color.Transparent; // Fondo transparente
            }
            */



            // Agregar líneas horizontales en Y=10, Y=30, Y=60
            double[] horizontalLines = { 10, 30, 60 };
            foreach (double y in horizontalLines)
            {
                Series horizontalLine = new Series
                {
                    Name = $"Línea Horizontal {y}",
                    Color = System.Drawing.Color.Red,
                    ChartType = SeriesChartType.Line,
                    BorderDashStyle = ChartDashStyle.Solid,
                    BorderWidth = 1 // Grosor de la línea horizontal
                };

                // Líneas desde el límite del eje X mínimo hasta el máximo
                horizontalLine.Points.AddXY(0.01, y); // Comienzo de la línea
                horizontalLine.Points.AddXY(300, y); // Fin de la línea

                // Añadir la línea horizontal al gráfico
                chart.Series.Add(horizontalLine);
            }




            // Ocultar la leyenda
            chart.Legends[0].Enabled = false;






            // Configuración del eje X (logarítmico y con inversión)
            chart.ChartAreas[0].AxisX.IsLogarithmic = true;
            chart.ChartAreas[0].AxisX.LogarithmBase = 10; // Base logarítmica
            chart.ChartAreas[0].AxisX.Minimum = 0.01;
            chart.ChartAreas[0].AxisX.Maximum = 300;
            chart.ChartAreas[0].AxisX.LabelStyle.Format = "0.##";



            // Personalizar las marcas de división mayores (cortas) en los valores clave (100, 10, 1, 0.1, 0.01)
            chart.ChartAreas[0].AxisX.MajorTickMark.Enabled = true;
            chart.ChartAreas[0].AxisX.MajorTickMark.LineColor = Color.Gray;
            chart.ChartAreas[0].AxisX.MajorTickMark.Size = 4; // Tamaño de las marcas mayores (cortas)
            chart.ChartAreas[0].AxisX.MajorTickMark.LineWidth = 1; // Grosor de las marcas mayores

            // Personalizar las marcas de división menores (cortas)
            chart.ChartAreas[0].AxisX.MinorTickMark.Enabled = true;
            chart.ChartAreas[0].AxisX.MinorTickMark.LineColor = Color.Gray;
            chart.ChartAreas[0].AxisX.MinorTickMark.Size = 1; // Tamaño de las marcas menores
            chart.ChartAreas[0].AxisX.MinorTickMark.LineWidth = 1; // Grosor de las marcas menores

            // Habilitar marcas de división menores en intervalos más pequeños
            chart.ChartAreas[0].AxisX.MinorTickMark.Interval = 1;  // Intervalo de las marcas menores
            chart.ChartAreas[0].AxisX.MinorGrid.Interval = 1;      // Ajusta los intervalos según sea necesario



        }
    }
}
