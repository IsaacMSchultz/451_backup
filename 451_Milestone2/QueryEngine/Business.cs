using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace QueryEngine
{
    class Business
    {
        private string name;
        private string businessId;
        private Location businessLocation;        
        private int fans;
        private int reviewCount;
        private double avgStars;
        // Add a list of attributes/ hours?
        List<Attribute> businessAttributes;
        List<Hours> businessHours;

        public event PropertyChangedEventHandler BusinessPropertyChanged; // event for notifying that there was a property changed. 

        private void OnBusinessPropertyChanged(object sender, PropertyChangedEventArgs e) // event handler for a change in business data.
        {
            // how to handle this in the QueryEngine class
        }
    }

    class Attribute
    {
        private string name;
        private string value;

        public Attribute(string newName, string newValue)
        {
            this.name = newName;
            this.value = newValue;
        }
}

    class Hours
    {
        public Hours(string newDay, string newOpenTime, string newCloseTime)
        {
            this.day = newDay;
            this.openTime = newOpenTime;
            this.closeTime = newCloseTime;
        }
        private string day { get; set; }
        private string closeTime { get; set; }
        private string openTime { get; set; }
    }
}
