using webApp.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

// �������� API ���� � ������������ (��������, � appsettings.json ��� ��� ���������� �����)
builder.Configuration["x-api-key"] = "your_secret_key_here";

var app = builder.Build();

// ������������� middleware ��� �������� ����� API
app.UseMiddleware<ApiKeyMiddleware>();

app.UseRouting();
app.MapControllers();

app.Run();
