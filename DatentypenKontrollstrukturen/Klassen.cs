
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

            Delorean d = new();
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
        protected void SchlüsselDrehen() { }
        public virtual void StartEngine()
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
        public override void OpenDoor() // ersetzt die geerbte funktion vollständig
        {
            Console.WriteLine("Tür geht nach oben auf");
        }
    }

    class Ferrari : Auto // uralter ferrari
    {
        private void KurbelDrehen() { }
        public override void StartEngine()
        {
            KurbelDrehen();
            SchlüsselDrehen();
        }
    }


}
