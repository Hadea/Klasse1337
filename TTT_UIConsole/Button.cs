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

        /// <summary>
        /// Selektiert oder Deselektiert den Button.
        /// </summary>
        public bool IsSelected
        {
            get { return mIsSelected; }
            set
            {
                mIsSelected = value;
                mCurrentColor = IsSelected ? mColorSelected : mColorNotSelected;
            }
        }

        /// <summary>
        /// Erstellt einen neuen Button
        /// </summary>
        /// <param name="X">Horizontaler Abstand zum linken Rand</param>
        /// <param name="Y">Vertikaler Abstand zum oberen Rand</param>
        /// <param name="Text">Text welcher auf dem Button stehen soll</param>
        /// <param name="Command">Kommando welches ausgeführt werden soll wenn der Button mit Enter bestätigt wird</param>
        public Button(int X, int Y, string Text, ButtonEvent Command) : base(X, Y, Text)
        {
            mCommand = Command;
        }

        /// <summary>
        /// Lässt den button auf Tastaturkommandos reagieren
        /// </summary>
        /// <param name="Key">Taste welche mit Console.ReadKey() gelesen wurde</param>
        public void HandleInput(ConsoleKey Key)
        {
            if (Key == ConsoleKey.Enter)
            {
                mCommand();
            }
        }

        /// <summary>
        /// Zeichnet den Button auf die Console
        /// </summary>
        public override void Draw()
        {
            Console.BackgroundColor = mCurrentColor;
            Console.SetCursorPosition(mPosX, mPosY);
            Console.WriteLine(mText);
        }
    }
}
