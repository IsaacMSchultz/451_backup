using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milestone2App
{
    class MapNamesToAttrValPair
    {
        Dictionary<string, string[]> name = new Dictionary<string, string[]>();

        public MapNamesToAttrValPair()
        {
            name["Accepts Credit Cards"] = new string[] { "BusinessAcceptsCreditCards", "True" };
            name["Takes Reservations"] = new string[] { "RestaurantsReservations", "True" };
            name["Wheelchair Accessible"] = new string[] { "WheelchairAccessible", "True" };
            name["Outdoor Seating"] = new string[] { "OutdoorSeating", "True" };
            name["Good for Kids"] = new string[] { "GoodForKids", "True" };
            name["Good for Groups"] = new string[] { "RestaurantsGoodForGroups", "True" };
            name["Delivery"] = new string[] { "RestaurantsDelivery", "True" };
            name["Take Out"] = new string[] { "RestaurantsTakeOut", "True" };
            name["Free Wi-Fi"] = new string[] { "WiFi", "free" };
            name["Bike Parking"] = new string[] { "BikeParking", "True" };
            name["Breakfast"] = new string[] { "breakfast", "True" };
            name["Brunch"] = new string[] { "brunch", "True" };
            name["Lunch"] = new string[] { "lunch", "True" }; //This one is not in the data
            name["Dinner"] = new string[] { "dinner", "True" };
            name["Dessert"] = new string[] { "dessert", "True" };
            name["Late Night"] = new string[] { "latenight", "True" };
            name["$"] = new string[] { "RestaurantsPriceRange2", "1" };
            name["$$"] = new string[] { "RestaurantsPriceRange2", "2" };
            name["$$$"] = new string[] { "RestaurantsPriceRange2", "3" };
            name["$$$$"] = new string[] { "RestaurantsPriceRange2", "4" };
        }

        public Tuple<string, string> MapFrom(string key)
        {
            if (name.ContainsKey(key))
            {
                string[] combo = name[key];
                return new Tuple<string, string>(combo[0], combo[1]);
            }
            return new Tuple<string, string>("N/A", "N/A");
        }
    }
}
