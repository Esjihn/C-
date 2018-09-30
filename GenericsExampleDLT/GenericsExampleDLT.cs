using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeDLT
{
    //public class ResultInt
    //{
    //    public bool Success { get; set; }
    //    public int Data { get; set; }
    //}

    //public class ResultString
    //{
    //    public bool Success { get; set; }
    //    public string Data { get; set; }
    //}

    //public class ResultBool
    //{
    //    public bool Success { get; set; }
    //    public bool Data { get; set; }
    //}

    public class Result<T>
    {
        public bool Success { get; set; }
        public T Data { get; set; }
        
    }

    public class ResultPrinter
    {
        public void Print<T>(Result<T> result)
        {
            Console.WriteLine(result.Success);
            Console.WriteLine(result.Data);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
         // call service, data access layer (dal), etc.
            var result = new Result<int> {Success = true, Data = 5};
            var result2 = new Result<string> {Success = false, Data = "John"};
            var result3 = new Result<bool> {Data = true, Success = true};
            var helper = new ResultPrinter();
            helper.Print(result3);

        }
    }
}
