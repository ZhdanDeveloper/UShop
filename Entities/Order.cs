using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class Order
    {
        public int Id { get; set; }
        public string PersonFirstName { get; set; }
        public string PersonLastName { get; set; }
        public string Phone { get; set; }
        public string City { get; set; }
        public string PostOfiice { get; set; }
        public DateTime OrderTime { get; set; }
        //public Item Item { get; set; }
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public decimal price { get; set; }
        public int Quantity { get; set; }
    }
}
