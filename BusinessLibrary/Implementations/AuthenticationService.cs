using BusinessLayer.Interface;
using DataTransferObject;
using Entities;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using Utility;

namespace BusinessLayer.Implementations
{
    public class AuthenticationService : IAuthenticationService
    {
        /// <summary>
        /// Generate a JWT Token for given user details.
        /// </summary>
        /// <param name="user">user dto</param>
        /// <param name="secretKey">secret key</param>
        /// <returns>JWT token</returns>
        public AuthenticationDto GenerateToken(User user, string secretKey)
        {
            List<Claim> claims = new List<Claim>()
            {
                 new Claim(ClaimTypes.Sid,user.Id.ToString())
            };

            foreach (var roles in user.UserRoles)
            {
                claims.Add(new Claim(ClaimTypes.Role, roles.Role.Name));
            }

            var securityKey = new SymmetricSecurityKey(System.Text.Encoding.Default.GetBytes(secretKey));
            var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
            var token = new JwtSecurityToken
            (
               issuer: Constants.NoIssuerAudience,
               audience: Constants.NoIssuerAudience,
               claims: claims,
               expires: DateTime.Now.AddHours(Constants.JwsExpireTime),
               signingCredentials: signingCredentials
            );

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
