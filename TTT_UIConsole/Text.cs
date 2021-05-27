using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TTT_UIConsole
{
    class Text : Label
    {
        readonly string[] mLines;
        public Text(int X, int Y, string FileName) : base(X,Y,FileName)
        {
            mLines = File.ReadAllLines(FileName);
        }

        public override void Draw()
        {
            Console.ResetColor();
            for (int counter = 0; counter < mLines.Length; counter++)
            {
                Console.SetCursorPosition(mPosX, mPosY + counter);
                Console.Write(mLines[counter]);
            }
        }
    }
}
