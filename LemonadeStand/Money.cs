using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Money
    {
        public double CurrentCash;
        public double CurrentRevenue;
        public double PricePerLemonade;

 
        public Money()
        {
            CurrentCash = 20.00;
            PricePerLemonade = 0;
            CurrentRevenue = 0;
         
        }
        public double LeftOverCash()
        {
            return CurrentCash;
        }
        public void displayCurrentBalance()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Your current cash balance: ${0} ", CurrentCash);
            Console.ResetColor();

        }
    }
}


