using System;
using System.Collections.Generic;
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

    /* 
     * 
     * Ein Zug auf ein belegtes feld muss "Ungültig" liefern
     * 
     * 
     * 
     * Wenn 3 gleiche steine in einer reihe sind soll "Sieg" zurückgegeben werden 
     * Wenn 3 gleiche steine in einer spalte sind soll "Sieg" zurückgegeben werden 
     * Wenn 3 gleiche steine in einer diagonalen sind soll "Sieg" zurückgegeben werden 
     * 
     * 
     * Ein Spieler darf nicht mehr als 10 mal in folge als erster am zug sein / Spieler sind immer abwechslnd dran/ verlierer beginnt
     * 
     * Nach einem Sieg bleibt der aktuelle spieler auf dem Siegspieler stehen
     */

    [TestClass]
    public class LogicTests
    {
        /// <summary>
        /// Testet ob die Logik vorhanden ist.
        /// </summary>
        [TestMethod]
        public void Createable()
        {
            Logic l = new();
            Assert.IsNotNull(l);
        }

        /// <summary>
        /// Nach Spielstart ein leeres Spielfeld
        /// </summary>
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

        /// <summary>
        /// Nach einem Zug auf eine gültige koordinate muss das gewählte feld befüllt sein, der rest muss weiterhin leer sein
        /// </summary>
        [TestMethod]
        public void FirstMove_Valid()
        {
            // vorbereitung
            Logic l = new(); // logik starten

            // ausführung
            TurnResult result = l.PlayerTurn(0, 0); // erster zug auf gültige koordinaten, muss valid ergeben

            // überprüfen des ergebnisses
            Assert.IsTrue(result == TurnResult.Valid); // testen ob auch valid zurück kam
            Assert.IsTrue(l.GetGameBoard()[0, 0] == Board.X || l.GetGameBoard()[0, 0] == Board.O);// testen ob der Zug auch auf dem Spielfeld vermerkt ist
        }

        /// <summary>
        /// Testet ob jeder mögliche korrekte erste Zug auch als gültig erkannt wird und auf dem Spielfeld eingetragen wird
        /// </summary>
        [TestMethod]
        public void FirstMove_ValidOnEveryPosition()
        {
            // vorbereitung
            Logic[] logicList = new Logic[9];
            for (int counter = 0; counter < 9; counter++)
                logicList[counter] = new Logic();

            // ausführung
            for (int counter = 0; counter < logicList.Length; counter++)
            {
                // counter erzeugt     012345678
                int x = counter % 3;// 012012012
                int y = counter / 3;// 000111222

                Assert.IsTrue(logicList[counter].PlayerTurn(x, y) == TurnResult.Valid); // erster zug auf gültige koordinaten, muss valid ergeben
                Assert.IsTrue(logicList[counter].GetGameBoard()[y, x] == Board.X || logicList[counter].GetGameBoard()[y, x] == Board.O);// testen ob der Zug auch auf dem Spielfeld vermerkt ist
            }
        }
        /// <summary>
        /// Ein Zug auf eine ungültige Koordinate (ausserhalb) muss "Ungültig" liefern. Das Spielfeld muss danach leer bleiben
        /// </summary>
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

        /// <summary>
        /// Ein Zug auf eine ungültige Koordinate (ausserhalb) muss "Ungültig" liefern. Das Spielfeld muss danach leer bleiben
        /// </summary>
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

        /// <summary>
        /// Zwei aufeinanderfolgende Züge auf unterschiedliche gültige koordinaten müssen unterschiedliche steine beinhalten
        /// </summary>
        [TestMethod]
        public void PlayerSwitch_ValidMove()
        {
            Logic l = new();

            // playerturn nimmt erst X dann Y
            Assert.IsTrue(l.PlayerTurn(1, 1) == TurnResult.Valid);
            Assert.IsTrue(l.PlayerTurn(0, 0) == TurnResult.Valid);
            Assert.IsTrue(l.PlayerTurn(0, 1) == TurnResult.Valid);

            Board[,] returnedBoard = l.GetGameBoard();

            // Arrayzugriff ist erst Y dann X
            Assert.IsTrue(returnedBoard[1, 1] != Board.Empty);
            Assert.IsTrue(returnedBoard[0, 0] != Board.Empty);
            Assert.IsTrue(returnedBoard[1, 0] != Board.Empty);

            Assert.IsTrue(returnedBoard[1, 1] == returnedBoard[1, 0]); // prüft ob der erste und der dritte zug den gleichen stein gesetzt haben
            Assert.IsTrue(returnedBoard[1, 1] != returnedBoard[0, 0]); // prüft ob der erste und der zweite zug unterschiedliche steine gesetzt haben
        }

        /// <summary>
        /// Aufeinanderfolgende fehlerhafte züge führen nicht zum spielerwechsel
        /// </summary>
        [TestMethod]
        public void PlayerSwitch_InvalidMove()
        {
            Logic l = new();

            Assert.IsTrue(l.PlayerTurn(1, 1) == TurnResult.Valid);//PlayerA belegt mitte
            Assert.IsTrue(l.PlayerTurn(1, 1) == TurnResult.Invalid);// PlayerB belegt fehlerhaft mitte und bleibt am zug
            Assert.IsTrue(l.PlayerTurn(3, -1) == TurnResult.Invalid);// PlayerB gibt falsche koordinaten an
            Assert.IsTrue(l.PlayerTurn(0, 0) == TurnResult.Valid);//PlayerB belegt oben links

            Board[,] returnedBoard = l.GetGameBoard();
            Assert.IsTrue(returnedBoard[1, 1] != Board.Empty);
            Assert.IsTrue(returnedBoard[0, 0] != Board.Empty);

            Assert.IsTrue(returnedBoard[0, 0] != returnedBoard[1, 1]);
        }

        /// <summary>
        /// Testet ob das Spiel gewonnen werden kann
        /// <list type="table">
        /// <item>XXX</item>
        /// <item>_OO</item>
        /// <item>___</item>
        /// </list>
        /// </summary>
        [TestMethod]
        public void EndGame_Win()
        {
            Logic l = new();

            Assert.IsTrue(l.PlayerTurn(0, 1) == TurnResult.Valid);//PlayerA
            Assert.IsTrue(l.PlayerTurn(1, 1) == TurnResult.Valid);//PlayerB

            Assert.IsTrue(l.PlayerTurn(0, 2) == TurnResult.Valid);//PlayerA
            Assert.IsTrue(l.PlayerTurn(1, 2) == TurnResult.Valid);//PlayerB

            TurnResult turnResult = l.PlayerTurn(0, 0);
            Assert.IsTrue(turnResult == TurnResult.WinO || turnResult == TurnResult.WinX);//PlayerA gewinnt
        }
        //TODO: testen aller anderen Siegmöglichkeiten


        /// <summary>
        /// Wenn der letzte stein auf das feld gesetzt wird und keinen Sieg bedeutet muss "Draw" geliefert werden
        /// </summary>
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

        /// <summary>
        /// Wenn der letzte stein auf dem feld zu einer siegbedingung führt muss "sieg" zurückgegeben werden
        /// </summary>
        [TestMethod]
        public void EndGame_WinOnLastStone()
        {
            Logic l = new();
            //X O X
            //O X O 
            //O X X

            Assert.IsTrue(l.PlayerTurn(0, 0) == TurnResult.Valid); // X
            Assert.IsTrue(l.PlayerTurn(0, 1) == TurnResult.Valid); // O
            Assert.IsTrue(l.PlayerTurn(0, 2) == TurnResult.Valid); // X
            Assert.IsTrue(l.PlayerTurn(1, 0) == TurnResult.Valid); // O
            Assert.IsTrue(l.PlayerTurn(1, 1) == TurnResult.Valid); // X
            Assert.IsTrue(l.PlayerTurn(2, 0) == TurnResult.Valid); // O 
            Assert.IsTrue(l.PlayerTurn(2, 1) == TurnResult.Valid); // X
            Assert.IsTrue(l.PlayerTurn(1, 2) == TurnResult.Valid); // O
            Assert.IsTrue(l.PlayerTurn(2, 2) != TurnResult.Draw); // X
        }

        /// <summary>
        /// Das Spielfeld muss nach einem reset leer sein und neue Züge sind erlaubt
        /// </summary>
        [TestMethod]
        public void EndGame_PlayableAfterDrawAndReset()
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

            l.ResetGame();
            Board[,] returnedBoard = l.GetGameBoard();
            foreach (Board item in returnedBoard)
            {
                Assert.IsTrue(item == Board.Empty);
            }
            Assert.IsTrue(l.PlayerTurn(0, 1) == TurnResult.Valid); // O

        }

        /// <summary>
        /// Nach einem Sieg sind normalerweise gültige züge auch "Ungültig"
        /// </summary>
        [TestMethod]
        public void EndGame_NoMovesAfterWin()
        {
            Logic l = new();

            Assert.IsTrue(l.PlayerTurn(0, 1) == TurnResult.Valid);//PlayerA
            Assert.IsTrue(l.PlayerTurn(1, 1) == TurnResult.Valid);//PlayerB

            Assert.IsTrue(l.PlayerTurn(0, 2) == TurnResult.Valid);//PlayerA
            Assert.IsTrue(l.PlayerTurn(1, 2) == TurnResult.Valid);//PlayerB

            TurnResult turnResult = l.PlayerTurn(0, 0);
            Assert.IsTrue(turnResult == TurnResult.WinO || turnResult == TurnResult.WinX);//PlayerA gewinnt

            Assert.IsTrue(l.PlayerTurn(2, 2) == TurnResult.Invalid);//Ungültig da das Spiel schon vorbei ist
        }

        /// <summary>
        /// Testet ob GetCurrentPlayer den korrekten Spieler ausgibt und auch nach Zügen wechselt
        /// </summary>
        [TestMethod]
        public void Player_GetCurrentPlayer()
        {
            Logic l = new();

            bool result = l.GetCurrentPlayer();
            l.PlayerTurn(0, 0);
            Assert.IsTrue(result != l.GetCurrentPlayer());
        }

        /// <summary>
        /// Testet ob GetCurrentPlayer bei ungültigen Zügen den gleichen Spieler ausgibt
        /// </summary>
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

        /// <summary>
        /// Testet ob spieler nach einem Reset abwechseld als erstes dran sind
        /// </summary>
        [TestMethod]
        public void Reset_SwitchesPlayer()
        {
            Logic l = new();
            bool firstPlayer = l.GetCurrentPlayer();

            l.ResetGame();
            Assert.IsTrue(firstPlayer != l.GetCurrentPlayer());
            l.ResetGame();
            Assert.IsTrue(firstPlayer == l.GetCurrentPlayer());
        }

        /// <summary>
        /// Testet ob Reset das Spielfeld leert
        /// </summary>
        [TestMethod]
        public void Reset_ClearsTheBoard()
        {
            Logic l = new();
            l.PlayerTurn(1, 1);
            Assert.IsTrue(l.GetGameBoard()[1, 1] != Board.Empty);
            l.ResetGame();
            Assert.IsTrue(l.GetGameBoard()[1, 1] == Board.Empty);

        }

        /// <summary>
        /// Testet ob der Startspieler bei einem völlig neuen Spiel zufällig gewählt wird
        /// Ein Spieler darf nicht mehr als 10 mal in folge als erster am zug sein
        /// </summary>
        [TestMethod]
        public void Player_DifferentBeginners()
        {
            List<Logic> logicList = new();

            logicList.Add(new Logic());
            logicList.Add(new Logic());
            logicList.Add(new Logic());
            logicList.Add(new Logic());
            logicList.Add(new Logic());
            logicList.Add(new Logic());
            logicList.Add(new Logic());
            logicList.Add(new Logic());

            bool firstStarter = logicList[0].GetCurrentPlayer();
            bool different = false;

            for (int counter = 1; counter < logicList.Count; counter++)
            {
                if (logicList[counter].GetCurrentPlayer() != firstStarter)
                {
                    different = true;
                    break;
                }
            }

            Assert.IsTrue(different);
        }
    }
}
