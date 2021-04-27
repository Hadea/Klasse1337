using System;
using System.Collections.Generic;

namespace Lotto
{
    class Program
    {
        static void Main(string[] args)
        {
            List<byte> Ziehung = new();
            List<byte> SpielZettel = new() { 5, 12, 23, 42, 49 };

            Random rndGen = new();

            //1. 5 zahlen zwischen 1 und 50 (inclusive) ausgeben, ohne doppelungen
            do
            {
                byte newNumber = (byte)rndGen.Next(1, 51);
                if (!Ziehung.Contains(newNumber))
                    Ziehung.Add(newNumber);
            } while (Ziehung.Count < 5);

            Console.Write("Zahlen des Spielers: ");
            foreach (byte item in SpielZettel)
                Console.Write(item + " ");

            Console.Write("\nZahlen der Ziehung:  ");
            foreach (byte item in Ziehung)
                Console.Write(item + " ");


            int treffer = 0;
            foreach (byte item in SpielZettel)
            {
                if (Ziehung.Contains(item))
                {
                    treffer++;
                }
            }

            Console.WriteLine("\nAnzahl der richtigen: " + treffer);

        }
    }
}
