using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using ZShop.Persistence;
using ZShop.Services.Interfaces;

namespace ZShop.Services.Implementations
{
    public class ProductService : IProductService
    {
        private readonly ZShopContext _context;
        public ProductService(ZShopContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Product product)
        {
            await _context.products.AddAsync(product);
            await SaveAsync();
        }

        public async Task DeleteAsync(Product products)
        {
            _context.products.Remove(products);
            await SaveAsync();
        }

        public  IQueryable<Product> GetAll()
        {
            return _context.products;
        }

        public async Task UpdateAsync(Product product)
        {
            _context.Update(product);
            await SaveAsync();
        }
        public Product GetById(int Id)
        {
            return _context.products.FirstOrDefault(x=>x.Id==Id);
        }

        public async Task SaveAsync()
        {
           await _context.SaveChangesAsync();
        }
    }
}
