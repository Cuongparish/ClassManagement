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

        [HttpGet()]
        public async Task<IActionResult> GetByUsernameAsync()
        {
            Console.WriteLine("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa1");
            var stocks = await _userRepo.GetByUsernameAsync("cuong1@gmail.com");
            if (stocks == null)
            {
                return NotFound();
            }
            return Ok(stocks.ToUserDto());
        }
    }
}