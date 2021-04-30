
using System;
using System.Collections.Generic;

namespace DatentypenKontrollstrukturen
{
    class Klassen
    {
        public static void DoSomething()
        {
            Auto a = new Auto(); //classic
            var b = new Auto(); //retro
            Auto c = new(); //neu

            Delorean d = new(); // startet den Auto-Konstruktor und danach den Delorean-Konstruktor
            d.OpenDoor();

            Ferrari f = new();
            f.OpenDoor();

            List<Auto> Stau = new();
            Stau.Add(d);
            Stau.Add(f);

            Console.WriteLine("Liste");
            foreach (Auto item in Stau)
            {
                item.OpenDoor();
            }
        }
    }

    class Auto
    {
        public Auto()
        {
            Console.WriteLine("Auto-Konstruktor gestartet");
        }
        protected void SchlüsselDrehen() { } // wie private, wird aber vererbt
        public virtual void StartEngine()// von aussen (einer anderen Klasse) startbar
        {
            SchlüsselDrehen();
        }
        public virtual void OpenDoor() // ermöglich das "Overriding"
        {
            Console.WriteLine("Tür geht nach vorn auf");
        }
    }

    class Delorean : Auto // delorean ist ein spezialisiertes Auto
    {
        public Delorean()
        {
            Console.WriteLine("Delorean-Konstruktor");
        }

        public override void OpenDoor() // ersetzt die geerbte funktion vollständig
        {
            Console.WriteLine("Tür geht nach oben auf");
        }
    }

    class Ferrari : Auto // uralter ferrari
    {
        private void KurbelDrehen() { } // wird nicht vererbt und ist nur von Ferrari startbar
        public override void StartEngine()
        {
            KurbelDrehen(); // die private aus Ferrari
            SchlüsselDrehen(); // die geerbte protected aus Auto
        }
    }


}
