using NUnit.Framework;
using PriceCalculation.ShoppingBasket.Discounts;
using PriceCalculation.ShoppingBasket.Models;
using System.Collections.Generic;

namespace PriceCalculation.ShoppingBasket.Test
{
    public class DiscountTest
    {
        private IDiscount milkDiscount;
        private IDiscount butterBreadDiscount;

        [SetUp]
        public void Setup()
        {
            milkDiscount = new Buy3GetOneFree("Milk");
            butterBreadDiscount = new Buy2Get50PercentOff("Butter", "Bread");
        }

        [Test]
        public void DiscountButter1milk1bread1()
        {
            var butter = new Product() { Name = "Butter", Price = new Price() { ItemCost = 0.80M }, Amount = 1 };
            var milk = new Product() { Name = "Milk", Price = new Price() { ItemCost = 1.15M }, Amount = 1 };
            var bread = new Product() { Name = "Bread", Price = new Price() { ItemCost = 1M }, Amount = 1 };
            var products = new List<Product>
            {
                butter,
                milk,
                bread
            };
            var milkDiscountResult = milkDiscount.GetDiscount(products);
            Assert.AreEqual(milkDiscountResult, 0);
            var butterBreadDiscountResult = butterBreadDiscount.GetDiscount(products);
            Assert.AreEqual(butterBreadDiscountResult, 0);
        }

        [Test]
        public void DiscountButter2bread2()
        {
            var butter = new Product() { Name = "Butter", Price = new Price() { ItemCost = 0.80M }, Amount = 2 };
            var bread = new Product() { Name = "Bread", Price = new Price() { ItemCost = 1M }, Amount = 2 };
            var products = new List<Product>
            {
                butter,
                bread
            };
            var milkDiscountResult = milkDiscount.GetDiscount(products);
            Assert.AreEqual(milkDiscountResult, 0);
            var butterBreadDiscountResult = butterBreadDiscount.GetDiscount(products);
            Assert.AreEqual(butterBreadDiscountResult, 0.5M);
        }

        [Test]
        public void DiscountMilk4()
        {
            var milk = new Product() { Name = "Milk", Price = new Price() { ItemCost = 1.15M }, Amount = 4 };
            var products = new List<Product>
            {
                milk
            };
            var milkDiscountResult = milkDiscount.GetDiscount(products);
            Assert.AreEqual(milkDiscountResult, 1.15M);
            var butterBreadDiscountResult = butterBreadDiscount.GetDiscount(products);
            Assert.AreEqual(butterBreadDiscountResult, 0);
        }

        [Test]
        public void DiscountButter2milk8bread1()
        {
            var butter = new Product() { Name = "Butter", Price = new Price() { ItemCost = 0.80M }, Amount = 2 };
            var milk = new Product() { Name = "Milk", Price = new Price() { ItemCost = 1.15M }, Amount = 8 };
            var bread = new Product() { Name = "Bread", Price = new Price() { ItemCost = 1M }, Amount = 1 };
            var products = new List<Product>
            {
                butter,
                milk,
                bread
            };
            var milkDiscountResult = milkDiscount.GetDiscount(products);
            Assert.AreEqual(milkDiscountResult, 2.3M);
            var butterBreadDiscountResult = butterBreadDiscount.GetDiscount(products);
            Assert.AreEqual(butterBreadDiscountResult, 0.5M);
        }
    }
}
