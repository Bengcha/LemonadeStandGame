using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public class Player

    {
        public string name;
        Money money;
        Store store;
        Inventory inventory;
        Recipe recipe;
        public double numberOfItem;
     

        public Player()
        {
            money = new Money();
            store = new Store();
            inventory = new Inventory();
            recipe = new Recipe();
           
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
                double numberOfItem = Convert.ToDouble(Console.ReadLine());
                if (money.CurrentCash > store.PriceOfWater * numberOfItem)
                {
                    money.CurrentCash = money.CurrentCash - (store.PriceOfWater * numberOfItem);
                    inventory.water += (store.numberOfWater * numberOfItem);
                    inventory.DisplayCurrentSupplies();
                    money.displayCurrentBalance();
                }
                else if (money.CurrentCash < store.PriceOfWater * numberOfItem)
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
                    inventory.lemon += (store.numberOfLemon * item);
                    inventory.DisplayCurrentSupplies();
                    money.displayCurrentBalance();
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
                    inventory.cup += (store.numberOfCup * item);
                    inventory.DisplayCurrentSupplies();
                    money.displayCurrentBalance();
                    return inventory.cup;
                   


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
                    inventory.ice += (store.numberOfIce * item);
                    inventory.DisplayCurrentSupplies();
                    money.displayCurrentBalance();
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
                    inventory.sugar += (store.numberOfSugar * item);
                    inventory.DisplayCurrentSupplies();
                    money.displayCurrentBalance();



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











