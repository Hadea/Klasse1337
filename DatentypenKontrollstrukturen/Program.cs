using System;

namespace DatentypenKontrollstrukturen
{
    class Program
    {
        static void Main(string[] args)
        {
            int A = 2;//  0000 0010
            int B = 1;//  0000 0001
            //            0000 0011
            
            int ergebnis = A | B;

            Console.WriteLine(ergebnis);

        }
    }
}
