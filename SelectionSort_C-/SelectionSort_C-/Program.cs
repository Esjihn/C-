using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelectionSort_C_
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] intArray = {20, 30, -15, 7, 55, 1, -22};


            // Outer loop increases sorted partition by 1. Growing
            // from right to left
            for (int lastUnsortedIndex = intArray.Length - 1;
                lastUnsortedIndex > 0;
                lastUnsortedIndex--)
            {
                int largest = 0;

                // Inner loop is looking for the largest element
                for (int i = 1; i <= lastUnsortedIndex; i++)
                {
                    largest = i;
                }


                Console.WriteLine();
            }

            // Once we know the largest we will then swap the largest element
            // with the last element in the unsorted partition
            // Grow sorted by 1, and then subtract unsorted by 1 of the last index. 

            // swap(intArray, largest, lastUnsortedIndex);



            for (int i = 0; i < intArray.Length; i++)
            {
                Console.WriteLine(intArray[i]);
            }

        }

        public static void swap(int[] array, int i, int j)
        {

            if (i == j)
            {
                return;
            }

            int temp = array[i];
            array[i] = array[j];
            array[j] = temp;

        }
    }
}
