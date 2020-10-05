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
    public class DetailsService : IDetailsService
    {
        private readonly ZShopContext _context;
        public DetailsService(ZShopContext context)
        {
            _context = context;
        }
        public async Task AddDetail(Detail detail)
        {
            await _context.AddAsync(detail);
            await SaveAsync();
        }

        public IEnumerable<Detail> DetailsById(int id)
        {
           return _context.details.Where(x => x.ProductId == id);
        }

        public async Task RemoveByIdAsync(int id)
        {
            var detail = _context.details.FirstOrDefault(x => x.Id == id);
            _context.Remove(detail);
            await SaveAsync();
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

    }
}
