using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoApp.Models;

namespace ToDoApp.Controllers;

public class ToDoController : Controller
{
    private readonly ApplicationDbContext _context;

    public ToDoController(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<ViewResult> Index()
    {
        var model = await _context.ToDos
            .OrderByDescending(t => t.Content)
            .ToListAsync();

        return View(model);
    }

    public ViewResult Add()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Add(ToDo toDo)
    {
        if (ModelState.IsValid)
        {
            _context.ToDos.Add(toDo);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        return View(toDo);
    }

    public async Task<ViewResult> Edit(int id)
    {
        var todo = await _context.ToDos.FindAsync(id);
        return View(todo);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(ToDo toDo)
    {
        if (ModelState.IsValid)
        {
            _context.ToDos.Update(toDo);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
        return View(toDo);
    }

    public async Task<ViewResult> Remove(int id)
    {
        var todo = await _context.ToDos.FindAsync(id);
        return View(todo);
    }

    [HttpPost]
    public async Task<IActionResult> Remove(ToDo toDo)
    {
        _context.ToDos.Remove(toDo);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
}