var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/api/products", () => Results.Ok(new[]
{
    new { Id = 1, Name = "Laptop", Price = 45000000 },
    new { Id = 2, Name = "Headphones", Price = 2500000 },
    new { Id = 3, Name = "Keyboard", Price = 1800000 }
}));

app.Run("http://localhost:5002");
