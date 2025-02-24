using Microsoft.EntityFrameworkCore;

namespace TodoApi.Infrastructure.Database;

public class MyDbContext : DbContext
{
    public DbSet<ToDoItem> ToDoItems { get; set; }
    public DbSet<User> Users { get; set; }

    public MyDbContext(DbContextOptions<MyDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(MyDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}
