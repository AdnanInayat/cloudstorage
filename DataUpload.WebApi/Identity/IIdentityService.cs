namespace DataUpload.WebApi.Services
{
    using DataUpload.WebApi.Models;

    public interface IIdentityService
    {
        IdentityModel GetIdentity();
    }
}
