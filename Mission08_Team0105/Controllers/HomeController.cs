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
        ViewBag.Quadrants = _context.Quadrants
            .OrderBy(x=> x.QuadrantName)
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
                    
            return View("AddEditTask", response);
        }
        else
        {
            ViewBag.Quadrants = _context.Quadrants
                .OrderBy(x=> x.QuadrantName)
                .ToList();
            
            return View(response); 
        }
    }
    
    [HttpGet]
    public IActionResult Edit(int id)
    {
        var recordToEdit = _context.Tasks
            .Single(x => x.TaskId == id);
        
        ViewBag.Quadrants = _context.Quadrants
            .OrderBy(x=> x.QuadrantName)
            .ToList();
        
        return View("AddEditTask", recordToEdit);
    }

    [HttpPost]
    public IActionResult Edit(Task updatedInfo)
    {
        _context.Update(updatedInfo);
        _context.SaveChanges(); 
        
        return RedirectToAction("TBD");
    }
    
    
}