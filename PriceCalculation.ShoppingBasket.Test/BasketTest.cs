using NUnit.Framework;
using PriceCalculation.ShoppingBasket.Discounts;
using PriceCalculation.ShoppingBasket.Models;
using System.Collections.Generic;

namespace PriceCalculation.ShoppingBasket.Test
{
    public class BasketTest
    {
        private Basket testBasket;

        [SetUp]
        public void Setup()
        {
            testBasket = new Basket(new List<IDiscount> { new Buy2Get50PercentOff("Butter", "Bread"), new Buy3GetOneFree("Milk") });
        }

        [Test]
        public void BasketButter1milk1bread1()
        {
            var butter = new Product() { Name = "Butter", Price = new Price() { ItemCost = 0.80M }, Amount = 1 };
            var milk = new Product() { Name = "Milk", Price = new Price() { ItemCost = 1.15M }, Amount = 1 };
            var bread = new Product() { Name = "Bread", Price = new Price() { ItemCost = 1M }, Amount = 1 };
            testBasket.Add(butter);
            testBasket.Add(milk);
            testBasket.Add(bread);
            var testResult = testBasket.GetTotalCostWihtDiscount();
            Assert.AreEqual(testResult, 2.95M);
        }

        [Test]
        public void BasketButter2bread2()
        {
            var butter = new Product() { Name = "Butter", Price = new Price() { ItemCost = 0.80M }, Amount = 2 };
            var bread = new Product() { Name = "Bread", Price = new Price() { ItemCost = 1M }, Amount = 2 };
            testBasket.Add(butter);
            testBasket.Add(bread);
            var testResult = testBasket.GetTotalCostWihtDiscount();
            Assert.AreEqual(testResult, 3.10M);
        }

        [Test]
        public void BasketMilk4()
        {
            var milk = new Product() { Name = "Milk", Price = new Price() { ItemCost = 1.15M }, Amount = 4 };
            testBasket.Add(milk);
            var testResult = testBasket.GetTotalCostWihtDiscount();
            Assert.AreEqual(testResult, 3.45M);
        }

        [Test]
        public void BasketButter2milk8bread1()
        {
            var butter = new Product() { Name = "Butter", Price = new Price() { ItemCost = 0.80M }, Amount = 2 };
            var milk = new Product() { Name = "Milk", Price = new Price() { ItemCost = 1.15M }, Amount = 8 };
            var bread = new Product() { Name = "Bread", Price = new Price() { ItemCost = 1M }, Amount = 1 };
            testBasket.Add(butter);
            testBasket.Add(milk);
            testBasket.Add(bread);
            var testResult = testBasket.GetTotalCostWihtDiscount();
            Assert.AreEqual(testResult, 9.00M);
        }
    }
}
