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

        public Task<bool> checkPasswordAsync(string email, string password)
        {
            var user = _dbContext.User.Where(x => x.Email == email).FirstOrDefault();
            if(user != null && user.Password == password) return Task.FromResult(true);
            else return Task.FromResult(false);
        }

        public Task<User> FindByEmailAsync(string email)
        {
            var user = _dbContext.User.Where(x => x.Email == email).FirstOrDefault();
            return Task.FromResult(user);
        }

        public Task<bool> isRegisteredAsync(string email)
        {
            var user = _dbContext.User.Where(x => x.Email == email).FirstOrDefault();
            if (user != null) return Task.FromResult(true);
            else return Task.FromResult(false);
        }

        public async Task<User> MakeAdmin(int user_id)
        {
            var user = _dbContext.User.Where(x => x.Id == user_id).FirstOrDefault();
            user.IsAdmin = true;
            await _dbContext.SaveChangesAsync();
            return await Task.FromResult(user);
        }
    }
}
