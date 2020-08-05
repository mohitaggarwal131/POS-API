using Entities;
using InfrastructureLayer.Context.Extensions;
using InfrastructureLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

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
