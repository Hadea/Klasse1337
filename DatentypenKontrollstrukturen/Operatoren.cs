using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace DatentypenKontrollstrukturen
{
    class Operatoren
    {
        public static void DoSomething()
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


            ////////////////////////////////////////
            ///Berechnungen mit Fliesskommazahlen
            Console.ReadLine();
            Console.Clear();
            float Af = 7.6f; // float wert wird in float variable gesteckt
            float Bf = 5; // integer wert wird implizit in float konvertiert und in variable gesteckt
            int Ci = 13;
            float resultFloat = Af / Bf; // nachkommastellen werden berechnet
            Console.WriteLine(resultFloat);
            Console.WriteLine(Af / Ci); // auch hier wird der int in float verwandelt und die float-variante des teilens verwendet

            int convertiert = (int)Af; // Nachkommastellen werden abgeschnitten und nicht gerundet
            convertiert = Convert.ToInt32(Af); // rundet beim konvertieren, sehr praktisch beim if
            Console.WriteLine(convertiert);

            ///////////////////////////////////
            // Besonderheiten mit Vergleichen und float

            resultFloat = (0.2f * 0.2f) / 0.2f;
            Console.WriteLine( resultFloat ); // ergibt 0,20000002 
            if (0.2f == resultFloat)//mathematisch sollte true rauskommen, durch float-ungenauigkeit aber false
                Console.WriteLine("treffer");
            else
                Console.WriteLine("nope");

            Console.WriteLine("A ist " + 0.2f + " B ist " + Math.Round(resultFloat, 1, MidpointRounding.AwayFromZero));

            if (Math.Round(0.2f, 1,MidpointRounding.AwayFromZero) == Math.Round(resultFloat, 1, MidpointRounding.AwayFromZero))
                Console.WriteLine("treffer");
            else
                Console.WriteLine("nope");

            if ((int)(0.2f*10) == (int)(resultFloat*10))
                Console.WriteLine("treffer");
            else
                Console.WriteLine("nope");



            //////////////////////////////////////////////////
            // Ausgabe von Werten

            // 1. Variante "concat"
            // durch jedes + werden zwei strings zusammenin einen neuen string konvertiert
            // langsam wenn viele + zeichen verwendet werden
            Console.WriteLine("WertA " + Af + " WertB " + Bf);

            // 2. Variante "lückentext"
            // variablen werden in strings konvertiert und dann zusammen mit dem äusseren text in einen
            // neuen ergebnisstring verwandelt. etwas effizienter als + aber nicht schleifentauglich
            Console.WriteLine($"WertA {Af} WertB {Bf}");

            // 3. Variante "classic printf"
            // konvertiert die zusätzlichen parameter und füllt die lücken
            Console.WriteLine("WertA {0} WertB {1}", Af, Bf);


            // mit formatierungen
            Random rndGen = new();
            for (int counter = 0; counter < 10; counter++)
            {
                int zufallszahl = rndGen.Next(10, 11000);
                // die 5 hinter dem komma sagt wieviel platz mindestens benutzt werden soll
                // verbraucht die zahl weniger wird mit leerzeichen aufgefüllt. rechtsbündig.
                Console.WriteLine($"Zahl {zufallszahl,5} ist zufällig gewählt");
            }

            for (int counter = 0; counter < 10; counter++)
            {
                int zufallszahl = rndGen.Next(10, 11000);
                // die 5 hinter dem komma sagt wieviel platz mindestens benutzt werden soll
                // verbraucht die zahl weniger wird mit leerzeichen aufgefüllt. Linksbündig.
                Console.WriteLine($"Zahl {zufallszahl,-5} ist zufällig gewählt");
            }

            
            
            float zuFormatierendeZahl = 123456.1f;
            // dezimalpunkte
            Console.WriteLine(zuFormatierendeZahl.ToString("0.000"));// 3 stellen hinter dem komma anzeigen
            Console.WriteLine(uint.MaxValue.ToString("X"));
            Console.WriteLine(zuFormatierendeZahl.ToString("N"));// punkte und komma zum formatieren, N1 würde eine nachkommastelle nutzen
            //währung
            Console.OutputEncoding = Encoding.UTF8; // zeichensatz umstellen damit das Währungsicon dargestellt werden kann
            Console.WriteLine("€");
            Console.WriteLine("Dieser Betrag ist Währung :" + zuFormatierendeZahl.ToString("c",CultureInfo.CreateSpecificCulture("de-DE")));//formatiert in deutscher Währungsschreibweise
            Console.WriteLine("Dieser Betrag ist Währung :" + zuFormatierendeZahl.ToString("c",CultureInfo.CreateSpecificCulture("en-US")));//formatiert in englischer Währungsschreibweise
            Console.WriteLine($"Dieser Betrag ist auch Währung : {zuFormatierendeZahl:C4}"); // formatiert als währung (anhand Betriebssystem)  mit 4 nachkommastellen
            //Datumsformatierung anhand CultureInfo
            Console.WriteLine(DateTime.Now.ToString(CultureInfo.CreateSpecificCulture("de-DE")));// datum in deutsch
            Console.WriteLine(DateTime.Now.ToString(CultureInfo.CreateSpecificCulture("en-US")));// datum in englisch
            Console.ReadLine();
        }
        //TODO: implement/override/overload operator

    }

    enum Optionen
    {
        VollBildEin =     0b0000_0001,
        VSyncEin =        0b0000_0010,
        AntialiasingEin = 0b0000_0100
    }
}
