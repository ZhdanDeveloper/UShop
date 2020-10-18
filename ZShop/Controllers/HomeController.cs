using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ReflectionIT.Mvc.Paging;
using ShopCartSpace;
using ZShop.Models;
using ZShop.Models.Pagination;
using ZShop.Services.Interfaces;

namespace ZShop.Controllers
{
        
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductService _productService;
        private readonly IComentService _comentService;
        private readonly ShopCart _shopCart;

        public HomeController(ILogger<HomeController> logger, IProductService productService, ShopCart shopCart, IComentService comentService)
        {
            _logger = logger;
            _productService = productService;
            _shopCart = shopCart;
            _comentService = comentService;
        }
        public async Task<IActionResult> Index(int? pageNumber = 1)
        {

            var prods = _productService.GetAll();


            int pageSize = 9;
            return View(await PaginatedList<Product>.CreateAsync(prods.AsNoTracking(), pageNumber ?? 1, pageSize));

        }
        [HttpGet("AllCategories")]
        public IActionResult AllCategories()
        {
            return View();
        }
        
        public IActionResult Privacy()
        {
            return View();
        }
        [HttpGet("ViewProduct/{id}")]
        public IActionResult ViewProduct(int id)
        {
            var Product = _productService.GetById(id);

            return View(Product);
        }
        [Authorize]
        [HttpPost("AddComment")]
        public async Task<IActionResult> AddComment(Comment comment)
        {
            //ClaimsPrincipal currentUser = this.User;
            //var currentUserId = currentUser.FindFirst("Id").Value;
            comment.UserId = Convert.ToInt32(User.FindFirst("Id").Value);
            await _comentService.CreateAsync(comment);

            return RedirectToAction("Index", "Home");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
