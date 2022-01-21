using Coffe.Domain.Models;
using Coffe.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
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



        public async Task<List<Product>> SearchAllAsync(string name)
        {
            return await _dbContext.Product.Where(x => x.Name.ToLower().Contains(name.ToLower())).ToListAsync();
        }

        public new async Task<List<Product>> FindAllAsync()
        {
            List<Product> output = new List<Product>();
            List<Product> list = await _dbContext.Product.ToListAsync();
            foreach(Product prod in list)
            {
                prod.Category = _dbContext.Category.Where(x => x.Products.Contains(prod)).FirstOrDefault();
                prod.Shop = _dbContext.Shop.Where(x => x.Products.Contains(prod)).FirstOrDefault();
                output.Add(prod);
            }
            return await Task.FromResult(output);
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

        public Task<bool> ClearAllFavoriteAsync(int id)
        {
            List<Product> AddProduct = new List<Product>();
            var tmp = _dbContext.Favorite.Where(x => x.User.Id == id).ToList();
            foreach (Favorite fav in tmp)
            {
                _dbContext.Favorite.Remove(fav);
            }
            return Task.FromResult(true);
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

        public async Task<Product> FindByNameAsync(string name)
        {
            Product prod = _dbContext.Product.Where(x => x.Name == name).FirstOrDefault();
            prod.Category = _dbContext.Category.Where(x => x.Products.Contains(prod)).FirstOrDefault();
            prod.Shop = _dbContext.Shop.Where(x => x.Products.Contains(prod)).FirstOrDefault();
            return await Task.FromResult(prod);
        }
    }
}
