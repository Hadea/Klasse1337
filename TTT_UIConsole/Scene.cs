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

        public abstract void Update();

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
