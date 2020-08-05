using System;
using System.Collections.Generic;
using System.Text;

namespace DataTransferObject
{
    public class AuthenticationDto
    {
        /// <summary>
        /// Get or set Jwt token
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// Get or set user id
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Get or set user's FirstName
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Get or set user's LastName
        /// </summary>
        public string LastName { get; set; }
    }
}
