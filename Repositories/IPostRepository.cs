using ContactWebAPI.Models;

namespace ContactWebAPI.Repositories;

public interface IPostRepository
{
    public List<Post> GetPosts();
    public Post GetPostById(int id);
    public Post CreatePost(PostCreateDto postCreateDto);
    public Post UpdatePost(int id, PostUpdateDto postUpdateDto);
    public Post DeletePost(int id);
}
