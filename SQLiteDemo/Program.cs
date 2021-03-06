using System;
using System.Data.SQLite;
using System.IO;
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

                            Console.Write($" {reader.GetByte(1), 3} {reader.GetByte(2),3} {reader.GetByte(3),3} ");
                            if (reader.IsDBNull(0))
                                Console.WriteLine("Kein Name");
                            else
                                Console.WriteLine(reader.GetString(0)); // varchar
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
            stringBuilder.FailIfMissing = false;
            using (SQLiteConnection connection = new(stringBuilder.ToString()))
            {
                connection.Open();
                var command = connection.CreateCommand();

                command.CommandText = File.ReadAllText("Recipies.sql");
                command.ExecuteNonQuery();
            }
            stringBuilder.FailIfMissing = true;
        }
    }
}
