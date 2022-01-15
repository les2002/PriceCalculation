using NUnit.Framework;

namespace PriceCalculation.ShoppingBasket.Test
{
    public class BasketTest
    {
        private Basket testBasket;

        [SetUp]
        public void Setup()
        {
            testBasket = new Basket();
        }

        [Test]
        public void Test1()
        {
            var butter = new Product() { Name = "Butter", Price = 0.80M, Amount = 1 };
            var milk = new Product() { Name = "Milk", Price = 1.15M, Amount = 1 };
            var bread = new Product() { Name = "Bread", Price = 1M, Amount = 1 };
            testBasket.Add(butter);
            testBasket.Add(milk);
            testBasket.Add(bread);
            var testResult = testBasket.GetTotalCostWihtDiscount();
            Assert.AreEqual(testResult, 2.95M);
        }

        [Test]
        public void Test2()
        {
            var butter = new Product() { Name = "Butter", Price = 0.80M, Amount = 2 };
            var bread = new Product() { Name = "Bread", Price = 1M, Amount = 2 };
            testBasket.Add(butter);
            testBasket.Add(bread);
            var testResult = testBasket.GetTotalCostWihtDiscount();
            Assert.AreEqual(testResult, 3.10M);
        }

        [Test]
        public void Test3()
        {
            var milk = new Product() { Name = "Milk", Price = 1.15M, Amount = 4 };
            testBasket.Add(milk);
            var testResult = testBasket.GetTotalCostWihtDiscount();
            Assert.AreEqual(testResult, 3.45M);
        }

        [Test]
        public void Test4()
        {
            var butter = new Product() { Name = "Butter", Price = 0.80M, Amount = 2 };
            var milk = new Product() { Name = "Milk", Price = 1.15M, Amount = 8 };
            var bread = new Product() { Name = "Bread", Price = 1M, Amount = 1 };
            testBasket.Add(butter);
            testBasket.Add(milk);
            testBasket.Add(bread);
            var testResult = testBasket.GetTotalCostWihtDiscount();
            Assert.AreEqual(testResult, 9.00M);
        }
    }
}
