using System.ComponentModel.DataAnnotations;

namespace ContactWebAPI.Models;

public class User : BaseModel
{
    public User(string name, string password)
    {
        this.Name = name;
        this.Password = password;

    }
    public int Id { get; set; }
    public string Name { get; set; }
    public string Password { get; set; }

}

public class UserCreateDto
{
    public UserCreateDto(string name, string password)
    {
        this.Name = name;
        this.Password = password;

    }
    [Required]
    public string Name { get; set; }
    [Required]
    public string Password { get; set; }
}