using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueryEngine
{
    class Location
    {
        private double latitude;
        private double longitude;
        private string city;
        private string state;
        private string address;
        private string zipcode;

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
