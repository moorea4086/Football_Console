using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Text;

namespace Football_cs
{
    class Kickoff
    {
        public Kickoff(string kicker, string return_man, string kicking_team, string receiving_team)
        {
            string DatabaseFile = "KickerStats2019.db";
            string DatabaseSource = "Data Source=" + DatabaseFile;
            int attempts;
            decimal avg_dist;
            int kickofffrom = 35;
            // put in averages of kick and return (should be linked to Player kicker and Player return_man)
            using (var connection = new SQLiteConnection(DatabaseSource))
            {
                using (var command = new SQLiteCommand(connection))
                {
                    connection.Open();

                    SQLiteDataReader sqlite_datareader;
                    var sql = $"SELECT attempts , avg_dist FROM Placekicker WHERE name = \"{kicker}\";";
                    var select_command = new SQLiteCommand(sql, connection);

                    sqlite_datareader = select_command.ExecuteReader();
                    while (sqlite_datareader.Read()) // Read() returns true if there is still a result line to read
                    {
                        attempts = sqlite_datareader.GetInt16(0);
                        avg_dist = sqlite_datareader.GetDecimal(1);
                        double kickoffdistance = KickoffDistance(avg_dist);
                        KickoffOutput(kicker, kicking_team, avg_dist, kickoffdistance);
                        var start_of_return = CalculateFieldPosition.calculatefieldposition(kickofffrom, kickoffdistance);
                    }
                    connection.Close();
                }
            }
        }

        public static double KickoffDistance(decimal avg_dist)
        {
            // https://stackoverflow.com/questions/218060/random-gaussian-variables
            Random rand = new Random(); //reuse this if you are generating many
            double u1 = 1.0 - rand.NextDouble(); //uniform(0,1] random doubles
            double u2 = 1.0 - rand.NextDouble();
            double randStdNormal = Math.Sqrt(-2.0 * Math.Log(u1)) *
                         Math.Sin(2.0 * Math.PI * u2); //random normal(0,1)
            double kickoffdistance =
                         (double)avg_dist + 3 * randStdNormal; //random normal(mean,stdDev^2)
            //var kickoffdistancestr = kickoffdistance.ToString("n1");
            //return kickoffdistancestr;
            return kickoffdistance;
        }

        public static void KickoffOutput(string kicker, string kicking_team, decimal avg_dist, double kickoffdistance) 
        {
            Console.WriteLine("{0} of the {1} has kickedoff {2} yards. His average distance is {3} yards.",
                        kicker, kicking_team, kickoffdistance.ToString("n1"), avg_dist);
        }        
    }
}
