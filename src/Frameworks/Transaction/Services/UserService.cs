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

    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public UserService(IUserRepository userRepository, IMapper mapper, ILogger<UserService> logger)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Domain.UserResult> GetUser(string username, string password)
        {
            var user = await _userRepository.GetUser(username, password);
            var res = _mapper.Map<Domain.UserResult>(user);
            return res;
        }

        public async Task<Domain.UserResult> GetUser(int id)
        {
            var user = await _userRepository.GetUser(id);
            var res = _mapper.Map<Domain.UserResult>(user);
            return res;
        }

        public bool RemoveUser(Domain.UserResult user)
        {
            return _userRepository.RemoveUser(_mapper.Map<Data.Entities.User>(user));
        }

        public async Task<Domain.UserResult> SaveUser(Domain.UserResult user)
        {
            return _mapper.Map<Domain.UserResult>(await _userRepository.SaveUser(_mapper.Map<Data.Entities.User>(user)));
        }
    }
}
