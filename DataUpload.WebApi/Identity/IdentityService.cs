namespace DataUpload.WebApi.Services
{
    using Microsoft.AspNetCore.Http;
    using System;
    using System.IdentityModel.Tokens.Jwt;
    using System.Linq;
    using DataUpload.WebApi.Models;

    public class IdentityService : IIdentityService
    {
        private IHttpContextAccessor _context;

        public IdentityService(IHttpContextAccessor context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IdentityModel GetIdentity()
        {
            string authorizationHeader = _context.HttpContext.Request.Headers["Authorization"];

            if (authorizationHeader != null)
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var token = authorizationHeader.Split(" ")[1];
                var paresedToken = tokenHandler.ReadJwtToken(token);

                var userid = paresedToken.Claims
                    .Where(c => c.Type == "userid")
                    .FirstOrDefault();

                var username = paresedToken.Claims
                    .Where(c => c.Type == "username")
                    .FirstOrDefault();

                var email = paresedToken.Claims
                    .Where(c => c.Type == "email")
                    .FirstOrDefault();

                return new IdentityModel() {
                    UserId = Convert.ToInt32(userid.Value),
                    Username = username.Value,
                    Email = email.Value
                };
            }

            throw new ArgumentNullException("userid");
        }
    }
}
