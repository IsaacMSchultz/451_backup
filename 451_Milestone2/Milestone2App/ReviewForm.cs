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

namespace Milestone2App
{
    public partial class ReviewForm : Form
    {
        private static string LOGININFO = "Host=localhost; Username=postgres; Password=greatPassword; Database=milestone2db"; // Defines our connection to local databus
        public ReviewForm(string bid)
        {
            InitializeComponent();

            using (var connection = new NpgsqlConnection(LOGININFO))
            {
                connection.Open();
                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = connection;
                    cmd.CommandText = "SELECT * FROM review WHERE business_id = '" + bid + "' ORDER BY review_stars;";
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine(reader["review_stars"]);
                            Console.WriteLine(reader["date"]);
                            Console.WriteLine(reader["text"]);
                            Console.WriteLine(reader["useful_vote"]);
                            Console.WriteLine(reader["funny_vote"]);
                            Console.WriteLine(reader["cool_vote"]);
                            ReviewGrid.Rows.Add(reader["review_stars"], reader["date"], reader["text"], reader["useful_vote"], reader["funny_vote"], reader["cool_vote"]);
                        }
                    }
                }
                connection.Close();
            }
        }
    }
}
