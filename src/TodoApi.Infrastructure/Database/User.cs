namespace TodoApi.Infrastructure.Database;

public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public virtual List<ToDoItem> TodoItems { get; set; }

    public User()
    {
        TodoItems = new List<ToDoItem>();
    }
}
