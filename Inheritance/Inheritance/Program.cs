
using System;

namespace Inheritance
{
    class Program
    {
        static void Main(string[] args)
        {
            var text = new Text();
            text.Width = 100;
            Console.WriteLine(text.Width);
            text.Copy();
        }
    }
}
