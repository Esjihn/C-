using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StopWatchEX
{
    class Program
    {
        static void Main(string[] args)
        {
            StopWatchConsole();
        }

        static void StopWatchConsole()
        {
            Stopwatch s1 = new Stopwatch(TimeSpan.MinValue, TimeSpan.MaxValue);

            Console.WriteLine(s1);
        }
    }
}
