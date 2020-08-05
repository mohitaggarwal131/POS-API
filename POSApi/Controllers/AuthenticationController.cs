using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Interface;
using DataTransferObject;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Utility;
using Utility.CustomException;

namespace POSApi.Controllers
{
    [Route("authentication")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        #region Private Fields

        private readonly IAuthenticationService _authenticationService;
        private readonly IUserService _userService;
        private readonly string _secretKey;
        private readonly ILogger<AuthenticationController> _logger;

        #endregion

        /// <summary>
        /// Parameterized constructor
        /// </summary>
        /// <param name="authenticationService">authenticationService instance</param>
        /// <param name="config">IConfiguration instance</param>
        /// <param name="userService">userService instance</param>
        /// <param name="logger">logger instance of authenticationController</param>
        public AuthenticationController(IAuthenticationService authenticationService, IConfiguration config, IUserService userService, ILogger<AuthenticationController> logger)
        {
            _authenticationService = authenticationService;
            _userService = userService;
            _secretKey = config[Constants.SecretKey];
            _logger = logger;
        }

        #region Public Methods

        /// <summary>
        /// Create and return JWT token for a user
        /// </summary>
        /// <param name="userDetails">Username and password</param>
        /// <returns>JWT</returns>
        [HttpPost]
        [Route("authentication-token")]
        public IActionResult GetAuthenticationToken(UserDto userDetails)
        {
            try
            {
                var user = _userService.GetByUserCredentials(userDetails);
                if (user == null)
                {
                    return Unauthorized();
                }
                var jwtToken = _authenticationService.GenerateToken(user, _secretKey);
                return Ok(jwtToken);
            }
            catch (CustomException exception)
            {
                _logger.LogError(exception.Message);
                return StatusCode(exception.ErrorDetails.StatusCode, exception.ErrorDetails);
            }
        }

        #endregion
    }
}
