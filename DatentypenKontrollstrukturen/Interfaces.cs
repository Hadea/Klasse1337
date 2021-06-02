
using System;
using System.Collections.Generic;

namespace DatentypenKontrollstrukturen
{
    class Interfaces
    {
        IStartable start;

        public void SetStart(IStartable compliantObject) // dependency injection
        {
            start = compliantObject;
        }

        public void DoSomething()
        {
            List<IStartable> startList = new();

            startList.Add(new Toaster());
            startList.Add(new Flugzeugträger());
            startList.Add(new Schiff());
            startList.Add(new SandwitchToaster());

            foreach (var item in startList)
            {
                // alle funktionen die vom Interface vorgegeben sind können auch benutzt werden.
                // Datentyp beschreibt die funktionalität

                item.Start();

                item.Stop();
            }

            using (Toaster t = new())
            {

            }

            using (Flugzeugträger ft = new())
            {

            }
            
            using (Schiff s = new())
            {

            }
        }
    }

    // vererbung: SandwitchToaster "is a" specialized Toaster
    // Interface: SandwitchToaster "can do" Startable and Disposable

    class Toaster : IStartable, IDisposable
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void Start()
        {
            throw new System.NotImplementedException();
        }

        public void Stop()
        {
            throw new System.NotImplementedException();
        }
    }

    class SandwitchToaster : Toaster
    {

    }

    class Schiff : IStartable, IDisposable
    {
        public void Start()
        {
            throw new System.NotImplementedException();
        }

        public void Stop()
        {
            throw new System.NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }

    class Flugzeugträger : Schiff, IDisposable
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }

    interface IStartable
    {
        public void Start();
        public void Stop();
    }


}
