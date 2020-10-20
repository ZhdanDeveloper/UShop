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
                    ProductId = item.Product.Id,
                    price = item.price * item.amount,
                    Quantity = item.amount,
                    ProductName = item.Product.Name,
                    OrderTime = time,
                    Region = order.Region

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

        public Order FindById(int id)
        {
            return _context.orders.FirstOrDefault(x => x.Id == id);
        }

        public IQueryable<Order> GetAll()
        {
            return _context.orders;
        }

        public IQueryable<Order> GetListByPhone(string Phone)
        {
            return _context.orders.Where(x => x.Phone.Contains(Phone));
        }

       

        public async Task SaveAsync()
        {
           await _context.SaveChangesAsync();
        }
    }
}
