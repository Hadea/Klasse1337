using System;

namespace Geldautomat
{
    class Program
    {
        static void Main()
        {
            printGreeting();
            string cardID;
            cardID = Console.ReadLine();

            if (cardID[0] != 'K')
            {
                Console.WriteLine("Karte wird eingezogen weil ungültig");
                return;
            }



        }

        /// <summary>
        /// Prints a greeting and asks for customer card
        /// </summary>
        private static void printGreeting()
        {
            Console.WriteLine("Hallo, ich bin ein Geldautomat");
            Console.WriteLine("Bitte Karte einschieben");
        }
    }
}
