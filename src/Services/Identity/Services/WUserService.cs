//namespace Identity.WebApi.Services
//{
//    using Identity.WebApi.Helpers;
//    using Identity.WebApi.Models;
//    using Microsoft.Extensions.Options;
//    using Microsoft.IdentityModel.Tokens;
//    using System;
//    using System.Collections.Generic;
//    using System.IdentityModel.Tokens.Jwt;
//    using System.Linq;
//    using System.Security.Claims;
//    using System.Text;
//    using System.Threading.Tasks;
//    using Transaction.Framework.Domain;
//    using Transaction.Framework.Services.Interface;

//    public interface IWUserService
//    {
//        Task<Models.SecurityToken> Authenticate(string username, string password);
//        Task<User> Register(User user);
//    }

//    public class WUserService : IWUserService
//    {
//        private readonly AppSettings _appSettings;
//        private readonly IUserService _userService;
//        //private readonly 

//        public WUserService(IOptions<AppSettings> appSettings, IUserService userService)
//        {
//            _appSettings = appSettings.Value;
//            _userService = userService;
//        }

//        public async Task<Models.SecurityToken> Authenticate(string username, string password)
//        {
//            var user = await _userService.GetUser(username, password);

//            // return null if user not found
//            if (user == null)
//                return null;

//            // authentication successful so generate jwt token
//            var tokenHandler = new JwtSecurityTokenHandler();
//            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
//            var tokenDescriptor = new SecurityTokenDescriptor
//            {
//                Subject = new ClaimsIdentity(new Claim[]
//                {
//                    new Claim("Id", user.Id.ToString()),
//                    new Claim("Username", user.Username)
//                }),
//                Expires = DateTime.UtcNow.AddDays(7),
//                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
//            };
//            var token = tokenHandler.CreateToken(tokenDescriptor);
//            var jwtSecurityToken = tokenHandler.WriteToken(token);

//            return new Models.SecurityToken() { auth_token = jwtSecurityToken };
//        }

//        public async Task<User> Register(User user)
//        {
//            return await _userService.SaveUser(user);
//        }
//    }
//}
