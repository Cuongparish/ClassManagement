using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using server.Data;
using server.Interfaces;
using server.Mappers;

namespace server.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        private readonly IUserRepository _userRepo;
        public UserController(ApplicationDBContext context, IUserRepository userRepo)
        {
            _userRepo = userRepo;
            _context = context;
        }

        // manage profile
        [HttpPost]
        public async Task<IActionResult> GetByUsernameAsync([FromBody] string email)
        {
            var user = await _userRepo.GetByUsernameAsync(email);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user.ToUserDto());
        }
    }
}