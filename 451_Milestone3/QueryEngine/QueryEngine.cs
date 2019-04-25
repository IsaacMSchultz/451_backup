using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Npgsql;
using Npgsql.Schema;
using SpicyMap;

namespace QueryEngine1
{
    public class QueryEngine
    {
        private Dictionary<string, List<string>> searchParameters;
        List<List<string>> lastQuery;
        string currBusId;
        string currUserId;
        MapNamesToAttrValPair attrList;

        private static Random random = new Random();
        const string chars = "abcdefghijklmnopqrstuvwyxzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789_- ";

        public event PropertyChangedEventHandler YelpDataChanged; // event for notifying that there was a property changed. 
        private static string LOGININFO = "Host=35.230.13.126; Username=postgres; Password=oiAv4Kmdup8Pd4vd; Database=milestone3db"; // cloud database
        //private static string LOGININFO = "Host=localhost; Username=postgres; Password=greatPassword; Database=milestone3db";

        public QueryEngine()
        {
            searchParameters = new Dictionary<string, List<string>>();
            lastQuery = new List<List<string>>();
            currBusId = "";
            attrList = new MapNamesToAttrValPair();
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
                    return new List<string>();
            }
            else
            {
                //string q = "SELECT DISTINCT category_name FROM category WHERE business_id = '" + id + "';";
                return ExecuteListQuery("SELECT DISTINCT category_name FROM category WHERE business_id = '" + id + "';");
            }
        }

        //TODO: BUG WHERE THIS RETURNS ALL CATEGORIES EVEN IF THEY ARENT IN THE DATA.
        //Returns a list of all the checked categories, or an empty list if there are no checked categories
        public List<string> GetCheckedCategories()
        {
            if (searchParameters.ContainsKey("category_name"))
            {
                List<string> returnListNoReference = new List<string>(); //need to deep copy because just returning searchParameters["category_name"] gives a reference to data from here which causes issues
                foreach (string value in searchParameters["category_name"])
                    returnListNoReference.Add(value);
                return returnListNoReference;
            }
            else return new List<string>();
        }

        public List<List<string>> GetAttributes(string id = "N/A")
        {
            return ExecuteCategorizedQuery("SELECT DISTINCT attribute_name, attribute_value FROM attributes WHERE business_id = '" + id + "';");
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

        // Need to templatize to avoid repeated code
        public List<string> GetBusinesses(string name, string projection = "business_id")
        {
            List<string> returnList = new List<string>();
            if (name == string.Empty)
                return returnList;

            returnList = ExecuteListQuery("SELECT distinct " + projection + " FROM business WHERE business.name like '%" + name + "%' ORDER BY business_id;");

            return returnList;
        }

        public List<List<string>> GetBusiness(string id, string projection = "*")
        {
            return ExecuteCategorizedQuery("SELECT " + projection + " from business WHERE business.business_id = '" + id + "';");
        }

        public List<List<string>> GetUser(string id, string projection = "*")
        {
            return ExecuteCategorizedQuery("SELECT " + projection + " from yelpuser WHERE yelpuser.user_id = '" + id + "';");
        }

        public List<List<string>> GetFriendsWhoReviewedBus(string user_id, string business_id)
        {
            return ExecuteCategorizedQuery("select n2.name as name1, b.name as name2, n2.review_stars, n2.text from business as b inner join" +
                "(select yu.name, n.text, n.review_stars, n.business_id from yelpuser as yu inner join" +
                "(select user_id, text, business_id, review_stars from review) n on" +
                "(yu.user_id = n.user_id and yu.user_id in (Select friend_id from friend where user_id = '" + currUserId + "'))) n2 on" +
                "(n2.business_id = b.business_id and b.business_id = '" + business_id + "')");
        }

        public List<List<string>> GetReviewsByKeyword(string keyword, string projection = "*")
        {
            return ExecuteCategorizedQuery("SELECT " + projection + " from review WHERE text like '%" + keyword + "%'");
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
                string queryList = ""; //building subquery to find all the cities in the listbox                

                //iterate through all the Keys and values and build all the necesary subqueries
                foreach (KeyValuePair<string, List<string>> key in searchParams) //each keyValuePar
                {
                    if (attrList.Contains(key.Key))
                    {
                        foreach (string item in key.Value) //Each item in the list for each key      
                        {
                            queryList += " business_id IN ( SELECT business_id FROM attributes WHERE ";
                            queryList += "attribute_name = '" + key.Key + "' AND attribute_value = '" + item + "') "; // "<key> = '<each item in the list with that key>' AND "                            
                            if (key.Value.Last() != item) //Only add the AND to the end if it isnt the last one on the list
                                queryList += " AND";
                        }
                    }
                    else
                    {
                        if (key.Key != "category_name")
                        {
                            queryList += key.Key + " IN ( SELECT " + key.Key + " FROM business WHERE "; // ") AND <nextKey> IN ( SELECT  FROM business WHERE " (also increments the currIndex)
                            foreach (string item in key.Value) //Each item in the list for each key      
                            {
                                queryList += key.Key + " = '" + item + "' "; // "<key> = '<each item in the list with that key>' OR "
                                if (key.Value.Last() != item) //Only add the OR to the end if it isnt the last one on the list
                                    queryList += " OR ";
                                else
                                    queryList += ")"; // On the last item we need to close the parenthesis
                            }
                        }
                        else
                        {
                            foreach (string item in key.Value) //Each item in the list for each key      
                            {
                                queryList += " business_id IN ( SELECT business_id FROM category WHERE ";
                                queryList += key.Key + " = '" + item + "') "; // "<key> = '<each item in the list with that key>'"
                                if (key.Value.Last() != item) //Only add the AND to the end if it isnt the last one on the list
                                    queryList += " AND ";
                            }
                        }
                    }

                    if (!searchParams.Last().Equals(key)) // Add an AND for each subquery only if this isnt the last element in te dictionary
                        queryList += " AND ";
                }

                string query = "SELECT " + projection + " FROM " + tables + " WHERE " + queryList + endQuery + " ORDER BY state;"; //Broken up into 3 lines for debug purposes
                lastQuery = ExecuteCategorizedQuery(query);
                return lastQuery;
            }
            lastQuery = new List<List<string>>();
            return lastQuery; //return empty array because there are no search parameters.
        }

        /// <summary>
        /// Adds a value to the search parameters  
        /// </summary>
        public void AddSearchParameter(string key, string value)
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
        public void RemoveSearchParameter(string key, string value)
        {
            if (searchParameters.ContainsKey(key) && searchParameters[key].Contains(value)) // can only remove something if its actually there.
            {
                searchParameters[key].Remove(value);
                if (searchParameters[key].Count == 0) // if that was the last value in that keyValue pair, remove the key
                    searchParameters.Remove(key);
            }
        }

        /// <summary>
        /// Adds a value to the search parameters  
        /// </summary>
        public void AddSearchAttribute(string key, List<string> values)
        {
            searchParameters[key] = values;
        }

        /// <summary>
        /// Removes a value from the search parameters    
        /// </summary>
        public void RemoveSearchAttribute(string key)
        {
            if (searchParameters.ContainsKey(key)) // can only remove something if its actually there.
            {
                searchParameters.Remove(key);
            }
        }

        /// <summary>
        /// sets a search parameter to contain only one value 
        /// </summary>
        public void ResetSearchParameter(string key, string value)
        {
            searchParameters = new Dictionary<string, List<string>>();

            List<string> newList = new List<string>(); //insert new key-value pair with the single value.
            newList.Add(value);
            searchParameters.Add(key, newList);
        }

        private void YelpPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            YelpDataChanged?.Invoke(sender, e);
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

        // Posts a review and checks the status
        public bool PostReview(string reviewText, int reviewStars, string busID, string UserID)
        {
            string reviewID = new string(Enumerable.Repeat(chars, 22).Select(s => s[random.Next(s.Length)]).ToArray()); //makes a random 22 charachter string
            string query = "INSERT INTO review VALUES ('" + reviewID + "', '" + busID + "', '" + UserID + "', '" + reviewStars + "', NOW(), '" + reviewText + "', 0, 0, 0);";
            return ExecuteNonQuery(query);
        }

        // Should only return 2 values in the list, latitude and longitude
        public List<double> GetUserLocation(string userId)
        {
            string query = "Select user_latitude, user_longitude from yelpuser where user_id = '" + userId + "'";
            //return ExecuteDoubleQuery(query);
            List<List<double>> userLocation = ExecuteCategorizedDoubleQuery(query);

            return userLocation[0];
        }

        // Each business will have two values in their list: latitude and longitude
        // Need to change this to search based off of business_ids
        public List<List<double>> GetBusinessLocations(List<string> businessIds)
        {
            List<List<double>> results = new List<List<double>>();
            ReadOnlyCollection<NpgsqlDbColumn> columns = new ReadOnlyCollection<NpgsqlDbColumn>(new List<NpgsqlDbColumn>());

            //string query = "select b.latitude, b.longitude from business as b where b.name = 'Blimpie' or b.name = 'Back-Health Chiropractic' or b.name = 'QQ Foot Spa'";
            string query = "select b.latitude, b.longitude from business as b where b.business_id";

            foreach (string businessId in businessIds)
            {
                if (businessId != businessIds[businessIds.Count - 1])
                    query = query + " = '" + businessId + "' or b.business_id";
                else
                    query = query + " = '" + businessId + "'";
            }

            return ExecuteCategorizedDoubleQuery(query);
        }

        public List<List<string>> GetFavBusinesses(string userId)
        {
            string query = "Select name, stars, city, zipcode, address from business where business_id in (Select favorited_business from favorite where user_id = '" + userId + "')";
            return ExecuteCategorizedQuery(query);
        }

        public List<List<string>> GetFriends(string userId)
        {
            string query = "Select name, average_stars, yelping_since from yelpuser where user_id in (Select friend_id from friend where user_id = '" + userId + "')";
            return ExecuteCategorizedQuery(query);
        }

        public List<List<string>> GetReviewsByKeyword(string keyword)
        {
            string query = "SELECT business.name, funny_vote, text FROM review INNER JOIN business ON business.business_id = review.business_id WHERE review.text like '%" + keyword + "%'";
            return ExecuteCategorizedQuery(query);
        }

        // Strange bug where whichever "name" column is first will also be the 2nd column
        public List<List<string>> GetFriendsReview(string userId)
        {
            string query = "select n2.name as name1, b.name as name2, b.city, n2.text from business as b inner join(select yu.name, n.text, n.business_id from yelpuser as yu inner join(select distinct on (user_id) user_id, text, business_id from review " +
                "order by user_id, date desc) n on(yu.user_id = n.user_id and yu.user_id in (Select friend_id from friend where user_id = '" + userId + "'))) n2 on(n2.business_id = b.business_id)";
            return ExecuteCategorizedQuery(query);
        }

        public bool RemoveFavBus(string user_id, string busName, string busAdd)
        {
            string query = "delete from favorite as f where f.user_id = '" + user_id + "' and f.favorited_business in (select business_id from business as b " +
                "where b.name = '" + busName + "' and b.address = '" + busAdd + "')";
            return ExecuteNonQuery(query);
        }

        public bool UpdateAttribute(string business_id, string attribute_name, string attribute_value)
        {
            string query = "Update attributes set attribute_value = '" + attribute_value + "' where business_id = '" +
                business_id + "' and attribute_name = '" + attribute_name + "'";
            return ExecuteNonQuery(query);
        }

        public bool UpdateBusinessName(string business_id, string business_name)
        {
            string query = "Update business set name = '" + business_name + "' where business_id = '" +
                business_id + "'";
            return ExecuteNonQuery(query);
        }

        /// <summary>
        /// Update the selected user's latitude and longitude
        /// </summary>
        /// <param name="user_id">selected user's id</param>
        /// <param name="lat">entered latitude</param>
        /// <param name="lon">entered lonitude</param>
        public bool UpdateUserLocation(string user_id, double lat, double lon)
        {
            string query = "Update yelpuser set user_latitude = " + lat.ToString() +
                ", user_longitude = " + lon.ToString() + " where user_id = '" +
                user_id + "'";

            return ExecuteNonQuery(query);
        }

        /// <summary>
        /// Add a checkin for the current user!
        /// </summary>
        /// <param name="user_id">selected user's id</param>
        /// <param name="lat">entered latitude</param>
        /// <param name="lon">entered lonitude</param>
        public bool AddCheckin(string business_id, DateTime time)
        {
            // Round to the nearest hour
            long ticks = time.Ticks + 18000000000; // add 30 minutes
            time = new DateTime(ticks - ticks % 36000000000, time.Kind); // Round down the hour
            string query = "INSERT INTO checkins VALUES ('" + business_id + "', '" + time.DayOfWeek.ToString() + "', '" + time.ToString("HH:mm:ss") + "', 1);";
            return ExecuteNonQuery(query);
        }

        public bool InsertAttribute(string business_id, string attribute_name, string attribute_value)
        {
            string query = "INSERT INTO attributes VALUES ('" + business_id + "', '" + attribute_name + "', '" + attribute_value + "');";
            return ExecuteNonQuery(query);
        }

        public bool AddToFavorites(string business_id, string user_id)
        {
            string check = "SELECT favorited_business FROM favorite WHERE favorited_business = '" + business_id + "' AND user_id = '" + user_id + "';";
            if (ExecuteListQuery(check).Count == 0) // If the business is not favorited already
            {
                string query = "INSERT INTO favorite VALUES ('" + user_id + "', '" + business_id + "');";
                return ExecuteNonQuery(query);
            }
            return false;
        }

        /// <summary>
        /// Executes the query on the database and returns the results as a 2 dimensional list of Businesses   
        /// the first row of the first list will contain the column names.
        /// </summary>
        private List<List<string>> ExecuteCategorizedQuery(string query)
        {
            List<List<string>> returnList = new List<List<string>>();
            ReadOnlyCollection<NpgsqlDbColumn> columns = new ReadOnlyCollection<NpgsqlDbColumn>(new List<NpgsqlDbColumn>());

            try
            {
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
            }
            catch (NpgsqlException e)
            {
                Console.WriteLine(e.ToString());
                return returnList;
            }

            // Returns the list of column names as the first row.
            List<string> header = new List<string>();
            foreach (NpgsqlDbColumn column in columns)
                header.Add(column.ColumnName);
            returnList.Insert(0, header);

            lastQuery = returnList;
            return returnList;
        }

        private List<List<double>> ExecuteCategorizedDoubleQuery(string query)
        {
            List<List<double>> results = new List<List<double>>();
            ReadOnlyCollection<NpgsqlDbColumn> columns = new ReadOnlyCollection<NpgsqlDbColumn>(new List<NpgsqlDbColumn>());
            try
            {
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
                                    if (double.TryParse(reader[column.ColumnName].ToString(), out value))
                                        row.Add(value);

                                results.Add(row);
                            }
                        }
                    }
                    connection.Close();
                }
                return results;
            }
            catch (NpgsqlException e)
            {
                Console.WriteLine(e.ToString());
                return new List<List<double>>();
            }
        }

        private List<string> ExecuteListQuery(string query)
        {
            List<string> strings = new List<string>();
            try
            {
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
            }
            catch (NpgsqlException e)
            {
                Console.WriteLine(e.ToString());
            }
            return strings;
        }

        private List<double> ExecuteDoubleQuery(string query)
        {
            List<double> returnList = new List<double>();
            try
            {
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
                                returnList.Add(reader.GetDouble(0));
                        }
                    }
                    connection.Close();
                }
            }
            catch (NpgsqlException e)
            {
                Console.WriteLine(e.ToString());
            }
            return returnList;
        }

        private bool ExecuteNonQuery(string query)
        {
            try
            {
                int rows = 0;
                using (var connection = new NpgsqlConnection(LOGININFO))
                {
                    connection.Open();
                    using (var cmd = new NpgsqlCommand())
                    {
                        cmd.Connection = connection;
                        cmd.CommandText = query;
                        rows = cmd.ExecuteNonQuery();
                    }
                    connection.Close();
                }
                if (rows > 0) // Only return true if the query modified some rows
                    return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            return false;
        }

        public List<KeyValuePair<String, int>> QueryCheckinsGraph(string busId = "--ab39IjZR_xUf81WyTyHg")
        {
            List<KeyValuePair<String, int>> myChartData = new List<KeyValuePair<string, int>>();

            try
            {
                //Select business_id, SUM(num_checkins) from business Where business_id = '--ab39IjZR_xUf81WyTyHg' group by business_id order by business_id;
                using (var conn = new NpgsqlConnection(LOGININFO))
                {
                    conn.Open();
                    using (var cmd = new NpgsqlCommand())
                    {
                        cmd.Connection = conn;
                        // Business ID needs to be specificly stated. Do we need to add an input for the button on the interface
                        cmd.CommandText = "SELECT checkins.day, SUM(checkins.count)FROM business JOIN checkins ON business.business_id = checkins.business_id WHERE business.business_id =@busId GROUP BY checkins.day ORDER BY CASE WHEN checkins.day = 'Monday' THEN '1' WHEN checkins.day = 'Tuesday' THEN '2' WHEN checkins.day = 'Wednesday' THEN '3' WHEN checkins.day = 'Thursday' THEN '4' WHEN checkins.day = 'Friday' THEN '5' WHEN checkins.day = 'Saturday' THEN '6' WHEN checkins.day = 'Sunday' THEN '7'ELSE checkins.day END ASC";
                        cmd.Parameters.AddWithValue("@busId", busId);
                        //cmd.CommandText = "SELECT checkins.day, COUNT(checkins.day) FROM business JOIN checkins ON business.business_id = checkins.business_id WHERE business.business_id = '--ab39IjZR_xUf81WyTyHg' GROUP BY checkins.day ORDER BY CASE WHEN checkins.day = 'Monday' THEN '1' WHEN checkins.day = 'Tuesday' THEN '2' WHEN checkins.day = 'Wednesday' THEN '3' WHEN checkins.day = 'Thursday' THEN '4' WHEN checkins.day = 'Friday' THEN '5' WHEN checkins.day = 'Saturday' THEN '6' WHEN checkins.day = 'Sunday' THEN '7'ELSE checkins.day END ASC";
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                myChartData.Add(new KeyValuePair<string, int>(reader.GetString(0), reader.GetInt32(1)));
                            }
                        }
                    }
                }
            }
            catch (NpgsqlException e)
            {
                Console.WriteLine(e.ToString());
                return new List<KeyValuePair<string, int>>();
            }
            return myChartData;
        }
    }
}