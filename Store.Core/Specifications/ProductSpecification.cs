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
        public ProductSpecification():base()
        {
            Includes.Add(p => p.Brand);
            Includes.Add(p => p.Type);


        }

        public ProductSpecification(int id) : base(p=>p.Id==id) {
            Includes.Add(p => p.Brand);
            Includes.Add(p => p.Type);


        }

    }
}
