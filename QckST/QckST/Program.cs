using System;
using System.IO;

namespace QckST
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] intArray = {-1, 35, -15, 7, 55, 1, -22};

            quickSort(intArray, 0, intArray.Length);

            for (int i = 0; i < intArray.Length; i++)
            {
                Console.WriteLine(intArray[i]);
            }
        }


        static void quickSort(int[] input, int start, int end)
        {
            // If array is size one then it doesnt need to be 
            // sorted
            if (end - start < 2)
            {
                return;
            }

            // Figure out where is the index of pivot sorted
            // Put pivot in right location everything to the left
            // of the pivot is less than, everything to the right 
            // is greater than
            int pivotIndex = partition(input, start, end);
            // quick sort the left sub array (recursive call)
            quickSort(input, start, pivotIndex);
            // quick sort the right sub array
            quickSort(input, pivotIndex + 1, end);

        }

        static int partition(int[] input, int start, int end)
        {
            // This is using the first element as the pivot
            int pivot = input[start];
            // index traversing from left to right
            int i = start;
            // index traversing from right to left
            int j = end;
            // Run while start hasnt crossed over end
            while (i < j)
            {
                // NOTE: empty loop body, using loop to keep
                // decrementing j until find element less than 
                // pivot or j crosses i
                while (i < j && input[--j] >= pivot);
                if (i < j)
                {
                    // move element j into i if less than pivot found
                    input[i] = input[j];
                }
                // NOTE: empty loop body, using 
                while (i < j && input[++i] <= pivot);
                if (i < j)
                {
                    // NOTE: not losing data we have already moved 
                    // data in previous non empty loop
                    input[j] = input[i];
                }

            }

            input[j] = pivot;
            // return index where we inserted pivot
            return j;


        }
    }
}
