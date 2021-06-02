using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatentypenKontrollstrukturen
{

    delegate void FunktionsListeFuerEreignis(int Number); // erstellt einen neuen datentypen für funktionen die einen integer entgegennehmen und void zurückliefern
    // entspricht Action<int>

    delegate bool FunktionMitRueckgabeUndParametern(string Text, int Zahl, Auto a);
    // entspricht Func<string,int,Auto,bool>
    // rückgabewert ist der letzte eintrag im generic

    class DelegateExample
    {
        FunktionsListeFuerEreignis ereignis;

        public void DoSomtheing()
        {

            ereignis = FunktionFuerEreignis; // speichert die RAM-Adresse in der Variable
            ereignis += AndereFunktionFuerEreignis; // es können auch mehr Adressen gespeichert werden, ausführung erfolgt in reihenfolge


            ereignis(5); // startet alle funktionen die in ereignis gespeichert sind

            ereignis -= FunktionFuerEreignis; //entfernt eine funktion aus dem delegate, vorsicht ... könnte langsam sein
        }

        void FunktionFuerEreignis(int Zahl) // exakte übereinstimmung mit dem delegate. Rückgabe und Parametertypen!
        {
            Console.WriteLine(Zahl);
        }

        void AndereFunktionFuerEreignis(int Zahl) // exakte übereinstimmung mit dem delegate. Rückgabe und Parametertypen!
        {
            Console.WriteLine(Zahl * -1);
        }

    }




}
