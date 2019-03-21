namespace Milestone2App
{
    partial class Form1
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
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
            this.businessNameTextBox_Review = new System.Windows.Forms.RichTextBox();
            this.WriteReviewTextBox_Review = new System.Windows.Forms.TextBox();
            this.ShowReviewsButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel8 = new System.Windows.Forms.TableLayoutPanel();
            this.button1 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.businessGrid)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.tableLayoutPanel7.SuspendLayout();
            this.tableLayoutPanel8.SuspendLayout();
            this.SuspendLayout();
            // 
            // businessGrid
            // 
            this.businessGrid.AllowUserToAddRows = false;
            this.businessGrid.AllowUserToDeleteRows = false;
            this.businessGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.businessGrid.Location = new System.Drawing.Point(200, 0);
            this.businessGrid.Margin = new System.Windows.Forms.Padding(0);
            this.businessGrid.Name = "businessGrid";
            this.businessGrid.ReadOnly = true;
            this.businessGrid.Size = new System.Drawing.Size(600, 270);
            this.businessGrid.TabIndex = 2;
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
            this.CityHeader.Size = new System.Drawing.Size(200, 13);
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
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 34);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(200, 138);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // cityCheckBox
            // 
            this.cityCheckBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cityCheckBox.FormattingEnabled = true;
            this.cityCheckBox.Location = new System.Drawing.Point(0, 13);
            this.cityCheckBox.Margin = new System.Windows.Forms.Padding(0);
            this.cityCheckBox.MultiColumn = true;
            this.cityCheckBox.Name = "cityCheckBox";
            this.cityCheckBox.Size = new System.Drawing.Size(200, 125);
            this.cityCheckBox.TabIndex = 0;
            this.cityCheckBox.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.cityCheckBox_ItemCheck);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Controls.Add(this.stateDropDown, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.StateHeader, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(200, 34);
            this.tableLayoutPanel2.TabIndex = 7;
            // 
            // stateDropDown
            // 
            this.stateDropDown.Dock = System.Windows.Forms.DockStyle.Fill;
            this.stateDropDown.FormattingEnabled = true;
            this.stateDropDown.Location = new System.Drawing.Point(0, 13);
            this.stateDropDown.Margin = new System.Windows.Forms.Padding(0);
            this.stateDropDown.Name = "stateDropDown";
            this.stateDropDown.Size = new System.Drawing.Size(200, 21);
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
            this.StateHeader.Size = new System.Drawing.Size(200, 13);
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
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 4;
            this.tableLayoutPanel5.SetRowSpan(this.tableLayoutPanel3, 2);
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(200, 450);
            this.tableLayoutPanel3.TabIndex = 8;
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.ColumnCount = 1;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel6.Controls.Add(this.categoriesCheckBox, 1, 1);
            this.tableLayoutPanel6.Controls.Add(this.categoriesTextBox, 1, 0);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(0, 310);
            this.tableLayoutPanel6.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 2;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(200, 140);
            this.tableLayoutPanel6.TabIndex = 9;
            // 
            // categoriesCheckBox
            // 
            this.categoriesCheckBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.categoriesCheckBox.FormattingEnabled = true;
            this.categoriesCheckBox.Location = new System.Drawing.Point(0, 13);
            this.categoriesCheckBox.Margin = new System.Windows.Forms.Padding(0);
            this.categoriesCheckBox.MultiColumn = true;
            this.categoriesCheckBox.Name = "categoriesCheckBox";
            this.categoriesCheckBox.Size = new System.Drawing.Size(200, 127);
            this.categoriesCheckBox.TabIndex = 0;
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
            this.categoriesTextBox.Size = new System.Drawing.Size(200, 13);
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
            this.tableLayoutPanel4.Location = new System.Drawing.Point(0, 172);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(200, 138);
            this.tableLayoutPanel4.TabIndex = 8;
            // 
            // zipCheckBox
            // 
            this.zipCheckBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.zipCheckBox.FormattingEnabled = true;
            this.zipCheckBox.Location = new System.Drawing.Point(0, 13);
            this.zipCheckBox.Margin = new System.Windows.Forms.Padding(0);
            this.zipCheckBox.MultiColumn = true;
            this.zipCheckBox.Name = "zipCheckBox";
            this.zipCheckBox.Size = new System.Drawing.Size(200, 125);
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
            this.ZipText.Size = new System.Drawing.Size(200, 13);
            this.ZipText.TabIndex = 4;
            this.ZipText.Text = "Zip";
            this.ZipText.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 2;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
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
            this.tableLayoutPanel5.Size = new System.Drawing.Size(800, 450);
            this.tableLayoutPanel5.TabIndex = 8;
            // 
            // tableLayoutPanel7
            // 
            this.tableLayoutPanel7.ColumnCount = 2;
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel7.Controls.Add(this.businessNameTextBox_Review, 0, 0);
            this.tableLayoutPanel7.Controls.Add(this.WriteReviewTextBox_Review, 0, 1);
            this.tableLayoutPanel7.Controls.Add(this.ShowReviewsButton, 1, 0);
            this.tableLayoutPanel7.Controls.Add(this.tableLayoutPanel8, 1, 1);
            this.tableLayoutPanel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel7.Location = new System.Drawing.Point(200, 270);
            this.tableLayoutPanel7.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel7.Name = "tableLayoutPanel7";
            this.tableLayoutPanel7.RowCount = 2;
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel7.Size = new System.Drawing.Size(600, 180);
            this.tableLayoutPanel7.TabIndex = 9;
            // 
            // businessNameTextBox_Review
            // 
            this.businessNameTextBox_Review.Dock = System.Windows.Forms.DockStyle.Fill;
            this.businessNameTextBox_Review.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.businessNameTextBox_Review.Location = new System.Drawing.Point(0, 0);
            this.businessNameTextBox_Review.Margin = new System.Windows.Forms.Padding(0);
            this.businessNameTextBox_Review.Name = "businessNameTextBox_Review";
            this.businessNameTextBox_Review.Size = new System.Drawing.Size(500, 38);
            this.businessNameTextBox_Review.TabIndex = 0;
            this.businessNameTextBox_Review.Text = "Business name (click on one)";
            // 
            // WriteReviewTextBox_Review
            // 
            this.WriteReviewTextBox_Review.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WriteReviewTextBox_Review.Location = new System.Drawing.Point(0, 38);
            this.WriteReviewTextBox_Review.Margin = new System.Windows.Forms.Padding(0);
            this.WriteReviewTextBox_Review.Multiline = true;
            this.WriteReviewTextBox_Review.Name = "WriteReviewTextBox_Review";
            this.WriteReviewTextBox_Review.Size = new System.Drawing.Size(500, 142);
            this.WriteReviewTextBox_Review.TabIndex = 1;
            // 
            // ShowReviewsButton
            // 
            this.ShowReviewsButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ShowReviewsButton.Location = new System.Drawing.Point(503, 3);
            this.ShowReviewsButton.Name = "ShowReviewsButton";
            this.ShowReviewsButton.Size = new System.Drawing.Size(94, 32);
            this.ShowReviewsButton.TabIndex = 2;
            this.ShowReviewsButton.Text = "Show Reviews";
            this.ShowReviewsButton.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel8
            // 
            this.tableLayoutPanel8.ColumnCount = 1;
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel8.Controls.Add(this.button1, 0, 1);
            this.tableLayoutPanel8.Controls.Add(this.comboBox1, 0, 0);
            this.tableLayoutPanel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel8.Location = new System.Drawing.Point(500, 38);
            this.tableLayoutPanel8.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel8.Name = "tableLayoutPanel8";
            this.tableLayoutPanel8.RowCount = 2;
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel8.Size = new System.Drawing.Size(100, 142);
            this.tableLayoutPanel8.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(3, 74);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(3, 3);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(94, 21);
            this.comboBox1.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tableLayoutPanel5);
            this.Name = "Form1";
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
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}

