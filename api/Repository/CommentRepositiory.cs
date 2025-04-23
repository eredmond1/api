using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using api.Data;
using api.Interface;
using api.Models;

namespace api.Repository
{
    public class CommentRepositiory: ICommentRepositiory
    {
        private readonly ApplicationDBContext _context;
        public CommentRepositiory(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Comment> CreateAsync(Comment commentModel)
        {
            await _context.Comment.AddAsync(commentModel);
            await _context.SaveChangesAsync();
            return commentModel;
        }

        public async Task<List<Comment>> GetAllAsync()
        {
            return await _context.Comment.ToListAsync();
        }

        public async Task<Comment?> GetByIdAsync(int id)
        {
            return await _context.Comment.FindAsync(id);
        }

        public async Task<Comment?> UpdateAsync(int id, Comment commentModel )
        {
            var existingComment  = await _context.Comment.FindAsync(id);
            if (existingComment == null)
            {
                return null;
            }
            existingComment.Title = commentModel.Title;
            existingComment.Content= commentModel.Content;
            
            await _context.SaveChangesAsync();
            return existingComment;


        }
    }

    
}