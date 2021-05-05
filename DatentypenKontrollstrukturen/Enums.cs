using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatentypenKontrollstrukturen
{
    // wird verwendet wie ein integer wo jeder integer eine besondere bedeutung hat
    // im Code können wir das Wort verwenden um langes suchen in der Dokumentation
    // zu verhindern. 

    enum BenutzerStatus
    {
        Admin, // standardmässig wird ab 0 gezählt
        Professor,
        Student,
        Mitarbeiter,
        Assistent,
        Hausmeister,
        Besucher,
        length // kleiner trick wenn man wissen möchte wieviele werte im enum sind
    }

    enum RezeptOptionen
    {
        Kaffee = 0b_0001,
        Milch = 0b_0010,
        Zucker = 0b_0100,
        schokostreussel = 0b_1000,
        mandelaroma = 0b_0001_0000,
    }
    class Enums
    {
        public static void DoSomething()
        {
            BenutzerStatus status; // erstellt eine variable vom enum das wir oben erstellt haben

            status = BenutzerStatus.Admin; // weist status den wert Admin aus dem enum zu

            List<BenutzerStatus> StatusListe = new(); // wie bei einem normalen int können wir auch listen und arrays erstellen

            ///////////////////////////////////////////////////////
            // integer operationen funktionieren auch auf enum, sollten aber vermieden werden
            status++;

            for (BenutzerStatus counter = 0; counter < BenutzerStatus.length; counter++)
            {
                Console.WriteLine(counter);
            }

            /////////////////////////////////////////
            // Binäroperationen mit enum
            // häufig in c++, in c# eher selten anzutreffen

            OptionenBenutzen(RezeptOptionen.Kaffee | RezeptOptionen.Milch | RezeptOptionen.schokostreussel);
            // entspricht 0b_1011
        }

        private static void OptionenBenutzen(RezeptOptionen rezeptOptionen)
        {
            // übertragener wert 1011

            // Kaffee = 0001
            // Milch  = 0010
            // Zucker = 0100
            // Schoko = 1000

            // 1011
            // 0100
            // &
            // 0000

            if ((rezeptOptionen & RezeptOptionen.Kaffee) > 0)
                Console.WriteLine("Kaffe wurde gewünscht, Mahlwerk an");

            if ((rezeptOptionen & RezeptOptionen.Milch) > 0)
                Console.WriteLine("Milch wurde gewünscht");

            if ((rezeptOptionen & RezeptOptionen.Zucker) > 0)
                Console.WriteLine("Zucker kommt auch noch");

            if ((rezeptOptionen & RezeptOptionen.schokostreussel) > 0)
                Console.WriteLine("Streussel will der nutzer auch");

        }
    }
}
