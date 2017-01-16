using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace LemonadeStand
{
    class Game
    {
        int numberOfDays;
        int currentDay;
        List<Customer> customers;
        List<Weather> weatherForecast;
        Inventory inventory;
        Store store;
        Player player;
        Day day;
        Weather weather;
        bool mainMenu;
        public Game()
        {
            currentDay = 1;
            customers = new List<Customer>();
            weatherForecast = new List<Weather>();
            inventory = new Inventory();
            store = new Store();
            player = new Player();
            day = new Day();
            weather = new Weather();
            mainMenu = true;
        }
        public void StartGame()
        {
            DisplayWelcomeMessage();
            DisplayPlayOption();
            DisplayGameTitle();
            RuleOptions();
            ChooseName();
            GetDays();
            SetWeather();
            PlayerMenu();
            EndGame();
        }
        public void DisplayWelcomeMessage()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
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
        public void RuleOptions()
        {
            DisplayGameTitle();
            Console.WriteLine("\nWould you like to see the Mission statment? Yes | No \n");
            string choice = Console.ReadLine().ToLower();
            switch (choice)
            {
                case "yes":
                case "y":
                    DisplayRule();
                    break;
                case "no":
                case "n":
                    Console.WriteLine("\nOkay lets move forward. \n");
                    break;
                default:
                    Console.WriteLine("Please answer yes or no.");
                    Console.ReadKey();
                    Console.Clear();
                    RuleOptions();
                    break;
            }
        }
        public void DisplayRule()
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("\nYou are given $50.00 to start a Lemonade Business. You can choose the amount of days");
            Console.WriteLine("you want to play for. You can start buying supplies with the amount of cash you have.");
            Console.WriteLine("The supplies are lemon, ice, cup, and sugar. You have the options ");
            Console.WriteLine("to choose the amount of supplies you want to buy each day. The weathers ");
            Console.WriteLine("conidition will greatly impact your sales and profit. To win the game your");
            Console.WriteLine("final balance should be greater than your starting balance.");
            Console.ResetColor();
            Console.WriteLine("\npress enter to continue...\n");
            Console.ReadLine();
        }
        public void ChooseName()
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("What will your character name be?");
            Console.ResetColor();
            player.Name = Console.ReadLine().ToUpper();
            if (player.Name.Equals(""))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You forgot to enter a Name for your character \n");
                Console.ResetColor();
                ChooseName();
            }
        }
        public void SetCurrentDay(int day)
        {
            currentDay = day;
        }
        public void GetDays()
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("\nHello {0}! please enter the amount of days you wish to play \n", player.Name);
            Console.ResetColor();
            string playerDays = Console.ReadLine().ToUpper();
            int converted;
            bool result = Int32.TryParse(playerDays, out converted);
            if (result)
            {
                if (converted > 0)
                {
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    numberOfDays = converted;
                    Console.WriteLine("\nGreat! You are set to play for {0} days.", converted);
                    Console.ResetColor();
                    Console.WriteLine("\npress enter to continue...");
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Please enter number only.");
                    GetDays();
                }
            }
            else
            {
                Console.WriteLine("Please enter number only.");
                GetDays();
            }
        }
        public void SetWeather()
        {
            int weatherDays = numberOfDays + 7;
            for (int i = 0; i < weatherDays; i++)
            {
                Weather weather = new Weather();
                weather.RandomForecast();
                weatherForecast.Add(weather);
            }
        }
        public void PlayerMenu()
        {
            while (mainMenu)
            {
                DisplayGameTitle();
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("\n*************** DAY {0} ***************", currentDay);
                Console.ResetColor();
                weather.DisplayTodaysWeather(weatherForecast);
                Console.WriteLine("\n{0} what would you like to do?", player.Name);
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("[1] Start Day [2] Inventory [3] Store [4] Cash Balance \n[5] Recipe    [6] Set Price [7] Quit ");
                string choice = Console.ReadLine().ToLower();
                Console.ResetColor();
                switch (choice)
                {
                    case "1":
                        Console.Clear();
                        day.StartDay(inventory, player, this, weatherForecast[0]);
                        day.EndDay(this, player, inventory);

                        Console.ReadKey();
                        break;
                    case "2":
                        inventory.DisplayInventory();
                        Console.ReadKey();
                        break;
                    case "3":
                        store.Purchase(inventory.Storage, player, inventory);
                        Console.ReadKey();
                        break;
                    case "4":
                        player.DisplayCash();
                        Console.ReadKey();
                        break;
                    case "5":
                        player.DisplayRecipe();
                        player.GetChangeRecipe();
                        Console.ReadKey();
                        break;
                    case "6":
                        player.DisplayPricePerLemonadeCup();
                        Console.ReadKey();
                        break;
                    case "7":
                        mainMenu = false;
                        Console.WriteLine("You Ended the Game. Goodbye!");
                        Console.ReadKey();
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Thats not a valid option, please choose between [1] - [7]");
                        Console.WriteLine("press enter to continue...");
                        Console.ReadLine();
                        mainMenu = true;
                        break;
                }
            }
        }
        public Customer MakeCustomer()
        {
            Customer customer = new Customer();
            customer.Randomize();
            return customer;
        }
        public int GetCurrentDay()
        {
            return currentDay;
        }
        public void ChangeDay(Player player)
        {
            weatherForecast.RemoveAt(0);
            currentDay++;
            player.ResetMoneySpent();
            if (currentDay == numberOfDays + 1)
            {
                mainMenu = false;
            }
        }
        public void EndGame()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nGame over.");
            Console.ResetColor();
            Console.WriteLine("You have completed all your business days");
            Console.WriteLine("\npress any key to see your game result\n");
            Console.ReadKey();
            if (player.cash > 50)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Congratulation! You Won!");
                Console.WriteLine("Your starting balance was $50.00 and your ending balance was ${0}", player.cash);
                Console.WriteLine("\nPress any key to exit game.");
                Console.ResetColor();
                Console.ReadKey();
                Environment.Exit(0);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("You Lost! Good luck next time");
                Console.WriteLine("Your starting balance was $50.00 and your ending balance was ${0}", player.cash);
                Console.WriteLine("\nPress any key to exit.");
                Console.ResetColor();
                Console.ReadKey();
                Environment.Exit(0);
            }
        }
    }
}