using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSection
{
    class Program
    {
        static float n1 = 432, n2 = 543;
        static void Main(string[] args)
        {
            csharpSectionConsole();
        }
        private static void csharpSectionConsole()
        {
            
            var addition = Add();
            var subtraction = Subtract();
            var multiplication = Multiply();
            var division = Divide();
            // Prevents console for being closed
            Console.WriteLine(addition);
            Console.WriteLine(subtraction);
            Console.WriteLine(multiplication);
            Console.WriteLine(division);

            Console.ReadLine();
        }
        private static float Add()
        {
            float result = n1 + n2;

            return result;
        }
        
        private static float Subtract()
        {
            float result = n1 - n2;

            return result;
        }
        
        private static float Multiply()
        {
            float result = n1 * n2;

            return result;
        }

        private static float Divide()
        {
            float result = n1 / n2;

            return result;
        }
    }
}
