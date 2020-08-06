using InfrastructureLayer.Context.Extensions;
using InfrastructureLayer.Interfaces;

namespace InfrastructureLayer.Implementations
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly POSContext _context;
        private IProductRepository _productRepository;
        private ISaleRepository _saleRepository;
        private IUserRepository _userRepository;
        private ICategoryRepository _categoryRepository;
        private ISaleProductRepository _saleProductRepository;


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

        public IUserRepository UserRepository
        {
            get
            {
                return _userRepository ??= new UserRepository(_context);
            }
        }

        public ICategoryRepository CategoryRepository
        {
            get
            {
                return _categoryRepository ??= new CategoryRepository(_context);
            }
        }

        public ISaleProductRepository SaleProductRepository
        {
            get
            {
                return _saleProductRepository ??= new SaleProductRepository(_context);
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
