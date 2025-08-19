using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using KanbanBoard.Web.Models;

public class Category
{
    public int Id { get; set; }

    [Required]
    [MaxLength(50)]
    public string Name { get; set; }

    public ICollection<TodoTask> Tasks { get; set; }
}
