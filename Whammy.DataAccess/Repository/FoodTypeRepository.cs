using System;
using Whammy.DataAccess.Data;
using Whammy.DataAccess.Repository.IRepository;
using Whammy.Models;

namespace Whammy.DataAccess.Repository
{
    public class FoodTypeRepository : Repository<FoodType>, IFoodTypeRepository
    {
        private readonly AppDbContext dbContext;

        public FoodTypeRepository(AppDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Update(FoodType foodType)
        {
            var obj = dbContext.FoodTypes.Find(foodType.Id);
            obj.Name = foodType.Name;
        }
    }
}

