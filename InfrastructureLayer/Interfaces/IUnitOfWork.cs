namespace InfrastructureLayer.Interfaces
{
    public interface IUnitOfWork
    {
        IProductRepository ProductRepository { get; }


        ISaleRepository SaleRepository { get; }

        IUserRepository UserRepository { get; }

        ICategoryRepository CategoryRepository { get; }

        ISaleProductRepository SaleProductRepository { get; }

        public void Commit();
    }
}
