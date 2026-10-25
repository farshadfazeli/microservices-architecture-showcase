var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/api/deliveries/{orderId:int}", (int orderId) => Results.Ok(new
{
    OrderId = orderId,
    Status = "Preparing",
    Address = "Tehran"
}));

app.Run("http://localhost:5006");
