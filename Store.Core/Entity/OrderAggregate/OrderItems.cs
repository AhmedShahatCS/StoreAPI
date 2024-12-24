using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Core.Entity.OrderAggregate
{
    public class OrderItems:BaseEntity<int>
    {
        public OrderItems()
        {
            
        }
        public OrderItems(ProdutItemOrder product, decimal price, int quantity)
        {
            Product = product;
            Price = price;
            Quantity = quantity;
        }

        public ProdutItemOrder Product { get; set; }

        public decimal Price { get; set; }
        public int Quantity { get; set; }


    }
}
