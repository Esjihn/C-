using System;

namespace ArrAndString1._1
{
    class Program
    {
        static void Main(string[] args)
        {
            IsUniqueChart("Name");
            Console.ReadKey();
        }

        static Boolean IsUniqueChart(string text)
        {
            if (text.Length == 0 || text.Length > 256)
            {
                Console.WriteLine(" The text is empty or too larg");
                return false;
            }
            Boolean[] charSet = new Boolean[256];

            for (int i = 0; i < text.Length; i++)
            {
                int val = text[i];//already found this char in the string
                if (charSet[val])
                {
                    Console.WriteLine(" The text is not unique");
                    return false;
                }
                charSet[val] = true;
            }
            Console.WriteLine(" The text is unique");
            return true;
        }

    }
}