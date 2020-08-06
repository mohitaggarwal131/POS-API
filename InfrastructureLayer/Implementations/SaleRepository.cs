using Entities;
using InfrastructureLayer.Context.Extensions;
using InfrastructureLayer.Interfaces;

namespace InfrastructureLayer.Implementations
{
    public class SaleRepository : GenericRepository<Sale>,
                                                      ISaleRepository
    {
        public SaleRepository(POSContext context) : base(context)
        {
        }
    }
}
