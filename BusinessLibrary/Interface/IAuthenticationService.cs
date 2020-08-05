using DataTransferObject;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interface
{
    public interface IAuthenticationService
    {
        /// <summary>
        /// Generate a JWT Token for given user details.
        /// </summary>
        /// <param name="user">user dto</param>
        /// <param name="secretKey">secret key</param>
        /// <returns>JWT token</returns>
        AuthenticationDto GenerateToken(User user, string secretKey);
    }
}
