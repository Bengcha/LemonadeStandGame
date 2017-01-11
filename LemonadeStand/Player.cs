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
        public double moneySpentToday;
        public double moneyEarnedToday;
        public double totalMoneySpent;
        public double totalMoneyEarned;

        public Player()
        {
            cash = 50;
            price = .1;
            recipe = new Dictionary<string, int>();
            recipe.Add("lemons", 1);
            recipe.Add("sugar", 1);
            recipe.Add("ice", 1);
            recipe.Add("cups", 1);

            moneyEarnedToday = moneySpentToday = totalMoneyEarned = totalMoneySpent = 0;
        }
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                
                name = value;
               
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
            return totalMoneySpent;
        }
        public double GetTotalProfit()
        {
            return totalMoneyEarned;
        }
        public void AdjustCash(double amount)
        {
            cash += amount;
        }
        public void AdjustMoneySpentToday(double amount)
        {
            moneySpentToday += amount;
        }
        public void AdjustTotalMoneySpent(double amount)
        {
            totalMoneySpent += amount;
        }
        public double GetPrice()
        {
            return price;
        }
        public void DisplayCash()
        {
            Console.WriteLine("Your cash balance: ${0}.", cash);
        }
        public void ResetMoneySpent()
        {
            moneySpentToday = 0;
        }
        public void SetTotalSpent(double amount)
        {
            totalMoneySpent = amount;
        }
        public void SetTotalProfit(int amount)
        {
            totalMoneyEarned = amount;
        }
        public double GetMoneySpentToday()
        {
            return moneySpentToday;
        }
        public void DisplayRecipe()
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("Your current Recipe: {0} Lemon, {1} Sugar cubes, {2} Ice Cube", recipe["lemons"], recipe["sugar"], recipe["ice"]);
            Console.ResetColor();
        }
        public void GetChangeRecipe()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Do you wish to change your Recipe? Y|N");
            Console.ResetColor();
            string change = Console.ReadLine().ToLower();
            if (change == "y")
            {
                ChangeRecipe();
            }
            else if (change =="n")
            {
                Console.WriteLine("No change to Recipe");
            }
            else
            {
                Console.WriteLine("Please choose a valid answer");
                GetChangeRecipe();
            }
        }
        public void ChangeRecipe()
        {
            ChangeItem("lemons");
            ChangeItem("sugar");
            ChangeItem("ice");
        }
        public void adjustTotalMoneySpent(double moneySpentToday)
        {
            totalMoneySpent += moneySpentToday;
        }
        public void ChangeItem(string item)
        {
            int converted;
            Console.WriteLine("How many {0} do you want to add to the pitcher recipe?", item);
            string howMany = Console.ReadLine();
            bool result = Int32.TryParse(howMany, out converted);
            if (result)
            {
                if (converted >= 0)
                {
                    recipe[item] = converted;
                    Console.WriteLine("Your pitcher recipe now contain {0} {1}", converted, item);
                }
                else
                {
                    Console.WriteLine("Please enter 0 or a positive number.");
                    ChangeItem(item);
                }
            }
            else
            {
                Console.WriteLine("Please enter 0 or a positive number.");
                ChangeItem(item);
            }
        }
        public void DisplayPrice()
        {
            Console.WriteLine("You currently charge ${0} for a cup of lemonade.", price);
        }

        public void GetChangePrice()
        {
            double converted;
            Console.WriteLine("Enter your new price.");
            string newPrice = Console.ReadLine();
            bool result = Double.TryParse(newPrice, out converted);

            if (result)
            {
                if (converted > 0)
                {
                    Console.WriteLine("You now charge ${0} for a cup of lemonade.", converted);
                    price = converted;
                }
                else
                {
                    Console.WriteLine("Please enter a number higher than 0.");
                    GetChangePrice();
                }
            }
            else
            {
                Console.WriteLine("Please enter a number higher than 0.");
                GetChangePrice();
            }
        }

    }

}