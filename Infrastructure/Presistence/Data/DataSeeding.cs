using Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Presistence.Data
{
    public class DataSeeding(StoreDbContext _dbContext) : IDataSeeding
    {
        public  async Task SeedDataAsync()
        {
            try
            {
                var pendingMigrations = await _dbContext.Database.GetPendingMigrationsAsync();
                //Any Pending Migration ==> apply database
                if (pendingMigrations.Any())
                {
                    await _dbContext.Database.MigrateAsync();
                }

                if (!_dbContext.ProductBrands.Any())
                {
                    //var ProductBrandData = File.ReadAllText("C:\\Users\\qal3a\\OneDrive\\Documents\\.NET Course\\C#\\E-Commerce\\Infrastructure\\Presistence\\Data\\DataSeed\\brands.json");
                    var productBrandsData = File.OpenRead("..\\Infrastructure\\Presistence\\Data\\DataSeed\\brands.json");
                    // json ==> C# object [List<ProductBrand>]
                    var productBrands =await JsonSerializer.DeserializeAsync<List<ProductBrand>>(productBrandsData);
                    if (productBrands is not null && productBrands.Any())
                    {
                        await _dbContext.ProductBrands.AddRangeAsync(productBrands);
                    }
                }
                if (!_dbContext.ProductTypes.Any())
                {
                    var productTypesData = File.OpenRead("..\\Infrastructure\\Presistence\\Data\\DataSeed\\types.json");
                    // json ==> C# object [List<ProductType>]
                    var productTypes = await JsonSerializer.DeserializeAsync<List<ProductType>>(productTypesData);
                    if (productTypes is not null && productTypes.Any())
                    {
                       await _dbContext.ProductTypes.AddRangeAsync(productTypes);
                    }
                }
                if (!_dbContext.Products.Any())
                {
                    var productData = File.OpenRead("..\\Infrastructure\\Presistence\\Data\\DataSeed\\products.json");
                    // json ==> C# object [List<Product>]
                    var products =await JsonSerializer.DeserializeAsync<List<Product>>(productData);
                    if (products is not null && products.Any())
                    {
                       await _dbContext.Products.AddRangeAsync(products);
                    }
                }
               await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                //Handle ex
            }
        }
    }
}
