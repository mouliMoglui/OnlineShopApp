using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1
{
    public class OnlineShopContext : DbContext
    {
        public OnlineShopContext(DbContextOptions options) : base(options)
        { 

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
