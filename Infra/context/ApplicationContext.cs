using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.order.entity;
using Domain.product.entity;
using Infra.mappers;
using Microsoft.EntityFrameworkCore;

    namespace Infra.context
    {
        public class ApplicationContext : DbContext
        {
            public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }
            public DbSet<Product> Products { get; set; }
            public DbSet<Order> Orders { get; set; }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                modelBuilder.ApplyConfiguration(new ProductConfig());
                modelBuilder.ApplyConfiguration(new OrderProductConifg());
                modelBuilder.ApplyConfiguration(new OrderConfig());
                base.OnModelCreating(modelBuilder);
            }
        }
    }

