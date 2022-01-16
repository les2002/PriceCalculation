using PriceCalculation.ShoppingBasket.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PriceCalculation.ShoppingBasket.Discounts
{
    public class Buy2Get50PercentOff : IDiscount
    {
        private readonly string BuyProductName;
        private readonly string GetProductName;

        public Buy2Get50PercentOff(string buyProductName, string getProductName)
        {
            GetProductName = getProductName;
            BuyProductName = buyProductName;
        }
        public decimal GetDiscount(List<Product> products)
        {
            var foundButter = products.FirstOrDefault(x => string.Equals(x.Name, BuyProductName, StringComparison.OrdinalIgnoreCase));
            var foundBread = products.FirstOrDefault(x => string.Equals(x.Name, GetProductName, StringComparison.OrdinalIgnoreCase));
            var discount = 0M;
            if (foundButter != null && foundBread != null)
            {
                var discountBread = Math.Abs(foundButter.Amount / 2);
                var discountButter = Math.Min(discountBread, foundBread.Amount);
                discount = Enumerable.Range(0, discountButter).Sum(i => foundBread.Price.ItemCost / 2);
            }
            return discount;
        }
    }
}
