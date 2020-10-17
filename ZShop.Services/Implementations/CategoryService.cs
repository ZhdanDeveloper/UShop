using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZShop.Persistence;
using ZShop.Services.Interfaces;

namespace ZShop.Services.Implementations
{
    public class CategoryService : ICategoryService
    {
        private readonly ZShopContext _context;
        public CategoryService(ZShopContext context)
        {
            _context = context;
        }

        public async Task AddCategoryAsync(Category category)
        {
            _context.categories.Add(category);
            await SaveAsync();
        }

        public IQueryable<Category> GetAll()
        {
            return _context.categories;
        }

        public Category GetById(int Id)
        {
            return _context.categories.FirstOrDefault(x=>x.Id == Id);
        }

        public async Task RemoveCategoryByIdAsync(int id)
        {
            var category = _context.categories.FirstOrDefault(x=>x.Id == id);
            _context.categories.Remove(category);
            await SaveAsync();
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
