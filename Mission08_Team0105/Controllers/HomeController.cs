using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
// using Mission08_Team0105.Models;

namespace Mission08_Team0105.Controllers;

public class HomeController : Controller
{
    
    public IActionResult Index()
    {
        return View();
    }
    [HttpGet]
    public IActionResult AddEditTask()
    {
        return View();
    }
    
    // [HttpPost]
    // public IActionResult AddEdit-Task()
    // {
    //     return View();
    // }
    
    
}