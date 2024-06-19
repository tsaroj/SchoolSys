using System.Runtime.InteropServices;
using SERVER.CORE.Interface;
using SERVER.UTIL.Helper;

namespace SERVER.APPLICATION.Services
{
    public class UserServices(IUserRepository userRepository ) : IUserServices
    {
        private readonly IUserRepository _userRepository = userRepository;

        public async Task<JsonResponse> GetAllUsers()
        {
            JsonResponse response  = new();
            try
            {
                response.IsSuccess = true;
                response.IsValid = true;
                response.Result = await _userRepository.GetAllUsers();
                response.Status = 200;
                response.Message = "Data Fetched Successfully !!";
            }
            catch(SEHException ex)
            {
                response.IsSuccess = false;
                response.IsValid = false;
                response.Status =  ex.ErrorCode;
                response.Message = ex.Message;
            }
            catch (Exception ex)
            {
                 response.IsSuccess = false;
                response.IsValid = false;
                response.Status =  500;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<JsonResponse> GetUserById(int id)
        {
            JsonResponse response  = new();
            try
            {
                response.IsSuccess = true;
                response.IsValid = true;
                response.Result = await _userRepository.GetUserById(id);
                response.Status = 200;
                response.Message = "Data Fetched Successfully !!";
            }
            catch(SEHException ex)
            {
                response.IsSuccess = false;
                response.IsValid = false;
                response.Status =  ex.ErrorCode;
                response.Message = ex.Message;
            }
            catch (Exception ex)
            {
                 response.IsSuccess = false;
                response.IsValid = false;
                response.Status =  500;
                response.Message = ex.Message;
            }
            return response;
        }
    }
}