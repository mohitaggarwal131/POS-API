using BusinessLayer.Interface;
using DataTransferObject;
using Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Utility;

namespace BusinessLayer.Implementations
{
    public class AuthenticationService : IAuthenticationService
    {
        #region Private Fields

        private readonly IConfiguration _configuration;

        #endregion

        /// <summary>
        /// Constructor to inject configuration in the authentication service
        /// </summary>
        /// <param name="configuration">instance of configuration</param>
        public AuthenticationService(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        /// <summary>
        /// Generate a JWT Token for given user details.
        /// </summary>
        /// <param name="user">user</param>
        /// <param name="secretKey">secret key</param>
        /// <returns>AuthenticationDto</returns>
        public AuthenticationDto GenerateToken(User user, string secretKey)
        {
            List<Claim> claims = new List<Claim>()
            {
                 new Claim(ClaimTypes.Name,user.FirstName)
            };

            foreach (var roles in user.UserRoles)
            {
               claims.Add(new Claim(ClaimTypes.Role, roles.Role.Name));
            }

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
            var token = new JwtSecurityToken(_configuration[Constants.IssuerKey],
                _configuration[Constants.IssuerKey],
                claims,
                expires: DateTime.Now.AddHours(Constants.JwsExpireTime),
                signingCredentials: signingCredentials);

            var authentication = new AuthenticationDto()
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                UserId = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName
            };
            return authentication;
        }
    }
}
