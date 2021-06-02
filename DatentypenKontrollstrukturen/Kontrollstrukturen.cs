using System;
using System.Collections.Generic;

namespace DatentypenKontrollstrukturen
{
    class Kontrollstrukturen
    {

        public static void Beispiele()
        {
            #region IF-Verzweigung

            if (5 < 3) // testet ob eine aussage wahr ist
            {
                // wenn sie wahr ist
            }

            if (5 < 3) // testet ob eine aussage wahr ist
            {
                // wenn sie wahr ist
            }
            else
            {
                // wenn sie nicht wahr ist
            }

            if (3 > 7)
                System.Console.WriteLine("Stimmt");
            else
                Console.WriteLine("Stimmt nicht");

            if (5 == 7)
            {
                // wenn wahr
            }
            else if (5 > 3)
            {
                // wenn erstes nicht wahr und zweites wahr ergibt
            }
            else
            {
                // wenn keiner der tests wahr ergibt
            }

            if (8 < 7) throw new ArgumentOutOfRangeException(); // häufig am anfang einer funktion um die Parameter zu überprüfen

            ////////////////////////////
            // kurzschreibweise des if "inline if"
            //                 ( test  ?   wenn true   : wenn false         )
            Console.WriteLine((8 < 7 ? "ist kleiner" : "ist nicht kleiner"));
            #endregion

            /////////////////////////////////////////////////////////////

            #region While-Schleife

            int counter = 5;

            while (counter > 0) // läuft solang die bedingung wahr ist, test vor dem ersten durchlauf
            {
                counter--;
            }
            Console.WriteLine(counter);

            counter = 5;
            do // testet erst nach dem ersten durchlauf *Spongebob meme* "Wanna see me do it again?"
            {
                Console.WriteLine("Bin in der schleife");
                counter--;
            } while (counter > 0);

            #endregion

            /////////////////////////////////////////////////

            #region For-Schleifen

            // nützlich wenn die anzahl der durchläufe vorher bekannt wird.
            // erzeugt nur zahlen

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Bin in der For und i ist " + i);
            }

            for (; ; ) // Zoidberg FOR, variablenerstellung, test und zähleränderung sind optional
            {
                break; // beendet das For weil wir sonst hier eine endlosschleife haben
            }

            List<int> ZahlenListe = new();
            // geht einen Container von anfang bis ende durch und führt den code für jedes element aus.
            // funktioniert mit fast allen containern
            // item enthält eine KOPIE! des wertes welches für den aktuellen durchlauf vorgesehen ist.
            // Änderungen an der kopie beeinflussen natürlich nicht das original.
            // Sollte die Liste aus einem Referenz-Typen bestehen (Class) dann wird eine Kopie der referenz in Item
            // bereitgestellt sodass diese auch weiterhin auf das Original Objekt zeigt.
            foreach (int item in ZahlenListe)
            {
                Console.WriteLine(item);
            }

            #endregion

            ///////////////////////////////////////////////////////

            #region Switch-Verzweigung

            switch (counter)// schaut in die Variable und springt in den passenden case, führt den code aus und endet
            {
                default: // wenn kein case trifft wird default gemacht (optional), bei enum besser mitnehmen und mit exception füllen
                    Console.WriteLine("Bin im Default gelandet");
                    break;
                case 3: // wenn in der variable vom switch eine 3 gefunden wird
                    Console.WriteLine("Hab ne 3");
                    break;// nach jedem case wird der switch beendet. (break, return, throw)
                case 7: // wenn 7 oder 1 gefunden wird und die gleich behandelt werden sollen
                case 1:
                    Console.WriteLine("Da ist eine eins oder sieben drin");
                    break;
            }

            // schreibweise mit if und sehr vielen scopes (klammern)
            if (counter == 1 || counter == 7)
            {
                Console.WriteLine("Da ist eine eins oder sieben drin");
            }
            else
            {
                if (counter == 3)
                {
                    Console.WriteLine("Hab ne 3");
                }
                else
                {
                    Console.WriteLine("Bin im Default gelandet");
                }
            }


            /////////////////////////////////////////////////
            // kurzschreibweise für switch wenn dieser über die befüllung einer variablen entscheidet

            // original:
            bool ergebnis;
            switch (Console.ReadLine())
            {
                case "123":
                    ergebnis = true;
                    break;
                case "321":
                    ergebnis = false;
                    break;
                default:
                    ergebnis = false;
                    break;
            }

            // kurz, wenn ihr euch mit dem switch für einen wert entscheiden wollt
            ergebnis = (Console.ReadLine()) switch
            {
                "123" => true,
                "321" => false,
                _ => false
            };
            // der unterstrich entspricht dem default
            // komma ist das break

            #endregion

        }

    }
}
