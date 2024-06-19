using SERVER.UTIL.Helper;

namespace SERVER.APPLICATION.Interface
{
    public interface IAuthServices
    {
        Task<JsonResponse> Authentication(Login login);
    }
}