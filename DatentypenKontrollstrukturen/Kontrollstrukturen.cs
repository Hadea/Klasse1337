using System;
using System.Collections.Generic;

namespace DatentypenKontrollstrukturen
{
    class Kontrollstrukturen
    {
        public void Beispiele()
        {

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

            /////////////////////////////////////////////////////////////

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

            /////////////////////////////////////////////////

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Bin in der For und i ist " + i);
            }

            for(;;) // Zoidberg FOR, variablenerstellung, test und zähleränderung sind optional
            {
                break; // beendet das For weil wir sonst hier eine endlosschleife haben
            }

            List<int> ZahlenListe = new();

            foreach (int item in ZahlenListe) // geht einen Container von anfang bis ende durch
            {
                Console.WriteLine(item);
            }

            ///////////////////////////////////////////////////////

            switch (counter)// schaut in die Variable und springt in den passenden case
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
        }

    }
}
