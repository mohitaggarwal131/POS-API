using BusinessLayer.Implementations;
using BusinessLayer.Interface;
using Entities;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using System;

namespace UnitTests
{
    public class AuthenticationServiceTest
    {
        #region Private Fields

        private IAuthenticationService _authenticationService;

        #endregion

        #region MockData

        private User user = new User
        {
            Id = 1,
            GuId = Guid.NewGuid(),
            FirstName = "Mohit",
            LastName = "Aggarwal",
            UserName = "mohit-131",
            Password = "1234"
        };
        private string secretKey = "b23e32f3bf837fg83fv023f92v23f82vf279vf283vf2$%$E#FR#$!FDedfeiwEWFwe";
        private readonly IConfiguration _config;

        #endregion

        #region Setup

        [SetUp]
        public void Setup()
        {
            _authenticationService = new AuthenticationService(_config);
        }
        #endregion

        #region Tests

        /// <summary>
        /// Test method to check authentication
        /// </summary>
        [Test]
        public void TestAuthentication()
        {
            Assert.DoesNotThrow(() => _authenticationService.GenerateToken(user, secretKey));
        }

        #endregion
    }
}
