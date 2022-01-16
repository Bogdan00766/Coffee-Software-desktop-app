using Coffe.Domain.Models;
using Coffe.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Coffe.Domain.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        Task <bool> isRegisteredAsync(string email);
        Task<bool> checkPasswordAsync(string email, string password);
        Task<User> FindByEmailAsync(string email);
    }
}
