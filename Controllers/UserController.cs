using ContactWebAPI.Database;
using ContactWebAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace ContactWebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly ILogger<UserController> _logger;
    private readonly ApplicationContext _applicationContext;

    public UserController(ILogger<UserController> logger, ApplicationContext applicationContext)
    {
        _applicationContext = applicationContext;
        _logger = logger;
    }

    [HttpGet]
    public IActionResult Index()
    {
        var users = _applicationContext.Users.ToList();
        return Ok(users);
    }
    [HttpPost]
    public IActionResult Create(UserCreateDto user){
        Console.WriteLine(user.Name);
        return Ok();
    }
}
