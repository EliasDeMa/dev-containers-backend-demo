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

        modelBuilder.Entity<User>().HasData(
            new User { Id = 1, Name = "Alice" },
            new User { Id = 2, Name = "Bob" }
        );

        modelBuilder.Entity<ToDoItem>().HasData(
            new ToDoItem { Id = 1, UserId = 1, Title = "Buy groceries", IsCompleted = false },
            new ToDoItem { Id = 2, UserId = 1, Title = "Finish report", IsCompleted = true },
            new ToDoItem { Id = 3, UserId = 2, Title = "Walk the dog", IsCompleted = false }
        );
        base.OnModelCreating(modelBuilder);
    }
}
