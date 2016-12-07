using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Customer
    {
        Inventory inventory;
        public string name;
        List <Customer> RandomCustomerList;
        public double numberOfCustomer;

        public Customer()
        {
            inventory = new Inventory();
            RandomCustomerList = new List<Customer> ();
        }
        public List<Customer> CustomerPreference(double numberOfCustomerPreference)
        {
            Random random = new Random();
            for (double i = 0; i < numberOfCustomerPreference; i++)
            {
                double rndNumber = random.Next(1, 10);
                if (rndNumber == 1 || rndNumber == 5 || rndNumber == 8)
                {
                    Console.WriteLine("no sales");
                }
                else if (inventory.numberOfFullLemonadeCup < 0)
                {
                    Console.WriteLine("You have run out of Lemonade!");
                }
                else
                {
                    Console.WriteLine("Bought Lemonade");
                    inventory.numberOfLemonadeSold += 1;
                }
            }
            return RandomCustomerList;
        }


    }
}
