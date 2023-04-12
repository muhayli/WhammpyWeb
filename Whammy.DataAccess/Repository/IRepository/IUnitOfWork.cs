using System;
namespace Whammy.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        ICategoryRepository category { get; }
        IFoodTypeRepository foodType { get; }
        IMenuItemRepository menuItem { get; }
        IShoppingCartRepository shoppingCart { get; }
        IOrderHeaderRepository orderHeader { get; }
        IOrderDetailRepository orderDetail { get; }
        IAppUserRepository appUser { get; }

        void Save();
        //void Dispose();

    }
}

