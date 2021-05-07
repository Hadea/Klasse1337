using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            return (Number < 3 ? 1 : Fibonacci(Number - 1) + Fibonacci(Number - 2));
        }

        // Die Fibonacci Funktion umschreiben das sie anstelle einer Rekursion (selbstaufruf) eine schleife verwendet

        // Bonus : Die Rekursive Fibonacci Funktion umschreiben das sie zwischenergebnisse speichern kann


        // fibonacci(8)
    }
}
