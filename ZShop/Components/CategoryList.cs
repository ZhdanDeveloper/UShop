using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZShop.Services.Interfaces;

namespace ZShop.Components
{
    public class CategoryList : ViewComponent
    {
        private ICategoryService _categoryService;
        public CategoryList(ICategoryService categoryService)
        {

            _categoryService = categoryService;
        }

        public IViewComponentResult Invoke()
        {
            var categories = _categoryService.GetAll();
            return View(categories);
        }
    }
}
