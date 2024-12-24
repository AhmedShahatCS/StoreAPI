using Microsoft.EntityFrameworkCore;
using Store.Core.Entity;
using Store.Core.Entity.OrderAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Store.Repository.Data.Contexts
{
    public class StoreDbContext:DbContext
    {
        public StoreDbContext(DbContextOptions<StoreDbContext> option):base(option)
        { 
        
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductBrand> Brands { get; set; }
        public DbSet<ProductType> Types { get; set; }
        public DbSet<Order> orders { get; set; }
        public DbSet<OrderItems> OrderItems { get; set; }
        public DbSet<DeliveryMethods> DeliveryMethodss { get; set; }





    }
}
