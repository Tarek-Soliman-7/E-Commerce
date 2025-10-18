using Shared;
using Shared.Dtos;
using Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstraction
{
    public interface IProductService
    {
        //Get All Products
        Task<IEnumerable<ProductDto>> GetAllProductsAsync(ProductSpecificationParameters parameters);

        //Get Products By Id
        Task<ProductDto?> GetProductsByIdAsync(int Id);

        //Get All Types
        Task<IEnumerable<TypeDto>> GetAllTypesAsync();

        ///Get All Brands
        Task<IEnumerable<BrandDto>> GetAllBrandsAsync();

    }
}
