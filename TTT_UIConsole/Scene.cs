using System;
using System.Collections.Generic;

namespace TTT_UIConsole
{
    abstract class Scene
    {
        protected readonly List<Label> mLabelList;
        protected readonly List<Button> mButtonList;
        protected byte mActiveButtonID;

        public Scene()
        {
            mLabelList = new();
            mButtonList = new();
        }

        public virtual void Update()
        {
            if (Console.KeyAvailable)
            {
                var key = Console.ReadKey(true).Key;
                switch (key)
                {
                    case ConsoleKey.UpArrow:
                        mButtonList[mActiveButtonID].IsSelected = false;
                        mActiveButtonID = (byte)(mActiveButtonID == 0 ? mButtonList.Count - 1 : mActiveButtonID - 1);
                        mButtonList[mActiveButtonID].IsSelected = true;
                        break;
                    case ConsoleKey.DownArrow:
                        mButtonList[mActiveButtonID].IsSelected = false;
                        mActiveButtonID = (byte)(mActiveButtonID == mButtonList.Count - 1 ? 0 : mActiveButtonID + 1);
                        mButtonList[mActiveButtonID].IsSelected = true;
                        break;
                    default:
                        mButtonList[mActiveButtonID].HandleInput(key);
                        break;
                }
            }

        }

        public virtual void Draw()
        {
            foreach (var item in mLabelList)
            {
                item.Draw();
            }

            foreach (var item in mButtonList)
            {
                item.Draw();
            }
        }
    }
}
