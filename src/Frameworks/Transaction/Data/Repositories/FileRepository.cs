namespace Transaction.Framework.Data.Repositories
{
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Transaction.Framework.Data.Entities;
    using Transaction.Framework.Data.Interface;

    public class FileRepository : IFileRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly DbSet<File> _fileEntity;

        public FileRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _fileEntity = _dbContext.Set<File>();
        }

        public async Task<File> GetFile(string filename)
        {
            return await _fileEntity.FirstOrDefaultAsync(o => o.FileName == filename);
        }

        public async Task<File> GetFile(int id)
        {
            return await _fileEntity.FirstOrDefaultAsync(o => o.Id == id);
        }

        public bool RemoveFile(File File)
        {
            try
            {
                _fileEntity.Remove(File);
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public async Task<File> SaveFile(File File)
        {
            _dbContext.Entry(File).State = File.Id > 0 ? EntityState.Modified : EntityState.Added;
            await _dbContext.SaveChangesAsync();
            return File;
        }
    }
}
