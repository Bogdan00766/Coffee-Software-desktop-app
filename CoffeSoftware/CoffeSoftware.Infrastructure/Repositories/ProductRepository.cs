using Coffe.Domain.Models;
using Coffe.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coffe.Infrastructure.Repositories
{
    class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(CoffeDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<List<Product>> FindAllForUserAsync(int id)
        {
            List<Product> productsList = new List<Product>();
            //return _dbContext.Product.Where(x => x.OrderListProducts.OrderList.User.Id == id).toList();
            var tmp = _dbContext.OrderListProduct.Where(x => x.OrderList.User.Id == id).ToList();
            foreach(OrderListProduct olp in tmp)
            {
                Product product = _dbContext.Product.Where(x => x.Id == olp.Id).FirstOrDefault();               
                productsList.Add(product);
            }
            return Task.FromResult(productsList);
        }
    }
}
