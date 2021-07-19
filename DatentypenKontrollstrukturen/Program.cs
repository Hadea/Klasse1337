using System;

namespace DatentypenKontrollstrukturen
{
    class Program
    {
        static void Main()
        {
            int ZahlA = 5;
            int ZahlB = 7;
            int ZahlC = 4;
            int ZahlD;

            Console.WriteLine($"Vorher  A {ZahlA}  B {ZahlB}");
            Funktionen.ParameterDemo(ZahlA, ref ZahlB, in ZahlC, out ZahlD);
            Console.WriteLine($"Nachher A {ZahlA}  B {ZahlB}");

            Funktionen.ParamsDemo(ZahlA, ZahlB, ZahlC, ZahlD);
            Funktionen.ParamsDemo(ZahlA, ZahlB, ZahlC, ZahlB, ZahlC, ZahlB, ZahlC, ZahlB, ZahlC, ZahlB, ZahlC);

            Funktionen.PrintLine(1, "Hallo", " Welt", "!");
        }
    }

}
