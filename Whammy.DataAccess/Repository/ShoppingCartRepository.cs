using System;
using Whammy.DataAccess.Data;
using Whammy.DataAccess.Repository.IRepository;
using Whammy.Models;

namespace Whammy.DataAccess.Repository
{
    public class ShoppingCartRepository : Repository<ShoppingCart>, IShoppingCartRepository
    {
        private readonly AppDbContext dbContext;

        public ShoppingCartRepository(AppDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public int decrementCount(ShoppingCart shoppingCart, int count)
        {
            shoppingCart.Count -= count;
            dbContext.SaveChanges();
            return shoppingCart.Count;
        }

        public int IncrementCount(ShoppingCart shoppingCart, int count)
        {
            shoppingCart.Count += count;
            dbContext.SaveChanges();
            return shoppingCart.Count;

        }
    }
}

