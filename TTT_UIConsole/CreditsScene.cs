using System;
using System.Collections.Generic;
using System.IO;

namespace TTT_UIConsole
{
    class CreditsScene : Scene
    {
        readonly List<string> mCreditsLines = new();
        int mOffsetY;
        const float mStepDelay = 1;
        DateTime mLastFrameTime;

        public CreditsScene()
        {
            mCreditsLines.AddRange(File.ReadAllLines("logo.txt"));
            mCreditsLines.AddRange(File.ReadAllLines("Credits.txt"));
            mOffsetY = Console.WindowHeight - 1;
            mLastFrameTime = DateTime.Now;
        }

        public override void Update()
        {
            if (Console.KeyAvailable)
            {
                Console.ReadKey(true);
                SceneManager.Instance.RemoveScene(this);
            }
        }

        public override void Draw()
        {
            // anhand des offsets berechnen welche die erste zeile auf dem bildschirm sein müsste
            // das array ab berechneter position bis zum ende des bildschirmes füllen solange noch daten da sind
            int screenHeight = Console.WindowHeight;
            if ((DateTime.Now - mLastFrameTime).TotalSeconds > mStepDelay)
            {
                Console.Clear();
                mLastFrameTime = DateTime.Now;
                mOffsetY--;
                int lineToWrite = Math.Min(0, mOffsetY);
                Console.SetCursorPosition(0, Math.Max(0, mOffsetY));
                for (int screenLineID = Math.Max(0, mOffsetY); screenLineID < screenHeight && lineToWrite < mCreditsLines.Count; screenLineID++)
                {
                    Console.WriteLine(mCreditsLines[lineToWrite++]);
                }
            }

        }
    }
}
