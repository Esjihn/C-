using System;
using System.Runtime.InteropServices;

namespace WeatherDiscussionTest
{
    class Weather
    {
        string _name;
        double _currentTemp;
        double _lowTemp;
        double _highTemp;
        double _baroPressure;
        double _windSpeed;
        double _windDirection;

        public Weather(string name, double currentTemp, double lowTemp,
                       double highTemp, double baroPressure, double windSpeed,
                       double windDirection)
        {
            this._name = name;
            this._currentTemp = currentTemp;
            this._lowTemp = lowTemp;
            this._highTemp = highTemp;
            this._baroPressure = baroPressure;
            this._windSpeed = windSpeed;
            this._windDirection = windDirection;

            Console.WriteLine("Today's Weather Forecast!\n\n");
            Console.WriteLine("Your location: {0}", name);
            Console.WriteLine("Today's estimated Current Temperature: {0}", currentTemp);
            Console.WriteLine("Today's estimated Low Temperature: {0}", lowTemp);
            Console.WriteLine("Today's estimated High Temperature: {0}", highTemp);
            Console.WriteLine("Today's estimated Barometric Pressure: {0}", baroPressure);
            Console.WriteLine("Today's estimated Wind Speed: {0}", windSpeed);
            Console.WriteLine("Today's estimated Wind Direction: {0}\n", windDirection);
        }

        // TODO add Conversion Kelvin to Fahrenheit F = (K * 9/5) - 459.67
        public void ConversionKtoF(double currentTemp, double lowTemp, double highTemp)
        {
            double currentTempF = (int) ((currentTemp * 9 / 5) - 459.67);
            double lowTempF = (int) ((lowTemp * 9 / 5) - 459.67);
            double highTempF = (int) ((highTemp * 9 / 5) - 459.67);

            Console.WriteLine("Conversation Kelvin to Fahrenheit complete: ");
            Console.WriteLine("Current Temp: " + currentTempF + "F. " + "Low Temp: "
                          + lowTempF + "F. " + "High Temp: " + highTempF + "F. \n");
        }

        // TODO add Conversion Kelvin to Celcius C = K - 273.15
        public void ConversionKtoC(double currentTemp, double lowTemp, double highTemp)
        {
            double currentTempC = (int)(currentTemp - 273.15);
            double lowTempC = (int)(lowTemp - 273.15);
            double highTempC = (int)(highTemp - 273.15);

            Console.WriteLine("Conversation Kelvin to Celsius complete.");
            Console.WriteLine("Current Temp: " + currentTempC + "C. " + "Low Temp: " 
                          + lowTempC + "C. " + "High Temp: " + highTempC + "C. ");
        }
    }
}