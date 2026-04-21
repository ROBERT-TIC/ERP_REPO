using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;
using System.Windows;

namespace ERP_LIEC
{
    class conexion_cobranza
    {

        public static MySqlConnection USR = new MySqlConnection("server=192.168.1.173; database=cobranza; uid=root; pwd=123; Convert Zero Datetime=True;");


        public static void registrar(string Q)
        {

            MySqlCommand traduce = new MySqlCommand(Q, USR);

            try
            {
                USR.Open();
                traduce.ExecuteNonQuery();
                USR.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);

            }
            finally
            {
                USR.Close();


            }

        }

        public static DataTable Consultageneral(string Q)
        {

            MySqlDataAdapter DA = new MySqlDataAdapter(Q, USR);
            DataTable TB = new DataTable();
            try
            {
                USR.Open();
                DA.Fill(TB);
                USR.Close();
            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message);
            }
            finally
            {
                USR.Close();

            }
            return TB;


        }

      
    }
}
