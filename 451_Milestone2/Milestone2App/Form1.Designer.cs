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
            this.StateHeader = new System.Windows.Forms.TextBox();
            this.CityHeader = new System.Windows.Forms.TextBox();
            this.stateDropDown = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.cityCheckBox = new System.Windows.Forms.CheckedListBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.zipCheckBox = new System.Windows.Forms.CheckedListBox();
            this.ZipText = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.businessGrid)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // businessGrid
            // 
            this.businessGrid.AllowUserToAddRows = false;
            this.businessGrid.AllowUserToDeleteRows = false;
            this.businessGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.businessGrid.Location = new System.Drawing.Point(203, 3);
            this.businessGrid.Name = "businessGrid";
            this.businessGrid.ReadOnly = true;
            this.businessGrid.Size = new System.Drawing.Size(594, 444);
            this.businessGrid.TabIndex = 2;
            // 
            // StateHeader
            // 
            this.StateHeader.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.StateHeader.Cursor = System.Windows.Forms.Cursors.Default;
            this.StateHeader.Location = new System.Drawing.Point(0, 4);
            this.StateHeader.Margin = new System.Windows.Forms.Padding(0);
            this.StateHeader.Name = "StateHeader";
            this.StateHeader.ReadOnly = true;
            this.StateHeader.Size = new System.Drawing.Size(40, 13);
            this.StateHeader.TabIndex = 3;
            this.StateHeader.Text = "State";
            this.StateHeader.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // CityHeader
            // 
            this.CityHeader.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.CityHeader.Cursor = System.Windows.Forms.Cursors.Default;
            this.CityHeader.Location = new System.Drawing.Point(0, 100);
            this.CityHeader.Margin = new System.Windows.Forms.Padding(0);
            this.CityHeader.Name = "CityHeader";
            this.CityHeader.ReadOnly = true;
            this.CityHeader.Size = new System.Drawing.Size(40, 13);
            this.CityHeader.TabIndex = 4;
            this.CityHeader.Text = "City";
            this.CityHeader.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // stateDropDown
            // 
            this.stateDropDown.Dock = System.Windows.Forms.DockStyle.Fill;
            this.stateDropDown.FormattingEnabled = true;
            this.stateDropDown.Location = new System.Drawing.Point(40, 0);
            this.stateDropDown.Margin = new System.Windows.Forms.Padding(0);
            this.stateDropDown.Name = "stateDropDown";
            this.tableLayoutPanel2.SetRowSpan(this.stateDropDown, 3);
            this.stateDropDown.Size = new System.Drawing.Size(160, 21);
            this.stateDropDown.TabIndex = 0;
            this.stateDropDown.Text = "Select state...";
            this.stateDropDown.SelectedIndexChanged += new System.EventHandler(this.stateDropDown_SelectedIndexChanged);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.CityHeader, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.cityCheckBox, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 21);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(200, 214);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // cityCheckBox
            // 
            this.cityCheckBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cityCheckBox.FormattingEnabled = true;
            this.cityCheckBox.Location = new System.Drawing.Point(40, 0);
            this.cityCheckBox.Margin = new System.Windows.Forms.Padding(0);
            this.cityCheckBox.MultiColumn = true;
            this.cityCheckBox.Name = "cityCheckBox";
            this.tableLayoutPanel1.SetRowSpan(this.cityCheckBox, 3);
            this.cityCheckBox.Size = new System.Drawing.Size(160, 214);
            this.cityCheckBox.TabIndex = 0;
            this.cityCheckBox.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.cityCheckBox_ItemCheck);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.stateDropDown, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.StateHeader, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(200, 21);
            this.tableLayoutPanel2.TabIndex = 7;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel4, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel1, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 3;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 21F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(200, 450);
            this.tableLayoutPanel3.TabIndex = 8;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Controls.Add(this.zipCheckBox, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.ZipText, 0, 1);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(0, 235);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 3;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(200, 215);
            this.tableLayoutPanel4.TabIndex = 8;
            // 
            // zipCheckBox
            // 
            this.zipCheckBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.zipCheckBox.FormattingEnabled = true;
            this.zipCheckBox.Location = new System.Drawing.Point(40, 0);
            this.zipCheckBox.Margin = new System.Windows.Forms.Padding(0);
            this.zipCheckBox.MultiColumn = true;
            this.zipCheckBox.Name = "zipCheckBox";
            this.tableLayoutPanel4.SetRowSpan(this.zipCheckBox, 3);
            this.zipCheckBox.Size = new System.Drawing.Size(160, 215);
            this.zipCheckBox.TabIndex = 0;
            this.zipCheckBox.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.zipCheckBox_ItemCheck);
            // 
            // ZipText
            // 
            this.ZipText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ZipText.Cursor = System.Windows.Forms.Cursors.Default;
            this.ZipText.Location = new System.Drawing.Point(0, 101);
            this.ZipText.Margin = new System.Windows.Forms.Padding(0);
            this.ZipText.Name = "ZipText";
            this.ZipText.ReadOnly = true;
            this.ZipText.Size = new System.Drawing.Size(40, 13);
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
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(800, 450);
            this.tableLayoutPanel5.TabIndex = 8;
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
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.tableLayoutPanel5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView businessGrid;
        private System.Windows.Forms.TextBox StateHeader;
        private System.Windows.Forms.TextBox CityHeader;
        private System.Windows.Forms.ComboBox stateDropDown;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.CheckedListBox cityCheckBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.CheckedListBox zipCheckBox;
        private System.Windows.Forms.TextBox ZipText;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
    }
}

