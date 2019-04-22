﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Npgsql;
using Npgsql.Schema;
using System.Text.RegularExpressions;

namespace QueryEngine1
{
    /// <summary>
    /// 
    /// </summary>
    public class QueryEngine
    {
        private Dictionary<string, List<string>> searchParameters;
        List<List<string>> lastQuery;
        string currBusId;
        string currUserId;

        private static Random random = new Random();
        const string chars = "abcdefghijklmnopqrstuvwyxzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789_- ";

        public event PropertyChangedEventHandler yelpDataChanged; // event for notifying that there was a property changed. 
        //private static string LOGININFO = "Host=35.230.13.126; Username=postgres; Password=oiAv4Kmdup8Pd4vd; Database=milestone3db";
        private static string LOGININFO = "Host=localhost; Username=postgres; Password=greatPassword; Database=milestone2db";

        public QueryEngine()
        {
            searchParameters = new Dictionary<string, List<string>>();
            lastQuery = new List<List<string>>();
            currBusId = "";
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

        //TODO: make a single GET function that takes the parameter we are looking for instead of many for each.

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

        public List<string> GetCategories(string id = "N/A")
        {
            if (id.Length < 4) // If the call was not passed with a valid id
            {
                if (searchParameters.ContainsKey("zipcode"))
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
                else
                {
                    return new List<string>();
                }
            }
            else
            {
                //string q = "SELECT DISTINCT category_name FROM category WHERE business_id = '" + id + "';";
                return ExecuteListQuery("SELECT DISTINCT category_name FROM category WHERE business_id = '" + id + "';");
            }            
        }

        public List<List<string>> GetAttributes(string id = "N/A")
        {
            //if (id.Length < 4) // If the call was not passed with a valid id
            //{
            //    if (searchParameters.ContainsKey("attributes"))
            //    {
            //        string cmd = "SELECT DISTINCT attribute_name FROM attributes WHERE business_id IN (SELECT business_id FROM business WHERE state = '" + searchParameters["state"][0] + "')";

            //        cmd += " AND business_id IN (SELECT business_id FROM business WHERE "; //building subquery to find all the cities in the listbox
            //        foreach (string zipcode in searchParameters["zipcode"])
            //        {
            //            cmd += "zipcode = '" + zipcode + "' OR "; // city = 'string' OR 
            //        }
            //        cmd = cmd.Substring(0, cmd.Length - 3); // Cuts off the final "OR "
            //        cmd += ")";

            //        cmd += " ORDER BY category_name;";

            //        return ExecuteListQuery(cmd);
            //    }
            //    else
            //    {
            //        return new List<string>();
            //    }
            //}
            //else
            //{
                //string q = "SELECT DISTINCT attribute_name, attribute_value FROM attributes WHERE business_id = '" + id + "';";
                return ExecuteCategorizedQuery("SELECT DISTINCT attribute_name, attribute_value FROM attributes WHERE business_id = '" + id + "';");
            //}
        }

        public List<List<string>> Search(string projection = "*")
        {
            if (projection.Contains(", distance")) //assuming distance will always be at the end. Can change this later.
            {
                if (currUserId != null)
                {
                    //Regex reg = new Regex(@"(?:\w+\,)");                    
                    projection = "business." + projection; //add business. to the first column of the projection
                    projection = projection.Replace(", ", ", business.");
                    projection = projection.Replace("business.distance", "distance(business.latitude, business.longitude, yelpuser.user_latitude, yelpuser.user_longitude)");
                    return Search(searchParameters, projection, "yelpuser, business", " AND yelpuser.user_id = '" + currUserId + "' ");
                }
                else
                {
                    projection = projection.Replace(", distance", "");
                }
            }
            return Search(searchParameters, projection, "business");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="projection"></param>
        /// <returns></returns>
        public List<string> GetUsers(string name, string projection = "user_id")
        {
            List<string> returnList = new List<string>();
            if (name == string.Empty)
                return returnList;

            returnList = ExecuteListQuery("SELECT distinct " + projection + " FROM yelpuser WHERE yelpuser.name like '%" + name + "%' ORDER BY user_id;");

            return returnList;
        }

        public List<List<string>> GetUser(string id, string projection = "*")
        {
            return ExecuteCategorizedQuery("SELECT " + projection + " from yelpuser WHERE yelpuser.user_id = '" + id + "';");
        }

        public List<List<string>> GetReviews(string id, string projection = "*")
        {
            return ExecuteCategorizedQuery("SELECT " + projection + " from review WHERE business_id = '" + id + "' ORDER BY review_stars;");
        }

        public List<List<string>> GetCheckins(string id, string projection = "*")
        {
            return ExecuteCategorizedQuery("SELECT " + projection + " from checkins WHERE business_id = '" + id + "' ORDER BY day;");
        }

        public List<List<string>> GetHoursForDay(string id, string day)
        {
            string projection = "to_char(open, 'HH12:MI AM') as openTime, to_char(close, 'HH12:MI AM') as closeTime";
            string q = "SELECT " + projection + " FROM hours WHERE business_id = '" + id + "' AND day = '" + day + "';";
            return ExecuteCategorizedQuery("SELECT " + projection + " FROM hours WHERE business_id = '" + id + "' AND day = '" + day + "';");
        }

        /// <summary>
        /// Runs a query to return the results based on the current search parameters as a 2 dimensional array of strings
        /// If there are no search parameters, returns an empty string array.
        /// </summary>
        private List<List<string>> Search(Dictionary<string, List<string>> searchParams, string projection, string tables, string endQuery = "")
        {
            if (searchParams.Count != 0)
            {
                int currIndex = 0; //keeps track of what key we are looking at from the dictionary                
                string orList = ""; //building subquery to find all the cities in the listbox

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
                        orList += key.Key + " = '" + item + "' OR "; // "<key> = '<each item in the list with that key>' OR "                    

                    orList = orList.Substring(0, orList.Length - 3); // Cuts off the final "OR "orList       
                    orList += ") AND ";
                }

                if (searchParams.Count == 1)
                    orList = orList.Substring(0, orList.Length - 6); // if there is just one parameter, we wont need parenthesis or and AND.
                else
                    orList = orList.Substring(0, orList.Length - 4); // Cuts off the last ") AND "

                lastQuery = ExecuteCategorizedQuery("SELECT " + projection + " FROM " + tables + " WHERE " + orList + endQuery + " ORDER BY state;");
                return lastQuery;
            }
            lastQuery = new List<List<string>>();
            return lastQuery; //return empty array because there are no search parameters.
        }

        /// <summary>
        /// Executes the query on the database and returns the results as a 2 dimensional list of Businesses   
        /// the first row of the first list will contain the column names.
        /// </summary>
        private List<List<string>> ExecuteCategorizedQuery(string query)
        {
            List<List<string>> returnList = new List<List<string>>();
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
                                row.Add(reader[column.ColumnName].ToString());

                            returnList.Add(row);
                        }
                    }
                }
                connection.Close();
            }

            // Returns the list of column names as the first row.
            List<string> header = new List<string>();
            foreach (NpgsqlDbColumn column in columns)
                header.Add(column.ColumnName);
            returnList.Insert(0, header);

            lastQuery = returnList;
            return returnList;
        }

        public List<string> ExecuteListQuery(string query)
        {
            List<string> strings = new List<string>();

            using (var connection = new NpgsqlConnection(LOGININFO))
            {
                connection.Open();
                using (var cmd = new NpgsqlCommand())
                {
                    if (query == @"SELECT to_char(open, 'HH12:MI AM'), to_char(close, 'HH12:MI AM'), day FROM hours WHERE business_id = 'xmY0pzNvZKEzuN0XEqeV5w' AND day = 'Saturday';")
                        Console.WriteLine("TEST");
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
            if (searchParameters.ContainsKey(key) && searchParameters[key].Contains(value)) // can only remove something if its actually there.
            {
                searchParameters[key].Remove(value);
                if (searchParameters[key].Count == 0) // if that was the last value in that keyValue pair, remove the key
                    searchParameters.Remove(key);
            }
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

        // way for the queryengine to know what business a user has selected based off the rows.
        // THIS WONT WORK ALL THE TIME BECAUSE THE USERS CAN SORT THE LIST OF BUSINESSES BASED ON NAME, STARS, ETC
        private void SelectBusiness(int row)
        {
            if (lastQuery[0].Contains("business_id"))
                currBusId = lastQuery[row + 1][lastQuery[0].IndexOf("business_id")];
        }

        public void SelectUser(string userId)
        {
            currUserId = userId;
        }


        public bool PostReview(string reviewText, int reviewStars, string busID, string UserID)
        {
            int rows = 0;
            string reviewID = new string(Enumerable.Repeat(chars, 22).Select(s => s[random.Next(s.Length)]).ToArray()); //makes a random 22 charachter string
            using (var connection = new NpgsqlConnection(LOGININFO))
            {
                connection.Open();
                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = connection;
                    cmd.CommandText = "INSERT INTO review VALUES ('" + reviewID + "', '" + busID + "', '" + UserID + "', '" + reviewStars +
                        "', NOW(), '" + reviewText + "', 0, 0, 0);";
                    rows = cmd.ExecuteNonQuery();
                }
                connection.Close();
            }
            if (rows > 0)
                return true;
            return false;
        }

        // Should only return 2 values in the list, latitude and longitude
        public List<double> GetUserLocation(string userId)
        {
            List<double> returnValue = new List<double>();

            ReadOnlyCollection<NpgsqlDbColumn> columns = new ReadOnlyCollection<NpgsqlDbColumn>(new List<NpgsqlDbColumn>());

            using (var connection = new NpgsqlConnection(LOGININFO))
            {
                connection.Open();
                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = connection;
                    cmd.CommandText = "Select user_latitude, user_longitude from yelpuser where user_id = '" + userId + "'";
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (columns.Count == 0)
                                columns = reader.GetColumnSchema();

                            //List<double> row = new List<string>();
                            double value = 0;

                            foreach (NpgsqlDbColumn column in columns)
                            {
                                if (double.TryParse(reader[column.ColumnName].ToString(), out value))
                                {
                                    returnValue.Add(value);
                                }
                            }
                                //returnValue.Add(reader[column.ColumnName]);
                            //row.Add(reader[column.ColumnName].ToString());
                            //return
                            
                        }
                    }
                }
                connection.Close();
            }
            //// Returns the list of column names as the first row.
            //List<string> header = new List<string>();
            //foreach (NpgsqlDbColumn column in columns)
            //    header.Add(column.ColumnName);
            //results.Insert(0, header);

            //lastQuery = results;
            //return results;

            return returnValue;
        }

        // Each business will have two values in their list: latitude and longitude
        // Need to change this to search based off of business_ids
        public List<List<double>> GetBusinessLocations(List<string> businessNames)
        {
            List<List<double>> results = new List<List<double>>();
            ReadOnlyCollection<NpgsqlDbColumn> columns = new ReadOnlyCollection<NpgsqlDbColumn>(new List<NpgsqlDbColumn>());

            //string query = "select b.latitude, b.longitude from business as b where b.name = 'Blimpie' or b.name = 'Back-Health Chiropractic' or b.name = 'QQ Foot Spa'";
            string query = "select b.latitude, b.longitude from business as b where b.name";


            foreach (string businessName in businessNames)
            {
                if (businessName != businessNames[businessNames.Count - 1])
                {
                    query = query + " = '" + businessName + "' or b.name";

                }
                else
                {
                    query = query + " = '" + businessName + "'";
                }
            }

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

                            List<double> row = new List<double>();
                            double value;

                            foreach (NpgsqlDbColumn column in columns)
                            {
                                if (double.TryParse(reader[column.ColumnName].ToString(), out value))
                                {
                                    //returnValue.Add(value);
                                    row.Add(value);
                                }
                            }
                                
                            results.Add(row);
                        }
                    }
                }
                connection.Close();

                return results;
            }
        }

        public List<List<string>> GetFriends(string userId)
        {
            List<List<string>> results = new List<List<string>>();
            ReadOnlyCollection<NpgsqlDbColumn> columns = new ReadOnlyCollection<NpgsqlDbColumn>(new List<NpgsqlDbColumn>());

            using (var connection = new NpgsqlConnection(LOGININFO))
            {
                connection.Open();
                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = connection;
                    cmd.CommandText = "Select name, average_stars, yelping_since from yelpuser where user_id in (Select friend_id from friend where user_id = '" + userId + "')";
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (columns.Count == 0)
                                columns = reader.GetColumnSchema();

                            List<string> row = new List<string>();

                            foreach (NpgsqlDbColumn column in columns)
                                row.Add(reader[column.ColumnName].ToString());

                            results.Add(row);
                        }
                    }
                }
                connection.Close();
            }
            // Returns the list of column names as the first row.
            List<string> header = new List<string>();
            foreach (NpgsqlDbColumn column in columns)
                header.Add(column.ColumnName);
            results.Insert(0, header);

            lastQuery = results;
            return results;
        }

        public List<List<string>> GetFavBusinesses(string userId)
        {
            List<List<string>> results = new List<List<string>>();
            ReadOnlyCollection<NpgsqlDbColumn> columns = new ReadOnlyCollection<NpgsqlDbColumn>(new List<NpgsqlDbColumn>());

            using (var connection = new NpgsqlConnection(LOGININFO))
            {
                connection.Open();
                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = connection;
                    cmd.CommandText = "Select name, stars, city, zipcode, address from business where business_id in (Select favorited_business from favorite where user_id = '" + userId + "')";
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (columns.Count == 0)
                                columns = reader.GetColumnSchema();

                            List<string> row = new List<string>();

                            foreach (NpgsqlDbColumn column in columns)
                                row.Add(reader[column.ColumnName].ToString());

                            results.Add(row);
                        }
                    }
                }
                connection.Close();
            }
            // Returns the list of column names as the first row.
            List<string> header = new List<string>();
            foreach (NpgsqlDbColumn column in columns)
                header.Add(column.ColumnName);
            results.Insert(0, header);

            lastQuery = results;
            return results;
        }

        // Strange bug where whichever "name" column is first will also be the 2nd column
        public List<List<string>> GetFriendsReview(string userId)
        {
            List<List<string>> results = new List<List<string>>();
            ReadOnlyCollection<NpgsqlDbColumn> columns = new ReadOnlyCollection<NpgsqlDbColumn>(new List<NpgsqlDbColumn>());

            using (var connection = new NpgsqlConnection(LOGININFO))
            {
                connection.Open();
                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = connection;
                    cmd.CommandText = "select n2.name, b.name, b.city, n2.text from business as b inner join(select yu.name, n.text, n.business_id from yelpuser as yu inner join(select distinct on (user_id) user_id, text, business_id from review " +
                        "order by user_id, date desc) n on(yu.user_id = n.user_id and yu.user_id in (Select friend_id from friend where user_id = '" + userId + "'))) n2 on(n2.business_id = b.business_id)";
                    //cmd.CommandText = "select n2.name, b.name, b.city, n2.text from business as b inner join(select yu.name, n.text, n.business_id from yelpuser as yu inner join(select distinct on (user_id) user_id, text, business_id from review " + 
                    //  "order by user_id, date desc) n on(yu.user_id = n.user_id and yu.user_id in (Select friend_id from friend where user_id = '" + userId + "'))) n2 on(n2.business_id = b.business_id)";
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (columns.Count == 0)
                                columns = reader.GetColumnSchema();

                            List<string> row = new List<string>();

                            foreach (NpgsqlDbColumn column in columns)
                                row.Add(reader[column.ColumnName].ToString());

                            results.Add(row);
                        }
                    }
                }
                connection.Close();
            }
            // Returns the list of column names as the first row.
            List<string> header = new List<string>();
            foreach (NpgsqlDbColumn column in columns)
                header.Add(column.ColumnName);
            results.Insert(0, header);

            lastQuery = results;
            return results;
        }

        public void RemoveFavBus(string user_id, string busName, string busAdd)
        {
            string query = "delete from favorite as f where f.user_id = '" + user_id + "' and f.favorited_business in (select business_id from business as b " +
                "where b.name = '" + busName + "' and b.address = '" + busAdd + "')";

            using (var connection = new NpgsqlConnection(LOGININFO))
            {
                connection.Open();
                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = connection;
                    cmd.CommandText = query;
                    cmd.ExecuteNonQuery();
                }
                connection.Close();
            }
        }

        /// <summary>
        /// Update the selected user's latitude and longitude
        /// </summary>
        /// <param name="user_id">selected user's id</param>
        /// <param name="lat">entered latitude</param>
        /// <param name="lon">entered lonitude</param>
        public void updateUserLocation(string user_id, double lat, double lon)
        {
            string query = "Update yelpuser set user_latitude = " + lat.ToString() +
                ", user_longitude = " + lon.ToString() + " where user_id = '" +
                user_id + "'";

            using (var connection = new NpgsqlConnection(LOGININFO))
            {
                connection.Open();
                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = connection;
                    cmd.CommandText = query;
                    cmd.ExecuteNonQuery();
                }
                connection.Close();
            }
        }
    }
}
