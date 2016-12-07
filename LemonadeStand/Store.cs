using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Store
    {
        public double numberOfWater = 1;
        public double numberOfLemon = 1;
        public double numberOfIce = 1;
        public double numberOfCup = 1;
        public double numberOfSugar = 1;
        public double PriceOfWater;
        public double PriceOfLemon;
        public double PriceOfCup;
        public double PriceOfSugar;
        public double PriceOfIce;


        public Store()
        {
            PriceOfWater = 0.15;
            PriceOfLemon = 0.20;
            PriceOfCup = 0.05;
            PriceOfSugar = 0.10;
            PriceOfIce = 0.05;

        }
    }
}