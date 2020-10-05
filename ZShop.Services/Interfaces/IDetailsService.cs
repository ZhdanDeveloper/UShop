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
        IEnumerable<Detail> DetailsById(int id);
        Task RemoveByIdAsync(int id);
    }
}
