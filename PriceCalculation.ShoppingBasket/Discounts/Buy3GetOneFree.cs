using PriceCalculation.ShoppingBasket.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PriceCalculation.ShoppingBasket.Discounts
{
    public class Buy3GetOneFree : IDiscount
    {
        private readonly string ProductName;

        public Buy3GetOneFree(string productName)
        {
            ProductName = productName;
        }
        public decimal GetDiscount(List<Product> products)
        {
            var foundproduct = products.FirstOrDefault(x => string.Equals(x.Name, ProductName, StringComparison.OrdinalIgnoreCase));
            decimal discount = 0;
            if (foundproduct != null)
            {
                var discountMilk = Math.Abs(foundproduct.Amount / 4);
                discount = discountMilk * foundproduct.Price.ItemCost;
            }
            return discount;
        }
    }
}
