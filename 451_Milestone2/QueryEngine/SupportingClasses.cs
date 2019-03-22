using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueryEngine1
{
    public class Location
    {
        private double latitude;
        private double longitude;
        private string city;
        private string state;
        private string address;
        private string zipcode;

        public Location(double latitude, double longitude, string city, string state, string address, string zipcode)
        {
            this.latitude = latitude;
            this.longitude = longitude;
            this.city = city;
            this.state = state;
            this.address = address;
            this.zipcode = zipcode;
        }

        public Location(double latitude, double longitude)
        {
            this.latitude = latitude;
            this.longitude = longitude;
        }

        public int compareDistance(Location secondLocation) // gets the distance between two locations???
        {
            return 0;
        }
    }

    public class Checkin
    {
        private string businessId;
        private string day; // may need to select a different data type
        private string time; // ^
        private int count;
    }
}
