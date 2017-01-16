using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Store
    {
        Dictionary<string, double> price;
        bool buy;
        public Store()
        {
            price = new Dictionary<string, double>();
            price.Add("lemons", .20);
            price.Add("sugar", .15);
            price.Add("cups", .05);
            price.Add("ice", .10);          
        }
        public bool Buy { get; set;}
        public void Purchase(Dictionary<string, int> storeInventory, Player player, Inventory inventory)
        {
            DisplayPrices();
            player.DisplayCash();
            GetBuyChoice(storeInventory, player, inventory);
        }
        public void DisplayPrices()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("***BLM FOOD MARKET***\n");
            Console.ResetColor();
            Console.WriteLine("PRICE INFORMATION");
            foreach (KeyValuePair<string, double> supply in price)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("{0}: ${1} | ", supply.Key, supply.Value);
                Console.ResetColor();
            }
        }
        public void GetBuyChoice(Dictionary<string, int> storeInventory, Player player, Inventory inventory)
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("What would you like to buy?");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("[1] Lemon [2] Sugar [3] Cups [4] Ice [5] Exit");
            Console.ResetColor();
            string choice = Console.ReadLine().ToLower();
            buy = false;
            switch (choice)
            {
                case "1":
                    BuySupplies(player, storeInventory, "lemons", inventory);
                    GetBuyChoice(storeInventory, player, inventory);
                    break;
                case "2":
                    BuySupplies(player, storeInventory, "sugar", inventory);
                    GetBuyChoice(storeInventory, player, inventory);
                    break;
                case "3":
                    BuySupplies(player, storeInventory, "cups", inventory);
                    GetBuyChoice(storeInventory, player, inventory);
                    break;
                case "4":
                    BuySupplies(player, storeInventory, "ice", inventory);
                    GetBuyChoice(storeInventory, player, inventory);
                    break;
                case "5":
                    Console.Write("press enter to continue...");
                    break;
                default:
                    GetBuyChoice(storeInventory, player, inventory);
                    break;                  
            }
        }
        public void BuySupplies(Player player, Dictionary<string, int> storeInventory, string item, Inventory inventory)
        {
            int converted;
            AmountToBuy(item);
            string number = Console.ReadLine();
            bool result = Int32.TryParse(number, out converted);
            if (result)
            {
                if (converted > 0)
                {
                    double cost = (price[item] * converted);
                    if (cost <= player.cash)
                    {
                        DisplaySupplyBought(item, converted);
                        player.AdjustCash(cost * -1);
                        player.AdjustMoneySpentToday(cost);
                        player.AdjustTotalMoneySpent(cost);
                        switch (item)
                        {
                            case "lemons":
                                inventory.AddLemons(converted);
                                break;
                            case "ice":
                                inventory.AddIces(converted);
                                break;
                            case "sugar":
                                inventory.AddSugars(converted);
                                break;
                            case "cups":
                                inventory.AddCups(converted);
                                break;
                        }
                        buy = true;
                    }
                    else
                    {
                        DisplayYouCantBuy(item, converted);
                        buy = true;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input! Please try again!");
                }
            }
            else
            {
                Console.WriteLine("Invalid input! please try again!");
            }
        }
        public void AmountToBuy(string item)
        {
            if (item == "lemons" || item == "cups")
            {
                Console.WriteLine("\nHow many {0} would you like to buy?", item);
            }
            else if (item == "sugar" || item =="ice")
            {
                Console.WriteLine("\nHow many {0} cubes would you like to buy?", item);
            }
        }
        public void DisplaySupplyBought(string item, int amountBought)
        {
            if (item == "lemons" || item == "cups" || item == "trees")
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\nYou have bought {0} {1}.\n", amountBought, item);
            }
            else if (item == "sugar" || item=="ice")
            {
                Console.WriteLine("\nYou have bought {0} {1}cubes.\n", amountBought, item);
                Console.ResetColor();
            }
        }
        public void DisplayYouCantBuy(string item, int amount)
        {
            if (item == "lemons" || item == "cups")
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nYou don't have enough cashAmount to buy {0} {1}.", amount, item);
                Console.WriteLine("Please check your cashAmount balance");
                Console.ResetColor();
            }
            else if (item == "sugar" || item =="ice")
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nYou don't have enough cashAmount to buy {0} {1} cubes.", amount, item);
                Console.WriteLine("Please check your cashAmount balance");
                Console.ResetColor();
            }
        }
    }
}