
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

            Auto z = new Delorean();
            
            a.OpenDoor();
            z.OpenDoor();

            Delorean d = new(); // startet den Auto-Konstruktor und danach den Delorean-Konstruktor
            d.OpenDoor();

            Ferrari f = new();
            f.OpenDoor();

            List<IOpenable> Stau = new();
            Stau.Add(d);
            Stau.Add(f);

            Console.WriteLine("Liste");
            foreach (IOpenable item in Stau)
            {
                item.OpenDoor();
            }
        }
    }

    class Auto : IOpenable
    {
        protected int AnzahlDerTüren;
        protected int Hubraum; //in ccm


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
        bool fluxkompensatorLadestand; // automatisch private wenn keine Sichtbarkeit angegeben wurde
        public Delorean()
        {
            Console.WriteLine("Delorean-Konstruktor");
            Hubraum = 3500;
        }

        public override void StartEngine()
        {
            base.StartEngine();
            fluxkompensatorLadestand = true;
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
    //TODO: partial class, sealed, abstract 

    interface IOpenable
    {
        void OpenDoor();
    }

}
