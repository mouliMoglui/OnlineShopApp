using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.DTOs;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly OnlineShopContext context;

        public UserController(OnlineShopContext context)
        {
            this.context = context;
        }

        [HttpPost("signup")]
        public IActionResult SignUp([FromBody] UserFullDTO dto)
        {
            if (context.Users.Any(u => u.Email == dto.Email))
            {
                return BadRequest("Email already in use");
            }

            var newUser = new User
            {
                Email = dto.Email,
                Password = dto.Password,
            };

            context.Users.Add(newUser);
            context.SaveChanges();

            return Ok(new
            {
                message = "User created successfully",
                userId = newUser.Id,
            });
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] UserFullDTO dto)
        {
            var user = context.Users.FirstOrDefault(u => u.Email == dto.Email);
            
            if (user == null)
            {
                return Unauthorized("User not found");
            }

            if (dto.Password != user.Password)
            {
                return Unauthorized("Invalid password");
            }

            return Ok(new
            {
                message = "User authorized successfully",
                userId = user.Id, 
            });
        }
    }
}
