using Entities;
using ShopCartSpace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZShop.Persistence;
using ZShop.Services.Interfaces;

namespace ZShop.Services.Implementations
{
   

    public class OrderService : IOrderService
    {
        private readonly ZShopContext _context;
        private readonly ShopCart _shopCart;
        public OrderService(ZShopContext context, ShopCart shopCart)
        {
            _context = context;
            _shopCart = shopCart;
        }
        public async Task CreateAsync(Order order)
        {
            var time = DateTime.Now;
            var items = _shopCart.GetItems();
            foreach (var item in items)
            {
                var Order = new Order
                {
                    City = order.City,
                    PersonFirstName = order.PersonFirstName,
                    PersonLastName = order.PersonLastName,
                    Phone = order.Phone,
                    PostOfiice = order.PostOfiice,
                    ItemId = item.Id,
                    price = item.price,
                    Quantity = item.amount,
                    ItemName = item.Product.Name,
                    OrderTime = time

                };
                 _context.orders.Add(Order);
            }
            
            await SaveAsync();
        }

        public async Task DeleteAsync(Order order)
        {
            _context.orders.Remove(order);
            await SaveAsync();
        }

        public IQueryable<Product> GetAll()
        {
            return _context.products;
        }

        public async Task SaveAsync()
        {
           await _context.SaveChangesAsync();
        }
    }
}
