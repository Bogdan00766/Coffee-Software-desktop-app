using Coffe.Domain.Models;
using Coffe.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coffe.Infrastructure.Repositories
{
    class AddressRepository : Repository<Address>, IAddressRepository
    {
        public AddressRepository(CoffeDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public new Address Create(Address address)
        {
            var existingAddress = _dbContext.Address
                .Where(x => x.Street == address.Street)
                .Where(x => x.PostalCode == address.PostalCode)
                .Where(x => x.City == address.City)
                .Where(x => x.Country == address.Country)
                .Where(x => x.State == address.State)
                .FirstOrDefault();
            if(existingAddress == null)
            {
                _dbContext.Add(address);
                return address;
            }
            else
            {
                return existingAddress;
            }

        }

    }
}
