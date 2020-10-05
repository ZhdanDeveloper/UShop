using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ZShop.Persistence
{
    public class ZShopContext : DbContext
    {
        public ZShopContext(DbContextOptions<ZShopContext> options) : base(options) {  }
        public DbSet<User> Users { get; set; }
        public DbSet<Product> products { get; set; }
        public DbSet<Item> items { get; set; }
        public DbSet<Order> orders { get; set; }
        public DbSet<Category> categories { get; set; }
        public DbSet<Detail> details { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>()
                .HasIndex(u => u.Name)
                .IsUnique();
        }

    }
}
