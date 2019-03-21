using Npgsql;
using System;
using System.Windows.Forms;
using System.Collections.Generic;
using static System.Windows.Forms.CheckedListBox;

namespace Milestone2App
{
    public partial class YelpGUI : Form
    {
        public YelpGUI()
        {
            InitializeComponent();
            initializeDropDowns();
        }

        private void initializeDropDowns()
        {


            // Create the column headers for the data grid view.
            DataGridViewTextBoxColumn nameColumn = new DataGridViewTextBoxColumn();
            nameColumn.HeaderText = "Business name";
            nameColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            businessGrid.Columns.Add(nameColumn);

            DataGridViewTextBoxColumn zipColumn = new DataGridViewTextBoxColumn();
            zipColumn.HeaderText = "Zip";
            zipColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            businessGrid.Columns.Add(zipColumn);

            DataGridViewTextBoxColumn cityColumn = new DataGridViewTextBoxColumn();
            cityColumn.HeaderText = "City";
            cityColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            businessGrid.Columns.Add(cityColumn);

            DataGridViewTextBoxColumn stateColumn = new DataGridViewTextBoxColumn();
            stateColumn.HeaderText = "State";
            stateColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            businessGrid.Columns.Add(stateColumn);
        }

        private void stateDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            //ComboBox box = (ComboBox)sender; //casts sender as a ComboBox

            //if (cityCheckBox.Items.Count > 0) //removes all the data previously in the grid.
            //    cityCheckBox.Items.Clear();

            //// query database to get list of cities in the selected state
            //// update city dropdown with list
            //using (var connection = new NpgsqlConnection(LOGININFO))
            //{
            //    connection.Open();
            //    using (var cmd = new NpgsqlCommand())
            //    {
            //        cmd.Connection = connection;
            //        cmd.CommandText = "SELECT distinct city FROM business WHERE business.state = '" + box.SelectedItem + "' ORDER BY city;";
            //        using (var reader = cmd.ExecuteReader())
            //        {
            //            while (reader.Read())
            //                //cityDropDown.Items.Add(reader.GetString(0));
            //                cityCheckBox.Items.Add(reader.GetString(0));
            //        }
            //    }
            //    connection.Close();
            //}
        }

        private void cityCheckBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            //CheckedListBox CheckBox = (CheckedListBox)sender; //casts the sending object as a checkedbox
            //List<string> checkedItems = new List<string>();

            //// need to remove the zipcodes from that city from the zipBox
            //using (var connection = new NpgsqlConnection(LOGININFO))
            //{
            //    connection.Open();
            //    using (var cmd = new NpgsqlCommand())
            //    {
            //        cmd.Connection = connection;
            //        cmd.CommandText = "SELECT DISTINCT zipcode FROM business WHERE state = '" + stateDropDown.SelectedItem + "' AND city = '" + cityCheckBox.Items[e.Index].ToString() + "' ORDER BY zipcode;";
            //        using (var reader = cmd.ExecuteReader())
            //        {
            //            while (reader.Read())
            //                checkedItems.Add(reader.GetString(0));
            //        }
            //    }
            //    connection.Close();
            //}

            //if (e.NewValue == CheckState.Checked) //add or remove the check box item that just changed to the list
            //{
            //    foreach (string item in checkedItems)
            //        zipCheckBox.Items.Add(item);
            //}
            //else
            //{
            //    foreach (string item in checkedItems)
            //        zipCheckBox.Items.Remove(item);

            //    List<string> newZipBoxItems = new List<string>(); //a list that holds all the data we will pass to the grid updater function
            //    foreach (string item in zipCheckBox.CheckedItems)
            //        newZipBoxItems.Add(item);

            //    updateGrid(newZipBoxItems); //we need to update the datagrid to remove all the elements that are no longer selectable in the zipcode box
            //}

            
        }

        private void zipCheckBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            //CheckedListBox senderCheckBox = (CheckedListBox)sender; //casts the sending object as a checkedbox
            //List<string> zipItems = new List<string>();

            //foreach (string item in senderCheckBox.CheckedItems) // add all the checked Items into our list that holds their string names.            
            //    zipItems.Add(item);

            //if (e != null) //if the function is called without an argument, which is when its being called from within another event.
            //{
            //    if (e.NewValue == CheckState.Checked) //add or remove the check box item that just changed to the list
            //        zipItems.Add(senderCheckBox.Items[e.Index].ToString());
            //    else
            //        zipItems.Remove(senderCheckBox.Items[e.Index].ToString());
            //}

            //updateGrid(zipItems);
        }

        private void updateGrid(List<string> zipContents)
        {
            //businessGrid.Rows.Clear(); //removes all the data previously in the grid.

            //if (zipContents.Count == 0) //if there are no items that are checked.
            //    return; //end the call

            //string orList = "AND city IN (SELECT city FROM business WHERE "; //building subquery to find all the cities in the listbox
            //foreach (string item in cityCheckBox.CheckedItems)
            //{
            //    Console.WriteLine(item);
            //    orList += "city = '" + item + "' OR "; // city = 'string' OR 
            //}
            //orList = orList.Substring(0, orList.Length - 3); // Cuts off the final "OR "
            //orList += ") ";

            //orList += "AND zipcode IN (SELECT zipcode FROM business WHERE "; //building subquery to find all the zipcodes in the listbox
            //foreach (string item in zipContents)
            //{
            //    Console.WriteLine(item);
            //    orList += "zipcode = '" + item + "' OR ";
            //}
            //orList = orList.Substring(0, orList.Length - 3);
            //orList += ") ";

            //// populate data into businessGrid from database with the city and state from each check box
            //using (var connection = new NpgsqlConnection(LOGININFO))
            //{
            //    connection.Open();
            //    using (var cmd = new NpgsqlCommand())
            //    {
            //        cmd.Connection = connection;
            //        cmd.CommandText = "SELECT * FROM business WHERE state = '" + stateDropDown.SelectedItem + "'" + orList + " ORDER BY state;";
            //        using (var reader = cmd.ExecuteReader())
            //        {
            //            while (reader.Read())
            //                businessGrid.Rows.Add(reader["name"], reader["zipcode"], reader["city"], reader["state"]);
            //        }
            //    }
            //    connection.Close();
            //}
        }
    }
}
