# Microshop

Microshop is a small sample online store built with .NET 8 and ASP.NET Core. It demonstrates the basic idea of microservices without adding databases, authentication, message brokers, or complex infrastructure.

## What We Built

The application is split into small independent services. Each service owns one business responsibility and runs on its own port:

| Application | Responsibility | Port |
| --- | --- | ---: |
| User Service | User information | 5001 |
| Product Service | Product catalog | 5002 |
| Cart Service | Shopping carts | 5003 |
| Payment Service | Payment simulation | 5004 |
| Order Service | Order creation and status | 5005 |
| Delivery Service | Delivery status | 5006 |
| API Gateway | Single entry point for the APIs | 5000 |
| MVC Frontend | Simple web interface | 5007 |

## Why This Structure?

This structure follows the example from the microservices architecture presentation:

- Each business area has a separate service.
- Services can be started, changed, and deployed independently.
- The API Gateway hides internal service ports from clients.
- The MVC application acts as the user interface.
- In-memory sample data keeps the project easy to understand and run.

This is a learning sample, not a production-ready store. The services do not persist data after they restart.

## Project Structure

```text
src/
├── Services/
│   ├── UserService/UserService.API
│   ├── ProductService/ProductService.API
│   ├── CartService/CartService.API
│   ├── PaymentService/PaymentService.API
│   ├── OrderService/OrderService.API
│   └── DeliveryService/DeliveryService.API
├── ApiGateway/ApiGateway.csproj
└── Web/Microshop.Mvc/Microshop.Mvc.csproj
```

## How to Run

The API Gateway depends on the services behind it. Run every project in a separate terminal from the repository root:

```powershell
dotnet run --project src/Services/UserService/UserService.API --no-launch-profile
dotnet run --project src/Services/ProductService/ProductService.API --no-launch-profile
dotnet run --project src/Services/CartService/CartService.API --no-launch-profile
dotnet run --project src/Services/PaymentService/PaymentService.API --no-launch-profile
dotnet run --project src/Services/OrderService/OrderService.API --no-launch-profile
dotnet run --project src/Services/DeliveryService/DeliveryService.API --no-launch-profile
dotnet run --project src/ApiGateway/ApiGateway.csproj --no-launch-profile
dotnet run --project src/Web/Microshop.Mvc/Microshop.Mvc.csproj --no-launch-profile
```

After the applications start, open:

```text
http://localhost:5007
```

## API Examples

The product endpoint through the Gateway is:

```text
http://localhost:5000/api/products
```

It can also be tested with PowerShell:

```powershell
Invoke-RestMethod http://localhost:5000/api/products
```

Other Gateway endpoints include:

```text
GET  /api/users/1
GET  /api/carts/1
GET  /api/orders/1001
POST /api/orders
POST /api/payments
GET  /api/deliveries/1001
```

## Troubleshooting

If the browser shows `ERR_CONNECTION_REFUSED` for port `5000`, the API Gateway is not running. Start the Gateway with:

```powershell
dotnet run --project src/ApiGateway/ApiGateway.csproj --no-launch-profile
```

The Gateway will listen on `http://localhost:5000`. For `/api/products`, the Product Service must also be running on port `5002`.

## Build

To build the complete solution:

```powershell
dotnet build MicroshopSolution.sln
```
