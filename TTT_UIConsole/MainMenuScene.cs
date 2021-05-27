using System;

namespace TTT_UIConsole
{
    class MainMenuScene : Scene
    {
        public MainMenuScene()
        {
            mLabelList.Add(new Text(10, 1, "logo.txt"));
            mButtonList.Add(new Button(22, 12, "Start New Game", () => SceneManager.Instance.AddScene(new GameScene())));
            mButtonList.Add(new Button(24, 14, "Credits", () => SceneManager.Instance.AddScene(new CreditsScene())));
            mButtonList.Add(new Button(26, 16, "Quit", () => SceneManager.Instance.RemoveScene(this)));

            mButtonList[mActiveButtonID].IsSelected = true;
        }

        public override void Update()
        {
            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.UpArrow:
                    mButtonList[mActiveButtonID].IsSelected = false;
                    mActiveButtonID = (byte)(mActiveButtonID == 0 ? mButtonList.Count - 1 : mActiveButtonID - 1); //TODO, was wenn wir schon ganz oben sind?
                    mButtonList[mActiveButtonID].IsSelected = true;
                    break;
                case ConsoleKey.DownArrow:
                    mButtonList[mActiveButtonID].IsSelected = false;
                    mActiveButtonID = (byte)(mActiveButtonID == mButtonList.Count - 1 ? 0 : mActiveButtonID + 1);
                    mButtonList[mActiveButtonID].IsSelected = true;
                    break;
                case ConsoleKey.Enter:
                    mButtonList[mActiveButtonID].Execute();
                    break;
            }
        }
    }
}
