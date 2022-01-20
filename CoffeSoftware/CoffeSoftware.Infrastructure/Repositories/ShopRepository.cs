using Coffe.Domain.Models;
using Coffe.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Coffe.Infrastructure.Repositories
{
    class ShopRepository : Repository<Shop>, IShopRepository
    {
        public ShopRepository(CoffeDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public new Shop Create(Shop shop)
        {
            var existingShop = _dbContext.Shop
                .Where(x => x.Name == shop.Name)
                .FirstOrDefault();
            if (existingShop == null)
            {
                _dbContext.Add(shop);
                return shop;
            }
            else
            {
                return existingShop;
            }

        }
    }
}
