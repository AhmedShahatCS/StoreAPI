using Store.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Core.Specifications
{
    public class ProductWithFilterationForCountAsync:BaseSpecification<Product,int>
    {
        public ProductWithFilterationForCountAsync(ProductSpecParms parms) : base(
                P =>
                 (string.IsNullOrEmpty(parms.Search) || P.Name.ToLower().Contains(parms.Search))
                &&
                (!parms.Brandid.HasValue || P.BrandId == parms.Brandid)
                && (!parms.Typeid.HasValue || P.TypeId == parms.Typeid))

                { }

    }
}
