using Coffe.Domain.Models;
using Coffe.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coffe.Infrastructure.Repositories
{
    class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(CoffeDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Category> FindByNameAsync(string name)
        {
            var cat = _dbContext.Category.Where(x => x.Name == name).FirstOrDefault();
            return await Task.FromResult(cat);
        }
        public new Category Create(Category category)
        {
            var existingCategory = _dbContext.Category
                .Where(x => x.Name == category.Name)
                .FirstOrDefault();
            if (existingCategory == null)
            {
                _dbContext.Add(category);
                return category;
            }
            else
            {
                return existingCategory;
            }

        }
    }
}