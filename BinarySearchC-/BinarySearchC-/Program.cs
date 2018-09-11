using System;

namespace BinarySearchC_
{
    class Program
    {
        // binary search requires data thats already sorted
        // iF element is equal to the value, we're done
        // if element is greater than the value, search the left
        // half of the array, if less than, search the right of 
        // the array.
        // Similar to merge sort.
        // time complexity O(logn)
        static void Main(string[] args)
        {
            int[] intArray = {-22, -15, 1, 7, 20, 35, 55};

            Console.WriteLine(iterativeBinarySearch(intArray, -15));
            Console.WriteLine(iterativeBinarySearch(intArray, 35));
            Console.WriteLine(iterativeBinarySearch(intArray, 8888));
            Console.WriteLine(iterativeBinarySearch(intArray, 1));
        }

        static int iterativeBinarySearch(int[] input, int value)
        {
            int start = 0;
            int end = input.Length;

            while (start < end)
            {
                int midpoint = (start + end) / 2;
                Console.WriteLine("midpoint = " + midpoint);
                if (input[midpoint] == value)
                {
                    return midpoint;
                }
                // search right part of array
                else if (input[midpoint] < value)
                {
                    // changing index not value
                    start = midpoint + 1;
                }
                else
                {
                    end = midpoint; // search left part of array
                }
            }

            return -1;
        }

    }
}
