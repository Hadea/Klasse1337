using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DatentypenKontrollstrukturen
{
    class Funktionen
    {

        // ohne sichtbarkeitsangabe sind die funktionen "private"
        void MyFunctionNoParametersNoReturn()
        {
            // inhalt
        }

        // funktionen mit gleichem namen, aber unterschiedlichen Parametern sind "Überladen" Overload
        void MyFunctionWithParametersNoReturn(int Number)
        {
            Console.WriteLine(Number);
        }
        void MyFunctionWithParametersNoReturn(string Text)
        {
            Console.WriteLine(Text);
        }

        void MyFunctionWithParametersNoReturn(int Number, string Text)
        {
            Console.WriteLine(Text + " " + Number);
        }

        //öffentliche funktion

        public void MyPublicFunction()
        { }

        // mit rückgaben

        public int Sum(int NumberA, int NumberB)
        {
            if (NumberB > NumberA)
            {
                return 0; // beendet vorzeitig die funktion und gibt die zahl 0 an den aufrufer
            }

            int result;
            result = NumberA + NumberB;
            return result; // beendet die funktion und gibt den inhalt der variable an den aufrufer
        }

        // protected funktionen, wie private, aber dürfen vererbt werden
        protected void MyProtectedFunction() { }

        // internal verhält sich wie public, aber nur für unser projekt
        internal void MyInternalFunction() { }

        //statische funktionen, können starten ohne das ein objekt existiert. Alle objekte teilen sich
        // diese eine funktion
        // kann nicht auf Objektvarialben zugreifen

        public static void MyStaticFunction()
        { }

        //TODO ref
        //TODO out
        //TODO in

        public static void Rekursiv(int Number)
        {
            if (Number > 3) return;
            Rekursiv(Number + 1);
            Console.WriteLine(Number);
        }

        public static int Fibonacci(int Number)// 1 1 2 3 5 8 13 21
        {
            SlowDown();
            return (Number < 3 ? 1 : Fibonacci(Number - 1) + Fibonacci(Number - 2));
        }


        public static int FibonacciSchleife(int Number)
        {

            if (Number < 3) // wenn Übergabe kleiner als 3
            {
                return 1;//  rückgabe 1
            }// ende wenn

            int prepre = 1;
            int pre = 1;
            int result = 0;
            for (int counter = 2; counter < Number; counter++) // zählen von 3 bis zur angeforderten nummer
            {
                SlowDown();
                result = pre + prepre;//    ergebnis ist vorgänger + vorvorgänger
                prepre = pre;//    vorvorgänger mit vorgäner ersetzen
                pre = result; //    vorgänger mit ergebnis ersetzen
            }// ende zählen

            return result;// ergebnis zurückgeben
        }
        // Die Fibonacci Funktion umschreiben das sie anstelle einer Rekursion (selbstaufruf) eine schleife verwendet


        // Bonus : Die Rekursive Fibonacci Funktion umschreiben das sie zwischenergebnisse speichern kann
        public static int FibonacciMemoization(int Number, int[] precalculated = null)
        {
            SlowDown();
            if (Number < 3) return 1;
            if (precalculated is null) precalculated = new int[Number + 1];
            if (precalculated[Number] == 0)
                precalculated[Number] = FibonacciMemoization(Number - 1, precalculated) + FibonacciMemoization(Number - 2, precalculated);

            return precalculated[Number];
        }

        // fibonacci(8)
        static void SlowDown()
        {
            Console.Write("#");
            Thread.Sleep(50);
        }

        public static void ParameterDemo(int Alpha, ref int Bravo, in int Charly, out int Delta)
        {
            Alpha *= 2;
            Bravo *= 2;
            // Charly *= 2; Geht nicht, da schreibgeschützt "in"
            Bravo = Charly * 2;

            // Die out-variable muss mindestens einmal geschrieben worden sein bevor die funktion endet
            Delta = 2;
            Console.WriteLine(Delta);
        }

        public static void ParamsDemo(params int[] ZahlenArray)
        {

        }

        public static void PrintLine(byte Ausrichtung, params string[] Texte)
        {
            string AusgabeText = String.Empty;
            for (int counter = 0; counter < Texte.Length; counter++)
            {
                AusgabeText += Texte[counter];
            }

            Console.WriteLine(AusgabeText);
        }

    }
}
