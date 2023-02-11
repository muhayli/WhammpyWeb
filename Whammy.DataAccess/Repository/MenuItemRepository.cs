using System;
using Microsoft.EntityFrameworkCore;
using Whammy.DataAccess.Data;
using Whammy.DataAccess.Repository.IRepository;
using Whammy.Models;

namespace Whammy.DataAccess.Repository
{
    public class MenuItemRepository : Repository<MenuItem>, IMenuItemRepository
    {
        private readonly AppDbContext dbContext;

        public MenuItemRepository(AppDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public IEnumerable<MenuItem> GetDetails()
        {
            return dbContext.MenuItems.Include("Category").Include("FoodType").ToList();
        }

        public void Update(MenuItem menuItem)
        {
            var obj = dbContext.MenuItems.FirstOrDefault(o => o.Id == menuItem.Id);
            obj.Name = menuItem.Name;
            obj.Description = menuItem.Description;
            obj.Price = menuItem.Price;
            obj.CategoryId = menuItem.CategoryId;
            obj.FoodTypeId = menuItem.FoodTypeId;
            if (obj.Image != null)
            {
                obj.Image = menuItem.Image;
            }
        }
    }
}

