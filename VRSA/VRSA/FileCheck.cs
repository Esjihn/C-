using System;
using System.Collections.Generic;
using System.Linq;

namespace VRSA
{

    public class FileCheck
    {
        // 2 directories for comparison
        private string _pathA = @"C:\Compare1";
        private string _pathB = @"C:\Compare2";

        public FileCheck()
        {
        }

        public FileCheck(string pathA, string pathB)
        {
            this._pathA = pathA;
            this._pathB = pathB;
        }

        public void CompareTwoFolders()
        {
            System.IO.DirectoryInfo dir1 = new System.IO.DirectoryInfo(_pathA);
            System.IO.DirectoryInfo dir2 = new System.IO.DirectoryInfo(_pathB);

            // Interface to take snapshot of files
            IEnumerable<System.IO.FileInfo> list1 = dir1.GetFiles("*.*", System.IO.SearchOption.AllDirectories);
            IEnumerable<System.IO.FileInfo> list2 = dir2.GetFiles("*.*", System.IO.SearchOption.AllDirectories);

            FileCompare myFileCompare = new FileCompare();

            // determines whether the two folders contain identical file list based on
            // custom file comparer class below
            bool areIdentical = list1.SequenceEqual(list2, myFileCompare);

            if (areIdentical == true)
            {
                Console.WriteLine("the two folders are the same");
            }
            else
            {
                Console.WriteLine("The two folders are not the same");
            }

            // Find the common files. It produces a sequnece a sequence and doesn't execute 
            // until the foreach statement.

            var queryCommonFiles = list1.Intersect(list2, myFileCompare);

            var commonFiles = queryCommonFiles.ToList();
            if (commonFiles.Any())
            {
                Console.WriteLine("The following files are in both folders:");
                foreach (var v in commonFiles)
                {
                    Console.WriteLine(v.FullName); //shows which items end up in result list  
                }
            }
            else
            {
                Console.WriteLine("There are no common files in the two folders.");
            }

            // Find the set difference between the two folders.  
            // For this example we only check one way.  
            var queryList1Only = (from file in list1
                select file).Except(list2, myFileCompare);

            Console.WriteLine("The following files are in list1 but not list2:");
            foreach (var v in queryList1Only)
            {
                Console.WriteLine(v.FullName);
            }

            // Keep the console window open in debug mode.  
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }

        // This implementation defines a very simple comparison  
        // between two FileInfo objects. It only compares the name  
        // of the files being compared and their length in bytes.  
        class FileCompare : System.Collections.Generic.IEqualityComparer<System.IO.FileInfo>
        {
            public FileCompare()
            {
            }

            public bool Equals(System.IO.FileInfo f1, System.IO.FileInfo f2)
            {
                return f2 != null && (f1 != null && (f1.Name == f2.Name &&
                                                     f1.Length == f2.Length));
            }

            // Return a hash that reflects the comparison criteria. According to the   
            // rules for IEqualityComparer<T>, if Equals is true, then the hash codes must  
            // also be equal. Because equality as defined here is a simple value equality, not  
            // reference identity, it is possible that two or more objects will produce the same  
            // hash code.  
            public int GetHashCode(System.IO.FileInfo fi)
            {
                string s = String.Format("{0}{1}", fi.Name, fi.Length);
                return s.GetHashCode();
            }
        }
    }
}


