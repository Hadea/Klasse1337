using System;
using System.Linq;

namespace Sort
{
    class Program
    {
        static void Main()
        {
            byte[] ArrayToSortA = new byte[50000]; // Leeres Array der länge 30 erzeugen und in ArrayToSort ablegen

            Random rndGen = new();// zufallsgenerator Random erzeugen und in rndGen ablegen
            rndGen.NextBytes(ArrayToSortA);// füllt das ArrayToSort mit zufallswerten.

            byte[] ArrayToSortB = new byte[ArrayToSortA.Length];
            ArrayToSortA.CopyTo(ArrayToSortB, 0);

            byte[] ArrayToSortC = new byte[ArrayToSortA.Length];
            ArrayToSortA.CopyTo(ArrayToSortC, 0);


            // ausgabe des Arrays
            if (ArrayToSortA.Length < 31)
                for (byte counter = 0; counter < ArrayToSortA.Length; counter++)
                    Console.Write(ArrayToSortA[counter] + " ");

            uint checkSumOriginal = 0;
            // summe aller element des arrays
            foreach (var item in ArrayToSortA)
                checkSumOriginal += item; // entspricht sum = sum + item
            Console.WriteLine("\nDie summe aller elemente ist: " + checkSumOriginal + "\n");



            DateTime startTimeSelection = DateTime.Now;
            SelectionSortNaiive(ArrayToSortA);
            DateTime endTimeSelection = DateTime.Now;

            uint checkSumSelectionSort = 0;
            foreach (var item in ArrayToSortA)
                checkSumSelectionSort += item; // entspricht sum = sum + item

            DateTime startTimeMerge = DateTime.Now;
            MergeSortNaive(ArrayToSortB);
            DateTime endTimeMerge = DateTime.Now;

            uint checkSumMergeSort = 0;
            foreach (var item in ArrayToSortA)
                checkSumMergeSort += item; // entspricht sum = sum + item

            DateTime startTimeBubble = DateTime.Now;
            BubbleSort(ArrayToSortC);
            DateTime endTimeBubble = DateTime.Now;

            uint checkSumBubbleSort = 0;
            foreach (var item in ArrayToSortA)
                checkSumBubbleSort += item; // entspricht sum = sum + item
            Console.WriteLine(@"Algorythmus   | Dauer  | Summe | Sortierung");
            Console.WriteLine($"Selectionsort | { (endTimeSelection - startTimeSelection).TotalSeconds.ToString("N4") } | { (checkSumOriginal == checkSumSelectionSort), 5 } | { CheckAscending(ArrayToSortA) }");
            Console.WriteLine($"Mergesort     | { (endTimeMerge - startTimeMerge).TotalSeconds.ToString("N4") } | { (checkSumOriginal == checkSumMergeSort), 5} | { CheckAscending(ArrayToSortB)}");
            Console.WriteLine($"Bubblesort    | { (endTimeBubble - startTimeBubble).TotalSeconds.ToString("N4") } | { (checkSumOriginal == checkSumBubbleSort),5 } | { CheckAscending(ArrayToSortC)}");

            // sortiertes array ausgeben
            if (ArrayToSortA.Length < 31)
                foreach (var item in ArrayToSortA)
                    Console.Write(item + " ");
        }

        private static bool CheckAscending(byte[] ArrayToSortA)
        {
            bool IsSorted = true;
            for (int counter = 0; counter < ArrayToSortA.Length - 1; counter++)
            {
                if (ArrayToSortA[counter] > ArrayToSortA[counter + 1])
                {
                    IsSorted = false;
                    break;
                }
            }

            return IsSorted;
        }

        private static void MergeSortNaive(byte[] ArrayToSort)
        {
            ///////////////////////////////////
            // teilen

            if (ArrayToSort.Length < 2) return;

            //      halbieren
            byte[] leftSide = ArrayToSort.Take(ArrayToSort.Length / 2).ToArray();//take -> von anfang bis zu dem angegebenen index
            byte[] rightSide = ArrayToSort.Skip(ArrayToSort.Length / 2).ToArray();//skip -> überspringt bis inclusive angegeben index und nimmt den rest

            //      selbstaufruf für beide hälften
            MergeSortNaive(leftSide);
            MergeSortNaive(rightSide);

            /////////////////////////////////
            // zusammenfügen 

            int leftPointer = 0, rightPointer = 0, originalPointer = 0;

            while (leftPointer < leftSide.Length && rightPointer < rightSide.Length)// solange links noch nicht bis zum ende bearbeitet und rechts noch noch nicht bis zum ende bearbeitet
            {
                if (rightSide[rightPointer] > leftSide[leftPointer])//     wenn rechte seite grösser als linke
                {
                    //          linke seite nehmen
                    ArrayToSort[originalPointer] = leftSide[leftPointer];
                    leftPointer++;
                }
                else//     andernfalls
                {
                    //          rechte seite nehmen
                    ArrayToSort[originalPointer] = rightSide[rightPointer];
                    rightPointer++;
                } //      ende wenn
                originalPointer++;
            }// ende solange

            // reste von links anfügen
            while (leftPointer < leftSide.Length)
            {
                ArrayToSort[originalPointer] = leftSide[leftPointer];
                leftPointer++;
                originalPointer++;
            }


            // reste von rechts anfügen
            while (rightPointer < rightSide.Length)
            {
                ArrayToSort[originalPointer] = rightSide[rightPointer];
                rightPointer++;
                originalPointer++;
            }
        }

        private static void SelectionSortNaiive(byte[] ArrayToSort)
        {
            // sortieren

            for (int outer = 0; outer < ArrayToSort.Length - 1; outer++) // alle elemente des arrays durchgehen
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
        }

        private static void BubbleSort(byte[] ArrayToSort)
        {
            for (int limit = ArrayToSort.Length; limit >= 0; limit--)
            {
                for (int i = 0; i < limit - 1; i++)
                {
                    if (ArrayToSort[i + 1] < ArrayToSort[i])
                    {
                        byte backup = ArrayToSort[i];
                        ArrayToSort[i] = ArrayToSort[i + 1];
                        ArrayToSort[i + 1] = backup;
                    }
                }
            }
        }
    }
}
