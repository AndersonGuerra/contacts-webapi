using ContactWebAPI.Models;
using ContactWebAPI.Repositories;
using ContactWebAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace ContactWebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController : ControllerBase
{
    private readonly ILogger<UserController> _logger;
    private readonly IUserRepository _userRepository;
    private readonly ITokenService _tokenService;
    private readonly IConfiguration _config;

    public AuthController(ILogger<UserController> logger, IUserRepository userRepository, ITokenService tokenService, IConfiguration config)
    {
        _logger = logger;
        _userRepository = userRepository;
        _tokenService = tokenService;
        _config = config;
    }

    [Route("login")]
    [HttpPost]
    public IActionResult Index(UserLoginDto userLogin)
    {
        User user = _userRepository.GetUserByEmail(userLogin.Email);
        var validPassword = BCrypt.Net.BCrypt.Verify(userLogin.Password, user.Password);
        if (!validPassword)
        {
            return Unauthorized();
        }
        UserResponseDto userResponse = new(user.Name, user.Email);
        var token = _tokenService.BuildToken(_config["Jwt:Key"].ToString(), _config["Jwt:Issuer"].ToString(), userResponse);
        return Ok(new
        {
            Token = token
        });
    }
}