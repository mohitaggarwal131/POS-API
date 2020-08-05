using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataTransferObject
{
    public class UserDto
    {
        /// <summary>
        /// Get or set UserName
        /// </summary>
        [Required]
        public string UserName { get; set; }

        /// <summary>
        /// Get or set user last name
        /// </summary>
        [Required]
        public string Password { get; set; }
    }
}
