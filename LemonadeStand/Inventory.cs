using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Inventory 
    {
        public double currentWaterLeft = 0;
        public double currentLemonLeft = 0;
        public double currentIceLeft = 0;
        public double currentCupLeft = 0;
        public double currentSugarLeft = 0;
        public double numberOfFullLemonadeCup;

        public Inventory()
        {
            numberOfFullLemonadeCup = 0;
        }
        public void AddWater()
        {
            return;
        }
        public void CurrentSupplies()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Your current supplies are {0} bottles of water, {1} Lemon, {2} ices, {3} cups, {4} bag of sugar \n", currentWaterLeft, currentLemonLeft, currentIceLeft, currentCupLeft, currentSugarLeft);
            Console.ResetColor();
        }
        }
    }

