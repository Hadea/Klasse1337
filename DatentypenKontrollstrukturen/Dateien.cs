﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DatentypenKontrollstrukturen
{
    class Dateien
    {
        public static void DoSomething()
        {

            // pfadangaben können mit beiden schrägstrichen erfolgen. Kommandomodus für schrägstriche durch das @ deaktiviert
            string pfad = @"c:\windows\" + "nsystem32.dll";
            if (File.Exists(pfad))
            {
                // wenn die datei existiert und auch vom aktuellen nutzer
                // zugreifbar ist
            }

            string TextDateiInhalt = File.ReadAllText("testLogo.txt");// liesst textdateien komplett in einen string
            string[] TextDateiInhaltZeilenweise = File.ReadAllLines("testLogo.txt");

            byte[] BinärDateiInhalt = File.ReadAllBytes("testdatei.bin");// liesst binärdateien in ein bytearray
            /*
            FileMode.CreateNew; // erstellt eine neue datei, wenn sie bereits existiert -> fehler
            FileMode.Create; // erstellt eine neue datei, wenn sie existiert wird sie überschrieben
            FileMode.Open; // öffnet eine bestehende datei, wenn sie nicht existiert oder keine rechte -> fehler
            FileMode.OpenOrCreate; // Öffnet die datei wenn sie existiert oder erstell sie
            FileMode.Append; // Öffnet eine datei und schiebt den lesekopf bis ans ende
            FileMode.Truncate; // Öffnet eine datei und entfernt dabei den inhalt
            */

            // klassischer stil
            FileStream MeineDatei = File.Open(pfad, FileMode.Open); // öffnet die datei
            MeineDatei.Write(BinärDateiInhalt); // schreibt den inhalt eines array in die datei
            MeineDatei.Close(); // schliesst die datei, nicht vergessen!

            // besserer stil
            // Im using wird eine ressource geöffnet und bleibt solange offen wie die geschweiften klammern gehen, das schliessen pasiert automatisch
            using (FileStream MeineDateiB = File.Open(pfad, FileMode.Open))
            {
                Console.WriteLine(MeineDateiB.Length);
            } // die ressource wird automatisch geschlossen und freigegeben

            using (StreamReader reader = new StreamReader("textdatei.txt"))
            {
                string zeile;
                int zeilenNummer = 0;

                while ((zeile = reader.ReadLine()) != null)
                {
                    Console.WriteLine("Zeile " + zeilenNummer++ + " enthält" + zeile);
                }
            }

        }

        public  static void WriteXML()
        {
            /////////////////////////////////////////////
            // Dateien schreiben

            //TODO: textserialisierung
            DataFormat data = new();
            data.Number = 200;
            data.Text = "Hallo Welt!";
            data.AuchVersteckt = false;
            data.IntList.Add(5);
            data.IntList.Add(7);
            data.IntList.Add(2);


            XmlSerializer xml = new(typeof(DataFormat));
            using (StreamWriter writer = new("data.xml"))
            {
                xml.Serialize(writer, data);
            }

            DataFormat fromDisk;

            if (File.Exists("data.xml"))
            {
                using (StreamReader reader = new("data.xml"))
                {
                    fromDisk = (DataFormat)xml.Deserialize(reader);
                }
            }


            //TODO: binärserialisierung
            //TODO: Handarbeit
        }
    }

    public class DataFormat
    {
        public int Number;
        public string Text;
        private bool Versteckt = true; // wird nicht serialisiert da die Serializer-Klasse private nicht lesen darf

        [XmlIgnore] // schaltet die serialisierung für die nächste variable ab
        public bool AuchVersteckt;

        public List<int> IntList = new();
    }


}
