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
        Recipe recipe;
        Mission mission;

        public Game()
        {
            player = new Player();
            weather = new Weather();
            inventory = new Inventory();
            day = new Day();
            customer = new Customer();
            money = new Money();
            recipe = new Recipe();
            mission = new Mission();
        }

        public void RunGame()
        {
            DisplayWelcome();
            DisplayPlayOption();
            DisplayGameTitle();
            DisplayMission();
            player.ChooseName();
            StartGame();
        }

        public void DisplayWelcome()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Welcome to the Lemonade Stand Game \n");
            Console.ResetColor();
        }

        public void DisplayPlayOption()
        {
            Console.WriteLine("[1] Play Game \n[2] Quit Game");
            string play = Console.ReadLine();
            if (play == "1")
            {
                Console.Clear();
            }
            else if (play == "2")
            {
                Console.WriteLine("GAME OVER!");
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

        public void DisplayGameTitle()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("|************************************|");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("|~~~~~*** THE LEMONADE GAME ***~~~~~~|");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("|************************************|");
            Console.ResetColor();
        }

        public void DisplayMission()
        {
            Console.WriteLine("\nWould you like to see the Mission statment? Yes | No \n");
            string choice = Console.ReadLine().ToLower();
            switch (choice)
            {
                case "yes":
                    mission.goalStatment();
                    break;
                case "no":
                    Console.WriteLine("\nOkay lets move forward. \n");
                    break;
                default:
                    Console.WriteLine("Please answer yes or no.");
                    DisplayMission();
                    break;
            }
        }

        public void PlayerMenu()
        {

            bool MainMenu = true;
            while (MainMenu)
            {
                Console.WriteLine("\n{0} what would you like to do?\n", player.name);
                Console.WriteLine("[1] Start the Day        [2] Check Inventory  [3] Buy Supply\n[4] Check Cash Balance   [5] Check Recipe     [6] Quit  ");
                string chooseMenu = Console.ReadLine().ToLower();
                switch (chooseMenu)
                {
                    case "1":
                        MainMenu = false;
                        MakingLemonade();
                        break;
                    case "2":
                        MainMenu = true;
                        inventory.DisplayCurrentSupplies();
                        break;
                    case "3":
                        MainMenu = true;
                        BuySupply();
                        break;
                    case "4":
                        MainMenu = true;
                        money.displayCurrentBalance();
                        break;
                    case "5":
                        MainMenu = true;
                        recipe.supplyNeedToMakePitcher();
                        break;
                    case "6":
                        MainMenu = false;
                        Console.WriteLine("GAME OVER!");
                        Console.ReadLine();
                        Environment.Exit(0);
                        break;
                    default:
                        MainMenu = true;
                        break;
                }
            }
        }

        public void BuySupply()
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("\n****FoodMart Store****\n");
            Console.ResetColor();
            Console.WriteLine("\n[1] Water: $0.15 each     [2] Lemon: $0.20 each  [3] Ice: $0.05 per cube \n[4] Sugar: $0.10 per bag  [5] Cup: $0.05 each    [6] Done\n");
            string buyItem = Console.ReadLine();
            switch (buyItem)
            {
                case "1":
                    player.BuyingWater();
                    break;
                case "2":
                    player.BuyingLemon();
                    break;
                case "3":
                    player.BuyingIce();
                    break;
                case "4":
                    player.BuyingSugar();
                    break;
                case "5":
                    player.BuyingCup();
                    break;
                case "6":
                    break;
                default:
                    Console.WriteLine("Please enter a correct choice");
                    BuySupply();
                    break;
            }
        }

        public void StartGame()
        {
            while (day.firstDay < day.lastDay)
            {
                DisplayGameTitle();
                day.days();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Day {0} of Lemonade Business", day.firstDay);
                Console.ResetColor();
                weather.randomWeatherWithTemperature();
                PlayerMenu();
                MakingLemonade();
                SetLemonadePrice();
                day.CustomerPerDay(weather, player, money, inventory);
                Console.Clear();

            }
             day.firstDay++;
        }

        public double MakingLemonade()

        {

            Console.WriteLine("\nType ---' Make '--- to make yummy lemonade \n");
            string make = Console.ReadLine().ToLower();
            if (make == "make")
            {
                if (inventory.water >= 1 && inventory.lemon >= 4 && inventory.sugar >= 2 && inventory.ice >= 8 && inventory.cup >= 10)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\n~~~~Lemonade Making In Progress~~~~\n");
                    Console.ResetColor();
                    Console.WriteLine("press enter to see freshly made lemonade! \n");
                    Console.ReadLine();
                    inventory.water = inventory.water - 1;
                    inventory.lemon = inventory.lemon - 4;
                    inventory.sugar = inventory.sugar - 2;
                    inventory.ice = inventory.ice - 8;
                    inventory.cup = inventory.cup - 10;
                    inventory.numberOfFullLemonadeCup = inventory.numberOfFullLemonadeCup + 10;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("You successfully made 1 pitcher of lemonade");
                    Console.ResetColor();
                    Console.WriteLine("You now have {0} lemonade fill cup \n", inventory.numberOfFullLemonadeCup);
                    MakeMorePitcher();

                }
                else if (inventory.water < 1 || inventory.lemon < 4 || inventory.sugar < 2 || inventory.ice < 8 || inventory.cup < 5)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Sorry you don't have enough supplies to make a pitcher \n");
                    Console.ResetColor();
                    PlayerMenu();
                }
            }

            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("{0} you need to make some lemonade before proceed on ", player.name);
                Console.ResetColor();
                Console.WriteLine("press enter to continue... \n");
                Console.ReadKey();
                MakingLemonade();
            }
            return inventory.numberOfFullLemonadeCup;
        }
        public void MakeMorePitcher()
        {
            Console.WriteLine("Do you wish to make more Pitcher? Yes | No \n");
            string MakeMore = Console.ReadLine().ToLower();
            if (MakeMore == "yes")
            {
                MakingLemonade();

            }
            else if (MakeMore == "no")
            {
                Console.WriteLine("Great Good luck on your sales! \n");
            }
            else
            {
                Console.WriteLine("You enter a invalid choices");
                MakeMorePitcher();
            }
        }
        public double SetLemonadePrice()
        {
            Console.WriteLine("Set a price for your lemonade ");
            try
            {
                double price = Convert.ToDouble(Console.ReadLine());
                money.PricePerLemonade = inventory.numberOfFullLemonadeCup * price;
                Console.WriteLine("Your lemonade price is set to {0}", price);
                Console.WriteLine("You current have {0} lemonade and if you sell all your lemonade you will make ${1}", inventory.numberOfFullLemonadeCup, money.PricePerLemonade);
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nINVALID ENTRY! Enter a correct amount for your set price\n");
                Console.ResetColor();
                SetLemonadePrice();
            }
            return money.PricePerLemonade;
        }

    }
}



