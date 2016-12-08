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
        Money money;

        Store store;
        public double firstDay;
        public double lastDay;
        public double numberOfCustomer;


        public Day()
        {
            inventory = new Inventory();
            money = new Money();

            store = new Store();
            firstDay = 0;
            lastDay = 7;


        }

        public double days()
        {
            firstDay += 1;
            return firstDay;
        }

        public double CustomerPerDay(Weather weather, Player player, Money money, Inventory inventory)
        { 
            Random theCustomer = new Random();
            numberOfCustomer = theCustomer.Next(1, 50);
        
            if (weather.theWeather == 1 && weather.temperature <= 30 && money.PricePerLemonade <= 0.25 && inventory.numberOfFullLemonadeCup > 0)
            {
                inventory.numberOfFullLemonadeCup = inventory.numberOfFullLemonadeCup -= numberOfCustomer;
            }
            else if (weather.theWeather == 1 && weather.temperature > 30 && money.PricePerLemonade <= 0.20 && inventory.numberOfFullLemonadeCup > 0)
            {

                inventory.numberOfFullLemonadeCup = inventory.numberOfFullLemonadeCup -= numberOfCustomer;
            }

            else if (weather.theWeather == 2 && weather.temperature <= 80 && money.PricePerLemonade <= 0.50 && inventory.numberOfFullLemonadeCup > 0)
            {

                inventory.numberOfFullLemonadeCup = inventory.numberOfFullLemonadeCup -= numberOfCustomer;
            }
            else if (weather.theWeather == 2 && weather.temperature > 80 && money.PricePerLemonade <= 0.75 && inventory.numberOfFullLemonadeCup > 0)
            {

                inventory.numberOfFullLemonadeCup = inventory.numberOfFullLemonadeCup -= numberOfCustomer;
            }

            else if (weather.theWeather == 3 && weather.temperature <= 15 && money.PricePerLemonade <= 0.15 && inventory.numberOfFullLemonadeCup > 0)
            {
                inventory.numberOfFullLemonadeCup = inventory.numberOfFullLemonadeCup -= numberOfCustomer;

            }
            else if (weather.theWeather == 3 && weather.temperature > 15 && money.PricePerLemonade <= 0.20 && inventory.numberOfFullLemonadeCup > 0)
            {
                inventory.numberOfFullLemonadeCup = inventory.numberOfFullLemonadeCup -= numberOfCustomer;

            }

            Console.WriteLine("Today there are {0} customers and your amount of lemonade sold was : {1}", numberOfCustomer, inventory.numberOfFullLemonadeCup);
            money.CurrentRevenue = money.PricePerLemonade - (store.PriceOfWater + store.PriceOfLemon + store.PriceOfLemon + store.PriceOfIce + store.PriceOfCup);
            Console.WriteLine("Your total revenue today is : ${0}", money.CurrentRevenue);
            Console.ReadLine();
            return numberOfCustomer;

        }


    }
}
