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
        Weather weather;
        Inventory inventory;
        Day day;
        Customer customer;
        Money money;
        public Game()
        {
            player = new Player();
            weather = new Weather();
            inventory = new Inventory();
            day = new Day();
            customer = new Customer();
            money = new Money();

        }

        public void StartGame()
        {
            DisplayWelcome();
            DisplayPlayOption();
            DisplayRule();
            GreetPlayer();
            StartDay();
            
        }

        public void DisplayWelcome()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Welcome to the Lemonade Stand Game \n");
            Console.ResetColor();
            
        }

        public void DisplayPlayOption()
        {
            Console.WriteLine("Press 1 or 2 \n 1: Play Game \n 2: Quit Game");
            string play = Console.ReadLine();
            if (play == "1")
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("THE LEMONADE GAME");
                Console.ResetColor();
            }
            else if (play == "2")
            {
                Console.WriteLine("Thanks for playing, goodbye. \n");
                Console.ReadKey();
                Environment.Exit(0);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Please enter a correct choice. \n");
                Console.ResetColor();
                DisplayPlayOption();

            }
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
        public void GreetPlayer()
        {
            player = new Player();
            player.ChooseName();
            Console.WriteLine("\nNice to meet you {0}, my name is Kim and I'll guide you through the begining process of how to run your business \n", player.name);
            Console.WriteLine("press enter to continue...\n");
            Console.ReadLine();
        }
        public void DisplaySupplyPrice()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("The Supplies and Price");
            Console.ResetColor();
            Console.WriteLine("You will need 1 bottle of water, 4 lemon, 2 bag of sugar, 8 ice cube, and 10 cup to make one pitcher that hold 10 cups of Lemonade ");
            Console.WriteLine("The cost of each item: Water bottle: $0.15 each, Lemon: $0.20 each, Cup: $0.05 each, Sugar: $.10 each, Ice: $0.05 each \n");
            Console.WriteLine("press enter to continue...\n");
            Console.ReadLine();
        }

        public void GetSupply()
        {
            player.BuyingWater();
            player.BuyingLemon();
            player.BuyingCup();
            player.BuyingIce();
            player.BuyingSugar();
            player.MakingLemonade();
        }


        public void StartDay()
        {
            while (day.firstDay < day.sevenDay)
            {
                day.days();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Day {0} of Lemonade Business", day.firstDay);
                Console.ResetColor();
                DisplaySupplyPrice();
                weather.WeatherForecast();
                weather.RndTemperature();
                GetSupply();
                customer.CustomerPreference(day.numberOfCustomer);
            }
            day.firstDay++;
        }
}               


                }


