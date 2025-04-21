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

        public async Task<List<Comment>> GetAllAsync()
        {
            return await _context.Comment.ToListAsync();
        }

        public async Task<Comment?> GetByIdAsync(int id)
        {
            return await _context.Comment.FindAsync(id);
        }
    }

    
}