using System;
using System.Collections.Generic;
using System.Text;

namespace InfrastructureLayer.Interfaces
{
    public interface IUnitOfWork
    {
        IProductRepository ProductRepository { get; }


        ISaleRepository SaleRepository { get; }

        public void Commit();
    }
}
