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

            foreach (var column in cols)
            {
                // Create the column headers for the data grid view.
                DataGridViewTextBoxColumn newColumn = new DataGridViewTextBoxColumn();
                newColumn.HeaderText = column;
                newColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                if (column == "business_id")
                    newColumn.Visible = false;
                businessGrid.Columns.Add(newColumn);
            }
        }

        private void initializeDropDowns()
        {
            List<string> states = queryEngine.GetStates();
            foreach (var state in states)
                stateDropDown.Items.Add(state); //populates the state drop down with all the states returned by the queryEngine            
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
                cityCheckBox.Items.Add(city);
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
                {
                    queryEngine.removeSearchParameter("zipcode", item);
                    zipCheckBox.Items.Remove(item);
                }
                updateCategories();
            }
        }

        private void zipCheckBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            CheckedListBox senderCheckBox = (CheckedListBox)sender; //casts the sending object as a checkedbox
            string newItem = zipCheckBox.Items[e.Index].ToString();

            if (e.NewValue == CheckState.Checked) //add or remove the check box item that just changed to the list            
                queryEngine.addSearchParameter("zipcode", newItem); //add the new item to the list if it is checked            
            else
                queryEngine.removeSearchParameter("zipcode", newItem);//remove the new item to the list if its unchecked              

            updateCategories();
        }

        private void updateCategories()
        {
            categoriesCheckBox.Items.Clear(); //since attributes likely have a ton of overlap, it is simpler to just clear the list and re-populate each time a new item is checked.
            foreach (string item in queryEngine.GetCategories()) // add returned categories            
                if (!categoriesCheckBox.Items.Contains(item)) // if the category is not already in the listbox
                    categoriesCheckBox.Items.Add(item);
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

            foreach (List<string> listRow in queryEngine.Search(projection))
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
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            updateGrid();
        }

        private void PlayerIDListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Fill all of the user's info textboxes
            List<List<string>> userData = queryEngine.GetUser(PlayerIDListBox.SelectedItem.ToString(), "name, average_stars, cool, funny, useful, fans, review_count, yelping_since, user_latitude, user_longitude");

            NameValue.Text = userData[1][0];
            StarsValue.Text = userData[1][1];
            CoolValue.Text = userData[1][2];
            FunnyValue.Text = userData[1][3];
            UsefulValue.Text = userData[1][4];
            FansValue.Text = userData[1][5];
            ReviewCountValue.Text = userData[1][6];
            YelpingSinceValue.Text = userData[1][7];
            LatitudeValue.Text = userData[1][8];
            LongitudeValue.Text = userData[1][9];

            if (LatitudeValue.Text == string.Empty)
                LatitudeValue.Text = "empty";

            if (LongitudeValue.Text == string.Empty)
                LongitudeValue.Text = "empty";
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
                queryEngine.PostReview(WriteReviewTextBox_Review.Text, int.Parse(ReviewStarsDropDown.SelectedItem as string), currBusId, currUserId);
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

        private void UserNameEntryTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                List<string> userIds = queryEngine.GetUsers(UserNameEntryTextBox.Text);

                PlayerIDListBox.Items.Clear();

                foreach (string id in userIds)
                    PlayerIDListBox.Items.Add(id);


                e.Handled = true;
            }
        }
    }
}
