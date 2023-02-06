using System;
using Whammy.Models;

namespace Whammy.DataAccess.Repository.IRepository
{
    public interface IFoodTypeRepository : IRepository<FoodType>
    {
        void Update(FoodType foodType);
    }
}

