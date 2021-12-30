using Coffe.Domain.Models;
using Coffe.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Coffe.Infrastructure.Repositories
{
    class ShopRepository : Repository<Shop>, IShopRepository
    {
        public ShopRepository(CoffeDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
