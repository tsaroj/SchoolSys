using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using SERVER.APPLICATION.Interface;
using SERVER.APPLICATION.Services;
using SERVER.CORE.DTOs;
using SERVER.CORE.Interface;
using SERVER.INFRASTRUCTURE.Repositories;

namespace SERVER.INFRASTRUCTURE;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection RegisterServices(this IServiceCollection services,IConfiguration configuration)
    {
        
        services.AddAutoMapper(typeof(MapingConfig));
        services.AddTransient<IUserServices, UserServices>();
        services.AddTransient<IUserRepository, UserRepository>();
        services.AddTransient<IAuthServices, AuthServices>();
        services.AddTransient<IAuthRepository, AuthRepository>();
        services.AddTransient<IJwtRepository, JwtRepository>();
        services.AddHttpContextAccessor();
        
  
        return services;
    }
}
