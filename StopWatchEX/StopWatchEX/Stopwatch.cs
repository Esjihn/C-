using System;

namespace StopWatchEX
{
    public class Stopwatch
    {
        TimeSpan _start;
        TimeSpan _span;

        public Stopwatch(TimeSpan start, TimeSpan span)
        {
            _start = start;
            _span = span;
        }

        public TimeSpan Start(TimeSpan start)
        {
            start = TimeSpan.MinValue.Duration();
            return start;
        }

        public TimeSpan Stop(TimeSpan stop)
        {
            stop = TimeSpan.MaxValue.Duration();
            return stop;
        }
    }
}