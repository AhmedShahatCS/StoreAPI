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
        public ProductSpecification(string? sort, int? Brandid, int? Typeid) :
            base(
                P=>(!Brandid.HasValue||P.BrandId==Brandid)
                &&(!Typeid.HasValue||P.TypeId==Typeid)
                
                )
        {
            Includes.Add(p => p.Brand);
            Includes.Add(p => p.Type);
            if(!string.IsNullOrEmpty(sort))
            {
                switch (sort)
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


        }

        public ProductSpecification(int id) : base(p=>p.Id==id) {
            Includes.Add(p => p.Brand);
            Includes.Add(p => p.Type);


        }

    }
}
