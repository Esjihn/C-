using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoveDuplicatesFromSortedArr
{
    class Program
    {
        static void Main(string[] args)
        {
            int [] nums = {0,0,1,1,1,2,2,3,3,4};
            Console.WriteLine(RemoveDuplicates(nums));

        }

        public static int RemoveDuplicates(int[] nums)
        {
            if (nums == null || nums.Length == 0)
                return 0;

            int index = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (i == 0 || nums[i] != nums[i - 1])
                {
                    nums[index++] = nums[i];
                }
            }

            foreach (var num in nums)
            {
                Console.Write(num + " ");
            }

            Console.WriteLine();
            return index;
        }

        public static void PrintDuplicates()
        {

        }
    }
}
