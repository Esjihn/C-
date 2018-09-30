using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    public class Sample
    {
        public string Names { get; set; }
        public int Age;

        public void MyMethod()
        {

        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var assembly = Assembly.GetExecutingAssembly();
            Console.WriteLine(assembly.FullName);

            var types = assembly.GetTypes();
            foreach (var type in types)
            {
                Console.WriteLine("Type: {0}, {1}", type.Name, type.BaseType);
                var props = type.GetProperties();
                foreach (var prop in props)
                {
                    Console.WriteLine("\tProperty: {0}. PropertyType: {1}",
                        prop.Name, prop.PropertyType);
                }

                var fields = type.GetFields();
                foreach (var field in fields)
                {
                    Console.WriteLine("\tField: {0}", field.Name);
                }

                var methods = type.GetMethods();
                foreach (var method in methods)
                {
                    Console.WriteLine("\tMethod: {0}", method.Name);
                }
            }

            var sample = new Sample{Names = "John", Age = 25};
           
            var sampleType = typeof(Sample);

            var nameProperty = sampleType.GetProperty("Names");
            Console.WriteLine("Property: {0}", nameProperty.GetValue(sample));


        }
    }
}
