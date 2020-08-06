using Entities;
using InfrastructureLayer.Context.Extensions;
using InfrastructureLayer.Interfaces;

namespace InfrastructureLayer.Implementations
{
    public class ProductRepository : GenericRepository<Product>,
                                                      IProductRepository
    {
        public ProductRepository(POSContext context) : base(context)
        {
        }
    }
}
