using System;

namespace TTT_UIConsole
{
    class Button : Label
    {
        private readonly ButtonEvent mCommand;
        private const ConsoleColor mColorNotSelected = ConsoleColor.Black;
        private const ConsoleColor mColorSelected = ConsoleColor.Yellow;
        private ConsoleColor mCurrentColor = mColorNotSelected;
        private bool mIsSelected;

        public bool IsSelected
        {
            get { return mIsSelected; }
            set
            {
                mIsSelected = value;
                mCurrentColor = IsSelected ? mColorSelected : mColorNotSelected;
            }
        }

        public Button(int X, int Y, string Text, ButtonEvent btnStartGame) : base(X, Y, Text)
        {
            mCommand = btnStartGame;
        }

        public void HandleInput(ConsoleKey Key)
        {
            if (Key == ConsoleKey.Enter)
            {
                mCommand();
            }
        }

        public override void Draw()
        {
            Console.BackgroundColor = mCurrentColor;
            Console.SetCursorPosition(mPosX, mPosY);
            Console.WriteLine(mText);
        }
    }
}
