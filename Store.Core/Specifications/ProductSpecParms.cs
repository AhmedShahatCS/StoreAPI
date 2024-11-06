using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Core.Specifications
{
    public class ProductSpecParms
    {
        public string? sort { get; set; }
        public int? Brandid { get; set; }

        public int? Typeid { get; set; }

        public int PageIndex { get; set; } = 1;

        private int pageCount=5;
        public int PageCount {
            get { return pageCount; }
            set { pageCount = value > 10 ? 10 : value; }
        }

    }
}
