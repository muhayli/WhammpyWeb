using System;
using Whammy.Models;

namespace Whammy.DataAccess.Repository.IRepository
{
    public interface IMenuItemRepository : IRepository<MenuItem>
    {
        void Update(MenuItem menuItem);
    }
}

