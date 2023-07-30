﻿namespace ServicesLifetime.Middlewares;

public static class MyMiddlewareExtensions
{
    public static IApplicationBuilder UseMyMiddleware(this IApplicationBuilder builder)
    {
        return builder
            .UseMiddleware<ExceptionMiddleware>()
            .UseMiddleware<MyMiddleware>();
    }
}