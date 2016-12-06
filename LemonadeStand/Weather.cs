using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Weather
    {

        public double temperature;
        public string weatherType;
        public double theWeather;
        Random ChooseWeather = new Random();


        public string WeatherForecast()
        {
            theWeather = ChooseWeather.Next(1, 6);

            if ( theWeather == 1)
            {
                weatherType = "Rainy";
            }
            else if (theWeather  == 2)
            {
                weatherType = "Sunny";
            }
            else if ( theWeather == 3)
            {
                weatherType = "cloudy";
            }
            else if ( theWeather == 4)
            {
                weatherType = "Windy";
            }
            else if ( theWeather == 5)
            {
                weatherType = "Cold";
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(" The forecast weather today will be {0}", weatherType);
            Console.ResetColor();
            return weatherType;
        }
        public double RndTemperature()
        {
            temperature = ChooseWeather.Next(1, 110);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("The temperature for today forecast will be {0}", temperature);
            Console.ResetColor();
            return temperature;
           
        }
    }
}