using SERVER.CORE.DTOs.Users;

namespace SERVER.CORE.Interface
{
    public interface IUserRepository
    {
        Task<IEnumerable<UserResponse>> GetAllUsers();
        Task<UserResponse> GetUserById(int id);
        Task<int> AddUser(CreateRequest user);
        // void UpdateUser(User user);
        // void DeleteUser(int id);
    }
}
