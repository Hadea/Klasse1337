using System;
using System.Collections.Generic;
using System.Threading;

namespace Geldautomat
{
    class ATMLogic
    {
        public LoginState User;
        public MashineState Mashine;

        private byte remainingTries;
        private readonly byte maximumTries;
        private readonly ContainerData container;

        public ATMLogic()
        {
            Mashine = MashineState.StartingUp;
            maximumTries = 3;
            remainingTries = maximumTries;
            // connect to network
            // connect to database
            container = new();
            container.Load();
            Thread.Sleep(1000);
            Mashine = MashineState.Running;
        }
        public void CheckCard(string CardID)
        {
            if (CardID[0] == 'K')
                User = LoginState.CardAccepted;
            else
                User = LoginState.CardRejected;

            if (CardID == "abschalten")
            {
                ShutdownMashine();
            }
        }

        public void CheckPin(short PIN)
        {
            if (PIN == 1337)
            {
                User = LoginState.LoggedIn;
                remainingTries = maximumTries;
            }
            else
                remainingTries--;

            if (remainingTries < 1)
                User = LoginState.CardBlocked;
        }

        public void ShutdownMashine()
        {
            container.Save();
            // disconnect from database
            // network shutdown
            Mashine = MashineState.ShuttingDown;
        }

        public List<NoteStack> Withdraw(uint abhebebetrag)
        {
            if (abhebebetrag % (uint)container.SmallestNote != 0) return null;

            // prüfen ob der kunde genügend geld auf dem konto hat
            // wenn ja
                return container.Withdraw(abhebebetrag);
            // andernfalls
            //      abbruch
            // ende wenn

        }
    }
}
