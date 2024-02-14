// Ignore Spelling: API Dto

using API.Data;
using API.Dto;
using API.Entities;
using API.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IPasswordHasher _passwordHasher;

        public AccountController(DataContext context, IPasswordHasher passwordHasher)
        {
            _context = context;
            _passwordHasher = passwordHasher;
        }

        [HttpPost("register")]
        public async Task<ActionResult<User>> Register(RegisterDto registerDto)
        {
            
             if(await UserExist(registerDto.UserName)) return BadRequest();

             var PasswordHash = _passwordHasher.Hash(registerDto.Password);
             var user = new User
            {
                UserName = registerDto.UserName,
                PasswordHash = PasswordHash,
                FullName = registerDto.FullName,
                City = registerDto.City,
                Country = registerDto.Country
            };
             _context.Add(user);
             _context.SaveChanges();
             return user;
        }

        [HttpPost("login")]
        public async Task<ActionResult<User>>Login(LoginDto loginDto)
        {
         var user = await _context.User.FirstOrDefaultAsync(x =>x.UserName == loginDto.UserName);
            if(user == null) return BadRequest("Invalid Username");

            var result = _passwordHasher.verify(user.PasswordHash, loginDto.Password);
            if(!result) return BadRequest("Invalid Password");
            return user;
        }

        private async Task<bool> UserExist(string username) 
        {
         return await _context.User.AnyAsync(x => x.UserName == username);
        }
    }
}
