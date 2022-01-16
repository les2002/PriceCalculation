using PriceCalculation.ShoppingBasket.Models;

namespace PriceCalculation.ShoppingBasket
{
    public interface IBasket
    {
        void Add(Product product);
        decimal GetTotalCostWihtDiscount();
    }
}