using SaleKiosk.SharedKernel.Dto;

namespace SaleKiosk.Application.Services
{
    public interface IProductService
    {
        List<ProductDto> GetAll();
        ProductDto GetById(int id);
        int Create(CreateProductDto dto);
        void Update(UpdateProductDto dto);
        void Delete(int id);
    }
}
