using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly OnlineShopContext context;

        public ProductController(OnlineShopContext context)
        {
            this.context = context;
        }

        [HttpGet("/products")]
        public async Task<IActionResult> GetProducts()
        {
            var result = await context.Products.ToListAsync();
            if (result != null)
                return Ok(result);
            return NotFound("Couldn't get any products");
        }

        [HttpGet("/productById")]
        public async Task<IActionResult> GetProductById(int id)
        {
            try
            {
                var result = await context.Products.FirstAsync(product => product.Id == id);
                Console.WriteLine(result);
                if (result != null)
                    return Ok(result);
            }
            catch
            {
                return NotFound($"Couldn't find product with ID {id}");
            }

            return NotFound($"Couldn't find product with ID {id}");
        }
    }
}
