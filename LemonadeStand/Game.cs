using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Game
    {
        Player player;
        Inventory inventory = new Inventory();
        Money money = new Money();
        Store store = new Store();

        public void StartGame()
        {
            DisplayWelcome();
            DisplayRule();
            GetPlayerName();
            DisplaySupplyPrice();
            BuySupplies();
            

        }

        public void DisplayWelcome()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Welcome to the Lemonade Stand Game \n");
            Console.ResetColor();

        }

        public void DisplayRule()
        {
            Console.WriteLine("\nWould you like to see the rules? Yes | No \n");
            string choice = Console.ReadLine().ToLower();
            switch (choice)
            {
                case "yes":
                    Rules rule = new Rules();
                    rule.GameRules();
                    break;
                case "no":
                    Console.WriteLine("\nOkay lets move forward. \n");
                    break;
                default:
                    Console.WriteLine("Please answer yes or no.");
                    DisplayRule();
                    break;
            }
        }
        public void GetPlayerName()
        {
            player = new Player();
            player.ChooseName();
            Console.WriteLine("\nNice to meet you {0}, my name is Kim and I'll guide you through the begining process of how to run your business \n", player.name);
            Console.WriteLine("press enter to continue...\n");
            Console.ReadLine();
        }
        public void DisplaySupplyPrice()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("The Supplies and Price");
            Console.ResetColor();
            Console.WriteLine("You will need 1 bottle of water, 4 lemon, 2 bag of sugar, and 8 ice cube to make one pitcher that hold 5 cups of Lemonade ");
            Console.WriteLine("The cost of each item: Water bottle: $0.15 each, Lemon: $0.20 each, Cup: $0.05 each, Sugar: $.10 each, Ice: $0.05 each \n");
            Console.WriteLine("press enter to continue...\n");
            Console.ReadLine();
        }
        public void BuySupplies()
        {
            BuyWater();
            BuyLemon();
            BuyCup();
            BuyIce();
            BuySugar();
            inventory.CurrentSupplies();
            BuyMoreSupplies();
        }

        public double BuyWater()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("How many water bottle do you want to buy? \n");
            Console.ResetColor();
            try
            {
                double item = Convert.ToDouble(Console.ReadLine());
                if (money.CurrentCash > store.PriceOfWater * item)
                {
                    Console.WriteLine("You now have {0} water bottle \n", item);
                    money.CurrentCash = money.CurrentCash - (store.PriceOfWater * item);
                    inventory.currentWaterLeft += (store.numberOfWater * item);
                    Console.WriteLine("Your balance is now : {0} \n", money.CurrentCash);

                }
                else if (money.CurrentCash < store.PriceOfWater * item)
                {
                    Console.WriteLine("Sorry {0} you don't have enough cash to buy that amount\n", player.name);
                    BuyWater();
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("You enter a invalid amount");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Please use Number ONLY!");
                Console.ResetColor();
                BuyWater();
            }

            return money.CurrentCash;
        }

        public double BuyLemon()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("How many lemon do you want to buy? \n");
            Console.ResetColor();
            try
            {
                double item = Convert.ToDouble(Console.ReadLine());
           
                if (money.CurrentCash > store.PriceOfLemon * item)
                {
                    Console.WriteLine("You now have {0} of lemon \n", item);
                    money.CurrentCash = money.CurrentCash - (store.PriceOfLemon * item);
                    inventory.currentLemonLeft += (store.numberOfLemon * item);
                    Console.WriteLine("Your balance is now : {0}\n", money.CurrentCash);

                }
                else if (money.CurrentCash < store.PriceOfLemon * item)
                {
                    Console.WriteLine("Sorry {0} you don't have enough cash to buy that amount", player.name);
                    BuyLemon();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("You enter a invalid amount");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Please use Number ONLY!");
                Console.ResetColor();
                BuyLemon();
            }
            return money.CurrentCash;

        }
        public double BuyCup()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("How many cup do you want to buy? \n");
            Console.ResetColor();
            try
            {
                double item = Convert.ToDouble(Console.ReadLine());
                if (money.CurrentCash > store.PriceOfCup * item)
                {
                    Console.WriteLine("You now have {0} of cup \n", item);
                    money.CurrentCash = money.CurrentCash - (store.PriceOfCup * item);
                    inventory.currentCupLeft += (store.numberOfCup * item);
                    Console.WriteLine("Your balance is now : {0} \n", money.CurrentCash);

                }
                else if (money.CurrentCash < store.PriceOfCup * item)
                {
                    Console.WriteLine("Sorry {0} you don't have enough cash to buy that amount", player.name);
                    BuyCup();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("You enter a invalid amount");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Please use Number ONLY!");
                Console.ResetColor();
                BuyCup();
            }
            return money.CurrentCash;

        }
        public double BuyIce()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("How many ice cubes do you want to buy? \n");
            Console.ResetColor();
            try
            {
                double item = Convert.ToDouble(Console.ReadLine());

                if (money.CurrentCash > store.PriceOfIce * item)
                {
                    Console.WriteLine("You now have {0} of ice \n", item);
                    money.CurrentCash = money.CurrentCash - (store.PriceOfIce * item);
                    inventory.currentIceLeft += (store.numberOfIce * item);
                    Console.WriteLine("Your balance is now : {0} \n", money.CurrentCash);

                }
                else if (money.CurrentCash < store.PriceOfIce * item)
                {
                    Console.WriteLine("Sorry {0} you don't have enough cash to buy that amount", player.name);
                    BuyIce();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("You enter a invalid amount");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Please use Number ONLY!");
                Console.ResetColor();
                BuyIce();
            }
            return money.CurrentCash;

        }
        public double BuySugar()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("How many bags of sugar do you want to buy? \n");
            Console.ResetColor();
            try
            {
                double item = Convert.ToDouble(Console.ReadLine());
                if (money.CurrentCash > store.PriceOfSugar * item)
                {
                    Console.WriteLine("You now have {0} bag of sugar \n", item);
                    money.CurrentCash = money.CurrentCash - (store.PriceOfSugar * item);
                    inventory.currentSugarLeft += (store.numberOfSugar * item);
                    Console.WriteLine("Your balance is now : {0} \n", money.CurrentCash);

                }
                else if (money.CurrentCash < store.PriceOfSugar * item)
                {
                    Console.WriteLine("Sorry {0} you don't have enough cash to buy that amount", player.name);
                    BuySugar();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("You enter a invalid amount");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Please use Number ONLY!");
                Console.ResetColor();
                BuySugar();
            }
            return money.CurrentCash;

        }

        public void BuyMoreSupplies()
        {
            bool buymore = true;
            while (buymore)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Do you want to rebuy more supplies? Yes | No \n");
                Console.ResetColor();
                string more = Console.ReadLine().ToLower(); 


                if (more == "yes")
                {
                    buymore = true;
                    Console.WriteLine("Choose one: Water, Lemon, Ice, Cup, Sugar? \n");
                    string pick = Console.ReadLine().ToLower(); ;
                    if (pick == "water")
                    {
                        BuyWater();
                    }
                    else if (pick == "lemon")
                    {
                        BuyLemon();
                    }
                    else if (pick == "ice")
                    {
                        BuyIce();
                    }
                    else if (pick == "cup")
                    {
                        BuyCup();
                    }
                    else if (pick == "sugar")
                    {
                        BuySugar();
                    }

                }
                else if (more == "no")
                {
                    Console.WriteLine("\nEnjoy your first day of business!");
                    Console.ReadLine();
                    buymore = false;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("You enter a incorrect choice");
                    Console.ResetColor();
                }
            }
        }

    }
}
    



