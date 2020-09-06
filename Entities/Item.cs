using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class Item
    {
        public int Id { get; set; }
        public Product Product { get; set; } 
        public decimal price { get; set; }
        public int amount { get; set; }
        public string ShopCartId { get; set; }
        
      
        
    }
}
