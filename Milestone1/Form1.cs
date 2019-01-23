using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Milestone1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            string[] test = new string[] { "test1", "test2", "Arizona" };
            string[] testCity = new string[] { "Tucson", "Pheonix" };
            InitializeComponent();
            stateDropDown.Items.AddRange(test);
            cityDropDown.Items.AddRange(testCity);
        }

        private void initializeDropDowns()
        {
            // TODO:
            // interact with database to query the list of states contained within      
            // update states dropdown menu
        }

        private void stateDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            // need to look in MSD

            // query database to get list of cities in the selected state
            // update city dropdown with list
        }
    }
}
