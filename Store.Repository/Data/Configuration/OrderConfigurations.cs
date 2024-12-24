using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Store.Core.Entity.OrderAggregate;

namespace Store.Repository.Data.Configuration
{
    public class OrderConfigurations : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Core.Entity.OrderAggregate.Order> builder)
        {
            builder.Property(o => o.Status).HasConversion(o => o.ToString(), o => (OrderStatus) Enum.Parse(typeof(OrderStatus), o));

            builder.Property(o => o.SubTotal).HasColumnType("decimal(18,2)");

            builder.OwnsOne(o => o.ShippingAddress, sa => sa.WithOwner());
            builder.HasOne(O=>O.DeliveryMethods).WithMany().OnDelete(DeleteBehavior.NoAction);
        }
    }
}
