using System;

namespace TTT_UIConsole
{
    class Label
    {
        protected readonly int mPosX;
        protected readonly int mPosY;
        protected readonly string mText;

        public Label(int X, int Y, string Text)
        {
            mPosX = X;
            mPosY = Y;
            mText = Text;
        }

        public virtual void Draw()
        {
            Console.SetCursorPosition(mPosX, mPosY);
            Console.ResetColor();
            Console.WriteLine(mText);
        }
    }
}
