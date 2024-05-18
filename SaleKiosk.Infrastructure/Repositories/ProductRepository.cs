using SaleKiosk.Domain.Contracts;
using SaleKiosk.Domain.Models;

namespace SaleKiosk.Infrastructure.Repositories
{
    // Implementacja repozytoriów specyficznych
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly KioskDbContext _kioskDbContext;

        public ProductRepository(KioskDbContext context)
            : base(context)
        {
            _kioskDbContext = context;
        }

        public int GetMaxId()
        {
            return _kioskDbContext.Products.Max(x => x.Id);
        }

        public bool IsInUse(string name)
        {
            var result = _kioskDbContext.Products.Any(x => x.Name == name);
            return result;
        }
    }
}
