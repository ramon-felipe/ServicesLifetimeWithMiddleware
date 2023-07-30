using Microsoft.AspNetCore.Builder;
using ServicesLifetime;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IWeatherService, WeatherService>();
builder.Services.AddScoped<IAnotherService, AnotherService>();

builder.Services.AddTransient<IOperationTransient, Operation>();
builder.Services.AddScoped<IOperationScoped, Operation>();
builder.Services.AddSingleton<IOperationSingleton, Operation>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseMyMiddleware();

app.MapGet("/{id:int}", (int id) =>
{
    Console.WriteLine($"Hello World!: {id}");
});

app.MapGet("/GetWeatherForecast", (IWeatherService service, IAnotherService anotherService) =>
{
    var w1 = service.GetWeather();
    Console.WriteLine("Weather obtained!");
    _ = service.GetWeather();

    anotherService.Run();
    anotherService.Run();

    return w1;
});

app.Run();
