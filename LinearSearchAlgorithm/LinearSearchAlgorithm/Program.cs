using System;

namespace LinearSearchAlgorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] intArray = {20, 35, -15, 7, 55, 1, -22};
            Console.WriteLine(linearSearch(intArray, -15));
            Console.WriteLine(linearSearch(intArray, 1));
            Console.WriteLine(linearSearch(intArray, 8888));
            Console.WriteLine(linearSearch(intArray, -22));
            //O(n) linear
        }

        static int linearSearch(int[] input, int value)
        {
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == value)
                {
                    return i;
                }
            }

            return -1;
        }

    }
}
