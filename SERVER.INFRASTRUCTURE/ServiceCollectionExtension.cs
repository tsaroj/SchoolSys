namespace SERVER.INFRASTRUCTURE
{
    public static class ServiceCollectionExtension
    {
        public ServiceCollectionExtension(this IServiceCollection service,IConfiguration configuration)
        {
            services.AddTransient<IUserServices, UserServices>();
            Services.AddTransient<IUserRepository,UserRepository>();
        }
    }
}