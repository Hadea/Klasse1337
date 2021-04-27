using System;

namespace Lotto
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rndGen = new Random();
            for (int count = 0; count < 5; count++)
            {
                Console.WriteLine( rndGen.Next(1, 51)); 
            }


            //1. 5 zahlen zwischen 1 und 50 (inclusive) ausgeben, ohne doppelungen
            //2. 2 zahlen zwischen 1 und 10 (inclusive) ausgeben, ohne doppelungen
        }
    }
}
