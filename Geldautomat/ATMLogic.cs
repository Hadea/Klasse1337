using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geldautomat
{
    enum LoginState
    {
        CardAccepted,
        CardRejected,
        CardBlocked,
        PinIncorrect,
        LoggedIn,
    }

    enum MashineState
    {
        StartingUp,
        Running,
        ShuttingDown
    }

    class ATMLogic
    {
        public LoginState User;
        public MashineState Mashine;

        private byte remainingTries;
        private readonly byte maximumTries;

        public ATMLogic()
        {
            Mashine = MashineState.StartingUp;
            maximumTries = 3;
            remainingTries = maximumTries;
            // connect to network
            // connect to database
            Mashine = MashineState.Running;
        }
        public void CheckCard(string CardID)
        {
            if (CardID[0] == 'K')
                User = LoginState.CardAccepted;
            else 
                User = LoginState.CardRejected;
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
            // disconnect from database
            // network shutdown
            Mashine = MashineState.ShuttingDown;
        }
    }
}
