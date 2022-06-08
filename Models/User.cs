using System.ComponentModel.DataAnnotations;

namespace ContactWebAPI.Models;

public class User : BaseModel
{
    public User(string name, string email, string password)
    {
        this.Name = name;
        this.Email = email;
        this.Password = password;

    }
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }

}

public class UserCreateDto
{
    public UserCreateDto(string name, string email, string password)
    {
        this.Name = name;
        this.Email = email;
        this.Password = password;

    }
    [Required]
    public string Name { get; set; }
    [Required]
    [EmailAddress]
    public string Email { get; set; }
    [Required]
    public string Password { get; set; }
}

public class UserUpdateDto
{
    public UserUpdateDto(string name, string email, string password)
    {
        this.Name = name;
        this.Email = email;
        this.Password = password;

    }
    public string Name { get; set; }
    [EmailAddress]
    public string Email { get; set; }
    public string Password { get; set; }
}

public class UserResponseDto
{
    public UserResponseDto(string name, string email)
    {
        this.Name = name;
        this.Email = email;

    }
    [Required]
    public string Name { get; set; }
    [Required]
    [EmailAddress]
    public string Email { get; set; }
}