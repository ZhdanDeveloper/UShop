using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }      
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }      
        [Required]
        public string ImageUrl { get; set; }
        [Required]
        public string ImageUrl_1 { get; set; }
        [Required]
        public string ImageUrl_2 { get; set; }
        [Required]
        public string ImageUrl_3 { get; set; }
        [Required]
        public string ImageUrlShowCase { get; set; }
        [Required]
        public string Model { get; set; }
        [Required]
        public string Brand { get; set; }


    }
}
