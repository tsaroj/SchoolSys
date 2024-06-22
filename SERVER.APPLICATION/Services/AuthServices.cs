using System.Runtime.InteropServices;
using SERVER.APPLICATION.Interface;
using SERVER.CORE.Interface;
using SERVER.UTIL.Helper;

namespace SERVER.APPLICATION.Services
{
    public class AuthServices : IAuthServices
    {
        private readonly IAuthRepository _auth;

        public AuthServices(IAuthRepository auth)
        {
            _auth = auth;
        }
        public async Task<JsonResponse> Authentication(Login login)
        {
            JsonResponse response = new();
            try
            {
                response.Result = await _auth.Authentication(login);
                response.IsSuccess = true;
                response.IsValid = true;
                response.IsToken = true;
                response.Status = 200;
            }
            catch (SEHException ex)
            {
                response.IsSuccess = false;
                response.IsValid = false;
                response.Error = ex.Message;
                response.Status = ex.ErrorCode;
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.IsValid = false;
                response.Error = ex.Message;
                response.Status = 500;
            }
            return response;
        }
    }
}