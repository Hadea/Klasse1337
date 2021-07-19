using System;
using System.Collections.Generic;

namespace DatentypenKontrollstrukturen
{
    class Container
    {
        public static void DoSomething()
        {
            #region Arrays

            int[] ZahlenArray = new int[20];
            /* Entspricht in Java und C++ dem Array
             * 
             * Schnelles zugreifen über den Array Operator []
             * immer feste grösse
             * Garantiert ohne lücken direkt hintereinander im RAM
             */

            ZahlenArray[8] = 745291471; // füllen eines slots des arrays, die nummerierung beginnt bei 0
            Console.WriteLine(ZahlenArray[8]);

            byte[,,] MultidimensionalesByteArray = new byte[5, 10, 7];
            /*
             * 3-Dimensionales array
             * Daten auch immer am stück im RAM
             * Vorsicht mit der gesamtgrösse da es bei einem fragmentierten arbeitsspeicher manchmal
             * nicht am stück gespeichert werden kann obwohl der gesamte freie RAM genügen würde
             */
            MultidimensionalesByteArray[2, 5, 0] = 254;
            MultidimensionalesByteArray[0, 0, 0] = 1;
            MultidimensionalesByteArray[0, 0, 1] = 2;
            foreach (byte item in MultidimensionalesByteArray) // gibt alle dimensionen der reihe nach aus
            {
                Console.Write(item + " ");
            }

            // bei for schleifen darauf achten das die rechte ID die innerste schleife sein muss
            for (int Z = 0; Z < 5; Z++)
            {
                for (int Y = 0; Y < 10; Y++)
                {
                    for (int X = 0; X < 7; X++)
                    {
                        Console.Write(MultidimensionalesByteArray[Z, Y, X]);
                    }
                }
            }


            short[][] JaggedArray = new short[5][];
            JaggedArray[0] = new short[20];
            JaggedArray[1] = new short[5];
            JaggedArray[2] = new short[15];

            /* JaggedArray ist ein Array aus Arrays
             * In der Y achse werden nur referenzen zu den eigentlichen X arrays gespeichert
             * zugriff ist ein wenig langsamer da die einzelnen XArrays im RAM verstreut sind
             */
            Console.WriteLine(JaggedArray[0][5]);
            #endregion

            ///////////////////////////////////////////////

            #region List
            List<byte> ByteListe = new List<byte>();// erstellt eine leere Liste mit kapazität 8
            /* Entspricht dem C++ Vector, in Java ist es die ArrayList
             * 
             * Werte in der Liste unterliegen den gleichen regeln wie Array
             * Werte immer hintereinander im RAM und schnell im zugriff
             * Grösse der liste ist veränderbar (erstellt intern ein neues Array und kopiert die
             * daten von alt nach neu und zerstört das alte)
             * Beim vergrössern wird die Kapazität verdoppelt
             */
            ByteListe = new List<byte>(20);// erstellt eine leere Liste mit kapazität 20

            ByteListe.Add(5); // fügt das element ans ende der liste
            Console.WriteLine(ByteListe[0]);
            Console.WriteLine(ByteListe.Count); // anzahl der einträge
            Console.WriteLine(ByteListe.Capacity); // anzahl möglichen einträge bis eine vergrösserung stattfindet 
            #endregion

            //////////////////////////////////////////////////

            #region LinkedList
            LinkedList<short> DoppelteVerkettungVonShort = new LinkedList<short>();
            DoppelteVerkettungVonShort.AddLast(-29999);
            /* Entspricht in Java der LinkedList und C++ List
             * Speichert eine Kette von elementen, jedes element kennt dabei die RAM-Adresse des 
             * vorgängers und nachfolgers (doppelt verkettet).
             * schnelles einfügen, löschen, vergrössern und verkleinern
             * lesen ist langsam wenn die kette lang wird da immer von vorn von element zu element
             * gesprungen wird
             */
            foreach (var item in DoppelteVerkettungVonShort)
            {
                Console.WriteLine(item);
            } 
            #endregion

            /////////////////////////////////////////////////

            //TODO: Dictionary
            //TODO: Queue
            //TODO: Stack


        }

    }
}
