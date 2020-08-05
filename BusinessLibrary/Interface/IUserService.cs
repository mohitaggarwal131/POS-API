using DataTransferObject;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interface
{
    public interface IUserService
    {
        /// <summary>
        /// Retrieves a user for the user credentials.
        /// </summary>
        /// <param name="userDto">User dto</param>
        /// <returns>User</returns>
        User GetByUserCredentials(UserDto userDto);
    }
}
