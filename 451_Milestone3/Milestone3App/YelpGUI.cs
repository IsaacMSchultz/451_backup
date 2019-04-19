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
        string[] cols = { "Name", "Address", "City", "State", "Stars Shown", "Reviews", "Checkins", "Stars", "Open?", "business_id", "Distance" }; //column titles for the main datagridview
        string[] friendsCol = { "Name", "Average Stars", "Yelping Since" };
        string[] favBusCol = { "Name", "Stars", "City", "Zipcode", "Address" };
        string[] friendsRevCol = { "Name", "Business", "City", "Review" };
        string[] reviewCols = { "Stars", "Date", "Text", "Useful", "Funny", "Cool" }; //Column headers for the review form that can be opened from the GUI
        string projection; //selected columns to show in the database. Need to implement column constructors based on the projection instead of the cols[] array.

        //TODO: change to functions so that debugging global variables is less ambiguous.
        string currBusId; //global variable for the currend businessId
        string currUserId;

        // private variables used to generate a random ID.
        private static Random random = new Random();
        const string chars = "abcdefghijklmnopqrstuvwyxzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789_- ";        

        private static string LOGININFO = "Host=localhost; Username=postgres; Password=greatPassword; Database=milestone2db"; // Defines our connection to local databus
        //private static string LOGININFO = "Host=35.230.13.126; Username=postgres; Password=oiAv4Kmdup8Pd4vd; Database=milestone2db"; // Defines our connection to cloud hosted databus

        /// <summary>
        /// Constructor for a yelpGUI.
        /// </summary>
        /// <param name="proj">A projection selector for a query to only return certain columns.</param>
        public YelpGUI(string proj = "name, address, city, state, stars, review_count, num_checkins, reviewRating, is_open, business_id, distance")
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
                
                if (column == "Name")
                    newColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                else
                    newColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

                if (column == "business_id" || column == "Stars Shown")
                    newColumn.Visible = false;
                businessGrid.Columns.Add(newColumn);
            }

            foreach (var column in friendsCol)
            {
                DataGridViewTextBoxColumn newColumn = new DataGridViewTextBoxColumn();
                newColumn.HeaderText = column;
                
                FriendsGrid.Columns.Add(newColumn);
            }

            foreach (var column in favBusCol)
            {
                DataGridViewTextBoxColumn newColumn = new DataGridViewTextBoxColumn();
                newColumn.HeaderText = column;

                FavoriteBusinessGrid.Columns.Add(newColumn);
            }

            foreach (var column in friendsRevCol)
            {
                //dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                
                DataGridViewTextBoxColumn newColumn = new DataGridViewTextBoxColumn();
                newColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                newColumn.HeaderText = column;

                FriendsReviewsGrid.Columns.Add(newColumn);
            }
        }

        /// <summary>
        /// Initializes the state dropdown with a list of states from the database.
        /// </summary>
        private void initializeDropDowns()
        {
            List<string> states = queryEngine.GetStates();
            foreach (var state in states)
                stateDropDown.Items.Add(state); //populates the state drop down with all the states returned by the queryEngine            
        }

        /// <summary>
        /// When a state is selected, all checkboxes are cleared and then the city checkbox is updated with a list of cities.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
            updateGrid();
        }

        /// <summary>
        /// When an item in the city checkbox is checked, this fulnction will update the contents of the zipcode checkbox as well as
        /// update the contents of the categories checkbox, as there may be some cascading changes if an item that was included in the categories
        /// was dependent on a check from the cities checkbox that was chanaged.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
            updateGrid();
        }

        /// <summary>
        /// When an item in the zipcode checkbox is checked, this function will update the contents of the categories checkbox and add the checked item to
        /// the search parameters in the query engine.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void zipCheckBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            CheckedListBox senderCheckBox = (CheckedListBox)sender; //casts the sending object as a checkedbox
            string newItem = zipCheckBox.Items[e.Index].ToString();

            if (e.NewValue == CheckState.Checked) //add or remove the check box item that just changed to the list            
                queryEngine.addSearchParameter("zipcode", newItem); //add the new item to the list if it is checked            
            else
                queryEngine.removeSearchParameter("zipcode", newItem);//remove the new item to the list if its unchecked              

            updateCategories();
            updateGrid();
        }

        /// <summary>
        /// Updates the checkboxes in the categories list based on the queryEngine
        /// </summary>
        private void updateCategories()
        {
            categoriesCheckBox.Items.Clear(); //since attributes likely have a ton of overlap, it is simpler to just clear the list and re-populate each time a new item is checked.
            foreach (string item in queryEngine.GetCategories()) // add returned categories            
                if (!categoriesCheckBox.Items.Contains(item)) // if the category is not already in the listbox
                    categoriesCheckBox.Items.Add(item);
        }

        /// <summary>
        /// When an item in the categories checkbox is checked, update its value in the queryEngine and update the datagrid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void categoriesCheckBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            CheckedListBox senderCheckBox = (CheckedListBox)sender; //casts the sending object as a checkedbox
            string newItem = categoriesCheckBox.Items[e.Index].ToString();

            if (e.NewValue == CheckState.Checked) //add or remove the check box item that just changed to the list            
                queryEngine.addSearchParameter("category_name", newItem); //add the new item to the list if it is checked            
            else
                queryEngine.removeSearchParameter("category_name", newItem);//remove the new item to the list if its unchecked
            updateGrid();
        }

        /// <summary>
        /// Runs a search with the current query parameters that were built for the queryEngine.
        /// Updates the datagridview with the data returned from the queryEngine.
        /// </summary>
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

        /// <summary>
        /// Update the datagrid when the search button is clicked!
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SearchButton_Click(object sender, EventArgs e)
        {
            updateGrid();
        }

        /// <summary>
        /// When the user selects an ID from the list it should populate the user data section with that user's data.   
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PlayerIDListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Fill all of the user's info textboxes
            List<List<string>> userData = queryEngine.GetUser(PlayerIDListBox.SelectedItem.ToString(), "name, average_stars, cool, funny, useful, fans, review_count, yelping_since, user_latitude, user_longitude, user_id");

            NameValue.Text = userData[1][0];
            StarsValue.Text = userData[1][1];
            CoolValue.Text = userData[1][2];
            FunnyValue.Text = userData[1][3];
            UsefulValue.Text = userData[1][4];
            FansValue.Text = userData[1][5];
            YelpingSinceValue.Text = userData[1][7];
            LatitudeValue.Text = userData[1][8];
            LongitudeValue.Text = userData[1][9];

            if (LatitudeValue.Text == string.Empty)
                LatitudeValue.Text = "empty";

            if (LongitudeValue.Text == string.Empty)
                LongitudeValue.Text = "empty";

            currUserId = userData[1][10]; //set the current user id to what was returned by the query.

            updateFriendsGrid();
            updateFavBusinessGrid();
            updateFriendsRevGrid();

            queryEngine.SelectUser(currUserId);
        }

        /// <summary>
        /// When the user clicks on a cell in the datagridview, the business they clicked should become the currently selected business.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void businessGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {            
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {
                businessNameTextBox_Review.Text = (string)businessGrid[0, e.RowIndex].Value;
                currBusId = (string)businessGrid[9, e.RowIndex].Value;

                ShowReviewsButton.Enabled = true; //enable the button to show reviews after we click one

                MapButton.Enabled = true;
            }
        }

        /// <summary>
        /// When the user clicks the submit review button, it uses the queryEngine to post the review.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SubmitReviewButton_Click(object sender, EventArgs e)
        {
            if (currBusId != "" && currUserId != "" && ReviewStarsDropDown.SelectedItem as string != "Review Stars")
            {
                queryEngine.PostReview(WriteReviewTextBox_Review.Text, int.Parse(ReviewStarsDropDown.SelectedItem as string), currBusId, currUserId);
            }
        }

        /// <summary>
        /// When the user starts typing in the write review box, the submit review button should be enabled.       
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// When the user selects a rating to give a review, we should enable the submit review button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ReviewStarsDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (WriteReviewTextBox_Review.Text != "")
            {
                SubmitReviewButton.Enabled = true;
            }
        }
        /// <summary>
        /// When the user clicks the "Show Reviews" Button, it will open a new form displaying all the reviews for the selected business.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShowReviewsButton_Click(object sender, EventArgs e)
        {
            // create a new datagridview to pass to the new form that will open to show the reviews.
            DataGridView ReviewGrid = new DataGridView();
            ReviewGrid.RowHeadersVisible = false;

            // Build the columns and headers for the new form
            foreach (var column in reviewCols)
            {
                // Create the column headers for the data grid view.
                DataGridViewTextBoxColumn newColumn = new DataGridViewTextBoxColumn();
                newColumn.HeaderText = column;

                if (column == "text")
                    newColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                else
                    newColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

                ReviewGrid.Columns.Add(newColumn);
            }

            //Query the database for the reviews of the current business
            List<List<string>> reviews = queryEngine.GetReviews(currBusId, "review_stars, date, text, useful_vote, funny_vote, cool_vote");
            reviews.RemoveAt(0); //we dont need the headers so we can remove them.

            // Add all the returned reviews to the new datagrid
            foreach (List<string> review in reviews)
                ReviewGrid.Rows.Add(review[0], review[1], review[2], review[3], review[4], review[5]);

            // Make the new form open up and show it to the user.
            ReviewForm reviewWindow = new ReviewForm(ReviewGrid);
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

                //updateFriendsGrid();
            }
        }
        

        // Should consider *Templatizing* this to work for multiple DataGrids
        private void updateFriendsGrid()
        {
            int row = 0, col = 0;
            FriendsGrid.Rows.Clear(); //removes all the data previously in the grid.            

            foreach (List<string> listRow in queryEngine.GetFriends(currUserId))
            {
                if (row > 0)
                {
                    FriendsGrid.Rows.Add(); //the index of the new row
                    foreach (string item in listRow)
                        FriendsGrid.Rows[row - 1].Cells[col++].Value = item;
                    col = 0;
                }
                row++;
            }
        }

        // Should consider *Templatizing* this to work for multiple DataGrids
        private void updateFavBusinessGrid()
        {
            //FavoriteBusinessGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            

            int row = 0, col = 0;
            FavoriteBusinessGrid.Rows.Clear(); //removes all the data previously in the grid.            

            foreach (List<string> listRow in queryEngine.GetFavBusinesses(currUserId))
            {
                if (row > 0)
                {
                    FavoriteBusinessGrid.Rows.Add(); //the index of the new row
                    foreach (string item in listRow)
                        FavoriteBusinessGrid.Rows[row - 1].Cells[col++].Value = item;
                    col = 0;
                }
                row++;
            }
        }

        private void updateFriendsRevGrid()
        {
            int row = 0, col = 0;  
            FriendsReviewsGrid.Rows.Clear();

            foreach (List<string> listRow in queryEngine.GetFriendsReview(currUserId))
            {
                if (row > 0)
                {
                    FriendsReviewsGrid.Rows.Add(); //the index of the new row
                    foreach (string item in listRow)
                        FriendsReviewsGrid.Rows[row - 1].Cells[col++].Value = item;
                    col = 0;
                }
                row++;
            }
        }

        private void MapButton_Click(object sender, EventArgs e)
        {
            //Form mapWindow = new Form();
            //MapForm mapWindow = new MapForm(currBusId);
            //mapWindow.Show();
            MapForm mapTest = new MapForm(currBusId);
            mapTest.Show();
        }

        private void EditBtn_Click(object sender, EventArgs e)
        {
            EditBtn.Enabled = false;
            UpdateBtn.Enabled = true;
            LongitudeValue.Enabled = true;
            LatitudeValue.Enabled = true;
        }

        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            double lat, lon;
            if (double.TryParse(LatitudeValue.Text, out lat) && double.TryParse(LongitudeValue.Text, out lon))
            {
                // Update the User's location values
                queryEngine.updateUserLocation(currUserId, lat, lon);

                UpdateBtn.Enabled = false;
                EditBtn.Enabled = true;
                LatitudeValue.Enabled = false;
                LongitudeValue.Enabled = false;
            }
            else
            {
                MessageBox.Show("Please enter valid Latitude and Longitude values.");
            }
        }
    }
}
