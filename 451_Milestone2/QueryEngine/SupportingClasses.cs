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

        public void compareDistance(Location secondLocation) // gets the distance between two locations???
        {

        }
    }

    public class Checkin
    {
        private string business_Id;
        private string day; // may need to select a different data type
        private string time; // ^
        private int count;
    }
}
