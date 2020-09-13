using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZShop.Models.Pagination
{
    public class IndexViewModel
    {
        public IEnumerable<Product> Users { get; set; }
        public PageViewModel PageViewModel { get; set; }
    }
}
