namespace Transaction.Framework.Services.Interface
{
    using System.Threading.Tasks;
    using Transaction.Framework.Domain;

    public interface IFileService
    {
        Task<FileResult> GetFile(string filename);
        Task<FileResult> GetFile(int id);
        Task<FileResult> SaveFile(FileResult file);
        bool RemoveFile(FileResult file);
    }
}
