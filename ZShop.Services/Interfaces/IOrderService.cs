using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZShop.Services.Interfaces
{
    public interface IOrderService
    {
        Task CreateAsync(Order order);
        Task DeleteAsync(Order order);
        Order FindById(int id);
        IQueryable<Order> GetAll();
        IQueryable<Order> GetListByPhone(string Phone);
        Task SaveAsync();
    }
}
