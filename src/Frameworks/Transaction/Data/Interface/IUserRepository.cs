namespace Transaction.Framework.Data.Interface
{
    using System.Threading.Tasks;
    using Transaction.Framework.Data.Entities;

    public interface IUserRepository
    {
        Task<User> GetUser(string username, string password);
        Task<User> GetUser(int Id);
        Task<User> SaveUser(User user);
        bool RemoveUser(User user);
    }
}
