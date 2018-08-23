using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jagged_Dimensional_TestGS
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] jagged =
            {
                new int[] {4, 5},
                new int[] {6, 7, 8},
                new int[] {9, 10, 11},
                new int[] {12, 13, 14, 15}
            };


            foreach (var t in jagged)
            {
                foreach (var t1 in t)
                {
                    Console.WriteLine(t1);
                }

                Console.WriteLine();
            }

            for (int i = 0; i < jagged.Length; i++)
            {
                for (int j = 0; j < jagged[i].Length; j++)
                {
                    Console.WriteLine(jagged[i][j]);
                }

                Console.WriteLine();
            }  


        }
    }
}
