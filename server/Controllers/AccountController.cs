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
using server.Dtos.Auth;
using System.IdentityModel.Tokens.Jwt;

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
        private readonly IMailService _mailRepo;
        private readonly ApplicationDBContext _context;
        // , ITokenService tokenService, SignInManager<AppUser> signInManager
        public AccountController(ApplicationDBContext context, IUserRepository userRepo, IMailService mailRepo, UserManager<AppUser> userManager, ITokenService tokenService, SignInManager<AppUser> signInManager)
        {
            _userRepo = userRepo;
            _context = context;
            _userManager = userManager;
            _tokenService = tokenService;
            _signinManager = signInManager;
            _mailRepo = mailRepo;
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
                    id = userModel.id,
                    email = user.Email,
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
                            id = userModel.id,
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

        [HttpPost("resetpw")]
        public async Task<IActionResult> ResetPW([FromBody] string email)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(x => x.UserName == email.ToLower());

            if (user == null) return Unauthorized("Invalid username!");
            var appUser = new AppUser
            {
                UserName = email,
                Email = email
            };
            string newPw = "User@123456";
            string subject = "Bạn đã reset mật khẩu";
            string body = $"Mật khẩu mới được đặt lại của bạn là : {newPw}";
            await _mailRepo.SendEmailAsync(email, subject, body);
            await _userManager.RemovePasswordAsync(appUser);
            await _userManager.AddPasswordAsync(appUser, newPw);
            var user1 = await _userRepo.GetByUsernameAsync(user.UserName);
            var userModel = user1.ToUserDto();

            return Ok(
                new NewUserDto
                {
                    id = userModel.id,
                    email = user.Email,
                    pw = user.PasswordHash,
                    fullName = userModel.fullName,
                    dob = userModel.dob,
                    sex = userModel.sex,
                    phone = userModel.phone,
                }
            );
        }

        [HttpPost("changepw")]
        public async Task<IActionResult> ChangePW([FromBody] ChangePwDto changePwDto)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(x => x.UserName == changePwDto.Email.ToLower());

            if (user == null) return Unauthorized("Invalid username!");

            var appUser = new AppUser
            {
                UserName = changePwDto.Email,
                Email = changePwDto.Email

            };
            var updateUser = await _userManager.ChangePasswordAsync(appUser, changePwDto.OldPw, changePwDto.NewPw);

            var user1 = await _userRepo.GetByUsernameAsync(user.UserName);
            var userModel = user1.ToUserDto();

            return Ok(
                new NewUserDto
                {
                    id = userModel.id,
                    email = user.Email,
                    pw = user.PasswordHash,
                    fullName = userModel.fullName,
                    dob = userModel.dob,
                    sex = userModel.sex,
                    phone = userModel.phone,
                }
            );
        }

        [HttpPost("decode")]
        public IActionResult Decode([FromBody] TokenDto tokenDto)
        {
            var principal = _tokenService.DecodeToken(tokenDto.token_code);
            if (principal != null)
            {
                var emailClaim = principal.Claims.FirstOrDefault(c => c.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress")?.Value;
                var usernameClaim = principal.Claims.FirstOrDefault(c => c.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/givenname")?.Value;

                if (emailClaim == null || usernameClaim == null)
                {
                    return BadRequest("Claims not found");
                }

                return Ok(new { email = emailClaim, username = usernameClaim });
            }

            return BadRequest("Invalid token");
        }


    }
}