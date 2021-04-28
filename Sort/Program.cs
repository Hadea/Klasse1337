using System;
using System.Collections.Generic;

namespace Sort
{
    class Program
    {
        static void Main(string[] args)
        {
            //List<byte> ArrayToSort = new() { 7, 5, 2, 3, 9, 1, 8 };

            byte[] ArrayToSort = new byte[30];

            Random rndGen = new();
            rndGen.NextBytes(ArrayToSort);

            for (byte counter = 0; counter < ArrayToSort.Length; counter++)
            {
                Console.Write(ArrayToSort[counter] + " ");
            }

            int sum = 0;
            // summe aller element des arrays
            foreach (var item in ArrayToSort)
            {
                sum += item; // entspricht sum = sum + item
            }
            Console.WriteLine("\nDie summe aller elemente ist: " + sum + "\n");



            // sortieren

            for (int outer = 0; outer < ArrayToSort.Length -1 ; outer++) // alle elemente des arrays durchgehen
            {
                for (int inner = outer + 1; inner < ArrayToSort.Length; inner++)//alle verbleibenden elemente des array durchgehen
                {
                    if (ArrayToSort[outer] > ArrayToSort[inner])//wenn element an äusserem zähler grösser als element an innerem zähler
                    {
                        byte backup = ArrayToSort[outer];//backup erstellen vom äusseren wert
                        ArrayToSort[outer] = ArrayToSort[inner];//äusseren wert mit innerem überschreiben
                        ArrayToSort[inner] = backup;//inneren wert mit backup überschreiben
                    }//ende wenn
                }//ende array durchgehen
            } // ende array durchgehen


            // sortiertes array ausgeben
            foreach (var item in ArrayToSort)
            {
                Console.Write(item + " ");
            }
        }
    }
}
