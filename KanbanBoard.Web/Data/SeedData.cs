using KanbanBoard.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace KanbanBoard.Web.Data
{
    public static class SeedData
    {
        public static void Initialize(AppDbContext context)
        {
            context.Database.Migrate();

            if (context.Tasks.Any())
            {
            }

            context.Tasks.AddRange(
                new TodoTask { Title = "Set up project", Status = TodoTaskStatus.Done, DueDate = DateTime.Today },
                new TodoTask { Title = "Design Kanban board UI", Status = TodoTaskStatus.InProgress, DueDate = DateTime.Today.AddDays(3) },
                new TodoTask { Title = "Implement Create Task", Status = TodoTaskStatus.ToDo, DueDate = DateTime.Today.AddDays(7) }
            );

            context.SaveChanges();
        }
    }
}
