using Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ZShop.Services.Interfaces
{
    public interface IDetailsService
    {
        Task AddDetail(Detail detail);
        Task SaveAsync();
        IEnumerable<Detail> DetailsByProductId(int id);
        public Detail DetailById(int id);
        Task UpdateAsync(Detail detail);
        Task RemoveByIdAsync(int id);
    }
}
