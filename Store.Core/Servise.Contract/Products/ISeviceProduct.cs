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
        Task<IEnumerable<ProductDto>> GetAllProductAsync();
        Task<IEnumerable<TypeBrandDto>> GetAllBrandAsync();
        Task<IEnumerable<TypeBrandDto>> GetAllTypeAsync();

        Task<ProductDto> GetProductById(int? id);




    }
}
