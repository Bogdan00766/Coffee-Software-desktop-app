using Coffe.Domain.Models;
using Coffe.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace Coffe.Domain.Repositories
{
    public interface IAddressRepository : IRepository<Address>
    {
        new Address Create(Address address);
    }
}
