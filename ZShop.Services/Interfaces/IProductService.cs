using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZShop.Services.Interfaces
{
    public interface IProductService
    {

        Task CreateAsync(Product products);
        Task DeleteAsync(Product products);
        Task UpdateAsync(Product product);
        IQueryable<Product> GetAll();
        Product GetById(int Id);
        Task SaveAsync();



    }
}
