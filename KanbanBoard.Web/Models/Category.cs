using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using KanbanBoard.Web.Models;

namespace KanbanBoard.Web.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;

        public ICollection<TodoTask> Tasks { get; set; } = new List<TodoTask>();
    }
}