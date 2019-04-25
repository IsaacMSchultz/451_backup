using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace CheckInChart
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            //assuming args[0] is a string here.  Dangerous for real code.
            String busID = e.Args.Length > 0 ? e.Args[0] : "--ab39IjZR_xUf81WyTyHg";
            MainWindow wnd = new MainWindow(busID);
            wnd.Show();
        }
    }
}
