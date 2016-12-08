using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Recipe : iMixable
    {
        public double pitcher;

        public void mixSupply()
        {

        }
        public void supplyNeedToMakePitcher()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\nYou will need 1 bottle of water, 4 lemon, 2 bag of sugar, 8 ice cube, and 10 cup to make one pitcher that hold 10 cups of Lemonade \n");
            Console.ResetColor();
        }

        //for (inventory.numberOfFullLemonadeCup + 10)
        //{
        //    inventory.water = inventory.water - 1;
        //    inventory.lemon = inventory.lemon - 4;
        //    inventory.sugar = inventory.sugar - 2;
        //    inventory.ice = inventory.ice - 8;
        //    inventory.cup = inventory.cup - 10;

        //}

    }
}



