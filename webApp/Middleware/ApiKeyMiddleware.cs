namespace webApp.Middleware
{
    public class ApiKeyMiddleware
    {
        private readonly RequestDelegate _next;
        private const string APIKEY = "x-api-key"; // Заголовок, который будет содержать API ключ

        public ApiKeyMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {

            // Проверка только для маршрута /api
            if (!context.Request.Path.StartsWithSegments("/api"))
            {
                await _next(context);
                return;
            }

            // Проверка ключа в параметрах
            Console.WriteLine("Сработало middleware");

            // Получаем значения реф ключа из .env
            var appSettings = context.RequestServices.GetRequiredService<IConfiguration>();
            var apiKey = appSettings.GetValue<string>(APIKEY);

            // Получаем ключ из параметров строки
            var key = context.Request.Query["x-api-key"];
            Console.WriteLine($"Значение key {key}/{apiKey}");


            if (string.IsNullOrEmpty(key))
            {
                context.Response.StatusCode = 401; // Unauthorized
                await context.Response.WriteAsync("Unauthorized client.");
                return;
            }

            if (!key.Equals(apiKey))
            {
                context.Response.StatusCode = 401; // Unauthorized
                await context.Response.WriteAsync("Unauthorized client.");
                return;
            }


            Console.WriteLine($"Обнаружен ключ {key}");

            /*
            // Проверка ключа в header
            if (!context.Request.Headers.TryGetValue(APIKEY, out var extractedApiKey))
            {
                context.Response.StatusCode = 401; // Unauthorized
                await context.Response.WriteAsync("Unauthorized client.");
                return;
            }

            // Сравните предоставленный ключ с вашим ключом
            var appSettings = context.RequestServices.GetRequiredService<IConfiguration>();
            var apiKey = appSettings.GetValue<string>(APIKEY);

            if (!apiKey.Equals(extractedApiKey))
            {
                context.Response.StatusCode = 401; // Unauthorized
                await context.Response.WriteAsync("Unauthorized client.");
                return;
            }
            */

            await _next(context);
        }


    }
}
