using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SQLite;
using System.IO;
using Dapper; 
using System.Linq;
using Football_cs.Model;

// https://stackoverflow.com/questions/51536857/what-is-best-practice-to-initialize-c-sharp-objects-from-an-sqlite-database-perf
// https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1.getenumerator?view=netframework-4.8

namespace Football_cs
{
    public class Database
    {
        private const string DatabaseFile = "Rosters2019.db";
        private const string DatabaseSource = "Data Source=" + DatabaseFile;

        public static IEnumerable<Player> Roster(string team)
        //public static List<Player> Roster(string team)
        {
            // Connect to the database
            using (var connection = new SQLiteConnection(DatabaseSource))
            {
                // Create a database command
                using (var command = new SQLiteCommand(connection))
                {
                    connection.Open();

                    SQLiteDataReader sqlite_datareader;  // Data Reader Object

                    //    // Create the table
                    //    //command.CommandText = CreateTableQuery;
                    //    //command.ExecuteNonQuery();

                    //    //// Insert entries in database table
                    //    //command.CommandText = "INSERT INTO MyTable (Key,Value) VALUES ('key one','value one')";
                    //    //command.ExecuteNonQuery();
                    //    //command.CommandText = "INSERT INTO MyTable (Key,Value) VALUES ('key two','value two')";
                    //    //command.ExecuteNonQuery();

                    //    // Select and display database entries
                    command.CommandText = $"SELECT Position, STARTER, `2ND` , `3RD` , `4TH` FROM \"{team}\";";

                    sqlite_datareader = command.ExecuteReader();



                    // The SQLiteDataReader allows us to run through each row per loop
                    //while (sqlite_datareader.Read()) // Read() returns true if there is still a result line to read
                    //{
                    //    object idReader = sqlite_datareader.GetValue(0);
                    //    string textReader = sqlite_datareader.GetString(1);

                    //    Console.WriteLine(idReader + " '" + textReader + "' " + "\n");
                    //}
                    // Close the connection to the database
                    connection.Close();
                }

                using (var cnn = new SQLiteCommand(connection))
                {
                    connection.Open();
                    //var query_starters =  $"SELECT Position, STARTER as Starter FROM \"{team}\";";
                    //var query_second =    $"SELECT Position, `2ND` as Second FROM \"{team}\";";
                    //var query_third =     $"SELECT Position, `3RD` as Third FROM \"{team}\";";
                    //var query_fourth =    $"SELECT Position, `4TH` as Fourth FROM \"{team}\";";
                    var sql = $"SELECT Position, STARTER as Starter, `2ND` as Second, `3RD` as Third, `4TH` as Fourth FROM \"{team}\";";
                    var roster = connection.Query<Player>(sql);

                    //var starters = connection.Query<Player>(query_starters).ToList();
                    //var second = connection.Query<Player>(query_second).ToList();
                    //var third = connection.Query<Player>(query_third).ToList();
                    //var fourth = connection.Query<Player>(query_fourth).ToList();

                    //var result = from st in starters
                    //             join se in second on st.Position equals se.Position into g
                    //             select new
                    //             {
                    //                 Position = st.Position,
                    //                 Starter = st.Second,
                    //                 Second = g.Any() ? g.First().Second : null
                    //             };

                    //var result = 
                    //    from st in starters
                    //    join se in second 
                    //    on st.Position equals se.Position
                    //    select new
                    //    {
                    //        st.Position,
                    //        st.Starter,
                    //        se.Second
                    //    };


                    // test
                    //foreach (Player line in dataClassList)
                    //{
                    //    Console.WriteLine(line.STARTER);
                    //}
                    connection.Close();
                    return roster;
                }
            }
        }
    }
}
