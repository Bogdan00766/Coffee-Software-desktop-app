using Coffe.Domain.Models;
using Coffe.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Coffe.Infrastructure.Repositories
{
    class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(CoffeDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
