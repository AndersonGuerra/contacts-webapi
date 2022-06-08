using System.ComponentModel.DataAnnotations;

namespace ContactWebAPI.Models;

public class Post : BaseModel
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Text { get; set; }
    public User Author { get; set; }
}

public class PostCreateDto
{
    public PostCreateDto(string title, string text)
    {
        Title = title;
        Text = text;
    }

    [Required]
    public string Title { get; set; }
    [Required]
    public string Text { get; set; }
}

public class PostUpdateDto
{
    public PostUpdateDto(string title, string text)
    {
        Title = title;
        Text = text;
    }

    public string Title { get; set; }

    public string Text { get; set; }
}

public class PostResponseDto
{
    public PostResponseDto(int id, string title, string text)
    {
        Id = id;
        Title = title;
        Text = text;
    }

    public int Id { get; set; }
    public string Title { get; set; }
    public string Text { get; set; }
}