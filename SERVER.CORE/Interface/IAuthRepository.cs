using SERVER.UTIL.Helper;

namespace SERVER.CORE.Interface;

public interface IAuthRepository
{
    Task<string> Authentication(Login login);
}