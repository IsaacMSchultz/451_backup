using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace Milestone1
{
    public partial class Form1 : Form
    {

        public class Business
        {
            public string name { get; set; }
            public string state { get; set; }
            public string city { get; set; }
        }

        public Form1()
        {
            string[] test = new string[] { "test1", "test2", "Arizona" };
            string[] testCity = new string[] { "Tucson", "Pheonix" };
            InitializeComponent();
            initializeDropDowns();
            stateDropDown.Items.AddRange(test);
            cityDropDown.Items.AddRange(testCity);
        }

        private void initializeDropDowns()
        {
            // TODO:
            // interact with database to query the list of states contained within      
            // update states dropdown menu

            // 'using' keyword to auto call dispose when we are done.
            using (var connection = new NpgsqlConnection("Host=localhost; Username=postgres; Password=greatPassword; Database=milestone1db"))
            {
                connection.Open();
                using (var cmd = new NpgsqlCommand())
                {
                    
                }
            }

            DataGridViewTextBoxColumn col1 = new DataGridViewTextBoxColumn();
            col1.HeaderText = "Business name";
            col1.Width = 255;
            businessGrid.Columns.Add(col1);

            DataGridViewTextBoxColumn col2 = new DataGridViewTextBoxColumn();
            col2.HeaderText = "State";
            col2.Width = 255;
            businessGrid.Columns.Add(col2);
        }

        private void stateDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            // need to look in MSD

            // query database to get list of cities in the selected state
            // update city dropdown with list
        }

        private void cityDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            // populate data into businessGrid from database
        }
    }
}
