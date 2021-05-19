using System;
using System.Data.SQLite;
using MySql.Data.MySqlClient;

namespace SQLiteDemo
{
    class Program
    {
        static void Main()
        {
            SQLiteConnectionStringBuilder sqliteConnectionString = new();
            sqliteConnectionString.DataSource = "MashineSettings.db";
            sqliteConnectionString.Version = 3;
            sqliteConnectionString.ForeignKeys = true; // serienmässig werden keine Fremdschlüssel geprüft (abwärtskompatibel). Wir möchten aber eine Überprüfung.
            sqliteConnectionString.FailIfMissing = true; // serienmässig wird die datenbank neu erstellt wenn sie nicht vorhanden ist. Wir möchten aber eine fehlermeldung haben.

            // auslesen der Datenbank

            LoadSQLite(sqliteConnectionString);
            Console.ReadLine();
        }

        private static void ReadMySQL()
        {
            MySqlConnectionStringBuilder mySqlConnectionString = new();
            mySqlConnectionString.UserID = "MusicDBUser";
            mySqlConnectionString.Password = "MusicDBPass";
            mySqlConnectionString.Server = "192.168.2.2";
            mySqlConnectionString.Database = "musicdb";

            using (MySqlConnection connection = new(mySqlConnectionString.ToString()))
            {
                connection.Open();
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "select name, releasedate from Album;";

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.Write(reader.GetString(0));
                        Console.Write(" ");
                        Console.Write(reader.GetDateTime(1));
                    }
                }
            }
        }

        private static void LoadSQLite(SQLiteConnectionStringBuilder sqliteConnectionString)
        {
            try
            {
                using (SQLiteConnection connection = new(sqliteConnectionString.ToString()))
                {
                    connection.Open();
                    SQLiteCommand command = connection.CreateCommand();
                    command.CommandText = "select Name, WaterReq, CoffeeReq, MilkReq from Recipies";

                    using (var reader = command.ExecuteReader()) // kommando ausführen und ergebnis in tabellenform empfangen
                    {
                        while (reader.Read()) // zeilenweise durch das ergebnis gehen
                        {
                            if (reader.IsDBNull(0))
                                Console.WriteLine("Kein Name");
                            else
                                Console.Write(reader.GetString(0)); // varchar

                            Console.Write(reader.GetByte(1)); // tinyint
                            Console.Write(reader.GetByte(2)); // tinyint
                            Console.Write(reader.GetByte(3)); //tinyint
                        }
                    }
                    Console.ReadLine();
                }
            }
            catch (SQLiteException)
            {
                RecreateDatabase(sqliteConnectionString);
            }
        }

        private static void RecreateDatabase(SQLiteConnectionStringBuilder stringBuilder)
        {
            using (SQLiteConnection connection = new(stringBuilder.ToString()))
            {
                connection.Open();
                var command = connection.CreateCommand();

                command.CommandText = "create table Recipies ...";
                command.ExecuteNonQuery();

                command.CommandText = "create table Container ...";
                command.ExecuteNonQuery();

                command.CommandText = "insert into Recipies (Name, WaterReq, CoffeeReq) values (@alpha, @beta, @gamma)";
                command.Parameters.AddWithValue("@alpha", "Schwarzer Kaffee");
                command.Parameters.AddWithValue("@beta", 20);
                command.Parameters.AddWithValue("@gamma", 5);
                int rowsAffected = command.ExecuteNonQuery();
                Console.WriteLine(rowsAffected);

                command.CommandText = "insert into Container ...";
                command.ExecuteNonQuery();
            }
        }
    }
}
