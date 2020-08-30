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

       

    }
}
