using Microsoft.EntityFrameworkCore;
using TodoApi.Infrastructure.Database;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddDbContext<MyDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/users", (MyDbContext dbContext) =>
{
    return dbContext.Users.ToList();
});

app.MapPost("/users", async (MyDbContext dbContext, User user) =>
{
    await dbContext.Users.AddAsync(user);
    await dbContext.SaveChangesAsync();
    return Results.Created($"/users/{user.Id}", user);
});

app.Run();