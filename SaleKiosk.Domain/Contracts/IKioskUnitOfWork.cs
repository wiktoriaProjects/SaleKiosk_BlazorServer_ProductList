namespace SaleKiosk.Domain.Contracts
{
    public interface IKioskUnitOfWork : IDisposable
    {
        IProductRepository ProductRepository { get; }

        void Commit();
    }
}
