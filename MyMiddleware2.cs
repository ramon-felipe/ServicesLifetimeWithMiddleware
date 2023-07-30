namespace ServicesLifetime;

public class MyMiddleware2
{
    private readonly RequestDelegate _next;
    private readonly ILogger _logger;


    public MyMiddleware2(RequestDelegate next, ILogger<MyMiddleware2> logger)
    {
        _logger = logger;
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        _logger.LogInformation("Second middleware call...");

        await context.Response.WriteAsync("Hello from second middleware", CancellationToken.None);
        await _next(context);

        _logger.LogInformation("Second middleware call finished.");
    }
}