using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ShopCartSpace;
using ZShop.Models.Pagination;
using ZShop.Services.Interfaces;

namespace ZShop.Controllers
{
    public class SearchController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductService _productService;
        private readonly ShopCart _shopCart;
        public SearchController(ILogger<HomeController> logger, IProductService productService, ShopCart shopCart)
        {
            _logger = logger;
            _productService = productService;
            _shopCart = shopCart;
        }


        public async Task<IActionResult> Search(string SearchString, int? pageNumber, string currentFilter)
        {
            var prods = _productService.GetListByName(SearchString == null ? currentFilter : SearchString);
            if (prods == null)
            {

            }

            if (SearchString != null)
            {
                pageNumber = 1;
            }
            else if (currentFilter == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                SearchString = currentFilter;
            }
            ViewData["CurrentFilter"] = SearchString;



            int pageSize = 9;
            return View(await PaginatedList<Product>.CreateAsync(prods.AsNoTracking(), pageNumber ?? 1, pageSize));

        }

        public async Task<IActionResult> CategorySearch(int Id, int? pageNumber = 1)
        {

            var prods = _productService.GetListByCategory(Id);
            int pageSize = 9;
            return View(await PaginatedList<Product>.CreateAsync(prods.AsNoTracking(), pageNumber ?? 1, pageSize));
        }


    }
}
