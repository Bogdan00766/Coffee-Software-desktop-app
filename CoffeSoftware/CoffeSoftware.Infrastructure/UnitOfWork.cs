using Coffe.Domain;
using Coffe.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Coffe.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private CoffeDbContext _dbContext;
        //public ICategoryRepository CategoryRepository => new CategoryRepository(_dbContext);
        //public IProductRepository ProductRepository => new ProductRepository(_dbContext);

        public UnitOfWork()
        {
            _dbContext = new CoffeDbContext();
            _dbContext.Database.Migrate();
        }


        public async Task SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}
