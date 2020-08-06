using Entities;
using InfrastructureLayer.Context.Extensions;
using InfrastructureLayer.Interfaces;

namespace InfrastructureLayer.Implementations
{
    public class CategoryRepository : GenericRepository<Category>,
                                                      ICategoryRepository
    {
        public CategoryRepository(POSContext context) : base(context)
        {
        }
    }
}
