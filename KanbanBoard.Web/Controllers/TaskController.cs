using KanbanBoard.Web.Data;
using KanbanBoard.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KanbanBoard.Web.Controllers
{
    public class TaskController : Controller
    {
        private readonly AppDbContext _db;

        public TaskController(AppDbContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.Categories = await _db.Categories.ToListAsync();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TodoTask task)
        {
            // Remove Category from ModelState since it's a navigation property
            ModelState.Remove("Category");

            if (ModelState.IsValid)
            {
                task.CreatedAt = DateTime.UtcNow;
                _db.Tasks.Add(task);
                await _db.SaveChangesAsync();
                return RedirectToAction("Index", "Home");
            }

            // Re-populate categories if model validation fails
            ViewBag.Categories = await _db.Categories.ToListAsync();
            return View(task);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var task = await _db.Tasks.FindAsync(id);
            if (task == null)
            {
                return NotFound();
            }

            // Add categories for dropdown
            ViewBag.Categories = await _db.Categories.ToListAsync();
            return View(task);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, TodoTask task)
        {
            if (id != task.Id)
                return NotFound();

            // Remove Category from ModelState since it's a navigation property
            ModelState.Remove("Category");

            if (ModelState.IsValid)
            {
                try
                {
                    // Don't update CreatedAt
                    var existingTask = await _db.Tasks.FindAsync(id);
                    if (existingTask == null)
                    {
                        return NotFound();
                    }

                    existingTask.Title = task.Title;
                    existingTask.Description = task.Description;
                    existingTask.Status = task.Status;
                    existingTask.Priority = task.Priority;
                    existingTask.DueDate = task.DueDate;
                    existingTask.CategoryId = task.CategoryId;

                    await _db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TaskExists(task.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index", "Home");
            }

            // Re-populate categories if model validation fails
            ViewBag.Categories = await _db.Categories.ToListAsync();
            return View(task);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var task = await _db.Tasks
                .Include(t => t.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (task == null)
            {
                return NotFound();
            }

            return View(task);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var task = await _db.Tasks.FindAsync(id);
            if (task != null)
            {
                _db.Tasks.Remove(task);
                await _db.SaveChangesAsync();
            }
            return RedirectToAction("Index", "Home");
        }

        private bool TaskExists(int id)
        {
            return _db.Tasks.Any(e => e.Id == id);
        }
    }
}