using Microsoft.EntityFrameworkCore;
using TodoApi.Infrastructure.Database;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<MyDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// get argument from command line


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();

    // run migrations
    using var scope = app.Services.CreateScope();
    var dbContext = scope.ServiceProvider.GetRequiredService<MyDbContext>();

    if (args.Contains("delete")) 
    {
        dbContext.Database.ExecuteSqlRaw("DROP SCHEMA public CASCADE; CREATE SCHEMA public;");
    }
    else 
    {
        dbContext.Database.Migrate();
    }
}