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

        [HttpGet("/productId{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var result = await context.Products.FirstOrDefaultAsync(p => p.Id == id);
            if (result == null)
                return NotFound($"Couldn't find product with ID {id}");

            return Ok(result);
        }

        [HttpGet("/productCategory{category}")]
        public async Task<IActionResult> GetProductByCategory(string category)
        {
            var result = context.Products.Where(p => p.Category == category).ToList();
            if (result == null)
                return NotFound($"Couldn't find products with category {category}");

            return Ok(result);
        }
    }
}
