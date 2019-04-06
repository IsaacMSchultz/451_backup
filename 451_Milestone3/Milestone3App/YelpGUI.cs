using Npgsql;
using Npgsql.Schema;
using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using static System.Windows.Forms.CheckedListBox;
using QueryEngine1;
using System.Linq;

namespace Milestone2App
{
    public partial class YelpGUI : Form
    {
        QueryEngine queryEngine;
        List<Business> dataGridBusinesses;
        string[] cols = { "name", "address", "city", "state", "stars", "review_count", "num_checkins", "reviewRating", "is_open", "business_id" };
        string projection;

        string currBusId;
        string currUserId;

        private static Random random = new Random();
        const string chars = "abcdefghijklmnopqrstuvwyxzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789_- ";

        //private BindingSource businessBindingSource; //allows the datagridview to automatically update itself from the dataGridBusinesses.

        private static string LOGININFO = "Host=localhost; Username=postgres; Password=greatPassword; Database=milestone2db"; // Defines our connection to local databus
                                                                                                                              //private static string LOGININFO = "Host=35.230.13.126; Username=postgres; Password=oiAv4Kmdup8Pd4vd; Database=milestone2db"; // Defines our connection to cloud hosted databus



        public YelpGUI(string proj = "name, address, city, state, stars, review_count, num_checkins, reviewRating, is_open, business_id")
        {
            queryEngine = new QueryEngine();
            List<string> businessIds = new List<string>();

            currBusId = "";
            currUserId = "";
            projection = proj;

            InitializeComponent();
            initializeDropDowns();
            //businessBindingSource = new BindingSource(dataGridBusinesses);
            //businessGrid.DataSource = businessBindingSource; //tell the businessGrid to read the data from the list of businesses.            

            foreach (var column in cols)
            {
                // Create the column headers for the data grid view.
                DataGridViewTextBoxColumn newColumn = new DataGridViewTextBoxColumn();
                newColumn.HeaderText = column;
                //if (column == "name")
                //    newColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                //else
                newColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                businessGrid.Columns.Add(newColumn);
            }
        }

        private void initializeDropDowns()
        {
            List<string> states = queryEngine.GetStates();
            foreach (var state in states)
            {
                stateDropDown.Items.Add(state); //populates the state drop down with all the states returned by the queryEngine
                //queryEngine.addSearchParameter("state", state); //we dont want to add all these states to the search paraemeter!
            }
        }

        private void stateDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox box = (ComboBox)sender; //casts sender as a ComboBox

            cityCheckBox.Items.Clear();
            zipCheckBox.Items.Clear();
            categoriesCheckBox.Items.Clear();

            queryEngine.resetSearchParameter("state", (string)box.SelectedItem); //by using setSearchParameter, we ensure that there is only ever one state parameter.
            List<string> cities = queryEngine.GetCities(); //get the list of cities 

            foreach (string city in queryEngine.GetCities())
            {
                cityCheckBox.Items.Add(city);
            }
        }

        private void cityCheckBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            CheckedListBox CheckBox = (CheckedListBox)sender; //casts the sending object as a checkedbox
            string newItem = cityCheckBox.Items[e.Index].ToString();
            List<string> newZips = queryEngine.GetNewZips(newItem);

            //since zipcodes are always mutually exclusive, we can add and remove them based soley on the contetn of the city checkbox changing.
            if (e.NewValue == CheckState.Checked) //add or remove the check box item that just changed to the list
            {
                queryEngine.addSearchParameter("city", newItem);
                foreach (string item in newZips)
                    zipCheckBox.Items.Add(item);
            }
            else
            {
                queryEngine.removeSearchParameter("city", newItem);
                foreach (string item in newZips)
                    zipCheckBox.Items.Remove(item);
            }
        }

        private void zipCheckBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            CheckedListBox senderCheckBox = (CheckedListBox)sender; //casts the sending object as a checkedbox
            string newItem = zipCheckBox.Items[e.Index].ToString();

            categoriesCheckBox.Items.Clear(); //since attributes likely have a ton of overlap, it is simpler to just clear the list and re-populate each time a new item is checked.

            if (e.NewValue == CheckState.Checked) //add or remove the check box item that just changed to the list            
                queryEngine.addSearchParameter("zipcode", newItem); //add the new item to the list if it is checked            
            else
                queryEngine.removeSearchParameter("zipcode", newItem);//remove the new item to the list if its unchecked              

            List<string> attributes = queryEngine.GetCategories();

            foreach (string item in attributes) // add returned categories
            {
                if (!categoriesCheckBox.Items.Contains(item)) // if the category is not already in the listbox
                    categoriesCheckBox.Items.Add(item);
            }
        }


        private void categoriesCheckBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            CheckedListBox senderCheckBox = (CheckedListBox)sender; //casts the sending object as a checkedbox
            string newItem = categoriesCheckBox.Items[e.Index].ToString();

            if (e.NewValue == CheckState.Checked) //add or remove the check box item that just changed to the list            
                queryEngine.addSearchParameter("category_name", newItem); //add the new item to the list if it is checked            
            else
                queryEngine.removeSearchParameter("category_name", newItem);//remove the new item to the list if its unchecked               
        }

        private void updateGrid(/*List<string> categoryContents*/) //way to call before the ItemCheck function completes (old ghetto way)
        {
            int row = 0, col = 0;
            businessGrid.Rows.Clear(); //removes all the data previously in the grid.
            var search = queryEngine.Search(projection);

            foreach (List<string> listRow in search)
            {
                if (row > 0)
                {
                    businessGrid.Rows.Add(); //the index of the new row
                    foreach (string item in listRow)
                        businessGrid.Rows[row - 1].Cells[col++].Value = item;
                    col = 0;
                }
                row++;                
            }
            Console.WriteLine(search[0][0]);
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            updateGrid();
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
            currUserId = PlayerIDListBox.SelectedItem.ToString();

            using (var connection = new NpgsqlConnection(LOGININFO))
            {
                connection.Open();
                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = connection;
                    // SELECT * from yelpuser WHERE yelpuser.user_id = 'QGauzwshJlwHyMqT--CGiQ';
                    cmd.CommandText = "SELECT * from yelpuser WHERE yelpuser.user_id = '" + currUserId + "' ORDER BY user_id;";
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
                        }
                    }
                }
                connection.Close();
            }
        }

        private void businessGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //SubmitReviewButton
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {
                businessNameTextBox_Review.Text = (string)businessGrid[0, e.RowIndex].Value;
                currBusId = (string)businessGrid[9, e.RowIndex].Value;

                ShowReviewsButton.Enabled = true; //enable the button to show reviews after we click one
            }
        }

        private void SubmitReviewButton_Click(object sender, EventArgs e)
        {
            if (currBusId != "" && currUserId != "" && ReviewStarsDropDown.SelectedItem as string != "Review Stars")
            {
                string reviewID = new string(Enumerable.Repeat(chars, 22).Select(s => s[random.Next(s.Length)]).ToArray()); //makes a random 22 charachter string

                using (var connection = new NpgsqlConnection(LOGININFO))
                {
                    connection.Open();
                    using (var cmd = new NpgsqlCommand())
                    {
                        cmd.Connection = connection;
                        cmd.CommandText = "INSERT INTO review VALUES ('" + reviewID + "', '" + currBusId + "', '" + currUserId + "', '" + ReviewStarsDropDown.SelectedItem +
                            "', NOW(), '" + WriteReviewTextBox_Review.Text + "', 0, 0, 0);";
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
        }

        private void WriteReviewTextBox_Review_TextChanged(object sender, EventArgs e)
        {
            if (WriteReviewTextBox_Review.Text != "" && ReviewStarsDropDown.SelectedItem as string != "Review Stars")
            {
                SubmitReviewButton.Enabled = true;
            }
            else if (SubmitReviewButton.Enabled == true)
            {
                SubmitReviewButton.Enabled = false;
            }
        }

        private void ReviewStarsDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (WriteReviewTextBox_Review.Text != "")
            {
                SubmitReviewButton.Enabled = true;
            }
        }

        private void ShowReviewsButton_Click(object sender, EventArgs e)
        {

            ReviewForm reviewWindow = new ReviewForm(currBusId);
            reviewWindow.Show();

        }
    }
}
