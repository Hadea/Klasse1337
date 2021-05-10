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


    /// <summary>
    /// Represents a bank note
    /// Note value castable into integer
    /// </summary>
    enum BankNote
    {
        Mixed,
        Euro5 = 5,
        Euro10 = 10,
        Euro20 = 20,
        Euro50 = 50,
        Euro100 = 100,
        Euro200 = 200
    }
}
