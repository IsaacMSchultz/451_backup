using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Npgsql;

namespace QueryEngine1
{
    /// <summary>
    /// 
    /// </summary>
    public class QueryEngine 
    {
        private Dictionary<string, List<string>> searchParameters;
        public event PropertyChangedEventHandler yelpDataChanged; // event for notifying that there was a property changed. 
        //private static string LOGININFO = "Host=35.230.13.126; Username=postgres; Password=oiAv4Kmdup8Pd4vd; Database=milestone2db";
        private static string LOGININFO = "Host=localhost; Username=postgres; Password=greatPassword; Database=milestone2db";

        public QueryEngine()
        {
            searchParameters = new Dictionary<string, List<string>>();
        }

        private void DataChanged(object sender, PropertyChangedEventArgs e) // Event handler for when user data changes.
        {
            // good model of how we will be implementing this class
            if (sender is Review reviewChanged)
            {
                if (e.PropertyName == "newReview")
                {
                    // run an INSERT if the reviewId is not in the database
                }

                // "UPDATE review WHERE review.reviewId = " AND reviewChanged.reviewId AND " 
            }
            YelpPropertyChanged(sender, e);
        }

        /// <summary>
        /// interact with database to query the list of states contained within.  
        /// </summary>
        /// <returns>
        /// A list of strings containing all the states in the database
        /// </returns>
        // update states dropdown menu with the list of distinct states
        // 'using' keyword to auto call dispose when we are done.
        public List<string> getStates()
        {
            List<string> returnList = new List<string>();
            using (var connection = new NpgsqlConnection(LOGININFO))
            {
                connection.Open();               
                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = connection;
                    cmd.CommandText = "SELECT distinct state FROM business ORDER BY state;";
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                            returnList.Add(reader.GetString(0));
                    }
                }
                connection.Close();
            }
            return returnList;
        }

        public object Search(string parameters = "")
        {
            if (parameters == "city")
            {
                var cities = new Dictionary<string, List<string>>();
                cities.Add("state", searchParameters["state"]); //get only the cities from the search parameters
                return Search(cities);
            }
            else //nothing specified, search for businesses to update grid.
                return Search(searchParameters);
        }

        /// <summary>
        /// Runs a query to return the results based on the current search parameters as a 2 dimensional array of strings
        /// If there are no search parameters, returns an empty string array.
        /// </summary>
        private object Search(Dictionary<string, List<string>> searchParams, string projection = "")
        {
            if (searchParams.Count != 0)
            {
                int currIndex = 0; //keeps track of what key we are looking at from the dictionary
                string CommandText; // the final Query that will be run
                string orList = ""; //building subquery to find all the cities in the listbox

                //iterate through all the Keys and values and build all the necesary subqueries
                foreach (KeyValuePair<string, List<string>> key in searchParams) //each keyValuePar
                {
                    // Build the subquery to find all tuples with the value from that keyPair
                    if (searchParams.Keys.Last() != searchParams.Keys.ElementAt(currIndex)) //if this key is not the last one in the Dictionary, add the start of the next subquery
                        orList += ") AND " + searchParams.Keys.ElementAt(++currIndex) + " IN ( SELECT  FROM business WHERE "; // ") AND <nextKey> IN ( SELECT  FROM business WHERE " (also increments the currIndex)

                    foreach (string item in key.Value) //Each item in the list for each key
                    {
                        Console.WriteLine(item);
                        orList += key.Key + " = '" + item + "' OR "; // "<key> = '<each item in the list with that key>' OR "
                    }

                    orList = orList.Substring(0, orList.Length - 3); // Cuts off the final "OR "
                }

                orList = orList.Substring(6, orList.Length); // Cuts off the first ") AND "

                CommandText = "SELECT * FROM business WHERE " + orList + " ORDER BY state;";
                Console.WriteLine(CommandText);
                return ExecuteListQuery(CommandText);
            }
            return new List<Business>(); //return empty array because there are no search parameters.
        }

        /// <summary>
        /// Adds a value to the search parameters  
        /// </summary>
        public void addSearchParameter(string key, string value)
        {
            if (searchParameters.ContainsKey(key))
                searchParameters[key].Add(value);
            else
            {
                List<string> newList = new List<string>();
                newList.Add(value);
                searchParameters.Add(key, newList);
            }
        }

        /// <summary>
        /// Removes a value from the search parameters    
        /// </summary>
        public void removeSearchParameter(string key, string value)
        {
            searchParameters[key].Remove(value);
            if (searchParameters[key].Count == 0) // if that was the last value in that keyValue pair, remove the key
                searchParameters.Remove(key);
        }

        /// <summary>
        /// Executes the query on the database and returns the results as a 2 dimensional list of Businesses   
        /// </summary>
        private List<Business> ExecuteBusinessQuery(string query){

            List<Business> businesses = new List<Business>();
            
            using (var connection = new NpgsqlConnection(LOGININFO))
            {
                connection.Open();
                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = connection;
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                            businesses.Add(new Business((string) reader["name"], (string) reader["business_id"], new Location((double) reader["latitude"],
                                (double) reader["longitude"], (string) reader["city"], (string) reader["state"], (string) reader["address"], 
                                (string) reader["zipcode"]), (int) reader["review_count"], (double) reader["stars"]));
                    }
                }
                connection.Close();
            }
            return businesses;
        }

        public List<string> ExecuteListQuery(string query)
        {
            List<string> strings = new List<string>();

            using (var connection = new NpgsqlConnection(LOGININFO))
            {
                connection.Open();
                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = connection;
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                            strings.Add(reader.GetString(0));
                    }
                }
                connection.Close();
            }
            return strings;
        }

        private void YelpPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            yelpDataChanged?.Invoke(sender, e);
        }
    }
}
