using Coffe.Domain;
using Coffe.Domain.Models;
using Coffe.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coffe.Infrastructure.Repositories
{
    class OrderListProductRepository : Repository<OrderListProduct>, IOrderListProductRepository
    {
        public OrderListProductRepository(CoffeDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

       

    }
}