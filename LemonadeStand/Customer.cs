using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Customer
    {
        int thirst;
        int cash;
        int sweetness;
        int sourness;
        Random customerRandom = new Random();
        public Customer()
        {
            thirst = 0;
            cash = 0;
            sweetness = 0;
        }
        public void Randomize()
        {
            thirst = customerRandom.Next(0, 50);
            sweetness = customerRandom.Next(0, 50);
            sourness = customerRandom.Next(0, 50);
            cash = customerRandom.Next(1, 10);
        }
        public bool WillBuy(Player player, Weather weather, Pitcher pitcher)
        {
            double costThreshold = cash / 3;
            double afterTemp = 1 + ((weather.GetTemperature() - 84.0) / 100.0);
            costThreshold = costThreshold * afterTemp;
            if (player.GetPrice() > costThreshold)
            {
                return false;
            }
            else
            {
                int buyRoll = customerRandom.Next(1, 100);
                double cheapPrice = 1;
                if (player.GetPrice() < cash / 6)
                {
                    cheapPrice = 1 + (cash / 5);
                }
                if (buyRoll <= (thirst * afterTemp * cheapPrice))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

        }
        public int GetThirst()
        {
            return thirst;
        }
        public double GetCash()
        {
            return cash;
        }

        public bool DetermineIfCustomerWillBuyAgain(Pitcher pitcher)
        {
            if (pitcher.GetSweetness() == sweetness || pitcher.GetSourness() == sourness)
            {
                return true;
            }
            else if (Math.Abs(pitcher.GetSweetness() - sweetness) <= 25)
            {
                return true;
            }
            else if (Math.Abs(pitcher.GetSourness() - sourness) <= 25)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

}

