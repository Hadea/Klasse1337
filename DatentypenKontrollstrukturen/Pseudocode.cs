

using System;

namespace DatentypenKontrollstrukturen
{
    class Pseudocode
    {
        public static void DoSomething()
        {
            /* Aus dem UseCase diagramm abgeleitet
             * 
             * An/ausschalten
             * Kaffee ausgeben
             * Tee ausgeben
             * Behälterstand anzeigen
             */


            // Programmstart
            // Ausgabe: "Kaffee: " + BehälterKaffee
            // Ausgabe: "Tee: " + BehälterTee
            // Ausgabe: "Welches getränk möchten sie"
            // Nutzereingabe wunsch
            // wenn wunsch Kaffee
            //      Ausgabe: "Gewünschter Kaffee"
            // wenn wunsch Tee
            //      Ausgabe: "Hier ist ihr Tee"
            // wenn wunsch Abschalten
            //      haltewunsch 
            //
            // solange haltewunsch "nö": wieder nach oben

            bool haltewunsch = false;
            int BehälterKaffee = 100;
            int BehälterTee = 100;
            int BehälterWasser = 100;
            do
            {
                Console.WriteLine("Kaffee: " + BehälterKaffee);// Ausgabe: "Kaffee: " + BehälterKaffee
                Console.WriteLine("Tee: " + BehälterTee);// Ausgabe: "Tee: " + BehälterTee
                Console.WriteLine("Welches getränk möchten sie?");// Ausgabe: "Welches getränk möchten sie"
                string Nutzereingabe;
                Nutzereingabe = Console.ReadLine();  // Nutzereingabe wunsch
                if (Nutzereingabe == "Kaffee")// wenn wunsch Kaffee
                {
                    if (BehälterWasser >= 10 && BehälterKaffee >= 5)// wenn Wasserbehälter >10 und Kaffebehälter >5
                    {
                        BehälterKaffee = BehälterKaffee - 5; // 5 kaffee aus container nehmen
                        BehälterWasser -= 10; // 10 wasser aus container nehmen
                        Console.WriteLine("Gewünschter Kaffee"); //Ausgabe: "Gewünschter Kaffee"
                    }
                    else// andernfalls
                    {
                        Console.WriteLine("Bitte behälter füllen");// ausgabe "Bitte behälter füllen"
                    }// ende wenn
                }
                if (Nutzereingabe == "Tee")// wenn wunsch Tee
                {
                    Console.WriteLine("Hier ist ihr Tee");//      Ausgabe: "Hier ist ihr Tee"
                }
                if (Nutzereingabe == "Abschalten")// wenn wunsch Abschalten
                {
                    haltewunsch = true; //      haltewunsch
                }
            }
            while (haltewunsch == false) ; // solange haltewunsch "nö": wieder nach oben

        }

    }
}
