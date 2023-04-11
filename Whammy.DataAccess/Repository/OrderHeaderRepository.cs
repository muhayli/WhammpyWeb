using System;
using Whammy.DataAccess.Data;
using Whammy.DataAccess.Repository.IRepository;
using Whammy.Models;

namespace Whammy.DataAccess.Repository
{
    public class OrderHeaderRepository : Repository<OrderHeader>, IOrderHeaderRepository
    {
        private readonly AppDbContext dbContext;

        public OrderHeaderRepository(AppDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Update(OrderHeader orderHeader)
        {
            dbContext.orderHeaders.Update(orderHeader);
            //var obj = dbContext.orderHeaders.FirstOrDefault(oh => oh.Id == orderHeader.Id);
        }
    }
}

