using System.Security.Claims;
using System.Threading.Tasks;
using DigitalOwl.Repository.Entity.Identity;

namespace DigitalOwl.Api.Infrastructure.Auth
{
    public interface IJwtFactory
    {
        Task<string> GenerateEncodedToken(string userName, ClaimsIdentity identity);
        ClaimsIdentity GenerateClaimsIdentity(User user);
    }
}