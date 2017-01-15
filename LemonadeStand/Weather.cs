using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace LemonadeStand
{
    class Weather
    {
        int temperature;
        int cloudPercentage;
        int rainPercentage;
        Random weatherRandom;
        public Weather()
        {
            weatherRandom = new Random();
        }
        public void RandomForecast()
        {
            temperature = 60 + weatherRandom.Next(0, 16) + weatherRandom.Next(0, 16) + weatherRandom.Next(0, 16);
            Thread.Sleep(15);
            cloudPercentage = weatherRandom.Next(0, 101);
            int rainChance = weatherRandom.Next(1, 101);
            if (rainChance < 50)
            {
                rainPercentage = 0;
            }
            else
            {
                rainPercentage = weatherRandom.Next(0, 101);
            }
        }
        public void DisplayTodaysWeather(List<Weather> weatherForecast)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nToday Weather Forecast");
            Console.ResetColor();
            DisplayWeather(weatherForecast[0]);
        }
        public void DisplayWeather(Weather weather)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Temperature: {0}° degree", weather.GetTemperature());
            Console.ResetColor();
            Console.WriteLine("Cloudy: {0}%", weather.GetCloudiness());
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Chance of Rain: {0}%", weather.GetRain());
            Console.ResetColor();
        }

        public int GetTemperature()
        {
            return temperature;
        }
        public int GetCloudiness()
        {
            return cloudPercentage;
        }
        public int GetRain()
        {
            return rainPercentage;
        }
    }
}