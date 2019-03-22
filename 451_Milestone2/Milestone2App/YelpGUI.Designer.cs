namespace Milestone2App
{
    partial class YelpGUI
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.businessGrid = new System.Windows.Forms.DataGridView();
            this.CityHeader = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.cityCheckBox = new System.Windows.Forms.CheckedListBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.stateDropDown = new System.Windows.Forms.ComboBox();
            this.StateHeader = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.categoriesCheckBox = new System.Windows.Forms.CheckedListBox();
            this.categoriesTextBox = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.zipCheckBox = new System.Windows.Forms.CheckedListBox();
            this.ZipText = new System.Windows.Forms.TextBox();
            this.SearchButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
            this.businessNameTextBox_Review = new System.Windows.Forms.RichTextBox();
            this.WriteReviewTextBox_Review = new System.Windows.Forms.TextBox();
            this.ShowReviewsButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel8 = new System.Windows.Forms.TableLayoutPanel();
            this.SubmitReviewButton = new System.Windows.Forms.Button();
            this.ReviewStarsDropDown = new System.Windows.Forms.ComboBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.BusinessTabPage = new System.Windows.Forms.TabPage();
            this.UsersTabPage = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel9 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel10 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel12 = new System.Windows.Forms.TableLayoutPanel();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel11 = new System.Windows.Forms.TableLayoutPanel();
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.YelpingSinceValue = new System.Windows.Forms.TextBox();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.StarsValue = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.NameValue = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox13 = new System.Windows.Forms.TextBox();
            this.FansValue = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel14 = new System.Windows.Forms.TableLayoutPanel();
            this.textBox11 = new System.Windows.Forms.TextBox();
            this.FunnyValue = new System.Windows.Forms.TextBox();
            this.textBox18 = new System.Windows.Forms.TextBox();
            this.CoolValue = new System.Windows.Forms.TextBox();
            this.textBox20 = new System.Windows.Forms.TextBox();
            this.UsefulValue = new System.Windows.Forms.TextBox();
            this.textBox14 = new System.Windows.Forms.TextBox();
            this.LatitudeValue = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox22 = new System.Windows.Forms.TextBox();
            this.LongitudeValue = new System.Windows.Forms.TextBox();
            this.ReviewCount = new System.Windows.Forms.TextBox();
            this.ReviewCountValue = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel13 = new System.Windows.Forms.TableLayoutPanel();
            this.PlayerIDListBox = new System.Windows.Forms.ListBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.UserNameEntryTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.businessGrid)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.tableLayoutPanel7.SuspendLayout();
            this.tableLayoutPanel8.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.BusinessTabPage.SuspendLayout();
            this.UsersTabPage.SuspendLayout();
            this.tableLayoutPanel9.SuspendLayout();
            this.tableLayoutPanel10.SuspendLayout();
            this.tableLayoutPanel12.SuspendLayout();
            this.tableLayoutPanel11.SuspendLayout();
            this.tableLayoutPanel14.SuspendLayout();
            this.tableLayoutPanel13.SuspendLayout();
            this.SuspendLayout();
            // 
            // businessGrid
            // 
            this.businessGrid.AllowUserToAddRows = false;
            this.businessGrid.AllowUserToDeleteRows = false;
            this.businessGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.businessGrid.Location = new System.Drawing.Point(267, 0);
            this.businessGrid.Margin = new System.Windows.Forms.Padding(0);
            this.businessGrid.Name = "businessGrid";
            this.businessGrid.ReadOnly = true;
            this.businessGrid.Size = new System.Drawing.Size(792, 315);
            this.businessGrid.TabIndex = 2;
            this.businessGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.businessGrid_CellContentClick);
            // 
            // CityHeader
            // 
            this.CityHeader.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.CityHeader.Cursor = System.Windows.Forms.Cursors.Default;
            this.CityHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CityHeader.Location = new System.Drawing.Point(0, 0);
            this.CityHeader.Margin = new System.Windows.Forms.Padding(0);
            this.CityHeader.Name = "CityHeader";
            this.CityHeader.ReadOnly = true;
            this.CityHeader.Size = new System.Drawing.Size(267, 15);
            this.CityHeader.TabIndex = 4;
            this.CityHeader.Text = "City";
            this.CityHeader.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.cityCheckBox, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.CityHeader, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 42);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(267, 152);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // cityCheckBox
            // 
            this.cityCheckBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cityCheckBox.FormattingEnabled = true;
            this.cityCheckBox.Location = new System.Drawing.Point(0, 15);
            this.cityCheckBox.Margin = new System.Windows.Forms.Padding(0);
            this.cityCheckBox.Name = "cityCheckBox";
            this.cityCheckBox.Size = new System.Drawing.Size(267, 137);
            this.cityCheckBox.TabIndex = 0;
            this.cityCheckBox.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.cityCheckBox_ItemCheck);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel2.Controls.Add(this.stateDropDown, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.StateHeader, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(267, 42);
            this.tableLayoutPanel2.TabIndex = 7;
            // 
            // stateDropDown
            // 
            this.stateDropDown.Dock = System.Windows.Forms.DockStyle.Fill;
            this.stateDropDown.FormattingEnabled = true;
            this.stateDropDown.Location = new System.Drawing.Point(0, 15);
            this.stateDropDown.Margin = new System.Windows.Forms.Padding(0);
            this.stateDropDown.Name = "stateDropDown";
            this.stateDropDown.Size = new System.Drawing.Size(267, 24);
            this.stateDropDown.TabIndex = 0;
            this.stateDropDown.Text = "Select state...";
            this.stateDropDown.SelectedIndexChanged += new System.EventHandler(this.stateDropDown_SelectedIndexChanged);
            // 
            // StateHeader
            // 
            this.StateHeader.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.StateHeader.Cursor = System.Windows.Forms.Cursors.Default;
            this.StateHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StateHeader.Location = new System.Drawing.Point(0, 0);
            this.StateHeader.Margin = new System.Windows.Forms.Padding(0);
            this.StateHeader.Name = "StateHeader";
            this.StateHeader.ReadOnly = true;
            this.StateHeader.Size = new System.Drawing.Size(267, 15);
            this.StateHeader.TabIndex = 3;
            this.StateHeader.Text = "State";
            this.StateHeader.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel6, 0, 3);
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel1, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel4, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.SearchButton, 0, 4);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 5;
            this.tableLayoutPanel5.SetRowSpan(this.tableLayoutPanel3, 2);
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(267, 525);
            this.tableLayoutPanel3.TabIndex = 8;
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.ColumnCount = 1;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel6.Controls.Add(this.categoriesCheckBox, 1, 1);
            this.tableLayoutPanel6.Controls.Add(this.categoriesTextBox, 1, 0);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(0, 346);
            this.tableLayoutPanel6.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 2;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(267, 152);
            this.tableLayoutPanel6.TabIndex = 9;
            // 
            // categoriesCheckBox
            // 
            this.categoriesCheckBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.categoriesCheckBox.FormattingEnabled = true;
            this.categoriesCheckBox.Location = new System.Drawing.Point(0, 15);
            this.categoriesCheckBox.Margin = new System.Windows.Forms.Padding(0);
            this.categoriesCheckBox.Name = "categoriesCheckBox";
            this.categoriesCheckBox.Size = new System.Drawing.Size(268, 137);
            this.categoriesCheckBox.TabIndex = 0;
            this.categoriesCheckBox.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.categoriesCheckBox_ItemCheck);
            // 
            // categoriesTextBox
            // 
            this.categoriesTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.categoriesTextBox.Cursor = System.Windows.Forms.Cursors.Default;
            this.categoriesTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.categoriesTextBox.Location = new System.Drawing.Point(0, 0);
            this.categoriesTextBox.Margin = new System.Windows.Forms.Padding(0);
            this.categoriesTextBox.Name = "categoriesTextBox";
            this.categoriesTextBox.ReadOnly = true;
            this.categoriesTextBox.Size = new System.Drawing.Size(268, 15);
            this.categoriesTextBox.TabIndex = 4;
            this.categoriesTextBox.Text = "Categories";
            this.categoriesTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel4.Controls.Add(this.zipCheckBox, 1, 1);
            this.tableLayoutPanel4.Controls.Add(this.ZipText, 1, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(0, 194);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(267, 152);
            this.tableLayoutPanel4.TabIndex = 8;
            // 
            // zipCheckBox
            // 
            this.zipCheckBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.zipCheckBox.FormattingEnabled = true;
            this.zipCheckBox.Location = new System.Drawing.Point(0, 15);
            this.zipCheckBox.Margin = new System.Windows.Forms.Padding(0);
            this.zipCheckBox.Name = "zipCheckBox";
            this.zipCheckBox.Size = new System.Drawing.Size(268, 137);
            this.zipCheckBox.TabIndex = 0;
            this.zipCheckBox.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.zipCheckBox_ItemCheck);
            // 
            // ZipText
            // 
            this.ZipText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ZipText.Cursor = System.Windows.Forms.Cursors.Default;
            this.ZipText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ZipText.Location = new System.Drawing.Point(0, 0);
            this.ZipText.Margin = new System.Windows.Forms.Padding(0);
            this.ZipText.Name = "ZipText";
            this.ZipText.ReadOnly = true;
            this.ZipText.Size = new System.Drawing.Size(268, 15);
            this.ZipText.TabIndex = 4;
            this.ZipText.Text = "Zip";
            this.ZipText.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // SearchButton
            // 
            this.SearchButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SearchButton.Location = new System.Drawing.Point(0, 498);
            this.SearchButton.Margin = new System.Windows.Forms.Padding(0);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(267, 27);
            this.SearchButton.TabIndex = 10;
            this.SearchButton.Text = "Search";
            this.SearchButton.UseVisualStyleBackColor = true;
            this.SearchButton.Click += new System.EventHandler(this.SearchButton_Click);
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 2;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 267F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Controls.Add(this.tableLayoutPanel3, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.businessGrid, 1, 0);
            this.tableLayoutPanel5.Controls.Add(this.tableLayoutPanel7, 1, 1);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel5.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 2;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(1059, 525);
            this.tableLayoutPanel5.TabIndex = 8;
            // 
            // tableLayoutPanel7
            // 
            this.tableLayoutPanel7.ColumnCount = 2;
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 133F));
            this.tableLayoutPanel7.Controls.Add(this.businessNameTextBox_Review, 0, 0);
            this.tableLayoutPanel7.Controls.Add(this.WriteReviewTextBox_Review, 0, 1);
            this.tableLayoutPanel7.Controls.Add(this.ShowReviewsButton, 1, 0);
            this.tableLayoutPanel7.Controls.Add(this.tableLayoutPanel8, 1, 1);
            this.tableLayoutPanel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel7.Location = new System.Drawing.Point(267, 315);
            this.tableLayoutPanel7.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel7.Name = "tableLayoutPanel7";
            this.tableLayoutPanel7.RowCount = 2;
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 47F));
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel7.Size = new System.Drawing.Size(792, 210);
            this.tableLayoutPanel7.TabIndex = 9;
            // 
            // businessNameTextBox_Review
            // 
            this.businessNameTextBox_Review.Dock = System.Windows.Forms.DockStyle.Fill;
            this.businessNameTextBox_Review.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.businessNameTextBox_Review.Location = new System.Drawing.Point(0, 0);
            this.businessNameTextBox_Review.Margin = new System.Windows.Forms.Padding(0);
            this.businessNameTextBox_Review.Name = "businessNameTextBox_Review";
            this.businessNameTextBox_Review.ReadOnly = true;
            this.businessNameTextBox_Review.Size = new System.Drawing.Size(659, 47);
            this.businessNameTextBox_Review.TabIndex = 0;
            this.businessNameTextBox_Review.Text = "Business name (click on one)";
            // 
            // WriteReviewTextBox_Review
            // 
            this.WriteReviewTextBox_Review.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WriteReviewTextBox_Review.Location = new System.Drawing.Point(0, 47);
            this.WriteReviewTextBox_Review.Margin = new System.Windows.Forms.Padding(0);
            this.WriteReviewTextBox_Review.Multiline = true;
            this.WriteReviewTextBox_Review.Name = "WriteReviewTextBox_Review";
            this.WriteReviewTextBox_Review.Size = new System.Drawing.Size(659, 163);
            this.WriteReviewTextBox_Review.TabIndex = 1;
            this.WriteReviewTextBox_Review.TextChanged += new System.EventHandler(this.WriteReviewTextBox_Review_TextChanged);
            // 
            // ShowReviewsButton
            // 
            this.ShowReviewsButton.Dock = System.Windows.Forms.DockStyle.Fill;
<<<<<<< Updated upstream
            this.ShowReviewsButton.Enabled = false;
            this.ShowReviewsButton.Location = new System.Drawing.Point(492, 0);
=======
            this.ShowReviewsButton.Location = new System.Drawing.Point(659, 0);
>>>>>>> Stashed changes
            this.ShowReviewsButton.Margin = new System.Windows.Forms.Padding(0);
            this.ShowReviewsButton.Name = "ShowReviewsButton";
            this.ShowReviewsButton.Size = new System.Drawing.Size(133, 47);
            this.ShowReviewsButton.TabIndex = 2;
            this.ShowReviewsButton.Text = "Show Reviews";
            this.ShowReviewsButton.UseVisualStyleBackColor = true;
            this.ShowReviewsButton.Click += new System.EventHandler(this.ShowReviewsButton_Click);
            // 
            // tableLayoutPanel8
            // 
            this.tableLayoutPanel8.ColumnCount = 1;
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel8.Controls.Add(this.SubmitReviewButton, 0, 1);
            this.tableLayoutPanel8.Controls.Add(this.ReviewStarsDropDown, 0, 0);
            this.tableLayoutPanel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel8.Location = new System.Drawing.Point(659, 47);
            this.tableLayoutPanel8.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel8.Name = "tableLayoutPanel8";
            this.tableLayoutPanel8.RowCount = 2;
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel8.Size = new System.Drawing.Size(133, 163);
            this.tableLayoutPanel8.TabIndex = 3;
            // 
            // SubmitReviewButton
            // 
            this.SubmitReviewButton.Dock = System.Windows.Forms.DockStyle.Fill;
<<<<<<< Updated upstream
            this.SubmitReviewButton.Enabled = false;
            this.SubmitReviewButton.Location = new System.Drawing.Point(0, 21);
=======
            this.SubmitReviewButton.Location = new System.Drawing.Point(0, 24);
>>>>>>> Stashed changes
            this.SubmitReviewButton.Margin = new System.Windows.Forms.Padding(0);
            this.SubmitReviewButton.Name = "SubmitReviewButton";
            this.SubmitReviewButton.Size = new System.Drawing.Size(133, 139);
            this.SubmitReviewButton.TabIndex = 0;
            this.SubmitReviewButton.Text = "Submit Review";
            this.SubmitReviewButton.UseVisualStyleBackColor = true;
            this.SubmitReviewButton.Click += new System.EventHandler(this.SubmitReviewButton_Click);
            // 
            // ReviewStarsDropDown
            // 
            this.ReviewStarsDropDown.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ReviewStarsDropDown.FormattingEnabled = true;
            this.ReviewStarsDropDown.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5"});
            this.ReviewStarsDropDown.Location = new System.Drawing.Point(0, 0);
            this.ReviewStarsDropDown.Margin = new System.Windows.Forms.Padding(0);
            this.ReviewStarsDropDown.Name = "ReviewStarsDropDown";
            this.ReviewStarsDropDown.Size = new System.Drawing.Size(133, 24);
            this.ReviewStarsDropDown.TabIndex = 1;
            this.ReviewStarsDropDown.Text = "Review Stars";
            this.ReviewStarsDropDown.SelectedIndexChanged += new System.EventHandler(this.ReviewStarsDropDown_SelectedIndexChanged);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.BusinessTabPage);
            this.tabControl1.Controls.Add(this.UsersTabPage);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1067, 554);
            this.tabControl1.TabIndex = 9;
            // 
            // BusinessTabPage
            // 
            this.BusinessTabPage.Controls.Add(this.tableLayoutPanel5);
            this.BusinessTabPage.Location = new System.Drawing.Point(4, 25);
            this.BusinessTabPage.Margin = new System.Windows.Forms.Padding(0);
            this.BusinessTabPage.Name = "BusinessTabPage";
            this.BusinessTabPage.Size = new System.Drawing.Size(1059, 525);
            this.BusinessTabPage.TabIndex = 0;
            this.BusinessTabPage.Text = "Business";
            this.BusinessTabPage.UseVisualStyleBackColor = true;
            // 
            // UsersTabPage
            // 
            this.UsersTabPage.Controls.Add(this.tableLayoutPanel9);
            this.UsersTabPage.Location = new System.Drawing.Point(4, 25);
            this.UsersTabPage.Margin = new System.Windows.Forms.Padding(0);
            this.UsersTabPage.Name = "UsersTabPage";
            this.UsersTabPage.Size = new System.Drawing.Size(1059, 525);
            this.UsersTabPage.TabIndex = 1;
            this.UsersTabPage.Text = "Users";
            this.UsersTabPage.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel9
            // 
            this.tableLayoutPanel9.ColumnCount = 1;
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel9.Controls.Add(this.tableLayoutPanel10, 0, 0);
            this.tableLayoutPanel9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel9.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel9.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel9.Name = "tableLayoutPanel9";
            this.tableLayoutPanel9.RowCount = 2;
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel9.Size = new System.Drawing.Size(1059, 525);
            this.tableLayoutPanel9.TabIndex = 9;
            // 
            // tableLayoutPanel10
            // 
            this.tableLayoutPanel10.ColumnCount = 1;
            this.tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel10.Controls.Add(this.tableLayoutPanel12, 0, 1);
            this.tableLayoutPanel10.Controls.Add(this.tableLayoutPanel13, 0, 0);
            this.tableLayoutPanel10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel10.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel10.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel10.Name = "tableLayoutPanel10";
            this.tableLayoutPanel10.RowCount = 2;
            this.tableLayoutPanel9.SetRowSpan(this.tableLayoutPanel10, 2);
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 164F));
            this.tableLayoutPanel10.Size = new System.Drawing.Size(1059, 525);
            this.tableLayoutPanel10.TabIndex = 8;
            // 
            // tableLayoutPanel12
            // 
            this.tableLayoutPanel12.ColumnCount = 1;
            this.tableLayoutPanel12.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel12.Controls.Add(this.textBox2, 0, 0);
            this.tableLayoutPanel12.Controls.Add(this.tableLayoutPanel11, 0, 1);
            this.tableLayoutPanel12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel12.Location = new System.Drawing.Point(0, 361);
            this.tableLayoutPanel12.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel12.Name = "tableLayoutPanel12";
            this.tableLayoutPanel12.RowCount = 2;
            this.tableLayoutPanel12.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel12.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 148F));
            this.tableLayoutPanel12.Size = new System.Drawing.Size(1059, 164);
            this.tableLayoutPanel12.TabIndex = 2;
            // 
            // textBox2
            // 
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Cursor = System.Windows.Forms.Cursors.Default;
            this.textBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox2.Location = new System.Drawing.Point(0, 0);
            this.textBox2.Margin = new System.Windows.Forms.Padding(0);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(1059, 15);
            this.textBox2.TabIndex = 4;
            this.textBox2.Text = "User Information";
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tableLayoutPanel11
            // 
            this.tableLayoutPanel11.ColumnCount = 4;
            this.tableLayoutPanel11.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel11.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel11.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel11.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel11.Controls.Add(this.textBox10, 0, 3);
            this.tableLayoutPanel11.Controls.Add(this.YelpingSinceValue, 1, 2);
            this.tableLayoutPanel11.Controls.Add(this.textBox8, 0, 2);
            this.tableLayoutPanel11.Controls.Add(this.StarsValue, 1, 1);
            this.tableLayoutPanel11.Controls.Add(this.textBox6, 0, 1);
            this.tableLayoutPanel11.Controls.Add(this.NameValue, 1, 0);
            this.tableLayoutPanel11.Controls.Add(this.textBox4, 0, 0);
            this.tableLayoutPanel11.Controls.Add(this.textBox13, 2, 1);
            this.tableLayoutPanel11.Controls.Add(this.FansValue, 3, 1);
            this.tableLayoutPanel11.Controls.Add(this.tableLayoutPanel14, 1, 3);
            this.tableLayoutPanel11.Controls.Add(this.textBox14, 0, 5);
            this.tableLayoutPanel11.Controls.Add(this.LatitudeValue, 1, 5);
            this.tableLayoutPanel11.Controls.Add(this.textBox1, 2, 5);
            this.tableLayoutPanel11.Controls.Add(this.textBox22, 0, 4);
            this.tableLayoutPanel11.Controls.Add(this.LongitudeValue, 3, 5);
            this.tableLayoutPanel11.Controls.Add(this.ReviewCount, 2, 0);
            this.tableLayoutPanel11.Controls.Add(this.ReviewCountValue, 3, 0);
            this.tableLayoutPanel11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel11.Location = new System.Drawing.Point(0, 15);
            this.tableLayoutPanel11.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel11.Name = "tableLayoutPanel11";
            this.tableLayoutPanel11.RowCount = 6;
            this.tableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel11.Size = new System.Drawing.Size(1059, 149);
            this.tableLayoutPanel11.TabIndex = 5;
            // 
            // textBox10
            // 
            this.textBox10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox10.Location = new System.Drawing.Point(0, 75);
            this.textBox10.Margin = new System.Windows.Forms.Padding(0);
            this.textBox10.Name = "textBox10";
            this.textBox10.Size = new System.Drawing.Size(176, 22);
            this.textBox10.TabIndex = 16;
            this.textBox10.Text = "Votes";
            // 
            // YelpingSinceValue
            // 
            this.tableLayoutPanel11.SetColumnSpan(this.YelpingSinceValue, 3);
            this.YelpingSinceValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.YelpingSinceValue.Location = new System.Drawing.Point(176, 50);
            this.YelpingSinceValue.Margin = new System.Windows.Forms.Padding(0);
            this.YelpingSinceValue.Name = "YelpingSinceValue";
            this.YelpingSinceValue.Size = new System.Drawing.Size(883, 22);
            this.YelpingSinceValue.TabIndex = 15;
            // 
            // textBox8
            // 
            this.textBox8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox8.Location = new System.Drawing.Point(0, 50);
            this.textBox8.Margin = new System.Windows.Forms.Padding(0);
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(176, 22);
            this.textBox8.TabIndex = 14;
            this.textBox8.Text = "Yelping Since";
            // 
            // StarsValue
            // 
            this.StarsValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StarsValue.Location = new System.Drawing.Point(176, 25);
            this.StarsValue.Margin = new System.Windows.Forms.Padding(0);
            this.StarsValue.Name = "StarsValue";
            this.StarsValue.Size = new System.Drawing.Size(352, 22);
            this.StarsValue.TabIndex = 13;
            // 
            // textBox6
            // 
            this.textBox6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox6.Location = new System.Drawing.Point(0, 25);
            this.textBox6.Margin = new System.Windows.Forms.Padding(0);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(176, 22);
            this.textBox6.TabIndex = 12;
            this.textBox6.Text = "Stars";
            // 
            // NameValue
            // 
            this.NameValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NameValue.Location = new System.Drawing.Point(176, 0);
            this.NameValue.Margin = new System.Windows.Forms.Padding(0);
            this.NameValue.Name = "NameValue";
            this.NameValue.Size = new System.Drawing.Size(352, 22);
            this.NameValue.TabIndex = 11;
            // 
            // textBox4
            // 
            this.textBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox4.Location = new System.Drawing.Point(0, 0);
            this.textBox4.Margin = new System.Windows.Forms.Padding(0);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(176, 22);
            this.textBox4.TabIndex = 10;
            this.textBox4.Text = "Name";
            // 
            // textBox13
            // 
            this.textBox13.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox13.Location = new System.Drawing.Point(528, 25);
            this.textBox13.Margin = new System.Windows.Forms.Padding(0);
            this.textBox13.Name = "textBox13";
            this.textBox13.Size = new System.Drawing.Size(176, 22);
            this.textBox13.TabIndex = 19;
            this.textBox13.Text = "Fans";
            // 
            // FansValue
            // 
            this.FansValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FansValue.Location = new System.Drawing.Point(704, 25);
            this.FansValue.Margin = new System.Windows.Forms.Padding(0);
            this.FansValue.Name = "FansValue";
            this.FansValue.Size = new System.Drawing.Size(355, 22);
            this.FansValue.TabIndex = 18;
            // 
            // tableLayoutPanel14
            // 
            this.tableLayoutPanel14.ColumnCount = 6;
            this.tableLayoutPanel11.SetColumnSpan(this.tableLayoutPanel14, 3);
            this.tableLayoutPanel14.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66583F));
            this.tableLayoutPanel14.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.6675F));
            this.tableLayoutPanel14.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66583F));
            this.tableLayoutPanel14.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.6675F));
            this.tableLayoutPanel14.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66583F));
            this.tableLayoutPanel14.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.6675F));
            this.tableLayoutPanel14.Controls.Add(this.textBox11, 0, 0);
            this.tableLayoutPanel14.Controls.Add(this.FunnyValue, 1, 0);
            this.tableLayoutPanel14.Controls.Add(this.textBox18, 2, 0);
            this.tableLayoutPanel14.Controls.Add(this.CoolValue, 3, 0);
            this.tableLayoutPanel14.Controls.Add(this.textBox20, 4, 0);
            this.tableLayoutPanel14.Controls.Add(this.UsefulValue, 5, 0);
            this.tableLayoutPanel14.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel14.Location = new System.Drawing.Point(176, 75);
            this.tableLayoutPanel14.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel14.Name = "tableLayoutPanel14";
            this.tableLayoutPanel14.RowCount = 1;
            this.tableLayoutPanel14.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel14.Size = new System.Drawing.Size(883, 25);
            this.tableLayoutPanel14.TabIndex = 24;
            // 
            // textBox11
            // 
            this.textBox11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox11.Location = new System.Drawing.Point(0, 0);
            this.textBox11.Margin = new System.Windows.Forms.Padding(0);
            this.textBox11.Name = "textBox11";
            this.textBox11.Size = new System.Drawing.Size(147, 22);
            this.textBox11.TabIndex = 0;
            this.textBox11.Text = "Funny:";
            // 
            // FunnyValue
            // 
            this.FunnyValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FunnyValue.Location = new System.Drawing.Point(147, 0);
            this.FunnyValue.Margin = new System.Windows.Forms.Padding(0);
            this.FunnyValue.Name = "FunnyValue";
            this.FunnyValue.Size = new System.Drawing.Size(147, 22);
            this.FunnyValue.TabIndex = 1;
            // 
            // textBox18
            // 
            this.textBox18.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox18.Location = new System.Drawing.Point(294, 0);
            this.textBox18.Margin = new System.Windows.Forms.Padding(0);
            this.textBox18.Name = "textBox18";
            this.textBox18.Size = new System.Drawing.Size(147, 22);
            this.textBox18.TabIndex = 2;
            this.textBox18.Text = "Cool:";
            // 
            // CoolValue
            // 
            this.CoolValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CoolValue.Location = new System.Drawing.Point(441, 0);
            this.CoolValue.Margin = new System.Windows.Forms.Padding(0);
            this.CoolValue.Name = "CoolValue";
            this.CoolValue.Size = new System.Drawing.Size(147, 22);
            this.CoolValue.TabIndex = 3;
            // 
            // textBox20
            // 
            this.textBox20.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox20.Location = new System.Drawing.Point(588, 0);
            this.textBox20.Margin = new System.Windows.Forms.Padding(0);
            this.textBox20.Name = "textBox20";
            this.textBox20.Size = new System.Drawing.Size(147, 22);
            this.textBox20.TabIndex = 4;
            this.textBox20.Text = "Useful:";
            // 
            // UsefulValue
            // 
            this.UsefulValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UsefulValue.Location = new System.Drawing.Point(735, 0);
            this.UsefulValue.Margin = new System.Windows.Forms.Padding(0);
            this.UsefulValue.Name = "UsefulValue";
            this.UsefulValue.Size = new System.Drawing.Size(148, 22);
            this.UsefulValue.TabIndex = 5;
            // 
            // textBox14
            // 
            this.textBox14.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox14.Location = new System.Drawing.Point(0, 125);
            this.textBox14.Margin = new System.Windows.Forms.Padding(0);
            this.textBox14.Name = "textBox14";
            this.textBox14.Size = new System.Drawing.Size(176, 22);
            this.textBox14.TabIndex = 21;
            this.textBox14.Text = "Longitude";
            // 
            // LatitudeValue
            // 
            this.LatitudeValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LatitudeValue.Location = new System.Drawing.Point(176, 125);
            this.LatitudeValue.Margin = new System.Windows.Forms.Padding(0);
            this.LatitudeValue.Name = "LatitudeValue";
            this.LatitudeValue.Size = new System.Drawing.Size(352, 22);
            this.LatitudeValue.TabIndex = 22;
            this.LatitudeValue.Text = "Longitude";
            // 
            // textBox1
            // 
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox1.Location = new System.Drawing.Point(528, 125);
            this.textBox1.Margin = new System.Windows.Forms.Padding(0);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(176, 22);
            this.textBox1.TabIndex = 20;
            this.textBox1.Text = "Latitude";
            // 
            // textBox22
            // 
            this.tableLayoutPanel11.SetColumnSpan(this.textBox22, 4);
            this.textBox22.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox22.Location = new System.Drawing.Point(0, 100);
            this.textBox22.Margin = new System.Windows.Forms.Padding(0);
            this.textBox22.Name = "textBox22";
            this.textBox22.Size = new System.Drawing.Size(1059, 22);
            this.textBox22.TabIndex = 25;
            this.textBox22.Text = "Location:";
            // 
            // LongitudeValue
            // 
            this.LongitudeValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LongitudeValue.Location = new System.Drawing.Point(704, 125);
            this.LongitudeValue.Margin = new System.Windows.Forms.Padding(0);
            this.LongitudeValue.Name = "LongitudeValue";
            this.LongitudeValue.Size = new System.Drawing.Size(355, 22);
            this.LongitudeValue.TabIndex = 23;
            this.LongitudeValue.Text = "Longitude";
            // 
            // ReviewCount
            // 
            this.ReviewCount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ReviewCount.Location = new System.Drawing.Point(528, 0);
            this.ReviewCount.Margin = new System.Windows.Forms.Padding(0);
            this.ReviewCount.Name = "ReviewCount";
            this.ReviewCount.Size = new System.Drawing.Size(176, 22);
            this.ReviewCount.TabIndex = 26;
            this.ReviewCount.Text = "Review Count";
            // 
            // ReviewCountValue
            // 
            this.ReviewCountValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ReviewCountValue.Location = new System.Drawing.Point(704, 0);
            this.ReviewCountValue.Margin = new System.Windows.Forms.Padding(0);
            this.ReviewCountValue.Name = "ReviewCountValue";
            this.ReviewCountValue.Size = new System.Drawing.Size(355, 22);
            this.ReviewCountValue.TabIndex = 27;
            // 
            // tableLayoutPanel13
            // 
            this.tableLayoutPanel13.ColumnCount = 1;
            this.tableLayoutPanel13.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel13.Controls.Add(this.PlayerIDListBox, 0, 2);
            this.tableLayoutPanel13.Controls.Add(this.textBox3, 0, 0);
            this.tableLayoutPanel13.Controls.Add(this.UserNameEntryTextBox, 0, 1);
            this.tableLayoutPanel13.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel13.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel13.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel13.Name = "tableLayoutPanel13";
            this.tableLayoutPanel13.RowCount = 3;
            this.tableLayoutPanel13.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel13.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel13.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel13.Size = new System.Drawing.Size(1059, 361);
            this.tableLayoutPanel13.TabIndex = 7;
            // 
            // PlayerIDListBox
            // 
            this.PlayerIDListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PlayerIDListBox.FormattingEnabled = true;
            this.PlayerIDListBox.ItemHeight = 16;
            this.PlayerIDListBox.Location = new System.Drawing.Point(0, 37);
            this.PlayerIDListBox.Margin = new System.Windows.Forms.Padding(0);
            this.PlayerIDListBox.Name = "PlayerIDListBox";
            this.PlayerIDListBox.Size = new System.Drawing.Size(1059, 324);
            this.PlayerIDListBox.TabIndex = 10;
            this.PlayerIDListBox.SelectedIndexChanged += new System.EventHandler(this.PlayerIDListBox_SelectedIndexChanged);
            // 
            // textBox3
            // 
            this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox3.Cursor = System.Windows.Forms.Cursors.Default;
            this.textBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox3.Location = new System.Drawing.Point(0, 0);
            this.textBox3.Margin = new System.Windows.Forms.Padding(0);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(1059, 15);
            this.textBox3.TabIndex = 3;
            this.textBox3.Text = "Name";
            this.textBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // UserNameEntryTextBox
            // 
            this.UserNameEntryTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UserNameEntryTextBox.Location = new System.Drawing.Point(0, 15);
            this.UserNameEntryTextBox.Margin = new System.Windows.Forms.Padding(0);
            this.UserNameEntryTextBox.Name = "UserNameEntryTextBox";
            this.UserNameEntryTextBox.Size = new System.Drawing.Size(1059, 22);
            this.UserNameEntryTextBox.TabIndex = 11;
            this.UserNameEntryTextBox.Text = "Enter name...";
            this.UserNameEntryTextBox.TextChanged += new System.EventHandler(this.UserNameEntryTextBox_TextChanged);
            // 
            // YelpGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.tabControl1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "YelpGUI";
            this.Text = "Milestone 2";
            ((System.ComponentModel.ISupportInitialize)(this.businessGrid)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel6.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel7.ResumeLayout(false);
            this.tableLayoutPanel7.PerformLayout();
            this.tableLayoutPanel8.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.BusinessTabPage.ResumeLayout(false);
            this.UsersTabPage.ResumeLayout(false);
            this.tableLayoutPanel9.ResumeLayout(false);
            this.tableLayoutPanel10.ResumeLayout(false);
            this.tableLayoutPanel12.ResumeLayout(false);
            this.tableLayoutPanel12.PerformLayout();
            this.tableLayoutPanel11.ResumeLayout(false);
            this.tableLayoutPanel11.PerformLayout();
            this.tableLayoutPanel14.ResumeLayout(false);
            this.tableLayoutPanel14.PerformLayout();
            this.tableLayoutPanel13.ResumeLayout(false);
            this.tableLayoutPanel13.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView businessGrid;
        private System.Windows.Forms.TextBox CityHeader;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.CheckedListBox cityCheckBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.CheckedListBox zipCheckBox;
        private System.Windows.Forms.TextBox ZipText;
        private System.Windows.Forms.ComboBox stateDropDown;
        private System.Windows.Forms.TextBox StateHeader;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.CheckedListBox categoriesCheckBox;
        private System.Windows.Forms.TextBox categoriesTextBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel7;
        private System.Windows.Forms.RichTextBox businessNameTextBox_Review;
        private System.Windows.Forms.TextBox WriteReviewTextBox_Review;
        private System.Windows.Forms.Button ShowReviewsButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel8;
        private System.Windows.Forms.Button SubmitReviewButton;
        private System.Windows.Forms.ComboBox ReviewStarsDropDown;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage BusinessTabPage;
        private System.Windows.Forms.TabPage UsersTabPage;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel9;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel10;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel12;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel13;
        private System.Windows.Forms.ListBox PlayerIDListBox;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox UserNameEntryTextBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel11;
        private System.Windows.Forms.TextBox textBox13;
        private System.Windows.Forms.TextBox FansValue;
        private System.Windows.Forms.TextBox textBox10;
        private System.Windows.Forms.TextBox YelpingSinceValue;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.TextBox StarsValue;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.TextBox NameValue;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox LongitudeValue;
        private System.Windows.Forms.TextBox LatitudeValue;
        private System.Windows.Forms.TextBox textBox14;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel14;
        private System.Windows.Forms.TextBox textBox11;
        private System.Windows.Forms.TextBox FunnyValue;
        private System.Windows.Forms.TextBox textBox18;
        private System.Windows.Forms.TextBox CoolValue;
        private System.Windows.Forms.TextBox textBox20;
        private System.Windows.Forms.TextBox UsefulValue;
        private System.Windows.Forms.TextBox textBox22;
        private System.Windows.Forms.TextBox ReviewCount;
        private System.Windows.Forms.TextBox ReviewCountValue;
        private System.Windows.Forms.Button SearchButton;
    }
}

