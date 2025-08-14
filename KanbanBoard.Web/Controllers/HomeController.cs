using KanbanBoard.Web.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KanbanBoard.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _dbContext;
        public HomeController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IActionResult> Index()
        {
            var tasks = await _dbContext.Tasks
                                 .OrderBy(t => t.Status)
                                 .ToListAsync();
            return View(tasks);
        }
    }
}
