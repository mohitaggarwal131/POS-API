using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utility.Enums;

namespace POSApi.Helpers
{
    public class AuthorizeUserAttribute : AuthorizeAttribute
    {
        #region Constructor

        public AuthorizeUserAttribute(params UserRoleEnum[] roles)
        {
            Roles = string.Join(",", roles.Select(r => r.ToString()));
        }

        #endregion
    }
}
