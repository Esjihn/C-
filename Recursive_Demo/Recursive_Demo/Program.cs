using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recursive_Demo
{
    class Program
    {
        public static int Fact(int n)
        {
            if (n == 1)
                return 1;
            else
            {
                return n * Fact(n - 1);
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine(Fact(10));
        }
    }
}
