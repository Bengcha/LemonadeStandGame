using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Pitcher
    {
        int fullPitcher;
        int sweetLemonade;
        int sourLemonade;

        public Pitcher(Player player)
        {
            fullPitcher = 0;
            sweetLemonade = 0;
            for (int sugar = 0; sugar < player.recipe["sugar"]; sugar++)
            {
                sweetLemonade += 15;
            }
            for (int lemons = 0; lemons < player.recipe["lemons"]; lemons++)
            {
                sourLemonade += 30;
            }
            for (int ice = 0; ice < player.recipe["ice"]; ice++)
            {
                sweetLemonade -= 3;
                sourLemonade -= 3;
            }
        }
        public int GetSweetness()
        {
            return sweetLemonade;
        }
        public int GetSourness()
        {
            return sweetLemonade;
        }
        public int GetFull()
        {
            return fullPitcher;
        }
        public void AdjustFull(int amount)
        {
            fullPitcher += amount;
        }
        public void FillPitcher(Inventory inventory, Player player)
        {
            fullPitcher = 100;
            for (int i = 0; i < player.recipe["lemons"]; i++)
            {
                inventory.RemoveLemon();
            }
            for (int i = 0; i < player.recipe["sugar"]; i++)
            {
                inventory.RemoveSugar();
            }
            for (int i = 0; i < player.recipe["ice"]; i++)
            {
                inventory.RemoveIce();
            }
            //for (int i = 0; i < player.recipe["cups"]; i++)
            //{
            //    inventory.RemoveCup();
            //}
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("***~~~Lemonade Selling in process~~***");
            Console.ResetColor();
        }
    }
}
