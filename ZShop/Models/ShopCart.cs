using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZShop.Persistence;

namespace ZShop.Models
{
    public class ShopCart
    {
        private readonly ZShopContext _context;
        public ShopCart(ZShopContext context)
        {
            _context = context;
        }
        public string ShopCartId { get; set; }
        public List<Item> ShopItemsList{get;set;}

        public static ShopCart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = services.GetService<ZShopContext>();
            string shopCartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();
            session.SetString("CartId", shopCartId);
            return new ShopCart(context) { ShopCartId = shopCartId };
        }

        public void AddToCart(Product product)
        {
            _context.items.Add(new Item
            {

                ShopCartId = ShopCartId,
                Product = product,
                price = product.Price

            }) ;
            _context.SaveChanges();
        }

        public List<Item> GetItems()
        {
            return ShopItemsList ?? (ShopItemsList =_context.items.Where(c => c.ShopCartId == ShopCartId).Include(s => s.Product).ToList());
        }
    }
}
