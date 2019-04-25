using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Windows.Media;
using Microsoft.Maps.MapControl.WPF;
using Npgsql;
using QueryEngine1;
using SpicyMap;

namespace Milestone2App {
    public partial class YelpGUI : Form {

        QueryEngine queryEngine; //class used for database access and search
        MapNamesToAttrValPair mapNamesToAttrValPair; // A hashmap-like class for finding the ID's for attribute searching

        // Used for dynamically creating different datagridviews
        string[] cols = { "Name", "Address", "City", "State", "Stars", "Reviews", "Checkins", "Avg Review Rating", "Open?", "business_id", "Distance" }; //column titles for the main datagridview
        string[] reviewCols = { "Stars", "Date", "Text", "Useful", "Funny", "Cool" }; //Column headers for the review form that can be opened from the GUI
        string[] checkinsCols = { "Day", "Time", "Count" }; //Column headers for the review form that can be opened from the GUI

        string projection; //selected columns to show in the database. Need to implement column constructors based on the projection instead of the cols[] array.

        // Instance of MapForm to access map with
        MapForm mapTest = new MapForm ();

        //TODO: change to functions so that debugging global variables is less ambiguous.
        string currBusId; //global variable for the currend businessId
        string currUserId;
        string currAdminId;

        // private variables used to generate a random ID.
        private static Random random = new Random ();
        const string chars = "abcdefghijklmnopqrstuvwyxzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789_- ";

        /**
         * ! YelpGUI
         * ? Initialization functions
         */

        /// <summary>
        /// Constructor for a yelpGUI.
        /// </summary>
        /// <param name="proj">A projection selector for a query to only return certain columns.</param>
        public YelpGUI (string proj = "name, address, city, state, stars, review_count, num_checkins, reviewRating, is_open, business_id, distance") {

            // ? initialize variables
            queryEngine = new QueryEngine ();
            List<string> businessIds = new List<string> ();
            mapNamesToAttrValPair = new MapNamesToAttrValPair ();
            currBusId = string.Empty;
            currUserId = string.Empty;
            projection = proj;

            InitializeComponent ();
            InitializeDropDowns (); //Initialize the state list dropdown

            // Initialize map to be able to scroll
            mapTest.userControl11.map.Focus ();

            // By default we do not want the user to be able to click this button
            RemoveFavBtn.Enabled = false;

            // Create the column headers for the data grid view.
            foreach (var column in cols) {
                DataGridViewTextBoxColumn newColumn = new DataGridViewTextBoxColumn ();
                newColumn.HeaderText = column;

                if (column == "Name")
                    newColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells; //Can change this to fill depending on if we want to make our app window larger
                else
                    newColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

                if (column == "business_id") //TODO: see what this does???
                    newColumn.Visible = false;
                businessGrid.Columns.Add (newColumn);
            }
        }

        /// <summary>
        /// Initializes the state dropdown with a list of states from the database.
        /// </summary>
        private void InitializeDropDowns () {
            List<string> states = queryEngine.GetStates ();
            foreach (var state in states)
                stateDropDown.Items.Add (state); //populates the state drop down with all the states returned by the queryEngine            
        }

        /**
         * ! Business Page
         * ? Search Functionality
         */

        /// <summary>
        /// When a state is selected, all checkboxes are cleared and then the city checkbox is updated with a list of cities.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StateDropDown_SelectedIndexChanged (object sender, EventArgs e) {
            ComboBox box = (ComboBox) sender; //casts sender as a ComboBox

            cityCheckBox.Items.Clear ();
            zipCheckBox.Items.Clear ();
            categoriesCheckBox.Items.Clear ();

            queryEngine.ResetSearchParameter ("state", (string) box.SelectedItem); //by using setSearchParameter, we ensure that there is only ever one state parameter.
            List<string> cities = queryEngine.GetCities (); //get the list of cities 

            foreach (string city in cities)
                cityCheckBox.Items.Add (city);
            //updateGrid(); //This is really slow because we end up loading thousands of businesses. THe user can still load them by clicking the search button.
        }

        /// <summary>
        /// When an item in the city checkbox is checked, this fulnction will update the contents of the zipcode checkbox as well as
        /// update the contents of the categories checkbox, as there may be some cascading changes if an item that was included in the categories
        /// was dependent on a check from the cities checkbox that was chanaged.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CityCheckBox_ItemCheck (object sender, ItemCheckEventArgs e) {
            CheckedListBox CheckBox = (CheckedListBox) sender; //casts the sending object as a checkedbox
            string newItem = cityCheckBox.Items[e.Index].ToString ();
            List<string> newZips = queryEngine.GetNewZips (newItem);

            //since zipcodes are always mutually exclusive, we can add and remove them based soley on the contetn of the city checkbox changing.
            if (e.NewValue == CheckState.Checked) //add or remove the check box item that just changed to the list
            {
                queryEngine.AddSearchParameter ("city", newItem);
                foreach (string item in newZips)
                    zipCheckBox.Items.Add (item);
            } else {
                queryEngine.RemoveSearchParameter ("city", newItem);
                foreach (string item in newZips) {
                    queryEngine.RemoveSearchParameter ("zipcode", item);
                    zipCheckBox.Items.Remove (item);
                }
                UpdateCategories ();
            }
            UpdateGrid ();
        }

        /// <summary>
        /// When an item in the zipcode checkbox is checked, this function will update the contents of the categories checkbox and add the checked item to
        /// the search parameters in the query engine.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ZipCheckBox_ItemCheck (object sender, ItemCheckEventArgs e) {
            CheckedListBox senderCheckBox = (CheckedListBox) sender; //casts the sending object as a checkedbox
            string newItem = zipCheckBox.Items[e.Index].ToString ();

            if (e.NewValue == CheckState.Checked) //add or remove the check box item that just changed to the list            
                queryEngine.AddSearchParameter ("zipcode", newItem); //add the new item to the list if it is checked            
            else
                queryEngine.RemoveSearchParameter ("zipcode", newItem); //remove the new item to the list if its unchecked              

            UpdateCategories ();
            UpdateGrid ();
        }

        /// <summary>
        /// When an item in the categories checkbox is checked, update its value in the queryEngine and update the datagrid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CategoriesCheckBox_ItemCheck (object sender, ItemCheckEventArgs e) {
            CheckedListBox senderCheckBox = (CheckedListBox) sender; //casts the sending object as a checkedbox
            string newItem = categoriesCheckBox.Items[e.Index].ToString ();

            if (e.NewValue == CheckState.Checked) //add or remove the check box item that just changed to the list            
                queryEngine.AddSearchParameter ("category_name", newItem); //add the new item to the list if it is checked            
            else
                queryEngine.RemoveSearchParameter ("category_name", newItem); //remove the new item to the list if its unchecked
            UpdateGrid ();
        }

        //TODO: implement attribute support in the queryEngine -- if statement looking for "attribute" that puts the list of elements in an AND list inside of the subquery.
        //      Assuming that attributes only have a max of two values
        //Implementing one function to add or remove ALL attribute checklists
        private void AttributesPanel_ItemCheck (object sender, EventArgs e) {
            CheckBox senderCheckBox = (CheckBox) sender; //casts the sending object as a CheckBox
            Console.WriteLine (senderCheckBox.Text);
            Tuple<string, string> attr = mapNamesToAttrValPair.MapFrom (senderCheckBox.Text); //accesses a map that uses sender names to get the values needed from the database

            if (senderCheckBox.Checked == true) //add or remove the check box item that just changed to the list
                queryEngine.AddSearchParameter (attr.Item1, attr.Item2); //add the new item to the list if it is checked
            else
                queryEngine.RemoveSearchParameter (attr.Item1, attr.Item2); //remove the new item to the list if its unchecked

            UpdateGrid ();
        }

        /// <summary>
        /// Update the datagrid when the search button is clicked!
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SearchButton_Click (object sender, EventArgs e) {
            UpdateGrid ();
        }

        /// <summary>
        /// Runs a search with the current query parameters that were built for the queryEngine.
        /// Updates the datagridview with the data returned from the queryEngine.
        /// </summary>
        private void UpdateGrid ( /*List<string> categoryContents*/ ) //way to call before the ItemCheck function completes (old ghetto way)
        {
            int row = 0, col = 0;
            businessGrid.Rows.Clear (); //removes all the data previously in the grid.            

            foreach (List<string> listRow in queryEngine.Search (projection)) {
                if (row > 0) {
                    businessGrid.Rows.Add (); //the index of the new row
                    foreach (string item in listRow)
                        businessGrid.Rows[row - 1].Cells[col++].Value = item;
                    col = 0;
                }
                row++;
            }
        }

        /// <summary>
        /// Updates the checkboxes in the categories list based on the queryEngine
        /// </summary>
        private void UpdateCategories () {
            List<string> categorylist = queryEngine.GetCategories ();
            List<string> checkedCategories = queryEngine.GetCheckedCategories ();
            categoriesCheckBox.Items.Clear (); //since attributes likely have a ton of overlap, it is simpler to just clear the list and re-populate each time a new item is checked.

            foreach (string item in categorylist) // add returned categories   
            {
                int index = categoriesCheckBox.Items.Add (item); //adds the item and gets the index that it was added.
                if (checkedCategories.Contains (item)) // if that item was included in the checked list, then show that it is checked on the grid.
                {
                    categoriesCheckBox.SetItemChecked (index, true);
                    checkedCategories.Remove (item); //remove the new item to the list if its checked
                }
            }

            //Remove each item that is not show in from the search parameters in the queryEngine
            foreach (string item in checkedCategories) {
                queryEngine.RemoveSearchParameter ("category_name", item); //remove the new item to the list if its unchecked
            }
        }

        /**
         * ! Business Page
         * ? Business Info Functionality
         */

        /// <summary>
        /// When the user clicks on a cell in the datagridview, the business they clicked should become the currently selected business.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BusinessGrid_CellContentClick (object sender, DataGridViewCellEventArgs e) {
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0) {
                currBusId = (string) businessGrid[9, e.RowIndex].Value; //set global currBusId to the current business ID. Probably want to change this to a function in the future            
                string today = DateTime.Today.DayOfWeek.ToString (); //get the current day of the week from the local machine

                businessNameTextBox_Review.Text = (string) businessGrid[0, e.RowIndex].Value; //Show business name
                Address_Textbox.Text = (string) businessGrid[1, e.RowIndex].Value; //Show the business address
                DayOfTheWeek_Textbox.Text = today; //put the day of the week in the hours textbox

                // replace the categories checkbox with all the categories that the selected business has
                string categoriesStr = string.Empty;
                List<string> categories = queryEngine.GetCategories (currBusId);
                if (categories.Count > 0) {
                    foreach (string category in categories) {
                        categoriesStr += category + ", ";
                    }
                    categoriesStr = categoriesStr.Substring (0, categoriesStr.Length - 2); // Cuts off the final ", "
                }
                Categories_Textbox.Text = categoriesStr;

                UpdateBusinessPageAttributes ();

                //Show the business' hours if it has any for the current day.
                List<List<string>> hours = queryEngine.GetHoursForDay (currBusId, today); // query the database for the hours of a business
                if (hours.Count > 1) // If the query returned some hours
                {
                    Opens_Textbox.Text = hours[1].Count > 0 ? hours[1][0] : "N/A"; //show N/A if there are no hours at that time
                    Closes_Textbox.Text = hours[1].Count > 1 ? hours[1][1] : "N/A";
                }

                // update the friends who reviewd grid
                UpdateFriendsWhoReviewed ();

                //enable the buttons now that there is a business selected
                ShowReviewsButton.Enabled = true;
                ShowCheckinsButton.Enabled = true;
                AddToFavoritesButton.Enabled = true;
                CheckInButton.Enabled = true;
                MapButton.Enabled = true;
            }
        }

        private bool UpdateBusinessPageAttributes () {
            if (currBusId != string.Empty) {
                // replace the attributes checkbox with all the categories that the selected business has
                string attributesStr = string.Empty;
                List<List<string>> attributes = queryEngine.GetAttributes (currBusId);
                if (attributes.Count > 1) {
                    for (int i = 1; i < attributes.Count; i++)
                        attributesStr += attributes[i][0] + ":" + attributes[i][1] + ", ";

                    attributesStr = attributesStr.Substring (0, attributesStr.Length - 2); // Cuts off the final ", "
                }
                Attributes_Textbox.Text = attributesStr;
                return true;
            }
            return false;
        }

        private void UpdateFriendsWhoReviewed () {
            int row = 0, col = 0;
            FriendsWhoRevewedGrid.Rows.Clear (); //removes all the data previously in the grid.  

            foreach (List<string> listRow in queryEngine.GetFriendsWhoReviewedBus (currUserId, currBusId)) {
                if (row > 0) {
                    FriendsWhoRevewedGrid.Rows.Add (); //the index of the new row
                    foreach (string item in listRow)
                        FriendsWhoRevewedGrid.Rows[row - 1].Cells[col++].Value = item;
                    col = 0;
                }
                row++;
            }
        }

        /**
         * ! Business Page
         * ? Submit Review Functionality
         */

        /// <summary>
        /// When the user clicks the submit review button, it uses the queryEngine to post the review.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SubmitReviewButton_Click (object sender, EventArgs e) {
            if (currBusId != string.Empty && currUserId != string.Empty && ReviewStarsDropDown.SelectedItem != null) {
                queryEngine.PostReview (WriteReviewTextBox_Review.Text, int.Parse (ReviewStarsDropDown.SelectedItem as string), currBusId, currUserId);
                UpdateGrid();
                return;
            }
            if (currUserId == string.Empty)
                MessageBox.Show ("Please select a user to sign in as.");
            if (ReviewStarsDropDown.SelectedItem == null)
                MessageBox.Show ("Please select a stars rating.");
            if (currBusId == string.Empty)
                MessageBox.Show ("Please select a business.");

            //UpdateGrid();
            //SearchButton_Click(null, null);
        }

        /// <summary>
        /// When the user starts typing in the write review box, the submit review button should be enabled.       
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WriteReviewTextBox_Review_TextChanged (object sender, EventArgs e) {
            if (WriteReviewTextBox_Review.Text != string.Empty && ReviewStarsDropDown.SelectedItem as string != "Review Stars")
                SubmitReviewButton.Enabled = true;
            else if (SubmitReviewButton.Enabled == true)
                SubmitReviewButton.Enabled = false;
        }

        /// <summary>
        /// When the user selects a rating to give a review, we should enable the submit review button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ReviewStarsDropDown_SelectedIndexChanged (object sender, EventArgs e) {
            if (WriteReviewTextBox_Review.Text != string.Empty) {
                SubmitReviewButton.Enabled = true;
            }
        }

        /**
         * ! Business Page
         * ? Business Info Buttons Functionality
         */

        /// <summary>
        /// When the user clicks the "Show Reviews" Button, it will open a new form displaying all the reviews for the selected business.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShowReviewsButton_Click (object sender, EventArgs e) {
            foreach (Form form in Application.OpenForms) {
                if (form is ReviewForm) {
                    form.Hide ();
                }
            }

            // create a new datagridview to pass to the new form that will open to show the reviews.
            DataGridView ReviewGrid = new DataGridView ();
            ReviewGrid.RowHeadersVisible = false;

            // Build the columns and headers for the new form
            foreach (var column in reviewCols) { // Create the column headers for the data grid view.        
                DataGridViewTextBoxColumn newColumn = new DataGridViewTextBoxColumn ();
                newColumn.HeaderText = column;

                // Set autosize mode
                if (column == "text")
                    newColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                else
                    newColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

                ReviewGrid.Columns.Add (newColumn); //add the column to the datagridview
            }

            //Query the database for the reviews of the current business
            List<List<string>> reviews = queryEngine.GetReviews (currBusId, "review_stars, date, text, useful_vote, funny_vote, cool_vote");
            reviews.RemoveAt (0); //we dont need the headers so we can remove them.

            // Add all the returned reviews to the new datagrid
            foreach (List<string> review in reviews)
                ReviewGrid.Rows.Add (review[0], review[1], review[2], review[3], review[4], review[5]);

            // Make the new form open up and show it to the user.
            ReviewForm reviewWindow = new ReviewForm (ReviewGrid);
            reviewWindow.Show ();
        }

        private void ShowCheckinsButton_Click (object sender, EventArgs e) {
            foreach (Form form in Application.OpenForms)
            {
                if (form is ReviewForm)
                    form.Hide();
            }

            // Launch check-in graph UI

            CheckInChart.MainWindow cic = new CheckInChart.MainWindow(currBusId);
            cic.Show();

            // create a new datagridview to pass to the new form that will open to show the reviews.
            DataGridView CheckinsGrid = new DataGridView();
            CheckinsGrid.RowHeadersVisible = false;

            // Build the columns and headers for the new form
            foreach (var column in checkinsCols)
            {
                // Create the column headers for the data grid view.
                DataGridViewTextBoxColumn newColumn = new DataGridViewTextBoxColumn();
                newColumn.HeaderText = column;

                newColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells; //make the size fo the columns be only the size of the data inside them

                CheckinsGrid.Columns.Add(newColumn);
            }

            //Query the database for the reviews of the current business
            List<List<string>> checkins = queryEngine.GetCheckins(currBusId, "day, to_char(time, 'HH12:MI AM'), count");
            checkins.RemoveAt(0); //we dont need the headers so we can remove them.

            // Add all the returned reviews to the new datagrid
            foreach (List<string> checkin in checkins)
                CheckinsGrid.Rows.Add(checkin[0], checkin[1], checkin[2]);

            // Make the new form open up and show it to the user.
            ReviewForm checkinsWindow = new ReviewForm(CheckinsGrid);
            checkinsWindow.Show();

            int width = 0; //find the width of all the columns and makes that the size of the window
            foreach (DataGridViewColumn column in CheckinsGrid.Columns)
                if (column.Visible == true)
                    width += column.Width;
            width += 40;
            checkinsWindow.Size = new System.Drawing.Size(width, checkinsWindow.Size.Height);
        }

        private void MapButton_Click (object sender, EventArgs e) {
            // Remove all pins on the map
            mapTest.userControl11.map.Children.Clear ();

            //List<double> userLocation = queryEngine.GetUserLocation(currUserId);
            List<string> selectedBusinesses = new List<string> ();
            Microsoft.Maps.MapControl.WPF.Location userCoord = null;
            Microsoft.Maps.MapControl.WPF.Location busCoord = null;

            // Resets the map each time the button is clicked, even if it is already open
            if (this.mapTest.Visible) {
                mapTest.Close ();
            }

            if (currUserId != string.Empty) {
                //MessageBox.Show("Log in to a user to view business on map");
                //return;
                List<double> userLocation = queryEngine.GetUserLocation (currUserId);

                // Only set the map view to the user's position if the user has both a lat and long value entered
                if (userLocation.Count == 2) {
                    userCoord = new Microsoft.Maps.MapControl.WPF.Location (userLocation[0], userLocation[1]);
                    Pushpin pin = new Pushpin ();
                    pin.Background = new SolidColorBrush (Color.FromArgb (200, 0, 100, 100));
                    pin.Location = userCoord;
                    mapTest.userControl11.map.Children.Add (pin);
                }
            }

            // Add pins for all of the businesses in the grid
            // Instead of requerying the businesses, just pulling from the datagrid view the business names, 
            // then I will query the locations for the businesses
            foreach (DataGridViewRow row in businessGrid.Rows) {
                selectedBusinesses.Add (row.Cells[9].Value.ToString ());
            }

            // Need to protect against case where no businesses are present in the grid
            foreach (List<double> locations in queryEngine.GetBusinessLocations (selectedBusinesses)) {
                busCoord = new Microsoft.Maps.MapControl.WPF.Location (locations[0], locations[1]);
                Pushpin pin = new Pushpin ();
                pin.Location = busCoord;
                mapTest.userControl11.map.Children.Add (pin);

                mapTest.userControl11.map.SetView (busCoord, 11);
            }

            // Draw line between the user and most recently added business to make map more readable
            if (userCoord != null && busCoord != null) {
                MapPolyline polyline = new MapPolyline ();
                polyline.Stroke = new System.Windows.Media.SolidColorBrush (System.Windows.Media.Colors.DarkRed);
                polyline.StrokeThickness = 3;
                polyline.Opacity = 0.5;
                polyline.Locations = new LocationCollection () {
                    userCoord,
                    busCoord
                };

                mapTest.userControl11.map.Children.Add (polyline);
            }

            this.mapTest.Show ();
        }

        private void CheckInButton_Click (object sender, EventArgs e) {
            if (currBusId != string.Empty && currUserId != string.Empty) {
                // Make the new form open up and show it to the user.
                CheckinForm checkinsWindow = new CheckinForm (currUserId, currBusId, DateTime.Now);
                checkinsWindow.Show ();
            } else {
                if (currUserId == string.Empty)
                    MessageBox.Show ("Please select a user to sign in as.");
                else if (currBusId == string.Empty)
                    MessageBox.Show ("Please select a business");
            }
        }

        private void AddToFavoritesButton_Click (object sender, EventArgs e) {
            if (currBusId != string.Empty && currUserId != string.Empty) // Only try to add if there is a business selected and a user signed in
            {
                if (queryEngine.AddToFavorites (currBusId, currUserId)) // Try to add the business to favorites
                {
                    MessageBox.Show ("Added to favorites"); // If the business was added, then tell the user
                    UpdateFavBusinessGrid ();
                } else
                    MessageBox.Show ("Business already in favorites"); //If the business wasnt added then its probably already in their favorites
            } else {
                if (currUserId != string.Empty) // Show an error for the possible things that could have gome wrong
                    MessageBox.Show ("Please select a user to sign in as.");
                if (currBusId != string.Empty)
                    MessageBox.Show ("Please select a business");
            }
        }

        /**
         * ! User Page
         * ? User Search functionality
         */

        private void UserNameEntryTextBox_KeyPress (object sender, KeyPressEventArgs e) {
            if (e.KeyChar == 13) {
                List<string> userIds = queryEngine.GetUsers (UserNameEntryTextBox.Text);

                PlayerIDListBox.Items.Clear ();

                foreach (string id in userIds)
                    PlayerIDListBox.Items.Add (id);

                e.Handled = true;
            }
        }

        /// <summary>
        /// When the user selects an ID from the list it should populate the user data section with that user's data.   
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PlayerIDListBox_SelectedIndexChanged (object sender, EventArgs e) {
            // Fill all of the user's info textboxes
            // Object reference not set to an instance of an object.
            List<List<string>> userData = queryEngine.GetUser (PlayerIDListBox.SelectedItem.ToString (), "name, average_stars, cool, funny, useful, fans, review_count, yelping_since, user_latitude, user_longitude, user_id");

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

            UpdateFriendsGrid ();
            UpdateFavBusinessGrid ();
            UpdateFriendsRevGrid ();

            queryEngine.SelectUser (currUserId);
            UpdateGrid (); //update the business grid so the user can see how far away they are from the searched businesses.
        }

        // Should consider *Templatizing* this to work for multiple DataGrids
        private void UpdateFriendsGrid () {
            int row = 0, col = 0;
            FriendsGrid.Rows.Clear (); //removes all the data previously in the grid.            

            foreach (List<string> listRow in queryEngine.GetFriends (currUserId)) {
                if (row > 0) {
                    FriendsGrid.Rows.Add (); //the index of the new row
                    foreach (string item in listRow)
                        FriendsGrid.Rows[row - 1].Cells[col++].Value = item;
                    col = 0;
                }
                row++;
            }
        }

        // Should consider *Templatizing* this to work for multiple DataGrids
        private void UpdateFavBusinessGrid () {
            int row = 0, col = 0;
            FavoriteBusinessGrid.Rows.Clear (); //removes all the data previously in the grid.            

            foreach (List<string> listRow in queryEngine.GetFavBusinesses (currUserId)) {
                if (row > 0) {
                    FavoriteBusinessGrid.Rows.Add (); //the index of the new row
                    foreach (string item in listRow)
                        FavoriteBusinessGrid.Rows[row - 1].Cells[col++].Value = item;
                    col = 0;
                }
                row++;
            }
        }

        private void UpdateFriendsRevGrid () {
            int row = 0, col = 0;
            FriendsReviewsGrid.Rows.Clear ();

            foreach (List<string> listRow in queryEngine.GetFriendsReview (currUserId)) {
                if (row > 0) {
                    FriendsReviewsGrid.Rows.Add (); //the index of the new row
                    foreach (string item in listRow)
                        FriendsReviewsGrid.Rows[row - 1].Cells[col++].Value = item;
                    col = 0;
                }
                row++;
            }
        }

        private void FavoriteBusinessGrid_RowPrePaint (object sender, DataGridViewRowPrePaintEventArgs e) {
            e.PaintParts &= ~DataGridViewPaintParts.Focus;
        }

        /**
         * ! User Page
         * ? Edit User Data functionality
         */

        private void FavoriteBusinessGrid_CellClick (object sender, DataGridViewCellEventArgs e) {
            RemoveFavBtn.Enabled = true;
        }

        private void FavoriteBusinessGrid_CellContentClick (object sender, DataGridViewCellEventArgs e) {
            RemoveFavBtn.Enabled = true;
        }

        private void EditBtn_Click (object sender, EventArgs e) {
            EditBtn.Enabled = false;
            UpdateBtn.Enabled = true;
            LongitudeValue.Enabled = true;
            LatitudeValue.Enabled = true;
        }

        private void UpdateBtn_Click (object sender, EventArgs e) {
            double lat, lon;
            if (double.TryParse (LatitudeValue.Text, out lat) && double.TryParse (LongitudeValue.Text, out lon)) {
                // Update the User's location values
                queryEngine.UpdateUserLocation (currUserId, lat, lon);

                UpdateBtn.Enabled = false;
                EditBtn.Enabled = true;
                LatitudeValue.Enabled = false;
                LongitudeValue.Enabled = false;
            } else {
                MessageBox.Show ("Please enter valid Latitude and Longitude values.");
            }
        }

        // User should only be able to select one business at a time
        // Need to query by business_id
        private void RemoveFavBtn_Click (object sender, EventArgs e) {
            RemoveFavBtn.Enabled = false;

            foreach (DataGridViewRow row in FavoriteBusinessGrid.SelectedRows)
                queryEngine.RemoveFavBus (currUserId, row.Cells[0].Value.ToString (), row.Cells[4].Value.ToString ());

            UpdateFavBusinessGrid ();
        }

        /**
         * ! Business Admin Page
         * ? Search Business functionality
         */

        private void BusinessNameTB_KeyPress (object sender, KeyPressEventArgs e) {
            if (e.KeyChar == 13) {
                List<string> busIds = queryEngine.GetBusinesses (BusinessNameTB.Text);

                BusinessIdLB.Items.Clear ();

                foreach (string id in busIds)
                    BusinessIdLB.Items.Add (id);

                e.Handled = true;
            }
        }

        private void BusinessIdLB_SelectedIndexChanged (object sender, EventArgs e) {
            List<List<string>> busData = queryEngine.GetBusiness (BusinessIdLB.SelectedItem.ToString (), "name, address, state, city, zipcode, latitude, longitude, review_count, num_checkins, reviewrating, stars, business_id");

            BusNameValue.Text = busData[1][0];
            AdminAddressValue.Text = busData[1][1];
            AdminStateValue.Text = busData[1][2];
            AdminCityValue.Text = busData[1][3];
            AdminZipValue.Text = busData[1][4];
            AdminLatValue.Text = busData[1][5];
            AdminLonValue.Text = busData[1][6];
            AdminReviewValue.Text = busData[1][7];
            AdminCheckinValue.Text = busData[1][8];
            AdminRatingValue.Text = busData[1][9];
            AdminStarsValue.Text = busData[1][10];

            currAdminId = busData[1][11]; //set the current user id to what was returned by the query.

            UpdateBussAttributesGrid ();
        }

        private void UpdateBussAttributesGrid () {
            int row = 0, col = 0;
            BusinessAttrGrid.Rows.Clear (); //removes all the data previously in the grid.            

            foreach (List<string> listRow in queryEngine.GetAttributes (currAdminId)) {
                if (row > 0) {
                    BusinessAttrGrid.Rows.Add (); //the index of the new row
                    foreach (string item in listRow)
                        BusinessAttrGrid.Rows[row - 1].Cells[col++].Value = item;
                    col = 0;
                }
                row++;
            }
        }

        /**
         * ! Business Admin Page
         * ? Edit Business Name functionality
         */

        private void AdminEditNameBtn_Click (object sender, EventArgs e) {
            AdminEditNameBtn.Enabled = false;
            AdminUpdateBtn.Enabled = true;
            BusNameValue.Enabled = true;
        }

        private void AdminUpdateBtn_Click (object sender, EventArgs e) {

            AdminUpdateBtn.Enabled = false;
            AdminEditNameBtn.Enabled = true;

            // Execute update query
            if (BusNameValue.Text != string.Empty)
                queryEngine.UpdateBusinessName (currAdminId, BusNameValue.Text);

            UpdateGrid ();

            string query = string.Empty;
            string address = AdminAddressValue.Text;
        }

        /**
         * ! Business Admin Page
         * ? Edit Business Attributes functionality
         */

        private void BusinessAttrGrid_CellClick (object sender, DataGridViewCellEventArgs e) {
            EditAttrBtn.Enabled = true;

            foreach (DataGridViewRow row in BusinessAttrGrid.SelectedRows) {
                //queryEngine.updateAttribute(currAdminId, row.Cells[0].Value.ToString(), AttributeValValue.Text);
                AttributeNameValue.Text = row.Cells[0].Value.ToString ();
                AttributeValValue.Text = row.Cells[1].Value.ToString ();
            }
        }

        private void BusinessAttrGrid_CellContentClick (object sender, DataGridViewCellEventArgs e) {
            EditAttrBtn.Enabled = true;
        }

        /// <summary>
        /// Used for making sure the user adds somewhat valid data into the business's attributes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NewAttrValue_KeyDown (object sender, KeyEventArgs e) {
            if (NewAttrValue.Text != string.Empty && NewAttriValValue.Text != string.Empty)
                AddAttrBtn.Enabled = true;
            else
                AddAttrBtn.Enabled = false;
        }

        /// <summary>
        /// Used for making sure the user adds somewhat valid data into the business's attributes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NewAttriValValue_KeyDown (object sender, KeyEventArgs e) {
            if (NewAttrValue.Text != string.Empty && NewAttriValValue.Text != string.Empty)
                AddAttrBtn.Enabled = true;
            else
                AddAttrBtn.Enabled = false;
        }

        private void EditAttrBtn_Click (object sender, EventArgs e) {
            AttributeValValue.Enabled = true;
            UpdateAttrBtn.Enabled = true;
            EditAttrBtn.Enabled = false;
        }

        private void UpdateAttrBtn_Click (object sender, EventArgs e) {
            AttributeValValue.Enabled = false;
            UpdateAttrBtn.Enabled = false;
            EditAttrBtn.Enabled = true;

            // Execute update query

            queryEngine.UpdateAttribute (currAdminId, AttributeNameValue.Text, AttributeValValue.Text);

            AttributeNameValue.Text = string.Empty;
            AttributeValValue.Text = string.Empty;

            UpdateBussAttributesGrid ();
            UpdateBusinessPageAttributes (); //update the attributes on the business tab
        }

        private void AddAttrBtn_Click (object sender, EventArgs e) {
            // Execute insert query

            try {
                queryEngine.InsertAttribute (currAdminId, NewAttrValue.Text, NewAttriValValue.Text);
                UpdateBussAttributesGrid ();
            } catch (PostgresException) {
                MessageBox.Show ("Attribute is already present in database!");
            }

            NewAttrValue.Text = string.Empty;
            NewAttriValValue.Text = string.Empty;
            UpdateBussAttributesGrid ();
            UpdateBusinessPageAttributes (); //update the attributes on the business tab
        }

        /**
         * ! Search Page
         * ? Search control functions
         */

        private void SearchReviewsBtn_Click (object sender, EventArgs e) {
            if (KeywordValue.Text != string.Empty) {
                int row = 0, col = 0;

                ReviewKeywordGrid.Rows.Clear (); //removes all the data previously in the grid.            

                foreach (List<string> listRow in queryEngine.GetReviewsByKeyword (KeywordValue.Text)) {
                    if (row > 0) {
                        ReviewKeywordGrid.Rows.Add (); //the index of the new row
                        foreach (string item in listRow)
                            ReviewKeywordGrid.Rows[row - 1].Cells[col++].Value = item;
                        col = 0;
                    }
                    row++;
                }

                if (ReviewKeywordGrid.Rows.Count == 0)
                    MessageBox.Show ("There are no reviews containing the phrase \"" + KeywordValue.Text + "\". Maybe you should write one!");
            }
        }

        // Also search when the enter button is pressed
        private void KeywordValue_KeyPress (object sender, KeyPressEventArgs e) {
            if (e.KeyChar == 13) {
                SearchReviewsBtn_Click (sender, e);
                e.Handled = true;
            }
        }
    }
}