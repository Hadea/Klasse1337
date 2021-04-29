using System;

namespace Geldautomat
{
    class Program
    {

        static void Main()
        {
            PrintGreeting();

            string cardID;
            cardID = Console.ReadLine(); // entspricht std::cin , liesst von der konsole bis zum enter

            if (cardID[0] != 'K')
            {
                Console.WriteLine("Karte wird eingezogen weil ungültig");
                return;
            }


            Console.WriteLine("Bitte Pin eingeben:");
            bool LoginStatus = false;
            byte TriesRemaining = 3;
            do
            {
                string pin = Console.ReadLine();
                if (pin == "1337")
                {
                    LoginStatus = true;
                    break;
                }
                Console.WriteLine("Pin falsch!");

            } while (--TriesRemaining > 0);

            if (LoginStatus == false)
            {
                Console.WriteLine("3x Falscher Pin. Karte eingezogen");
                return;
            }

            Console.WriteLine("Wieviel Geld möchten sie abheben?");
            string Abhebebetrag = Console.ReadLine();

            Console.WriteLine("Ihr Geld: " + Abhebebetrag + " wird ausgeworfen");
            Console.WriteLine("Ihre Karte wird ausgeworfen");
            Console.WriteLine("Geld abgebucht");
        }

        private static void PrintGreeting()
        {
            Console.WriteLine("Hallo, ich bin ein Geldautomat");
            Console.WriteLine("Bitte Karte einschieben");
        }
    }
}
