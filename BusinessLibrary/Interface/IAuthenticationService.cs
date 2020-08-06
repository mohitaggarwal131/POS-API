using DataTransferObject;
using Entities;

namespace BusinessLayer.Interface
{
    public interface IAuthenticationService
    {
        /// <summary>
        /// Generate a JWT Token for given user details.
        /// </summary>
        /// <param name="user">user</param>
        /// <param name="secretKey">secret key</param>
        /// <returns>Authentication Dto</returns>
        AuthenticationDto GenerateToken(User user, string secretKey);
    }
}
