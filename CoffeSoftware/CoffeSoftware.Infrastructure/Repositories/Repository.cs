using Coffe.Domain.SeedWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Coffe.Infrastructure.Repositories
{
    public class Repository<T> : IRepository<T> where T : Entity
    {
        protected CoffeDbContext _dbContext;

        public Repository(CoffeDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public T Create(T e)
        {
            _dbContext.Add(e);
            return e;
        }

        public T Delete(T e)
        {
            _dbContext.Remove(e);
            return e;
        }

        public async Task<List<T>> FindAllAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task<T> FindByIdAsync(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public T Update(T e)
        {
            _dbContext.Entry(e).State = EntityState.Modified;
            _dbContext.Update(e);
            return e;
        }

    }
}
