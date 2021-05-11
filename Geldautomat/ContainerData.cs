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

        public const string FileName = "Data.xml";
        public void Load()
        {
            if (File.Exists(FileName))
            {
                XmlSerializer xml = new(typeof(ContainerData));
                using (StreamReader reader = new(FileName))
                {

                    object data = xml.Deserialize(reader);
                    ContainerData dataAsContainer = data as ContainerData;
                    ContainerList = dataAsContainer.ContainerList;

                    //ContainerList = ((ContainerData)xml.Deserialize(reader)).ContainerList;
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
            XmlSerializer xml = new(typeof(ContainerData));

            using (StreamWriter writer = new(FileName))
            {
                xml.Serialize(writer, this);
            }
        }
    }
}
