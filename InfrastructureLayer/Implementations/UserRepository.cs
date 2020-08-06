using Entities;
using InfrastructureLayer.Context.Extensions;
using InfrastructureLayer.Interfaces;

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
