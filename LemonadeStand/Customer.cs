using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Customer
    {
        Random customerRandom;
        int thirstPercentage;
        int cashAmount;
        int sweetPercentage;
        int sourPercentage;    
        public Customer()
        {
            customerRandom = new Random();
            thirstPercentage = 0;
            cashAmount = 0;
            sweetPercentage = 0;        
        }
        public int GetThirst()
        {
            return thirstPercentage;
        }
        public double GetCash()
        {
            return cashAmount;
        }
        public void Randomize()
        {
            thirstPercentage = customerRandom.Next(0, 50);
            sweetPercentage = customerRandom.Next(0, 50);
            sourPercentage = customerRandom.Next(0, 50);
            cashAmount = customerRandom.Next(1, 10);
        }
        public bool CheckingCustomerBuyingStatus(Pitcher pitcher)
        {
            if (pitcher.GetSweetness() == sweetPercentage || pitcher.GetSourness() == sourPercentage)
            {
                return true;
            }
            else if (Math.Abs(pitcher.GetSweetness() - sweetPercentage) <= 20)
            {
                return true;
            }
            else if (Math.Abs(pitcher.GetSourness() - sourPercentage) <= 20)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool WillPurchase(Player player, Weather weather, Pitcher pitcher)
        {
            double costThreshold = cashAmount / 3;
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
                if (player.GetPrice() < cashAmount / 6)
                {
                    cheapPrice = 1 + (cashAmount / 5);
                }
                if (buyRoll <= (thirstPercentage * afterTemp * cheapPrice))
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
}


