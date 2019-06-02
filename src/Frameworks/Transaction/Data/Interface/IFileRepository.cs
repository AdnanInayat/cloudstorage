namespace Transaction.Framework.Data.Interface
{
    using System.Threading.Tasks;
    using Transaction.Framework.Data.Entities;

    public interface IFileRepository
    {
        Task<File> GetFile(string Filename);
        Task<File> GetFile(int Id);
        Task<File> SaveFile(File File);
        bool RemoveFile(File File);
    }
}
