var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/api/users/{id:int}", (int id) => Results.Ok(new
{
    Id = id,
    Name = "Ali Ahmadi",
    Email = "ali@example.com"
}));

app.Run("http://localhost:5001");
