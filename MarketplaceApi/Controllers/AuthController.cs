using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MarketplaceApi.Data;
using MarketplaceApi.DTO.Auth;
using MarketplaceApi.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace MarketplaceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _context;
        public AuthController(AppDbContext context)
        {    
            _context = context;
        }

        [HttpPost("signup")]
        public async Task<IActionResult> SignUp([FromBody] SignUpRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (string.IsNullOrWhiteSpace(request.Email) || string.IsNullOrWhiteSpace(request.Password))
            {
                return BadRequest(new { message = "Email and password are required." });
            }

            var email = request.Email.Trim().ToLower();

            var existingUser = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);

            if (existingUser != null)
            {
                return BadRequest(new { message = "Email is already registered." });
            }

            var user = new User
            {
                Email = email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password)
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return Ok(new
            {
                message = "Signup successful",
                userId = user.Id,
                email = user.Email
            });
        }
    }
}
