using System;
using System.IO;

namespace BMP_Reader
{
    class Program
    {
        static void Main(string[] args)
        {
            string filename;
            if (args.Length == 1)
            {
                filename = args[0];
            // Bonus5: Kommandozeilen-Parameter auswerten um dateinamen zu empfangen
            }
            else
            {
                filename = "red.bmp";
            }

            if (File.Exists(filename))
            {
            BMPImage image = new BMPImage(filename);
            Console.WriteLine(image);

            }
            else
            {
                Console.WriteLine("Datei nicht gefunden");
            }

            for (int counter = 0; counter < filename.Length; counter++)
            {

            }
        }
    }
}
