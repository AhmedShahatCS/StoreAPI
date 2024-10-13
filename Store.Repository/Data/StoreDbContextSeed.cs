using Store.Core.Entity;
using Store.Repository.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Store.Repository.Data
{
    public static class StoreDbContextSeed
    {
        public static async Task SeedAsync(StoreDbContext _context)
        {
            //E:\Backend-Rout\Api\Demo\Store\Store.Repository\Data\DataSeeding
            //read data  bfrom file
            if (_context.Brands.Count() == 0)
            {

                var branddata = File.ReadAllText(@"..\Store.Repository\Data\DataSeeding\brands.json");
                var brand = JsonSerializer.Deserialize<List<ProductBrand>>(branddata);
                if (brand is not null && brand.Count() > 0)
                {
                    await _context.Brands.AddRangeAsync(brand);
                    await _context.SaveChangesAsync();
                }

            }

            if (_context.Types.Count() == 0)
            {

                var typesdata = File.ReadAllText(@"..\Store.Repository\Data\DataSeeding\types.json");
                var types = JsonSerializer.Deserialize<List<ProductType>>(typesdata);
                if (types is not null && types.Count() > 0)
                {
                    await _context.Types.AddRangeAsync(types);
                    await _context.SaveChangesAsync();
                }

            }

            if (_context.Products.Count() == 0)
            {

                var productsdata = File.ReadAllText(@"..\Store.Repository\Data\DataSeeding\products.json");
                var products = JsonSerializer.Deserialize<List<Product>>(productsdata);
                if (products is not null && products.Count() > 0)
                {
                    await _context.Products.AddRangeAsync(products);
                    await _context.SaveChangesAsync();
                }

            }
        }
    }
}
