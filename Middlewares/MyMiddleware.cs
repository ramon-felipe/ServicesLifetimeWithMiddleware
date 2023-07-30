namespace ServicesLifetime.Middlewares;

public class MyMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger _logger;

    private readonly IOperationSingleton _singletonOperation;

    public MyMiddleware(RequestDelegate next, ILogger<MyMiddleware> logger, IOperationSingleton singletonOperation)
    {
        _logger = logger;
        _singletonOperation = singletonOperation;
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context, IOperationTransient transientOperation, IOperationScoped scopedOperation)
    {
        _logger.LogInformation("Transient: {res}", transientOperation.OperationId);
        _logger.LogInformation("Scoped: {res}", scopedOperation.OperationId);
        _logger.LogInformation("Singleton: {res}", _singletonOperation.OperationId);

        await _next(context);

        _logger.LogInformation("First middleware call finished.");
    }
}