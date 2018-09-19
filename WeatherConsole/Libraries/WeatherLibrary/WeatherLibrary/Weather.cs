using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherLibrary
{
    public class Weather
    {
        string _location;
        double _currentTemperature;
        double _highTemperature;
        double _lowTemperature;
        double _pressure;
        int _humidity;
        double _windSpeed;
        double _windDirection;
        long _dtSeconds;

        public Weather(string location, double currentTemperature, double highTemperature,
            double lowTemperature, double pressure, int humidity, double windSpeed, double windDirection,
            long dtSeconds)
        {
            this._location = location;
            this._currentTemperature = currentTemperature;
            this._highTemperature = highTemperature;
            this._lowTemperature = lowTemperature;
            this._pressure = pressure;
            this._humidity = humidity;
            this._windSpeed = windSpeed;
            this._windDirection = windDirection;
            this._dtSeconds = dtSeconds;
        }

        public string getLocation()
        {
            return _location;
        }

        public double getCurrentTemperatureF()
        {
            return (_currentTemperature - 273.15) * 9 / 5 + 32;
        }

        public double getHighTemperatureF()
        {
            return (_highTemperature - 273.15) * 9 / 5 + 32;
        }

        public double getLowTemperatureF()
        {
            return (_lowTemperature - 273.15) * 9 / 5 + 32;
        }

        public double getPressureInHg()
        {
            return _pressure * 0.02953;
        }

        public int getHumidity()
        {
            return _humidity;
        }

        public double getWindSpeed()
        {
            return _windSpeed * 2.23694;
        }

        public double getWindDirection()
        {
            return _windDirection;
        }

    }
}
