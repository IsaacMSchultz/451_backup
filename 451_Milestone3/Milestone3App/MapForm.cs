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
        //private static string LOGININFO = "Host=localhost; Username=postgres; Password=greatPassword; Database=milestone2db"; // Defines our connection to local databus
        private static string LOGININFO = "Host=35.230.13.126; Username=postgres; Password=oiAv4Kmdup8Pd4vd; Database=milestone2db";
        
        public MapForm(string bid)
        {
            InitializeComponent();
            //UserControl1 tempUserControl = new UserControl1();

            using (var connection = new NpgsqlConnection(LOGININFO))
            {
                connection.Open();
                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = connection;
                    cmd.CommandText = "SELECT * FROM business WHERE business_id = '" + bid + "'";
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine(reader["longitude"]);
                            Console.WriteLine(reader["latitude"]);

                            //userControl11(double.Parse(reader["latitude"].ToString()), double.Parse(reader["longitude"].ToString()));
                        }
                    }
                }
                connection.Close();
            }
        }
    }
}
