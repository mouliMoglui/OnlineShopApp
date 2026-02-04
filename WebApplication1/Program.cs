using Microsoft.EntityFrameworkCore;
using WebApplication1;
using WebApplication1.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<OnlineShopContext>(options => options.UseInMemoryDatabase("OnlineShop"));

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<OnlineShopContext>();

    if (!context.Products.Any())
    {
        context.Products.AddRange(
            new Product
            {
                Name = "Robotis X15+ Pro AI",
                Price = 3000,
                Category = "laptop",
                Description = "Bleeding edge laptop powered by an NPU",
                Brand = "Lenovo"
            },
            new Product
            {
                Name = "Razor Premium",
                Price = 5800,
                Category = "tv",
                Description = "Ultra thin full color 8K OLED TV",
                Brand = "Nanotek"
            },
            new Product
            {
                Name = "Z26+",
                Price = 2500,
                Category = "phone",
                Description = "lorem ipsum",
                Brand = "Matek"
            }
        );

        context.SaveChanges();
    }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
