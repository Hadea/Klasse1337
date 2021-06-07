using System;
using System.IO;

namespace TTT_UIConsole
{
    internal class CreditsScene : Scene
    {
        string[] creditsLines;
        int mOffsetY;
        float mStepDelay = 1;
        DateTime mLastFrameTime;

        public CreditsScene()
        {
            creditsLines = File.ReadAllLines("Credits.txt");
            mOffsetY = Console.WindowHeight;
            mLastFrameTime = DateTime.Now;
        }

        public override void Update()
        {
            if (Console.KeyAvailable)
            {
                Console.ReadKey(true);
                SceneManager.Instance.RemoveScene(this);
            }

            if ((DateTime.Now -  mLastFrameTime).TotalSeconds > mStepDelay )
            {
                mLastFrameTime = DateTime.Now;
                mOffsetY--;
            }
        }

        public override void Draw()
        {
            // anhand des offsets berechnen welche die erste zeile auf dem bildschirm sein müsste
            // das array ab berechneter position bis zum ende des bildschirmes füllen solange noch daten da sind


        }
    }
}
