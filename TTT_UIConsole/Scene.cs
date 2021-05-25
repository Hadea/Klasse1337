using System.Collections.Generic;

namespace TTT_UIConsole
{
    abstract class Scene
    {
        private List<Label> mLabelList;
        private List<Button> mButtonList;


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
