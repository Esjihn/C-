using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Services;
using System.Text;
using System.Threading.Tasks;

namespace ExSectSix
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter your first name");
            var name = Console.ReadLine();
            var nameStorage = new char[name.Length];

            for (int i = name.Length; i > 0; i--)
            {
                nameStorage[name.Length - i] = name[i - 1];
            }

            var reversed = new string(nameStorage);
            Console.WriteLine("Reversed name: " + reversed);
        }
    }
}

