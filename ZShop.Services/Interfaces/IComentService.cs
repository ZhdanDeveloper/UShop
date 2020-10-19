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
        Task DeleteAllByUserId(int Id);
        Task DeleteAllByProductId(int Id);
        Task DeleteOneByCommentIdAsync(int id);
        int GetProductIdByCommentId(int id);
        Comment CommentById(int id);
        IEnumerable<Comment> CommentsByProductId(int id);
        IEnumerable<Comment> CommentsByUserId(int id);
        Task SaveAsync();

    }
}
