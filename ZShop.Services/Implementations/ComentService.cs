using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZShop.Persistence;
using ZShop.Services.Interfaces;

namespace ZShop.Services.Implementations
{
    public class ComentService : IComentService
    {

        private readonly ZShopContext _context;
        public ComentService(ZShopContext context)
        {
            _context = context;
        }
       

        public IEnumerable<Comment> CommentsByProductId(int id)
        {
            return _context.Comments.Where(x=>x.ProductId == id);
        }

        public IEnumerable<Comment> CommentsByUserId(int id)
        {
            return _context.Comments.Where(x => x.UserId == id);
        }

        public async Task CreateAsync(Comment comment)
        {
            _context.Comments.Add(comment);
            await SaveAsync();
        }

        public async Task DeleteAllByProductId(int Id)
        {
            var coms = _context.Comments.Where(x => x.ProductId == Id);
            _context.Comments.RemoveRange(coms);
            await SaveAsync();
        }

        public async Task DeleteAllByUserId(int Id)
        {
            var coms = _context.Comments.Where(x => x.UserId == Id);
            _context.Comments.RemoveRange(coms);
            await SaveAsync();
        }

        public async Task DeleteAsync(Comment comment)
        {
            _context.Comments.Remove(comment);
            await SaveAsync();
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
