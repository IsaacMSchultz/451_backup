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
using MapControlLibrary;

namespace Milestone2App
{
    public partial class MapForm : Form
    {
        public MapForm()
        {
            InitializeComponent();
        }

        // Never runs
        private void MapForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Enable the MapButton on the YelpGUI
            this.Hide();
            this.Parent = null;
            //e.Cancel = true;
        }

        // Don't need
        private void MapForm_Load(object sender, EventArgs e)
        {

        }

        private void MapForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            this.Parent = null;
            e.Cancel = true;
        }
    }
    
}
