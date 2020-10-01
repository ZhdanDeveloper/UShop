using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZShop.Services.Interfaces
{
    public interface ICategoryService
    {
        IQueryable<Category> GetAll();
    }
}
