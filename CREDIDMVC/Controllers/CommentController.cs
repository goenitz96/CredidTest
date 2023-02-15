using Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CREDIDMVC.Controllers;

public class CommentController : Controller
{
    private readonly ICommentService _commentService;

    public CommentController(ICommentService commentService)
    {
        _commentService = commentService;
    }

    public async Task<IActionResult> Index()
    {
        var data = await _commentService.getComments();
        return View(data);
    }
    
    public async Task<IActionResult> Search(string name, string body)
    {
        return View(await _commentService.searchByNameOrBody(name, body));
    }
}