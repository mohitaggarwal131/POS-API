using InfrastructureLayer.Context.Extensions;
using InfrastructureLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace InfrastructureLayer.Implementations
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly POSContext _context;
        private IProductRepository _productRepository;
        private ISaleRepository _saleRepository;


        public UnitOfWork(POSContext context)
        {
            _context = context;
        }

        public IProductRepository ProductRepository
        {
            get
            {
                return _productRepository ??= new ProductRepository(_context);
            }
        }


        public ISaleRepository SaleRepository
        {
            get
            {
                return _saleRepository ??= new SaleRepository(_context);
            }
        }

        /// <summary>
        /// Save all the changes made in context to the database
        /// </summary>
        public void Commit()
        {
            _context.SaveChanges();
        }
    }
}
