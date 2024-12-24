using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Core.Entity.OrderAggregate
{
    public class Order:BaseEntity<int>
    {
        public Order()
        {
            
        }
        public Order(string buyeEmail, DeliveryMethods deliveryMethods, Address shippingAddress, ICollection<OrderItems> items, decimal subTotal)
        {
            BuyeEmail = buyeEmail;
            DeliveryMethods = deliveryMethods;
            ShippingAddress = shippingAddress;
            Items = items;
            SubTotal = subTotal;
        }

        public string BuyeEmail { get; set; }
        public DateTimeOffset OderDate { get; set; } = DateTimeOffset.Now;
        public OrderStatus Status { get; set; } = OrderStatus.Pendding;

        public DeliveryMethods DeliveryMethods { get; set; }

        public Address ShippingAddress { get; set; }

        public ICollection<OrderItems> Items { get; set; }= new HashSet<OrderItems>();

        public decimal SubTotal { get; set; }
        public decimal GetTotal()
        {
            return SubTotal + DeliveryMethods.Cost;
        }

        public string PaymentIntentId { get; set; }=string.Empty;
    }
}
