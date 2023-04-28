using ToDoAPI.Data;

namespace ToDoAPI.Services.Interface
{
    public interface IUserServices
    {
        Task<User> CreateUser(User user);
        Task<LoginResponse> Login(string username, string password);
    }
}
