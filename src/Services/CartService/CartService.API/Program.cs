var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/api/carts/{userId:int}", (int userId) => Results.Ok(new
{
    UserId = userId,
    Items = new[]
    {
        new { ProductId = 1, Quantity = 1 },
        new { ProductId = 2, Quantity = 2 }
    }
}));

app.Run("http://localhost:5003");
