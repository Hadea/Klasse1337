using System;

namespace TTT_Logic
{
    /// <summary>
    /// Enthält die Logik für Tic Tac Toe
    /// </summary>
    public class Logic
    {
        private Board[,] mGameBoard = new Board[3, 3];
        private bool mCurrentPlayer;
        private bool mGameRunning = true;
        private byte mTurnCounter = 0;

        public Logic()
        {
            Random rndGen = new();
            mCurrentPlayer = rndGen.Next() % 2 == 1;
        }

        public Board[,] GetGameBoard()
        {
            return mGameBoard;
        }

        /// <summary>
        /// Nimmt für das aktuelle Spiel die Koordinaten des Zuges entgegen und wertet diesen Zug aus.
        /// </summary>
        /// <param name="x">X-Koordinate auf dem Spielfeld</param>
        /// <param name="y">Y-Koordinate auf dem Spielfeld</param>
        /// <returns>Gibt das Ergebnis des Zuges zurück als <see cref="TurnResult"/></returns>
        public TurnResult PlayerTurn(int x, int y)
        {
            if (x > 2 || y > 2) return TurnResult.Invalid;
            if (x < 0 || y < 0) return TurnResult.Invalid;
            if (mGameBoard[y, x] != Board.Empty) return TurnResult.Invalid;
            if (!mGameRunning) return TurnResult.Invalid;

            mGameBoard[y,x] = mCurrentPlayer ? Board.O: Board.X;
            mTurnCounter++;

            if (checkWin())
            {
                mGameRunning = false;
                return mCurrentPlayer ? TurnResult.WinO : TurnResult.WinX;
            }
            else
            {
                if (mTurnCounter > 8) return TurnResult.Draw;
                mCurrentPlayer = !mCurrentPlayer;
                return TurnResult.Valid;
            }
        }

        /// <summary>
        /// Prüft ob es einen Gewinner gibt
        /// </summary>
        /// <returns>true wenn es einen gewinner gibt, sonst false</returns>
        private bool checkWin()
        {
            if (mTurnCounter < 5) return false;
            //TODO: check center first

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

        public void ResetGame()
        {
            mGameRunning = true;
            mCurrentPlayer = !mCurrentPlayer;
            for (int Y = 0; Y < 3; Y++)
            {
                for (int X = 0; X < 3; X++)
                {
                    mGameBoard[Y,X] = Board.Empty;
                }
            }

            mTurnCounter = 0;
        }
    }
}
