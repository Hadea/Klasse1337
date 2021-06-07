using System;
using TTT_Logic;

namespace TTT_UIConsole
{
    internal class GameScene : Scene
    {
        readonly Logic mGameLogic = new();

        /// <summary>
        /// Asks the player for coordinates and sends them to the logic
        /// </summary>
        public override void Update()
        {
            // ausgabe Spieler X oder Y soll koordinaten eingeben

            Console.WriteLine("Bitte Koordinaten eingeben");
            string userInput = Console.ReadLine();
            int x = userInput[0] - 48; //A -> 65 -> 17
            int y = userInput[1] - 48; //+ -> 43 -> -5

            TurnResult turnResult = mGameLogic.PlayerTurn(x, y);

            switch (turnResult)
            {
                case TurnResult.WinX:
                case TurnResult.WinO:
                case TurnResult.Draw:
                    SceneManager.Instance.AddScene(new EndGameScene(mGameLogic, turnResult, this));
                    Console.Clear();
                    break;
            }
        }

        /// <summary>
        /// Draws the current playing field and whos turn it is
        /// </summary>
        public override void Draw()
        {
            Console.Clear(); // coordinaten setzen und überschreiben ist besser
            Board[,] board = mGameLogic.GetGameBoard();

            //spielfeld anzeigen
            // horrible hack ... nicht machen!
            Console.WriteLine($"\n\n               {board[0,0],5} | {board[0, 1],5} | {board[0, 2],5}" );
            Console.WriteLine($"               {board[1,0],5} | {board[1, 1],5} | {board[1, 2],5}" );
            Console.WriteLine($"               {board[2,0],5} | {board[2, 1],5} | {board[2, 2],5}" );

            // aktuellen spieler anzeigen
            Console.WriteLine("\nAktueller Spieler ist : " + (mGameLogic.GetCurrentPlayer() ? "O" : "X"));
            // farben maybe?
            
        }
    }
}
