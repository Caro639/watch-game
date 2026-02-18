using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WatchGame.Models;
using System.Text.Encodings.Web;

namespace WatchGame.Controllers;

public class HelloWorldController : Controller
{
    // 
    // GET: /HelloWorld/
    public IActionResult Index()
    {
        return View();
    }
    // 
    // GET: /HelloWorld/Welcome/ 
    // Requires using System.Text.Encodings.Web;
    public string Welcome(string name, int ID = 1)
    {
        return HtmlEncoder.Default.Encode($"Hello {name}, ID: {ID}");
    }
}