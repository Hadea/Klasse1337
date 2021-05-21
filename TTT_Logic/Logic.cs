using System;

namespace TTT_Logic
{
    public class Logic
    {
        private Board[,] mGameBoard = new Board[3,3];

        public Board[,] GetGameBoard()
        {
            return mGameBoard;
        }

        public TurnResult PlayerTurn(int x, int y)
        {
            if (x > 2 || y > 2) return TurnResult.Invalid;

            mGameBoard[y, x] = Board.O;

            return TurnResult.Valid;
        }
    }
}
