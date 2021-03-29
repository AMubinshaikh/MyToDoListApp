using Microsoft.EntityFrameworkCore;
using MyTodoApp_ISG.Model;

namespace MyTodoApp_ISG.Model {

    public class TodoDbContext : DbContext {
        public TodoDbContext () { }

        public TodoDbContext (DbContextOptions<TodoDbContext> options) : base (options) { }

        public DbSet<Todo> Todos { get; set; }

    }
}