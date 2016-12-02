using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Game
    {
        Player player;


        public void StartGame()
        {
            DisplayWelcome();
            DisplayRule();
            GetPlayerName();
        }

        public void DisplayWelcome()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Welcome to the Lemonade Stand Game \n");
            Console.ResetColor();
        }

        public void DisplayRule()
        {
            Console.WriteLine("\nWould you like to see the rules? Yes | No \n");
            string choice = Console.ReadLine().ToLower();
            switch (choice)
            {
                case "yes":
                    Rules rule = new Rules();
                    rule.GameRules();
                    break;
                case "no":
                    Console.WriteLine("\nOkay lets move forward. \n");
                    break;
                default:
                    Console.WriteLine("Please answer yes or no.");
                    DisplayRule();
                    break;
            }
        }
            public void GetPlayerName()
        {
            player = new Player();
            player.ChooseName();
        }
            
        }

    }



