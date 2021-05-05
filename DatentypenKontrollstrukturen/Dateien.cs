using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

                while((zeile = reader.ReadLine()) != null)
                {
                    Console.WriteLine("Zeile " + zeilenNummer++ + " enthält" + zeile);
                }
            }
        }
    }
}
