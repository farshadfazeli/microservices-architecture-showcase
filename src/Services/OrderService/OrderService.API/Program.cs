var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/api/orders/{id:int}", (int id) => Results.Ok(new
{
    Id = id,
    UserId = 1,
    Status = "Paid",
    Total = 50000000
}));

app.MapPost("/api/orders", () => Results.Ok(new
{
    Id = 1001,
    Status = "Created"
}));

app.Run("http://localhost:5005");
