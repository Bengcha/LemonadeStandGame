using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Player
    {
        string name;
        public double cash;
        public Dictionary<string, int> recipe;
        public double price;
        public double cashAmountSpendToday;
        public double cashAmountEarnToday;
        public double totalCashSpent;
        public double totalCashEarned;
        public double finalCashBalance;
        public string Name { get { return name; } set { name = value; } }
        public Player()
        {
            cash = 50;
            price = .25;
            recipe = new Dictionary<string, int>();
            recipe.Add("lemons", 1);
            recipe.Add("sugar", 1);
            recipe.Add("ice", 1);
            recipe.Add("cups", 1);
            cashAmountEarnToday = 0;
            cashAmountSpendToday = 0;
            totalCashEarned = 0;
            totalCashSpent = 0;
            finalCashBalance = cash + totalCashEarned;
        }
        public void DisplayCash()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nYour cashAmount balance: ${0}\n", cash);
            Console.ResetColor();
        }
        public void DisplayRecipe()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Your current Lemonade Recipe Pitcher: {0} Lemon, {1} Sugar cubes, {2} Ice Cube", recipe["lemons"], recipe["sugar"], recipe["ice"]);
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Remember 1 Pitcher can hold 10 cups of Lemonade so make sure you have enough cups");
            Console.ResetColor();
        }
        public void DisplayPricePerLemonadeCup()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Your default price per lemonade cup is ${0}", price);
            Console.ResetColor();
            PriceOption();
        }
        public void PriceOption()
        {
            Console.WriteLine("Do you wish to change your lemonade price? Y|N");
            string priceChange = Console.ReadLine().ToLower();
            if (priceChange == "yes" || priceChange == "y")
            {
                GetChangePrice();
            }
            else if (priceChange == "no" || priceChange == "n")
            {
                Console.WriteLine("Okay, your price remain the same");
            }
            else
            {
                Console.WriteLine("Invalid input. Please choose a valid opitons");
                PriceOption();
            }
        }
        public void GetChangePrice()
        {
            double converted;
            Console.WriteLine("\nEnter your new price.");
            string newPrice = Console.ReadLine();
            bool result = Double.TryParse(newPrice, out converted);

            if (result)
            {
                if (converted > 0)
                {
                    Console.WriteLine("Your new price is ${0} per Lemonade cup", converted);
                    price = converted;
                }
                else
                {
                    Console.WriteLine("Your new price must be higher than $0.00");
                    GetChangePrice();
                }
            }
            else
            {
                Console.WriteLine("You enter a invalid option. Make sure your price is higher than $0.00");
                GetChangePrice();
            }
        }
        public void ChangeRecipe()
        {
            ChangeItem("lemons");
            ChangeItem("sugar");
            ChangeItem("ice");
        }
        public void GetChangeRecipe()
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("Do you wish to change your Recipe? Y|N");
            Console.ResetColor();
            string change = Console.ReadLine().ToLower();
            if (change == "y" || change == "yes")
            {
                ChangeRecipe();
            }
            else if (change == "n" || change == "no")
            {
                Console.WriteLine("No change to Recipe");
            }
            else
            {
                Console.WriteLine("Please choose a valid answer");
                GetChangeRecipe();
            }
        }
        public void ChangeItem(string item)
        {
            int converted;
            Console.WriteLine("\nHow many {0} do you want to add to the pitcher recipe?\n", item);
            string howMany = Console.ReadLine();
            bool result = Int32.TryParse(howMany, out converted);
            if (result)
            {
                if (converted >= 0)
                {
                    recipe[item] = converted;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Your new pitcher recipe now contain {0} {1}", converted, item);
                    Console.ResetColor();
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter number only");
                    ChangeItem(item);
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter number only");
                ChangeItem(item);
            }
        }
        public double GetCash()
        {
            return cash;
        }
        public void SetCash(double amount)
        {
            cash = amount;
        }
        public double GetTotalSpent()
        {
            return totalCashSpent;
        }
        public double GetTotalProfit()
        {
            return totalCashEarned;
        }
        public void AdjustCash(double amount)
        {
            cash += amount;
        }
        public void AdjustMoneySpentToday(double amount)
        {
            cashAmountSpendToday += amount;
        }
        public void AdjustTotalMoneySpent(double amount)
        {
            totalCashSpent += amount;
        }
        public double GetPrice()
        {
            return price;
        }
        public void ResetMoneySpent()
        {
            cashAmountSpendToday = 0;
        }
        public void SetTotalSpent(double amount)
        {
            totalCashSpent = amount;
        }
        public void SetTotalProfit(int amount)
        {
            totalCashEarned = amount;
        }
        public double GetMoneySpentToday()
        {
            return cashAmountSpendToday;
        }

        public void adjustTotalMoneySpent(double moneySpentToday)
        {
            totalCashSpent += moneySpentToday;
        }      
    }
}