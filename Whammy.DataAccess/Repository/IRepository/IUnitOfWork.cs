using System;
namespace Whammy.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        ICategoryRepository category { get; }
        IFoodTypeRepository foodType { get; }

        void Save();
        //void Dispose();

    }
}

