using System.Security.Cryptography;
using System.Text;
using API.Data;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class AccountController : BaseApiController
    {
        private readonly DataContext _context;
        private readonly ITokenService _tokenService;
        public AccountController(DataContext context, ITokenService tokenService)
        {
            _tokenService = tokenService;
            _context = context;
        }

        [HttpPost("register")]  // POST: api/account/register?username=username&password=password
        public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto)
        {

            if (await UserExists(registerDto.Username))
            {
                return BadRequest("Username already exists.");
            }

            using var hmac = new HMACSHA512();

            var user = new AppUser
            {
                UserName = registerDto.Username.ToLower(),
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDto.Password)),
                PasswordSalt = hmac.Key
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return new UserDto
            {
                Username = user.UserName,
                Token = _tokenService.CreateToken(user)
            };
        }

        //The [HttpPost("login")] attribute specifies that this method should handle HTTP POST requests with the URL path "/login".
        [HttpPost("login")]
        //The method signature specifies that this is an asynchronous method that returns a Task object, which will eventually 
        //contain an ActionResult<AppUser> object. The method takes a LoginDto object as a parameter, which contains the username 
        //and password for the user attempting to log in.
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
        {
            // Find the user in the database that matches the provided username.
            var user = await _context.Users.SingleOrDefaultAsync(appuser =>
            appuser.UserName == loginDto.Username);

            // If the user wasn't found, return an unauthorized response.
            if (user == null) return Unauthorized();

            // Compute the HMAC hash of the provided password using the user's password salt.
            using var hmac = new HMACSHA512(user.PasswordSalt);
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDto.Password));

            // Compare the computed hash to the hash stored in the user's password hash field.
            // If they don't match, return an unauthorized response.
            for (int i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i] != user.PasswordHash[i])
                {
                    return Unauthorized("Invalid password.");
                }
            }

            // If the password is correct, return the user 
             return new UserDto
            {
                Username = user.UserName,
                Token = _tokenService.CreateToken(user)
            };
        }
        private async Task<bool> UserExists(string username)
        {
            return await _context.Users.AnyAsync(appuser => appuser.UserName == username.ToLower());
        }
    }
}