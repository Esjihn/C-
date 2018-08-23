using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherDiscussionTest
{
    class Program
    {
        
        static void Main(string[] args)
        {
            WeatherConsole();
        }

        static void WeatherConsole()
        {
            Console.WriteLine("\tPlease enter your local Weather in the following format. \n");

            Console.Write("Please enter your city: ");
            string name = Console.ReadLine();
            Console.WriteLine();

            Console.Write("Please enter your Current Temperature in Kelvin: ");
            double currentTemp = Double.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
            Console.WriteLine();

            Console.Write("Please enter your Lowest Temperature in Kelvin: ");
            double lowTemp = Double.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
            Console.WriteLine();

            Console.Write("Please enter your Highest Temperature in Kelvin: ");
            double highTemp = Double.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
            Console.WriteLine();

            Console.Write("Please enter the estimated Barometric Pressure: ");
            double baroPressure = Double.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
            Console.WriteLine();

            Console.Write("Please enter the estimated Wind Speed: ");
            double windSpeed = Double.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
            Console.WriteLine();

            Console.Write("Please enter the estimated Wind Direction: ");
            double windDirection = Double.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
            Console.WriteLine();

            Weather w1 = new Weather(name, currentTemp, lowTemp, highTemp, baroPressure,
                                     windSpeed, windDirection);

            
            w1.ConversionKtoC(currentTemp, lowTemp, highTemp);

            w1.ConversionKtoF(currentTemp, lowTemp, highTemp);
        }
    }
}
