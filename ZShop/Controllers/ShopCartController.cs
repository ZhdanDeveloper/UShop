using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ZShop.Models;
using ZShop.Services.Interfaces;

namespace ZShop.Controllers
{
    public class ShopCartController : Controller
    {
        private readonly IProductService _productService;
        private readonly ShopCart _shopCart;
        public ShopCartController(IProductService productService, ShopCart shopCart)
        {
            _productService = productService;
            _shopCart = shopCart;
        }

        public ViewResult Index()
        {
           

            var obj = new ShopCartViewModel
            {
                shopCart = _shopCart
            };

            return View(obj);
        }

        public RedirectToActionResult AddToCart(int id)
        {
            var item = _productService.GetById(id);
            if (item != null)
            {
                _shopCart.AddToCart(item);
            }
            return RedirectToAction("Index");
        }
    }
}
