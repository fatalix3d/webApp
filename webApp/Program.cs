using webApp.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

// Добавьте API ключ в конфигурацию (например, в appsettings.json или как переменную среды)
builder.Configuration["x-api-key"] = "your_secret_key_here";

var app = builder.Build();

// Использование middleware для проверки ключа API
app.UseMiddleware<ApiKeyMiddleware>();

app.UseRouting();
app.MapControllers();

app.Run();
