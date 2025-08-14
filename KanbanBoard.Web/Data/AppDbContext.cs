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
    }
}
