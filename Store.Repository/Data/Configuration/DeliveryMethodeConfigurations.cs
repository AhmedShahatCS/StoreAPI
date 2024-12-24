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
    public class DeliveryMethodeConfigurations : IEntityTypeConfiguration<DeliveryMethods>
    {
        public void Configure(EntityTypeBuilder<DeliveryMethods> builder)
        {
            builder.Property(o => o.Cost).HasColumnType("decimal(18,2)");

        }
    }
}
