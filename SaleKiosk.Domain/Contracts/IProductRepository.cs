

using SaleKiosk.Domain.Models;

namespace SaleKiosk.Domain.Contracts
{
    // interfejsy repozytoriów specyficznych
    public interface IProductRepository : IRepository<Product>
    {
        int GetMaxId();
        bool IsInUse(string email);
    }
}
