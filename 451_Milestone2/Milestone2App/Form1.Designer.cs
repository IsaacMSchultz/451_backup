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
            this.cityDropDown = new System.Windows.Forms.ComboBox();
            this.stateDropDown = new System.Windows.Forms.ComboBox();
            this.SelctionDropDownPanel = new System.Windows.Forms.Panel();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.SelectionHeaderPanel = new System.Windows.Forms.Panel();
            this.ZipHeader = new System.Windows.Forms.TextBox();
            this.SelectionPanel = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.businessGrid)).BeginInit();
            this.SelctionDropDownPanel.SuspendLayout();
            this.SelectionHeaderPanel.SuspendLayout();
            this.SelectionPanel.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // businessGrid
            // 
            this.businessGrid.AllowUserToAddRows = false;
            this.businessGrid.AllowUserToDeleteRows = false;
            this.businessGrid.Location = new System.Drawing.Point(107, 125);
            this.businessGrid.Name = "businessGrid";
            this.businessGrid.ReadOnly = true;
            this.businessGrid.Size = new System.Drawing.Size(612, 270);
            this.businessGrid.TabIndex = 2;
            // 
            // StateHeader
            // 
            this.StateHeader.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.StateHeader.Cursor = System.Windows.Forms.Cursors.Default;
            this.StateHeader.Location = new System.Drawing.Point(0, 3);
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
            this.CityHeader.Location = new System.Drawing.Point(0, 24);
            this.CityHeader.Margin = new System.Windows.Forms.Padding(0);
            this.CityHeader.Name = "CityHeader";
            this.CityHeader.ReadOnly = true;
            this.CityHeader.Size = new System.Drawing.Size(40, 13);
            this.CityHeader.TabIndex = 4;
            this.CityHeader.Text = "City";
            this.CityHeader.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cityDropDown
            // 
            this.cityDropDown.Dock = System.Windows.Forms.DockStyle.Top;
            this.cityDropDown.FormattingEnabled = true;
            this.cityDropDown.Location = new System.Drawing.Point(0, 21);
            this.cityDropDown.Margin = new System.Windows.Forms.Padding(0);
            this.cityDropDown.Name = "cityDropDown";
            this.cityDropDown.Size = new System.Drawing.Size(760, 21);
            this.cityDropDown.TabIndex = 1;
            this.cityDropDown.Text = "Cities will be displayed once a state is selected...";
            this.cityDropDown.SelectedIndexChanged += new System.EventHandler(this.cityDropDown_SelectedIndexChanged);
            // 
            // stateDropDown
            // 
            this.stateDropDown.Dock = System.Windows.Forms.DockStyle.Top;
            this.stateDropDown.FormattingEnabled = true;
            this.stateDropDown.Location = new System.Drawing.Point(0, 0);
            this.stateDropDown.Margin = new System.Windows.Forms.Padding(0);
            this.stateDropDown.Name = "stateDropDown";
            this.stateDropDown.Size = new System.Drawing.Size(760, 21);
            this.stateDropDown.TabIndex = 0;
            this.stateDropDown.Text = "Select state...";
            this.stateDropDown.SelectedIndexChanged += new System.EventHandler(this.stateDropDown_SelectedIndexChanged);
            // 
            // SelctionDropDownPanel
            // 
            this.SelctionDropDownPanel.Controls.Add(this.comboBox1);
            this.SelctionDropDownPanel.Controls.Add(this.cityDropDown);
            this.SelctionDropDownPanel.Controls.Add(this.stateDropDown);
            this.SelctionDropDownPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SelctionDropDownPanel.Location = new System.Drawing.Point(40, 0);
            this.SelctionDropDownPanel.Margin = new System.Windows.Forms.Padding(0);
            this.SelctionDropDownPanel.Name = "SelctionDropDownPanel";
            this.SelctionDropDownPanel.Size = new System.Drawing.Size(760, 63);
            this.SelctionDropDownPanel.TabIndex = 3;
            // 
            // comboBox1
            // 
            this.comboBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(0, 42);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(0);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(760, 21);
            this.comboBox1.TabIndex = 2;
            this.comboBox1.Text = "Zipcodes will be displayed once a city is selected...";
            // 
            // SelectionHeaderPanel
            // 
            this.SelectionHeaderPanel.Controls.Add(this.ZipHeader);
            this.SelectionHeaderPanel.Controls.Add(this.CityHeader);
            this.SelectionHeaderPanel.Controls.Add(this.StateHeader);
            this.SelectionHeaderPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.SelectionHeaderPanel.Location = new System.Drawing.Point(0, 0);
            this.SelectionHeaderPanel.Margin = new System.Windows.Forms.Padding(0);
            this.SelectionHeaderPanel.Name = "SelectionHeaderPanel";
            this.SelectionHeaderPanel.Size = new System.Drawing.Size(40, 63);
            this.SelectionHeaderPanel.TabIndex = 4;
            // 
            // ZipHeader
            // 
            this.ZipHeader.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ZipHeader.Cursor = System.Windows.Forms.Cursors.Default;
            this.ZipHeader.Location = new System.Drawing.Point(0, 42);
            this.ZipHeader.Margin = new System.Windows.Forms.Padding(0);
            this.ZipHeader.Name = "ZipHeader";
            this.ZipHeader.ReadOnly = true;
            this.ZipHeader.Size = new System.Drawing.Size(40, 13);
            this.ZipHeader.TabIndex = 5;
            this.ZipHeader.Text = "Zip";
            this.ZipHeader.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // SelectionPanel
            // 
            this.SelectionPanel.Controls.Add(this.SelctionDropDownPanel);
            this.SelectionPanel.Controls.Add(this.SelectionHeaderPanel);
            this.SelectionPanel.Location = new System.Drawing.Point(0, 0);
            this.SelectionPanel.Margin = new System.Windows.Forms.Padding(0);
            this.SelectionPanel.Name = "SelectionPanel";
            this.SelectionPanel.Size = new System.Drawing.Size(800, 63);
            this.SelectionPanel.TabIndex = 5;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.businessGrid);
            this.panel4.Controls.Add(this.SelectionPanel);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(800, 450);
            this.panel4.TabIndex = 6;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel4);
            this.Name = "Form1";
            this.Text = "Milestone 1";
            ((System.ComponentModel.ISupportInitialize)(this.businessGrid)).EndInit();
            this.SelctionDropDownPanel.ResumeLayout(false);
            this.SelectionHeaderPanel.ResumeLayout(false);
            this.SelectionHeaderPanel.PerformLayout();
            this.SelectionPanel.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView businessGrid;
        private System.Windows.Forms.TextBox StateHeader;
        private System.Windows.Forms.TextBox CityHeader;
        private System.Windows.Forms.ComboBox cityDropDown;
        private System.Windows.Forms.ComboBox stateDropDown;
        private System.Windows.Forms.Panel SelctionDropDownPanel;
        private System.Windows.Forms.Panel SelectionHeaderPanel;
        private System.Windows.Forms.Panel SelectionPanel;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox ZipHeader;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}

