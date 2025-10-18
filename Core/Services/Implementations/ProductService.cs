using AutoMapper;
using Domain.Contracts;
using Domain.Entities.ProductModule;
using Services.Abstraction;
using Services.Specifications;
using Shared;
using Shared.Dtos;
using Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implementations
{
    public class ProductService(IUnitOfWork _unitOfWork, IMapper _mapper) : IProductService
    {
        public async Task<IEnumerable<BrandDto>> GetAllBrandsAsync()
        {
            var Repo = _unitOfWork.GetRepository<ProductBrand, int>();
            var brands = await Repo.GetAllAsync();
            var brandsDto = _mapper.Map<IEnumerable<ProductBrand>, IEnumerable<BrandDto>>(brands);
            return brandsDto;
        }

        public async Task<IEnumerable<ProductDto>> GetAllProductsAsync(ProductSpecificationParameters parameters)
        {
            var specifications = new ProductWithBrandAndTypeSpecifications(parameters);
            var products = await _unitOfWork.GetRepository<Product, int>().GetAllAsync(specifications);
            return _mapper.Map<IEnumerable<Product>, IEnumerable<ProductDto>>(products);
        }

        public async Task<IEnumerable<TypeDto>> GetAllTypesAsync()
        {
            var types = await _unitOfWork.GetRepository<ProductType, int>().GetAllAsync();
            return _mapper.Map<IEnumerable<ProductType>, IEnumerable<TypeDto>>(types);
        }

        public async Task<ProductDto?> GetProductsByIdAsync(int Id)
        {
            var specifications = new ProductWithBrandAndTypeSpecifications(Id);
            var products = await _unitOfWork.GetRepository<Product, int>().GetByIdAsync(specifications);
            return _mapper.Map<Product, ProductDto>(products!);
        }
    }
}
