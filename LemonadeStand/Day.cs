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
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("!!~~~~Lemonade Bussiness in Progress~~~!!\n");
            Console.ResetColor();
            Console.ReadKey();
            bool businessIsInProcess = true;
            bool pitcherIsEmpty = false;
            bool CupIsOut = false;
            int timePeriod = 1;
            Pitcher pitcher = new Pitcher(player);
            cashMakeFromSale = 0;
            if (CheckRecipe(inventory, player) == true)
            {
                pitcher.Fill(inventory, player);
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

                    Console.WriteLine("You ran out of Lemonade juice!");
                    Console.WriteLine("Do you want to check if you have enough supplies to make another pitcher?");
                    string makeAnotherPitcher = Console.ReadLine().ToLower();
                    if (makeAnotherPitcher == "yes" || makeAnotherPitcher == "y")
                    {
                        if (CheckRecipe(inventory, player) && businessIsInProcess == true)
                        {
                            pitcher.Fill(inventory, player);
                        }
                        else
                        {
                            Console.WriteLine("\nSorry but you don't have enough supplies to make another Pitcher");
                        }
                    }
                    else if (makeAnotherPitcher == "no" || makeAnotherPitcher == "n")
                    {
                        Console.WriteLine("\n****Today Result****");
                        Console.WriteLine("press any key to see today result");
                        Console.ReadKey();
                        break;
                    }
                    else
                    {
                        try
                        {
                            if (makeAnotherPitcher.Equals(""))
                            {
                                Console.WriteLine("Please choose a valid option");
                            }
                        }
                        catch
                        {
                            Console.WriteLine("Please choose a valid option");
                        }
                    }
                }
                if (inventory.RetrieveCup() <= 0)
                {
                    CupIsOut = true;
                    Console.WriteLine("\nOops! seem like you run out of cups. No more business for today.");
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
                    Console.ResetColor();
                    Console.WriteLine("\n~~~*Checking inventory for more cups*~~~");
                    Console.WriteLine("press any key to see if you have more cup\n");
                    Console.ReadKey();
                }

                timePeriod++;
            }
            EndDayResult(game, player);
        }
        public void EndDayResult(Game game, Player player)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nDay {0} is OVER. \n", game.GetCurrentDay());
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("You spent ${0} on supplies today.", player.GetMoneySpentToday());
            Console.WriteLine("You make ${0} back from your sales today", cashMakeFromSale);
            Console.ResetColor();
            if (cashMakeFromSale - player.GetMoneySpentToday() > 0)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Congrats! You did good today. Your profit today was ${0}.", cashMakeFromSale - player.GetMoneySpentToday());
                Console.ResetColor(); 
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Your loss today is ${0}.", cashMakeFromSale - player.GetMoneySpentToday());
                Console.ResetColor();
                Console.ResetColor();
            }
        }
        public bool CheckRecipe(Inventory inventory, Player player)
        {
            if (CheckLemonInventory(inventory, player) && CheckSugarInventory(inventory, player) && CheckIceInventory(inventory, player) && CheckCupInventory(inventory, player))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool CheckLemonInventory(Inventory inventory, Player player)
        {
            if (player.recipe["lemons"] <= inventory.lemonStorage.Count())
            {
                return true;
            }
            else
            {
                Console.WriteLine("You need to buy more lemon!");
                return false;           
            }
        }
        public bool CheckSugarInventory(Inventory inventory, Player player)
        {
            if (player.recipe["sugar"] <= inventory.sugarStorage.Count())
            {
                return true;
            }
            else
            {
                Console.WriteLine("You need to buy more sugar!");
                return false;
            }
        }
        public bool CheckIceInventory(Inventory inventory, Player player)
        {
            if (player.recipe["ice"] <= inventory.iceStorage.Count())
            {
                return true;
            }
            else
            {
                Console.WriteLine("You need to buy more ice!");
                return false;
            }
        }
        public bool CheckCupInventory(Inventory inventory, Player player)
        {
            if (player.recipe["cups"] <= inventory.cupStorage.Count() == true)
            {
                return true;
            }
            else
            {
                Console.WriteLine("\nThere no more cup left so you can't sell any more lemonade");
                return false;
            }
        }
        public void CheckForCustomer(Player player, Pitcher pitcher, Inventory inventory, Weather weather)
        {
            int chance = dayRandom.Next(0, 100);
            if (chance <= 80 && !isRaining)
            {
                Customer customer = new Customer();
                customer.Randomize();
                if (customer.WillPurchase(player, weather, pitcher))
                {
                    BuyCup(player, pitcher, inventory);
                    if (customer.CheckingCustomerBuyingStatus(pitcher))
                    {
                        BuyCup(player, pitcher, inventory);
                    }
                    else
                    {
                        Console.WriteLine("No customer walk by...");
                    }
                }
            }
            else
            {
                Console.WriteLine("*The rain is pouring hard so no customer stop to buy any lemonade!*\n");
            }
        }
        public void BuyCup(Player player, Pitcher pitcher, Inventory inventory)
        {
            player.cash += player.GetPrice();
            pitcher.AdjustFull(-10);
            inventory.RemoveCup();
            cashMakeFromSale += player.GetPrice();
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("Yay! A customer just bought a cup of lemonade");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Yellow;
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
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Current time: {0}:00 {1}\n", hour, time);
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
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
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Oh no! All Your ice have melted away!.");
                inventory.ResetIce();
                Console.ResetColor();
            }
            else
            {
                Console.WriteLine("Remember to buy ice for your next day of business");
            }
        }
    }
}

