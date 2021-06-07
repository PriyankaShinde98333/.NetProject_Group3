using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Loot_Lo_API.Models
{
    public class LootLoDbContext : DbContext
    {
        public LootLoDbContext()
        {
        }

        public LootLoDbContext(DbContextOptions<LootLoDbContext> options) : base(options)
        {

        }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerOrderDetails> CustomerOrderDetails { get; set; }
        public DbSet<OrderedProductQuantity> OrderedProductQuantity { get; set; }


    }
}
