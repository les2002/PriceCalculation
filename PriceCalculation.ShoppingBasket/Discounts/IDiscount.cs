using PriceCalculation.ShoppingBasket.Models;
using System.Collections.Generic;

namespace PriceCalculation.ShoppingBasket.Discounts
{
    public interface IDiscount
    {
        decimal GetDiscount(List<Product> products);
    }
}