using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Geldautomat
{
    class ContainerData
    {
        List<Container> ContainerList = new();

        public const string FileName = "ATMData.bin";
        public void Load()
        {
            if (File.Exists(FileName))
            {
                using (BinaryReader reader = new(File.OpenRead(FileName)))
                {
                    // check magic
                    byte[] magic = reader.ReadBytes(3);
                    if (magic[0] != 'A' || magic[1] != 'T' || magic[2] != 'M' )
                    {
                        throw new FileLoadException();
                    }

                    ContainerList.Clear();
                    byte containerCount = reader.ReadByte();
                    for (int counter = 0; counter < containerCount; counter++)
                    {
                        Container newContainer;
                        newContainer.Current = reader.ReadUInt16();
                        newContainer.ContentType = (BankNote)reader.ReadByte();
                    }
                }

            }
            else // datei nicht vorhanden
            {
                ContainerList.Add(new Container { ContentType = BankNote.Euro10, Current = 200 });
                ContainerList.Add(new Container { ContentType = BankNote.Euro20, Current = 200 });
                ContainerList.Add(new Container { ContentType = BankNote.Euro50, Current = 200 });
            }

        }

        public void Save()
        {
            using (BinaryWriter writer = new(File.OpenWrite(FileName)))
            {
                // magic schreiben
                writer.Write('A');
                writer.Write('T');
                writer.Write('M');

                // byte mit containeranzahl
                writer.Write((byte)ContainerList.Count);

                foreach (var item in ContainerList)// für jedes element in der Containerliste
                {
                    writer.Write(item.Current); //      short schreiben mit inhaltsAnzahl
                    writer.Write((byte)item.ContentType); //      byte schreiben mit inhaltsTyp
                }// ende für
            }
        }
    }
}
