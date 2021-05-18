using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatentypenKontrollstrukturen
{
    class ExceptionHandling
    {
        public static void DoSomething()
        {
            Console.WriteLine("starte funktion");

            try
            {
                NotImplemented();
                NotThrowing();
            }
            catch (NotImplementedException thrownExeption)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Fehler: Da wurde was gemacht was noch nicht fertig ist");
                Console.WriteLine(thrownExeption.StackTrace);
                Console.ResetColor();
            }
            catch (FileNotFoundException thrownExeption)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Fehler: Datei ist gar nicht da, standardwerte werden benutzt");
                Console.WriteLine(thrownExeption.StackTrace);
                Console.ResetColor();
            }

            Console.WriteLine("beende funktion");
        }

        /// <summary>
        /// macht nix, crasht aber ganz gut
        /// </summary>
        /// <exception cref="NotImplementedException" />
        public static void NotImplemented()
        {
            Console.WriteLine("unfertig gestartet");
            throw new NotImplementedException();
            Console.WriteLine("unfertig beendet");
        }

        public static void NotThrowing()
        {

        }

    }
}
