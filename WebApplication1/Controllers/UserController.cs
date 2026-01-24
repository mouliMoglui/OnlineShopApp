using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        List<User> users = new List<User>() { };

        [HttpGet("/users")]
        IActionResult GetUsers()
        {
            if(users == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(users);
            }
        }

        [HttpGet("/userById")]
        IActionResult GetUserById(int id)
        {
            var user = users.Find(x => x.Id == id);

            if(user == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(user);
            }
        }
    }
}
