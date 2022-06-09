using ContactWebAPI.Models;

namespace ContactWebAPI.Repositories;

public interface IUserRepository
{
    public List<User> GetUsers();
    public User GetUserById(int id);
    public User GetUserByEmail(string email);
    public User CreateUser(UserCreateDto userCreateDto);
    public User UpdateUser(int id, UserUpdateDto userUpdateDto);
    public User DeleteUser(int id);
}
