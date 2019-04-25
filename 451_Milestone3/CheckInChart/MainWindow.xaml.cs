using System.Windows;
using QueryEngine1;

namespace CheckInChart
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        QueryEngine queryEngine;
        public MainWindow(string busId)
        {
            queryEngine = new QueryEngine();
            InitializeComponent();
            columnChart(busId);
        }

        private void columnChart(string busId = "")
        {
            if (busId.Length != 22) //make sure that there is a business ID to query
                MessageBox.Show("No business selected!!!!");
            else
                myChart.DataContext = queryEngine.QueryCheckinsGraph(busId);
        }
    }

}
