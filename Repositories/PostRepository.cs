using ContactWebAPI.Database;
using ContactWebAPI.Models;

namespace ContactWebAPI.Repositories;

public class PostRepository : IPostRepository
{
    ApplicationContext _applicationContext;

    public PostRepository(ApplicationContext applicationContext)
    {
        _applicationContext = applicationContext;
    }

    public Post CreatePost(PostCreateDto postCreateDto)
    {
        Post post = new()
        {
            Title = postCreateDto.Title,
            Text = postCreateDto.Text
        };
        _applicationContext.Posts.Add(post);
        _applicationContext.SaveChanges();
        return post;
    }

    public Post DeletePost(int id)
    {
        Post post = GetPostById(id);
        _applicationContext.Posts.Remove(post);
        _applicationContext.SaveChanges();
        return post;
    }

    public Post GetPostById(int id)
    {
        var post = _applicationContext.Posts.Where(x => x.Id == id).First();
        return post;
    }

    public List<Post> GetPosts()
    {
        var posts = _applicationContext.Posts.ToList();
        return posts;
    }

    public Post UpdatePost(int id, PostUpdateDto postUpdateDto)
    {
        Post post = GetPostById(id);
        post.Title = postUpdateDto.Title;
        post.Text = postUpdateDto.Text;
        _applicationContext.Update(post);
        _applicationContext.SaveChanges();
        return post;
    }
}