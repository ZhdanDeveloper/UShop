using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities
{
    public class Order
    {
        public int Id { get; set; }
        [Required]
        public string PersonFirstName { get; set; }
        public string Region { get; set; }
        public string PersonLastName { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string PostOfiice { get; set; }
        public DateTime OrderTime { get; set; }
        //public Item Item { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal price { get; set; }
        public int Quantity { get; set; }
    }
}
