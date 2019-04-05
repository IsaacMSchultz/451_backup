using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace QueryEngine1
{
    public class Business
    {
        private string name;
        private string businessId;
        private Location businessLocation;        
        private int reviewCount;
        private double avgStars;
        // Add a list of attributes/ hours?
        private List<Attribute> businessAttributes;
        private List<Hours> businessHours;

        public event PropertyChangedEventHandler BusinessPropertyChanged; // event for notifying that there was a property changed. 

        public Business(string name, string businessId, Location businessLocation, int reviewCount, double avgStars)
        {
            this.name = name;
            this.businessId = businessId;
            this.businessLocation = businessLocation;        
            this.reviewCount = reviewCount;
            this.avgStars = avgStars;
        }

        private void OnBusinessPropertyChanged(object sender, PropertyChangedEventArgs e) // event handler for a change in business data.
        {
            // how to handle this in the QueryEngine class
        }
    }

    class Attribute
    {
        private string name;
        private string value;

        public string Name { get { return name; } }
        public string Value { get { return value; } }

        public Attribute(string newName, string newValue)
        {
            this.name = newName;
            this.value = newValue;
        }
}

    class Hours
    {
        private string day;
        private string closeTime;
        private string openTime;

        public string Day { get { return day; } }
        public string CloseTime { get { return closeTime; } }
        public string OpenTime { get { return openTime; } }

        public Hours(string newDay, string newOpenTime, string newCloseTime)
        {
            this.day = newDay;
            this.openTime = newOpenTime;
            this.closeTime = newCloseTime;
        }

    }
}
