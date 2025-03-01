using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mission08_Team0105.Models;
using Task = Mission08_Team0105.Models.Task;

// using Task = System.Threading.Tasks.Task;

namespace Mission08_Team0105.Controllers;

public class HomeController : Controller
{
    private TaskContext _context;

    public HomeController(TaskContext temp)
    {
        _context = temp;
    }

    public IActionResult Index()
    {
        return View();
    }
    
    
    [HttpGet]
    public IActionResult AddEditTask()
    {
        ViewBag.Categories = _context.Categories
            .OrderBy(x=> x.CategoryName)
            .ToList();
        
        return View("AddEditTask", new Task());
    }
    
    [HttpPost]
    public IActionResult AddEditTask(Task response)
    {
        if (ModelState.IsValid)
        {
            _context.Tasks.Add(response);
                _context.SaveChanges();
                    
                return View("Confirmation", response);
        }
        else
        {
            ViewBag.Categories = _context.Categories
                .OrderBy(x=> x.CategoryName)
                .ToList();
            
            return View(response); 
        }
    }
    
    [HttpGet]
    public IActionResult Edit(int id)
    {
        var recordToEdit = _context.Tasks
            .Single(x => x.TaskId == id);
        
        ViewBag.Quadrants = _context.Categories
            .OrderBy(x=> x.CategoryName)
            .ToList();
        
        return View("AddEditTask", recordToEdit);
    }

    [HttpPost]
    public IActionResult Edit(Task updatedInfo)
    {
        _context.Update(updatedInfo);
        _context.SaveChanges(); 
        
        return RedirectToAction("Quadrants");
    }
    
    public IActionResult Quadrants()
    {
        var taskList = _context.Tasks
            .Include(x=>x.Category)
            .ToList();
        
        return View(taskList);
    }
    
    [HttpGet]
    public IActionResult Delete(int id)
    {
        var recordToDelete = _context.Tasks
            .Single(x => x.TaskId == id);
        
        return View(recordToDelete);
    }

    [HttpPost]
    public IActionResult Delete(Task record)
    {
        _context.Tasks.Remove(record);
        _context.SaveChanges();
        
        return RedirectToAction("Quadrants");
    }
    
    
}