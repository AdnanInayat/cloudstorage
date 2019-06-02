namespace Transaction.Framework.Data.Repositories
{
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Transaction.Framework.Data.Entities;
    using Transaction.Framework.Data.Interface;

    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly DbSet<User> _UserEntity;

        public UserRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _UserEntity = _dbContext.Set<User>();
        }

        public async Task<User> GetUser(string username, string password)
        {
            return await _UserEntity.FirstOrDefaultAsync(o => o.Username == username && o.Password == password);
        }

        public async Task<User> GetUser(int id)
        {
            return await _UserEntity.FirstOrDefaultAsync(o => o.Id == id);
        }

        public bool RemoveUser(User user)
        {
            try
            {
                _UserEntity.Remove(user);
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public async Task<User> SaveUser(User user)
        {
            _dbContext.Entry(user).State = user.Id > 0 ? EntityState.Modified : EntityState.Added;
            await _dbContext.SaveChangesAsync();
            return user;
        }
    }
}
