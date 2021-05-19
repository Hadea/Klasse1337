using System;
using System.Collections.Generic;
using System.IO;
using MySql.Data.MySqlClient;

namespace Geldautomat
{
    class ContainerData
    {
        List<Container> ContainerList = new();
        public BankNote SmallestNote
        {
            get { return ContainerList[^1].ContentType; }
        }
        MySqlConnectionStringBuilder builder = new();

        public ContainerData()
        {
            builder.Database = "ATM";
            builder.UserID = "ATMUser";
            builder.Password = "ATMPass";
            builder.Server = "192.168.2.2";
        }

        //public const string FileName = "ATMData.bin";
        public void Load()
        {
            try
            {
                using (MySqlConnection connection = new(builder.ToString()))
                {
                    ContainerList.Clear();
                    connection.Open();
                    MySqlCommand command = connection.CreateCommand();
                    command.CommandText = "select BankNoteID, CurrentCount from Containers";

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Container newContainer;
                            newContainer.ContentType = (BankNote)reader.GetByte(0);
                            newContainer.Current = reader.GetUInt16(1);
                            ContainerList.Add(newContainer);
                        }
                    }
                }
            }
            catch (FileNotFoundException) // datei nicht vorhanden
            {
                Console.WriteLine("Datei nicht gefunden, lade Standardwerte!");
                LoadDefaultContainer();
            }
            catch (DirectoryNotFoundException) // verzeichnis nicht vorhanden
            {
                Console.WriteLine("Verzeichnis nicht gefunden, lade Standardwerte!");
                LoadDefaultContainer();
            }
            catch (UnauthorizedAccessException) // zugriff verweigert
            {
                Console.WriteLine("Nicht genügend Rechte für Dateizugriff, lade Standardwerte!");
                LoadDefaultContainer();
            }
            ContainerList.Sort(containerDescComparer);

        }

        private void LoadDefaultContainer()
        {
            ContainerList.Add(new Container { ContentType = BankNote.Euro10, Current = 200 });
            ContainerList.Add(new Container { ContentType = BankNote.Euro20, Current = 200 });
            ContainerList.Add(new Container { ContentType = BankNote.Euro50, Current = 200 });
        }

        private int containerDescComparer(Container x, Container y)
        {
            return (x.ContentType < y.ContentType ? 1 : -1);
        }

        public List<NoteStack> Withdraw(uint abhebebetrag)
        {
            List<NoteStack> result = new();

            for (int containerID = 0; containerID < ContainerList.Count && abhebebetrag > 0; containerID++)
            {
                uint noteNeeded = abhebebetrag / (uint)ContainerList[containerID].ContentType;
                if (noteNeeded == 0) continue;
                Container currentContainer = ContainerList[containerID];
                ushort noteWithdraw = Math.Min((ushort)noteNeeded, currentContainer.Current);
                currentContainer.Current -= noteWithdraw;
                ContainerList[containerID] = currentContainer;
                abhebebetrag -= noteWithdraw * (uint)ContainerList[containerID].ContentType;
                NoteStack stack;
                stack.NoteType = ContainerList[containerID].ContentType;
                stack.Amount = noteWithdraw;
                result.Add(stack);
            }

            return result;

            // container durchgehen von grösstem zu kleinstem inhalt
            //      scheinanzahl  = abhebebetrag modulo containerinhalt
            //      Minimum zwischen scheinanzahl und kontainervorrat auswählen
            //      scheinanzahl und wert in Liste eintragen
            //      scheinwert mal gewählte scheine von abhebebetrag abziehen
            // ende container durchgehen

            // wenn abhebebetrag 0 ist
            //      scheine aus containern nehmen
            //      scheinliste zurückgeben
            // andernfalls
            //      Fehler ausgeben das die scheine nicht passen
            // ende wenn

        }

        public void Save()
        {
            try
            {
                using (MySqlConnection connection = new(builder.ToString()))
                {
                    connection.Open();
                    MySqlCommand command = connection.CreateCommand();
                    command.CommandText = "truncate Containers";
                    command.ExecuteNonQuery();

                    command.CommandText = "insert into Containers (BankNoteID, Currentcount) values ";

                    foreach (var item in ContainerList)
                    {
                        command.CommandText += $"({(byte)item.ContentType}, {item.Current}),";
                    }

                    command.CommandText = command.CommandText[..^1];
                    command.ExecuteNonQuery();
                }
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("Datei kann nicht gespeichert werden, da Rechte fehlen.");
            }
            catch (DirectoryNotFoundException)
            {
                Console.WriteLine("Verzeichnis für Datei wurde nicht gefunden. Daten nicht gespeichert!");
            }
        }
    }
}
