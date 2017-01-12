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
            if (CheckRecipe(inventory, player) == true)
            {
                pitcher.FillPitcher(inventory, player);
            }
            else
            {
                Console.WriteLine("You're missing some supplies!");
                Console.WriteLine("Please double check your inventory and recipe");
                pitcherIsEmpty = true;
                businessIsInProcess = false;
            }
            while (timePeriod <= numberOfTimePeriods && businessIsInProcess)
            {
                if (pitcher.GetFull() <= 10)
                {
                    if (CheckRecipe(inventory, player) == true)
                    {
                        pitcher.FillPitcher(inventory, player);
                        Console.ReadKey();
                    }
                    else
                    {
                        pitcherIsEmpty = true;
                        businessIsInProcess = false;
                        Console.WriteLine("You run out of Lemonade!, you can't sell any more");
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
                    try
                    {
                        if (inventory.cupStorage.Count() >= 1)
                        {
                            CheckForCustomer(player, pitcher, inventory, weather);
                        }
                    }
                    catch
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nThat was the last lemonade cup on the table!");
                        Console.WriteLine("~~~*Checking inventory for more cups*~~~");
                        Console.WriteLine("press any key to see if you have more cup\n");
                        Console.ResetColor();
                        Console.ReadKey();
                    }
                    
                
                
                
            
        

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
            if (CheckLemons(inventory, player) && CheckSugar(inventory, player) && CheckIce(inventory, player) && CheckCup(inventory, player))
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
        public bool CheckCup(Inventory inventory, Player player)
        {
            if (player.recipe["cups"] <= inventory.cupStorage.Count() == true)
            {
                return true;
            }
            else
            {
                Console.WriteLine("You don't have anymore cup to hold the lemonade!");
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
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Yay! A customer just bought a cup of lemonade");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("You made ${0} and your pitcher of lemonade is {1}% left.\n", player.GetPrice(), pitcher.GetFull());
            Console.ResetColor();
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
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("Current time: {0}:00 {1}\n", hour, time);
            }
            else
            {
                Console.WriteLine("Current time: {0}:{1} {2} \n", hour, minutes, time);
                Console.ResetColor();
            }
        }
        public void EndDay(Game game, Player player, Inventory inventory)
        {
            IceMelted(inventory);
            game.ChangeDay(player);
        }

        public void IceMelted(Inventory inventory)
        {
            if (inventory.iceStorage.Count() >= 1)
            {
                Console.WriteLine("Oh no! All Your ice have melted away!.");
                inventory.ResetIce();
            }
            else
            {
                Console.WriteLine("Remember to buy ice for your next day of business");
            }
        }
    }
}

