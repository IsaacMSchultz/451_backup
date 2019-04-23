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

namespace WpfApp12
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            columnChart();
        }
        private void columnChart()
        {
            List<KeyValuePair<String, int>> myChartData = new List<KeyValuePair<string, int>>();
            /*using (var conn = new NpgsqlConnection("Host = localhost; Username = postgres; Password = Xsandy9189; Database = milestone2db"))
            {
                conn.Open();
                using (var cmd = new Npgsqlcommand())
                {
                    cmd.Connection = conn;
                    // Business ID needs to be specificly stated. Do we need to add an input for the button on the interface
                    cmd.CommandText = "Select num_checkins, count(business_id) from business where Business_id = 'Tempe' group by num_checkins order by num_checkins;";
                    using (var reader = cmd.ExecuteReader())
                    {
                        while(reader.Read())
                        {
                            myChartData.Add(new KeyValuePair<string, int>(reader.GetString(0), reader.GetInt32(1)));

                        }
                    }
                }
            }*/
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
