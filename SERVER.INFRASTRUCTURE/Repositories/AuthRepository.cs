using Dapper;
using Microsoft.Extensions.Configuration;
using Npgsql;
using SERVER.CORE.Entities;
using SERVER.CORE.Interface;
using SERVER.QUERY.query;
using SERVER.UTIL.Helper;
using BCryptNet = BCrypt.Net.BCrypt;

namespace SERVER.INFRASTRUCTURE.Repositories;
public class AuthRepository:IAuthRepository
{
    private readonly IJwtRepository _jwt;
    private readonly string? _connectionString;
    public AuthRepository(IConfiguration configuration,IJwtRepository jwt)
    {
        _jwt = jwt;
        _connectionString = configuration.GetConnectionString("DbConnString");
    }

    public async Task<string> Authentication(Login login)
    {
        using (NpgsqlConnection connection = new(_connectionString))
        {
            await connection.OpenAsync();
            var  user = await connection.QuerySingleOrDefaultAsync<User>(AuthQuery.UserByUSerName, new { UserName = login.UserName });
            
            if (user != null)
            {
                if (!BCryptNet.Verify(login.Password, user.Password)) {
                    return "invalid username and password";
                }
                else
                {
                    var updateLogin = new User()
                    {
                        Id = user.Id,
                        UpdatedAt = DateTime.Now,
                        LastLogin = DateTime.Now,
                        LoginCount = (user.LoginCount ?? 0) + 1,
                        Otp = await GetOtp()  
                    };
                    var loginUpdates = await connection.ExecuteAsync(AuthQuery.UpdataLogin, updateLogin);
                    if (loginUpdates >0)
                    {
                        var token = _jwt.Token(user);
                        return token;
                    }
                    return "Error";
                }
            }
        }
        return "User not found";
    }
    
    private Task<string> GetOtp()
    {
        Random random = new();
        string randomString = random.Next(100000, 1000000).ToString();
        return Task.FromResult(randomString);
    }
}