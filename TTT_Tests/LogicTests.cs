using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TTT_Logic;

namespace TTT_Tests
{
    [TestClass]
    public class LogicTests
    {
        [TestMethod]
        public void Createable()
        {
            Logic l = new();
            Assert.IsNotNull(l);
        }

        [TestMethod]
        public void EmptyFieldAfterCreation()
        {
            Logic l = new();
            Board[,] returnedBoard= l.GetGameBoard();

            foreach (Board item in returnedBoard)
            {
                Assert.IsTrue(item == Board.Empty);
            }
        }

        [TestMethod]
        public void FirstMove_Valid()
        {
            // vorbereitung
            Logic l = new(); // logik starten

            // ausführung
            TurnResult result = l.PlayerTurn(0, 0); // erster zug auf gültige koordinaten, muss valid ergeben
            
            // überprüfen des ergebnisses
            Assert.IsTrue(result == TurnResult.Valid); // testen ob auch valid zurück kam
            Assert.IsTrue(l.GetGameBoard()[0, 0] != Board.Empty);// testen ob der Zug auch auf dem Spielfeld vermerkt ist
        }

        [TestMethod]
        public void FirstMove_OutOfRange()
        {
            Logic l = new();

            TurnResult result = l.PlayerTurn(3, 3);
            var returnedBoard = l.GetGameBoard();

            Assert.IsTrue(result == TurnResult.Invalid);
            foreach (Board item in returnedBoard)
            {
                Assert.IsTrue(item == Board.Empty);
            }
        }

        [TestMethod]
        public void FirstMove_NegativeCoordinates()
        {
            Logic l = new();

            TurnResult result = l.PlayerTurn(-1, -1);
            var returnedBoard = l.GetGameBoard();

            Assert.IsTrue(result == TurnResult.Invalid);
            foreach (Board item in returnedBoard)
            {
                Assert.IsTrue(item == Board.Empty);
            }
        }
        
        [TestMethod]
        public void PlayerSwitch_ValidMove()
        {
            Logic l = new();

            Assert.IsTrue(l.PlayerTurn(1, 1) == TurnResult.Valid);
            Assert.IsTrue(l.PlayerTurn(0, 0) == TurnResult.Valid);
            Assert.IsTrue(l.PlayerTurn(0, 1) == TurnResult.Valid);

            var returnedBoard = l.GetGameBoard();

            Assert.IsTrue(returnedBoard[1, 1] != Board.Empty);
            Assert.IsTrue(returnedBoard[0, 0] != Board.Empty);
            Assert.IsTrue(returnedBoard[0, 1] != Board.Empty);

            Assert.IsTrue(returnedBoard[1, 1] == returnedBoard[0,1]);
        }        

        [TestMethod]
        public void PlayerSwitch_InvalidMove()
        {
            Logic l = new();

            Assert.IsTrue(l.PlayerTurn(1, 1) == TurnResult.Valid);//PlayerA belegt mitte
            Assert.IsTrue(l.PlayerTurn(1, 1) == TurnResult.Invalid);// PlayerB belegt fehlerhaft mitte und bleibt am zug
            Assert.IsTrue(l.PlayerTurn(3, -1) == TurnResult.Invalid);// PlayerB gibt falsche koordinaten an
            Assert.IsTrue(l.PlayerTurn(0, 0) == TurnResult.Valid);//PlayerB belegt oben links

            var returnedBoard = l.GetGameBoard();
            Assert.IsTrue(returnedBoard[1, 1] != Board.Empty);
            Assert.IsTrue(returnedBoard[0, 0] != Board.Empty);

            Assert.IsTrue(returnedBoard[0, 0] != returnedBoard[1,1]);
        }

        [TestMethod]
        public void EndGame_Win()
        {
            Logic l = new();

            Assert.IsTrue(l.PlayerTurn(0, 1) == TurnResult.Valid);//PlayerA
            Assert.IsTrue(l.PlayerTurn(1, 1) == TurnResult.Valid);//PlayerB

            Assert.IsTrue(l.PlayerTurn(0, 2) == TurnResult.Valid);//PlayerA
            Assert.IsTrue(l.PlayerTurn(1, 2) == TurnResult.Valid);//PlayerB

            var turnResult = l.PlayerTurn(0, 0);
            Assert.IsTrue(turnResult == TurnResult.WinO || turnResult == TurnResult.WinX);//PlayerA gewinnt
        }

        //TODO: win on last stone
        //TODO: draw
        //TODO: no moves after win
    }
}
