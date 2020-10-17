using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZShop.Services.Interfaces
{
    public interface ICategoryService
    {
        IQueryable<Category> GetAll();
        Category GetById(int Id);
        Task AddCategoryAsync(Category category);
        Task RemoveCategoryByIdAsync(int id);
        Task SaveAsync();
    }
}
