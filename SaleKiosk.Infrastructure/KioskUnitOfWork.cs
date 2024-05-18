using SaleKiosk.Domain.Contracts;

namespace SaleKiosk.Infrastructure
{
    // implementacja Unit of Work
    public class KioskUnitOfWork : IKioskUnitOfWork
    {
        private readonly KioskDbContext _context;

        public IProductRepository ProductRepository { get; }

        public KioskUnitOfWork(KioskDbContext context, IProductRepository productRepository)
        {
            this._context = context;
            this.ProductRepository = productRepository;

        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
