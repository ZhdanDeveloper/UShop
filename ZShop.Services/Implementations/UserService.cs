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
    public class UserService : IUserService
    {
        public ZShopContext _context;



        public UserService(ZShopContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(User newUser)
        {
            await _context.Users.AddAsync(newUser);
            await SaveAsync();
        }
        

        public async Task Delete(int userId)
        {
            var user = GetById(userId);
            _context.Users.Remove(user);
            await SaveAsync();
        }
        public async Task UpdateAsync(User user)
        {
            _context.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(int id)
        {
            var user = GetById(id);
            _context.Update(user);
            await SaveAsync();
        }

        public IQueryable<User> GetAll()
        {
            return _context.Users;
        }

        public User GetById(int UserId)
        {
            return _context.Users.FirstOrDefault(x => x.Id == UserId);
        }

        public async Task SaveAsync()
        {
             
             await _context.SaveChangesAsync();
            
        }

        public IQueryable<User> GetUsersByName(string Name)
        {
            return _context.Users.Where(x => x.Name.Contains(Name));
        }
    }
}
