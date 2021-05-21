using System.Collections.Generic;

namespace TTT_UIConsole
{
    abstract class Scene
    {
        private List<Label> mLabelList;
        private List<Button> mButtonList;


        public abstract void Update();

        public abstract void Draw();
    }
}
