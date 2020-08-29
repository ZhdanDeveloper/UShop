using Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ZShop.Services.Interfaces
{
    public interface IProductService
    {

        Task CreateAsync(Product products);
        Task DeleteAsync(Product products);
        Task UpdateAsync(Product product);




    }
}
