using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
     public class Recipe : iMixable
    {
        public double pitcher;
        double mySupplyLemon;
        double mySupplySugar;
        double mySupplyIce;

        public void mixSupply()
        {

        }
        public void displayMakeRecipe()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Its time to setup your recipe for your Pitcher \n");
            Console.WriteLine("One Pitcher can hold 10 cup of Lemonade");
            Console.ResetColor();
            NewRecipe();
            displayRecipe();
        }

        public void NewRecipe()
        {
            CreateRecipe("Lemon");
            CreateRecipe("Sugar");
            CreateRecipe("Ice");
        }
        public void CreateRecipe(string supply)
        {
            Console.WriteLine("How many {0} do you want in a pitcher? \n", supply);
            string NumberOfItem = Console.ReadLine();
            double numberOfItem = Convert.ToDouble(NumberOfItem);
            if (numberOfItem > 0)
            {
                mySupplyLemon = numberOfItem;
                mySupplySugar = numberOfItem;
                mySupplyIce = numberOfItem;
                Console.WriteLine("Your recipe now contain {0} {1} \n", numberOfItem, supply);
            }
            else
            {
                Console.WriteLine("Please enter a valid amount");
            }
        }
        public void displayRecipe()
        {
            Console.WriteLine("Your complete recipe: {0} Lemon, {1} Sugar bag, {2} Ice cubes \n", mySupplyLemon, mySupplySugar, mySupplyIce );
        }





    }
}



