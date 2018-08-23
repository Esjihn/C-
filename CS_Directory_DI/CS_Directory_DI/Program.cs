using System;
using System.IO;

namespace CS_Directory_DI
{
    class Program
    {
        static void Main(string[] args)
        {
            Directory.CreateDirectory(@"d:\temp\folder1");

//            var files = Directory.GetFiles(@"d:\C#\CS_Directory_DI", "*.sln",
//                SearchOption.AllDirectories);
//
//            foreach (var file in files)
//                Console.WriteLine(file);

            var directories = Directory.GetDirectories(@"d:\C#\CS_Directory_DI", "*.*",
                SearchOption.AllDirectories);
            foreach (var directory in directories)
                Console.WriteLine(directory);

            Directory.Exists("...");

            var directoryInfo = new DirectoryInfo("...");
            directoryInfo.GetFiles();
            directoryInfo.GetDirectories();

        }
    }
}
