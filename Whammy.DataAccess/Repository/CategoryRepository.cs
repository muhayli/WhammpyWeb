using System;
using Whammy.DataAccess.Data;
using Whammy.Models;

namespace Whammy.DataAccess.Repository.IRepository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private readonly AppDbContext dbContext;

        public CategoryRepository(AppDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Save()
        {
            dbContext.SaveChanges();
        }

        public void Update(Category category)
        {
            var obj = dbContext.Categories.Find(category.Id);

            obj.Name = category.Name;
            obj.DisplayOrder = category.DisplayOrder;
            //if (obj != null)
            //{
            //    dbContext.Update(category);
            //}
            //this.Save();

        }
    }
}

