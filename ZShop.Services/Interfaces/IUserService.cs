using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZShop.Services.Interfaces
{
    public interface IUserService
    {
        Task CreateAsync(User user);
        Task Delete(int userId);
        IQueryable<User> GetAll();
        Task UpdateAsync(User user);
        Task UpdateAsync(int id);
        User GetById(int UserId);
        IQueryable<User> GetUsersByName(string Name);
        Task SaveAsync();
    }
}
