using Microsoft.AspNetCore.Mvc;

namespace ContactWebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class PostController : ControllerBase
{
    private readonly ILogger<PostController> _logger;

    public PostController(ILogger<PostController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public IActionResult Index(){
        return Ok();
    }
}