using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QueryEngine1;

namespace Milestone2App
{
    public partial class CheckinForm : Form
    {
        QueryEngine queryEngine;
        string userID;
        string businessID;
        DateTime day;
        public CheckinForm(string uID, string bID, DateTime today)
        {            
            queryEngine = new QueryEngine();
            userID = uID;
            businessID = bID;
            day = today;
            InitializeComponent();
            CheckinTimeSelector.Format = DateTimePickerFormat.Custom;
            CheckinTimeSelector.CustomFormat = "MMMM dd, yyyy HH:mm:ss tt";
        }

        private void SubmitCheckinButton_Click(object sender, EventArgs e)
        {
            Console.WriteLine(CheckinTimeSelector.Value);            
            queryEngine.AddCheckin(businessID, CheckinTimeSelector.Value);
            this.Close();
        }
    }
}
