using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LemonadeStand;
namespace LemonadeStandTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]


        public void ReturnNumberOfBoughtWater()
        {
            Player player = new Player();

            //arrange
            player.inventory.water = 20;
            player.store.numberOfWater = 1;
            double numberOfItem = 5;
            double acutalResult;
            double expectedResult = player.inventory.water += (player.store.numberOfWater * numberOfItem);
            //act
            acutalResult = player.BuyingWater(numberOfItem, player.inventory.water);

            //Assert
            Assert.AreEqual(expectedResult, acutalResult);


        }
        [TestMethod]
        public void ReturnNumberOfBoughtLemon()
        {
            Player player = new Player();

            //arrange
            player.inventory.lemon = 20;
            player.store.numberOfLemon = 1;
            double numberOfItem = 2;
            double acutalResult;
            double expectedResult = player.inventory.lemon += (player.store.numberOfLemon * numberOfItem);

            //act
            acutalResult = player.BuyingLemon(numberOfItem, player.inventory.lemon);

            //Assert
            Assert.AreEqual(expectedResult, acutalResult);

        }

        [TestMethod]
        public void GetWeatherType()
        {
            Weather weather = new Weather();


            weather.randomWeatherWithTemperature();


            Assert.IsTrue(weather.weatherType == "Rainy" || weather.weatherType == "Sunny" || weather.weatherType == "Cold");
        }




    }
}
