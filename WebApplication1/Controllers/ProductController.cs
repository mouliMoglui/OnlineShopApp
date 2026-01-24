using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        List<Product> products = new List<Product>() { };

        [HttpGet("/products")]
        IActionResult GetProducts()
        {
            if (products == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(products);
            }
        }

        [HttpGet("/productById")]
        IActionResult GetProductById(int id)
        {
            var product = products.Find(x => x.Id == id);

            if(product == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(product);
            }
        }
    }
}
