using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Text;
using System.Data;

namespace Football_cs
{
    class TeamNames
    {
        public static List<string> TeamNamesList()
        {
            string DatabaseFile = "Rosters2019.db";
            string DatabaseSource = "Data Source=" + DatabaseFile;
            List<string> teamnames = new List<string>();
            // put in averages of kick and return (should be linked to Player kicker and Player return_man)
            using (var connection = new SQLiteConnection(DatabaseSource))
            {
                using (var command = new SQLiteCommand(connection))
                {
                    connection.Open();

                    //SQLiteDataReader sqlite_datareader;
                    //var sql = $"SELECT name FROM sqlite_master WHERE type = 'table' ORDER BY 1;";
                    //var select_command = new SQLiteCommand(sql, connection);

                    //List<string> tables = new List<string>();
                    //using (SQLiteConnection con = GetConnection())
                    //{
                      //  con.Open();
                    DataTable dt = connection.GetSchema("Tables");
                    foreach (DataRow row in dt.Rows)
                    {
                        string tablename = (string)row[2];
                        //Console.WriteLine(tablename);
                        teamnames.Add(tablename);
                        connection.Close();
                    }
                }
            }
            teamnames.Sort();
            foreach (string team in teamnames)
            {
                Console.WriteLine(team);
            }
            return teamnames;
        }
    }
}
