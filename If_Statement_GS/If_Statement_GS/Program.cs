using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace If_Statement_GS
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = 0;


            for (int i = 0; i > number; i++)
            {
                number++;
                if (number % 2 == 0)
                {
                    Console.WriteLine("Even number");
                }

                if (number % 3 == 0)
                {
                    Console.WriteLine("Odd number");
                }
                


            }

        }
    }
}
