using System;
using System.IO;

namespace BMP_Reader
{
    class Program
    {
        static void Main(string[] args)
        {
            string filename;
            if (args.Length == 1) // prüft ob wir exakt einen einzigen parameter bekommen haben
            {
                filename = args[0];
                // Bonus5: Kommandozeilen-Parameter auswerten um dateinamen zu empfangen
            }
            else
            {
                filename = "red.bmp"; // andernfalls standard-bild wählen
            }

            if (File.Exists(filename)) // prüfen ob die gewählte datei auch existiert
            {
                BMPImage image = new BMPImage(filename); // datei laden
                Console.WriteLine(image); // nutzt die ToString() methode um informationen auszugeben
                Console.ReadLine();
                image.PrintColor();// gibt den inhalt der datei in etwa aus (die konsole kann nur wenig farben)
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Datei nicht gefunden");
            }
        }
    }
}
