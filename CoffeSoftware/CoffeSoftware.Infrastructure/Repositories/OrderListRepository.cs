using Coffe.Domain.Models;
using Coffe.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Coffe.Infrastructure.Repositories
{
    class OrderListRepository : Repository<OrderList>, IOrderListRepository
    {
        public OrderListRepository(CoffeDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
