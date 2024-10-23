using KaihokoApi.Models;
using KaihokoApi.Services;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.Configure<MongDbDataBaseSettings>(
    builder.Configuration.GetSection("MongoKaihokoDatabase"));
builder.Services.AddSingleton<CategoryDataService>();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference(options=>{
        options.Title = "Kaihoko API";
        options.WithDefaultHttpClient(ScalarTarget.CSharp,ScalarClient.HttpClient);
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
