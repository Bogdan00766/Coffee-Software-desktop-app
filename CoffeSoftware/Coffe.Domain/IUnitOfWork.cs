using Coffe.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Coffe.Domain
{
    public interface IUnitOfWork : IDisposable
    {
        IAddressRepository AddressRepository { get; }
        ICategoryRepository CategoryRepository { get; }
        IOrderListRepository OrderListRepository { get; }
        IProductRepository ProductRepository { get; }
        IShopRepository ShopRepository { get; }
        IUserRepository UserRepository { get; }   
      
        Task SaveAsync();
    }
}
