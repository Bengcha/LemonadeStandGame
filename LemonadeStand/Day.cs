using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Day
    {
        Inventory inventory;
        public double numberOfCustomer;
        Weather weather;
        public double firstDay;
        public double sevenDay;


        public Day()
        {
            firstDay = 0;
            sevenDay = 7;
            inventory = new Inventory();
            weather = new Weather();
            numberOfCustomer = 0;

        }

        public double days()
        {
            firstDay += 1;
            return firstDay;   
        }

        public double CustomerPerDay(double numberOfCustomerPerWeather)
        {
            if (weather.theWeather == 1)
            {
                numberOfCustomer = 5;
            }
            else if (weather.theWeather == 2)
            {
                numberOfCustomer = 10;
            }
            else if (weather.theWeather == 3)
            {
                numberOfCustomer = 6;
            }
            else if (weather.theWeather == 4)
            {
                numberOfCustomer = 7;
            }
            else if (weather.theWeather == 5)
            {
                numberOfCustomer = 2;
            }
            return numberOfCustomer;
        }


    }
}