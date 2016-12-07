using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Player

    {
        public string name;
        Money money;
        Store store;
        Inventory inventory;

        public Player()
        {
            money = new Money();
            store = new Store();
            inventory = new Inventory();
        }


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
        public double BuyingWater()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("How many water bottle do you want to buy? \n");
            Console.ResetColor();
            try
            {
                double item = Convert.ToDouble(Console.ReadLine());
                if (money.CurrentCash > store.PriceOfWater * item)
                {
                    money.CurrentCash = money.CurrentCash - (store.PriceOfWater * item);
                    inventory.currentWaterLeft += (store.numberOfWater * item);
                    Console.WriteLine("You now have {0} water bottle in your inventory \n", inventory.currentWaterLeft);
                }
                else if (money.CurrentCash < store.PriceOfWater * item)
                {
                    Console.WriteLine("Sorry {0} you don't have enough cash to buy that amount\n", name);
                    BuyingWater();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("You enter a invalid amount");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Please use Number ONLY!");
                Console.ResetColor();
                BuyingWater();
            }

            return money.CurrentCash;
        }

        public double BuyingLemon()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("How many lemon do you want to buy? \n");
            Console.ResetColor();
            try
            {
                double item = Convert.ToDouble(Console.ReadLine());
                if (money.CurrentCash > store.PriceOfLemon * item)
                {
                    money.CurrentCash = money.CurrentCash - (store.PriceOfLemon * item);
                    inventory.currentLemonLeft += (store.numberOfLemon * item);
                    Console.WriteLine("You now have {0} lemon in your inventory \n", inventory.currentLemonLeft);
                }
                else if (money.CurrentCash < store.PriceOfLemon * item)
                {
                    Console.WriteLine("Sorry {0} you don't have enough cash to buy that amount", name);
                    BuyingLemon();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("You enter a invalid amount");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Please use Number ONLY!");
                Console.ResetColor();
                BuyingLemon();
            }
            return money.CurrentCash;
        }

        public double BuyingCup()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("How many cup do you want to buy? \n");
            Console.ResetColor();
            try
            {
                double item = Convert.ToDouble(Console.ReadLine());
                if (money.CurrentCash > store.PriceOfCup * item)
                {
                    money.CurrentCash = money.CurrentCash - (store.PriceOfCup * item);
                    inventory.currentCupLeft += (store.numberOfCup * item);
                    Console.WriteLine("You now have {0} cups in your inventory \n", inventory.currentCupLeft);


                }
                else if (money.CurrentCash < store.PriceOfCup * item)
                {
                    Console.WriteLine("Sorry {0} you don't have enough cash to buy that amount", name);
                    BuyingCup();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("You enter a invalid amount");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Please use Number ONLY!");
                Console.ResetColor();
                BuyingCup();
            }
            return money.CurrentCash;
        }

        public double BuyingIce()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("How many ice cubes do you want to buy? \n");
            Console.ResetColor();
            try
            {
                double item = Convert.ToDouble(Console.ReadLine());

                if (money.CurrentCash > store.PriceOfIce * item)
                {
                    money.CurrentCash = money.CurrentCash - (store.PriceOfIce * item);
                    inventory.currentIceLeft += (store.numberOfIce * item);
                    Console.WriteLine("You now have {0} ice cubes in your inventory \n", inventory.currentIceLeft);
                }
                else if (money.CurrentCash < store.PriceOfIce * item)
                {
                    Console.WriteLine("Sorry {0} you don't have enough cash to buy that amount", name);
                    BuyingIce();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("You enter a invalid amount");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Please use Number ONLY!");
                Console.ResetColor();
                BuyingIce();
            }
            return money.CurrentCash;
        }

        public double BuyingSugar()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("How many bags of sugar do you want to buy? \n");
            Console.ResetColor();
            try
            {
                double item = Convert.ToDouble(Console.ReadLine());
                if (money.CurrentCash > store.PriceOfSugar * item)
                {
                   
                    money.CurrentCash = money.CurrentCash - (store.PriceOfSugar * item);
                    inventory.currentSugarLeft += (store.numberOfSugar * item);
                    Console.WriteLine("You now have {0} bags of sugar in your inventory \n", inventory.currentSugarLeft);

                }
                else if (money.CurrentCash < store.PriceOfSugar * item)
                {
                    Console.WriteLine("Sorry {0} you don't have enough cash to buy that amount", name);
                    BuyingSugar();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("You enter a invalid amount");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Please use Number ONLY!");
                Console.ResetColor();
                BuyingSugar();
            }
            return money.CurrentCash;

        }


        public void MakingLemonade()

        {
            inventory.CurrentSupplies();
            money.displayCurrentBalance();
            Console.WriteLine("\nType ---' Make '--- to make yummy lemonade \n");
            string make = Console.ReadLine().ToLower();
            if (make == "make")
            {
                if (inventory.currentWaterLeft >= 1 && inventory.currentLemonLeft >= 4 && inventory.currentSugarLeft >= 2 && inventory.currentIceLeft >= 8 && inventory.currentCupLeft >= 10)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("~~Lemonade Making In Progress~~");
                    Console.ResetColor();
                    Console.WriteLine("press enter to see freshly made lemonade! \n");
                    Console.ReadLine();
                    inventory.currentWaterLeft = inventory.currentWaterLeft - 1;
                    inventory.currentLemonLeft = inventory.currentLemonLeft - 4;
                    inventory.currentSugarLeft = inventory.currentSugarLeft - 2;
                    inventory.currentIceLeft = inventory.currentIceLeft - 8;
                    inventory.currentCupLeft = inventory.currentCupLeft - 10;
                    inventory.numberOfFullLemonadeCup = inventory.numberOfFullLemonadeCup + 10;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("You successfully made 1 pitcher of lemonade");
                    Console.ResetColor(); 
                    Console.WriteLine("You now have {0} lemonade fill cup \n", inventory.numberOfFullLemonadeCup);
                    inventory.CurrentSupplies();
                    MakeMorePitcher();
                }
                else if (inventory.currentWaterLeft < 1 || inventory.currentLemonLeft < 4 || inventory.currentSugarLeft < 2 || inventory.currentIceLeft < 8 || inventory.currentCupLeft < 5)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Sorry you don't have enough supplies to make a pitcher \n");
                    Console.WriteLine("Shopping Time");
                    money.displayCurrentBalance();
                    Console.ResetColor();
                    inventory.CurrentSupplies();
                    bool more = true;
                    while (more)
                    {
                        
                        Console.WriteLine("Choose a options \nBuy: (Water, Lemon, Sugar, Ice, Cup) \nDone = Ready to make more Lemonade \nQuit = End Game");
                        string buymore = Console.ReadLine().ToLower();
                        switch (buymore)
                        {
                            case "water":
                                more = true;
                                BuyingWater();
                                break;
                            case "lemon":
                                more = true;
                                BuyingLemon();
                                break;
                            case "sugar":
                                more = true;
                                BuyingSugar();
                                break;
                            case "ice":
                                more = true;
                                BuyingIce();
                                break;
                            case "cup":
                                more = true;
                                BuyingCup();
                                break;
                            case "done":
                                more = false;
                                MakingLemonade();
                                break;
                            case "quit":
                                Console.WriteLine("Thanks for playing, Goodbye!");
                                Console.ReadLine();
                                Environment.Exit(0);
                                break;
                            default:
                                more = true;
                                break;
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("{0} you need to make some lemonade before proceed on ", name);
                MakingLemonade();
            }



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
        }
    }

    





                
    //public void SetLemonadePrice()
    //{
    //    Inventory supply = new Inventory();
    //    Money price = new Money();
    //    if (supply.numberOfFullLemonadeCup > 0)
    //    {
    //        Console.WriteLine("Enter the amount per Lemonade cup: \n");
    //        price.PricePerLemonade = Convert.ToDouble(Console.ReadLine());
    //        setPrice = true;

    //    }
    //    else if (supply.numberOfFullLemonadeCup == 0)
    //    {
    //        Console.WriteLine("You don't have any Lemonade to sell");
    //        Console.WriteLine("Game Over \n");
    //        Console.ReadLine();
    //        setPrice = false;











