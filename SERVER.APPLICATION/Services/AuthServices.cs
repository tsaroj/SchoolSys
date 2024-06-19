using SERVER.APPLICATION.Interface;
using SERVER.UTIL.Helper;

namespace SERVER.APPLICATION.Services
{
    public class AuthServices : IAuthServices
    {
        public Task<JsonResponse> Authentication(Login login)
        {
            throw new NotImplementedException();
        }
    }
}