using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace Geldautomat
{
    class Program
    {
        private static ATMLogic logic = new();
        static void Main()
        {
            Console.Clear(); // bildschirm leeren
            PrintLogo();
            Console.WriteLine("Starte Geldautomat");
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
                Console.ReadLine();
            }
        }

        private static void PrintLogo()
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;

            using (StreamReader reader = new StreamReader("Logo.txt"))
            {
                string line;
                int distanceToTop = 0;

                while ((line = reader.ReadLine()) != null)
                {
                    Console.SetCursorPosition(Console.WindowWidth / 2 - line.Length / 2, distanceToTop++);//      Cursorposition verschieben damit die zeile zentriert ist
                    Console.WriteLine(line); //      Zeile ausgeben
                }
            }

            Console.ResetColor();
            Console.ReadLine();
        }

        private static void PrintWithdrawal()
        {
            Console.WriteLine("Wieviel Geld möchten sie abheben?");
            string Abhebebetrag = Console.ReadLine();
            List<NoteStack> MoneyStack = logic.Withdraw(uint.Parse(Abhebebetrag));

            if (MoneyStack is null)
                Console.WriteLine("ungültiger Betrag");
            else
            {

                foreach (var item in MoneyStack)
                {
                    string Currency = (item.NoteType) switch
                    {
                        BankNote.Euro10 => "10 Euro Scheine",
                        BankNote.Euro100 => "100 Euro Scheine",
                        BankNote.Euro20 => "20 Euro Scheine",
                        BankNote.Euro200 => "200 Euro Scheine",
                        BankNote.Euro5 => "5 Euro Scheine",
                        BankNote.Euro50 => "50 Euro Scheine",
                        _ => throw new InvalidDataException()
                    };

                    Console.WriteLine($"> {item.Amount,3} x {Currency}");
                }
                Console.WriteLine("Geld abgebucht");
            }

            Console.WriteLine("Ihre Karte wird ausgeworfen");
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
