using SERVER.CORE.Entities;

namespace SERVER.CORE.Interface;

public interface IJwtRepository
{
    string Token(User user);
}