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
        int cloudiness;
        int rainLevel;
        Random weatherRandom = new Random();
        public void RandomForecast()
        {
            //Thread.Sleep(15);
            temperature = 60 + weatherRandom.Next(0, 16) + weatherRandom.Next(0, 16) + weatherRandom.Next(0, 16);
            Thread.Sleep(15);
            cloudiness = weatherRandom.Next(0, 101);
            //Thread.Sleep(15);
            int rainChance = weatherRandom.Next(1, 101);
            if (rainChance < 50)
            {
                rainLevel = 0;
            }
            else
            {
                //Thread.Sleep(15);
                rainLevel = weatherRandom.Next(0, 101);
            }
        }
        public void DisplayTodaysWeather(List<Weather> weatherForecast)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\nToday Weather Forecast");
            Console.ResetColor();
            DisplayWeather(weatherForecast[0]);
        }
        //public void WeatherReport(List<Weather> weatherForecast)
        //{
        //    for (int i = 0; i < 7; i++)
        //    {
        //        Console.WriteLine("\nDay {0}'s weather:", i + 1);
        //        DisplayWeather(weatherForecast[i]);
        //    }


        //}
        public void DisplayWeather(Weather weather)
        {
            Console.WriteLine("Temperature: {0}° degree", weather.GetTemperature());
            Console.WriteLine("Cloudy: {0}%", weather.GetCloudiness());
            Console.WriteLine("Chance of Rain: {0}%", weather.GetRain());
        }

        public int GetTemperature()
        {
            return temperature;
        }
        public int GetCloudiness()
        {
            return cloudiness;
        }
        public int GetRain()
        {
            return rainLevel;
        }
    }
}