﻿using System;
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

        private static string LOGININFO = "Host=localhost; Username=postgres; Password=greatPassword; Database=milestone1db";

        public class Business
        {
            public string name { get; set; }
            public string state { get; set; }
            public string city { get; set; }
        }

        public Form1()
        {
            InitializeComponent();
            initializeDropDowns();
        }

        private void initializeDropDowns()
        {
            // interact with database to query the list of states contained within      
            // update states dropdown menu with the list of distinct states
            // 'using' keyword to auto call dispose when we are done.
            using (var connection = new NpgsqlConnection(LOGININFO))
            {
                connection.Open();
                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = connection;
                    cmd.CommandText = "SELECT distinct state FROM business ORDER BY state;";
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                            stateDropDown.Items.Add(reader.GetString(0));
                    }
                }
                connection.Close();
            }

            DataGridViewTextBoxColumn col1 = new DataGridViewTextBoxColumn();
            col1.HeaderText = "Business name";
            col1.Width = 255;
            businessGrid.Columns.Add(col1);

            DataGridViewTextBoxColumn col2 = new DataGridViewTextBoxColumn();
            col2.HeaderText = "City";
            col2.Width = 115;
            businessGrid.Columns.Add(col2);

            DataGridViewTextBoxColumn col3 = new DataGridViewTextBoxColumn();
            col3.HeaderText = "State";
            col3.Width = 50;
            businessGrid.Columns.Add(col3);
        }

        private void stateDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox box = (ComboBox)sender; //casts sender as a ComboBox

            // query database to get list of cities in the selected state
            // update city dropdown with list
            using (var connection = new NpgsqlConnection(LOGININFO))
            {
                connection.Open();
                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = connection;
                    cmd.CommandText = "SELECT distinct city FROM business WHERE business.state = '" + box.SelectedItem + "' ORDER BY city;";
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                            cityDropDown.Items.Add(reader.GetString(0));
                    }
                }
                connection.Close();
            }
        }

        private void cityDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            while (businessGrid.RowCount > 0)
                businessGrid.Rows.RemoveAt(0);

            // populate data into businessGrid from database with the city and state from each dropdown.
            using (var connection = new NpgsqlConnection(LOGININFO))
            {
                connection.Open();
                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = connection;
                    cmd.CommandText = "SELECT * FROM business WHERE city = '" + cityDropDown.SelectedItem + "' AND state = '" + stateDropDown.SelectedItem + "' ORDER BY state;";
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine(reader.GetString(0));
                            Console.WriteLine(reader.GetString(1));
                            Console.WriteLine(reader.GetString(2));
                            //cityDropDown.Items.Add(reader.GetString(0));
                            businessGrid.Rows.Add(reader.GetString(0), reader.GetString(1), reader.GetString(2));
                        }
                    }
                }
                connection.Close();
            }
        }
    }
}
