using DataTransferObject;
using Entities;

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
