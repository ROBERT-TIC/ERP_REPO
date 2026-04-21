using ERP_LIEC;
using LiveCharts;
using LiveCharts.Wpf;
using MySql.Data.MySqlClient;
using System;   //DEFINEN UN AMBITO PARA UTILIZAR RECURSOS //
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ERP_COMPLETO  //NOMBRE DEL ESPACIO
{
    public partial class INDEX_SUP : Form  //CLASE PRINCIPAL DEL FORMULARIO ACTUAL
    {
        public INDEX_SUP()
        {
            InitializeComponent();   //INICIALIZA COMPONENTE
        }


        int alto = 0;  //VARIABLES INICIALES
        int medio = 0;
        int bajo = 0;
        int muy_bajo = 0;
        int no_realizadas = 0;
        int PORCENTAJEFUNCION = 0;



        private void tomar_categorias()
        {
            MySqlConnection CONEXION = conexion_rh.USR;   //CONEXION A DB 
            MySqlCommand comando = new MySqlCommand("SELECT * FROM  categorias ORDER BY CATEGORIA ", CONEXION);  //QUERY DE CONSULTA


            CONEXION.Open();
            MySqlDataReader consulta = comando.ExecuteReader();

            while (consulta.Read())
            {
                area.Items.Add(consulta["CATEGORIA"].ToString());  //DEPOSITO DE INFORMACION


            }

            CONEXION.Close();   //CIERRE DE CONEXION


        }
        private void estatica()   //ESTILOS APLICABLES A ELEMENTOS 
        {

            p_titulo.Height = 43;
            p_azul.Height = 50;
            img_titulo.Size = new Size(30, 30);
            altoButton1.Height = 30;
            area.Height = 30;
            Año.Height = 30;


            titulo.Left = (p_titulo.Width - titulo.Width) / 2;
            titulo.Top = (p_titulo.Height - titulo.Height) / 2;   //ESTILOS APLICABLES A ELEMENTOS 
            img_titulo.Left = (titulo.Left - img_titulo.Width) - 5;
            img_titulo.Top = (p_titulo.Height - img_titulo.Height) / 2;

            label_año.Height = (p_azul.Height - label_año.Height) / 2;
            label_año.Left = 30;
            Año.Top = (p_azul.Height - Año.Height) / 2;
            label_area.Top = (p_azul.Height - label_area.Height) / 2;
            area.Top = (p_azul.Height - area.Height) / 2;

            Año.Left = label_año.Right + 10;
            label_area.Left = Año.Right + 10;
            area.Left = label_area.Right + 10;   //ESTILOS APLICABLES A ELEMENTOS 

            p1.Width = this.Width / 2;
            p2.Width = this.Width / 2;


            altoButton1.Top = (p_azul.Height - altoButton1.Height) / 2;
            altoButton1.Left = (p_azul.Width - altoButton1.Width) - 10;

            REFRESH.Left = (altoButton1.Left - REFRESH.Width) - 20;   //ESTILOS APLICABLES A ELEMENTOS 
            REFRESH.Top = (p_azul.Height - altoButton1.Height) / 2;


            panel1.Height = 35;
            myProgressBar.Left = label_año.Left;
            myProgressBar.Width = altoButton1.Right - myProgressBar.Left;

            ss1.Left = (ps1.Width - ss1.Width) / 2;
            ss2.Left = (ps2.Width - ss2.Width) / 2;
        }



        private void grafica()
        {

            // Defina la etiqueta que aparecerá sobre la parte del gráfico.
            // en este caso mostraremos el valor dado y el porcentaje, por ejemplo, 123 (8%)
            Func<ChartPoint, string> labelPoint = chartPoint => string.Format("{0} ({1:P})", chartPoint.Y, chartPoint.Participation);

            // Definir una colección de elementos para mostrar en el gráfico.
            SeriesCollection piechartData = new SeriesCollection
    {
        new PieSeries
        {
            Title = "Alto rendimiento",
            Values = new ChartValues<double> {alto},
            DataLabels = true,
            LabelPoint = labelPoint,
            Fill = System.Windows.Media.Brushes.MediumSeaGreen,
        },
        new PieSeries
        {
            Title = "Rendimiento Regular",
            Values = new ChartValues<double> {medio},
            DataLabels = true,
            LabelPoint = labelPoint,
              Fill = System.Windows.Media.Brushes.DodgerBlue,
        },
        new PieSeries
        {
            Title = "Rendimiento Insuficiente",
            Values = new ChartValues<double> {bajo},
            DataLabels = true,
            LabelPoint = labelPoint,
               Fill = System.Windows.Media.Brushes.Goldenrod,
        },
        new PieSeries
        {
            Title = "Bajo Rendimiento",
            Values = new ChartValues<double> {muy_bajo},
            DataLabels = true,
            LabelPoint = labelPoint,
             Fill = System.Windows.Media.Brushes.IndianRed,
        },
         new PieSeries
        {
            Title = "No realizadas",
            Values = new ChartValues<double> {no_realizadas},
            DataLabels = true,
            LabelPoint = labelPoint,
             Fill = System.Windows.Media.Brushes.Gray,
        }

    };



            // Definir la colección de valores para mostrar en el gráfico circular
            pieChart1.Series = piechartData;

            // Establecer la ubicación de la leyenda para que aparezca en el lado derecho del gráfico
            pieChart1.LegendLocation = LegendLocation.Right;


        }
        private void grafica2()
        {
            // Defina la etiqueta que aparecerá sobre la parte del gráfico.
            // en este caso mostraremos el valor dado y el porcentaje, por ejemplo, 123 (8%)
            Func<ChartPoint, string> labelPoint = chartPoint => string.Format("{0} ({1:P})", chartPoint.Y, chartPoint.Participation);

            // Definir una colección de elementos para mostrar en el gráfico.
            SeriesCollection piechartData = new SeriesCollection
    {
        new PieSeries
        {
            Title = "Alto rendimiento",
            Values = new ChartValues<double> {alto},
            DataLabels = true,
            LabelPoint = labelPoint,
            Fill = System.Windows.Media.Brushes.MediumSeaGreen,
        },
        new PieSeries
        {
            Title = "Rendimiento Regular",
            Values = new ChartValues<double> {medio},
            DataLabels = true,
            LabelPoint = labelPoint,
              Fill = System.Windows.Media.Brushes.DodgerBlue,
        },
        new PieSeries
        {
            Title = "Rendimiento Insuficiente",
            Values = new ChartValues<double> {bajo},
            DataLabels = true,
            LabelPoint = labelPoint,
               Fill = System.Windows.Media.Brushes.Goldenrod,
        },
        new PieSeries
        {
            Title = "Bajo Rendimiento",
            Values = new ChartValues<double> {muy_bajo},
            DataLabels = true,
            LabelPoint = labelPoint,
             Fill = System.Windows.Media.Brushes.IndianRed,
        },
         new PieSeries
        {
            Title = "No realizadas",
            Values = new ChartValues<double> {no_realizadas},
            DataLabels = true,
            LabelPoint = labelPoint,
           Fill = System.Windows.Media.Brushes.Silver,
        }

    };


            // Definir la colección de valores para mostrar en el gráfico circular
            pieChart2.Series = piechartData;

            // Establecer la ubicación de la leyenda para que aparezca en el lado derecho del gráfico
            pieChart2.LegendLocation = LegendLocation.Right;


        }

        private void INDEX_SUP_Load(object sender, EventArgs e)
        {
            estatica();
            tomar_categorias();

            this.ET.SetToolTip(REFRESH, "Refrescar Vista");

        }

        private void pieChart1_ChildChanged(object sender, System.Windows.Forms.Integration.ChildChangedEventArgs e)
        {




        }

        private void pieChart1_DataClick(object sender, ChartPoint chartPoint)
        {








            string dato = chartPoint.SeriesView.Title;


            if (dato == "Alto rendimiento")
            {
                Form nv = new Form();
                using (DETALLES_SUPREVISION_PERSONAL mn = new DETALLES_SUPREVISION_PERSONAL())  //ABRE FORMULARIO 
                {
                    nv.StartPosition = FormStartPosition.Manual;
                    nv.FormBorderStyle = FormBorderStyle.None;
                    nv.Opacity = .70d;
                    nv.BackColor = Color.Black;
                    nv.WindowState = FormWindowState.Maximized;   //ESTILOS APLICABLES A ELEMENTOS 
                    nv.TopMost = false;
                    nv.Location = this.Location;
                    nv.ShowInTaskbar = false;
                    nv.Show();
                    mn.Owner = nv;
                    mn.Opacity = 0;
                    mn.titulo.Text = "Alto rendimiento";

                    mn.semestre_primero = true;
                    mn.rango1 = 80;
                    mn.rango2 = 100;

                    mn.semestre = Año.Texts + "-06-01";
                    mn.filtro = area.Texts;
                    mn.no_realizado = false;


                    mn.ShowDialog();

                    nv.Dispose();
                }



            }
            if (dato == "Rendimiento Regular")
            {
                Form nv = new Form();
                using (DETALLES_SUPREVISION_PERSONAL mn = new DETALLES_SUPREVISION_PERSONAL())  //ABRE FORMULARIO 
                {
                    nv.StartPosition = FormStartPosition.Manual;
                    nv.FormBorderStyle = FormBorderStyle.None;
                    nv.Opacity = .70d;
                    nv.BackColor = Color.Black;
                    nv.WindowState = FormWindowState.Maximized;   //ESTILOS APLICABLES A ELEMENTOS 
                    nv.TopMost = false;
                    nv.Location = this.Location;
                    nv.ShowInTaskbar = false;
                    nv.Show();
                    mn.Owner = nv;
                    mn.Opacity = 0;

                    mn.semestre_primero = true;
                    mn.rango1 = 60;
                    mn.rango2 = 80;
                    mn.titulo.Text = "Rendimiento Regular";
                    mn.semestre = Año.Texts + "-06-01";
                    mn.filtro = area.Texts;
                    mn.no_realizado = false;


                    mn.ShowDialog();

                    nv.Dispose();
                }

            }
            if (dato == "Rendimiento Insuficiente")
            {
                Form nv = new Form();
                using (DETALLES_SUPREVISION_PERSONAL mn = new DETALLES_SUPREVISION_PERSONAL())   //ABRE FORMULARIO 
                {
                    nv.StartPosition = FormStartPosition.Manual;
                    nv.FormBorderStyle = FormBorderStyle.None;
                    nv.Opacity = .70d;
                    nv.BackColor = Color.Black;
                    nv.WindowState = FormWindowState.Maximized;   //ESTILOS APLICABLES A ELEMENTOS 
                    nv.TopMost = false;
                    nv.Location = this.Location;
                    nv.ShowInTaskbar = false;
                    nv.Show();
                    mn.Owner = nv;
                    mn.Opacity = 0;

                    mn.semestre_primero = true;
                    mn.rango1 = 40;
                    mn.rango2 = 60;
                    mn.titulo.Text = "Rendimiento Insuficiente";
                    mn.semestre = Año.Texts + "-06-01";
                    mn.filtro = area.Texts;
                    mn.no_realizado = false;


                    mn.ShowDialog();

                    nv.Dispose();
                }
            }
            if (dato == "Bajo Rendimiento")
            {
                Form nv = new Form();
                using (DETALLES_SUPREVISION_PERSONAL mn = new DETALLES_SUPREVISION_PERSONAL())  //ABRE FORMULARIO 
                {
                    nv.StartPosition = FormStartPosition.Manual;
                    nv.FormBorderStyle = FormBorderStyle.None;
                    nv.Opacity = .70d;
                    nv.BackColor = Color.Black;
                    nv.WindowState = FormWindowState.Maximized;   //ESTILOS APLICABLES A ELEMENTOS 
                    nv.TopMost = false;
                    nv.Location = this.Location;
                    nv.ShowInTaskbar = false;
                    nv.Show();
                    mn.Owner = nv;
                    mn.Opacity = 0;
                    mn.titulo.Text = "Bajo Rendimiento";

                    mn.semestre_primero = true;
                    mn.rango1 = 0;
                    mn.rango2 = 40;

                    mn.semestre = Año.Texts + "-06-01";
                    mn.filtro = area.Texts;
                    mn.no_realizado = false;


                    mn.ShowDialog();

                    nv.Dispose();
                }
            }
            if (dato == "No realizadas")
            {
                Form nv = new Form();
                using (DETALLES_SUPREVISION_PERSONAL mn = new DETALLES_SUPREVISION_PERSONAL())  //ABRE FORMULARIO 
                {
                    nv.StartPosition = FormStartPosition.Manual;
                    nv.FormBorderStyle = FormBorderStyle.None;
                    nv.Opacity = .70d;
                    nv.BackColor = Color.Black;
                    nv.WindowState = FormWindowState.Maximized;   //ESTILOS APLICABLES A ELEMENTOS 
                    nv.TopMost = false;
                    nv.Location = this.Location;
                    nv.ShowInTaskbar = false;
                    nv.Show();
                    mn.Owner = nv;
                    mn.Opacity = 0;

                    mn.semestre_primero = true;
                    mn.rango1 = 0;
                    mn.rango2 = 0;

                    mn.semestre = Año.Texts + "-06-01";
                    mn.filtro = area.Texts;
                    mn.no_realizado = true;


                    mn.ShowDialog();

                    nv.Dispose();
                }
            }













        }

        private void primer_semest()
        {
            no_realizadas = 0;

            tabla.DataSource = conexion_rh.Consultageneral("SELECT * FROM pdr_personal1 WHERE CATEGORIA LIKE '%" + area.Texts + "%'");   //QUERY DE CONSULTA
            no_realizadas = tabla.RowCount;
            tabla.DataSource = conexion_supervision_tecnica.Consultageneral("SELECT RESULTADO FROM personal_agenda WHERE CATEGORIA LIKE '%" + area.Texts + "%' AND FECHA_TENTATIVA < '" + Año.Texts + "-06-01" + "'");   //QUERY DE CONSULTA

            foreach (DataGridViewRow row in tabla.Rows)
            {

                double dato = double.Parse(row.Cells[0].Value.ToString());
                if (dato >= 80 && dato <= 100) { alto = alto + 1; no_realizadas = no_realizadas - 1; }
                else if (dato >= 60 && dato <= 80) { medio = medio + 1; no_realizadas = no_realizadas - 1; }
                else if (dato >= 40 && dato <= 60) { bajo = bajo + 1; no_realizadas = no_realizadas - 1; }
                else if (dato >= 0 && dato <= 20) { muy_bajo = muy_bajo + 1; no_realizadas = no_realizadas - 1; }
            }



            //////////


            // Defina la etiqueta que aparecerá sobre la parte del gráfico.
            // en este caso mostraremos el valor dado y el porcentaje, por ejemplo, 123 (8%)
            Func<ChartPoint, string> labelPoint = chartPoint => string.Format("{0} ({1:P})", chartPoint.Y, chartPoint.Participation);

            // Definir una colección de elementos para mostrar en el gráfico.
            SeriesCollection piechartData = new SeriesCollection
    {
        new PieSeries
        {
            Title = "Alto rendimiento",
            Values = new ChartValues<double> {alto},
            DataLabels = true,
            LabelPoint = labelPoint,
            Fill = System.Windows.Media.Brushes.MediumSeaGreen,
        },
        new PieSeries
        {
            Title = "Rendimiento Regular",
            Values = new ChartValues<double> {medio},
            DataLabels = true,
            LabelPoint = labelPoint,
              Fill = System.Windows.Media.Brushes.DodgerBlue,
        },
        new PieSeries
        {
            Title = "Rendimiento Insuficiente",
            Values = new ChartValues<double> {bajo},
            DataLabels = true,
            LabelPoint = labelPoint,
               Fill = System.Windows.Media.Brushes.Goldenrod,
        },
        new PieSeries
        {
            Title = "Bajo Rendimiento",
            Values = new ChartValues<double> {muy_bajo},
            DataLabels = true,
            LabelPoint = labelPoint,
             Fill = System.Windows.Media.Brushes.IndianRed,
        },
         new PieSeries
        {
            Title = "No realizadas",
            Values = new ChartValues<double> {no_realizadas},
            DataLabels = true,
            LabelPoint = labelPoint,
             Fill = System.Windows.Media.Brushes.Silver,
            // Fill = System.Windows.Media.Brushes.LightSteelBlue,
        }

    };


            // Definir la colección de valores para mostrar en el gráfico circular
            pieChart1.Series = piechartData;

            // Establecer la ubicación de la leyenda para que aparezca en el lado derecho del gráfico
            pieChart1.LegendLocation = LegendLocation.Right;
            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////









        }
        private void segundo_semest()
        {

            no_realizadas = 0;
            alto = 0;
            medio = 0;
            bajo = 0;
            muy_bajo = 0;

            tabla.DataSource = conexion_rh.Consultageneral("SELECT * FROM pdr_personal1 WHERE CATEGORIA LIKE '%" + area.Texts + "%'");   //QUERY DE CONSULTA
            no_realizadas = tabla.RowCount;
            tabla.DataSource = conexion_supervision_tecnica.Consultageneral("SELECT RESULTADO FROM personal_agenda WHERE CATEGORIA LIKE '%" + area.Texts + "%' AND FECHA_TENTATIVA > '" + Año.Texts + "-06-01" + "'");   //QUERY DE CONSULTA

            foreach (DataGridViewRow row in tabla.Rows)
            {

                double dato = double.Parse(row.Cells[0].Value.ToString());
                if (dato >= 80 && dato <= 100) { alto = alto + 1; no_realizadas = no_realizadas - 1; }
                else if (dato >= 60 && dato <= 80) { medio = medio + 1; no_realizadas = no_realizadas - 1; }
                else if (dato >= 40 && dato <= 60) { bajo = bajo + 1; no_realizadas = no_realizadas - 1; }
                else if (dato >= 0 && dato <= 20) { muy_bajo = muy_bajo + 1; no_realizadas = no_realizadas - 1; }
            }


            grafica2();



        }

        private void altoButton1_Click(object sender, EventArgs e)
        {
            //  altoButton1.Enabled = false;

            myBGWorker.RunWorkerAsync();


        }

        private void area_OnSelectedIndexChanged(object sender, EventArgs e)
        {







        }

        private void pieChart2_DataClick(object sender, ChartPoint chartPoint)
        {







            string dato = chartPoint.SeriesView.Title;


            if (dato == "Alto rendimiento")
            {
                Form nv = new Form();
                using (DETALLES_SUPREVISION_PERSONAL mn = new DETALLES_SUPREVISION_PERSONAL())  //ABRE FORMULARIO
                {
                    nv.StartPosition = FormStartPosition.Manual;
                    nv.FormBorderStyle = FormBorderStyle.None;
                    nv.Opacity = .70d;
                    nv.BackColor = Color.Black;
                    nv.WindowState = FormWindowState.Maximized;
                    nv.TopMost = false;
                    nv.Location = this.Location;
                    nv.ShowInTaskbar = false;
                    nv.Show();
                    mn.Owner = nv;
                    mn.Opacity = 0;

                    mn.semestre_primero = false;
                    mn.rango1 = 80;
                    mn.rango2 = 100;

                    mn.semestre = Año.Texts + "-06-01";
                    mn.filtro = area.Texts;
                    mn.no_realizado = false;


                    mn.ShowDialog();

                    nv.Dispose();
                }



            }
            else if (dato == "Rendimiento Regular")
            {
                Form nv = new Form();
                using (DETALLES_SUPREVISION_PERSONAL mn = new DETALLES_SUPREVISION_PERSONAL())  //ABRE FORMULARIO
                {
                    nv.StartPosition = FormStartPosition.Manual;
                    nv.FormBorderStyle = FormBorderStyle.None;
                    nv.Opacity = .70d;
                    nv.BackColor = Color.Black;
                    nv.WindowState = FormWindowState.Maximized;
                    nv.TopMost = false;
                    nv.Location = this.Location;
                    nv.ShowInTaskbar = false;
                    nv.Show();
                    mn.Owner = nv;
                    mn.Opacity = 0;

                    mn.semestre_primero = false;
                    mn.rango1 = 60;
                    mn.rango2 = 80;

                    mn.semestre = Año.Texts + "-06-01";
                    mn.filtro = area.Texts;
                    mn.no_realizado = false;


                    mn.ShowDialog();

                    nv.Dispose();
                }

            }
            else if (dato == "Rendimiento Insuficiente")
            {
                Form nv = new Form();
                using (DETALLES_SUPREVISION_PERSONAL mn = new DETALLES_SUPREVISION_PERSONAL())  //ABRE FORMULARIO
                {
                    nv.StartPosition = FormStartPosition.Manual;
                    nv.FormBorderStyle = FormBorderStyle.None;
                    nv.Opacity = .70d;
                    nv.BackColor = Color.Black;
                    nv.WindowState = FormWindowState.Maximized;   //ESTILOS APLICABLES A ELEMENTOS 
                    nv.TopMost = false;
                    nv.Location = this.Location;
                    nv.ShowInTaskbar = false;
                    nv.Show();
                    mn.Owner = nv;
                    mn.Opacity = 0;

                    mn.semestre_primero = false;
                    mn.rango1 = 40;
                    mn.rango2 = 60;
                    mn.semestre = Año.Texts + "-06-01";
                    mn.filtro = area.Texts;
                    mn.no_realizado = false;


                    mn.ShowDialog();

                    nv.Dispose();
                }
            }
            else if (dato == "Bajo Rendimiento")
            {
                Form nv = new Form();
                using (DETALLES_SUPREVISION_PERSONAL mn = new DETALLES_SUPREVISION_PERSONAL())  //ABRE FORMULARIO
                {
                    nv.StartPosition = FormStartPosition.Manual;
                    nv.FormBorderStyle = FormBorderStyle.None;
                    nv.Opacity = .70d;
                    nv.BackColor = Color.Black;
                    nv.WindowState = FormWindowState.Maximized;   //ESTILOS APLICABLES A ELEMENTOS 
                    nv.TopMost = false;
                    nv.Location = this.Location;
                    nv.ShowInTaskbar = false;
                    nv.Show();
                    mn.Owner = nv;
                    mn.Opacity = 0;

                    mn.semestre_primero = false;
                    mn.rango1 = 0;
                    mn.rango2 = 40;

                    mn.semestre = Año.Texts + "-06-01";
                    mn.filtro = area.Texts;
                    mn.no_realizado = false;


                    mn.ShowDialog();

                    nv.Dispose();
                }
            }
            else if (dato == "No realizadas")
            {
                Form nv = new Form();
                using (DETALLES_SUPREVISION_PERSONAL mn = new DETALLES_SUPREVISION_PERSONAL())  //ABRE FORMULARIO
                {
                    nv.StartPosition = FormStartPosition.Manual;
                    nv.FormBorderStyle = FormBorderStyle.None;
                    nv.Opacity = .70d;
                    nv.BackColor = Color.Black;
                    nv.WindowState = FormWindowState.Maximized;   //ESTILOS APLICABLES A ELEMENTOS 
                    nv.TopMost = false;
                    nv.Location = this.Location;
                    nv.ShowInTaskbar = false;
                    nv.Show();
                    mn.Owner = nv;
                    mn.Opacity = 0;

                    mn.semestre_primero = false;
                    mn.rango1 = 0;
                    mn.rango2 = 0;

                    mn.semestre = Año.Texts + "-06-01";
                    mn.filtro = area.Texts;
                    mn.no_realizado = true;


                    mn.ShowDialog();

                    nv.Dispose();
                }
            }






        }

        private void pieChart2_ChildChanged(object sender, System.Windows.Forms.Integration.ChildChangedEventArgs e)
        {

        }

        private void myBGWorker_DoWork(object sender, DoWorkEventArgs e)  //VISUALIZACION DE PANTALLA CARGANDO 
        {
            int percentage = 0;
            percentage = percentage + 20;
            myBGWorker.ReportProgress(percentage);

            System.Threading.Thread.Sleep(1500);

            Invoke(new MethodInvoker(() =>
            {

                primer_semest();
                ss1.Visible = true;
            }));

            System.Threading.Thread.Sleep(3000);
            percentage = percentage + 30;
            myBGWorker.ReportProgress(percentage);

            Invoke(new MethodInvoker(() =>
            {


                segundo_semest();
                ss2.Visible = true;

            }));

            System.Threading.Thread.Sleep(1500);
            percentage = percentage + 50;
            myBGWorker.ReportProgress(percentage);



        }

        private void myBGWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            myProgressBar.Value = e.ProgressPercentage;
        }

        private void myBGWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            myProgressBar.Value = 0;

            MENSAJE_GENERAL MN = new MENSAJE_GENERAL();
            MN.BOTON.Text = "¡Búsqueda Completa!";
            MN.ShowDialog();


        }


        private void refrescar_form()
        {
            MENU_PRICIPAL_ERP.cortaps.REINICIA_ANALISIS_EVALUACION();
        }


        private void REFRESH_Click(object sender, EventArgs e)
        {
            refrescar_form();
        }


    }
}
