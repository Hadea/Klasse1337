using System;

namespace TTT_UIConsole
{
    //todo: finish button
    class Button : Label
    {
        private readonly Action mCommand;
        private const ConsoleColor mColorNotSelected = ConsoleColor.Black;
        private const ConsoleColor mColorSelected = ConsoleColor.Yellow;

        public bool IsSelected { get; set; }

        public Button(int X, int Y, string Text, Action btnStartGame) : base(X, Y, Text)
        {
            mCommand = btnStartGame;
        }

        public void Execute()
        {
            mCommand();
        }

        public override void Draw()
        {
            Console.SetCursorPosition(mPosX, mPosY);
            Console.BackgroundColor = IsSelected ? mColorSelected : mColorNotSelected;
            Console.WriteLine(mText);
        }
    }
}
