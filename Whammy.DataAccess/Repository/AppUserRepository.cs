using System;
using Whammy.DataAccess.Data;
using Whammy.Models;

namespace Whammy.DataAccess.Repository.IRepository
{
    public class AppUserRepository : Repository<AppUser>, IAppUserRepository
    {
        private readonly AppDbContext dbContext;

        public AppUserRepository(AppDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }
    }
}

