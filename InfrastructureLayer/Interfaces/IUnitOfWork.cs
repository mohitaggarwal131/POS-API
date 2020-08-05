using System;
using System.Collections.Generic;
using System.Text;

namespace InfrastructureLayer.Interfaces
{
    public interface IUnitOfWork
    {
        IProductRepository ProductRepository { get; }


        ISaleRepository SaleRepository { get; }

        IUserRepository UserRepository { get; }

        ICategoryRepository CategoryRepository { get; }

        public void Commit();
    }
}
