using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inches
{
    class Inches
    {
        static void Main(string[] args)
        {
            // Using break with nested loops.
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("Outer loop count: " + i);
                Console.WriteLine("     Inner loop count: ");

                int t = 0;
                while (t < 100)
                {
                    if (t == 10)
                    {
                        break;
                    }

                    Console.Write(t + " ");
                    t++;
                }

                Console.WriteLine();
            }

            Console.WriteLine("Loops complete.");
        }
    }
}
