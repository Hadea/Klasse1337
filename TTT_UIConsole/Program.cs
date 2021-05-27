using System;
using TTT_Logic;

namespace TTT_UIConsole
{
    class Program
    {
        static void Main()
        {
            Console.CursorVisible = false;
            SceneManager.Instance.AddScene(new MainMenuScene());

            while (SceneManager.Instance.Count > 0)
            {
                SceneManager.Instance.Draw();
                SceneManager.Instance.Update();
            }
        }
    }
}
