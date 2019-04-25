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
using Microsoft.Maps.MapControl.WPF;

namespace MapControlLibrary
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class UserControl1 : UserControl
    {
        //public Map map = new Map();

        // Will work on map functionalities later
        // Was having a hard time accessing the instance
        // that the displayed map is a part of
        public UserControl1()
        {
            InitializeComponent();
            this.map.Focus();
            // Defaults to snohomish now
            //Location temp = new Location(47.912876, -122.098183);
            //map.SetView(temp, 10);
            ////Push
                
                
            //    pin = new Pushpin();
            //pin.Location = temp;
            //map.Children.Add(pin);
        }
        
        // Method to add a business to the map later on
        public void addBusiness(double lat, double lon)
        {
            Location temp = new Location(47.912876, -122.098183);
            map.SetView(temp, 10);
            Pushpin pin = new Pushpin();
            pin.Location = temp;
            map.Children.Add(pin);
        }
    }
}
