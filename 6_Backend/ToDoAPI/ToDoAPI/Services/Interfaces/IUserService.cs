using ToDoAPI.Data;

namespace ToDoAPI.Services.Interfaces
{
    public interface IUserService
    {
        Task Register(User model);
        Task<LoginResponse> Login(string username, string password);
    }
}
