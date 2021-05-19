using System;
using System.Data.SQLite;

namespace SQLiteDemo
{
    class Program
    {
        static void Main()
        {
            SQLiteConnectionStringBuilder stringBuilder = new();
            stringBuilder.DataSource = "MashineSettings.db";
            stringBuilder.Version = 3;
            stringBuilder.ForeignKeys = true; // serienmässig werden keine Fremdschlüssel geprüft (abwärtskompatibel). Wir möchten aber eine Überprüfung.
            stringBuilder.FailIfMissing = true; // serienmässig wird die datenbank neu erstellt wenn sie nicht vorhanden ist. Wir möchten aber eine fehlermeldung haben.

            using (SQLiteConnection connection = new(stringBuilder.ToString()))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "insert into Recipies (Name, WaterReq, CoffeeReq) values (@alpha, @beta, @gamma)";
                command.Parameters.AddWithValue("@alpha", "Schwarzer Kaffee");
                command.Parameters.AddWithValue("@beta", 20);
                command.Parameters.AddWithValue("@gamma", 5);

                int rowsAffected = command.ExecuteNonQuery();
                Console.WriteLine(rowsAffected);
            }


            // auslesen der Datenbank
            using (SQLiteConnection connection = new(stringBuilder.ToString()))
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
    }
}
