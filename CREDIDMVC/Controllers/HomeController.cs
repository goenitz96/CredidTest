using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CREDIDMVC.Models;

namespace CREDIDMVC.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public string GetIpAddress()  
    {
        HttpRequest request = HttpContext.Request;
        var ipv4 =request.HttpContext.Connection.LocalIpAddress.ToString();
        return ipv4;
    } 
    
    public string GetUserAgent()  
    {
        HttpRequest request = HttpContext.Request;
        var userAgent = request.Headers["User-Agent"].ToString();
        return userAgent;
    }
    
    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}