using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public class Inventory : Store
    {
        public double water;
        public double lemon;
        public double ice;
        public double cup;
        public double sugar; 
        public double numberOfFullLemonadeCup;
        public double numberOfLemonadeSold;

        public Inventory()
        {
            cup = 0;
        }
     

        public double NumberOfCupOwn()
        {
            return cup;
        }



        public void DisplayCurrentSupplies()
        {
            
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nYour current supplies are {0} bottles of water, {1} Lemon, {2} ice cube, {3} cups, {4} bag of sugar \n", water, lemon, ice, cup, sugar);
            Console.ResetColor();
        
        }
        public double FullLemonadeCupMade()
        {
            return numberOfFullLemonadeCup;
        }

        }
        }
    

