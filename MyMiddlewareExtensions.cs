namespace ServicesLifetime;

public static class MyMiddlewareExtensions
{
    public static IApplicationBuilder UseMyMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<MyMiddleware>().UseMiddleware<MyMiddleware2>();
    }
}