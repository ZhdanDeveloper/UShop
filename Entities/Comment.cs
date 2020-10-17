using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class Comment
    {
        public int Id { get; set; }
        public string text { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public User User { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public DateTime date { get; set; } = DateTime.Now;
    }
}
