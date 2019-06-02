using Identity.WebApi.Helpers;
using Identity.WebApi.Models;
//using Identity.WebApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Transaction.Framework.Domain;
using Transaction.Framework.Services.Interface;

namespace Identity.WebApi.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly AppSettings _appSettings;
        private readonly IUserService _userService;

        public UserController(IOptions<AppSettings> appSettings, IUserService userService)
        {
            _appSettings = appSettings.Value;
            _userService = userService;
        }
        [AllowAnonymous]
        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] Login loginParam)
        {
            //var file = Request.Form.Files[0];
            var user = await _userService.GetUser(loginParam.Username, loginParam.Password);

            // return null if user not found
            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim("userid", user.Id.ToString()),
                    new Claim("username", user.Username),
                    new Claim("email", user.Email),

                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var jwtSecurityToken = tokenHandler.WriteToken(token);

            var returnToken = new Models.SecurityToken() { auth_token = jwtSecurityToken };

            if (returnToken == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(returnToken);
        }
        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserResult registerParam)
        {
            var user = await _userService.SaveUser(registerParam);

            if (user == null)
                return BadRequest(new { message = "Registeration unsuccessfull" });

            return Ok(user);
        }
    }
}
