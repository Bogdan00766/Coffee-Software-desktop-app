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

        public Task<List<Product>> FindAllFavoriteAsync(int id)
        {
            List<Product> AddProduct = new List<Product>();
            var tmp = _dbContext.Favorite.Where(x => x.User.Id == id).ToList();
            foreach (Favorite fav in tmp)
            {
                Product product = _dbContext.Product.Where(x => x.Id == fav.Id).FirstOrDefault();
                AddProduct.Add(product);
            }
            return Task.FromResult(AddProduct);
        } 

        public Task<bool> ClearAllForUserAsync(int id)
        {
            List<Product> productsList = new List<Product>();
            //return _dbContext.Product.Where(x => x.OrderListProducts.OrderList.User.Id == id).toList();
            var tmp = _dbContext.OrderListProduct.Where(x => x.OrderList.User.Id == id).ToList();
            foreach (OrderListProduct olp in tmp)
            {
                _dbContext.OrderListProduct.Remove(olp);
            }
            return Task.FromResult(true);
        }
    }
}
