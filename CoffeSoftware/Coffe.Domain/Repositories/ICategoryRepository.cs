using Coffe.Domain.Models;
using Coffe.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Coffe.Domain.Repositories
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Task<Category> FindByNameAsync(string name);
    }
}
