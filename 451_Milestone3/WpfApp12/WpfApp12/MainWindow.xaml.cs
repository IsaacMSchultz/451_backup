using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Npgsql;

namespace WpfApp12
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(string busId)
        {
            InitializeComponent();
            columnChart(busId);
        }
        private void columnChart(string busId = "--ab39IjZR_xUf81WyTyHg")
        {
            List<KeyValuePair<String, int>> myChartData = new List<KeyValuePair<string, int>>();

            //Select business_id, SUM(num_checkins) from business Where business_id = '--ab39IjZR_xUf81WyTyHg' group by business_id order by business_id;
            using (var conn = new NpgsqlConnection("Host = localhost; Username = postgres; Password = Xsandy9189; Database = milestone2db"))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conn;
                    // Business ID needs to be specificly stated. Do we need to add an input for the button on the interface
                    cmd.CommandText = "SELECT checkins.day, COUNT(checkins.day)FROM business JOIN checkins ON business.business_id = checkins.business_id WHERE business.business_id =@busId GROUP BY checkins.day ORDER BY CASE WHEN checkins.day = 'Monday' THEN '1' WHEN checkins.day = 'Tuesday' THEN '2' WHEN checkins.day = 'Wednesday' THEN '3' WHEN checkins.day = 'Thursday' THEN '4' WHEN checkins.day = 'Friday' THEN '5' WHEN checkins.day = 'Saturday' THEN '6' WHEN checkins.day = 'Sunday' THEN '7'ELSE checkins.day END ASC";
                    cmd.Parameters.AddWithValue("@busId", busId);
                    //cmd.CommandText = "SELECT checkins.day, COUNT(checkins.day) FROM business JOIN checkins ON business.business_id = checkins.business_id WHERE business.business_id = '--ab39IjZR_xUf81WyTyHg' GROUP BY checkins.day ORDER BY CASE WHEN checkins.day = 'Monday' THEN '1' WHEN checkins.day = 'Tuesday' THEN '2' WHEN checkins.day = 'Wednesday' THEN '3' WHEN checkins.day = 'Thursday' THEN '4' WHEN checkins.day = 'Friday' THEN '5' WHEN checkins.day = 'Saturday' THEN '6' WHEN checkins.day = 'Sunday' THEN '7'ELSE checkins.day END ASC";
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            myChartData.Add(new KeyValuePair<string, int>(reader.GetString(0), reader.GetInt32(1)));

                        }
                    }
                }
                //}
                /*myChartData.Add(new KeyValuePair<string, int>("Sun", 10));
                myChartData.Add(new KeyValuePair<string, int>("Mon", 20));
                myChartData.Add(new KeyValuePair<string, int>("Tue", 30));
                myChartData.Add(new KeyValuePair<string, int>("Wed", 40));
                myChartData.Add(new KeyValuePair<string, int>("Thurs", 50));
                myChartData.Add(new KeyValuePair<string, int>("Fri", 60));
                myChartData.Add(new KeyValuePair<string, int>("Sat", 90));*/


                myChart.DataContext = myChartData;


            }
        }
    }
}
