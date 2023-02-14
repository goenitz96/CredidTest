using Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CREDIDMVC.Controllers;

public class UserController : Controller
{
    private readonly IUserService _userService;
    
    public UserController(IUserService userService)
    {
        _userService = userService;
    }
    public async Task<IActionResult> Index()
    {
        var data = await _userService.getUsers();
        return View(data);
    }
}