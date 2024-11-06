using Store.Core.Dtos.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Core.Servise.Contract.Products
{
    public interface ISeviceProduct
    {
        Task<IReadOnlyList<ProductDto>> GetAllProductAsync(string? sort, int? Brandid, int? Typeid);
        Task<IReadOnlyList<TypeBrandDto>> GetAllBrandAsync();
        Task<IReadOnlyList<TypeBrandDto>> GetAllTypeAsync();

        Task<ProductDto> GetProductById(int? id);




    }
}
