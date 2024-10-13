using AspNetJsonHash.Api.Endpoints;
using AspNetJsonHash.Api.JsonHashes;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("AspNetJsonHash.Tests")]
[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton(typeof(IJsonHash<>), typeof(SHA256Json<>));

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGroup("/objects")
    .MapMyObjectsApi()
    .WithTags("My Objects Endpoints");

app.Run();

internal record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}

public partial class Program
{ }
