using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using server.Data;
using server.Interfaces;
using server.Models;

namespace server.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDBContext _context;
        public UserRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<User> CreateAsync(User userModel)
        {
            await _context.Users.AddAsync(userModel);
            await _context.SaveChangesAsync();
            return userModel;
        }

        public async Task<User?> GetByUsernameAsync(string email)
        {
            var existingStock = await _context.Users.FirstOrDefaultAsync(i => i.email == email);
            if (existingStock == null)
            {
                return null;
            }
            return existingStock;
        }

        public async Task<List<User?>> GetByUserIdAsync(int[] userIds)
        {
            var users = await _context.Users
            .Where(s => userIds.Contains(s.id))
            .ToListAsync();
            return users.Cast<User?>().ToList();
        }
    }
}