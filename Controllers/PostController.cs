using ContactWebAPI.Models;
using ContactWebAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ContactWebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class PostController : ControllerBase
{
    private readonly ILogger<PostController> _logger;
    private readonly IPostRepository _postRepository;

    public PostController(ILogger<PostController> logger, IPostRepository postRepository)
    {
        _logger = logger;
        _postRepository = postRepository;
    }

    [HttpGet]
    public IActionResult Index()
    {
        var posts = _postRepository.GetPosts();
        return Ok(posts);
    }

    [HttpPost]
    public IActionResult Create(PostCreateDto postCreate)
    {
        Post post = _postRepository.CreatePost(postCreate);
        return Ok(post);
    }

}