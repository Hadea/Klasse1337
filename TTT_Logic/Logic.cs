using System;

namespace TTT_Logic
{
    public class Logic
    {
        private Board[,] mGameBoard = new Board[3, 3];
        private bool mCurrentPlayer;
        private bool mGameRunning = true;
        private byte mTurnCounter = 0;

        public Board[,] GetGameBoard()
        {
            return mGameBoard;
        }

        public TurnResult PlayerTurn(int x, int y)
        {
            if (x > 2 || y > 2) return TurnResult.Invalid;
            if (x < 0 || y < 0) return TurnResult.Invalid;
            if (mGameBoard[y, x] != Board.Empty) return TurnResult.Invalid;
            if (!mGameRunning) return TurnResult.Invalid;
            if (mTurnCounter > 7) return TurnResult.Draw;

            mGameBoard[y, x] = mCurrentPlayer ? Board.O : Board.X;
            mTurnCounter++;

            if (mCheckWin())
            {
                mGameRunning = false;
                return mCurrentPlayer ? TurnResult.WinO : TurnResult.WinX;
            }
            else
            {
                mCurrentPlayer = !mCurrentPlayer;
                return TurnResult.Valid;
            }
        }

        private bool mCheckWin()
        {
            if (mTurnCounter < 5) return false;

            if (mGameBoard[0, 0] != Board.Empty)
            {
                if (mGameBoard[0, 0] == mGameBoard[0, 1] && mGameBoard[0, 0] == mGameBoard[0, 2]) return true;
                if (mGameBoard[0, 0] == mGameBoard[1, 1] && mGameBoard[0, 0] == mGameBoard[2, 2]) return true;
                if (mGameBoard[0, 0] == mGameBoard[1, 0] && mGameBoard[0, 0] == mGameBoard[2, 0]) return true;
            }

            if (mGameBoard[0, 2] != Board.Empty)
            {
                if (mGameBoard[0, 2] == mGameBoard[1, 2] && mGameBoard[0, 2] == mGameBoard[2, 2]) return true;
                if (mGameBoard[0, 2] == mGameBoard[1, 1] && mGameBoard[0, 2] == mGameBoard[2, 0]) return true;
            }

            if (mGameBoard[1, 0] != Board.Empty && mGameBoard[1, 0] == mGameBoard[1, 1] && mGameBoard[1, 0] == mGameBoard[1, 2]) return true;
            if (mGameBoard[2, 0] != Board.Empty && mGameBoard[2, 0] == mGameBoard[2, 1] && mGameBoard[2, 0] == mGameBoard[2, 2]) return true;

            if (mGameBoard[0, 1] != Board.Empty && mGameBoard[0, 1] == mGameBoard[1, 1] && mGameBoard[0, 1] == mGameBoard[2, 1]) return true;

            return false;
        }

        public bool GetCurrentPlayer()
        {
            return mCurrentPlayer;
        }

        public void Reset()
        {
            mGameRunning = true;
            mCurrentPlayer = !mCurrentPlayer;
            mGameBoard = new Board[3, 3];
            mTurnCounter = 0;
        }
    }
}
