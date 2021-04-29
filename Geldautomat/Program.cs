using System;

namespace Geldautomat
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Hallo, ich bin ein Geldautomat");
            Console.WriteLine("Bitte Karte einschieben");
            string cardID;
            cardID = Console.ReadLine();

            if (cardID[0] != 'K')
            {
                Console.WriteLine("Karte wird eingezogen weil ungültig");
                return;
            }

            // bis zu 3x nach PIN fragen, wenn dann noch immer falsch -> sperren und ende

            // fragen wieviel geld der nutzer haben möchte

            // geld ausgeben (writeline genügt)
            // karte ausgeben (writeline genügt)
            // geld abbuchen (writeline genügt)
        }
    }
}
