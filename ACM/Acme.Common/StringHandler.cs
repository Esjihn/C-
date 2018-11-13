using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.Common
{
    public static class StringHandler
    {
        // Extension method must reside in a static class
        // Method itself must be static (will be if step one)
        // need this keyword as parameter. using this makes parameter no longer
        // considered passed to the method. it represents the type being extended. 
        public static string InsertSpaces(this string source)
        {
            string result = string.Empty;

            if (!String.IsNullOrWhiteSpace(source))
            {
                foreach (char letter in source)
                {
                    if (char.IsUpper(letter))
                    {
                        result = result.Trim();
                        result += " ";
                    }
                    result += letter;
                }

                result = result.Trim();
            }
            return result;
        }
    }
}
