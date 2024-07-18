using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using server.Models;

namespace server.Interfaces
{
    public interface IUserRepository
    {

        Task<User> CreateAsync(User userModel);
        Task<User?> GetByUsernameAsync(string email);
        Task<List<User?>> GetByUserIdAsync(int[] userIds);
    }
}