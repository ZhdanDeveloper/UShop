using Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ZShop.Persistence;
using ZShop.Services.Interfaces;

namespace ZShop.Services.Implementations
{
    class ProductService : IProductService
    {
        private readonly ZShopContext _context;
        public ProductService(ZShopContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Product product)
        {
            await _context.products.AddAsync(product);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Product products)
        {
            _context.products.Remove(products);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Product product)
        {
            _context.Update(product);
            await _context.SaveChangesAsync();
        }
    }
}
