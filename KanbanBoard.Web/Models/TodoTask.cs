namespace KanbanBoard.Web.Models
{
     public enum TaskStatus { ToDo, InProgress, Done }

    public class TodoTask
    {
            public int Id { get; set; }

            public string Title { get; set; } = string.Empty;

            public string? Description { get; set; }

            public TaskStatus Status { get; set; } = TaskStatus.ToDo;

            public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

            public DateTime? DueDate { get; set; }
    }
}

