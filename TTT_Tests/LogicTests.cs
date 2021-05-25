using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TTT_Logic;

namespace TTT_Tests
{
    /* Checkliste für tests (unvollständig)
     * Parameter einer Funktion
     *      - Null
     *      - Negative werte
     *      - Leere Container
     *      - Zu grosse werte
     *      - korrekte exceptions wenn fehlerhafte werte benutzt werden
     * 
     * Rückgabe einer Funktion / out-Parameter
     *      - Null
     *      - Leere Container
     *      - Erwarteter Wert
     */

    /* Nach Spielstart ein leeres Spielfeld
     * Nach einem Zug auf eine gültige koordinate muss das gewählte feld befüllt sein, der rest muss weiterhin leer sein
     * Ein Zug auf ein belegtes feld muss "Ungültig" liefern
     * Ein Zug auf eine ungültige Koordinate (ausserhalb) muss "Ungültig" liefern
     * Zwei aufeinanderfolgende Züge auf unterschiedliche gültige koordinaten müssen unterschiedliche steine beinhalten
     * Wenn der letzte stein auf das feld gesetzt wird und keinen Sieg bedeutet muss "Draw" geliefert werden
     * Wenn der letzte stein auf dem feld zu einer siegbedingung führt muss "sieg" zurückgegeben werden
     * Wenn 3 gleiche steine in einer reihe sind soll "Sieg" zurückgegeben werden 
     * Wenn 3 gleiche steine in einer spalte sind soll "Sieg" zurückgegeben werden 
     * Wenn 3 gleiche steine in einer diagonalen sind soll "Sieg" zurückgegeben werden 
     * Aufeinanderfolgende fehlerhafte züge führen nicht zum spielerwechsel
     * 
     * Ein Spieler darf nicht mehr als 10 mal in folge als erster am zug sein / Spieler sind immer abwechslnd dran/ verlierer beginnt
     * Nach einem Sieg sind normalerweise gültige züge auch "Ungültig"
     * Nach einem Sieg bleibt der aktuelle spieler auf dem Siegspieler stehen
     */

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
            Board[,] returnedBoard = l.GetGameBoard();

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

            // playerturn nimmt erst X dann Y
            Assert.IsTrue(l.PlayerTurn(1, 1) == TurnResult.Valid);
            Assert.IsTrue(l.PlayerTurn(0, 0) == TurnResult.Valid);
            Assert.IsTrue(l.PlayerTurn(0, 1) == TurnResult.Valid);

            var returnedBoard = l.GetGameBoard();

            // Arrayzugriff ist erst Y dann X
            Assert.IsTrue(returnedBoard[1, 1] != Board.Empty);
            Assert.IsTrue(returnedBoard[0, 0] != Board.Empty);
            Assert.IsTrue(returnedBoard[1, 0] != Board.Empty);

            Assert.IsTrue(returnedBoard[1, 1] == returnedBoard[1, 0]);
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

            Assert.IsTrue(returnedBoard[0, 0] != returnedBoard[1, 1]);
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

        [TestMethod]
        public void EndGame_Draw()
        {
            Logic l = new();
            //X O X
            //O X O 
            //O X O

            Assert.IsTrue(l.PlayerTurn(0, 1) == TurnResult.Valid); // O
            Assert.IsTrue(l.PlayerTurn(0, 0) == TurnResult.Valid); // X
            Assert.IsTrue(l.PlayerTurn(1, 0) == TurnResult.Valid); // O
            Assert.IsTrue(l.PlayerTurn(0, 2) == TurnResult.Valid); // X
            Assert.IsTrue(l.PlayerTurn(2, 0) == TurnResult.Valid); // O 
            Assert.IsTrue(l.PlayerTurn(1, 1) == TurnResult.Valid); // X
            Assert.IsTrue(l.PlayerTurn(1, 2) == TurnResult.Valid); // O
            Assert.IsTrue(l.PlayerTurn(2, 1) == TurnResult.Valid); // X
            Assert.IsTrue(l.PlayerTurn(2, 2) == TurnResult.Draw); // O
        }

        [TestMethod]
        public void EndGame_PlayablaAfterDrawAndReset()
        {
            Logic l = new();
            //X O X
            //O X O 
            //O X O

            Assert.IsTrue(l.PlayerTurn(0, 1) == TurnResult.Valid); // O
            Assert.IsTrue(l.PlayerTurn(0, 0) == TurnResult.Valid); // X
            Assert.IsTrue(l.PlayerTurn(1, 0) == TurnResult.Valid); // O
            Assert.IsTrue(l.PlayerTurn(0, 2) == TurnResult.Valid); // X
            Assert.IsTrue(l.PlayerTurn(2, 0) == TurnResult.Valid); // O 
            Assert.IsTrue(l.PlayerTurn(1, 1) == TurnResult.Valid); // X
            Assert.IsTrue(l.PlayerTurn(1, 2) == TurnResult.Valid); // O
            Assert.IsTrue(l.PlayerTurn(2, 1) == TurnResult.Valid); // X
            Assert.IsTrue(l.PlayerTurn(2, 2) == TurnResult.Draw); // O

            l.Reset();
            Assert.IsTrue(l.PlayerTurn(0, 1) == TurnResult.Valid); // O

        }

        [TestMethod]
        public void EndGame_NoMovesAfterWin()
        {
            Logic l = new();

            Assert.IsTrue(l.PlayerTurn(0, 1) == TurnResult.Valid);//PlayerA
            Assert.IsTrue(l.PlayerTurn(1, 1) == TurnResult.Valid);//PlayerB

            Assert.IsTrue(l.PlayerTurn(0, 2) == TurnResult.Valid);//PlayerA
            Assert.IsTrue(l.PlayerTurn(1, 2) == TurnResult.Valid);//PlayerB

            var turnResult = l.PlayerTurn(0, 0);
            Assert.IsTrue(turnResult == TurnResult.WinO || turnResult == TurnResult.WinX);//PlayerA gewinnt

            Assert.IsTrue(l.PlayerTurn(2, 2) == TurnResult.Invalid);//Ungültig da das Spiel schon vorbei ist
        }
        //TODO: win on last stone

        [TestMethod]
        public void Player_GetCurrentPlayer()
        {
            Logic l = new();

            bool result = l.GetCurrentPlayer();
            l.PlayerTurn(0, 0);
            Assert.IsTrue(result != l.GetCurrentPlayer());
        }
        [TestMethod]
        public void Player_GetCurrentPlayer_InvalidMove()
        {
            Logic l = new();

            bool result = l.GetCurrentPlayer();
            l.PlayerTurn(0, 0); // X
            l.PlayerTurn(0, 1); // O
            l.PlayerTurn(0, 1); // X ungültig, x bleibt am zug
            Assert.IsTrue(result == l.GetCurrentPlayer());
        }

        [TestMethod]
        public void Reset_SwitchesPlayer()
        {
            Logic l = new();
            bool firstPlayer = l.GetCurrentPlayer();

            l.Reset();
            Assert.IsTrue(firstPlayer != l.GetCurrentPlayer());
            l.Reset();
            Assert.IsTrue(firstPlayer == l.GetCurrentPlayer());
        }

        [TestMethod]
        public void Reset_ClearsTheBoard()
        {
            Logic l = new();
            l.PlayerTurn(1, 1);
            Assert.IsTrue(l.GetGameBoard()[1, 1] != Board.Empty);
            l.Reset();
            Assert.IsTrue(l.GetGameBoard()[1, 1] == Board.Empty);
      
        }
    }
}
