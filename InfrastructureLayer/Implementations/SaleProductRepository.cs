using Entities;
using InfrastructureLayer.Context.Extensions;
using InfrastructureLayer.Interfaces;

namespace InfrastructureLayer.Implementations
{
    public class SaleProductRepository : GenericRepository<SaleProduct>,
                                                      ISaleProductRepository
    {
        public SaleProductRepository(POSContext context) : base(context)
        {
        }
    }
}
