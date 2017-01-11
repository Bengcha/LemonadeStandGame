using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace LemonadeStand
{
    class Day
    {
        Random dayRandom = new Random();
        double cashMakeFromSale;
        bool isRaining;
        int numberOfTimePeriods;
        
        public Day()
        {
            numberOfTimePeriods = 30;
        }

        public void StartDay(Inventory inventory, Player player, Game game, Weather weather)
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("!!~~~~Lemonade Bussiness in Progress~~~!!");
            Console.ResetColor();
            Console.ReadKey();
            bool businessIsInProcess = true;
            bool pitcherIsEmpty = false;
            bool CupIsOut = false;
            int timePeriod = 1;
            Pitcher pitcher = new Pitcher(player);
            cashMakeFromSale = 0;
            if (dayRandom.Next(0, 100) <= weather.GetRain())
            {
                isRaining = true;
                Console.WriteLine("It is raining.");
            }
            else
            {
                isRaining = false;
            }
            if (CheckRecipe(inventory, player) || inventory.RetrieveCup() >= 1)
            {
                pitcher.FillPitcher(inventory, player);
            }
            else
            {
                Console.WriteLine("You don't have any cup to hold your lemonade!");
                pitcherIsEmpty = true;
                businessIsInProcess = false;
            }
            while (timePeriod <= numberOfTimePeriods && businessIsInProcess)
            {
                if (pitcher.GetFull() < 10 || inventory.RetrieveCup() < 1)
                {
                    if (CheckRecipe(inventory, player))
                    {
                        pitcher.FillPitcher(inventory, player);
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("You run out of Lemonade!, you can't sell any more");
                        pitcherIsEmpty = true;
                        businessIsInProcess = false;
                    }
                }
                if (inventory.RetrieveCup() <= 0)
                {
                    CupIsOut = true;
                    Console.WriteLine("Oops! seem like you run out of cups. No more business for today.");
                    businessIsInProcess = false;
                }
                if (!pitcherIsEmpty && !CupIsOut)
                {
                    DisplayTime(timePeriod);
                    if (dayRandom.Next(0, 100) <= weather.GetRain())
                    {
                        isRaining = true;
                        Console.WriteLine("Its Raining");
                    }
                    else
                    {
                        if (isRaining)
                        {
                            Console.WriteLine("The rain have stop!");
                        }
                        isRaining = false;
                    }
                    CheckForCustomer(player, pitcher, inventory, weather);

                }
                timePeriod++;


            }
            Console.WriteLine("Day {0} is OVER.", game.GetCurrentDay());
            Console.WriteLine("You spent ${0} on supplies today.", player.GetMoneySpentToday());
            Console.WriteLine("You make ${0} back from your sales today", cashMakeFromSale);
            if (cashMakeFromSale - player.GetMoneySpentToday() >= 0)
            {
                Console.WriteLine("Your profit today was {0}.", cashMakeFromSale - player.GetMoneySpentToday());
            }
            else
            {
                Console.WriteLine("Your loss today was {0}.", cashMakeFromSale - player.GetMoneySpentToday());
            }
        }

        public bool CheckRecipe(Inventory inventory, Player player)
        {
            if (CheckLemons(inventory, player) && CheckSugar(inventory, player) && CheckIce(inventory, player))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool CheckLemons(Inventory inventory, Player player)
        {
            if (player.recipe["lemons"] <= inventory.lemonStorage.Count())
            {
                return true;
            }
            else
            {
                Console.WriteLine("You don't have enough lemons to make a pitcher!");
                return false;
            }
        }
        public bool CheckSugar(Inventory inventory, Player player)
        {
            if (player.recipe["sugar"] <= inventory.sugarStorage.Count())
            {
                return true;
            }
            else
            {
                Console.WriteLine("You don't have enough sugar to make a pitcher!");
                return false;
            }
        }
        public bool CheckIce(Inventory inventory, Player player)
        {
            if (player.recipe["ice"] <= inventory.iceStorage.Count())
            {
                return true;
            }
            else
            {
                Console.WriteLine("You don't have enough ice to make a pitcher!");
                return false;
            }
        }


        public void CheckForCustomer(Player player, Pitcher pitcher, Inventory inventory, Weather weather)
        {
            int chance = dayRandom.Next(0, 100);
            if (chance <= 90 && !isRaining)
            {
                Customer customer = new Customer();
                customer.Randomize();
                if (customer.WillBuy(player, weather, pitcher))
                {
                    BuyCup(player, pitcher, inventory);
                    if (customer.DetermineIfCustomerWillBuyAgain(pitcher))
                    {
                        BuyCup(player, pitcher, inventory);
                    }
                }
            }
            else
            {
                Console.WriteLine("*No customer bought your lemonade*\n");
            }
        }
        public void BuyCup(Player player, Pitcher pitcher, Inventory inventory)
        {
            player.cash += player.GetPrice();
            pitcher.AdjustFull(-10);
            inventory.RemoveCup();
            cashMakeFromSale += player.GetPrice();
            Console.WriteLine("You made ${0} and your amount of lemonade cup left is {1}.", player.GetPrice(), pitcher.GetFull());
        }
        public void DisplayTime(int timePeriod)
        {
            int hour = 8 + timePeriod / 4;
            int minutes = (timePeriod - ((hour - 8) * 4)) * 15;
            string time;
            if (hour < 12)
            {
                time = "AM";
            }
            else
            {
                time = "PM";
            }
            if (hour > 12)
            {
                hour = hour - 12;
            }
            if (minutes == 0)
            {
                Console.WriteLine("Current time: {0}:00 {1}\n", hour, time);
            }
            else
            {
                Console.WriteLine("Current time: {0}:{1} {2}", hour, minutes, time);
            }
        }
        public void EndDay(Game game, Player player, Inventory inventory)
        {
            inventory.MeltIce();
            game.ChangeDay(player);
        }
    }
}

