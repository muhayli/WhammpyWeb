using System;
using Whammy.DataAccess.Data;
using Whammy.Models;

namespace Whammy.DataAccess.Repository.IRepository
{
    public class OrderDetailRepository : Repository<OrderDetail>, IOrderDetailRepository
    {
        private readonly AppDbContext dbContext;

        public OrderDetailRepository(AppDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }


        public void Update(OrderDetail orderDetail)
        {
            dbContext.orderDetails.Update(orderDetail);
        }
    }
}

