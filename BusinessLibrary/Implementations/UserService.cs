using BusinessLayer.Interface;
using DataTransferObject;
using Entities;
using InfrastructureLayer.Interfaces;
using System.Linq;

namespace BusinessLayer.Implementations
{
    public class UserService : IUserService
    {
        #region Private Fields

        private readonly IUnitOfWork _unitOfWork;

        #endregion

        #region Constructor

        /// <summary>
        /// Parameterized Constructor
        /// </summary>
        /// <param name="unitOfWork">Object of UnitOfWork</param>
        public UserService( IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        #endregion

        /// <summary>
        /// Retrieves a user for the user credentials.
        /// </summary>
        /// <param name="userDto">User dto</param>
        /// <returns>User</returns>
        public User GetByUserCredentials(UserDto userDto)
        {
           dynamic user = _unitOfWork.UserRepository.FindBy(u => u.UserName == userDto.UserName && u.Password == userDto.Password).FirstOrDefault();
            return user;
        }
    }
}
