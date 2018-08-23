/*
 * C# Program to Check whether the Entered Number is Even or Odd
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace check1
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.Write("Enter a Number : ");
            int i = Convert.ToInt32(Console.ReadLine());
            if (i % 2 == 0)
            {
                Console.WriteLine("Entered Number is an Even Number");
            }
            else
            {
                Console.WriteLine("Entered Number is an Odd Number");
            }
        }
    }
}