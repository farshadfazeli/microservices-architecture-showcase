var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHttpClient();
var app = builder.Build();

app.MapGet("/api/products", (IHttpClientFactory clients) =>
    Forward(clients, "http://localhost:5002/api/products"));

app.MapGet("/api/users/{id:int}", (int id, IHttpClientFactory clients) =>
    Forward(clients, $"http://localhost:5001/api/users/{id}"));

app.MapGet("/api/carts/{userId:int}", (int userId, IHttpClientFactory clients) =>
    Forward(clients, $"http://localhost:5003/api/carts/{userId}"));

app.MapGet("/api/orders/{id:int}", (int id, IHttpClientFactory clients) =>
    Forward(clients, $"http://localhost:5005/api/orders/{id}"));

app.MapGet("/api/deliveries/{orderId:int}", (int orderId, IHttpClientFactory clients) =>
    Forward(clients, $"http://localhost:5006/api/deliveries/{orderId}"));

app.MapPost("/api/payments", (IHttpClientFactory clients) =>
    Forward(clients, "http://localhost:5004/api/payments", HttpMethod.Post));

app.MapPost("/api/orders", (IHttpClientFactory clients) =>
    Forward(clients, "http://localhost:5005/api/orders", HttpMethod.Post));

app.Run("http://localhost:5000");

static async Task<IResult> Forward(IHttpClientFactory clients, string url, HttpMethod? method = null)
{
    using var request = new HttpRequestMessage(method ?? HttpMethod.Get, url);
    using var response = await clients.CreateClient().SendAsync(request);
    var content = await response.Content.ReadAsStringAsync();
    return Results.Content(content, response.Content.Headers.ContentType?.MediaType ?? "application/json", statusCode: (int)response.StatusCode);
}
