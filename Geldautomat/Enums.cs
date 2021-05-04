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
}
