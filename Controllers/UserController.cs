using ContactWebAPI.Models;
using ContactWebAPI.Repositories;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace ContactWebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly ILogger<UserController> _logger;
    private readonly IUserRepository _userRepository;

    public UserController(ILogger<UserController> logger, IUserRepository userRepository)
    {
        _logger = logger;
        _userRepository = userRepository;
    }

    [HttpGet]
    public IActionResult Index()
    {
        var users = _userRepository.GetUsers().Select(x => new UserResponseDto(x.Name, x.Email));
        return Ok(users);
    }
    [HttpPost]
    public IActionResult Create(UserCreateDto user)
    {
        User createdUser = _userRepository.CreateUser(user);
        UserResponseDto userResponse = new(user.Name, user.Email);
        return Ok(userResponse);
    }
    [HttpPut]
    [Route("{id}")]
    public IActionResult Update(int id, UserUpdateDto userUpdate) {
        User user = _userRepository.UpdateUser(id, userUpdate);
        UserResponseDto userResponse = new(user.Name, user.Email);
        return Ok(userResponse);
    }

    [HttpGet]
    [Route("{id}")]
    public IActionResult GetById(int id)
    {
        try
        {
            User user = _userRepository.GetUserById(id);
            UserResponseDto userResponse = new(user.Name, user.Email);
            return Ok(userResponse);
        }
        catch (System.InvalidOperationException)
        {
            return NotFound();
        }
    }

    [HttpDelete]
    [Route("{id}")]
    public IActionResult Delete(int id)
    {
        User user = _userRepository.DeleteUser(id);
        UserResponseDto userResponse = new(user.Name, user.Email);
        return Ok(userResponse);
    }
}
