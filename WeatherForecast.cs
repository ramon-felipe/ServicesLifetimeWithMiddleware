using System;

namespace ServicesLifetime;

public class WeatherForecast
{
    public DateOnly Date { get; set; }

    public int TemperatureC { get; set; }

    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

    public string? Summary { get; set; }
}

public interface IWeatherService
{
    WeatherForecast GetWeather();
}

public class WeatherService : IWeatherService
{
    private readonly ILogger<WeatherService> _logger;

    private readonly IOperationSingleton _singletonOperation;
    private readonly IOperationScoped _scopedOperation;
    private readonly IOperationTransient _transientOperation;

    private static string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    public WeatherService(ILogger<WeatherService> logger, IOperationSingleton singletonOperation, IOperationScoped scopedOperation, IOperationTransient transientOperation)
    {
        _logger = logger;

        _singletonOperation = singletonOperation;
        _scopedOperation = scopedOperation;
        _transientOperation = transientOperation;
    }

    public WeatherForecast GetWeather()
    {
        var w = new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(Random.Shared.NextInt64(20))),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        };

        _logger.LogInformation("Transient: {res}", _transientOperation.OperationId);
        _logger.LogInformation("Scoped: {res}", _scopedOperation.OperationId);
        _logger.LogInformation("Singleton: {res}", _singletonOperation.OperationId);

        return w;
    }
}