var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapPost("/api/payments", () => Results.Ok(new
{
    Success = true,
    Message = "Payment completed"
}));

app.Run("http://localhost:5004");
