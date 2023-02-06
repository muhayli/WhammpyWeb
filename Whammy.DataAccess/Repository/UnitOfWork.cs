using System;
using Whammy.DataAccess.Data;
using Whammy.DataAccess.Repository.IRepository;

namespace Whammy.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext dbContext;

        public UnitOfWork(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
            category = new CategoryRepository(dbContext);
            foodType = new FoodTypeRepository(dbContext);
        }

        public ICategoryRepository category { get; private set; }
        public IFoodTypeRepository foodType { get; private set; }


        public void Dispose()
        {
            dbContext.Dispose();
        }

        public void Save()
        {
            dbContext.SaveChanges();
        }
    }
}

