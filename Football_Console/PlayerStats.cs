using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SQLite;

namespace Football_cs
{
    class PlayerStats
    {
        public static void playerstats()
        {
            string DatabaseFile = "KickerStats2019.db";
            string DatabaseSource = "Data Source=" + DatabaseFile;
            // Connect to the database
            using (var connection = new SQLiteConnection(DatabaseSource))
            {
                using (var command = new SQLiteCommand(connection))
                {
                    connection.Open();
                    ///////////////////// not for production
                    command.CommandText = " DROP Table if exists Placekicker";
                    command.ExecuteNonQuery();
                    ////////////////////
                    string sql = "create table Placekicker (name string, attempts int, avg_dist decimal(2,1), touchbacks int, returned int, avg_return decimal(2,1))";
                    var create_command = new SQLiteCommand(sql, connection);
                    create_command.ExecuteNonQuery();

                    sql = "insert into Placekicker (name, attempts, avg_dist, touchbacks, returned, avg_return) values ('Justin Tucker',647,64.0,410,221,22.2)"; // J. Tucker from NFL.com
                    var insert_command = new SQLiteCommand(sql, connection);
                    insert_command.ExecuteNonQuery();

                    sql = "insert into Placekicker (name, attempts, avg_dist, touchbacks, returned, avg_return) values ('Chris Boswell',367,63.3,192,168,22.3)"; // from NFL.com
                    insert_command = new SQLiteCommand(sql, connection);
                    insert_command.ExecuteNonQuery();

                    connection.Close();
                }
            }
        }
    }
}
