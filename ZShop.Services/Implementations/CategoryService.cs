﻿using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZShop.Persistence;
using ZShop.Services.Interfaces;

namespace ZShop.Services.Implementations
{
    public class CategoryService : ICategoryService
    {
        private readonly ZShopContext _context;
        public CategoryService(ZShopContext context)
        {
            _context = context;
        }

        public IQueryable<Category> GetAll()
        {
            return _context.categories;
        }
    }
}