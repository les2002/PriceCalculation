using System;
using System.Collections.Generic;
using System.Text;

namespace PriceCalculation.ShoppingBasket.Models
{
    public class Product
    {
        // if we have db then we should use id of product instead of name
        public string Name;
        public int Amount;
        public Price Price;

        public decimal GetTotalPrice()
        {
            if (Price != null)
            {
                return Amount * Price.ItemCost;
            }
            return 0;
        }
    }
}
