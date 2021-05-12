using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

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
            byte[] sessionCounter = new byte[4];
            sessionCounter[0] = LoadDataBinary();
            sessionCounter[1] = LoadDataXML();
            sessionCounter[2] = LoadDataAllBytes();

            for (int counter = 0; counter < sessionCounter.Length; counter++)
            {
                sessionCounter[counter]++; // zähler um 1 erhöhen
            }

            SaveDataBinary(sessionCounter[0]);
            SaveDataXML(sessionCounter[1]);
            SaveDataAllBytes(sessionCounter[2]);

            foreach (var item in sessionCounter)
            {
                Console.WriteLine(item);
            }
        }

        private static void SaveDataAllBytes(byte ValueToWrite)
        {
            // daten vorbereiten
            byte[] fileData = new byte[4];
            fileData[0] = 83; // ein S
            fileData[1] = 67; // ein C
            fileData[2] = 1; // versionsnummer des dateityps            
            fileData[3] = ValueToWrite;

            File.WriteAllBytes("counterByteArray.sc", fileData);
        }

        private static byte LoadDataAllBytes()
        {
            byte[] dataFromDisk;
            if (!File.Exists("counterByteArray.sc")) return 0;

            dataFromDisk = File.ReadAllBytes("counterByteArray.sc");
            if (dataFromDisk[0] == 83 && dataFromDisk[1] == 67)
            {
                // richtige datei
                if (dataFromDisk[2] == 1)
                {
                    // richtige formatversion
                    return dataFromDisk[3];
                }
                else
                {
                    // falsche formatversion
                    return 0;
                }

            }
            else
            {
                return 0;
            }


        }

        private static void SaveDataXML(byte ValueToSave)
        {
            XmlSerializer xml = new(typeof(DataFormat)); // serializer vorbereiten für den zu schreibenden Typ

            // ein Objekt vom vorbereiteten Typ erstellen und befüllen
            DataFormat objectPreparedForDisk = new();
            objectPreparedForDisk.Counter = ValueToSave;

            using (StreamWriter writer = new("counter.xml"))
            {
                xml.Serialize(writer, objectPreparedForDisk); // objekt auf festplatte speichern
            }
        }

        private static byte LoadDataXML()
        {
            if (!File.Exists("counter.xml")) return 0;

            XmlSerializer xml = new(typeof(DataFormat));

            using (StreamReader reader = new("counter.xml"))
            {
                object dataFromDisk = xml.Deserialize(reader);
                DataFormat original = dataFromDisk as DataFormat; // null wenn es nicht geht
                return original.Counter;
            }
        }

        private static void SaveDataBinary(byte sessionCount)
        {
            // Daten vorbereiten für die Festplatte
            DataFormat data = new();
            data.Counter = sessionCount;

            // Serializer für den datentransfer auf die festplatte starten
            BinaryFormatter formatter = new();

            using (Stream file = new FileStream(fileName, FileMode.Create, FileAccess.Write))// datei öffnen
            {
                formatter.Serialize(file, data);//      Daten in datei serialisieren
            }// datei schliessen
        }

        private static byte LoadDataBinary()
        {
            if (!File.Exists(fileName))// wenn datei nicht vorhanden
            {
                return 0;//      zähler mit 0 beginnen
            }// ende wenn

            BinaryFormatter formatter = new();

            using (Stream file = new FileStream(fileName, FileMode.Open, FileAccess.Read))// Datei öffnen
            {
                // Inhalt der datei Deserialisieren und in variable ablegen
                object dataFromDisk = formatter.Deserialize(file); //liesst den inhalt der datei in den RAM
                DataFormat dataFormatted = dataFromDisk as DataFormat; //interpretiert den bereich des RAM als ein DataFormat-Objekt
                return dataFormatted.Counter; // ganz normaler zugriff als ob das objekt in C# erstellt wurde 
            }//      Datei schliessen
        }
    }
}
