using Npgsql;
using Npgsql.Schema;
using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using static System.Windows.Forms.CheckedListBox;
using QueryEngine1;

namespace Milestone2App
{
    public partial class YelpGUI : Form
    {
        QueryEngine queryEngine;
        List<Business> dataGridBusinesses;
        //private BindingSource businessBindingSource; //allows the datagridview to automatically update itself from the dataGridBusinesses.

        private static string LOGININFO = "Host=localhost; Username=postgres; Password=greatPassword; Database=milestone2db"; // Defines our connection to local databus
        //private static string LOGININFO = "Host=35.230.13.126; Username=postgres; Password=oiAv4Kmdup8Pd4vd; Database=milestone2db"; // Defines our connection to cloud hosted databus

        public YelpGUI()
        {
            queryEngine = new QueryEngine();
            InitializeComponent();
            initializeDropDowns();
            //businessBindingSource = new BindingSource(dataGridBusinesses);
            //businessGrid.DataSource = businessBindingSource; //tell the businessGrid to read the data from the list of businesses.


            string[] cols = { "name", "address", "city", "state", "stars", "review_count", "num_checkins", "reviewRating", "is_open" };

            foreach (var column in cols)
            {
                // Create the column headers for the data grid view.
                DataGridViewTextBoxColumn newColumn = new DataGridViewTextBoxColumn();
                newColumn.HeaderText = column;
                newColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                businessGrid.Columns.Add(newColumn);
            }                                       
        }

        private void initializeDropDowns()
        {
            List<string> states = queryEngine.getStates();
            foreach (var state in states)
                stateDropDown.Items.Add(state); //populates the state drop down with all the states returned by the queryEngine         
        }

        private void stateDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox box = (ComboBox)sender; //casts sender as a ComboBox

            
            cityCheckBox.Items.Clear();
            zipCheckBox.Items.Clear();

            // query database to get list of cities in the selected state
            // update city dropdown with list
            using (var connection = new NpgsqlConnection(LOGININFO))
            {
                connection.Open();
                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = connection;
                    cmd.CommandText = "SELECT distinct city FROM business WHERE business.state = '" + box.SelectedItem + "' ORDER BY city;";
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                            //cityDropDown.Items.Add(reader.GetString(0));
                            cityCheckBox.Items.Add(reader.GetString(0));
                    }
                }
                connection.Close();
            }

        }

        private void cityCheckBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            CheckedListBox CheckBox = (CheckedListBox)sender; //casts the sending object as a checkedbox
            List<string> checkedItems = new List<string>();

            // need to remove the zipcodes from that city from the zipBox
            using (var connection = new NpgsqlConnection(LOGININFO))
            {
                connection.Open();
                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = connection;
                    cmd.CommandText = "SELECT DISTINCT zipcode FROM business WHERE state = '" + stateDropDown.SelectedItem + "' AND city = '" + cityCheckBox.Items[e.Index].ToString() + "' ORDER BY zipcode;";
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                            checkedItems.Add(reader.GetString(0));
                    }
                }
                connection.Close();
            }

            if (e.NewValue == CheckState.Checked) //add or remove the check box item that just changed to the list
            {
                foreach (string item in checkedItems)
                    zipCheckBox.Items.Add(item);
            }
            else
            {
                foreach (string item in checkedItems)
                    zipCheckBox.Items.Remove(item);

                List<string> newZipBoxItems = new List<string>(); //a list that holds all the data we will pass to the grid updater function
                foreach (string item in zipCheckBox.CheckedItems)
                    newZipBoxItems.Add(item);

                updateGrid(newZipBoxItems); //we need to update the datagrid to remove all the elements that are no longer selectable in the zipcode box
            }
        }

        private void zipCheckBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            CheckedListBox senderCheckBox = (CheckedListBox)sender; //casts the sending object as a checkedbox
            List<string> zipItems = new List<string>();

            foreach (string item in senderCheckBox.CheckedItems) // add all the checked Items into our list that holds their string names.            
                zipItems.Add(item);

            if (e != null) //if the function is called without an argument, which is when its being called from within another event.
            {
                if (e.NewValue == CheckState.Checked) //add or remove the check box item that just changed to the list
                    zipItems.Add(senderCheckBox.Items[e.Index].ToString());
                else
                    zipItems.Remove(senderCheckBox.Items[e.Index].ToString());
            }

            
        }


        private void categoriesCheckBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            CheckedListBox senderCheckBox = (CheckedListBox)sender; //casts the sending object as a checkedbox
            List<string> zipItems = new List<string>();

            foreach (string item in senderCheckBox.CheckedItems) // add all the checked Items into our list that holds their string names.            
                zipItems.Add(item);

            if (e != null) //if the function is called without an argument, which is when its being called from within another event.
            {
                if (e.NewValue == CheckState.Checked) //add or remove the check box item that just changed to the list
                    zipItems.Add(senderCheckBox.Items[e.Index].ToString());
                else
                    zipItems.Remove(senderCheckBox.Items[e.Index].ToString());
            }

            updateGrid(zipItems);
        }

        private void updateGrid(List<string> categoryContents)
        {
            businessGrid.Rows.Clear(); //removes all the data previously in the grid.

            if (categoryContents.Count == 0) //if there are no items that are checked.
                return; //end the call

            string orList = "AND city IN (SELECT city FROM business WHERE "; //building subquery to find all the cities in the listbox
            foreach (string item in cityCheckBox.CheckedItems)
            {
                Console.WriteLine(item);
                orList += "city = '" + item + "' OR "; // city = 'string' OR 
            }
            orList = orList.Substring(0, orList.Length - 3); // Cuts off the final "OR "
            orList += ") ";

            orList += "AND zipcode IN (SELECT zipcode FROM business WHERE "; //building subquery to find all the zipcodes in the listbox
            foreach (string item in categoriesCheckBox.CheckedItems)
            {
                Console.WriteLine(item);
                orList += "zipcode = '" + item + "' OR ";
            }
            orList = orList.Substring(0, orList.Length - 3);
            orList += ") ";

            orList += "AND zipcode IN (SELECT category FROM category WHERE "; //building subquery to find all the zipcodes in the listbox
            foreach (string item in categoriesCheckBox.CheckedItems)
            {
                Console.WriteLine(item);
                orList += "zipcode = '" + item + "' OR ";
            }
            orList = orList.Substring(0, orList.Length - 3);
            orList += ") ";

            // populate data into businessGrid from database with the city and state from each check box
            using (var connection = new NpgsqlConnection(LOGININFO))
            {
                //bool noColumns = true; //really really ghetto way to add all the columns. Might be useful for queryEngine though
                connection.Open(); 
                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = connection;
                    cmd.CommandText = "SELECT name, address, city, state, stars, review_count, num_checkins, reviewRating, is_open FROM business WHERE state = '" + stateDropDown.SelectedItem + "'" + orList + " ORDER BY state;";
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {                            
                            //if (noColumns)
                            //{
                            //    noColumns = false;
                            //    ReadOnlyCollection<NpgsqlDbColumn> addColumns = reader.GetColumnSchema();
                            //    foreach (NpgsqlDbColumn column in addColumns)
                            //    {
                            //        // Create the column headers for the data grid view.
                            //        DataGridViewTextBoxColumn newColumn = new DataGridViewTextBoxColumn();
                            //        newColumn.HeaderText = column.ColumnName;
                            //        newColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                            //        businessGrid.Columns.Add(newColumn);
                            //    }                                    
                            //}

                            ReadOnlyCollection<NpgsqlDbColumn> columns = reader.GetColumnSchema();
                            int col = 0;
                            var row = businessGrid.Rows.Add(); //the index of the new row
                            foreach (NpgsqlDbColumn column in columns)
                            {
                                businessGrid.Rows[row].Cells[col].Value = reader[column.ColumnName].ToString();
                                col++;
                            }
                        }
                    }
                }
                connection.Close();
            }
        }

        private void UserNameEntryTextBox_TextChanged(object sender, EventArgs e)
        {
            string name = UserNameEntryTextBox.Text;

            if (PlayerIDListBox.Items.Count > 0) //removes all the data previously in the grid.
                PlayerIDListBox.Items.Clear();

            if (name == string.Empty)
            {
                return;
            }

            // fill PlayerIDListBox with ids that match the name
            // run query
            using (var connection = new NpgsqlConnection(LOGININFO))
            {
                connection.Open();
                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = connection;
                    cmd.CommandText = "SELECT distinct user_id FROM yelpuser WHERE yelpuser.name like '%" + name + "%' ORDER BY user_id;";
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            PlayerIDListBox.Items.Add(reader.GetString(0));
                        }
                    }
                }
                connection.Close();
            }
        }

        private void PlayerIDListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Fill all of the user's info textboxes
            string user_id = PlayerIDListBox.SelectedItem.ToString();

            using (var connection = new NpgsqlConnection(LOGININFO))
            {
                connection.Open();
                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = connection;
                    // SELECT * from yelpuser WHERE yelpuser.user_id = 'QGauzwshJlwHyMqT--CGiQ';
                    cmd.CommandText = "SELECT * from yelpuser WHERE yelpuser.user_id = '" + user_id + "' ORDER BY user_id;";
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            NameValue.Text = reader.GetString(1);
                            StarsValue.Text = reader.GetDouble(2).ToString();
                            CoolValue.Text = reader.GetValue(3).ToString();
                            FunnyValue.Text = reader.GetValue(4).ToString();
                            UsefulValue.Text = reader.GetValue(5).ToString();
                            FansValue.Text = reader.GetValue(6).ToString();
                            ReviewCountValue.Text = reader.GetValue(7).ToString();
                            YelpingSinceValue.Text = reader.GetDate(8).ToString();

                            try
                            {
                                LatitudeValue.Text = reader.GetDouble(9).ToString();
                            }
                            catch (InvalidCastException ex)
                            {
                                LatitudeValue.Text = "empty";
                            }

                            try
                            {
                                LongitudeValue.Text = reader.GetDouble(10).ToString();
                            }
                            catch (InvalidCastException ex)
                            {
                                LongitudeValue.Text = "empty";
                            }
                            
                            
                            

                            //if reader.GetDouble(7)


                        }
                    }
                }
                connection.Close();
            }



        }

    }
}
