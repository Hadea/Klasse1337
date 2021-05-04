using System;
using System.Threading;

namespace Geldautomat
{
    class Program
    {
        static void Main()
        {
            Console.Clear(); // bildschirm leeren
            PrintLogo();
            Console.WriteLine("Starte Geldautomat");
            ATMLogic logic = new();
            Console.WriteLine("Status: " + logic.Mashine);// enum in string verwandeln für eine ausgabe ist eigendlich nicht erwünscht, aber hier der einfachheit gemacht

            while (logic.Mashine == MashineState.Running)
            {
                PrintGreeting();
                string cardID = Console.ReadLine(); // entspricht std::cin , liesst von der konsole bis zum enter
                logic.CheckCard(cardID);
                if (logic.User == LoginState.CardBlocked ||
                    logic.User == LoginState.CardRejected)
                {
                    Console.WriteLine("Karte wird eingezogen weil ungültig");
                    continue; // beendet den durchlauf vorzeitig und startet den nächsten
                }

                Console.WriteLine("Bitte Pin eingeben:");

                do
                {
                    string pinText = Console.ReadLine();
                    short pin;
                    pin = short.Parse(pinText);
                    logic.CheckPin(pin);

                } while (logic.User != LoginState.LoggedIn &&
                         logic.User != LoginState.CardBlocked);

                if (logic.User == LoginState.CardBlocked)
                {
                    Console.WriteLine("3x Falscher Pin, Karte wird eingezogen und Konto Blockiert");
                    continue;
                }

                PrintWithdrawal();
            }
        }

        private static void PrintLogo()
        {
            Console.WriteLine(@" █████╗ ████████╗███╗   ███╗");
            Console.WriteLine(@"██╔══██╗╚══██╔══╝████╗ ████║");
            Console.WriteLine(@"███████║   ██║   ██╔████╔██║");
            Console.WriteLine(@"██╔══██║   ██║   ██║╚██╔╝██║");
            Console.WriteLine(@"██║  ██║   ██║   ██║ ╚═╝ ██║");
            Console.WriteLine(@"╚═╝  ╚═╝   ╚═╝   ╚═╝     ╚═╝");
        }

        private static void PrintWithdrawal()
        {
            Console.WriteLine("Wieviel Geld möchten sie abheben?");
            string Abhebebetrag = Console.ReadLine();

            Console.WriteLine("Ihr Geld: " + Abhebebetrag + " wird ausgeworfen");
            Console.WriteLine("Ihre Karte wird ausgeworfen");
            Console.WriteLine("Geld abgebucht");
        }

        private static void PrintGreeting()
        {
            Thread.Sleep(1000);
            Console.Clear();
            Console.WriteLine("Hallo, ich bin ein Geldautomat");
            Console.WriteLine("Bitte Karte einschieben");
        }
    }
}
