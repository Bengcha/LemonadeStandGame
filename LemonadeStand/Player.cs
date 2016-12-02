using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Player 

    {
        bool setPrice = true;
        public string name;

        public void ChooseName()
        {
            Console.WriteLine("What will your character name be? \n");
            name = Console.ReadLine();
            if (name.Equals(""))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You forgot to enter a Name for your character \n");
                Console.ResetColor();
                ChooseName();
            }

        }
        public void SetLemonadePrice()
        {
            Inventory supply = new Inventory();
            Money price = new Money();
            if (supply.numberOfFullLemonadeCup > 0)
            {
                Console.WriteLine("Enter the amount per Lemonade cup: \n");
                price.PricePerLemonade = Convert.ToDouble(Console.ReadLine());
                setPrice = true;

            }
            else if (supply.numberOfFullLemonadeCup == 0)
            {
                Console.WriteLine("You don't have any Lemonade to sell");
                Console.WriteLine("Game Over \n");
                Console.ReadLine();
                setPrice = false;
            }
        }
        }
        
    }


