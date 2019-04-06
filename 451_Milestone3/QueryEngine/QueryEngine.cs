using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Npgsql;
using Npgsql.Schema;

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

        public List<string> ExecuteListQuery(string query)
        {
            List<string> strings = new List<string>();

            using (var connection = new NpgsqlConnection(LOGININFO))
            {
                connection.Open();
                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = connection;
                    cmd.CommandText = query;
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

        /// <summary>
        /// interact with database to query the list of states contained within.  
        /// </summary>
        /// <returns>
        /// A list of strings containing all the states in the database
        /// </returns>
        // update states dropdown menu with the list of distinct states
        // 'using' keyword to auto call dispose when we are done.
        public List<string> GetStates()
        {
            return ExecuteListQuery("SELECT distinct state FROM business ORDER BY state;");
        }

        public List<string> GetCities()
        {
            return ExecuteListQuery("SELECT distinct city FROM business WHERE business.state = '" + searchParameters["state"][0] + "' ORDER BY city;");
        }

        public List<string> GetNewZips(string city)
        {
            return ExecuteListQuery("SELECT DISTINCT zipcode FROM business WHERE state = '" + searchParameters["state"][0] + "' AND city = '" + city + "' ORDER BY zipcode;");
        }

        public List<string> GetCategories()
        {
            string cmd = "SELECT DISTINCT category_name FROM category WHERE business_id IN (SELECT business_id FROM business WHERE state = '" + searchParameters["state"][0] + "')";

            cmd += " AND business_id IN (SELECT business_id FROM business WHERE "; //building subquery to find all the cities in the listbox
            foreach (string zipcode in searchParameters["zipcode"])
            {                
                cmd += "zipcode = '" + zipcode + "' OR "; // city = 'string' OR 
            }
            cmd = cmd.Substring(0, cmd.Length - 3); // Cuts off the final "OR "
            cmd += ")";

            cmd += " ORDER BY category_name;";

            return ExecuteListQuery(cmd);
        }

        public List<List<string>> Search(string projection = "*")
        {
            return Search(searchParameters, projection);
        }

        /// <summary>
        /// Runs a query to return the results based on the current search parameters as a 2 dimensional array of strings
        /// If there are no search parameters, returns an empty string array.
        /// </summary>
        private List<List<string>> Search(Dictionary<string, List<string>> searchParams, string projection)
        {
            if (searchParams.Count != 0)
            {
                int currIndex = 0; //keeps track of what key we are looking at from the dictionary
                string CommandText; // the final Query that will be run
                string orList = ""; //building subquery to find all the cities in the listbox

                List<string> t = new List<string>();

                foreach (KeyValuePair<string, List<string>> key in searchParams)
                    t.Add(searchParams.Keys.ElementAt(currIndex++));

                currIndex = 0;
                //iterate through all the Keys and values and build all the necesary subqueries
                foreach (KeyValuePair<string, List<string>> key in searchParams) //each keyValuePar
                {
                    // Build the subquery to find all tuples with the value from that keyPair
                    if (key.Key == "category_name")
                        orList += " business_id IN ( SELECT business_id FROM category WHERE ";
                    else
                        if (searchParams.Keys.Last() != searchParams.Keys.ElementAt(currIndex)) //if this key is not the last one in the Dictionary, add the start of the next subquery
                            orList += key.Key + " IN ( SELECT " + key.Key + " FROM business WHERE "; // ") AND <nextKey> IN ( SELECT  FROM business WHERE " (also increments the currIndex)

                    foreach (string item in key.Value) //Each item in the list for each key
                    {                        
                        orList += key.Key + " = '" + item + "' OR "; // "<key> = '<each item in the list with that key>' OR "
                    }

                    orList = orList.Substring(0, orList.Length - 3); // Cuts off the final "OR "orList       
                    orList += ") AND ";
                }

                orList = orList.Substring(0, orList.Length - 4); // Cuts off the last ") AND "

                CommandText = "SELECT " + projection + " FROM business WHERE " + orList + " ORDER BY state;";                
                return ExecuteCategorizedQuery(CommandText);
            }
            return new List<List<string>>(); //return empty array because there are no search parameters.
        }

        /// <summary>
        /// Executes the query on the database and returns the results as a 2 dimensional list of Businesses   
        /// the first row of the first list will contain the column names.
        /// </summary>
        private List<List<string>> ExecuteCategorizedQuery(string query)
        {
            List<List<string>> returnList = new List<List<string>>();
            List<string> header = new List<string>();
            ReadOnlyCollection<NpgsqlDbColumn> columns = new ReadOnlyCollection<NpgsqlDbColumn>(new List<NpgsqlDbColumn>());

            using (var connection = new NpgsqlConnection(LOGININFO))
            {
                connection.Open();
                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = connection;
                    cmd.CommandText = query;
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (columns.Count == 0)
                                columns = reader.GetColumnSchema();

                            List<string> row = new List<string>();

                            foreach (NpgsqlDbColumn column in columns)
                            {
                                row.Add(reader[column.ColumnName].ToString());
                            }
                            returnList.Add(row);
                        }
                    }
                }
                connection.Close();
            }

            foreach (NpgsqlDbColumn column in columns)
                header.Add(column.ColumnName);

            returnList.Insert(0, header);

            return returnList;
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
        /// sets a search parameter to contain only one value 
        /// </summary>
        public void resetSearchParameter(string key, string value)
        {
            searchParameters = new Dictionary<string, List<string>>();

            List<string> newList = new List<string>(); //insert new key-value pair with the single value.
            newList.Add(value);
            searchParameters.Add(key, newList);
        }

        private void YelpPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            yelpDataChanged?.Invoke(sender, e);
        }
    }
}
