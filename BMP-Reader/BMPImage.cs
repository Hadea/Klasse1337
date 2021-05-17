using System;
using System.IO;

namespace BMP_Reader
{
    class BMPImage
    {
        BMPHeader headerInfo;
        string fileName;
        Color[,] colorInfo;
        public BMPImage()
        {
            fileName = string.Empty;
        }

        /// <summary>
        /// Creates an <seealso cref="BMPImage">BMPImage</seealso> object and loads content of file into it
        /// </summary>
        /// <param name="FileName">Name of the file to load</param>
        public BMPImage(string FileName)
        {
            fileName = FileName; // merken des dateinamens für später
            using (BinaryReader reader = new BinaryReader(File.OpenRead(fileName))) // datei lesend mit einem reader öffnen
            {
                // der reihenfolge nach die werte aus der datei holen
                // https://de.wikipedia.org/wiki/Windows_Bitmap
                // jeder lesevorgang schiebt den lesekopf auch weiter.
                // die Datei wird dabei nicht vollständig in den RAM geladen sodass wir viel Speicher sparen
                // Das Betriebssystem kümmert sich datum das der Lesekopf immer daten zur verfügung hat und läd
                // automatisch den nächsten teil der Datei in den RAM

                headerInfo.bfMagicA = reader.ReadChar();
                headerInfo.bfMagicB = reader.ReadChar();
                headerInfo.bfSize = reader.ReadUInt32();
                //headerInfo.bfReserved = reader.ReadUInt32(); // brauchen wir nicht, deshalb übersprungen
                reader.BaseStream.Seek(4, SeekOrigin.Current); // überspringen von werten
                headerInfo.bfImageOffset = reader.ReadUInt32();
                headerInfo.biImageHeaderSize = reader.ReadUInt32();
                headerInfo.biWidth = reader.ReadInt32();
                headerInfo.biHeight = reader.ReadInt32();
                //headerInfo.biPlanes = reader.ReadUInt16(); // brauchen wir nicht, deshalb übersprungen
                reader.BaseStream.Seek(2, SeekOrigin.Current); // weitere 2 byte überspringen
                headerInfo.biBitCount = reader.ReadUInt16();
                headerInfo.biCompression = reader.ReadInt32();

                reader.BaseStream.Seek(headerInfo.bfImageOffset, SeekOrigin.Begin); // sprung an die position wo die bilddaten beginnen

                colorInfo = new Color[headerInfo.biHeight, headerInfo.biWidth]; // array für die Pixel erstellen

                // pixel für pixel füllen
                for (int y = 0; y < headerInfo.biHeight; y++)
                {
                    for (int x = 0; x < headerInfo.biWidth; x++)
                    {
                        byte[] pixeldata = reader.ReadBytes(3); // BMP-Format speichert in BGR
                        colorInfo[y, x].Blue = pixeldata[0];
                        colorInfo[y, x].Green = pixeldata[1];
                        colorInfo[y, x].Red = pixeldata[2];
                    }
                    // wenn die zeilenlänge nicht durch 4 teilbar ist werden füllbytes angehängt
                    // die füllbytes müssen übersprungen werden um in der nächsten zeile weiterlesen zu können
                    // das wird gemacht da grafikkarten nur quadratische Bilder 2^x speichern
                    reader.BaseStream.Seek(headerInfo.biWidth % 4, SeekOrigin.Current);
                }

                // Bonus1: Auflösung der Datei ausgeben
                // Bonus2: Bit pro pixel ausgeben
            }
        }

        public override string ToString() // ersetzt die geerbte ToString durch eine selbstgeschriebene
        {
            //erstellt einen string mit den wichtigsten informationen zu dem Bild
            return $"Bitmap {fileName} hat folgende Eigenschaften:\n" +
                   $"Dateigrösse: {headerInfo.bfSize,8} Byte\n" +
                   $"Auflösung  : {headerInfo.biWidth} x {headerInfo.biHeight} Pixel\n" +
                   $"Farbtiefe  : {headerInfo.biBitCount} Bit";
        }

        public void PrintColor()
        {
            //TODO: check if top-down or bottom-up

            // durch das array durchgehen pixel für pixel
            for (int y = 0; y < headerInfo.biHeight; y++)
            {
                for (int x = 0; x < headerInfo.biWidth; x++)
                {

                    ConsoleColor choosenColor = ConsoleColor.Black;//ausgangsfarbe ist 0,0,0 also schwarz

                    // rot reinmischen, je nachdem wie stark es auftritt
                    if (colorInfo[y, x].Red > 160) choosenColor = choosenColor | ConsoleColor.Red;
                    else if (colorInfo[y, x].Red > 80) choosenColor = choosenColor | ConsoleColor.DarkRed;

                    // grün reinmischen, je nachdem wie stark es auftritt
                    if (colorInfo[y, x].Green > 160) choosenColor = choosenColor | ConsoleColor.Green;
                    else if (colorInfo[y, x].Green > 80) choosenColor = choosenColor | ConsoleColor.DarkGreen;

                    // blau reinmischen, je nachdem wie stark es auftritt
                    if (colorInfo[y, x].Blue > 160) choosenColor = choosenColor | ConsoleColor.Blue;
                    else if (colorInfo[y, x].Blue > 80) choosenColor = choosenColor | ConsoleColor.DarkBlue;

                    Console.BackgroundColor = choosenColor; //hintergrund auf die gewünschte farbe stellen
                    Console.Write("  ");// zwei leerzeichen mit der hintergrundfarbe zeichnen, es wird dadurch quadratisch
                    // gesamthelligkeit
                }
                Console.WriteLine();// zeilenumbruch nachdem eine zeile des bildes gezeichnet wurde
            }
            Console.ResetColor();// am ende farben wieder auf die nutzereinstellung zurücksetzen
        }
    }
}
