using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multi_Dimensional_TestGS
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] numbers = new int[2, 5]
            {
                {2, 4, 6, 8, 10},
                {1, 3, 5, 7, 9}
            };

            for (int row = 0; row < numbers.GetLength(0); row++)
            {
                for (int col = 0; col < numbers.GetLength(1); col++)
                {
                    Console.WriteLine(numbers[row, col]);
                }

                Console.WriteLine();
            }
        }
    }
}
