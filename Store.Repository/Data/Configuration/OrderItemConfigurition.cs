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
    public class OrderItemConfigurition : IEntityTypeConfiguration<OrderItems>
    {
        public void Configure(EntityTypeBuilder<OrderItems> builder)
        {
            builder.Property(o => o.Price).HasColumnType("decimal(18,2)");
            builder.OwnsOne(i => i.Product, io => io.WithOwner());
        }
    }
}
