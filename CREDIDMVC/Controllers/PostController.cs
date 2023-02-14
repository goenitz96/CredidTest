using Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CREDIDMVC.Controllers;

public class PostController : Controller
{
    private readonly IPostService _postService;

    public PostController(IPostService postService)
    {
        _postService = postService;
    }

    public async Task<IActionResult> Index()
    {
        var data= await _postService.getPosts();
        return View(data);
    }
}