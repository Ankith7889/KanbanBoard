using KanbanBoard.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace KanbanBoard.Web.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        
        public DbSet<TodoTask> Tasks { get; set; } = default!;
        public DbSet<Category> Categories { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed Categories
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Work" },
                new Category { Id = 2, Name = "Personal" },
                new Category { Id = 3, Name = "Shopping" }
            );

            // Seed Tasks
            modelBuilder.Entity<TodoTask>().HasData(
                new TodoTask { Id = 1, Title = "Build Kanban Board", Status = TodoTaskStatus.ToDo, CategoryId = 1 },
                new TodoTask { Id = 2, Title = "Buy Groceries", Status = TodoTaskStatus.InProgress, CategoryId = 3 },
                new TodoTask { Id = 3, Title = "Call Mom", Status =TodoTaskStatus.Done, CategoryId = 2 }
            );
        }

    }
}
