using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatentypenKontrollstrukturen
{
    class Konsoleninteraktion
    {
        public static void DoSomething()
        {
            Console.ReadLine(); // liesst Tastatureingaben bis der Nutzer enter drückt.

            string nutzereingabe = Console.ReadLine();//  Das Ergebnis wird als string zurückgegeben.
            Console.WriteLine(nutzereingabe); // gibt die eingabe des nutzers wieder aus

            int taste = Console.Read(); //liesst den nächsten buchstaben, sollte nichts im Tastaturpuffer sein kommt -1

            // Beispiel: einlesen des tastaturpuffers zeichen für zeichen und ablegen in einen string
            nutzereingabe = string.Empty;
            while ( (taste = Console.Read()) != 1)// weist der variable taste das aktuelle zeichen aus dem tastaturpuffer zu, prüft dann den inhalt ob er nicht -1 ist
            {
                nutzereingabe += taste;
            }

            Console.ReadKey(); // kann einzelne tasten auf der tastatur unterscheiden
            Console.ReadKey(true); // taste wird gelesen, aber nicht auf der konsole angezeigt

            ConsoleKeyInfo eingabe = Console.ReadKey();
            /*
            eingabe.KeyChar; //beinhaltet den errechneten char
            eingabe.Key; // beinhaltet die Taste auf der tastatur (Nummernblock 1 und Zahlentaste 1 sind unterschiedlich)
            eingabe.Modifiers; //beinhaltet informationen ob Strg, Alt oder Shift gehalten wurde während des tastendrucks
            */
            switch (eingabe.Key)
            {
                case ConsoleKey.D1:
                case ConsoleKey.NumPad1:
                    Console.WriteLine("Eine eins");
                    break;
            }

            Console.Clear();// überschreibt den gesamten bildschirm mit leerzeichen und setzt den cursor nach oben links (0,0)

            Console.BackgroundColor = ConsoleColor.Red; // hintergrundfarbe auf rot ändern. alle weiteren ausgaben sind betroffen
            Console.ForegroundColor = ConsoleColor.Green; // textfarbe auf grün ändern. gilt für folgende texte
            Console.WriteLine("Bunter text");
            Console.ResetColor();// stellt die originalfarben wieder her welcher der nutzer für seine console gewählt hat

            bool keyDown = Console.KeyAvailable; // prüft ob ein tastenanschlag im tastaturpuffer steckt
            if (keyDown) // durch die kombination mit KeyAvailable können wir sicherstellen das ReadKey ohne wartezeit ein ergebnis liefert
            {
                Console.ReadKey();// liesst ein zeichen aus dem tastaturpuffer
            }
        }

    }
}
