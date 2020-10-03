using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZShop.Persistence;

namespace ShopCartSpace
{
    public class ShopCart
    {
        private readonly ZShopContext _context;
        public ShopCart(ZShopContext context)
        {
            _context = context;
        }
        public string ShopCartId { get; set; }
        public List<Item> ShopItemsList { get; set; }



        public static ShopCart GetCart(IServiceProvider services)
        {



            //ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            //  var context = services.GetService<ZShopContext>();
            //  string shopCartId = cookieValueFromContext ?? Guid.NewGuid().ToString();

            //session.SetString("CartId", shopCartId);
        
            string cookieValueFromContext = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Request.Cookies["shopCartId"];
            //ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = services.GetService<ZShopContext>();
            string shopCartId = cookieValueFromContext ?? Guid.NewGuid().ToString();
            services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Response.Cookies.Append("shopCartId", shopCartId , new Microsoft.AspNetCore.Http.CookieOptions
            {
                Expires = DateTimeOffset.Now.AddYears(100)
            });
            //session.SetString("CartId", shopCartId);
            return new ShopCart(context) { ShopCartId = shopCartId };
        }

        public void AddToCart(Product product, int amount)
        {
            var shoppingCartItem = _context.items.SingleOrDefault(s => s.Product.Id == product.Id && s.ShopCartId == ShopCartId);
            if (shoppingCartItem == null)
            {
                _context.items.Add(new Item
                {
                    ShopCartId = ShopCartId,
                    Product = product,
                    price = product.Price,
                    amount = 1
                });
            }
            else
            {
                shoppingCartItem.amount++;
            }

            _context.SaveChanges();
        }



        public void RemoveAmount(int id)
        {
            var shoppingCartItem = _context.items.FirstOrDefault(x => x.Id == id);
            if (shoppingCartItem != null)
            {
                if (shoppingCartItem.amount > 1)
                {
                    shoppingCartItem.amount--;
                }
            }

            _context.SaveChanges();
        }


        public void RemoveFromCart(int id)
        {
            var shoppingCartItem = _context.items.FirstOrDefault(x => x.Id == id);
            _context.Remove(shoppingCartItem);
            _context.SaveChanges();

        }
        public Item GetItem(int id)
        {
            return _context.items.FirstOrDefault(x => x.Id == id);
        }

        public void ClearCart()
        {
            var items = _context.items.Where(x => x.ShopCartId == ShopCartId);
            _context.items.RemoveRange(items);
            _context.SaveChanges();

        }

        public List<Item> GetItems()
        {
            return ShopItemsList ?? (ShopItemsList = _context.items.Where(c => c.ShopCartId == ShopCartId).Include(s => s.Product).ToList());
        }
    }
}
