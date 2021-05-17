using System.IO;

namespace BMP_Reader
{
    class BMPImage
    {
        BMPHeader headerInfo;
        string fileName;
        public BMPImage()
        {

        }

        /// <summary>
        /// Creates an <seealso cref="BMPImage">BMPImage</seealso> object and loads content of file into it
        /// </summary>
        /// <param name="FileName">Name of the file to load</param>
        public BMPImage(string FileName)
        {
            fileName = FileName;
            using (BinaryReader reader = new BinaryReader(File.OpenRead(fileName)))
            {
                // BMP-Datei mit dem BinaryReader lesen und Dateigrösse auf die Konsole ausgeben

                headerInfo.bfMagicA = reader.ReadChar();
                headerInfo.bfMagicB = reader.ReadChar();
                headerInfo.bfSize = reader.ReadUInt32();
                //headerInfo.bfReserved = reader.ReadUInt32();
                reader.BaseStream.Seek(4, SeekOrigin.Current);
                headerInfo.bfImageOffset = reader.ReadUInt32();
                headerInfo.biImageHeaderSize = reader.ReadUInt32();
                headerInfo.biWidth = reader.ReadInt32();
                headerInfo.biHeight = reader.ReadInt32();
                //headerInfo.biPlanes = reader.ReadUInt16();
                reader.BaseStream.Seek(2, SeekOrigin.Current);
                headerInfo.biBitCount = reader.ReadUInt16();
                headerInfo.biCompression = reader.ReadInt32();

                // Bonus1: Auflösung der Datei ausgeben
                // Bonus2: Bit pro pixel ausgeben
            }
        }

        public override string ToString()
        {
            return $"Bitmap {fileName} hat folgende Eigenschaften:\n" +
                   $"Dateigrösse: {headerInfo.bfSize, 8} Byte\n" +
                   $"Auflösung  : {headerInfo.biWidth} x {headerInfo.biHeight} Pixel\n"+
                   $"Farbtiefe  : {headerInfo.biBitCount} Bit";
        }
    }
}
