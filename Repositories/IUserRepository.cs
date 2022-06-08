using ContactWebAPI.Models;
using Microsoft.AspNetCore.JsonPatch;

namespace ContactWebAPI.Repositories;

public interface IUserRepository
{
    public List<User> GetAllUsers();
    public User GetUserById(int id);
    public User CreateUser(UserCreateDto userCreateDto);
    public User UpdateUser(int id, UserUpdateDto userUpdateDto);
    public User DeleteUser(int id);
}
