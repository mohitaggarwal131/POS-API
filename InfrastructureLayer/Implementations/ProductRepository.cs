using Entities;
using InfrastructureLayer.Context.Extensions;
using InfrastructureLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

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
