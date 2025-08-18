using System.ComponentModel.DataAnnotations;

namespace KanbanBoard.Web.Models
{
     public enum TodoTaskStatus { ToDo, InProgress, Done }

    public class TodoTask
    {
            public int Id { get; set; }
            [Required]
            public string Title { get; set; } = string.Empty;

            public string? Description { get; set; }

            public TodoTaskStatus Status { get; set; } = TodoTaskStatus.ToDo;

            public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

            [DataType(DataType.Date)]
            public DateTime? DueDate { get; set; }
            public string Priority { get; set; } = "Medium";
    }
}

