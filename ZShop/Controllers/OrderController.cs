using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities;
using Microsoft.AspNetCore.Mvc;
using ShopCartSpace;
using ZShop.Services.Interfaces;

namespace ZShop.Controllers
{

    public class OrderController : Controller
    {
       
        private readonly ShopCart _shopCart;
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService, ShopCart shopCart)
        {
            _shopCart = shopCart;
            _orderService = orderService;
        }
         [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(Order order)
        {
            //if (_shopCart.ShopItemsList.Count == 0)
            //{
            //    ModelState.AddModelError("", "NO ITEMS");
            //}
            if (ModelState.IsValid)
            {
                await _orderService.CreateAsync(order);
                _shopCart.ClearCart();

                return RedirectToAction("Index", "Home");
            }
            return View(order);
        }
    }
}
