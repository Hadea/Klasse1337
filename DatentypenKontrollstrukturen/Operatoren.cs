using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatentypenKontrollstrukturen
{
    class Operatoren
    {
        public void DoSomething()
        {
            int A = 5; // zuweisung
            int B = 7;

            int ergebnis;

            // addition
            ergebnis = A + B; // ergebnis ist 5 + 7 = 12
            ergebnis += A; // ergebnis wird um A erhöht 12 + 5 = 17
            ergebnis++;// ergebnis wird um 1 erhöht 17 + 1 = 18

            // subtraktion
            ergebnis = A - B;
            ergebnis -= B;
            ergebnis--;

            // multiplikation
            ergebnis = A * B;
            ergebnis *= A;

            // division
            ergebnis = B / A; // 7 / 5 = 1  dividiert, ignoriert reste und nachkommastellen bei Ganzzahlen
            ergebnis /= A; // 1 / 5 = 0

            // modulo
            ergebnis = B % A; // 7 % 5 = 2  gibt den rest einer Ganzzahl-division aus
            ergebnis %= B; // 2 % 7 = 2

            for (int counter = 0; counter < 20; counter++)
            {
                Console.Write(counter + " durch 4 ist ");
                Console.Write(counter / 4);
                Console.Write(" rest ");
                Console.WriteLine(counter % 4);
            }


            // incrementieren

            ergebnis++; // nach benutzung raufzählen, denn ++ ist hinten
            ++ergebnis; // vor benutzung raufzählen, denn ++ ist vorn

            ergebnis = 5;
            Console.WriteLine(++ergebnis);

            A = 5; // 6
            B = 7; // 9

            //                 5   +  5  - 7   + 9  - 5
            Console.WriteLine(A++ + --A - B++ + ++B - A++); // ausgabe: 7

            ///////////////////////////////////

            string WortA = "Hallo";
            string WortB = " Welt!";
            Console.WriteLine(WortA + WortB + " " + WortA); // erstellt einen neuen string aus den angegebenen strings
            // ausgabe:  Hallo Welt! Hallo

            //////////////////////////////////

            bool Alpha = false;
            bool Beta = true;

            bool Gamma = Alpha || Beta; // oder: eines von beiden auf true genügt für das ergebnis auf true
            Gamma = Alpha && Beta; // und: beide müssen true sein damit das ergebnis true ergibt


            ergebnis = (int)(Optionen.AntialiasingEin | Optionen.VSyncEin);
        }


    }

    enum Optionen
    {
        VollBildEin =     0b0000_0001,
        VSyncEin =        0b0000_0010,
        AntialiasingEin = 0b0000_0100
    }
}
