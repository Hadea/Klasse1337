using System;
using System.Collections.Generic;

namespace Sort
{
    class Program
    {
        static void Main(string[] args)
        {
            List<byte> ArrayToSort = new() {7,5,2,3,9,1,8 };
            for (int counter = 0; counter < ArrayToSort.Count; counter++)
            {
                Console.Write( ArrayToSort[counter] + " " );
            }

            // sortieren

            // alle elemente des arrays durchgehen
            //    alle verbleibenden elemente des array durchgehen
            //        wenn element an äusserem zähler grösser als element an innerem zähler
            //            backup erstellen vom inneren wert
            //            inneren wert mit äusserem überschreiben
            //            äusseren wert mit backup überschreiben
            //        ende wenn
            //    ende array durchgehen
            // ende array durchgehen

            // nochmal ausgeben

        }
    }
}
