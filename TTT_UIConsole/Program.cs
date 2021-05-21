using System;
using TTT_Logic;

namespace TTT_UIConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Logic l = new();

            var board = l.GetGameBoard();

            if (board[0,0] == Board.O)
                Console.Write("O wurde an den koordinaten 0 0 gefunden");
        }
    }
}
