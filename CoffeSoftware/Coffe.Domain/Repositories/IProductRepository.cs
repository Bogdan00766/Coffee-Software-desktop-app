using Coffe.Domain.Models;
using Coffe.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Coffe.Domain.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<List<Product>> FindAllForUserAsync(int id);
        Task<bool> ClearAllForUserAsync(int id);
        Task<List<Product>> FindAllFavoriteAsync(int id);
        Task<Product> FindByNameAsync(string name);
    }
}
