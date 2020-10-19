using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ZShop.Models.Account
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public int CategoryId { get; set; }
        [Required]
        public IFormFile ImageUrl { get; set; }
        public IFormFile ImageUrl_1 { get; set; }
        public IFormFile ImageUrl_2 { get; set; }
        public IFormFile ImageUrl_3 { get; set; }

        [Required]
        public string Model { get; set; }
        [Required]
        public string Brand { get; set; }

    }
}
