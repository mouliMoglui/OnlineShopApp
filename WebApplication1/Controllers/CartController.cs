using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly OnlineShopContext context;

        public CartController(OnlineShopContext context)
        {
            this.context = context;
        }

        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetUserCart(int userId)
        {
            var carts = await context.Carts
                .Include(c => c.Product)
                .Where(c => c.UserId == userId)
                .ToListAsync();

            if (!carts.Any())
                return NotFound("Cart is empty");

            return Ok(carts);
        }

        [HttpPost]
        public async Task<IActionResult> AddToCart(int userId, int productId)
        {
            var existingCartItem = await context.Carts
                .FirstOrDefaultAsync(c => c.UserId == userId && c.ProductId == productId);

            if (existingCartItem != null)
            {
                existingCartItem.Amount += 1;
            }
            else
            {
                var cart = new Cart
                {
                    UserId = userId,
                    ProductId = productId,
                    Amount = 1
                };

                await context.Carts.AddAsync(cart);
            }

            await context.SaveChangesAsync();

            return Ok("Product added to cart");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveFromCart(int id)
        {
            var cartItem = await context.Carts.FindAsync(id);

            if (cartItem == null)
                return NotFound("Cart item not found");

            context.Carts.Remove(cartItem);
            await context.SaveChangesAsync();

            return Ok("Removed from cart");
        }
    }
}
