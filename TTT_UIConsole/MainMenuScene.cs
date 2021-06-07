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
        public override void Draw()
        {
            base.Draw();
            Console.SetCursorPosition(0, 0);
            Console.Write(SceneManager.Instance.FPS);
        }
    }
}
