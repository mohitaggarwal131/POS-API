using Entities;
using InfrastructureLayer.Context.Extensions;
using InfrastructureLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

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
