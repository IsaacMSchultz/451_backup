﻿using Npgsql;
using System;
using System.Windows.Forms;
using System.Collections.Generic;
using static System.Windows.Forms.CheckedListBox;

namespace Milestone2App
{
    public partial class Form1 : Form
    {

        //private static string LOGININFO = "Host=35.230.13.126; Username=postgres; Password=oiAv4Kmdup8Pd4vd; Database=milestone2db";
        private static string LOGININFO = "Host=localhost; Username=postgres; Password=greatPassword; Database=milestone2db";

        public class Business //Not Used for now.
        {
            public string name { get; set; }
            public string state { get; set; }
            public string city { get; set; }
        }

        public Form1()
        {
            InitializeComponent();
            initializeDropDowns();
        }

        private void initializeDropDowns()
        {
            // interact with database to query the list of states contained within      
            // update states dropdown menu with the list of distinct states
            // 'using' keyword to auto call dispose when we are done.
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
                            stateDropDown.Items.Add(reader.GetString(0));
                    }
                }
                connection.Close();
            }

            // Create the column headers for the data grid view.
            DataGridViewTextBoxColumn col1 = new DataGridViewTextBoxColumn();
            col1.HeaderText = "Business name";
            col1.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            businessGrid.Columns.Add(col1);

            DataGridViewTextBoxColumn col2 = new DataGridViewTextBoxColumn();
            col2.HeaderText = "City";
            col2.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            businessGrid.Columns.Add(col2);

            DataGridViewTextBoxColumn col3 = new DataGridViewTextBoxColumn();
            col3.HeaderText = "State";
            col3.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            businessGrid.Columns.Add(col3);
        }

        private void stateDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox box = (ComboBox)sender; //casts sender as a ComboBox

            if (cityCheckBox.Items.Count > 0) //removes all the data previously in the grid.
                cityCheckBox.Items.Clear();

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

                // if (CheckBox.CheckedItems.Count == 0) //if there are no items that are checked.
                //   return; //end the call
                /*
                string orList = "AND city IN (SELECT city FROM business WHERE "; //building subquery to find all the cities in the listbox
                foreach (string item in checkedItems)
                {
                    Console.WriteLine(item);
                    orList += "city = '" + item + "' OR "; // city = 'string' OR 
                }
                orList = orList.Substring(0, orList.Length - 3); // Cuts off the final "OR "
                orList += ')';*/
                foreach (string item in checkedItems)
                    zipCheckBox.Items.Add(item);

            }
            else
            {
                foreach (string item in checkedItems)
                    zipCheckBox.Items.Remove(item);
            }

            
        }

        private void zipCheckBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            CheckedListBox senderCheckBox = (CheckedListBox)sender; //casts the sending object as a checkedbox
            List<string> zipItems = new List<string>();

            foreach (string item in senderCheckBox.CheckedItems) // add all the checked Items into our list that holds their string names.            
                zipItems.Add(item);

            if (e.NewValue == CheckState.Checked) //add or remove the check box item that just changed to the list
                zipItems.Add(senderCheckBox.Items[e.Index].ToString());
            else
                zipItems.Remove(senderCheckBox.Items[e.Index].ToString());

            businessGrid.Rows.Clear(); //removes all the data previously in the grid.

            if (zipItems.Count == 0) //if there are no items that are checked.
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
            foreach (string item in zipItems)
            {
                Console.WriteLine(item);
                orList += "zipcode = '" + item + "' OR ";
            }
            orList = orList.Substring(0, orList.Length - 3);
            orList += ") ";

            // populate data into businessGrid from database with the city and state from each check box
            using (var connection = new NpgsqlConnection(LOGININFO))
            {
                connection.Open();
                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = connection;
                    cmd.CommandText = "SELECT * FROM business WHERE state = '" + stateDropDown.SelectedItem + "'" + orList + " ORDER BY state;";
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                            businessGrid.Rows.Add(reader["name"], reader["city"], reader["state"]);
                    }
                }
                connection.Close();
            }
        }
    }
}
