using Microsoft.Data.Entity;

namespace TodoApp.Models
{
    public class TodoAppContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }
        
        public DbSet<Task> Tasks { get; set; }
    }
}