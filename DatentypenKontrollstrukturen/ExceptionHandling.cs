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

        /// <summary>
        /// Startet das Beispiel für exceptions
        /// </summary>
        public static void DoSomething()
        {
            Console.WriteLine("starte funktion");

            try // im Try-block wird eine Funktion gestartet die vielleicht eine exception werfen könnte
            {
                NotImplemented(); // wirft eine exception
                NotThrowing();
            }
            catch (NotImplementedException thrownExeption) // überprüft ob die geworfene exception genau dem hier angegebenen typen entspricht
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Fehler: Da wurde was gemacht was noch nicht fertig ist");
                Console.WriteLine(thrownExeption.StackTrace);
                Console.ResetColor();
                // die exception wird hier bearbeitet und danach läuft das programm normal weiter
            }
            catch (FileNotFoundException thrownExeption)
            {
                // nur der code der passenden catch-anweisung wird im fehlerfall ausgeführt
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Fehler: Datei ist gar nicht da, standardwerte werden benutzt");
                Console.WriteLine(thrownExeption.StackTrace);
                Console.ResetColor();
            }
            finally
            {
                // hier machen wir aufräum-sachen
                // ressourcen freigeben, netzwerkverbindungen trennen oder so
                // läuft immer, egal ob exception fliegt oder nicht
            }

            Console.WriteLine("beende funktion");
        }
        // TODO: finally
        // TODO: rethrow
        // TODO: multicatch (when )

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
