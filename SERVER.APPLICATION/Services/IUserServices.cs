
using SERVER.UTIL.Helper;

namespace SERVER.APPLICATION.Services
{
    public interface IUserServices
    {
        Task<JsonResponse> GetAllUsers();
        Task<JsonResponse> GetUserById(int id);
        // Task<int> AddUser(User user);
        // void UpdateUser(User user);
        // void DeleteUser(int id);

    }
}