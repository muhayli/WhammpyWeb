using System;
using Whammy.Models;

namespace Whammy.DataAccess.Repository.IRepository
{
    public interface IShoppingCartRepository : IRepository<ShoppingCart>
    {
        int IncrementCount(ShoppingCart shoppingCart, int count);
        int decrementCount(ShoppingCart shoppingCart, int count);
    }
}

