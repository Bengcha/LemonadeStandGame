using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public class Inventory 
    {
        public double currentWaterLeft;
        public double currentLemonLeft;
        public double currentIceLeft;
        public double currentCupLeft;
        public double currentSugarLeft; 
        public double numberOfFullLemonadeCup;

        public Inventory()
        {
            currentCupLeft = 0;
            currentIceLeft = 0;
            currentLemonLeft = 0;
            currentSugarLeft = 0;
            currentWaterLeft = 0;
            numberOfFullLemonadeCup = 0;
        

        }
        public void CurrentSupplies()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Your current supplies are {0} bottles of water, {1} Lemon, {2} ices, {3} cups, {4} bag of sugar \n", currentWaterLeft, currentLemonLeft, currentIceLeft, currentCupLeft, currentSugarLeft);
            Console.ResetColor();
        }
        public double ReturnNewSupply()
        {
            return currentWaterLeft;


        }
        }
    }

