using System;
using System.IO;

namespace CS_Path
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = @"D:\C#\HelloWorld\HelloWorld.sln";

            var dotIndex = path.IndexOf('.');
            var extension = path.Substring(dotIndex);

            Console.WriteLine("Extension: " + Path.GetExtension(path));
            Console.WriteLine("File Name: " + Path.GetFileName(path));
            Console.WriteLine("File Name without Extension: " + Path.GetFileNameWithoutExtension(path));

            Console.WriteLine("Directory Name: " + Path.GetDirectoryName(path));


        }
    }
}
