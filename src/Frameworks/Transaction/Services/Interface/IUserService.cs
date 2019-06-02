namespace Transaction.Framework.Services.Interface
{
    using System.Threading.Tasks;
    using Transaction.Framework.Domain;

    public interface IUserService
    {
        Task<UserResult> GetUser(string username, string password);
        Task<UserResult> GetUser(int id);
        Task<UserResult> SaveUser(UserResult user);
        bool RemoveUser(UserResult user);
    }
}
