using AutoMapper;
using SaleKiosk.Domain.Contracts;
using SaleKiosk.Domain.Exceptions;
using SaleKiosk.Domain.Models;
using SaleKiosk.SharedKernel.Dto;

namespace SaleKiosk.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IKioskUnitOfWork _uow;
        private readonly IMapper _mapper;

        public ProductService(IKioskUnitOfWork unitOfWork, IMapper mapper)
        {
            this._uow = unitOfWork;
            this._mapper = mapper;
        }

        public int Create(CreateProductDto dto)
        {
            if (dto == null)
            {
                throw new BadRequestException("Product is null");
            }

            var id = _uow.ProductRepository.GetMaxId() + 1;
            var product = _mapper.Map<Product>(dto);
            product.Id = id;

            _uow.ProductRepository.Insert(product);
            _uow.Commit();

            return id;
        }

        public void Delete(int id)
        {
            var product = _uow.ProductRepository.Get(id);
            if (product == null)
            {
               throw new NotFoundException("Product not found");
            }

            _uow.ProductRepository.Delete(product);
            _uow.Commit();
        }

        public List<ProductDto> GetAll()
        {
            var products = _uow.ProductRepository.GetAll();

            List<ProductDto> result = _mapper.Map<List<ProductDto>>(products);
            return result;
        }

        public ProductDto GetById(int id)
        {
            if (id <= 0)
            {
                throw new BadRequestException("Id is less than zero");
            }

            var product = _uow.ProductRepository.Get(id);
            if (product == null)
            {
                throw new NotFoundException("Product not found");
            }

            var result = _mapper.Map<ProductDto>(product);
            return result;
        }

        public void Update(UpdateProductDto dto)
        {
            if (dto == null)
            {
                throw new BadRequestException("No product data");
            }

            var product = _uow.ProductRepository.Get(dto.Id);
            if (product == null)
            {
                throw new NotFoundException("Product not found");
            }

            product.Name = dto.Name;
            product.Description = dto.Desc;
            product.UnitPrice = dto.UnitPrice;

            _uow.Commit();
        }
    }
}
