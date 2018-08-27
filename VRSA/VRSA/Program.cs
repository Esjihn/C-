using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace VRSA
{
    class Program
    {
        static void Main(string[] args)
        {
            FileCheckConsole();
        }
        static void FileCheckConsole()
        {
            FileCheck fileCheck = new FileCheck();
            fileCheck.CompareTwoFolders();
        }
    }
}

