using ContactWebAPI.Database;
using ContactWebAPI.Models;
using Microsoft.AspNetCore.JsonPatch;

namespace ContactWebAPI.Repositories;
public class UserRepository : IUserRepository
{

    ApplicationContext _applicationContext;

    public UserRepository(ApplicationContext applicationContext)
    {
        _applicationContext = applicationContext;
    }

    public User CreateUser(UserCreateDto userCreateDto)
    {
        var salt = BCrypt.Net.BCrypt.GenerateSalt(10);
        var hashedPassword = BCrypt.Net.BCrypt.HashPassword(userCreateDto.Password, salt);
        User user = new(userCreateDto.Name, userCreateDto.Email, hashedPassword);
        _applicationContext.Users.Add(user);
        _applicationContext.SaveChanges();
        return user;
    }

    public User UpdateUser(int id, UserUpdateDto userUpdateDto)
    {
        var salt = BCrypt.Net.BCrypt.GenerateSalt(10);
        var hashedPassword = BCrypt.Net.BCrypt.HashPassword(userUpdateDto.Password, salt);
        User user = GetUserById(id);
        user.Name = userUpdateDto.Name;
        user.Email = userUpdateDto.Email;
        user.Password = hashedPassword;
        _applicationContext.Update(user);
        _applicationContext.SaveChanges();
        return user;
    }

    public List<User> GetUsers()
    {
        return _applicationContext.Users.ToList();
    }

    public User GetUserById(int id)
    {
        User user = _applicationContext.Users.Where(x => x.Id == id).First();
        return user;
    }

    public User DeleteUser(int id)
    {
        User user = GetUserById(id);
        _applicationContext.Users.Remove(user);
        _applicationContext.SaveChanges();
        return user;
    }


}
