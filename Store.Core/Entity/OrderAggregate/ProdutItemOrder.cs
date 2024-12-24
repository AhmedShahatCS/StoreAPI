using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Core.Entity.OrderAggregate
{
    public class ProdutItemOrder
    {
        public ProdutItemOrder()
        {
            
        }
        public ProdutItemOrder(int productId, string productName, string pictuerUrl)
        {
            ProductId = productId;
            ProductName = productName;
            PictuerUrl = pictuerUrl;
        }

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string PictuerUrl { get; set; }
    }
}
