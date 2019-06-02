namespace Transaction.Framework.Services
{
    using AutoMapper;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Threading.Tasks;
    using Transaction.Framework.Data.Entities;
    using Transaction.Framework.Data.Interface;
    using Transaction.Framework.Domain;
    using Transaction.Framework.Services.Interface;

    public class FileService : IFileService
    {
        private readonly IFileRepository _FileRepository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public FileService(IFileRepository FileRepository, IMapper mapper, ILogger<FileService> logger)
        {
            _FileRepository = FileRepository ?? throw new ArgumentNullException(nameof(FileRepository));

        }

        public async Task<Domain.FileResult> GetFile(string filename)
        {
            var file = await _FileRepository.GetFile(filename);
            var res = _mapper.Map<Domain.FileResult>(file);
            return res;
        }

        public async Task<Domain.FileResult> GetFile(int id)
        {
            var file = await _FileRepository.GetFile(id);
            var res = _mapper.Map<Domain.FileResult>(file);
            return res;
        }

        public bool RemoveFile(Domain.FileResult file)
        {
            return _FileRepository.RemoveFile(_mapper.Map<Data.Entities.File>(file));
        }

        public async Task<Domain.FileResult> SaveFile(Domain.FileResult file)
        {
            return _mapper.Map<Domain.FileResult>(await _FileRepository.SaveFile(_mapper.Map<Data.Entities.File>(file)));
        }
    }
}
