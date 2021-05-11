using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace StartupCounter
{
    class Program
    {
        private const string fileName = @"counter.bin";

        //TODO: XML-Serialisierung
        //TODO: WriteAllText
        //TODO: WriteAllBytes
        //TODO: BinaryReader/Writer (morgen erst im Unterricht)


        static void Main(string[] args)
        {
            // Aufgabe: Laden einer datei mit einer Zahl, diese um 1 erhöhen und wieder in die datei schreiben
            byte sessionCount = LoadData();
            sessionCount++; // zähler um 1 erhöhen
            SaveData(sessionCount);
            Console.WriteLine(sessionCount);
        }

        private static void SaveData(byte sessionCount)
        {
            using (Stream file = new FileStream(fileName, FileMode.Create, FileAccess.Write))// datei öffnen
            {
                BinaryFormatter formatter = new();
                DataFormat data = new();
                data.Counter = sessionCount;

                formatter.Serialize(file, data);//      Daten in datei serialisieren
            }// datei schliessen
        }

        private static byte LoadData()
        {
            if (!File.Exists(fileName))// wenn datei nicht vorhanden
            {
                return 0;//      zähler mit 0 beginnen
            }// ende wenn

            BinaryFormatter formatter = new();

            using (Stream file = new FileStream(fileName, FileMode.Open, FileAccess.Read))//      Datei öffnen
            {
                //          Inhalt der datei Deserialisieren und in variable ablegen
                object dataFromDisk = formatter.Deserialize(file);
                DataFormat dataFormatted = dataFromDisk as DataFormat;
                return dataFormatted.Counter;
            }//      Datei schliessen
        }

    }

    [Serializable]
    class DataFormat
    {
        public byte Counter;
    }

    // klasse erstellen welche die Datei-Daten repräsentiert
    //      eine Ganzzahl
}
