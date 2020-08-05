using Entities;
using InfrastructureLayer.Context.Extensions;
using InfrastructureLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace InfrastructureLayer.Implementations
{
    public class UserRepository : GenericRepository<User>,
                                                      IUserRepository
    {
        public UserRepository(POSContext context) : base(context)
        {
        }
    }
}
