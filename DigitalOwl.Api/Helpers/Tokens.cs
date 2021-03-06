using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using DigitalOwl.Api.Infrastructure.Auth;
using Newtonsoft.Json;

namespace DigitalOwl.Api.Helpers
{
    /// <summary>
    /// Class To generate JWT
    /// </summary>
    public class Tokens
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="identity"></param>
        /// <param name="jwtFactory"></param>
        /// <param name="userName"></param>
        /// <param name="jwtOptions"></param>
        /// <param name="serializerSettings"></param>
        /// <returns></returns>
        public static async Task<string> GenerateJwt(ClaimsIdentity identity, IJwtFactory jwtFactory, string userName, JwtIssuerOptions jwtOptions, JsonSerializerSettings serializerSettings)
        {
            var response = new
            {
                id = identity.Claims.Single(c => c.Type == "id").Value,
                token = await jwtFactory.GenerateEncodedToken(userName, identity),
                expires_in = (int)jwtOptions.ValidFor.TotalSeconds,
                userName = userName, 
                userRole = identity.Claims.Single(c => c.Type == "rol").Value
            };

            return JsonConvert.SerializeObject(response, serializerSettings);
        }
    }
}