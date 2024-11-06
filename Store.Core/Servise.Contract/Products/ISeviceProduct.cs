using Store.Core.Dtos.Product;
using Store.Core.Mapping;
using Store.Core.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Core.Servise.Contract.Products
{
    public interface ISeviceProduct
    {
        Task<Pagination<ProductDto>> GetAllProductAsync(ProductSpecParms Parms);
        Task<IReadOnlyList<TypeBrandDto>> GetAllBrandAsync();
        Task<IReadOnlyList<TypeBrandDto>> GetAllTypeAsync();

        Task<ProductDto> GetProductById(int? id);




    }
}
