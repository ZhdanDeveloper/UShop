using Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ZShop.Services.Interfaces
{
    public interface IComentService
    {
        Task CreateAsync(Comment comment);
        Task DeleteAsync(Comment comment);
        IEnumerable<Comment> CommentsByProductId(int id);
        Task SaveAsync();

    }
}
