
using SERVER.CORE.DTOs.Users;
using SERVER.UTIL.Helper;

namespace SERVER.APPLICATION.Services
{
    public interface IUserServices
    {
        Task<JsonResponse> GetAllUsers();
        Task<JsonResponse> GetUserById(int id);
        Task<JsonResponse> AddUser(CreateRequest user);
        // void UpdateUser(User user);
        // void DeleteUser(int id);

    }
}