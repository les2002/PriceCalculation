using PriceCalculation.ShoppingBasket.Discounts;
using PriceCalculation.ShoppingBasket.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PriceCalculation.ShoppingBasket
{
    public class Basket : IBasket
    {
        private readonly List<Product> Products;
        private readonly List<IDiscount> Discounts;

        public Basket(List<IDiscount> discounts = null)
        {
            Discounts = discounts;
            Products = new List<Product>();
        }

        public void Add(Product product)
        {
            if (product != null)
            {
                var foundProduct = Products.FirstOrDefault(x => string.Equals(x.Name, product.Name, StringComparison.OrdinalIgnoreCase));
                if (foundProduct != null)
                {
                    foundProduct.Amount += product.Amount;
                }
                Products.Add(product);
            }
        }

        private decimal GetTotalCostWihtoutDiscount()
        {
            var cost = Products.Sum(x => x.GetTotalPrice());
            return cost;
        }
        private decimal GetTotalDiscount()
        {
            var totalDiscount = 0M;
            if (Discounts != null)
            {
                foreach (var singleDiscount in Discounts)
                {
                    totalDiscount += singleDiscount.GetDiscount(Products);
                }
            }
            return totalDiscount;
        }

        public decimal GetTotalCostWihtDiscount()
        {
            var totalDiscount = GetTotalDiscount();
            var cost = GetTotalCostWihtoutDiscount();
            return cost - totalDiscount;
        }
    }
}
