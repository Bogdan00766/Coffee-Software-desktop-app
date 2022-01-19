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
        IOrderListProductRepository OrderListProductRepository { get; }
        IProductRepository ProductRepository { get; }
        IShopRepository ShopRepository { get; }
        IPaymentRepository PaymentRepository { get; }
        IFavoriteRepository FavoriteRepository { get; }
        IUserRepository UserRepository { get; }
        Task SaveAsync();
    }
}
