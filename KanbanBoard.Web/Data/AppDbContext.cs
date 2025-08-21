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
        public DbSet<Category> Categories { get; set; } = default!;

      
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TodoTask>()
                .HasOne(t => t.Category)
                .WithMany(c => c.Tasks)
                .HasForeignKey(t => t.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<Category>()
                .Property(c => c.Name)
                .IsRequired()                  
                .HasMaxLength(50);              

            modelBuilder.Entity<TodoTask>()
                .Property(t => t.Title)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<TodoTask>()
                .Property(t => t.Description)
                .HasMaxLength(500);             

            modelBuilder.Entity<TodoTask>()
                .Property(t => t.Priority)
                .IsRequired()
                .HasDefaultValue("Medium");     
           
            modelBuilder.Entity<TodoTask>()
                .HasIndex(t => t.Status)        
                .HasDatabaseName("IX_Tasks_Status");

            modelBuilder.Entity<TodoTask>()
                .HasIndex(t => t.CategoryId)    
                .HasDatabaseName("IX_Tasks_CategoryId");

  
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Work" },
                new Category { Id = 2, Name = "Personal" },
                new Category { Id = 3, Name = "Shopping" },
                new Category { Id = 4, Name = "Health" },
                new Category { Id = 5, Name = "Learning" }
            );

            modelBuilder.Entity<TodoTask>().HasData(
                new TodoTask
                {
                    Id = 1,
                    Title = "Build Kanban Board",
                    Description = "Create a fully functional kanban board with drag & drop",
                    Status = TodoTaskStatus.InProgress,
                    Priority = "High",
                    CategoryId = 5, // Learning
                    DueDate = new DateTime(2025, 9, 1),
                    CreatedAt = new DateTime(2025, 8, 15, 10, 0, 0, DateTimeKind.Utc)
                },
                new TodoTask
                {
                    Id = 2,
                    Title = "Buy Groceries",
                    Description = "Milk, eggs, bread, vegetables, fruits",
                    Status = TodoTaskStatus.ToDo,
                    Priority = "Medium",
                    CategoryId = 3, // Shopping
                    DueDate = new DateTime(2025, 8, 21),
                    CreatedAt = new DateTime(2025, 8, 20, 14, 30, 0, DateTimeKind.Utc)
                },
                new TodoTask
                {
                    Id = 3,
                    Title = "Call Mom",
                    Description = "Weekly check-in call with family",
                    Status = TodoTaskStatus.Done,
                    Priority = "High",
                    CategoryId = 2, // Personal
                    DueDate = new DateTime(2025, 8, 19),
                    CreatedAt = new DateTime(2025, 8, 18, 16, 0, 0, DateTimeKind.Utc)
                },
                new TodoTask
                {
                    Id = 4,
                    Title = "Prepare Quarterly Report",
                    Description = "Compile sales data and performance metrics",
                    Status = TodoTaskStatus.ToDo,
                    Priority = "High",
                    CategoryId = 1, // Work
                    DueDate = new DateTime(2025, 8, 30),
                    CreatedAt = new DateTime(2025, 8, 20, 9, 0, 0, DateTimeKind.Utc)
                },
                new TodoTask
                {
                    Id = 5,
                    Title = "Gym Workout",
                    Description = "Cardio and strength training session",
                    Status = TodoTaskStatus.InProgress,
                    Priority = "Medium",
                    CategoryId = 4, // Health
                    DueDate = new DateTime(2025, 8, 21),
                    CreatedAt = new DateTime(2025, 8, 20, 18, 0, 0, DateTimeKind.Utc)
                },
                new TodoTask
                {
                    Id = 6,
                    Title = "Learn Entity Framework",
                    Description = "Study EF Core relationships and migrations",
                    Status = TodoTaskStatus.Done,
                    Priority = "High",
                    CategoryId = 5, // Learning
                    DueDate = new DateTime(2025, 8, 18),
                    CreatedAt = new DateTime(2025, 8, 15, 11, 0, 0, DateTimeKind.Utc)
                }
            );
        }
    }
}