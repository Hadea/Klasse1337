using TTT_Logic;
using System;

namespace TTT_UIConsole
{
    internal class EndGameScene : Scene
    {
        private readonly Logic mLogic;
        private readonly TurnResult mTurnResult;

        public EndGameScene(Logic RunningLogic, TurnResult LastTurnResult, GameScene gameScene)
        {
            mLogic = RunningLogic;
            mTurnResult = LastTurnResult;

        
            mLabelList.Add(new Label(30,5,"Spielende"));
            mLabelList.Add(new Label(30,6,LastTurnResult.ToString()));
            mButtonList.Add(new Button(30,8,"Nächste Runde", () => { Console.Clear(); mLogic.ResetGame(); SceneManager.Instance.RemoveScene(this); }));
            mButtonList.Add(new Button(27,10,"zurück zum Hauptmenü", () => { Console.Clear(); SceneManager.Instance.RemoveScene(gameScene); SceneManager.Instance.RemoveScene(this); }));
            mButtonList[mActiveButtonID].IsSelected = true;
        }
    }
}
