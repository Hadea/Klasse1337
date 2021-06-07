using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TTT_UIConsole
{
    class Timer
    {
        private DateTime mTimeBegin;
        private int mFrames = 0;
        private int mFPS = 0;

        public int FPS { get { return mFPS; } }

        public void Update()
        {
            mFrames++;
            if ( (DateTime.Now - mTimeBegin).TotalMilliseconds > 1000d )
            {
                mTimeBegin = DateTime.Now;
                mFPS = mFrames;
                mFrames = 0;
            }
        }
    }
}
