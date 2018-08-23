using System;

namespace Stopwatch
{
    class StopWatch
    {
        double _start;
        double _stop;

        public StopWatch()
        {
            
        }
        double GetStart()
        {
            return _start += TimeSpan.FromSeconds();
        }

        void SetStart(int st)
        {
            this._start = st;
        }

        void SetStop(int stp)
        {
            this._stop = stp;
        }

        double GetStop()
        {
            return _stop - _start;
        }
    }
}