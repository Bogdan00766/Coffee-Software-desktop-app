using Coffe.Domain.Models;
using Coffe.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coffe.Infrastructure.Repositories
{
    class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(CoffeDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<bool> isRegisteredAsync(string email)
        {
            var user = _dbContext.User.Where(x => x.Email == email).FirstOrDefault();
            if (user != null) return Task.FromResult(true);
            else return Task.FromResult(false);
        }
    }
}
