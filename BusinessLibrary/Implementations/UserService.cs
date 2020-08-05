using BusinessLayer.Interface;
using DataTransferObject;
using Entities;
using InfrastructureLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
        /// <param name="syncUserService">Object of sync user service</param>
        /// <param name="unitOfWork">Object of UnitOfWork</param>
        /// <param name="mapper">Object of mapper</param>
        /// <param name="syncApplicationService">Object of sync application service</param>
        /// <param name="clientService">Object of client service</param>
        /// <param name="groupService">Object of group service</param>
        /// <param name="activityHistoryService">Object of activity history service</param>
        /// <param name="emailService">Object of email service</param>
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
           var user = _unitOfWork.UserRepository.FindBy(u => u.UserName == userDto.UserName && u.Password == userDto.Password).FirstOrDefault();
            return user;
        }
    }
}
