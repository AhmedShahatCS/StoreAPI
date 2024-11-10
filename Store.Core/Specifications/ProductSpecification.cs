using Store.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Core.Specifications
{
    public class ProductSpecification :BaseSpecification<Product,int>
    {
        public ProductSpecification(ProductSpecParms Parms) :
            base(
                P=>
                (string.IsNullOrEmpty(Parms.Search)||P.Name.ToLower().Contains(Parms.Search))
                &&
                (!Parms.Brandid.HasValue||P.BrandId== Parms.Brandid)
                &&
                (!Parms.Typeid.HasValue||P.TypeId== Parms.Typeid)
                
                )
        {
            Includes.Add(p => p.Brand);
            Includes.Add(p => p.Type);
            if(!string.IsNullOrEmpty(Parms.sort))
            {
                switch (Parms.sort)
                {
                    case "PriceAsc":
                        AddOrderBy(p => p.Price);
                        break;
                    case "PriceDesc":
                        AddOrderByDesc(p => p.Price);
                        break;

                    default:
                        AddOrderBy(p => p.Name);
                        break;

                }
            }

            ApllyPagination(Parms.PageCount * (Parms.PageIndex-1), Parms.PageCount);
        }

        public ProductSpecification(int id) : base(p=>p.Id==id) {
            Includes.Add(p => p.Brand);
            Includes.Add(p => p.Type);


        }

    }
}
