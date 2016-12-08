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
        public Weather()
        {
        }


        public string randomWeatherWithTemperature()
        {
            theWeather = ChooseWeather.Next(1, 4);

            if (theWeather == 1)
            {
                weatherType = "Rainy";
                temperature = ChooseWeather.Next(20, 50);
                DisplayWeatherAndTemperature();
                Console.WriteLine("Rain, rain go away! Raining day can cause a great impact on your sales so becareful and don't over make your lemonade. \n");       
            }
            else if (theWeather == 2)
            {
                weatherType = "Sunny";
                temperature = ChooseWeather.Next(70, 110);
                DisplayWeatherAndTemperature();
                Console.WriteLine("HOT HOT!, Hot day is the perfect day to sell lemonade. Make sure to make plenty of lemonade but be careful of your pricing.\n");
            }
 
            else if (theWeather == 3)
            {
                weatherType = "Cold";
                temperature = ChooseWeather.Next(1, 30);
                DisplayWeatherAndTemperature();
                Console.WriteLine("AaaaaChoo! Wow its almost freezing outside! It's the worst day to sell your lemonade but maybe you will have a chance if your adjust your pricing right.\n");
            }
            return weatherType + temperature;
        }
        public void DisplayWeatherAndTemperature()
        { 
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("The Weather today will be {0}, and the temperature will be {1} degree", weatherType, temperature);
            Console.ResetColor();
            
        }
    }
}