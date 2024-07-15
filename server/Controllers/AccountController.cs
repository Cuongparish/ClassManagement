using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using server.Dtos.Account;
using server.Dtos.User;
using server.Interfaces;
using server.Models;
using server.Controllers;
using server.Data;
using server.Mappers;

namespace server.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ITokenService _tokenService;
        private readonly SignInManager<AppUser> _signinManager;
        private readonly IUserRepository _userRepo;
        private readonly ApplicationDBContext _context;
        // , ITokenService tokenService, SignInManager<AppUser> signInManager
        public AccountController(ApplicationDBContext context, IUserRepository userRepo, UserManager<AppUser> userManager, ITokenService tokenService, SignInManager<AppUser> signInManager)
        {
            _userRepo = userRepo;
            _context = context;
            _userManager = userManager;
            _tokenService = tokenService;
            _signinManager = signInManager;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = await _userManager.Users.FirstOrDefaultAsync(x => x.UserName == loginDto.Username.ToLower());

            if (user == null) return Unauthorized("Invalid username!");

            var result = await _signinManager.CheckPasswordSignInAsync(user, loginDto.Password, false);

            if (!result.Succeeded) return Unauthorized("Username not found and/or password incorrect");

            var user1 = await _userRepo.GetByUsernameAsync(user.UserName);
            var userModel = user1.ToUserDto();

            return Ok(
                new NewUserDto
                {
                    email = user.UserName,
                    pw = user.PasswordHash,
                    fullName = userModel.fullName,
                    dob = userModel.dob,
                    sex = userModel.sex,
                    phone = userModel.phone,
                    Token = _tokenService.CreateToken(user)
                }
            );
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var appUser = new AppUser
                {
                    UserName = registerDto.Email,
                    Email = registerDto.Email
                };

                var createdUser = await _userManager.CreateAsync(appUser, registerDto.Password);

                if (createdUser.Succeeded)
                {
                    var roleResult = await _userManager.AddToRoleAsync(appUser, "User");

                    //gọi hàm để thêm thông tin người dùng vào chỗ này

                    var user = new CreateUserRequestDto
                    {
                        email = registerDto.Email,
                        pw = registerDto.Password,
                        fullName = registerDto.fullName,
                        dob = registerDto.dob,
                        sex = registerDto.sex,
                        phone = registerDto.phone
                    };
                    var userModel = user.ToUserFromCreateDTO();
                    await _userRepo.CreateAsync(userModel);

                    if (roleResult.Succeeded)
                    {
                        return Ok(new NewUserDto
                        {
                            email = appUser.UserName,
                            pw = appUser.PasswordHash,
                            fullName = userModel.fullName,
                            dob = userModel.dob,
                            sex = userModel.sex,
                            phone = userModel.phone,
                            Token = _tokenService.CreateToken(appUser)
                        });
                    }
                    else
                    {

                        return StatusCode(500, roleResult.Errors);
                    }
                }
                else
                {
                    return StatusCode(500, createdUser.Errors);
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }
    }
}