using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpSection_2.Classes;

namespace CSharpSection_2
{
    class SimpleMath
    {
        public static float Add(float n1, float n2)
        {
            return n1 + n2;
        }
        public static float Multiplication(float n1, float n2)
        {
            return n1 * n2;
        }
        public static float Subtract(float n1, float n2)
        {
            return n1 - n2;
        }
        public static float Division(float n1, float n2)
        {
            return n1 / n2;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            simpleMathConsole();

        }
        static void simpleMathConsole()
        {
            Console.WriteLine(SimpleMath.Division(432.23f, 54523.2f));
            BankAccount bankAccount1 = new BankAccount(124321.32f, "Jane Doe");
            Console.WriteLine(bankAccount1.Balance);

            ChildBankAccount bankAccount2 = new ChildBankAccount(1321.32f, "John Doe", "Jane Done");
            

            Console.WriteLine(bankAccount1.addBalance(100f));
            Console.WriteLine(bankAccount2.addBalance(-1421.32f, true));
            
            Console.ReadLine();
            
        }
    }
}
