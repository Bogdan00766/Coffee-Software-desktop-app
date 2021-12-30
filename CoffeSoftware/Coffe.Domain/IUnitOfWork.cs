using Coffe.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Coffe.Domain
{
    public interface IUnitOfWork : IDisposable
    {
        //ICategoryRepository CategoryRepository { get; }
        //IProductRepository ProductRepository { get; }

        Task SaveAsync();
    }
}
